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
        Task<EventEvent> CopyDataAsync(Guid id, EventEventCopyDataRequestDto input);
        Task<EventEvent> GenerateLeadsAsync(Guid id);
        Task<EventEvent> GetBackendMenuIdAsync(Guid id);
        Task<EventEvent> GetKioskUrlAsync(Guid id);
        Task<EventEvent> GoogleMapLinkAsync(Guid id, EventEventGoogleMapLinkRequestDto input);
        Task<EventEvent> InviteContactsAsync(Guid id);
        Task<EventEvent> MailAttendeesAsync(Guid id, EventEventMailAttendeesRequestDto input);
        Task<EventEvent> MassMailingAttendeesAsync(Guid id);
        Task<EventEvent> MassMailingTrackSpeakersAsync(Guid id);
        Task<EventEvent> SetDoneAsync(Guid id);
        Task<EventEvent> ToggleBoothMenuAsync(Guid id, EventEventToggleBoothMenuRequestDto input);
        Task<EventEvent> ToggleExhibitorMenuAsync(Guid id, EventEventToggleExhibitorMenuRequestDto input);
        Task<EventEvent> ToggleWebsiteMenuAsync(Guid id, EventEventToggleWebsiteMenuRequestDto input);
        Task<EventEvent> ToggleWebsiteTrackAsync(Guid id, EventEventToggleWebsiteTrackRequestDto input);
        Task<EventEvent> ToggleWebsiteTrackProposalAsync(Guid id, EventEventToggleWebsiteTrackProposalRequestDto input);
        Task<EventEvent> ViewLinkedOrdersAsync(Guid id);
    }
}