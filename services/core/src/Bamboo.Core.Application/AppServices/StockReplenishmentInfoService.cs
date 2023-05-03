
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
public partial class StockReplenishmentInfoAppService :
    CrudAppService<StockReplenishmentInfo, StockReplenishmentInfo, Guid, PagedAndSortedResultRequestDto>,
    IStockReplenishmentInfoAppService
{
    private readonly IDataFilter _dataFilter;

    public StockReplenishmentInfoAppService(IDataFilter dataFilter, IRepository<StockReplenishmentInfo, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
