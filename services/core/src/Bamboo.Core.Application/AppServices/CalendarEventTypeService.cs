
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
public partial class CalendarEventTypeAppService :
    CrudAppService<CalendarEventType, CalendarEventType, long, PagedAndSortedResultRequestDto>,
    ICalendarEventTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public CalendarEventTypeAppService(IDataFilter dataFilter, IRepository<CalendarEventType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
