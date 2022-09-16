using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LanguageTechnologyRepository : EfRepositoryBase<LanguageTechnology,BaseDbContext> , ILanguageTechnologyRepository
{
    public LanguageTechnologyRepository(BaseDbContext context) : base(context)
    {
    }
}