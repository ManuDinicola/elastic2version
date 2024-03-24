namespace ElasticRepository;

public interface IElasticRepository
{
    public Task<IReadOnlyCollection<IProduct>> AdvancedSearchAsync(string searchedValue);
}