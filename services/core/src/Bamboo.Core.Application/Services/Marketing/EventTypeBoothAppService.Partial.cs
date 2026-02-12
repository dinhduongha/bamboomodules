using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class EventTypeBoothAppService
    {

        protected async Task<EventTypeBooth> ActionPostConfirmInternalAsync(object write_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _action_post_confirm) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeIsAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_is_available) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> GetDefaultBoothCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py, METHOD: _get_default_booth_category) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventTypeBooth> GetEventBoothFieldsWhitelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py, METHOD: _get_event_booth_fields_whitelist) ---
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_type_booth.py, METHOD: _get_event_booth_fields_whitelist) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> PostConfirmationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _post_confirmation_message) ---
            */
            return default;
        }

        protected async Task<EventTypeBooth> SearchIsAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _search_is_available) ---
            */
            return default;
        }
    }
}