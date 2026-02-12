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
    [Module("product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductCatalogMixinAppService : ApplicationService, IProductCatalogMixinAppService
    {

        public ProductCatalogMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAcknowledgeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_acknowledge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_activate_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_add_from_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAssignAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_assign) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_assign) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBillMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_bill_matching) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionClearLotProducingIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_clear_lot_producing_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ActionComputeBomDaysAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_compute_bom_days) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmMoBackordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_confirm_mo_backorders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_create_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_force_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateBackorderWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object quantity_issues) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_backorder_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateConsumptionWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object consumption_issues) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_consumption_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_serial) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_generate_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_download_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _action_invoice_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_merge) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_merge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMoveDownloadAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_move_download_all) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_discount_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_type) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOperationFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_open_operation_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPlanWithComponentsAvailabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_plan_with_components_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_post) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_preview_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_print_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_product_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPurchaseComparisonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_purchase_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairCancelDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _action_repair_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairEndAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_end) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairStartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_start) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRfqSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_rfq_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSeeMoveScrapAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_see_move_scrap) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_send_and_print) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetBomOnOrderpointAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_set_bom_on_orderpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSplitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_split) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_start) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_switch_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_toggle_block_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleIsLockedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_toggle_is_locked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnreserveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_unreserve) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_update_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_update_fpos_values) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateMovesWithConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_validate_moves_with_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_view_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_view_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMoDeliveryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mo_delivery) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionBackordersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_backorders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionChildsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_childs) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionSourcesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_sources) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionUnbuildsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_unbuilds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewReceptionReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_reception_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_view_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSerialNumbersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_serial_numbers) ---
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _add_base_lines_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> AddReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reference) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _add_reference) ---
            */
            return default;
        }

        public async Task<TEntity> AddSupplierToProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _add_supplier_to_product) ---
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        public async Task<TEntity> AmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _amount_all) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _apply_delta_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ApprovalAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _approval_allowed) ---
            */
            return default;
        }

        public async Task<TEntity> AreFinishedSerialsAlreadyProducedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lots, object excluded_sml) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _are_finished_serials_already_produced) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _auto_init) ---
            */
            return default;
        }

        public async Task<TEntity> AutoProductionChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _auto_production_checks) ---
            */
            return default;
        }

        public async Task<TEntity> AutoconfirmProductionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoconfirm_production) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_bill) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_size) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> AutoprintGeneratedLotInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid lot_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_generated_lot) ---
            */
            return default;
        }

        public async Task<TEntity> AutoprintMassGeneratedLotsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_mass_generated_lots) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BomFindDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object picking_type, Guid company_id, object bom_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BomFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object picking_type, Guid company_id, object bom_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find) ---
            */
            return default;
        }

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _build_credit_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonApproveAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_hash) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonMarkDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_mark_done) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonMarkDoneSanityChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _button_mark_done_sanity_checks) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonPlanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_plan) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_request_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonScrapAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_scrap) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_set_checked) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnbuildAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unbuild) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnplanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unplan) ---
            */
            return default;
        }

        public async Task<TEntity> CalPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object consumed_moves) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _cal_price) ---
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _calculate_hashes) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_be_unlinked) ---
            */
            return default;
        }

        protected async Task<object> CanCommitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_commit) ---
            */
            return default;
        }

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_force_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> CanProduceSerialNumbersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sns) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _can_produce_serial_numbers) ---
            */
            return default;
        }

        public async Task<TEntity> ChangeProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _change_producing) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_balanced) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBomCycleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_cycle) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBomLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CheckByproductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_byproducts) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_draftable) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_fiscal_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_journal_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> CheckKitHasNotOrderpointAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: check_kit_has_not_orderpoint) ---
            */
            return default;
        }

        public async Task<TEntity> CheckLotProducingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_lot_producing_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_move_sequence_chain) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _check_order_line_company_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_order_line_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSelectedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_selected_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSnUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_sn_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidBatchSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_valid_batch_size) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cleanup_write_orm_values) ---
            */
            return default;
        }

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _collect_tax_cash_basis_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_abnormal_warnings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntriesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entries_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginMovesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_moves_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedLotIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_lot_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_always_tax_exigible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalCcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_amount_total_cc) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount_total_words) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_undiscounted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_authorized_transaction_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_auto_post_until) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailabilityBooleanInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_availability_boolean) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_bank_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_bom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCheckedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_checked) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeComponentsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_components_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateCalendarStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_calendar_start) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_deadline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayAlertDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_delay_alert_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_direction_sign) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_inactive_currency_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayLinkQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_link_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplaySendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_duplicated_order_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_duplicated_order_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_duplicated_ref_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationExpectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration_expected) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_expected_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_fiscal_position_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForecastedIssueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_forecasted_issue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_active_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_archived_products) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_has_reconciled_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasUncompleteMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_has_uncomplete_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_hide_post_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highest_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighlightSendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highlight_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_date_due) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_default_sale_person) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_filter_type_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceHasOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_has_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceIncotermPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_incoterm_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_partner_display_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_being_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDelayedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_delayed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_is_expired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_planned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSaleInstalledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_sale_installed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_journal_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJsonPopoverInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_linked_attachment_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_locations) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_lot_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveByproductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_byproduct_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveFinishedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_finished_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveRawIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_raw_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: compute_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionSourceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_source_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_narration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_needed_terms) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_next_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOperationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_operation_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_credit_warning) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_invoice_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_shipping_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_parts_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_reconciled_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_to_reconcile_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_product_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_type_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingTypeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePossibleProductTemplateAttributeValueIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_possible_product_template_attribute_value_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_preferred_payment_method_line_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_pricelist_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductLocationDestIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_dest_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductLocationSrcIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_src_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_qty) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_product_uom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_purchase_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_edit_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_encoding_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReceiptReminderEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_receipt_reminder_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecycleLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_recycle_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReservationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_reservation_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_sale_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScrapMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_scrap_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_secured) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialNumbersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_serial_numbers_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowAllocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowComparisonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_show_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowGenerateBomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_generate_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLockInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLotIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lot_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLotsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lots) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowProduceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_produce) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_reset_to_draft_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowSetBomButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_show_set_bom_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_status_in_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_country_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDatePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxes_legal_notes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_type_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnbuildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unbuild_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnreserveVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unreserve_visible) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_unreserve_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_validity_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_workorder_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _confirmation_error_message) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _confirmation_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_account_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create_document_from_attachment) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentLinesFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object down_payment_base_lines) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_lines_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentSectionLineIfNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_section_line_if_needed) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownpaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_downpayments) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field, object name, object position) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _create_section) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateMoveFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _create_update_move_finished) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_upsell_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cron_account_move_send) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronSendPendingEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _cron_send_pending_emails) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _detach_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_discount_precision) ---
            */
            return default;
        }

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_recursion) ---
            */
            return default;
        }

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _discard_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> DoUnreserveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: do_unreserve) ---
            */
            return default;
        }

        public async Task<TEntity> EarlyPaymentDiscountMoveTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _early_payment_discount_move_types) ---
            */
            return default;
        }

        public async Task<TEntity> ExplodeAsync<TEntity>(IEnumerable<TEntity> entities, object product, object quantity, object picking_type, object never_attribute_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: explode) ---
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object @new) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _extend_with_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _fetch_duplicate_orders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _fetch_duplicate_orders) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _fetch_duplicate_reference) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string fname, object query) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_will_change) ---
            */
            return default;
        }

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _filter_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _find_and_set_purchase_orders) ---
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _find_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _force_lines_to_invoice_policy_order) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_and_send) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _generate_downpayment_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePortalPaymentQrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_portal_payment_qr) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date_source) ---
            */
            return default;
        }

        public async Task<TEntity> GetAcknowledgeUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_acknowledge_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product_catalog_mixin.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_with_base_document_layout_configurator) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_all_reconciled_invoice_partials) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_automatic_balancing_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutoprintDoneReportActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_autoprint_done_report_actions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableActionReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_invoice_report) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_action_reports) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackorderMoValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_backorder_mo_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetBomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ratio) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_bom_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chain_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chains_to_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_children) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmUrlAsync<TEntity>(IEnumerable<TEntity> entities, object confirm_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_confirm_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetConsumptionIssuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_consumption_issues) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_copiable_order_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopyMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_copy_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCreateSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _get_default_create_section_values) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_default_create_section_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_finished) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultIsLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_is_locked) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_default_payment_link_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultProductUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_default_product_uom_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_discount_allocation_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentIterateKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid move_raw_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_document_iterate_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetDomainIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_domain_is_late) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiBuildersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_edi_builders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_edi_builders) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_edi_creation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetExtraAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_extra_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_extra_print_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_detach) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_frequent_account_and_taxes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_inbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields_and_subfields) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_computed_reference) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_currency_rate_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_filter_type_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoice_grouping_keys) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_in_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents_all) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_next_payment_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_pdf_proforma) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_portal_extra_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_proforma_pdf_report_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension, object report) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_report_filename) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiceable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_last_sequence_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lines_onchange_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities, object date_planned) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_localized_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_location) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_thread_data_attachments) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveFinishedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object product_uom_qty, object product_uom, Guid operation_id, Guid byproduct_id, object cost_share) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_finished_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_hash_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_lines_to_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveRawValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object product_uom_qty, object product_uom, Guid operation_id, object bom_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_raw_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveZipExportDocsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_zip_export_docs) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesFinishedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_finished_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesRawValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_raw_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesRequiringConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_moves_requiring_confirmation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNameBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object sequence) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_name_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_name_invoice_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_portal_content_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_tax_totals_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewCatalogLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_new_catalog_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewLineSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field, Guid section_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _get_new_line_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_note_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_order_lines_to_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrderTimezoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_order_timezone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrdersToRemindInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_orders_to_remind) ---
            */
            return default;
        }

        public async Task<TEntity> GetOriginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_origin) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_outbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_partner_credit_warning_exclude_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_picking_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_portal_last_transaction) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalPaymentLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_portal_payment_link) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_portal_return_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_prepayment_required_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_priced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProducedQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_produced_qty) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids, object child_field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _get_product_catalog_order_line_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_protected_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_purchase_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuantityProducedIssuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_produced_issues) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuantityToBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_to_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_quick_edit_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetRatioBetweenMoAndBomQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bom) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ratio_between_mo_and_bom_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> GetReadyToProduceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ready_to_produce_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_amls) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices_partials) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_payments) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_statement_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_report_base_filename) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_report_base_filename) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_rounded_base_and_tax_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_sale_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSectionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _get_sections) ---
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sequence_date_range) ---
            */
            return default;
        }

        public async Task<TEntity> GetSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_sources) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_starting_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type, object company) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncStackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sync_stack) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unbalanced_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unlink_logger_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_update_prices_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdateUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_update_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_valid_journal_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_paid) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_signed) ---
            */
            return default;
        }

        public async Task<TEntity> HasWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _has_workorders) ---
            */
            return default;
        }

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _hash_moves) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_amount_total) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _inverse_lines) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            */
            return default;
        }

        public async Task<TEntity> IsActionReportAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_report, object is_invoice_report) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_action_report_available) ---
            */
            return default;
        }

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_confirmation_amount_reached) ---
            */
            return default;
        }

        public async Task<TEntity> IsDisplayStockInCatalogInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _is_display_stock_in_catalog) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _is_display_stock_in_catalog) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product_catalog_mixin.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_downpayment) ---
            */
            return default;
        }

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_eligible_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_entry) ---
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_inbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> IsLineValidForSectionLineCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_line_valid_for_section_line_count) ---
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _is_line_valid_for_section_line_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_move_restricted) ---
            */
            return default;
        }

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_outbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_protected_by_audit_trail) ---
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_purchase_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> IsReceiptAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_receipt) ---
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_sale_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsUserAbleToReviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_user_able_to_review) ---
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_assign_outstanding_line) ---
            */
            return default;
        }

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_remove_outstanding_partial) ---
            */
            return default;
        }

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _link_bill_origin_to_purchase_orders) ---
            */
            return default;
        }

        public async Task<TEntity> LinkBomInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bom) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_bom) ---
            */
            return default;
        }

        public async Task<TEntity> LinkWorkordersAndMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_workorders_and_moves) ---
            */
            return default;
        }

        public async Task<TEntity> LogDownsideManufacturedQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_modification, object cancel) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_downside_manufactured_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> LogManufactureExceptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents, object cancel) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_manufacture_exception) ---
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        public async Task<TEntity> MarkByproductsAsProducedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _mark_byproducts_as_produced) ---
            */
            return default;
        }

        public async Task<TEntity> MergeAlternativePoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfqs) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _merge_alternative_po) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_message, object message_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: message_post) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _move_dict_to_preview_vals) ---
            */
            return default;
        }

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _must_check_constrains_date_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> MustDeleteDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _must_delete_date_planned) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _nothing_to_invoice_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: onchange) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBomStructureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_bom_structure) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_commitment_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_cash_rounding_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_vendor_bill) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLocationPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _onchange_location_picking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLotProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_lot_producing) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_name_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_order_line) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_pricelist_id_show_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductTmplIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_product_tmpl_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductUomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: onchange_product_uom) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQtyProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntryOriginMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entry_origin_moves) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_created_caba_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_payments) ---
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_reconcile_view) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_capture) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_void) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlanWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object replan) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _plan_workorders) ---
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _post) ---
            */
            return default;
        }

        public async Task<TEntity> PostInventoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cancel_backorder) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_inventory) ---
            */
            return default;
        }

        public async Task<TEntity> PostRunManufactureInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_production_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_run_manufacture) ---
            */
            return default;
        }

        public async Task<TEntity> PreActionSplitMergeHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merge, object split) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _pre_action_split_merge_hook) ---
            */
            return default;
        }

        public async Task<TEntity> PreButtonMarkDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: pre_button_mark_done) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_analytic_account_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_cash_rounding_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_confirmation_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineValuesFromBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_values_from_base_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_section_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_down_payment_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareFinishedExtraValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_finished_extra_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGroupedDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_grouped_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_invoice_aggregated_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMergeOrigLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_merge_orig_links) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object non_deductible_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_product_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStockLotValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_stock_lot_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object line, object price, object currency) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_supplier_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_lines_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: preview_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> PrintQuotationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: print_quotation) ---
            */
            return default;
        }

        public async Task<TEntity> PrintRepairOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: print_repair_order) ---
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _quick_edit_mode_suggest_invoice_date) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: read) ---
            */
            return default;
        }

        public async Task<TEntity> ReasonCannotDecodeHasInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reason_cannot_decode_has_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _rec_names_search) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _recompute_cash_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reconcile_reversed_moves) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: refresh_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _refunds_origin_required) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reference) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _require_bill_date_for_autopost) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSectionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sections, object child_field) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product_catalog_mixin.py, METHOD: _resequence_sections) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _resequence_workorders) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: retrieve_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reverse_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundLastLineDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lines_done) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _round_last_line_done) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchComponentsAvailabilityStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_components_availability_state) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_date_category) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _search_date_category) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_default_journal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDelayAlertDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_delay_alert_date) ---
            */
            return default;
        }

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _search_invoice_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsDelayedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_is_delayed) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _search_is_late) ---
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMoveSentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_next_payment_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: search_read) ---
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_secured) ---
            */
            return default;
        }

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _select_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _send_only_when_ready) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_confirmation_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object allow_deferred_sending) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_notification_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_payment_succeeded_for_order_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object send_single) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderOpenComposerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_open_composer) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: send_reminder_preview) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_fixed_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_yearly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SetMoveByproductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_move_byproduct_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SetMovesCheckedAsync<TEntity>(IEnumerable<TEntity> entities, object is_checked) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: set_moves_checked) ---
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_next_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> SetOutdatedBomInProductionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _set_outdated_bom_in_productions) ---
            */
            return default;
        }

        public async Task<TEntity> SetQtyProducingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: set_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> SetQtyProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pick_manual_consumption_moves) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> SetQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_reversed_entry) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _should_be_locked) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldPostponeDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_finished) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_postpone_date_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldReturnRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_return_records) ---
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _show_autopost_bills_wizard) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SkipForNoVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object bom_attribule_values, object never_attribute_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _skip_for_no_variant) ---
            */
            return default;
        }

        public async Task<TEntity> SplitProductionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts, object cancel_remaining_qty, object set_consumed_qty) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _split_productions) ---
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _stolen_move) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line_needed_values) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> SyncNonDeductibleBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_non_deductible_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_tax_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_unbalanced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _synchronize_business_models) ---
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_finalize) ---
            */
            return default;
        }

        public async Task<TEntity> TrackGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_account_audit_trail_except_once_post) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptConfirmedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _unlink_except_confirmed) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_except_done) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptRunningMoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _unlink_except_running_mo) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_forbid_parts_of_chain) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCancelledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _unlink_if_cancelled) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfNotDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_if_not_done) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_or_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCatalogLineQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object quantity) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_catalog_line_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_date_planned_for_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_catalog_mixin.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateRawMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object factor) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_raw_moves) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateSaleOrderLinePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_sale_order_line_price) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates, object activity) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _validate_order) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _validate_taxes_country) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IProductCatalogMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: write) ---
            */
            return default;
        }
    }
}