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
    public partial class ResConfigSettingsAppService : GenericAppService<ResConfigSettings>, IResConfigSettingsAppService
    {

        public ResConfigSettingsAppService(IRepository<ResConfigSettings, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResConfigSettings> ButtonDisconnectThisDatabaseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: button_disconnect_this_database) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ButtonOpenPeppolConfigWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: button_open_peppol_config_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ButtonPeppolDisconnectBranchFromParentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: button_peppol_disconnect_branch_from_parent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ButtonPeppolRegisterSenderAsReceiverAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: button_peppol_register_sender_as_receiver) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ButtonReconnectThisDatabaseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: button_reconnect_this_database) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResConfigSettings> CreateAsync(CreateRequestDto<ResConfigSettings> input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: res_config_settings.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: res_config_settings.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ResConfigSettings> CrmAssignLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: action_crm_assign_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> CustomLinkActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: custom_link_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> EditExternalHeaderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: edit_external_header) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> EuOssTaxMappingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: action_eu_oss_tax_mapping) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ExecuteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: execute) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> GenerateQrCodesPageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: generate_qr_codes_page) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> GenerateQrCodesZipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: generate_qr_codes_zip) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResConfigSettings> GetConfigWarningAsync(ResConfigSettingsGetConfigWarningRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: get_config_warning) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResConfigSettings> GetOptionNameAsync(ResConfigSettingsGetOptionNameRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: get_option_name) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResConfigSettings> GetOptionPathAsync(ResConfigSettingsGetOptionPathRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: get_option_path) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> GetPosQrStandsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: get_pos_qr_stands) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResConfigSettings> GetUriAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_config_settings.py, METHOD: get_uri) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResConfigSettings> GetValuesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_config_settings.py, METHOD: get_values) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: get_values) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OnchangeAdvLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: onchange_adv_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OnchangeAnalyticAccountingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: onchange_analytic_accounting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OnchangeModuleAccountBudgetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: onchange_module_account_budget) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenAbandonedCartMailTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: action_open_abandoned_cart_mail_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenBlockedThirdPartyDomainsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: action_open_blocked_third_party_domains) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenCloudStorageMigrationConfigurationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: res_config_settings.py, METHOD: action_open_cloud_storage_migration_configurations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenCompanyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: open_company) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenEmailLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_config_settings.py, METHOD: open_email_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenExtraInfoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: action_open_extra_info) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenFollowupLevelFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: settings.py, METHOD: open_followup_level_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenMailTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_config_settings.py, METHOD: open_mail_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenNewUserDefaultGroupsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: open_new_user_default_groups) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenPaymentMethodFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: open_payment_method_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenPeppolFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: action_open_peppol_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenProductFeedsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: action_open_product_feeds) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenRobotsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: action_open_robots) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenSaleMailTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: action_open_sale_mail_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenSmsTwilioAccountManageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_config_settings.py, METHOD: action_open_sms_twilio_account_manage) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> OpenTemplateUserAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: action_open_template_user) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> PosCloseUiAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: pos_close_ui) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: pos_close_ui) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> PosConfigCreateNewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: action_pos_config_create_new) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> PosOpenUiAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: pos_open_ui) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> PosPrinterDialogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: action_pos_printer_dialog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> PreviewSelfOrderAppAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: preview_self_order_app) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> RedirectToBuyAutocompleteCreditAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_config_settings.py, METHOD: redirect_to_buy_autocomplete_credit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> RegenerateKioskKeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_config_settings.py, METHOD: regenerate_kiosk_key) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ReloadTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: reload_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> SetValuesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: product, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: project, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: website_sale_mass_mailing, FILE: res_config_settings.py, METHOD: set_values) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: set_values) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> UpdateAccessTokensAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: update_access_tokens) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> UpdateTermsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: action_update_terms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ViewDeliveryProviderModulesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: action_view_delivery_provider_modules) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> ViewInStoreDeliveryMethodsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: res_config_settings.py, METHOD: action_view_in_store_delivery_methods) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> WPaymentStartPaymentOnboardingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: res_config_settings.py, METHOD: action_w_payment_start_payment_onboarding) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResConfigSettings> WebsiteCreateNewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: action_website_create_new) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResConfigSettings> input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}