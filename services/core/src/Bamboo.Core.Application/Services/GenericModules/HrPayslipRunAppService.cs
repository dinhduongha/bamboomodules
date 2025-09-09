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
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("OmHrPayroll", Depends = new[] { "mail", "hr_contract", "hr_holidays" })]
    public class HrPayslipRunAppService : GenericApplicationService<HrPayslipRun>, IHrPayslipRunAppService
    {

        public HrPayslipRunAppService(IRepository<HrPayslipRun, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<HrPayslipRun> ClosePayslipRunAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def close_payslip_run(self):
            // return self.write({'state': 'close'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslipRun> DonePayslipRunAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def done_payslip_run(self):
            // for line in self.slip_ids:
            //     line.action_payslip_done()
            // return self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslipRun> DraftPayslipRunAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def draft_payslip_run(self):
            // return self.write({'state': 'draft'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}