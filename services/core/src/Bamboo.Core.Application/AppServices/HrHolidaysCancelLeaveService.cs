
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
public partial class HrHolidaysCancelLeaveAppService :
    CrudAppService<HrHolidaysCancelLeave, HrHolidaysCancelLeave, Guid, PagedAndSortedResultRequestDto>,
    IHrHolidaysCancelLeaveAppService
{
    private readonly IDataFilter _dataFilter;

    public HrHolidaysCancelLeaveAppService(IDataFilter dataFilter, IRepository<HrHolidaysCancelLeave, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
