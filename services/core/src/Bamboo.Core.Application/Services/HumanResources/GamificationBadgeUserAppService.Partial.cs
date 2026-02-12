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
    public partial class GamificationBadgeUserAppService
    {

        protected async Task<GamificationBadgeUser> CheckEmployeeRelatedUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py, METHOD: _check_employee_related_user) ---
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> ComputeHasEditDeleteAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py, METHOD: _compute_has_edit_delete_access) ---
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> SendBadgeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _send_badge) ---
            */
            return default;
        }
    }
}