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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("iap", Category = "Misc", Depends = new[] { "web", "base_setup" })]
    public partial class IapEnrichApiAppService : ApplicationService, IIapEnrichApiAppService
    {

        public IapEnrichApiAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object @params) where TEntity : IEntity<Guid>, IIapEnrichApiable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_enrich_api.py, METHOD: _contact_iap) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RequestEnrichInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_emails) where TEntity : IEntity<Guid>, IIapEnrichApiable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_enrich_api.py, METHOD: _request_enrich) ---
            */
            return default;
        }
    }
}