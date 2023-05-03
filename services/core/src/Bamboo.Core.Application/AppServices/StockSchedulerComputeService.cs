
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
public partial class StockSchedulerComputeAppService :
    CrudAppService<StockSchedulerCompute, StockSchedulerCompute, Guid, PagedAndSortedResultRequestDto>,
    IStockSchedulerComputeAppService
{
    private readonly IDataFilter _dataFilter;

    public StockSchedulerComputeAppService(IDataFilter dataFilter, IRepository<StockSchedulerCompute, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
