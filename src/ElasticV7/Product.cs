using ElasticRepository;
using Nest;

namespace ElasticV7
{
    /// <summary>
    /// Object mapped to elastic index
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Gets or sets Cnk
        /// </summary>
        [Text(Name = "cnk")]
        public string? Cnk { get; set; }

        /// <summary>
        /// Gets or sets ShortFr
        /// </summary>
        [Text(Name = "shortfr")]
        public string? ShortFr { get; set; }

        /// <summary>
        /// Gets or sets LongFr
        /// </summary>
        [Text(Name = "longfr")]
        public string? LongFr { get; set; }

        /// <summary>
        /// Gets or sets ShortNl
        /// </summary>
        [Text(Name = "shortnl")]
        public string? ShortNl { get; set; }

        /// <summary>
        /// Gets or sets LongNl
        /// </summary>
        [Text(Name = "longnl")]
        public string? LongNl { get; set; }

        /// <summary>
        /// Gets or sets CommercialStatus
        /// </summary>
        [Text(Name = "commercialstatus")]
        public string? CommercialStatus { get; set; }
    }
}