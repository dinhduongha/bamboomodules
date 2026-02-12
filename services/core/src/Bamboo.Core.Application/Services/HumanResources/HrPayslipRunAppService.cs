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
    [Module("OmHrPayroll", Category = "HumanResources", Depends = new[] { "mail", "hr_contract", "hr_holidays" })]
    public partial class HrPayslipRunAppService : GenericAppService<HrPayslipRun>, IHrPayslipRunAppService
    {

        public HrPayslipRunAppService(IRepository<HrPayslipRun, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrPayslipRun> ClosePayslipRunAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: close_payslip_run) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslipRun> DonePayslipRunAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: done_payslip_run) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslipRun> DraftPayslipRunAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: draft_payslip_run) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}