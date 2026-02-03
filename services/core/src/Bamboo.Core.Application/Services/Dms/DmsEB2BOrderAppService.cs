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
    public interface IDmsEB2BOrderAppService : IGenericAppService<DmsEB2BOrder>
    {
        Task CreateFromChatAsync(string channel, string message);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsEB2BOrderAppService : GenericAppService<DmsEB2BOrder>, IDmsEB2BOrderAppService
    {
        public DmsEB2BOrderAppService(
            IRepository<DmsEB2BOrder, Guid> repository,
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

        public async Task CreateFromChatAsync(string channel, string message)
        {
            var order = new DmsEB2BOrder
            {
                Channel = channel,
                OrderContent = message,
                OrderStatus = "pending",
                Timestamp = DateTime.UtcNow
            };
            await Repository.InsertAsync(order);
        }
    }
}