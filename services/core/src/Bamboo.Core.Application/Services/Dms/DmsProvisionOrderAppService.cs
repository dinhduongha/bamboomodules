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
    public interface IDmsProvisionOrderAppService : IGenericAppService<DmsProvisionOrder>
    {
        Task ProvisionStockAsync(Guid provisionId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsProvisionOrderAppService : GenericAppService<DmsProvisionOrder>, IDmsProvisionOrderAppService
    {
        public DmsProvisionOrderAppService(
            IRepository<DmsProvisionOrder, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
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
