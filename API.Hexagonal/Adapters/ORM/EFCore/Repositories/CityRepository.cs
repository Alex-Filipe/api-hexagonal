using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Hexagonal.Adapters.ORM.EFCore.Repositories;

public class CityRepository(EFContext context, IMapper mapper) : ICityRepository
{
    public async Task<City> GetByIdAsync(int id)
    {
        var cityModel = await context.Cities
            .FirstOrDefaultAsync(c => c.Id == id);

        return mapper.Map<City>(cityModel);
    }
}