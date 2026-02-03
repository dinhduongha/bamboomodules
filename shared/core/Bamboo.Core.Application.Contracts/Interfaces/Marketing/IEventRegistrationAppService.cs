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
    public interface IEventRegistrationAppService : IGenericAppService<EventRegistration>
    {
        Task<EventRegistration> CancelAsync(Guid[] ids);
        Task<EventRegistration> ConfirmAsync(Guid[] ids);
        Task<EventRegistration> RegisterAttendeeAsync(EventRegistrationRegisterAttendeeRequestDto input);
        Task<EventRegistration> SendBadgeEmailAsync(Guid[] ids);
        Task<EventRegistration> SetDoneAsync(Guid[] ids);
        Task<EventRegistration> SetDraftAsync(Guid[] ids);
        Task<EventRegistration> ViewPosOrderAsync(Guid[] ids);
        Task<EventRegistration> ViewSaleOrderAsync(Guid[] ids);
    }
}