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
    public interface IDmsTradePromotionAppService : IGenericApplicationService<DmsTradePromotion>
    {
        Task TrackSpendAsync(Guid promotionId, decimal amount);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsTradePromotionAppService : GenericApplicationService<DmsTradePromotion>, IDmsTradePromotionAppService
    {
        public DmsTradePromotionAppService(
            IRepository<DmsTradePromotion, Guid> repository,
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

        public async Task TrackSpendAsync(Guid promotionId, decimal amount)
        {
            var promo = await Repository.GetAsync(promotionId);
            promo.ActualSpend += amount;
            await Repository.UpdateAsync(promo);
        }
    }
}