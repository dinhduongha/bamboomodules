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
    public interface IDmsRouteLineAppService : IGenericAppService<DmsRouteLine>
    {
        Task UpdateSequenceAsync(Guid lineId, int newSequence);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsRouteLineAppService : GenericAppService<DmsRouteLine>, IDmsRouteLineAppService
    {
        public DmsRouteLineAppService(
            IRepository<DmsRouteLine, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task UpdateSequenceAsync(Guid lineId, int newSequence)
        {
            var line = await Repository.GetAsync(lineId);
            line.Sequence = newSequence;
            await Repository.UpdateAsync(line);
        }
    }
}