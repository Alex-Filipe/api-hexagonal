using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Hexagonal.Adapters.ORM.EFCore.Repositories;

public class SectorRepository(EFContext context, IMapper mapper) : ISectorRepository
{
    public async Task<Sector> GetByIdAsync(int id)
    {
        var sectorModel = await context.Sectors
            .FirstOrDefaultAsync(s => s.Id == id);

        return mapper.Map<Sector>(sectorModel);
    }
}