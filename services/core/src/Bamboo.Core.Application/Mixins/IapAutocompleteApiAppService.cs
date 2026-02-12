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
    [Module("partner_autocomplete", Category = "Misc", Depends = new[] { "iap_mail" })]
    public partial class IapAutocompleteApiAppService : ApplicationService, IIapAutocompleteApiAppService
    {

        public IapAutocompleteApiAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: iap_autocomplete_api.py, METHOD: _contact_iap) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RequestPartnerAutocompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: iap_autocomplete_api.py, METHOD: _request_partner_autocomplete) ---
            */
            return default;
        }
    }
}