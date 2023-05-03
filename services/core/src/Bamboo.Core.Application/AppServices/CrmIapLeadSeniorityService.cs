
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
public partial class CrmIapLeadSeniorityAppService :
    CrudAppService<CrmIapLeadSeniority, CrmIapLeadSeniority, long, PagedAndSortedResultRequestDto>,
    ICrmIapLeadSeniorityAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmIapLeadSeniorityAppService(IDataFilter dataFilter, IRepository<CrmIapLeadSeniority, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
