
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
public partial class AccountAccountTagAppService :
    CrudAppService<AccountAccountTag, AccountAccountTag, long, PagedAndSortedResultRequestDto>,
    IAccountAccountTagAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountAccountTagAppService(IDataFilter dataFilter, IRepository<AccountAccountTag, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
