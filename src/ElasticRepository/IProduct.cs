namespace ElasticRepository;

/// <summary>
/// Object mapped to elastic index
/// </summary>
public interface IProduct
{
    string? Cnk { get; set; }

    string? ShortFr { get; set; }

    string? LongFr { get; set; }

    string? ShortNl { get; set; }

    string? LongNl { get; set; }

    string? CommercialStatus { get; set; }

    public string DisplayName()
    {
        return $"{Cnk} {LongFr}";
    }
}