
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
public partial class HrLeaveStressDayAppService :
    CrudAppService<HrLeaveStressDay, HrLeaveStressDay, Guid, PagedAndSortedResultRequestDto>,
    IHrLeaveStressDayAppService
{
    private readonly IDataFilter _dataFilter;

    public HrLeaveStressDayAppService(IDataFilter dataFilter, IRepository<HrLeaveStressDay, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
