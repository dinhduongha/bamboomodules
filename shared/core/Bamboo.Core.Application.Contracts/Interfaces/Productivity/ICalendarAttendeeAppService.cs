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
    public interface ICalendarAttendeeAppService : IGenericApplicationService<CalendarAttendee>
    {
        Task<CalendarAttendee> DoAcceptAsync(Guid[] ids);
        Task<CalendarAttendee> DoDeclineAsync(Guid[] ids);
        Task<CalendarAttendee> DoTentativeAsync(Guid[] ids);
    }
}