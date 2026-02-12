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
    [Module("WebsiteCustomer", Category = "Website", Depends = new[] { "website_crm_partner_assign", "website_partner", "website_google_map" })]
    public partial class ResPartnerTagAppService : GenericAppService<ResPartnerTag>, IResPartnerTagAppService
    {
        protected readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public ResPartnerTagAppService(IRepository<ResPartnerTag, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        [ApiModel]
        public async Task<ResPartnerTag> GetSelectionClassAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py, METHOD: get_selection_class) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}