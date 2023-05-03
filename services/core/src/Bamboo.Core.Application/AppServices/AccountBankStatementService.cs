
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
public partial class AccountBankStatementAppService :
    CrudAppService<AccountBankStatement, AccountBankStatement, Guid, PagedAndSortedResultRequestDto>,
    IAccountBankStatementAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountBankStatementAppService(IDataFilter dataFilter, IRepository<AccountBankStatement, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
