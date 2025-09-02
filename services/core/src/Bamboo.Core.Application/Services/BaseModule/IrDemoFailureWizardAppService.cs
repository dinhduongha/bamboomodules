using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class IrDemoFailureWizardAppService : GenericApplicationService<IrDemoFailureWizard>, IIrDemoFailureWizardAppService
    {

        public IrDemoFailureWizardAppService(IRepository<IrDemoFailureWizard, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrDemoFailureWizard> ComputeFailuresCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_demo_failure.py) ---
            // def _compute_failures_count(self):
            // for r in self:
            //     r.failures_count = len(r.failure_ids)
            */
            return default;
        }

        public async Task<IrDemoFailureWizard> DoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_demo_failure.py) ---
            // def done(self):
            // # pylint: disable=next-method-called
            // return self.env['ir.module.module'].next()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}