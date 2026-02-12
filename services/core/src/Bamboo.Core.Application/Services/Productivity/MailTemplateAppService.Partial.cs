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
    public partial class MailTemplateAppService
    {

        protected async Task<MailTemplate> CheckAbstractModelsInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_abstract_models) ---
            */
            return default;
        }

        protected async Task<MailTemplate> CheckCanBeRenderedInternalAsync(object fnames, object render_options)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_can_be_rendered) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeCanWriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_can_write) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeHasDynamicReportsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_dynamic_reports) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeHasMailServerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_mail_server) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeIsTemplateEditorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_is_template_editor) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeRenderModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ComputeTemplateCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_template_category) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ExpressionIsDefaultInternalAsync(object source, object model, object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _expression_is_default) ---
            */
            return default;
        }

        protected async Task<MailTemplate> FixAttachmentOwnershipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GenerateTemplateAttachmentsInternalAsync(List<Guid> res_ids, object render_fields, object render_results)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_attachments) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GenerateTemplateInternalAsync(List<Guid> res_ids, object render_fields, object recipients_allow_suggested, object find_or_create_partners)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GenerateTemplateRecipientsInternalAsync(List<Guid> res_ids, object render_fields, object allow_suggested, object find_or_create_partners, object render_results)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_recipients) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GenerateTemplateScheduledDateInternalAsync(List<Guid> res_ids, object render_results)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_scheduled_date) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GenerateTemplateStaticValuesInternalAsync(List<Guid> res_ids, object render_fields, object render_results)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_static_values) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GetDynamicFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_dynamic_field_names) ---
            */
            return default;
        }

        protected async Task<MailTemplate> GetNonAbstractModelsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_non_abstract_models_domain) ---
            */
            return default;
        }

        protected async Task<MailTemplate> HasUnsafeExpressionTemplateInlineTemplateInternalAsync(object source, object model, object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_inline_template) ---
            */
            return default;
        }

        protected async Task<MailTemplate> HasUnsafeExpressionTemplateQwebInternalAsync(object source, object model, object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_qweb) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailTemplate> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: mail_template.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailTemplate> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: mail_template.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<MailTemplate> OnchangeModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _onchange_model) ---
            */
            return default;
        }

        protected async Task<MailTemplate> ParsePartnerToInternalAsync(object partner_to)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _parse_partner_to) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailTemplate> SearchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: mail_template.py, METHOD: _search) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailTemplate> SearchTemplateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _search_template_category) ---
            */
            return default;
        }

        protected async Task<MailTemplate> SendCheckAccessInternalAsync(List<Guid> res_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _send_check_access) ---
            */
            return default;
        }

        protected async Task<MailTemplate> UnlinkExceptMasterMailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_template.py, METHOD: _unlink_except_master_mail_template) ---
            */
            return default;
        }
    }
}