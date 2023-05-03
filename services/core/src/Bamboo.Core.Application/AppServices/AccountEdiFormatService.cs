
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
public partial class AccountEdiFormatAppService :
    CrudAppService<AccountEdiFormat, AccountEdiFormat, long, PagedAndSortedResultRequestDto>,
    IAccountEdiFormatAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountEdiFormatAppService(IDataFilter dataFilter, IRepository<AccountEdiFormat, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
