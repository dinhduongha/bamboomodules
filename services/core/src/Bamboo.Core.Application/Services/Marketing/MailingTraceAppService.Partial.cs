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
    public partial class MailingTraceAppService
    {

        protected async Task<MailingTrace> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MailingTrace> ComputeSmsIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py, METHOD: _compute_sms_id) ---
            */
            return default;
        }

        protected async Task<MailingTrace> GetRandomCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py, METHOD: _get_random_code) ---
            */
            return default;
        }
    }
}