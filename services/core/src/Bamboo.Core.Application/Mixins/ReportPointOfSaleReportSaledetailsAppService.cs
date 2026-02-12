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
    [Module("point_of_sale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class ReportPointOfSaleReportSaledetailsAppService : ApplicationService, IReportPointOfSaleReportSaledetailsAppService
    {

        public ReportPointOfSaleReportSaledetailsAppService() 
        {

        }

        public async Task<TEntity> GetDateStartAndDateStopInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_date_start_and_date_stop) ---
            */
            return default;
        }

        public async Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_domain) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: _get_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_product_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductsAndTaxesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object products, object taxes, object currency) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_products_and_taxes_dict) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_report_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: get_sale_details) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: get_sale_details) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxesInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_taxes_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotalAndQtyPerCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _get_total_and_qty_per_category) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: report_sale_details.py, METHOD: _prepare_get_sale_details_args_kwargs) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: _prepare_get_sale_details_args_kwargs) ---
            */
            return default;
        }
    }
}