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
    public interface IDmsPromotionApplicationAppService : IGenericApplicationService<DmsPromotionApplication>
    {
        Task ApplyPromotionAsync(Guid applicationId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPromotionApplicationAppService : GenericApplicationService<DmsPromotionApplication>, IDmsPromotionApplicationAppService
    {
        public DmsPromotionApplicationAppService(
            IRepository<DmsPromotionApplication, Guid> repository,
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

        public async Task ApplyPromotionAsync(Guid applicationId)
        {
            var app = await Repository.GetAsync(applicationId);
            app.Status = "applied";
            await Repository.UpdateAsync(app);
        }
    }
}