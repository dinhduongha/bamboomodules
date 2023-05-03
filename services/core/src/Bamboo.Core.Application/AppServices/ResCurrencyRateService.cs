
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
public partial class ResCurrencyRateAppService :
    CrudAppService<ResCurrencyRate, ResCurrencyRate, Guid, PagedAndSortedResultRequestDto>,
    IResCurrencyRateAppService
{
    private readonly IDataFilter _dataFilter;

    public ResCurrencyRateAppService(IDataFilter dataFilter, IRepository<ResCurrencyRate, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
