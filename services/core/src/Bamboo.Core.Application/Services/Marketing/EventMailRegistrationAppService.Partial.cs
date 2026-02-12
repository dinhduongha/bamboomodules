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
    public partial class EventMailRegistrationAppService
    {

        protected async Task<EventMailRegistration> ComputeScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py, METHOD: _compute_scheduled_date) ---
            */
            return default;
        }

        protected async Task<EventMailRegistration> ExecuteOnRegistrationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py, METHOD: _execute_on_registrations) ---
            --- METHOD SOURCE (MODULE: event_sms, FILE: event_mail_registration.py, METHOD: _execute_on_registrations) ---
            */
            return default;
        }

        protected async Task<EventMailRegistration> GetSkipDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py, METHOD: _get_skip_domain) ---
            */
            return default;
        }
    }
}