using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("rating", Depends = new[] { "mail" })]
    public class RatingParentMixinAppService : ApplicationService, IRatingParentMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public RatingParentMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_join(self):
            // self.ensure_one()
            // self.user_ids = [Command.link(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionQuitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_quit(self):
            // self.ensure_one()
            // self.user_ids = [Command.unlink(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            return default;
        }

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionViewChatbotScriptsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_chatbot_scripts(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.chatbot_script_action')
            // chatbot_script_ids = self.env['im_livechat.channel.rule'].search(
            //     [('channel_id', 'in', self.ids)]).mapped('chatbot_script_id')
            // if len(chatbot_script_ids) == 1:
            //     action['res_id'] = chatbot_script_ids.id
            //     action['view_mode'] = 'form'
            //     action['views'] = [(False, 'form')]
            // else:
            //     action['domain'] = [('id', 'in', chatbot_script_ids.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_rating(self):
            // """ Action to display the rating relative to the channel, so all rating of the
            //     sessions of the current channel
            //     :returns : the ir.action 'action_view_rating' with the correct context
            // """
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.rating_rating_action_livechat')
            // action['context'] = {'search_default_parent_res_name': self.name}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> AreYouInsideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _are_you_inside(self):
            // for channel in self:
            //     channel.are_you_inside = self.env.user in channel.user_ids
            */
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_account_id(self):
            // # Overriden from 'analytic.plan.fields.mixin'
            // pass
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super(Project, self)._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_warning(self):
            // super(Project, self)._compute_access_warning()
            // for project in self.filtered(lambda x: x.privacy_visibility != 'portal'):
            //     project.access_warning = _(
            //         "This project is currently restricted to \"Invited internal users\". The project's visibility will be changed to \"invited portal users and all internal users (public)\" in order to make it accessible to the recipients.")
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableOperatorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_available_operator_ids(self):
            // for record in self:
            //     record.available_operator_ids = record.user_ids.filtered(lambda user: user._is_user_available())
            */
            return default;
        }

        public async Task<TEntity> ComputeChatbotScriptCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_chatbot_script_count(self):
            // data = self.env['im_livechat.channel.rule']._read_group(
            //     [('channel_id', 'in', self.ids)], ['channel_id'], ['chatbot_script_id:count_distinct'])
            // mapped_data = {channel.id: count_distinct for channel, count_distinct in data}
            // for channel in self:
            //     channel.chatbot_script_count = mapped_data.get(channel.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_company_id(self):
            // for project in self:
            //     # if a new restriction is put on the account or the customer, the restriction on the project is updated.
            //     if project.account_id.company_id:
            //         project.company_id = project.account_id.company_id
            //     if not project.company_id and project.partner_id.company_id:
            //         project.company_id = project.partner_id.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_favorite(self):
            // for project in self:
            //     project.is_favorite = self.env.user in project.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_color(self):
            // for project in self:
            //     project.last_update_color = STATUS_COLOR[project.last_update_status]
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_status(self):
            // for project in self:
            //     project.last_update_status = project.last_update_id.status or 'to_define'
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeNbrChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_nbr_channel(self):
            // data = self.env['discuss.channel']._read_group([
            //     ('livechat_channel_id', 'in', self.ids),
            // ], ['livechat_channel_id'], ['__count'])
            // channel_count = {livechat_channel.id: count for livechat_channel, count in data}
            // for record in self:
            //     record.nbr_channel = channel_count.get(record.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeRatingPercentageSatisfactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_parent_mixin.py) ---
            // def _compute_rating_percentage_satisfaction(self):
            // # build domain and fetch data
            // domain = [('parent_res_model', '=', self._name), ('parent_res_id', 'in', self.ids), ('rating', '>=', rating_data.RATING_LIMIT_MIN), ('consumed', '=', True)]
            // if self._rating_satisfaction_days:
            //     domain += [('write_date', '>=', fields.Datetime.to_string(fields.datetime.now() - timedelta(days=self._rating_satisfaction_days)))]
            // data = self.env['rating.rating']._read_group(domain, ['parent_res_id', 'rating'], ['__count'])
            // 
            // # get repartition of grades per parent id
            // default_grades = {'great': 0, 'okay': 0, 'bad': 0}
            // grades_per_parent = dict((parent_id, dict(default_grades)) for parent_id in self.ids)  # map: {parent_id: {'great': 0, 'bad': 0, 'ok': 0}}
            // rating_scores_per_parent = defaultdict(int)  # contains the total of the rating values per record
            // for parent_id, rating, count in data:
            //     grade = rating_data._rating_to_grade(rating)
            //     grades_per_parent[parent_id][grade] += count
            //     rating_scores_per_parent[parent_id] += rating * count
            // 
            // # compute percentage per parent
            // for record in self:
            //     repartition = grades_per_parent.get(record.id, default_grades)
            //     rating_count = sum(repartition.values())
            //     record.rating_count = rating_count
            //     record.rating_percentage_satisfaction = repartition['great'] * 100 / rating_count if rating_count else -1
            //     record.rating_avg = rating_scores_per_parent[record.id] / rating_count if rating_count else 0
            //     record.rating_avg_percentage = record.rating_avg / 5
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingRequestDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_resource_calendar_id(self):
            // for project in self:
            //     project.resource_calendar_id = project.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            */
            return default;
        }

        public async Task<TEntity> ComputeScriptExternalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_script_external(self):
            // values = {
            //     "dbname": self._cr.dbname,
            // }
            // for record in self:
            //     values["channel_id"] = record.id
            //     values["url"] = record.get_base_url()
            //     record.script_external = self.env['ir.qweb']._render('im_livechat.external_loader', values) if record.id else False
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_completion_percentage(self):
            // for task in self:
            //     task.task_completion_percentage = task.task_count and 1 - task.open_task_count / task.task_count
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_count(self):
            // self.__compute_task_count()
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ComputeWebPageLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_web_page_link(self):
            // for record in self:
            //     record.web_page = "%s/im_livechat/support/%i" % (record.get_base_url(), record.id) if record.id else False
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if default and 'name' in default:
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", project.name)) for project, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> DefaultButtonTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_button_text(self):
            // return _('Have a Question? Chat with us.')
            */
            return default;
        }

        public async Task<TEntity> DefaultDefaultMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_default_message(self):
            // return _('How may I help you?')
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _default_stage_id(self):
            // # Since project stages are order by sequence first, this should fetch the one with the lowest sequence number.
            // return self.env['project.project.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_user_ids(self):
            // return [(6, 0, [self._uid])]
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetChannelInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_channel_infos(self):
            // self.ensure_one()
            // 
            // return {
            //     'header_background_color': self.header_background_color,
            //     'button_background_color': self.button_background_color,
            //     'title_color': self.title_color,
            //     'button_text_color': self.button_text_color,
            //     'button_text': self.button_text,
            //     'input_placeholder': self.input_placeholder,
            //     'default_message': self.default_message,
            //     "channel_name": self.name,
            //     "channel_id": self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetLessActiveOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operator_statuses, object operators) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_less_active_operator(self, operator_statuses, operators):
            // """ Retrieve the most available operator based on the following criteria:
            // - Lowest number of active chats.
            // - Not in  a call.
            // - If an operator is in a call and has two or more active chats, don't
            //   give priority over an operator with more conversations who is not in a
            //   call.
            // 
            // :param operator_statuses: list of dictionaries containing the operator's
            //     id, the number of active chats and a boolean indicating if the
            //     operator is in a call. The list is ordered by the number of active
            //     chats (ascending) and whether the operator is in a call
            //     (descending).
            // :param operators: recordset of :class:`ResUsers` operators to choose from.
            // :return: the :class:`ResUsers` record for the chosen operator
            // """
            // if not operators:
            //     return False
            // 
            // # 1) only consider operators in the list to choose from
            // operator_statuses = [
            //     s for s in operator_statuses if s['livechat_operator_id'] in set(operators.partner_id.ids)
            // ]
            // 
            // # 2) try to select an inactive op, i.e. one w/ no active status (no recent chat)
            // active_op_partner_ids = {s['livechat_operator_id'] for s in operator_statuses}
            // candidates = operators.filtered(lambda o: o.partner_id.id not in active_op_partner_ids)
            // if candidates:
            //     return random.choice(candidates)
            // 
            // # 3) otherwise select least active ops, based on status ordering (count + in_call)
            // best_status = operator_statuses[0]
            // best_status_op_partner_ids = {
            //     s['livechat_operator_id']
            //     for s in operator_statuses
            //     if (s['count'], s['in_call']) == (best_status['count'], best_status['in_call'])
            // }
            // candidates = operators.filtered(lambda o: o.partner_id.id in best_status_op_partner_ids)
            // return random.choice(candidates)
            */
            return default;
        }

        public async Task<TEntity> GetLivechatDiscussChannelValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object anonymous_name, Guid previous_operator_id, object chatbot_script, Guid user_id, Guid country_id, object lang) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(
            //     self, anonymous_name, previous_operator_id=None, chatbot_script=None, user_id=None, country_id=None, lang=None
            // ):
            //     user_operator = False
            //     if chatbot_script:
            //         if chatbot_script.id not in self.browse(self.ids).mapped('rule_ids.chatbot_script_id.id'):
            //             return False
            //     else:
            //         user_operator = self._get_operator(previous_operator_id=previous_operator_id, lang=lang, country_id=country_id)
            //         if not user_operator:
            //             # no one available
            //             return False
            //     # partner to add to the discuss.channel
            //     operator_partner_id = user_operator.partner_id.id if user_operator else chatbot_script.operator_partner_id.id
            //     members_to_add = [
            //         Command.create({
            //             # making sure the unpin_dt is always later than the last_interest_dt
            //             # so that the channel is always unpinned at first
            //             'last_interest_dt': fields.Datetime.now() - timedelta(seconds=30),
            //             'partner_id': operator_partner_id,
            //             'unpin_dt': fields.Datetime.now(),
            //         })
            //     ]
            //     visitor_user = False
            //     if user_id:
            //         visitor_user = self.env['res.users'].browse(user_id)
            //         if visitor_user and visitor_user.active and user_operator and visitor_user != user_operator:  # valid session user (not public)
            //             members_to_add.append(Command.create({'partner_id': visitor_user.partner_id.id}))
            // 
            //     if chatbot_script:
            //         name = chatbot_script.title
            //     else:
            //         name = ' '.join([
            //             visitor_user.display_name if visitor_user else anonymous_name,
            //             user_operator.livechat_username or user_operator.name
            //         ])
            // 
            //     return {
            //         'channel_member_ids': members_to_add,
            //         'livechat_active': True,
            //         'livechat_operator_id': operator_partner_id,
            //         'livechat_channel_id': self.id,
            //         'chatbot_current_step_id': chatbot_script._get_welcome_steps()[-1].id if chatbot_script else False,
            //         'anonymous_name': False if user_id else anonymous_name,
            //         'country_id': country_id,
            //         'channel_type': 'livechat',
            //         'name': name,
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetLivechatInfoAsync<TEntity>(IEnumerable<TEntity> entities, object username) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def get_livechat_info(self, username=None):
            // self.ensure_one()
            // 
            // if username is None:
            //     username = _('Visitor')
            // info = {}
            // info['available'] = self.chatbot_script_count or len(self.available_operator_ids) > 0
            // info['server_url'] = self.get_base_url()
            // info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // if info['available']:
            //     info['options'] = self._get_channel_infos()
            //     info['options']["default_username"] = username
            // return info
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid previous_operator_id, object lang, Guid country_id) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator(self, previous_operator_id=None, lang=None, country_id=None):
            // """ Return an operator for a livechat. Try to return the previous
            // operator if available. If not, one of the most available operators be
            // returned.
            // 
            // A livechat is considered 'active' if it has at least one message within
            // the 30 minutes. This method will try to match the given lang and
            // country_id.
            // 
            // (Some annoying conversions have to be made on the fly because this model
            // holds 'res.users' as available operators and the discuss_channel model
            // stores the partner_id of the randomly selected operator)
            // 
            // :param previous_operator_id: id of the previous operator with whom the
            //     visitor was chatting.
            // :param lang: code of the preferred lang of the visitor.
            // :param country_id: id of the country of the visitor.
            // :return : user
            // :rtype : res.users
            // """
            // if not self.available_operator_ids:
            //     return False
            // # FIXME: remove inactive call sessions so operators no longer in call are available
            // # sudo: required to use garbage collecting function.
            // self.env["discuss.channel.rtc.session"].sudo()._gc_inactive_sessions()
            // self.env.cr.execute("""
            //     WITH operator_rtc_session AS (
            //         SELECT COUNT(DISTINCT s.id) as nbr, member.partner_id as partner_id
            //           FROM discuss_channel_rtc_session s
            //           JOIN discuss_channel_member member ON (member.id = s.channel_member_id)
            //           GROUP BY member.partner_id
            //     )
            //     SELECT COUNT(DISTINCT c.id), COALESCE(rtc.nbr, 0) > 0 as in_call, c.livechat_operator_id
            //     FROM discuss_channel c
            //     LEFT OUTER JOIN mail_message m ON c.id = m.res_id AND m.model = 'discuss.channel'
            //     LEFT OUTER JOIN operator_rtc_session rtc ON rtc.partner_id = c.livechat_operator_id
            //     WHERE c.channel_type = 'livechat' AND c.create_date > ((now() at time zone 'UTC') - interval '24 hours')
            //     AND (
            //         c.livechat_active IS TRUE
            //         OR m.create_date > ((now() at time zone 'UTC') - interval '30 minutes')
            //     )
            //     AND c.livechat_operator_id in %s
            //     GROUP BY c.livechat_operator_id, rtc.nbr
            //     ORDER BY COUNT(DISTINCT c.id) < 2 OR rtc.nbr IS NULL DESC, COUNT(DISTINCT c.id) ASC, rtc.nbr IS NULL DESC""",
            //     (tuple(self.available_operator_ids.partner_id.ids),)
            // )
            // operator_statuses = self.env.cr.dictfetchall()
            // operator = None
            // # Try to match the previous operator
            // if previous_operator_id in self.available_operator_ids.partner_id.ids:
            //     previous_operator_status = next(
            //         (status for status in operator_statuses if status['livechat_operator_id'] == previous_operator_id),
            //         None
            //     )
            //     if not previous_operator_status or previous_operator_status['count'] < 2 or not previous_operator_status['in_call']:
            //         previous_operator_user = next(
            //             available_user
            //             for available_user in self.available_operator_ids
            //             if available_user.partner_id.id == previous_operator_id
            //         )
            //         return previous_operator_user
            // # Try to match an operator with the same main lang as the visitor
            // # If no operator with the same lang, try to match an operator with the addition lang
            // if lang:
            //     same_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.lang == lang)
            //     if same_lang_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_lang_operator_ids)
            //     else:
            //         addition_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: lang in operator.res_users_settings_id.livechat_lang_ids.mapped('code'))
            //         if addition_lang_operator_ids:
            //             operator = self._get_less_active_operator(operator_statuses, addition_lang_operator_ids)
            // # Try to match an operator with the same country as the visitor
            // if country_id and not operator:
            //     same_country_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.country_id.id == country_id)
            //     if same_country_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_country_operator_ids)
            // # Try to get a random operator, regardless of the lang or the country
            // if not operator:
            //     operator = self._get_less_active_operator(operator_statuses, self.available_operator_ids)
            // return operator
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_plan_domain(self, plan):
            // return AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return [('account_id', 'in', self.account_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_items_from_aal(with_action)
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_parent_mixin.py) ---
            // def _search_rating_avg(self, operator, value):
            // if operator not in rating_data.OPERATOR_MAPPING:
            //     raise NotImplementedError('This operator %s is not supported in this search method.' % operator)
            // domain = [('parent_res_model', '=', self._name), ('consumed', '=', True), ('rating', '>=', rating_data.RATING_LIMIT_MIN)]
            // if self._rating_satisfaction_days:
            //     min_date = fields.datetime.now() - timedelta(days=self._rating_satisfaction_days)
            //     domain = expression.AND([domain, [('write_date', '>=', fields.Datetime.to_string(min_date))]])
            // rating_read_group = self.env['rating.rating'].sudo()._read_group(domain, ['parent_res_id'], ['rating:avg'])
            // parent_res_ids = [
            //     parent_res_id
            //     for parent_res_id, rating_avg in rating_read_group
            //     if rating_data.OPERATOR_MAPPING[operator](float_compare(rating_avg, value, 2), 0)
            // ]
            // return [('id', 'in', parent_res_ids)]
            */
            return default;
        }

        public async Task<TEntity> SendRatingAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return self.env.user.has_group('analytic.group_analytic_accounting')
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return True
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

        protected async Task<object> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _to_store(self, store: Store, /, *, fields=None):
            // if fields is None:
            //     fields = []
            // store.add(self._name, self._read_format(fields))
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_project_stage_change')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IRatingParentMixinable
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