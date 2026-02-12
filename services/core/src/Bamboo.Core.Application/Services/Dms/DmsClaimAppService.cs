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
    public interface IDmsClaimAppService : IGenericAppService<DmsClaim>
    {
        Task ApproveClaimAsync(Guid claimId);
        Task RejectClaimAsync(Guid claimId);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsClaimAppService : GenericAppService<DmsClaim>, IDmsClaimAppService
    {
        public DmsClaimAppService(
            IRepository<DmsClaim, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task ApproveClaimAsync(Guid claimId)
        {
            var claim = await Repository.GetAsync(claimId);
            claim.Status = "approved";
            await Repository.UpdateAsync(claim);
        }

        public async Task RejectClaimAsync(Guid claimId)
        {
            var claim = await Repository.GetAsync(claimId);
            claim.Status = "rejected";
            await Repository.UpdateAsync(claim);
        }
    }
}