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
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IMemoryCache memoryCache)
            : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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