using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsRouteSessionAppService : IGenericAppService<DmsRouteSession>
    {
        //Task<Guid> StartSessionAsync(Guid routeId, Guid userId, DateTime sessionDate);
        Task EndSessionAsync(Guid sessionId);
        Task UpdateMissedVisitsAsync(Guid sessionId, int count);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsRouteSessionAppService : GenericAppService<DmsRouteSession>, IDmsRouteSessionAppService
    {
        public DmsRouteSessionAppService(
            IRepository<DmsRouteSession, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task<Guid> StartSessionAsync(Guid routeId, Guid userId, DateTime sessionDate, int sessionNumber, bool isOvernight = false)
        {
            var session = new DmsRouteSession
            {
                RouteId = routeId,
                UserId = userId,
                SessionDate = sessionDate,
                SessionNumber = sessionNumber,
                StartTime = DateTime.UtcNow,
                IsOvernight = isOvernight,
                Status = "in_progress",
                MissedVisitsCount = 0
            };
            await Repository.InsertAsync(session);
            return session.Id;
        }

        public async Task EndSessionAsync(Guid sessionId)
        {
            var session = await Repository.GetAsync(sessionId);
            session.EndTime = DateTime.UtcNow;
            session.Status = "completed";
            await Repository.UpdateAsync(session);
        }

        public async Task UpdateMissedVisitsAsync(Guid sessionId, int count)
        {
            var session = await Repository.GetAsync(sessionId);
            session.MissedVisitsCount = count;
            await Repository.UpdateAsync(session);
        }
    }
}