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
    [Module("Crm", Category = "Sales", Depends = new[] { "base_setup", "sales_team", "mail", "calendar", "resource", "utm", "web_tour", "contacts", "digest", "phone_validation" })]
    public partial class CrmLeadAppService : GenericAppService<CrmLead>, ICrmLeadAppService
    {
        protected readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        protected readonly IMailThreadCcAppService _mailThreadCcAppService;
        protected readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        protected readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        protected readonly IUtmMixinAppService _utmMixinAppService;
        public CrmLeadAppService(IRepository<CrmLead, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IFormatAddressMixinAppService formatAddressMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<CrmLead> AssignGeoLocalizeAsync(CrmLeadAssignGeoLocalizeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: assign_geo_localize) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> AssignPartnerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: action_assign_partner) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> AssignPartnerAsync(CrmLeadAssignPartnerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: assign_partner) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> AssignSalesmanOfAssignedPartnerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: assign_salesman_of_assigned_partner) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> ConvertOpportunityAsync(CrmLeadConvertOpportunityRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: convert_opportunity) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> CopyDataAsync(CrmLeadCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<CrmLead> CreateAsync(CreateRequestDto<CrmLead> input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: crm_lead.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<CrmLead> CreateOppPortalAsync(CrmLeadCreateOppPortalRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: create_opp_portal) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> GenerateLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_lead.py, METHOD: action_generate_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmLead> GetEmptyListHelpAsync(CrmLeadGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmLead> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> GetRainbowmanMessageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_rainbowman_message) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> IapEnrichAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: iap_enrich) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> LogMeetingAsync(CrmLeadLogMeetingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: log_meeting) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> MergeOpportunityAsync(CrmLeadMergeOpportunityRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: merge_opportunity) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmLead> MessageNewAsync(CrmLeadMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> NewQuotationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: action_new_quotation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> OpenLivechatAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: crm_lead.py, METHOD: action_open_livechat) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> PartnerDesinterestedAsync(CrmLeadPartnerDesinterestedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: partner_desinterested) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> PartnerInterestedAsync(CrmLeadPartnerInterestedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: partner_interested) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> PreparePlsTooltipDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: prepare_pls_tooltip_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> RedirectLeadOpportunityViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: redirect_lead_opportunity_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> RedirectToLivechatSessionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_livechat, FILE: crm_lead.py, METHOD: action_redirect_to_livechat_sessions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> RedirectToPageViewsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py, METHOD: action_redirect_to_page_views) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> RescheduleMeetingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_reschedule_meeting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> RestoreAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_restore) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SaleQuotationsNewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: action_sale_quotations_new) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> ScheduleMeetingAsync(CrmLeadScheduleMeetingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_schedule_meeting) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmLead> SearchFetchAsync(CrmLeadSearchFetchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: search_fetch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SearchGeoPartnerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: search_geo_partner) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SetAutomatedProbabilityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_automated_probability) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SetLostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_lost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SetWonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> SetWonRainbowmanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won_rainbowman) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> ShowPotentialDuplicatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_show_potential_duplicates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> UpdateContactDetailsFromPortalAsync(CrmLeadUpdateContactDetailsFromPortalRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: update_contact_details_from_portal) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> UpdateLeadPortalAsync(CrmLeadUpdateLeadPortalRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: update_lead_portal) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> ViewSaleQuotationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: action_view_sale_quotation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmLead> WebsiteFormInputFilterAsync(CrmLeadWebsiteFormInputFilterRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py, METHOD: website_form_input_filter) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<CrmLead> input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: crm_lead.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}