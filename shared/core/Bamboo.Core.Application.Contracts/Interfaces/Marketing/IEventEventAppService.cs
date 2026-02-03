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
    public interface IEventEventAppService : IGenericApplicationService<EventEvent>
    {
        Task<EventEvent> CopyDataAsync(EventEventCopyDataRequestDto input);
        Task<EventEvent> CopyEventMenusAsync(EventEventCopyEventMenusRequestDto input);
        Task<EventEvent> GenerateLeadsAsync(EventEventGenerateLeadsRequestDto input);
        Task<EventEvent> GetBackendMenuIdAsync(Guid[] ids);
        Task<EventEvent> GetKioskUrlAsync(Guid[] ids);
        Task<EventEvent> GetSlotTicketsAvailabilityPosAsync(EventEventGetSlotTicketsAvailabilityPosRequestDto input);
        Task<EventEvent> GoogleMapLinkAsync(EventEventGoogleMapLinkRequestDto input);
        Task<EventEvent> InviteContactsAsync(Guid[] ids);
        Task<EventEvent> MassMailingAttendeesAsync(Guid[] ids);
        Task<EventEvent> MassMailingTrackSpeakersAsync(Guid[] ids);
        Task<EventEvent> OpenSlotCalendarAsync(Guid[] ids);
        Task<EventEvent> SetDoneAsync(Guid[] ids);
        Task<EventEvent> ToggleBoothMenuAsync(EventEventToggleBoothMenuRequestDto input);
        Task<EventEvent> ToggleExhibitorMenuAsync(EventEventToggleExhibitorMenuRequestDto input);
        Task<EventEvent> ToggleWebsiteMenuAsync(EventEventToggleWebsiteMenuRequestDto input);
        Task<EventEvent> ToggleWebsiteTrackAsync(EventEventToggleWebsiteTrackRequestDto input);
        Task<EventEvent> ToggleWebsiteTrackProposalAsync(EventEventToggleWebsiteTrackProposalRequestDto input);
        Task<EventEvent> ViewLinkedOrdersAsync(Guid[] ids);
    }
}