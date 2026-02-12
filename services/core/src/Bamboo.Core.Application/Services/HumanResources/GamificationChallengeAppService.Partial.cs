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
    public partial class GamificationChallengeAppService
    {

        protected async Task<GamificationChallenge> CheckChallengeRewardInternalAsync(object force)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _check_challenge_reward) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> ComputeUserCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _compute_user_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<GamificationChallenge> CronUpdateInternalAsync(object ids, object commit)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _cron_update) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GenerateGoalsFromChallengeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _generate_goals_from_challenge) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetChallengerUsersInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_challenger_users) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetNextReportDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_next_report_date) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetReportTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_report_template) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetSerializedChallengeLinesInternalAsync(object user, object restrict_goals, object restrict_top)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_serialized_challenge_lines) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetTopNUsersInternalAsync(object n)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_topN_users) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> RecomputeChallengeUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _recompute_challenge_users) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> RewardUserInternalAsync(object user, object badge)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _reward_user) ---
            */
            return default;
        }

        protected async Task<GamificationChallenge> UpdateAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _update_all) ---
            */
            return default;
        }
    }
}