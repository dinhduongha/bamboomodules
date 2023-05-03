
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
public partial class AccountCommonAccountReportAppService :
    CrudAppService<AccountCommonAccountReport, AccountCommonAccountReport, Guid, PagedAndSortedResultRequestDto>,
    IAccountCommonAccountReportAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountCommonAccountReportAppService(IDataFilter dataFilter, IRepository<AccountCommonAccountReport, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
