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
    public interface IDmsDeliveryZoneAppService : IGenericAppService<DmsDeliveryZone>
    {
        Task AssignOutletToZoneAsync(Guid zoneId, Guid outletId);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDeliveryZoneAppService : GenericAppService<DmsDeliveryZone>, IDmsDeliveryZoneAppService
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

        // public async Task<bool> IsOutletInZoneAsync(Guid zoneId, Guid outletId)
        // {
        //     var zone = await Repository.GetAsync(zoneId);
        //     var outlet = await _partnerRepository.GetAsync(outletId);

        //     return await _dbContext.Database.SqlQuery<bool>(
        //         $"SELECT ST_Contains({zone.Geom}, {outlet.Geom})"
        //     ).SingleAsync();
        // }

        // /// <summary>
        // /// Tìm tất cả outlet trong zone (dùng ST_Within)
        // /// </summary>
        // public async Task<List<ResPartner>> GetOutletsInZoneAsync(Guid zoneId)
        // {
        //     var zone = await Repository.GetAsync(zoneId);

        //     return await _partnerRepository.GetListAsync(p =>
        //         EF.Functions.ST_Within(p.Geom, zone.Geom));
        // }

        // /// <summary>
        // /// Tìm zone gần nhất cho outlet (dùng ST_Distance)
        // /// </summary>
        // public async Task<DmsDeliveryZone> GetNearestZoneAsync(Guid outletId)
        // {
        //     var outlet = await _partnerRepository.GetAsync(outletId);

        //     return await Repository.GetQueryable()
        //         .OrderBy(z => EF.Functions.ST_Distance(z.Geom, outlet.Geom))
        //         .FirstOrDefaultAsync();
        // }

        // /// <summary>
        // /// Lấy danh sách H3 bao phủ zone (dùng h3_polyfill)
        // /// </summary>
        // public async Task<string[]> GetH3CoverageAsync(Guid zoneId, int resolution = 9)
        // {
        //     var zone = await Repository.GetAsync(zoneId);

        //     return await _dbContext.Database.SqlQuery<string[]>(
        //         $"SELECT h3_polyfill({zone.Geom}, {resolution})"
        //     ).SingleAsync();
        // }
    }
}