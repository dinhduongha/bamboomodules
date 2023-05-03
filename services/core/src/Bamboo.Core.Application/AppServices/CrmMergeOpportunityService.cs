
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
public partial class CrmMergeOpportunityAppService :
    CrudAppService<CrmMergeOpportunity, CrmMergeOpportunity, Guid, PagedAndSortedResultRequestDto>,
    ICrmMergeOpportunityAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmMergeOpportunityAppService(IDataFilter dataFilter, IRepository<CrmMergeOpportunity, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
