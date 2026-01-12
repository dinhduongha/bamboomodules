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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Calendar", Category = "Productivity", Depends = new[] { "base", "mail" })]
    public class CalendarFiltersAppService : GenericApplicationService<CalendarFilters>, ICalendarFiltersAppService
    {

        public CalendarFiltersAppService(IRepository<CalendarFilters, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<CalendarFilters> UnlinkFromPartnerIdAsync(Guid id, CalendarFiltersUnlinkFromPartnerIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_filter.py) ---
            // def unlink_from_partner_id(self, partner_id):
            // return self.search([('partner_id', '=', partner_id)]).unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}