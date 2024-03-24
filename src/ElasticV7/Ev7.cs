using ElasticRepository;
using Nest;

namespace ElasticV7
{
    public class Ev7(IElasticClient client) : IElasticRepository
    {
        public async Task<IReadOnlyCollection<IProduct>> AdvancedSearchAsync(string searchedValue)
        {
            Console.WriteLine("V7");

            ISearchResponse<Product> searchResponse = await client.SearchAsync<Product>(s => s
                    .Index("product")
                    .Query(q => q
                        .QueryString(qs => qs
                            .Query("*123*")
                        )
                    )
                    .From(0)
                    .Size(10)
                    .Sort(so => so) // Adjust sort if needed
            );

            foreach (Product searchResponseDocument in searchResponse.Documents)
            {
                Console.WriteLine(searchResponseDocument.Cnk);
            }

            return searchResponse.Documents;
        }
    }
}