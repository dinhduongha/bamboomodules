using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailTrackingDurationMixinAppService : ApplicationService, IMailTrackingDurationMixinAppService
    {

        public MailTrackingDurationMixinAppService() 
        {

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
            // values = super(Project, self)._alias_get_creation_values()
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
            //     'context': {'default_applicant_ids': self.ids, 'active_test': False},
            //     'views': [[False, 'form']]
            // }
            */
            return default;
        }

        public async Task<TEntity> ArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_archive(self):
            // child_tasks = self.child_ids.filtered(lambda child_task: not child_task.display_in_project)
            // if child_tasks:
            //     child_tasks.action_archive()
            // self.filtered(lambda t: not t.display_in_project and t.parent_id).display_in_project = True
            // return super().action_archive()
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // tools.create_index(self._cr, 'crm_lead_user_id_team_id_type_index',
            //                    self._table, ['user_id', 'team_id', 'type'])
            // tools.create_index(self._cr, 'crm_lead_create_date_team_id_idx',
            //                    self._table, ['create_date', 'team_id'])
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
            //     if new_visibility == 'portal':
            //         project.message_subscribe(partner_ids=project.partner_id.ids)
            //         for task in project.task_ids.filtered('partner_id'):
            //             task.message_subscribe(partner_ids=task.partner_id.ids)
            //     elif project.privacy_visibility == 'portal':
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

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // if field_names and operation in ('read', 'write'):
            //     self._ensure_fields_are_accessible(field_names, operation)
            // elif not field_names and not self.env.su and self.env.user._is_portal():
            //     valid_names = self.SELF_READABLE_FIELDS
            //     return [
            //         fname for fname in super().check_field_access_rights(operation, field_names)
            //         if fname in valid_names
            //     ]
            // return super().check_field_access_rights(operation, field_names)
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

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_sharing_access(self):
            // self.ensure_one()
            // if self.privacy_visibility != 'portal':
            //     return False
            // if self.env.user._is_portal():
            //     return self.env['project.collaborator'].search([('project_id', '=', self.sudo().id), ('partner_id', '=', self.env.user.partner_id.id)])
            // return self.env.user._is_internal()
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
            //         project.access_instruction_message = _('Grant portal users access to your project by adding them as followers (the tasks of the project are not included). To grant access to tasks to a portal user, add them as followers for these tasks.')
            //     elif project.privacy_visibility == 'followers':
            //         project.access_instruction_message = _('Grant employees access to your project or tasks by adding them as followers. Employees automatically get access to the tasks they are assigned to.')
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
            // super(Project, self)._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_url(self):
            // super(Task, self)._compute_access_url()
            // for task in self:
            //     task.access_url = f'/my/tasks/{task.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_warning(self):
            // super(Project, self)._compute_access_warning()
            // for project in self.filtered(lambda x: x.privacy_visibility != 'portal'):
            //     project.access_warning = _(
            //         "This project is currently restricted to \"Invited internal users\". The project's visibility will be changed to \"invited portal users and all internal users (public)\" in order to make it accessible to the recipients.")
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_warning(self):
            // super(Task, self)._compute_access_warning()
            // for task in self.filtered(lambda x: x.project_id.privacy_visibility != 'portal'):
            //     visibility_field = self.env['ir.model.fields'].search([('model', '=', 'project.project'), ('name', '=', 'privacy_visibility')], limit=1)
            //     visibility_public = self.env['ir.model.fields.selection'].search([('field_id', '=', visibility_field.id), ('value', '=', 'portal')])
            //     task.access_warning = _(
            //         "The task cannot be shared with the recipient(s) because the privacy of the project is too restricted. Set the privacy of the project to '%(visibility)s' in order to make it accessible by the recipient(s).",
            //         visibility=visibility_public.name,
            //     )
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

        public async Task<TEntity> ComputeCategIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_categ_ids(self):
            // for applicant in self:
            //     applicant.categ_ids = applicant.candidate_id.categ_ids.ids + applicant.categ_ids.ids
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
            // project_sharings = self.filtered(lambda project: project.privacy_visibility == 'portal')
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
            // for lead in self:
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
            //         applicant.date_closed = fields.datetime.now()
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
            // self.filtered(
            //     lambda t: not t.display_in_project and (
            //         not t.project_id or t.project_id != t.parent_id.project_id
            //     )
            // ).display_in_project = True
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
            //     applicant.display_name = applicant.partner_name or applicant.name
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
            // self.env['mail.tracking.value'].flush_model()
            // self.env['mail.message'].flush_model()
            // query = """
            //        SELECT m.res_id,
            //               v.create_date,
            //               v.old_value_integer
            //          FROM mail_tracking_value v
            //     LEFT JOIN mail_message m
            //            ON m.id = v.mail_message_id
            //           AND v.field_id = %(field_id)s
            //         WHERE m.model = %(model_name)s
            //           AND m.res_id IN %(record_ids)s
            //      ORDER BY v.id
            // """
            // self.env.cr.execute(query, {"field_id": field.id, "model_name": self._name, "record_ids": tuple(self.ids)})
            // trackings = self.env.cr.dictfetchall()
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
            //         for email in email_split(lead.email_from):
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
            // for project in self:
            //     project.is_favorite = self.env.user in project.favorite_user_ids
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

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_mobile(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.mobile or lead.partner_id.mobile:
            //         lead.mobile = lead.partner_id.mobile
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
            // milestone_ids_per_project_id = {
            //     project.id: milestone_ids
            //     for project, milestone_ids in self.env['project.milestone']._read_group(
            //         [('project_id', 'in', self.ids), ('is_reached', '=', False)],
            //         ['project_id'],
            //         ['id:recordset'],
            //     )
            // }
            // for project in self:
            //     milestone = milestone_ids_per_project_id.get(project.id, self.env['project.milestone'])[:1]
            //     project.next_milestone_id = milestone
            //     project.can_mark_milestone_as_done = milestone.can_be_marked_as_done
            //     project.is_milestone_deadline_exceeded = milestone.is_deadline_exceeded
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

        public async Task<TEntity> ComputeOtherApplicationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_other_applications_count(self):
            // for applicant in self:
            //     same_candidate_applications = max(len(applicant.with_context(active_test=False).candidate_id.applicant_ids) - 1, 0)
            //     if applicant.candidate_id:
            //         domain = applicant.candidate_id._get_similar_candidates_domain()
            //         similar_candidates = self.env['hr.candidate'].with_context(active_test=False).search(domain) - applicant.candidate_id
            //         similar_candidate_applications = sum(len(candidate.applicant_ids) for candidate in similar_candidates)
            //         applicant.other_applications_count = similar_candidate_applications + same_candidate_applications
            //     else:
            //         applicant.other_applications_count = same_candidate_applications
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
            // for lead in self:
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_name(self):
            // for applicant in self:
            //     applicant.partner_name = applicant.candidate_id.partner_name
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

        public async Task<TEntity> ComputePersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_personal_stage_type_id(self):
            // for task in self:
            //     task.personal_stage_type_id = task.personal_stage_id.stage_id
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
            //     model = self.env[model_name].sudo().with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id if isinstance(lead.id, models.NewId) else lead.id
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
            //     # in case phone and mobile are both set.
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
            //     elif project.privacy_visibility == 'portal' and project._origin.privacy_visibility != 'portal':
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility != 'portal' and project._origin.privacy_visibility == 'portal':
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
            // lead_probabilities = self._pls_get_naive_bayes_probabilities()
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

        public async Task<TEntity> ComputeRatingRequestDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_rating_request_deadline(self):
            // periods = {'daily': 1, 'weekly': 7, 'bimonthly': 15, 'monthly': 30, 'quarterly': 90, 'yearly': 365}
            // for project in self:
            //     project.rating_request_deadline = fields.datetime.now() + timedelta(days=periods.get(project.rating_status_period, 0))
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

        public async Task<TEntity> ComputeShowDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_show_display_in_project(self):
            // for task in self:
            //     task.show_display_in_project = bool(task.parent_id) and task.project_id == task.parent_id.sudo().project_id
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id:
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
            //         dependent_open_tasks = [dependent_task for dependent_task in task.depend_on_ids if dependent_task.state not in CLOSED_STATES]
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

        public async Task<TEntity> ComputeTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_title(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.title or lead.partner_id.title:
            //         lead.title = lead.partner_id.title
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

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.probability == 100:
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

        public async Task<TEntity> ConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            // new_projects = super(Project, self.with_context(copy_context)).copy(default=default)
            // if 'milestone_mapping' not in self.env.context:
            //     self = self.with_context(milestone_mapping={})
            // actions_per_project = dict(self.env['ir.embedded.actions']._read_group(
            //     domain=[
            //         ('parent_res_id', 'in', self.ids),
            //         ('parent_res_model', '=', 'project.project'),
            //         ('user_id', '=', False),
            //     ],
            //     groupby=['parent_res_id'],
            //     aggregates=['id:recordset'],
            // ))
            // for old_project, new_project in zip(self, new_projects):
            //     for follower in old_project.message_follower_ids:
            //         new_project.message_subscribe(partner_ids=follower.partner_id.ids, subtype_ids=follower.subtype_ids.ids)
            //     if old_project.allow_milestones:
            //         new_project.milestone_ids = self.milestone_ids.copy().ids
            //     if 'tasks' not in default:
            //         old_project.map_tasks(new_project.id)
            //     if not old_project.active:
            //         new_project.with_context(active_test=False).tasks.active = True
            //     # Copy the shared embedded actions in the new project
            //     shared_embedded_actions = actions_per_project.get(old_project.id)
            //     if shared_embedded_actions:
            //         copy_shared_embedded_actions = shared_embedded_actions.copy({'parent_res_id': new_project.id})
            //         for original_action, copied_action in zip(shared_embedded_actions, copy_shared_embedded_actions):
            //             copied_action.filter_ids = original_action.filter_ids.copy({'embedded_parent_res_id': new_project.id})
            // return new_projects
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy(self, default=None):
            // default = default or {}
            // default.update({
            //     'depend_on_ids': False,
            //     'dependent_ids': False,
            // })
            // copied_tasks = super(Task, self.with_context(
            //     mail_auto_subscribe_no_notify=True,
            //     mail_create_nosubscribe=True,
            //     mail_create_nolog=True,
            // )).copy(default=default)
            // 
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
            //     vals['date_open'] = now if lead.type == 'opportunity' else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if default and 'name' in default:
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", project.name)) for project, vals in zip(self, vals_list)]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // not_project_user = not self.env.user.has_group('project.group_project_user')
            // if not_project_user:
            //     vals_list = [{k: v for k, v in vals.items() if k in self.SELF_READABLE_FIELDS} for vals in vals_list]
            // 
            // milestone_mapping = self.env.context.get('milestone_mapping', {})
            // for task, vals in zip(self, vals_list):
            // 
            //     if not default.get('stage_id'):
            //         vals['stage_id'] = task.stage_id.id
            //     if 'active' not in default and not task['active'] and not self.env.context.get('copy_project'):
            //         vals['active'] = True
            //     vals['name'] = task.name if self.env.context.get('copy_project') else _("%s (copy)", task.name)
            //     if task.recurrence_id and not default.get('recurrence_id'):
            //         vals['recurrence_id'] = task.recurrence_id.copy().id
            //     if task.allow_milestones:
            //         vals['milestone_id'] = milestone_mapping.get(vals['milestone_id'], vals['milestone_id'])
            //     if task.child_ids and not default.get('child_ids'):
            //         default = {
            //             'depend_on_ids': False,
            //             'dependent_ids': False,
            //             'parent_id': False,
            //         }
            //         vals['child_ids'] = [Command.create(child_id.copy_data(default)[0]) for child_id in task.child_ids]
            // return vals_list
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
            // leads = super(Lead, self).create(vals_list)
            // 
            // for lead, values in zip(leads, vals_list):
            //     if any(field in ['active', 'stage_id'] for field in values):
            //         lead._handle_won_lost(values)
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
            //             record_name=applicant.display_name,
            //             model_description="Applicant",
            //         )
            // # Copy CV from candidate to applicant at record creation
            // attachments_result = self.env['ir.attachment'].read_group([
            //     ('res_id', 'in', applicants.candidate_id.ids),
            //     ('res_model', '=', "hr.candidate")
            // ], ['ids:array_agg(id)'], groupby=['res_id'])
            // attachments_by_candidate = {e['res_id']: e['ids'] for e in attachments_result}
            // for applicant in applicants:
            //     if applicant.candidate_id.company_id and applicant.company_id != applicant.candidate_id.company_id:
            //         raise ValidationError(_("You cannot create an applicant in a different company than the candidate"))
            //     candidate_id = applicant.candidate_id.id
            //     if candidate_id not in attachments_by_candidate:
            //         continue
            //     self.env['ir.attachment'].browse(attachments_by_candidate[candidate_id]).copy({
            //         'res_id': applicant.id,
            //         'res_model': 'hr.applicant'
            //     })
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
            //     if 'default_stage_id' in self._context:
            //         stage = self.env['project.project.stage'].browse(self._context['default_stage_id'])
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
            // new_context = dict(self.env.context)
            // default_personal_stage = new_context.pop('default_personal_stage_type_ids', False)
            // default_project_id = new_context.get("default_project_id", False)
            // self = self.with_context(new_context)
            // 
            // is_portal_user = self.env.user._is_portal()
            // if is_portal_user:
            //     self.browse().check_access('create')
            // default_stage = dict()
            // for vals in vals_list:
            //     project_id = vals.get('project_id') or default_project_id
            // 
            //     if vals.get('user_ids'):
            //         vals['date_assign'] = fields.Datetime.now()
            //         if not (vals.get('parent_id') or project_id):
            //             user_ids = self._fields['user_ids'].convert_to_cache(vals.get('user_ids', []), self.env['project.task'])
            //             if self.env.user.id not in list(user_ids) + [SUPERUSER_ID]:
            //                 vals['user_ids'] = [Command.set(list(user_ids) + [self.env.user.id])]
            //     if default_personal_stage and 'personal_stage_type_id' not in vals:
            //         vals['personal_stage_type_id'] = default_personal_stage[0]
            //     if not vals.get('name') and vals.get('display_name'):
            //         vals['name'] = vals['display_name']
            //     if is_portal_user:
            //         self._ensure_fields_are_accessible(vals.keys(), operation='write', check_group_user=False)
            // 
            //     if project_id and not "company_id" in vals:
            //         vals["company_id"] = self.env["project.project"].browse(
            //             project_id
            //         ).company_id.id
            //     if not project_id and ("stage_id" in vals or self.env.context.get('default_stage_id')):
            //         vals["stage_id"] = False
            // 
            //     if project_id and "stage_id" not in vals:
            //         # 1) Allows keeping the batch creation of tasks
            //         # 2) Ensure the defaults are correct (and computed once by project),
            //         # by using default get (instead of _get_default_stage_id or _stage_find),
            //         if project_id not in default_stage:
            //             default_stage[project_id] = self.with_context(
            //                 default_project_id=project_id
            //             ).default_get(['stage_id']).get('stage_id')
            //         vals["stage_id"] = default_stage[project_id]
            // 
            //     # Stage change: Update date_end if folded stage and date_last_stage_update
            //     if vals.get('stage_id'):
            //         vals.update(self.update_date_end(vals['stage_id']))
            //         vals['date_last_stage_update'] = fields.Datetime.now()
            //     # recurrence
            //     rec_fields = vals.keys() & self._get_recurrence_fields()
            //     if rec_fields and vals.get('recurring_task') is True:
            //         rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //         recurrence = self.env['project.task.recurrence'].create(rec_values)
            //         vals['recurrence_id'] = recurrence.id
            // # The sudo is required for a portal user as the record creation
            // # requires the read access on other models, as mail.template
            // # in order to compute the field tracking
            // was_in_sudo = self.env.su
            // if is_portal_user:
            //     vals_list_no_sudo, vals_list = zip(*(self._get_portal_sudo_vals(vals, defaults=True) for vals in vals_list))
            //     self_no_sudo, self = self, self.sudo().with_context(self._get_portal_sudo_context())
            // tasks = super(Task, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // if is_portal_user:
            //     for task, vals in zip(tasks.with_env(self_no_sudo.env), vals_list_no_sudo):
            //         task.write(vals)
            // tasks._populate_missing_personal_stages()
            // self._task_message_auto_subscribe_notify({task: task.user_ids - self.env.user for task in tasks})
            // 
            // # in case we were already in sudo, we don't check the rights.
            // if is_portal_user and not was_in_sudo:
            //     # since we use sudo to create tasks, we need to check
            //     # if the portal user could really create the tasks based on the ir rule.
            //     tasks.browse().with_user(self.env.user).check_access('create')
            // current_partner = self.env.user.partner_id
            // 
            // all_partner_emails = []
            // for task in tasks:
            //     all_partner_emails += tools.email_split(task.email_cc)
            // partners = self.env['res.partner'].search([('email', 'in', all_partner_emails)])
            // partner_per_email = {
            //     partner.email: partner
            //     for partner in partners
            //     if not all(u.share for u in partner.user_ids)
            // }
            // if tasks.project_id:
            //     tasks.sudo()._set_stage_on_project_from_task()
            // for task in tasks:
            //     if task.project_id.privacy_visibility == 'portal':
            //         task._portal_ensure_token()
            //     for follower in task.parent_id.message_follower_ids:
            //         task.message_subscribe(follower.partner_id.ids, follower.subtype_ids.ids)
            //     if current_partner not in task.message_partner_ids:
            //         task.message_subscribe(current_partner.ids)
            //     if task.email_cc:
            //         partners_with_internal_user = self.env['res.partner']
            //         for email in tools.email_split(task.email_cc):
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

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = None
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id if partner_company else False))
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
            // self.ensure_one()
            // action = self.candidate_id.with_context(clean_context(self.env.context)).create_employee_from_candidate()
            // employee = self.env['hr.employee'].browse(action['res_id'])
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

        public async Task<TEntity> CreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            //     'default_candidate_id': self.candidate_id.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
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

        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_company_id(self):
            // if self._context.get('default_project_id'):
            //     return self.env['project.project'].browse(self._context['default_project_id']).company_id
            // return False
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object default_fields) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def default_get(self, default_fields):
            // vals = super(Task, self).default_get(default_fields)
            // 
            // # prevent creating new task in the waiting state
            // if 'state' in default_fields and vals.get('state') == '04_waiting_normal':
            //     vals['state'] = '01_in_progress'
            // 
            // if 'repeat_until' in default_fields:
            //     vals['repeat_until'] = fields.Date.today() + timedelta(days=7)
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
            //     if 'company_id' in default_fields and 'default_project_id' not in self.env.context:
            //         vals['company_id'] = project.sudo().company_id.id
            // elif 'default_user_ids' not in self.env.context and 'user_ids' in default_fields:
            //     user_ids = vals.get('user_ids', [])
            //     user_ids.append(Command.link(self.env.user.id))
            //     vals['user_ids'] = user_ids
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> DefaultPersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_personal_stage_type_id(self):
            // default_id = self.env.context.get('default_personal_stage_type_ids')
            // return (default_id or self.env['project.task.type'].search([('user_id', '=', self.env.user.id)], limit=1).ids or [False])[0]
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

        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_user_ids(self):
            // return self.env.context.keys() & {'default_personal_stage_type_ids', 'default_personal_stage_type_id'} and self.env.user
            */
            return default;
        }

        public async Task<TEntity> DependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_dependent_tasks(self):
            // self.ensure_one()
            // return {
            //     'res_model': 'project.task',
            //     'type': 'ir.actions.act_window',
            //     'context': {**self._context, 'default_depend_on_ids': [Command.link(self.id)], 'show_project_update': False, 'search_default_open_tasks': True},
            //     'domain': [('depend_on_ids', '=', self.id)],
            //     'name': _('Dependent Tasks'),
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            // }
            */
            return default;
        }

        public async Task<TEntity> DetermineFieldsToFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names, object ignore_when_in_cache) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _determine_fields_to_fetch(self, field_names, ignore_when_in_cache=False):
            // if not self.env.su and self.env.user._is_portal():
            //     valid_names = self.SELF_READABLE_FIELDS
            //     field_names = [fname for fname in field_names if fname in valid_names]
            // return super()._determine_fields_to_fetch(field_names, ignore_when_in_cache)
            */
            return default;
        }

        public async Task<TEntity> EmailSplitAsync<TEntity>(IEnumerable<TEntity> entities, object msg) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def email_split(self, msg):
            // email_list = tools.email_split((msg.get('to') or '') + ',' + (msg.get('cc') or ''))
            // # check left-part is not already an alias
            // aliases = self.mapped('project_id.alias_name')
            // return [x for x in email_list if x.split('@')[0] not in aliases]
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

        public async Task<TEntity> EnsureFieldsAreAccessibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object operation, object check_group_user) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_fields_are_accessible(self, fields, operation='read', check_group_user=True):
            // """" ensure all fields are accessible by the current user
            // 
            //     This method checks if the portal user can access to all fields given in parameter.
            //     By default, it checks if the current user is a portal user and then checks if all fields are accessible for this user.
            // 
            //     :param fields: list of fields to check if the current user can access.
            //     :param operation: contains either 'read' to check readable fields or 'write' to check writable fields.
            //     :param check_group_user: contains boolean value.
            //         - True, if the method has to check if the current user is a portal one.
            //         - False if we are sure the user is a portal user,
            // """
            // assert operation in ('read', 'write'), 'Invalid operation'
            // if fields and (not check_group_user or self.env.user._is_portal()) and not self.env.su:
            //     unauthorized_fields = set(fields) - (self.SELF_READABLE_FIELDS if operation == 'read' else self.SELF_WRITABLE_FIELDS)
            //     if unauthorized_fields:
            //         unauthorized_field_list = format_list(self.env, list(unauthorized_fields))
            //         if operation == 'read':
            //             error_message = _('You cannot read the following fields on tasks: %(field_list)s', field_list=unauthorized_field_list)
            //         else:
            //             error_message = _('You cannot write on the following fields on tasks: %(field_list)s', field_list=unauthorized_field_list)
            //         raise AccessError(error_message)
            */
            return default;
        }

        public async Task<TEntity> EnsurePersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_personal_stages(self):
            // user = self.env.user
            // ProjectTaskTypeSudo = self.env['project.task.type'].sudo()
            // # In the case no stages have been found, we create the default stages for the user
            // if not ProjectTaskTypeSudo.search_count([('user_id', '=', user.id)], limit=1):
            //     ProjectTaskTypeSudo.with_context(lang=user.lang, default_project_id=False).create(
            //         self.with_context(lang=user.lang)._get_default_personal_stage_create_vals(user.id)
            //     )
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
            // self.priority = "1"
            // priority_group = self._get_group_pattern()['priority']
            // self.display_name, dummy = re.subn(priority_group, '', self.display_name)
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
            //     domain = expression.OR([[('name', '=ilike', tag)] for tag in tags])
            //     existing_tags = self.env['project.tags'].search(domain)
            //     existing_tags_names = {tag.name.lower() for tag in existing_tags}
            //     new_tags_names = {tag for tag in tags if tag.lower() not in existing_tags_names}
            //     self.tag_ids = [Command.set(existing_tags.ids)] + [Command.create({'name': name}) for name in new_tags_names]
            // pattern = tags_and_users_group % ('(?!%s)' % ('|').join(users_to_keep) if users_to_keep else '')
            // self.display_name, dummy = re.subn(pattern, '', self.display_name)
            */
            return default;
        }

        public async Task<TEntity> FieldsGetAsync<TEntity>(IEnumerable<TEntity> entities, object allfields, object attributes) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // fields = super().fields_get(allfields=allfields, attributes=attributes)
            // if not self.env.user._is_portal():
            //     return fields
            // readable_fields = self.SELF_READABLE_FIELDS
            // public_fields = {field_name: description for field_name, description in fields.items() if field_name in readable_fields}
            // 
            // writable_fields = self.SELF_WRITABLE_FIELDS
            // for field_name, description in public_fields.items():
            //     if field_name not in writable_fields and not description.get('readonly', False):
            //         # If the field is not in Writable fields and it is not readonly then we force the readonly to True
            //         description['readonly'] = True
            // 
            // return public_fields
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_only) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self, email_only=False):
            // """ Try to find a matching partner with available information on the
            // lead, using notably customer's name, email, ...
            // 
            // :param email_only: Only find a matching based on the email. To use
            //     for automatic process where ilike based on name can be too dangerous
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // 
            // if not partner and self.email_from:
            //     partner = self.env['res.partner'].search([('email', '=', self.email_from)], limit=1)
            // 
            // if not partner and not email_only:
            //     # search through the existing partners based on the lead's partner or contact name
            //     # to be aligned with _create_customer, search on lead's name as last possibility
            //     for customer_potential_name in [self[field_name] for field_name in ['partner_name', 'contact_name', 'name'] if self[field_name]]:
            //         partner = self.env['res.partner'].search([('name', 'ilike', customer_potential_name)], limit=1)
            //         if partner:
            //             break
            // 
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
            // email_normalized_to_values = super()._get_customer_information()
            // Partner = self.env['res.partner']
            // 
            // for record in self.filtered('email_normalized'):
            //     values = email_normalized_to_values.setdefault(record.email_normalized, {})
            //     contact_name = record.contact_name or record.partner_name or parse_contact_from_email(record.email_from)[0] or record.email_from
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update(record._prepare_customer_values(contact_name, is_company=False))
            //     values['company_name'] = record.partner_name
            //     if contact_name == record.partner_name:
            //         values['company_type'] = 'company'
            // return email_normalized_to_values
            */
            return default;
        }

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
            // previous_date = self.create_date
            // 
            // # If there is a tracking value to be created, but still in the
            // # precommit values, create a fake one to take it into account.
            // # Otherwise, the duration_tracking value will add time spent on
            // # previous tracked field value to the time spent in the new value
            // # (after writing the stage on the record)
            // if f'mail.tracking.{self._name}' in self.env.cr.precommit.data:
            //     if data := self.env.cr.precommit.data.get(f'mail.tracking.{self._name}', {}).get(self.id):
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

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            // if self._context.get('default_type') == 'lead':
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
            //             'help_title': _("No application found. Let's create one !"),
            //         }
            // 
            //         if hr_job:
            //             pattern = r'(.*)<a>(.*?)<\/a>(.*)'
            //             match = re.fullmatch(pattern, _('Have you tried to <a>add skills to your job position</a> and search into the Reserve ?'))
            //             nocontent_body += Markup("""
            // <p>%(para_1)s<a href="%(link)s">%(para_2)s</a>%(para_3)s</p>""") % {
            //             'para_1': match[1],
            //             'para_2': match[2],
            //             'para_3': match[3],
            //             'link': f'/odoo/recruitment/{hr_job.id}',
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Try creating an application by sending an email to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_empty_list_help(self, help):
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
            // return super(Task, self).get_empty_list_help(help)
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
            //     'priority': r'\s(!)',
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

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
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
            // for normalized_email in [tools.email_normalize(email) for email in tools.email_split(email)]:
            //     domain.append(('email_normalized', '=', normalized_email))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     domain += ['|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     domain += ['&', ('active', '=', True), '|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("%(name)s's Milestones", name=self.name),
            //     'domain': [('project_id', '=', self.id)],
            //     'res_model': 'project.milestone',
            //     'views': [(self.env.ref('project.project_milestone_view_tree').id, 'list')],
            //     'view_mode': 'list',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             No milestones found. Let's create one!
            //         </p><p>
            //             Track major progress points that must be reached to achieve success.
            //         </p>
            //     """),
            //     'context': {
            //         'default_project_id': self.id,
            //         **self.env.context
            //     }
            // }
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
            // domain = expression.AND([
            //     self.env["res.partner"]._get_mention_suggestions_domain(search),
            //     [("id", "in", followers.partner_id.ids)],
            // ])
            // partners = self.env["res.partner"].sudo()._search_mention_suggestions(domain, limit)
            // return Store(partners).get_result()
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
            // user_tz = self.env.user.tz or self.env.context.get('tz')
            // user_pytz = pytz.timezone(user_tz) if user_tz else pytz.utc
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
            // return AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        public async Task<TEntity> GetPortalSudoContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_portal_sudo_context(self):
            // return {
            //     key: value for key, value in self.env.context.items()
            //     if key == 'default_project_id'
            //     or key == 'default_user_ids' and value is False
            //     or not key.startswith('default_')
            //     or key[8:] in (field for field in self.SELF_WRITABLE_FIELDS if self._fields[field].type not in ('one2many', 'many2many'))
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPortalSudoValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_portal_sudo_vals(self, vals, defaults=False):
            // """ returns the values which must be written without and with sudo when a portal user creates / writes a task.
            //     :param vals: dict of {field: value}, the values to create/write
            //     :return: a tuple with 2 dicts:
            //         - the first with the values to write without sudo
            //         - the second with the values to write with sudo
            // """
            // vals_no_sudo = {key: val for key, val in vals.items() if self._fields[key].type in ('one2many', 'many2many')}
            // if defaults:
            //     vals_no_sudo.update({
            //         key[8:]: value
            //         for key, value in self.env.context.items()
            //         if key.startswith('default_') and key[8:] in self.SELF_WRITABLE_FIELDS and self._fields[key[8:]].type in ('one2many', 'many2many')
            //     })
            // vals_sudo = {key: val for key, val in vals.items() if key not in vals_no_sudo}
            // return vals_no_sudo, vals_sudo
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

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return expression.AND([
            //     [('partner_id', '!=', False)],
            //     additional_domain or [],
            // ])
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
            // if not self.user_id or not self.team_id:
            //     return False
            // if not self.expected_revenue:
            //     # Show rainbow man for the first won lead of a salesman, even if expected revenue is not set. It is not
            //     # very often that leads without revenues are marked won, so simply get count using ORM instead of query
            //     today = fields.Datetime.today()
            //     user_won_leads_count = self.search_count([
            //         ('type', '=', 'opportunity'),
            //         ('user_id', '=', self.user_id.id),
            //         ('probability', '=', 100),
            //         ('date_closed', '>=', date_utils.start_of(today, 'year')),
            //         ('date_closed', '<', date_utils.end_of(today, 'year')),
            //     ])
            //     if user_won_leads_count == 1:
            //         return _('Go, go, go! Congrats for your first deal.')
            //     return False
            // 
            // self.flush_model()  # flush fields to make sure DB is up to date
            // query = """
            //     SELECT
            //         SUM(CASE WHEN user_id = %(user_id)s THEN 1 ELSE 0 END) as total_won,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_7,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_7
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', date_closed) = DATE_TRUNC('year', CURRENT_DATE)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {'user_id': self.user_id.id,
            //                             'team_id': self.team_id.id})
            // query_result = self.env.cr.dictfetchone()
            // 
            // message = False
            // if query_result['total_won'] == 1:
            //     message = _('Go, go, go! Congrats for your first deal.')
            // elif query_result['max_team_30'] == self.expected_revenue:
            //     message = _('Boom! Team record for the past 30 days.')
            // elif query_result['max_team_7'] == self.expected_revenue:
            //     message = _('Yeah! Deal of the last 7 days for the team.')
            // elif query_result['max_user_30'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 30 days.')
            // elif query_result['max_user_7'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 7 days.')
            // return message
            */
            return default;
        }

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
            //     'text': self.env._('Tasks'),
            //     'number': number,
            //     'action_type': 'object',
            //     'action': 'action_view_tasks',
            //     'show': True,
            //     'sequence': 1,
            // }]
            // if self.rating_count != 0 and self.env.user.has_group('project.group_project_rating'):
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
            //         'show': self.rating_active,
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
            // res = dict.fromkeys(self._ids, [])
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
            //             "active": self._context.get('active_test', True),
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

        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id, object mode) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_thread_with_access(self, thread_id, mode="read", **kwargs):
            // if project_sharing_id := kwargs.get("project_sharing_id"):
            //     if token := ProjectSharingChatter._check_project_access_and_get_token(
            //         self, project_sharing_id, self._name, thread_id, kwargs.get("token")
            //     ):
            //         kwargs["token"] = token
            // return super()._get_thread_with_access(thread_id, mode, **kwargs)
            */
            return default;
        }

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
            // return [Task.description.name]
            */
            return default;
        }

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

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer()
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

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, vals):
            // """ This method handle the state changes :
            // - To lost : We need to increment corresponding lost count in scoring frequency table
            // - To won : We need to increment corresponding won count in scoring frequency table
            // - From lost to Won : We need to decrement corresponding lost count + increment corresponding won count
            // in scoring frequency table.
            // - From won to lost : We need to decrement corresponding won count + increment corresponding lost count
            // in scoring frequency table."""
            // Lead = self.env['crm.lead']
            // leads_reach_won = Lead
            // leads_leave_won = Lead
            // leads_reach_lost = Lead
            // leads_leave_lost = Lead
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead in self:
            //     if 'stage_id' in vals:
            //         if vals['stage_id'] in won_stage_ids:
            //             if lead.probability == 0:
            //                 leads_leave_lost += lead
            //             leads_reach_won += lead
            //         elif lead.stage_id.id in won_stage_ids and lead.active:  # a lead can be lost at won_stage
            //             leads_leave_won += lead
            //     if 'active' in vals:
            //         if not vals['active'] and lead.active:  # archive lead
            //             if lead.stage_id.id in won_stage_ids and lead not in leads_leave_won:
            //                 leads_leave_won += lead
            //             leads_reach_lost += lead
            //         elif vals['active'] and not lead.active:  # restore lead
            //             leads_leave_lost += lead
            // 
            // leads_reach_won._pls_increment_frequencies(to_state='won')
            // leads_leave_won._pls_increment_frequencies(from_state='won')
            // leads_reach_lost._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost._pls_increment_frequencies(from_state='lost')
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def init(self):
            // super().init()
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_applicant_job_id_stage_id_idx
            //     ON hr_applicant(job_id, stage_id)
            //     WHERE active IS TRUE
            // """)
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
            //     if project.partner_id and project.partner_id.company_id and project.company_id != project.partner_id.company_id:
            //         raise UserError(_('The project and the associated partner must be linked to the same company.'))
            //     if not account or not account.company_id:
            //         continue
            //     # if the account of the project has more than one company linked to it, or if it has aal, do not update the account, and set back the old company on the project.
            //     if (account.project_count > 1 or account.line_ids) and project.company_id != account.company_id:
            //         raise UserError(
            //             _("The project's company cannot be changed if its analytic account has analytic lines or if more than one project is linked to it."))
            //     account.company_id = project.company_id
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_display_name(self):
            // for task in self:
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

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_name(self):
            // for applicant in self:
            //     if applicant.partner_name and not applicant.candidate_id:
            //         applicant.candidate_id = self.env['hr.candidate'].create({'partner_name': applicant.partner_name})
            //     else:
            //         applicant.candidate_id.partner_name = applicant.partner_name
            */
            return default;
        }

        public async Task<TEntity> InversePersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_personal_stage_type_id(self):
            // for task in self:
            //     task.personal_stage_id.stage_id = task.personal_stage_type_id
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
            // for task in self:
            //     if task.state in CLOSED_STATES and task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id):
            //         task.recurrence_id._create_next_occurrence(task)
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
            // if not self.rating_active:
            //     res -= self.env.ref('project.mt_project_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_project_task_waiting')
            //     if not self.allow_task_dependencies and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.project_id.rating_active:
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

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['customer_id']
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
            // new_tasks = self.env['project.task']
            // # We want to copy archived task, but do not propagate an active_test context key
            // tasks = self.env['project.task'].with_context(active_test=False).search([('project_id', '=', self.id), ('parent_id', '=', False)])
            // if self.allow_task_dependencies and 'task_mapping' not in self.env.context:
            //     self = self.with_context(task_mapping=dict())
            // # preserve task name and stage, normally altered during copy
            // defaults = self._map_tasks_default_values(project)
            // new_tasks = tasks.with_context(copy_project=True).copy(defaults)
            // all_subtasks = new_tasks._get_all_subtasks()
            // project.write({'tasks': [Command.set(new_tasks.ids)]})
            // subtasks_not_displayed = all_subtasks.filtered(
            //     lambda task: not task.display_in_project
            // )
            // all_subtasks.filtered(
            //     lambda child: child.project_id == self
            // ).write({
            //     'project_id': project.id
            // })
            // subtasks_not_displayed.write({
            //     'display_in_project': False
            // })
            // return True
            */
            return default;
        }

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
            //     :param fields: list of fields to process
            //     :return dict data: contains the merged values of the new opportunity
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
            // """ Merge opportunities in one. Different cases of merge:
            //         - merge leads together = 1 new lead
            //         - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            //     The resulting lead/opportunity will be the most important one (based on its confidence level)
            //     updated with values from other opportunities to merge.
            // 
            // :param user_id : the id of the saleperson. If not given, will be determined by `_merge_data`.
            // :param team : the id of the Sales Team. If not given, will be determined by `_merge_data`.
            // 
            // :return crm.lead record resulting of th merge
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
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_id', '=', merged_data['team_id']), ('team_id', '=', False)], order='sequence, id')
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

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email_from)) or r.email_from,
            //         'email_cc': False,
            //     } for r in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // try:
            //     # check if that language is correctly installed (and active) before using it
            //     lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            //     if self.partner_id:
            //         self._message_add_suggested_recipient(
            //             recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            //     elif self.email_from:
            //         self._message_add_suggested_recipient(
            //             recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // except AccessError:  # no read access rights -> just ignore suggested recipients because this imply modifying followers
            //     pass
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(recipients, partner=self.partner_id.sudo(), reason=_('Contact'))
            // elif self.email_from:
            //     email_from = tools.email_normalize(self.email_from)
            //     if email_from and self.partner_name:
            //         email_from = tools.formataddr((self.partner_name, email_from))
            //         self._message_add_suggested_recipient(recipients, email=email_from, reason=_('Contact Email'))
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     reason = _('Customer Email') if self.partner_id.email else _('Customer')
            //     self._message_add_suggested_recipient(recipients, partner=self.partner_id, reason=reason)
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg, object custom_values) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
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
            // return super(Lead, self).message_new(msg_dict, custom_values=defaults)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False, mail_notify_author=True)  # Allows sending stage updates to the author
            // stage = False
            // candidate_defaults = {}
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg.get('from'))
            // candidate_domain = [
            //     ("email_from", "=", email_from_normalized),
            // ]
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            //     candidate_defaults['company_id'] = job.company_id.id
            //     candidate_domain = expression.AND([candidate_domain, [("company_id", "in", [job.company_id.id, False])]])
            // 
            // candidate = self.env["hr.candidate"].search(candidate_domain, limit=1)\
            //     or self.env["hr.candidate"].create({
            //         "partner_name": partner_name or email_from_normalized,
            //         **candidate_defaults,
            //     })
            // 
            // defaults = {
            //     'candidate_id': candidate.id,
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // if msg.get('from') and not job_platform:
            //     candidate.email_from = msg.get('from')
            //     candidate.partner_id = msg.get('author_id', False)
            // if msg.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg.get('subject')) + re.findall(subject_pattern, msg.get('body'))
            //     candidate.partner_name = regex_results[0] if regex_results else partner_name
            //     defaults["partner_name"] = candidate.partner_name
            //     del msg['email_from']
            // if msg.get('priority'):
            //     defaults['priority'] = msg.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg, custom_values=defaults)
            // candidate._compute_partner_phone_email()
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_new(self, msg, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // create_context = dict(self.env.context or {})
            // create_context['default_user_ids'] = False
            // create_context['mail_notify_author'] = True  # Allows sending stage updates to the author
            // if custom_values is None:
            //     custom_values = {}
            // # Auto create partner if not existant when the task is created from email
            // if not msg.get('author_id') and msg.get('email_from'):
            //     msg['author_id'] = self.env['res.partner'].create({
            //         'email': msg['email_from'],
            //         'name': msg['email_from'],
            //     }).id
            // 
            // defaults = {
            //     'name': msg.get('subject') or _("No Subject"),
            //     'allocated_hours': 0.0,
            //     'partner_id': msg.get('author_id'),
            // }
            // defaults.update(custom_values)
            // 
            // task = super(Task, self.with_context(create_context)).message_new(msg, custom_values=defaults)
            // email_list = task.email_split(msg)
            // partner_ids = [p.id for p in self.env['mail.thread']._mail_find_partner_from_emails(email_list, records=task, force_create=False) if p]
            // task.message_subscribe(partner_ids)
            // return task
            */
            return default;
        }

        public async Task<TEntity> MessagePartnerInfoFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object link_mail) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_partner_info_from_emails(self, emails, link_mail=False):
            // """ Try to propose a better recipient when having only an email by populating
            // it with the partner_name / contact_name field of the lead e.g. if lead
            // contact_name is "Raoul" and email is "raoul@raoul.fr", suggest
            // "Raoul" <raoul@raoul.fr> as recipient. """
            // result = super(Lead, self)._message_partner_info_from_emails(emails, link_mail=link_mail)
            // if not (self.partner_name or self.contact_name) or not self.email_from:
            //     return result
            // for email, partner_info in zip(emails, result):
            //     if partner_info.get('partner_id') or not email:
            //         continue
            //     # reformat email if no name information
            //     name_emails = tools.mail.email_split_tuples(email)
            //     name_from_email = name_emails[0][0] if name_emails else False
            //     if name_from_email:
            //         continue  # already containing name + email
            //     name_from_email = self.partner_name or self.contact_name
            //     emails_normalized = tools.email_normalize_all(email)
            //     email_normalized = emails_normalized[0] if emails_normalized else False
            //     if email.lower() == self.email_from.lower() or (email_normalized and self.email_normalized == email_normalized):
            //         partner_info['full_name'] = tools.formataddr((
            //             name_from_email,
            //             ','.join(emails_normalized) if emails_normalized else email))
            //         break
            // return result
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
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
            // return super(Lead, self)._message_post_after_hook(message, msg_vals)
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
            // return super(Applicant, self)._message_post_after_hook(message, msg_vals)
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
            // ):
            //     self.description = message.body
            // return super(Task, self)._message_post_after_hook(message, msg_vals)
            */
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
            // res = super(Project, self).message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
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
            // """ Set task notification based on project notification preference if user follow the project"""
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
            // super().message_unsubscribe(partner_ids=partner_ids)
            // if partner_ids:
            //     self.env['project.collaborator'].search([('partner_id', 'in', partner_ids), ('project_id', 'in', self.ids)]).unlink()
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg, object update_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_update(self, msg, update_vals=None):
            // """ Override to update the task according to the email. """
            // email_list = self.email_split(msg)
            // partner_ids = [p.id for p in self.env['mail.thread']._mail_find_partner_from_emails(email_list, records=self, force_create=False) if p]
            // self.message_subscribe(partner_ids)
            // return super(Task, self).message_update(msg, update_vals=update_vals)
            */
            return default;
        }

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
            // headers = super(Task, self)._notify_by_email_get_headers(headers=headers)
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

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.stage_id:
            //     render_context['subtitles'].append(_('Stage: %s', self.stage_id.name))
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle salesman recipients that can convert leads into opportunities
            // and set opportunities as won / lost. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // local_msg_vals = dict(msg_vals or {})
            // 
            // self.ensure_one()
            // if self.type == 'lead':
            //     convert_action = self._notify_get_action_link('controller', controller='/lead/convert', **local_msg_vals)
            //     salesman_actions = [{'url': convert_action, 'title': _('Convert to opportunity')}]
            // else:
            //     won_action = self._notify_get_action_link('controller', controller='/lead/case_mark_won', **local_msg_vals)
            //     lost_action = self._notify_get_action_link('controller', controller='/lead/case_mark_lost', **local_msg_vals)
            //     salesman_actions = [
            //         {'url': won_action, 'title': _('Mark Won')},
            //         {'url': lost_action, 'title': _('Mark Lost')}]
            // 
            // salesman_group_id = self.env.ref('sales_team.group_sale_salesman').id
            // new_group = (
            //     'group_sale_salesman',
            //     lambda pdata: pdata['type'] == 'user' and salesman_group_id in pdata['groups'],
            //     {
            //         'actions': salesman_actions,
            //         'active': True,
            //         'has_button_access': True,
            //     }
            // )
            // 
            // return [new_group] + groups
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Give access to the portal user/customer if the project visibility is portal. """
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // portal_privacy = self.privacy_visibility == 'portal'
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ['portal', 'portal_customer'] and not portal_privacy:
            //         group_data['has_button_access'] = False
            // return groups
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle project users and managers recipients that can assign
            // tasks and create new one directly from notification emails. Also give
            // access button to portal users and portal customers. If they are notified
            // they should probably have access to the document. """
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
            // if self.project_privacy_visibility == 'portal':
            //     groups.insert(0, (
            //         'allowed_portal_users',
            //         lambda pdata: pdata['type'] == 'portal',
            //         {
            //             'active': True,
            //             'has_button_access': True,
            //         }
            //     ))
            // portal_privacy = self.project_id.privacy_visibility == 'portal'
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

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of lead and opportunities to their sales team if any. """
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(Lead, leftover)._notify_get_reply_to(default=default))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(Applicant, leftover)._notify_get_reply_to(default=default))
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of tasks to their project if any. """
            // aliases = self.sudo().mapped('project_id')._notify_get_reply_to(default=default)
            // res = {task.id: aliases.get(task.project_id.id) for task in self}
            // leftover = self.filtered(lambda rec: not rec.project_id)
            // if leftover:
            //     res.update(super(Task, leftover)._notify_get_reply_to(default=default))
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

        public async Task<TEntity> OnchangeMobileValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_parent_id(self):
            // if self.display_in_project:
            //     return
            // if not self.parent_id:
            //     self.display_in_project = True
            // elif self.project_id != self.parent_id.project_id:
            //     self.project_id = self.parent_id.project_id
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

        public async Task<TEntity> OpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> OpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return self.candidate_id.action_open_employee()
            */
            return default;
        }

        public async Task<TEntity> OpenOtherApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_other_applications(self):
            // self.ensure_one()
            // similar_candidates = (
            //     self.env["hr.candidate"]
            //     .with_context(active_test=False)
            //     .search(self.candidate_id._get_similar_candidates_domain())
            //     - self.candidate_id
            // )
            // return {
            //     'name': _('Other Applications'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.applicant',
            //     'view_mode': 'list,kanban,form,pivot,graph,calendar,activity',
            //     'domain': [('id', 'in', (self.candidate_id.applicant_ids + similar_candidates.applicant_ids).ids)],
            //     'context': {
            //         'active_test': False,
            //         'search_default_stage': 1,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            //     'context': self._context
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> OpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> OpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_task(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self._context
            // }
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

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=[]):
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
            //     query = self.env['crm.lead'].with_context(active_test=False)._where_calc(domain)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self._cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self._cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self._cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self._cr.dictfetchall()
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

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False):
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
            // :return: probability in percent (and integer rounded) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         '&',
            //             ('active', '=', True), ('id', 'in', self.ids),
            //             '|',
            //                 ('probability', '=', None),
            //                 '&',
            //                     ('probability', '<', 100), ('probability', '>', 0)
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
            //     value = frequency['value']
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
            // 
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             s_lead_won *= value_result['won'] / total_won
            //             s_lead_lost *= value_result['lost'] / total_lost
            // 
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // return lead_probabilities
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
            // :param frequencies: lead_scoring_frequencies
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_id', '=', False)], order='sequence, id', limit=1)
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
            //         '&',
            //             ('create_date', '>=', pls_start_date),
            //             '|',
            //                 ('probability', '=', 100),
            //                 '&',
            //                     ('probability', '=', 0), ('active', '=', False)
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
            // for lead_id, values in leads_values_dict.items():
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
            // :param name : furtur name of the partner
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
            //     'parent_id': parent_id,
            //     'phone': self.phone,
            //     'mobile': self.mobile,
            //     'email': email_parts[0] if email_parts else False,
            //     'title': self.title.id,
            //     'function': self.function,
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     'is_company': is_company,
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

        public async Task<TEntity> ProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            // rating = super(Task, self).rating_apply(
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
            // res = super(Task, self)._rating_get_partner()
            // if not res and self.project_id.partner_id:
            //     return self.project_id.partner_id
            // return res
            */
            return default;
        }

        public async Task<TEntity> ReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object groupby, object offset, object limit, object @orderby, object lazy) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def read_group(self, domain, fields, groupby, offset=0, limit=None, orderby=False, lazy=True):
            // # A read_group can not be performed if records are grouped by personal_stage_type_id as it is a computed field.
            // # personal_stage_type_ids behaves like a M2O from the point of view of the user, we therefore use this field instead.
            // if 'personal_stage_type_id' in groupby and (not lazy or groupby[0] == 'personal_stage_type_id'):
            //     groupby = ["personal_stage_type_ids" if field == "personal_stage_type_id" else field for field in groupby] # limitation: problem when both personal_stage_type_id and personal_stage_type_ids appear in read_group, but this has no functional utility
            //     result = super().read_group(domain, fields, groupby, offset, limit, orderby, lazy)
            //     for group in result:
            //         group['personal_stage_type_id'] = group.pop('personal_stage_type_ids', False)
            //         group['personal_stage_type_id_count'] = group.pop('personal_stage_type_ids_count', 0)
            //     return result
            // return super().read_group(domain, fields, groupby, offset, limit, orderby, lazy)
            */
            return default;
        }

        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_personal_stage_type_ids(self, stages, domain):
            // return stages.search(['|', ('id', 'in', stages.ids), ('user_id', '=', self.env.user.id)])
            */
            return default;
        }

        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self._context.get('default_team_id')
            // if team_id:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_id', '=', False), ('team_id', '=', team_id)]
            // else:
            //     search_domain = ['|', ('id', 'in', stages.ids), ('team_id', '=', False)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve job_id from the context and write the domain: ids + contextual columns (job or default)
            // job_id = self._context.get('default_job_id')
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
            // if 'default_project_id' in self.env.context and not self._context.get('subtask_action') and 'project_kanban' in self.env.context:
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
            //     self._cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<TEntity> RecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> RedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_redirect_to_project_task_form(self):
            // menu_id = self.env.ref('project.menu_project_management_all_tasks').id
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f"/odoo/1/action-project.act_project_project_2_project_task_all/{self.id}?menu_id={menu_id}",
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> RescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> SELFREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return PROJECT_TASK_READABLE_FIELDS | self.SELF_WRITABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> SELFWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def SELF_WRITABLE_FIELDS(self):
            // return PROJECT_TASK_WRITABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param smart_calendar: boolean, to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :return dict: dictionary value for created Meeting view
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

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_application_status(self, operator, value):
            // supported_operators = ['=', '!=', 'in', 'not in']
            // if operator not in supported_operators:
            //     raise UserError(_('Operation not supported'))
            // 
            // # Normalize value to be a list to simplify processing
            // if isinstance(value, (str, bool)):
            //     value = [value]
            // 
            // # Ensure all values are either correct strings or False
            // valid_statuses = ['ongoing', 'hired', 'refused', 'archived']
            // if not all(v in valid_statuses or v is False for v in value):
            //     raise UserError(_('Some values do not exist in the application status'))
            // 
            // # Map statuses to domain filters
            // for status in value:
            //     if status == 'refused':
            //         domain = [('refuse_reason_id', '!=', None)]
            //     elif status == 'hired':
            //         domain = [('date_closed', '!=', False)]
            //     elif status == 'archived' or status is False:
            //         domain = [('active', '=', False)]
            //     elif status == 'ongoing':
            //         domain = ['&', ('active', '=', True), ('date_closed', '=', False)]
            // 
            // # Invert the domain for '!=' and 'not in' operators
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     domain.insert(0, expression.NOT_OPERATOR)
            //     domain = expression.distribute_not(domain)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
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
            // my_lead_domain = expression.AND([[('id', 'in', my_lead_ids)], domain])
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
            //     expression.AND([[('id', 'not in', my_lead_ids_skip)], domain]),
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
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise NotImplementedError(_(
            //         "The search does not support operator %(operator)s or value %(value)s.",
            //         operator=operator,
            //         value=value,
            //     ))
            // domain = [
            //     ('allow_milestones', '=', True),
            //     ('milestone_id', '!=', False),
            //     ('milestone_id.is_reached', '=', False),
            //     ('milestone_id.deadline', '!=', False), ('milestone_id.deadline', '<', fields.Date.today())
            // ]
            // if (operator == '!=' and value) or (operator == '=' and not value):
            //     domain.insert(0, expression.NOT_OPERATOR)
            //     domain = expression.distribute_not(domain)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_is_closed(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise NotImplementedError(_(
            //         "The search does not support operator %(operator)s or value %(value)s.",
            //         operator=operator,
            //         value=value,
            //     ))
            // if (operator == '!=' and value) or (operator == '=' and not value):
            //     searched_states = self.OPEN_STATES
            // else:
            //     searched_states = list(CLOSED_STATES.keys())
            // domain = [
            //     ('state', 'in', searched_states)
            // ]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // return [('favorite_user_ids', 'in' if (operator == '=') == value else 'not in', self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_milestone_exceeded(self, operator, value):
            // if not isinstance(value, bool):
            //     raise ValueError(_('Invalid value: %s', value))
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('Invalid operator: %s', operator))
            // 
            // sql = SQL("""(
            //     SELECT P.id
            //       FROM project_project P
            //  LEFT JOIN project_milestone M ON P.id = M.project_id
            //      WHERE M.is_reached IS false
            //        AND P.allow_milestones IS true
            //        AND M.deadline <= CAST(now() AS date)
            // )""")
            // if (operator == '=' and value is True) or (operator == '!=' and value is False):
            //     operator_new = 'in'
            // else:
            //     operator_new = 'not in'
            // return [('id', operator_new, sql)]
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
            //             op = "ilike" if op == "child_of" else op
            //             if isinstance(value, list) and all(isinstance(val, int) for val in value):
            //                 new_domain.append(("id", op, value))
            //             if isinstance(value, str) or (isinstance(value, list) and not all(isinstance(val, str) for val in value)):
            //                 new_domain.append(("name", op, value))
            //             if isinstance(value, int):
            //                 if op == "=":
            //                     op = "in"
            //                 if op == "!=":
            //                     op = "not in"
            //                 new_domain.append(("id", op, [value]))
            //         else:
            //             new_domain.append(dom)
            //     return new_domain
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
            // filtered_domain = _change_operator(filtered_domain)
            // if not filtered_domain:
            //     return self.env[comodel]
            // if additional_domain:
            //     filtered_domain = expression.AND([filtered_domain, additional_domain])
            // return self.env[comodel].search(filtered_domain)
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_partner_name(self, operator, value):
            // return [('candidate_id.partner_name', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchPersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_personal_stage_type_id(self, operator, value):
            // return [('personal_stage_type_ids', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_portal_user_names(self, operator, value):
            // if operator != 'ilike' and not isinstance(value, str):
            //     raise ValidationError(_('Not Implemented.'))
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

        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_email_notify_to_cc(self, partners_to_notify):
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
            //         record_name=self.display_name,
            //         email_layout_xmlid='mail.mail_notification_layout',
            //         model_description=task_model_description,
            //         mail_auto_delete=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> SendRatingAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _send_rating_all(self):
            // projects = self.search([
            //     ('rating_active', '=', True),
            //     ('rating_status', '=', 'periodic'),
            //     ('rating_request_deadline', '<=', fields.Datetime.now())
            // ])
            // for project in projects:
            //     project.task_ids._send_task_rating_mail()
            //     project._compute_rating_request_deadline()
            //     self.env.cr.commit()
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
            //     if rating_template and partner and partner != self.env.user.partner_id:
            //         task.rating_send_request(rating_template, lang=task.partner_id.lang, force_send=force_send)
            */
            return default;
        }

        public async Task<TEntity> SetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // self.write({'probability': self.automated_probability})
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

        public async Task<TEntity> SetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 or active = False """
            // res = self.action_archive()
            // if additional_values:
            //     self.write(dict(additional_values))
            // return res
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

        public async Task<TEntity> SetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: probability = 100 (active untouched) """
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

        public async Task<TEntity> SetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> SnoozeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_snooze(self):
            // self.ensure_one()
            // my_next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // my_next_activity.action_snooze()
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
            //     Parameter of the stage search taken from the lead:
            //     - section_id: if set, stages must belong to this section or
            //       be a default stage; if not set, stages must be default
            //       stages
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
            //     search_domain = ['|', ('team_id', '=', False), ('team_id', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_id', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

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
            //             record_name=task.display_name,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             model_description=task_model_description,
            //             mail_auto_delete=False,
            //         )
            */
            return default;
        }

        protected async Task<object> ThreadToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _thread_to_store(self, store: Store, /, *, request_list=None, **kwargs):
            // super()._thread_to_store(store, request_list=request_list, **kwargs)
            // if request_list and "followers" in request_list:
            //     store.add(
            //         self,
            //         {"collaborator_ids": Store.many(self.collaborator_ids.partner_id, only_id=True)},
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def toggle_active(self):
            // """ When archiving: mark probability as 0. When re-activating
            // update probability again, for leads and opportunities. """
            // res = super(Lead, self).toggle_active()
            // activated = self.filtered(lambda lead: lead.active)
            // archived = self.filtered(lambda lead: not lead.active)
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // if archived:
            //     archived.write({'probability': 0, 'automated_probability': 0})
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def toggle_active(self):
            // self = self.with_context(just_unarchived=True)
            // res = super(Applicant, self).toggle_active()
            // active_applicants = self.filtered(lambda applicant: applicant.active)
            // if active_applicants:
            //     active_applicants.reset_applicant()
            // return res
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.probability == 100 and self.stage_id:
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'active' in init_values and self.active:
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'active' in init_values and not self.active:
            //     return self.env.ref('crm.mt_lead_lost')
            // return super(Lead, self)._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_subtype(self, init_values):
            // record = self[0]
            // if 'stage_id' in init_values and record.stage_id:
            //     return self.env.ref('hr_recruitment.mt_applicant_stage_changed')
            // return super(Applicant, self)._track_subtype(init_values)
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
            // return super(Task, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super(Applicant, self)._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant._context.get('just_moved')\
            //     and not applicant._context.get('just_unarchived'):
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
            // res = super(Task, self)._track_template(changes)
            // test_task = self[0]
            // if 'stage_id' in changes and test_task.stage_id.mail_template_id:
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
            // return super(Lead, self).unlink()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def unlink(self):
            // # Delete the empty related analytic account
            // analytic_accounts_to_delete = self.env['account.analytic.account']
            // for project in self:
            //     if project.account_id and not project.account_id.line_ids:
            //         analytic_accounts_to_delete |= project.account_id
            // self.with_context(active_test=False).tasks.unlink()
            // result = super(Project, self).unlink()
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

        public async Task<TEntity> UnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_unlink_recurrence(self):
            // self.recurrence_id.task_ids.recurring_task = False
            // self.recurrence_id.unlink()
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
            // # (Won : probability = 100 | Lost : probability = 0 or inactive. Here, inactive won't be returned anyway)
            // # Get also all the lead without probability --> These are the new leads. Activate auto probability on them.
            // pending_lead_domain = [
            //     '&',
            //         '&',
            //             ('stage_id', '!=', False), ('create_date', '>=', pls_start_date),
            //         '|',
            //             ('probability', '=', False),
            //             '&',
            //                 ('probability', '<', 100), ('probability', '>', 0)
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     lead_probabilities.update(leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True))
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
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
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

        public async Task<TEntity> ViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_all_rating(self):
            // """ return the action to see all the rating of the project and activate default filters"""
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_view_project_rating')
            // action['display_name'] = _("%(name)s's Rating", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context.update(self._context)
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

        public async Task<TEntity> ViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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

        public async Task<TEntity> ViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailTrackingDurationMixinable
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
            //     'active_test': self.active
            //     })
            // action['context'] = context
            // return action
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
            //             vals.update({'probability': 100, 'automated_probability': 100})
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
            // if any(field in ['active', 'stage_id'] for field in vals):
            //     self._handle_won_lost(vals)
            // 
            // if not stage_is_won:
            //     return super(Lead, self).write(vals)
            // 
            // # stage change between two won stages: does not change the date_closed
            // leads_already_won = self.filtered(lambda lead: lead.stage_id.is_won)
            // remaining = self - leads_already_won
            // if remaining:
            //     result = super(Lead, remaining).write(vals)
            // if leads_already_won:
            //     vals.pop('date_closed', False)
            //     result = super(Lead, leads_already_won).write(vals)
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
            //         res = super().write(vals)
            // else:
            //     res = super().write(vals)
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            //     self.message_unsubscribe(partner_ids=interviewers_to_clean.partner_id.ids)
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
            //                 record_name=applicant.display_name,
            //                 model_description="Applicant",
            //             )
            // if vals.get('date_closed'):
            //     for applicant in self:
            //         if applicant.job_id.date_to:
            //             applicant.candidate_id.availability = applicant.job_id.date_to + relativedelta(days=1)
            // 
            // if vals.get("company_id") and not self.env.context.get('do_not_propagate_company', False):
            //     self.candidate_id.with_context(do_not_propagate_company=True).write({"company_id": vals["company_id"]})
            //     self.candidate_id.applicant_ids.with_context(do_not_propagate_company=True).write({"company_id": vals["company_id"]})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def write(self, vals):
            // if vals.get('access_token'):
            //     self.ensure_one()  # We are not supposed to add a single access token to multiple project
            //     if self.privacy_visibility != 'portal':
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
            // res = super(Project, self).write(vals) if vals else True
            // 
            // if 'allow_task_dependencies' in vals and not vals.get('allow_task_dependencies'):
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('state', '=', '04_waiting_normal')]).write({'state': '01_in_progress'})
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
            // if len(self) == 1:
            //     handle_history_divergence(self, 'description', vals)
            // portal_can_write = False
            // project_link_per_task_id = {}
            // partner_ids = []
            // if self.env.user._is_portal() and not self.env.su:
            //     # Check if all fields in vals are in SELF_WRITABLE_FIELDS
            //     self._ensure_fields_are_accessible(vals.keys(), operation='write', check_group_user=False)
            //     self.check_access('write')
            //     portal_can_write = True
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
            //         unvalid_milestone_tasks.write({'milestone_id': False})
            //         if valid_milestone_tasks:
            //             valid_milestone_tasks.write({'milestone_id': vals['milestone_id']})
            //         del vals['milestone_id']
            // 
            //     # 2. Parent's milestone is set to subtask with no milestone recursively
            //     subtasks_to_update = valid_milestone_tasks.child_ids.filtered(
            //         lambda task: (task not in self and \
            //                       not task.milestone_id and \
            //                       task.project_id == milestone.project_id and \
            //                       task.state not in CLOSED_STATES))
            // 
            //     # 3. If parent and child task share the same milestone, child task's milestone is updated when the parent one is changed
            //     # No need to check if state is changed in vals as it won't affect the subtasks selected for update
            //     if 'project_id' not in vals:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and \
            //                           task.milestone_id == task.parent_id.milestone_id and \
            //                           task.state not in CLOSED_STATES))
            //     else:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and \
            //                           (not task.display_in_project or task.project_id.id == vals['project_id']) and \
            //                           task.milestone_id == task.parent_id.milestone_id  and \
            //                           task.state not in CLOSED_STATES))
            //     if subtasks_to_update:
            //         subtasks_to_update.write({'milestone_id': vals['milestone_id']})
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
            //     vals.update(self.update_date_end(vals['stage_id']))
            //     vals['date_last_stage_update'] = now
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
            // # The sudo is required for a portal user as the record update
            // # requires the write access on others models, as rating.rating
            // # in order to keep the same name than the task.
            // if portal_can_write:
            //     self_no_sudo, self = self, self.sudo().with_context(self._get_portal_sudo_context())
            //     vals_no_sudo, vals = self._get_portal_sudo_vals(vals)
            // 
            // # Track user_ids to send assignment notifications
            // old_user_ids = {t: t.user_ids for t in self.sudo()}
            // 
            // if "personal_stage_type_id" in vals and not vals['personal_stage_type_id']:
            //     del vals['personal_stage_type_id']
            // 
            // # sends an email to the 'Task Creation' subtype subscribers
            // # When project_id is changed
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
            //     vals['display_in_project'] = True
            // result = super().write(vals)
            // if portal_can_write:
            //     super(Task, self_no_sudo).write(vals_no_sudo)
            // 
            // if 'user_ids' in vals:
            //     self._populate_missing_personal_stages()
            // 
            // # user_ids change: update date_assign
            // if 'user_ids' in vals:
            //     for task in self:
            //         if not task.user_ids and task.date_assign:
            //             task.date_assign = False
            //         elif 'date_assign' not in vals and task.id in task_ids_without_user_set:
            //             task.date_assign = now
            // 
            // # rating on stage
            // if 'stage_id' in vals and vals.get('stage_id'):
            //     self.filtered(lambda x: x.project_id.rating_active and x.project_id.rating_status == 'stage')._send_task_rating_mail(force_send=True)
            // 
            // if 'state' in vals:
            //     # specific use case: when the blocked task goes from 'forced' done state to a not closed state, we fix the state back to waiting
            //     for task in self:
            //         if task.allow_task_dependencies:
            //             if task.is_blocked_by_dependences() and vals['state'] not in CLOSED_STATES and vals['state'] != '04_waiting_normal':
            //                 task.state = '04_waiting_normal'
            //         task.date_last_stage_update = now
            // elif 'project_id' in vals:
            //     self.filtered(lambda t: t.state != '04_waiting_normal').state = '01_in_progress'
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
            //                 destination_project=self.project_id._get_html_link(title=self.project_id.display_name),
            //             )
            //         else:
            //             body = _('Task Converted from To-Do')
            //         task.message_notify(
            //             body=body,
            //             partner_ids=partner_ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             record_name=task.display_name,
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
            // domain = [('project_id', 'in', self.ids), ('display_in_project', '=', True)]
            // if additional_domain:
            //     domain = AND([domain, additional_domain])
            // tasks_count_by_project = dict(self.env['project.task'].with_context(
            //     active_test=any(project.active for project in self)
            // )._read_group(domain, ['project_id'], ['__count']))
            // for project in self:
            //     project.update({count_field: tasks_count_by_project.get(project, 0)})
            */
            return default;
        }
    }
}