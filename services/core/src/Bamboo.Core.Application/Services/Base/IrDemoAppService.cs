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
    public partial class IrDemoAppService : GenericAppService<IrDemo>, IIrDemoAppService
    {

        public IrDemoAppService(IRepository<IrDemo, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrDemo> InstallDemoAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_demo.py) ---
            // def install_demo(self):
            // import odoo.modules.loading  # noqa: PLC0415
            // odoo.modules.loading.force_demo(self.env)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': '/odoo',
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}