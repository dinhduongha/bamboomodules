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
using System.Collections.Generic;
using System.Linq;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsRouteTemplateAppService : IGenericAppService<DmsRouteTemplate>
    {
        Task CreateTemplateAsync(string code, string name, string frequency, int? dayOfWeek, int? weekOfMonth);
        Task AddLineToTemplateAsync(Guid templateId, Guid outletId, int sequence, int? estimatedTimeMinutes);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsRouteTemplateAppService : GenericAppService<DmsRouteTemplate>, IDmsRouteTemplateAppService
    {
        public DmsRouteTemplateAppService(
            IRepository<DmsRouteTemplate, Guid> repository,
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

        public async Task CreateTemplateAsync(string code, string name, string frequency, int? dayOfWeek, int? weekOfMonth)
        {
            var template = new DmsRouteTemplate
            {
                TemplateCode = code,
                TemplateName = name,
                Frequency = frequency,
                DayOfWeek = dayOfWeek,
                WeekOfMonth = weekOfMonth,
                IsActive = true
            };
            await Repository.InsertAsync(template);
        }

        public async Task AddLineToTemplateAsync(Guid templateId, Guid outletId, int sequence, int? estimatedTimeMinutes)
        {
            var line = new DmsRouteTemplateLine
            {
                TemplateId = templateId,
                ResPartnerId = outletId,
                Sequence = sequence,
                EstimatedTimeMinutes = estimatedTimeMinutes
            };
            //await _routeTemplateLineRepository.InsertAsync(line);
        }
    }
}