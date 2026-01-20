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
    public interface IDmsDeliveryZoneAppService : IGenericApplicationService<DmsDeliveryZone>
    {
        Task AssignOutletToZoneAsync(Guid zoneId, Guid outletId);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDeliveryZoneAppService : GenericApplicationService<DmsDeliveryZone>, IDmsDeliveryZoneAppService
    {
        public DmsDeliveryZoneAppService(
            IRepository<DmsDeliveryZone, Guid> repository,
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

        public async Task AssignOutletToZoneAsync(Guid zoneId, Guid outletId)
        {
            var zone = await Repository.GetAsync(zoneId);
            // Logic assign (có thể thêm collection nếu cần)
        }
    }
}