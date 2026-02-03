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
    public interface ISlideChannelAppService : IGenericAppService<SlideChannel>
    {
        Task<SlideChannel> ArchiveAsync(Guid[] ids);
        Task<SlideChannel> ChannelEnrollAsync(Guid[] ids);
        Task<SlideChannel> ChannelInviteAsync(Guid[] ids);
        Task<SlideChannel> CopyDataAsync(SlideChannelCopyDataRequestDto input);
        Task<SlideChannel> GetBackendMenuIdAsync(Guid[] ids);
        Task<SlideChannel> GrantAccessAsync(SlideChannelGrantAccessRequestDto input);
        Task<SlideChannel> MassMailingAttendeesAsync(Guid[] ids);
        Task<SlideChannel> MessagePostAsync(Guid[] ids);
        Task<SlideChannel> RedirectToCertifiedMembersAsync(Guid[] ids);
        Task<SlideChannel> RedirectToCompletedMembersAsync(Guid[] ids);
        Task<SlideChannel> RedirectToEngagedMembersAsync(Guid[] ids);
        Task<SlideChannel> RedirectToForumAsync(Guid[] ids);
        Task<SlideChannel> RedirectToInvitedMembersAsync(Guid[] ids);
        Task<SlideChannel> RedirectToMembersAsync(SlideChannelRedirectToMembersRequestDto input);
        Task<SlideChannel> RefuseAccessAsync(SlideChannelRefuseAccessRequestDto input);
        Task<SlideChannel> RequestAccessAsync(Guid[] ids);
        Task<SlideChannel> UnarchiveAsync(Guid[] ids);
        Task<SlideChannel> ViewRatingsAsync(Guid[] ids);
        Task<SlideChannel> ViewSalesAsync(Guid[] ids);
        Task<SlideChannel> ViewSlidesAsync(Guid[] ids);
    }
}