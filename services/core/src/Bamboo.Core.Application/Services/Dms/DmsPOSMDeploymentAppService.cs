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
    public interface IDmsPOSMDeploymentAppService : IGenericApplicationService<DmsPOSMDeployment>
    {
        Task ConfirmDeploymentAsync(Guid deploymentId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsPOSMDeploymentAppService : GenericApplicationService<DmsPOSMDeployment>, IDmsPOSMDeploymentAppService
    {
        public DmsPOSMDeploymentAppService(
            IRepository<DmsPOSMDeployment, Guid> repository,
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

        public async Task ConfirmDeploymentAsync(Guid deploymentId)
        {
            var dep = await Repository.GetAsync(deploymentId);
            dep.Status = "confirmed";
            await Repository.UpdateAsync(dep);
        }
    }
}