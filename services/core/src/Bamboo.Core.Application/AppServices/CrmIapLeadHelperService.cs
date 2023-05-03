
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
public partial class CrmIapLeadHelperAppService :
    CrudAppService<CrmIapLeadHelper, CrmIapLeadHelper, Guid, PagedAndSortedResultRequestDto>,
    ICrmIapLeadHelperAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmIapLeadHelperAppService(IDataFilter dataFilter, IRepository<CrmIapLeadHelper, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
