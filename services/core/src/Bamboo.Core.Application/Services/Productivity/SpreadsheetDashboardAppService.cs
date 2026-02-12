using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("SpreadsheetDashboardModule", Category = "Productivity", Depends = new[] { "spreadsheet" })]
    public partial class SpreadsheetDashboardAppService : GenericAppService<SpreadsheetDashboard>, ISpreadsheetDashboardAppService
    {
        protected readonly ISpreadsheetMixinAppService _spreadsheetMixinAppService;
        public SpreadsheetDashboardAppService(IRepository<SpreadsheetDashboard, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, ISpreadsheetMixinAppService spreadsheetMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _spreadsheetMixinAppService = spreadsheetMixinAppService;
        }

        public async Task<SpreadsheetDashboard> CopyDataAsync(SpreadsheetDashboardCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SpreadsheetDashboard> ToggleFavoriteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: action_toggle_favorite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}