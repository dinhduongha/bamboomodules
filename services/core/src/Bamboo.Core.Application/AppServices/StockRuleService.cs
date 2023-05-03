
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
public partial class StockRuleAppService :
    CrudAppService<StockRule, StockRule, Guid, PagedAndSortedResultRequestDto>,
    IStockRuleAppService
{
    private readonly IDataFilter _dataFilter;

    public StockRuleAppService(IDataFilter dataFilter, IRepository<StockRule, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
