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
    public partial class GamificationBadgeAppService : GenericAppService<GamificationBadge>, IGamificationBadgeAppService
    {
        protected readonly IImageMixinAppService _imageMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public GamificationBadgeAppService(IRepository<GamificationBadge, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        public async Task<GamificationBadge> CheckGrantingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: check_granting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<GamificationBadge> GetGrantedEmployeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py, METHOD: get_granted_employees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}