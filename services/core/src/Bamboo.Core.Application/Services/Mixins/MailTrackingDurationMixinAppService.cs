using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailTrackingDurationMixinAppService : ApplicationService, IMailTrackingDurationMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MailTrackingDurationMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_archive(self):
            // return super(HrApplicant, self.with_context(just_unarchived=True)).action_archive()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_archive(self):
            // child_tasks = self.child_ids.filtered(lambda child_task: not child_task.display_in_project)
            // if child_tasks:
            //     child_tasks.action_archive()
            // return super().action_archive()
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_convert_to_subtask(self):
            // self.ensure_one()
            // if self.project_id:
            //     return {
            //         'name': _('Convert to Task/Sub-Task'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'project.task',
            //         'res_id': self.id,
            //         'views': [(self.env.ref('project.project_task_convert_to_subtask_view_form', False).id, 'form')],
            //         'target': 'new',
            //     }
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'danger',
            //         'message': _('Private tasks cannot be converted into sub-tasks. Please set a project on the task to gain access to this feature.'),
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_convert_to_template(self):
            // self.ensure_one()
            // if not self.project_id:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'message': _('Private tasks cannot be converted into templates'),
            //         },
            //     }
            // if self.is_template:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'project_show_template_undo_confirmation_dialog',
            //         'params': {
            //             'task_id': self.id,
            //         },
            //     }
            // self.is_template = True
            // self.role_ids = False
            // self.message_post(body=_("Task converted to template"))
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'project_show_template_notification',
            //     'params': {
            //         'task_id': self.id,
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload',
            //         },
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_create_from_template(self, values=None, role_to_users_mapping=None):
            // self.ensure_one()
            // values = values or {}
            // 
            // if self.date_start and self.date:
            //     if not values.get("date_start"):
            //         values["date_start"] = fields.Date.today()
            //     if not values.get("date"):
            //         values["date"] = values["date_start"] + (self.date - self.date_start)
            // 
            // default = {
            //     key.removeprefix('default_'): value
            //     for key, value in self.env.context.items()
            //     if key.startswith('default_') and key.removeprefix('default_') in self._get_template_default_context_whitelist()
            // } | values
            // project = self.with_context(copy_from_template=True, copy_from_project_template=True).copy(default=default)
            // project.message_post(body=self.env._("Project created from template %(name)s.", name=self.name))
            // 
            // # Tasks dispatching using project roles
            // if role_to_users_mapping and (mapping := role_to_users_mapping.filtered(lambda entry: entry.user_ids)):
            //     for new_task in project.task_ids:
            //         for entry in mapping:
            //             if entry.role_id in new_task.role_ids:
            //                 new_task.user_ids |= entry.user_ids
            // 
            // project.task_ids.role_ids = False
            // return project
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_create_from_template(self, values=None):
            // self.ensure_one()
            // values = values or {}
            // default = {
            //               key[8:]: value
            //               for key, value in self.env.context.items()
            //               if key.startswith('default_') and key[8:] in self._get_template_default_context_whitelist()
            //           } | {
            //               field: False
            //               for field in self._get_template_field_blacklist()
            //           } | values
            // return self.with_context(copy_from_template=True).copy(default=default).id
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_create_meeting(self):
            // """ This opens Meeting's calendar view to schedule meeting on current applicant
            //     @return: Dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('You must define a Contact Name for this applicant.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // partners = self.partner_id | self.department_id.manager_id.user_id.partner_id
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     partners |= self.env.user.partner_id
            // else:
            //     partners |= self.user_id.partner_id
            // 
            // res = self.env['ir.actions.act_window']._for_xml_id('calendar.action_calendar_event')
            // # As we are redirected from the hr.applicant, calendar checks rules on "hr.applicant",
            // # in order to decide whether to allow creation of a meeting.
            // # As interviewer does not have create right on the hr.applicant, in order to allow them
            // # to create a meeting for an applicant, we pass 'create': True to the context.
            // res['context'] = {
            //     'create': True,
            //     'default_applicant_id': self.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionCreateTemplateFromProjectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_create_template_from_project(self):
            // self.ensure_one()
            // template = self.copy(default={"is_template": True, "partner_id": False})
            // template._toggle_template_mode(True)
            // template.message_post(body=self.env._("Template created from %s.", self.name))
            // config = {
            //     "tag": "project_template_show_notification",
            //     "params": {
            //         "project_id": template.id,
            //         "undo_method": "unlink",
            //     },
            // }
            // if callbacks := self._get_template_from_project_undo_callbacks():
            //     config["params"]["callback_data"] = {
            //         "method": "create_template_from_project_undo_callback",
            //         "args": [self.id, callbacks],
            //     }
            // return {
            //     "type": "ir.actions.client",
            //     **config,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_dependent_tasks(self):
            // self.ensure_one()
            // return {
            //     'res_model': 'project.task',
            //     'type': 'ir.actions.act_window',
            //     'context': {**self.env.context, 'default_depend_on_ids': [Command.link(self.id)], 'show_project_update': False, 'search_default_open_tasks': True},
            //     'domain': [('depend_on_ids', '=', self.id)],
            //     'name': _('Dependent Tasks'),
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_milestone_action')
            // action['display_name'] = _("%(name)s's Milestones", name=self.name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionJobAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_job_add_applicants(self):
            // return {
            //     "name": _("Create Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "job.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_applicant_ids": self.ids
            //         or self.env.context.get("default_applicant_ids"),
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_applications(self):
            // self.ensure_one()
            // similar_applicants = (
            //     self.env["hr.applicant"]
            //     .with_context(active_test=False)
            //     .search(
            //         self._get_similar_applicants_domain(ignore_talent=True),
            //     )
            // )
            // return {
            //     "name": _("Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "list,form",
            //     "domain": [("id", "in", similar_applicants.ids)],
            //     "context": {
            //         "active_test": False,
            //         "search_default_stage": 1,
            //         "default_applicant_ids": self.ids,
            //         "no_create_application_button": True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': 'hr.applicant',
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids), ],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.employee_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_parent_task(self):
            // return {
            //     'name': _('Parent Task'),
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.parent_id.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self.env.context
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_ratings(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_task')
            // if self.rating_count == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.rating_ids[0].id
            //     action['views'] = [[self.env.ref('project.rating_rating_view_form_project').id, 'form']]
            //     return action
            // else:
            //     return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_open_share_project_wizard(self):
            // template = self.env.ref('project.mail_template_project_sharing', raise_if_not_found=False)
            // 
            // local_context = self.env.context | {
            //     'default_template_id': template.id if template else False,
            //     'default_email_layout_xmlid': 'mail.mail_notification_light',
            //     'active_id': self.id,
            //     'active_model': 'project.project',
            // }
            // action = self.env["ir.actions.actions"]._for_xml_id("project.project_share_wizard_action")
            // if self.env.context.get('default_access_mode'):
            //     action['name'] = _("Share Project")
            // action['context'] = local_context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_task(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self.env.context
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_blocking(self):
            // self.ensure_one()
            // blockings = self.dependent_ids
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_blocking_tasks')
            // if len(blockings) == 1:
            //     action['view_mode'] = 'form'
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //     action['res_id'] = blockings.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_subtasks(self):
            // self.ensure_one()
            // subtasks = self.env['project.task'].search([('id', 'child_of', self.id), ('id', '!=', self.id)])
            // if subtasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_sub_task')
            //     if len(subtasks) == 1:
            //         action['view_mode'] = 'form'
            //         action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //         action['res_id'] = subtasks.id
            //     return action
            // return {
            //     'name': 'Portal Sub-tasks',
            //     'type': 'ir.actions.act_url',
            //     'url': f'/my/projects/{self.project_id.id}/task/{self.id}/subtasks' if len(subtasks) > 1 else subtasks.get_portal_url(query_string='project_sharing=1'),
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_task(self):
            // action = self.action_open_task()
            // action['views'] = [[self.env.ref('project.project_sharing_project_task_view_form').id, 'form']]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_recurring_tasks(self):
            // self.ensure_one()
            // recurrent_tasks = self.env['project.task'].search([('recurrence_id', 'in', self.recurrence_id.ids)])
            // # If all the recurrent tasks are in the same project, open the list view in sharing mode.
            // if recurrent_tasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_recurring_tasks_action')
            //     action.update({
            //         'context': {'default_project_id': self.project_id.id},
            //         'domain': [
            //             ('project_id', '=', self.project_id.id),
            //             ('recurrence_id', 'in', self.recurrence_id.ids)
            //         ]
            //     })
            //     return action
            // # If at least one recurrent task belong to another project, open the portal page
            // return {
            //     'name': 'Portal Recurrent Tasks',
            //     'type': 'ir.actions.act_url',
            //     'url':  f'/my/projects/{self.project_id.id}/task/{self.id}/recurrent_tasks',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_view_parent_task(self):
            // if self.parent_id.project_id != self.project_id and self.env.user._is_portal():
            //     project = self.parent_id.project_id._filtered_access('read')
            //     if project:
            //         url = f"/my/projects/{self.parent_id.project_id.id}/task/{self.parent_id.id}"
            //         if project._check_project_sharing_access():
            //             url = f"/my/projects/{self.parent_id.project_id.id}?task_id={self.parent_id.id}"
            //         return {
            //             "name": "Portal Parent Task",
            //             "type": "ir.actions.act_url",
            //             "url": url,
            //         }
            //     elif self.display_parent_task_button:
            //         return self.parent_id.get_portal_url()
            //     # The portal user has no access to the parent task, so normally the button should be invisible.
            //     return {}
            // action = self.with_context({
            //     'search_view_ref': 'project.project_sharing_project_task_view_search',
            // }).action_open_parent_task()
            // action['views'] = [(self.env.ref('project.project_sharing_project_task_view_form').id, 'form')]
            // action['search_view_id'] = self.env.ref("project.project_sharing_project_task_view_search").id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_project_task_burndown_chart_report(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_burndown_chart_report')
            // action['display_name'] = _("%(name)s's Burndown Chart", name=self.name)
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'stage_name_and_sequence_per_id': {
            //         stage.id: {
            //             'sequence': stage.sequence,
            //             'name': stage.name
            //         } for stage in self.type_ids
            //     }
            // })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_recurring_tasks(self):
            // return {
            //     'name': _('Tasks in Recurrence'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'project.task',
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            //     'context': {'create': False},
            //     'domain': [('recurrence_id', 'in', self.recurrence_id.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_redirect_to_project_task_form(self):
            // menu_id = self.env.ref('project.menu_project_management_all_tasks').id
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f"/odoo/{self.project_id.id}/action-project.act_project_project_2_project_task_all/{self.id}?menu_id={menu_id}",
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_reschedule_meeting(self):
            // self.ensure_one()
            // action = self.action_schedule_meeting(smart_calendar=False)
            // next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // if next_activity.calendar_event_id:
            //     action['context']['initial_date'] = next_activity.calendar_event_id.start
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRestoreAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_restore(self):
            // """ Restoring a lost lead means that it should go back to its normal life cycle.
            // This should reactivate the lead but also force the recompute of its probability, for the stage where the lead
            // is currently at. During toggle_active, when reactivating a lost lead,only the automated probability will be
            // recomputed, because the probability is not automated anymore. Restore will reset this automation."""
            // self.action_unarchive()
            // for lead in self:
            //     lead.probability = lead.automated_probability
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param bool smart_calendar: to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :returns: dictionary value for created Meeting view
            //     :rtype: dict
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // partner_ids = self.env.user.partner_id.ids
            // if self.partner_id:
            //     partner_ids.append(self.partner_id.id)
            // current_opportunity_id = self.id if self.type == 'opportunity' else False
            // action['context'] = {
            //     'search_default_opportunity_id': current_opportunity_id,
            //     'default_opportunity_id': current_opportunity_id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_partner_ids': partner_ids,
            //     'default_team_id': self.team_id.id,
            //     'default_name': self.name,
            // }
            // 
            // # 'Smart' calendar view : get the most relevant time period to display to the user.
            // if current_opportunity_id and smart_calendar:
            //     mode, initial_date = self._get_opportunity_meeting_view_parameters()
            //     action['context'].update({'default_mode': mode, 'initial_date': initial_date})
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'applicant.send.mail',
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // """ Update the automated probability and align probability to that value """
            // self.ensure_one()
            // self._compute_probabilities()
            // self.write({'probability': self.automated_probability})
            */
            return default;
        }

        public async Task<TEntity> ActionSetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 AND active = False """
            // res = self.action_archive()
            // self.write({**additional_values, 'probability': 0, 'automated_probability': 0})
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: stage.is_won (AND probability = 100 but implied) """
            // self.action_unarchive()
            // # group the leads by team_id, in order to write once by values couple (each write leads to frequency increment)
            // leads_by_won_stage = {}
            // for lead in self:
            //     won_stages = self._stage_find(domain=[('is_won', '=', True)], limit=None)
            //     # ABD : We could have a mixed pipeline, with "won" stages being separated by "standard"
            //     # stages. In the future, we may want to prevent any "standard" stage to have a higher
            //     # sequence than any "won" stage. But while this is not the case, searching
            //     # for the "won" stage while alterning the sequence order (see below) will correctly
            //     # handle such a case :
            //     #       stage sequence : [x] [x (won)] [y] [y (won)] [z] [z (won)]
            //     #       when in stage [y] and marked as "won", should go to the stage [y (won)],
            //     #       not in [x (won)] nor [z (won)]
            //     stage_id = next((stage for stage in won_stages if stage.sequence > lead.stage_id.sequence), None)
            //     if not stage_id:
            //         stage_id = next((stage for stage in reversed(won_stages) if stage.sequence <= lead.stage_id.sequence), won_stages)
            //     if stage_id in leads_by_won_stage:
            //         leads_by_won_stage[stage_id] += lead
            //     else:
            //         leads_by_won_stage[stage_id] = lead
            // for won_stage_id, leads in leads_by_won_stage.items():
            //     leads.write({'stage_id': won_stage_id.id, 'probability': 100})
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won_rainbowman(self):
            // self.ensure_one()
            // self.action_set_won()
            // 
            // message = self._get_rainbowman_message()
            // if message:
            //     return {
            //         'effect': {
            //             'fadeout': 'slow',
            //             'message': message,
            //             'img_url': '/web/image/%s/%s/image_1024' % (self.team_id.user_id._name, self.team_id.user_id.id) if self.team_id.user_id.image_1024 else '/web/static/img/smile.svg',
            //             'type': 'rainbow_man',
            //         }
            //     }
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_show_potential_duplicates(self):
            // """ Open kanban view to display duplicate leads or opportunity.
            //     :return dict: dictionary value for created kanban view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.duplicate_lead_ids.ids)]
            // action['context'] = {
            //     'active_test': False,
            //     'create': False
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_add_applicants(self):
            // return {
            //     "name": _("Add applicant(s) to the pool"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "talent.pool.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_talent_pool_ids": self.env.context.get(
            //             "default_talent_pool_ids"
            //         )
            //         or [],
            //         "default_applicant_ids": self.ids,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolStatButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_stat_button(self):
            // self.ensure_one()
            // # If the applicant has other applications linked to pool but for some
            // # reason this applicant is not linked to that account then link it
            // if not self.pool_applicant_id:
            //     self.link_applicant_to_talent()
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "form",
            //     "target": "current",
            //     "res_id": self.pool_applicant_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionToggleProjectTemplateModeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_toggle_project_template_mode(self):
            // self.ensure_one()
            // config = {
            //     "params": {
            //         "project_id": self.id,
            //     },
            // }
            // if self.is_template:
            //     config["tag"] = "project_template_show_undo_confirmation_dialog"
            //     if callbacks := self._get_template_to_project_confirmation_callbacks():
            //         config["params"]["callback_data"] = {
            //             "method": "template_to_project_confirmation_callback",
            //             "args": [self.id, callbacks],
            //         }
            //     if warning_messages := self._get_template_to_project_warnings():
            //         config["params"]["message"] = self.env._(
            //             "%(warning_messages)s\nAre you sure you want to continue?",
            //             warning_messages="\n".join(warning_messages),
            //         )
            //     else:
            //         config["params"]["message"] = self.env._(
            //             "This project is currently a template. Would you like to convert it back into a regular project?",
            //         )
            // else:
            //     config["tag"] = "project_to_template_redirection_action"
            // return {
            //     "type": "ir.actions.client",
            //     **config,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_unarchive(self):
            // """ When re-activating, force update probability for both leads and
            // opportunities. Note that archiving triggers nothing more, as a lead
            // can be archived and not lost. """
            // activated = self.filtered(lambda rec: not rec.active)
            // res = super().action_unarchive()
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_unarchive(self):
            // res = super(HrApplicant, self.with_context(just_unarchived=True)).action_unarchive()
            // self.reset_applicant()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_undo_convert_to_template(self):
            // self.ensure_one()
            // self._toggle_template_mode(False)
            // self.message_post(body=self.env._("Template converted back to regular project."))
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "display_notification",
            //     "params": {
            //         "message": self.env._("Template converted back to regular project."),
            //         "next": {
            //             "type": "ir.actions.client",
            //             "tag": "soft_reload",
            //         },
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_undo_convert_to_template(self):
            // self.ensure_one()
            // self.is_template = False
            // self.message_post(body=_("Template converted back to regular task"))
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('Template converted back to regular task'),
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload',
            //         },
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_unlink_recurrence(self):
            // self.recurrence_id.task_ids.recurring_task = False
            // self.recurrence_id.unlink()
            */
            return default;
        }

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_all_rating(self):
            // """ return the action to see all the rating of the project and activate default filters"""
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_view_project_rating')
            // action['display_name'] = _("%(name)s's Rating", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context.update(self.env.context)
            // action_context['search_default_filter_write_date'] = 'custom_write_date_last_30_days'
            // action_context.pop('group_by', None)
            // action['domain'] = [('consumed', '=', True), ('parent_res_model', '=', 'project.project'), ('parent_res_id', '=', self.id)]
            // if self.rating_count == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'views': [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form'],
            //         'res_id': self.rating_ids[0].id, # [0] since rating_ids might be > then rating_count
            //     })
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_analysis(self):
            // """ return the action to see the tasks analysis report of the project """
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_user_tree')
            // action['display_name'] = _("%(name)s's Tasks Analysis", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context['search_default_project_id'] = self.id
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // action = self.env['ir.actions.act_window'].with_context(active_id=self.id)._for_xml_id('project.act_project_project_2_project_task_all')
            // action['display_name'] = self.name
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'create': self.active,
            //     'active_test': self.active,
            //     'active_id': self.id,
            //     'allow_milestones': self.allow_milestones,
            //     'allow_task_dependencies': self.allow_task_dependencies,
            //     })
            // action['context'] = context
            // if self.is_template:
            //     action['context'].update({'template_project': True})
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type not in ('pivot', 'graph')]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksFromProjectMilestoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_from_project_milestone(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_milestone_action_view_tasks')
            // action['display_name'] = _("Tasks")
            // action['domain'] = [('milestone_id', 'in', self.milestone_ids.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_collaborators(self, partners, limited_access=False):
            // self.ensure_one()
            // new_collaborators = self._get_new_collaborators(partners)
            // if not new_collaborators:
            //     # Then we have nothing to do
            //     return
            // self.write({'collaborator_ids': [
            //     Command.create({
            //         'partner_id': collaborator.id,
            //         'limited_access': limited_access,
            //     }) for collaborator in new_collaborators],
            // })
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_followers(self, partners):
            // self.ensure_one()
            // self.message_subscribe(partners.ids)
            // 
            // dict_tasks_per_partner = {}
            // dict_partner_ids_to_subscribe_per_partner = {}
            // for task in self.task_ids:
            //     if task.partner_id in dict_tasks_per_partner:
            //         dict_tasks_per_partner[task.partner_id] |= task
            //     else:
            //         partner_ids_to_subscribe = [
            //             partner.id for partner in partners
            //             if partner == task.partner_id or partner in task.partner_id.child_ids
            //         ]
            //         if partner_ids_to_subscribe:
            //             dict_tasks_per_partner[task.partner_id] = task
            //             dict_partner_ids_to_subscribe_per_partner[task.partner_id] = partner_ids_to_subscribe
            // for partner, tasks in dict_tasks_per_partner.items():
            //     tasks.message_subscribe(dict_partner_ids_to_subscribe_per_partner[partner])
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('project.task').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['project_id'] = self.id
            // return values
            */
            return default;
        }

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def archive_applicant(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Refuse Reason'),
            //     'res_model': 'applicant.get.refuse.reason',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //         'active_test': False,
            //         'hide_mail_template_management_options': True,
            //     },
            //     'views': [[False, 'form']]
            // }
            */
            return default;
        }

        public async Task<TEntity> AssignUserlessLeadInTeamInternalAsync<TEntity>(IEnumerable<TEntity> entities, string creation_source) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _assign_userless_lead_in_team(self, creation_source: str):
            // """ Assign userless leads to their team's leader. """
            // if not self._is_rule_based_assignment_activated() and self.team_id:
            //     for team_id, leads in self.filtered(lambda lead: not lead.user_id).grouped('team_id').items():
            //         if team_id.user_id:
            //             leads.user_id = team_id.user_id
            //             message = _('This new lead created by %(creation_source)s was automatically assigned to team leader %(user_name)s',
            //                 user_name=team_id.user_id.name,
            //                 creation_source=creation_source,
            //             )
            //             leads._message_log_batch(bodies={lead.id: message for lead in leads})
            */
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _change_privacy_visibility(self, new_visibility):
            // """
            // Unsubscribe non-internal users from the project and tasks if the project privacy visibility
            // goes from 'portal' to a different value.
            // If the privacy visibility is set to 'portal', subscribe back project and tasks partners.
            // """
            // for project in self:
            //     if project.privacy_visibility == new_visibility:
            //         continue
            //     if new_visibility in ['invited_users', 'portal']:
            //         project.message_subscribe(partner_ids=project.partner_id.ids)
            //         for task in project.task_ids.filtered('partner_id'):
            //             task.message_subscribe(partner_ids=task.partner_id.ids)
            //     elif project.privacy_visibility in ['invited_users', 'portal']:
            //         portal_users = project.message_partner_ids.user_ids.filtered('share')
            //         project.message_unsubscribe(partner_ids=portal_users.partner_id.ids)
            //         project.tasks._unsubscribe_portal_users()
            //         # revoke access_token since the project and its tasks are no longer accessible for portal/public users
            //         project.tasks.access_token = ''
            //         project.access_token = ''
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_account_id(self):
            // # Overriden from 'analytic.plan.fields.mixin'
            // pass
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFeaturesEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object updated_features) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def check_features_enabled(self, updated_features=None):
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // if updated_features:
            //     return {
            //         field_name: self.env.user.has_group(group)
            //         for field_name, group in self._get_project_features_mapping().items()
            //         if field_name in updated_features
            //     }
            // return {
            //     field_name: self.env.user.has_group(group)
            //     for field_name, group in self._get_project_features_mapping().items()
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_interviewer_access(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     raise UserError(_('You are not allowed to perform this action.'))
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_no_cyclic_dependencies(self):
            // if self._has_cycle('depend_on_ids'):
            //     raise ValidationError(_("Two tasks cannot depend on each other."))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create a recursive hierarchy of tasks.'))
            */
            return default;
        }

        public async Task<TEntity> CheckProjectGroupAtRemovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_group_at_removal(self):
            // self._check_project_group_with_field('allow_task_dependencies', 'project.group_project_task_dependencies')
            // self._check_project_group_with_field('allow_milestones', 'project.group_project_milestone')
            // self._check_project_group_with_field('allow_recurring_tasks', 'project.group_project_recurring_tasks')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckProjectGroupWithFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object group_name) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_group_with_field(self, field_name, group_name):
            // """ Check if the user has the group 'group_name' and if there is a project with the field 'field_name' set to True.
            // If not, remove the group 'group_name' from the user base group.
            // Otherwise, add the group 'group_name' to the user base group.
            // Returns True if the group was added, False if it was removed, None if no change was made.
            // """
            // has_user_group = bool(self.env.user.has_group(group_name))
            // group = self.env.ref(group_name)
            // base_group_user = self.env.ref('base.group_user')
            // has_project_field_set = bool(self.env['project.project'].search_count([(field_name, '=', True)], limit=1))
            // res = None
            // 
            // if not has_user_group and has_project_field_set:
            //     # add the group to the base user group if there is at least one project with field_name=True
            //     base_group_user.sudo().write({
            //         'implied_ids': [Command.link(group.id)]
            //     })
            //     res = True
            // elif has_user_group and not has_project_field_set:
            //     # remove the group from the base user group if there is no project with field_name=True
            //     base_group_user.sudo().write({
            //         'implied_ids': [Command.unlink(group.id)]
            //     })
            //     group.sudo().write({'user_ids': [Command.clear()]})
            //     res = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_sharing_access(self):
            // self.ensure_one()
            // if self.privacy_visibility not in ['invited_users', 'portal']:
            //     return False
            // if self.env.user._is_portal():
            //     return self.env['project.collaborator'].search([('project_id', '=', self.sudo().id), ('partner_id', '=', self.env.user.partner_id.id)])
            // return self.env.user._is_internal()
            */
            return default;
        }

        public async Task<TEntity> CheckTalentPoolRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_talent_pool_required(self):
            // for talent in self:
            //     if talent.pool_applicant_id == talent and not talent.talent_pool_ids:
            //         raise ValidationError(self.env._("Talent must belong to at least one Talent Pool."))
            */
            return default;
        }

        public async Task<TEntity> CheckWonValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _check_won_validity(self):
            // for lead in self:
            //     if lead.stage_id.is_won and lead.probability != 100:
            //         raise ValidationError(_("A lead in a Won stage cannot be lost. Move it to another stage first."))
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_instruction_message(self):
            // for project in self:
            //     if project.privacy_visibility == 'portal':
            //         project.access_instruction_message = self.env._('To give portal users access to your project, add them as followers. For task access, add them as followers for each task.')
            //     elif project.privacy_visibility == 'followers':
            //         project.access_instruction_message = self.env._('Grant employees access to your project or tasks by adding them as followers. Employees automatically get access to the tasks they are assigned to.')
            //     elif project.privacy_visibility == 'invited_users':
            //         project.access_instruction_message = self.env._("Grant users access by adding them as followers — either to the project or individual tasks. Internal users automatically gain access to tasks they are assigned to.")
            //     else:
            //         project.access_instruction_message = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for task in self:
            //     task.access_url = f'/my/tasks/{task.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_count(self):
            // """
            // This method will calculate the number of applications that are either
            // directly or indirectly linked to the current application(s)
            // - An application is considered directly linked if it shares the same
            //   pool_applicant_id
            // - An application is considered indirectly_linked if it has the same
            //   value as the current application(s) in any of the following field:
            //   email, phone number or linkedin
            // 
            // Note: If self has pool_applicant_id, email, phone number or linkedin set
            // this method will include self in the returned count
            // """
            // all_emails = {a.email_normalized for a in self if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in self if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in self if a.linkedin_profile}
            // all_pool_applicants = {a.pool_applicant_id.id for a in self if a.pool_applicant_id}
            // 
            // domain = Domain.FALSE
            // if all_emails:
            //     domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // if all_pool_applicants:
            //     domain |= Domain("pool_applicant_id", "in", list(all_pool_applicants))
            // 
            // domain &= Domain("talent_pool_ids", "=", False)
            // matching_applicants = self.env["hr.applicant"].with_context(active_test=False).search(domain)
            // 
            // email_map = defaultdict(set)
            // phone_map = defaultdict(set)
            // linkedin_map = defaultdict(set)
            // pool_applicant_map = defaultdict(set)
            // for app in matching_applicants:
            //     if app.email_normalized:
            //         email_map[app.email_normalized].add(app.id)
            //     if app.partner_phone_sanitized:
            //         phone_map[app.partner_phone_sanitized].add(app.id)
            //     if app.linkedin_profile:
            //         linkedin_map[app.linkedin_profile].add(app.id)
            //     if app.pool_applicant_id:
            //         pool_applicant_map[app.pool_applicant_id].add(app.id)
            // 
            // for applicant in self:
            //     related_ids = set()
            //     if applicant.email_normalized:
            //         related_ids.update(email_map.get(applicant.email_normalized, set()))
            //     if applicant.partner_phone_sanitized:
            //         related_ids.update(phone_map.get(applicant.partner_phone_sanitized, set()))
            //     if applicant.linkedin_profile:
            //         related_ids.update(linkedin_map.get(applicant.linkedin_profile, set()))
            //     if applicant.pool_applicant_id:
            //         related_ids.update(pool_applicant_map.get(applicant.pool_applicant_id, set()))
            // 
            //     count = len(related_ids)
            // 
            //     applicant.application_count = max(0, count)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_status(self):
            // for applicant in self:
            //     if applicant.refuse_reason_id:
            //         applicant.application_status = 'refused'
            //     elif not applicant.active:
            //         applicant.application_status = 'archived'
            //     elif applicant.date_closed:
            //         applicant.application_status = 'hired'
            //     else:
            //         applicant.application_status = 'ongoing'
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_attachment_ids(self):
            // for task in self:
            //     attachment_ids = self.env['ir.attachment'].search(task._get_attachments_search_domain()).ids
            //     message_attachment_ids = task.mapped('message_ids.attachment_ids').ids  # from mail_thread
            //     task.attachment_ids = [(6, 0, list(set(attachment_ids) - set(message_attachment_ids)))]
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_closed_task_count(self):
            // self.__compute_task_count(
            //     count_field='closed_task_count',
            //     additional_domain=[('state', 'in', [*CLOSED_STATES])],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_collaborator_count(self):
            // project_sharings = self.filtered(lambda project: project.privacy_visibility in ['invited_users', 'portal'])
            // collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', project_sharings.ids)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // collaborator_count_by_project = {project.id: count for project, count in collaborator_read_group}
            // for project in self:
            //     project.collaborator_count = collaborator_count_by_project.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_commercial_partner_id(self):
            // leads_w_partners = self.filtered('partner_id')
            // for lead in leads_w_partners:
            //     commercial_partner = lead.partner_id.commercial_partner_id
            //     lead.commercial_partner_id = commercial_partner.is_company and commercial_partner != lead.partner_id and commercial_partner
            // # match by name if exists
            // remaining_leads_w_pname = (self - leads_w_partners).filtered('partner_name')
            // commercial_partner_by_name = self.env['res.partner']._read_group(
            //     [('is_company', '=', True), ('name', 'in', remaining_leads_w_pname.mapped('partner_name'))],
            //     ['name'], ['id:array_agg'],
            // )
            // remaining_leads_by_name = remaining_leads_w_pname.grouped('partner_name')
            // for commercial_partner_name, commercial_partner_ids in commercial_partner_by_name:
            //     remaining_leads_by_name[commercial_partner_name].commercial_partner_id = commercial_partner_ids[0]
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_currency(self):
            // for lead in self:
            //     if not lead.company_id:
            //         lead.company_currency = self.env.company.currency_id
            //     else:
            //         lead.company_currency = lead.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_id(self):
            // """ Compute company_id coherency. """
            // for lead in self:
            //     proposal = lead.company_id
            // 
            //     # invalidate wrong configuration
            //     if proposal:
            //         # company not in responsible companies
            //         if lead.user_id and proposal not in lead.user_id.company_ids:
            //             proposal = False
            //         # inconsistent
            //         elif lead.team_id.company_id and proposal != lead.team_id.company_id:
            //             proposal = False
            //         # void company on team and no assignee
            //         elif lead.team_id and not lead.team_id.company_id and not lead.user_id:
            //             proposal = False
            //         # no user and no team -> void company and let assignment do its job
            //         # unless customer has a company
            //         elif not lead.team_id and not lead.user_id and \
            //                 (not lead.partner_id or lead.partner_id.company_id != proposal):
            //             proposal = False
            // 
            //     # propose a new company based on team > user (respecting context) > partner
            //     if not proposal:
            //         if lead.team_id.company_id:
            //             lead.company_id = lead.team_id.company_id
            //         elif lead.user_id:
            //             if self.env.company in lead.user_id.company_ids:
            //                 lead.company_id = self.env.company
            //             else:
            //                 lead.company_id = lead.user_id.company_id & self.env.companies
            //         elif lead.partner_id:
            //             lead.company_id = lead.partner_id.company_id
            //         else:
            //             lead.company_id = False
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_company_id(self):
            // for project in self:
            //     # if a new restriction is put on the account or the customer, the restriction on the project is updated.
            //     if project.account_id.company_id:
            //         project.company_id = project.account_id.company_id
            //     if not project.company_id and project.partner_id.company_id:
            //         project.company_id = project.partner_id.company_id
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_company_id(self):
            // for task in self:
            //     if not task.parent_id and not task.project_id:
            //         continue
            //     task.company_id = task.project_id.company_id or task.parent_id.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_company(self):
            // for applicant in self:
            //     company_id = False
            //     if applicant.department_id:
            //         company_id = applicant.department_id.company_id.id
            //     if not company_id and applicant.job_id:
            //         company_id = applicant.job_id.company_id.id
            //     applicant.company_id = company_id or self.env.company.id
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_contact_name(self):
            // """ compute the new values when partner_id has changed """
            // to_reset = self.filtered(lambda l: not l.partner_id)
            // to_reset.contact_name = False
            // for lead in (self - to_reset):
            //     lead.update(lead._prepare_contact_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_currency_id(self):
            // default_currency_id = self.env.company.currency_id
            // for project in self:
            //     project.currency_id = project.company_id.currency_id or default_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_current_user_same_company_partner(self):
            // commercial_partner_id = self.env.user.partner_id.commercial_partner_id
            // for task in self:
            //     task.current_user_same_company_partner = task.partner_id and commercial_partner_id == task.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_date_closed(self):
            // for applicant in self:
            //     if applicant.stage_id and applicant.stage_id.hired_stage and not applicant.date_closed:
            //         applicant.date_closed = fields.Datetime.now()
            //     if not applicant.stage_id.hired_stage:
            //         applicant.date_closed = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_last_stage_update(self):
            // for lead in self:
            //     if not lead.date_last_stage_update:
            //         lead.date_last_stage_update = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_open(self):
            // for lead in self:
            //     if not lead.date_open and lead.user_id:
            //         lead.date_open = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_close(self):
            // """ Compute difference between current date and log date """
            // leads = self.filtered(lambda l: l.date_closed and l.create_date)
            // others = self - leads
            // others.day_close = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date)
            //     date_close = fields.Datetime.from_string(lead.date_closed)
            //     lead.day_close = abs((date_close - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_day(self):
            // for applicant in self:
            //     if applicant.date_open:
            //         date_create = applicant.create_date
            //         date_open = applicant.date_open
            //         applicant.day_open = (date_open - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_open = False
            //     if applicant.date_closed:
            //         date_create = applicant.create_date
            //         date_closed = applicant.date_closed
            //         applicant.day_close = (date_closed - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_close = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_open(self):
            // """ Compute difference between create date and open date """
            // leads = self.filtered(lambda l: l.date_open and l.create_date)
            // others = self - leads
            // others.day_open = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date).replace(microsecond=0)
            //     date_open = fields.Datetime.from_string(lead.date_open)
            //     lead.day_open = abs((date_open - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_delay(self):
            // for applicant in self:
            //     if applicant.date_open and applicant.day_close:
            //         applicant.delay_close = applicant.day_close - applicant.day_open
            //     else:
            //         applicant.delay_close = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_department(self):
            // for applicant in self:
            //     applicant.department_id = applicant.job_id.department_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_depend_on_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // tasks_without_dependency = self - tasks_with_dependency
            // tasks_without_dependency.depend_on_count = 0
            // tasks_without_dependency.closed_depend_on_count = 0
            // if not any(self._ids):
            //     for task in self:
            //         task.depend_on_count = len(task.depend_on_ids)
            //         task.closed_depend_on_count = len(task.depend_on_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // if tasks_with_dependency:
            //     # need the sudo for project sharing
            //     total_and_closed_depend_on_count = {
            //         dependent_on.id: (count, sum(s in CLOSED_STATES for s in states))
            //         for dependent_on, states, count in self.env['project.task']._read_group(
            //             [('dependent_ids', 'in', tasks_with_dependency.ids)],
            //             ['dependent_ids'],
            //             ['state:array_agg', '__count'],
            //         )
            //     }
            //     for task in tasks_with_dependency:
            //         task.depend_on_count, task.closed_depend_on_count = total_and_closed_depend_on_count.get(task._origin.id or task.id, (0, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_dependent_tasks_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // (self - tasks_with_dependency).dependent_tasks_count = 0
            // if tasks_with_dependency:
            //     group_dependent = self.env['project.task']._read_group([
            //         ('depend_on_ids', 'in', tasks_with_dependency.ids),
            //         ('is_closed', '=', False),
            //     ], ['depend_on_ids'], ['__count'])
            //     dependent_tasks_count_dict = {
            //         depend_on.id: count
            //         for depend_on, count in group_dependent
            //     }
            //     for task in tasks_with_dependency:
            //         task.dependent_tasks_count = dependent_tasks_count_dict.get(task.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_follow_button(self):
            // if not self.env.user.share:
            //     self.display_follow_button = False
            //     return
            // project_collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', self.project_id.ids), ('partner_id', '=', self.env.user.partner_id.id)],
            //     ['project_id'],
            //     ['limited_access:bool_and'],
            // )
            // limited_access_per_project_id = dict(project_collaborator_read_group)
            // for task in self:
            //     task.display_follow_button = not limited_access_per_project_id.get(task.project_id, True)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_in_project(self):
            // for record in self:
            //     record.display_in_project = not record.project_id or (
            //             not record.parent_id or record.project_id != record.parent_id.project_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('show_partner_name'):
            //     return super()._compute_display_name()
            // for applicant in self:
            //     applicant.display_name = applicant.partner_name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_parent_task_button(self):
            // accessible_parent_tasks = self.parent_id.with_user(self.env.user)._filtered_access('read')
            // for task in self:
            //     task.display_parent_task_button = task.parent_id in accessible_parent_tasks
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _compute_duration_tracking(self):
            // """
            // Computes duration_tracking, a Json field stored as { <many2one_id (str)>: <duration_spent_in_seconds (int)> }
            // 
            //     e.g. {"1": 1230, "2": 2220, "5": 14}
            // 
            // `_track_duration_field` must be present in the model that uses the mixin to specify on what
            // field to compute time spent. Besides, tracking must be activated for that field.
            // 
            //     e.g.
            //     class MyModel(models.Model):
            //         _name = 'my.model'
            //         _track_duration_field = "tracked_field"
            // 
            //         tracked_field = fields.Many2one('tracked.model', tracking=True)
            // """
            // 
            // field = self.env['ir.model.fields'].sudo().search_fetch([
            //     ('model', '=', self._name),
            //     ('name', '=', self._track_duration_field),
            // ], ['id'], limit=1)
            // 
            // if (
            //     self._track_duration_field not in self._track_get_fields()
            //     or self._fields[self._track_duration_field].type != 'many2one'
            // ):
            //     self.duration_tracking = False
            //     raise ValueError(_(
            //         'Field “%(field)s” on model “%(model)s” must be of type Many2one and have tracking=True for the computation of duration.',
            //         field=self._track_duration_field, model=self._name
            //     ))
            // 
            // if self.ids:
            //     self.env['mail.tracking.value'].flush_model()
            //     self.env['mail.message'].flush_model()
            //     trackings = self.env.execute_query_dict(SQL("""
            //            SELECT m.res_id,
            //                   v.create_date,
            //                   v.old_value_integer
            //              FROM mail_tracking_value v
            //         LEFT JOIN mail_message m
            //                ON m.id = v.mail_message_id
            //               AND v.field_id = %(field_id)s
            //             WHERE m.model = %(model_name)s
            //               AND m.res_id IN %(record_ids)s
            //          ORDER BY v.id
            //         """,
            //         field_id=field.id, model_name=self._name, record_ids=tuple(self.ids),
            //     ))
            // else:
            //     trackings = []
            // 
            // for record in self:
            //     record_trackings = [tracking for tracking in trackings if tracking['res_id'] == record._origin.id]
            //     record.duration_tracking = record._get_duration_from_tracking(record_trackings)
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_elapsed(self):
            // task_linked_to_calendar = self.filtered(
            //     lambda task: task.project_id.resource_calendar_id and task.create_date
            // )
            // for task in task_linked_to_calendar:
            //     dt_create_date = fields.Datetime.from_string(task.create_date)
            // 
            //     if task.date_assign:
            //         dt_date_assign = fields.Datetime.from_string(task.date_assign)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_assign, compute_leaves=True)
            //         task.working_hours_open = duration_data['hours']
            //         task.working_days_open = duration_data['days']
            //     else:
            //         task.working_hours_open = 0.0
            //         task.working_days_open = 0.0
            // 
            //     if task.date_end:
            //         dt_date_end = fields.Datetime.from_string(task.date_end)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_end, compute_leaves=True)
            //         task.working_hours_close = duration_data['hours']
            //         task.working_days_close = duration_data['days']
            //     else:
            //         task.working_hours_close = 0.0
            //         task.working_days_close = 0.0
            // 
            // (self - task_linked_to_calendar).update(dict.fromkeys(
            //     ['working_hours_open', 'working_hours_close', 'working_days_open', 'working_days_close'], 0.0))
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_domain_criterion(self):
            // self.email_domain_criterion = False
            // for lead in self.filtered('email_normalized'):
            //     lead.email_domain_criterion = iap_tools.mail_prepare_for_domain_search(
            //         lead.email_normalized
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_from(self):
            // for lead in self:
            //     if lead.partner_id.email and lead._get_partner_email_update():
            //         lead.email_from = lead.partner_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_state(self):
            // for lead in self:
            //     email_state = False
            //     if lead.email_from:
            //         email_state = 'incorrect'
            //         for email in email_normalize_all(lead.email_from):
            //             if mail_validation.mail_validate(email):
            //                 email_state = 'correct'
            //                 break
            //     lead.email_state = email_state
            */
            return default;
        }

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_function(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.function or lead.partner_id.function:
            //         lead.function = lead.partner_id.function
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_late_and_unreached_milestone(self):
            // if all(not task.allow_milestones for task in self):
            //     self.has_late_and_unreached_milestone = False
            //     return
            // late_milestones = self.env['project.milestone'].sudo()._search([  # sudo is needed for the portal user in Project Sharing.
            //     ('id', 'in', self.milestone_id.ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', fields.Date.today()),
            // ])
            // for task in self:
            //     task.has_late_and_unreached_milestone = task.allow_milestones and task.milestone_id.id in late_milestones
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_template_ancestor(self):
            // for task in self:
            //     task.has_template_ancestor = task.is_template or (task.parent_id and task.parent_id.sudo().has_template_ancestor)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_applicant_in_pool(self):
            // """
            // Computes if an application is linked to a talent pool or not.
            // An application can either be directly or indirectly linked to a talent pool.
            // Direct link:
            //     - 1. Application has talent_pool_ids set, meaning this application
            //         is a talent pool application, or talent for short.
            //     - 2. Application has pool_applicant_id set, meaning this application
            //     is a copy or directly linked to a talent (scenario 1)
            // 
            // Indirect link:
            //     - 3. Application shares a phone number, email, or linkedin with a
            //         direclty linked application.
            // 
            // Note: While possible, linking an application to a pool through linking
            // it to an indirect link is currently excluded from the implementation
            // for technical reasons.
            // """
            // direct = self.filtered(lambda a: a.talent_pool_ids or a.pool_applicant_id)
            // direct.is_applicant_in_pool = True
            // indirect = self - direct
            // 
            // if not indirect:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirect if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirect if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirect if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // in_pool_data = {"emails": set(), "phones": set(), "linkedins": set()}
            // 
            // for applicant in in_pool_applicants:
            //     if applicant.email_normalized:
            //         in_pool_data["emails"].add(applicant.email_normalized)
            //     if applicant.partner_phone_sanitized:
            //         in_pool_data["phones"].add(applicant.partner_phone_sanitized)
            //     if applicant.linkedin_profile:
            //         in_pool_data["linkedins"].add(applicant.linkedin_profile)
            // 
            // for applicant in indirect:
            //     applicant.is_applicant_in_pool = (
            //         applicant.email_normalized in in_pool_data["emails"]
            //         or applicant.partner_phone_sanitized in in_pool_data["phones"]
            //         or applicant.linkedin_profile in in_pool_data["linkedins"]
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_automated_probability(self):
            // """ If probability and automated_probability are equal probability computation
            // is considered as automatic, aka probability is sync with automated_probability """
            // for lead in self:
            //     lead.is_automated_probability = tools.float_compare(lead.probability, lead.automated_probability, 2) == 0
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_is_closed(self):
            // for task in self:
            //     task.is_closed = task.state in CLOSED_STATES
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_favorite(self):
            // favorite_project_ids = self.env.user.favorite_project_ids
            // for project in self:
            //     project.is_favorite = project in favorite_project_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_milestone_exceeded(self):
            // today = fields.Date.context_today(self)
            // read_group = self.env['project.milestone']._read_group([
            //     ('project_id', 'in', self.filtered('allow_milestones').ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', today)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.is_milestone_exceeded = bool(mapped_count.get(project.id, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_partner_visible(self):
            // """ When the crm.lead is of type 'lead', we don't want to display the "Customer" field on the form view
            // unless it's set (or debug mode).
            // 
            // Indeed, most of the times leads will not have this information set, since when we assign a Customer we
            // usually convert the lead to an opportunity as well.
            // 
            // This means that on the lead form, we don't want to display this field since it may be misleading for the
            // end user.
            // When it's set however, we want to display it, mainly because there are a few automatic synchronizations between
            // the lead and its partner (phone and email for examples), and this needs to be clear that modifying
            // one of those fields will in turn modify the linked partner."""
            // is_debug_mode = self.env.user.has_group('base.group_no_one')
            // for lead in self:
            //     lead.is_partner_visible = bool(lead.type == 'opportunity' or lead.partner_id or is_debug_mode)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_pool(self):
            // for applicant in self:
            //     applicant.is_pool_applicant = applicant.talent_pool_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_active_count(self):
            // self.lang_active_count = len(self.env['res.lang'].get_installed())
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_id(self):
            // """ compute the lang based on partner, erase any value to force the partner
            // one if set. """
            // # prepare cache
            // lang_codes = [code for code in self.mapped('partner_id.lang') if code]
            // if lang_codes:
            //     lang_id_by_code = dict(
            //         (code, self.env['res.lang']._get_data(code=code).id)
            //         for code in lang_codes
            //     )
            // else:
            //     lang_id_by_code = {}
            // for lead in self.filtered('partner_id'):
            //     lead.lang_id = lang_id_by_code.get(lead.partner_id.lang, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_color(self):
            // for project in self:
            //     project.last_update_color = STATUS_COLOR[project.last_update_status]
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_status(self):
            // for project in self:
            //     project.last_update_status = project.last_update_id.status or 'to_define'
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_link_preview_name(self):
            // for task in self:
            //     link_preview_name = task.display_name
            //     if task.project_id:
            //         link_preview_name += f' | {task.project_id.sudo().name}'
            //     task.link_preview_name = link_preview_name
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_meeting_display(self):
            // now = fields.Datetime.now()
            // meeting_data = self.env['calendar.event'].sudo()._read_group([
            //     ('opportunity_id', 'in', self.ids),
            // ], ['opportunity_id'], ['start:array_agg', 'start:max'])
            // mapped_data = {
            //     lead: {
            //         'last_meeting_date': last_meeting_date,
            //         'next_meeting_date': min([dt for dt in meeting_start_dates if dt > now] or [False]),
            //     } for lead, meeting_start_dates, last_meeting_date in meeting_data
            // }
            // for lead in self:
            //     lead_meeting_info = mapped_data.get(lead)
            //     if not lead_meeting_info:
            //         lead.meeting_display_date = False
            //         lead.meeting_display_label = _('No Meeting')
            //     elif lead_meeting_info['next_meeting_date']:
            //         lead.meeting_display_date = lead_meeting_info['next_meeting_date']
            //         lead.meeting_display_label = _('Next Meeting')
            //     else:
            //         lead.meeting_display_date = lead_meeting_info['last_meeting_date']
            //         lead.meeting_display_label = _('Last Meeting')
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_meeting_display(self):
            // applicant_with_meetings = self.filtered('meeting_ids')
            // (self - applicant_with_meetings).update({
            //     'meeting_display_text': _('No Meeting'),
            //     'meeting_display_date': ''
            // })
            // today = fields.Date.today()
            // for applicant in applicant_with_meetings:
            //     count = len(applicant.meeting_ids)
            //     dates = applicant.meeting_ids.mapped('start')
            //     min_date, max_date = min(dates).date(), max(dates).date()
            //     if min_date >= today:
            //         applicant.meeting_display_date = min_date
            //     else:
            //         applicant.meeting_display_date = max_date
            //     if count == 1:
            //         applicant.meeting_display_text = _('1 Meeting')
            //     elif applicant.meeting_display_date >= today:
            //         applicant.meeting_display_text = _('Next Meeting')
            //     else:
            //         applicant.meeting_display_text = _('Last Meeting')
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_count(self):
            // read_group = self.env['project.milestone']._read_group([('project_id', 'in', self.ids)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count = mapped_count.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_milestone_id(self):
            // for task in self:
            //     if task.project_id != task.milestone_id.project_id:
            //         task.milestone_id = task.parent_id.project_id == task.project_id and task.parent_id.milestone_id
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_reached_count(self):
            // read_group = self.env['project.milestone']._read_group(
            //     [('project_id', 'in', self.ids), ('is_reached', '=', True)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count_reached = mapped_count.get(project.id, 0)
            //     project.milestone_progress = project.milestone_count and project.milestone_count_reached * 100 // project.milestone_count
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_name(self):
            // for lead in self:
            //     if not lead.name and lead.partner_id and lead.partner_id.name:
            //         lead.name = _("%s's opportunity") % lead.partner_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_next_milestone_id(self):
            // milestones_per_project_id = {
            //     project.id: milestones
            //     for project, milestones in self.env['project.milestone']._read_group(
            //         [('project_id', 'in', self.ids), ('is_reached', '=', False)],
            //         ['project_id'],
            //         ['id:recordset'],
            //     )
            // }
            // milestones = self.env['project.milestone'].concat(*milestones_per_project_id.values())
            // task_read_group = self.env['project.task']._read_group(
            //     [('milestone_id', 'in', milestones.ids)],
            //     ['milestone_id', 'state'],
            //     ['__count'],
            // )
            // task_count_per_milestones = defaultdict(lambda: (0, 0))
            // for milestone, state, count in task_read_group:
            //     opened_task_count, closed_task_count = task_count_per_milestones[milestone.id]
            //     if state in CLOSED_STATES:
            //         closed_task_count += count
            //     else:
            //         opened_task_count += count
            //     task_count_per_milestones[milestone.id] = opened_task_count, closed_task_count
            // for project in self:
            //     milestones = milestones_per_project_id.get(project.id, self.env['project.milestone'])
            //     project.next_milestone_id = milestones[:1]
            //     milestone_deadline_exceeded = False
            //     milestone_marked_as_done = False
            //     for m in milestones:
            //         opened_task_count, closed_task_count = task_count_per_milestones[m.id]
            //         if (
            //             not milestone_deadline_exceeded
            //             and m.is_deadline_exceeded
            //             and (opened_task_count > 0 or closed_task_count == 0)
            //         ):
            //             milestone_deadline_exceeded = True
            //             break
            //         if not milestone_marked_as_done and opened_task_count == 0 and closed_task_count > 0:
            //             milestone_marked_as_done = True
            //     project.is_milestone_deadline_exceeded = milestone_deadline_exceeded
            //     project.can_mark_milestone_as_done = milestone_marked_as_done
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_open_task_count(self):
            // self.__compute_task_count(
            //     count_field='open_task_count',
            //     additional_domain=[('state', 'in', self.env['project.task'].OPEN_STATES)],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_address_values(self):
            // """ Sync all or none of address fields """
            // for lead in self:
            //     lead.update(lead._prepare_address_values_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_email_update(self):
            // for lead in self:
            //     lead.partner_email_update = lead._get_partner_email_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_id(self):
            // """ Compute the partner_id when the tasks have no partner_id.
            // 
            //     Use the project partner_id if any, or else the parent task partner_id.
            // """
            // for task in self:
            //     if task.has_template_ancestor:
            //         continue
            //     if task.partner_id and not (task.project_id or task.parent_id):
            //         task.partner_id = False
            //         continue
            //     if not task.partner_id:
            //         task.partner_id = self._get_default_partner_id(task.project_id, task.parent_id)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_name(self):
            // """ compute the new values when partner_id has changed """
            // to_reset = self.filtered(lambda l: not l.partner_id)
            // to_reset.partner_name = False
            // for lead in (self - to_reset):
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_email(self):
            // for applicant in self:
            //     if not applicant.partner_id:
            //         continue
            //     applicant.email_from = applicant.partner_id.email
            //     if not applicant.partner_phone:
            //         applicant.partner_phone = applicant.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_phone(self):
            // for task in self:
            //     task.partner_phone = task.partner_id.phone or False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_sanitized(self):
            // for applicant in self:
            //     applicant.partner_phone_sanitized = (
            //         applicant._phone_format(fname="partner_phone") or applicant.partner_phone
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_phone_update(self):
            // for lead in self:
            //     lead.partner_phone_update = lead._get_partner_phone_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_personal_stage_id(self):
            // # An user may only access his own 'personal stage' and there can only be one pair (user, task_id)
            // personal_stages = self.env['project.task.stage.personal'].search([('user_id', '=', self.env.uid), ('task_id', 'in', self.ids)])
            // self.personal_stage_id = False
            // for personal_stage in personal_stages:
            //     personal_stage.task_id.personal_stage_id = personal_stage
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone(self):
            // for lead in self:
            //     if lead.partner_id.phone and lead._get_partner_phone_update():
            //         lead.phone = lead.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone_state(self):
            // for lead in self:
            //     phone_status = False
            //     if lead.phone:
            //         country_code = lead.country_id.code if lead.country_id and lead.country_id.code else None
            //         try:
            //             if phone_validation.phone_parse(lead.phone, country_code):  # otherwise library not installed
            //                 phone_status = 'correct'
            //         except UserError:
            //             phone_status = 'incorrect'
            //     lead.phone_state = phone_status
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_portal_user_names(self):
            // """ This compute method allows to see all the names of assigned users to each task contained in `self`.
            // 
            //     When we are in the project sharing feature, the `user_ids` contains only the users if we are a portal user.
            //     That is, only the users in the same company of the current user.
            //     So this compute method is a related of `user_ids.name` but with more records that the portal user
            //     can normally see.
            //     (In other words, this compute is only used in project sharing views to see all assignees for each task)
            // """
            // if self._origin:
            //     # fetch 'user_ids' in superuser mode (and override value in cache
            //     # browse is useful to avoid miscache because of the newIds contained in self
            //     self.invalidate_recordset(fnames=['user_ids'])
            //     self._origin.fetch(['user_ids'])
            // for task in self.with_context(prefetch_fields=False):
            //     task.portal_user_names = format_list(self.env, task.user_ids.mapped('name'))
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_potential_lead_duplicates(self):
            // """ Override potential lead duplicates computation to be more efficient
            // with high lead volume.
            // Criterions:
            //   * email domain exact match;
            //   * phone_sanitized exact match;
            //   * same commercial entity;
            // """
            // SEARCH_RESULT_LIMIT = 21
            // 
            // def return_if_relevant(model_name, domain):
            //     """ Returns the recordset obtained by performing a search on the provided
            //     model with the provided domain if the cardinality of that recordset is
            //     below a given threshold (i.e: `SEARCH_RESULT_LIMIT`). Otherwise, returns
            //     an empty recordset of the provided model as it indicates search term
            //     was not relevant.
            //     Note: The function will use the administrator privileges to guarantee
            //     that a maximum amount of leads will be included in the search results
            //     and transcend multi-company record rules. It also includes archived
            //     records. Idea is that counter indicates duplicates are present and
            //     the lead could be escalated to managers.
            //     """
            //     model = self.env[model_name].with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id
            //     common_lead_domain = [
            //         ('id', '!=', lead_id)
            //     ]
            // 
            //     duplicate_lead_ids = self.env['crm.lead']
            // 
            //     # check the "company" email domain duplicates
            //     if lead.email_domain_criterion:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('email_domain_criterion', '=', lead.email_domain_criterion)
            //         ])
            //     # check for "same commercial entity" duplicates
            //     if lead.partner_id and lead.partner_id.commercial_partner_id:
            //         duplicate_lead_ids |= lead.with_context(active_test=False).search(common_lead_domain + [
            //             ("partner_id", "child_of", lead.partner_id.commercial_partner_id.ids)
            //         ])
            //     # check the phone number duplicates, based on phone_sanitized. Only
            //     # exact matches are found, and the single one stored in phone_sanitized
            //     # in case phone is set.
            //     if lead.phone_sanitized:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('phone_sanitized', '=', lead.phone_sanitized)
            //         ])
            // 
            //     lead.duplicate_lead_ids = duplicate_lead_ids + lead
            //     lead.duplicate_lead_count = len(duplicate_lead_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_privacy_visibility_warning(self):
            // for project in self:
            //     if not project.ids:
            //         project.privacy_visibility_warning = ''
            //     elif project.privacy_visibility in ['invited_users', 'portal'] and project._origin.privacy_visibility not in ['invited_users', 'portal']:
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility not in ['invited_users', 'portal'] and project._origin.privacy_visibility in ['invited_users', 'portal']:
            //         project.privacy_visibility_warning = _('Portal users will be removed from the followers of the project and its tasks.')
            //     else:
            //         project.privacy_visibility_warning = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_probabilities(self):
            // lead_probabilities, _unused = self._pls_get_naive_bayes_probabilities()
            // for lead in self:
            //     if lead.id in lead_probabilities:
            //         was_automated = lead.active and lead.is_automated_probability
            //         lead.automated_probability = lead_probabilities[lead.id]
            //         if was_automated:
            //             lead.probability = lead.automated_probability
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_project_id(self):
            // self.env.remove_to_compute(self._fields['display_in_project'], self)
            // for task in self:
            //     if not task.display_in_project and task.parent_id and task.parent_id.project_id != task.project_id:
            //         task.project_id = task.parent_id.project_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_prorated_revenue(self):
            // for lead in self:
            //     lead.prorated_revenue = round((lead.expected_revenue or 0.0) * (lead.probability or 0) / 100.0, 2)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_recurring_count(self):
            // self.recurring_count = 0
            // recurring_tasks = self.filtered(lambda l: l.recurrence_id)
            // count = self.env['project.task']._read_group([('recurrence_id', 'in', recurring_tasks.recurrence_id.ids)], ['recurrence_id'], ['__count'])
            // tasks_count = {recurrence.id: count for recurrence, count in count}
            // for task in recurring_tasks:
            //     task.recurring_count = tasks_count.get(task.recurrence_id.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly = (lead.recurring_revenue or 0.0) / (lead.recurring_plan.number_of_months or 1)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly_prorated = (lead.recurring_revenue_monthly or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_prorated = (lead.recurring_revenue or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_repeat(self):
            // rec_fields = self._get_recurrence_fields()
            // defaults = self.default_get(rec_fields)
            // for task in self:
            //     for f in rec_fields:
            //         if task.recurrence_id:
            //             task[f] = task.recurrence_id.sudo()[f]
            //         else:
            //             if task.recurring_task:
            //                 task[f] = defaults.get(f)
            //             else:
            //                 task[f] = False
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_resource_calendar_id(self):
            // for project in self:
            //     project.resource_calendar_id = project.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            */
            return default;
        }

        public async Task<TEntity> ComputeRottingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _compute_rotting(self):
            // """
            // A resource is rotting if its stage has not been updated in a number of days depending on its
            // stage's rotting_threshold_days value, assuming it matches _get_rotting_domain() conditions.
            // 
            // If the rotting_threshold_days field is not defined on the tracked module,
            // or if the value of rotting_threshold_days is 0,
            // then the resource will never rot.
            // """
            // if not self._is_rotting_feature_enabled():
            //     self.is_rotting = False
            //     self.rotting_days = 0
            //     return
            // now = self.env.cr.now()
            // rot_enabled = self.filtered_domain(self._get_rotting_domain())
            // others = self - rot_enabled
            // for stage, records in rot_enabled.grouped(self._track_duration_field).items():
            //     rotting = records.filtered(lambda record:
            //         (record.date_last_stage_update or record.create_date or fields.Datetime.now())
            //         + timedelta(days=stage.rotting_threshold_days) < now
            //     )
            //     for record in rotting:
            //         record.is_rotting = True
            //         record.rotting_days = (now - (record.date_last_stage_update or record.create_date)).days
            //     others += records - rotting
            // others.is_rotting = False
            // others.rotting_days = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRatingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_show_ratings(self):
            // projects_with_rating_active = self.env['project.task.type'].search_fetch(
            //     domain=[
            //         ('project_ids', 'in', self.ids),
            //         ('rating_active', '=', True),
            //     ],
            //     field_names=['project_ids'],
            // ).project_ids
            // for project in self:
            //     project.show_ratings = project in projects_with_rating_active
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id or (lead.team_id and lead.stage_id.team_ids and lead.team_id not in lead.stage_id.team_ids):
            //         lead.stage_id = lead._stage_find(domain=[('fold', '=', False)]).id
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_stage_id(self):
            // for task in self:
            //     project = task.project_id or task.parent_id.project_id
            //     if project:
            //         if project not in task.stage_id.project_ids:
            //             task.stage_id = task.stage_find(project.id, [('fold', '=', False)])
            //     else:
            //         task.stage_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_stage(self):
            // for applicant in self:
            //     if applicant.job_id:
            //         if not applicant.stage_id:
            //             stage_ids = self.env['hr.recruitment.stage'].search([
            //                 '|',
            //                 ('job_ids', '=', False),
            //                 ('job_ids', '=', applicant.job_id.id),
            //                 ('fold', '=', False)
            //             ], order='sequence asc', limit=1).ids
            //             applicant.stage_id = stage_ids[0] if stage_ids else False
            //     else:
            //         applicant.stage_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_state(self):
            // for task in self:
            //     dependent_open_tasks = []
            //     if task.allow_task_dependencies:
            //         dependent_open_tasks = [dependent_task for dependent_task in task.depend_on_ids if
            //                                 dependent_task.state not in CLOSED_STATES]
            //     # if one of the blocking task is in a blocking state
            //     if dependent_open_tasks:
            //         # here we check that the blocked task is not already in a closed state (if the task is already done we don't put it in waiting state)
            //         if task.state not in CLOSED_STATES:
            //             task.state = '04_waiting_normal'
            //     # if the task as no blocking dependencies and is in waiting_normal, the task goes back to in progress
            //     elif task.state not in CLOSED_STATES:
            //         task.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_allocated_hours(self):
            // for task in self:
            //     task.subtask_allocated_hours = sum(task.child_ids.mapped('allocated_hours'))
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_completion_percentage(self):
            // for task in self:
            //     task.subtask_completion_percentage = task.subtask_count and task.closed_subtask_count / task.subtask_count
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_count(self):
            // if not any(self._ids):
            //     for task in self:
            //         task.subtask_count, task.closed_subtask_count = len(task.child_ids), len(task.child_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // total_and_closed_subtask_count_per_parent_id = {
            //     parent.id: (count, sum(s in CLOSED_STATES for s in states))
            //     for parent, states, count in self.env['project.task']._read_group(
            //         [('parent_id', 'in', self.ids)],
            //         ['parent_id'],
            //         ['state:array_agg', '__count'],
            //     )
            // }
            // for task in self:
            //     task.subtask_count, task.closed_subtask_count = total_and_closed_subtask_count_per_parent_id.get(task.id, (0, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentPoolCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_talent_pool_count(self):
            // """
            // This method will find the amount of talent pools the current application is associated with.
            // An application can either be associated directly with a talent pool through talent_pool_ids
            // and/or pool_applicant_id.talent_pool_ids or indirectly by having the same email, phone
            // number or linkedin as a directly linked application.
            // """
            // pool_applicants = self.filtered("is_applicant_in_pool")
            // (self - pool_applicants).talent_pool_count = 0
            // 
            // if not pool_applicants:
            //     return
            // 
            // directly_linked = pool_applicants.filtered("pool_applicant_id")
            // for applicant in directly_linked:
            //     # All talents(applications with talent_pool_ids set) have a pool_applicant_id set to
            //     # themselves which is the reason we only look for that instead of searching for all
            //     # applications with talent_pool_ids and all applications with pool_applicant_id seperately
            //     applicant.talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            // 
            // indirectly_linked = pool_applicants - directly_linked
            // if not indirectly_linked:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirectly_linked if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirectly_linked if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirectly_linked if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // 
            // in_pool_emails = defaultdict(int)
            // in_pool_phones = defaultdict(int)
            // in_pool_linkedins = defaultdict(int)
            // 
            // for applicant in in_pool_applicants:
            //     talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            //     if applicant.email_normalized:
            //         in_pool_emails[applicant.email_normalized] = talent_pool_count
            //     if applicant.partner_phone_sanitized:
            //         in_pool_phones[applicant.partner_phone_sanitized] = talent_pool_count
            //     if applicant.linkedin_profile:
            //         in_pool_linkedins[applicant.linkedin_profile] = talent_pool_count
            // 
            // for applicant in indirectly_linked:
            //     if applicant.email_from and in_pool_emails[applicant.email_normalized]:
            //         applicant.talent_pool_count = in_pool_emails[applicant.email_normalized]
            //     elif applicant.partner_phone_sanitized and in_pool_phones[applicant.partner_phone_sanitized]:
            //         applicant.talent_pool_count = in_pool_phones[applicant.partner_phone_sanitized]
            //     elif applicant.linkedin_profile and in_pool_linkedins[applicant.linkedin_profile]:
            //         applicant.talent_pool_count = in_pool_linkedins[applicant.linkedin_profile]
            //     else:
            //         applicant.talent_pool_count = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_completion_percentage(self):
            // for task in self:
            //     task.task_completion_percentage = task.task_count and 1 - task.open_task_count / task.task_count
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_count(self):
            // self.__compute_task_count()
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for lead in self:
            //     # setting user as void should not trigger a new team computation
            //     if not lead.user_id:
            //         continue
            //     user = lead.user_id
            //     if lead.team_id and user in (lead.team_id.member_ids | lead.team_id.user_id):
            //         continue
            //     team_domain = [('use_leads', '=', True)] if lead.type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     if lead.team_id != team:
            //         lead.team_id = team.id
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_total_update_ids(self):
            // update_count_per_project = dict(
            //     self.env['project.update']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'],
            //         ['id:count'],
            //     )
            // )
            // for project in self:
            //     project.update_count = update_count_per_project.get(project, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_user_company_ids(self):
            // all_companies = self.env['res.company'].search([])
            // for lead in self:
            //     if not lead.company_id:
            //         lead.user_company_ids = all_companies
            //     else:
            //         lead.user_company_ids = lead.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_user(self):
            // for applicant in self:
            //     applicant.user_id = applicant.job_id.user_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_website(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.website or lead.partner_id.website:
            //         lead.website = lead.partner_id.website
            */
            return default;
        }

        public async Task<TEntity> ComputeWonStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_won_status(self):
            // for lead in self:
            //     if lead.probability == 100 and lead.stage_id.is_won:
            //         lead.won_status = 'won'
            //     elif not lead.active and lead.probability == 0:
            //         lead.won_status = 'lost'
            //     else:
            //         lead.won_status = 'pending'
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.won_status == 'won':
            //         continue
            //     vals = lead._convert_opportunity_data(customer, team_id)
            //     lead.write(vals)
            // 
            // if user_ids or team_id:
            //     self._handle_salesmen_assignment(user_ids=user_ids, team_id=team_id)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _convert_opportunity_data(self, customer, team_id=False):
            // """ Extract the data from a lead to create the opportunity
            //     :param customer : res.partner record
            //     :param team_id : identifier of the Sales Team to determine the stage
            // """
            // new_team_id = team_id if team_id else self.team_id.id
            // upd_values = {
            //     'type': 'opportunity',
            //     'date_conversion': self.env.cr.now(),
            // }
            // if customer != self.partner_id:
            //     upd_values['partner_id'] = customer.id if customer else False
            // if not self.stage_id:
            //     stage = self._stage_find(team_id=new_team_id)
            //     upd_values['stage_id'] = stage.id
            // return upd_values
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy(self, default=None):
            // default = dict(default or {})
            // # Since we dont want to copy the milestones if the original project has the feature disabled, we set the milestones to False by default.
            // default['milestone_ids'] = False
            // copy_context = dict(
            //      self.env.context,
            //      mail_auto_subscribe_no_notify=True,
            //      mail_create_nosubscribe=True,
            //  )
            // copy_context.pop("default_stage_id", None)
            // new_projects = super(ProjectProject, self.with_context(copy_context)).copy(default=default)
            // if 'milestone_mapping' not in self.env.context:
            //     self = self.with_context(milestone_mapping={})
            // for old_project, new_project in zip(self, new_projects):
            //     for follower in old_project.message_follower_ids:
            //         new_project.message_subscribe(partner_ids=follower.partner_id.ids, subtype_ids=follower.subtype_ids.ids)
            //     if old_project.allow_milestones:
            //         new_project.milestone_ids = self.milestone_ids.copy().ids
            //     if 'tasks' not in default:
            //         old_project.map_tasks(new_project.id)
            //     if not old_project.active:
            //         new_project.with_context(active_test=False).tasks.active = True
            // # Copy the shared embedded actions and config in the new projects
            // shared_embedded_actions_mapping = self._copy_shared_embedded_actions(new_projects)
            // self._copy_embedded_actions_config(new_projects, shared_embedded_actions_mapping)
            // return new_projects
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy(self, default=None):
            // default = default or {}
            // copied_tasks = super(ProjectTask, self.with_context(
            //     mail_auto_subscribe_no_notify=True,
            //     mail_create_nosubscribe=True,
            //     mail_create_nolog=True,
            // )).copy(default=default)
            // 
            // self._resolve_copied_dependencies(copied_tasks)
            // log_message = _("Task Created")
            // copied_tasks._message_log_batch(bodies={task.id: log_message for task in copied_tasks})
            // 
            // return copied_tasks
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def copy_data(self, default=None):
            // # set default value in context, if not already set (Put stage to 'new' stage)
            // # Set date_open to today if it is an opp
            // default = dict(default or {})
            // if not self.env.user.has_group('crm.group_use_recurring_revenues'):
            //     default['recurring_revenue'] = 0
            //     default['recurring_plan'] = False
            // vals_list = super().copy_data(default=default)
            // now = self.env.cr.now()
            // for lead, vals in zip(self, vals_list):
            //     vals.setdefault('type', lead.type)
            //     vals.setdefault('team_id', lead.team_id.id)
            //     vals['date_open'] = now if lead.type == 'opportunity' and lead.user_id.active else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // 
            // # Avoid adding `(copy)` to partner_name when an applicant is created trough the talent pool mechanism
            // if not self.env.context.get("no_copy_in_partner_name"):
            //     vals_list = [
            //         dict(vals, partner_name=self.env._("%s (copy)", applicant.partner_name))
            //         for applicant, vals in zip(self, vals_list)
            //     ]
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // copy_from_template = self.env.context.get('copy_from_template')
            // for project, vals in zip(self, vals_list):
            //     if project.is_template and not copy_from_template:
            //         vals['is_template'] = True
            //     if copy_from_template:
            //         for field in self._get_template_field_blacklist():
            //             if field in vals and field not in default:
            //                 del vals[field]
            //     if copy_from_template or (not project.is_template and vals.get('is_template')):
            //         vals['name'] = default.get('name', project.name)
            //     else:
            //         vals['name'] = default.get('name', self.env._('%s (copy)', project.name))
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // default.update({
            //     'depend_on_ids': False,
            //     'dependent_ids': False,
            // })
            // vals_list = super().copy_data(default=default)
            // # filter only readable fields
            // vals_list = [
            //     {
            //         k: v
            //         for k, v in vals.items()
            //         if self._has_field_access(self._fields[k], 'read')
            //     }
            //     for vals in vals_list
            // ]
            // 
            // active_users = self.env['res.users']
            // has_default_users = 'user_ids' in default
            // if not has_default_users:
            //     active_users = self.user_ids.filtered('active')
            // milestone_mapping = self.env.context.get('milestone_mapping', {})
            // for task, vals in zip(self, vals_list):
            // 
            //     if not default.get('stage_id'):
            //         vals['stage_id'] = task.stage_id.id
            //     if 'active' not in default and not task['active'] and not self.env.context.get('copy_project'):
            //         vals['active'] = True
            //     if not default.get('name'):
            //         vals['name'] = task.name if self.env.context.get('copy_project') or self.env.context.get('copy_from_template') else _("%s (copy)", task.name)
            //     if task.recurrence_id and not default.get('recurrence_id'):
            //         vals['recurrence_id'] = task.recurrence_id.copy().id
            //     if task.allow_milestones:
            //         vals['milestone_id'] = milestone_mapping.get(vals['milestone_id'], vals['milestone_id'])
            //     if not default.get('child_ids') and task.child_ids:
            //         default = {
            //             'parent_id': False,
            //         }
            //         current_task = task
            //         if self.env.context.get('copy_from_template'):
            //             current_task = current_task.with_context(active_test=True)
            //         child_ids = current_task.child_ids
            //         vals['child_ids'] = [Command.create(child_id.copy_data(default)[0]) for child_id in child_ids]
            //     if not has_default_users and vals['user_ids']:
            //         task_active_users = task.user_ids & active_users
            //         vals['user_ids'] = [Command.set(task_active_users.ids)]
            //     if self.env.context.get('copy_from_template') and not self.env.context.get('copy_from_project_template'):
            //         vals['is_template'] = False
            //     if self.env.context.get('copy_from_template'):
            //         for field in set(self._get_template_field_blacklist()) & set(vals.keys()):
            //             del vals[field]
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CopyEmbeddedActionsConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects, object shared_embedded_actions_mapping) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _copy_embedded_actions_config(self, new_projects, shared_embedded_actions_mapping=None):
            // shared_embedded_actions_mapping = shared_embedded_actions_mapping or {}
            // embedded_action_configs_per_project = dict(
            //     self.env['res.users.settings.embedded.action'].sudo()._read_group(
            //         [('res_id', 'in', self.ids), ('res_model', '=', self._name)],
            //         ['res_id'],
            //         ['id:recordset'],
            //     )
            // )
            // valid_embedded_action_ids = self.env['ir.embedded.actions'].sudo().search(
            //     domain=[
            //         ('parent_res_model', '=', self._name),
            //         ('user_id', '=', False),
            //     ],
            // ).ids + [False]
            // new_embedded_actions_config_vals_list = []
            // for project, new_project in zip(self, new_projects):
            //     configs = embedded_action_configs_per_project.get(project.id, self.env['res.users.settings.embedded.action'])
            //     config_vals_list = configs.copy_data({'res_id': new_project.id})
            //     for config_vals in config_vals_list:
            //         # Apply the mapping of shared embedded actions and filter the visibility and order by excluding the user-specific actions
            //         if config_vals['embedded_actions_visibility']:
            //             embedded_actions_visibility = [
            //                 shared_embedded_actions_mapping.get(action_id, action_id)
            //                 for action_id in [False if x == 'false' else int(x) for x in config_vals['embedded_actions_visibility'].split(',')]
            //                 if action_id in valid_embedded_action_ids
            //             ]
            //             config_vals['embedded_actions_visibility'] = ','.join('false' if action_id is False else str(action_id) for action_id in embedded_actions_visibility)
            //         if config_vals['embedded_actions_order']:
            //             embedded_actions_order = [
            //                 shared_embedded_actions_mapping.get(action_id, action_id)
            //                 for action_id in [False if x == 'false' else int(x) for x in config_vals['embedded_actions_order'].split(',')]
            //                 if action_id in valid_embedded_action_ids
            //             ]
            //             config_vals['embedded_actions_order'] = ','.join('false' if action_id is False else str(action_id) for action_id in embedded_actions_order)
            //         new_embedded_actions_config_vals_list.append(config_vals)
            // # sudo is needed to update the user settings for all users using the projects to duplicate
            // self.env['res.users.settings.embedded.action'].sudo().create(new_embedded_actions_config_vals_list)
            */
            return default;
        }

        public async Task<TEntity> CopySharedEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _copy_shared_embedded_actions(self, new_projects):
            // shared_embedded_actions_per_record = dict(self.env['ir.embedded.actions'].sudo()._read_group(
            //     domain=[
            //         ('parent_res_id', 'in', self.ids),
            //         ('parent_res_model', '=', self._name),
            //         ('user_id', '=', False),
            //     ],
            //     groupby=['parent_res_id'],
            //     aggregates=['id:recordset'],
            // ))
            // shared_embedded_actions_mapping = dict()
            // for project, new_project in zip(self, new_projects):
            //     # Copy the shared embedded actions in the new record
            //     shared_embedded_actions = shared_embedded_actions_per_record.get(project.id)
            //     if shared_embedded_actions:
            //         copy_shared_embedded_actions = shared_embedded_actions.copy({'parent_res_id': new_project.id})
            //         for original_action, copied_action in zip(shared_embedded_actions, copy_shared_embedded_actions):
            //             shared_embedded_actions_mapping[original_action.id] = copied_action.id
            //             copied_action.filter_ids = original_action.filter_ids.copy({'embedded_parent_res_id': new_project.id})
            // return shared_embedded_actions_mapping
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _create_analytic_account(self):
            // analytic_accounts_values = self._get_values_analytic_account_batch(self._read_format(['name', 'company_id', 'partner_id'], None))
            // analytic_accounts = self.env['account.analytic.account'].create(analytic_accounts_values)
            // for project, analytic_account in zip(self, analytic_accounts):
            //     project.account_id = analytic_account
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // leads = super().create(vals_list)
            // 
            // # handling a date_closed value if the lead is directly created in the won stage
            // won_to_set = leads.filtered(lambda l: not l.date_closed and l.stage_id.is_won)
            // won_to_set.write({'date_closed': fields.Datetime.now()})
            // 
            // if self.default_get(['partner_id']).get('partner_id') is None:
            //     commercial_partner_ids = [vals['commercial_partner_id'] for vals in vals_list if vals.get('commercial_partner_id')]
            //     CommercialPartners = self.env['res.partner'].with_prefetch(commercial_partner_ids)
            //     for lead, lead_vals in zip(leads, vals_list, strict=True):
            //         if not lead_vals.get('partner_id') and lead_vals.get('commercial_partner_id'):
            //             commercial_partner = CommercialPartners.browse(lead_vals['commercial_partner_id'])
            //             if (lead.phone or lead.email_from) and (
            //                 lead.phone_sanitized != commercial_partner.phone_sanitized or
            //                 lead.email_normalized != commercial_partner.email_normalized
            //             ):
            //                 lead.partner_name = lead.partner_name or commercial_partner.name
            //                 continue
            //             lead.partner_id = commercial_partner
            // 
            // leads._handle_won_lost({}, {
            //     lead.id: {
            //         'is_lost': lead.won_status == 'lost',
            //         'is_won': lead.won_status == 'won',
            //     } for lead in leads
            // })
            // 
            // return leads
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         vals['date_open'] = fields.Datetime.now()
            //     if vals.get('email_from'):
            //         vals['email_from'] = vals['email_from'].strip()
            // applicants = super().create(vals_list)
            // applicants.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            // for applicant in applicants:
            //     if applicant.talent_pool_ids and not applicant.pool_applicant_id:
            //         applicant.pool_applicant_id = applicant
            // 
            // if (applicants.interviewer_ids.partner_id - self.env.user.partner_id):
            //     for applicant in applicants:
            //         interviewers_to_notify = applicant.interviewer_ids.partner_id - self.env.user.partner_id
            //         notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //         notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //         applicant.message_notify(
            //             res_id=applicant.id,
            //             model=applicant._name,
            //             partner_ids=interviewers_to_notify.ids,
            //             author_id=self.env.user.partner_id.id,
            //             email_from=self.env.user.email_formatted,
            //             subject=notification_subject,
            //             body=notification_body,
            //             email_layout_xmlid="mail.mail_notification_layout",
            //             model_description="Applicant",
            //         )
            // return applicants
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create(self, vals_list):
            // # Prevent double project creation
            // self = self.with_context(mail_create_nosubscribe=True)
            // if any('label_tasks' in vals and not vals['label_tasks'] for vals in vals_list):
            //     task_label = _("Tasks")
            //     for vals in vals_list:
            //         if 'label_tasks' in vals and not vals['label_tasks']:
            //             vals['label_tasks'] = task_label
            // if self.env.user.has_group('project.group_project_stages'):
            //     if 'default_stage_id' in self.env.context:
            //         stage = self.env['project.project.stage'].browse(self.env.context['default_stage_id'])
            //         # The project's company_id must be the same as the stage's company_id
            //         if stage.company_id:
            //             for vals in vals_list:
            //                 if vals.get('stage_id'):
            //                     continue
            //                 vals['company_id'] = stage.company_id.id
            //     else:
            //         companies_ids = [vals.get('company_id', False) for vals in vals_list] + [False]
            //         stages = self.env['project.project.stage'].search([('company_id', 'in', companies_ids)])
            //         for vals in vals_list:
            //             if vals.get('stage_id'):
            //                 continue
            //             # Pick the stage with the lowest sequence with no company or project's company
            //             stage_domain = [False] if 'company_id' not in vals else [False, vals.get('company_id')]
            //             stage = stages.filtered(lambda s: s.company_id.id in stage_domain)[:1]
            //             vals['stage_id'] = stage.id
            // 
            // for vals in vals_list:
            //     if vals.pop('is_favorite', False):
            //         vals['favorite_user_ids'] = [self.env.uid]
            // projects = super().create(vals_list)
            // return projects
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def create(self, vals_list):
            // # Some values are determined by this override and must be written as
            // # sudo for portal users, because they do not have access to these
            // # fields. Other values must not be written as sudo.
            // additional_vals_list = [{} for _ in vals_list]
            // 
            // new_context = dict(self.env.context)
            // default_personal_stage = new_context.pop('default_personal_stage_type_ids', False)
            // default_project_id = new_context.pop('default_project_id', False)
            // if not default_project_id:
            //     parent_task = self.browse({parent_id for vals in vals_list if (parent_id := vals.get('parent_id'))})
            //     if len(parent_task) == 1:
            //         default_project_id = parent_task.sudo().project_id.id
            // # (portal) users that don't have write access can still create a task
            // # in the project that will be checked using record rules
            // new_context["default_create_in_project_id"] = default_project_id
            // if not self._has_field_access(self._fields['user_ids'], 'write'):
            //     # remove user_ids if we have no access to it
            //     new_context.pop('default_user_ids', False)
            // self_ctx = self.with_context(new_context)
            // 
            // self_ctx.browse().check_access('create')
            // default_stage = dict()
            // for vals, additional_vals in zip(vals_list, additional_vals_list):
            //     project_id = vals.get('project_id') or default_project_id
            // 
            //     if vals.get('user_ids'):
            //         additional_vals['date_assign'] = fields.Datetime.now()
            //         if not (vals.get('parent_id') or project_id):
            //             user_ids = self_ctx._fields['user_ids'].convert_to_cache(vals.get('user_ids', []), self_ctx.env['project.task'])
            //             if self_ctx.env.user.id not in list(user_ids) + [SUPERUSER_ID]:
            //                 additional_vals['user_ids'] = [Command.set(list(user_ids) + [self_ctx.env.user.id])]
            //     if default_personal_stage and 'personal_stage_type_id' not in vals:
            //         additional_vals['personal_stage_type_id'] = default_personal_stage[0]
            //     if not vals.get('name') and vals.get('display_name'):
            //         vals['name'] = vals['display_name']
            // 
            //     if self_ctx.env.user._is_portal() and not self_ctx.env.su:
            //         self_ctx._ensure_fields_write(vals, defaults=True)
            // 
            //     if project_id and not "company_id" in vals:
            //         additional_vals["company_id"] = self_ctx.env["project.project"].browse(
            //             project_id
            //         ).company_id.id
            //     if not project_id and ("stage_id" in vals or self_ctx.env.context.get('default_stage_id')):
            //         vals["stage_id"] = False
            // 
            //     if project_id and "stage_id" not in vals:
            //         # 1) Allows keeping the batch creation of tasks
            //         # 2) Ensure the defaults are correct (and computed once by project),
            //         # by using default get (instead of _get_default_stage_id or _stage_find),
            //         if project_id not in default_stage:
            //             default_stage[project_id] = self_ctx.with_context(
            //                 default_project_id=project_id
            //             ).default_get(['stage_id']).get('stage_id')
            //         vals["stage_id"] = default_stage[project_id]
            // 
            //     # Stage change: Update date_end if folded stage and date_last_stage_update
            //     if vals.get('stage_id'):
            //         additional_vals.update(self_ctx.update_date_end(vals['stage_id']))
            //         additional_vals['date_last_stage_update'] = fields.Datetime.now()
            //     # recurrence
            //     rec_fields = vals.keys() & self_ctx._get_recurrence_fields()
            //     if rec_fields and vals.get('recurring_task') is True:
            //         rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //         recurrence = self_ctx.env['project.task.recurrence'].create(rec_values)
            //         vals['recurrence_id'] = recurrence.id
            // 
            // # create the task, write computed inaccessible fields in sudo
            // for vals, computed_vals in zip(vals_list, additional_vals_list):
            //     for field_name in list(computed_vals):
            //         if self_ctx._has_field_access(self_ctx._fields[field_name], 'write'):
            //             vals[field_name] = computed_vals.pop(field_name)
            // # no track when the portal user create a task to avoid using during tracking
            // # process since the portal does not have access to tracking models
            // tasks = super(ProjectTask, self_ctx.with_context(mail_create_nosubscribe=True, mail_notrack=not self_ctx.env.su and self_ctx.env.user._is_portal())).create(vals_list)
            // for task, computed_vals in zip(tasks.sudo(), additional_vals_list):
            //     if computed_vals:
            //         task.write(computed_vals)
            // tasks.sudo()._populate_missing_personal_stages()
            // self_ctx._task_message_auto_subscribe_notify({task: task.user_ids - self_ctx.env.user for task in tasks})
            // 
            // current_partner = self_ctx.env.user.partner_id
            // 
            // all_partner_emails = []
            // for task in tasks.sudo():
            //     all_partner_emails += tools.email_normalize_all(task.email_cc)
            // partners = self_ctx.env['res.partner'].search([('email', 'in', all_partner_emails)])
            // partner_per_email = {
            //     partner.email: partner
            //     for partner in partners
            //     if not all(u.share for u in partner.user_ids)
            // }
            // if tasks.project_id:
            //     tasks.sudo()._set_stage_on_project_from_task()
            // for task in tasks.sudo():
            //     if task.project_id.privacy_visibility in ['invited_users', 'portal']:
            //         task._portal_ensure_token()
            //     for follower in task.parent_id.message_follower_ids:
            //         task.message_subscribe(follower.partner_id.ids, follower.subtype_ids.ids)
            //     if current_partner not in task.message_partner_ids:
            //         task.message_subscribe(current_partner.ids)
            //     if task.email_cc:
            //         partners_with_internal_user = self_ctx.env['res.partner']
            //         for email in tools.email_normalize_all(task.email_cc):
            //             new_partner = partner_per_email.get(email)
            //             if new_partner:
            //                 partners_with_internal_user |= new_partner
            //         if not partners_with_internal_user:
            //             continue
            //         task._send_email_notify_to_cc(partners_with_internal_user)
            //         task.message_subscribe(partners_with_internal_user.ids)
            // return tasks
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_parent) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self, with_parent=None):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :param with_parent: if set, create the new partner with the given parent
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if with_parent:
            //     partner_company = with_parent
            // elif self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = self.env['res.partner']
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id))
            // 
            // if partner_company:
            //     return partner_company
            // return Partner.create(self._prepare_customer_values(self.name, is_company=False))
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create_employee_from_applicant(self):
            // """ Create an employee from applicant """
            // self.ensure_one()
            // self._check_interviewer_access()
            // 
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an applicant name.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('hr.open_view_employee_list')
            // employee = self.env['hr.employee'].with_context(clean_context(self.env.context)).create(self._get_employee_create_vals())
            // action['res_id'] = employee.id
            // employee_attachments = self.env['ir.attachment'].search([('res_model', '=','hr.employee'), ('res_id', '=', employee.id)])
            // unique_attachments = self.attachment_ids.filtered(
            //     lambda attachment: attachment.datas not in employee_attachments.mapped('datas')
            // )
            // unique_attachments.copy({'res_model': 'hr.employee', 'res_id': employee.id})
            // employee.write({
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'department_id': self.department_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from, # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            // })
            // return action
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _create_task_mapping(self, copied_tasks):
            // """
            // Thanks to the way create and command.create is handled, when a task with 2 children is copied, we have the guarantee that the children of the
            // copied task will have the same index in the child_ids recordset. We can use this behavior to create a mapping containing all the original tasks and their copy.
            // :return:
            //     task_mapping: a dict containing the mapping of the original task ids and their copied task (k: original_task.id, v: new_task)
            //     task_dependencies: a dict containing the ids of the dependencies of the original task when they have one.
            //     (k: original_task_id, v: [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            // """
            // task_mapping, task_dependencies = {}, {}
            // for original_task, copied_task in zip(self, copied_tasks):
            //     task_mapping[original_task.id] = copied_task
            //     if original_task.allow_task_dependencies and (original_task.depend_on_ids or original_task.dependent_ids):
            //         task_dependencies[original_task.id] = [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            //     if original_task.child_ids:
            //         # If the task has children, we have to call the method create_task_mapping to get their ids and dependencies mapping too.
            //         children_mapping, children_dependencies = original_task.child_ids._create_task_mapping(copied_task.child_ids)
            //         task_mapping.update(children_mapping)
            //         task_dependencies.update(children_dependencies)
            // return task_mapping, task_dependencies
            */
            return default;
        }

        public async Task<TEntity> CreateTemplateFromProjectUndoCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create_template_from_project_undo_callback(self, callbacks):
            // self.ensure_one()
            // if callbacks.get("unarchive_project"):
            //     self.action_unarchive()
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.team_id:
            //     return _('A new lead has been created for the team "%(team_name)s".', team_name=self.team_id.display_name)
            // return _('A new lead has been created and is not assigned to any team.')
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.project_id:
            //     return _('A new task has been created in the "%(project_name)s" project.',
            //              project_name=self.project_id.display_name)
            // return _('A new task has been created and is not part of any project.')
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('crm.mt_lead_create')
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _creation_subtype(self):
            // self.ensure_one()
            // if self.is_pool_applicant:
            //     return self.env.ref('hr_recruitment.mt_talent_new', raise_if_not_found=False)
            // return self.env.ref('hr_recruitment.mt_applicant_new')
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('project.mt_task_new')
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _cron_update_automated_probabilities(self):
            // """ This cron will :
            //   - rebuild the lead scoring frequency table
            //   - recompute all the automated_probability and align probability if both were aligned
            // """
            // cron_start_date = datetime.now()
            // self._rebuild_pls_frequency_table()
            // self._update_automated_probabilities()
            // _logger.info("Predictive Lead Scoring : Cron duration = %d seconds" % ((datetime.now() - cron_start_date).total_seconds()))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_company_id(self):
            // if self.env.context.get('default_project_id'):
            //     return self.env['project.project'].browse(self.env.context['default_project_id']).company_id
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def default_get(self, fields):
            // vals = super().default_get(fields)
            // 
            // if project_id := self.env.context.get('default_create_in_project_id'):
            //     vals['project_id'] = project_id
            // 
            // # prevent creating new task in the waiting state
            // if 'state' in fields and vals.get('state') == '04_waiting_normal':
            //     vals['state'] = '01_in_progress'
            // 
            // if 'repeat_until' in fields:
            //     vals['repeat_until'] = Date.today() + timedelta(days=7)
            // 
            // if 'partner_id' in vals and not vals['partner_id']:
            //     # if the default_partner_id=False or no default_partner_id then we search the partner based on the project and parent
            //     project_id = vals.get('project_id')
            //     parent_id = vals.get('parent_id', self.env.context.get('default_parent_id'))
            //     if project_id or parent_id:
            //         partner_id = self._get_default_partner_id(
            //             project_id and self.env['project.project'].browse(project_id),
            //             parent_id and self.env['project.task'].browse(parent_id)
            //         )
            //         if partner_id:
            //             vals['partner_id'] = partner_id
            // project_id = vals.get('project_id', self.env.context.get('default_project_id'))
            // if project_id:
            //     project = self.env['project.project'].browse(project_id)
            //     if 'company_id' in fields and 'default_project_id' not in self.env.context:
            //         vals['company_id'] = project.sudo().company_id.id
            // elif 'default_user_ids' not in self.env.context and 'user_ids' in fields:
            //     user_ids = vals.get('user_ids', [])
            //     user_ids.append(Command.link(self.env.user.id))
            //     vals['user_ids'] = user_ids
            // 
            // parent_id = vals.get('parent_id', self.env.context.get('default_parent_id'))
            // if parent_id:
            //     parent = self.env['project.task'].browse(parent_id)
            //     if not vals.get('tag_ids'):
            //         vals['tag_ids'] = parent.tag_ids
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _default_stage_id(self):
            // # Since project stages are order by sequence first, this should fetch the one with the lowest sequence number.
            // return self.env['project.project.stage'].search([], limit=1)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_user_ids(self):
            // return self.env.user.ids if any(key in self.env.context for key in ('default_personal_stage_type_ids', 'default_personal_stage_type_id')) else ()
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_company_consistency_with_partner(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if task.partner_id and task.partner_id.company_id and task.company_id and task.company_id != task.partner_id.company_id:
            //         raise ValidationError(_('The task and the associated partner must be linked to the same company.'))
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_fields_write(self, vals, defaults=False):
            // if defaults:
            //     vals = {
            //         **{
            //             key[8:]: value
            //             for key, value in self.env.context.items()
            //             if key.startswith("default_") and key[8:] in self._fields
            //         },
            //         **vals
            //     }
            // 
            // for fname, value in vals.items():
            //     field = self._fields.get(fname)
            //     if field and field.type == 'many2one':
            //         self.env[field.comodel_name].browse(value).check_access('read')
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _ensure_stage_has_same_company(self):
            // for project in self:
            //     if project.stage_id.company_id and project.stage_id.company_id != project.company_id:
            //         raise UserError(
            //             _('This project is associated with %(project_company)s, whereas the selected stage belongs to %(stage_company)s. '
            //             'There are a couple of options to consider: either remove the company designation '
            //             'from the project or from the stage. Alternatively, you can update the company '
            //             'information for these records to align them under the same company.', project_company=project.company_id.name, stage_company=project.stage_id.company_id.name)
            //             if project.company_id else
            //             _('This project is not associated with any company, while the stage is associated with %s. '
            //             'There are a couple of options to consider: either change the project\'s company '
            //             'to align with the stage\'s company or remove the company designation from the stage', project.stage_id.company_id.name)
            //         )
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_super_task_is_not_private(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if not task.project_id and task.subtask_count:
            //         raise ValidationError(_('This task has sub-tasks, so it can\'t be private.'))
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_priority(self):
            // priority_group = self._get_group_pattern()['priority']
            // match = re.search(priority_group, self.display_name)
            // if match:
            //     self.priority = str(min(len(match.group(1)), 3))
            //     self.display_name, _dummy = re.subn(priority_group, '', self.display_name)
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_tags_and_users(self):
            // tags = []
            // users = []
            // tags_and_users_group = self._get_group_pattern()['tags_and_users']
            // for word in re.findall(tags_and_users_group % '', self.display_name):
            //     (tags if word.startswith('#') else users).append(word[1:])
            // users_to_keep = []
            // user_ids = []
            // for user in users:
            //     matched_users = self.env['res.users'].name_search(user)
            //     if len(matched_users) == 1:
            //         user_ids.append(Command.link(matched_users[0][0]))
            //     else:
            //         users_to_keep.append(r'%s\b' % user)
            // self.user_ids = user_ids
            // if tags:
            //     domain = Domain.OR(Domain('name', '=ilike', tag) for tag in tags)
            //     existing_tags = self.env['project.tags'].search(domain)
            //     existing_tags_names = {tag.name.lower() for tag in existing_tags}
            //     new_tags_names = {tag for tag in tags if tag.lower() not in existing_tags_names}
            //     self.tag_ids = [Command.set(existing_tags.ids)] + [Command.create({'name': name}) for name in new_tags_names]
            // pattern = tags_and_users_group % ('(?!%s)' % ('|').join(users_to_keep) if users_to_keep else '')
            // self.display_name, _ = re.subn(pattern, '', self.display_name)
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_expr, object query) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _field_to_sql(self, alias, field_expr, query=None) -> SQL:
            // if field_expr == 'company_currency':
            //     alias_company = query.make_alias(self._table, 'company_id')
            //     company_field_sql = self._field_to_sql(self._table, 'company_id', query)
            //     query.add_join('LEFT JOIN', alias_company, 'res_company', SQL(
            //         "%s = %s", company_field_sql, SQL.identifier(alias_company, 'id'),
            //     ))
            //     company_currency_expr = self.env['res.company']._field_to_sql(alias_company, 'currency_id', query)
            //     return SQL(
            //         '(CASE WHEN %s IS NOT NULL THEN %s ELSE %s END)',
            //         company_field_sql, company_currency_expr, self.env.company.currency_id.id
            //     )
            // return super()._field_to_sql(alias, field_expr, query)
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _find_internal_users_from_address_mail(self, emails, project_id=False):
            // sanitized_email_dict = self._mail_cc_sanitized_raw_dict(emails)
            // matched_partners = self.env['res.partner']._find_or_create_from_emails(
            //     sanitized_email_dict.keys(),
            //     no_create=True
            // )
            // partners = self.env['res.partner'].concat(*matched_partners)
            // unresolved_emails = set(sanitized_email_dict) - set(partners.mapped("email"))
            // if project_id:
            //     project = self.env["project.project"].browse(project_id)
            //     project_alias_address = project.alias_name + "@" + project.alias_domain_id.name
            //     # Removing project alias from unresolved_emails as this will be added to cc_mail address and when
            //     # a mail is sent unnecessary partner is created in the name of project_alias
            //     unresolved_emails.discard(project_alias_address)
            // unmatched_partner_emails = [sanitized_email_dict.get(email) for email in unresolved_emails]
            // 
            // users = partners.user_ids
            // internal_user_ids = users.filtered(lambda u: not u.share).ids
            // 
            // partner_emails_without_internal_users = (partners - users.partner_id).mapped("email_formatted")
            // 
            // return internal_user_ids, partner_emails_without_internal_users, unmatched_partner_emails
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self):
            // """ Try to find a matching partner with available information on the
            // lead, using currently customer's email
            // 
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // if not partner and (self.email_normalized or self.email_from):
            //     partner = self._partner_find_from_emails_single(
            //         [self.email_normalized or self.email_from],
            //         no_create=True,
            //     )
            // return partner
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _format_properties(self):
            // """Format the properties to build the merge message.
            // 
            // Return a list of dict containing the label, and a value key if there's only
            // one value, or a "values" key if we have multiple values (e.g. many2many, tags).
            // 
            // E.G.
            //     [{
            //         'label': 'My Partner',
            //         'value': 'Alice',
            //     }, {
            //         'label': 'My Partners',
            //         'values': [
            //             {'name': 'Alice'},
            //             {'name': 'Bob'},
            //         ],
            //     }, {
            //         'label': 'My Tags',
            //         'values': [
            //             {'name': 'A', 'color': 1},
            //             {'name': 'C', 'color': 3},
            //         ],
            //     }]
            // """
            // self.ensure_one()
            // # read to have the display names already in the value
            // properties = self.read(['lead_properties'])[0]['lead_properties']
            // 
            // formatted = []
            // for definition in properties:
            //     label = definition.get('string')
            //     value = definition.get('value')
            //     property_type = definition['type']
            //     if not value and property_type != 'boolean':
            //         continue
            // 
            //     property_dict = {'label': label}
            //     if property_type == 'boolean':
            //         property_dict['value'] = _('Yes') if value else _('No')
            //     elif value and property_type == 'many2one':
            //         property_dict['value'] = value[1]
            //     elif value and property_type == 'many2many':
            //         # show many2many in badge
            //         property_dict['values'] = [{'name': rec[1]} for rec in value]
            //     elif value and property_type in ['selection', 'tags']:
            //         # retrieve the option label from the value
            //         options = {
            //             option[0]: option[1:]
            //             for option in (definition.get(property_type) or [])
            //         }
            //         if property_type == 'selection':
            //             value = options.get(value)
            //             property_dict['value'] = value[0] if value else None
            //         else:
            //             property_dict['values'] = [{
            //                 'name': options[tag][0],
            //                 'color': options[tag][1],
            //                 } for tag in value if tag in options
            //             ]
            //     else:
            //         property_dict['value'] = value
            // 
            //     formatted.append(property_dict)
            // 
            // return formatted
            */
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_account_node_context(self, plan):
            // return {
            //     **super()._get_account_node_context(plan),
            //     'default_company_id': unquote('company_id'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_all_subtasks(self):
            // return self.browse(set.union(set(), *self._get_subtask_ids_per_task_id().values()))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_allowed_access_params(self):
            // return super()._get_allowed_access_params() | {'project_sharing_id'}
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // # To be extended to avoid account.move.line overlap between
            // # profitability reports.
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_attachment_number(self):
            // read_group_res = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids)],
            //     ['res_id'], ['__count'])
            // attach_data = dict(read_group_res)
            // for record in self:
            //     record.attachment_number = attach_data.get(record.id, 0)
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_attachments_search_domain(self):
            // self.ensure_one()
            // return [('res_id', '=', self.id), ('res_model', '=', 'project.task')]
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_cannot_start_with_patterns(self):
            // return [r'(?![#!@\s])']
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_customer_information(self):
            // email_keys_to_values = super()._get_customer_information()
            // 
            // for lead in self:
            //     email_key = lead.email_normalized or lead.email_from
            //     # do not fill Falsy with random data, unless monorecord (= always correct)
            //     if not email_key and len(self) > 1:
            //         continue
            //     values = email_keys_to_values.setdefault(email_key, {})
            //     contact_name = lead.contact_name or parse_contact_from_email(lead.email_from)[0] or lead.email_from
            //     is_company = bool(lead.partner_name) and contact_name == lead.partner_name
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update({
            //         key: val for key, val in lead._prepare_customer_values(
            //             contact_name, is_company=is_company, parent_id=False
            //         ).items() if val and key != 'email'  # don't force email used as criterion
            //     })
            //     values['is_company'] = is_company
            //     if not is_company and lead.commercial_partner_id:
            //         values['parent_id'] = lead.commercial_partner_id.id
            //         values.pop('company_name', None)
            // return email_keys_to_values
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_customer_information(self):
            // email_keys_to_values = super()._get_customer_information()
            // 
            // for applicant in self:
            //     email_key = tools.email_normalize(applicant.email_from) or applicant.email_from
            //     # do not fill Falsy with random data, unless monorecord (= always correct)
            //     if not email_key and len(self) > 1:
            //         continue
            //     email_keys_to_values.setdefault(email_key, {}).update({
            //         'name': applicant.partner_name or tools.parse_contact_from_email(applicant.email_from)[0] or applicant.email_from,
            //         'phone': applicant.partner_phone,
            //     })
            // return email_keys_to_values
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_partner_id(self, project=None, parent=None):
            // if parent and parent.partner_id:
            //     return parent.partner_id.id
            // if project and project.partner_id:
            //     return project.partner_id.id
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_personal_stage_create_vals(self, user_id):
            // return [
            //     {'sequence': 1, 'name': _('Inbox'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 2, 'name': _('Today'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 3, 'name': _('This Week'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 4, 'name': _('This Month'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 5, 'name': _('Later'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 6, 'name': _('Done'), 'user_id': user_id, 'fold': True},
            //     {'sequence': 7, 'name': _('Cancelled'), 'user_id': user_id, 'fold': True},
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_stage_id(self):
            // """ Gives default stage_id """
            // project_id = self.env.context.get('default_project_id')
            // if not project_id:
            //     return False
            // return self.stage_find(project_id, order="fold, sequence, id")
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_duration_from_tracking(self, trackings):
            // json = super()._get_duration_from_tracking(trackings)
            // now = datetime.now()
            // for applicant in self:
            //     if applicant.refuse_reason_id and applicant.refuse_date:
            //         json[applicant.stage_id.id] -= (now - applicant.refuse_date).total_seconds()
            // return json
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _get_duration_from_tracking(self, trackings):
            // """
            // Calculates the duration spent in each value based on the provided list of trackings.
            // It adds a "fake" tracking at the end of the trackings list to account for the time spent in the current value.
            // 
            // Args:
            //     trackings (list): A list of dictionaries representing the trackings with:
            //         - 'create_date': The date and time of the tracking.
            //         - 'old_value_integer': The ID of the previous value.
            // 
            // Returns:
            //     dict: A dictionary where the keys are the IDs of the values, and the values are the durations in seconds
            // """
            // self.ensure_one()
            // json = defaultdict(lambda: 0)
            // previous_date = self.create_date or self.env.cr.now()
            // 
            // # If there is a tracking value to be created, but still in the
            // # precommit values, create a fake one to take it into account.
            // # Otherwise, the duration_tracking value will add time spent on
            // # previous tracked field value to the time spent in the new value
            // # (after writing the stage on the record)
            // if f'mail.tracking.{self._name}' in self.env.cr.precommit.data:
            //     if data := self.env.cr.precommit.data.get(f'mail.tracking.{self._name}', {}).get(self._origin.id):
            //         new_id = data.get(self._track_duration_field, self.env[self._name]).id
            //         if new_id and new_id != self[self._track_duration_field].id:
            //             trackings.append({
            //                 'create_date': self.env.cr.now(),
            //                 'old_value_integer': data[self._track_duration_field].id,
            //             })
            // 
            // # add "fake" tracking for time spent in the current value
            // trackings.append({
            //     'create_date': self.env.cr.now(),
            //     'old_value_integer': self[self._track_duration_field].id,
            // })
            // 
            // for tracking in trackings:
            //     json[tracking['old_value_integer']] += int((tracking['create_date'] - previous_date).total_seconds())
            //     previous_date = tracking['create_date']
            // 
            // return json
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_employee_create_vals(self):
            // self.ensure_one()
            // address_id = self.partner_id.address_get(['contact'])['contact']
            // address_sudo = self.env['res.partner'].sudo().browse(address_id)
            // return {
            //     'name': self.partner_name or self.partner_id.display_name,
            //     'work_contact_id': self.partner_id.id,
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'private_street': address_sudo.street,
            //     'private_street2': address_sudo.street2,
            //     'private_city': address_sudo.city,
            //     'private_state_id': address_sudo.state_id.id,
            //     'private_zip': address_sudo.zip,
            //     'private_country_id': address_sudo.country_id.id,
            //     'private_phone': address_sudo.phone,
            //     'private_email': address_sudo.email,
            //     'lang': address_sudo.lang,
            //     'department_id': self.department_id.id,
            //     'address_id': self.company_id.partner_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from,  # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            //     'applicant_ids': self.ids,
            //     'phone': self.partner_phone
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_empty_list_help(self, help_message):
            // """ This method returns the action helpers for the leads. If help is already provided
            //     on the action, the same is returned. Otherwise, we build the help message which
            //     contains the alias responsible for creating the lead (if available) and return it.
            // """
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title, sub_title = "", ""
            // if self.env.context.get('default_type') == 'lead':
            //     help_title = _('Create a new lead')
            // else:
            //     help_title = _('Create an opportunity to start playing with your pipeline.')
            // alias_domain = [
            //     ('company_id', 'in', [self.env.company.id, False]),
            //     ('alias_id.alias_name', '!=', False),
            //     ('alias_id.alias_name', '!=', ''),
            //     ('alias_id.alias_model_id.model', '=', 'crm.lead'),
            // ]
            // # sort by use_leads, then by our membership of the team
            // alias_records = self.env['crm.team'].search(alias_domain).sorted(
            //     lambda r: (r.use_leads, self.env.user in r.member_ids), reverse=True
            // )
            // alias_record = alias_records[0] if alias_records else None
            // if alias_record and alias_record.alias_domain and alias_record.alias_name:
            //     sub_title = Markup(_('Use the <i>New</i> button, or send an email to %(email_link)s to test the email gateway.')) % {
            //         'email_link': Markup("<b><a href='mailto:%s'>%s</a></b>") % (alias_record.alias_email, alias_record.alias_email),
            //     }
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_empty_list_help(self, help_message):
            //         if 'active_id' in self.env.context and self.env.context.get('active_model') == 'hr.job':
            //             hr_job = self.env['hr.job'].browse(self.env.context['active_id'])
            //         elif self.env.context.get('default_job_id'):
            //             hr_job = self.env['hr.job'].browse(self.env.context['default_job_id'])
            //         else:
            //             hr_job = self.env['hr.job']
            // 
            //         nocontent_body = Markup("""
            // <p class="o_view_nocontent_smiling_face">%(help_title)s</p>
            // """) % {
            //             'help_title': _("No applications found."),
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Send applications to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_empty_list_help(self, help_message):
            // tname = _("task")
            // project_id = self.env.context.get('default_project_id', False)
            // if project_id:
            //     name = self.env['project.project'].browse(project_id).label_tasks
            //     if name: tname = name.lower()
            // 
            // self = self.with_context(
            //     empty_list_help_id=self.env.context.get('default_project_id'),
            //     empty_list_help_model='project.project',
            //     empty_list_help_document_name=tname,
            // )
            // return super().get_empty_list_help(help_message)
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_group_pattern(self):
            // return {
            //     'tags_and_users': r'\s([#@]%s[^\s]+)',
            //     'priority': r'(?:^|\s)(!{1,3})(?=\s|$)',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups(self):
            // return [
            //     lambda task: task._extract_tags_and_users(),
            //     lambda task: task._extract_priority(),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups_patterns(self):
            // return [
            //     r'(?:%s)*' % ('|').join(self._prepare_pattern_groups()),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Tasks'),
            //     'template': '/project/static/xls/tasks_import_template.xlsx',
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_items_from_aal(self, with_action=True):
            // return {
            //     'revenues': {'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}},
            //     'costs': {'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_last_update_or_default(self):
            // self.ensure_one()
            // labels = dict(self._fields['last_update_status']._description_selection(self.env))
            // return {
            //     'status': labels.get(self.last_update_status, _('Set Status')),
            //     'color': self.last_update_color,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_lead_duplicates(self, partner=None, email=None, include_lost=False):
            // """ Search for leads that seem duplicated based on partner / email.
            // 
            // :param partner : optional customer when searching duplicated
            // :param email: email (possibly formatted) to search
            // :param boolean include_lost: if True, search includes archived opportunities
            //   (still only active leads are considered). If False, search for active
            //   and not won leads and opportunities;
            // """
            // if not email and not partner:
            //     return self.env['crm.lead']
            // 
            // domain = []
            // normalized_emails = email_normalize_all(email)
            // if normalized_emails:
            //     domain.append(('email_normalized', 'in', normalized_emails))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     # include lost means archived opportunities are allowed, if lost
            //     domain += [('won_status', '!=', 'won'), '|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     # always filter out archived, those are not actionable anymore
            //     domain += [('won_status', '=', 'pending'), ('active', '=', True)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """Return the 'limit'-first followers of the given task or followers of its project matching
            // a 'search' string as a list of partner data (returned by `_to_store()`).
            // See similar method for all partners `get_mention_suggestions()`.
            // """
            // self.ensure_one()
            // project = self.project_id
            // if not (
            //     project
            //     and project._check_project_sharing_access()
            //     and project._get_thread_with_access(project.id)
            // ):
            //     return {}
            // # sudo: mail.followers - reading message_follower_ids on accessible task/project is allowed
            // followers = project.sudo().message_follower_ids | self.sudo().message_follower_ids
            // domain = (
            //     Domain(self.env["res.partner"]._get_mention_suggestions_domain(search))
            //     & Domain("id", "in", followers.partner_id.ids)
            // )
            // partners = self.env["res.partner"].sudo()._search_mention_suggestions(domain, limit)
            // return (
            //     Store()
            //     .add(partners, ["email", "im_status", "name", *partners._get_store_mention_fields()])
            //     .get_result()
            // )
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_milestones(self):
            // if self.env.user.has_group('project.group_project_user'):
            //     return self._get_milestones()
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_milestones(self):
            // self.ensure_one()
            // return {
            //     'data': self.milestone_ids._get_data_list(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_new_collaborators(self, partners):
            // self.ensure_one()
            // return partners.filtered(
            //     lambda partner:
            //         partner not in self.collaborator_ids.partner_id
            //         and partner.partner_share
            // )
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_opportunity_meeting_view_parameters(self):
            // """ Return the most relevant parameters for calendar view when viewing meetings linked to an opportunity.
            //     If there are any meetings that are not finished yet, only consider those meetings,
            //     since the user would prefer no to see past meetings. Otherwise, consider all meetings.
            //     Allday events datetimes are used without taking tz into account.
            //     -If there is no event, return week mode and false (The calendar will target 'now' by default)
            //     -If there is only one, return week mode and date of the start of the event.
            //     -If there are several events entirely on the same week, return week mode and start of first event.
            //     -Else, return month mode and the date of the start of first event as initial date. (If they are
            //     on the same month, this will display that month and therefore show all of them, which is expected)
            // 
            //     :return tuple(mode, initial_date)
            //         - mode: selected mode of the calendar view, 'week' or 'month'
            //         - initial_date: date of the start of the first relevant meeting. The calendar will target that date.
            // """
            // self.ensure_one()
            // meeting_results = self.env["calendar.event"].search_read([('opportunity_id', '=', self.id)], ['start', 'stop', 'allday'])
            // if not meeting_results:
            //     return "week", False
            // 
            // user_pytz = self.env.tz
            // 
            // # meeting_dts will contain one tuple of datetimes per meeting : (Start, Stop)
            // # meetings_dts and now_dt are as per user time zone.
            // meeting_dts = []
            // now_dt = datetime.now().astimezone(user_pytz).replace(tzinfo=None)
            // 
            // # When creating an allday meeting, whatever the TZ, it will be stored the same e.g. 00.00.00->23.59.59 in utc or
            // # 08.00.00->18.00.00. Therefore we must not put it back in the user tz but take it raw.
            // for meeting in meeting_results:
            //     if meeting.get('allday'):
            //         meeting_dts.append((meeting.get('start'), meeting.get('stop')))
            //     else:
            //         meeting_dts.append((meeting.get('start').astimezone(user_pytz).replace(tzinfo=None),
            //                            meeting.get('stop').astimezone(user_pytz).replace(tzinfo=None)))
            // 
            // # If there are meetings that are still ongoing or to come, only take those.
            // unfinished_meeting_dts = [meeting_dt for meeting_dt in meeting_dts if meeting_dt[1] >= now_dt]
            // relevant_meeting_dts = unfinished_meeting_dts if unfinished_meeting_dts else meeting_dts
            // relevant_meeting_count = len(relevant_meeting_dts)
            // 
            // if relevant_meeting_count == 1:
            //     return "week", relevant_meeting_dts[0][0].date()
            // else:
            //     # Range of meetings
            //     earliest_start_dt = min(relevant_meeting_dt[0] for relevant_meeting_dt in relevant_meeting_dts)
            //     latest_stop_dt = max(relevant_meeting_dt[1] for relevant_meeting_dt in relevant_meeting_dts)
            // 
            //     # The week start day depends on language. We fetch the week_start of user's language. 1 is monday.
            //     lang_week_start = self.env["res.lang"].search_read([('code', '=', self.env.user.lang)], ['week_start'])
            //     # We substract one to make week_start_index range 0-6 instead of 1-7
            //     week_start_index = int(lang_week_start[0].get('week_start', '1')) - 1
            // 
            //     # We compute the weekday of earliest_start_dt according to week_start_index. earliest_start_dt_index will be 0 if we are on the
            //     # first day of the week and 6 on the last. weekday() returns 0 for monday and 6 for sunday. For instance, Tuesday in UK is the
            //     # third day of the week, so earliest_start_dt_index is 2, and remaining_days_in_week includes tuesday, so it will be 5.
            //     # The first term 7 is there to avoid negative left side on the modulo, improving readability.
            //     earliest_start_dt_weekday = (7 + earliest_start_dt.weekday() - week_start_index) % 7
            //     remaining_days_in_week = 7 - earliest_start_dt_weekday
            // 
            //     # We compute the start of the week following the one containing the start of the first meeting.
            //     next_week_start_date = earliest_start_dt.date() + timedelta(days=remaining_days_in_week)
            // 
            //     # Latest_stop_dt must be before the start of following week. Limit is therefore set at midnight of first day, included.
            //     meetings_in_same_week = latest_stop_dt <= datetime(next_week_start_date.year, next_week_start_date.month, next_week_start_date.day, 0, 0, 0)
            // 
            //     if meetings_in_same_week:
            //         return "week", earliest_start_dt.date()
            //     else:
            //         return "month", earliest_start_dt.date()
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_panel_data(self):
            // self.ensure_one()
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // show_profitability = self._show_profitability()
            // panel_data = {
            //     'user': self._get_user_values(),
            //     'buttons': sorted(self._get_stat_buttons(), key=lambda k: k['sequence']),
            //     'currency_id': self.currency_id.id,
            //     'show_project_profitability_helper': show_profitability and self._show_profitability_helper(),
            //     'show_milestones': self.allow_milestones,
            // }
            // if self.allow_milestones:
            //     panel_data['milestones'] = self._get_milestones()
            // if show_profitability:
            //     profitability_items = self.with_context(active_test=False)._get_profitability_items()
            //     if self._get_profitability_sequence_per_invoice_type() and profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //         profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //         profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            //     panel_data['profitability_items'] = profitability_items
            //     panel_data['profitability_labels'] = self._get_profitability_labels()
            // return panel_data
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_email_update(self, force_void=True):
            // """Calculate if we should write the email on the related partner. When
            // the email of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of email update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void email value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.email_from) and self.email_from != self.partner_id.email:
            //     lead_email_normalized = tools.email_normalize(self.email_from) or self.email_from or False
            //     partner_email_normalized = tools.email_normalize(self.partner_id.email) or self.partner_id.email or False
            //     return lead_email_normalized != partner_email_normalized
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_phone_update(self, force_void=True):
            // """Calculate if we should write the phone on the related partner. When
            // the phone of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of phone update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void phone value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.phone) and self.phone != self.partner_id.phone:
            //     lead_phone_formatted = self._phone_format(fname='phone') or self.phone or False
            //     partner_phone_formatted = self.partner_id._phone_format(fname='phone') or self.partner_id.phone or False
            //     return lead_phone_formatted != partner_phone_formatted
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_plan_domain(self, plan):
            // return Domain.AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return [('account_id', 'in', self.account_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_items_from_aal(with_action)
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_values(self):
            // if not self.env.user.has_group('project.group_project_manager'):
            //     return {}, False
            // profitability_items = self._get_profitability_items(False)
            // if profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //     profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //     profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            // costs = sum(profitability_items['costs']['total'].values())
            // revenues = sum(profitability_items['revenues']['total'].values())
            // margin = revenues + costs
            // to_bill_to_invoice = profitability_items['costs']['total']['to_bill'] + profitability_items['revenues']['total']['to_invoice']
            // billed_invoiced = profitability_items['costs']['total']['billed'] + profitability_items['revenues']['total']['invoiced']
            // expected_percentage, to_bill_to_invoice_percentage, billed_invoiced_percentage = 0, 0, 0
            // if revenues:
            //     expected_percentage = formatLang(self.env, (margin / revenues) * 100, digits=0)
            // if profitability_items['revenues']['total']['to_invoice']:
            //     to_bill_to_invoice_percentage = formatLang(self.env, (to_bill_to_invoice / profitability_items['revenues']['total']['to_invoice']) * 100, digits=0)
            // if profitability_items['revenues']['total']['invoiced']:
            //     billed_invoiced_percentage = formatLang(self.env, (billed_invoiced / profitability_items['revenues']['total']['invoiced']) * 100, digits=0)
            // profitability_values_dict = {
            //     'account_id': self.account_id,
            //     'costs': profitability_items['costs'],
            //     'revenues': profitability_items['revenues'],
            //     'expected_percentage': expected_percentage,
            //     'to_bill_to_invoice_percentage': to_bill_to_invoice_percentage,
            //     'billed_invoiced_percentage': billed_invoiced_percentage,
            //     'total': {
            //         'costs': costs,
            //         'revenues': revenues,
            //         'margin': margin,
            //         'margin_percentage': formatLang(self.env,
            //                                         not float_utils.float_is_zero(costs, precision_digits=2) and (margin / -costs) * 100 or 0.0,
            //                                         digits=0),
            //     },
            //     'labels': self._get_profitability_labels(),
            // }
            // show_profitability = bool(profitability_values_dict.get('account_id')
            //     and (profitability_values_dict.get('costs') or profitability_values_dict.get('revenues'))
            // )
            // return profitability_values_dict, show_profitability
            */
            return default;
        }

        public async Task<TEntity> GetProjectFeaturesMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_project_features_mapping(self):
            // return {
            //     'allow_task_dependencies': 'project.group_project_task_dependencies',
            //     'allow_milestones': 'project.group_project_milestone',
            //     'allow_recurring_tasks': 'project.group_project_recurring_tasks',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return Domain('partner_id', '!=', False) & Domain(additional_domain or Domain.TRUE)
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_rainbowman_message(self):
            // self.ensure_one()
            // if self.stage_id.is_won:
            //     return self._get_rainbowman_message()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rainbowman_message(self):
            // self.ensure_one()
            // if not self.user_id:
            //     return False
            // self.flush_model()  # flush fields to make sure DB is up to date
            // 
            // # checked here as it is its position in the priority order
            // if len(self.message_ids) >= 25:
            //     return _('Phew, that took some effort — but you nailed it. Good job!')
            // 
            // team_condition = f'team_id = {self.team_id.id}' if self.team_id else 'team_id IS NULL'
            // source_case = f'source_id = {self.source_id.id} AND {team_condition}' if self.source_id else 'false'
            // country_case = f'country_id = {self.country_id.id} AND {team_condition}' if self.country_id else 'false'
            // tz_midnight = fields.Datetime.now().astimezone(pytz.timezone(self.env.user.tz or self.user_id.tz or 'UTC')).replace(hour=0, minute=0, second=0)
            // tz_midnight_in_utc = tz_midnight.astimezone(pytz.UTC).replace(tzinfo=None)
            // query = f"""
            // SELECT
            //     MAX(CASE WHEN team_id = %(team_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '31 days' AND id <> %(lead_id)s THEN expected_revenue ELSE 0 END) AS max_team_31,
            //     MAX(CASE WHEN team_id = %(team_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '7 days'  AND id <> %(lead_id)s THEN expected_revenue ELSE 0 END) AS max_team_7,
            //     MAX(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '31 days' AND id <> %(lead_id)s THEN expected_revenue ELSE 0 END) AS max_user_31,
            //     MAX(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '7 days'  AND id <> %(lead_id)s THEN expected_revenue ELSE 0 END) AS max_user_7,
            //     MIN(CASE WHEN COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '31 days' THEN day_close ELSE 31 END) AS min_day_close_31,
            //     COUNT(CASE WHEN user_id = %(user_id)s THEN 1 ELSE NULL END) AS count_user_closed_year,
            //     COUNT(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '3 days' AND COALESCE(date_closed, create_date) < %(tz_midnight)s - INTERVAL '2 days' THEN 1 ELSE NULL END) AS count_user_closed_minus3day,
            //     COUNT(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '2 days' AND COALESCE(date_closed, create_date) < %(tz_midnight)s - INTERVAL '1 days' THEN 1 ELSE NULL END) AS count_user_closed_minus2day,
            //     COUNT(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s - INTERVAL '1 days' AND COALESCE(date_closed, create_date) < %(tz_midnight)s THEN 1 ELSE NULL END) AS count_user_closed_yesterday,
            //     COUNT(CASE WHEN user_id = %(user_id)s AND COALESCE(date_closed, create_date) >= %(tz_midnight)s THEN 1 ELSE NULL END) AS count_user_closed_today,
            //     COUNT(CASE WHEN {source_case} THEN 1 ELSE NULL END) AS count_source_closed_year,
            //     COUNT(CASE WHEN {country_case} THEN 1 ELSE NULL END) AS count_country_closed_year
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', COALESCE(date_closed, create_date)) = DATE_TRUNC('year', %(tz_midnight)s)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {
            //     'user_id': self.env.user.id,
            //     'team_id': self.team_id.id or -1,
            //     'lead_id': self.id,
            //     'tz_midnight': tz_midnight_in_utc,
            // })
            // query_result = self.env.cr.dictfetchone()
            // 
            // if query_result['count_user_closed_year'] == 1:
            //     return _('Go, go, go! Congrats for your first deal.')
            // elif self.expected_revenue and query_result['max_team_31'] < self.expected_revenue:
            //     return _('Boom! Team record for the past 30 days.')
            // elif self.expected_revenue and query_result['max_team_7'] < self.expected_revenue:
            //     return _('Yeah! Best deal out of the last 7 days for the team.')
            // elif self.expected_revenue and query_result['max_user_31'] < self.expected_revenue:
            //     return _('You just beat your personal record for the past 30 days.')
            // elif self.expected_revenue and query_result['max_user_7'] < self.expected_revenue:
            //     return _('You just beat your personal record for the past 7 days.')
            // elif query_result['count_user_closed_today'] == 5:
            //     return _('You\'re on fire! Fifth deal won today 🔥')
            // elif query_result['count_user_closed_today'] == 1 and query_result['count_user_closed_yesterday'] and query_result['count_user_closed_minus2day'] and not query_result['count_user_closed_minus3day']:
            //     return _('You\'re on a winning streak. 3 deals in 3 days, congrats!')
            // # check that at least one minute has elapsed since record creation to only account for 'real' leads
            // elif query_result['min_day_close_31'] == self.day_close and self.day_close < 31 \
            //     and self.date_closed and (self.date_closed - self.create_date).total_seconds() > 60:
            //     return _('Wow, that was fast. That deal didn’t stand a chance!')
            // # use duration tracking field to determine if the task jumped from first to last stage
            // # only takes into accounts stages on which the lead has spent at least a minute,
            // # to only account for valid stage movements
            // elif len(stage_ids := [int(stage_id) for stage_id, duration in self.duration_tracking.items() if duration >= 60]) == 1:
            //     first_stage = self.env['crm.stage'].search([
            //         '|', ('team_ids', 'in', False), ('team_ids', 'in', self.team_id.id),
            //     ], order='sequence ASC', limit=1)
            //     if first_stage.id == stage_ids[0]:
            //         return _('No detours, no delays - from %(stage_name)s straight to the win! 🚀', stage_name=first_stage.name)
            // if query_result['count_country_closed_year'] == 1 and self.country_id:
            //     return _('You just expanded the map! First win in %(country)s.', country=self.country_id.name)
            // elif query_result['count_source_closed_year'] == 1 and self.source_id:
            //     return _('Yay, your first win from %(utm_source_name)s!', utm_source_name=self.source_id.name)
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_recurrence_fields(self):
            // return [
            //     'repeat_interval',
            //     'repeat_unit',
            //     'repeat_type',
            //     'repeat_until',
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['won_status', 'type']
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['application_status', 'date_closed']
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _get_rotting_depends_fields(self):
            // """
            // fields added to this method through override should likely also be returned by _get_rotting_domain() override
            // 
            // :return: the array of fields that can affect the ability of a resource to rot
            // """
            // if hasattr(self, '_track_duration_field') and 'rotting_threshold_days' in self[self._track_duration_field]:
            //     return ['date_last_stage_update', f'{self._track_duration_field}.rotting_threshold_days']
            // return []
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['is_closed']
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain([
            //     ('won_status', '=', 'pending'),
            //     ('type', '=', 'opportunity'),
            // ])
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain([
            //     ('application_status', '=', 'ongoing'),
            //     ('date_closed', '=', False),
            // ])
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _get_rotting_domain(self):
            // """
            // fields added to this method through override should likely also be returned by _get_rotting_depends_fields() override
            // 
            // :return: domain: conditions that must be met so that the field can be considered rotting
            // """
            // return Domain(f'{self._track_duration_field}.rotting_threshold_days', '!=', 0)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain('is_closed', '=', False)
            */
            return default;
        }

        public async Task<TEntity> GetSimilarApplicantsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ignore_talent, object only_talent) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_similar_applicants_domain(self, ignore_talent=False, only_talent=False):
            // """
            // This method returns a domain for the applicants whitch match with the
            // current applicant according to email_from, partner_phone or linkedin_profile.
            // Thus, search on the domain will return the current applicant as well
            // if any of the following fields are filled.
            // 
            // Args:
            //     ignore_talent: if you want the domain to only include applicants not belonging to a talent pool
            //     only_talent: if you want the domain to only include applicants belonging to a talent pool
            // 
            // Returns:
            //     Domain()
            // """
            // domain = Domain.AND([
            //     Domain('company_id', 'in', self.mapped('company_id.id')),
            //     Domain.OR([
            //         Domain("id", "in", self.ids),
            //         Domain("email_normalized", "in", [email for email in self.mapped("email_normalized") if email]),
            //         Domain("partner_phone_sanitized", "in", [phone for phone in self.mapped("partner_phone_sanitized") if phone]),
            //         Domain("linkedin_profile", "in", [linkedin_profile for linkedin_profile in self.mapped("linkedin_profile") if linkedin_profile]),
            //         Domain("pool_applicant_id", "in", [pool_applicant.id for pool_applicant in self.mapped("pool_applicant_id") if pool_applicant]),
            //     ])
            // ])
            // if ignore_talent:
            //     domain &= Domain("talent_pool_ids", "=", False)
            // if only_talent:
            //     domain &= Domain("talent_pool_ids", "!=", False)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // self.ensure_one()
            // closed_task_count = self.task_count - self.open_task_count
            // if self.task_count:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s (%(closed_rate)s%%)",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //         closed_rate=round(100 * closed_task_count / self.task_count),
            //     )
            // else:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //     )
            // buttons = [{
            //     'icon': 'check',
            //     'text': self.label_tasks,
            //     'number': number,
            //     'action_type': 'object',
            //     'action': 'action_view_tasks',
            //     'show': True,
            //     'sequence': 1,
            // }]
            // if self.rating_count != 0:
            //     if self.rating_avg >= rating_data.RATING_AVG_TOP:
            //         icon = 'smile-o text-success'
            //     elif self.rating_avg >= rating_data.RATING_AVG_OK:
            //         icon = 'meh-o text-warning'
            //     else:
            //         icon = 'frown-o text-danger'
            //     buttons.append({
            //         'icon': icon,
            //         'text': self.env._('Average Rating'),
            //         'number': f'{int(self.rating_avg) if self.rating_avg.is_integer() else round(self.rating_avg, 1)} / 5',
            //         'action_type': 'object',
            //         'action': 'action_view_all_rating',
            //         'show': self.show_ratings,
            //         'sequence': 15,
            //     })
            // if self.env.user.has_group('project.group_project_user'):
            //     buttons.append({
            //         'icon': 'area-chart',
            //         'text': self.env._('Burndown Chart'),
            //         'action_type': 'action',
            //         'action': 'project.action_project_task_burndown_chart_report',
            //         'additional_context': json.dumps({
            //             'active_id': self.id,
            //             'stage_name_and_sequence_per_id': {
            //                 stage.id: {
            //                     'sequence': stage.sequence,
            //                     'name': stage.name
            //                 } for stage in self.type_ids
            //             },
            //         }),
            //         'show': True,
            //         'sequence': 60,
            //     })
            // return buttons
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtask_ids_per_task_id(self):
            // if not self:
            //     return {}
            // 
            // res = {id_: [] for id_ in self._ids}
            // if all(self._ids):
            //     self.env.cr.execute(
            //         """
            //  WITH RECURSIVE task_tree
            //              AS (
            //              SELECT id, id as supertask_id
            //                FROM project_task
            //               WHERE id IN %(ancestor_ids)s
            //               UNION
            //                  SELECT t.id, tree.supertask_id
            //                    FROM project_task t
            //                    JOIN task_tree tree
            //                      ON tree.id = t.parent_id
            //                     AND t.active in (TRUE, %(active)s)
            //                   WHERE t.parent_id IS NOT NULL
            //        ) SELECT supertask_id, ARRAY_AGG(id)
            //            FROM task_tree
            //           WHERE id != supertask_id
            //        GROUP BY supertask_id
            //         """,
            //         {
            //             "ancestor_ids": tuple(self.ids),
            //             "active": self.env.context.get('active_test', True),
            //         }
            //     )
            //     res.update(dict(self.env.cr.fetchall()))
            // else:
            //     res.update({
            //         task.id: task._get_subtasks_recursively().ids
            //         for task in self
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtasks_recursively(self):
            // children = self.child_ids
            // if not children:
            //     return self.env['project.task']
            // return children + children._get_subtasks_recursively()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_default_context_whitelist(self):
            // """
            // Whitelist of fields that can be set through the `default_` context keys when creating a project from a template.
            // """
            // return [
            //     "allow_milestones",
            // ]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_template_default_context_whitelist(self):
            // """
            // Whitelist of fields that can be set through the `default_` context keys when creating a task from a template.
            // """
            // return [
            //     "parent_id",
            // ]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_field_blacklist(self):
            // """
            // Blacklist of fields to not copy when creating a project from a template.
            // """
            // return [
            //     "partner_id",
            // ]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_template_field_blacklist(self):
            // """
            // Blacklist of fields to not copy when creating a task from a template.
            // """
            // return [
            //     "partner_id",
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFromProjectUndoCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_from_project_undo_callbacks(self):
            // self.ensure_one()
            // callbacks = {}
            // if self.active:
            //     self.action_archive()
            //     callbacks["unarchive_project"] = True
            // return callbacks
            */
            return default;
        }

        public async Task<TEntity> GetTemplateTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_template_tasks(self):
            // self.ensure_one()
            // return self.env['project.task'].search_read(
            //     [('project_id', '=', self.id), ('is_template', '=', True)],
            //     ['id', 'name'],
            // )
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectConfirmationCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_confirmation_callbacks(self):
            // self.ensure_one()
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_warnings(self):
            // self.ensure_one()
            // return []
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_thread_with_access(self, thread_id, *, project_sharing_id=None, token=None, **kwargs):
            // if project_sharing_id:
            //     if token := ProjectSharingChatter._check_project_access_and_get_token(
            //         self, project_sharing_id, self._name, thread_id, token
            //     ):
            //         token = token
            // return super()._get_thread_with_access(thread_id, project_sharing_id=project_sharing_id, token=token, **kwargs)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // calendar = self.env.company.resource_calendar_id
            // return calendar._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC)
            // )
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_user_values(self):
            // return {
            //     'is_project_user': self.env.user.has_group('project.group_project_user'),
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_values_analytic_account_batch(self, project_vals_list):
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return [{
            //     'name': project_vals.get('name', self.env._('Unknown Analytic Account')),
            //     'company_id': project_vals.get('company_id', False),
            //     'partner_id': project_vals.get('partner_id', False),
            //     'plan_id': project_plan.id,
            // } for project_vals in project_vals_list]
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_versioned_fields(self):
            // return [ProjectTask.description.name]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if view_type == 'form' and self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')\
            //     and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     view_id = self.env.ref('hr_recruitment.hr_applicant_view_form_interviewer').id
            // return super().get_view(view_id, view_type, **options)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """The override of fields_get making fields readonly for portal users
            // makes the view cache dependent on the fact the user has the group portal or not"""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self.env.user._is_portal(),)
            */
            return default;
        }

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing, object with_parent) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True, with_parent=None):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // :param with_parent: if set, create the new partner with the given parent
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer(with_parent=with_parent)
            //         lead.partner_id = partner.id
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_salesmen_assignment(self, user_ids=False, team_id=False):
            // """ Assign salesmen and salesteam to a batch of leads.  If there are more
            // leads than salesmen, these salesmen will be assigned in round-robin. E.g.
            // 4 salesmen (S1, S2, S3, S4) for 6 leads (L1, L2, ... L6) will assigned as
            // following: L1 - S1, L2 - S2, L3 - S3, L4 - S4, L5 - S1, L6 - S2.
            // 
            // :param list user_ids: salesmen to assign
            // :param int team_id: salesteam to assign
            // """
            // update_vals = {'team_id': team_id} if team_id else {}
            // if not user_ids and team_id:
            //     self.write(update_vals)
            // else:
            //     lead_ids = self.ids
            //     steps = len(user_ids)
            //     # pass 1 : lead_ids[0:6:3] = [L1,L4]
            //     # pass 2 : lead_ids[1:6:3] = [L2,L5]
            //     # pass 3 : lead_ids[2:6:3] = [L3,L6]
            //     # ...
            //     for idx in range(0, steps):
            //         subset_ids = lead_ids[idx:len(lead_ids):steps]
            //         update_vals['user_id'] = user_ids[idx]
            //         self.env['crm.lead'].browse(subset_ids).write(update_vals)
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_status_by_lead, object new_status_by_lead) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, old_status_by_lead, new_status_by_lead):
            // """ This method handles all changes of won / lost status of leads on creation / writing,
            // and update the scoring frequency table accordingly:
            // - To lost : Increment corresponding lost count
            // - To won : Increment corresponding won count
            // - Leaving lost : Decrement corresponding lost count
            // - Leaving won : Decrement corresponding won count
            // More than one operation can happen simultaneously, for instance, going from lost to won:
            // Decrement corresponding lost count + increment corresponding won count.
            // 
            // A lead is WON when in won stage (and probability = 100% but that is implied and constrained)
            // A lead is LOST when active = False AND probability = 0
            // In every other case, the lead is not won nor lost.
            // 
            // :param old_status_by_lead: dict of old status by lead: {lead.id: {'is_lost': ..., 'is_won': ...}}
            // :param new_status_by_lead: dict of new status by lead: {lead.id: {'is_lost': ..., 'is_won': ...}}
            // """
            // leads_reach_won_ids = self.env['crm.lead']
            // leads_leave_won_ids = self.env['crm.lead']
            // leads_reach_lost_ids = self.env['crm.lead']
            // leads_leave_lost_ids = self.env['crm.lead']
            // 
            // for lead in self:
            //     new_status = new_status_by_lead.get(
            //         lead.id, {'is_lost': False, 'is_won': False}
            //     )
            //     old_status = old_status_by_lead.get(
            //         lead.id, {'is_lost': False, 'is_won': False}
            //     )
            //     if new_status['is_lost'] and new_status['is_won']:
            //         raise ValidationError(_("The lead %s cannot be won and lost at the same time.", lead))
            // 
            //     if new_status['is_lost'] and not old_status['is_lost']:
            //         leads_reach_lost_ids += lead
            //     elif not new_status['is_lost'] and old_status['is_lost']:
            //         leads_leave_lost_ids += lead
            // 
            //     if new_status['is_won'] and not old_status['is_won']:
            //         leads_reach_won_ids += lead
            //     elif not new_status['is_won'] and old_status['is_won']:
            //         leads_leave_won_ids += lead
            // 
            // leads_reach_won_ids._pls_increment_frequencies(to_state='won')
            // leads_leave_won_ids._pls_increment_frequencies(from_state='won')
            // leads_reach_lost_ids._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost_ids._pls_increment_frequencies(from_state='lost')
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _has_field_access(self, field, operation):
            // if not super()._has_field_access(field, operation):
            //     return False
            // if not self.env.su and self.env.user._is_portal():
            //     # additional checks for portal users
            //     readable, writeable = self._portal_accessible_fields()
            //     if operation == 'read':
            //         return field.name in readable
            //     if operation == 'write':
            //         return field.name in writeable
            // return True
            */
            return default;
        }

        public async Task<TEntity> InverseAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_milestones(self):
            // self._check_project_group_with_field('allow_milestones', 'project.group_project_milestone')
            */
            return default;
        }

        public async Task<TEntity> InverseAllowRecurringTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_recurring_tasks(self):
            // self._check_project_group_with_field('allow_recurring_tasks', 'project.group_project_recurring_tasks')
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_task_dependencies(self):
            // """ Reset state for waiting tasks in the project if the feature is disabled
            //     or recompute the tasks with dependencies if the project has the feature enabled again
            // """
            // project_with_task_dependencies_feature = self.filtered('allow_task_dependencies')
            // projects_without_task_dependencies_feature = self - project_with_task_dependencies_feature
            // ProjectTask = self.env['project.task']
            // if (
            //     project_with_task_dependencies_feature
            //     and (
            //         open_tasks_with_dependencies := ProjectTask.search([
            //             ('project_id', 'in', project_with_task_dependencies_feature.ids),
            //             ('depend_on_ids.state', 'in', ProjectTask.OPEN_STATES),
            //             ('state', 'in', ProjectTask.OPEN_STATES),
            //         ])
            //     )
            // ):
            //     open_tasks_with_dependencies.state = '04_waiting_normal'
            // if (
            //     projects_without_task_dependencies_feature
            //     and (
            //         waiting_tasks := ProjectTask.search([
            //             ('project_id', 'in', projects_without_task_dependencies_feature.ids),
            //             ('state', '=', '04_waiting_normal'),
            //         ])
            //     )
            // ):
            //     waiting_tasks.state = '01_in_progress'
            // res = self._check_project_group_with_field('allow_task_dependencies', 'project.group_project_task_dependencies')
            // # Hide/Show task waiting subtype when task dependencies feature is disabled/enabled
            // if res or res is False:
            //     self.env.ref('project.mt_task_waiting').hidden = not res
            //     self.env.ref('project.mt_project_task_waiting').hidden = not res
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_company_id(self):
            // """
            // Ensures that the new company of the project is valid for the account. If not set back the previous company, and raise a user Error.
            // Ensures that the new company of the project is valid for the partner
            // """
            // for project in self:
            //     account = project.account_id
            //     if (
            //         project.partner_id
            //         and project.partner_id.company_id
            //         and project.company_id
            //         and project.company_id != project.partner_id.company_id
            //     ):
            //         raise UserError(_('The project and the associated partner must be linked to the same company.'))
            //     if not account or not account.company_id:
            //         continue
            //     # if the account of the project has more than one company linked to it, or if it has aal, do not update the account, and set back the old company on the project.
            //     if (account.project_count > 1 or account.line_ids) and project.company_id != account.company_id:
            //         raise UserError(
            //             _("The project's company cannot be changed if its analytic account has analytic lines or if more than one project is linked to it."))
            //     account.company_id = project.company_id or project.partner_id.company_id
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_display_name(self):
            // for task in self:
            //     if not task.display_name:
            //         continue
            //     pattern = re.compile(r'^%s.+?%s$' % (
            //         ('').join(task._get_cannot_start_with_patterns()),
            //         ('').join(task._get_groups_patterns()))
            //     )
            //     match = pattern.match(task.display_name)
            //     if match:
            //         for group, extract_data in enumerate(task._get_groups(), start=1):
            //             if match.group(group):
            //                 extract_data(task)
            //         task.name = task.display_name.strip()
            */
            return default;
        }

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_email_from(self):
            // for lead in self:
            //     if lead._get_partner_email_update(force_void=False):
            //         lead.partner_id.email = lead.email_from
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_parent_id(self):
            // for task in self.sudo():
            //     if not task.parent_id:
            //         task.display_in_project = True
            //     elif task.display_in_project and task.project_id == task.parent_id.sudo().project_id:
            //         task.display_in_project = False
            */
            return default;
        }

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_partner_email(self):
            // for applicant in self:
            //     email_normalized = tools.email_normalize(applicant.email_from or '')
            //     if not email_normalized:
            //         continue
            //     if not applicant.partner_id:
            //         if not applicant.partner_name:
            //             raise UserError(_("You must define a Contact Name for this applicant."))
            //         applicant.partner_id = applicant._partner_find_from_emails_single(
            //             [applicant.email_from], no_create=False,
            //             additional_values={
            //                 email_normalized: {'lang': self.env.lang}
            //             },
            //         )
            //     if applicant.partner_name and applicant.partner_name != applicant.partner_id.name:
            //         applicant.partner_id.name = applicant.partner_name
            //     if email_normalized and email_normalized != applicant.partner_id.email:
            //         applicant.partner_id.email = applicant.email_from
            //     if applicant.partner_phone and applicant.partner_phone != applicant.partner_id.phone:
            //         applicant.partner_id.phone = applicant.partner_phone
            */
            return default;
        }

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_partner_phone(self):
            // for task in self:
            //     if task.partner_id:
            //         task.partner_id.phone = task.partner_phone
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_phone(self):
            // for lead in self:
            //     if lead._get_partner_phone_update(force_void=False):
            //         lead.partner_id.phone = lead.phone
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_state(self):
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // tasks = self.filtered(lambda task: task.state in CLOSED_STATES and task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id))
            // self.env['project.task.recurrence']._create_next_occurrences(tasks)
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def is_blocked_by_dependences(self):
            // return any(blocking_task.state not in CLOSED_STATES for blocking_task in self.depend_on_ids)
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _is_recurrence_valid(self):
            // self.ensure_one()
            // return self.repeat_interval > 0 and\
            //         (self.repeat_type != 'until' or self.repeat_until and self.repeat_until > fields.Date.today())
            */
            return default;
        }

        public async Task<TEntity> IsRottingFeatureEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _is_rotting_feature_enabled(self):
            // """
            // To enable the rotting behavior, the following must be present:
            // 
            // * Stage-like model (linked by '_track_duration_field') must have a 'rotting_threshold_days' integer field
            //     modeling the number of days before a record rots
            // 
            // * Model inheriting from duration mixin must have a 'date_last_stage_update' field tracking the last stage change
            // 
            // 
            // Also consider overriding _get_rotting_depends_fields() and _get_rotting_domain().
            // 
            // Certain views have access to widgets to display rotting status:
            //     'rotting' for kanbans, 'rotting_statusbar_duration' for forms, 'badge_rotting' for lists.
            // 
            // :return: bool: whether the rotting feature has been configured for this model
            // """
            // return 'rotting_threshold_days' in self[self._track_duration_field] and 'date_last_stage_update' in self and (
            //     not self  # api.model call
            //     or any(stage.rotting_threshold_days for stage in self[self._track_duration_field])
            // )
            */
            return default;
        }

        public async Task<TEntity> IsRuleBasedAssignmentActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _is_rule_based_assignment_activated(self):
            // """ Returns whether a rule-based assignment method is activated (cron-enabled or manually-ran).
            // """
            // return self.env['ir.config_parameter'].sudo().get_param('crm.lead.auto.assignment', False)
            */
            return default;
        }

        public async Task<TEntity> LinkApplicantToTalentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def link_applicant_to_talent(self):
            // talent = self.env["hr.applicant"].search(domain=self._get_similar_applicants_domain(only_talent=True))
            // self.pool_applicant_id = talent
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _load_records_create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('recurring_task'):
            //         if not vals.get('recurrence_id'):
            //             default_val = self.default_get(self._get_recurrence_fields())
            //             vals.update(**default_val)
            //     project_id = vals.get('project_id')
            //     if project_id:
            //         self = self.with_context(default_project_id=project_id)
            // tasks = super()._load_records_create(vals_list)
            // 
            // return tasks
            */
            return default;
        }

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def log_meeting(self, meeting):
            // """ Log the meeting info with a link to it in the chatter
            // :param record meeting: the meeting we want to log
            // """
            // if not meeting.duration:
            //     duration = _('unknown')
            // else:
            //     duration = self.env['ir.qweb.field.duration'].value_to_html(meeting.duration, {'unit': 'hour'})
            // meeting_usertime = fields.Datetime.to_string(fields.Datetime.context_timestamp(self, meeting.start))
            // meeting_time = Markup("<time datetime='%(meeting_start)s+00:00'>%(meeting_user_time)s</time>") % {
            //     'meeting_start': meeting.start,
            //     'meeting_user_time': meeting_usertime,
            // }
            // message = Markup("<p>%(meeting)s<br/>%(subject_string)s %(subject_link)s<br/>%(duration)s<p>") % {
            //     'meeting': _("Meeting scheduled at %s", meeting_time),
            //     'subject_string': _("Subject: "),
            //     'subject_link': meeting._get_html_link(),
            //     'duration': _("Duration: %s", duration),
            // }
            // return self.message_post(body=message)
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_project_task_waiting')
            //     if not self.allow_task_dependencies and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.stage_id.rating_active:
            //     res -= self.env.ref('project.mt_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_task_waiting')
            //     if ((self.project_id and not self.project_id.allow_task_dependencies)\
            //         or (not self.project_id and not self.env.user.has_group('project.group_project_task_dependencies')))\
            //         and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def map_tasks(self, new_project_id):
            // """ copy and map tasks from old to new project """
            // project = self.browse(new_project_id)
            // # We want to copy archived task, but do not propagate an active_test context key
            // tasks = self.env['project.task'].with_context(active_test=False).search([('project_id', '=', self.id), ('parent_id', '=', False)])
            // if self.allow_task_dependencies and 'task_mapping' not in self.env.context:
            //     self = self.with_context(task_mapping=dict())
            // # preserve task name and stage, normally altered during copy
            // defaults = self._map_tasks_default_values(project)
            // new_tasks = tasks.with_context(copy_project=True).copy(defaults)
            // all_subtasks = new_tasks._get_all_subtasks()
            // all_subtasks.filtered(
            //     lambda child: child.project_id == self
            // ).write({
            //     'project_id': project.id
            // })
            // return True
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _map_tasks_default_values(self, project):
            // """ get the default value for the copied task on project duplication.
            // The stage_id, name field will be set for each task in the overwritten copy_data function in project.task """
            // return {
            //     'state': '01_in_progress',
            //     'company_id': project.company_id.id,
            //     'project_id': project.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_data(self, fnames=None):
            // """ Prepare lead/opp data into a dictionary for merging. Different types
            //     of fields are processed in different ways:
            //         - text: all the values are concatenated
            //         - m2m and o2m: those fields aren't processed
            //         - m2o: the first not null value prevails (the other are dropped)
            //         - any other type of field: same as m2o
            // 
            //     :param fnames: list of fields to process
            //     :returns: contains the merged values of the new opportunity
            //     :rtype: dict
            // """
            // if fnames is None:
            //     fnames = self._merge_get_fields()
            // fcallables = self._merge_get_fields_specific()
            // address_values = self._merge_get_fields_address()
            // 
            // # helpers
            // def _get_first_not_null(attr, opportunities):
            //     value = False
            //     for opp in opportunities:
            //         if opp[attr]:
            //             value = opp[attr].id if isinstance(opp[attr], models.BaseModel) else opp[attr]
            //             break
            //     return value
            // 
            // # process the field's values
            // data = {}
            // for field_name in fnames:
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     fcallable = fcallables.get(field_name)
            //     if fcallable and callable(fcallable):
            //         data[field_name] = fcallable(field_name, self)
            //     elif field_name in address_values:
            //         data[field_name] = address_values[field_name]
            //     elif not fcallable and field.type in ('many2many', 'one2many'):
            //         continue
            //     else:
            //         data[field_name] = _get_first_not_null(field_name, self)  # take the first not null
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_attachments(self, opportunities):
            // """ Move attachments of given opportunities to the current one `self`, and rename
            //     the attachments having same name than native ones.
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // 
            // all_attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', opportunities.ids)
            // ])
            // 
            // for opportunity in opportunities:
            //     attachments = all_attachments.filtered(lambda attach: attach.res_id == opportunity.id)
            //     for attachment in attachments:
            //         attachment.write({
            //             'res_id': self.id,
            //             'name': _("%(attach_name)s (from %(lead_name)s)",
            //                       attach_name=attachment.name,
            //                       lead_name=opportunity.name[:20]
            //                      )
            //         })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_calendar_events(self, opportunities):
            // """ Move calender.event from the given opportunities to the current one. `self` is the
            //     crm.lead record destination for event of `opportunities`.
            // :param opportunities: see ``merge_dependences``
            // """
            // self.ensure_one()
            // meetings = self.env['calendar.event'].search([('opportunity_id', 'in', opportunities.ids)])
            // return meetings.write({
            //     'res_id': self.id,
            //     'opportunity_id': self.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_history(self, opportunities):
            // """ Move history from the given opportunities to the current one. `self`
            // is the crm.lead record destination for message of `opportunities`.
            // 
            // This method moves
            //   * messages
            //   * activities
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // # sudo usage: because we want to go through all messages, whatever the real ACLs
            // # current user has on them
            // for opportunity_su in opportunities.sudo():
            //     for message_su in opportunity_su.message_ids:
            //         if message_su.subject:
            //             subject = _("From %(source_name)s: %(source_subject)s", source_name=opportunity_su.name, source_subject=message_su.subject)
            //         else:
            //             subject = _("From %(source_name)s", source_name=opportunity_su.name)
            //         message_su.write({
            //             'res_id': self.id,
            //             'subject': subject,
            //         })
            // opportunities.activity_ids.write({
            //     'res_id': self.id,
            // })
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // """ Merge dependences (messages, attachments,activities, calendar events,
            // ...). These dependences will be transfered to `self` considered as the
            // master lead.
            // 
            // :param opportunities : recordset of opportunities to transfer. Does not
            //   include `self` which is the target crm.lead being the result of the
            //   merge;
            // """
            // self.ensure_one()
            // self._merge_dependences_history(opportunities)
            // self._merge_dependences_attachments(opportunities)
            // self._merge_dependences_calendar_events(opportunities)
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_followers(self, opportunities):
            // """Add the followers into the destination lead if they post a message in the last 30 days.
            // 
            // :param opportunities : Record<crm.lead> of opportunities to transfer
            // :return: {old_lead_id: Record<mail.followers>} Followers which have been added in
            //     the destination lead grouped by source lead ID.
            // """
            // self.ensure_one()
            // 
            // self.env['mail.message'].flush_model()
            // self.env['mail.followers'].flush_model()
            // 
            // # Get the active followers (followers whose partner post a message on the
            // # leads in the last 30 days) which should be moved on the destination lead
            // self.env.cr.execute(
            //     '''
            //     SELECT MAX(mf.id) AS id
            //       FROM mail_followers AS mf
            //       JOIN mail_message AS mm
            //         ON mm.author_id = mf.partner_id
            //        AND mm.res_id = mf.res_id
            //        AND mm.model = 'crm.lead'
            //        AND mm.date > NOW() - INTERVAL '30 DAY'
            //            /* Check if the partner is already
            //               following the destination lead */
            //  LEFT JOIN mail_followers AS destf
            //         ON destf.res_model = 'crm.lead'
            //        AND destf.res_id = %(lead_id)s
            //        AND destf.partner_id = mf.partner_id
            //            /* Select only once each partner
            //               to not create duplicated followers */
            //      WHERE mf.res_model = 'crm.lead'
            //        AND mf.res_id IN %(lead_ids)s
            //        AND destf IS NULL
            //   GROUP BY mf.partner_id
            //     ''',
            //     {'lead_ids': tuple(opportunities.ids), 'lead_id': self.id},
            // )
            // followers_to_update = [r[0] for r in self.env.cr.fetchall()]
            // followers_to_update = self.env['mail.followers'].browse(followers_to_update).sudo()
            // followers_by_old_lead = dict(groupby(followers_to_update, lambda f: f.res_id))
            // followers_to_update.write({'res_id': self.id})
            // return followers_by_old_lead
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_address(self):
            // """The address fields are propagated as a whole.
            // 
            // The address is taken from the lead with the most non-empty address field
            // (sorted by highest rank if multiple lead have the same amount of non-empty
            // fields).
            // """
            // source_lead = max(self, key=lambda lead: len(list(
            //     lead[field] for field in PARTNER_ADDRESS_FIELDS_TO_SYNC
            //     if lead[field]
            // )))
            // return {fname: source_lead[fname] for fname in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return (
            //     CRM_LEAD_FIELDS_TO_MERGE
            //     + list(self._merge_get_fields_specific().keys())
            //     + PARTNER_ADDRESS_FIELDS_TO_SYNC
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     'description': lambda fname, leads: '<br/><br/>'.join(desc for desc in leads.mapped('description') if not is_html_empty(desc)),
            //     'type': lambda fname, leads: 'opportunity' if any(lead.type == 'opportunity' for lead in leads) else 'lead',
            //     'priority': lambda fname, leads: max(priorities) if (priorities := leads.filtered('priority').mapped('priority')) else False,
            //     'tag_ids': lambda fname, leads: leads.mapped('tag_ids'),
            //     'lost_reason_id': lambda fname, leads:
            //         False if leads and leads[0].probability
            //         else next((lead.lost_reason_id for lead in leads if lead.lost_reason_id), False),
            // }
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_log_summary(self, merged_followers, opportunities_tail):
            // """Log the merge message on the lead."""
            // self.ensure_one()
            // self.message_post_with_source(
            //     "crm.crm_lead_merge_summary",
            //     render_values={
            //         "merged_followers": merged_followers,
            //         "opportunities": opportunities_tail,
            //         "is_html_empty": is_html_empty,
            //     },
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True):
            // """
            // Merge opportunities in one. Different cases of merge:
            // 
            // - merge leads together = 1 new lead
            // - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            // 
            // The resulting lead/opportunity will be the most important one (based on its confidence level)
            // updated with values from other opportunities to merge.
            // 
            // :param user_id: the id of the saleperson. If not given, will be determined by :meth:`_merge_data`.
            // :param team_id: the id of the Sales Team. If not given, will be determined by :meth:`_merge_data`.
            // :returns: crm.lead record resulting of th merge
            // """
            // return self._merge_opportunity(user_id=user_id, team_id=team_id, auto_unlink=auto_unlink)
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True, max_length=5):
            // """ Private merging method. This one allows to relax rules on record set
            // length allowing to merge more than 5 opportunities at once if requested.
            // This should not be called by action buttons.
            // 
            // See ``merge_opportunity`` for more details. """
            // if len(self.ids) <= 1:
            //     raise UserError(_('Select at least two Leads/Opportunities from the list to merge them.'))
            // 
            // if max_length and len(self.ids) > max_length and not self.env.is_superuser():
            //     raise UserError(_("To prevent data loss, Leads and Opportunities can only be merged by groups of %(max_length)s.", max_length=max_length))
            // 
            // opportunities = self._sort_by_confidence_level(reverse=True)
            // 
            // # get SORTED recordset of head and tail, and complete list
            // opportunities_head = opportunities[0]
            // opportunities_tail = opportunities[1:]
            // 
            // # merge all the sorted opportunity. This means the value of
            // # the first (head opp) will be a priority.
            // merged_data = opportunities._merge_data(self._merge_get_fields())
            // 
            // # force value for saleperson and Sales Team
            // if user_id:
            //     merged_data['user_id'] = user_id
            // if team_id:
            //     merged_data['team_id'] = team_id
            // 
            // merged_followers = opportunities_head._merge_followers(opportunities_tail)
            // 
            // # log merge message
            // opportunities_head._merge_log_summary(merged_followers, opportunities_tail)
            // # merge other data (mail.message, attachments, ...) from tail into head
            // opportunities_head._merge_dependences(opportunities_tail)
            // 
            // # check if the stage is in the stages of the Sales Team. If not, assign the stage with the lowest sequence
            // if merged_data.get('team_id'):
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_ids', 'in', merged_data['team_id']), ('team_ids', '=', False)], order='sequence, id')
            //     if merged_data.get('stage_id') not in team_stage_ids.ids:
            //         merged_data['stage_id'] = team_stage_ids[0].id if team_stage_ids else False
            // 
            // # write merged data into first opportunity; remove some keys if already
            // # set on opp to avoid useless recomputes
            // if 'user_id' in merged_data and opportunities_head.user_id.id == merged_data['user_id']:
            //     merged_data.pop('user_id')
            // if 'team_id' in merged_data and opportunities_head.team_id.id == merged_data['team_id']:
            //     merged_data.pop('team_id')
            // opportunities_head.write(merged_data)
            // 
            // # delete tail opportunities
            // # we use the SUPERUSER to avoid access rights issues because as the user had the rights to see the records it should be safe to do so
            // if auto_unlink:
            //     opportunities_tail.sudo().unlink()
            // 
            // return opportunities_head
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_auto_subscribe_followers(self, updated_values, default_subtype_ids):
            // if 'user_ids' not in updated_values:
            //     return []
            // # Since the changes to user_ids becoming a m2m, the default implementation of this function
            // #  could not work anymore, override the function to keep the functionality.
            // new_followers = []
            // # Normalize input to tuple of ids
            // value = self._fields['user_ids'].convert_to_cache(updated_values.get('user_ids', []), self.env['project.task'], validate=False)
            // users = self.env['res.users'].browse(value)
            // for user in users:
            //     try:
            //         if user.partner_id:
            //             # The you have been assigned notification is handled separately
            //             new_followers.append((user.partner_id.id, default_subtype_ids, False))
            //     except Exception:
            //         pass
            // return new_followers
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set an user as responsible. We prefer that
            // # assignment is done automatically (scoring) or manually. Otherwise it
            // # would always be root (gateway user). It also allows to exclude portal
            // # and public users.
            // self = self.with_context(default_user_id=False)
            // 
            // if custom_values is None:
            //     custom_values = {}
            // defaults = {
            //     'name':  msg_dict.get('subject') or _("No Subject"),
            //     'email_from': msg_dict.get('from'),
            //     'partner_id': msg_dict.get('author_id', False),
            // }
            // if msg_dict.get('priority') in dict(crm_stage.AVAILABLE_PRIORITIES):
            //     defaults['priority'] = msg_dict.get('priority')
            // defaults.update(custom_values)
            // 
            // new_lead = super().message_new(msg_dict, custom_values=defaults)
            // new_lead._assign_userless_lead_in_team(_('incoming email'))
            // return new_lead
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False)
            // stage = False
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            // 
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg_dict.get('from'))
            // 
            // defaults = {
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // 
            // if msg_dict.get('from') and not job_platform:
            //     defaults['email_from'] = msg_dict.get('from')
            //     defaults['partner_id'] = msg_dict.get('author_id', False)
            // if msg_dict.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg_dict.get('subject')) + re.findall(subject_pattern, msg_dict.get('body'))
            //     defaults['partner_name'] = regex_results[0] if regex_results else partner_name
            //     del msg_dict['email_from']
            // if msg_dict.get('priority'):
            //     defaults['priority'] = msg_dict.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg_dict, custom_values=defaults)
            // res._compute_partner_phone_email()
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // create_context = dict(self.env.context or {})
            // create_context['default_user_ids'] = False
            // if custom_values is None:
            //     custom_values = {}
            // # Auto create partner if not existent when the task is created from email
            // if not msg_dict.get('author_id') and msg_dict.get('email_from'):
            //     author = self.env['mail.thread']._partner_find_from_emails_single([msg_dict['email_from']], no_create=False)
            //     msg_dict['author_id'] = author.id
            // 
            // defaults = {
            //     'name': msg_dict.get('subject') or _("No Subject"),
            //     'allocated_hours': 0.0,
            //     'partner_id': msg_dict.get('author_id'),
            //     'email_cc': ", ".join(self._mail_cc_sanitized_raw_dict(msg_dict.get('cc')).values()) if custom_values.get('project_id') else ""
            // 
            // }
            // defaults.update(custom_values)
            // 
            // # users having email address matched from emails recepients are filtered out and added as assignees to the task
            // if msg_dict.get('to'):
            //     internal_users, partner_emails_without_users, unmatched_partner_emails = self._find_internal_users_from_address_mail(msg_dict.get('to'), defaults.get('project_id'))
            //     # set only internal users as assignees
            //     defaults['user_ids'] = defaults.get('user_ids', []) + internal_users
            //     if custom_values.get("project_id") and (partner_emails_without_users or unmatched_partner_emails):
            //         defaults["email_cc"] = defaults.get("email_cc", "") + ", " + ", ".join(partner_emails_without_users + unmatched_partner_emails)
            // task = super(ProjectTask, self.with_context(create_context)).message_new(msg_dict, custom_values=defaults)
            // partners = task._partner_find_from_emails_single(tools.email_split((msg_dict.get('to') or '') + ',' + (msg_dict.get('cc') or '')), no_create=True)
            // if task.project_id:
            //     task.message_subscribe(partners.ids)
            // return task
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     email_normalized = tools.email_normalize(self.email_from)
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (email_normalized and partner.email_normalized == email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].create_date.date() == fields.Date.today():
            //             new_partner[0].write({
            //                 'name': self.partner_name or self.email_from,
            //             })
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_from', 'in', [new_partner[0].email, new_partner[0].email_normalized])
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if message.attachment_ids and not self.displayed_image_id:
            //     image_attachments = message.attachment_ids.filtered(lambda a: a.mimetype == 'image')
            //     if image_attachments:
            //         self.displayed_image_id = image_attachments[0]
            // 
            // # use the sanitized body of the email from the message thread to populate the task's description
            // if (
            //    not self.description
            //    and message.subtype_id == self._creation_subtype()
            //    and self.partner_id == message.author_id
            //    and msg_vals['message_type'] == 'email'
            //    and msg_vals.get('body')
            // ):
            //     # Remove the signature from the email body
            //     source_html = msg_vals.get('body')
            //     doc = html.fromstring(source_html)
            // 
            //     signature_xpath = (
            //         '//*[@id="Signature"] | '
            //         '//*[@data-smartmail="gmail_signature"] | '
            //         '//span[normalize-space(.) = "--"]'
            //     )
            // 
            //     for element in doc.xpath(signature_xpath):
            //         element.getparent().remove(element)
            // 
            //     cleaned_html = html.tostring(doc, encoding='unicode').strip()
            //     self.description = html_sanitize(cleaned_html)
            // 
            // return super()._message_post_after_hook(message, msg_vals)
            #endif
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // """
            // Subscribe to newly created task but not all existing active task when subscribing to a project.
            // User update notification preference of project its propagated to all the tasks that the user is
            // currently following.
            // """
            // res = super().message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // if subtype_ids:
            //     project_subtypes = self.env['mail.message.subtype'].browse(subtype_ids)
            //     task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids
            //     if task_subtypes:
            //         for task in self.task_ids:
            //             partners = set(task.message_partner_ids.ids) & set(partner_ids)
            //             if partners:
            //                 task.message_subscribe(partner_ids=list(partners), subtype_ids=task_subtypes)
            //         self.update_ids.message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // # Set task notification based on project notification preference if user follow the project
            // if not subtype_ids:
            //     project_followers = self.project_id.sudo().message_follower_ids.filtered(lambda f: f.partner_id.id in partner_ids)
            //     for project_follower in project_followers:
            //         project_subtypes = project_follower.subtype_ids
            //         task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids if project_subtypes else None
            //         partner_ids.remove(project_follower.partner_id.id)
            //         super().message_subscribe(project_follower.partner_id.ids, task_subtypes)
            // return super().message_subscribe(partner_ids, subtype_ids)
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_unsubscribe(self, partner_ids=None):
            // self.task_ids.message_unsubscribe(partner_ids=partner_ids)
            // super().message_unsubscribe(partner_ids=partner_ids)
            // if partner_ids:
            //     self.env['project.collaborator'].search([('partner_id', 'in', partner_ids), ('project_id', 'in', self.ids)]).unlink()
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_update(self, msg_dict, update_vals=None):
            // for task in self:
            //     partners = task._partner_find_from_emails_single(tools.email_split((msg_dict.get('to') or '') + ',' + (msg_dict.get('cc') or '')), no_create=True)
            //     task.message_subscribe(partners.ids)
            // return super().message_update(msg_dict, update_vals=update_vals)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def name_create(self, name):
            // res = super().name_create(name)
            // if res:
            //     # We create a default stage `new` for projects created on the fly.
            //     self.browse(res[0]).type_ids += self.env['project.task.type'].sudo().create({'name': _('New')})
            // return res
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_get_headers(self, headers=None):
            // headers = super()._notify_by_email_get_headers(headers=headers)
            // if self.project_id:
            //     current_objects = [h for h in headers.get('X-Odoo-Objects', '').split(',') if h]
            //     current_objects.insert(0, 'project.project-%s, ' % self.project_id.id)
            //     headers['X-Odoo-Objects'] = ','.join(current_objects)
            // if self.tag_ids:
            //     headers['X-Odoo-Tags'] = ','.join(self.tag_ids.mapped('name'))
            // return headers
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // project_name = self.project_id.sudo().name
            // stage_name = self.stage_id.name
            // subtitles = ""
            // if project_name and stage_name:
            //     subtitles = _('Project: %(project_name)s, Stage: %(stage_name)s', project_name=project_name, stage_name=stage_name)
            // elif project_name:
            //     subtitles = _('Project: %(project_name)s', project_name=project_name)
            // elif stage_name:
            //     subtitles = _('Stage: %(stage_name)s', stage_name=stage_name)
            // if subtitles:
            //     render_context['subtitles'].append(subtitles)
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // """ Give access to the portal user/customer if the project visibility is portal. """
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // portal_privacy = self.privacy_visibility in ['invited_users', 'portal']
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ['portal', 'portal_customer'] and not portal_privacy:
            //         group_data['has_button_access'] = False
            // return groups
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # Handle project users and managers recipients that can assign
            // # tasks and create new one directly from notification emails. Also give
            // # access button to portal users and portal customers. If they are notified
            // # they should probably have access to the document.
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // 
            // project_user_group_id = self.env.ref('project.group_project_user').id
            // new_group = ('group_project_user', lambda pdata: pdata['type'] == 'user' and project_user_group_id in pdata['groups'], {})
            // groups = [new_group] + groups
            // 
            // if self.project_privacy_visibility in ['invited_users', 'portal']:
            //     groups.insert(0, (
            //         'allowed_portal_users',
            //         lambda pdata: pdata['type'] in ['invited_users', 'portal'],
            //         {
            //             'active': True,
            //             'has_button_access': True,
            //         }
            //     ))
            // portal_privacy = self.project_id.privacy_visibility in ['invited_users', 'portal']
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ('customer', 'user') or group_name == 'portal_customer' and not portal_privacy:
            //         group_data['has_button_access'] = False
            //     elif group_name == 'portal_customer' and portal_privacy:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // # Override to set alias of lead and opportunities to their sales team if any
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default, author_id=author_id)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(CrmLead, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default, author_id=author_id)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(HrApplicant, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // # Override to set alias of tasks to their project if any
            // aliases = self.sudo().mapped('project_id')._notify_get_reply_to(default=default, author_id=author_id)
            // res = {task.id: aliases.get(task.project_id.id) for task in self}
            // leftover = self.filtered(lambda rec: not rec.project_id)
            // if leftover:
            //     res.update(super(ProjectTask, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def OPEN_STATES(self):
            // """ Return a list of the technical names complementing the CLOSED_STATES, a.k.a the open states """
            // return list(set(self._fields['state'].get_values(self.env)) - set(CLOSED_STATES))
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_commercial_partner_id(self):
            // for lead in self:
            //     if lead.partner_id and lead.commercial_partner_id and lead.commercial_partner_id != lead.partner_id.commercial_partner_id:
            //         # writing to partner will invalidate and recompute
            //         # re-write the original value to keep user selection
            //         commercial_partner = lead.commercial_partner_id
            //         lead.update({
            //             'partner_id': False,
            //             'email_from': False,
            //             'phone': False,
            //         })
            //         lead.commercial_partner_id = commercial_partner
            //     if not lead.name and lead.commercial_partner_id:
            //         lead.name = _("%s's opportunity", lead.commercial_partner_id.name)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _onchange_company_id(self):
            // if (self.env.user.has_group('project.group_project_stages') and self.stage_id.company_id
            //         and self.stage_id.company_id != self.company_id):
            //     self.stage_id = self.env['project.project.stage'].search(
            //         [('company_id', 'in', [self.company_id.id, False])],
            //         order=f"sequence asc, {self.env['project.project.stage']._order}",
            //         limit=1,
            //     ).id
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_project_id(self):
            // if self.state != '04_waiting_normal':
            //     self.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_task_company(self):
            // if self.project_id.company_id and self.project_id.company_id != self.company_id:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT project_id FROM project_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _phone_get_number_fields(self):
            // """ This method returns the fields to use to find the number to use to
            // send an SMS on a record. """
            // return ['partner_phone']
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def plan_task_in_calendar(self, vals):
            // self.ensure_one()
            // return self.write(vals)
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=None):
            // """
            // This methods builds a dict where, for each lead in self or matching the given domain,
            // we will get a list of field/value couple.
            // Due to onchange and create, we don't always have the id of the lead to recompute.
            // When we update few records (one, typically) with onchanges, we build the lead_values (= couple field/value)
            // using the ORM.
            // To speed up the computation and avoid making too much DB read inside loops,
            // we can give a domain to make sql queries to bypass the ORM.
            // This domain will be used in sql queries to get the values for every lead matching the domain.
            // :param domain: If set, we get all the leads values via unique sql queries (one for tags, one for other fields),
            //                     using the given domain on leads.
            //                If not set, get lead values lead by lead using the ORM.
            // :return: {lead_id: [(field1: value1), (field2: value2), ...], ...}
            // """
            // leads_values_dict = OrderedDict()
            // pls_fields = ["stage_id", "team_id"] + self._pls_get_safe_fields()
            // 
            // # Check if tag_ids is in the pls_fields and removed it from the list. The tags will be managed separately.
            // use_tags = 'tag_ids' in pls_fields
            // if use_tags:
            //     pls_fields.remove('tag_ids')
            // 
            // if domain:
            //     # Get leads values
            //     self.flush_model()
            //     # active_test = False as domain should take active into 'active' field it self
            //     query = self.env['crm.lead'].with_context(active_test=False)._search(domain, bypass_access=True)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self.env.cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self.env.cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self.env.cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self.env.cr.dictfetchall()
            //     else:
            //         tag_results = []
            // 
            //     # get all (variable, value) couple for all in self
            //     for lead in lead_results:
            //         lead_values = []
            //         for field in pls_fields + ['probability']:  # add probability as used in _pls_prepare_frequencies (needed in rebuild mode)
            //             value = lead[field]
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             if value or field == 'probability':  # 0 is a correct value for probability
            //                 lead_values.append((field, value))
            //             elif field in ('email_state', 'phone_state'):  # As ORM reads 'None' as 'False', do the same here
            //                 lead_values.append((field, False))
            //             leads_values_dict[lead['id']] = {'values': lead_values, 'team_id': lead['team_id'] or 0}
            // 
            //     for tag in tag_results:
            //         if tag['tag_id']:
            //             leads_values_dict[tag['lead_id']]['values'].append(('tag_id', tag['tag_id']))
            //     return leads_values_dict
            // else:
            //     for lead in self:
            //         lead_values = []
            //         for field in pls_fields:
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             value = lead[field].id if isinstance(lead[field], models.BaseModel) else lead[field]
            //             if value or field in ('email_state', 'phone_state'):
            //                 lead_values.append((field, value))
            //         if use_tags:
            //             for tag in lead.tag_ids:
            //                 lead_values.append(('tag_id', tag.id))
            //         leads_values_dict[lead.id] = {'values': lead_values, 'team_id': lead['team_id'].id}
            //     return leads_values_dict
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode, object is_tooltip) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False, is_tooltip=False):
            // """
            // In machine learning, naive Bayes classifiers (NBC) are a family of simple "probabilistic classifiers" based on
            // applying Bayes theorem with strong (naive) independence assumptions between the variables taken into account.
            // E.g: will TDE eat m&m's depending on his sleep status, the amount of work he has and the fullness of his stomach?
            // As we use experience to compute the statistics, every day, we will register the variables state + the result.
            // As the days pass, we will be able to determine, with more and more precision, if TDE will eat m&m's
            // for a specific combination :
            //     - did sleep very well, a lot of work and stomach full > Will never happen !
            //     - didn't sleep at all, no work at all and empty stomach > for sure !
            // Following Bayes' Theorem: the probability that an event occurs (to win) under certain conditions is proportional
            // to the probability to win under each condition separately and the probability to win. We compute a 'Win score'
            // -> P(Won | A∩B) ∝ P(A∩B | Won)*P(Won) OR S(Won | A∩B) = P(A∩B | Won)*P(Won)
            // To compute a percentage of probability to win, we also compute the 'Lost score' that is proportional to the
            // probability to lose under each condition separately and the probability to lose.
            // -> Probability =  S(Won | A∩B) / ( S(Won | A∩B) + S(Lost | A∩B) )
            // See https://www.youtube.com/watch?v=CPqOCI0ahss can help to get a quick and simple example.
            // One issue about NBC is when a event occurence is never observed.
            // E.g: if when TDE has an empty stomach, he always eat m&m's, than the "not eating m&m's when empty stomach' event
            // will never be observed.
            // This is called 'zero frequency' and that leads to division (or at least multiplication) by zero.
            // To avoid this, we add 0.1 in each frequency. With few data, the computation is than not really realistic.
            // The more we have records to analyse, the more the estimation will be precise.
            // 
            // :param bool is_tooltip: If true, method recomputes the probability of self, that should be a singleton, and
            //     also returns a dict containing probability, and a list of all (score, field, value) triplets for all value of
            //     PLS fields that impact the computation of the probability. Score is a simple value that indicates whether the
            //     impact is positive (>.5) or negative (<.5). See method prepare_pls_tooltip_data, or test_pls_tooltip_data for
            //     more details
            // 
            // :return: probability in percent (and rounded at 2 decimals) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Initialize tooltip data. A returned 0.00 probability means computation was not possible.
            // tooltip_data = {}
            // if is_tooltip:
            //     self.ensure_one()
            //     tooltip_data = {
            //         'probability': 0.0,
            //         'scores': [],
            //     }
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         ('active', '=', True),
            //         ('id', 'in', self.ids),
            //         ('won_status', '=', 'pending'),
            //     ]
            // leads_values_dict = self._pls_get_lead_pls_values(domain=domain)
            // 
            // if not leads_values_dict:
            //     return lead_probabilities
            // 
            // # Get unique couples to search in frequency table and won leads.
            // leads_fields = set()  # keep unique fields, as a lead can have multiple tag_ids
            // won_leads = set()
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead_id, values in leads_values_dict.items():
            //     for field, value in values['values']:
            //         if field == 'stage_id' and value in won_stage_ids:
            //             won_leads.add(lead_id)
            //         leads_fields.add(field)
            // leads_fields = sorted(leads_fields)
            // # get all variable related records from frequency table, no matter the team_id
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('variable', 'in', list(leads_fields))], order="team_id asc, id")
            // 
            // # get all team_ids from frequencies
            // frequency_teams = frequencies.mapped('team_id')
            // frequency_team_ids = [team.id for team in frequency_teams]
            // 
            // # restrict to frequencies of lead team if any exist.
            // if is_tooltip and self.team_id & frequency_teams:
            //     frequency_team_ids = [self.team_id.id]
            //     frequencies = frequencies.filtered(
            //         lambda frequency: frequency.team_id & self.team_id
            //     )
            // 
            // # 1. Compute each variable value count individually
            // # regroup each variable to be able to compute their own probabilities
            // # As all the variable does not enter into account (as we reject unset values in the process)
            // # each value probability must be computed only with their own variable related total count
            // # special case: for lead for which team_id is not in frequency table or lead with no team_id,
            // # we consider all the records, independently from team_id (this is why we add a result[-1])
            // result = dict((team_id, dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)) for team_id in frequency_team_ids)
            // result[-1] = dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)
            // for frequency in frequencies:
            //     field = frequency['variable']
            //     value = frequency['value']  # This is always a string
            // 
            //     # To avoid that a tag take too much importance if its subset is too small,
            //     # we ignore the tag frequencies if we have less than 50 won or lost for this tag.
            //     if field == 'tag_id' and (frequency['won_count'] + frequency['lost_count']) < 50:
            //         continue
            // 
            //     if frequency.team_id:
            //         team_result = result[frequency.team_id.id]
            //         team_result[field][value] = {'won': frequency['won_count'], 'lost': frequency['lost_count']}
            //         team_result[field]['won_total'] += frequency['won_count']
            //         team_result[field]['lost_total'] += frequency['lost_count']
            // 
            //     if value not in result[-1][field]:
            //         result[-1][field][value] = {'won': 0, 'lost': 0}
            //     result[-1][field][value]['won'] += frequency['won_count']
            //     result[-1][field][value]['lost'] += frequency['lost_count']
            //     result[-1][field]['won_total'] += frequency['won_count']
            //     result[-1][field]['lost_total'] += frequency['lost_count']
            // 
            // # Get all won, lost and total count for all records in frequencies per team_id
            // for team_id in result:
            //     result[team_id]['team_won'], \
            //     result[team_id]['team_lost'], \
            //     result[team_id]['team_total'] = self._pls_get_won_lost_total_count(result[team_id])
            // 
            // save_team_id = None
            // p_won, p_lost = 1, 1
            // for lead_id, lead_values in leads_values_dict.items():
            //     # if stage_id is null, return 0 and bypass computation
            //     lead_fields = [value[0] for value in lead_values.get('values', [])]
            //     if not 'stage_id' in lead_fields:
            //         lead_probabilities[lead_id] = 0
            //         continue
            //     # if lead stage is won, return 100
            //     elif lead_id in won_leads:
            //         lead_probabilities[lead_id] = 100
            //         continue
            // 
            //     # team_id not in frequency Table -> convert to -1
            //     lead_team_id = lead_values['team_id'] if lead_values['team_id'] in result else -1
            //     if lead_team_id != save_team_id:
            //         save_team_id = lead_team_id
            //         team_won = result[save_team_id]['team_won']
            //         team_lost = result[save_team_id]['team_lost']
            //         team_total = result[save_team_id]['team_total']
            //         # if one count = 0, we cannot compute lead probability
            //         if not team_won or not team_lost:
            //             continue
            //         p_won = team_won / team_total
            //         p_lost = team_lost / team_total
            // 
            //     # 2. Compute won and lost score using each variable's individual probability
            //     s_lead_won, s_lead_lost = p_won, p_lost
            //     for field, value in lead_values['values']:
            //         field_result = result.get(save_team_id, {}).get(field)
            //         value = value.origin if hasattr(value, 'origin') else value
            //         value_result = field_result.get(str(value)) if field_result else False
            //         if value_result:
            //             total_won = team_won if field == 'stage_id' else field_result['won_total']
            //             total_lost = team_lost if field == 'stage_id' else field_result['lost_total']
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             p_field_value_won = value_result['won'] / total_won
            //             p_field_value_lost = value_result['lost'] / total_lost
            //             s_lead_won *= p_field_value_won
            //             s_lead_lost *= p_field_value_lost
            // 
            //             if is_tooltip:
            //                 score = (
            //                     1 - p_field_value_lost if field == 'stage_id'
            //                     else p_field_value_won / (p_field_value_won + p_field_value_lost)
            //                 )
            //                 tooltip_data['scores'].append((score, field, value))
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // 
            // if tooltip_data and self.id in lead_probabilities:
            //     tooltip_data['probability'] = lead_probabilities[self.id]
            // 
            // return lead_probabilities, tooltip_data
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_fields(self):
            // """ As config_parameters does not accept M2M field,
            //     we the fields from the formated string stored into the Char config field.
            //     To avoid sql injections when using that list, we return only the fields
            //     that are defined on the model. """
            // pls_fields_config = self.env['ir.config_parameter'].sudo().get_param('crm.pls_fields')
            // pls_fields = pls_fields_config.split(',') if pls_fields_config else []
            // pls_safe_fields = [field for field in pls_fields if field in self._fields.keys()]
            // return pls_safe_fields
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_start_date(self):
            // """ As config_parameters does not accept Date field,
            //     we get directly the date formated string stored into the Char config field,
            //     as we directly use this string in the sql queries.
            //     To avoid sql injections when using this config param,
            //     we ensure the date string can be effectively a date."""
            // str_date = self.env['ir.config_parameter'].sudo().get_param('crm.pls_start_date')
            // if not fields.Date.to_date(str_date):
            //     return False
            // return str_date
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_won_lost_total_count(self, team_results):
            // """ Get all won and all lost + total :
            //        first stage can be used to know how many lost and won there is
            //        as won count are equals for all stage
            //        and first stage is always incremented in lost_count
            // :param team_results:
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_ids', '=', False)], order='sequence, id', limit=1)
            // if str(first_stage_id.id) not in team_results.get('stage_id', []):
            //     return 0, 0, 0
            // stage_result = team_results['stage_id'][str(first_stage_id.id)]
            // return stage_result['won'], stage_result['lost'], stage_result['won'] + stage_result['lost']
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequencies(self, from_state=None, to_state=None):
            // """
            // When losing or winning a lead, this method is called to increment each PLS parameter related to the lead
            // in won_count (if won) or in lost_count (if lost).
            // 
            // This method is also used when reactivating a mistakenly lost lead (using the decrement argument).
            // In this case, the lost count should be de-increment by 1 for each PLS parameter linked to the lead.
            // 
            // Live increment must be done before writing the new values because we need to know the state change (from and to).
            // This would not be an issue for the reach won or reach lost as we just need to increment the frequencies with the
            // final state of the lead.
            // This issue is when the lead leaves a closed state because once the new values have been writen, we do not know
            // what was the previous state that we need to decrement.
            // This is why 'is_won' and 'decrement' parameters are used to describe the from / to change of its state.
            // """
            // new_frequencies_by_team, existing_frequencies_by_team = self._pls_prepare_update_frequency_table(target_state=from_state or to_state)
            // 
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1 if to_state else -1,
            //                                  existing_frequencies_by_team=existing_frequencies_by_team)
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequency_dict(self, frequencies, field, value, won, lost):
            // value = str(value)  # Ensure we will always compare strings.
            // if value not in frequencies[field]:
            //     frequencies[field][value] = {'won': won, 'lost': lost}
            // else:
            //     frequencies[field][value]['won'] += won
            //     frequencies[field][value]['lost'] += lost
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_frequencies(self, lead_values, leads_pls_fields, target_state=None):
            // """new state is used when getting frequencies for leads that are changing to lost or won.
            // Stays none if we are checking frequencies for leads already won or lost."""
            // pls_fields = leads_pls_fields.copy()
            // frequencies = dict((field, {}) for field in pls_fields)
            // 
            // stage_ids = self.env['crm.stage'].search_read([], ['sequence', 'name', 'id'], order='sequence, id')
            // stage_sequences = {stage['id']: stage['sequence'] for stage in stage_ids}
            // 
            // # Increment won / lost frequencies by criteria (field / value couple)
            // for values in lead_values:
            //     if target_state:  # ignore probability values if target state (as probability is the old value)
            //         won_count = values['count'] if target_state == 'won' else 0
            //         lost_count = values['count'] if target_state == 'lost' else 0
            //     else:
            //         won_count = values['count'] if values.get('probability', 0) == 100 else 0
            //         lost_count = values['count'] if values.get('probability', 1) == 0  else 0
            // 
            //     if 'tag_id' in values:
            //         frequencies = self._pls_increment_frequency_dict(frequencies, 'tag_id', values['tag_id'], won_count, lost_count)
            //         continue
            // 
            //     # Else, treat other fields
            //     if 'tag_id' in pls_fields:  # tag_id already treated here above.
            //         pls_fields.remove('tag_id')
            //     for field in pls_fields:
            //         if field not in values:
            //             continue
            //         value = values[field]
            //         if value or field in ('email_state', 'phone_state'):
            //             if field == 'stage_id':
            //                 if won_count:  # increment all stages if won
            //                     stages_to_increment = [stage['id'] for stage in stage_ids]
            //                 else:  # increment only current + previous stages if lost
            //                     current_stage_sequence = stage_sequences[value]
            //                     stages_to_increment = [stage['id'] for stage in stage_ids if stage['sequence'] <= current_stage_sequence]
            //                 for stage_id in stages_to_increment:
            //                     frequencies = self._pls_increment_frequency_dict(frequencies, field, stage_id, won_count, lost_count)
            //             else:
            //                 frequencies = self._pls_increment_frequency_dict(frequencies, field, value, won_count, lost_count)
            // 
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_update_frequency_table(self, rebuild=False, target_state=False):
            // """
            // This method is common to Live Increment or Full Rebuild mode, as it shares the main steps.
            // This method will prepare the frequency dict needed to update the frequency table:
            //     - New frequencies: frequencies that we need to add in the frequency table.
            //     - Existing frequencies: frequencies that are already in the frequency table.
            // In rebuild mode, only the new frequencies are needed as existing frequencies are truncated.
            // For each team, each dict contains the frequency in won and lost for each field/value couple
            // of the target leads.
            // Target leads are :
            //     - in Live increment mode : given ongoing leads (self)
            //     - in Full rebuild mode : all the closed (won and lost) leads in the DB.
            // During the frequencies update, with both new and existing frequencies, we can split frequencies to update
            // and frequencies to add. If a field/value couple already exists in the frequency table, we just update it.
            // Otherwise, we need to insert a new one.
            // """
            // # Keep eligible leads
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return {}, {}
            // 
            // if rebuild:  # rebuild will treat every closed lead in DB, increment will treat current ongoing leads
            //     pls_leads = self
            // else:
            //     # Only treat leads created after the PLS start Date
            //     pls_leads = self.filtered(
            //         lambda lead: fields.Date.to_date(pls_start_date) <= fields.Date.to_date(lead.create_date))
            //     if not pls_leads:
            //         return {}, {}
            // 
            // # Extract target leads values
            // if rebuild:  # rebuild is ok
            //     domain = [
            //         ('create_date', '>=', pls_start_date),
            //         ('won_status', 'in', ['lost', 'won']),
            //       ]
            //     team_ids = self.env['crm.team'].with_context(active_test=False).search([]).ids + [0]  # If team_id is unset, consider it as team 0
            // else:  # increment
            //     domain = [('id', 'in', pls_leads.ids)]
            //     team_ids = pls_leads.mapped('team_id').ids + [0]
            // 
            // leads_values_dict = pls_leads._pls_get_lead_pls_values(domain=domain)
            // 
            // # split leads values by team_id
            // # get current frequencies related to the target leads
            // leads_frequency_values_by_team = dict((team_id, []) for team_id in team_ids)
            // leads_pls_fields = set()  # ensure to keep each field unique (can have multiple tag_id leads_values_dict)
            // for values in leads_values_dict.values():
            //     team_id = values.get('team_id', 0)  # If team_id is unset, consider it as team 0
            //     lead_frequency_values = {'count': 1}
            //     for field, value in values['values']:
            //         if field != "probability":  # was added to lead values in batch mode to know won/lost state, but is not a pls fields.
            //             leads_pls_fields.add(field)
            //         else:  # extract lead probability - needed to increment tag_id frequency. (proba always before tag_id)
            //             lead_probability = value
            //         if field == 'tag_id':  # handle tag_id separatelly (as in One Shot rebuild mode)
            //             leads_frequency_values_by_team[team_id].append({field: value, 'count': 1, 'probability': lead_probability})
            //         else:
            //             lead_frequency_values[field] = value
            //     leads_frequency_values_by_team[team_id].append(lead_frequency_values)
            // leads_pls_fields = sorted(leads_pls_fields)
            // 
            // # get new frequencies
            // new_frequencies_by_team = {}
            // for team_id in team_ids:
            //     # prepare fields and tag values for leads by team
            //     new_frequencies_by_team[team_id] = self._pls_prepare_frequencies(
            //         leads_frequency_values_by_team[team_id], leads_pls_fields, target_state=target_state)
            // 
            // # get existing frequencies
            // existing_frequencies_by_team = {}
            // if not rebuild:  # there is no existing frequency in rebuild mode as they were all deleted.
            //     # read all fields to get everything in memory in one query (instead of having query + prefetch)
            //     existing_frequencies = self.env['crm.lead.scoring.frequency'].search_read(
            //         ['&', ('variable', 'in', leads_pls_fields),
            //               '|', ('team_id', 'in', pls_leads.mapped('team_id').ids), ('team_id', '=', False)])
            //     for frequency in existing_frequencies:
            //         team_id = frequency['team_id'][0] if frequency.get('team_id') else 0
            //         if team_id not in existing_frequencies_by_team:
            //             existing_frequencies_by_team[team_id] = dict((field, {}) for field in leads_pls_fields)
            // 
            //         existing_frequencies_by_team[team_id][frequency['variable']][frequency['value']] = {
            //             'frequency_id': frequency['id'],
            //             'won': frequency['won_count'],
            //             'lost': frequency['lost_count']
            //         }
            // 
            // return new_frequencies_by_team, existing_frequencies_by_team
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_update_frequency_table(self, new_frequencies_by_team, step, existing_frequencies_by_team=None):
            // """ Create / update the frequency table in a cross company way, per team_id"""
            // values_to_update = {}
            // values_to_create = []
            // if not existing_frequencies_by_team:
            //     existing_frequencies_by_team = {}
            // # build the create multi + frequencies to update
            // for team_id, new_frequencies in new_frequencies_by_team.items():
            //     for field, value in new_frequencies.items():
            //         # frequency already present ?
            //         current_frequencies = existing_frequencies_by_team.get(team_id, {})
            //         for param, result in value.items():
            //             current_frequency_for_couple = current_frequencies.get(field, {}).get(param, {})
            //             # If frequency already present : UPDATE IT
            //             if current_frequency_for_couple:
            //                 new_won = current_frequency_for_couple['won'] + (result['won'] * step)
            //                 new_lost = current_frequency_for_couple['lost'] + (result['lost'] * step)
            //                 # ensure to have always positive frequencies
            //                 values_to_update[current_frequency_for_couple['frequency_id']] = {
            //                     'won_count': new_won if new_won > 0 else 0.1,
            //                     'lost_count': new_lost if new_lost > 0 else 0.1
            //                 }
            //                 continue
            // 
            //             # Else, CREATE a new frequency record.
            //             # We add + 0.1 in won and lost counts to avoid zero frequency issues
            //             # should be +1 but it weights too much on small recordset.
            //             values_to_create.append({
            //                 'variable': field,
            //                 'value': param,
            //                 'won_count': result['won'] + 0.1,
            //                 'lost_count': result['lost'] + 0.1,
            //                 'team_id': team_id if team_id else None  # team_id = 0 means no team_id
            //             })
            // 
            // LeadScoringFrequency = self.env['crm.lead.scoring.frequency'].sudo()
            // for frequency_id, values in values_to_update.items():
            //     LeadScoringFrequency.browse(frequency_id).write(values)
            // 
            // if values_to_create:
            //     LeadScoringFrequency.create(values_to_create)
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _populate_missing_personal_stages(self):
            // # Assign the default personal stage for those that are missing
            // personal_stages_without_stage = self.env['project.task.stage.personal'].sudo().search([('task_id', 'in', self.ids), ('stage_id', '=', False)])
            // if personal_stages_without_stage:
            //     user_ids = personal_stages_without_stage.user_id
            //     personal_stage_by_user = defaultdict(lambda: self.env['project.task.stage.personal'])
            //     for personal_stage in personal_stages_without_stage:
            //         personal_stage_by_user[personal_stage.user_id] |= personal_stage
            //     for user_id in user_ids:
            //         stage = self.env['project.task.type'].sudo().search([('user_id', '=', user_id.id)], limit=1)
            //         # In the case no stages have been found, we create the default stages for the user
            //         if not stage:
            //             stages = self.env['project.task.type'].sudo().with_context(lang=user_id.partner_id.lang, default_project_ids=False).create(
            //                 self.with_context(lang=user_id.partner_id.lang)._get_default_personal_stage_create_vals(user_id.id)
            //             )
            //             stage = stages[0]
            //         personal_stage_by_user[user_id].sudo().write({'stage_id': stage.id})
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_accessible_fields(self) -> tuple[frozenset[str], frozenset[str]]:
            // """Readable and writable fields by portal users."""
            // readable = frozenset(self.TASK_PORTAL_READABLE_FIELDS)
            // writeable = frozenset(self.TASK_PORTAL_WRITABLE_FIELDS)
            // return readable | writeable, writeable
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_get_parent_hash_token(self, pid):
            // return self.project_id._sign_token(pid)
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_address_values_from_partner(self, partner):
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // if any(partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC):
            //     values = {f: partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // else:
            //     values = {f: self[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // return values
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_contact_name_from_partner(self, partner):
            // contact_name = False if partner.is_company else partner.name
            // return {'contact_name': contact_name or self.contact_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // """ Extract data from lead to create a partner.
            // 
            // :param partner_name : future name of the partner
            // :param is_company : True if the partner is a company
            // :param parent_id : id of the parent partner (False if no parent)
            // 
            // :return: dictionary of values to give at res_partner.create()
            // """
            // email_parts = tools.email_split(self.email_from)
            // res = {
            //     'name': partner_name,
            //     'user_id': self.env.context.get('default_user_id') or self.user_id.id,
            //     'comment': self.description,
            //     'phone': self.phone,
            //     'email': email_parts[0] if email_parts else False,
            //     'function': self.function,
            //     # address
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     # company / hierarchy
            //     'parent_id': parent_id,
            //     'is_company': is_company,
            //     'company_name': not is_company and not parent_id and self.partner_name,
            //     'type': 'contact'
            // }
            // if self.lang_id.active:
            //     res['lang'] = self.lang_id.code
            // return res
            */
            return default;
        }

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_partner_name_from_partner(self, partner):
            // """ Company name: name of partner parent (if set) or name of partner
            // (if company) or company_name of partner (if not a company). """
            // partner_name = partner.parent_id.name
            // if not partner_name and partner.is_company:
            //     partner_name = partner.name
            // elif not partner_name and partner.company_name:
            //     partner_name = partner.company_name
            // return {'partner_name': partner_name or self.partner_name}
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _prepare_pattern_groups(self):
            // group = self._get_group_pattern()
            // return [
            //     group['tags_and_users'] % '',
            //     group['priority'],
            // ]
            */
            return default;
        }

        public async Task<TEntity> PreparePlsTooltipDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def prepare_pls_tooltip_data(self):
            // """
            // Compute and return all necessary information to render CrmPlsTooltip, displayed when
            // pressing the small AI button, located next to the label of probability when automated,
            // in the crm.lead form view. This method first replaces ids with display names of relational
            // fields before returning data, then also recomputes probabilities and writes them on self.
            // 
            // :returns:
            // 
            //     ::
            //         {
            //             low_3_data: list of field-value couples for lowest 3 criterions, lowest first
            //             probability: numerical value, used for display on tooltip
            //             team_name: string, name of lead team if any
            //             top_3_data: list of field-value couples for top 3 criterions, highest first
            //         }
            // 
            // :rtype: dict
            // """
            // self.ensure_one()
            // _unused, tooltip_data = self._pls_get_naive_bayes_probabilities(is_tooltip=True)
            // sorted_scores_with_name = []
            // 
            // # We want to display names in the tooltip, not ids.
            // # The last element in tuple is only used for tags to ensure same color in tooltip.
            // for score, field, value in sorted(tooltip_data['scores']):
            //     # Skip nonsense results for phone and email states. May happen in a db having a few leads.
            //     if field in ['phone_state', 'email_state']:
            //         if value in [False, 'incorrect'] and tools.float_compare(score, 0.50, 2) > 0:
            //             continue
            //         if value == 'correct' and tools.float_compare(score, 0.50, 2) < 0:
            //             continue
            //     if field == 'tag_id':
            //         tag = self.tag_ids.filtered(lambda tag: tag.id == value)
            //         sorted_scores_with_name.append((score, field, tag.display_name, tag.color))
            //     elif isinstance(self[field], models.BaseModel):
            //         sorted_scores_with_name.append((score, field, self[field].display_name, False))
            //     else:
            //         sorted_scores_with_name.append((score, field, str(value), False))
            // 
            // # Update automated probability, as it may have changed since last computation
            // # -> avoids differences in display between tooltip and record. A 0.00 probability implies
            // # that the computation was not possible. Sample data will be used instead.
            // probability_values = {'automated_probability': tooltip_data['probability']}
            // if self.is_automated_probability:
            //     probability_values['probability'] = tooltip_data['probability']
            // self.write(probability_values)
            // 
            // # Sample values if probability could not be computed. If it was, but if all scores
            // # were excluded above, a placeholder will be used instead in the tooltip.
            // if tools.float_is_zero(tooltip_data['probability'], 2):
            //     sorted_scores_with_name = [
            //         (.1, 'email_state', False, False),
            //         (.2, 'tag_id', _('Exploration'), 4),
            //         (.3, 'stage_id', _('New'), False),
            //         (.7, 'phone_state', 'correct', False),
            //         (.8, 'country_id', _('Belgium'), False),
            //         (.9, 'tag_id', _('Consulting'), 3),
            //     ]
            // 
            // return {
            //     'low_3_data': [
            //         {
            //             'field': element[1],
            //             'value': element[2],
            //             'color': element[3]
            //         } for element in sorted_scores_with_name[:3] if tools.float_compare(element[0], 0.50, 2) < 0
            //     ],
            //     'probability': tooltip_data['probability'],
            //     'team_name': self.team_id.display_name,
            //     'top_3_data': [
            //         {
            //             'field': element[1],
            //             'value': element[2],
            //             'color': element[3]
            //         } for element in sorted_scores_with_name[::-1][:3] if tools.float_compare(element[0], 0.50, 2) > 0
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_values_from_partner(self, partner):
            // """ Get a dictionary with values coming from partner information to
            // copy on a lead. Non-address fields get the current lead
            // values to avoid being reset if partner has no value for them. """
            // 
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // values = self._prepare_address_values_from_partner(partner)
            // 
            // # For other fields, get the info from the partner, but only if set
            // values.update({f: partner[f] or self[f] for f in PARTNER_FIELDS_TO_SYNC if f != 'lang'})
            // if partner.lang:
            //     values['lang_id'] = self.env['res.lang']._get_data(code=partner.lang).id
            // 
            // # Fields with specific logic
            // values.update(self._prepare_contact_name_from_partner(partner))
            // values.update(self._prepare_partner_name_from_partner(partner))
            // 
            // return self._convert_to_write(values)
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def project_sharing_toggle_is_follower(self):
            // self.ensure_one()
            // self.check_access('write')
            // is_follower = self.message_is_follower
            // if is_follower:
            //     self.sudo().message_unsubscribe(self.env.user.partner_id.ids)
            // else:
            //     self.sudo().message_subscribe(self.env.user.partner_id.ids)
            // return not is_follower
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def project_update_all_action(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_update_all_action')
            // action['display_name'] = _("%(name)s Dashboard", name=self.name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def rating_apply(self, rate, token=None, rating=None, feedback=None,
            //              subtype_xmlid=None, notify_delay_send=False):
            // rating = super().rating_apply(
            //     rate, token=token, rating=rating, feedback=feedback,
            //     subtype_xmlid=subtype_xmlid, notify_delay_send=notify_delay_send)
            // if self.stage_id and self.stage_id.auto_validation_state:
            //     state = '03_approved' if rating.rating >= rating_data.RATING_LIMIT_SATISFIED else '02_changes_requested'
            //     self.write({'state': state})
            // return rating
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_apply_get_default_subtype_id(self):
            // return self.env['ir.model.data']._xmlid_to_res_id("project.mt_task_rating")
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_operator(self):
            // """ Overwrite since we have user_ids and not user_id """
            // tasks_with_one_user = self.filtered(lambda task: len(task.user_ids) == 1 and task.user_ids.partner_id)
            // return tasks_with_one_user.user_ids.partner_id or self.env['res.partner']
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'project_id'
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_partner(self):
            // res = super()._rating_get_partner()
            // if not res and self.project_id.partner_id:
            //     return self.project_id.partner_id
            // return res
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group(self, domain, groupby=(), aggregates=(), having=(), offset=0, limit=None, order=None) -> list[tuple]:
            // # A _read_group cannot be performed if records are grouped by personal_stage_type_id
            // # as it is a computed field. personal_stage_type_ids behaves like a M2O from the point
            // # of view of the user, we therefore use this field instead.
            // if 'personal_stage_type_id' in groupby:
            //     # limitation: problem when both personal_stage_type_id and personal_stage_type_ids
            //     # appear in read_group, but this has no functional utility
            //     groupby = ['personal_stage_type_ids' if fname == 'personal_stage_type_id' else fname for fname in groupby]
            //     if order:
            //         order = order.replace('personal_stage_type_id', 'personal_stage_type_ids')
            // return super()._read_group(domain, groupby, aggregates, having, offset, limit, order)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_personal_stage_type_ids(self, stages, domain):
            // return stages.search(['|', ('id', 'in', stages.ids), ('user_id', '=', self.env.user.id)])
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self.env.context.get('default_team_id')
            // team_ids = self.env.user.crm_team_ids._ids if self.env.context.get('show_user_team_stages') else ()
            // team_ids += (team_id,) if team_id else ()
            // search_domain = ['|', ('id', 'in', stages.ids), ('team_ids', '=', False)]
            // if team_ids:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_ids', '=', False), ('team_ids', 'in', team_ids)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve job_id from the context and write the domain: ids + contextual columns (job or default)
            // job_id = self.env.context.get('default_job_id')
            // search_domain = [('job_ids', '=', False)]
            // if job_id:
            //     search_domain = ['|', ('job_ids', '=', job_id)] + search_domain
            // if stages:
            //     search_domain = ['|', ('id', 'in', stages.ids)] + search_domain
            // 
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // search_domain = [('id', 'in', stages.ids)]
            // if 'default_project_id' in self.env.context and not self.env.context.get(
            //         'subtask_action') and 'project_kanban' in self.env.context:
            //     search_domain = ['|', ('project_ids', '=', self.env.context['default_project_id'])] + search_domain
            // 
            // stage_ids = stages._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _rebuild_pls_frequency_table(self):
            // # Clear the frequencies table (in sql to speed up the cron)
            // try:
            //     self.browse().check_access('unlink')
            // except AccessError:
            //     raise UserError(_("You don't have the access needed to run this cron."))
            // else:
            //     self.env.cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def redirect_lead_opportunity_view(self):
            // self.ensure_one()
            // return {
            //     'name': _('Lead or Opportunity'),
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'domain': [('type', '=', self.type)],
            //     'res_id': self.id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_type': self.type}
            // }
            */
            return default;
        }

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def reset_applicant(self):
            // """ Reinsert the applicant into the recruitment pipe in the first stage"""
            // default_stage = dict()
            // for job_id in self.mapped('job_id'):
            //     default_stage[job_id.id] = self.env['hr.recruitment.stage'].search(
            //         [
            //             '|',
            //             ('job_ids', '=', False),
            //             ('job_ids', '=', job_id.id),
            //             ('fold', '=', False)
            //         ], order='sequence asc', limit=1).id
            // for applicant in self:
            //     applicant.write(
            //         {'stage_id': applicant.job_id.id and default_stage[applicant.job_id.id],
            //          'refuse_reason_id': False})
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _resolve_copied_dependencies(self, copied_tasks):
            // task_mapping, task_dependencies = self._create_task_mapping(copied_tasks)
            // 
            // for original_task_id, (depend_on_ids, dependant_ids) in task_dependencies.items():
            //     # If one of the task_id in the dependencies mapping is also a key of the task_mapping, it means that this task was copied too.
            //     # In this case, we should exchange this id with the id of the corresponding copied task
            //     task_mapping[original_task_id].depend_on_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in depend_on_ids
            //     ]
            //     task_mapping[original_task_id].dependent_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in dependant_ids
            //     ]
            */
            return default;
        }

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_application_status(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domains = []
            // # Map statuses to domain filters
            // if 'refused' in value:
            //     domains.append([('active', '=', True), ('refuse_reason_id', '!=', None)])
            // if 'hired' in value:
            //     domains.append([('active', '=', True), ('date_closed', '!=', False)])
            // if 'archived' in value or False in value:
            //     domains.append([('active', '=', False)])
            // if 'ongoing' in value:
            //     domains.append([('active', '=', True), ('date_closed', '=', False)])
            // 
            // return Domain.OR(domains)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
            // """ Override to support ordering on my_activity_date_deadline.
            // 
            // Ordering through web client calls search_read() with an order parameter
            // set. Method search_read() then calls search_fetch(). Here we override
            // search_fetch() to intercept a search with an order on field
            // my_activity_date_deadline. In that case we do the search in two steps.
            // 
            // First step: fill with deadline-based results
            // 
            //   * Perform a read_group on my activities to get a mapping lead_id / deadline
            //     Remember date_deadline is required, we always have a value for it. Only
            //     the earliest deadline per lead is kept.
            //   * Search leads linked to those activities that also match the asked domain
            //     and order from the original search request.
            //   * Results of that search will be at the top of returned results. Use limit
            //     None because we have to search all leads linked to activities as ordering
            //     on deadline is done in post processing.
            //   * Reorder them according to deadline asc or desc depending on original
            //     search ordering. Finally take only a subset of those leads to fill with
            //     results matching asked offset / limit.
            // 
            // Second step: fill with other results. If first step does not gives results
            // enough to match offset and limit parameters we fill with a search on other
            // leads. We keep the asked domain and ordering while filtering out already
            // scanned leads to keep a coherent results.
            // 
            // All other search and search_read are left untouched by this override to avoid
            // side effects. Search_count is not affected by this override.
            // """
            // if not order or 'my_activity_date_deadline' not in order:
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // order_items = [order_item.strip().lower() for order_item in (order or self._order).split(',')]
            // domain = Domain(domain)
            // 
            // # Perform a read_group on my activities to get a mapping lead_id / deadline
            // # Remember date_deadline is required, we always have a value for it. Only
            // # the earliest deadline per lead is kept.
            // activity_asc = any('my_activity_date_deadline asc' in item for item in order_items)
            // my_lead_activities = self.env['mail.activity']._read_group(
            //     [('res_model', '=', self._name), ('user_id', '=', self.env.uid)],
            //     ['res_id'],
            //     ['date_deadline:min'],
            //     order='date_deadline:min ASC, res_id',
            // )
            // my_lead_mapping = dict(my_lead_activities)
            // my_lead_ids = list(my_lead_mapping.keys())
            // my_lead_domain = Domain('id', 'in', my_lead_ids) & domain
            // my_lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // # Search leads linked to those activities and order them. See docstring
            // # of this method for more details.
            // search_res = super().search_fetch(my_lead_domain, field_names, order=my_lead_order)
            // my_lead_ids_ordered = sorted(search_res.ids, key=lambda lead_id: my_lead_mapping[lead_id], reverse=not activity_asc)
            // # keep only requested window (offset + limit, or offset+)
            // my_lead_ids_keep = my_lead_ids_ordered[offset:(offset + limit)] if limit else my_lead_ids_ordered[offset:]
            // # keep list of already skipped lead ids to exclude them from future search
            // my_lead_ids_skip = my_lead_ids_ordered[:(offset + limit)] if limit else my_lead_ids_ordered
            // 
            // # do not go further if limit is achieved
            // if limit and len(my_lead_ids_keep) >= limit:
            //     return self.browse(my_lead_ids_keep)
            // 
            // # Fill with remaining leads. If a limit is given, simply remove count of
            // # already fetched. Otherwise keep none. If an offset is set we have to
            // # reduce it by already fetch results hereabove. Order is updated to exclude
            // # my_activity_date_deadline when calling super() .
            // lead_limit = (limit - len(my_lead_ids_keep)) if limit else None
            // if offset:
            //     lead_offset = max((offset - len(search_res), 0))
            // else:
            //     lead_offset = 0
            // lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // other_lead_res = super().search_fetch(
            //     Domain('id', 'not in', my_lead_ids_skip) & domain,
            //     field_names, lead_offset, lead_limit, lead_order,
            // )
            // return self.browse(my_lead_ids_keep) + other_lead_res
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_has_late_and_unreached_milestone(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [
            //     ('allow_milestones', '=', True),
            //     ('milestone_id', 'any', [
            //         ('is_reached', '=', False),
            //         ('deadline', '<', fields.Date.today()),
            //     ]),
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_has_template_ancestor(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     return NotImplemented
            // template_tasks = self.env['project.task'].with_context(active_test=False).sudo().search([('is_template', '=', True)])
            // domain = [('id', 'child_of', template_tasks.ids)]
            // if (operator == "=") != value:
            //     domain = ['!', ('id', 'child_of', template_tasks.ids)]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_is_applicant_in_pool(self, operator, value):
            // """
            // This function is needed to hide duplicates when adding applicants/talents to a talent pool.
            // All applications that have either talent_pool_ids or pool_applicant_id set are considered
            // directly in a pool. Furthermore, any application with the same phone number, email or linkedin
            // as the first applications, that are directly in the pool, are also considered to belong to
            // the same talent pool.
            // 
            // Returns:
            //     returns a domain with ids of applications that are either directly or indirectly linked to a pool
            // """
            // if operator != 'in':
            //     return NotImplemented
            // 
            // return [('id', 'in', SQL("""
            //         WITH talent_pool_applicants AS (
            //             SELECT
            //                    a.id as id,
            //                    email_normalized,
            //                    partner_phone_sanitized,
            //                    linkedin_profile
            //               FROM hr_applicant a
            //          LEFT JOIN hr_applicant_hr_talent_pool_rel rel
            //                 ON a.id = rel.hr_applicant_id
            //              WHERE pool_applicant_id IS NOT NULL
            //                 OR hr_talent_pool_id IS NOT NULL
            //         )
            //         SELECT a.id
            //         FROM hr_applicant a
            //         WHERE
            //             -- Check if directly linked to a pool
            //             (a.id IN (
            //                 SELECT DISTINCT id
            //                 from talent_pool_applicants
            //             ))
            //             OR
            //             -- Check if email matches any talent pool applicant
            //             (a.email_normalized IN (
            //                 SELECT DISTINCT email_normalized
            //                 FROM talent_pool_applicants
            //                 WHERE email_normalized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if phone matches any talent pool applicant
            //             (a.partner_phone_sanitized IN (
            //                 SELECT DISTINCT partner_phone_sanitized
            //                 FROM talent_pool_applicants
            //                 WHERE partner_phone_sanitized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if LinkedIn profile matches any talent pool applicant
            //             (a.linkedin_profile IN (
            //                 SELECT DISTINCT linkedin_profile
            //                 FROM talent_pool_applicants
            //                 WHERE linkedin_profile IS NOT NULL
            //             ))
            // """))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_is_closed(self, operator, value):
            // if operator == 'in':
            //     searched_states = list(CLOSED_STATES.keys())
            // elif operator == 'not in':
            //     searched_states = self.OPEN_STATES
            // else:
            //     return NotImplemented
            // return [('state', 'in', searched_states)]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('favorite_user_ids', 'in', [self.env.uid])]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_milestone_exceeded(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // sql = SQL("""(
            //     SELECT P.id
            //       FROM project_project P
            //  LEFT JOIN project_milestone M ON P.id = M.project_id
            //      WHERE M.is_reached IS false
            //        AND P.allow_milestones IS true
            //        AND M.deadline <= CAST(now() AS date)
            // )""")
            // return [('id', 'any', sql)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsRottingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py) ---
            // def _search_is_rotting(self, operator, value):
            // if operator not in ['in', 'not in']:
            //     raise ValueError(self.env._('For performance reasons, use "=" operators on rotting fields.'))
            // if not self._is_rotting_feature_enabled():
            //     raise UserError(self.env._('Model configuration does not support the rotting feature'))
            // model_depends = [fname for fname in self._get_rotting_depends_fields() if '.' not in fname]
            // self.flush_model(model_depends)  # flush fields to make sure DB is up to date
            // self.env[self[self._track_duration_field]._name].flush_model(['rotting_threshold_days'])
            // base_query = self._search(self._get_rotting_domain())
            // 
            // # Our query needs to JOIN the stage field's table.
            // # This JOIN needs to use the same alias as the base query to avoid non-matching alias issues
            // # Note that query objects do not make their alias table available trivially,
            // # but the alias can be inferred by consulting the _joins attribute and compare it to the result of make_alias()
            // stage_table_alias_name = base_query.make_alias(self._table, self._track_duration_field)
            // 
            // # We only need to add a JOIN if the stage table is not already present in the query's _joins attribute.
            // from_add_join = ''
            // if not base_query._joins or not stage_table_alias_name in base_query._joins:
            //     from_add_join = """
            //         INNER JOIN %(stage_table)s AS %(stage_table_alias_name)s
            //             ON %(stage_table_alias_name)s.id = %(table)s.%(stage_field)s
            //     """
            // 
            // # Items with a date_last_stage_update inferior to that number of months will not be returned by the search function.
            // max_rotting_months = int(self.env['ir.config_parameter'].sudo().get_param('crm.lead.rot.max.months', default=12))
            // 
            // # We use a F-string so that the from_add_join is added with its %s parameters before the query string is processed
            // query = f"""
            //     WITH perishables AS (
            //         SELECT  %(table)s.id AS id,
            //                 (
            //                     %(table)s.date_last_stage_update + %(stage_table_alias_name)s.rotting_threshold_days * interval '1 day'
            //                 ) AS date_rot
            //         FROM %(from_clause)s
            //             {from_add_join}
            //         WHERE
            //             %(table)s.date_last_stage_update > %(today)s - INTERVAL '%(max_rotting_months)s months'
            //             AND %(where_clause)s
            //     )
            //     SELECT id
            //     FROM perishables
            //     WHERE %(today)s >= date_rot
            // 
            // """
            // self.env.cr.execute(SQL(query,
            //     table=SQL.identifier(self._table),
            //     stage_table=SQL.identifier(self[self._track_duration_field]._table),
            //     stage_table_alias_name=SQL.identifier(stage_table_alias_name),
            //     stage_field=SQL.identifier(self._track_duration_field),
            //     today=self.env.cr.now(),
            //     where_clause=base_query.where_clause,
            //     from_clause=base_query.from_clause,
            //     max_rotting_months=max_rotting_months,
            // ))
            // rows = self.env.cr.dictfetchall()
            // return [('id', operator, [r['id'] for r in rows])]
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_on_comodel(self, domain, field, comodel, additional_domain=None):
            // """ This method is called by `group_expand` methods, whose purpose is to add empty groups to the `read_group`
            //     (which otherwise returns groups containing records that match the domain).
            //     When specifically filtering on a comodel's field, the result of the `read_group` should contain all matching groups.
            //     However, if the search isn't filtered on any comodel's field, the result shouldn't be affected,
            //     which explains why we return `False` if `filtered_domain` is empty.
            // 
            //     Returns:
            //         False or recordset of the comodel given in parameter.
            // """
            // def _change_operator(domain):
            //     new_domain = []
            //     for dom in domain:
            //         if len(dom) == 3:
            //             _, op, value = dom
            //             if op in ("any", "not any"):
            //                 new_op = "in" if op == "any" else "not in"
            //                 ids = [val[2] for val in value if isinstance(val, (tuple, list)) and isinstance(val[2], int)]
            //                 new_domain.append(("id", new_op, ids))
            //                 continue
            //             op = "ilike" if op == "child_of" else op
            //             if isinstance(value, list) and all(isinstance(val, int) for val in value):
            //                 new_domain.append(("id", op, value))
            //             elif isinstance(value, str) or (isinstance(value, list) and not all(isinstance(val, str) for val in value)):
            //                 new_domain.append(("name", op, value))
            //             if isinstance(value, int):
            //                 if op == "=":
            //                     op = "in"
            //                 if op == "!=":
            //                     op = "not in"
            //                 new_domain.append(("id", op, [value]))
            //         else:
            //             new_domain.append(dom)
            //     return Domain(new_domain)
            // 
            // filtered_domain = filter_domain_leaf(domain, lambda field_to_check: field_to_check in [
            //     field,
            //     f"{field}.id",
            //     f"{field}.name",
            // ], {
            //     field: "name",
            //     f"{field}.id": "id",
            //     f"{field}.name": "name",
            // })
            // if filtered_domain.is_true():
            //     return self.env[comodel]
            // filtered_domain = _change_operator(filtered_domain)
            // if additional_domain:
            //     filtered_domain &= Domain(additional_domain)
            // return self.env[comodel].search(filtered_domain)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_personal_stage_id(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // field_name = 'display_name' if any(isinstance(v, str) for v in value) or value == '' else 'id'  # noqa: PLC1901
            // domain = Domain(field_name, operator, value) & Domain('user_id', '=', self.env.uid)
            // personal_stages = self.env['project.task.stage.personal']._search(domain)
            // return Domain('id', 'in', personal_stages.subselect('task_id'))
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_portal_user_names(self, operator, value):
            // if operator != 'ilike' or not isinstance(value, str):
            //     return NotImplemented
            // 
            // sql = SQL("""(
            //     SELECT task_user.task_id
            //       FROM project_task_user_rel task_user
            // INNER JOIN res_users users ON task_user.user_id = users.id
            // INNER JOIN res_partner partners ON partners.id = users.partner_id
            //      WHERE partners.name ILIKE %s
            // )""", f"%{value}%")
            // return [('id', 'in', sql)]
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_email_notify_to_cc(self, partners_to_notify):
            // # TDE TODO: this should be removed with email-like recipients management
            // self.ensure_one()
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.task_invitation_follower', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // values = {
            //     'object': self,
            // }
            // for partner in partners_to_notify:
            //     values['partner_name'] = partner.name
            //     assignation_msg = self.env['ir.qweb']._render('project.task_invitation_follower', values, minimal_qcontext=True)
            //     self.message_notify(
            //         subject=_('You have been invited to follow %s', self.display_name),
            //         body=assignation_msg,
            //         partner_ids=partner.ids,
            //         email_layout_xmlid='mail.mail_notification_layout',
            //         model_description=task_model_description,
            //         mail_auto_delete=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_task_rating_mail(self, force_send=False):
            // for task in self:
            //     rating_template = task.stage_id.rating_template_id
            //     partner = task.partner_id
            //     if rating_template and partner and partner != self.env.user.partner_id and not task.is_template:
            //         task.rating_send_request(rating_template, lang=task.partner_id.lang, force_send=force_send)
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _set_favorite_user_ids(self, is_favorite):
            // self_sudo = self.sudo() # To allow project users to set projects as favorite
            // if is_favorite:
            //     self_sudo.favorite_user_ids = [Command.link(self.env.uid)]
            // else:
            //     self_sudo.favorite_user_ids = [Command.unlink(self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _set_stage_on_project_from_task(self):
            // stage_ids_per_project = defaultdict(list)
            // for task in self:
            //     if task.stage_id and task.stage_id not in task.project_id.type_ids and task.stage_id.id not in stage_ids_per_project[task.project_id]:
            //         stage_ids_per_project[task.project_id].append(task.stage_id.id)
            // 
            // for project, stage_ids in stage_ids_per_project.items():
            //     project.write({'type_ids': [Command.link(stage_id) for stage_id in stage_ids]})
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return self.env.user.has_group('analytic.group_analytic_accounting')
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return True
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _sort_by_confidence_level(self, reverse=False):
            // """ Sorting the leads/opps according to the confidence level to it
            // being won. It is sorted following this incremental heuristics :
            // 
            //   * "not lost" first (inactive leads are lost); normally all leads
            //     should be active but in case lost one, they are always last.
            //     Inactive opportunities are considered as valid;
            //   * opportunity is more reliable than a lead which is a pre-stage
            //     used mainly for first classification;
            //   * stage sequence: the higher the better as it indicates we are moving
            //     towards won stage;
            //   * probability: the higher the better as it is more likely to be won;
            //   * ID: the higher the better when all other parameters are equal. We
            //     consider newer leads to be more reliable;
            // """
            // def opps_key(opportunity):
            //     return opportunity.type == 'opportunity' or opportunity.active,  \
            //         opportunity.type == 'opportunity', \
            //         opportunity.stage_id.sequence, \
            //         opportunity.probability, \
            //         -opportunity._origin.id
            // 
            // return self.sorted(key=opps_key, reverse=reverse)
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def stage_find(self, section_id, domain=[], order='sequence, id'):
            // """ Override of the base.stage method
            // Parameter of the stage search taken from the lead:
            // 
            // :param section_id: if set, stages must belong to this section or
            //     be a default stage; if not set, stages must be default stages
            // """
            // # collect all section_ids
            // section_ids = []
            // if section_id:
            //     section_ids.append(section_id)
            // section_ids.extend(self.mapped('project_id').ids)
            // search_domain = []
            // if section_ids:
            //     search_domain = [('|')] * (len(section_ids) - 1)
            //     for section_id in section_ids:
            //         search_domain.append(('project_ids', '=', section_id))
            // search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['project.task.type'].search(search_domain, order=order, limit=1).id
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _stage_find(self, team_id=False, domain=None, order='sequence, id', limit=1):
            // """ Determine the stage of the current lead with its teams, the given domain and the given team_id
            //     :param team_id
            //     :param domain : base search domain for stage
            //     :param order : base search order for stage
            //     :param limit : base search limit for stage
            //     :returns crm.stage recordset
            // """
            // # collect all team_ids by adding given one, and the ones related to the current leads
            // team_ids = set()
            // if team_id:
            //     team_ids.add(team_id)
            // for lead in self:
            //     if lead.team_id:
            //         team_ids.add(lead.team_id.id)
            // # generate the domain
            // if team_ids:
            //     search_domain = ['|', ('team_ids', '=', False), ('team_ids', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_ids', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return PROJECT_TASK_READABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_WRITABLE_FIELDS(self):
            // return PROJECT_TASK_WRITABLE_FIELDS
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _task_message_auto_subscribe_notify(self, users_per_task):
            // if self.env.context.get('mail_auto_subscribe_no_notify'):
            //     return
            // # Utility method to send assignation notification upon writing/creation.
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.project_message_user_assigned', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // for task, users in users_per_task.items():
            //     if not users:
            //         continue
            //     values = {
            //         'object': task,
            //         'model_description': task_model_description,
            //         'access_link': task._notify_get_action_link('view'),
            //     }
            //     for user in users:
            //         values.update(assignee_name=user.sudo().name)
            //         assignation_msg = self.env['ir.qweb']._render('project.project_message_user_assigned', values, minimal_qcontext=True)
            //         assignation_msg = self.env['mail.render.mixin']._replace_local_links(assignation_msg)
            //         task.message_notify(
            //             subject=_('You have been assigned to %s', task.display_name),
            //             body=assignation_msg,
            //             partner_ids=user.partner_id.ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             model_description=task_model_description,
            //             mail_auto_delete=False,
            //         )
            */
            return default;
        }

        public async Task<TEntity> TemplateToProjectConfirmationCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def template_to_project_confirmation_callback(self, callbacks):
            // self.ensure_one()
            // pass
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _thread_to_store(self, store: Store, fields, *, request_list=None):
            // super()._thread_to_store(store, fields, request_list=request_list)
            // if request_list and "followers" in request_list:
            //     store.add(
            //         self,
            //         {"collaborator_ids": Store.Many(self.collaborator_ids.partner_id, [])},
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def toggle_favorite(self):
            // favorite_projects = not_fav_projects = self.env['project.project'].sudo()
            // for project in self:
            //     if self.env.user in project.favorite_user_ids:
            //         favorite_projects |= project
            //     else:
            //         not_fav_projects |= project
            // 
            // # Project User has no write access for project.
            // not_fav_projects.write({'favorite_user_ids': [(4, self.env.uid)]})
            // favorite_projects.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> ToggleTemplateModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_template) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _toggle_template_mode(self, is_template):
            // self.ensure_one()
            // self.is_template = is_template
            // if not is_template:
            //     self.task_ids.role_ids = False
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.won_status == 'won':
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'won_status' in init_values and self.won_status != 'lost':
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'won_status' in init_values and self.won_status == 'lost':
            //     return self.env.ref('crm.mt_lead_lost')
            // return super()._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_subtype(self, init_values):
            // record = self[0]
            // if 'stage_id' in init_values and record.stage_id:
            //     return self.env.ref('hr_recruitment.mt_applicant_stage_changed')
            // return super()._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_project_stage_change')
            // return super()._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // mail_message_subtype_per_state = {
            //     '1_done': 'project.mt_task_done',
            //     '1_canceled': 'project.mt_task_canceled',
            //     '01_in_progress': 'project.mt_task_in_progress',
            //     '03_approved': 'project.mt_task_approved',
            //     '02_changes_requested': 'project.mt_task_changes_requested',
            //     '04_waiting_normal': 'project.mt_task_waiting',
            // }
            // 
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_task_stage')
            // elif 'state' in init_values and self.state in mail_message_subtype_per_state:
            //     return self.env.ref(mail_message_subtype_per_state[self.state])
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant.env.context.get('just_moved')\
            //     and not applicant.env.context.get('just_unarchived'):
            //     res['stage_id'] = (applicant.stage_id.template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'hr_recruitment.mail_notification_light_without_background'
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // project = self[0]
            // if self.env.user.has_group('project.group_project_stages') and 'stage_id' in changes and project.stage_id.mail_template_id:
            //     res['stage_id'] = (project.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light',
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // test_task = self[0]
            // if 'stage_id' in changes and test_task.stage_id.mail_template_id and not test_task.is_template:
            //     res['stage_id'] = (test_task.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light'
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def unlink(self):
            // """ Update meetings when removing opportunities, otherwise you have
            // a link to a record that does not lead anywhere. """
            // meetings = self.env['calendar.event'].search([
            //     ('res_id', 'in', self.ids),
            //     ('res_model', '=', self._name),
            // ])
            // if meetings:
            //     meetings.write({
            //         'res_id': False,
            //         'res_model_id': False,
            //     })
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def unlink(self):
            // # Delete the embedded action configs related to the deleted projects
            // self.env['res.users.settings.embedded.action'].sudo().search(
            //     domain=[('res_id', 'in', self.ids), ('res_model', '=', self._name)],
            // ).unlink()
            // # Delete the empty related analytic account
            // analytic_accounts_to_delete = self.env['account.analytic.account']
            // for project in self:
            //     if project.account_id and not project.account_id.line_ids:
            //         analytic_accounts_to_delete |= project.account_id
            // self.with_context(active_test=False).tasks.unlink()
            // result = super().unlink()
            // analytic_accounts_to_delete.unlink()
            // return result
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def unlink(self):
            // # Add subtasks to batch of tasks to delete
            // self |= self._get_all_subtasks()
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // for task in self:
            //     if task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id):
            //         task.recurrence_id.unlink()
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _unsubscribe_portal_users(self):
            // self.message_unsubscribe(partner_ids=self.message_partner_ids.filtered('user_ids.share').ids)
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _update_automated_probabilities(self):
            // """ Recompute all the automated_probability (and align probability if both were aligned) for all the leads
            // that are active (not won, nor lost).
            // 
            // For performance matter, as there can be a huge amount of leads to recompute, this cron proceed by batch.
            // Each batch is performed into its own transaction, in order to minimise the lock time on the lead table
            // (and to avoid complete lock if there was only 1 transaction that would last for too long -> several minutes).
            // If a concurrent update occurs, it will simply be put in the queue to get the lock.
            // """
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return
            // 
            // # 1. Get all the leads to recompute created after pls_start_date that are nor won nor lost
            // pending_lead_domain = [
            //     ('stage_id', '!=', False),
            //     ('create_date', '>=', pls_start_date),
            //     ('won_status', '=', 'pending'),
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     batch_probabilites, _unused = leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True)
            //     lead_probabilities.update(batch_probabilites)
            // _logger.info("Predictive Lead Scoring : New automated probabilities computed")
            // 
            // # 3. Group by new probability to reduce server roundtrips when executing the update
            // probability_leads = defaultdict(list)
            // for lead_id, probability in sorted(lead_probabilities.items()):
            //     probability_leads[probability].append(lead_id)
            // 
            // # 4. Update automated_probability (+ probability if both were equal)
            // update_sql = """UPDATE crm_lead
            //                 SET automated_probability = %s,
            //                     probability = CASE WHEN (probability = automated_probability OR probability is null)
            //                                        THEN (%s)
            //                                        ELSE (probability)
            //                                   END
            //                 WHERE id in %s"""
            // 
            // # Update by a maximum number of leads at the same time, one batch by transaction :
            // # - avoid memory errors
            // # - avoid blocking the table for too long with a too big transaction
            // transactions_count, transactions_failed_count = 0, 0
            // cron_update_lead_start_date = datetime.now()
            // auto_commit = not modules.module.current_test
            // self.flush_model()
            // for probability, probability_lead_ids in probability_leads.items():
            //     for lead_ids_current in tools.split_every(PLS_UPDATE_BATCH_STEP, probability_lead_ids):
            //         transactions_count += 1
            //         try:
            //             self.env.cr.execute(update_sql, (probability, probability, tuple(lead_ids_current)))
            //             # auto-commit except in testing mode
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception as e:
            //             _logger.warning("Predictive Lead Scoring : update transaction failed. Error: %s" % e)
            //             transactions_failed_count += 1
            // self.invalidate_model()
            // 
            // _logger.info(
            //     "Predictive Lead Scoring : All automated probabilities updated (%d leads / %d transactions (%d failed) / %d seconds)" % (
            //         leads_to_update_count,
            //         transactions_count,
            //         transactions_failed_count,
            //         (datetime.now() - cron_update_lead_start_date).total_seconds(),
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def update_date_end(self, stage_id):
            // project_task_type = self.env['project.task.type'].browse(stage_id)
            // if project_task_type.fold:
            //     return {'date_end': fields.Datetime.now()}
            // return {'date_end': False}
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def write(self, vals):
            // if vals.get('website'):
            //     vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // 
            // now = self.env.cr.now()
            // stage_updated, stage_is_won = False, False
            // # stage change (or reset): update date_last_stage_update if at least one
            // # lead does not have the same stage
            // if 'stage_id' in vals:
            //     stage_updated = any(lead.stage_id.id != vals['stage_id'] for lead in self)
            //     if stage_updated:
            //         vals['date_last_stage_update'] = now
            //     if stage_updated and vals.get('stage_id'):
            //         stage = self.env['crm.stage'].browse(vals['stage_id'])
            //         if stage.is_won:
            //             vals.update({'active': True, 'probability': 100, 'automated_probability': 100})
            //             stage_is_won = True
            // # user change; update date_open if at least one lead does not
            // # have the same user
            // if 'user_id' in vals and not vals.get('user_id'):
            //     vals['date_open'] = False
            // elif vals.get('user_id'):
            //     user_updated = any(lead.user_id.id != vals['user_id'] for lead in self)
            //     if user_updated:
            //         vals['date_open'] = now
            // 
            // # stage change with new stage: update probability and date_closed
            // if vals.get('probability', 0) >= 100 or not vals.get('active', True):
            //     vals['date_closed'] = fields.Datetime.now()
            // elif vals.get('probability', 0) > 0:
            //     vals['date_closed'] = False
            // elif stage_updated and not stage_is_won and not 'probability' in vals:
            //     vals['date_closed'] = False
            // 
            // update_frequencies = any(field in ['active', 'stage_id', 'probability'] for field in vals)
            // old_status_by_lead = {
            //     lead.id: {
            //         'is_lost': lead.won_status == 'lost',
            //         'is_won': lead.won_status == 'won',
            //     } for lead in self
            // } if update_frequencies else {}
            // 
            // if not stage_is_won:
            //     result = super().write(vals)
            // else:
            //     # stage change between two won stages: does not change the date_closed
            //     leads_already_won = self.filtered(lambda lead: lead.stage_id.is_won)
            //     remaining = self - leads_already_won
            //     if remaining:
            //         result = super(CrmLead, remaining).write(vals)
            //     if leads_already_won:
            //         vals.pop('date_closed', False)
            //         result = super(CrmLead, leads_already_won).write(vals)
            // 
            // if update_frequencies:
            //     self._handle_won_lost(old_status_by_lead, {
            //         lead.id: {
            //             'is_lost': lead.won_status == 'lost',
            //             'is_won': lead.won_status == 'won',
            //         } for lead in self
            //     })
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def write(self, vals):
            // # user_id change: update date_open
            // if vals.get('user_id'):
            //     vals['date_open'] = fields.Datetime.now()
            // old_interviewers = self.interviewer_ids
            // # stage_id: track last stage before update
            // if 'stage_id' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            //     if 'kanban_state' not in vals:
            //         vals['kanban_state'] = 'normal'
            //     for applicant in self:
            //         vals['last_stage_id'] = applicant.stage_id.id
            //         new_stage = self.env['hr.recruitment.stage'].browse(vals['stage_id'])
            //         if new_stage.hired_stage and not applicant.stage_id.hired_stage:
            //             if applicant.job_id.no_of_recruitment > 0:
            //                 applicant.job_id.no_of_recruitment -= 1
            //         elif not new_stage.hired_stage and applicant.stage_id.hired_stage:
            //             applicant.job_id.no_of_recruitment += 1
            // # kanban_state: also set date_last_stage_update
            // if 'kanban_state' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            // res = super().write(vals)
            // 
            // for applicant in self:
            //     if applicant.pool_applicant_id and applicant != applicant.pool_applicant_id and (not applicant.is_pool_applicant):
            //         if 'email_from' in vals:
            //             applicant.pool_applicant_id.email_from = vals['email_from']
            //         if 'partner_phone' in vals:
            //             applicant.pool_applicant_id.partner_phone = vals['partner_phone']
            //         if 'linkedin_profile' in vals:
            //             applicant.pool_applicant_id.linkedin_profile = vals['linkedin_profile']
            //         if 'type_id' in vals:
            //             applicant.pool_applicant_id.type_id = vals['type_id']
            // 
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            //     new_interviewers = self.interviewer_ids - old_interviewers - self.env.user
            //     if new_interviewers:
            //         for applicant in self:
            //             notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //             notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //             applicant.message_notify(
            //                 res_id=applicant.id,
            //                 model=applicant._name,
            //                 partner_ids=new_interviewers.partner_id.ids,
            //                 author_id=self.env.user.partner_id.id,
            //                 email_from=self.env.user.email_formatted,
            //                 subject=notification_subject,
            //                 body=notification_body,
            //                 email_layout_xmlid="mail.mail_notification_layout",
            //                 model_description="Applicant",
            //             )
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def write(self, vals):
            // if vals.get('access_token'):
            //     self.ensure_one()  # We are not supposed to add a single access token to multiple project
            //     if self.privacy_visibility not in ['invited_users', 'portal']:
            //         vals['access_token'] = ''
            // 
            // # Here we modify the project's stage according to the selected company (selecting the first
            // # stage in sequence that is linked to the company).
            // company_id = vals.get('company_id')
            // if self.env.user.has_group('project.group_project_stages') and company_id:
            //     projects_already_with_company = self.filtered(lambda p: p.company_id.id == company_id)
            //     if projects_already_with_company:
            //         projects_already_with_company.write({key: value for key, value in vals.items() if key != 'company_id'})
            //         self -= projects_already_with_company
            //     if company_id not in (None, *self.company_id.ids) and self.stage_id.company_id:
            //         ProjectStage = self.env['project.project.stage']
            //         vals["stage_id"] = ProjectStage.search(
            //             [('company_id', 'in', (company_id, False))],
            //             order=f"sequence asc, {ProjectStage._order}",
            //             limit=1,
            //         ).id
            // 
            // # directly compute is_favorite to dodge allow write access right
            // if 'is_favorite' in vals:
            //     self._set_favorite_user_ids(vals.pop('is_favorite'))
            // 
            // if 'last_update_status' in vals and vals['last_update_status'] != 'to_define':
            //     for project in self:
            //         # This does not benefit from multi create, this is to allow the default description from being built.
            //         # This does seem ok since last_update_status should only be updated on one record at once.
            //         self.env['project.update'].with_context(default_project_id=project.id).create({
            //             'name': _('Status Update - %(date)s', date=fields.Date.today().strftime(get_lang(self.env).date_format)),
            //             'status': vals.get('last_update_status'),
            //         })
            //     vals.pop('last_update_status')
            // if vals.get('privacy_visibility'):
            //     self._change_privacy_visibility(vals['privacy_visibility'])
            // 
            // date_start = vals.get('date_start', True)
            // date_end = vals.get('date', True)
            // if not date_start or not date_end:
            //     vals['date_start'] = False
            //     vals['date'] = False
            // else:
            //     no_current_date_begin = not all(project.date_start for project in self)
            //     no_current_date_end = not all(project.date for project in self)
            //     date_start_update = 'date_start' in vals
            //     date_end_update = 'date' in vals
            //     if (date_start_update and no_current_date_end and not date_end_update):
            //         del vals['date_start']
            //     elif (date_end_update and no_current_date_begin and not date_start_update):
            //         del vals['date']
            // 
            // res = super().write(vals) if vals else True
            // 
            // if 'allow_task_dependencies' in vals and not vals.get('allow_task_dependencies'):
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('state', '=', '04_waiting_normal')]).write({'state': '01_in_progress'})
            // 
            // if 'allow_recurring_tasks' in vals and not vals['allow_recurring_tasks']:
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('recurring_task', '=', True)]).write({'recurring_task': False})
            // 
            // if 'active' in vals:
            //     # archiving/unarchiving a project does it on its tasks, too
            //     self.with_context(active_test=False).mapped('tasks').write({'active': vals['active']})
            // if 'name' in vals and self.account_id:
            //     projects_read_group = self.env['project.project']._read_group(
            //         [('account_id', 'in', self.account_id.ids)],
            //         ['account_id'],
            //         having=[('__count', '=', 1)],
            //     )
            //     analytic_account_to_update = self.env['account.analytic.account'].browse([
            //         analytic_account.id for [analytic_account] in projects_read_group
            //     ])
            //     analytic_account_to_update.write({'name': self.name})
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def write(self, vals):
            // self.check_access('write')
            // if len(self) == 1:
            //     handle_history_divergence(self, 'description', vals)
            // partner_ids = []
            // 
            // # Some values are determined by this override and must be written as
            // # sudo for portal users, because they do not have access to these
            // # fields. Other values must not be written as sudo.
            // additional_vals = {}
            // if self.env.user._is_portal() and not self.env.su:
            //     self._ensure_fields_write(vals, defaults=False)
            // 
            // if 'milestone_id' in vals:
            //     # WARNING: has to be done after 'project_id' vals is written on subtasks
            //     milestone = self.env['project.milestone'].browse(vals['milestone_id'])
            // 
            //     # 1. Task for which the milestone is unvalid -> milestone_id is reset
            //     if 'project_id' not in vals:
            //         unvalid_milestone_tasks = self.filtered(lambda task: task.project_id != milestone.project_id) if vals['milestone_id'] else self.env['project.task']
            //     else:
            //         unvalid_milestone_tasks = self if not vals['milestone_id'] or milestone.project_id.id != vals['project_id'] else self.env['project.task']
            //     valid_milestone_tasks = self - unvalid_milestone_tasks
            //     if unvalid_milestone_tasks:
            //         unvalid_milestone_tasks.sudo().write({'milestone_id': False})
            //         if valid_milestone_tasks:
            //             valid_milestone_tasks.sudo().write({'milestone_id': vals['milestone_id']})
            //         del vals['milestone_id']
            // 
            //     # 2. Parent's milestone is set to subtask with no milestone recursively
            //     subtasks_to_update = valid_milestone_tasks.child_ids.filtered(
            //         lambda task: (task not in self and
            //                       not task.milestone_id and
            //                       task.project_id == milestone.project_id and
            //                       task.state not in CLOSED_STATES))
            // 
            //     # 3. If parent and child task share the same milestone, child task's milestone is updated when the parent one is changed
            //     # No need to check if state is changed in vals as it won't affect the subtasks selected for update
            //     if 'project_id' not in vals:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and
            //                           task.milestone_id == task.parent_id.milestone_id and
            //                           task.state not in CLOSED_STATES))
            //     else:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and
            //                           (not task.display_in_project or task.project_id.id == vals['project_id']) and
            //                           task.milestone_id == task.parent_id.milestone_id and
            //                           task.state not in CLOSED_STATES))
            //     if subtasks_to_update:
            //         subtasks_to_update.sudo().write({'milestone_id': vals['milestone_id']})
            // 
            // if vals.get('parent_id') in self.ids:
            //     raise UserError(_("Sorry. You can't set a task as its parent task."))
            // 
            // # stage change: update date_last_stage_update
            // now = fields.Datetime.now()
            // if 'stage_id' in vals:
            //     if not 'project_id' in vals and self.filtered(lambda t: not t.project_id):
            //         raise UserError(_('You can only set a personal stage on a private task.'))
            // 
            //     additional_vals.update(self.update_date_end(vals['stage_id']))
            //     additional_vals['date_last_stage_update'] = now
            // task_ids_without_user_set = set()
            // if 'user_ids' in vals and 'date_assign' not in vals:
            //     # prepare update of date_assign after super call
            //     task_ids_without_user_set = {task.id for task in self if not task.user_ids}
            // 
            // # recurrence fields
            // rec_fields = vals.keys() & self._get_recurrence_fields()
            // if rec_fields:
            //     rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //     for task in self:
            //         if task.recurrence_id:
            //             task.recurrence_id.write(rec_values)
            //         elif vals.get('recurring_task'):
            //             recurrence = self.env['project.task.recurrence'].create(rec_values)
            //             task.recurrence_id = recurrence.id
            // 
            // if not vals.get('recurring_task', True) and self.recurrence_id:
            //     tasks_in_recurrence = self.recurrence_id.task_ids
            //     self.recurrence_id.unlink()
            //     tasks_in_recurrence.write({'recurring_task': False})
            // 
            // # Track user_ids to send assignment notifications
            // old_user_ids = {t: t.user_ids for t in self.sudo()}
            // 
            // if "personal_stage_type_id" in vals and not vals['personal_stage_type_id']:
            //     del vals['personal_stage_type_id']
            // 
            // # sends an email to the 'Task Creation' subtype subscribers
            // # When project_id is changed
            // project_link_per_task_id = {}
            // if vals.get('project_id'):
            //     project = self.env['project.project'].browse(vals.get('project_id'))
            //     notification_subtype_id = self.env['ir.model.data']._xmlid_to_res_id('project.mt_project_task_new')
            //     partner_ids = project.message_follower_ids.filtered(lambda follower: notification_subtype_id in follower.subtype_ids.ids).partner_id.ids
            //     if partner_ids:
            //         link_per_project_id = {}
            //         for task in self:
            //             if task.project_id:
            //                 project_link = link_per_project_id.get(task.project_id.id)
            //                 if not project_link:
            //                     project_link = link_per_project_id[task.project_id.id] = task.project_id._get_html_link(title=task.project_id.display_name)
            //                 project_link_per_task_id[task.id] = project_link
            // if vals.get('parent_id') is False:
            //     additional_vals['display_in_project'] = True
            // if 'description' in vals:
            //     # the portal user cannot access to html_field_history and so it would be
            //     # better to write in sudo for description field to avoid giving access to html_field_history
            //     additional_vals['description'] = vals.pop('description')
            // 
            //     # write changes
            // if self.env.su or not self.env.user._is_portal():
            //     vals.update(additional_vals)
            // elif additional_vals:
            //     super(ProjectTask, self.sudo()).write(additional_vals)
            // result = super().write(vals)
            // 
            // if 'user_ids' in vals:
            //     self._populate_missing_personal_stages()
            // 
            // # user_ids change: update date_assign
            // if 'user_ids' in vals:
            //     for task in self.sudo():
            //         if not task.user_ids and task.date_assign:
            //             task.date_assign = False
            //         elif 'date_assign' not in vals and task.id in task_ids_without_user_set:
            //             task.date_assign = now
            // 
            // # rating on stage
            // if 'stage_id' in vals and vals.get('stage_id'):
            //     self.sudo().filtered(lambda x: x.stage_id.rating_active and x.stage_id.rating_status == 'stage')._send_task_rating_mail(force_send=True)
            // 
            // if 'state' in vals:
            //     # specific use case: when the blocked task goes from 'forced' done state to a not closed state, we fix the state back to waiting
            //     for task in self.sudo():
            //         if task.allow_task_dependencies:
            //             if task.is_blocked_by_dependences() and vals['state'] not in CLOSED_STATES and vals['state'] != '04_waiting_normal':
            //                 task.state = '04_waiting_normal'
            //         task.date_last_stage_update = now
            // elif 'project_id' in vals:
            //     self.filtered(lambda t: t.state != '04_waiting_normal').state = '01_in_progress'
            // 
            // # Do not recompute the state when changing the parent (to avoid resetting the state)
            // if 'parent_id' in vals:
            //     self.env.remove_to_compute(self._fields['state'], self)
            // 
            // self._task_message_auto_subscribe_notify({task: task.user_ids - old_user_ids[task] - self.env.user for task in self})
            // 
            // if partner_ids:
            //     for task in self:
            //         project_link = project_link_per_task_id.get(task.id)
            //         if project_link:
            //             body = _(
            //                 'Task Transferred from Project %(source_project)s to %(destination_project)s',
            //                 source_project=project_link,
            //                 destination_project=task.project_id._get_html_link(title=task.project_id.display_name),
            //             )
            //         else:
            //             body = _('Task Converted from To-Do')
            //         task.message_notify(
            //             body=body,
            //             partner_ids=partner_ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             notify_author_mention=False,
            //        )
            // return result
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def __compute_task_count(self, count_field='task_count', additional_domain=None):
            // count_fields = {fname for fname in self._fields if 'count' in fname}
            // if count_field not in count_fields:
            //     raise ValueError(f"Parameter 'count_field' can only be one of {count_fields}, got {count_field} instead.")
            // domain = Domain('project_id', 'in', self.ids) & Domain('is_template', '=', False)
            // if additional_domain:
            //     domain &= Domain(additional_domain)
            // ProjectTask = self.env['project.task'].with_context(active_test=any(project.active for project in self))
            // tasks_count_by_project = dict(ProjectTask._read_group(domain, ['project_id'], ['__count']))
            // for project in self:
            //     project.update({count_field: tasks_count_by_project.get(project, 0)})
            */
            return default;
        }
    }
}