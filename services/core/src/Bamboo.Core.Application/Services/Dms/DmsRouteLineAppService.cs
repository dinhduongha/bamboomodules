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
    public interface IDmsRouteLineAppService : IGenericApplicationService<DmsRouteLine>
    {
        Task UpdateSequenceAsync(Guid lineId, int newSequence);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsRouteLineAppService : GenericApplicationService<DmsRouteLine>, IDmsRouteLineAppService
    {
        public DmsRouteLineAppService(
            IRepository<DmsRouteLine, Guid> repository,
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

        public async Task UpdateSequenceAsync(Guid lineId, int newSequence)
        {
            var line = await Repository.GetAsync(lineId);
            line.Sequence = newSequence;
            await Repository.UpdateAsync(line);
        }
    }
}