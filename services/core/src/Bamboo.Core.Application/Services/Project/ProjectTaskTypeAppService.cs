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
    public class ProjectTaskTypeAppService : GenericApplicationService<ProjectTaskType>, IProjectTaskTypeAppService
    {

        public ProjectTaskTypeAppService(IRepository<ProjectTaskType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ProjectTaskType> CheckPersonalStageNotLinkedToProjectsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _check_personal_stage_not_linked_to_projects(self):
            // if any(stage.user_id and stage.project_ids for stage in self):
            //     raise UserError(_('A personal stage cannot be linked to a project because it is only visible to its corresponding user.'))
            */
            return default;
        }

        protected async Task<ProjectTaskType> ComputeDisabledRatingWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _compute_disabled_rating_warning(self):
            // for stage in self:
            //     disabled_projects = stage.project_ids.filtered(lambda p: not p.rating_active)
            //     if disabled_projects:
            //         stage.disabled_rating_warning = '\n'.join('- %s' % p.name for p in disabled_projects)
            //     else:
            //         stage.disabled_rating_warning = False
            */
            return default;
        }

        protected async Task<ProjectTaskType> ComputeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _compute_user_id(self):
            // """ Fields project_ids and user_id cannot be set together for a stage. It can happen that
            //     project_ids is set after stage creation (e.g. when setting demo data). In such case, the
            //     default user_id has to be removed.
            // """
            // self.sudo().filtered('project_ids').user_id = False
            */
            return default;
        }

        public async Task<ProjectTaskType> CopyDataAsync(Guid id, ProjectTaskTypeCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", task_type.name)) for task_type, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTaskType> DefaultUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _default_user_id(self):
            // return not self.env.context.get('default_project_id', False) and self.env.uid
            */
            return default;
        }

        protected async Task<ProjectTaskType> GetDefaultProjectIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _get_default_project_ids(self):
            // default_project_id = self.env.context.get('default_project_id')
            // return [default_project_id] if default_project_id else None
            */
            return default;
        }

        protected async Task<ProjectTaskType> PreparePersonalStagesDeletionInternalAsync(object remaining_stages_dict, object personal_stages_to_update)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _prepare_personal_stages_deletion(self, remaining_stages_dict, personal_stages_to_update):
            // """ _prepare_personal_stages_deletion prepare the deletion of personal stages of a single user.
            //     Tasks using that stage will be moved to the first stage with a lower sequence if it exists
            //     higher if not.
            // :param self: project.task.type recordset containing the personal stage of a user
            //              that need to be deleted
            // :param remaining_stages_dict: list of dict representation of the personal stages of a user that
            //                               can be used to replace the deleted ones. Can not be empty.
            //                               e.g: [{'id': stage1_id, 'seq': stage1_sequence}, ...]
            // :param personal_stages_to_update: project.task.stage.personal recordset containing the records
            //                                   that need to be updated after stage modification. Is passed to
            //                                   this method as an argument to avoid to reload it for each users
            //                                   when this method is called multiple times.
            // """
            // stages_to_delete_dict = sorted([{'id': stage.id, 'seq': stage.sequence} for stage in self],
            //                                key=lambda stage: stage['seq'])
            // replacement_stage_id = remaining_stages_dict.pop()['id']
            // next_replacement_stage = remaining_stages_dict and remaining_stages_dict.pop()
            // 
            // personal_stages_by_stage = {
            //     stage.id: personal_stages
            //     for stage, personal_stages in personal_stages_to_update
            // }
            // for stage in stages_to_delete_dict:
            //     while next_replacement_stage and next_replacement_stage['seq'] < stage['seq']:
            //         replacement_stage_id = next_replacement_stage['id']
            //         next_replacement_stage = remaining_stages_dict and remaining_stages_dict.pop()
            //     if stage['id'] in personal_stages_by_stage:
            //         personal_stages_by_stage[stage['id']].stage_id = replacement_stage_id
            */
            return default;
        }

        public async Task<ProjectTaskType> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def toggle_active(self):
            // res = super().toggle_active()
            // stage_active = self.filtered('active')
            // inactive_tasks = self.env['project.task'].with_context(active_test=False).search(
            //     [('active', '=', False), ('stage_id', 'in', stage_active.ids)], limit=1)
            // if stage_active and inactive_tasks:
            //     wizard = self.env['project.task.type.delete.wizard'].create({
            //         'stage_ids': stage_active.ids,
            //     })
            // 
            //     return {
            //         'name': _('Unarchive Tasks'),
            //         'view_mode': 'form',
            //         'res_model': 'project.task.type.delete.wizard',
            //         'views': [(self.env.ref('project.view_project_task_type_unarchive_wizard').id, 'form')],
            //         'type': 'ir.actions.act_window',
            //         'res_id': wizard.id,
            //         'target': 'new',
            //     }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTaskType> UnlinkIfRemainingPersonalStagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def _unlink_if_remaining_personal_stages(self):
            // """ Prepare personal stages for deletion (i.e. move task to other personal stages) and
            //     avoid unlink if no remaining personal stages for an active internal user.
            // """
            // # Personal stages are processed if the user still has at least one personal stage after unlink
            // personal_stages = self.filtered('user_id')
            // if not personal_stages:
            //     return
            // remaining_personal_stages_all = self.env['project.task.type']._read_group(
            //     [('user_id', 'in', personal_stages.user_id.ids), ('id', 'not in', personal_stages.ids)],
            //     groupby=['user_id', 'sequence', 'id'],
            //     order="user_id,sequence DESC",
            // )
            // remaining_personal_stages_by_user = defaultdict(list)
            // for user, sequence, stage in remaining_personal_stages_all:
            //     remaining_personal_stages_by_user[user].append({'id': stage.id, 'seq': sequence})
            // 
            // # For performance issue, project.task.stage.personal records that need to be modified are listed before calling _prepare_personal_stages_deletion
            // personal_stages_to_update = self.env['project.task.stage.personal']._read_group([('stage_id', 'in', personal_stages.ids)], ['stage_id'], ['id:recordset'])
            // for user in personal_stages.user_id:
            //     if not user.active or user.share:
            //         continue
            //     user_stages_to_unlink = personal_stages.filtered(lambda stage: stage.user_id == user)
            //     user_remaining_stages = remaining_personal_stages_by_user[user]
            //     if not user_remaining_stages:
            //         raise UserError(_("Each user should have at least one personal stage. Create a new stage to which the tasks can be transferred after the selected ones are deleted."))
            //     user_stages_to_unlink._prepare_personal_stages_deletion(user_remaining_stages, personal_stages_to_update)
            */
            return default;
        }

        public async Task<ProjectTaskType> UnlinkWizardAsync(Guid id, ProjectTaskTypeUnlinkWizardRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task_type.py) ---
            // def unlink_wizard(self, stage_view=False):
            // self = self.with_context(active_test=False)
            // # retrieves all the projects with a least 1 task in that stage
            // # a task can be in a stage even if the project is not assigned to the stage
            // readgroup = self.with_context(active_test=False).env['project.task']._read_group([('stage_id', 'in', self.ids)], ['project_id'])
            // project_ids = list(set([project.id for [project] in readgroup] + self.project_ids.ids))
            // 
            // wizard = self.with_context(project_ids=project_ids).env['project.task.type.delete.wizard'].create({
            //     'project_ids': project_ids,
            //     'stage_ids': self.ids
            // })
            // 
            // context = dict(self.env.context)
            // context['stage_view'] = stage_view
            // return {
            //     'name': _('Delete Stage'),
            //     'view_mode': 'form',
            //     'res_model': 'project.task.type.delete.wizard',
            //     'views': [(self.env.ref('project.view_project_task_type_delete_wizard').id, 'form')],
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