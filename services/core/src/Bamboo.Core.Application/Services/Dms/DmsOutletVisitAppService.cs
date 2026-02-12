
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
using System.Collections.Generic;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsOutletVisitAppService : IGenericAppService<DmsOutletVisit>
    {
        Task CheckInAsync(Guid visitId, decimal lat, decimal lng);
        Task CheckOutAsync(Guid visitId);
        Task AddNoSaleReasonAsync(Guid visitId, string reason);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsOutletVisitAppService : GenericAppService<DmsOutletVisit>, IDmsOutletVisitAppService
    {
        public DmsOutletVisitAppService(
            IRepository<DmsOutletVisit, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task CheckInAsync(Guid visitId, decimal lat, decimal lng)
        {
            var visit = await Repository.GetAsync(visitId);
            visit.CheckInLatitude = lat;
            visit.CheckInLongitude = lng;
            visit.VisitStatus = "in_progress";
            await Repository.UpdateAsync(visit);
        }

        public async Task CheckOutAsync(Guid visitId)
        {
            var visit = await Repository.GetAsync(visitId);
            visit.VisitStatus = "completed";
            await Repository.UpdateAsync(visit);
        }

        public async Task AddNoSaleReasonAsync(Guid visitId, string reason)
        {
            var visit = await Repository.GetAsync(visitId);
            visit.NoSaleReasonId = Guid.NewGuid(); // giả sử tạo new reason
            await Repository.UpdateAsync(visit);
        }

        // public async Task<List<ResPartner>> GetNearbyOutletsAsync(decimal lat, decimal lng, int h3RingSize = 5)
        // {
        //     var currentH3 = await _dbContext.Database.SqlQuery<string>(
        //         $"SELECT h3_lat_lng_to_cell({lat}, {lng}, 9)"
        //     ).SingleAsync();

        //     var nearbyH3 = await _dbContext.Database.SqlQuery<string[]>(
        //         $"SELECT h3_kRing({currentH3}, {h3RingSize})"
        //     ).SingleAsync();

        //     return await _partnerRepository.GetListAsync(p => nearbyH3.Contains(p.H3Index));
        // }
    }
}