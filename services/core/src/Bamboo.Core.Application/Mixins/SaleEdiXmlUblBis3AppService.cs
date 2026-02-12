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
    [Module("sale_edi_ubl", Category = "Sales", Depends = new[] { "sale", "account_edi_ubl_cii" })]
    public partial class SaleEdiXmlUblBis3AppService : ApplicationService, ISaleEdiXmlUblBis3AppService
    {

        public SaleEdiXmlUblBis3AppService() 
        {

        }

        public async Task<TEntity> AddSaleOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_base_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_buyer_customer_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_monetary_totals_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_payment_terms_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_seller_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _add_sale_order_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _export_order) ---
            */
            return default;
        }

        public async Task<TEntity> ExportOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _export_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _get_product_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _get_sale_order_node) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _import_order_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }
    }
}