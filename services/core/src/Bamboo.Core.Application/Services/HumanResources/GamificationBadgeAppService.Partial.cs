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
    public partial class GamificationBadgeAppService
    {

        protected async Task<GamificationBadge> CanGrantBadgeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _can_grant_badge) ---
            */
            return default;
        }

        protected async Task<GamificationBadge> ComputeGrantedEmployeesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py, METHOD: _compute_granted_employees_count) ---
            */
            return default;
        }

        protected async Task<GamificationBadge> ComputeSurveyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: badge.py, METHOD: _compute_survey_id) ---
            */
            return default;
        }

        protected async Task<GamificationBadge> GetBadgeUserStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_badge_user_stats) ---
            */
            return default;
        }

        protected async Task<GamificationBadge> GetOwnersInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_owners_info) ---
            */
            return default;
        }

        protected async Task<GamificationBadge> RemainingSendingCalcInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _remaining_sending_calc) ---
            */
            return default;
        }
    }
}