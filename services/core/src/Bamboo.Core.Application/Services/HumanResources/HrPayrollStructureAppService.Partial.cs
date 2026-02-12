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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class HrPayrollStructureAppService
    {

        protected async Task<HrPayrollStructure> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrPayrollStructure> GetParentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py, METHOD: _get_parent) ---
            */
            return default;
        }

        protected async Task<HrPayrollStructure> GetParentStructureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py, METHOD: _get_parent_structure) ---
            */
            return default;
        }
    }
}