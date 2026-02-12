using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class HrPayslipAppService
    {

        protected async Task<HrPayslip> CheckDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: _check_dates) ---
            */
            return default;
        }

        protected async Task<HrPayslip> ComputeDetailsBySalaryRuleCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: _compute_details_by_salary_rule_category) ---
            */
            return default;
        }

        protected async Task<HrPayslip> ComputePayslipCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: _compute_payslip_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrPayslip> GetPayslipLinesInternalAsync(List<Guid> contract_ids, Guid payslip_id)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: _get_payslip_lines) ---
            */
            return default;
        }
    }
}