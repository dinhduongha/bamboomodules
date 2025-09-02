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
    public interface ISlideChannelAppService : IGenericApplicationService<SlideChannel>
    {
        Task<SlideChannel> ChannelEnrollAsync(Guid id);
        Task<SlideChannel> ChannelInviteAsync(Guid id);
        Task<SlideChannel> CopyDataAsync(Guid id, SlideChannelCopyDataRequestDto input);
        Task<SlideChannel> GetBackendMenuIdAsync(Guid id);
        Task<SlideChannel> GrantAccessAsync(Guid id, SlideChannelGrantAccessRequestDto input);
        Task<SlideChannel> MassMailingAttendeesAsync(Guid id);
        Task<SlideChannel> MessagePostAsync(Guid id);
        Task<SlideChannel> OpenWebsiteUrlAsync(Guid id);
        Task<SlideChannel> RedirectToCertifiedMembersAsync(Guid id);
        Task<SlideChannel> RedirectToCompletedMembersAsync(Guid id);
        Task<SlideChannel> RedirectToEngagedMembersAsync(Guid id);
        Task<SlideChannel> RedirectToForumAsync(Guid id);
        Task<SlideChannel> RedirectToInvitedMembersAsync(Guid id);
        Task<SlideChannel> RedirectToMembersAsync(Guid id, SlideChannelRedirectToMembersRequestDto input);
        Task<SlideChannel> RefuseAccessAsync(Guid id, SlideChannelRefuseAccessRequestDto input);
        Task<SlideChannel> RequestAccessAsync(Guid id);
        Task<SlideChannel> ToggleActiveAsync(Guid id);
        Task<SlideChannel> ViewRatingsAsync(Guid id);
        Task<SlideChannel> ViewSalesAsync(Guid id);
        Task<SlideChannel> ViewSlidesAsync(Guid id);
    }
}