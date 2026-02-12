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
    [Module("PartnerAutocomplete", Category = "Misc", Depends = new[] { "iap_mail" })]
    public partial class ResPartnerAutocompleteSyncAppService : GenericAppService<ResPartnerAutocompleteSync>, IResPartnerAutocompleteSyncAppService
    {

        public ResPartnerAutocompleteSyncAppService(IRepository<ResPartnerAutocompleteSync, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResPartnerAutocompleteSync> AddToQueueAsync(ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner_autocomplete_sync.py, METHOD: add_to_queue) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartnerAutocompleteSync> StartSyncAsync(ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner_autocomplete_sync.py, METHOD: start_sync) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}