
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
public partial class AccountCommonReportAppService :
    CrudAppService<AccountCommonReport, AccountCommonReport, Guid, PagedAndSortedResultRequestDto>,
    IAccountCommonReportAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountCommonReportAppService(IDataFilter dataFilter, IRepository<AccountCommonReport, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
