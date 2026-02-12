using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class MailGroupAppService
    {

        protected async Task<MailGroup> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        protected async Task<MailGroup> AliasGetErrorInternalAsync(object message, object message_dict, object @alias)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _alias_get_error) ---
            */
            return default;
        }

        protected async Task<MailGroup> CheckAccessModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_access_mode) ---
            */
            return default;
        }

        protected async Task<MailGroup> CheckModerationGuidelinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderation_guidelines) ---
            */
            return default;
        }

        protected async Task<MailGroup> CheckModerationNotifyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderation_notify) ---
            */
            return default;
        }

        protected async Task<MailGroup> CheckModeratorEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderator_email) ---
            */
            return default;
        }

        protected async Task<MailGroup> CheckModeratorExistenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderator_existence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailGroup> CleanEmailBodyInternalAsync(object body_html)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _clean_email_body) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeCanManageGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_can_manage_group) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeIsMemberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeIsModeratorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_is_moderator) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeMailGroupMessageCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_count) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeMailGroupMessageLastMonthCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_last_month_count) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeMailGroupMessageModerationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_moderation_count) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeMemberCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeMemberPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_member_partner_ids) ---
            */
            return default;
        }

        protected async Task<MailGroup> ComputeModerationRuleCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_moderation_rule_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailGroup> CronNotifyModeratorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _cron_notify_moderators) ---
            */
            return default;
        }

        protected async Task<MailGroup> FindMemberInternalAsync(object email, Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _find_member) ---
            */
            return default;
        }

        protected async Task<MailGroup> FindMembersInternalAsync(object email, Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _find_members) ---
            */
            return default;
        }

        protected async Task<MailGroup> GenerateActionTokenInternalAsync(object email, object action)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_action_token) ---
            */
            return default;
        }

        protected async Task<MailGroup> GenerateActionUrlInternalAsync(object email, object action)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_action_url) ---
            */
            return default;
        }

        protected async Task<MailGroup> GenerateEmailAccessTokenInternalAsync(object email)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_email_access_token) ---
            */
            return default;
        }

        protected async Task<MailGroup> GenerateGroupAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_group_access_token) ---
            */
            return default;
        }

        protected async Task<MailGroup> GetEmailUnsubscribeUrlInternalAsync(object email_to)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _get_email_unsubscribe_url) ---
            */
            return default;
        }

        protected async Task<MailGroup> JoinGroupInternalAsync(object email, Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _join_group) ---
            */
            return default;
        }

        protected async Task<MailGroup> LeaveGroupInternalAsync(object email, Guid partner_id, object all_members)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _leave_group) ---
            */
            return default;
        }

        protected async Task<MailGroup> NotifyMembersInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _notify_members) ---
            */
            return default;
        }

        protected async Task<MailGroup> NotifyModeratorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _notify_moderators) ---
            */
            return default;
        }

        protected async Task<MailGroup> OnchangeAccessModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _onchange_access_mode) ---
            */
            return default;
        }

        protected async Task<MailGroup> OnchangeModerationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _onchange_moderation) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailGroup> RoutingCheckRouteInternalAsync(object message, object message_dict, object route, object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        protected async Task<MailGroup> SearchMemberPartnerIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _search_member_partner_ids) ---
            */
            return default;
        }

        protected async Task<MailGroup> SendSubscribeConfirmationEmailInternalAsync(object email)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _send_subscribe_confirmation_email) ---
            */
            return default;
        }

        protected async Task<MailGroup> SendUnsubscribeConfirmationEmailInternalAsync(object email)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _send_unsubscribe_confirmation_email) ---
            */
            return default;
        }
    }
}