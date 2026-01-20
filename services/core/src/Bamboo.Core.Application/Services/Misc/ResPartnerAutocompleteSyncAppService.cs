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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("PartnerAutocomplete", Category = "Misc", Depends = new[] { "iap_mail" })]
    public partial class ResPartnerAutocompleteSyncAppService : GenericApplicationService<ResPartnerAutocompleteSync>, IResPartnerAutocompleteSyncAppService
    {

        public ResPartnerAutocompleteSyncAppService(IRepository<ResPartnerAutocompleteSync, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResPartnerAutocompleteSync> AddToQueueAsync(Guid id, ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner_autocomplete_sync.py) ---
            // def add_to_queue(self, partner_id):
            // pass
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartnerAutocompleteSync> StartSyncAsync(Guid id, ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner_autocomplete_sync.py) ---
            // def start_sync(self, batch_size=1000):
            // pass
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}