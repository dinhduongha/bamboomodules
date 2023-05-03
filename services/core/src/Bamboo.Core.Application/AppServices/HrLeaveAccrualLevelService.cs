
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
public partial class HrLeaveAccrualLevelAppService :
    CrudAppService<HrLeaveAccrualLevel, HrLeaveAccrualLevel, long, PagedAndSortedResultRequestDto>,
    IHrLeaveAccrualLevelAppService
{
    private readonly IDataFilter _dataFilter;

    public HrLeaveAccrualLevelAppService(IDataFilter dataFilter, IRepository<HrLeaveAccrualLevel, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
