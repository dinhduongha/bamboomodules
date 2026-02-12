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
    public interface IDmsAIInsightAppService : IGenericAppService<DmsAIInsight>
    {
        Task GenerateInsightAsync(Guid insightId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsAIInsightAppService : GenericAppService<DmsAIInsight>, IDmsAIInsightAppService
    {
        public DmsAIInsightAppService(
            IRepository<DmsAIInsight, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task GenerateInsightAsync(Guid insightId)
        {
            var insight = await Repository.GetAsync(insightId);
            insight.InsightText = "Generated insight from AI";
            await Repository.UpdateAsync(insight);
        }
    }
}