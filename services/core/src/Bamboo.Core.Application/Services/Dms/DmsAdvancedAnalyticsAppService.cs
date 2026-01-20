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
    public interface IDmsAdvancedAnalyticsAppService : IGenericApplicationService<DmsAdvancedAnalytics>
    {
        Task GenerateInsightAsync(Guid analyticsId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsAdvancedAnalyticsAppService : GenericApplicationService<DmsAdvancedAnalytics>, IDmsAdvancedAnalyticsAppService
    {
        public DmsAdvancedAnalyticsAppService(
            IRepository<DmsAdvancedAnalytics, Guid> repository,
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

        public async Task GenerateInsightAsync(Guid analyticsId)
        {
            var analytics = await Repository.GetAsync(analyticsId);
            analytics.InsightText = "Generated predictive insight";
            await Repository.UpdateAsync(analytics);
        }
    }
}