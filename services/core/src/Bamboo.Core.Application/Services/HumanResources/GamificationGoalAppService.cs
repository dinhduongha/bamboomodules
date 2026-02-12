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
    [Module("Gamification", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class GamificationGoalAppService : GenericAppService<GamificationGoal>, IGamificationGoalAppService
    {

        public GamificationGoalAppService(IRepository<GamificationGoal, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<GamificationGoal> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationGoal> FailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: action_fail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationGoal> GetActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: get_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationGoal> ReachAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: action_reach) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationGoal> StartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: action_start) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationGoal> UpdateGoalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py, METHOD: update_goal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}