
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
public partial class CrmIapLeadRoleAppService :
    CrudAppService<CrmIapLeadRole, CrmIapLeadRole, long, PagedAndSortedResultRequestDto>,
    ICrmIapLeadRoleAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmIapLeadRoleAppService(IDataFilter dataFilter, IRepository<CrmIapLeadRole, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
