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
    public partial class MailingListAppService
    {

        protected async Task<MailingList> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MailingList> ComputeMailingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _compute_mailing_count) ---
            */
            return default;
        }

        protected async Task<MailingList> ComputeMailingListStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _compute_mailing_list_statistics) ---
            */
            return default;
        }

        protected async Task<MailingList> FetchContactStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _fetch_contact_statistics) ---
            */
            return default;
        }

        protected async Task<MailingList> GetContactStatisticsFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _get_contact_statistics_fields) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: _get_contact_statistics_fields) ---
            */
            return default;
        }

        protected async Task<MailingList> GetContactStatisticsJoinsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _get_contact_statistics_joins) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: _get_contact_statistics_joins) ---
            */
            return default;
        }

        protected async Task<MailingList> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        protected async Task<MailingList> MailingGetOptOutListInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _mailing_get_opt_out_list) ---
            */
            return default;
        }

        protected async Task<MailingList> MailingGetOptOutListSmsInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: _mailing_get_opt_out_list_sms) ---
            */
            return default;
        }

        protected async Task<MailingList> UpdateSubscriptionFromEmailInternalAsync(object email, object opt_out, object force_message)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: _update_subscription_from_email) ---
            */
            return default;
        }
    }
}