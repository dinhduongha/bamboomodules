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
    public partial class MailingContactAppService
    {

        protected async Task<MailingContact> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<MailingContact> ComputeOptOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _compute_opt_out) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailingContact> IsNameSplitActivatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _is_name_split_activated) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailingContact> SearchOptOutInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _search_opt_out) ---
            */
            return default;
        }
    }
}