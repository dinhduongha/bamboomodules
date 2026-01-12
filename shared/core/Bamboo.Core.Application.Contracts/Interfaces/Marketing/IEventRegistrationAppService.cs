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
    public interface IEventRegistrationAppService : IGenericApplicationService<EventRegistration>
    {
        Task<EventRegistration> CancelAsync(Guid id);
        Task<EventRegistration> ConfirmAsync(Guid id);
        Task<EventRegistration> RegisterAttendeeAsync(Guid id, EventRegistrationRegisterAttendeeRequestDto input);
        Task<EventRegistration> SendBadgeEmailAsync(Guid id);
        Task<EventRegistration> SetDoneAsync(Guid id);
        Task<EventRegistration> SetDraftAsync(Guid id);
        Task<EventRegistration> ViewPosOrderAsync(Guid id);
        Task<EventRegistration> ViewSaleOrderAsync(Guid id);
    }
}