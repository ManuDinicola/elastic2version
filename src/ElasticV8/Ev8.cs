using Elastic.Clients.Elasticsearch;
using ElasticRepository;

namespace ElasticV8
{
    public class Ev8(ElasticsearchClient client) : IElasticRepository
    {
        public async Task<IReadOnlyCollection<IProduct>> AdvancedSearchAsync(string searchedValue)
        {
            Console.WriteLine("V8");

            SearchResponse<Product> searchResponse = await client.SearchAsync<Product>(s => s
                    .Index("product")
                    .Query(q => q
                        .QueryString(qs => qs
                            .Query("*123*")
                        )
                    )
                    .From(0)
                    .Size(10)
            );

            foreach (Product searchResponseDocument in searchResponse.Documents)
            {
                Console.WriteLine(searchResponseDocument.Cnk);
            }

            return searchResponse.Documents;
        }
    }
}