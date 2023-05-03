
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
public partial class AccountFiscalYearAppService :
    CrudAppService<AccountFiscalYear, AccountFiscalYear, Guid, PagedAndSortedResultRequestDto>,
    IAccountFiscalYearAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountFiscalYearAppService(IDataFilter dataFilter, IRepository<AccountFiscalYear, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
