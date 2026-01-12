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
    [Module("rating", Category = "Productivity", Depends = new[] { "mail" })]
    public class RatingParentMixinAppService : ApplicationService, IRatingParentMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public RatingParentMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values, object role_to_users_mapping) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionCreateTemplateFromProjectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_join(self):
            // self.ensure_one()
            // if not self.env.user.has_group("im_livechat.im_livechat_group_user"):
            //     raise AccessError(_("Only Live Chat operators can join Live Chat channels"))
            // # sudo: im_livechat.channel - operators can join channels
            // self.sudo().user_ids = [Command.link(self.env.user.id)]
            // Store(bus_channel=self.env.user).add(self, ["are_you_inside", "name"]).bus_send()
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
            // # sudo: im_livechat.channel - users can leave channels
            // self.sudo().user_ids = [Command.unlink(self.env.user.id)]
            // Store(bus_channel=self.env.user).add(self.sudo(), ["are_you_inside", "name"]).bus_send()
            */
            return default;
        }

        public async Task<TEntity> ActionToggleProjectTemplateModeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            // action = self.env["ir.actions.act_window"]._for_xml_id(
            //     "im_livechat.discuss_channel_action_from_livechat_channel"
            // )
            // action["context"] = {
            //     "search_default_parent_res_name": self.name,
            //     "search_default_fiter_session_rated": "1"
            // }
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

        public async Task<TEntity> ActionViewTasksFromProjectMilestoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            // values = super()._alias_get_creation_values()
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

        public async Task<TEntity> CheckFeaturesEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object updated_features) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CheckProjectGroupAtRemovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CheckProjectGroupWithFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object group_name) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CheckReviewLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _check_review_link(self):
            // for record in self.filtered("review_link"):
            //     url = urlparse(record.review_link)
            //     if url.scheme not in ("http", "https") or not url.netloc:
            //         raise ValidationError(
            //             self.env._("Invalid URL '%s'. The Review Link must start with 'http://' or 'https://'.") % record.review_link
            //         )
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

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableOperatorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_available_operator_ids(self):
            // operators_by_livechat_channel = self._get_available_operators_by_livechat_channel()
            // for livechat_channel in self:
            //     livechat_channel.available_operator_ids = operators_by_livechat_channel[livechat_channel]
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
            // favorite_project_ids = self.env.user.favorite_project_ids
            // for project in self:
            //     project.is_favorite = project in favorite_project_ids
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

        public async Task<TEntity> ComputeOngoingSessionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_ongoing_sessions_count(self):
            // count_by_channel = defaultdict(int)
            // for key, count in self._get_ongoing_session_count_by_agent_livechat_channel().items():
            //     count_by_channel[key[1]] += count
            // for channel in self:
            //     channel.ongoing_session_count = count_by_channel.get(channel, 0)
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
            //     elif project.privacy_visibility in ['invited_users', 'portal'] and project._origin.privacy_visibility not in ['invited_users', 'portal']:
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility not in ['invited_users', 'portal'] and project._origin.privacy_visibility in ['invited_users', 'portal']:
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
            //     domain += [('write_date', '>=', fields.Datetime.to_string(fields.Datetime.now() - timedelta(days=self._rating_satisfaction_days)))]
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

        public async Task<TEntity> ComputeRemainingSessionCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_remaining_session_capacity(self):
            // count = self._get_ongoing_session_count_by_agent_livechat_channel()
            // for channel in self:
            //     users = channel.user_ids
            //     if channel.block_assignment_during_call:
            //         users = users.filtered(lambda u: not u.livechat_is_in_call)
            //     total_capacity = channel.max_sessions * len(users)
            //     capacity = total_capacity - sum(
            //         count.get((user.partner_id, channel), 0) for user in users
            //     )
            //     channel.remaining_session_capacity = max(capacity, 0)
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
            //     "dbname": self.env.cr.dbname,
            // }
            // for record in self:
            //     values["channel_id"] = record.id
            //     values["url"] = record.get_base_url()
            //     record.script_external = self.env['ir.qweb']._render('im_livechat.external_loader', values) if record.id else False
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRatingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> CopyEmbeddedActionsConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects, object shared_embedded_actions_mapping) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> CopySharedEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> CreateTemplateFromProjectUndoCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> DefaultButtonTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_button_text(self):
            // return _('Need help? Chat with us.')
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
            // return [(6, 0, [self.env.uid])]
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

        protected async Task<object> GetAgentMemberValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_agent_member_vals(self, /, *, last_interest_dt, now, chatbot_script, operator_partner, operator_model, **kwargs):
            // return {
            //     "chatbot_script_id": chatbot_script.id if operator_model == 'chatbot.script' else False,
            //     "last_interest_dt": last_interest_dt,
            //     "livechat_member_type": "agent" if operator_model == 'res.users' else "bot",
            //     "partner_id": operator_partner.id,
            //     "unpin_dt": now,
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

        public async Task<TEntity> GetAvailableOperatorsByLivechatChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_available_operators_by_livechat_channel(self, users=None):
            // """Return a dictionary mapping each livechat channel in ``self`` to the users that are
            // available for that livechat channel, according to the user status and the optional
            // limit of concurrent sessions of the livechat channel.
            // 
            // When ``users`` are provided, each user is attempted to be mapped for each livechat
            // channel. Otherwise, only the users of each respective livechat channel are considered.
            // 
            // :param users: Optional list of users to consider. Every agent in ``self`` will be
            //  considered if omitted.
            // 
            // """
            // counts = {}
            // if livechat_channels := self.filtered(lambda c: c.max_sessions_mode == "limited"):
            //     counts = livechat_channels._get_ongoing_session_count_by_agent_livechat_channel(
            //         users, filter_online=True
            //     )
            // 
            // def is_available(user, channel):
            //     return (
            //         #  sudo - res.users: can access agent presence to determine if they are available.
            //         user.sudo().presence_ids.status == "online"
            //         and (
            //             channel.max_sessions_mode == "unlimited"
            //             or counts.get((user.partner_id, channel), 0) < channel.max_sessions
            //         )
            //         # sudo: res.users - it's acceptable to check if the user is in call
            //         and (not channel.block_assignment_during_call or not user.sudo().is_in_call)
            //     )
            // 
            // operators_by_livechat_channel = {}
            // for livechat_channel in self:
            //     possible_users = users if users is not None else livechat_channel.user_ids
            //     operators_by_livechat_channel[livechat_channel] = possible_users.filtered(
            //         lambda user, livechat_channel=livechat_channel: is_available(user, livechat_channel)
            //     )
            // return operators_by_livechat_channel
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
            //     'default_message': self.default_message,
            //     "channel_name": self.name,
            //     "channel_id": self.id,
            //     "review_link": self.review_link,
            // }
            */
            return default;
        }

        protected async Task<object> GetChannelNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_channel_name(self, /, *, visitor_user=None, guest=None, agent, chatbot_script, operator_model, **kwargs):
            // if operator_model == 'chatbot.script':
            //     channel_name = chatbot_script.title
            // else:
            //     channel_name = ' '.join([
            //         visitor_user.display_name if visitor_user else guest.name,
            //         agent.livechat_username or agent.name
            //     ])
            // return channel_name
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
            //     s for s in operator_statuses if s['partner_id'] in set(operators.partner_id.ids)
            // ]
            // 
            // # 2) try to select an inactive op, i.e. one w/ no active status (no recent chat)
            // active_op_partner_ids = {s['partner_id'] for s in operator_statuses}
            // candidates = operators.filtered(lambda o: o.partner_id.id not in active_op_partner_ids)
            // if candidates:
            //     return random.choice(candidates)
            // 
            // # 3) otherwise select least active ops, based on status ordering (count + in_call)
            // best_status = operator_statuses[0]
            // best_status_op_partner_ids = {
            //     s['partner_id']
            //     for s in operator_statuses
            //     if (s['count'], s['in_call']) == (best_status['count'], best_status['in_call'])
            // }
            // candidates = operators.filtered(lambda o: o.partner_id.id in best_status_op_partner_ids)
            // return random.choice(candidates)
            */
            return default;
        }

        protected async Task<object> GetLivechatDiscussChannelValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(self, /, *, chatbot_script=None, agent=None, operator_partner, operator_model, **kwargs):
            // # use the same "now" in the whole function to ensure unpin_dt > last_interest_dt
            // now = fields.Datetime.now()
            // last_interest_dt = now - timedelta(seconds=1)
            // members_to_add = [Command.create(self._get_agent_member_vals(
            //     last_interest_dt=last_interest_dt, now=now,
            //     chatbot_script=chatbot_script,
            //     operator_partner=operator_partner,
            //     operator_model=operator_model,
            //     **kwargs
            // ))]
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest and self.env.user._is_public():
            //     members_to_add.append(
            //         Command.create({"livechat_member_type": "visitor", "guest_id": guest.id})
            //     )
            // visitor_user = self.env["res.users"]
            // if not self.env.user._is_public():
            //     visitor_user = self.env.user
            //     if visitor_user and visitor_user != agent:
            //         members_to_add.append(
            //             Command.create(
            //                 {
            //                     "livechat_member_type": "visitor",
            //                     "partner_id": visitor_user.partner_id.id,
            //                 }
            //             )
            //         )
            // 
            // channel_name = self._get_channel_name(
            //     visitor_user=visitor_user,
            //     guest=guest,
            //     agent=agent,
            //     chatbot_script=chatbot_script,
            //     operator_model=operator_model,
            //     **kwargs
            // )
            // is_chatbot_script = operator_model == 'chatbot.script'
            // is_agent = operator_model == 'res.users'
            // return {
            //     'channel_member_ids': members_to_add,
            //     "last_interest_dt": last_interest_dt,
            //     'livechat_operator_id': operator_partner.id,
            //     'livechat_channel_id': self.id,
            //     "livechat_failure": "no_answer" if is_agent else "no_failure",
            //     "livechat_status": "in_progress",
            //     'chatbot_current_step_id': chatbot_script._get_welcome_steps()[-1].id if is_chatbot_script else False,
            //     'channel_type': 'livechat',
            //     'name': channel_name,
            // }
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
            // info['available'] = self._is_livechat_available()
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

        public async Task<TEntity> GetOngoingSessionCountByAgentLivechatChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users, object filter_online) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_ongoing_session_count_by_agent_livechat_channel(self, users=None, filter_online=False):
            // """Return a dictionary mapping each ``(user, livechat_channel)`` pair to the number of
            // ongoing livechat sessions.
            // 
            // :param users: List of users to consider for the session count.
            // :param filter_online: If ``True``, only online agents will be considered.
            // :type filter_online: bool
            // :returns: A dictionary mapping ``(partner_id, livechat_channel_id)`` to the session count.
            // :rtype: dict
            // 
            // """
            // user_domain = Domain(False)
            // for channel in self:
            //     active_users = users if users is not None else channel.user_ids
            //     if filter_online:
            //         # sudo - res.users: can access agent presence to determine if they are available.
            //         active_users = active_users.filtered(lambda u: u.sudo().presence_ids.status == "online")
            //     user_domain |= Domain(
            //         [
            //             ("partner_id", "in", active_users.partner_id.ids),
            //             ("channel_id.livechat_channel_id", "in", channel.ids),
            //         ]
            //     )
            // counts = self.env["discuss.channel.member"]._read_group(
            //     Domain("channel_id.livechat_end_dt", "=", False)
            //     & Domain("channel_id.last_interest_dt", ">=", "-15M")
            //     & user_domain,
            //     groupby=["partner_id", "channel_id.livechat_channel_id"],
            //     aggregates=["__count"],
            // )
            // return {(partner, channel): count for (partner, channel, count) in counts}
            */
            return default;
        }

        protected async Task<object> GetOperatorInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator_info(self, /, *, lang, country_id, previous_operator_id=None, chatbot_script_id=None, **kwargs):
            // agent = self.env['res.users']
            // chatbot_script = self.env['chatbot.script']
            // operator_partner = self.env['res.partner']
            // # The operator_model establishes the priority among potential operators (e.g., chatbot_script or ai_agent) for a live chat channel.
            // # It dictates which operator model is selected when multiple are configured.
            // operator_model = ''
            // 
            // if chatbot_script_id and chatbot_script_id in self.rule_ids.chatbot_script_id.ids:
            //     chatbot_script = (
            //         self.env["chatbot.script"]
            //         .sudo()
            //         .with_context(lang=self.env["chatbot.script"]._get_chatbot_language())
            //         .search([("id", "=", chatbot_script_id)])
            //     )
            //     operator_partner = chatbot_script.operator_partner_id
            //     operator_model = 'chatbot.script'
            // 
            // if not operator_model:
            //     agent = self._get_operator(
            //         previous_operator_id=previous_operator_id,
            //         lang=lang,
            //         country_id=country_id,
            //     )
            //     operator_partner = agent.partner_id
            //     operator_model = 'res.users'
            // 
            // return {'agent': agent, 'chatbot_script': chatbot_script, 'operator_partner': operator_partner, 'operator_model': operator_model}
            */
            return default;
        }

        public async Task<TEntity> GetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid previous_operator_id, object lang, Guid country_id, object expertises, object users) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator(
            //     self, previous_operator_id=None, lang=None, country_id=None, expertises=None, users=None
            // ):
            //     """ Return an operator for a livechat. Try to return the previous
            //     operator if available. If not, one of the most available operators be
            //     returned.
            // 
            //     A livechat is considered 'active' if it has at least one message within
            //     the 30 minutes. This method will try to match the given lang, expertises
            //     and country_id.
            // 
            //     (Some annoying conversions have to be made on the fly because this model
            //     holds 'res.users' as available operators and the discuss_channel model
            //     stores the partner_id of the randomly selected operator)
            // 
            //     :param previous_operator_id: partner id of the previous operator with
            //         whom the visitor was chatting.
            //     :param lang: code of the preferred lang of the visitor.
            //     :param country_id: id of the country of the visitor.
            //     :param expertises: preferred expertises for filtering operators.
            //     :param users: recordset of available users to use as candidates instead
            //         of the users of the livechat channel.
            //     :return : user
            //     :rtype : res.users
            //     """
            //     self.ensure_one()
            //     # FIXME: remove inactive call sessions so operators no longer in call are available
            //     # sudo: required to use garbage collecting function.
            //     self.env["discuss.channel.rtc.session"].sudo()._gc_inactive_sessions()
            //     users = users if users is not None else self.available_operator_ids
            //     if not users:
            //         return self.env["res.users"]
            //     if expertises is None:
            //         expertises = self.env["im_livechat.expertise"]
            //     self.env.cr.execute(
            //         """
            //             WITH operator_rtc_session AS (
            //                 SELECT COUNT(DISTINCT s.id) as nbr, member.partner_id as partner_id
            //                   FROM discuss_channel_rtc_session s
            //                   JOIN discuss_channel_member member ON (member.id = s.channel_member_id)
            //               GROUP BY member.partner_id
            //             )
            //            SELECT COUNT(DISTINCT h.channel_id), COALESCE(rtc.nbr, 0) > 0 as in_call, h.partner_id
            //              FROM im_livechat_channel_member_history h
            //              JOIN discuss_channel c ON h.channel_id = c.id
            //   LEFT OUTER JOIN operator_rtc_session rtc ON rtc.partner_id = h.partner_id
            //             WHERE c.livechat_end_dt IS NULL
            //               AND c.last_interest_dt > ((now() at time zone 'UTC') - interval '30 minutes')
            //               AND h.partner_id in %s
            //          GROUP BY h.partner_id, rtc.nbr
            //          ORDER BY COUNT(DISTINCT h.channel_id) < 2 OR rtc.nbr IS NULL DESC,
            //                   COUNT(DISTINCT h.channel_id) ASC,
            //                   rtc.nbr IS NULL DESC
            //         """,
            //         (tuple(users.partner_id.ids),),
            //     )
            //     operator_statuses = self.env.cr.dictfetchall()
            //     # Try to match the previous operator
            //     if previous_operator_id in users.partner_id.ids:
            //         previous_operator_status = next(
            //             (
            //                 status
            //                 for status in operator_statuses
            //                 if status['partner_id'] == previous_operator_id
            //             ),
            //             None,
            //         )
            //         if not previous_operator_status or previous_operator_status['count'] < 2 or not previous_operator_status['in_call']:
            //             previous_operator_user = next(
            //                 available_user
            //                 for available_user in users
            //                 if available_user.partner_id.id == previous_operator_id
            //             )
            //             return previous_operator_user
            // 
            //     agents_failing_buffer = {
            //             group[0]
            //             for group in self.env["im_livechat.channel.member.history"]._read_group(
            //                 [
            //                     ("livechat_member_type", "=", "agent"),
            //                     ("partner_id", "in", users.partner_id.ids),
            //                     ("channel_id.livechat_end_dt", "=", False),
            //                     (
            //                         "create_date",
            //                         ">",
            //                         fields.Datetime.now() - timedelta(seconds=BUFFER_TIME),
            //                     ),
            //                 ],
            //                 groupby=["partner_id"],
            //             )
            //         }
            // 
            //     def same_language(operator):
            //         return operator.partner_id.lang == lang or lang in operator.livechat_lang_ids.mapped("code")
            // 
            //     def all_expertises(operator):
            //         return operator.livechat_expertise_ids >= expertises
            // 
            //     def one_expertise(operator):
            //         return operator.livechat_expertise_ids & expertises
            // 
            //     def same_country(operator):
            //         return operator.partner_id.country_id.id == country_id
            // 
            //     # List from most important to least important. Order on each line is irrelevant, all
            //     # elements of a line must be satisfied together or the next line is checked.
            //     preferences_list = [
            //         [same_language, all_expertises],
            //         [same_language, one_expertise],
            //         [same_language],
            //         [same_country, all_expertises],
            //         [same_country, one_expertise],
            //         [same_country],
            //         [all_expertises],
            //         [one_expertise],
            //     ]
            //     for preferences in preferences_list:
            //         operators = users
            //         for preference in preferences:
            //             operators = operators.filtered(preference)
            //         if operators:
            //             if agents_respecting_buffer := operators.filtered(
            //                 lambda op: op.partner_id not in agents_failing_buffer
            //             ):
            //                 operators = agents_respecting_buffer
            //             return self._get_less_active_operator(operator_statuses, operators)
            //     return self._get_less_active_operator(operator_statuses, users)
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
            // return Domain.AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
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

        public async Task<TEntity> GetProfitabilityValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetProjectFeaturesMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFromProjectUndoCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetTemplateTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> GetTemplateToProjectConfirmationCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_confirmation_callbacks(self):
            // self.ensure_one()
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_warnings(self):
            // self.ensure_one()
            // return []
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

        public async Task<TEntity> InverseAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_milestones(self):
            // self._check_project_group_with_field('allow_milestones', 'project.group_project_milestone')
            */
            return default;
        }

        public async Task<TEntity> InverseAllowRecurringTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_recurring_tasks(self):
            // self._check_project_group_with_field('allow_recurring_tasks', 'project.group_project_recurring_tasks')
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
            // res = self._check_project_group_with_field('allow_task_dependencies', 'project.group_project_task_dependencies')
            // # Hide/Show task waiting subtype when task dependencies feature is disabled/enabled
            // if res or res is False:
            //     self.env.ref('project.mt_task_waiting').hidden = not res
            //     self.env.ref('project.mt_project_task_waiting').hidden = not res
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

        public async Task<TEntity> IsLivechatAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _is_livechat_available(self):
            // return self.chatbot_script_count or len(self.available_operator_ids) > 0
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            // if operator != 'in':
            //     return NotImplemented
            // return [('favorite_user_ids', 'in', [self.env.uid])]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_parent_mixin.py) ---
            // def _search_rating_avg(self, operator, value):
            // op = rating_data.OPERATOR_MAPPING.get(operator)
            // if not op:
            //     return NotImplemented
            // domain = Domain([('parent_res_model', '=', self._name), ('consumed', '=', True), ('rating', '>=', rating_data.RATING_LIMIT_MIN)])
            // if self._rating_satisfaction_days:
            //     min_date = fields.Datetime.now() - timedelta(days=self._rating_satisfaction_days)
            //     domain &= Domain('write_date', '>=', fields.Datetime.to_string(min_date))
            // rating_read_group = self.env['rating.rating'].sudo()._read_group(domain, ['parent_res_id'], ['rating:avg'])
            // parent_res_ids = [
            //     parent_res_id
            //     for parent_res_id, rating_avg in rating_read_group
            //     if op(float_compare(rating_avg, value, 2), 0)
            // ]
            // return [('id', 'in', parent_res_ids)]
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

        public async Task<TEntity> TemplateToProjectConfirmationCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def template_to_project_confirmation_callback(self, callbacks):
            // self.ensure_one()
            // pass
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IRatingParentMixinable
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

        public async Task<TEntity> ToggleTemplateModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_template) where TEntity : IEntity<Guid>, IRatingParentMixinable
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
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync<TEntity>(IEnumerable<TEntity> entities, object specification) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def web_read(self, specification: dict[str, dict]) -> list[dict]:
            // user_context = specification.get("user_ids", {}).get("context", {})
            // if len(self) == 1 and user_context.pop("add_livechat_channel_ctx", None):
            //     user_context["im_livechat_channel_id"] = self.id
            // return super().web_read(specification)
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