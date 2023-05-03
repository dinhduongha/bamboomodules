
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
public partial class ThemeWebsiteMenuAppService :
    CrudAppService<ThemeWebsiteMenu, ThemeWebsiteMenu, long, PagedAndSortedResultRequestDto>,
    IThemeWebsiteMenuAppService
{
    private readonly IDataFilter _dataFilter;

    public ThemeWebsiteMenuAppService(IDataFilter dataFilter, IRepository<ThemeWebsiteMenu, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
