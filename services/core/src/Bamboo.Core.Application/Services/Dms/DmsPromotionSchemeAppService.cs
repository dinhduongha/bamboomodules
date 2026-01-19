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
    public interface IDmsPromotionSchemeAppService : IGenericApplicationService<DmsPromotionScheme>
    {
        Task ActivateSchemeAsync(Guid schemeId);
        Task DeactivateSchemeAsync(Guid schemeId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPromotionSchemeAppService : GenericApplicationService<DmsPromotionScheme>, IDmsPromotionSchemeAppService
    {
        public DmsPromotionSchemeAppService(
            IRepository<DmsPromotionScheme, Guid> repository,
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

        public async Task ActivateSchemeAsync(Guid schemeId)
        {
            var scheme = await Repository.GetAsync(schemeId);
            scheme.IsActive = true;
            await Repository.UpdateAsync(scheme);
        }

        public async Task DeactivateSchemeAsync(Guid schemeId)
        {
            var scheme = await Repository.GetAsync(schemeId);
            scheme.IsActive = false;
            await Repository.UpdateAsync(scheme);
        }
    }
}