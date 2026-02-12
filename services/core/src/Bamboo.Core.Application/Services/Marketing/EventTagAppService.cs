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
    [Module("Event", Category = "Marketing", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public partial class EventTagAppService : GenericAppService<EventTag>, IEventTagAppService
    {
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        public EventTagAppService(IRepository<EventTag, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
        }

        [ApiModel]
        public override async Task<EventTag> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_tag.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }
    }
}