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
    [Module("pos_hr", Category = "Sales", Depends = new[] { "point_of_sale", "hr" })]
    public partial class ReportPosHrSingleEmployeeSalesReportAppService : ApplicationService, IReportPosHrSingleEmployeeSalesReportAppService
    {

        public ReportPosHrSingleEmployeeSalesReportAppService() 
        {

        }

        public async Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: _get_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: get_sale_details) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py, METHOD: _prepare_get_sale_details_args_kwargs) ---
            */
            return default;
        }
    }
}