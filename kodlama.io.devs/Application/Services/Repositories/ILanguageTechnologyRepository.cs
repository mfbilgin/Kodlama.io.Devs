using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ILanguageTechnologyRepository : IAsyncRepository<LanguageTechnology>, IRepository<LanguageTechnology>
{
}