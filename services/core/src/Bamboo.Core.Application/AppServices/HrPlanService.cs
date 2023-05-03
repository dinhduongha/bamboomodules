
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
public partial class HrPlanAppService :
    CrudAppService<HrPlan, HrPlan, Guid, PagedAndSortedResultRequestDto>,
    IHrPlanAppService
{
    private readonly IDataFilter _dataFilter;

    public HrPlanAppService(IDataFilter dataFilter, IRepository<HrPlan, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
