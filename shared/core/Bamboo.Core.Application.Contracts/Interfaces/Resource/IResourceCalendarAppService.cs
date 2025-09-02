using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResourceCalendarAppService : IGenericApplicationService<ResourceCalendar>
    {
        Task<ResourceCalendar> CopyDataAsync(Guid id, ResourceCalendarCopyDataRequestDto input);
        Task<ResourceCalendar> GetWorkDurationDataAsync(Guid id, ResourceCalendarGetWorkDurationDataRequestDto input);
        Task<ResourceCalendar> GetWorkHoursCountAsync(Guid id, ResourceCalendarGetWorkHoursCountRequestDto input);
        Task<ResourceCalendar> OpenContractsAsync(Guid id);
        Task<ResourceCalendar> PlanDaysAsync(Guid id, ResourceCalendarPlanDaysRequestDto input);
        Task<ResourceCalendar> PlanHoursAsync(Guid id, ResourceCalendarPlanHoursRequestDto input);
        Task<ResourceCalendar> SwitchCalendarTypeAsync(Guid id);
        Task<ResourceCalendar> TransferLeavesToAsync(Guid id, ResourceCalendarTransferLeavesToRequestDto input);
    }
}