using Application.Features.CreateLanguage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.CreateLanguage.Models;

public class LanguageListModel : BasePageableModel
{
    public IList<LanguageListDto>? Items { get; set; }
}