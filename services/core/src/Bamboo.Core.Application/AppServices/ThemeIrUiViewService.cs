
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
public partial class ThemeIrUiViewAppService :
    CrudAppService<ThemeIrUiView, ThemeIrUiView, long, PagedAndSortedResultRequestDto>,
    IThemeIrUiViewAppService
{
    private readonly IDataFilter _dataFilter;

    public ThemeIrUiViewAppService(IDataFilter dataFilter, IRepository<ThemeIrUiView, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
