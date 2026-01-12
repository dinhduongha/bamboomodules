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
    public interface IDiscussChannelAppService : IGenericApplicationService<DiscussChannel>
    {
        Task<DiscussChannel> AddMembersAsync(Guid id, DiscussChannelAddMembersRequestDto input);
        Task<DiscussChannel> ChannelChangeDescriptionAsync(Guid id, DiscussChannelChannelChangeDescriptionRequestDto input);
        Task<DiscussChannel> ChannelFetchedAsync(Guid id);
        Task<DiscussChannel> ChannelJoinAsync(Guid id);
        Task<DiscussChannel> ChannelPinAsync(Guid id, DiscussChannelChannelPinRequestDto input);
        Task<DiscussChannel> ChannelRenameAsync(Guid id, DiscussChannelChannelRenameRequestDto input);
        Task<DiscussChannel> ChannelSetCustomNameAsync(Guid id, DiscussChannelChannelSetCustomNameRequestDto input);
        Task<DiscussChannel> ExecuteCommandHelpAsync(Guid id);
        Task<DiscussChannel> ExecuteCommandHistoryAsync(Guid id);
        Task<DiscussChannel> ExecuteCommandLeadAsync(Guid id);
        Task<DiscussChannel> ExecuteCommandLeaveAsync(Guid id);
        Task<DiscussChannel> ExecuteCommandWhoAsync(Guid id);
        Task<DiscussChannel> GetMentionSuggestionsAsync(Guid id, DiscussChannelGetMentionSuggestionsRequestDto input);
        Task<DiscussChannel> InviteByEmailAsync(Guid id, DiscussChannelInviteByEmailRequestDto input);
        Task<DiscussChannel> LivechatJoinChannelNeedingHelpAsync(Guid id);
        Task<DiscussChannel> MessagePostAsync(Guid id);
        Task<DiscussChannel> SetMessagePinAsync(Guid id, DiscussChannelSetMessagePinRequestDto input);
        Task<DiscussChannel> UnfollowAsync(Guid id);
    }
}