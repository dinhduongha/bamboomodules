using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsDistributorPortalConfigAppService : IGenericAppService<DmsDistributorPortalConfig>
    {
        Task UpdateAccessLevelAsync(Guid configId, string level);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDistributorPortalConfigAppService : GenericAppService<DmsDistributorPortalConfig>, IDmsDistributorPortalConfigAppService
    {
        public DmsDistributorPortalConfigAppService(
            IRepository<DmsDistributorPortalConfig, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task UpdateAccessLevelAsync(Guid configId, string level)
        {
            var config = await Repository.GetAsync(configId);
            config.PortalAccessLevel = level;
            await Repository.UpdateAsync(config);
        }
    }
}