
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
public partial class AccountCashRoundingAppService :
    CrudAppService<AccountCashRounding, AccountCashRounding, Guid, PagedAndSortedResultRequestDto>,
    IAccountCashRoundingAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountCashRoundingAppService(IDataFilter dataFilter, IRepository<AccountCashRounding, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
