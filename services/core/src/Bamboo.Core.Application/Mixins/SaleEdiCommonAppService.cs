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
    public partial class SaleEdiCommonAppService : ApplicationService, ISaleEdiCommonAppService
    {

        public SaleEdiCommonAppService() 
        {

        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _get_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerDetailStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _get_partner_detail_str) ---
            */
            return default;
        }

        public async Task<TEntity> ImportDeliveryPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object name, object phone, object email) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _import_delivery_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _import_fill_order) ---
            */
            return default;
        }

        public async Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _import_fill_order_prepare_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xpath) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _import_order_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _import_order_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _import_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ImportPaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xapth) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py, METHOD: _import_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py, METHOD: _import_retrieve_delivery_vals) ---
            */
            return default;
        }
    }
}