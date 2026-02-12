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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class TemplateResetMixinAppService : ApplicationService, ITemplateResetMixinAppService
    {

        public TemplateResetMixinAppService() 
        {

        }

        public async Task<TEntity> ActionCreateSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_create_sidebar_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenMailPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: action_open_mail_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_unlink_sidebar_action) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAbstractModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_abstract_models) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanBeRenderedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object render_options) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_can_be_rendered) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_can_write) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasDynamicReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_dynamic_reports) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_is_template_editor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_template_category) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: create_action) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> ExpressionIsDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _expression_is_default) ---
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object recipients_allow_suggested, object find_or_create_partners) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object allow_suggested, object find_or_create_partners, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_scheduled_date) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateStaticValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_static_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetDynamicFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_dynamic_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetNonAbstractModelsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_non_abstract_models_domain) ---
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateInlineTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_inline_template) ---
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateQwebInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_qweb) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _onchange_model) ---
            */
            return default;
        }

        public async Task<TEntity> OverrideTranslationTermInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module_name, List<Guid> xml_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py, METHOD: _override_translation_term) ---
            */
            return default;
        }

        protected async Task<object> ParsePartnerToInternalAsync(object partner_to)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _parse_partner_to) ---
            */
            return default;
        }

        public async Task<TEntity> ResetTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py, METHOD: reset_template) ---
            #endif
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _search_template_category) ---
            */
            return default;
        }

        public async Task<TEntity> SendCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _send_check_access) ---
            */
            return default;
        }

        public async Task<TEntity> SendMailAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendMailBatchAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail_batch) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink_action) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: write) ---
            */
            return default;
        }
    }
}