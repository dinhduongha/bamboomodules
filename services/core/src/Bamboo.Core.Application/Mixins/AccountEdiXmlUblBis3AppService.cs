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
    [Module("account_edi_ubl_cii", Category = "Accounting", Depends = new[] { "account" })]
    public partial class AccountEdiXmlUblBis3AppService : ApplicationService, IAccountEdiXmlUblBis3AppService
    {

        public AccountEdiXmlUblBis3AppService() 
        {

        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_document_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_header_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _add_invoice_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_tax_category_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_monetary_total_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_payment_means_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _add_invoice_payment_means_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _add_invoice_payment_means_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _add_invoice_tax_total_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_tax_total_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _add_invoice_tax_total_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _add_invoice_tax_total_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _add_invoice_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_base_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_buyer_customer_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_monetary_totals_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_payment_terms_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_seller_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_base_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_buyer_customer_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_monetary_totals_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_payment_terms_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_seller_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> CanExportSelfbillingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _can_export_selfbilling) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _export_invoice_constraints) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _export_invoice_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _export_invoice_filename) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _export_invoice_filename) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _export_invoice_filename) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _export_invoice_filename) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _export_invoice_filename) ---
            */
            return default;
        }

        public async Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _export_order) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _export_order) ---
            */
            return default;
        }

        public async Task<TEntity> ExportOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _export_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_address_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _get_address_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _get_customization_id) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_customization_id) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _get_customization_id) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _get_customization_id) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _get_customization_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_financial_account_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _get_party_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_party_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _get_party_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _get_party_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _get_product_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPurchaseOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _get_purchase_order_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _get_sale_order_node) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderPaymentTermsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_order_payment_terms_id) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_order_ubl) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _import_order_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_retrieve_partner_vals) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _invoice_constraints_cen_en16931_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _invoice_constraints_peppol_en16931_ubl) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsCustomerBehindChorusProInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _is_customer_behind_chorus_pro) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SetupBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _setup_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _ubl_add_values_tax_currency_code) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _ubl_add_values_tax_currency_code) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _ubl_add_values_tax_currency_code) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _ubl_add_values_tax_currency_code) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _ubl_default_tax_category_grouping_key) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _ubl_default_tax_category_grouping_key) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _ubl_default_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _ubl_default_tax_subtotal_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }
    }
}