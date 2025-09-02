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
    [Module("Project", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public class ProjectProjectStageAppService : GenericApplicationService<ProjectProjectStage>, IProjectProjectStageAppService
    {

        public ProjectProjectStageAppService(IRepository<ProjectProjectStage, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ProjectProjectStage> CopyDataAsync(Guid id, ProjectProjectStageCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project_stage.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", stage.name)) for stage, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProjectStage> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project_stage.py) ---
            // def toggle_active(self):
            // res = super().toggle_active()
            // stage_active = self.filtered('active')
            // inactive_projects = self.env['project.project'].with_context(active_test=False).search(
            //     [('active', '=', False), ('stage_id', 'in', stage_active.ids)], limit=1)
            // if stage_active and inactive_projects:
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProjectStage> UnlinkWizardAsync(Guid id, ProjectProjectStageUnlinkWizardRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}