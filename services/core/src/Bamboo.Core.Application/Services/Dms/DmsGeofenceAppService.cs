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
    public interface IDmsGeofenceAppService : IGenericApplicationService<DmsGeofence>
    {
        Task ValidateGeofenceAsync(Guid geofenceId, decimal lat, decimal lng);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsGeofenceAppService : GenericApplicationService<DmsGeofence>, IDmsGeofenceAppService
    {
        public DmsGeofenceAppService(
            IRepository<DmsGeofence, Guid> repository,
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

        public async Task ValidateGeofenceAsync(Guid geofenceId, decimal lat, decimal lng)
        {
            var geofence = await Repository.GetAsync(geofenceId);
            // Logic tính khoảng cách (placeholder)
        }
    }
}