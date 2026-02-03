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
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public partial class ProjectProjectStageAppService : GenericAppService<ProjectProjectStage>, IProjectProjectStageAppService
    {

        public ProjectProjectStageAppService(IRepository<ProjectProjectStage, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ProjectProjectStage> CopyDataAsync(ProjectProjectStageCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project_stage.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", stage.name)) for stage, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProjectStage> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project_stage.py) ---
            // def action_unarchive(self):
            // res = super().action_unarchive()
            // stage_active = self.filtered(self._active_name)
            // if stage_active and self.env['project.project'].with_context(active_test=False).search_count(
            //     [('active', '=', False), ('stage_id', 'in', stage_active.ids)], limit=1
            // ):
            //     wizard = self.env['project.project.stage.delete.wizard'].create({
            //         'stage_ids': stage_active.ids,
            //     })
            // 
            //     return {
            //         'name': _('Unarchive Projects'),
            //         'view_mode': 'form',
            //         'res_model': 'project.project.stage.delete.wizard',
            //         'views': [(self.env.ref('project.view_project_project_stage_unarchive_wizard').id, 'form')],
            //         'type': 'ir.actions.act_window',
            //         'res_id': wizard.id,
            //         'target': 'new',
            //     }
            // return res
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProjectStage> UnlinkWizardAsync(ProjectProjectStageUnlinkWizardRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project_stage.py) ---
            // def unlink_wizard(self, stage_view=False):
            // wizard = self.with_context(active_test=False).env['project.project.stage.delete.wizard'].create({
            //     'stage_ids': self.ids
            // })
            // 
            // context = dict(self.env.context)
            // context['stage_view'] = stage_view
            // return {
            //     'name': _('Delete Project Stage'),
            //     'view_mode': 'form',
            //     'res_model': 'project.project.stage.delete.wizard',
            //     'views': [(self.env.ref('project.view_project_project_stage_delete_wizard').id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'res_id': wizard.id,
            //     'target': 'new',
            //     'context': context,
            // }
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}