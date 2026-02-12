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
    public interface IDmsTradePromotionAppService : IGenericAppService<DmsTradePromotion>
    {
        Task TrackSpendAsync(Guid promotionId, decimal amount);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsTradePromotionAppService : GenericAppService<DmsTradePromotion>, IDmsTradePromotionAppService
    {
        public DmsTradePromotionAppService(
            IRepository<DmsTradePromotion, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
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