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
    public partial class EventBoothRegistrationAppService
    {

        protected async Task<EventBoothRegistration> CancelPendingRegistrationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py, METHOD: _cancel_pending_registrations) ---
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        protected async Task<EventBoothRegistration> GetFieldsForBoothConfirmationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py, METHOD: _get_fields_for_booth_confirmation) ---
            --- METHOD SOURCE (MODULE: website_event_booth_sale_exhibitor, FILE: event_booth_registration.py, METHOD: _get_fields_for_booth_confirmation) ---
            */
            return default;
        }
    }
}