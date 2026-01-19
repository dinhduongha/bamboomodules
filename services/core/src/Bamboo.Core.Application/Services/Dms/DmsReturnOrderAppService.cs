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
    public interface IDmsReturnOrderAppService : IGenericApplicationService<DmsReturnOrder>
    {
        Task ProcessReturnAsync(Guid returnId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsReturnOrderAppService : GenericApplicationService<DmsReturnOrder>, IDmsReturnOrderAppService
    {
        public DmsReturnOrderAppService(
            IRepository<DmsReturnOrder, Guid> repository,
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

        public async Task ProcessReturnAsync(Guid returnId)
        {
            var returnOrder = await Repository.GetAsync(returnId);
            // Logic xử lý trả hàng (cập nhật stock, tạo picking return)
            await Repository.UpdateAsync(returnOrder);
        }
    }
}