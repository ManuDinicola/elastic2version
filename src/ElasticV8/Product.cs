using ElasticRepository;
using System.Text.Json.Serialization;

namespace ElasticV8
{
    /// <summary>
    /// Object mapped to elastic index
    /// </summary>
    public class Product : IProduct
    {
        [JsonPropertyName("cnk")]
        public string? Cnk { get; set; }

        [JsonPropertyName("shortfr")]
        public string? ShortFr { get; set; }

        [JsonPropertyName("longfr")]
        public string? LongFr { get; set; }

        [JsonPropertyName("shortnl")]
        public string? ShortNl { get; set; }

        [JsonPropertyName("longnl")]
        public string? LongNl { get; set; }

        [JsonPropertyName("commercialstatus")]
        public string? CommercialStatus { get; set; }
    }
}