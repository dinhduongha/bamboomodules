using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Calendar", Category = "Productivity", Depends = new[] { "base", "mail" })]
    public partial class CalendarFiltersAppService : GenericAppService<CalendarFilters>, ICalendarFiltersAppService
    {

        public CalendarFiltersAppService(IRepository<CalendarFilters, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<CalendarFilters> UnlinkFromPartnerIdAsync(CalendarFiltersUnlinkFromPartnerIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_filter.py) ---
            // def unlink_from_partner_id(self, partner_id):
            // return self.search([('partner_id', '=', partner_id)]).unlink()
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}