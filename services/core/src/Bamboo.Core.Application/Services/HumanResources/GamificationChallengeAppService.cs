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
    [Module("Gamification", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class GamificationChallengeAppService : GenericAppService<GamificationChallenge>, IGamificationChallengeAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public GamificationChallengeAppService(IRepository<GamificationChallenge, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<GamificationChallenge> AcceptChallengeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: accept_challenge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> CheckAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_check) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> DiscardChallengeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: discard_challenge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> ReportProgressAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_report_progress) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> ReportProgressAsync(GamificationChallengeReportProgressRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: report_progress) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> StartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_start) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationChallenge> ViewUsersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_view_users) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}