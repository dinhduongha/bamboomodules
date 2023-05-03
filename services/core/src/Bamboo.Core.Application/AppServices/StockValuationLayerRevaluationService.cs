
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
public partial class StockValuationLayerRevaluationAppService :
    CrudAppService<StockValuationLayerRevaluation, StockValuationLayerRevaluation, Guid, PagedAndSortedResultRequestDto>,
    IStockValuationLayerRevaluationAppService
{
    private readonly IDataFilter _dataFilter;

    public StockValuationLayerRevaluationAppService(IDataFilter dataFilter, IRepository<StockValuationLayerRevaluation, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
