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
    public partial class IrActionsActionsAppService : ApplicationService, IIrActionsActionsAppService
    {

        public IrActionsActionsAppService() 
        {

        }

        public async Task<TEntity> ActionConfigureExternalReportLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _action_configure_external_report_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: action_open_parent_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenScheduledActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: action_open_scheduled_action) ---
            */
            return default;
        }

        public async Task<TEntity> AssociatedViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: associated_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode_type, object @value) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildWkhtmltopdfArgsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid paperformat_id, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _build_wkhtmltopdf_args) ---
            */
            return default;
        }

        public async Task<TEntity> CanExecuteActionOnRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _can_execute_action_on_records) ---
            */
            return default;
        }

        public async Task<TEntity> CheckChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_children) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_model) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_path) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPythonCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_python_code) ---
            */
            return default;
        }

        public async Task<TEntity> CheckViewModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_view_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_allowed_states) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableModelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_available_model_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCrudRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_crud_relations) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_embedded_actions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _compute_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_params) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCodeHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_show_code_history) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValueFieldToShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_value_field_to_show) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_views) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebhookSamplePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_webhook_sample_payload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create_action) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: create_action) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUpdatePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _default_update_path) ---
            */
            return default;
        }

        public async Task<TEntity> EvalValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _eval_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ExistingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _existing) ---
            */
            return default;
        }

        public async Task<TEntity> ExistsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: exists) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ForXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid full_xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _for_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateActionNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _generate_action_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_action_dict) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_action_dict) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableBarcodeMasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_available_barcode_masks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetBindingsAsync<TEntity>(IEnumerable<TEntity> entities, object model_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: get_bindings) ---
            */
            return default;
        }

        public async Task<TEntity> GetBindingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_bindings) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChildrenDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_children_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetEvalContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_eval_context) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_eval_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_layout) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_paperformat) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatByXmlidAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_paperformat_by_xmlid) ---
            */
            return default;
        }

        public async Task<TEntity> GetReadableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_readable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelationChainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object searched_field_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_relation_chain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_rendering_context_model) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReportFromNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report_from_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetRunnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_runner) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidActionReportsAsync<TEntity>(IEnumerable<TEntity> entities, object model, List<Guid> record_ids) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_valid_action_reports) ---
            */
            return default;
        }

        public async Task<TEntity> GetWarningMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_warning_messages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWkhtmltopdfStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_wkhtmltopdf_state) ---
            */
            return default;
        }

        public async Task<TEntity> HandleMergePdfsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, object error_stream) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _handle_merge_pdfs_error) ---
            */
            return default;
        }

        public async Task<TEntity> HistoryWizardActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: history_wizard_action) ---
            */
            return default;
        }

        public async Task<TEntity> InverseParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _inverse_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MergePdfsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object streams, object handle_error) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _merge_pdfs) ---
            */
            return default;
        }

        public async Task<TEntity> NameDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _name_depends) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _onchange_name) ---
            */
            return default;
        }

        public async Task<TEntity> PreRenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _pre_render_qweb_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object report_model) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareLocalAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_local_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePdfReportAttachmentValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object streams) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_pdf_report_attachment_vals_list) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderQwebHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_html) ---
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfPrepareStreamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object data, List<Guid> res_ids) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderQwebTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_text) ---
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_template) ---
            */
            return default;
        }

        public async Task<TEntity> ReportActionAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data, object config) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: report_action) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: retrieve_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionCodeMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_code_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_copy) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_create) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_write) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionWebhookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_webhook) ---
            */
            return default;
        }

        public async Task<TEntity> RunAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: run) ---
            */
            return default;
        }

        public async Task<TEntity> RunInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run) ---
            */
            return default;
        }

        public async Task<List<object>> RunWkhtmltoimageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object width, object height, object image_format) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _run_wkhtmltoimage) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunWkhtmltopdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object report_ref, object header, object footer, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _run_wkhtmltopdf) ---
            */
            return default;
        }

        public async Task<TEntity> SearchModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _search_model_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SelectionTargetModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _selection_target_model) ---
            */
            return default;
        }

        public async Task<TEntity> SetCrudModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_crud_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> SetResourceRefInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_resource_ref) ---
            */
            return default;
        }

        public async Task<TEntity> SetSelectionValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_selection_value) ---
            */
            return default;
        }

        public async Task<TEntity> TraversePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _traverse_path) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: unlink_action) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: unlink_action) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkCheckHomeActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _unlink_check_home_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WarningDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _warning_depends) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: write) ---
            */
            return default;
        }
    }
}