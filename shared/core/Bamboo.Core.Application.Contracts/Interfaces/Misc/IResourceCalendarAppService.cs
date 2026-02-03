using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResourceCalendarAppService : IGenericAppService<ResourceCalendar>
    {
        Task<ResourceCalendar> CopyDataAsync(ResourceCalendarCopyDataRequestDto input);
        Task<ResourceCalendar> GetWorkDurationDataAsync(ResourceCalendarGetWorkDurationDataRequestDto input);
        Task<ResourceCalendar> GetWorkHoursCountAsync(ResourceCalendarGetWorkHoursCountRequestDto input);
        Task<ResourceCalendar> PlanDaysAsync(ResourceCalendarPlanDaysRequestDto input);
        Task<ResourceCalendar> PlanHoursAsync(ResourceCalendarPlanHoursRequestDto input);
        Task<ResourceCalendar> SwitchBasedOnDurationAsync(Guid[] ids);
        Task<ResourceCalendar> SwitchCalendarTypeAsync(Guid[] ids);
        Task<ResourceCalendar> TransferLeavesToAsync(ResourceCalendarTransferLeavesToRequestDto input);
    }
}