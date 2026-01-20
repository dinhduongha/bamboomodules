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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("SpreadsheetDashboardModule", Category = "Productivity", Depends = new[] { "spreadsheet" })]
    public partial class SpreadsheetDashboardAppService : GenericApplicationService<SpreadsheetDashboard>, ISpreadsheetDashboardAppService
    {
        private readonly ISpreadsheetMixinAppService _spreadsheetMixinAppService;
        public SpreadsheetDashboardAppService(IRepository<SpreadsheetDashboard, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, ISpreadsheetMixinAppService spreadsheetMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _spreadsheetMixinAppService = spreadsheetMixinAppService;
        }

        protected async Task<SpreadsheetDashboard> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _compute_is_favorite(self):
            // for dashboard in self:
            //     dashboard.is_favorite = self.env.uid in dashboard.favorite_user_ids.ids
            */
            return default;
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
            // return any(self.env[model].search_count([], limit=1) == 0 for model in self.sudo().main_data_model_ids.mapped("model"))
            */
            return default;
        }

        protected async Task<SpreadsheetDashboard> GetDashboardTranslationNamespaceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _get_dashboard_translation_namespace(self):
            // data = self.env['ir.model.data'].sudo().search([
            //     ('model', '=', self._name),
            //     ('res_id', 'in', self.ids),
            // ], limit=1)
            // return data.module
            */
            return default;
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

        protected async Task<SpreadsheetDashboard> GetSerializedReadonlyDashboardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _get_serialized_readonly_dashboard(self):
            // snapshot = json.loads(self.spreadsheet_data)
            // user_locale = self.env['res.lang']._get_user_spreadsheet_locale()
            // snapshot.setdefault('settings', {})['locale'] = user_locale
            // default_currency = self.env['res.currency'].get_company_currency_for_spreadsheet()
            // return json.dumps({
            //     'snapshot': snapshot,
            //     'revisions': [],
            //     'default_currency': default_currency,
            //     'translation_namespace': self._get_dashboard_translation_namespace(),
            // })
            */
            return default;
        }

        public async Task<SpreadsheetDashboard> ToggleFavoriteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def action_toggle_favorite(self):
            // self.ensure_one()
            // current_user_id = self.env.uid
            // if current_user_id in self.favorite_user_ids.ids:
            //     self.sudo().favorite_user_ids = [Command.unlink(current_user_id)]
            // else:
            //     self.sudo().favorite_user_ids = [Command.link(current_user_id)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}