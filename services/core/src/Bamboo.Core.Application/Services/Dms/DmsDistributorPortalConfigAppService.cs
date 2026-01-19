using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsDistributorPortalConfigAppService : IGenericApplicationService<DmsDistributorPortalConfig>
    {
        Task UpdateAccessLevelAsync(Guid configId, string level);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDistributorPortalConfigAppService : GenericApplicationService<DmsDistributorPortalConfig>, IDmsDistributorPortalConfigAppService
    {
        public DmsDistributorPortalConfigAppService(
            IRepository<DmsDistributorPortalConfig, Guid> repository,
            IServiceProvider serviceProvider,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IMemoryCache memoryCache)
            : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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