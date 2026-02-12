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
    public interface IDmsAchievementLogAppService : IGenericAppService<DmsAchievementLog>
    {
        Task LogDailyAchievementAsync(Guid userId, decimal sales, int visits);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsAchievementLogAppService : GenericAppService<DmsAchievementLog>, IDmsAchievementLogAppService
    {
        public DmsAchievementLogAppService(
            IRepository<DmsAchievementLog, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task LogDailyAchievementAsync(Guid userId, decimal sales, int visits)
        {
            var log = new DmsAchievementLog
            {
                UserId = userId,
                Date = DateTime.UtcNow,
                SalesToday = sales,
                VisitsToday = visits
            };
            await Repository.InsertAsync(log);
        }
    }
}