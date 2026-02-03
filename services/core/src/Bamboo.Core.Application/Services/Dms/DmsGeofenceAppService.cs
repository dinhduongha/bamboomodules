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
    public interface IDmsGeofenceAppService : IGenericAppService<DmsGeofence>
    {
        Task ValidateGeofenceAsync(Guid geofenceId, decimal lat, decimal lng);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsGeofenceAppService : GenericAppService<DmsGeofence>, IDmsGeofenceAppService
    {
        public DmsGeofenceAppService(
            IRepository<DmsGeofence, Guid> repository,
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

        public async Task ValidateGeofenceAsync(Guid geofenceId, decimal lat, decimal lng)
        {
            var geofence = await Repository.GetAsync(geofenceId);
            // Logic tính khoảng cách (placeholder)
        }
        // public async Task<bool> ValidateGeofenceAsync(Guid geofenceId, decimal lat, decimal lng)
        // {
        //     var geofence = await Repository.GetAsync(geofenceId);
        //     var point = GeographyHelper.CreatePoint(lng, lat); // helper tạo geography point

        //     return await _dbContext.Database.SqlQuery<bool>(
        //         $"SELECT ST_DWithin({geofence.Geom}, {point}::geography, {geofence.RadiusMeters})"
        //     ).SingleAsync();
        // }
    }
}