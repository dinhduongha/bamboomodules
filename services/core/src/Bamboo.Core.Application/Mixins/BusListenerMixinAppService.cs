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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("bus", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class BusListenerMixinAppService : ApplicationService, IBusListenerMixinAppService
    {

        public BusListenerMixinAppService() 
        {

        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChangePasswordWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_change_password_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_create_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreatePasskeyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: action_create_passkey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDisconnectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: action_disconnect) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: action_event_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionGetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: action_get) ---
            */
            return default;
        }

        public async Task<TEntity> ActionKarmaReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: action_karma_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: action_open_document) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenMyAccountSettingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: action_open_my_account_settings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewAttachmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: ir_attachment.py, METHOD: action_preview_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py, METHOD: action_privacy_lookup) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_related_contact) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResetPasswordAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: action_reset_password) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResetPasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _action_reset_password) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRevokeAllDevicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_revoke_all_devices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRevokeAllDevicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _action_revoke_all_devices) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionSetupOutgoingMailServerAsync<TEntity>(IEnumerable<TEntity> entities, object server_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_setup_outgoing_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowAccessesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_accesses) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowAllUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: action_show_all_users) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowGroupsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_groups) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _action_show) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: action_signup_prepare) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionTestOutgoingMailServerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_test_outgoing_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTotpDisableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: action_totp_disable) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTotpEnableWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: action_totp_enable_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTotpInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: action_totp_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object guest, object post_leave_message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: action_view_certifications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: action_view_courses) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatSessionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: action_view_livechat_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: action_view_loyalty_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: action_view_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_view_partner_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: action_view_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_partner.py, METHOD: action_view_stock_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActivateGroupAccountSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_users.py, METHOD: _activate_group_account_secured) ---
            */
            return default;
        }

        public async Task<TEntity> AddKarmaBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_per_user) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _add_karma_batch) ---
            */
            return default;
        }

        public async Task<TEntity> AddKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, object gain, object source, object reason) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _add_karma) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> guest_ids, object invite_to_rtc_call, object post_joined_message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: add_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _add_members) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _address_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AllowInviteByEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _allow_invite_by_email) ---
            */
            return default;
        }

        public async Task<TEntity> ApiKeyWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: api_key_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object implied_group) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _apply_group) ---
            */
            return default;
        }

        public async Task<TEntity> AssertCanAuthInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _assert_can_auth) ---
            */
            return default;
        }

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _asset_difference_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AuthOauthAsync<TEntity>(IEnumerable<TEntity> entities, object provider, object @params) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: auth_oauth) ---
            */
            return default;
        }

        public async Task<TEntity> AuthOauthRpcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object endpoint, object access_token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_rpc) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AuthOauthSigninInternalAsync<TEntity>(IEnumerable<TEntity> entities, object provider, object validation, object @params) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_signin) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AuthOauthValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object provider, object access_token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_validate) ---
            */
            return default;
        }

        public async Task<TEntity> AuthenticateAsync<TEntity>(IEnumerable<TEntity> entities, object credential, object user_agent_env) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: authenticate) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: authenticate) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: authenticate) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_vat) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> BroadcastInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _broadcast) ---
            */
            return default;
        }

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _build_error_peppol_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _build_vat_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _build_vcard) ---
            */
            return default;
        }

        public async Task<TEntity> BuildZipFromAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _build_zip_from_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> BusChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_listener_mixin.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: bus, FILE: ir_attachment.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: bus, FILE: res_users.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: bus, FILE: res_users_settings.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_link_preview.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _bus_send_history_message) ---
            */
            return default;
        }

        protected async Task<object> BusSendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_listener_mixin.py, METHOD: _bus_send) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendReactionGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _bus_send_reaction_group) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendTransientMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object content) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: bus_listener_mixin.py, METHOD: _bus_send_transient_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: button_account_peppol_check_partner_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CanBypassRightsOnMediaDialogInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            --- METHOD SOURCE (MODULE: web_unsplash, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _can_edit_country) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: can_edit_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CanImportRemoteUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _can_import_remote_urls) ---
            */
            return default;
        }

        public async Task<TEntity> CanManageUnsplashSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web_unsplash, FILE: res_users.py, METHOD: _can_manage_unsplash_settings) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ChangePasswordAsync<TEntity>(IEnumerable<TEntity> entities, object old_passwd, object new_passwd) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: change_password) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: change_password) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: change_password) ---
            */
            return default;
        }

        public async Task<TEntity> ChangePasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_passwd) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _change_password) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelChangeDescriptionAsync<TEntity>(IEnumerable<TEntity> entities, object description) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_change_description) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelFetchedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_fetched) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_join) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelPinAsync<TEntity>(IEnumerable<TEntity> entities, object pinned) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_pin) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelRenameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_rename) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelSetCustomNameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_set_custom_name) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, string operation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _check_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_action_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckAsync<TEntity>(IEnumerable<TEntity> entities, object mode, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: check) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAtLeastOneAdministratorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_at_least_one_administrator) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckCalendarCredentialsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanUpdateMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _check_can_update_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_company_domain) ---
            */
            return default;
        }

        public async Task<TEntity> CheckContentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _check_contents) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCredentialsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credential, object env) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_credentials) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDisjointGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _check_disjoint_groups) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_disjoint_groups) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format, object process_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_document_type_support) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _check_login) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPasswordPolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object passwords) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: _check_password_policy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPendingOdooRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _check_pending_odoo_records) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _check_peppol_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_peppol_participant_exists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServingAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _check_serving_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSynchronizationStatusAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckUidPasswdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uid, object passwd) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_uid_passwd) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUserCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_user_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUserDisjointGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _check_user_disjoint_groups) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_al) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_br) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_cr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_de) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_do) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ec) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGtAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gt) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_hu) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ie) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_il) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_in) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object validation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatJpAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_jp) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ma) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_mx) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_no) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _check_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_pe) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ph) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ro) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRsAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_rs) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ru) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_sa) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatThAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_th) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTwAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tw) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ua) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_uy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_vn) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanAttendanceOfficersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_users.py, METHOD: _clean_attendance_officers) ---
            */
            return default;
        }

        public async Task<TEntity> CleanEmptyMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _clean_empty_message) ---
            */
            return default;
        }

        public async Task<TEntity> CleanLeaveResponsibleUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _clean_leave_responsible_users) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanupExpiredMutesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _cleanup_expired_mutes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClearRemovedEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _clear_removed_edi_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_accesses_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllGroupIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_all_group_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllImpliedByIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_implied_by_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllImpliedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_implied_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllUsersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_users_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_edi_formats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_sending_methods) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_bank_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_bom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDefaultPrivacyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _compute_calendar_default_privacy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanEditRoleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_can_edit_role) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelNameMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_name_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChecksumInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_checksum) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompaniesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_companies_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_company_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_contact_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: _compute_count_active_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_credit_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_credit_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCrmTeamIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _compute_crm_team_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_datas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_days_sales_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisjointIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_disjoint_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_email_domain_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryGroupCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_group_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_full_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGroupPublicIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_group_public_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAccessLivechatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_has_access_livechat) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_has_error) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasExternalMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_has_external_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLockTimeoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_has_lock_timeout) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasOauthAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _compute_has_oauth_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasThumbnailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _compute_has_thumbnail) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_image_size) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImageSrcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_image_src) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_implemented_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitationUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invitation_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitedMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invited_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_invoice_emails) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsCurrentUserOrGuestAuthorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_is_current_user_or_guest_author) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHrUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_is_hr_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_is_in_call) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOutOfOfficeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_is_out_of_office) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPinnedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_is_pinned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_is_self) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSystemInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_is_system) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_ubl_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _compute_karma) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_leave_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedMessageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_linked_message_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatExpertiseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_expertise_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatIsInCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_is_in_call) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatLangIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_lang_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatOngoingSessionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_ongoing_session_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocalUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_local_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTimeout2faSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_2fa_selection) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTimeoutDelayUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_delay_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTimeoutInactivity2faSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_2fa_selection) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTimeoutInactivityBoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_bool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTimeoutInactivityDelayUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_delay_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_message_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageUnreadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_message_unread) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMimetypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_mimetype) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeedactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_needaction) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNotificationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_notification_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py, METHOD: _compute_on_time_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutgoingMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_outgoing_mail_server_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: _compute_partner_iap_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_vat_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_partner_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_password) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_partner.py, METHOD: _compute_payment_token_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_perform_vies_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _compute_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_production_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRawInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_raw) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecordNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_record_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_res_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResUsersSettingsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_res_users_settings_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRoleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_role) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _compute_sale_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfMemberIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_self_member_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sid) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_session_token) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_show_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_signature) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStarredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_starred) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url_is_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _compute_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_supplier_invoice_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotpEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _compute_totp_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotpSecretInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _compute_totp_secret) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTourEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: res_users.py, METHOD: _compute_tour_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_user_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_vies_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViewGroupHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_view_group_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintFromMessageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_from_message_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintGroupIdChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_group_id_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintParentChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_parent_channel_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintPartnersChatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_partners_chat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ContextGetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: context_get) ---
            */
            return default;
        }

        public async Task<TEntity> ContrainsNoPublicMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _contrains_no_public_member) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _convert_hu_local_to_eu_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsForPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object extra_list) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_attachments_for_post) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid group_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateFromMessageAndNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object request_url) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_link_preview.py, METHOD: _create_from_message_and_notify) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object default_display_mode, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_group) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _create_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> CreateRecruitmentInterviewersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py, METHOD: _create_recruitment_interviewers) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid from_message_id, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_sub_channel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateUniqueAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: create_unique) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUserFromTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _create_user_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_debit_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_search) ---
            */
            return default;
        }

        public async Task<TEntity> CronMigrateLocalToCloudStorageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py, METHOD: _cron_migrate_local_to_cloud_storage) ---
            */
            return default;
        }

        public async Task<TEntity> CryptContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _crypt_context) ---
            */
            return default;
        }

        public async Task<TEntity> DeactivatePortalUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _debit_search) ---
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _deduce_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _default_groups) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserCalendarDefaultPrivacyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _default_user_calendar_default_privacy) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultViewGroupHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _default_view_group_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteAndNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _delete_and_notify) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteInactiveRtcSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _delete_inactive_rtc_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_button_print) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_mail) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action_dermanord) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_print) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeIdsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _employee_ids_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_duns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_gst) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_projects) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _ensure_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> ExceptAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _except_audit_trail) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpMessageExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _execute_command_help_message_extra) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_leave) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandWhoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_who) ---
            */
            return default;
        }

        public async Task<TEntity> ExportDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_export) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: export_data) ---
            */
            return default;
        }

        public async Task<TEntity> ExtrasToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object format_reply) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _extras_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: fetch) ---
            */
            return default;
        }

        public async Task<TEntity> FetchChildrenPartnersForHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _fetch_children_partners_for_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _field_store_repr) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldsGetAsync<TEntity>(IEnumerable<TEntity> entities, object allfields, object attributes) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: fields_get) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: fields_view_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FileDeleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_delete) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FileReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object size) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FileWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_value, object checksum) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_write) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FilestoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _filestore) ---
            */
            return default;
        }

        public async Task<TEntity> FilterEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _filter_empty) ---
            */
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _find_accounting_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindAllowedDocIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> model_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _find_allowed_doc_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: find_or_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateForUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _find_or_create_for_user) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object ban_emails, object filter_found, object additional_values, object no_create, object sort_key, object sort_reverse) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _find_or_create_from_emails) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateMemberForSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_member_for_self) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreatePersonaForChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_persona_for_channel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ForceStorageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: force_storage) ---
            */
            return default;
        }

        public async Task<TEntity> FormatAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _format_auth_cookie) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _format_data_company) ---
            */
            return default;
        }

        public async Task<TEntity> FormatSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_format) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py, METHOD: _format_settings) ---
            --- METHOD SOURCE (MODULE: web, FILE: res_users_settings.py, METHOD: _format_settings) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _format_settings) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatClAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_cl) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatCoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_co) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_eu) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_hu) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _format_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_sm) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_vn) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> FromRequestFileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _from_request_file) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FullPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _full_path) ---
            */
            return default;
        }

        public async Task<TEntity> GcBusPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: _gc_bus_presence) ---
            */
            return default;
        }

        public async Task<TEntity> GcDocIndexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: api_doc, FILE: ir_attachment.py, METHOD: _gc_doc_index) ---
            */
            return default;
        }

        public async Task<TEntity> GcFileStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _gc_file_store) ---
            */
            return default;
        }

        public async Task<TEntity> GcFileStoreUnsafeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _gc_file_store_unsafe) ---
            */
            return default;
        }

        public async Task<TEntity> GcInactiveSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _gc_inactive_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> GcPersonalMailServersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _gc_personal_mail_servers) ---
            */
            return default;
        }

        public async Task<TEntity> GcUnpinOutdatedSubChannelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _gc_unpin_outdated_sub_channels) ---
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py, METHOD: _gelato_prepare_address_payload) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAccessTokenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: generate_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _generate_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageAzureSasUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_azure_sas_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageAzureUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object blob_name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_azure_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageBlobNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_blob_name) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageDownloadInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageGoogleSignedUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bucket_name, object blob_name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_google_signed_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageGoogleUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object blob_name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_google_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageUploadInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCloudStorageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateOnboardingTodoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _generate_onboarding_todo) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateProfileTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, object email) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _generate_profile_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateRandomTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_random_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _generate_signup_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateSignupValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object provider, object validation, object @params) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _generate_signup_values) ---
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: geo_localize) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: _geo_localize) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountStatisticsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_account_statistics_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActivityGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: contacts, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _get_activity_groups) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_address_format) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_all_addr) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedChannelMemberCreateParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_channel_member_create_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessageParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_amounts_and_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetApplicationGroupsAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_users.py, METHOD: get_application_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: get_attendee_detail) ---
            */
            return default;
        }

        public async Task<TEntity> GetAuthMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_auth_methods) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: contacts, FILE: res_partner.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBusyCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _get_busy_calendar_events) ---
            */
            return default;
        }

        public async Task<TEntity> GetCallNotificationTagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_call_notification_tag) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChannelsAsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_channels_as_member) ---
            */
            return default;
        }

        public async Task<TEntity> GetCloudStorageAzureInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _get_cloud_storage_azure_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetCloudStorageGoogleInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _get_cloud_storage_google_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetCloudStorageUnsupportedModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _get_cloud_storage_unsupported_models) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCompanyCurrencyIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: get_company_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetContactOpportunitiesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_country_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_current_partner) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_current_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_current_persona) ---
            */
            return default;
        }

        public async Task<TEntity> GetDatasRelatedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object mimetype) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_datas_related_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWarehouseIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: _get_default_warehouse_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_users.py, METHOD: _get_default_warehouse_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryAddressDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_edi_builder) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmailDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_email_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_email_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmbeddedActionsSettingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_users_settings.py, METHOD: get_embedded_actions_settings) ---
            --- METHOD SOURCE (MODULE: web, FILE: res_users_settings.py, METHOD: get_embedded_actions_settings) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeFieldsToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _get_employee_fields_to_sync) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: _get_employee_fields_to_sync) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_employees_from_attendees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFieldsBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_followup_overdue_query) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: get_followup_table_html) ---
            */
            return default;
        }

        public async Task<TEntity> GetForbiddenAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, string operation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_forbidden_access) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFrontendWritableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetGamificationRedirectionDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleCalendarTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _get_google_calendar_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleSyncStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _get_google_sync_status) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetGroupDefinitionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_group_definitions) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_group_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_guest_from_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_guest_from_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetHtmlLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_html_link) ---
            */
            return default;
        }

        public async Task<TEntity> GetHtmlLinkTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_html_link_title) ---
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvalidationFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_invalidation_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetKarmaPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_karma_position) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_last_messages) ---
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_latest) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockTimeoutInactivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_lock_timeout_inactivity) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockTimeoutsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_lock_timeouts) ---
            */
            return default;
        }

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_login_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLoginDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object login) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_login_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_login_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLoginOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_login_order) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_login_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailServerSetupEndActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object smtp_server) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailServerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object server_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMediaInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _get_media_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_suggestions_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions_from_channel) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMessageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_message_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftCalendarTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _get_microsoft_calendar_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftSyncStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _get_microsoft_sync_status) ---
            */
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_needaction_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewPartnerAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: get_new_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextRankInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_next_rank) ---
            */
            return default;
        }

        public async Task<TEntity> GetNotifyValidParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_notify_valid_parameters) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrCreateChatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object pin) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_or_create_chat) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrCreateGuestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_or_create_guest) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnershipTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_ownership_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_participant_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_partner_from_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: get_partner_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_partners) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPasswordPolicyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: get_password_policy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data, object sha) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_path) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEndpointValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object field, object eas) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_endpoint_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format, object process_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_peppol_verification_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetPersonalInfoPartnerIdsToNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object employee) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _get_personal_info_partner_ids_to_notify) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalAccessUpdateBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_granted) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_portal_access_update_body) ---
            */
            return default;
        }

        public async Task<TEntity> GetRawAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_raw_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> GetRtcInviteMembersDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_rtc_invite_members_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRtcServerInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rtc_session, object ice_servers, object key) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_rtc_server_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _get_sale_order_domain_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> GetSearchDomainShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_search_domain_share) ---
            */
            return default;
        }

        public async Task<TEntity> GetSelectedCalendarsPartnerIdsAsync<TEntity>(IEnumerable<TEntity> entities, object include_user) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: get_selected_calendars_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetServeAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object extra_domain, object order) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_attachment.py, METHOD: _get_serve_attachment) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_serve_attachment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetServingGroupsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_attachment.py, METHOD: get_serving_groups) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: get_serving_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionTokenFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionTokenQueryParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _get_session_token_query_params) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_session_token_query_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSignupInvitationScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _get_signup_invitation_scope) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_signup_invitation_scope) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url_for_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetStorageDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_storage_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAttachmentFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_attachment_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreExtraFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _get_store_extra_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreGuestFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_store_guest_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreLinkedMessagesFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_linked_messages_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreLivechatUsernameFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _get_store_livechat_username_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMentionFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_mention_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMessageUpdateExtraFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_store_message_update_extra_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreOwnershipFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_store_ownership_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStorePartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_store_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStorePartnerNameFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_partner_name_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _get_street_split) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_suggested_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_ubl_cii_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetThumbnailTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_thumbnail_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetTimezoneFromRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_timezone_from_request) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotpInviteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: get_totp_invite_url) ---
            --- METHOD SOURCE (MODULE: auth_totp_portal, FILE: res_users.py, METHOD: get_totp_invite_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotpMailCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _get_totp_mail_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotpMailKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _get_totp_mail_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackingKarmaGainPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_domain, object from_date, object to_date) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_tracking_karma_gain_position) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackingValuesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_term) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_tracking_values_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_by_country) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserBadgeLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_user_badge_level) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<string>> GetUserCalendarConfigurationFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _get_user_calendar_configuration_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserTypeGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_user_type_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetVatRequiredValidInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_vat_required_valid) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _get_vat_required_valid) ---
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _get_vcard_file) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewGroupHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_view_group_hierarchy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewPostprocessedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view, object arch) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_view_postprocessed) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_views) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id, object mode) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_with_access) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: get_working_hours_for_all_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py, METHOD: get_worklocation) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleCalendarAuthenticatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _google_calendar_authenticated) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_img) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _google_map_signed_img) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HasAnyActiveSynchronizationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> HasAttachmentsOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_tokens) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _has_attachments_ownership) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<bool> HasGroupAsync<TEntity>(IEnumerable<TEntity> entities, Guid group_ext_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: has_group) ---
            */
            return default;
        }

        public async Task<bool> HasGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid group_ext_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _has_group) ---
            */
            return default;
        }

        public async Task<bool> HasGroupsAsync<TEntity>(IEnumerable<TEntity> entities, string group_spec) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: has_groups) ---
            */
            return default;
        }

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _has_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _has_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HasSetupCredentialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _has_setup_credentials) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HasSetupMicrosoftCredentialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _has_setup_microsoft_credentials) ---
            */
            return default;
        }

        public async Task<TEntity> HideAndNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_link_preview.py, METHOD: _hide_and_notify) ---
            */
            return default;
        }

        public async Task<TEntity> IapPartnerAutocompleteGetTagIdsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: iap_partner_autocomplete_get_tag_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceIndustryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_industry_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_language_codes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_location_codes) ---
            */
            return default;
        }

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _ie_check_char) ---
            */
            return default;
        }

        public async Task<TEntity> InaccessibleComodelRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> model_and_ids, string operation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inaccessible_comodel_records) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InactiveRtcSessionDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _inactive_rtc_session_domain) ---
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, string field, int n) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _increase_rank) ---
            */
            return default;
        }

        public async Task<TEntity> IndexDocxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_docx) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IndexInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data, string file_type, object checksum) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _index) ---
            */
            return default;
        }

        public async Task<TEntity> IndexOpendocInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_opendoc) ---
            */
            return default;
        }

        public async Task<TEntity> IndexPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> IndexPptxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_pptx) ---
            */
            return default;
        }

        public async Task<TEntity> IndexXlsxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_xlsx) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_attachment.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InitMessagingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_messaging) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_messaging) ---
            */
            return default;
        }

        public async Task<TEntity> InitOdoobotInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: _init_odoobot) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InitStoreDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_store_data) ---
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _interval_to_business_hours) ---
            */
            return default;
        }

        public async Task<TEntity> InvalidateDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, Guid res_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _invalidate_documents) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _inverse_all_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCalendarResUsersSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _inverse_calendar_res_users_settings) ---
            */
            return default;
        }

        public async Task<TEntity> InverseChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _inverse_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDatasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inverse_datas) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLivechatExpertiseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_expertise_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLivechatLangIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_lang_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLockTimeout2faSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _inverse_lock_timeout_2fa_selection) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLockTimeoutInactivity2faSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _inverse_lock_timeout_inactivity_2fa_selection) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNotificationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _inverse_notification_type) ---
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _inverse_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> InverseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inverse_raw) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _inverse_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _inverse_token) ---
            */
            return default;
        }

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _inverse_vat) ---
            */
            return default;
        }

        public async Task<TEntity> InviteByEmailAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: invite_by_email) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _invoice_total) ---
            */
            return default;
        }

        public async Task<TEntity> IsAdminInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_admin) ---
            */
            return default;
        }

        public async Task<TEntity> IsDomainThottledInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_link_preview.py, METHOD: _is_domain_thottled) ---
            */
            return default;
        }

        public async Task<TEntity> IsEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_empty) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsFeatureEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities, object group_reference) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _is_feature_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> IsGoogleCalendarSyncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: is_google_calendar_synced) ---
            */
            return default;
        }

        public async Task<TEntity> IsGoogleCalendarValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _is_google_calendar_valid) ---
            */
            return default;
        }

        public async Task<TEntity> IsInternalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_internal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsLinkPreviewEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_link_preview.py, METHOD: _is_link_preview_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> IsMicrosoftCalendarValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _is_microsoft_calendar_valid) ---
            */
            return default;
        }

        public async Task<TEntity> IsPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_portal) ---
            */
            return default;
        }

        public async Task<TEntity> IsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_public) ---
            */
            return default;
        }

        public async Task<TEntity> IsRemoteSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _is_remote_source) ---
            */
            return default;
        }

        public async Task<TEntity> IsSuperuserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_superuser) ---
            */
            return default;
        }

        public async Task<TEntity> IsSystemInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_system) ---
            */
            return default;
        }

        public async Task<TEntity> IsThreadMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object thread) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_thread_message) ---
            */
            return default;
        }

        public async Task<TEntity> IsThreadMessageVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object thread) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_thread_message_visible) ---
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: is_valid_ruc_ec) ---
            */
            return default;
        }

        public async Task<TEntity> JoinSfuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ice_servers, object force) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _join_sfu) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> LazyLoadMembersChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _lazy_load_members_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> LegacySessionTokenHashComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sid) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _legacy_session_token_hash_compute) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_partner.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _log_verification_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> LoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credential, object user_agent_env) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _login) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _login) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _login) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        public async Task<object> MakeAccessErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, string operation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _make_access_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MarkAllAsReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: mark_all_as_read) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid last_message_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _mark_as_read) ---
            */
            return default;
        }

        public async Task<TEntity> MarkForGcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _mark_for_gc) ---
            */
            return default;
        }

        public async Task<TEntity> MemberBasedNamingChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _member_based_naming_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _merge_method) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> MessageNotificationsToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_notifications_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MessageReactionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, object action, object partner, object guest, object store) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_reaction) ---
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_receive_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_subscribe) ---
            */
            return default;
        }

        protected async Task<object> MessageUpdateContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_update_content) ---
            */
            return default;
        }

        public async Task<TEntity> MfaTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _mfa_type) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _mfa_type) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _mfa_type) ---
            */
            return default;
        }

        public async Task<TEntity> MfaUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _mfa_url) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _mfa_url) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _mfa_url) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftCalendarAuthenticatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _microsoft_calendar_authenticated) ---
            */
            return default;
        }

        public async Task<TEntity> MigrateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _migrate) ---
            */
            return default;
        }

        public async Task<TEntity> MigrateLocalToCloudStorageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py, METHOD: _migrate_local_to_cloud_storage) ---
            */
            return default;
        }

        public async Task<TEntity> MigrateRemoteToLocalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _migrate_remote_to_local) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _migrate_remote_to_local) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _mondialrelay_search_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: name_search) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: name_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: new) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByWebPushPreparePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object force_record_name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_by_web_push_prepare_payload) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyInviterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _notify_inviter) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyMessageNotificationUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _notify_message_notification_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyMuteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _notify_mute) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyPeersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object notifications) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _notify_peers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifySecurityNewConnectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object auth_info) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _notify_security_new_connection) ---
            */
            return default;
        }

        public async Task<TEntity> NotifySecuritySettingUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object subject, object content, object mail_values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _notify_security_setting_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifySecuritySettingUpdatePrepareValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _notify_security_setting_update_prepare_values) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _notify_security_setting_update_prepare_values) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByWebPushInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread_by_web_push) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyTypingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_typing) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _notify_typing) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: on_change_login) ---
            */
            return default;
        }

        public async Task<TEntity> OnLoginCooldownInternalAsync<TEntity>(IEnumerable<TEntity> entities, object failures, object previous) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _on_login_cooldown) ---
            */
            return default;
        }

        public async Task<TEntity> OnWebclientBootstrapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: _on_webclient_bootstrap) ---
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: _on_webclient_bootstrap) ---
            */
            return default;
        }

        public async Task<TEntity> OnboardUsersIntoProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_users.py, METHOD: _onboard_users_into_project) ---
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _onboard_users_into_project) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: onchange) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_city_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeHasLockTimeoutInactivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_has_lock_timeout_inactivity) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeHasLockTimeoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_has_lock_timeout) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLockTimeoutDelayUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_lock_timeout_delay_unit) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLockTimeoutInactivityDelayUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_lock_timeout_inactivity_delay_unit) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _onchange_property_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeRoleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _onchange_role) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _onchange_vat) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVerifyPeppolStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _onchange_verify_peppol_status) ---
            */
            return default;
        }

        public async Task<TEntity> OndeleteSignupCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _ondelete_signup_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: res_users.py, METHOD: open_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _order) ---
            */
            return default;
        }

        public async Task<TEntity> PauseGoogleSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: pause_google_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> PauseMicrosoftSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: pause_microsoft_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_due_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_earliest_date_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_overdue_search) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _peppol_eas_endpoint_depends) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PeppolLookupParticipantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _peppol_lookup_participant) ---
            */
            return default;
        }

        public async Task<TEntity> PostAddCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessContentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _postprocess_contents) ---
            */
            return default;
        }

        public async Task<TEntity> PreferenceChangePasswordAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: preference_change_password) ---
            */
            return default;
        }

        public async Task<TEntity> PreferenceSaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: preference_save) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _process_enriched_response) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessProfileValidationTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object email) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _process_profile_validation_token) ---
            */
            return default;
        }

        public async Task<TEntity> RankChangedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _rank_changed) ---
            */
            return default;
        }

        public async Task<TEntity> ReactionGroupToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object content) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _reaction_group_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: read) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeRankBulkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _recompute_rank_bulk) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeRankInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _recompute_rank) ---
            */
            return default;
        }

        public async Task<TEntity> RecordByMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _record_by_message) ---
            */
            return default;
        }

        public async Task<TEntity> RecordsByModelNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _records_by_model_name) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshGoogleCalendarTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _refresh_google_calendar_token) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshMicrosoftCalendarTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _refresh_microsoft_calendar_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RegenerateAssetsBundlesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: regenerate_assets_bundles) ---
            */
            return default;
        }

        public async Task<TEntity> RegisterAsMainAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: register_as_main_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> RegisterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _register_hook) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object implied_group) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _remove_group) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveOauthAccessTokenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: remove_oauth_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveRecruitmentInterviewersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py, METHOD: _remove_recruitment_interviewers) ---
            */
            return default;
        }

        public async Task<TEntity> ResUsersSettingsFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_format) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _res_users_settings_format) ---
            */
            return default;
        }

        public async Task<TEntity> ResetPasswordAsync<TEntity>(IEnumerable<TEntity> entities, object login) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: reset_password) ---
            */
            return default;
        }

        public async Task<TEntity> RestartGoogleSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: restart_google_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> RestartMicrosoftSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: restart_microsoft_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_phone_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_vat) ---
            */
            return default;
        }

        public async Task<TEntity> RevokeAllDevicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: revoke_all_devices) ---
            */
            return default;
        }

        public async Task<TEntity> RevokeAllDevicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _revoke_all_devices) ---
            */
            return default;
        }

        public async Task<TEntity> RpcApiKeysOnlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            */
            return default;
        }

        public async Task<TEntity> RtcCancelInvitationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _rtc_cancel_invitations) ---
            */
            return default;
        }

        public async Task<TEntity> RtcInviteMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_invite_members) ---
            */
            return default;
        }

        public async Task<TEntity> RtcJoinCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, List<Guid> check_rtc_session_ids, object camera) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_join_call) ---
            */
            return default;
        }

        public async Task<TEntity> RtcLeaveCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_leave_call) ---
            */
            return default;
        }

        public async Task<TEntity> RtcSyncSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> check_rtc_session_ids) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_sync_sessions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunVatChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object vat, object partner_name, object validation) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _run_vat_checks) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _run_vat_checks) ---
            */
            return default;
        }

        public async Task<TEntity> SELFREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            */
            return default;
        }

        public async Task<TEntity> SELFWRITEABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SameContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bin_data, object filepath) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _same_content) ---
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAllGroupIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_all_group_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAllImpliedByIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_implied_by_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAllImpliedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_implied_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAllUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCompanyEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _search_company_employee) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCrmTeamIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _search_crm_team_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: search_for_channel_invite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> SearchFullNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_full_name) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_has_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsPinnedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _search_is_pinned) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _search_is_self) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _search_is_subcontractor) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchNeedactionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_needaction) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchOrCreateFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_link_preview.py, METHOD: _search_or_create_from_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchResUsersSettingsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_res_users_settings_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_completed_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchStarredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_starred) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _search_state) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SelfAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _self_accessible_fields) ---
            */
            return default;
        }

        public async Task<TEntity> SendPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object im_status, object bus_target) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: _send_presence) ---
            */
            return default;
        }

        public async Task<TEntity> SendProfileValidationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _send_profile_validation_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendTotpMailCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _send_totp_mail_code) ---
            */
            return default;
        }

        public async Task<TEntity> SendUnregisteredUserReminderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: send_unregistered_user_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> SessionTokenGetValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _session_token_get_values) ---
            */
            return default;
        }

        public async Task<TEntity> SessionTokenHashComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sid, object field_values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _session_token_hash_compute) ---
            */
            return default;
        }

        public async Task<TEntity> SetAttachmentDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object asbytes) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _set_attachment_data) ---
            */
            return default;
        }

        public async Task<TEntity> SetAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _set_auth_cookie) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _set_calendar_last_notif_ack) ---
            */
            return default;
        }

        public async Task<TEntity> SetEmbeddedActionsSettingAsync<TEntity>(IEnumerable<TEntity> entities, Guid action_id, Guid res_id, object vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_users_settings.py, METHOD: set_embedded_actions_setting) ---
            */
            return default;
        }

        public async Task<TEntity> SetEmptyPasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _set_empty_password) ---
            */
            return default;
        }

        public async Task<TEntity> SetEncryptedPasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uid, object pw) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_encrypted_password) ---
            */
            return default;
        }

        public async Task<TEntity> SetGoogleAuthTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token, object refresh_token, object ttl) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _set_google_auth_tokens) ---
            */
            return default;
        }

        public async Task<TEntity> SetICPFirstSynchronizationDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object now) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _set_ICP_first_synchronization_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetLastSeenMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object notify) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _set_last_seen_message) ---
            */
            return default;
        }

        public async Task<TEntity> SetMessageDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: set_message_done) ---
            */
            return default;
        }

        public async Task<TEntity> SetMessagePinAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id, object pinned) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: set_message_pin) ---
            */
            return default;
        }

        public async Task<TEntity> SetMicrosoftAuthTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token, object refresh_token, object ttl) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: res_users.py, METHOD: _set_microsoft_auth_tokens) ---
            */
            return default;
        }

        public async Task<TEntity> SetNewMessageSeparatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _set_new_message_separator) ---
            */
            return default;
        }

        public async Task<TEntity> SetNewPasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_new_password) ---
            */
            return default;
        }

        public async Task<TEntity> SetPasswordInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: _set_password) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_password) ---
            */
            return default;
        }

        public async Task<TEntity> SetResUsersSettingsAsync<TEntity>(IEnumerable<TEntity> entities, object new_settings) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py, METHOD: set_res_users_settings) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: set_res_users_settings) ---
            */
            return default;
        }

        public async Task<TEntity> SetVoiceMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _set_voice_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeSettingAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object volume, Guid guest_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py, METHOD: set_volume_setting) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldCaptchaLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credential) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: _should_captcha_login) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldInviteMembersToJoinCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupAsync<TEntity>(IEnumerable<TEntity> entities, object values, object token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: signup) ---
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_cancel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupCreateUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _signup_create_user) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _signup_create_user) ---
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_get_auth_param) ---
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_prepare) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_partner) ---
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _split_vat) ---
            */
            return default;
        }

        public async Task<TEntity> StopGoogleSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: stop_google_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> StopMicrosoftSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: stop_microsoft_synchronization) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StorageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _storage) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyGetMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SwitchTourEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: res_users.py, METHOD: switch_tour_enabled) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncAllGoogleCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_all_google_calendar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncAllMicrosoftCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _sync_all_microsoft_calendar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _sync_field_names) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _sync_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> SyncGoogleCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object calendar_service) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_google_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> SyncMicrosoftCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _sync_microsoft_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> SyncRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object calendar_service, Guid event_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_request) ---
            */
            return default;
        }

        public async Task<TEntity> SyncSingleEventInternalAsync<TEntity>(IEnumerable<TEntity> entities, object calendar_service, object odoo_event, Guid event_id) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_single_event) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> SystrayGetCalendarEventDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _systray_get_calendar_event_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ToHttpStreamInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _to_http_stream) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _to_http_stream) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_link_preview.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_link_preview.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToStorePersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _to_store_persona) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleMessageStarredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: toggle_message_starred) ---
            */
            return default;
        }

        public async Task<TEntity> TotpEnableSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_enable_search) ---
            */
            return default;
        }

        public async Task<TEntity> TotpRateLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_rate_limit) ---
            */
            return default;
        }

        public async Task<TEntity> TotpRateLimitPurgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_rate_limit_purge) ---
            */
            return default;
        }

        public async Task<TEntity> TotpTrySettingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object secret, object code) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_try_setting) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TryUpdatePresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_or_guest, object inactivity_period) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: _try_update_presence) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingSeenInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_seen_infos) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAndNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_link_preview.py, METHOD: _unlink_and_notify) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkContactRelEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _unlink_contact_rel_employee) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptAllEmployeeChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _unlink_except_all_employee_channel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptGovernmentDocumentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: ir_attachment.py, METHOD: _unlink_except_government_document) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptSettingsGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _unlink_except_settings_group) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _unlink_if_partner_in_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPosNoOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _unlink_if_pos_no_orders) ---
            */
            return default;
        }

        public async Task<TEntity> UnpauseGoogleSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: unpause_google_synchronization) ---
            */
            return default;
        }

        public async Task<TEntity> UnpauseMicrosoftSynchronizationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: unpause_microsoft_synchronization) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UnstarAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: unstar_all) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribeFromNonPublicChannelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _unsubscribe_from_non_public_channels) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAndBroadcastInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _update_and_broadcast) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdateLastLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _update_last_login) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _update_name) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _update_peppol_state_per_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdatePresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_or_guest, object inactivity_period) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: _update_presence) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timezone) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _update_timezone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: web_create_users) ---
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_users.py, METHOD: web_create_users) ---
            */
            return default;
        }

        public async Task<TEntity> WebsitePublishButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: website_publish_button) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_presence.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBusListenerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}