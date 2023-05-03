
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
public partial class AccountFiscalPositionAccountTemplateAppService :
    CrudAppService<AccountFiscalPositionAccountTemplate, AccountFiscalPositionAccountTemplate, Guid, PagedAndSortedResultRequestDto>,
    IAccountFiscalPositionAccountTemplateAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountFiscalPositionAccountTemplateAppService(IDataFilter dataFilter, IRepository<AccountFiscalPositionAccountTemplate, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
