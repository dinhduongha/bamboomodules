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
    [Module("pos_hr", Category = "Misc", Depends = new[] { "point_of_sale", "hr" })]
    public partial class ReportPosHrMultiEmployeeSalesReportAppService : ApplicationService, IReportPosHrMultiEmployeeSalesReportAppService
    {

        public ReportPosHrMultiEmployeeSalesReportAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPosHrMultiEmployeeSalesReportable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: multi_employee_sales_report.py, METHOD: _get_report_values) ---
            */
            return default;
        }
    }
}