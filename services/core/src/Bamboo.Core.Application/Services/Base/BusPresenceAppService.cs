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
    [Module("Bus", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class BusPresenceAppService : GenericAppService<BusPresence>, IBusPresenceAppService
    {

        public BusPresenceAppService(IRepository<BusPresence, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<BusPresence> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: init) ---
            --- METHOD SOURCE (MODULE: mail, FILE: bus_presence.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<BusPresence> UpdatePresenceAsync(BusPresenceUpdatePresenceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: update_presence) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}