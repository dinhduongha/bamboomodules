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
    public interface IDmsAIInsightAppService : IGenericApplicationService<DmsAIInsight>
    {
        Task GenerateInsightAsync(Guid insightId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsAIInsightAppService : GenericApplicationService<DmsAIInsight>, IDmsAIInsightAppService
    {
        public DmsAIInsightAppService(
            IRepository<DmsAIInsight, Guid> repository,
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

        public async Task GenerateInsightAsync(Guid insightId)
        {
            var insight = await Repository.GetAsync(insightId);
            insight.InsightText = "Generated insight from AI";
            await Repository.UpdateAsync(insight);
        }
    }
}