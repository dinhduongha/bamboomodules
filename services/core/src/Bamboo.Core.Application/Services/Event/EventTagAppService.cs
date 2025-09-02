using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Event", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public class EventTagAppService : GenericApplicationService<EventTag>, IEventTagAppService
    {
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        public EventTagAppService(IRepository<EventTag, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
        }

        protected async Task<EventTag> DefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_tag.py) ---
            // def _default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        public override async Task<EventTag> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_tag.py) ---
            // def default_get(self, fields_list):
            // result = super().default_get(fields_list)
            // if self.env.context.get('default_website_id'):
            //     result['website_id'] = self.env.context.get('default_website_id')
            // return result
            */
            return await base.DefaultGetAsync(fields);
        }
    }
}