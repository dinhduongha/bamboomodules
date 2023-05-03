
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
public partial class StockTrackConfirmationAppService :
    CrudAppService<StockTrackConfirmation, StockTrackConfirmation, Guid, PagedAndSortedResultRequestDto>,
    IStockTrackConfirmationAppService
{
    private readonly IDataFilter _dataFilter;

    public StockTrackConfirmationAppService(IDataFilter dataFilter, IRepository<StockTrackConfirmation, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
