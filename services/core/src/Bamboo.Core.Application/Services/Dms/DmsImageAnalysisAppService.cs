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
    public interface IDmsImageAnalysisAppService : IGenericAppService<DmsImageAnalysis>
    {
        Task AnalyzeImageAsync(Guid analysisId, string imageUrl);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsImageAnalysisAppService : GenericAppService<DmsImageAnalysis>, IDmsImageAnalysisAppService
    {
        public DmsImageAnalysisAppService(
            IRepository<DmsImageAnalysis, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
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