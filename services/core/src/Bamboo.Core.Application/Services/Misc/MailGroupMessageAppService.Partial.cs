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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class MailGroupMessageAppService
    {

        protected async Task<MailGroupMessage> AssertModerableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _assert_moderable) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> ComputeAuthorModerationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _compute_author_moderation) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> ComputeEmailFromNormalizedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _compute_email_from_normalized) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> ConstrainsMailMessageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _constrains_mail_message_id) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> CreateModerationRuleInternalAsync(object status)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _create_moderation_rule) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> GetPendingSameAuthorSameGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _get_pending_same_author_same_group) ---
            */
            return default;
        }

        protected async Task<MailGroupMessage> ModerateSendRejectEmailInternalAsync(object subject, object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: _moderate_send_reject_email) ---
            */
            return default;
        }
    }
}