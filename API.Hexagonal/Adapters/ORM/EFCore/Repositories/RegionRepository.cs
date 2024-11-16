using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Hexagonal.Adapters.ORM.EFCore.Repositories;

public class RegionRepository(EFContext context, IMapper mapper) : IRegionRepository
{
    public async Task<Region> GetByIdAsync(int id)
    {
        var regionModel = await context.Regions
            .FirstOrDefaultAsync(r => r.Id == id);

        return mapper.Map<Region>(regionModel);
    }
}