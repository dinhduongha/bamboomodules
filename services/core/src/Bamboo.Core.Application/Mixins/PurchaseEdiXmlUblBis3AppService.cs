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
    [Module("purchase_edi_ubl_bis3", Category = "SupplyChain", Depends = new[] { "purchase", "account_edi_ubl_cii" })]
    public partial class PurchaseEdiXmlUblBis3AppService : ApplicationService, IPurchaseEdiXmlUblBis3AppService
    {

        public PurchaseEdiXmlUblBis3AppService() 
        {

        }

        public async Task<TEntity> AddPurchaseOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_base_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_buyer_customer_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_monetary_totals_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_payment_terms_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_seller_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _add_purchase_order_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_order) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _export_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetPurchaseOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _get_purchase_order_node) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }
    }
}