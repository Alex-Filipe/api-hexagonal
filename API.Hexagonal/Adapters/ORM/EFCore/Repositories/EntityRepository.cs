using API.Hexagonal.Domain.Repositories;

namespace API.Hexagonal.Adapters.ORM.EFCore.Repositories;

public class EntityRepository : IEntityRepository
{
    public async Task<T> GetRequiredEntityAsync<T, TKey>(
        Func<TKey, Task<T>> getByIdFunc, TKey id, string entityName)
        where T : class
    {
        var entity = await getByIdFunc(id);
        if (entity == null)
        {
            throw new Exception($"{entityName} com ID '{id}' não foi encontrada.");
        }
        return entity;
    }
}