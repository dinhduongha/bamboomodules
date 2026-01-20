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
    public interface IDmsOutletInventoryCheckAppService : IGenericApplicationService<DmsOutletInventoryCheck>
    {
        Task PerformCheckAsync(Guid checkId, decimal checkedQty);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsOutletInventoryCheckAppService : GenericApplicationService<DmsOutletInventoryCheck>, IDmsOutletInventoryCheckAppService
    {
        public DmsOutletInventoryCheckAppService(
            IRepository<DmsOutletInventoryCheck, Guid> repository,
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

        public async Task PerformCheckAsync(Guid checkId, decimal checkedQty)
        {
            var check = await Repository.GetAsync(checkId);
            check.CheckedQty = checkedQty;
            await Repository.UpdateAsync(check);
        }
    }
}