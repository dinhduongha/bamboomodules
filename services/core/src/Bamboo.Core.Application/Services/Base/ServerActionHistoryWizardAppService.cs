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
    [Module("BaseModule", Category = "Base")]
    public partial class ServerActionHistoryWizardAppService : GenericAppService<ServerActionHistoryWizard>, IServerActionHistoryWizardAppService
    {

        public ServerActionHistoryWizardAppService(IRepository<ServerActionHistoryWizard, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<ServerActionHistoryWizard> ComputeCodeDiffInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_code_diff(self):
            // for wizard in self:
            //     rev_code = wizard.revision.code
            //     actual_code = wizard.action_id.code
            //     has_diff = actual_code != rev_code
            //     wizard.code_diff = get_diff(
            //             (actual_code or "", _("Actual Code")),
            //             (rev_code or "", _("Revision Code")),
            //             dark_color_scheme=request and request.cookies.get("color_scheme") == "dark",
            //     ) if has_diff else False
            */
            return default;
        }

        [ApiModel]
        protected async Task<ServerActionHistoryWizard> DefaultRevisionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _default_revision(self):
            // action_id = self.env['ir.actions.server'].browse(self.env.context.get('default_action_id', False))
            // return self.env["ir.actions.server.history"].search([
            //     ("action_id", "=", action_id.id),
            //     ('code', '!=', action_id.code),
            // ], limit=1)
            */
            return default;
        }

        public async Task<ServerActionHistoryWizard> RestoreRevisionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def restore_revision(self):
            // self.ensure_one()
            // self.action_id.code = self.revision.code
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}