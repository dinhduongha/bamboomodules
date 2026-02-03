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
    public interface IDmsPOSMDeploymentAppService : IGenericAppService<DmsPOSMDeployment>
    {
        Task ConfirmDeploymentAsync(Guid deploymentId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPOSMDeploymentAppService : GenericAppService<DmsPOSMDeployment>, IDmsPOSMDeploymentAppService
    {
        public DmsPOSMDeploymentAppService(
            IRepository<DmsPOSMDeployment, Guid> repository,
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

        public async Task ConfirmDeploymentAsync(Guid deploymentId)
        {
            var dep = await Repository.GetAsync(deploymentId);
            dep.Status = "confirmed";
            await Repository.UpdateAsync(dep);
        }
    }
}