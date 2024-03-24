using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticRepository;
using ElasticV7;
using ElasticV8;
using Nest;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IElasticClient>(p =>
{
    Nest.ElasticClient ex = new(new Uri("http://localhost:9200"));

    return ex;
});

builder.Services.AddSingleton<ElasticsearchClient>(p =>
{
    ElasticsearchClientSettings settings = new(new Uri("https://localhost:9200"));

    _ = settings.CertificateFingerprint("0bc4633005b8ab6e7f39af8b46980f3a543e5db2bace85506f87fb6292773db4");
    _ = settings.DefaultIndex("product");
    _ = settings.Authentication(new BasicAuthentication("elastic", "7CYfLjL1+lZWoFVEd7I-"));

    ElasticsearchClient ec = new(settings);

    return ec;
});

builder.Services.AddKeyedSingleton<IElasticRepository, Ev8>("v8");
builder.Services.AddKeyedSingleton<IElasticRepository, Ev7>("v7");

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

string[] summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (IHttpContextAccessor context, IConfiguration configuration) =>
    {
        IElasticRepository repo = GetStrategy(context, configuration["EVersion"]);

        IReadOnlyCollection<IProduct> p = await repo.AdvancedSearchAsync("1");

        foreach (IProduct product in p)
        {
            Console.WriteLine(product.DisplayName());
        }

        return p;
    })
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

static IElasticRepository GetStrategy(IHttpContextAccessor context, string strategy)
{
    return strategy switch
    {
        "v8" => context.HttpContext.RequestServices.GetRequiredKeyedService<IElasticRepository>("v8"),
        "v7" => context.HttpContext.RequestServices.GetRequiredKeyedService<IElasticRepository>("v7"),
        _ => throw new Exception("fds"),
    };
}