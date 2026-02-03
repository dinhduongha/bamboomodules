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
    public interface IDmsDemandForecastAppService : IGenericAppService<DmsDemandForecast>
    {
        Task GenerateForecastAsync(Guid forecastId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsDemandForecastAppService : GenericAppService<DmsDemandForecast>, IDmsDemandForecastAppService
    {
        public DmsDemandForecastAppService(
            IRepository<DmsDemandForecast, Guid> repository,
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

        public async Task GenerateForecastAsync(Guid forecastId)
        {
            var forecast = await Repository.GetAsync(forecastId);
            // Logic generate forecast (placeholder)
            forecast.ForecastQty = 100; // example
            await Repository.UpdateAsync(forecast);
        }
    }
}
