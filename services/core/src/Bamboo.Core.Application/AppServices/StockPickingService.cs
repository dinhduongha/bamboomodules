
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
public partial class StockPickingAppService :
    CrudAppService<StockPicking, StockPicking, Guid, PagedAndSortedResultRequestDto>,
    IStockPickingAppService
{
    private readonly IDataFilter _dataFilter;

    public StockPickingAppService(IDataFilter dataFilter, IRepository<StockPicking, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
