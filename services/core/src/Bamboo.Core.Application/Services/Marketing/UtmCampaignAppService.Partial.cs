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
    public partial class UtmCampaignAppService
    {

        protected async Task<UtmCampaign> ComputeAbTestingCompletedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _compute_ab_testing_completed) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeClicksCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: utm.py, METHOD: _compute_clicks_count) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeCrmLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: utm.py, METHOD: _compute_crm_lead_count) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeIsMailingCampaignActivatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _compute_is_mailing_campaign_activated) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeMailingMailCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _compute_mailing_mail_count) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeMailingSmsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: _compute_mailing_sms_count) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: utm_campaign.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeQuotationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py, METHOD: _compute_quotation_count) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeSaleInvoicedAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py, METHOD: _compute_sale_invoiced_amount) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _compute_statistics) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeUseLeadsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: utm.py, METHOD: _compute_use_leads) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<UtmCampaign> CronProcessMassMailingAbTestingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _cron_process_mass_mailing_ab_testing) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: _cron_process_mass_mailing_ab_testing) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> GetMailingRecipientsInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py, METHOD: _get_mailing_recipients) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<UtmCampaign> GroupExpandStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: utm_campaign.py, METHOD: _group_expand_stage_ids) ---
            */
            return default;
        }

        protected async Task<UtmCampaign> UnlinkExceptUtmCampaignJobInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: utm_campaign.py, METHOD: _unlink_except_utm_campaign_job) ---
            */
            return default;
        }
    }
}