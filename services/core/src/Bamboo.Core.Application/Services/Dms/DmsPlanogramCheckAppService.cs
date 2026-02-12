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
    public interface IDmsPlanogramCheckAppService : IGenericAppService<DmsPlanogramCheck>
    {
        Task PerformCheckAsync(Guid checkId, string photoUrl);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPlanogramCheckAppService : GenericAppService<DmsPlanogramCheck>, IDmsPlanogramCheckAppService
    {
        public DmsPlanogramCheckAppService(
            IRepository<DmsPlanogramCheck, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task PerformCheckAsync(Guid checkId, string photoUrl)
        {
            var check = await Repository.GetAsync(checkId);
            check.PhotoUrl = photoUrl;
            await Repository.UpdateAsync(check);
        }
    }
}