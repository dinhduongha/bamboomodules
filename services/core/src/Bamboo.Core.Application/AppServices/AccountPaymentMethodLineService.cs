
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
public partial class AccountPaymentMethodLineAppService :
    CrudAppService<AccountPaymentMethodLine, AccountPaymentMethodLine, Guid, PagedAndSortedResultRequestDto>,
    IAccountPaymentMethodLineAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountPaymentMethodLineAppService(IDataFilter dataFilter, IRepository<AccountPaymentMethodLine, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
