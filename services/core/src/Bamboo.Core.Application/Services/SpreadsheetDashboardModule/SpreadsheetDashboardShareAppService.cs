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
    public class SpreadsheetDashboardShareAppService : GenericApplicationService<SpreadsheetDashboardShare>, ISpreadsheetDashboardShareAppService
    {
        private readonly ISpreadsheetMixinAppService _spreadsheetMixinAppService;
        public SpreadsheetDashboardShareAppService(IRepository<SpreadsheetDashboardShare, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, ISpreadsheetMixinAppService spreadsheetMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _spreadsheetMixinAppService = spreadsheetMixinAppService;
        }

        protected async Task<SpreadsheetDashboardShare> CheckDashboardAccessInternalAsync(object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _check_dashboard_access(self, access_token):
            // self.ensure_one()
            // token_access = self._check_token(access_token)
            // dashboard = self.dashboard_id.with_user(self.create_uid)
            // user_access = dashboard.has_access("read")
            // if not (token_access and user_access):
            //     raise Forbidden(_("You don't have access to this dashboard. "))
            */
            return default;
        }

        protected async Task<SpreadsheetDashboardShare> CheckTokenInternalAsync(object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _check_token(self, access_token):
            // if not access_token:
            //     return False
            // return consteq(access_token, self.access_token)
            */
            return default;
        }

        protected async Task<SpreadsheetDashboardShare> ComputeFullUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _compute_full_url(self):
            // for share in self:
            //     share.full_url = "%s/dashboard/share/%s/%s" % (share.get_base_url(), share.id, share.access_token)
            */
            return default;
        }

        public async Task<SpreadsheetDashboardShare> GetShareUrlAsync(Guid id, SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def action_get_share_url(self, vals):
            // if "excel_files" in vals:
            //     excel_zip = self._zip_xslx_files(
            //         vals["excel_files"]
            //     )
            //     del vals["excel_files"]
            //     vals["excel_export"] = base64.b64encode(excel_zip)
            // return self.create(vals).full_url
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}