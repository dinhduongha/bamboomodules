using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("pos_hr", Depends = new[] { "point_of_sale", "hr" })]
    public class ReportPosHrMultiEmployeeSalesReportAppService : ApplicationService, IReportPosHrMultiEmployeeSalesReportAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ReportPosHrMultiEmployeeSalesReportAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPosHrMultiEmployeeSalesReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: multi_employee_sales_report.py) ---
            // def _get_report_values(self, docids, data=None):
            // data = dict(data or {})
            // data.update({
            //     'session_ids': data.get('session_ids'),
            //     'employee_ids': data.get('employee_ids'),
            //     'config_ids': data.get('config_ids'),
            //     'date_start': data.get('date_start'),
            //     'date_stop': data.get('date_stop'),
            // })
            // return data
            */
            return default;
        }
    }
}