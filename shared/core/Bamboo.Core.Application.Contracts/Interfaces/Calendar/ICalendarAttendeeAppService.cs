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
    public interface ICalendarAttendeeAppService : IGenericApplicationService<CalendarAttendee>
    {
        Task<CalendarAttendee> DoAcceptAsync(Guid id);
        Task<CalendarAttendee> DoDeclineAsync(Guid id);
        Task<CalendarAttendee> DoTentativeAsync(Guid id);
    }
}