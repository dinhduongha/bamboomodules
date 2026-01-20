using Volo.Abp.ObjectMapping;
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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("ImLivechat", Category = "Website", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public partial class ImLivechatChannelMemberHistoryAppService : GenericApplicationService<ImLivechatChannelMemberHistory>, IImLivechatChannelMemberHistoryAppService
    {

        public ImLivechatChannelMemberHistoryAppService(IRepository<ImLivechatChannelMemberHistory, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeAvatar128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_avatar_128(self):
            // for history in self:
            //     history.avatar_128 = history.partner_id.avatar_128 or history.guest_id.avatar_128
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeCallDurationHourInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_call_duration_hour(self):
            // for history in self:
            //     history.call_duration_hour = sum(history.call_history_ids.mapped("duration_hour"))
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_display_name(self):
            // for history in self:
            //     name = history.partner_id.name or history.guest_id.name
            //     if history.partner_id and history.livechat_member_type == "visitor":
            //         name = history.partner_id.display_name
            //     history.display_name = name or self.env._("Unknown")
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeHasCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_has_call(self):
            // for history in self:
            //     history.has_call = 1 if history.call_history_ids else 0
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeHelpStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_help_status(self):
            // agent_histories = self.filtered(lambda h: h.livechat_member_type == "agent")
            // (self - agent_histories).help_status = None
            // for history in agent_histories:
            //     if history.channel_id.livechat_agent_requesting_help_history == history:
            //         history.help_status = "requested"
            //     elif history.channel_id.livechat_agent_providing_help_history == history:
            //         history.help_status = "provided"
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeMemberFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_member_fields(self):
            // for history in self:
            //     history.channel_id = history.channel_id or history.member_id.channel_id
            //     history.guest_id = history.guest_id or history.member_id.guest_id
            //     history.partner_id = history.partner_id or history.member_id.partner_id
            //     history.livechat_member_type = (
            //         history.livechat_member_type or history.member_id.livechat_member_type
            //     )
            //     history.chatbot_script_id = history.chatbot_script_id or history.member_id.chatbot_script_id
            //     history.agent_expertise_ids = (
            //         history.agent_expertise_ids or history.member_id.agent_expertise_ids
            //     )
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeRatingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_rating_id(self):
            // agent_histories = self.filtered(lambda h: h.livechat_member_type in ("agent", "bot"))
            // (self - agent_histories).rating_id = None
            // for history in agent_histories:
            //     history.rating_id = history.channel_id.rating_ids.filtered(
            //         lambda r: r.rated_partner_id == history.partner_id
            //     )[:1]
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ComputeSessionDurationHourInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _compute_session_duration_hour(self):
            // ongoing_chats = self.channel_id.filtered(lambda c: not c.livechat_end_dt)
            // last_msg_dt_by_channel_id = {
            //     message.res_id: message.create_date for message in ongoing_chats._get_last_messages()
            // }
            // for history in self:
            //     end = history.channel_id.livechat_end_dt or last_msg_dt_by_channel_id.get(
            //         history.channel_id.id, fields.Datetime.now()
            //     )
            //     history.session_duration_hour = (end - history.create_date).total_seconds() / 3600
            */
            return default;
        }

        protected async Task<ImLivechatChannelMemberHistory> ConstraintChannelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def _constraint_channel_id(self):
            // # sudo: im_livechat.channel.member.history - skipping ACL for
            // # constraint, more performant and no sensitive information is leaked.
            // if failing_histories := self.sudo().filtered(
            //     lambda h: h.channel_id.channel_type != "livechat"
            // ):
            //     raise ValidationError(
            //         self.env._(
            //             "Cannot create history as it is only available for live chats: %(histories)s.",
            //             histories=failing_histories.member_id.mapped("display_name")
            //         )
            //     )
            */
            return default;
        }

        public async Task<ImLivechatChannelMemberHistory> OpenDiscussChannelViewAsync(Guid id, ImLivechatChannelMemberHistoryOpenDiscussChannelViewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py) ---
            // def action_open_discuss_channel_view(self, domain=()):
            // discuss_channels = self.search_fetch(domain, ["channel_id"]).channel_id
            // action = self.env["ir.actions.act_window"]._for_xml_id("im_livechat.discuss_channel_action")
            // if len(discuss_channels) == 1:
            //     action["res_id"] = discuss_channels.id
            //     action["view_mode"] = "form"
            //     action["views"] = [view for view in action["views"] if view[1] == "form"]
            //     return action
            // action["context"] = {}
            // action["domain"] = [("id", "in", discuss_channels.ids)]
            // action["mobile_view_mode"] = "list"
            // action["view_mode"] = "list"
            // action["views"] = [view for view in action["views"] if view[1] in ("list", "form")]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}