using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsDailyCheckpointAppService : IGenericApplicationService<DmsDailyCheckpoint>
    {
        Task CheckInWarehouseAsync(Guid checkpointId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDailyCheckpointAppService : GenericApplicationService<DmsDailyCheckpoint>, IDmsDailyCheckpointAppService
    {
        public DmsDailyCheckpointAppService(
            IRepository<DmsDailyCheckpoint, Guid> repository,
            IServiceProvider serviceProvider,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IDistributedCache cache,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
        }

        public async Task CheckInWarehouseAsync(Guid checkpointId)
        {
            var checkpoint = await Repository.GetAsync(checkpointId);
            checkpoint.Status = "completed";
            checkpoint.CheckInTime = DateTime.UtcNow;
            await Repository.UpdateAsync(checkpoint);
        }
    }
}