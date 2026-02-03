using Volo.Abp.ObjectMapping;
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
    [Module("BaseModule", Category = "Base")]
    public partial class IrDemoFailureWizardAppService : GenericAppService<IrDemoFailureWizard>, IIrDemoFailureWizardAppService
    {

        public IrDemoFailureWizardAppService(IRepository<IrDemoFailureWizard, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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

        public async Task<IrDemoFailureWizard> DoneAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_demo_failure.py) ---
            // def done(self):
            // # pylint: disable=next-method-called
            // return self.env['ir.module.module'].next()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}