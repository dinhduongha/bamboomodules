using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
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
    public interface IDmsRouteTemplateAppService : IGenericApplicationService<DmsRouteTemplate>
    {
        Task CreateTemplateAsync(string code, string name, string frequency, int? dayOfWeek, int? weekOfMonth);
        Task AddLineToTemplateAsync(Guid templateId, Guid outletId, int sequence, int? estimatedTimeMinutes);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsRouteTemplateAppService : GenericApplicationService<DmsRouteTemplate>, IDmsRouteTemplateAppService
    {
        public DmsRouteTemplateAppService(
            IRepository<DmsRouteTemplate, Guid> repository,
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