
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
public partial class SpreadsheetDashboardGroupAppService :
    CrudAppService<SpreadsheetDashboardGroup, SpreadsheetDashboardGroup, long, PagedAndSortedResultRequestDto>,
    ISpreadsheetDashboardGroupAppService
{
    private readonly IDataFilter _dataFilter;

    public SpreadsheetDashboardGroupAppService(IDataFilter dataFilter, IRepository<SpreadsheetDashboardGroup, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
