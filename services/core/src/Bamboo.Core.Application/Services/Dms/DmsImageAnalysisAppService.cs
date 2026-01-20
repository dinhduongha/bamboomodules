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
    public interface IDmsImageAnalysisAppService : IGenericApplicationService<DmsImageAnalysis>
    {
        Task AnalyzeImageAsync(Guid analysisId, string imageUrl);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsImageAnalysisAppService : GenericApplicationService<DmsImageAnalysis>, IDmsImageAnalysisAppService
    {
        public DmsImageAnalysisAppService(
            IRepository<DmsImageAnalysis, Guid> repository,
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

        public async Task AnalyzeImageAsync(Guid analysisId, string imageUrl)
        {
            var analysis = await Repository.GetAsync(analysisId);
            analysis.AnalyzedImageUrl = imageUrl;
            await Repository.UpdateAsync(analysis);
        }
    }
}