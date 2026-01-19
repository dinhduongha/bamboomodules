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
    public interface IDmsClaimAppService : IGenericApplicationService<DmsClaim>
    {
        Task ApproveClaimAsync(Guid claimId);
        Task RejectClaimAsync(Guid claimId);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsClaimAppService : GenericApplicationService<DmsClaim>, IDmsClaimAppService
    {
        public DmsClaimAppService(
            IRepository<DmsClaim, Guid> repository,
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