using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("SpreadsheetDashboardModule", Depends = new[] { "spreadsheet" })]
    public class SpreadsheetDashboardAppService : GenericApplicationService<SpreadsheetDashboard>, ISpreadsheetDashboardAppService
    {
        private readonly ISpreadsheetMixinAppService _spreadsheetMixinAppService;
        public SpreadsheetDashboardAppService(IRepository<SpreadsheetDashboard, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, ISpreadsheetMixinAppService spreadsheetMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _spreadsheetMixinAppService = spreadsheetMixinAppService;
        }

        public async Task<SpreadsheetDashboard> CopyDataAsync(Guid id, SpreadsheetDashboardCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for dashboard, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", dashboard.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SpreadsheetDashboard> DashboardIsEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _dashboard_is_empty(self):
            // return any(self.env[model].search_count([], limit=1) == 0 for model in self.main_data_model_ids.sudo().mapped("model"))
            */
            return default;
        }

        public async Task<SpreadsheetDashboard> GetReadonlyDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def get_readonly_dashboard(self):
            // self.ensure_one()
            // snapshot = json.loads(self.spreadsheet_data)
            // if self._dashboard_is_empty() and self.sample_dashboard_file_path:
            //     sample_data = self._get_sample_dashboard()
            //     if sample_data:
            //         return {
            //             "snapshot": sample_data,
            //             "is_sample": True,
            //         }
            // user_locale = self.env['res.lang']._get_user_spreadsheet_locale()
            // snapshot.setdefault('settings', {})['locale'] = user_locale
            // default_currency = self.env['res.currency'].get_company_currency_for_spreadsheet()
            // return {
            //     'snapshot': snapshot,
            //     'revisions': [],
            //     'default_currency': default_currency,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SpreadsheetDashboard> GetSampleDashboardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _get_sample_dashboard(self):
            // try:
            //     with file_open(self.sample_dashboard_file_path) as f:
            //         return json.load(f)
            // except FileNotFoundError:
            //     return
            */
            return default;
        }
    }
}