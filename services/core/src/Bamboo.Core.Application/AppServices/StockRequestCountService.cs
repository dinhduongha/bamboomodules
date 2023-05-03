
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
public partial class StockRequestCountAppService :
    CrudAppService<StockRequestCount, StockRequestCount, Guid, PagedAndSortedResultRequestDto>,
    IStockRequestCountAppService
{
    private readonly IDataFilter _dataFilter;

    public StockRequestCountAppService(IDataFilter dataFilter, IRepository<StockRequestCount, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
