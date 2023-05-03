
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
public partial class StockPackageDestinationAppService :
    CrudAppService<StockPackageDestination, StockPackageDestination, Guid, PagedAndSortedResultRequestDto>,
    IStockPackageDestinationAppService
{
    private readonly IDataFilter _dataFilter;

    public StockPackageDestinationAppService(IDataFilter dataFilter, IRepository<StockPackageDestination, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
