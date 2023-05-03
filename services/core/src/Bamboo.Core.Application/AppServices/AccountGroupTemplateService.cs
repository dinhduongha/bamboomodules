
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
public partial class AccountGroupTemplateAppService :
    CrudAppService<AccountGroupTemplate, AccountGroupTemplate, Guid, PagedAndSortedResultRequestDto>,
    IAccountGroupTemplateAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountGroupTemplateAppService(IDataFilter dataFilter, IRepository<AccountGroupTemplate, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
