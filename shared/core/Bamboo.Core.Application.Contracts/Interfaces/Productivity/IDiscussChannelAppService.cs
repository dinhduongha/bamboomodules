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
    public interface IDiscussChannelAppService : IGenericAppService<DiscussChannel>
    {
        Task<DiscussChannel> AddMembersAsync(DiscussChannelAddMembersRequestDto input);
        Task<DiscussChannel> ChannelChangeDescriptionAsync(DiscussChannelChannelChangeDescriptionRequestDto input);
        Task<DiscussChannel> ChannelFetchedAsync(Guid[] ids);
        Task<DiscussChannel> ChannelJoinAsync(Guid[] ids);
        Task<DiscussChannel> ChannelPinAsync(DiscussChannelChannelPinRequestDto input);
        Task<DiscussChannel> ChannelRenameAsync(DiscussChannelChannelRenameRequestDto input);
        Task<DiscussChannel> ChannelSetCustomNameAsync(DiscussChannelChannelSetCustomNameRequestDto input);
        Task<DiscussChannel> ExecuteCommandHelpAsync(Guid[] ids);
        Task<DiscussChannel> ExecuteCommandHistoryAsync(Guid[] ids);
        Task<DiscussChannel> ExecuteCommandLeadAsync(Guid[] ids);
        Task<DiscussChannel> ExecuteCommandLeaveAsync(Guid[] ids);
        Task<DiscussChannel> ExecuteCommandWhoAsync(Guid[] ids);
        Task<DiscussChannel> GetMentionSuggestionsAsync(DiscussChannelGetMentionSuggestionsRequestDto input);
        Task<DiscussChannel> InviteByEmailAsync(DiscussChannelInviteByEmailRequestDto input);
        Task<DiscussChannel> LivechatJoinChannelNeedingHelpAsync(Guid[] ids);
        Task<DiscussChannel> MessagePostAsync(Guid[] ids);
        Task<DiscussChannel> SetMessagePinAsync(DiscussChannelSetMessagePinRequestDto input);
        Task<DiscussChannel> UnfollowAsync(Guid[] ids);
    }
}