
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
public partial class AccountAccountTypeAppService :
    CrudAppService<AccountAccountType, AccountAccountType, long, PagedAndSortedResultRequestDto>,
    IAccountAccountTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountAccountTypeAppService(IDataFilter dataFilter, IRepository<AccountAccountType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
