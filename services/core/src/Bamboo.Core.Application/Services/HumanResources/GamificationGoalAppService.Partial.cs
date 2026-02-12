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
    public partial class GamificationGoalAppService
    {

        protected async Task<GamificationGoal> CheckRemindDelayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: _check_remind_delay) ---
            */
            return default;
        }

        protected async Task<GamificationGoal> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<GamificationGoal> GetCompletionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: _get_completion) ---
            */
            return default;
        }

        protected async Task<GamificationGoal> GetWriteValuesInternalAsync(object new_value)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: _get_write_values) ---
            */
            return default;
        }

        protected async Task<GamificationGoal> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }
    }
}