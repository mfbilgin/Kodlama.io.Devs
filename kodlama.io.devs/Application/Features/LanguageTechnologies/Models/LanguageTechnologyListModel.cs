using Application.Features.LanguageTechnologies.Dtos;
using Core.Persistence.Paging;


namespace Application.Features.LanguageTechnologies.Models;

public class LanguageTechnologyListModel : BasePageableModel
{
    public IList<LanguageTechnologyListDto> Items { get; set; }
}