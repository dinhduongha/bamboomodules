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
    public interface IDmsProvisionOrderAppService : IGenericApplicationService<DmsProvisionOrder>
    {
        Task ProvisionStockAsync(Guid provisionId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsProvisionOrderAppService : GenericApplicationService<DmsProvisionOrder>, IDmsProvisionOrderAppService
    {
        public DmsProvisionOrderAppService(
            IRepository<DmsProvisionOrder, Guid> repository,
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

        public async Task ProvisionStockAsync(Guid provisionId)
        {
            var order = await Repository.GetAsync(provisionId);
            order.State = "done";
            await Repository.UpdateAsync(order);
        }
    }
}
