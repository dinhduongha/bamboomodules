
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
public partial class AccountAnalyticPlanAppService :
    CrudAppService<AccountAnalyticPlan, AccountAnalyticPlan, Guid, PagedAndSortedResultRequestDto>,
    IAccountAnalyticPlanAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountAnalyticPlanAppService(IDataFilter dataFilter, IRepository<AccountAnalyticPlan, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
