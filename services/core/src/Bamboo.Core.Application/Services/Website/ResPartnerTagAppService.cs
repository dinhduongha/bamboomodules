using Volo.Abp.ObjectMapping;
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
    public partial class ResPartnerTagAppService : GenericApplicationService<ResPartnerTag>, IResPartnerTagAppService
    {
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public ResPartnerTagAppService(IRepository<ResPartnerTag, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        protected async Task<ResPartnerTag> DefaultIsPublishedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def _default_is_published(self):
            // return True
            */
            return default;
        }

        public async Task<ResPartnerTag> GetSelectionClassAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def get_selection_class(self):
            // classname = ['info', 'primary', 'success', 'warning', 'danger']
            // return [(x, str.title(x)) for x in classname]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}