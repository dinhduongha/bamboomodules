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
    [Module("BaseModule", Category = "Base")]
    public partial class ResPartnerAppService : GenericAppService<ResPartner>, IResPartnerAppService
    {
        protected readonly IAvatarMixinAppService _avatarMixinAppService;
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        protected readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        protected readonly IFormatVatLabelMixinAppService _formatVatLabelMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        protected readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IPropertiesBaseDefinitionMixinAppService _propertiesBaseDefinitionMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ResPartnerAppService(IRepository<ResPartner, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAvatarMixinAppService avatarMixinAppService, IBusListenerMixinAppService busListenerMixinAppService, IFormatAddressMixinAppService formatAddressMixinAppService, IFormatVatLabelMixinAppService formatVatLabelMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IPosLoadMixinAppService posLoadMixinAppService, IPropertiesBaseDefinitionMixinAppService propertiesBaseDefinitionMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _busListenerMixinAppService = busListenerMixinAppService;
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _formatVatLabelMixinAppService = formatVatLabelMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _propertiesBaseDefinitionMixinAppService = propertiesBaseDefinitionMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<ResPartner> AddressGetAsync(ResPartnerAddressGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> AutocompleteByNameAsync(ResPartnerAutocompleteByNameRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_name) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> AutocompleteByVatAsync(ResPartnerAutocompleteByVatRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_vat) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ButtonAccountPeppolCheckPartnerEndpointAsync(ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: button_account_peppol_check_partner_endpoint) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CanEditVatAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: can_edit_vat) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatAlAsync(ResPartnerCheckVatAlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_al) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatBrAsync(ResPartnerCheckVatBrRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_br) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatChAsync(ResPartnerCheckVatChRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatCrAsync(ResPartnerCheckVatCrRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_cr) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatDeAsync(ResPartnerCheckVatDeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_de) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatDoAsync(ResPartnerCheckVatDoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_do) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatEcAsync(ResPartnerCheckVatEcRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ec) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatGrAsync(ResPartnerCheckVatGrRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gr) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatGtAsync(ResPartnerCheckVatGtRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gt) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatHuAsync(ResPartnerCheckVatHuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_hu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatIdAsync(ResPartnerCheckVatIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatIeAsync(ResPartnerCheckVatIeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ie) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatIlAsync(ResPartnerCheckVatIlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_il) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatInAsync(ResPartnerCheckVatInRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_in) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatJpAsync(ResPartnerCheckVatJpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_jp) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatMaAsync(ResPartnerCheckVatMaRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ma) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatMxAsync(ResPartnerCheckVatMxRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_mx) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatNoAsync(ResPartnerCheckVatNoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_no) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatPeAsync(ResPartnerCheckVatPeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_pe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatPhAsync(ResPartnerCheckVatPhRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ph) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatRoAsync(ResPartnerCheckVatRoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ro) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatRsAsync(ResPartnerCheckVatRsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_rs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatRuAsync(ResPartnerCheckVatRuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ru) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatSaAsync(ResPartnerCheckVatSaRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_sa) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatThAsync(ResPartnerCheckVatThRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_th) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatTrAsync(ResPartnerCheckVatTrRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tr) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatTwAsync(ResPartnerCheckVatTwRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tw) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatUaAsync(ResPartnerCheckVatUaRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ua) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatUyAsync(ResPartnerCheckVatUyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_uy) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatVeAsync(ResPartnerCheckVatVeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ve) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CheckVatVnAsync(ResPartnerCheckVatVnRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_vn) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> CopyDataAsync(ResPartnerCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResPartner> CreateAsync(CreateRequestDto<ResPartner> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ResPartner> CreateCompanyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<ResPartner> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<ResPartner> DoButtonPrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_button_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> DoPartnerMailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_mail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> DoPartnerManualActionAsync(ResPartnerDoPartnerManualActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> DoPartnerManualDermanordAsync(ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action_dermanord) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> DoPartnerPrintAsync(ResPartnerDoPartnerPrintRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_print) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> DoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: action_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> EnrichByDomainAsync(ResPartnerEnrichByDomainRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_domain) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> EnrichByDunsAsync(ResPartnerEnrichByDunsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_duns) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> EnrichByGstAsync(ResPartnerEnrichByGstRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_gst) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> EventViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: action_event_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FieldsViewGetAsync(ResPartnerFieldsViewGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: fields_view_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> FindOrCreateAsync(ResPartnerFindOrCreateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: find_or_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatChAsync(ResPartnerFormatVatChRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_ch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatClAsync(ResPartnerFormatVatClRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_cl) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatCoAsync(ResPartnerFormatVatCoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_co) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatEuAsync(ResPartnerFormatVatEuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_eu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatHuAsync(ResPartnerFormatVatHuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_hu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatSmAsync(ResPartnerFormatVatSmRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_sm) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> FormatVatVnAsync(ResPartnerFormatVatVnRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_vn) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GeoLocalizeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: geo_localize) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GetAttendeeDetailAsync(ResPartnerGetAttendeeDetailRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: get_attendee_detail) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GetBackendMenuIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py, METHOD: get_backend_menu_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GetFollowupTableHtmlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: get_followup_table_html) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetMentionSuggestionsAsync(ResPartnerGetMentionSuggestionsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetMentionSuggestionsFromChannelAsync(ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions_from_channel) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetNewPartnerAsync(ResPartnerGetNewPartnerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: get_new_partner) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetPartnerLocalisationFieldsRequiredToInvoiceAsync(ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: get_partner_localisation_fields_required_to_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> GetWorkingHoursForAllAttendeesAsync(ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: get_working_hours_for_all_attendees) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GetWorklocationAsync(ResPartnerGetWorklocationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py, METHOD: get_worklocation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GoogleMapImgAsync(ResPartnerGoogleMapImgRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_img) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> GoogleMapLinkAsync(ResPartnerGoogleMapLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> IapPartnerAutocompleteGetTagIdsAsync(ResPartnerIapPartnerAutocompleteGetTagIdsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: iap_partner_autocomplete_get_tag_ids) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> IsValidRucEcAsync(ResPartnerIsValidRucEcRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: is_valid_ruc_ec) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> OnchangeCompanyTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> OnchangeParentIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> OpenCommercialEntityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> OpenEmployeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: action_open_employees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> PrivacyLookupAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py, METHOD: action_privacy_lookup) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ScheduleMeetingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: schedule_meeting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> SearchForChannelInviteAsync(ResPartnerSearchForChannelInviteRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: search_for_channel_invite) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> SignupCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> SignupGetAuthParamAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_get_auth_param) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> SignupPrepareAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: action_signup_prepare) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> SignupPrepareAsync(ResPartnerSignupPrepareRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_prepare) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewCertificationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: action_view_certifications) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewCoursesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: action_view_courses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartner> ViewHeaderGetAsync(ResPartnerViewHeaderGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewLivechatSessionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: action_view_livechat_sessions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewLoyaltyCardsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: action_view_loyalty_cards) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewOpportunityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: action_view_opportunity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewPartnerInvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_view_partner_invoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: action_view_pos_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewStockSerialAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_partner.py, METHOD: action_view_stock_serial) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartner> ViewTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: action_view_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResPartner> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: partnership, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}