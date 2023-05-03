
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
public partial class AccountTaxGroupAppService :
    CrudAppService<AccountTaxGroup, AccountTaxGroup, Guid, PagedAndSortedResultRequestDto>,
    IAccountTaxGroupAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountTaxGroupAppService(IDataFilter dataFilter, IRepository<AccountTaxGroup, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
