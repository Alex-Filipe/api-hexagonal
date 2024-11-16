namespace API.Hexagonal.Domain.Repositories;

public interface IEntityRepository
{
    Task<T> GetRequiredEntityAsync<T, TKey>(Func<TKey, Task<T>> getByIdFunc, TKey id, string entityName) where T : class;
}