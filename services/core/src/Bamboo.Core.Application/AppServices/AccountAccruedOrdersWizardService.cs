
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
public partial class AccountAccruedOrdersWizardAppService :
    CrudAppService<AccountAccruedOrdersWizard, AccountAccruedOrdersWizard, Guid, PagedAndSortedResultRequestDto>,
    IAccountAccruedOrdersWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountAccruedOrdersWizardAppService(IDataFilter dataFilter, IRepository<AccountAccruedOrdersWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
