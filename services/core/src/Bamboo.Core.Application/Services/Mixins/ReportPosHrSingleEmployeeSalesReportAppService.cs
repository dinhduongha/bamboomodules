using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("pos_hr", Depends = new[] { "point_of_sale", "hr" })]
    public class ReportPosHrSingleEmployeeSalesReportAppService : ApplicationService, IReportPosHrSingleEmployeeSalesReportAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ReportPosHrSingleEmployeeSalesReportAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py) ---
            // def _get_domain(self, date_start=False, date_stop=False, config_ids=False, session_ids=False, employee_id=False):
            // domain = super()._get_domain(config_ids=config_ids, session_ids=session_ids)
            // 
            // if (employee_id):
            //     domain = AND([domain, [('employee_id', '=', employee_id)]])
            // 
            // return domain
            */
            return default;
        }

        public async Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py) ---
            // def get_sale_details(self, date_start=False, date_stop=False, config_ids=False, session_ids=False, employee_id=False):
            // data = super().get_sale_details(config_ids=config_ids, session_ids=session_ids, employee_id=employee_id)
            // 
            // if (employee_id):
            //     employee = self.env['hr.employee'].search([('id', '=', employee_id)])
            //     data['employee_name'] = employee.name
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: single_employee_sales_report.py) ---
            // def _prepare_get_sale_details_args_kwargs(self, data):
            // args, kwargs = super()._prepare_get_sale_details_args_kwargs(data)
            // kwargs['employee_id'] = data.get('employee_id')
            // return args, kwargs
            */
            return default;
        }
    }
}