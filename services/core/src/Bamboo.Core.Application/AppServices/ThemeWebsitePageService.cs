
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Models;

namespace Bamboo.Core.Services;

//[Authorize]
public partial class ThemeWebsitePageAppService :
    CrudAppService<ThemeWebsitePage, ThemeWebsitePage, long, PagedAndSortedResultRequestDto>,
    IThemeWebsitePageAppService
{
    private readonly IDataFilter _dataFilter;

    public ThemeWebsitePageAppService(IDataFilter dataFilter, IRepository<ThemeWebsitePage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
