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
    public partial class IrActionsReportAppService : ApplicationService, IIrActionsReportAppService
    {

        public IrActionsReportAppService() 
        {

        }

        public async Task<TEntity> ActionConfigureExternalReportLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _action_configure_external_report_layout) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddPagesToWriterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object writer, object document, object prefix) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py, METHOD: _add_pages_to_writer) ---
            */
            return default;
        }

        public async Task<TEntity> AssociatedViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: associated_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode_type, object @value) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildWkhtmltopdfArgsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid paperformat_id, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _build_wkhtmltopdf_args) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _compute_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: create_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableBarcodeMasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_available_barcode_masks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCustomValueFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document, object form_field_name, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py, METHOD: _get_custom_value_from_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_layout) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: ir_actions_report.py, METHOD: get_paperformat) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_paperformat) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatByXmlidAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_paperformat_by_xmlid) ---
            */
            return default;
        }

        public async Task<TEntity> GetReadableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_readable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _get_rendering_context) ---
            --- METHOD SOURCE (MODULE: stock, FILE: ir_actions_report.py, METHOD: _get_rendering_context) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_rendering_context_model) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReportFromNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_name) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report_from_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _get_report_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplittedReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object content, object report_type) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _get_splitted_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidActionReportsAsync<TEntity>(IEnumerable<TEntity> entities, object model, List<Guid> record_ids) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_valid_action_reports) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValueFromPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object form_field, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py, METHOD: _get_value_from_path) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWkhtmltopdfStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: get_wkhtmltopdf_state) ---
            */
            return default;
        }

        public async Task<TEntity> HandleMergePdfsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, object error_stream) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _handle_merge_pdfs_error) ---
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _is_invoice_report) ---
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseOrderReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: ir_actions_report.py, METHOD: _is_purchase_order_report) ---
            */
            return default;
        }

        public async Task<TEntity> IsSaleOrderReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: ir_actions_report.py, METHOD: _is_sale_order_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MergePdfsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object streams, object handle_error) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _merge_pdfs) ---
            */
            return default;
        }

        public async Task<TEntity> PreRenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _pre_render_qweb_pdf) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _pre_render_qweb_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object report_model) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareLocalAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_local_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePdfReportAttachmentValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object streams) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _prepare_pdf_report_attachment_vals_list) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderQwebHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_html) ---
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfPrepareStreamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object data, List<Guid> res_ids) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: sale, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_pdf_prepare_streams) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderQwebTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_qweb_text) ---
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _render_template) ---
            */
            return default;
        }

        public async Task<TEntity> ReportActionAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data, object config) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: report_action) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: ir_actions_report.py, METHOD: retrieve_attachment) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: retrieve_attachment) ---
            */
            return default;
        }

        public async Task<List<object>> RunWkhtmltoimageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object width, object height, object image_format) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _run_wkhtmltoimage) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunWkhtmltopdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object report_ref, object header, object footer, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _run_wkhtmltopdf) ---
            */
            return default;
        }

        public async Task<TEntity> SearchModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: _search_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py, METHOD: unlink_action) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py, METHOD: _unlink_except_master_tags) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdateMappingAndAddPagesToWriterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object writer, object document, object form_fields_values_mapping, object prefix, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py, METHOD: _update_mapping_and_add_pages_to_writer) ---
            */
            return default;
        }
    }
}