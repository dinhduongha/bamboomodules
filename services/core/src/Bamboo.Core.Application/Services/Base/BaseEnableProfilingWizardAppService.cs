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

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class BaseEnableProfilingWizardAppService : GenericApplicationService<BaseEnableProfilingWizard>, IBaseEnableProfilingWizardAppService
    {

        public BaseEnableProfilingWizardAppService(IRepository<BaseEnableProfilingWizard, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<BaseEnableProfilingWizard> ComputeExpirationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def _compute_expiration(self):
            // for record in self:
            //     unit, quantity = (record.duration or 'days_0').split('_')
            //     record.expiration = fields.Datetime.now() + relativedelta(**{unit: int(quantity)})
            */
            return default;
        }

        public async Task<BaseEnableProfilingWizard> SubmitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def submit(self):
            // self.env['ir.config_parameter'].set_param('base.profiling_enabled_until', self.expiration)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}