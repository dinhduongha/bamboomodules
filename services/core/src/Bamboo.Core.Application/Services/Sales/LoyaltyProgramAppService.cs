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
    [Module("Loyalty", Category = "Sales", Depends = new[] { "product", "portal", "account" })]
    public partial class LoyaltyProgramAppService : GenericAppService<LoyaltyProgram>, ILoyaltyProgramAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        public LoyaltyProgramAppService(IRepository<LoyaltyProgram, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
        }

        [ApiModel]
        public async Task<LoyaltyProgram> CreateFromTemplateAsync(LoyaltyProgramCreateFromTemplateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: create_from_template) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LoyaltyProgram> GetProgramTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: get_program_templates) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: get_program_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LoyaltyProgram> OpenLoyaltyCardsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: action_open_loyalty_cards) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LoyaltyProgram> ProgramShareAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py, METHOD: action_program_share) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}