using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class DiscussChannelAppService : GenericAppService<DiscussChannel>, IDiscussChannelAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IRatingMixinAppService _ratingMixinAppService;
        public DiscussChannelAppService(IRepository<DiscussChannel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService, IMailThreadAppService mailThreadAppService, IRatingMixinAppService ratingMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _ratingMixinAppService = ratingMixinAppService;
        }

        public async Task<DiscussChannel> AddMembersAsync(DiscussChannelAddMembersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: add_members) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelChangeDescriptionAsync(DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_change_description) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelFetchedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_fetched) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelJoinAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_join) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelPinAsync(DiscussChannelChannelPinRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_pin) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: channel_pin) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelRenameAsync(DiscussChannelChannelRenameRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_rename) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelSetCustomNameAsync(DiscussChannelChannelSetCustomNameRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_set_custom_name) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandHelpAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            --- METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandHistoryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: execute_command_history) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandLeadAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: execute_command_lead) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandLeaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_leave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandWhoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_who) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<DiscussChannel> GetMentionSuggestionsAsync(DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: get_mention_suggestions) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> InviteByEmailAsync(DiscussChannelInviteByEmailRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: invite_by_email) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> LivechatJoinChannelNeedingHelpAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: livechat_join_channel_needing_help) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> SetMessagePinAsync(DiscussChannelSetMessagePinRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: set_message_pin) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> UnfollowAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: action_unfollow) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<DiscussChannel> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}