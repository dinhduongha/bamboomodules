
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
public partial class AccountAgedTrialBalanceAppService :
    CrudAppService<AccountAgedTrialBalance, AccountAgedTrialBalance, Guid, PagedAndSortedResultRequestDto>,
    IAccountAgedTrialBalanceAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountAgedTrialBalanceAppService(IDataFilter dataFilter, IRepository<AccountAgedTrialBalance, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
