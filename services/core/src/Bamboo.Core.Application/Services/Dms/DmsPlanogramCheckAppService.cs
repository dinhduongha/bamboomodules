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
    public interface IDmsPlanogramCheckAppService : IGenericApplicationService<DmsPlanogramCheck>
    {
        Task PerformCheckAsync(Guid checkId, string photoUrl);
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPlanogramCheckAppService : GenericApplicationService<DmsPlanogramCheck>, IDmsPlanogramCheckAppService
    {
        public DmsPlanogramCheckAppService(
            IRepository<DmsPlanogramCheck, Guid> repository,
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

        public async Task PerformCheckAsync(Guid checkId, string photoUrl)
        {
            var check = await Repository.GetAsync(checkId);
            check.PhotoUrl = photoUrl;
            await Repository.UpdateAsync(check);
        }
    }
}