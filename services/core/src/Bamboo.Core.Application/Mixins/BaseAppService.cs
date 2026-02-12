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
    [Module("base", Category = "Base")]
    public partial class BaseAppService : ApplicationService, IBaseAppService
    {

        public BaseAppService() 
        {

        }

        public async Task<TEntity> AddGroupbyValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_read_specification, List<string> groupby, List<object> current_groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _add_groupby_values) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object @alias) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: models.py, METHOD: _alias_get_error) ---
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _alias_get_error) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: models.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> FindValueFromFieldPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_path) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _find_value_from_field_path) ---
            */
            return default;
        }

        public async Task<TEntity> FormatWebSearchReadResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object records, object offset, object limit, object count_limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _format_web_search_read_results) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<Dictionary<string, object>>> FormattedReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, int offset, object limit, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: formatted_read_group) ---
            */
            return default;
        }

        public async Task<TEntity> FormattedReadGroupWithLengthInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object offset, object limit, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _formatted_read_group_with_length) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattedReadGroupingSetsAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object grouping_sets, object aggregates) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: formatted_read_grouping_sets) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_model.py, METHOD: _get_base_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_model.py, METHOD: get_base_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultActivityViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _get_default_activity_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultCalendarViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_calendar_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultFormViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_form_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultGraphViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_graph_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultKanbanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_kanban_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultListViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_list_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPivotViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_pivot_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultSearchViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_search_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<string> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, string help_message) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldTranslationsAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object langs) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: models.py, METHOD: get_field_translations) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFieldsSpecInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_info) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_fields_spec) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_formview_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetHtmlLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object title) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _get_html_link) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<string> GetReadGroupOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dict_order, List<string> groupby, object aggregates) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _get_read_group_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecordsActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_records_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_cache) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewFieldAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: models.py, METHOD: _get_view_field_attributes) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_field_attributes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_type, object models) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewPostprocessedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view, object arch) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_postprocessed) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_model.py, METHOD: get_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HierarchyReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object specification, object parent_field, object child_field, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: models.py, METHOD: hierarchy_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailAllowedQwebExpressionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: mail_allowed_qweb_expressions) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetAliasDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_company) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_alias_domains) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_companies) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetCompanyFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_company_field) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_customer) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: mail_get_partner_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetPrimaryEmailFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_primary_email_field) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPrimaryEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_primary_email) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_get_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> MailGroupByOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_group_by_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailTrackGetFieldSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_track_get_field_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> MailTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracked_fields, object initial_values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_track) ---
            */
            return default;
        }

        public async Task<TEntity> MailTrackOrderFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracked_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _mail_track_order_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_primary_email) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _message_add_suggested_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_cc, object all_tos) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _message_get_default_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reply_discussion, object reply_message, object no_create, object primary_email, object additional_partners) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _message_get_suggested_recipients_batch) ---
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reply_discussion, object reply_message, object no_create, object primary_email, object additional_partners) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _message_get_suggested_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object defaults, List<Guid> author_ids) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _notify_get_reply_to_batch) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToFormattedEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_email, Guid author_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _notify_get_reply_to_formatted_email) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> values, List<string> field_names, Dictionary<string, object> fields_spec) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: onchange) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OnchangeSpecInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_info) where TEntity : IEntity<Guid>, IBaseable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_spec) ---
            #endif
            return default;
        }

        public async Task<TEntity> OpenGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _open_groups) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object number, object country, object force_format, object raise_exception) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: models.py, METHOD: _phone_format) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneFormatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object number, object country, object force_format, object raise_exception) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: models.py, METHOD: _phone_format_number) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PhoneGetCountryFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: models.py, METHOD: _phone_get_country_field) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: models.py, METHOD: _phone_get_country) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: models.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadProgressBarAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object group_by, object progress_bar) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: read_progress_bar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelDomainImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object domain, object set_count, object limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _search_panel_domain_image) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelFieldImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _search_panel_field_image) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelGlobalCountersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_range, object parent_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _search_panel_global_counters) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSanitizedParentHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object parent_name, object ids) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _search_panel_sanitized_parent_hierarchy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectMultiRangeAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: search_panel_select_multi_range) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectRangeAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: search_panel_select_range) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectionRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _search_panel_selection_range) ---
            */
            return default;
        }

        public async Task<TEntity> SmsGetRecipientsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_field, object partner_fallback) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: models.py, METHOD: _sms_get_recipients_info) ---
            */
            return default;
        }

        public async Task<TEntity> SortSuggestedMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object messages) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _sort_suggested_messages) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py, METHOD: _valid_field_parameter) ---
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: view_header_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebNameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object specification, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_name_search) ---
            */
            return default;
        }

        public async Task<TEntity> WebOverrideTranslationsAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_override_translations) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync<TEntity>(IEnumerable<TEntity> entities, object specification) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object limit, int offset, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_read_group) ---
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupExpandInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groups, object groupby_spec, object aggregates, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_expand) ---
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupFieldExpandInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_field_expand) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebReadGroupFillTemporalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groups, object groupby, object aggregates, object fill_from, object fill_to, object min_groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_fill_temporal) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadGroupFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby, object aggregates, List<object> groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_format) ---
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupGroupbyFormatterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_spec, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_groupby_formatter) ---
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupGroupbyPropertiesFormatterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_spec, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _web_read_group_groupby_properties_formatter) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebResequenceAsync<TEntity>(IEnumerable<TEntity> entities, object specification, string field_name, int offset) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_resequence) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebSaveAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object specification, Guid next_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_save) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebSaveMultiAsync<TEntity>(IEnumerable<TEntity> entities, List<Dictionary<string, object>> vals_list, object specification) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_save_multi) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebSearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object specification, object offset, object limit, object order, object count_limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: web_search_read) ---
            */
            return default;
        }

        public async Task<TEntity> WithUserAsync<TEntity>(IEnumerable<TEntity> entities, object user) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: models.py, METHOD: with_user) ---
            */
            return default;
        }
    }
}