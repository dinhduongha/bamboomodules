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
    public partial class RatingMixinAppService : ApplicationService, IRatingMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public RatingMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_add_members(self, target_partners, member_status='joined', raise_on_access=False):
            // """ Adds the target_partners as attendees of the channel(s).
            //     Partners are added as follows, depending on the value of member_status:
            //     1) (Default) 'joined'. The partners will be added as enrolled attendees. This will make the content
            //         (slides) of the channel available to that partner. This can also happen when an invited attendee
            //         enrolls themself. The attendees are also subscribed to the chatter of the channel.
            //         :return: the union of previous partners re-enrolling, new attendees and invited ones enrolling.
            //     2) 'invited' : This is used when inviting partners. The partners are added as invited attendees
            //         This will make the channel accessible but not the slides until they enroll themselves.
            //         :return: returns the union of new records and the ones unarchived.
            // """
            // SlideChannelPartnerSudo = self.env['slide.channel.partner'].sudo()
            // allowed_channels = self._filter_add_members(raise_on_access=raise_on_access)
            // if not allowed_channels or not target_partners:
            //     return SlideChannelPartnerSudo
            // 
            // existing_channel_partners = self.env['slide.channel.partner'].with_context(active_test=False).sudo().search([
            //     ('channel_id', 'in', allowed_channels.ids),
            //     ('partner_id', 'in', target_partners.ids)
            // ])
            // 
            // # Unarchive existing channel partners, recomputing their completion and updating member_status
            // archived_channel_partners = existing_channel_partners.filtered(lambda channel_partner: not channel_partner.active)
            // to_unarchived = SlideChannelPartnerSudo
            // if archived_channel_partners:
            //     archived_channel_partners.action_unarchive()
            //     to_unarchived = archived_channel_partners
            //     # Update member_status (and completion if enrolling)
            //     to_unarchived.member_status = member_status
            //     if member_status == 'joined':
            //         to_unarchived._recompute_completion()
            // 
            // existing_channel_partners_map = defaultdict(lambda: self.env['slide.channel.partner'])
            // for channel_partner in existing_channel_partners:
            //     existing_channel_partners_map[channel_partner.channel_id] += channel_partner
            // 
            // # Invited partners confirming their invitation by enrolling, or upgraded to 'joined'.
            // to_update_as_joined = SlideChannelPartnerSudo
            // to_create_channel_partners_values = []
            // 
            // for channel in allowed_channels:
            //     channel_partners = existing_channel_partners_map[channel]
            //     if member_status == 'joined':
            //         to_update_as_joined += channel_partners.filtered(lambda cp: cp.member_status == 'invited')
            //     for partner in target_partners - channel_partners.partner_id:
            //         to_create_channel_partners_values.append(dict(channel_id=channel.id, partner_id=partner.id, member_status=member_status))
            // 
            // new_slide_channel_partners = SlideChannelPartnerSudo.create(to_create_channel_partners_values)
            // to_update_as_joined.member_status = 'joined'
            // to_update_as_joined._recompute_completion()
            // 
            // # All fragments are in sudo.
            // result_channel_partners = to_unarchived + to_update_as_joined + new_slide_channel_partners
            // 
            // # Subscribe partners joining the course to the chatter.
            // if member_status == 'joined':
            //     result_channel_partners_map = defaultdict(list)
            //     for channel_partner in result_channel_partners:
            //         result_channel_partners_map[channel_partner.channel_id].append(channel_partner.partner_id.id)
            //     for channel, partner_ids in result_channel_partners_map.items():
            //         channel.message_subscribe(
            //             partner_ids=partner_ids,
            //             subtype_ids=[self.env.ref('website_slides.mt_channel_slide_published').id]
            //         )
            // return result_channel_partners
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_archive(self):
            // child_tasks = self.child_ids.filtered(lambda child_task: not child_task.display_in_project)
            // if child_tasks:
            //     child_tasks.action_archive()
            // return super().action_archive()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_archive(self):
            // """ Archiving a channel does it on its slides, too.
            // 
            // We want to be archiving the channel FIRST.
            // So that when slides are archived and the recompute is triggered,
            // it does not try to mark the channel as "completed".
            // That happens because it counts slide_done / slide_total, but slide_total
            // will be 0 since all the slides for the course have been archived as well.
            // """
            // archived = self.filtered(self._active_name)
            // res = super().action_archive()
            // archived.is_published = False
            // archived.slide_ids.action_archive()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def action_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').action_bom_cost()
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_enroll(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_enroll', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template, enroll_mode=True)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_invite(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_invite', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_channel_open_invite_wizard(self, mail_template, enroll_mode=False):
            // """ Open the invitation wizard to invite and add attendees to the course(s) in self.
            // 
            // :param mail_template: mail.template used in the invite wizard.
            // :param enroll_mode: true if we want to enroll the attendees invited through the wizard.
            //     False otherwise, adding them as 'invited', e.g. when using "Invite" action."""
            // course_name = self.name if len(self) == 1 else ''
            // local_context = dict(
            //     self.env.context,
            //     default_channel_id=self.id if len(self) == 1 else False,
            //     default_email_layout_xmlid='website_slides.mail_notification_channel_invite',
            //     default_enroll_mode=enroll_mode,
            //     default_template_id=mail_template and mail_template.id or False,
            //     default_use_template=bool(mail_template),
            // )
            // if enroll_mode:
            //     name = _('Enroll Attendees to %(course_name)s', course_name=course_name or _('a course'))
            // else:
            //     name = _('Invite Attendees to %(course_name)s', course_name=course_name or _('a course'))
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, 'form']],
            //     'res_model': 'slide.channel.invite',
            //     'target': 'new',
            //     'context': local_context,
            //     'name': name,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def action_create_product_variants_from_gelato_template(self):
            // """ Override of `sale_gelato` to unpublish products for which the synchronization with
            // Gelato led to new print images being created. """
            // image_count_before_sync = len(self.gelato_image_ids)
            // res = super().action_create_product_variants_from_gelato_template()
            // if image_count_before_sync < len(self.gelato_image_ids):
            //     self.is_published = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_grant_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     if self._action_add_members(partner):
            //         self.activity_search(
            //             ['mail.mail_activity_data_todo'],
            //             user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)],
            //             only_automated=False,
            //         ).action_feedback(feedback=_('Access Granted'))
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_documents(self):
            // self.ensure_one()
            // return {
            //     'name': _('Documents'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'product.document',
            //     'view_mode': 'kanban,list,form',
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.id,
            //         'default_company_id': self.company_id.id,
            //     },
            //     'domain': self._get_product_document_domain(),
            //     'target': 'current',
            //     'help': """
            //         <p class="o_view_nocontent_smiling_face">
            //             %s
            //         </p>
            //         <p>
            //             %s
            //             <br/>
            //             %s
            //         </p>
            //         <p>
            //             <a class="oe_link" href="https://www.odoo.com/documentation/latest/_downloads/c2c6ce32294dfddffcfefcf2775f7a09/pdfquotebuilderexamples.zip">
            //             %s
            //             </a>
            //         </p>
            //     """ % (
            //         _("Upload files to your product"),
            //         _("Use this feature to store any files you would like to share with your customers"),
            //         _("(e.g: product description, ebook, legal notice, ...)."),
            //         _("Download examples")
            //     )
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_label_layout(self):
            // if any(product_tmpl.type == 'service' for product_tmpl in self):
            //     raise ValidationError(_('Labels cannot be printed for products of service type'))
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_tmpl_ids': self.ids}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_product_lot(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_product_production_lot_form")
            // action['domain'] = [
            //     ('product_id.product_tmpl_id', '=', self.id),
            //     '|', ('location_id', '=', False),
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self.env.context['allowed_company_ids']))
            // ]
            // action['context'] = {
            //     'default_product_tmpl_id': self.id,
            //     'search_default_group_by_location': True,
            // }
            // if self.product_variant_count == 1:
            //     action['context'].update({
            //         'default_product_id': self.product_variant_id.id,
            //     })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_quants(self):
            // if 'product_variant' in self.env.context:
            //     return self.env['product.product'].browse(self.env.context['default_product_id']).action_open_quants()
            // return self.product_variant_ids.filtered(lambda p: p.active or p.qty_available != 0).action_open_quants()
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_routes_diagram(self):
            // products = False
            // if self.env.context.get('default_product_id'):
            //     products = self.env['product.product'].browse(self.env.context['default_product_id'])
            // if not products and self.env.context.get('default_product_tmpl_id'):
            //     products = self.env['product.template'].browse(self.env.context['default_product_tmpl_id']).product_variant_ids
            // if not self.env.user.has_group('stock.group_stock_multi_warehouses') and len(products) == 1:
            //     company = products.company_id or self.env.company
            //     warehouse = self.env['stock.warehouse'].search([('company_id', '=', company.id)], limit=1)
            //     return self.env.ref('stock.action_report_stock_rule').report_action(None, data={
            //         'product_id': products.id,
            //         'warehouse_ids': warehouse.ids,
            //     }, config=False)
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_stock_rules_report")
            // action['context'] = self.env.context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_product_tmpl_forecast_report(self):
            // self.ensure_one()
            // if not self.env.user._get_default_warehouse_id():
            //     self.env['stock.warehouse']._warehouse_redirect_warning()
            // action = self.env["ir.actions.actions"]._for_xml_id('stock.stock_forecasted_product_template_action')
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_completed_members(self):
            // return self.action_redirect_to_members('completed')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_engaged_members(self):
            // return self.action_redirect_to_members('engaged')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_invited_members(self):
            // return self.action_redirect_to_members('invited')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_members(self, status_filter=''):
            // """ Redirects to attendees of the course. If status_filter is set to 'invited' /
            // 'engaged' ('joined' + 'ongoing') / 'completed', attendees are filtered accordingly."""
            // action_ctx = {}
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_channel_partner_action")
            // if status_filter == 'engaged':
            //     action_ctx['search_default_filter_joined'] = 1
            //     action_ctx['search_default_filter_ongoing'] = 1
            // elif status_filter:
            //     action_ctx[f'search_default_filter_{status_filter}'] = 1
            // action['domain'] = [('channel_id', 'in', self.ids)]
            // action['sample'] = 1
            // if status_filter == 'completed':
            //     help_message = {
            //         'header_message': _("No Attendee has completed this course yet!"),
            //         'body_message': ""
            //     }
            // else:
            //     help_message = {
            //         'header_message': _("No Attendees Yet!"),
            //         'body_message': _("From here you'll be able to monitor attendees and to track their progress.")
            //     }
            // action['help'] = Markup("""<p class="o_view_nocontent_smiling_face">%(header_message)s</p><p>%(body_message)s</p>""") % help_message
            // if len(self) == 1:
            //     action['display_name'] = _('Attendees of %s', self.name)
            //     action_ctx['default_channel_id'] = self.id
            // action['context'] = action_ctx
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_refuse_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     self.activity_search(
            //         ['mail.mail_activity_data_todo'],
            //         user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)],
            //         only_automated=False,
            //     ).action_feedback(feedback=_('Access Refused'))
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_request_access(self):
            // """ Request access to the channel. Returns a dict with keys being either 'error'
            // (specific error raised) or 'done' (request done or not). """
            // if self.env.user._is_public():
            //     return {'error': _('You have to sign in before')}
            // if not self.is_published:
            //     return {'error': _('Course not published yet')}
            // if self.is_member:
            //     return {'error': _('Already member')}
            // if self.enroll == 'invite':
            //     activities = self.sudo()._action_request_access(self.env.user.partner_id)
            //     if activities:
            //         return {'done': True}
            //     return {'error': _('Already Requested')}
            // return {'done': False}
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_request_access(self, partner):
            // activities = self.env['mail.activity']
            // requested_cids = self.sudo().activity_search(
            //     ['mail.mail_activity_data_todo'],
            //     additional_domain=[('request_partner_id', '=', partner.id)],
            // ).mapped('res_id')
            // for channel in self:
            //     if channel.id not in requested_cids and channel.user_id:
            //         activities += channel.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('<b>%s</b> is requesting access to this course.', partner.name),
            //             summary=_('Access Request'),
            //             user_id=channel.user_id.id,
            //             request_partner_id=partner.id
            //         )
            // return activities
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def action_sync_gelato_template_info(self):
            // """ Fetch the template information from Gelato and update the product template accordingly.
            // 
            // :return: The action to display a toast notification to the user.
            // :rtype: dict
            // """
            // # Fetch the template info from Gelato.
            // try:
            //     endpoint = f'templates/{self.gelato_template_ref}'
            //     template_info = utils.make_request(
            //         self.env.company.sudo().gelato_api_key, 'ecommerce', 'v1', endpoint, method='GET'
            //     )  # In sudo mode to read the API key from the company.
            // except UserError as e:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'title': _("Could not synchronize with Gelato"),
            //             'message': str(e),
            //             'sticky': True,
            //         }
            //     }
            // 
            // # Apply the necessary changes on the product template.
            // self._create_attributes_from_gelato_info(template_info)
            // self._create_print_images_from_gelato_info(template_info)
            // 
            // # Display a toaster notification to the user if all went well.
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'title': _("Successfully synchronized with Gelato"),
            //         'message': _("Missing product variants and images have been successfully created."),
            //         'sticky': False,
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload'
            //         }
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_unarchive(self):
            // """ Unarchiving a channel does it on its slides, too.
            // 
            // We want to archive the channel LAST.
            // So that when it recomputes stats for the channel and completion, it correctly
            // counts the slides_total by counting slides that are already un-archived.
            // """
            // to_activate = self.filtered(lambda channel: not channel.active)
            // to_activate.with_context(active_test=False).slide_ids.action_unarchive()
            // return super(SlideChannel, to_activate).action_unarchive()
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> ActionUnfollowAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def action_unfollow(self):
            // self._action_unfollow(self.env.user.partner_id)
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object guest, object post_leave_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _action_unfollow(self, partner=None, guest=None, post_leave_message=True):
            // super()._action_unfollow(partner, guest, post_leave_message)
            // # sudo - discuss.channel: user just left but we need to close the live
            // # chat if the last operator left.
            // channel_sudo = self.sudo()
            // if (
            //     channel_sudo.channel_type == "livechat"
            //     and not channel_sudo.livechat_end_dt
            //     and channel_sudo.member_count == 1
            // ):
            //     # sudo: discuss.channel - last operator left the conversation, state must be updated.
            //     channel_sudo.livechat_end_dt = fields.Datetime.now()
            //     Store(bus_channel=self).add(channel_sudo, "livechat_end_dt").bus_send()
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_unlink_recurrence(self):
            // self.recurrence_id.task_ids.recurring_task = False
            // self.recurrence_id.unlink()
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_used_in_bom(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_bom_form_action")
            // action['domain'] = [('bom_line_ids.product_tmpl_id', '=', self.id)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_view_mos(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_production_action")
            // action['domain'] = [('state', '=', 'done'), ('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'search_default_filter_plan_date': 1,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_orderpoints(self):
            // return self.product_variant_ids.action_view_orderpoints()
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def action_view_po(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = ['&',
            //     ('state', '=', 'purchase'),
            //     ('product_id', 'in', self.with_context(active_test=False).product_variant_ids.ids)
            // ]
            // action['display_name'] = _("Purchase History for %s", self.display_name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_view_ratings(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.rating_rating_action_slide_channel")
            // action['name'] = _('Rating of %s', self.name)
            // action['domain'] = Domain.AND([ast.literal_eval(action.get('domain', '[]')), Domain('res_id', 'in', self.ids)])
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_related_putaway_rules(self):
            // self.ensure_one()
            // domain = [
            //     '|',
            //         ('product_id.product_tmpl_id', '=', self.id),
            //         ('category_id', '=', self.categ_id.id),
            // ]
            // return self._get_action_view_related_putaway_rules(domain)
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def action_view_sales(self):
            // action = self.env['ir.actions.actions']._for_xml_id('sale.report_all_channels_sales_action')
            // action['domain'] = [('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'pivot_measures': ['product_uom_qty'],
            //     'active_id': self.env.context.get('active_id'),
            //     'active_model': 'sale.report',
            //     'search_default_Sales': 1,
            //     'search_default_filter_order_date': 1,
            //     'search_default_group_by_date': 1,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_view_slides(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_slide_action")
            // action['context'] = {
            //     'search_default_published': 1,
            //     'default_channel_id': self.id
            // }
            // action['domain'] = [('channel_id', "=", self.id), ('is_category', '=', False)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_stock_move_lines(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_move_line_action")
            // action['domain'] = [('product_id.product_tmpl_id', 'in', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_storage_category_capacity(self):
            // self.ensure_one()
            // return self.product_variant_ids.action_view_storage_category_capacity()
            */
            return default;
        }

        public async Task<TEntity> AddArchivedCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _add_archived_combinations(self, products):
            // """ Add archived combinations to the product template data. """
            // product_data = {product['id']: product for product in products}
            // for product_tmpl in self.browse(product_data.keys()):
            //     product = product_data[product_tmpl.id]
            //     attribute_exclusions = product_tmpl._get_attribute_exclusions()
            //     product['_archived_combinations'] = attribute_exclusions['archived_combinations']
            //     excluded = {}
            //     for ptav_id, ptav_ids in attribute_exclusions['exclusions'].items():
            //         for ptav_id2 in set(ptav_ids) - excluded.keys():
            //             excluded[ptav_id] = ptav_id2
            //     product['_archived_combinations'].extend(excluded.items())
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _add_groups_members(self):
            // for channel in self:
            //     channel._action_add_members(channel.mapped('enroll_group_ids.all_user_ids.partner_id'))
            */
            return default;
        }

        public async Task<TEntity> AddMembersAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> guest_ids, object invite_to_rtc_call, object post_joined_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def add_members(
            //     self, partner_ids=None, guest_ids=None, invite_to_rtc_call=False, post_joined_message=True
            // ):
            //     """ Adds the given partner_ids and guest_ids as member of self channels. """
            //     return self._add_members(
            //         partners=self.env["res.partner"].browse(partner_ids or []).exists(),
            //         guests=self.env["mail.guest"].browse(guest_ids or []).exists(),
            //         invite_to_rtc_call=invite_to_rtc_call,
            //         post_joined_message=post_joined_message,
            //     )
            */
            return default;
        }

        public async Task<TEntity> AddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_members(
            //     self,
            //     *,
            //     guests=None,
            //     partners=None,
            //     users=None,
            //     create_member_params=None,
            //     invite_to_rtc_call=False,
            //     post_joined_message=True,
            //     inviting_partner=None,
            // ):
            //     all_new_members = super()._add_members(
            //         guests=guests,
            //         partners=partners,
            //         users=users,
            //         create_member_params=create_member_params,
            //         invite_to_rtc_call=invite_to_rtc_call,
            //         post_joined_message=post_joined_message,
            //         inviting_partner=inviting_partner,
            //     )
            //     for channel in all_new_members.channel_id:
            //         # sudo: discuss.channel - accessing livechat_status in internal code is acceptable
            //         if channel.sudo().livechat_status == "need_help":
            //             # sudo: discuss.channel - writing livechat_status when a new operator joins is acceptable
            //             channel.sudo().livechat_status = "in_progress"
            //     return all_new_members
            */
            return default;
        }

        public async Task<TEntity> AddNewMembersToChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object create_member_params, object inviting_partner, object users, object partners) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_new_members_to_channel(self, create_member_params, inviting_partner, users=None, partners=None):
            // member_params = {
            //     'create_member_params': create_member_params,
            //     'inviting_partner': inviting_partner
            // }
            // if users:
            //     member_params['users'] = users
            // if partners:
            //     member_params['partners'] = partners
            // self._add_members(**member_params)
            */
            return default;
        }

        public async Task<TEntity> AddNextStepMessageToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_next_step_message_to_store(self, chatbot_script_step):
            // if chatbot_script_step:
            //     step_message = next((
            //         # sudo - chatbot.message.id: visitor can access chat bot messages.
            //         m.mail_message_id for m in self.sudo().chatbot_message_ids.sorted("id")
            //         if m.script_step_id == chatbot_script_step
            //         and m.mail_message_id.author_id == chatbot_script_step.chatbot_script_id.operator_partner_id
            //     ), self.env["mail.message"])
            //     Store(bus_channel=self).add_model_values(
            //         "ChatbotStep",
            //         {
            //             "id": (chatbot_script_step.id, step_message.id),
            //             "scriptStep": chatbot_script_step.id,
            //             "message": step_message.id,
            //             "operatorFound": True,
            //         },
            //     ).bus_send()
            */
            return default;
        }

        public async Task<TEntity> AllowInviteByEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _allow_invite_by_email(self):
            // return self.channel_type == "group" or (
            //     self.channel_type == "channel" and not self.group_public_id
            // )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _allow_publish_rating_stats(self):
            // """Override to allow the rating stats to be demonstrated."""
            // return False
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _allow_publish_rating_stats(self):
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _allow_publish_rating_stats(self):
            // return True
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _apply_taxes_to_price(
            //     self, price, currency, product_taxes, taxes, product_or_template,
            //     website=None,
            // ):
            //     website = website or self.env['website'].get_current_website()
            //     price = self.env['product.product']._get_tax_included_unit_price_from_price(
            //         price,
            //         product_taxes,
            //         product_taxes_after_fp=taxes,
            //     )
            //     show_tax = website.show_line_subtotals_tax_selection
            //     tax_display = 'total_excluded' if show_tax == 'tax_excluded' else 'total_included'
            // 
            //     # The list_price is always the price of one.
            //     return taxes.compute_all(
            //         price, currency, 1, product_or_template, self.env.user.partner_id
            //     )[tax_display]
            */
            return default;
        }

        public async Task<TEntity> AttachmentToHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _attachment_to_html(self, attachment):
            // if attachment.mimetype.startswith("image/"):
            //     return Markup(
            //         "<img src='%s?access_token=%s' alt='%s' style='max-width: 75%%; height: auto; padding: 5px;'>",
            //     ) % (
            //         attachment.image_src,
            //         attachment.generate_access_token()[0],
            //         attachment.name,
            //     )
            // file_extension = get_extension(attachment.display_name)
            // attachment_data = {
            //     "id": attachment.id,
            //     "access_token": attachment.generate_access_token()[0],
            //     "checksum": attachment.checksum,
            //     "extension": file_extension.lstrip("."),
            //     "mimetype": attachment.mimetype,
            //     "filename": attachment.display_name,
            //     "url": attachment.url,
            // }
            // return Markup(
            //     "<div data-embedded='file' data-oe-protected='true' contenteditable='false' data-embedded-props='%s'/>",
            // ) % json.dumps({"fileData": attachment_data})
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _auto_init(self):
            // """Override _auto_init to prevent MemoryError on ecommerce installation in dbs with lots of products"""
            // if not column_exists(self.env.cr, 'product_template', 'variants_default_code'):
            //     create_column(self.env.cr, 'product_template', 'variants_default_code', 'varchar')
            //     self.env.cr.execute(SQL(
            //         """
            //             UPDATE product_template
            //             SET variants_default_code = variants.default_codes
            //             FROM (
            //                 SELECT pt.id AS template_id,
            //                        STRING_AGG(pv.default_code, %s) AS default_codes
            //                 FROM product_template pt
            //                 JOIN product_product pv ON pv.product_tmpl_id = pt.id
            //                 WHERE pv.default_code IS NOT NULL
            //                 GROUP BY pt.id
            //             ) AS variants
            //             WHERE product_template.id = variants.template_id
            //         """, RARE_DELIMITER))
            // return super()._auto_init()
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _base_domain_item_ids(self):
            // return [
            //     '|',
            //     ('pricelist_id', '=', False),
            //     ('pricelist_id.active', '=', True),
            // ]
            */
            return default;
        }

        public async Task<TEntity> BroadcastInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _broadcast(self, partner_ids):
            // """ Broadcast the current channel header to the given partner ids
            //     :param partner_ids : the partner to notify
            // """
            // for partner in self.env['res.partner'].browse(partner_ids):
            //     if user := partner.main_user_id:
            //         Store(bus_channel=user).add(
            //             self.with_user(user).with_context(allowed_company_ids=[]),
            //         ).bus_send()
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def button_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').button_bom_cost()
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _can_be_added_to_cart(self):
            // """
            // Pre-check to `_is_add_to_cart_possible` to know if product can be sold.
            // """
            // self.ensure_one()
            // return bool(self.filtered_domain(self.env['website']._product_domain()))
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if field_name in ["image_512", "image_128"] and self.sudo().self_order_available:
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _cartesian_product(self, product_template_attribute_values_per_line, parent_combination):
            // """
            // Generate all possible combination for attributes values (aka cartesian product).
            // It is equivalent to itertools.product except it skips invalid partial combinations before they are complete.
            // 
            // Imagine the cartesian product of 'A', 'CD' and range(1_000_000) and let's say that 'A' and 'C' are incompatible.
            // If you use itertools.product or any normal cartesian product, you'll need to filter out of the final result
            // the 1_000_000 combinations that start with 'A' and 'C' . Instead, This implementation will test if 'A' and 'C' are
            // compatible before even considering range(1_000_000), skip it and and continue with combinations that start
            // with 'A' and 'D'.
            // 
            // It's necessary for performance reason because filtering out invalid combinations from standard Cartesian product
            // can be extremely slow
            // 
            // :param product_template_attribute_values_per_line: the values we want all the possibles combinations of.
            // One list of values by attribute line
            // :return: a generator of product template attribute value
            // """
            // if not product_template_attribute_values_per_line:
            //     return
            // 
            // all_exclusions = {self.env['product.template.attribute.value'].browse(k):
            //                   self.env['product.template.attribute.value'].browse(v) for k, v in
            //                   self._get_own_attribute_exclusions().items()}
            // # The following dict uses product template attribute values as keys
            // # 0 means the value is acceptable, greater than 0 means it's rejected, it cannot be negative
            // # Bear in mind that several values can reject the same value and the latter can only be included in the
            // #  considered combination if no value rejects it.
            // # This dictionary counts how many times each value is rejected.
            // # Each time a value is included in the considered combination, the values it rejects are incremented
            // # When a value is discarded from the considered combination, the values it rejects are decremented
            // current_exclusions = defaultdict(int)
            // for exclusion in self._get_parent_attribute_exclusions(parent_combination):
            //     current_exclusions[self.env['product.template.attribute.value'].browse(exclusion)] += 1
            // partial_combination = self.env['product.template.attribute.value']
            // 
            // # The following list reflects product_template_attribute_values_per_line
            // # For each line, instead of a list of values, it contains the index of the selected value
            // # -1 means no value has been picked for the line in the current (partial) combination
            // value_index_per_line = [-1] * len(product_template_attribute_values_per_line)
            // # determines which line line we're working on
            // line_index = 0
            // # determines which ptav we're working on
            // current_ptav = None
            // 
            // while True:
            //     current_line_values = product_template_attribute_values_per_line[line_index]
            //     current_ptav_index = value_index_per_line[line_index]
            // 
            //     # For multi-checkbox attribute, the list is empty as we want to start without any selected value
            //     if not current_line_values:
            //         if line_index == len(product_template_attribute_values_per_line) - 1:
            //             # submit combination if we're on the last line
            //             yield partial_combination
            //             # will break or continue further down as current_ptav_index is always -1 here
            //         else:
            //             line_index += 1
            //             continue
            //     else:
            //         current_ptav = current_line_values[current_ptav_index]
            // 
            //     # removing exclusions from current_ptav as we're removing it from partial_combination
            //     if current_ptav_index >= 0:
            //         for ptav_to_include_back in all_exclusions[current_ptav]:
            //             current_exclusions[ptav_to_include_back] -= 1
            //         partial_combination -= current_ptav
            // 
            //     if current_ptav_index < len(current_line_values) - 1:
            //         # go to next value of current line
            //         value_index_per_line[line_index] += 1
            //         current_line_values = product_template_attribute_values_per_line[line_index]
            //         current_ptav_index = value_index_per_line[line_index]
            //         current_ptav = current_line_values[current_ptav_index]
            //     elif line_index != 0:
            //         # reset current line, and then go to previous line
            //         value_index_per_line[line_index] = - 1
            //         line_index -= 1
            //         continue
            //     else:
            //         # we're done if we must reset first line
            //         break
            // 
            //     # adding exclusions from current_ptav as we're incorporating it in partial_combination
            //     for ptav_to_exclude in all_exclusions[current_ptav]:
            //         current_exclusions[ptav_to_exclude] += 1
            //     partial_combination += current_ptav
            // 
            //     # test if included values excludes current value or if current value exclude included values
            //     if current_exclusions[current_ptav] or \
            //             any(intersection in partial_combination for intersection in all_exclusions[current_ptav]):
            //         continue
            // 
            //     if line_index == len(product_template_attribute_values_per_line) - 1:
            //         # submit combination if we're on the last line
            //         yield partial_combination
            //     else:
            //         # else we go to the next line
            //         line_index += 1
            */
            return default;
        }

        public async Task<TEntity> ChannelChangeDescriptionAsync<TEntity>(IEnumerable<TEntity> entities, object description) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_change_description(self, description):
            // self.ensure_one()
            // self.write({'description': description})
            */
            return default;
        }

        public async Task<TEntity> ChannelFetchedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_fetched(self):
            // """ Broadcast the channel_fetched notification to channel members
            // """
            // for channel in self:
            //     if not channel.message_ids.ids:
            //         continue
            //     # a bit not-modular but helps understanding code
            //     if channel.channel_type not in {'chat', 'whatsapp'}:
            //         continue
            //     last_message_id = channel.message_ids.ids[0] # zero is the index of the last message
            //     member = self.env['discuss.channel.member'].search([('channel_id', '=', channel.id), ('partner_id', '=', self.env.user.partner_id.id)], limit=1)
            //     if not member:
            //         # member not a part of the channel
            //         continue
            //     if member.fetched_message_id.id == last_message_id:
            //         # last message fetched by user is already up-to-date
            //         continue
            //     # Avoid serialization error when multiple tabs are opened.
            //     query = """
            //         UPDATE discuss_channel_member
            //         SET fetched_message_id = %s
            //         WHERE id IN (
            //             SELECT id FROM discuss_channel_member WHERE id = %s
            //             FOR NO KEY UPDATE SKIP LOCKED
            //         )
            //     """
            //     self.env.cr.execute(query, (last_message_id, member.id))
            //     channel._bus_send(
            //         "discuss.channel.member/fetched",
            //         {
            //             "channel_id": channel.id,
            //             "id": member.id,
            //             "last_message_id": last_message_id,
            //             "partner_id": self.env.user.partner_id.id,
            //         },
            //     )
            */
            return default;
        }

        public async Task<TEntity> ChannelJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_join(self):
            // """Shortcut to add the current user as member of self channels.
            // Prefer calling add_members() directly when possible.
            // """
            // self._add_members(users=self.env.user)
            */
            return default;
        }

        public async Task<TEntity> ChannelPinAsync<TEntity>(IEnumerable<TEntity> entities, object pinned) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_pin(self, pinned=False):
            // self.ensure_one()
            // member = self.env['discuss.channel.member'].search(
            //     [('partner_id', '=', self.env.user.partner_id.id), ('channel_id', '=', self.id), ('is_pinned', '!=', pinned)])
            // if member:
            //     member.write({'unpin_dt': False if pinned else fields.Datetime.now()})
            // store = Store(bus_channel=self.env.user)
            // if not pinned:
            //     store.add(self, {"close_chat_window": True})
            // else:
            //     store.add(self)
            // store.bus_send()
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def channel_pin(self, pinned=False):
            // """ Override to clean an empty livechat channel.
            //  This is typically called when the operator send a chat request to a website.visitor
            //  but don't speak to them and closes the chatter.
            //  This allows operators to send the visitor a new chat request.
            //  If active empty livechat channel,
            //  delete discuss_channel as not useful to keep empty chat
            //  """
            // super().channel_pin(pinned=pinned)
            // if self.channel_type == "livechat" and not pinned and not self.message_ids:
            //     self.sudo().unlink()
            */
            return default;
        }

        public async Task<TEntity> ChannelRenameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_rename(self, name):
            // self.ensure_one()
            // self.write({'name': name})
            // body = Markup('<div data-oe-type="channel_rename" class="o_mail_notification">%s</div>') % name
            // self.message_post(body=body, message_type="notification", subtype_xmlid="mail.mt_comment")
            */
            return default;
        }

        public async Task<TEntity> ChannelSetCustomNameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_set_custom_name(self, name):
            // self.ensure_one()
            // self.self_member_id.custom_channel_name = name
            // Store(bus_channel=self.self_member_id._bus_channel()).add(
            //     self.self_member_id,
            //     "custom_channel_name",
            // ).bus_send()
            */
            return default;
        }

        public async Task<TEntity> ChatbotFindCustomerValuesInMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object step_type_to_field) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_find_customer_values_in_messages(self, step_type_to_field):
            // """
            // Look for user's input in the channel's messages based on a dictionary
            // mapping the step_type to the field name of the model it will be used on.
            // 
            // :param dict step_type_to_field: a dict of step types to customer fields
            //     to fill, like : {'question_email': 'email_from', 'question_phone': 'mobile'}
            // """
            // values = {}
            // filtered_message_ids = self.chatbot_message_ids.filtered(
            //     # sudo: chatbot.script.step - getting the type of the current step
            //     lambda m: m.script_step_id.sudo().step_type in step_type_to_field
            // )
            // for message_id in filtered_message_ids:
            //     field_name = step_type_to_field[message_id.script_step_id.step_type]
            //     if not values.get(field_name):
            //         values[field_name] = html2plaintext(message_id.user_raw_answer or '')
            // 
            // return values
            */
            return default;
        }

        public async Task<TEntity> ChatbotPostMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script, object body) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_post_message(self, chatbot_script, body):
            // """ Small helper to post a message as the chatbot operator
            // 
            // :param record chatbot_script
            // :param string body: message HTML body """
            // # sudo: mail.message - chat bot is allowed to post a message which
            // # requires reading its partner among other things.
            // return self.with_context(mail_post_autofollow_author_skip=True).sudo().message_post(
            //     author_id=chatbot_script.sudo().operator_partner_id.id,
            //     body=body,
            //     message_type='comment',
            //     subtype_xmlid='mail.mt_comment',
            // )
            */
            return default;
        }

        public async Task<TEntity> ChatbotRestartInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_restart(self, chatbot_script):
            // # sudo: discuss.channel - visitor can clear current step to restart the script
            // self.sudo().chatbot_current_step_id = False
            // # sudo: discuss.channel - visitor can reactivate livechat
            // self.sudo().livechat_end_dt = False
            // # sudo: chatbot.message - visitor can clear chatbot messages to restart the script
            // self.sudo().chatbot_message_ids.unlink()
            // return self._chatbot_post_message(
            //     chatbot_script,
            //     Markup('<div class="o_mail_notification">%s</div>') % _('Restarting conversation...'),
            // )
            */
            return default;
        }

        public async Task<TEntity> ChatbotValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object chatbot_script) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_validate_email(self, email_address, chatbot_script):
            // email_address = html2plaintext(email_address)
            // email_normalized = email_normalize(email_address)
            // 
            // posted_message = False
            // error_message = False
            // if not email_normalized:
            //     error_message = _(
            //         "'%(input_email)s' does not look like a valid email. Can you please try again?",
            //         input_email=email_address
            //     )
            //     posted_message = self._chatbot_post_message(chatbot_script, plaintext2html(error_message))
            // 
            // return {
            //     'success': bool(email_normalized),
            //     'posted_message': posted_message,
            //     'error_message': error_message,
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_barcode_uniqueness(self):
            // for template in self:
            //     template.product_variant_ids._check_barcode_uniqueness()
            */
            return default;
        }

        public async Task<TEntity> CheckCanUpdateMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _check_can_update_message_content(self, message):
            // # Don't call super in this override as we want to ignore the mail.thread behavior completely
            // if not message.message_type == 'comment':
            //     raise UserError(_("Only messages type comment can have their content updated on model 'discuss.channel'"))
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_combo_ids_not_empty(self):
            // for template in self:
            //     if template.type == 'combo' and not template.combo_ids:
            //         raise ValidationError(_("A combo product must contain at least 1 combo choice."))
            */
            return default;
        }

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _check_combo_inclusions(self):
            // for product in self:
            //     if not product.available_in_pos:
            //         combo_name = self.env['product.combo.item'].sudo().search([('product_id', 'in', product.product_variant_ids.ids)], limit=1).combo_id.name
            //         if combo_name:
            //             raise UserError(_('You must first remove this product from the %s combo', combo_name))
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_incompatible_types(self):
            // incompatible_types = self._get_incompatible_types()
            // if len(incompatible_types) < 2:
            //     return
            // fields = self.env['ir.model.fields'].sudo().search_read(
            //     [('model', '=', 'product.template'), ('name', 'in', incompatible_types)],
            //     ['name', 'field_description'])
            // field_descriptions = {v['name']: v['field_description'] for v in fields}
            // field_list = incompatible_types + ['name']
            // values = self.read(field_list)
            // for val in values:
            //     incompatible_fields = [f for f in incompatible_types if val[f]]
            //     if len(incompatible_fields) > 1:
            //         raise ValidationError(_(
            //             "The product (%(product)s) has incompatible values: %(value_list)s",
            //             product=val['name'],
            //             value_list=[field_descriptions[v] for v in incompatible_fields],
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_no_cyclic_dependencies(self):
            // if self._has_cycle('depend_on_ids'):
            //     raise ValidationError(_("Two tasks cannot depend on each other."))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create a recursive hierarchy of tasks.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _check_print_images_are_set_before_publishing(self):
            // for product in self.filtered('gelato_template_ref'):
            //     if product.is_published and product.gelato_missing_images:
            //         raise ValidationError(
            //             _("Print images must be set on products before they can be published.")
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _check_project_and_template(self):
            // """ NOTE 'service_tracking' should be in decorator parameters but since ORM check constraints twice (one after setting
            //     stored fields, one after setting non stored field), the error is raised when company-dependent fields are not set.
            //     So, this constraints does cover all cases and inconsistent can still be recorded until the ORM change its behavior.
            // """
            // for product in self:
            //     if product.service_tracking == 'no' and (product.project_id or product.project_template_id):
            //         raise ValidationError(_('The product %s should not have a project nor a project template since it will not generate project.', product.name))
            //     elif product.service_tracking == 'task_global_project' and product.project_template_id:
            //         raise ValidationError(_('The product %s should not have a project template since it will generate a task in a global project.', product.name))
            //     elif product.service_tracking in ['task_in_project', 'project_only'] and product.project_id:
            //         raise ValidationError(_('The product %s should not have a global project since it will generate a project.', product.name))
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_sale_combo_ids(self):
            // for template in self:
            //     if (
            //         template.type == 'combo'
            //         and template.sale_ok
            //         and any(
            //             not product.sale_ok for product in template.combo_ids.combo_item_ids.product_id
            //         )
            //     ):
            //         raise ValidationError(
            //             _("A sellable combo product can only contain sellable products.")
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_sale_product_company(self):
            // """Ensure the product is not being restricted to a single company while
            // having been sold in another one in the past, as this could cause issues."""
            // products_by_compagny = defaultdict(lambda: self.env['product.template'])
            // for product in self:
            //     if not product.product_variant_ids or not product.company_id:
            //         # No need to check if the product has just being created (`product_variant_ids` is
            //         # still empty) or if we're writing `False` on its company (should always work.)
            //         continue
            //     products_by_compagny[product.company_id] |= product
            // 
            // for target_company, products in products_by_compagny.items():
            //     subquery_products = self.env['product.product'].sudo().with_context(active_test=False)._search([('product_tmpl_id', 'in', products.ids)])
            //     so_lines = self.env['sale.order.line'].sudo().search_read(
            //         [('product_id', 'in', subquery_products), '!', ('company_id', 'child_of', target_company.id)],
            //         fields=['id', 'product_id'])
            //     if so_lines:
            //         used_products = [sol['product_id'][1] for sol in so_lines]
            //         raise ValidationError(_('The following products cannot be restricted to the company'
            //                                 ' %(company)s because they have already been used in quotations or '
            //                                 'sales orders in another company:\n%(used_products)s\n'
            //                                 'You can archive these products and recreate them '
            //                                 'with your company restriction instead, or leave them as '
            //                                 'shared product.', company=target_company.name, used_products=', '.join(used_products)))
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_service_to_purchase(self):
            // for template in self:
            //     if template.service_to_purchase:
            //         if template.type != 'service':
            //             raise ValidationError(_("Product that is not a service can not create RFQ."))
            //         template._check_vendor_for_service_to_purchase(template.seller_ids)
            */
            return default;
        }

        public async Task<TEntity> CheckServiceTrackingForEventBoothsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _check_service_tracking_for_event_booths(self):
            // """ Prevent changing the service_tracking field if the product template or any of its variants
            // is linked to an Event Booth Category.
            // """
            // if product_variants_not_event_booth := self.product_variant_ids.filtered(lambda p: p.service_tracking != 'event_booth'):
            //     linked_booth_category = self.env['event.booth.category'].sudo().search([
            //         ('product_id', 'in', product_variants_not_event_booth.ids)
            //     ], limit=1)
            //     if linked_booth_category:
            //         raise ValidationError(
            //             _(
            //                 'The "service_tracking" for the product template, %(product_template_name)s cannot be changed because '
            //                 'one of its variants is assigned to the Event Booth Category, %(event_booth_category_name)s. '
            //                 'The service_tracking must remain "Event Booth".',
            //                 product_template_name=linked_booth_category.product_id.name,
            //                 event_booth_category_name=linked_booth_category.name,
            //             )
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _check_uom_not_in_invoice(self):
            // self.env['product.template'].flush_model(['uom_id'])
            // self.env.cr.execute("""
            //     SELECT prod_template.id
            //       FROM account_move_line line
            //       JOIN product_product prod_variant ON line.product_id = prod_variant.id
            //       JOIN product_template prod_template ON prod_variant.product_tmpl_id = prod_template.id
            //       JOIN uom_uom template_uom ON prod_template.uom_id = template_uom.id
            //       JOIN uom_uom line_uom ON line.product_uom_id = line_uom.id
            //      WHERE prod_template.id IN %s
            //        AND line.parent_state = 'posted'
            //        AND template_uom.id != line_uom.id
            //      LIMIT 1
            // """, [tuple(self.ids)])
            // if self.env.cr.fetchall():
            //     raise ValidationError(_(
            //         "This product is already being used in posted Journal Entries.\n"
            //         "If you want to change its Unit of Measure, please archive this product and create a new one."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_vendor_for_service_to_purchase(self, sellers):
            // if not sellers:
            //     raise ValidationError(_("Please define the vendor from whom you would like to purchase this service automatically."))
            */
            return default;
        }

        public async Task<TEntity> CleanEmptyMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _clean_empty_message(self, message):
            // super()._clean_empty_message(message)
            // message.parent_id = False
            */
            return default;
        }

        public async Task<TEntity> CloseLivechatSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _close_livechat_session(self, **kwargs):
            // """ Set deactivate the livechat channel and notify (the operator) the reason of closing the session."""
            // self.ensure_one()
            // if not self.livechat_end_dt:
            //     member = self.channel_member_ids.filtered(lambda m: m.is_self)
            //     if member:
            //         # sudo: discuss.channel.rtc.session - member of current user can leave call
            //         member.sudo()._rtc_leave_call()
            //     # sudo: discuss.channel - visitor left the conversation, state must be updated
            //     self.sudo().livechat_end_dt = fields.Datetime.now()
            //     Store(bus_channel=self).add(self, "livechat_end_dt").bus_send()
            //     # avoid useless notification if the channel is empty
            //     if not self.message_ids:
            //         return
            //     # Notify that the visitor has left the conversation
            //     # sudo: mail.message - posting visitor leave message is allowed
            //     self.sudo().message_post(
            //         author_id=self.env.ref('base.partner_root').id,
            //         body=Markup('<div class="o_mail_notification o_hide_author">%s</div>')
            //         % self._get_visitor_leave_message(**kwargs),
            //         message_type='notification',
            //         subtype_xmlid='mail.mt_comment'
            //     )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _complete_inverse_exclusions(self, exclusions):
            // """Will complete the dictionnary of exclusions with their respective inverse
            // e.g: Black excludes XL and L
            // -> XL excludes Black
            // -> L excludes Black"""
            // result = dict(exclusions)
            // for key, value in exclusions.items():
            //     for exclusion in value:
            //         if exclusion in result and key not in result[exclusion]:
            //             result[exclusion].append(key)
            //         else:
            //             result[exclusion] = [key]
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for task in self:
            //     task.access_url = f'/my/tasks/{task.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_action_rights(self):
            // user_karma = self.env.user.karma
            // for channel in self:
            //     if channel.can_publish:
            //         channel.can_vote = channel.can_comment = channel.can_review = True
            //     elif not channel.is_member:
            //         channel.can_vote = channel.can_comment = channel.can_review = False
            //     else:
            //         channel.can_review = user_karma >= channel.karma_review
            //         channel.can_comment = user_karma >= channel.karma_slide_comment
            //         channel.can_vote = user_karma >= channel.karma_slide_vote
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_allow_comment(self):
            // """Comment allowed by default except for documentation channels."""
            // for record in self:
            //     record.allow_comment = record.channel_type != 'documentation'
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_avatar_128(self):
            // for record in self:
            //     record.avatar_128 = record.image_128 or record._generate_avatar()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_avatar_cache_key(self):
            // for channel in self:
            //     if not channel.avatar_128:
            //         channel.avatar_cache_key = 'no-avatar'
            //     else:
            //         channel.avatar_cache_key = sha512(channel.avatar_128).hexdigest()
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_barcode(self):
            // self._compute_template_field_from_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_count(self):
            // self.base_unit_count = 0
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_count = template.product_variant_ids.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_id(self):
            // self.base_unit_id = self.env['website.base.unit']
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_id = template.product_variant_ids.base_unit_id
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_name(self):
            // for template in self:
            //     template.base_unit_name = template.base_unit_id.name or template.uom_name
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_price(self):
            // for template in self:
            //     template.base_unit_price = template._get_base_unit_price(template.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_bom_count(self):
            // for product in self:
            //     product.bom_count = self.env['mrp.bom'].search_count(
            //         ['|', ('product_tmpl_id', 'in', product.ids), ('byproduct_ids.product_id.product_tmpl_id', 'in', product.ids)]
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_can_be_expensed(self):
            // self.filtered(lambda p: p.type not in ['consu', 'service'] or not p.purchase_ok).update({'can_be_expensed': False})
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for template in self.with_context(bin_size=False):
            //     template.can_image_1024_be_zoomed = template.image_1920 and is_image_size_above(template.image_1920, template.image_1024)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_can_publish(self):
            // """ For channels of type 'training', only the responsible (see user_id field) can publish slides.
            // The 'sudo' user needs to be handled because they are the one used for uploads done on the front-end when the
            // logged in user is not publisher but fulfills the upload_group_ids condition. Invited attendees can
            // preview the course as public and sudo. Prevent them from uploading."""
            // for record in self:
            //     if not record.can_upload:
            //         record.can_publish = False
            //     elif record.user_id == self.env.user:
            //         record.can_publish = True
            //     else:
            //         record.can_publish = self.env.user.has_group('website_slides.group_website_slides_manager')
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_can_upload(self):
            // for record in self:
            //     if record.user_id == self.env.user:
            //         record.can_upload = True
            //     elif record.sudo().upload_group_ids:
            //         record.can_upload = bool(record.sudo().upload_group_ids & self.env.user.group_ids)
            //     else:
            //         record.can_upload = self.env.user.has_group('website_slides.group_website_slides_manager')
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_category_and_slide_ids(self):
            // for channel in self:
            //     channel.slide_category_ids = channel.slide_ids.filtered(lambda slide: slide.is_category)
            //     channel.slide_content_ids = channel.slide_ids - channel.slide_category_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelNameMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_channel_name_member_ids(self):
            //   to_compute = self.filtered(
            //       lambda c: c.channel_type in self._member_based_naming_channel_types()
            //   )
            //   (self - to_compute).channel_name_member_ids = False
            //   if not to_compute:
            //       return
            //   self.env.cr.execute("""
            //       SELECT channel.id, member.id
            //         FROM discuss_channel channel
            // JOIN LATERAL
            //           (
            //              SELECT id
            //                FROM discuss_channel_member M
            //               WHERE M.channel_id = channel.id
            //            ORDER BY id
            //               LIMIT 3
            //           ) as member ON TRUE
            //        WHERE channel.id IN %s
            //   """, (tuple(to_compute.ids),))
            //   channel_id_to_member_ids = defaultdict(list)
            //   for channel_id, member_id in self.env.cr.fetchall():
            //       channel_id_to_member_ids[channel_id].append(member_id)
            //   for channel in self:
            //       channel.channel_name_member_ids = channel_id_to_member_ids.get(channel.id)
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_channel_partner_ids(self):
            // for channel in self:
            //     channel.channel_partner_ids = channel.channel_member_ids.partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _compute_color(self):
            // """Automatically set the color field based on the selected category."""
            // for product in self:
            //     if product.pos_categ_ids:
            //         product.color = product.pos_categ_ids[0].color
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_company_id(self):
            // for task in self:
            //     if not task.parent_id and not task.project_id:
            //         continue
            //     task.company_id = task.project_id.company_id or task.parent_id.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_cost_currency_id(self):
            // env_currency_id = self.env.company.currency_id.id
            // for template in self:
            //     template.cost_currency_id = template.company_id.sudo().currency_id.id or env_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_cost_method(self):
            // for product_template in self:
            //     product_template.cost_method = (
            //         product_template.categ_id.with_company(
            //             product_template.company_id
            //         ).property_cost_method
            //         or (product_template.company_id or self.env.company).cost_method
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_currency_id(self):
            // main_company = self.env['res.company']._get_main_company()
            // for template in self:
            //     template.currency_id = template.company_id.sudo().currency_id.id or main_company.currency_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_default_code(self):
            // self._compute_template_field_from_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_display_name(self):
            // display_default_code = self.env.context.get('display_default_code', True)
            // for template in self:
            //     if not template.name:
            //         template.display_name = False
            //     elif not (display_default_code and template.default_code):
            //         template.display_name = template.name
            //     elif self.env.context.get('formatted_display_name'):
            //         code_prefix = f'\t--{template.default_code}--'
            //         template.display_name = f'{template.name}{code_prefix}'
            //     else:
            //         code_prefix = f'[{template.default_code}] '
            //         template.display_name = f'{code_prefix}{template.name}'
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_duration(self):
            // for record in self:
            //     end = record.livechat_end_dt or fields.Datetime.now()
            //     start = record.create_date or fields.Datetime.now()
            //     record.duration = (end - start).total_seconds() / 3600
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_enroll(self):
            // self.filtered(lambda channel: channel.visibility == 'members').enroll = 'invite'
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // self.filtered(lambda t: not t.sale_ok).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: not t.can_be_expensed).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: t.is_storable).expense_policy = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy_tooltip(self):
            // for product_template in self:
            //     if not product_template.can_be_expensed or not product_template.expense_policy:
            //         product_template.expense_policy_tooltip = False
            //     elif product_template.expense_policy == 'no':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses of this category may not be added to a Sales Order."
            //         )
            //     elif product_template.expense_policy == 'cost':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their actual cost when posted."
            //         )
            //     elif product_template.expense_policy == 'sales_price':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their sales price (product price, pricelist, etc.) when posted."
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     allowed_companies = record.company_id or self.env.companies
            //     record.fiscal_country_codes = ",".join(allowed_companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_missing_images(self):
            // for product in self:
            //     product.gelato_missing_images = any(
            //         not image.datas for image in product.gelato_image_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_product_uid(self):
            // self._compute_template_field_from_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> ComputeGroupPublicIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_group_public_id(self):
            // channels = self.filtered(lambda channel: channel.channel_type == "channel")
            // for channel in channels:
            //     if channel.parent_channel_id:
            //         channel.group_public_id = channel.parent_channel_id.group_public_id
            //     elif not channel.group_public_id:
            //         channel.group_public_id = self.env.ref("base.group_user")
            // (self - channels).group_public_id = None
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_has_available_route_ids(self):
            // self.has_available_route_ids = self.env['stock.route'].search_count([('product_selectable', '=', True)])
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_has_configurable_attributes(self):
            // """A product is considered configurable if:
            // - It has dynamic attributes
            // - It has any attribute line with at least 2 attribute values configured
            // - It has multi-checkbox display type
            // - It has at least one custom attribute value
            // """
            // for product in self:
            //     product.has_configurable_attributes = (
            //         product.has_dynamic_attributes() or any(
            //             ptal._is_configurable()
            //             for ptal in product.attribute_line_ids
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeHasCrmLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def _compute_has_crm_lead(self):
            // for channel in self:
            //     channel.has_crm_lead = bool(channel.lead_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_has_requested_access(self):
            // requested_cids = self.sudo().activity_search(
            //     ['mail.mail_activity_data_todo'],
            //     additional_domain=[('request_partner_id', '=', self.env.user.partner_id.id)],
            //     only_automated=False,
            // ).mapped('res_id')
            // for channel in self:
            //     channel.has_requested_access = channel.id in requested_cids
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_template_ancestor(self):
            // for task in self:
            //     task.has_template_ancestor = task.is_template or (task.parent_id and task.parent_id.sudo().has_template_ancestor)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitationUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_invitation_url(self):
            // for channel in self:
            //     channel.invitation_url = f"/chat/{channel.id}/{channel.uuid}"
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitedMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_invited_member_ids(self):
            // members_by_channel = {
            //     channel: self.env["discuss.channel.member"].browse(member_ids)
            //     for channel, member_ids in self.env["discuss.channel.member"]._read_group(
            //         [("channel_id", "in", self.ids), ("rtc_inviting_session_id", "!=", False)],
            //         ["channel_id"],
            //         ["id:array_agg"],
            //     )
            // }
            // for channel in self:
            //     channel.invited_member_ids = members_by_channel.get(channel)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_invoice_policy(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.invoice_policy).invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_is_closed(self):
            // for task in self:
            //     task.is_closed = task.state in CLOSED_STATES
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_dynamically_created(self):
            // for template in self:
            //     template.is_dynamically_created = any(
            //         line.attribute_id.create_variant == 'dynamic'
            //         for line in template.attribute_line_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_is_editable(self):
            // for channel in self:
            //     channel.is_editable = channel.has_access("write")
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_is_kits(self):
            // domain = [('product_tmpl_id', 'in', self.ids), ('type', '=', 'phantom'), '|', ('company_id', '=', False), ('company_id', '=', self.env.company.id)]
            // bom_mapping = self.env['mrp.bom'].sudo().search_read(domain, ['product_tmpl_id'])
            // kits_ids = set(b['product_tmpl_id'][0] for b in bom_mapping)
            // for template in self:
            //     template.is_kits = (template.id in kits_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_is_member(self):
            // for channel in self:
            //     channel.is_member = bool(channel.self_member_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def compute_is_storable(self):
            // self.filtered(lambda t: t.type != 'consu' and t.is_storable).is_storable = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_is_visible(self):
            // for channel in self:
            //     channel.is_visible = (
            //         channel.visibility == 'public'
            //         or channel.is_member
            //         or (not self.env.user._is_public() and channel.visibility == 'connected')
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeLivechatAgentHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_history_ids(self):
            // for channel in self:
            //     channel.livechat_agent_history_ids = (
            //         channel.livechat_channel_member_history_ids.filtered(
            //             lambda h: h.livechat_member_type == "agent",
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_partner_ids(self):
            // for channel in self:
            //     channel.livechat_agent_partner_ids = (
            //         channel.livechat_agent_history_ids.partner_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentProvidingHelpHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_providing_help_history(self):
            // for channel in self:
            //     channel.livechat_agent_providing_help_history = (
            //         channel.livechat_agent_history_ids.sorted(
            //             lambda h: (h.create_date, h.id), reverse=True
            //         )[0]
            //         if channel.livechat_is_escalated
            //         else None
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentRequestingHelpHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_requesting_help_history(self):
            // for channel in self:
            //     channel.livechat_agent_requesting_help_history = (
            //         channel.livechat_agent_history_ids.sorted(lambda h: (h.create_date, h.id))[0]
            //         if channel.livechat_is_escalated
            //         else None
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatBotHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_bot_history_ids(self):
            // for channel in self:
            //     channel.livechat_bot_history_ids = channel.livechat_channel_member_history_ids.filtered(
            //         lambda h: h.livechat_member_type == "bot",
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatBotPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_bot_partner_ids(self):
            // for channel in self:
            //     channel.livechat_bot_partner_ids = (
            //         channel.livechat_bot_history_ids.partner_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerGuestIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_guest_ids(self):
            // for channel in self:
            //     channel.livechat_customer_guest_ids = (
            //         channel.livechat_customer_history_ids.guest_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_history_ids(self):
            // for channel in self:
            //     channel.livechat_customer_history_ids = (
            //         channel.livechat_channel_member_history_ids.filtered(
            //             lambda h: h.livechat_member_type == "visitor",
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_partner_ids(self):
            // for channel in self:
            //     channel.livechat_customer_partner_ids = (
            //         channel.livechat_customer_history_ids.partner_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatIsEscalatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_is_escalated(self):
            // for channel in self:
            //     channel.livechat_is_escalated = len(channel.livechat_agent_history_ids) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatMatchesSelfExpertiseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_matches_self_expertise(self):
            // for channel in self:
            //     channel.livechat_matches_self_expertise = bool(
            //         channel.livechat_expertise_ids & self.env.user.livechat_expertise_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatMatchesSelfLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_matches_self_lang(self):
            // for channel in self:
            //     channel.livechat_matches_self_lang = (
            //         channel.livechat_lang_id in self.env.user.livechat_lang_ids
            //         or channel.livechat_lang_id.code == self.env.user.lang
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatOutcomeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_outcome(self):
            // for channel in self:
            //     self.livechat_outcome = (
            //         "escalated" if channel.livechat_is_escalated else channel.livechat_failure
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatStartHourInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_start_hour(self):
            // for channel in self:
            //     channel.livechat_start_hour = channel.create_date.hour
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_status(self):
            // for channel in self.filtered(lambda c: c.livechat_end_dt):
            //     channel.livechat_status = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatWeekDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_week_day(self):
            // for channel in self:
            //     channel.livechat_week_day = str(channel.create_date.weekday())
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_lot_valuated(self):
            // for product in self:
            //     if product.tracking == 'none':
            //         product.lot_valuated = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_member_count(self):
            // read_group_res = self.env['discuss.channel.member']._read_group(domain=[('channel_id', 'in', self.ids)], groupby=['channel_id'], aggregates=['__count'])
            // member_count_by_channel_id = {channel.id: count for channel, count in read_group_res}
            // for channel in self:
            //     channel.member_count = member_count_by_channel_id.get(channel.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_members_counts(self):
            // read_group_res = self.env['slide.channel.partner'].sudo()._read_group(
            //     domain=[('channel_id', 'in', self.ids)],
            //     groupby=['channel_id', 'member_status'],
            //     aggregates=['__count']
            // )
            // data = {(channel.id, member_status): count for channel, member_status, count in read_group_res}
            // for channel in self:
            //     channel.members_invited_count = data.get((channel.id, 'invited'), 0)
            //     channel.members_engaged_count = data.get((channel.id, 'joined'), 0) + data.get((channel.id, 'ongoing'), 0)
            //     channel.members_completed_count = data.get((channel.id, 'completed'), 0)
            //     channel.members_all_count = channel.members_invited_count + channel.members_engaged_count + channel.members_completed_count
            //     channel.members_count = channel.members_engaged_count + channel.members_completed_count
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_membership_values(self):
            // if self.env.user._is_public():
            //     self.is_member = False
            //     self.is_member_invited = False
            //     return
            // data = {
            //     member_status: channel_ids
            //     for member_status, channel_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         [('partner_id', '=', self.env.user.partner_id.id), ('channel_id', 'in', self.ids), ('active', '=', True)],
            //         ['member_status'], ['channel_id:array_agg']
            //     )
            // }
            // active_channels_ids = data.get('joined', []) + data.get('ongoing', []) + data.get('completed', [])
            // invitation_pending_channels_ids = data.get('invited', [])
            // for channel in self:
            //     channel.is_member = channel.id in active_channels_ids
            //     channel.is_member_invited = channel.id in invitation_pending_channels_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_message_count(self):
            // read_group_res = self.env["mail.message"]._read_group(
            //     domain=[
            //         ("model", "=", "discuss.channel"),
            //         ("res_id", "in", self.ids),
            //         ("message_type", "not in", ["user_notification", "notification"])
            //     ], groupby=["res_id"], aggregates=["__count"]
            // )
            // message_count_by_channel_id = dict(read_group_res)
            // for channel in self:
            //     channel.message_count = message_count_by_channel_id.get(channel.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // for template in self:
            //     template.mrp_product_qty = template.uom_id.round(sum(template.mapped('product_variant_ids').mapped('mrp_product_qty')))
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_moves(self):
            // res = defaultdict(lambda: {'moves_in': 0, 'moves_out': 0})
            // incoming_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'incoming'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // outgoing_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'outgoing'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // for product, count in incoming_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_in'] += count
            // for product, count in outgoing_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_out'] += count
            // for template in self:
            //     template.nbr_moves_in = res[template.id]['moves_in']
            //     template.nbr_moves_out = res[template.id]['moves_out']
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_reordering_rules(self):
            // res = {k: {'nbr_reordering_rules': 0, 'reordering_min_qty': 0, 'reordering_max_qty': 0} for k in self.ids}
            // product_data = self.env['stock.warehouse.orderpoint']._read_group([('product_id.product_tmpl_id', 'in', self.ids)], ['product_id'], ['__count', 'product_min_qty:sum', 'product_max_qty:sum'])
            // for product, count, product_min_qty, product_max_qty in product_data:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['nbr_reordering_rules'] += count
            //     res[product_tmpl_id]['reordering_min_qty'] = product_min_qty
            //     res[product_tmpl_id]['reordering_max_qty'] = product_max_qty
            // for template in self:
            //     if not template.id:
            //         template.nbr_reordering_rules = 0
            //         template.reordering_min_qty = 0
            //         template.reordering_max_qty = 0
            //         continue
            //     template.nbr_reordering_rules = res[template.id]['nbr_reordering_rules']
            //     template.reordering_min_qty = res[template.id]['reordering_min_qty']
            //     template.reordering_max_qty = res[template.id]['reordering_max_qty']
            */
            return default;
        }

        public async Task<TEntity> ComputeNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_next_serial(self):
            // for template in self:
            //     if template.lot_sequence_id:
            //         template.next_serial = '{:0{}d}{}'.format(
            //             template.lot_sequence_id.number_next_actual,
            //             template.lot_sequence_id.padding,
            //             template.lot_sequence_id.suffix or ""
            //         )
            //     else:
            //         template.next_serial = '0000001'
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_partner_has_new_content(self):
            // new_published_slides = self.env['slide.slide'].sudo().search([
            //     ('is_published', '=', True),
            //     ('date_published', '>', fields.Datetime.now() - relativedelta(days=7)),
            //     ('channel_id', 'in', self.ids),
            //     ('is_category', '=', False)
            // ])
            // slide_partner_completed = self.env['slide.slide.partner'].sudo().search([
            //     ('channel_id', 'in', self.ids),
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('slide_id', 'in', new_published_slides.ids),
            //     ('completed', '=', True)
            // ]).mapped('slide_id')
            // for channel in self:
            //     new_slides = new_published_slides.filtered(lambda slide: slide.channel_id == channel)
            //     channel.partner_has_new_content = any(slide not in slide_partner_completed for slide in new_slides)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_phone(self):
            // for task in self:
            //     task.partner_phone = task.partner_id.phone or False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_partners(self):
            // data = {
            //     slide_channel: partner_ids
            //     for slide_channel, partner_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         [('channel_id', 'in', self.ids), ('member_status', '!=', 'invited')],
            //         ['channel_id'],
            //         aggregates=['partner_id:array_agg']
            //     )
            // }
            // for slide_channel in self:
            //     slide_channel.partner_ids = data.get(slide_channel, [])
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_prerequisite_user_has_completed(self):
            // completed_prerequisite_channels = self.env['slide.channel.partner'].sudo().search([
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('channel_id', 'in', self.prerequisite_channel_ids.ids),
            //     ('member_status', '=', 'completed'),
            // ]).mapped('channel_id')
            // for channel in self:
            //     channel.prerequisite_user_has_completed = all(
            //         channel in completed_prerequisite_channels for channel in channel.prerequisite_channel_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_document_count(self):
            // for template in self:
            //     template.product_document_count = template.env['product.document'].search_count(
            //         template._get_product_document_domain()
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // self.product_tooltip = False
            // for template in self:
            //     template.product_tooltip = template._prepare_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_count(self):
            // for template in self:
            //     template.product_variant_count = len(template.product_variant_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_id(self):
            // for p in self:
            //     p.product_variant_id = p.product_variant_ids[:1].id
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputePublishDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_publish_date(self):
            // """Set `publish_date` to the moment of (re-)publishing."""
            // self.filtered('is_published').publish_date = fields.Datetime.now()
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchase_method(self):
            // default_purchase_method = self.env['product.template'].default_get(['purchase_method']).get('purchase_method', 'receive')
            // for product in self:
            //     if product.type == 'service':
            //         product.purchase_method = 'purchase'
            //     else:
            //         product.purchase_method = default_purchase_method
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // for record in self:
            //     if record.can_be_expensed:
            //         record.purchase_ok = True
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchased_product_qty(self):
            // for template in self.with_context(active_test=False):
            //     template.purchased_product_qty = template.uom_id.round(sum(p.purchased_product_qty for p in template.product_variant_ids))
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities_dict(self):
            // variants_available = {
            //     p['id']: p for p in self.product_variant_ids._origin.read(['qty_available', 'virtual_available', 'incoming_qty', 'outgoing_qty'])
            // }
            // prod_available = {}
            // for template in self:
            //     qty_available = 0
            //     virtual_available = 0
            //     incoming_qty = 0
            //     outgoing_qty = 0
            //     for p in template.product_variant_ids._origin:
            //         qty_available += variants_available[p.id]["qty_available"]
            //         virtual_available += variants_available[p.id]["virtual_available"]
            //         incoming_qty += variants_available[p.id]["incoming_qty"]
            //         outgoing_qty += variants_available[p.id]["outgoing_qty"]
            //     prod_available[template.id] = {
            //         "qty_available": qty_available,
            //         "virtual_available": virtual_available,
            //         "incoming_qty": incoming_qty,
            //         "outgoing_qty": outgoing_qty,
            //     }
            // return prod_available
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // res = self._compute_quantities_dict()
            // for template in self.with_context(skip_qty_available_update=True):
            //     template.qty_available = res[template.id]['qty_available']
            //     template.virtual_available = res[template.id]['virtual_available']
            //     template.incoming_qty = res[template.id]['incoming_qty']
            //     template.outgoing_qty = res[template.id]['outgoing_qty']
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingAvgTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _compute_rating_avg_text(self):
            // for record in self:
            //     record.rating_avg_text = rating_data._rating_avg_to_text(record.rating_avg)
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingLastValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _compute_rating_last_value(self):
            // # Pure SQL instead of calling read_group to allow ordering array_agg
            // self.flush_model(['rating_ids'])
            // self.env['rating.rating'].flush_model(['consumed', 'rating'])
            // if not self.ids:
            //     self.rating_last_value = 0
            //     return
            // self.env.cr.execute("""
            //     SELECT
            //         array_agg(rating ORDER BY write_date DESC, id DESC) AS "ratings",
            //         res_id as res_id
            //     FROM "rating_rating"
            //     WHERE
            //         res_model = %s
            //     AND res_id in %s
            //     AND consumed = true
            //     GROUP BY res_id""", [self._name, tuple(self.ids)])
            // read_group_raw = self.env.cr.dictfetchall()
            // rating_by_res_id = {e['res_id']: e['ratings'][0] for e in read_group_raw}
            // for record in self:
            //     record.rating_last_value = rating_by_res_id.get(record.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingSatisfactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _compute_rating_satisfaction(self):
            // """ Compute the rating satisfaction percentage, this is done separately from rating_count and rating_avg
            //     since the query is different, to avoid computing if it is not necessary"""
            // domain = self._rating_domain() & Domain('rating', '>=', rating_data.RATING_LIMIT_MIN)
            // # See `_compute_rating_percentage_satisfaction` above
            // read_group_res = self.env['rating.rating']._read_group(domain, ['res_id', 'rating'], aggregates=['__count'])
            // default_grades = {'great': 0, 'okay': 0, 'bad': 0}
            // grades_per_record = {record_id: default_grades.copy() for record_id in self.ids}
            // 
            // for record_id, rating, count in read_group_res:
            //     grade = rating_data._rating_to_grade(rating)
            //     grades_per_record[record_id][grade] += count
            // 
            // for record in self:
            //     grade_repartition = grades_per_record.get(record.id, default_grades)
            //     grade_count = sum(grade_repartition.values())
            //     record.rating_percentage_satisfaction = grade_repartition['great'] * 100 / grade_count if grade_count else -1
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _compute_rating_stats(self):
            // """ Compute avg and count in one query, as thoses fields will be used together most of the time. """
            // domain = self._rating_domain() & Domain('rating', '>=', rating_data.RATING_LIMIT_MIN)
            // read_group_res = self.env['rating.rating']._read_group(domain, ['res_id'], aggregates=['__count', 'rating:avg'])  # force average on rating column
            // mapping = {res_id: {'rating_count': count, 'rating_avg': rating_avg} for res_id, count, rating_avg in read_group_res}
            // for record in self:
            //     record.rating_count = mapping.get(record.id, {}).get('rating_count', 0)
            //     record.rating_avg = mapping.get(record.id, {}).get('rating_avg', 0)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_rating_stats(self):
            // super()._compute_rating_stats()
            // for record in self:
            //     record.rating_avg_stars = record.rating_avg
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_sales_count(self):
            // for product in self:
            //     product.sales_count = product.uom_id.round(sum(p.sales_count for p in product.with_context(active_test=False).product_variant_ids))
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfMemberIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_self_member_id(self):
            // member_by_channel = {
            //     channel: self.env["discuss.channel.member"].browse(member_id)
            //     for channel, member_id in self.env["discuss.channel.member"]._read_group(
            //         [("channel_id", "in", self.ids), ("is_self", "=", True)], ["channel_id"], ["id:max"]
            //     )
            // }
            // for channel in self:
            //     channel.self_member_id = member_by_channel.get(channel)
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _compute_self_order_visible(self):
            // active_self_order_configs = self.env['pos.config'].sudo().search_count([('self_ordering_mode', '!=', 'nothing')])
            // for product in self:
            //     product.self_order_visible = bool(active_self_order_configs)
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_serial_prefix_format(self):
            // for template in self:
            //     template.serial_prefix_format = template.lot_sequence_id.prefix or ""
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_service_policy(self):
            // for product in self:
            //     product.service_policy = self._get_general_to_service(product.invoice_policy, product.service_type)
            //     if not product.service_policy and product.type == 'service':
            //         product.service_policy = 'ordered_prepaid'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // self.filtered(lambda product: product.type != 'service').service_tracking = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // super()._compute_service_tracking()
            // self.filtered(lambda pt: not pt.sale_ok).service_tracking = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.service_type).service_type = 'manual'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // super()._compute_service_type()
            // self.filtered(lambda t: t.is_storable).service_type = 'manual'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_service_upsell_threshold_ratio(self):
            // product_uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_unit = self.env.ref('uom.product_uom_unit')
            // company_uom = self.env.company.timesheet_encode_uom_id
            // for record in self:
            //     if not record.uom_id or record.uom_id != uom_unit or\
            //        product_uom_hour.factor == record.uom_id.factor:
            //         record.service_upsell_threshold_ratio = False
            //         continue
            //     else:
            //         timesheet_encode_uom = record.company_id.timesheet_encode_uom_id or company_uom
            //         record.service_upsell_threshold_ratio = f'(1 {record.uom_id.name} = {timesheet_encode_uom.factor / product_uom_hour.factor:.2f} {timesheet_encode_uom.name})'
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // super()._compute_show_qty_status_button()
            // for template in self:
            //     if template.is_kits:
            //         template.show_on_hand_qty_status_button = template.product_variant_count <= 1
            //         template.show_forecasted_qty_status_button = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // for template in self:
            //     template.show_on_hand_qty_status_button = template.is_storable
            //     template.show_forecasted_qty_status_button = template.is_storable
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyUpdateButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_update_button(self):
            // for product in self:
            //     product.show_qty_update_button = (
            //         product._should_open_product_quants()
            //         or product.product_variant_count > 1
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slide_last_update(self):
            // for record in self:
            //     record.slide_last_update = fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slides_statistics(self):
            // default_vals = dict(total_views=0, total_votes=0, total_time=0, total_slides=0)
            // keys = ['nbr_%s' % slide_category for slide_category in self.env['slide.slide']._fields['slide_category'].get_values(self.env)]
            // default_vals.update(dict((key, 0) for key in keys))
            // 
            // result = dict((cid, dict(default_vals)) for cid in self.ids)
            // read_group_res = self.env['slide.slide']._read_group(
            //     [('active', '=', True), ('is_published', '=', True), ('channel_id', 'in', self.ids), ('is_category', '=', False)],
            //     ['channel_id', 'slide_category'],
            //     aggregates=['__count', 'likes:sum', 'dislikes:sum', 'total_views:sum', 'completion_time:sum'])
            // for channel, slide_category, count, likes_sum, dislikes_sum, total_views_sum, completion_time_sum in read_group_res:
            //     channel_dict = result[channel.id]
            //     channel_dict['total_votes'] += likes_sum
            //     channel_dict['total_votes'] -= dislikes_sum
            //     channel_dict['total_views'] += total_views_sum
            //     channel_dict['total_time'] += completion_time_sum
            //     if slide_category:
            //         channel_dict[f'nbr_{slide_category}'] = count
            //         channel_dict['total_slides'] += count
            // 
            // for record in self:
            //     record.update(result.get(record.id, default_vals))
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_standard_price(self):
            // # Depends on force_company context because standard_price is company_dependent
            // # on the product_product
            // self._compute_template_field_from_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_allocated_hours(self):
            // for task in self:
            //     task.subtask_allocated_hours = sum(task.child_ids.mapped('allocated_hours'))
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_completion_percentage(self):
            // for task in self:
            //     task.subtask_completion_percentage = task.subtask_count and task.closed_subtask_count / task.subtask_count
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ComputeTaskTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_task_template(self):
            // for product in self:
            //     if product.task_template_id and product.task_template_id.project_id != product.project_id:
            //         product.task_template_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_tax_string(self):
            // for record in self:
            //     record.tax_string = record._construct_tax_string(record.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_template_field_from_variant_field(self, fname, default=False):
            // """Sets the value of the given field based on the template variant values
            // 
            // Equals to product_variant_ids[fname] if it's a single variant product.
            // Otherwise, sets the value specified in ``default``.
            // It's used to compute fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field to compute
            //     (field name must be identical between product.product & product.template models)
            // :param default: default value to set when there are multiple or no variants on the template
            // :return: None
            // """
            // for template in self:
            //     variant_count = len(template.product_variant_ids)
            //     if variant_count == 1:
            //         template[fname] = template.product_variant_ids[fname]
            //     elif variant_count == 0 and self.env.context.get("active_test", True):
            //         # If the product has no active variants, retry without the active_test
            //         template_ctx = template.with_context(active_test=False)
            //         template_ctx._compute_template_field_from_variant_field(fname, default=default)
            //     else:
            //         template[fname] = default
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_tracking(self):
            // self.filtered(lambda t: not t.is_storable and t.tracking != 'none').tracking = 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_used_in_bom_count(self):
            // for template in self:
            //     template.used_in_bom_count = self.env['mrp.bom'].search_count(
            //         [('bom_line_ids.product_tmpl_id', 'in', template.ids)])
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_user_statistics(self):
            // current_user_info = self.env['slide.channel.partner'].sudo().search(
            //     [('channel_id', 'in', self.ids), ('partner_id', '=', self.env.user.partner_id.id)]
            // )
            // mapped_data = dict((info.channel_id.id, (info.member_status == 'completed', info.completed_slides_count)) for info in current_user_info)
            // for record in self:
            //     completed, completed_slides_count = mapped_data.get(record.id, (False, 0))
            //     record.completed = completed
            //     record.completion = 100.0 if completed else round(100.0 * completed_slides_count / (record.total_slides or 1))
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_valid_product_template_attribute_line_ids(self):
            // """A product template attribute line is considered valid if it has at
            // least one possible value.
            // 
            // Those with only one value are considered valid, even though they should
            // not appear on the configurator itself (unless they have an is_custom
            // value to input), indeed single value attributes can be used to filter
            // products among others based on that attribute/value.
            // """
            // for record in self:
            //     record.valid_product_template_attribute_line_ids = record.attribute_line_ids.filtered(lambda ptal: ptal.value_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_valuation(self):
            // for product_template in self:
            //     product_template.valuation = product_template.categ_id.with_company(
            //         product_template.company_id).property_valuation or self.env.company.inventory_valuation
            */
            return default;
        }

        public async Task<TEntity> ComputeVariantsDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_variants_default_code(self):
            // for template in self:
            //     template.variants_default_code = RARE_DELIMITER.join(
            //         template.product_variant_ids.filtered('default_code').mapped('default_code')
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('analytic.group_analytic_accounting')
            // for product_template in self:
            //     product_template.visible_expense_policy = visibility and product_template.purchase_ok
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // expense_products = self.filtered(lambda p: p.can_be_expensed)
            // super(ProductTemplate, self - expense_products)._compute_visible_expense_policy()
            // visibility = self.env.user.has_group('hr_expense.group_hr_expense_user')
            // for product_template in expense_products:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('project.group_project_user')
            // for product_template in self:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            // return super()._compute_visible_expense_policy()
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume(self):
            // self._compute_template_field_from_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_absolute_url(self):
            // super()._compute_website_absolute_url()
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_default_background_image_url(self):
            // for channel in self:
            //     channel.website_default_background_image_url = f'website_slides/static/src/img/channel-{channel.channel_type}-default.jpg'
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for product in self:
            //     if product.id:
            //         product.website_url = "/shop/%s" % self.env['ir.http']._slug(product)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for channel in self:
            //     if channel.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         channel.website_url = f"/slides/{self.env['ir.http']._slug(channel)}"
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight(self):
            // self._compute_template_field_from_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ConstraintFromMessageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_from_message_id(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // if failing_channels := self.sudo().filtered(
            //     lambda c: c.from_message_id
            //     and (
            //         c.from_message_id.res_id not in [c.parent_channel_id.id] + c.parent_channel_id.sub_channel_ids.ids
            //         or c.from_message_id.model != "discuss.channel"
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: initial message should belong to parent channel or one of its sub-channels.",
            //             channels=failing_channels.mapped("name"),
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> ConstraintGroupIdChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_group_id_channel(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // failing_channels = self.sudo().filtered(lambda channel: channel.channel_type != 'channel' and (channel.group_public_id or channel.group_ids))
            // if failing_channels:
            //     raise ValidationError(_("For %(channels)s, channel_type should be 'channel' to have the group-based authorization or group auto-subscription.", channels=', '.join([ch.name for ch in failing_channels])))
            */
            return default;
        }

        public async Task<TEntity> ConstraintParentChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_parent_channel_id(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // if failing_channels := self.sudo().filtered(
            //     lambda c: c.parent_channel_id
            //     and (
            //         c.parent_channel_id.parent_channel_id
            //         or c.parent_channel_id.channel_type not in ["channel", "group"]
            //         or c.parent_channel_id.channel_type != c.channel_type
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: parent should not be a sub-channel and should be of type 'channel' or 'group'. The sub-channel should have the same type as the parent.",
            //             channels=failing_channels.mapped("name"),
            //         ),
            //     )
            */
            return default;
        }

        public async Task<TEntity> ConstraintPartnersChatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_partners_chat(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // for ch in self.sudo().filtered(lambda ch: ch.channel_type == 'chat'):
            //     if len(ch.channel_member_ids) > 2:
            //         raise ValidationError(_("A channel of type 'chat' cannot have more than two users."))
            */
            return default;
        }

        public async Task<TEntity> ConstraintSubscriptionDepartmentIdsChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def _constraint_subscription_department_ids_channel(self):
            // failing_channels = self.sudo().filtered(lambda channel: channel.channel_type != 'channel' and channel.subscription_department_ids)
            // if failing_channels:
            //     raise ValidationError(_("For %(channels)s, channel_type should be 'channel' to have the department auto-subscription.", channels=', '.join([ch.name for ch in failing_channels])))
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _construct_tax_string(self, price):
            // currency = self.currency_id
            // res = self.taxes_id._filter_taxes_by_company(self.env.company).compute_all(
            //     price, product=self, partner=self.env['res.partner']
            // )
            // joined = []
            // included = res['total_included']
            // if currency.compare_amounts(included, price):
            //     joined.append(_('%(amount)s Incl. Taxes', amount=format_amount(self.env, included, currency)))
            // excluded = res['total_excluded']
            // if currency.compare_amounts(excluded, price):
            //     joined.append(_('%(amount)s Excl. Taxes', amount=format_amount(self.env, excluded, currency)))
            // if joined:
            //     tax_string = f"(= {', '.join(joined)})"
            // else:
            //     tax_string = " "
            // return tax_string
            */
            return default;
        }

        public async Task<TEntity> ConvertVisitorToLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object key) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def _convert_visitor_to_lead(self, partner, key):
            // """ Create a lead from channel /lead command
            // :param partner: internal user partner (operator) that created the lead;
            // :param key: operator input in chat ('/lead Lead about Product')
            // """
            // # if public user is part of the chat: consider lead to be linked to an
            // # anonymous user whatever the participants. Otherwise keep only share
            // # partners (no user or portal user) to link to the lead.
            // customers = self.env['res.partner']
            // for customer in self.with_context(active_test=False).channel_partner_ids.filtered(lambda p: p != partner and p.partner_share):
            //     if customer.is_public:
            //         customers = self.env['res.partner']
            //         break
            //     else:
            //         customers |= customer
            // 
            // utm_source = self.env.ref('crm_livechat.utm_source_livechat', raise_if_not_found=False)
            // return self.env['crm.lead'].create({
            //     "origin_channel_id": self.id,
            //     'name': html2plaintext(key[5:]),
            //     'partner_id': customers[0].id if customers else False,
            //     'user_id': False,
            //     'team_id': False,
            //     'description': self._get_channel_history(),
            //     'referred': partner.name,
            //     'source_id': utm_source and utm_source.id,
            // })
            --- ODOO METHOD SOURCE (MODULE: website_crm_livechat, FILE: discuss_channel.py) ---
            // def _convert_visitor_to_lead(self, partner, key):
            // """ When website is installed, we can link the created lead from /lead command
            //  to the current website_visitor. We do not use the lead name as it does not correspond
            //  to the lead contact name."""
            // lead = super()._convert_visitor_to_lead(partner, key)
            // visitor_sudo = self.livechat_visitor_id.sudo()
            // if visitor_sudo:
            //     visitor_sudo.write({'lead_ids': [(4, lead.id)]})
            //     lead.country_id = lead.country_id or visitor_sudo.country_id
            // return lead
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for channel, vals in zip(self, vals_list):
            //     if 'name' not in default:
            //         vals['name'] = f"{channel.name} ({_('copy')})"
            //     if 'enroll' not in default and channel.visibility == "members":
            //         vals['enroll'] = 'invite'
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     # Ensure creator is member of its channel it is easier for them to manage it (unless it is odoobot)
            //     if not vals.get('channel_partner_ids') and not self.env.is_superuser():
            //         vals['channel_partner_ids'] = [(0, 0, {
            //             'partner_id': self.env.user.partner_id.id
            //         })]
            //     if not is_html_empty(vals.get('description')) and is_html_empty(vals.get('description_short')):
            //         vals['description_short'] = vals['description']
            // 
            // channels = super(SlideChannel, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // 
            // for channel in channels:
            //     if channel.user_id:
            //         channel._action_add_members(channel.user_id.partner_id)
            //     if channel.enroll_group_ids:
            //         channel._add_groups_members()
            // 
            // return channels
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsForPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object extra_list) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_attachments_for_post(self, values_list, extra_list):
            // # Create voice metadata from meta information
            // attachments = super()._create_attachments_for_post(values_list, extra_list)
            // voice = attachments.env['ir.attachment']  # keep env, notably for potential sudo
            // for attachment, (_cid, _name, _token, info) in zip(attachments, extra_list):
            //     if info.get('voice'):
            //         voice += attachment
            // if voice:
            //     voice._set_voice_metadata()
            // return attachments
            */
            return default;
        }

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Create attributes for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // if len(template_info['variants']) == 1:  # The template has no attribute.
            //     self.gelato_product_uid = template_info['variants'][0]['productUid']
            // else:  # The template has multiple attributes.
            //     # Iterate over the variants to find and create the possible attributes.
            //     for variant_data in template_info['variants']:
            //         current_variant_pavs = self.env['product.attribute.value']
            //         for attribute_data in variant_data['variantOptions']:  # Attribute name and value.
            //             # Search for the existing attribute with the proper variant creation policy and
            //             # create it if not found.
            //             attribute = self.env['product.attribute'].search(
            //                 [('name', '=', attribute_data['name']), ('create_variant', '=', 'always')],
            //                 limit=1,
            //             )
            //             if not attribute:
            //                 attribute = self.env['product.attribute'].create({
            //                     'name': attribute_data['name']
            //                 })
            // 
            //             # Search for the existing attribute value and create it if not found.
            //             attribute_value = self.env['product.attribute.value'].search([
            //                 ('name', '=', attribute_data['value']),
            //                 ('attribute_id', '=', attribute.id),
            //             ], limit=1)
            //             if not attribute_value:
            //                 attribute_value = self.env['product.attribute.value'].create({
            //                     'name': attribute_data['value'],
            //                     'attribute_id': attribute.id
            //                 })
            //             current_variant_pavs += attribute_value
            // 
            //             # Search for the existing PTAL and create it if not found.
            //             ptal = self.env['product.template.attribute.line'].search(
            //                 [('product_tmpl_id', '=', self.id), ('attribute_id', '=', attribute.id)],
            //                 limit=1,
            //             )
            //             if not ptal:
            //                 self.env['product.template.attribute.line'].create({
            //                     'product_tmpl_id': self.id,
            //                     'attribute_id': attribute.id,
            //                     'value_ids': [Command.link(attribute_value.id)]
            //                 })
            //             else:  # The PTAL already exists.
            //                 ptal.value_ids = [Command.link(attribute_value.id)]  # Link the value.
            // 
            //         # Find the variant that was automatically created and set the Gelato UID.
            //         for variant in self.product_variant_ids:
            //             corresponding_ptavs = variant.product_template_attribute_value_ids
            //             corresponding_pavs = corresponding_ptavs.product_attribute_value_id
            //             if corresponding_pavs == current_variant_pavs:
            //                 variant.gelato_product_uid = variant_data['productUid']
            //                 break
            // 
            //     # Delete the incompatible variants that were created but not allowed by Gelato.
            //     variants_without_gelato = self.env['product.product'].search([
            //         ('product_tmpl_id', '=', self.id),
            //         ('gelato_product_uid', '=', False)
            //     ])
            //     variants_without_gelato.unlink()
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Override of `sale_gelato` to set the eCommerce description. """
            // self.description_ecommerce = template_info['description']
            // return super()._create_attributes_from_gelato_info(template_info)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid group_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_channel(self, name, group_id):
            // """ Create a channel and add the current partner, broadcast it (to make the user directly
            //     listen to it when polling)
            //     :param name : the name of the channel to create
            //     :param group_id : the group allowed to join the channel.
            //     :return dict : channel header
            // """
            // # create the channel
            // vals = {
            //     'channel_type': 'channel',
            //     'name': name,
            // }
            // new_channel = self.create(vals)
            // group = self.env['res.groups'].search([('id', '=', group_id)]) if group_id else None
            // new_channel.group_public_id = group.id if group else None
            // notification = Markup('<div class="o_mail_notification">%s</div>') % _("created this channel.")
            // new_channel.message_post(body=notification, message_type="notification", subtype_xmlid="mail.mt_comment")
            // return new_channel
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_first_product_variant(self, log_warning=False):
            // """Create if necessary and possible and return the first product
            // variant for this template.
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the first product variant or none
            // :rtype: recordset of `product.product`
            // """
            // return self._create_product_variant(self._get_first_possible_combination(), log_warning)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object default_display_mode, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_group(self, partners_to, default_display_mode=False, name=''):
            // """ Creates a group channel.
            // 
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param str default_display_mode: how the channel will be displayed by default
            //     :param str name: group name. default name is computed client side from the list of members if no name is set
            //     :returns: channel_info of the created channel
            //     :rtype: dict
            // """
            // partners_to = OrderedSet(partners_to)
            // channel = self.create({
            //     'channel_member_ids': [Command.create({'partner_id': partner_id}) for partner_id in partners_to],
            //     'channel_type': 'group',
            //     'default_display_mode': default_display_mode,
            //     'name': name,
            // })
            // channel._broadcast(channel.channel_member_ids.partner_id.ids)
            // return channel
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_print_images_from_gelato_info(self, template_info):
            // """ Create print image for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // # Iterate over the print image data listed in the info of the first variant, as we don't
            // # support varying image placements between variants.
            // for print_image_data in template_info['variants'][0]['imagePlaceholders']:
            //     # Gelato might send image placements that are named '1' or 'front' that are not accepted
            //     # by their API when placing order.
            //     if print_image_data['printArea'].lower() in ('1', 'front'):
            //         print_image_data['printArea'] = 'default'  # Use 'default' which is accepted.
            // 
            //     # Gelato might send several print images for the same placement if several layers were
            //     # defined, but we keep only one because their API only accepts one image per placement.
            //     print_image_found = bool(self.env['product.document'].search_count([
            //         ('name', 'ilike', print_image_data['printArea']),
            //         ('res_id', '=', self.id),
            //         ('res_model', '=', 'product.template'),
            //         ('is_gelato', '=', True),  # Avoid finding regular documents with the same name.
            //     ]))
            //     if not print_image_found:
            //         self.gelato_image_ids = [Command.create({
            //             'name': print_image_data['printArea'].lower(),
            //             'res_id': self.id,
            //             'res_model': 'product.template',
            //             'is_gelato': True,
            //         })]
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def create_product_variant(self, product_template_attribute_value_ids):
            // """ Create if necessary and possible and return the id of the product
            // variant matching the given combination for this template.
            // 
            // Note AWA: Known "exploit" issues with this method:
            // 
            // - This method could be used by an unauthenticated user to generate a
            //   lot of useless variants. Unfortunately, after discussing the
            //   matter with ODO, there's no easy and user-friendly way to block
            //   that behavior.
            //   We would have to use captcha/server actions to clean/... that
            //   are all not user-friendly/overkill mechanisms.
            // 
            // - This method could be used to try to guess what product variant ids
            //   are created in the system and what product template ids are
            //   configured as "dynamic", but that does not seem like a big deal.
            // 
            // The error messages are identical on purpose to avoid giving too much
            // information to a potential attacker:
            // 
            // - returning 0 when failing
            // - returning the variant id whether it already existed or not
            // 
            // :param product_template_attribute_value_ids: the combination for which
            //     to get or create variant
            // 
            // :type product_template_attribute_value_ids: list of id
            //     of `product.template.attribute.value`
            // 
            // :return: id of the product variant matching the combination or 0
            // :rtype: int
            // """
            // combination = self.env['product.template.attribute.value'].browse(
            //     product_template_attribute_value_ids)
            // 
            // return self._create_product_variant(combination, log_warning=True).id or 0
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantFromPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attribute_value_ids, Guid config_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def create_product_variant_from_pos(self, attribute_value_ids, config_id):
            // """ Create a product variant from the POS interface. """
            // self.ensure_one()
            // pos_config = self.env['pos.config'].browse(config_id)
            // product_template_attribute_value_ids = self.env['product.template.attribute.value'].browse(attribute_value_ids)
            // product_variant = self._create_product_variant(product_template_attribute_value_ids)
            // return {
            //     'product.product': product_variant.read(self.env['product.product']._load_pos_data_fields(pos_config), load=False),
            // }
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_product_variant(self, combination, log_warning=False):
            // """ Create if necessary and possible and return the product variant
            // matching the given combination for this template.
            // 
            // It is possible to create only if the template has dynamic attributes
            // and the combination itself is possible.
            // If we are in this case and the variant already exists but it is
            // archived, it is activated instead of being created again.
            // 
            // :param combination: the combination for which to get or create variant.
            //     The combination must contain all necessary attributes, including
            //     those of type no_variant. Indeed even though those attributes won't
            //     be included in the variant if newly created, they are needed when
            //     checking if the combination is possible.
            // :type combination: recordset of `product.template.attribute.value`
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the product variant matching the combination or none
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // Product = self.env['product.product']
            // 
            // product_variant = self._get_variant_for_combination(combination)
            // if product_variant:
            //     if not product_variant.active and self.has_dynamic_attributes() and self._is_combination_possible(combination):
            //         product_variant.active = True
            //     return product_variant
            // 
            // if not self.has_dynamic_attributes():
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create a variant for the non-dynamic product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // if not self._is_combination_possible(combination):
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create an invalid variant for the product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // return Product.sudo().create({
            //     'product_tmpl_id': self.id,
            //     'product_template_attribute_value_ids': [(6, 0, combination._without_no_variant_attributes().ids)]
            // })
            */
            return default;
        }

        public async Task<TEntity> CreateSubChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid from_message_id, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_sub_channel(self, from_message_id=None, name=None):
            // self.ensure_one()
            // message = self.env["mail.message"]
            // if from_message_id:
            //     message = self.env["mail.message"].search([("id", "=", from_message_id)])
            // if not name:
            //     name = self.env._("New Thread")
            //     if message:
            //         if message._filter_empty():
            //             name = self.env._("This message has been removed")
            //         elif stripped := message.body and message.body.striptags():
            //             name = stripped[:30]
            // sub_channel = self.create(
            //     {
            //         "channel_type": self.channel_type,
            //         "from_message_id": message.id,
            //         "name": name,
            //         "parent_channel_id": self.id,
            //     }
            // )
            // sub_channel.add_members(partner_ids=(self.env.user.partner_id | message.author_id).ids, post_joined_message=False)
            // notification = (
            //     Markup('<div class="o_mail_notification">%s</div>')
            //     % _(
            //         "%(user)s started a thread: %(goto)s%(thread_name)s%(goto_end)s."
            //     )
            // ) % {
            //     "user": self.env.user.display_name,
            //     "goto": Markup(
            //         "<a href='#' class='o_channel_redirect' data-oe-id='%s' data-oe-model='discuss.channel'>"
            //     )
            //     % sub_channel.id,
            //     "goto_end": Markup("</a>"),
            //     "thread_name": sub_channel.name,
            // }
            // self.message_post(
            //     body=notification, message_type="notification", subtype_xmlid="mail.mt_comment"
            // )
            // return sub_channel
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_variant_ids(self):
            // if not self:
            //     return
            // self.env.flush_all()
            // Product = self.env["product.product"]
            // 
            // variants_to_create = []
            // variants_to_activate = Product
            // variants_to_unlink = Product
            // 
            // for tmpl_id in self:
            //     lines_without_no_variants = tmpl_id.valid_product_template_attribute_line_ids._without_no_variant_attributes()
            // 
            //     all_variants = tmpl_id.with_context(active_test=False).product_variant_ids.sorted(lambda p: (p.active, -p.id))
            // 
            //     current_variants_to_create = []
            //     current_variants_to_activate = Product
            // 
            //     # adding an attribute with only one value should not recreate product
            //     # write this attribute on every product to make sure we don't lose them
            //     single_value_lines = lines_without_no_variants.filtered(lambda ptal: len(ptal.product_template_value_ids._only_active()) == 1)
            //     if single_value_lines:
            //         for variant in all_variants:
            //             combination = variant.product_template_attribute_value_ids | single_value_lines.product_template_value_ids._only_active()
            //             # Do not add single value if the resulting combination would
            //             # be invalid anyway.
            //             if (
            //                 len(combination) == len(lines_without_no_variants)
            //                 and combination.attribute_line_id == lines_without_no_variants
            //                 # Update only if necessary to prevent a cache invalidation
            //                 and variant.product_template_attribute_value_ids != combination
            //             ):
            //                 variant.product_template_attribute_value_ids = combination
            // 
            //     # Set containing existing `product.template.attribute.value` combination
            //     existing_variants = {
            //         variant.product_template_attribute_value_ids: variant for variant in all_variants
            //     }
            // 
            //     # Determine which product variants need to be created based on the attribute
            //     # configuration. If any attribute is set to generate variants dynamically, skip the
            //     # process.
            //     # Technical note: if there is no attribute, a variant is still created because
            //     # 'not any([])' and 'set([]) not in set([])' are True.
            //     if not tmpl_id.has_dynamic_attributes():
            //         # Iterator containing all possible `product.template.attribute.value` combination
            //         # The iterator is used to avoid MemoryError in case of a huge number of combination.
            //         all_combinations = itertools.product(*[
            //             ptal.product_template_value_ids._only_active() for ptal in lines_without_no_variants
            //         ])
            //         # For each possible variant, create if it doesn't exist yet.
            //         for combination in tmpl_id._filter_combinations_impossible_by_config(
            //             all_combinations, ignore_no_variant=True,
            //         ):
            //             if combination in existing_variants:
            //                 current_variants_to_activate += existing_variants[combination]
            //             else:
            //                 current_variants_to_create.append(tmpl_id._prepare_variant_values(combination))
            //                 variant_limit = self.env['ir.config_parameter'].sudo().get_param('product.dynamic_variant_limit', 1000)
            //                 if len(current_variants_to_create) > int(variant_limit):
            //                     raise UserError(_(
            //                         'The number of variants to generate is above allowed limit. '
            //                         'You should either not generate variants for each combination or generate them on demand from the sales order. '
            //                         'To do so, open the form view of attributes and change the mode of *Create Variants*.'))
            //         variants_to_create += current_variants_to_create
            //         variants_to_activate += current_variants_to_activate
            // 
            //     elif existing_variants:
            //         variants_combinations = [variant.product_template_attribute_value_ids for variant in existing_variants.values()]
            //         current_variants_to_activate += Product.concat(*[existing_variants[possible_combination]
            //             for possible_combination in tmpl_id._filter_combinations_impossible_by_config(variants_combinations, ignore_no_variant=True)
            //         ])
            //         variants_to_activate += current_variants_to_activate
            // 
            //     variants_to_unlink += all_variants - current_variants_to_activate
            // 
            // if variants_to_activate:
            //     variants_to_activate.write({'active': True})
            // if variants_to_create:
            //     Product.create(variants_to_create)
            // if variants_to_unlink:
            //     variants_to_unlink._unlink_or_archive()
            //     # prevent change if exclusion deleted template by deleting last variant
            //     if self.exists() != self:
            //         raise UserError(_("This configuration of product attributes, values, and exclusions would lead to no possible variant. Please archive or delete your product directly if intended."))
            // for variant in variants_to_unlink:
            //     combo_items_to_unlink = self.env['product.combo.item'].search([
            //         ('product_id', '=', variant.id)
            //     ])
            //     # Unlink all combo items which reference unlinked variants.
            //     combo_items_to_unlink.unlink()
            // 
            // # prefetched o2m have to be reloaded (because of active_test)
            // # (eg. product.template: product_variant_ids)
            // # We can't rely on existing invalidate because of the savepoint
            // # in _unlink_or_archive.
            // self.env.flush_all()
            // self.env.invalidate_all()
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('project.mt_task_new')
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_cover_properties(self):
            // """ Cover properties defaults are overridden to keep a consistent look for the slides
            // channels headers across Odoo versions (pre-customization, with purple gradient fitting the
            // homepage images, etc). Furthermore, as adding padding to the cover would not look great,
            // its height is set to fit to content (snippet option to change this also disabled on the view)."""
            // res = super()._default_cover_properties()
            // res.update({
            //     "background_color_class": "o_cc4",
            //     'background_color_style': (
            //         'background-color: rgba(0, 0, 0, 0); '
            //         'background-image: linear-gradient(120deg, #875A7B, #78516F);'
            //     ),
            //     'opacity': '0',
            //     'resize_class': 'cover_auto'
            // })
            // return res
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IRatingMixinable
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

        [ApiModel]
        public async Task<TEntity> DefaultPosSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _default_pos_sequence(self):
            // self.env.cr.execute('SELECT MAX(pos_sequence) FROM %s' % self._table)
            // max_sequence = self.env.cr.fetchone()[0]
            // if max_sequence is None:
            //     return 1
            // return max_sequence + 1
            */
            return default;
        }

        public async Task<TEntity> DefaultResponsibleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _default_responsible_id(self):
            // # Return the current user unless it's OdooBot
            // return not self.env.user._is_superuser() and self.env.uid
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_user_ids(self):
            // return self.env.user.ids if any(key in self.env.context for key in ('default_personal_stage_type_ids', 'default_personal_stage_type_id')) else ()
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_meta(self):
            // res = super()._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.description_sale
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = self.env['website'].image_url(self, 'image_1024')
            // res['default_meta_description'] = self.description_sale
            // return res
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_sequence(self):
            // """ We want new product to be the last (highest seq).
            // Every product should ideally have an unique sequence.
            // Default sequence (10000) should only be used for DB first product.
            // As we don't resequence the whole tree (as `sequence` does), this field
            // might have negative value.
            // """
            // self.env.cr.execute('SELECT MAX(website_sequence) FROM %s' % self._table)
            // max_sequence = self.env.cr.fetchone()[0]
            // if max_sequence is None:
            //     return 10000
            // return max_sequence + 5
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _demo_configure_variants(self):
            // acoustic_bloc_screens = self.env.ref(
            //     'product.product_template_acoustic_bloc_screens', raise_if_not_found=False
            // )
            // if acoustic_bloc_screens:
            //     acoustic_bloc_screens.product_variant_ids[0].default_code = 'FURN_6666'
            //     acoustic_bloc_screens.product_variant_ids[1].default_code = 'FURN_6667'
            //     self.env['ir.model.data']._update_xmlids([{
            //         'xml_id': 'product.product_product_25',
            //         'record': acoustic_bloc_screens.product_variant_ids[1],
            //         'noupdate': True,
            //     }])
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _domain_pricelist_rule_ids(self):
            // return self._base_domain_item_ids()
            */
            return default;
        }

        public async Task<TEntity> EmailLivechatTranscriptInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _email_livechat_transcript(self, email):
            // company = self.env.user.company_id
            // tz = "UTC"
            // # sudo: discuss.channel - access partner's/guest's timezone
            // for customer in self.sudo().livechat_customer_history_ids:
            //     customer_tz = customer.partner_id.tz or customer.guest_id.timezone
            //     if customer_tz:
            //         tz = customer_tz
            //         break
            // render_context = {
            //     "company": company,
            //     "channel": self,
            //     "tz": timezone(tz),
            // }
            // mail_body = self.env['ir.qweb']._render('im_livechat.livechat_email_template', render_context, minimal_qcontext=True)
            // mail_body = self.env['mail.render.mixin']._replace_local_links(mail_body)
            // mail = self.env['mail.mail'].sudo().create({
            //     'subject': _('Conversation with %s', self.livechat_operator_id.user_livechat_username or self.livechat_operator_id.name),
            //     'email_from': company.catchall_formatted or company.email_formatted,
            //     'author_id': self.env.user.partner_id.id,
            //     'email_to': email_split(email)[0],
            //     'body_html': mail_body,
            // })
            // mail.send()
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> EnsureUnusedInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _ensure_unused_in_pos(self):
            // open_pos_sessions = self.env['pos.session'].sudo().search([('state', '!=', 'closed')])
            // used_products = open_pos_sessions.order_ids.filtered(lambda o: o.state == "draft").lines.product_id.product_tmpl_id
            // if used_products & self:
            //     raise UserError(_(
            //         "Hold up! Archiving products while POS sessions are active is like pulling a plate mid-meal.\n"
            //         "Make sure to close all sessions first to avoid any issues.",
            //     ))
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_help(self, **kwargs):
            // self.ensure_one()
            // if self.channel_type == 'channel':
            //     msg = _(
            //         "You are in channel %(bold_start)s#%(channel_name)s%(bold_end)s.",
            //         bold_start=Markup("<b>"),
            //         bold_end=Markup("</b>"),
            //         channel_name=self.name,
            //     )
            // else:
            //     if members := self.channel_member_ids.filtered(lambda m: not m.is_self):
            //         member_names = html_escape(format_list(self.env, [f"%(member_{member.id})s" for member in members])) % {
            //             f"member_{member.id}": member._get_html_link(for_persona=True)
            //             for member in members
            //         }
            //         msg = _(
            //             "You are in a private conversation with %(member_names)s.",
            //             member_names=member_names,
            //         )
            //     else:
            //         msg = _("You are alone in a private conversation.")
            // msg += self._execute_command_help_message_extra()
            // self.env.user._bus_send_transient_message(self, msg)
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py) ---
            // def execute_command_help(self, **kwargs):
            // super().execute_command_help(**kwargs)
            // self.env['mail.bot']._apply_logic(self, kwargs, command="help")
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpMessageExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _execute_command_help_message_extra(self):
            // msg = _(
            //     "%(new_line)s"
            //     "%(new_line)sType %(bold_start)s@username%(bold_end)s to mention someone, and grab their attention."
            //     "%(new_line)sType %(bold_start)s#channel%(bold_end)s to mention a channel."
            //     "%(new_line)sType %(bold_start)s/command%(bold_end)s to execute a command."
            //     "%(new_line)sType %(bold_start)s::shortcut%(bold_end)s to insert a canned response in your message."
            //     "%(new_line)sType %(bold_start)s:emoji:%(bold_end)s to insert an emoji in your message.",
            //     bold_start=Markup("<b>"),
            //     bold_end=Markup("</b>"),
            //     new_line=Markup("<br>"),
            // )
            // return msg
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHistoryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def execute_command_history(self, **kwargs):
            // self._bus_send(
            //     "im_livechat.history_command",
            //     {"id": self.id, "partner_id": self.env.user.partner_id.id},
            // )
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def execute_command_lead(self, **kwargs):
            // key = kwargs['body']
            // lead_command = "/lead"
            // if key.strip() == lead_command:
            //     msg = _(
            //         "Create a new lead with: "
            //         "%(pre_start)s%(lead_command)s %(i_start)slead title%(i_end)s%(pre_end)s",
            //         lead_command=lead_command,
            //         pre_start=Markup("<pre>"),
            //         pre_end=Markup("</pre>"),
            //         i_start=Markup("<i>"),
            //         i_end=Markup("</i>"),
            //     )
            // else:
            //     lead = self._convert_visitor_to_lead(self.env.user.partner_id, key)
            //     msg = _("Created a new lead: %s", lead._get_html_link())
            // self.env.user._bus_send_transient_message(self, msg)
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_leave(self, **kwargs):
            // if self.channel_type in self._types_allowing_unfollow():
            //     self.action_unfollow()
            // else:
            //     self.channel_pin(False)
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandWhoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_who(self, **kwargs):
            // if all_other_members := self.channel_member_ids.filtered(lambda m: not m.is_self):
            //     members = all_other_members[:30]
            //     list_params = [f"%(member_{member.id})s" for member in members]
            //     if len(all_other_members) != len(members):
            //         list_params.append(_("more"))
            //     else:
            //         list_params.append(_("you"))
            //     member_names = html_escape(format_list(self.env, list_params)) % {
            //         f"member_{member.id}": member._get_html_link(for_persona=True)
            //         for member in members
            //     }
            //     msg = _(
            //         "Users in this channel: %(members)s.",
            //         members=member_names,
            //     )
            // else:
            //     msg = _("You are alone in this channel.")
            // self.env.user._bus_send_transient_message(self, msg)
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _filter_add_members(self, raise_on_access=False):
            // allowed = self.filtered(lambda channel: channel.enroll == 'public')
            // if controlled_access := (self - allowed):
            //     allowed += controlled_access._filtered_access('write')
            //     if raise_on_access and allowed != self:
            //         raise AccessError(_('You are not allowed to add members to this course. '
            //                             'Please contact the course responsible or an administrator.'))
            // return allowed
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _filter_combinations_impossible_by_config(self, combination_tuples, ignore_no_variant=False):
            // """ Filter combination_tuples according to the config of attributes on the template
            // 
            // :return: iterator over possible combinations
            // :rtype: generator
            // """
            // self.ensure_one()
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // attribute_lines_active_values = attribute_lines.product_template_value_ids._only_active()
            // if ignore_no_variant:
            //     attribute_lines = attribute_lines._without_no_variant_attributes()
            // attribute_lines_without_multi = attribute_lines.filtered(
            //     lambda l: l.attribute_id.display_type != 'multi')
            // exclusions = self._get_own_attribute_exclusions()
            // for combination_tuple in combination_tuples:
            //     combination = self.env['product.template.attribute.value'].concat(*combination_tuple)
            //     combination_without_multi = combination.filtered(
            //         lambda l: l.attribute_line_id.attribute_id.display_type != 'multi')
            //     if len(combination_without_multi) != len(attribute_lines_without_multi):
            //         # number of attribute values passed is different than the
            //         # configuration of attributes on the template
            //         continue
            //     if attribute_lines_without_multi != combination_without_multi.attribute_line_id:
            //         # combination has different attributes than the ones configured on the template
            //         continue
            //     if not (attribute_lines_active_values >= combination):
            //         # combination has different values than the ones configured on the template
            //         continue
            //     if exclusions:
            //         # exclude if the current value is in an exclusion,
            //         # and the value excluding it is also in the combination
            //         combination_ids = set(combination.ids)
            //         combination_excluded_ids = set(itertools.chain(*[exclusions.get(ptav_id) for ptav_id in combination.ids]))
            //         if combination_ids & combination_excluded_ids:
            //             continue
            //     yield combination
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> FindOrCreateMemberForSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _find_or_create_member_for_self(self):
            // self.ensure_one()
            // domain = [("channel_id", "=", self.id), ("is_self", "=", True)]
            // member = self.env["discuss.channel.member"].search(domain)
            // if member:
            //     return member
            // if not self.env.user._is_public():
            //     return self._add_members(users=self.env.user)
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest:
            //     return self._add_members(guests=guest)
            // return self.env["discuss.channel.member"]
            */
            return default;
        }

        public async Task<TEntity> FindOrCreatePersonaForChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _find_or_create_persona_for_channel(
            //     self,
            //     guest_name,
            //     timezone,
            //     country_code,
            //     create_member_params=None,
            //     post_joined_message=True,
            // ):
            //     """
            //     :param guest_name: name of the persona
            //     :param post_joined_message: whether to post a message to the channel
            //         to notify that the persona joined
            // 
            //     :param dict create_member_params: optional parameters to pass to the
            //         channel member create function.
            // 
            //     :rtype: tuple[partner, guest]
            //     """
            //     self.ensure_one()
            //     guest = self.env["mail.guest"]
            //     member = self.env["discuss.channel.member"].search([("channel_id", "=", self.id), ("is_self", "=", True)])
            //     if member:
            //         return member.partner_id, member.guest_id
            //     if not self.env.user._is_public():
            //         self._add_members(users=self.env.user, post_joined_message=post_joined_message)
            //     else:
            //         guest = guest._get_or_create_guest(
            //             guest_name=guest_name, country_code=country_code, timezone=timezone
            //         )
            //         self.with_context(guest=guest)._add_members(
            //             guests=guest,
            //             create_member_params=create_member_params,
            //             post_joined_message=post_joined_message,
            //         )
            //     return self.env.user.partner_id if not guest else self.env["res.partner"], guest
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_purchase_tax(self, companies):
            // default_supplier_taxes = companies.filtered('account_purchase_tax_id').account_purchase_tax_id
            // if not default_supplier_taxes:
            //     return
            // links = [Command.link(t.id) for t in default_supplier_taxes]
            // for sub_ids in split_every(self.env.cr.IN_MAX, self.ids):
            //     chunk = self.browse(sub_ids)
            //     chunk.write({'supplier_taxes_id': links})
            //     chunk.invalidate_recordset(['supplier_taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_sale_tax(self, companies):
            // default_customer_taxes = companies.filtered('account_sale_tax_id').account_sale_tax_id
            // if not default_customer_taxes:
            //     return
            // links = [Command.link(t.id) for t in default_customer_taxes]
            // for sub_ids in split_every(self.env.cr.IN_MAX, self.ids):
            //     chunk = self.browse(sub_ids)
            //     chunk.write({'taxes_id': links})
            //     chunk.invalidate_recordset(['taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_tax(self, companies):
            // self._force_default_sale_tax(companies)
            // self._force_default_purchase_tax(companies)
            */
            return default;
        }

        public async Task<TEntity> ForwardHumanOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step, object users) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _forward_human_operator(self, chatbot_script_step=None, users=None):
            // """ Add a human operator to the conversation. The conversation with the chatbot (scripted chatbot or ai agent) is stopped
            // the visitor will continue the conversation with a real person.
            // 
            // In case we don't find any operator (e.g: no-one is available) we don't post any messages.
            // The chat with the chatbot will continue normally, which allows to add extra steps when it's the case
            // (e.g: ask for the visitor's email and create a lead).
            // 
            // :param chatbot_script_step: the forward to operator chatbot script step if the forwarding is done through
            // a scripted chatbot (not used if the forwarding is done through an AI Agent).
            // :param users: recordset of candidate operators, if not provided the currently available
            //     users of the livechat channel are used as candidates instead.
            // """
            // 
            // human_operator = False
            // posted_message = self.env['mail.message']
            // if chatbot_script_step is None:
            //     chatbot_script_step = self.env['chatbot.script.step']
            // 
            // if self.livechat_channel_id:
            //     human_operator = self._get_human_operator(users, chatbot_script_step)
            // 
            // # handle edge case where we found yourself as available operator -> don't do anything
            // # it will act as if no-one is available (which is fine)
            // if human_operator and human_operator != self.env.user:
            // 
            //     # first post the message of the step (if we have one)
            //     posted_message = self._post_current_chatbot_step_message(chatbot_script_step)
            // 
            //     # sudo - discuss.channel: let the chat bot proceed to the forward step (change channel operator, add human operator
            //     # as member, remove bot from channel, rename channel and finally broadcast the channel to the new operator).
            //     channel_sudo = self.sudo()
            //     bot_partner_id = channel_sudo.channel_member_ids.filtered(lambda m: m.livechat_member_type == "bot").partner_id
            // 
            //     # next, add the human_operator to the channel and post a "Operator invited to the channel" notification
            //     create_member_params = {'livechat_member_type': 'agent'}
            //     if chatbot_script_step.operator_expertise_ids:
            //         create_member_params['agent_expertise_ids'] = chatbot_script_step.operator_expertise_ids.ids
            //         channel_sudo.livechat_expertise_ids |= chatbot_script_step.operator_expertise_ids
            //     channel_sudo._add_new_members_to_channel(
            //         create_member_params=create_member_params,
            //         inviting_partner=bot_partner_id,
            //         users=human_operator,
            //     )
            //     channel_sudo._action_unfollow(partner=bot_partner_id, post_leave_message=False)
            // 
            //     # finally, rename the channel to include the operator's name
            //     channel_sudo._update_forwarded_channel_data(
            //         livechat_failure="no_answer",
            //         livechat_operator_id=human_operator.partner_id,
            //         operator_name=human_operator.livechat_username if human_operator.livechat_username else human_operator.name,
            //     )
            //     channel_sudo._add_next_step_message_to_store(chatbot_script_step)
            //     channel_sudo._broadcast(human_operator.partner_id.ids)
            //     self.channel_pin(pinned=True)
            // else:
            //     # sudo: discuss.channel - visitor tried getting operator, outcome must be updated
            //     self.sudo().livechat_failure = "no_agent"
            // 
            // return posted_message
            */
            return default;
        }

        public async Task<TEntity> GcBotOnlyOngoingSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _gc_bot_only_ongoing_sessions(self):
            // """Garbage collect bot-only livechat sessions with no activity for over 1 day."""
            // stale_sessions = self.search([
            //     ("channel_type", "=", "livechat"),
            //     ("livechat_end_dt", "=", False),
            //     ("last_interest_dt", "<=", "-1d"),
            //     ("livechat_agent_partner_ids", "=", False),
            // ])
            // stale_sessions.livechat_end_dt = fields.Datetime.now()
            */
            return default;
        }

        public async Task<TEntity> GcEmptyLivechatSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _gc_empty_livechat_sessions(self):
            // hours = 1  # never remove empty session created within the last hour
            // self.env.cr.execute("""
            //     SELECT id as id
            //     FROM discuss_channel C
            //     WHERE NOT EXISTS (
            //         SELECT 1
            //         FROM mail_message M
            //         WHERE M.res_id = C.id AND m.model = 'discuss.channel'
            //     ) AND C.channel_type = 'livechat' AND livechat_channel_id IS NOT NULL AND
            //         COALESCE(write_date, create_date, (now() at time zone 'UTC'))::timestamp
            //         < ((now() at time zone 'UTC') - interval %s)""", ("%s hours" % hours,))
            // empty_channel_ids = [item['id'] for item in self.env.cr.dictfetchall()]
            // self.browse(empty_channel_ids).unlink()
            */
            return default;
        }

        public async Task<TEntity> GenerateAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _generate_avatar(self):
            // if self.channel_type not in ('channel', 'group'):
            //     return False
            // avatar = group_avatar if self.channel_type == 'group' else channel_avatar
            // bgcolor = get_hsl_from_seed(self.uuid)
            // avatar = avatar.replace('fill="#875a7b"', f'fill="{bgcolor}"')
            // return base64.b64encode(avatar.encode())
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateRandomTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _generate_random_token(self):
            // # Built to be shared on invitation link. It uses non-ambiguous characters and it is of a
            // # reasonable length: enough to avoid brute force, but short enough to be shareable easily.
            // # This token should not contain "mail.guest"._cookie_separator value.
            // return ''.join(choice('abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ23456789') for _i in range(10))
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to website if it is published. """
            // self.ensure_one()
            // if force_website or (self.website_published and self.env.user.share):
            //     return {
            //         "type": "ir.actions.act_url",
            //         "url": self.website_url,
            //         "target": "self",
            //         "target_type": "public",
            //     }
            // return super()._get_access_action(access_uid=access_uid, force_website=force_website)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to website if it is published. """
            // self.ensure_one()
            // if force_website or self.website_published:
            //     return {
            //         "type": "ir.actions.act_url",
            //         "url": self.website_url,
            //         "target": "self",
            //         "target_type": "public",
            //     }
            // return super()._get_access_action(access_uid=access_uid, force_website=force_website)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_action_view_related_putaway_rules(self, domain):
            // return {
            //     'name': _('Putaway Rules'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.putaway.rule',
            //     'view_mode': 'list',
            //     'domain': domain,
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, *, uom=None, **kwargs
            // ):
            //     """Return additional data about the specified product.
            // 
            //     This is a hook meant to append module-specific data in overriding modules.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param uom.uom uom: The uom to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to overrides.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     return {}
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, *, uom=None, **kwargs
            // ):
            //     """Override of `website_sale` to append stock data.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param uom.uom uom: The uom to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to overrides.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     data = super()._get_additional_configurator_data(
            //         product_or_template, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if (website := ir_http.get_request_website()) and product_or_template.is_product_variant:
            //         max_quantity = product_or_template._get_max_quantity(website, request.cart, **kwargs)
            //         if max_quantity is not None:
            //             if uom:
            //                 max_quantity = product_or_template.uom_id._compute_quantity(max_quantity, to_unit=uom)
            //             data['free_qty'] = max_quantity
            //     return data
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object uom, object date, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, uom, date, website):
            // """Compute additional combination info, based on given parameters.
            // 
            // :param product_or_template: `product.product` or `product.template` record
            //     as variant values must take precedence over template values (when we have a variant)
            // :param float quantity: requested quantity
            // :param uom: `uom.uom` record
            // :param date date: today's date, avoids useless calls to today/context_today and harmonize
            //     behavior
            // :param website: `website` record holding the current website of the request (if any),
            //     or the contextual website (tests, ...)
            // :returns: additional product/template information
            // :rtype: dict
            // """
            // pricelist = request.pricelist.with_context(self.env.context)
            // currency = website.currency_id.with_context(self.env.context)
            // 
            // # Pricelist price doesn't have to be converted
            // pricelist_price, pricelist_rule_id = pricelist._get_product_price_rule(
            //     product=product_or_template,
            //     quantity=quantity,
            //     uom=uom,
            //     target_currency=currency,
            // )
            // 
            // price_before_discount = pricelist_price
            // pricelist_item = self.env['product.pricelist.item'].browse(pricelist_rule_id)
            // if pricelist_item._show_discount_on_shop():
            //     price_before_discount = pricelist_item._compute_price_before_discount(
            //         product=product_or_template,
            //         quantity=quantity or 1.0,
            //         date=date,
            //         uom=uom,
            //         currency=currency,
            //     )
            // 
            // has_discounted_price = currency.compare_amounts(price_before_discount, pricelist_price) == 1
            // combination_info = {
            //     'list_price': max(pricelist_price, price_before_discount),
            //     'price': pricelist_price,
            //     'has_discounted_price': has_discounted_price,
            //     'discount_start_date': pricelist_item.date_start,
            //     'discount_end_date': pricelist_item.date_end,
            // }
            // 
            // if (
            //     not has_discounted_price
            //     and product_or_template.compare_list_price
            //     and self.env['res.groups']._is_feature_enabled(
            //         'website_sale.group_product_price_comparison'
            //     )
            // ):
            //     # TODO VCR comparison price only depends on the product template, but is shown/hidden
            //     # depending on product price, should be removed from combination info in the future
            //     combination_info['compare_list_price'] = product_or_template.currency_id._convert(
            //         from_amount=product_or_template.compare_list_price,
            //         to_currency=currency,
            //         company=self.env.company,
            //         date=date,
            //         round=False,
            //     )
            // 
            // # Apply taxes
            // product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            // taxes = self.env['account.tax']
            // if product_taxes:
            //     taxes = request.fiscal_position.map_tax(product_taxes)
            //     # We do not apply taxes on the compare_list_price value because it's meant to be
            //     # a strict value displayed as is.
            //     for price_key in ('price', 'list_price'):
            //         combination_info[price_key] = self._apply_taxes_to_price(
            //             combination_info[price_key],
            //             currency,
            //             product_taxes,
            //             taxes,
            //             product_or_template,
            //             website=website,
            //         )
            // 
            // combination_info.update({
            //     'prevent_zero_price_sale': website.prevent_zero_price_sale and float_is_zero(
            //         combination_info['price'],
            //         precision_rounding=currency.rounding,
            //     ),
            // 
            //     # additional info to simplify overrides
            //     'currency': currency,  # displayed currency
            //     'date': date,
            //     'product_taxes': product_taxes,  # taxes before fpos mapping
            //     'taxes': taxes,  # taxes after fpos mapping
            // })
            // 
            // if self.env['res.groups']._is_feature_enabled('website_sale.group_show_uom_price'):
            //     price_per_product_uom = uom._compute_price(
            //         price=combination_info['price'], to_unit=self.uom_id
            //     )
            //     combination_info.update({
            //         'base_unit_name': product_or_template.base_unit_name,
            //         'base_unit_price': product_or_template._get_base_unit_price(price_per_product_uom),
            //     })
            // 
            // if combination_info['prevent_zero_price_sale']:
            //     # If price is zero and prevent_zero_price_sale is enabled we don't want to send any
            //     # price information regarding the product
            //     combination_info['compare_list_price'] = 0
            // 
            // return combination_info
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_all_subtasks(self):
            // return self.browse(set.union(set(), *self._get_subtask_ids_per_task_id().values()))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_allowed_access_params(self):
            // return super()._get_allowed_access_params() | {'project_sharing_id'}
            */
            return default;
        }

        public async Task<TEntity> GetAllowedChannelMemberCreateParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_allowed_channel_member_create_params(self):
            // return super()._get_allowed_channel_member_create_params() + [
            //     "chatbot_script_id",
            //     "livechat_member_type",
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessageParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_message_params(self):
            // return super()._get_allowed_message_params() | {"special_mentions", "parent_id"}
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_message_partner_ids(self, partner_ids):
            // """Ensure only partners having access to the channel can be mentioned."""
            // partners = self.env["res.partner"].browse(partner_ids)
            // if self.channel_type == "channel":
            //     if self.group_public_id:
            //         partners = partners.filtered(
            //             lambda p: p.user_ids.all_group_ids & self.group_public_id,
            //         )
            // else:
            //     partners = (
            //         self.env["discuss.channel.member"]
            //         .search_fetch(
            //             [("channel_id", "=", self.id), ("partner_id", "in", partner_ids)],
            //             ["partner_id"],
            //         )
            //         .partner_id
            //     )
            // return partners.ids
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_alternative_product_filter(self):
            // return self.env.ref('website_sale.dynamic_filter_cross_selling_alternative_products').id
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = super(ProductTemplate, self)._get_asset_accounts()
            // if self.asset_category_id:
            //     res['stock_input'] = self.property_account_expense_id
            // if self.deferred_revenue_category_id:
            //     res['stock_output'] = self.property_account_income_id
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_attachments_search_domain(self):
            // self.ensure_one()
            // return [('res_id', '=', self.id), ('res_model', '=', 'project.task')]
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attribute_exclusions(
            //     self, parent_combination=None, parent_name=None, combination_ids=None
            // ):
            //     """Return the list of attribute exclusions of a product.
            // 
            //     :param parent_combination: the combination from which
            //         `self` is an optional or accessory product. Indeed exclusions
            //         rules on one product can concern another product.
            //     :type parent_combination: recordset `product.template.attribute.value`
            //     :param parent_name: the name of the parent product combination.
            //     :type parent_name: str
            //     :param list combination_ids: The combination of the product, as a
            //         list of `product.template.attribute.value` ids.
            // 
            //     :return: dict of exclusions
            //         - exclusions: from this product itself
            //         - archived_combinations: list of archived combinations
            //         - parent_combination: ids of the given parent_combination
            //         - parent_exclusions: from the parent_combination
            //        - parent_product_name: the name of the parent product if any, used in the interface
            //            to explain why some combinations are not available.
            //            (e.g: Not available with Customizable Desk (Legs: Steel))
            //        - mapped_attribute_names: the name of every attribute values based on their id,
            //            used to explain in the interface why that combination is not available
            //            (e.g: Not available with Color: Black)
            //     """
            //     self.ensure_one()
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     archived_products = self.with_context(active_test=False).product_variant_ids.filtered(lambda l: not l.active)
            //     active_combinations = set(tuple(product.product_template_attribute_value_ids.ids) for product in self.product_variant_ids)
            //     return {
            //         'exclusions': self._complete_inverse_exclusions(
            //             self._get_own_attribute_exclusions(combination_ids=combination_ids)
            //         ),
            //         'archived_combinations': list(set(
            //             tuple(product.product_template_attribute_value_ids.ids)
            //             for product in archived_products
            //             if product.product_template_attribute_value_ids and all(
            //                 ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //                 for ptav in product.product_template_attribute_value_ids
            //             )
            //         ) - active_combinations),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination),
            //         'parent_combination': parent_combination.ids,
            //         'parent_product_name': parent_name,
            //         'mapped_attribute_names': self._get_mapped_attribute_names(parent_combination),
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetAttributeValueDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_value_dict) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_attribute_value_domain(self, attribute_value_dict):
            // return [
            //     [('attribute_line_ids.value_ids', 'in', attribute_value_ids)]
            //     for attribute_value_ids in attribute_value_dict.values()
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attributes_extra_price(self):
            // self.ensure_one()
            // 
            // return sum(self.env.context.get('current_attributes_price_extra', []))
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_available_uoms(self):
            // self.ensure_one()
            // return self.uom_id | self.uom_ids
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('mrp.menu_mrp_root').id]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('purchase.menu_purchase_root').id]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('sale.sale_menu_root').id]
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_base_unit_price(self, price):
            // self.ensure_one()
            // return self.base_unit_count and price / self.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> GetCallNotificationTagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_call_notification_tag(self):
            // self.ensure_one()
            // return f"call_{self.id}"
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_cannot_start_with_patterns(self):
            // return [r'(?![#!@\s])']
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_categorized_slides(self, base_domain, order, force_void=True, limit=False, offset=False):
            // """ Return an ordered structure of slides by categories within a given
            // base_domain that must fulfill slides. As a course structure is based on
            // its slides sequences, uncategorized slides must have the lowest sequences.
            // 
            // Example
            //   * category 1 (sequence 1), category 2 (sequence 3)
            //   * slide 1 (sequence 0), slide 2 (sequence 2)
            //   * course structure is: slide 1, category 1, slide 2, category 2
            //     * slide 1 is uncategorized,
            //     * category 1 has one slide : Slide 2
            //     * category 2 is empty.
            // 
            // Backend and frontend ordering is the same, uncategorized first. It
            // eases resequencing based on DOM / displayed order, notably when
            // drag n drop is involved. """
            // self.ensure_one()
            // all_categories = self.env['slide.slide'].sudo().search([('channel_id', '=', self.id), ('is_category', '=', True)])
            // all_slides = self.env['slide.slide'].sudo().search(base_domain, order=order)
            // category_data = []
            // 
            // # Prepare all categories by natural order
            // for category in all_categories:
            //     category_slides = all_slides.filtered(lambda slide: slide.category_id == category)
            //     if not category_slides and not force_void:
            //         continue
            //     category_data.append({
            //         'category': category, 'id': category.id,
            //         'name': category.name, 'slug_name': self.env['ir.http']._slug(category),
            //         'total_slides': len(category_slides),
            //         'slides': category_slides[(offset or 0):(limit + offset or len(category_slides))],
            //     })
            // 
            // # Add uncategorized slides in first position
            // uncategorized_slides = all_slides.filtered(lambda slide: not slide.category_id)
            // if uncategorized_slides or force_void:
            //     category_data.insert(0, {
            //         'category': False, 'id': False,
            //         'name': _('Uncategorized'), 'slug_name': _('Uncategorized'),
            //         'total_slides': len(uncategorized_slides),
            //         'slides': uncategorized_slides[(offset or 0):(offset + limit or len(uncategorized_slides))],
            //     })
            // 
            // return category_data
            */
            return default;
        }

        public async Task<TEntity> GetChannelHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_channel_history(self):
            // """
            // Converting message body back to plaintext for correct data formatting in HTML field.
            // """
            // self.ensure_one()
            // parts = []
            // previous_message_author = None
            // # sudo - mail.message: getting empty messages to exclude them is allowed.
            // for message in (self.message_ids - self.message_ids.sudo()._filter_empty()).sorted("id"):
            //     # sudo - res.partner: accessing livechat username or name is allowed to visitor
            //     message_author = message.author_id.sudo() or message.author_guest_id
            //     if previous_message_author != message_author:
            //         parts.append(
            //             Markup("<br/><strong>%s:</strong><br/>")
            //             % (
            //                 (message_author.user_livechat_username if message_author._name == "res.partner" else None)
            //                 or message_author.name
            //             ),
            //         )
            //     if not tools.is_html_empty(message.body):
            //         parts.append(Markup("%s<br/>") % html2plaintext(message.body))
            //         previous_message_author = message_author
            //     for attachment in message.attachment_ids:
            //         previous_message_author = message_author
            //         # sudo - ir.attachment: public user can read attachment metadata
            //         parts.append(Markup("%s<br/>") % self._attachment_to_html(attachment.sudo()))
            // return Markup("").join(parts)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChannelsAsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_channels_as_member(self):
            // # 2 different queries because the 2 sub-queries together with OR are less efficient
            // member_domain = [("channel_type", "in", ("channel", "group")), ("is_member", "=", True)]
            // pinned_member_domain = [
            //         ("channel_type", "not in", ("channel", "group")),
            //         ("channel_member_ids", "any", [("is_self", "=", True), ("is_pinned", "=", True)]),
            //     ]
            // channels = self.env["discuss.channel"].search(member_domain)
            // channels += self.env["discuss.channel"].search(pinned_member_domain)
            // return channels
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combination(self, combination):
            // """See `_get_closest_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_closest_possible_combinations(combination), self.env['product.template.attribute.value'])
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combinations(self, combination):
            // """Generator returning the possible combinations that are the closest to
            // the given combination.
            // 
            // If the given combination is incomplete, try to complete it.
            // 
            // If the given combination is invalid, try to remove values from it before
            // completing it.
            // 
            // :param combination: the values to include if they are possible
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :return: the possible combinations that are including as much
            //     elements as possible from the given combination.
            // :rtype: generator of recordset of product.template.attribute.value
            // """
            // while True:
            //     res = self._get_possible_combinations(necessary_values=combination)
            //     try:
            //         # If there is at least one result for the given combination
            //         # we consider that combination set, and we yield all the
            //         # possible combinations for it.
            //         yield(next(res))
            //         for cur in res:
            //             yield(cur)
            //         return _("There are no remaining closest combination.")
            //     except StopIteration:
            //         # There are no results for the given combination, we try to
            //         # progressively remove values from it.
            //         if not combination:
            //             return _("There are no possible combination.")
            //         combination = combination[:-1]
            */
            return default;
        }

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, Guid uom_id, object only_template) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_combination_info(
            //     self, combination=False, product_id=False, add_qty=1.0, uom_id=False, only_template=False,
            // ):
            //     """Return info about a given combination.
            // 
            //     Note: this method does not take into account whether the combination is
            //     actually possible.
            // 
            //     :param combination: recordset of `product.template.attribute.value`
            // 
            //     :param int product_id: `product.product` id. If no `combination`
            //         is set, the method will try to load the variant `product_id` if
            //         it exists instead of finding a variant based on the combination.
            // 
            //         If there is no combination, that means we definitely want a
            //         variant and not something that will have no_variant set.
            // 
            //     :param float add_qty: the quantity for which to get the info,
            //         indeed some pricelist rules might depend on it.
            //     :param int|None uom_id: the uom for which to get the info, as an `uom.uom` id.
            // 
            //     :param only_template: boolean, if set to True, get the info for the
            //         template only: ignore combination and don't try to find variant
            // 
            //     :return: dict with product/combination info:
            // 
            //         - product_id: the variant id matching the combination (if it exists)
            // 
            //         - product_template_id: the current template id
            // 
            //         - display_name: the name of the combination
            // 
            //         - price: the computed price of the combination, take the catalog
            //             price if no pricelist is given
            // 
            //         - price_extra: the computed extra price of the combination
            // 
            //         - list_price: the catalog price of the combination, but this is
            //             not the "real" list_price, it has price_extra included (so
            //             it's actually more closely related to `lst_price`), and it
            //             is converted to the pricelist currency (if given)
            // 
            //         - has_discounted_price: True if the pricelist discount policy says
            //             the price does not include the discount and there is actually a
            //             discount applied (price < list_price), else False
            //     """
            //     self.ensure_one()
            // 
            //     combination = combination or self.env['product.template.attribute.value']
            //     website = request.website.with_context(self.env.context)
            //     uom = self.env['uom.uom'].browse(uom_id) or self.uom_id
            // 
            //     if not product_id and not combination and not only_template:
            //         combination = self._get_first_possible_combination()
            // 
            //     if only_template:
            //         product = self.env['product.product']
            //     elif product_id:
            //         product = self.env['product.product'].browse(product_id)
            //         if (combination - product.product_template_attribute_value_ids):
            //             # If the combination is not fully represented in the given product
            //             #   make sure to fetch the right product for the given combination
            //             product = self._get_variant_for_combination(combination)
            //     else:
            //         product = self._get_variant_for_combination(combination)
            // 
            //     product_or_template = product or self
            //     combination = combination or product.product_template_attribute_value_ids
            // 
            //     display_name = product_or_template.with_context(display_default_code=False).display_name
            //     if not product:
            //         combination_name = combination._get_combination_name()
            //         if combination_name:
            //             display_name = f"{display_name} ({combination_name})"
            // 
            //     price_context = product_or_template._get_product_price_context(combination)
            //     product_or_template = product_or_template.with_context(**price_context)
            // 
            //     combination_info = {
            //         'combination': combination,
            //         'product_id': product.id,
            //         'product_template_id': self.id,
            //         'display_name': display_name,
            //         'is_combination_possible': self._is_combination_possible(combination=combination),
            // 
            //         **self._get_additionnal_combination_info(
            //             product_or_template=product_or_template,
            //             quantity=add_qty or 1.0,
            //             uom=uom,
            //             date=fields.Date.context_today(self),
            //             website=website,
            //         )
            //     }
            // 
            //     if website.google_analytics_key:
            //         combination_info['product_tracking_info'] = self._get_google_analytics_data(
            //             product,
            //             combination_info,
            //         )
            // 
            //     if (
            //         product_or_template.type == 'combo'
            //         and website.show_line_subtotals_tax_selection == 'tax_included'
            //         and not all(
            //             tax.price_include
            //             for tax
            //             in product_or_template.sudo().combo_ids.combo_item_ids.product_id.taxes_id
            //         )
            //     ):
            //         combination_info['tax_disclaimer'] = _(
            //             "Final price may vary based on selection. Tax will be calculated at checkout."
            //         )
            // 
            //     return combination_info
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_configurator_display_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to apply taxes.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's display price (and the applied pricelist rule)
            //     """
            //     price, pricelist_rule_id = super()._get_configurator_display_price(
            //         product_or_template, quantity, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if website := ir_http.get_request_website():
            //         product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(
            //             self.env.company
            //         )
            //         if product_taxes:
            //             taxes = request.fiscal_position.map_tax(product_taxes)
            //             return self._apply_taxes_to_price(
            //                 price, currency, product_taxes, taxes, product_or_template, website=website
            //             ), pricelist_rule_id
            //     return price, pricelist_rule_id
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_configurator_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Return the specified product's price, to be used by the product and combo configurators.
            // 
            //     This is a hook meant to customize the price computation in overriding modules.
            // 
            //     This hook has been extracted from `_get_configurator_display_price` because the price
            //     computation can be overridden in 2 ways:
            // 
            //     - Either by transforming super's price (e.g. in `website_sale`, we apply taxes to the
            //       price),
            //     - Or by computing a different price (e.g. in `sale_subscription`, we ignore super when
            //       computing subscription prices).
            //     In some cases, the order of the overrides matters, which is why we need 2 separate methods
            //     (e.g. in `website_sale_subscription`, we must compute the subscription price before applying
            //     taxes).
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `_get_product_price`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's price (and the applied pricelist rule)
            //     """
            //     return pricelist._get_product_price_rule(
            //         product_or_template, quantity=quantity, currency=currency, date=date, **kwargs
            //     )
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_contextual_price(self, product=None):
            // return self._get_contextual_price(product=product)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_contextual_price(self, product=None):
            // self.ensure_one()
            // pricelist = self._get_contextual_pricelist()
            // quantity = self.env.context.get('quantity', 1.0)
            // uom = self.env['uom.uom'].browse(self.env.context.get('uom'))
            // date = self.env.context.get('date')
            // return pricelist._get_product_price(product or self, quantity, uom=uom, date=date)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Override to fallback on website current pricelist """
            // pricelist = super()._get_contextual_pricelist()
            // if request and request.is_frontend and not pricelist:
            //     return request.pricelist
            // return pricelist
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_default_enroll_msg(self):
            // return _('Contact Responsible')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IRatingMixinable
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
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_uom_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_earned_karma(self, partner_ids):
            // """ Compute the number of karma earned by partners on a channel
            // Warning: this count will not be accurate if the configuration has been
            // modified after the completion of a course!
            // """
            // total_karma = defaultdict(list)
            // 
            // slide_completed = self.env['slide.slide.partner'].sudo().search([
            //     ('partner_id', 'in', partner_ids),
            //     ('channel_id', 'in', self.ids),
            //     ('completed', '=', True),
            //     ('quiz_attempts_count', '>', 0)
            // ])
            // for partner_slide in slide_completed:
            //     slide = partner_slide.slide_id
            //     if not slide.question_ids:
            //         continue
            //     gains = [
            //         slide.quiz_first_attempt_reward,
            //         slide.quiz_second_attempt_reward,
            //         slide.quiz_third_attempt_reward,
            //         slide.quiz_fourth_attempt_reward,
            //     ]
            //     attempts = min(partner_slide.quiz_attempts_count, len(gains))
            //     total_karma[partner_slide.partner_id.id].append({
            //         'karma': gains[attempts - 1],
            //         'channel_id': slide.channel_id,
            //     })
            // 
            // channel_completed = self.env['slide.channel.partner'].sudo().search([
            //     ('partner_id', 'in', partner_ids),
            //     ('channel_id', 'in', self.ids),
            //     ('member_status', '=', 'completed')
            // ])
            // for partner_channel in channel_completed:
            //     channel = partner_channel.channel_id
            //     total_karma[partner_channel.partner_id.id].append({
            //         'karma': channel.karma_gen_channel_finish,
            //         'channel_id': channel,
            //     })
            // 
            // return total_karma
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_combination(self, parent_combination=None, necessary_values=None):
            // """See `_get_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_possible_combinations(parent_combination, necessary_values), self.env['product.template.attribute.value'])
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_variant_id(self):
            // """See `_create_first_product_variant`. This method returns an ID
            // so it can be cached."""
            // self.ensure_one()
            // return self._create_first_product_variant().id
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service(self, invoice_policy, service_type):
            // general_to_service = self._get_general_to_service_map()
            // return general_to_service.get((invoice_policy, service_type), False)
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service_map(self):
            // return {v: k for k, v in self._get_service_to_general_map().items()}
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_google_analytics_data(self, product, combination_info):
            // self.ensure_one()
            // return {
            //     'item_id': product.barcode or product.id,
            //     'item_name': combination_info['display_name'],
            //     'item_category': self.categ_id.name,
            //     'currency': combination_info['currency'].name,
            //     'price': combination_info['list_price'],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetHumanOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_human_operator(self, users, chatbot_script_step):
            // operator_params = {
            //     'lang': self.env.context.get("lang"),
            //     'country_id': self.country_id.id,
            //     'users': users
            // }
            // if chatbot_script_step:
            //     operator_params['expertises'] = chatbot_script_step.operator_expertise_ids
            // # sudo: res.users - visitor can access operator of their channel
            // human_operator = self.livechat_channel_id.sudo()._get_operator(**operator_params)
            // return human_operator
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_image_holder(self):
            // """Returns the holder of the image to use as default representation.
            // If the product template has an image it is the product template,
            // otherwise if the product has variants it is the first variant
            // 
            // :return: this product template or the first product variant
            // :rtype: recordset of 'product.template' or recordset of 'product.product'
            // """
            // self.ensure_one()
            // if self.image_128:
            //     return self
            // variant = self.env['product.product'].browse(self._get_first_possible_variant_id())
            // # if the variant has no image anyway, spare some queries by using template
            // return variant if variant.image_variant_128 else self
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_images(self):
            // """Return a list of records implementing `image.mixin` to
            // display on the carousel on the website for this template.
            // 
            // This returns a list and not a recordset because the records might be
            // from different models (template and image).
            // 
            // It contains in this order: the main image of the template and the
            // Template Extra Images.
            // """
            // self.ensure_one()
            // return [self] + list(self.product_template_image_ids)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Tasks'),
            //     'template': '/project/static/xls/tasks_import_template.xlsx',
            // }]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_incompatible_types(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetLastMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_last_messages(self):
            // """ Return the last message for each of the given channels."""
            // if not self.ids:
            //     return self.env["mail.message"]
            // self.env['mail.message'].flush_model()
            // self.env.cr.execute(
            //     """
            //            SELECT last_message_id
            //              FROM discuss_channel
            // LEFT JOIN LATERAL (
            //                       SELECT id
            //                         FROM mail_message
            //                        WHERE mail_message.model = 'discuss.channel'
            //                          AND mail_message.res_id = discuss_channel.id
            //                     ORDER BY id DESC
            //                        LIMIT 1
            //                   ) AS t(last_message_id) ON TRUE
            //             WHERE discuss_channel.id IN %(ids)s
            //          GROUP BY discuss_channel.id, t.last_message_id
            //          ORDER BY discuss_channel.id
            //     """,
            //     {"ids": tuple(self.ids)},
            // )
            // return self.env["mail.message"].browse([mid for (mid,) in self.env.cr.fetchall() if mid])
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `length`, 'width', 'height' field.
            // By default, we considerer that length are expressed in millimeters. Users can configure
            // to express them in feet by adding an ir.config_parameter record with "product.volume_in_cubic_feet"
            // as key and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_foot')
            // else:
            //     return self.env.ref('uom.product_uom_millimeter')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_name_from_ir_config_parameter(self):
            // return self._get_length_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product """
            // self.ensure_one()
            // if not self.taxes_id:
            //     return super()._get_list_price(price)
            // computed_price = self.taxes_id.compute_all(price, self.currency_id)
            // total_included = computed_price["total_included"]
            // 
            // if price == total_included:
            //     # Tax is configured as price included
            //     return total_included
            // # calculate base from tax
            // included_computed_price = self.taxes_id.with_context(force_price_include=True).compute_all(price, self.currency_id)
            // return included_computed_price['total_excluded']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product.
            // To be overridden in accounting module."""
            // self.ensure_one()
            // return price
            */
            return default;
        }

        public async Task<TEntity> GetLivechatSessionFieldsToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_livechat_session_fields_to_store(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_mapped_attribute_names(self, parent_combination=None):
            // """ The name of every attribute values based on their id,
            // used to explain in the interface why that combination is not available
            // (e.g: Not available with Color: Black).
            // 
            // It contains both attribute value names from this product and from
            // the parent combination if provided.
            // """
            // self.ensure_one()
            // all_product_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // if parent_combination:
            //     all_product_attribute_values |= parent_combination
            // 
            // return {
            //     attribute_value.id: attribute_value.display_name
            //     for attribute_value in all_product_attribute_values
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetNotifyValidParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_notify_valid_parameters(self):
            // return super()._get_notify_valid_parameters() | {"silent"}
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_onchange_service_policy_updates(self, service_tracking, service_policy, project_id, project_template_id):
            // vals = {}
            // if service_tracking != 'no' and service_policy == 'delivered_timesheet':
            //     if project_id and not project_id.allow_timesheets:
            //         vals['project_id'] = False
            //     elif project_template_id and not project_template_id.allow_timesheets:
            //         vals['project_template_id'] = False
            // return vals
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrCreateChatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object pin) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_or_create_chat(self, partners_to, pin=True):
            // """ Get the canonical private channel between some partners, create it if needed.
            //     To reuse an old channel (conversation), this one must be private, and contains
            //     only the given partners.
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param pin : True if getting the channel should pin it for the current user
            //     :returns: channel_info of the created or existing channel
            //     :rtype: dict
            // """
            // partners = (
            //     self.env["res.partner"]
            //     .with_context(active_test=False)
            //     .search([("id", "in", partners_to)])
            // ) | self.env.user.partner_id
            // if len(partners) > 2:
            //     raise UserError(_("A chat should not be created with more than 2 persons. Create a group instead."))
            // # determine type according to the number of partner in the channel
            // self.flush_model()
            // self.env['discuss.channel.member'].flush_model()
            // self.env.cr.execute(
            //     SQL(
            //         """
            //     SELECT M.channel_id
            //     FROM discuss_channel C, discuss_channel_member M
            //     WHERE M.channel_id = C.id
            //         AND M.partner_id IN %(partner_ids)s
            //         AND C.channel_type LIKE 'chat'
            //         AND NOT EXISTS (
            //             SELECT 1
            //             FROM discuss_channel_member M2
            //             WHERE M2.channel_id = C.id
            //                 AND M2.partner_id NOT IN %(partner_ids)s
            //         )
            //     GROUP BY M.channel_id
            //     HAVING ARRAY_AGG(DISTINCT M.partner_id ORDER BY M.partner_id) = %(sorted_partner_ids)s
            //     LIMIT 1
            //         """,
            //         partner_ids=tuple(partners.ids),
            //         sorted_partner_ids=sorted(partners.ids),
            //     )
            // )
            // result = self.env.cr.dictfetchall()
            // # use the same "now" in the whole function to ensure unpin_dt > last_interest_dt
            // now = fields.Datetime.now()
            // last_interest_dt = now - timedelta(seconds=1)
            // if result:
            //     # get the existing channel between the given partners
            //     channel = self.browse(result[0].get('channel_id'))
            //     # pin or open the channel for the current partner
            //     if pin:
            //         channel.self_member_id.write(
            //             {"last_interest_dt": last_interest_dt, "unpin_dt": False}
            //         )
            //     channel._broadcast(self.env.user.partner_id.ids)
            // else:
            //     # create a new one
            //     channel = self.create(
            //         {
            //             "channel_member_ids": [
            //                 Command.create(
            //                     {
            //                         "last_interest_dt": last_interest_dt,
            //                         "partner_id": partner.id,
            //                         # only pin for the current user, so the chat does not show up for the correspondent until a message has been sent
            //                         "unpin_dt": False if partner == self.env.user.partner_id else now,
            //                     }
            //                 )
            //                 for partner in partners
            //             ],
            //             "channel_type": "chat",
            //             "last_interest_dt": last_interest_dt,
            //             "name": ", ".join(partners.mapped("name")),
            //         }
            //     )
            //     channel._broadcast(partners.ids)
            // return channel
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_own_attribute_exclusions(self, combination_ids=None):
            // """Get exclusions coming from the current template.
            // 
            // :param list combination_ids: The combination of the product, as
            //     a list of `product.template.attribute.value` ids.
            // Dictionnary, each product template attribute value is a key, and for each of them
            // the value is an array with the other ptav that they exclude (empty if no exclusion).
            // """
            // self.ensure_one()
            // product_template_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // return {
            //     ptav.id: [
            //         value.id
            //         for filter_line in ptav.exclude_for.filtered(
            //             lambda filter_line: filter_line.product_tmpl_id == self
            //         ) for value in filter_line.value_ids if value.ptav_active
            //     ]
            //     for ptav in product_template_attribute_values if (
            //         ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //     )
            // }
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_parent_attribute_exclusions(self, parent_combination):
            // """Get exclusions coming from the parent combination.
            // 
            // Dictionnary, each parent's ptav is a key, and for each of them the value is
            // an array with the other ptav that are excluded because of the parent.
            // """
            // self.ensure_one()
            // if not parent_combination:
            //     return {}
            // 
            // result = {}
            // for product_attribute_value in parent_combination:
            //     for filter_line in product_attribute_value.exclude_for.filtered(
            //         lambda filter_line: filter_line.product_tmpl_id == self
            //     ):
            //         # Some exclusions don't have attribute value. This means that the template is not
            //         # compatible with the parent combination. If such an exclusion is found, it means that all
            //         # attribute values are excluded.
            //         if filter_line.value_ids:
            //             result[product_attribute_value.id] = filter_line.value_ids.ids
            //         else:
            //             result[product_attribute_value.id] = filter_line.product_tmpl_id.mapped('attribute_line_ids.product_template_value_ids').ids
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return self.website_default_background_image_url
            // return super()._get_placeholder_filename(field)
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_combinations(self, parent_combination=None, necessary_values=None):
            // """Generator returning combinations that are possible, following the
            // sequence of attributes and values.
            // 
            // See `_is_combination_possible` for what is a possible combination.
            // 
            // When encountering an impossible combination, try to change the value
            // of attributes by starting with the further regarding their sequences.
            // 
            // Ignore attributes that have no values.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :param necessary_values: values that must be in the returned combination
            // :type necessary_values: recordset of `product.template.attribute.value`
            // 
            // :return: the possible combinations
            // :rtype: generator of recordset of `product.template.attribute.value`
            // """
            // self.ensure_one()
            // 
            // if not self.active:
            //     return _("The product template is archived so no combination is possible.")
            // 
            // necessary_values = necessary_values or self.env['product.template.attribute.value']
            // necessary_attribute_lines = necessary_values.mapped('attribute_line_id')
            // attribute_lines = self.valid_product_template_attribute_line_ids.filtered(
            //     lambda ptal: ptal not in necessary_attribute_lines)
            // 
            // if not attribute_lines and self._is_combination_possible(necessary_values, parent_combination):
            //     yield necessary_values
            // 
            // product_template_attribute_values_per_line = []
            // for ptal in attribute_lines:
            //     if ptal.attribute_id.display_type != 'multi':
            //         values_to_add = ptal.product_template_value_ids._only_active()
            //     else:
            //         values_to_add = self.env['product.template.attribute.value']
            //     product_template_attribute_values_per_line.append(values_to_add)
            // 
            // for partial_combination in self._cartesian_product(product_template_attribute_values_per_line, parent_combination):
            //     combination = partial_combination + necessary_values
            //     if self._is_combination_possible(combination, parent_combination):
            //         yield combination
            // 
            // return _("There are no remaining possible combination.")
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_variants(self, parent_combination=None):
            // """Return the existing variants that are possible.
            // 
            // For dynamic attributes, it will only return the variants that have been
            // created already.
            // 
            // If there are a lot of variants, this method might be slow. Even if there
            // aren't too many variants, for performance reasons, do not call this
            // method in a loop over the product templates.
            // 
            // Therefore this method has a very restricted reasonable use case and you
            // should strongly consider doing things differently if you consider using
            // this method.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the existing variants that are possible.
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // return self.product_variant_ids.filtered(lambda p: p._is_variant_possible(parent_combination))
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_possible_variants_sorted(self, parent_combination=None):
            // """Return the sorted recordset of variants that are possible.
            // 
            // The order is based on the order of the attributes and their values.
            // 
            // See `_get_possible_variants` for the limitations of this method with
            // dynamic or no_variant attributes, and also for a warning about
            // performances.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the sorted variants that are possible
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // def _sort_key_attribute_value(value):
            //     # if you change this order, keep it in sync with _order from `product.attribute`
            //     return (value.attribute_id.sequence, value.attribute_id.id)
            // 
            // def _sort_key_variant(variant):
            //     """
            //         We assume all variants will have the same attributes, with only one value for each.
            //             - first level sort: same as "product.attribute"._order
            //             - second level sort: same as "product.attribute.value"._order
            //     """
            //     keys = []
            //     for attribute in variant.product_template_attribute_value_ids.sorted(_sort_key_attribute_value):
            //         # if you change this order, keep it in sync with _order from `product.attribute.value`
            //         keys.append(attribute.product_attribute_value_id.sequence)
            //         keys.append(attribute.id)
            //     return keys
            // 
            // return self._get_possible_variants(parent_combination).sorted(_sort_key_variant)
            */
            return default;
        }

        public async Task<TEntity> GetPreviewedAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object product_query_params) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_previewed_attribute_values(self, category=None, product_query_params=None):
            // """Compute previewed product attribute values for each product in the recordset.
            // 
            // :return: the previewed attribute values per product
            // :rtype: dict
            // """
            // res = defaultdict(dict)
            // show_count = 20
            // for template in self:
            //     previewed_ptal = next((
            //         p for p in template.attribute_line_ids
            //         if p.attribute_id.preview_variants != 'hidden'
            //     ), None)
            //     if previewed_ptal:
            //         previewed_ptavs = [
            //             ptav
            //             for ptav in previewed_ptal.product_template_value_ids
            //             if ptav.ptav_active and ptav.ptav_product_variant_ids
            //         ]
            // 
            //         if len(previewed_ptavs) > 1:
            //             previewed_ptavs_data = []
            //             for ptav in previewed_ptavs[:show_count]:
            //                 matching_variant = min(ptav.ptav_product_variant_ids, key=lambda p: p.id)
            //                 variant_query_params = {
            //                     **(product_query_params or {}),
            //                     'attribute_values': str(ptav.product_attribute_value_id.id)
            //                 }
            //                 previewed_ptavs_data.append({
            //                     'ptav': ptav,
            //                     'variant_image_url': self.env['website'].image_url(matching_variant, 'image_512'),
            //                     'variant_url': template._get_product_url(category, variant_query_params),
            //                 })
            // 
            //             res[template.id] = {
            //                 'ptavs_data': previewed_ptavs_data,
            //                 'hidden_ptavs_count': max(0, len(previewed_ptavs) - show_count)
            //             }
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // return {
            //     key: (fiscal_pos or self.env['account.fiscal.position']).map_account(account)
            //     for key, account in self._get_product_accounts().items()
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // """ Add the stock journal related to product to the result of super()
            // @return: dictionary which contains all needed information regarding stock accounts and journal and super (income+expense accounts)
            // """
            // accounts = super().get_product_accounts(fiscal_pos=fiscal_pos)
            // accounts.update({
            //     'stock_journal': (
            //         self.categ_id.property_stock_journal
            //         or self.categ_id._fields['property_stock_journal'].get_company_dependent_fallback(self.categ_id)
            //         or self.env.company.account_stock_journal_id
            //     )
            // })
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // return {
            //     'income': (
            //         self.property_account_income_id
            //         or self.categ_id.property_account_income_categ_id
            //         or (self.company_id or self.env.company).income_account_id
            //     ), 'expense': (
            //         self.property_account_expense_id
            //         or self.categ_id.property_account_expense_categ_id
            //         or (self.company_id or self.env.company).expense_account_id
            //     ),
            // }
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // accounts = super()._get_product_accounts()
            // if self.categ_id:
            //     # If category set on the product take production account from category even if
            //     # production account on category is False
            //     production_account = self.categ_id.property_stock_account_production_cost_id
            // else:
            //     ProductCategory = self.env['product.category']
            //     production_account = (
            //         self.valuation == 'real_time'
            //         and ProductCategory._fields['property_stock_account_production_cost_id'].get_company_dependent_fallback(
            //             ProductCategory
            //         )
            //         or self.env['account.account']
            //     )
            // accounts['production'] = production_account
            // return accounts
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // """ Add the stock accounts related to product to the result of super()
            // @return: dictionary which contains information regarding stock accounts and super (income+expense accounts)
            // """
            // accounts = super()._get_product_accounts()
            // 
            // accounts['stock_valuation'] = (
            //         self.categ_id.property_stock_valuation_account_id
            //         or self.categ_id._fields['property_stock_valuation_account_id'].get_company_dependent_fallback(self.categ_id)
            //         or self.env.company.account_stock_valuation_id
            //     )
            // accounts['stock_variation'] = accounts['stock_valuation'].account_stock_variation_id
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // self.ensure_one()
            // return (Domain('res_model', '=', 'product.template') & Domain('res_id', 'in', self.ids)) \
            //     | (Domain('res_model', '=', 'product.product') & Domain('res_id', 'in', self.product_variant_ids.ids))
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // """ Override of `product` to filter out gelato print images. """
            // return super()._get_product_document_domain() & Domain('is_gelato', '=', False)
            */
            return default;
        }

        public async Task<TEntity> GetProductInfoPosAsync<TEntity>(IEnumerable<TEntity> entities, object price, object quantity, Guid pos_config_id, Guid product_variant_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def get_product_info_pos(self, price, quantity, pos_config_id, product_variant_id=False):
            // self.ensure_one()
            // config = self.env['pos.config'].browse(pos_config_id)
            // product_variant = self.env['product.product'].browse(product_variant_id) if product_variant_id else False
            // template_or_variant = product_variant or self.product_variant_id
            // 
            // # Tax related
            // tax_to_use = self.env['account.tax']
            // company = config.company_id
            // while not tax_to_use and company:
            //     tax_to_use = self.taxes_id.filtered(lambda tax: tax.company_id.id == company.id)
            //     if not tax_to_use:
            //         company = company.sudo().parent_id
            // taxes = tax_to_use.compute_all(price, config.currency_id, quantity, self)
            // grouped_taxes = {}
            // for tax in taxes['taxes']:
            //     if tax['id'] in grouped_taxes:
            //         grouped_taxes[tax['id']]['amount'] += tax['amount'] / quantity if quantity else 0
            //     else:
            //         grouped_taxes[tax['id']] = {
            //             'name': tax['name'],
            //             'amount': tax['amount'] / quantity if quantity else 0
            //         }
            // 
            // all_prices = {
            //     'price_without_tax': taxes['total_excluded'] / quantity if quantity else 0,
            //     'price_with_tax': taxes['total_included'] / quantity if quantity else 0,
            //     'tax_details': list(grouped_taxes.values()),
            // }
            // 
            // # Pricelists
            // if config.use_pricelist:
            //     pricelists = config.available_pricelist_ids
            // else:
            //     pricelists = config.pricelist_id
            // price_per_pricelist_id = pricelists._price_get(template_or_variant, quantity) if pricelists else False
            // pricelist_list = [{'name': pl.name, 'price': price_per_pricelist_id[pl.id]} for pl in pricelists]
            // 
            // # Warehouses
            // warehouse_list = [
            //     {'id': w.id,
            //     'name': w.name,
            //     'available_quantity': template_or_variant.with_context({'warehouse_id': w.id}).qty_available,
            //     'free_qty': template_or_variant.with_context({'warehouse_id': w.id}).free_qty,
            //     'forecasted_quantity': template_or_variant.with_context({'warehouse_id': w.id}).virtual_available,
            //     'uom': template_or_variant.uom_name}
            //     for w in self.env['stock.warehouse'].search([('company_id', '=', config.company_id.id)])]
            // 
            // if config.picking_type_id.warehouse_id:
            //     # Sort the warehouse_list, prioritizing config.picking_type_id.warehouse_id
            //     warehouse_list = sorted(
            //         warehouse_list,
            //         key=lambda w: w['id'] != config.picking_type_id.warehouse_id.id
            //     )
            // 
            // # Suppliers
            // key = itemgetter('partner_id')
            // supplier_list = []
            // for _key, group in groupby(sorted(self.seller_ids, key=key), key=key):
            //     for s in group:
            //         if not ((s.date_start and s.date_start > date.today()) or (s.date_end and s.date_end < date.today()) or (s.min_qty > quantity)):
            //             supplier_list.append({
            //                 'id': s.id,
            //                 'name': s.partner_id.name,
            //                 'delay': s.delay,
            //                 'price': s.price
            //             })
            //             break
            // 
            // # Variants
            // variant_list = [{'name': attribute_line.attribute_id.name,
            //                  'values': [{'name': attr_name, 'search': f'{self.name} {attr_name}'} for attr_name in attribute_line.value_ids.mapped('name')]}
            //                 for attribute_line in self.attribute_line_ids]
            // 
            // return {
            //     'all_prices': all_prices,
            //     'pricelists': pricelist_list,
            //     'warehouses': warehouse_list,
            //     'suppliers': supplier_list,
            //     'variants': variant_list,
            //     'optional_products': self.pos_optional_product_ids.read(['id', 'name', 'list_price']),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_placeholder_filename(self):
            // return 'product/static/img/placeholder_thumbnail.png'
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_price_context(self, combination):
            // self.ensure_one()
            // res = {}
            // 
            // current_attributes_price_extra = [
            //     ptav.price_extra for ptav in combination.filtered(
            //         lambda ptav:
            //             ptav.price_extra
            //             and ptav.product_tmpl_id == self
            //     )
            // ]
            // if current_attributes_price_extra:
            //     res['current_attributes_price_extra'] = tuple(current_attributes_price_extra)
            // 
            // return res
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_product_types_allow_zero_price(self):
            // """
            // Returns a list of service_tracking (`product.template.service_tracking`) that can ignore the
            // `prevent_zero_price_sale` rule when buying products on a website.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetProductUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object query_params, object grouped_attributes_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_product_url(self, category=None, query_params=None, grouped_attributes_values=None):
            // self.ensure_one()
            // slug = self.env['ir.http']._slug
            // 
            // url = (category and f'/shop/{slug(category)}/{slug(self)}') or self.website_url
            // 
            // query_params = query_params or {}
            // if grouped_attributes_values:
            //     product_grouped_values = self.attribute_line_ids.value_ids.grouped('attribute_id')
            //     available_pav_ids = [
            //         next(v.id for v in pavs if v in product_grouped_values[pa])
            //         for pa, pavs in grouped_attributes_values.items()
            //         if pa in product_grouped_values
            //     ]
            //     available_pav_ids.sort()
            //     query_params['attribute_values'] = ','.join(str(i) for i in available_pav_ids)
            // 
            // if query_params:
            //     url = f'{url}?{urls.url_encode(query_params)}'
            // 
            // return url
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return Domain('partner_id', '!=', False) & Domain(additional_domain or Domain.TRUE)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Return a list of fields present on template and variants models and that are related"""
            // return ['barcode', 'default_code', 'standard_price', 'volume', 'weight', 'product_properties']
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Override of `product` to add `gelato_product_uid` as a related field. """
            // return super()._get_related_fields_variant_template() + ['gelato_product_uid']
            */
            return default;
        }

        public async Task<TEntity> GetRibbonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_vals, object auto_assign_ribbons, object variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_ribbon(self, price_vals=None, auto_assign_ribbons=None, variant=None):
            // """Return the ribbon to display for the current template.
            // 
            // It'll be either the ribbon set on the first variant, or the template, or the first
            // applicable ribbon in the automatically assigned ribbons.
            // 
            // :param dict price_vals: price values for the current product
            // :param auto_assign_ribbons: automatically assigned recordsets, as a `product.ribbon`
            //     recordset
            // :param product.product variant: if any, the displayed variant whose ribbon we're looking
            //     for.
            // 
            // :returns: the ribbon to display, if there is one.
            // :rtype: `product.ribbon` recordset
            // """
            // variant = variant or self.product_variant_id
            // ribbon = variant.sudo().variant_ribbon_id or self.sudo().website_ribbon_id
            // if not ribbon:
            //     # The None check ensures that we do not recompute the ribbons when no ribbons were
            //     # previously found.
            //     if auto_assign_ribbons is None:
            //         # On product page, the auto_assign_ribbons are not provided.
            //         auto_assign_ribbons = self.env['product.ribbon'].search_fetch([
            //             ('assign', '!=', 'manual'),
            //         ])
            //     for rb in auto_assign_ribbons:
            //         if rb._is_applicable_for(variant, price_vals):
            //             return rb
            // 
            // return ribbon
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['is_closed']
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain('is_closed', '=', False)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // return super()._get_saleable_tracking_types() + ['partnership']
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: product.py) ---
            // def _get_saleable_tracking_types(self):
            // return super()._get_saleable_tracking_types() + ['repair']
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // """Return list of salealbe service_tracking types.
            // 
            // :rtype: list
            // """
            // return ['no']
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // return super()._get_saleable_tracking_types() + [
            //     'task_global_project',
            //     'task_in_project',
            //     'project_only',
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_sales_prices(self, website):
            // if not self:
            //     return {}
            // 
            // pricelist = request.pricelist
            // currency = website.currency_id
            // fiscal_position_sudo = request.fiscal_position
            // date = fields.Date.context_today(self)
            // 
            // pricelist_prices = pricelist._compute_price_rule(self, 1.0)
            // comparison_prices_enabled = self.env['res.groups']._is_feature_enabled(
            //     'website_sale.group_product_price_comparison'
            // )
            // 
            // res = {}
            // for template in self:
            //     pricelist_price, pricelist_rule_id = pricelist_prices[template.id]
            // 
            //     product_taxes = template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            //     taxes = fiscal_position_sudo.map_tax(product_taxes)
            // 
            //     base_price = None
            //     template_price_vals = {
            //         'price_reduce': self._apply_taxes_to_price(
            //             pricelist_price, currency, product_taxes, taxes, template, website=website,
            //         ),
            //     }
            //     pricelist_item = template.env['product.pricelist.item'].browse(pricelist_rule_id)
            //     if pricelist_item._show_discount_on_shop():
            //         pricelist_base_price = pricelist_item._compute_price_before_discount(
            //             product=template,
            //             quantity=1.0,
            //             date=date,
            //             uom=template.uom_id,
            //             currency=currency,
            //         )
            //         if currency.compare_amounts(pricelist_base_price, pricelist_price) == 1:
            //             base_price = pricelist_base_price
            //             template_price_vals['base_price'] = self._apply_taxes_to_price(
            //                 base_price, currency, product_taxes, taxes, template, website=website,
            //             )
            // 
            //     if not base_price and comparison_prices_enabled and template.compare_list_price:
            //         template_price_vals['base_price'] = template.currency_id._convert(
            //             template.compare_list_price,
            //             currency,
            //             self.env.company,
            //             date,
            //             round=False,
            //         )
            // 
            //     res[template.id] = template_price_vals
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general(self, service_policy):
            // return self._get_service_to_general_map().get(service_policy, (False, False))
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     # service_policy: (invoice_policy, service_type)
            //     'ordered_prepaid': ('order', 'manual'),
            //     'delivered_milestones': ('delivery', 'milestones'),
            //     'delivered_manual': ('delivery', 'manual'),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     **super()._get_service_to_general_map(),
            //     'delivered_timesheet': ('delivery', 'timesheet'),
            //     'ordered_prepaid': ('order', 'timesheet'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products (method is extended in sale to return optional products info)
            // 
            // Note: self.ensure_one()
            // """
            // self.ensure_one()
            // if self.product_variant_count == 1 and not self.has_configurable_attributes:
            //     return {
            //         'product_id': self.product_variant_id.id,
            //         'product_name': self.product_variant_id.display_name,
            //     }
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products """
            // res = super().get_single_product_variant()
            // if res.get('product_id', False):
            //     has_optional_products = False
            //     for optional_product in self.product_variant_id.optional_product_ids:
            //         if optional_product.has_dynamic_attributes() or optional_product._get_possible_variants(
            //             self.product_variant_id.product_template_attribute_value_ids
            //         ):
            //             has_optional_products = True
            //             break
            //     res.update({
            //         'has_optional_products': has_optional_products,
            //         'is_combo': self.type == 'combo',
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // res = super().get_single_product_variant()
            // if self.has_configurable_attributes:
            //     res['mode'] = self.product_add_mode
            // else:
            //     res['mode'] = 'configurator'
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetStoreMessageUpdateExtraFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_store_message_update_extra_fields(self):
            // return super()._get_store_message_update_extra_fields() + [Store.One("parent_id")]
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_suitable_image_size(self, columns, x_size, y_size):
            // if x_size == 1 and y_size == 1 and columns >= 3:
            //     return 'image_512'
            // return 'image_1024'
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py) ---
            // def _get_template_matrix(self, **kwargs):
            // self.ensure_one()
            // company_id = kwargs.get('company_id', None) or self.company_id or self.env.company
            // currency_id = kwargs.get('currency_id', None) or self.currency_id
            // display_extra = kwargs.get('display_extra_price', False)
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // 
            // Attrib = self.env['product.template.attribute.value']
            // first_line_attributes = attribute_lines[0].product_template_value_ids._only_active()
            // attribute_ids_by_line = [line.product_template_value_ids._only_active().ids for line in attribute_lines]
            // 
            // header = [{"name": self.display_name}] + [
            //     attr._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra
            //     ) for attr in first_line_attributes]
            // 
            // result = [[]]
            // for pool in attribute_ids_by_line:
            //     result = [x + [y] for y in pool for x in result]
            // args = [iter(result)] * len(first_line_attributes)
            // rows = itertools.zip_longest(*args)
            // 
            // matrix = []
            // for row in rows:
            //     row_attributes = Attrib.browse(row[0][1:])
            //     row_header_cell = row_attributes._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra)
            //     result = [row_header_cell]
            // 
            //     for cell in row:
            //         combination = Attrib.browse(cell)
            //         is_possible_combination = self._is_combination_possible(combination)
            //         cell.sort()
            //         result.append({
            //             "ptav_ids": cell,
            //             "qty": 0,
            //             "is_possible_combination": is_possible_combination
            //         })
            //     matrix.append(result)
            // 
            // return {
            //     "header": header,
            //     "matrix": matrix,
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IRatingMixinable
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
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_for_combination(self, combination):
            // """Get the variant matching the combination.
            // 
            // All of the values in combination must be present in the variant, and the
            // variant should not have more attributes. Ignore the attributes that are
            // not supposed to create variants.
            // 
            // :param combination: recordset of `product.template.attribute.value`
            // 
            // :return: the variant if found, else empty
            // :rtype: recordset `product.product`
            // """
            // self.ensure_one()
            // filtered_combination = combination._without_no_variant_attributes()
            // return self.env['product.product'].browse(self._get_variant_id_for_combination(filtered_combination))
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_id_for_combination(self, filtered_combination):
            // """See `_get_variant_for_combination`. This method returns an ID
            // so it can be cached.
            // 
            // Use sudo because the same result should be cached for all users.
            // """
            // self.ensure_one()
            // domain = Domain('product_tmpl_id', '=', self.id)
            // combination_indices_ids = filtered_combination._ids2str()
            // 
            // if combination_indices_ids:
            //     domain &= Domain('combination_indices', '=', combination_indices_ids)
            // else:
            //     domain &= Domain('combination_indices', 'in', ['', False])
            // 
            // return self.env['product.product'].sudo().with_context(active_test=False).search(domain, order='active DESC', limit=1).id
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_versioned_fields(self):
            // return [ProjectTask.description.name]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> GetVisitorHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object visitor) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_history(self, visitor):
            // return visitor._get_visitor_history()
            */
            return default;
        }

        public async Task<TEntity> GetVisitorLeaveMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object cancel) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_leave_message(self, operator=False, cancel=False):
            // return _('Visitor left the conversation.')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `volume` field. By default, we consider
            // that volumes are expressed in cubic meters. Users can configure to express them in cubic feet
            // by adding an ir.config_parameter record with "product.volume_in_cubic_feet" as key
            // and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_cubic_foot')
            // else:
            //     return self.env.ref('uom.product_uom_cubic_meter')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_name_from_ir_config_parameter(self):
            // return self._get_volume_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_accessory_product(self):
            // domain = Domain(self.env['website'].sale_product_domain())
            // if not self.env.user._is_internal():
            //     domain &= Domain('is_published', '=', True)
            // return self.accessory_product_ids.filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_alternative_product(self):
            // domain = self.env['website'].sale_product_domain()
            // return self.alternative_product_ids.filtered_domain(domain)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `weight` field. By default, we considerer
            // that weights are expressed in kilograms. Users can configure to express them in pounds
            // by adding an ir.config_parameter record with "product.product_weight_in_lbs" as key
            // and "1" as value.
            // """
            // product_weight_in_lbs_param = self.env['ir.config_parameter'].sudo().get_param('product.weight_in_lbs')
            // if product_weight_in_lbs_param == '1':
            //     return self.env.ref('uom.product_uom_lb')
            // else:
            //     return self.env.ref('uom.product_uom_kgm')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_name_from_ir_config_parameter(self):
            // return self._get_weight_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def has_dynamic_attributes(self):
            // """Return whether this `product.template` has at least one dynamic
            // attribute.
            // 
            // :return: True if at least one dynamic attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'dynamic' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_is_custom_values(self):
            // self.ensure_one()
            // """Return whether this `product.template` has at least one is_custom
            // attribute value.
            // 
            // :return: True if at least one is_custom attribute value, False otherwise
            // :rtype: bool
            // """
            // return any(v.is_custom for v in self.valid_product_template_attribute_line_ids.product_template_value_ids._only_active())
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _has_multiple_uoms(self) -> bool:
            // if self.type == 'combo':
            //     return False
            // return self.env['res.groups']._is_feature_enabled('uom.group_uom') and len(
            //     self._get_available_uoms()
            // ) > 1
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_no_variant_attributes(self):
            // """Return whether this `product.template` has at least one no_variant
            // attribute.
            // 
            // :return: True if at least one no_variant attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'no_variant' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _init_column(self, column_name):
            // # to avoid generating a single default website_sequence when installing the module,
            // # we need to set the default row by row for this column
            // if column_name == "website_sequence":
            //     _logger.debug("Table '%s': setting default value of new column %s to unique values for each row", self._table, column_name)
            //     self.env.cr.execute("SELECT id FROM %s WHERE website_sequence IS NULL" % self._table)
            //     prod_tmpl_ids = self.env.cr.dictfetchall()
            //     max_seq = self._default_website_sequence()
            //     query = f"""
            //         UPDATE {self._table}
            //         SET website_sequence = p.web_seq
            //         FROM (VALUES %s) AS p(p_id, web_seq)
            //         WHERE id = p.p_id
            //     """
            //     values_args = [(prod_tmpl['id'], max_seq + i * 5) for i, prod_tmpl in enumerate(prod_tmpl_ids)]
            //     self.env.cr.execute_values(query, values_args)
            // else:
            //     super()._init_column(column_name)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _init_column(self, column_name):
            // """ Initialize the value of the given column for existing rows.
            //     Overridden here because we need to generate different access tokens
            //     and by default _init_column calls the default method once and applies
            //     it for every record.
            // """
            // if column_name != 'access_token':
            //     super()._init_column(column_name)
            // else:
            //     query = """
            //         UPDATE %(table_name)s
            //         SET access_token = md5(md5(random()::varchar || id::varchar) || clock_timestamp()::varchar)::uuid::varchar
            //         WHERE access_token IS NULL
            //     """ % {'table_name': self._table}
            //     self.env.cr.execute(query)
            */
            return default;
        }

        public async Task<TEntity> InverseChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _inverse_channel_partner_ids(self):
            // new_members = []
            // outdated = self.env['discuss.channel.member']
            // for channel in self:
            //     current_members = channel.channel_member_ids
            //     partners = channel.channel_partner_ids
            //     partners_new = partners - current_members.partner_id
            // 
            //     new_members += [{
            //         'channel_id': channel.id,
            //         'partner_id': partner.id,
            //     } for partner in partners_new]
            //     outdated += current_members.filtered(lambda m: m.partner_id not in partners)
            // if new_members:
            //     self.env['discuss.channel.member'].create(new_members)
            // if outdated:
            //     outdated.unlink()
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _inverse_gelato_product_uid(self):
            // self._set_product_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> InverseQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _inverse_qty_available(self):
            // if self.env.context.get('skip_qty_available_update', False):
            //     return
            // for template in self:
            //     if template.qty_available and not template.product_variant_id:
            //         raise UserError(_("Save the product form before updating the Quantity On Hand."))
            //     else:
            //         template.product_variant_id.qty_available = template.qty_available
            */
            return default;
        }

        public async Task<TEntity> InverseSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _inverse_serial_prefix_format(self):
            // valid_sequences = self.env['ir.sequence'].search([('prefix', 'in', self.mapped('serial_prefix_format'))])
            // sequences_by_prefix = {seq.prefix: seq for seq in valid_sequences}
            // for template in self:
            //     if template.serial_prefix_format:
            //         if template.serial_prefix_format in sequences_by_prefix:
            //             template.lot_sequence_id = sequences_by_prefix[template.serial_prefix_format]
            //         else:
            //             new_sequence = self.env['ir.sequence'].create({
            //                 'name': f'{template.name} Serial Sequence',
            //                 'code': 'stock.lot.serial',
            //                 'prefix': template.serial_prefix_format,
            //                 'padding': 7,
            //                 'company_id': False,
            //             })
            //             template.lot_sequence_id = new_sequence
            //             sequences_by_prefix[template.serial_prefix_format] = new_sequence
            //     else:
            //         template.lot_sequence_id = self.env.ref('stock.sequence_production_lots', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _inverse_service_policy(self):
            // for product in self:
            //     if product.service_policy:
            //         product.invoice_policy, product.service_type = self._get_service_to_general(product.service_policy)
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> InviteByEmailAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def invite_by_email(self, emails):
            // """
            // Send channel invitation emails to a list of email addresses. Existing members'
            // email addresses are ignored.
            // 
            // :param emails: List of email addresses to invite.
            // :type emails: list[str]
            // 
            // """
            // if not self.env.user._is_internal() or not self.has_access("read"):
            //     raise AccessError(self.env._("You don't have access to invite users to this channel."))
            // if not self._allow_invite_by_email():
            //     raise UserError(
            //         self.env._("Inviting by email is not allowed for this channel type (%s).")
            //         % self.channel_type
            //     )
            // eligible_emails = OrderedSet(norm for email in emails if email and (norm := email_normalize(email)))
            // # Removing emails linked to members of this channel.
            // member_domain = Domain("channel_id", "=", self.id) & Domain.OR(
            //     [
            //         [(field, "=ilike", email)]
            //         for email in eligible_emails
            //         for field in ("guest_id.email", "partner_id.email")
            //     ],
            // )
            // eligible_emails -= set(
            //     self.env["discuss.channel.member"]
            //     .search_fetch(member_domain, ["partner_id", "guest_id"])
            //     .mapped(lambda m: email_normalize(m.partner_id.email or m.guest_id.email))
            // )
            // mail_body = Markup("<p>%s</p>") % self.env._(
            //     "%(user_name)s has invited you to the %(strong_start)s%(channel_name)s%(strong_end)s channel."
            // ) % {
            //     "user_name": self.env.user.name,
            //     "channel_name": self.name,
            //     "strong_start": Markup("<strong>"),
            //     "strong_end": Markup("</strong>"),
            // }
            // to_create = []
            // for addr in eligible_emails:
            //     body = self.env["ir.qweb"]._render(
            //         "mail.discuss_channel_invitation_template",
            //         {
            //             "base_url": self.env["ir.config_parameter"].get_base_url(),
            //             "channel": self,
            //             "email_token": hash_sign(self.env(su=True), "mail.invite_email", addr),
            //             "mail_body": mail_body,
            //             "user": self.env.user,
            //         },
            //         minimal_qcontext=True,
            //     )
            //     to_create.append(
            //         {
            //             "body_html": body,
            //             "email_from": self.env.user.partner_id.email_formatted,
            //             "email_to": addr,
            //             "message_type": "user_notification",
            //             "model": "discuss.channel",
            //             "res_id": self.id,
            //             "subject": self.env._("%(author_name)s has invited you to a channel")
            //             % {"author_name": self.env.user.name},
            //         },
            //     )
            // if not to_create:
            //     return
            // try:
            //     # sudo - mail.mail: internal users having read access to the channel can invite others.
            //     self.env["mail.mail"].sudo().create(to_create).send(raise_exception=True)
            // except MailDeliveryException as mde:
            //     error_msg = self.env._(
            //         "There was an error when trying to deliver your Email, please check your configuration."
            //     )
            //     if len(mde.args) == 2 and isinstance(mde.args[1], ConnectionRefusedError):
            //         error_msg = self.env._(
            //             "Could not contact the mail server, please check your outgoing email server configuration."
            //         )
            //     raise UserError(error_msg) from mde
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _is_add_to_cart_possible(self, parent_combination=None):
            // """
            // It's possible to add to cart (potentially after configuration) if
            // there is at least one possible combination.
            // 
            // :param parent_combination: the combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: True if it's possible to add to cart, else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // if not self.active or not self._can_be_added_to_cart():
            //     # for performance: avoid calling `_get_possible_combinations`
            //     return False
            // return next(self._get_possible_combinations(parent_combination), False) is not False
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def is_blocked_by_dependences(self):
            // return any(blocking_task.state not in CLOSED_STATES for blocking_task in self.depend_on_ids)
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible_by_config(self, combination, ignore_no_variant=False):
            // """Return whether the given combination is possible according to the config of attributes on the template
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :return: wether the given combination is possible according to the config of attributes on the template
            // :rtype: bool
            // """
            // self.ensure_one()
            // # Returns False on StopIteration. Empty combination should return True.
            // return isinstance(next(self._filter_combinations_impossible_by_config([combination], ignore_no_variant), False), models.BaseModel)
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible(self, combination, parent_combination=None, ignore_no_variant=False):
            // """
            // The combination is possible if it is not excluded by any rule
            // coming from the current template, not excluded by any rule from the
            // parent_combination (if given), and there should not be any archived
            // variant with the exact same combination.
            // 
            // If the template does not have any dynamic attribute, the combination
            // is also not possible if the matching variant has been deleted.
            // 
            // Moreover the attributes of the combination must excatly match the
            // attributes allowed on the template.
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: whether the combination is possible
            // :rtype: bool
            // """
            // self.ensure_one()
            // 
            // if not self._is_combination_possible_by_config(combination, ignore_no_variant):
            //     return False
            // 
            // variant = self._get_variant_for_combination(combination)
            // 
            // if self.has_dynamic_attributes():
            //     if variant and not variant.active:
            //         # dynamic and the variant has been archived
            //         return False
            // else:
            //     if not variant or not variant.active:
            //         # not dynamic, the variant has been archived or deleted
            //         return False
            // 
            // parent_exclusions = self._get_parent_attribute_exclusions(parent_combination)
            // if parent_exclusions:
            //     # parent_exclusion are mapped by ptav but here we don't need to know
            //     # where the exclusion comes from so we loop directly on the dict values
            //     for exclusions_values in parent_exclusions.values():
            //         for exclusion in exclusions_values:
            //             if exclusion in combination.ids:
            //                 return False
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _is_in_wishlist(self):
            // self.ensure_one()
            // return self in self.env['product.wishlist'].current().mapped('product_id.product_tmpl_id')
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _is_sold_out(self):
            // """Return whether the product is sold out (no available quantity).
            // 
            // If a product inventory is not tracked, or if it's allowed to be sold regardless
            // of availabilities, the product is never considered sold out.
            // 
            // Note: only checks the availability of the first variant of the template.
            // 
            // :return: whether the product can still be sold
            // :rtype: bool
            // """
            // if not self.is_storable or self.allow_out_of_stock_order:
            //     return False
            // return self.product_variant_id._is_sold_out()
            */
            return default;
        }

        public async Task<TEntity> LazyLoadMembersChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _lazy_load_members_channel_types(self):
            // """ Return the channel types that load members lazily. """
            // return ["channel", "group"]
            */
            return default;
        }

        public async Task<TEntity> LivechatJoinChannelNeedingHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def livechat_join_channel_needing_help(self):
            // """Join a live chat for which help was requested.
            // 
            // :returns: Whether the live chat was joined. False if the live chat could not
            //     be joined because another agent already joined the channel in the meantime.
            // :rtype: bool
            // """
            // self.ensure_one()
            // if self.livechat_status != "need_help":
            //     return False
            // self._add_members(users=self.env.user)
            // return True
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _load_pos_data_domain(self, data, config):
            // domain = [
            //     *self.env['product.template']._check_company_domain(config.company_id),
            //     ('available_in_pos', '=', True),
            //     ('sale_ok', '=', True),
            // ]
            // if config.limit_categories:
            //     domain += [('pos_categ_ids', 'in', config.iface_available_categ_ids.ids)]
            // return domain
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'id', 'display_name', 'standard_price', 'categ_id', 'pos_categ_ids', 'taxes_id', 'barcode', 'name', 'list_price', 'is_favorite',
            //     'default_code', 'to_weight', 'uom_id', 'description_sale', 'description', 'tracking', 'type', 'service_tracking', 'is_storable',
            //     'write_date', 'color', 'pos_sequence', 'available_in_pos', 'attribute_line_ids', 'active', 'image_128', 'combo_ids', 'product_variant_ids', 'public_description',
            //     'pos_optional_product_ids', 'sequence', 'product_tag_ids'
            // ]
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: product_template.py) ---
            // def _load_pos_data_fields(self, config):
            // params = super()._load_pos_data_fields(config)
            // params += ['invoice_policy', 'type', 'sale_line_warn_msg']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_data_fields(self, config):
            // params = super()._load_pos_data_fields(config)
            // params += ['self_order_available']
            // return params
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // self._process_pos_ui_product_product(read_records, config)
            // return read_records
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_data = super()._load_pos_data_read(records, config)
            // discount_product_id = config.discount_product_id.id
            // product_ids_set = {product['id'] for product in read_data}
            // 
            // if config.module_pos_discount and discount_product_id not in product_ids_set:
            //     productModel = self.env['product.template'].with_context({**self.env.context, 'display_default_code': False})
            //     fields = self.env['product.template']._load_pos_data_fields(config)
            //     product = productModel.search_read([('id', '=', discount_product_id)], fields=fields, load=False)
            //     read_data.extend(product)
            // 
            // return read_data
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataSearchReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _load_pos_data_search_read(self, data, config):
            // limit_count = config.get_limited_product_count()
            // pos_limited_loading = self.env.context.get('pos_limited_loading', True)
            // if limit_count and pos_limited_loading:
            //     query = self._search(self._load_pos_data_domain(data, config), bypass_access=True)
            //     sql = SQL(
            //         """
            //             WITH pm AS (
            //                 SELECT pp.product_tmpl_id,
            //                     MAX(sml.write_date) date
            //                 FROM stock_move_line sml
            //                 JOIN product_product pp ON sml.product_id = pp.id
            //                 GROUP BY pp.product_tmpl_id
            //             )
            //             SELECT product_template.id
            //                 FROM %s
            //             LEFT JOIN pm ON product_template.id = pm.product_tmpl_id
            //                 WHERE %s
            //             ORDER BY product_template.is_favorite DESC NULLS LAST,
            //                 CASE WHEN product_template.type = 'service' THEN 1 ELSE 0 END DESC,
            //                 pm.date DESC NULLS LAST,
            //                 product_template.write_date DESC
            //             LIMIT %s
            //         """,
            //         query.from_clause,
            //         query.where_clause or SQL("TRUE"),
            //         limit_count,
            //     )
            //     product_tmpl_ids = [r[0] for r in self.env.execute_query(sql)]
            //     products = self._load_product_with_domain([('id', 'in', product_tmpl_ids)])
            // else:
            //     domain = self._load_pos_data_domain(data, config)
            //     products = self._load_product_with_domain(domain)
            // 
            // product_combo = products.filtered(lambda p: p['type'] == 'combo')
            // products += product_combo.combo_ids.combo_item_ids.product_id.product_tmpl_id
            // 
            // special_products = config._get_special_products().filtered(
            //             lambda product: not product.sudo().company_id
            //                             or product.sudo().company_id == self.env.company
            //         )
            // products += special_products.product_tmpl_id
            // if config.tip_product_id:
            //     tip_company_id = config.tip_product_id.sudo().company_id
            //     if not tip_company_id or tip_company_id == self.env.company:
            //         products += config.tip_product_id.product_tmpl_id
            // 
            // # Ensure optional products are loaded when configured.
            // if products.filtered(lambda p: p.pos_optional_product_ids):
            //     products |= products.mapped("pos_optional_product_ids")
            // 
            // # Ensure products from loaded orders are loaded
            // if data.get('pos.order.line'):
            //     products += self.env['product.product'].browse([l['product_id'] for l in data['pos.order.line']]).product_tmpl_id
            // 
            // return self._load_pos_data_read(products, config)
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py) ---
            // def _load_pos_data_search_read(self, data, config):
            // read_data = super()._load_pos_data_search_read(data, config)
            // 
            // rewards = config._get_program_ids().reward_ids
            // reward_products = rewards.discount_line_product_id | rewards.reward_product_ids | rewards.reward_product_id
            // trigger_products = config._get_program_ids().trigger_product_ids
            // 
            // loyalty_product_tmpl_ids = set((reward_products.product_tmpl_id | trigger_products.product_tmpl_id).ids)
            // already_loaded_product_tmpl_ids = {template['id'] for template in read_data}
            // 
            // missing_product_tmpl_ids = list(loyalty_product_tmpl_ids - already_loaded_product_tmpl_ids)
            // fields = self.env['product.template']._load_pos_data_fields(config)
            // 
            // missing_product_templates = self.env['product.template'].browse(missing_product_tmpl_ids).read(fields=fields, load=False)
            // product_ids_to_hide = reward_products.product_tmpl_id - self.env['product.template'].browse(already_loaded_product_tmpl_ids)
            // 
            // if self.env.context.get('pos_limited_loading', True):
            //     # Filter out products that can be loaded in the PoS but are not loaded yet
            //     product_ids_to_hide = product_ids_to_hide - product_ids_to_hide.filtered_domain(self._load_pos_data_domain(data, config))
            // 
            // config_data = data['pos.config'][0]
            // config_data['_pos_special_products_ids'] += product_ids_to_hide.product_variant_id.ids
            // 
            // # Identify special loyalty products (e.g., gift cards, e-wallets) to be displayed in the POS
            // loyality_products = config.get_record_by_ref([
            //     'loyalty.gift_card_product_50',
            //     'loyalty.ewallet_product_50',
            // ])
            // special_display_products = self.env['product.product'].browse(loyality_products)
            // # Include trigger products from loyalty programs of type 'gift_card' or 'ewallet'
            // special_display_products += self.env['loyalty.program'].search([
            //     ('program_type', 'in', ['ewallet']),
            //     ('pos_config_ids', 'in', [False, config.id]),
            // ]).trigger_product_ids
            // 
            // config_data['_pos_special_display_products_ids'] = special_display_products.product_tmpl_id.ids
            // 
            // read_data.extend(missing_product_templates)
            // return read_data
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_self_data_domain(self, data, config):
            // domain = super()._load_pos_self_data_domain(data, config)
            // return Domain.AND([domain, [('self_order_available', '=', True)]])
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _load_pos_self_data_read(self, data, config):
            // domain = self._load_pos_self_data_domain(data, config)
            // fields = set(self._load_pos_self_data_fields(config))
            // products = self.search_read(
            //     domain,
            //     fields,
            //     limit=config.get_limited_product_count(),
            //     order='sequence,default_code,name',
            //     load=False
            // )
            // 
            // combo_products = self.browse((p['id'] for p in products if p["type"] == "combo"))
            // combo_products_choice = self.search_read(
            //     [("id", 'in', combo_products.combo_ids.combo_item_ids.product_id.product_tmpl_id.ids), ("id", "not in", [p['id'] for p in products])],
            //     fields,
            //     limit=config.get_limited_product_count(),
            //     order='sequence,default_code,name',
            //     load=False
            // )
            // products.extend(combo_products_choice)
            // self._process_pos_self_ui_products(products)
            // 
            // return products
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadProductFromPosAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def load_product_from_pos(self, config_id, domain, offset=0, limit=0):
            // load_archived = self.env.context.get('load_archived', False)
            // domain = Domain(domain)
            // config = self.env['pos.config'].browse(config_id)
            // product_tmpls = self._load_product_with_domain(domain, load_archived, offset, limit)
            // 
            // # product.combo and product.combo.item loading
            // for product_tmpl in product_tmpls:
            //     if product_tmpl.type == 'combo':
            //         product_tmpls += product_tmpl.combo_ids.combo_item_ids.product_id.product_tmpl_id
            // 
            // combo_domain = Domain('id', 'in', product_tmpls.combo_ids.ids)
            // combo_records = self.env['product.combo'].search(combo_domain)
            // combo_read = self.env['product.combo']._load_pos_data_read(combo_records, config)
            // combo_item_domain = Domain('combo_id', 'in', product_tmpls.combo_ids.ids)
            // combo_item_records = self.env['product.combo.item'].search(combo_item_domain)
            // combo_item_read = self.env['product.combo.item']._load_pos_data_read(combo_item_records, config)
            // 
            // products = product_tmpls.product_variant_ids
            // 
            // # product.pricelist_item & product.pricelist loading
            // pricelists = config.current_session_id.get_pos_ui_product_pricelist_item_by_product(
            //     product_tmpls.ids,
            //     products.ids,
            //     config.id
            // )
            // 
            // # product.template.attribute.value & product.template.attribute.line loading
            // product_tmpl_attr_line = product_tmpls.attribute_line_ids
            // product_tmpl_attr_line_read = product_tmpl_attr_line._load_pos_data_read(product_tmpl_attr_line, config)
            // product_tmpl_attr_value = product_tmpls.attribute_line_ids.product_template_value_ids
            // product_tmpl_attr_value_read = product_tmpl_attr_value._load_pos_data_read(product_tmpl_attr_value, config)
            // 
            // # product.template.attribute.exclusion loading
            // product_tmpl_excl = self.env['product.template.attribute.exclusion']
            // product_tmpl_exclusion = product_tmpl_attr_value.exclude_for + product_tmpl_excl.search([
            //     ('product_tmpl_id', 'in', product_tmpls.ids),
            // ])
            // product_tmpl_exclusion_read = product_tmpl_excl._load_pos_data_read(product_tmpl_exclusion, config)
            // 
            // # product.product loading
            // product_read = products._load_pos_data_read(products.with_context(display_default_code=False), config)
            // 
            // # product.template loading
            // product_tmpl_read = self._load_pos_data_read(product_tmpls, config)
            // 
            // # product.uom loading
            // packaging_domain = Domain('product_id', 'in', products.ids)
            // barcode_in_domain = any('barcode' in condition.field_expr for condition in domain.iter_conditions())
            // 
            // if barcode_in_domain:
            //     barcode = [condition.value for condition in domain.iter_conditions() if 'barcode' in condition.field_expr]
            //     flat = [item for sublist in barcode for item in sublist]
            //     packaging_domain |= Domain('barcode', 'in', flat)
            // 
            // product_uom = self.env['product.uom']
            // packaging = product_uom.search(packaging_domain)
            // condition = packaging and packaging.product_id
            // packaging_read = product_uom._load_pos_data_read(packaging, config) if condition else []
            // 
            // # account.tax loading
            // account_tax = self.env['account.tax']
            // tax_domain = Domain(account_tax._check_company_domain(config.company_id.id))
            // tax_domain &= Domain('id', 'in', product_tmpls.taxes_id.ids)
            // tax_read = account_tax._load_pos_data_read(account_tax.search(tax_domain), config)
            // 
            // return {
            //     **pricelists,
            //     'account.tax': tax_read,
            //     'product.product': product_read,
            //     'product.template': product_tmpl_read,
            //     'product.uom': packaging_read,
            //     'product.combo': combo_read,
            //     'product.combo.item': combo_item_read,
            //     'product.template.attribute.value': product_tmpl_attr_value_read,
            //     'product.template.attribute.line': product_tmpl_attr_line_read,
            //     'product.template.attribute.exclusion': product_tmpl_exclusion_read,
            // }
            */
            return default;
        }

        public async Task<TEntity> LoadProductWithDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object load_archived, object offset, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _load_product_with_domain(self, domain, load_archived=False, offset=0, limit=0):
            // context = {**self.env.context, 'display_default_code': False, 'active_test': not load_archived, 'bin_size': True}
            // domain = self._server_date_to_domain(domain)
            // return self.with_context(context).search(
            //     domain,
            //     order='sequence,default_code,name',
            //     offset=offset,
            //     limit=limit if limit else False
            // )
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            */
            return default;
        }

        public async Task<TEntity> MemberBasedNamingChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _member_based_naming_channel_types(self):
            // """ Return the channel types that use member-based naming,
            //     specifically the `channel_name_member_ids` field.
            // """
            // return ["group"]
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IRatingMixinable
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
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // """
            // This method is called just before _notify_thread() method which is calling the _to_store()
            // method. We need a 'chatbot.message' record before it happens to correctly display the message.
            // It's created only if the mail channel is linked to a chatbot step. We also need to save the
            // user answer if the current step is a question selection.
            // """
            // if self.chatbot_current_step_id and not self.livechat_agent_history_ids:
            //     selected_answer = (
            //         self.env["chatbot.script.answer"]
            //         .browse(self.env.context.get("selected_answer_id"))
            //         .exists()
            //     )
            //     if selected_answer and selected_answer in self.chatbot_current_step_id.answer_ids:
            //         # sudo - chatbot.message: finding the question message to update the user answer is allowed.
            //         question_msg = (
            //             self.env["chatbot.message"]
            //             .sudo()
            //             .search(
            //                 [
            //                     ("discuss_channel_id", "=", self.id),
            //                     ("script_step_id", "=", self.chatbot_current_step_id.id),
            //                 ],
            //                 order="id DESC",
            //                 limit=1,
            //             )
            //         )
            //         question_msg.user_script_answer_id = selected_answer
            //         question_msg.user_raw_script_answer_id = selected_answer.id
            //         if store := self.env.context.get("message_post_store"):
            //             store.add(message).add(question_msg.mail_message_id)
            //         partner, guest = self.env["res.partner"]._get_current_persona()
            //         Store(bus_channel=partner or guest).add_model_values(
            //             "ChatbotStep",
            //             {
            //                 "id": (self.chatbot_current_step_id.id, question_msg.mail_message_id.id),
            //                 "scriptStep": self.chatbot_current_step_id.id,
            //                 "message": question_msg.mail_message_id.id,
            //                 "selectedAnswer": selected_answer.id,
            //             },
            //         ).bus_send()
            // 
            //     self.env["chatbot.message"].sudo().create(
            //         {
            //             "mail_message_id": message.id,
            //             "discuss_channel_id": self.id,
            //             "script_step_id": self.chatbot_current_step_id.id,
            //         }
            //     )
            // 
            // author_history = self.env["im_livechat.channel.member.history"]
            // # sudo - discuss.channel: accessing history to update its state is acceptable
            // if message.author_id or message.author_guest_id:
            //     author_history = self.sudo().livechat_channel_member_history_ids.filtered(
            //         lambda h: h.partner_id == message.author_id
            //         if message.author_id
            //         else h.guest_id == message.author_guest_id
            //     )
            // if author_history:
            //     if message.message_type not in ("notification", "user_notification"):
            //         author_history.message_count += 1
            // if author_history.livechat_member_type == "agent" and not author_history.response_time_hour:
            //     author_history.response_time_hour = (
            //         fields.Datetime.now() - author_history.create_date
            //     ).total_seconds() / 3600
            // if not self.livechat_end_dt and author_history.livechat_member_type == "agent":
            //     self.livechat_failure = "no_failure"
            // # sudo: discuss.channel - accessing livechat_status in internal code is acceptable
            // if (
            //     not self.livechat_end_dt
            //     and self.sudo().livechat_status == "waiting"
            //     and author_history.livechat_member_type == "visitor"
            // ):
            //     # sudo: discuss.channel - writing livechat_status when a message is posted is acceptable
            //     self.sudo().livechat_status = "in_progress"
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

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def message_post(self, *, parent_id=False, subtype_id=False, **kwargs):
            // """ Temporary workaround to avoid spam. If someone replies on a channel
            // through the 'Presentation Published' email, it should be considered as a
            // note as we don't want all channel followers to be notified of this answer.
            // Also make sure that only one review can be posted per course."""
            // self.ensure_one()
            // if kwargs.get('message_type') == 'comment' and not self.can_review:
            //     raise AccessError(_('Not enough karma to review'))
            // if parent_id:
            //     parent_message = self.env['mail.message'].sudo().browse(parent_id)
            //     if parent_message.subtype_id and parent_message.subtype_id == self.env.ref('website_slides.mt_channel_slide_published'):
            //         subtype_id = self.env.ref('mail.mt_note').id
            // message = super().message_post(parent_id=parent_id, subtype_id=subtype_id, **kwargs)
            // if self.env.user._is_internal() and not message.rating_value:
            //     return message
            // if message.subtype_id == self.env.ref("mail.mt_comment"):
            //     domain = [
            //         ("res_id", "=", self.id),
            //         ("author_id", "=", message.author_id.id),
            //         ("model", "=", "slide.channel"),
            //         ("subtype_id", "=", self.env.ref("mail.mt_comment").id),
            //         ("rating_ids", "!=", False),
            //     ]
            //     if self.env["mail.message"].search_count(domain, limit=2) > 1:
            //         raise ValidationError(_("Only a single review can be posted per course."))
            // if message.rating_value and message.is_current_user_or_guest_author:
            //     self.env.user._add_karma(self.karma_gen_channel_rank, self, _("Course Ranked"))
            // return message
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_receive_bounce(self, email, partner):
            // # Override bounce management to unsubscribe bouncing addresses
            // for p in partner:
            //     if p.message_bounce >= self.MAX_BOUNCE_LIMIT:
            //         self._action_unfollow(p)
            // return super()._message_receive_bounce(email, partner)
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> MessageSubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_subscribe(self, partner_ids=None, subtype_ids=None, customer_ids=None):
            // # Do not allow follower subscription on channels. Only members are considered
            // raise UserError(_('Adding followers on channels is not possible. Consider adding members instead.'))
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IRatingMixinable
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

        protected async Task<object> MessageUpdateContentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_update_content(self, message, /, *, partner_ids=None, **kwargs):
            // if partner_ids:
            //     kwargs["partner_ids"] = self._get_allowed_message_partner_ids(partner_ids)
            // super()._message_update_content(message, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _move_category_slides(self, category, new_category):
            // if not category.slide_ids:
            //     return
            // truncated_slide_ids = [slide_id for slide_id in self.slide_ids.ids if slide_id not in category.slide_ids.ids]
            // if new_category:
            //     place_idx = truncated_slide_ids.index(new_category.id)
            //     ordered_slide_ids = truncated_slide_ids[:place_idx] + category.slide_ids.ids + truncated_slide_ids[place_idx]
            // else:
            //     ordered_slide_ids = category.slide_ids.ids + truncated_slide_ids
            // for index, slide_id in enumerate(ordered_slide_ids):
            //     self.env['slide.slide'].browse([slide_id]).sequence = index + 1
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def name_search(self, name='', domain=None, operator='ilike', limit=100):
            // # Only use the product.product heuristics if there is a search term and the domain
            // # does not specify a match on `product.template` IDs.
            // self_obj = self
            // if 'search_product_product' not in self.env.context and any(term[0] == 'id' for term in (domain or [])):
            //     self_obj = self_obj.with_context(search_product_product=False)
            // return super(ProductTemplate, self_obj).name_search(name, domain, operator, limit)
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> NotifyByWebPushPreparePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object force_record_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_by_web_push_prepare_payload(self, message, msg_vals=False, force_record_name=False):
            // payload = super()._notify_by_web_push_prepare_payload(
            //     message, msg_vals=msg_vals, force_record_name=force_record_name,
            // )
            // msg_vals = msg_vals or {}
            // payload['options']['data']['action'] = 'mail.action_discuss'
            // record_name = force_record_name or message.record_name
            // author_ids = [msg_vals["author_id"]] if msg_vals.get("author_id") else message.author_id.ids
            // author = self.env["res.partner"].browse(author_ids) or self.env["mail.guest"].browse(
            //     msg_vals.get("author_guest_id", message.author_guest_id.id)
            // )
            // if self.channel_type == 'chat':
            //     payload['title'] = author.name
            // elif self.channel_type == 'channel':
            //     payload['title'] = "#%s - %s" % (record_name, author.name)
            // elif self.channel_type == 'group':
            //     if not record_name:
            //         member_names = self.channel_member_ids.mapped(lambda m: m.partner_id.name if m.partner_id else m.guest_id.name)
            //         record_name = f"{', '.join(member_names[:-1])} and {member_names[-1]}" if len(member_names) > 1 else member_names[0] if member_names else ""
            //     payload['title'] = "%s - %s" % (record_name, author.name)
            // else:
            //     payload['title'] = "#%s" % (record_name)
            // return payload
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> NotifyGetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_get_recipients(self, message, msg_vals=False, **kwargs):
            // # Override recipients computation as channel is not a standard
            // # mail.thread document. Indeed there are no followers on a channel.
            // # Instead of followers it has members that should be notified.
            // msg_vals = msg_vals or {}
            // 
            // # notify only user input (comment, whatsapp messages or incoming / outgoing emails)
            // message_type = msg_vals['message_type'] if 'message_type' in msg_vals else message.message_type
            // if message_type not in ('comment', 'email', 'email_outgoing', 'whatsapp_message'):
            //     return []
            // 
            // recipients_data = []
            // author_id = msg_vals.get("author_id") or message.author_id.id
            // pids = msg_vals['partner_ids'] or [] if 'partner_ids' in msg_vals else message.partner_ids.ids
            // if pids:
            //     email_from = tools.email_normalize(msg_vals.get('email_from') or message.email_from)
            //     self.env['res.partner'].flush_model(['active', 'email', 'partner_share'])
            //     self.env['res.users'].flush_model(['notification_type', 'partner_id'])
            //     sql_query = SQL(
            //         """
            //         SELECT DISTINCT ON (partner.id) partner.id,
            //                partner.email_normalized,
            //                partner.lang,
            //                partner.name,
            //                partner.partner_share,
            //                users.id as uid,
            //                COALESCE(users.notification_type, 'email') as notif,
            //                COALESCE(users.share, FALSE) as ushare
            //           FROM res_partner partner
            //      LEFT JOIN res_users users on partner.id = users.partner_id
            //          WHERE partner.active IS TRUE
            //                AND partner.email != %(email)s
            //                AND partner.id IN %(partner_ids)s AND partner.id != %(author_id)s
            //         """,
            //         email=email_from or "",
            //         partner_ids=tuple(pids),
            //         author_id=author_id or 0,
            //     )
            //     self.env.cr.execute(sql_query)
            //     for partner_id, email_normalized, lang, name, partner_share, uid, notif, ushare in self.env.cr.fetchall():
            //         # ocn_client: will add partners to recipient recipient_data. more ocn notifications. We neeed to filter them maybe
            //         recipients_data.append({
            //             'active': True,
            //             'email_normalized': email_normalized,
            //             'id': partner_id,
            //             'is_follower': False,
            //             'groups': [],
            //             'lang': lang,
            //             'name': name,
            //             'notif': notif,
            //             'share': partner_share,
            //             'type': 'user' if not partner_share and notif else 'customer',
            //             'uid': uid,
            //             'ushare': ushare,
            //         })
            // 
            // domain = Domain.AND([
            //     [("channel_id", "=", self.id)],
            //     [("partner_id", "!=", author_id)],
            //     [("partner_id.active", "=", True)],
            //     [("mute_until_dt", "=", False)],
            //     [("partner_id.user_ids.manual_im_status", "!=", "busy")],
            //     Domain.OR([
            //         [("channel_id.channel_type", "!=", "channel")],
            //         Domain.AND([
            //             [("channel_id.channel_type", "=", "channel")],
            //             Domain.OR([
            //                 [("custom_notifications", "=", "all")],
            //                 Domain.AND([
            //                     [("custom_notifications", "=", False)],
            //                     [("partner_id.user_ids.res_users_settings_ids.channel_notifications", "=", "all")],
            //                 ]),
            //                 Domain.AND([
            //                     [("custom_notifications", "=", "mentions")],
            //                     [("partner_id", "in", pids)],
            //                 ]),
            //                 Domain.AND([
            //                     [("custom_notifications", "=", False)],
            //                     [("partner_id.user_ids.res_users_settings_ids.channel_notifications", "=", False)],
            //                     [("partner_id", "in", pids)],
            //                 ]),
            //             ]),
            //         ]),
            //     ]),
            // ])
            // # sudo: discuss.channel.member - read to get the members of the channel and res.users.settings of the partners
            // members = self.env["discuss.channel.member"].sudo().search(domain)
            // for member in members:
            //     recipients_data.append({
            //         "active": True,
            //         "id": member.partner_id.id,
            //         "is_follower": False,
            //         "groups": [],
            //         "lang": member.partner_id.lang,
            //         "notif": "web_push",
            //         "share": member.partner_id.partner_share,
            //         "type": "customer",
            //         "uid": False,
            //         "ushare": False,
            //     })
            // return recipients_data
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> NotifyThreadByWebPushInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_thread_by_web_push(self, message, recipients_data, msg_vals=False, **kwargs):
            // # only notify "web_push" recipients in discuss channels.
            // # exclude "inbox" recipients in discuss channels as inbox and web push can be mutually exclusive.
            // # the user can turn off the web push but receive notifs via inbox if they want to.
            // super()._notify_thread_by_web_push(message, [r for r in recipients_data if r["notif"] == "web_push"], msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_thread(self, message, msg_vals=False, **kwargs):
            // # link message to channel
            // rdata = super()._notify_thread(message, msg_vals=msg_vals, **kwargs)
            // payload = {"data": Store(bus_channel=self).add(message).get_result(), "id": self.id}
            // if temporary_id := self.env.context.get("temporary_id"):
            //     payload["temporary_id"] = temporary_id
            // if kwargs.get("silent"):
            //     payload["silent"] = True
            // self._bus_send("discuss.channel/new_message", payload)
            // return rdata
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def OPEN_STATES(self):
            // """ Return a list of the technical names complementing the CLOSED_STATES, a.k.a the open states """
            // return list(set(self._fields['state'].get_values(self.env)) - set(CLOSED_STATES))
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _on_change_available_in_pos(self):
            // for record in self:
            //     if not record.available_in_pos:
            //         record.self_order_available = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _onchange_available_in_pos(self):
            // if self.available_in_pos and not self.sale_ok:
            //     self.sale_ok = True
            */
            return default;
        }

        public async Task<TEntity> OnchangeBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _onchange_buy_route(self):
            // if self.purchase_ok:
            //     return
            // buy_routes = self.env['stock.rule'].search([
            //     ('action', '=', 'buy'),
            //     ('picking_type_id.code', '=', 'incoming'),
            //     ('active', '=', True),
            // ]).route_id
            // if any(route in self.route_ids._origin for route in buy_routes):
            //     return {'warning': {
            //         'title': self.env._('Warning!'),
            //         'message': self.env._(
            //             'This product has the "Buy" route checked but is not purchasable.'
            //         )
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_default_code(self):
            // if not self.default_code:
            //     return
            // 
            // domain = [('default_code', '=', self.default_code)]
            // if self.id.origin:
            //     domain.append(('id', '!=', self.id.origin))
            // 
            // if self.env['product.template'].search_count(domain, limit=1):
            //     return {'warning': {
            //         'title': _("Note:"),
            //         'message': _("The Internal Reference '%s' already exists.", self.default_code),
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_project_id(self):
            // if self.state != '04_waiting_normal':
            //     self.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _onchange_sale_ok(self):
            // if not self.sale_ok:
            //     self.available_in_pos = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_fields(self):
            // for record in self:
            //     if record.type == 'service' and record.service_type == 'timesheet' and \
            //        not (record._origin.service_policy and record.service_policy == record._origin.service_policy):
            //         record.uom_id = self.env.ref('uom.product_uom_hour')
            //     elif record._origin.uom_id:
            //         record.uom_id = record._origin.uom_id
            //     else:
            //         record.uom_id = self.default_get(['uom_id']).get('uom_id')
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_policy(self):
            // self._inverse_service_policy()
            // vals = self._get_onchange_service_policy_updates(self.service_tracking,
            //                                                 self.service_policy,
            //                                                 self.project_id,
            //                                                 self.project_template_id)
            // if vals:
            //     self.update(vals)
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _onchange_service_to_purchase(self):
            // products_template = self.filtered(lambda p: p.type != 'service' or p.expense_policy != 'no')
            // products_template.service_to_purchase = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _onchange_service_tracking(self):
            // if self.service_tracking == 'no':
            //     self.project_id = False
            //     self.project_template_id = False
            // elif self.service_tracking == 'task_global_project':
            //     self.project_template_id = False
            // elif self.service_tracking in ['task_in_project', 'project_only']:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_standard_price(self):
            // if self.standard_price < 0:
            //     raise ValidationError(_("The cost of a product can't be negative."))
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_task_company(self):
            // if self.project_id.company_id and self.project_id.company_id != self.company_id:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_tracking(self):
            // return self.mapped('product_variant_ids')._onchange_tracking()
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _onchange_type_event_booth(self):
            // if self.service_tracking == 'event_booth':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _onchange_type_event(self):
            // if self.service_tracking == 'event':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     self.taxes_id = False
            //     self.supplier_taxes_id = False
            // return super()._onchange_type()
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     if self.attribute_line_ids:
            //         raise UserError(_("Combo products can't have attributes."))
            //     combo_items = self.env['product.combo.item'].sudo().search([
            //         ('product_id', 'in', self.product_variant_ids.ids)
            //     ])
            //     if combo_items:
            //         raise UserError(_(
            //             "This product is part of a combo, so its type can't be changed to \"combo\"."
            //         ))
            //     self.purchase_ok = False
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _onchange_type(self):
            // res = super()._onchange_type()
            // if self._origin and self.sales_count > 0:
            //     res['warning'] = {
            //         'title': _("Warning"),
            //         'message': _("You cannot change the product's type because it is already used in sales orders.")
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_type(self):
            // # Return a warning when trying to change the product type
            // res = super()._onchange_type()
            // if self.ids and self.product_variant_ids.ids and self.env['stock.move.line'].sudo().search_count([
            //     ('product_id', 'in', self.product_variant_ids.ids), ('state', '!=', 'cancel')
            // ]):
            //     res['warning'] = {
            //         'title': _('Warning!'),
            //         'message': _(
            //             'This product has been used in at least one inventory movement. '
            //             'It is not advised to change the Product Type since it can lead to inconsistencies. '
            //             'A better solution could be to archive the product and create a new one instead.'
            //         )
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_uom_id(self):
            // if self._origin.uom_id == self.uom_id or not self.with_context(active_test=False).product_variant_ids._trigger_uom_warning():
            //     return
            // message = _(
            //     'Changing the unit of measure for your product will apply a conversion 1 %(old_uom_name)s = 1 %(new_uom_name)s.\n'
            //     'All existing records (Sales orders, Purchase orders, etc.) using this product will be updated by replacing the unit name.',
            //     old_uom_name=self._origin.uom_id.display_name, new_uom_name=self.uom_id.display_name)
            // return {
            //     'warning': {
            //         'title': _('What to expect ?'),
            //         'message': message,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def plan_task_in_calendar(self, vals):
            // self.ensure_one()
            // return self.write(vals)
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_get_parent_hash_token(self, pid):
            // return self.project_id._sign_token(pid)
            */
            return default;
        }

        public async Task<TEntity> PostCurrentChatbotStepMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _post_current_chatbot_step_message(self, chatbot_script_step):
            // posted_message = self.env['mail.message']
            // if chatbot_script_step and chatbot_script_step.message:
            //     posted_message = self._chatbot_post_message(chatbot_script_step.chatbot_script_id, chatbot_script_step.message)
            // return posted_message
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.invoice_policy == 'delivery' and self.type != 'consu':
            //     return _("Invoice after delivery, based on quantities delivered, not ordered.")
            // elif self.invoice_policy == 'order' and self.type == 'service':
            //     return _("Invoice ordered quantities as soon as this service is sold.")
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_milestones':
            //     return _("Invoice your milestones when they are reached.")
            // # ordered_prepaid and delivered_manual are handled in the super call, according to the
            // # corresponding value in the `invoice_policy` field (delivered/ordered quantities)
            // return super()._prepare_invoicing_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_timesheet':
            //     return _("Invoice based on timesheets (delivered quantity).")
            // return super()._prepare_invoicing_tooltip()
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event_booth':
            //     return _("Mark the selected Booth as Unavailable.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event':
            //     return _("Create an Attendee for the selected Event.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'task_global_project':
            //     return _("Create a task in an existing project to track the time spent.")
            // elif self.service_tracking == 'project_only':
            //     return _(
            //         "Create an empty project for the order to track the time spent."
            //     )
            // elif self.service_tracking == 'task_in_project':
            //     return _(
            //         "Create a project for the order with a task for each sales order line "
            //         "to track the time spent."
            //     )
            // elif self.service_tracking == 'no':
            //     return _(
            //         "Create projects or tasks later, and link them to order to track the time spent."
            //     )
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'course':
            //     return _("Grant access to the eLearning course linked to this product.")
            // return super()._prepare_service_tracking_tooltip()
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // self.ensure_one()
            // tooltip = ""
            // if self.type == 'combo':
            //     tooltip = _(
            //         "Combos allow to choose one product amongst a selection of choices per category."
            //     )
            // return tooltip
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // tooltip = super()._prepare_tooltip()
            // if not self.sale_ok:
            //     return tooltip
            // 
            // invoicing_tooltip = self._prepare_invoicing_tooltip()
            // 
            // tooltip = f'{tooltip} {invoicing_tooltip}' if tooltip else invoicing_tooltip
            // 
            // if self.type == 'service':
            //     additional_tooltip = self._prepare_service_tracking_tooltip()
            //     tooltip = f'{tooltip} {additional_tooltip}' if additional_tooltip else tooltip
            // 
            // return tooltip
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _prepare_variant_values(self, combination):
            // variant_dict = super()._prepare_variant_values(combination)
            // variant_dict['base_unit_count'] = self.base_unit_count
            // return variant_dict
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _price_compute(self, price_type, uom=None, currency=None, company=None, date=False):
            // company = company or self.env.company
            // date = date or fields.Date.context_today(self)
            // 
            // self = self.with_company(company)
            // if price_type == 'standard_price':
            //     # standard_price field can only be seen by users in base.group_user
            //     # Thus, in order to compute the sale price from the cost for users not in this group
            //     # We fetch the standard price as the superuser
            //     self = self.sudo()
            // 
            // prices = dict.fromkeys(self.ids, 0.0)
            // for template in self:
            //     price = template[price_type] or 0.0
            //     price_currency = template.currency_id
            //     if price_type == 'standard_price':
            //         if not price and template.product_variant_ids:
            //             price = template.product_variant_ids[0].standard_price
            //         price_currency = template.cost_currency_id
            //     elif price_type == 'list_price':
            //         price += template._get_attributes_extra_price()
            // 
            //     if uom:
            //         price = template.uom_id._compute_price(price, uom)
            // 
            //     # Convert from current user company currency to asked one
            //     # This is right cause a field cannot be in more than one currency
            //     if currency:
            //         price = price_currency._convert(price, currency, company, date)
            // 
            //     prices[template.id] = price
            // return prices
            */
            return default;
        }

        public async Task<TEntity> ProcessPosSelfUiProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _process_pos_self_ui_products(self, products):
            // self._add_archived_combinations(products)
            // for product in products:
            //     product['image_128'] = bool(product['image_128'])
            */
            return default;
        }

        public async Task<TEntity> ProcessPosUiProductProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, Guid config_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _process_pos_ui_product_product(self, products, config_id):
            // 
            // def filter_taxes_on_company(product_taxes, taxes_by_company):
            //     """
            //     Filter the list of tax ids on a single company starting from the current one.
            //     If there is no tax in the result, it's filtered on the parent company and so
            //     on until a non empty result is found.
            //     """
            //     taxes, comp = None, self.env.company
            //     while not taxes and comp:
            //         taxes = list(set(product_taxes) & set(taxes_by_company[comp.id]))
            //         comp = comp.parent_id
            //     return taxes
            // 
            // taxes = self.env['account.tax'].search(self.env['account.tax']._check_company_domain(self.env.company))
            // # group all taxes by company in a dict where:
            // # - key: ID of the company
            // # - values: list of tax ids
            // taxes_by_company = defaultdict(set)
            // if self.env.company.parent_id:
            //     for tax in taxes:
            //         taxes_by_company[tax.company_id.id].add(tax.id)
            // 
            // different_currency = config_id.currency_id != self.env.company.currency_id
            // 
            // self._add_archived_combinations(products)
            // for product in products:
            //     if different_currency:
            //         product['list_price'] = self.env.company.currency_id._convert(product['list_price'], config_id.currency_id, self.env.company, fields.Date.today())
            //         product['standard_price'] = self.env.company.currency_id._convert(product['standard_price'], config_id.currency_id, self.env.company, fields.Date.today())
            // 
            //     product['image_128'] = bool(product['image_128'])
            // 
            //     if len(taxes_by_company) > 1 and len(product['taxes_id']) > 1:
            //         product['taxes_id'] = filter_taxes_on_company(product['taxes_id'], taxes_by_company)
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_apply_get_default_subtype_id(self):
            // return self.env['ir.model.data']._xmlid_to_res_id("project.mt_task_rating")
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _rating_domain(self):
            // """ Returns a normalized domain on rating.rating to select the records to
            //     include in count, avg, ... computation of current model.
            // """
            // return Domain([('res_model', '=', self._name), ('res_id', 'in', self.ids), ('consumed', '=', True)])
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // return super()._rating_domain() & Domain('is_internal', '=', False)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // return super()._rating_domain() & Domain('is_internal', '=', False)
            */
            return default;
        }

        public async Task<TEntity> RatingGetGradesAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def rating_get_grades(self, domain=None):
            // """ Get the repartitions of rating grade for the given res_ids.
            // :param domain: Optional domain of the rating to include/exclude
            //     in the grades computation.
            // :returns: A dictionary where the key is the rating and the value
            //     is the count of unique ``(res_model, res_id)`` pairs whose
            //     grades are associated with that rating.
            // 
            //     The rates are:
            // 
            //     * ``"great"``, graded between 70 and 100
            //     * ``"okay"``, graded between 31 and 69
            //     * ``"bad"``, graded between 0 and 30
            // :rtype: dict[typing.Literal["great", "okay", "bad"], int]
            // """
            // data = self._rating_get_repartition(domain=domain)
            // res = dict.fromkeys(['great', 'okay', 'bad'], 0)
            // for key in data:
            //     grade = rating_data._rating_to_grade(key)
            //     res[grade] += data[key]
            // return res
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'livechat_channel_id'
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'project_id'
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _rating_get_parent_field_name(self):
            // """Return the parent relation field name. Should return a Many2One"""
            // return None
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> RatingGetRepartitionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object add_stats, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _rating_get_repartition(self, add_stats=False, domain=None):
            // """ get the repatition of rating grade for the given res_ids.
            //     :param add_stats : flag to add stat to the result
            //     :type add_stats : boolean
            //     :param domain : optional extra domain of the rating to include/exclude in repartition
            //     :return dictionnary
            //         if not add_stats, the dict is like
            //             - key is the rating value (integer)
            //             - value is the number of object (res_model, res_id) having the value
            //         otherwise, key is the value of the information (string) : either stat name (avg, total, ...) or 'repartition'
            //         containing the same dict if add_stats was False.
            // """
            // base_domain = self._rating_domain() & Domain('rating', '>=', 1)
            // if domain:
            //     base_domain &= Domain(domain)
            // rg_data = self.env['rating.rating']._read_group(base_domain, ['rating'], ['__count'])
            // # init dict with all possible rate value, except 0 (no value for the rating)
            // values = dict.fromkeys(range(1, 6), 0)
            // for rating, count in rg_data:
            //     rating_val_round = float_round(rating, precision_digits=1)
            //     values[rating_val_round] = values.get(rating_val_round, 0) + count
            // # add other stats
            // if add_stats:
            //     rating_number = sum(values.values())
            //     return {
            //         'repartition': values,
            //         'avg': sum(float(key * values[key]) for key in values) / rating_number if rating_number > 0 else 0,
            //         'total': sum(count for __, count in rg_data),
            //     }
            // return values
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def rating_get_stats(self, domain=None):
            // """Get the statistics of the rating repartitions
            // 
            // :param domain : optional domain of the rating to include/exclude in statistic computation
            // :returns: A dictionnary where:
            // 
            //     - key is the name of the information (stat name)
            //     - value is statistic value : 'percent' contains the repartition in percentage, 'avg' is the average rate
            //       and 'total' is the number of rating
            // """
            // data = self._rating_get_repartition(domain=domain, add_stats=True)
            // result = {
            //     'avg': data['avg'],
            //     'total': data['total'],
            //     'percent': dict.fromkeys(range(1, 6), 0),
            // }
            // for rate in data['repartition']:
            //     result['percent'][rate] = (data['repartition'][rate] * 100) / data['total'] if data['total'] > 0 else 0
            // return result
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsPerRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _rating_get_stats_per_record(self, domain=None):
            // """
            // Computes rating statistics for each record individually.
            // 
            // :param domain: Optional domain to apply on the ratings.
            // :return: A dictionary mapping each record ID to its statistics dictionary.
            // :rtype: dict
            // """
            // base_domain = self._rating_domain() & Domain("rating", ">=", 1)
            // if domain:
            //     base_domain &= Domain(domain)
            // rg_data = self.env["rating.rating"]._read_group(
            //     base_domain,
            //     groupby=["res_id", "rating"],
            //     aggregates=["__count"],
            // )
            // stats_per_record = defaultdict(
            //     lambda: {"total": 0, "weighted_sum": 0.0, "counts": defaultdict(int), "percent": {}}
            // )
            // for res_id, rating, count in rg_data:
            //     stats = stats_per_record[res_id]
            //     stats["total"] += count
            //     stats["weighted_sum"] += rating * count
            //     stats["counts"][int(rating)] = count
            // for stats in stats_per_record.values():
            //     total = stats["total"]
            //     if total > 0:
            //         stats["avg"] = stats["weighted_sum"] / total
            //         stats["percent"] = {
            //             rate: (stats["counts"].get(rate, 0) * 100) / total for rate in range(1, 6)
            //         }
            //     else:
            //         stats["avg"] = 0
            //         stats["percent"] = dict.fromkeys(range(1, 6), 0.0)
            //     del stats["weighted_sum"]
            //     del stats["counts"]
            // return stats_per_record
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _read_group_categ_id(self, categories, domain):
            // category_ids = self.env.context.get('default_categ_id')
            // if not category_ids and self.env.context.get('group_expand'):
            //     category_ids = categories.sudo()._search([], order=categories._order)
            // return categories.browse(category_ids)
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IRatingMixinable
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
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_personal_stage_type_ids(self, stages, domain):
            // return stages.search(['|', ('id', 'in', stages.ids), ('user_id', '=', self.env.user.id)])
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _remove_membership(self, partner_ids):
            // """ Karma earned during course progress is kept upon membership removal.
            // This is done because re-joining the course will not allow you to gain the karma again,
            // as we keep your progress """
            // if not partner_ids:
            //     raise ValueError("Do not use this method with an empty partner_id recordset")
            // 
            // removed_channel_partner_domain = Domain.OR(
            //     Domain('partner_id', 'in', partner_ids)
            //     & Domain('channel_id', '=', channel.id)
            //     for channel in self
            // )
            // 
            // self.message_unsubscribe(partner_ids=partner_ids)
            // if self:
            //     removed_channel_partner = self.env['slide.channel.partner'].sudo().search(removed_channel_partner_domain)
            //     if removed_channel_partner:
            //         removed_channel_partner.action_archive()
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _resequence_slides(self, slide, force_category=False):
            // ids_to_resequence = self.slide_ids.ids
            // index_of_added_slide = ids_to_resequence.index(slide.id)
            // next_category_id = None
            // if self.slide_category_ids:
            //     force_category_id = force_category.id if force_category else slide.category_id.id
            //     index_of_category = self.slide_category_ids.ids.index(force_category_id) if force_category_id else None
            //     if index_of_category is None:
            //         next_category_id = self.slide_category_ids.ids[0]
            //     elif index_of_category < len(self.slide_category_ids.ids) - 1:
            //         next_category_id = self.slide_category_ids.ids[index_of_category + 1]
            // 
            // if next_category_id:
            //     added_slide_id = ids_to_resequence.pop(index_of_added_slide)
            //     index_of_next_category = ids_to_resequence.index(next_category_id)
            //     ids_to_resequence.insert(index_of_next_category, added_slide_id)
            //     for i, record in enumerate(self.env['slide.slide'].browse(ids_to_resequence)):
            //         record.write({'sequence': i + 1})  # start at 1 to make people scream
            // else:
            //     slide.write({
            //         'sequence': self.env['slide.slide'].browse(ids_to_resequence[-1]).sequence + 1
            //     })
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> RtcCancelInvitationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _rtc_cancel_invitations(self, member_ids=None):
            // """ Cancels the invitations of the RTC call from all invited members,
            //     if member_ids is provided, only the invitations of the specified members are canceled.
            // 
            //     :param list member_ids: list of the members ids from which the invitation has to be removed
            // """
            // self.ensure_one()
            // channel_member_domain = Domain([
            //     ('channel_id', '=', self.id),
            //     ('rtc_inviting_session_id', '!=', False),
            // ])
            // if member_ids:
            //     channel_member_domain &= Domain('id', 'in', member_ids)
            // members = self.env['discuss.channel.member'].search(channel_member_domain)
            // members.rtc_inviting_session_id = False
            // if members:
            //     Store(bus_channel=self).add(
            //         self,
            //         {
            //             "invited_member_ids": Store.Many(
            //                 members,
            //                 [
            //                     Store.One("channel_id", [], as_thread=True),
            //                     *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //                 ],
            //                 mode="DELETE",
            //             ),
            //         },
            //     ).bus_send()
            //     devices, private_key, public_key = self._web_push_get_partners_parameters(members.partner_id.ids)
            //     if devices:
            //         self._web_push_send_notification(devices, private_key, public_key, payload={
            //             "title": "",
            //             "options": {
            //                 "data": {
            //                     "type": PUSH_NOTIFICATION_TYPE.CANCEL
            //                 },
            //                 "tag": self._get_call_notification_tag(),
            //             }
            //         })
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_barcode(self, operator, value):
            // subquery = self.with_context(active_test=False)._search([
            //     ('product_variant_ids.barcode', operator, value),
            // ])
            // return [('id', 'in', subquery)]
            */
            return default;
        }

        public async Task<TEntity> SearchChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _search_channel_partner_ids(self, operator, operand):
            // return [('channel_member_ids', 'any', [('partner_id', operator, operand)])]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_display_name(self, operator, value):
            // domain = super()._search_display_name(operator, value)
            // if self.env.context.get('search_product_product', bool(value)):
            //     if operator in Domain.NEGATIVE_OPERATORS:
            //         domain = Domain.AND([domain, [('product_variant_ids', operator, value)]])
            //     else:
            //         query = SQL(
            //             """((%s) UNION ALL (%s))""",
            //             self._search(domain).select(),
            //             self._search([("product_variant_ids", operator, value)]).select(),
            //         )
            //         domain = [('id', 'in', query)]
            // return domain
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_image = options['displayImage']
            // with_description = options['displayDescription']
            // with_category = options['displayExtraLink']
            // with_price = options['displayDetail']
            // domains = [website.sale_product_domain()]
            // category = options.get('category')
            // tags = options.get('tags')
            // min_price = options.get('min_price')
            // max_price = options.get('max_price')
            // attribute_value_dict = options.get('attribute_value_dict')
            // if category:
            //     domains.append([('public_categ_ids', 'child_of', self.env['ir.http']._unslug(category)[1])])
            // if tags:
            //     if isinstance(tags, str):
            //         tags = tags.split(',')
            //     tags = list(map(int, tags))  # Convert list of strings to list of integers
            //     domains.append(Domain.OR([
            //         Domain('product_tag_ids', 'in', tags),
            //         Domain('product_variant_ids.additional_product_tag_ids', 'in', tags),
            //     ]))
            // if min_price:
            //     domains.append([('list_price', '>=', min_price)])
            // if max_price:
            //     domains.append([('list_price', '<=', max_price)])
            // if attribute_value_dict:
            //     domains.extend(self._get_attribute_value_domain(attribute_value_dict))
            // search_fields = ['name', 'default_code', 'variants_default_code']
            // fetch_fields = ['id', 'name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'default_code': {'name': 'default_code', 'type': 'text', 'match': True},
            //     'product_variant_ids.default_code': {'name': 'product_variant_ids.default_code', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_image:
            //     mapping['image_url'] = {'name': 'image_url', 'type': 'html'}
            // if with_description:
            //     # Internal note is not part of the rendering.
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     search_fields.append('description_sale')
            //     fetch_fields.append('description_sale')
            //     mapping['description'] = {'name': 'description_sale', 'type': 'text', 'match': True}
            // if with_price:
            //     mapping['detail'] = {'name': 'price', 'type': 'html', 'display_currency': options['display_currency']}
            //     mapping['detail_strike'] = {'name': 'list_price', 'type': 'html', 'display_currency': options['display_currency']}
            // if with_category:
            //     mapping['extra_link'] = {'name': 'category', 'type': 'html'}
            // return {
            //     'model': 'product.template',
            //     'base_domain': domains,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-shopping-cart',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // my = options.get('my')
            // search_tags = options.get('tag')
            // slide_category = options.get('slide_category')
            // domain = [website.website_domain(), [('is_visible', '=', True)]]
            // if my:
            //     domain.append([('is_member', '=', True)])
            // if search_tags:
            //     ChannelTag = self.env['slide.channel.tag']
            //     try:
            //         tag_ids = list(filter(None, [self.env['ir.http']._unslug(tag)[1] for tag in search_tags.split(',')]))
            //         tags = ChannelTag.search([('id', 'in', tag_ids)]) if tag_ids else ChannelTag
            //     except Exception:
            //         tags = ChannelTag
            //     # Group by group_id
            //     # OR inside a group, AND between groups.
            //     for tags_ in tags.grouped('group_id').values():
            //         domain.append([('tag_ids', 'in', tags_.ids)])
            // if slide_category and 'nbr_%s' % slide_category in self:
            //     domain.append([('nbr_%s' % slide_category, '>', 0)])
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('description_short')
            //     fetch_fields.append('description_short')
            //     mapping['description'] = {'name': 'description_short', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('slide_last_update')
            //     mapping['detail'] = {'name': 'slide_last_update', 'type': 'date'}
            // return {
            //     'model': 'slide.channel',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-graduation-cap',
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_incoming_qty(self, operator, value):
            // domain = [('incoming_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('active', '=', True)])
            // return [('id', 'in', bom_tmpl_query.subselect('product_tmpl_id'))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member_channel_ids(self, invited=False):
            // return self.env['slide.channel.partner'].sudo()._read_group(
            //     [('partner_id', '=', self.env.user.partner_id.id), ('member_status', '=' if invited else '!=', 'invited'), ('active', '=', True)],
            //     aggregates=['channel_id:array_agg']
            // )[0][0]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('id', 'in', self._search_is_member_channel_ids())]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member_invited(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('id', 'in', self._search_is_member_channel_ids(invited=True))]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_visible(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [
            //     '|', ('is_member', '=', True),
            //     ('visibility', 'in', ['public'] if self.env.user._is_public() else ['public', 'connected']),
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatAgentHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_agent_history_ids(self, operator, value):
            // if operator not in ("any", "in"):
            //     return NotImplemented
            // if operator == "in" and len(value) == 1 and not next(iter(value)):
            //     return [
            //         (
            //             "id",
            //             "not in",
            //             self.env["im_livechat.channel.member.history"]
            //             ._search([("livechat_member_type", "=", "agent")])
            //             .subselect("channel_id"),
            //         ),
            //     ]
            // query = (
            //     self.env["im_livechat.channel.member.history"]._search(value)
            //     if isinstance(value, fields.Domain)
            //     else value
            // )
            // agent_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "agent"),
            //         ("id", "in", query),
            //     ],
            // )
            // return [("id", "in", agent_history_query.subselect("channel_id"))]
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatBotHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_bot_history_ids(self, operator, value):
            // if operator != "in":
            //     return NotImplemented
            // bot_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "bot"),
            //         ("id", "in", value),
            //     ],
            // )
            // return [("id", "in", bot_history_query.subselect("channel_id"))]
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatCustomerHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_customer_history_ids(self, operator, value):
            // if operator != "in":
            //     return NotImplemented
            // customer_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "visitor"),
            //         ("id", "in", value),
            //     ],
            // )
            // return [("id", "in", customer_history_query.subselect("channel_id"))]
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatMatchesSelfExpertiseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_matches_self_expertise(self, operator, value):
            // if operator != "in" or value not in ({True}, {False}):
            //     return NotImplemented
            // operator = "in" if value == {True} else "not in"
            // return [("livechat_expertise_ids", operator, self.env.user.livechat_expertise_ids.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatMatchesSelfLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_matches_self_lang(self, operator, value):
            // if operator != "in" or value not in ({True}, {False}):
            //     return NotImplemented
            // operator = "in" if value == {True} else "not in"
            // lang_codes = self.env.user.livechat_lang_ids.mapped("code")
            // lang_codes.append(self.env.user.lang)
            // return [("livechat_lang_id.code", operator, lang_codes)]
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_outgoing_qty(self, operator, value):
            // domain = [('outgoing_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_partner_ids(self, operator, value):
            // return [(
            //     'channel_partner_ids', 'in', self.env['slide.channel.partner'].sudo()._search(
            //         [('partner_id', operator, value),
            //          ('active', '=', True),
            //          ('member_status', '!=', 'invited')],
            //     )
            // )]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available(self, operator, value):
            // domain = [('qty_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def _search_rating_avg(self, operator, value):
            // op = rating_data.OPERATOR_MAPPING.get(operator)
            // if not op:
            //     return NotImplemented
            // rating_read_group = self.env['rating.rating'].sudo()._read_group(
            //     [('res_model', '=', self._name), ('consumed', '=', True), ('rating', '>=', rating_data.RATING_LIMIT_MIN)],
            //     ['res_id'], ['rating:avg'])
            // res_ids = [
            //     res_id
            //     for res_id, rating_avg in rating_read_group
            //     if op(float_compare(rating_avg, value, 2), 0)
            // ]
            // return [('id', 'in', res_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_image = 'image_url' in mapping
            // with_category = 'extra_link' in mapping
            // with_price = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // current_website = self.env['website'].get_current_website()
            // for product, data in zip(self, results_data):
            //     categ_ids = product.public_categ_ids.filtered(lambda c: not c.website_id or c.website_id == current_website)
            //     if with_price:
            //         combination_info = product._get_combination_info(only_template=True)
            //         data['price'], list_price = self._search_render_results_prices(
            //             mapping, combination_info
            //         )
            //         if list_price:
            //             data['list_price'] = list_price
            // 
            //     if with_image:
            //         data['image_url'] = '/web/image/product.template/%s/image_128' % data['id']
            //     if with_category and categ_ids:
            //         data['category'] = self.env['ir.ui.view'].sudo()._render_template(
            //             "website_sale.product_category_extra_link",
            //             {
            //                 'categories': categ_ids,
            //                 'slug': self.env['ir.http']._slug,
            //                 'shop_path': SHOP_PATH,
            //             }
            //         )
            // return results_data
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results_prices(self, mapping, combination_info):
            // if combination_info.get('prevent_zero_price_sale'):
            //     return None, None
            // 
            // monetary_options = {'display_currency': mapping['detail']['display_currency']}
            // price = self.env['ir.qweb.field.monetary'].value_to_html(
            //     combination_info['price'], monetary_options
            // )
            // list_price = None
            // if combination_info['has_discounted_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['list_price'], monetary_options
            //     )
            // if combination_info.get('compare_list_price'):
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['compare_list_price'], monetary_options
            //     )
            // 
            // return price, list_price
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_standard_price(self, operator, value):
            // return [('product_variant_ids.standard_price', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _search_valuation(self, operator, value):
            // if operator != '=':
            //     raise UserError(self.env._("You can only use the '=' operator to search on valuation field."))
            // if value not in ['periodic', 'real_time']:
            //     raise UserError(self.env._("Only the value 'periodic' and 'real_time' are accepted to search on valuation field."))
            // domain_categ = Domain([('categ_id.property_valuation', operator, value)])
            // domain_company = Domain(['|', ('categ_id.property_valuation', '=', False), ('categ_id', '=', False), ('company_id.inventory_valuation', operator, value)])
            // return domain_company | domain_categ
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_virtual_available(self, operator, value):
            // domain = [('virtual_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = [
            //     # (service_policy, string)
            //     ('ordered_prepaid', _('Prepaid/Fixed Price')),
            //     ('delivered_manual', _('Based on Delivered Quantity (Manual)')),
            // ]
            // 
            // if self.env['res.groups']._is_feature_enabled('project.group_project_milestone'):
            //     service_policies.insert(1, ('delivered_milestones', _('Based on Milestones')))
            // return service_policies
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = super()._selection_service_policy()
            // service_policies.insert(1, ('delivered_timesheet', _('Based on Timesheets')))
            // return service_policies
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _send_share_email(self, emails):
            // """ Share channel through emails."""
            // courses_without_templates = self.filtered(lambda channel: not channel.share_channel_template_id)
            // if courses_without_templates:
            //     raise UserError(_('Impossible to send emails. Select a "Channel Share Template" for courses %(course_names)s first',
            //                          course_names=', '.join(courses_without_templates.mapped('name'))))
            // mail_ids = []
            // for record in self:
            //     template = record.share_channel_template_id.with_context(
            //         user=self.env.user,
            //         email=emails,
            //         base_url=record.get_base_url(),
            //     )
            //     email_values = {'email_to': emails}
            //     if self.env.user._is_portal():
            //         template = template.sudo()
            //         email_values['email_from'] = self.env.company.catchall_formatted or self.env.company.email_formatted
            // 
            //     mail_ids.append(template.send_mail(record.id, email_layout_xmlid='mail.mail_notification_light', email_values=email_values))
            // return mail_ids
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event_booth']
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self) -> list:
            // """ Service tracking field is used to distinguish some specific categories of products.
            // Those products shouldn't be displayed or used in unrelated applications.
            // This method returns a domain targeting all those specific products (events, courses, ...).
            // """
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['course']
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_barcode(self):
            // self._set_product_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_count(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_count = template.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_id(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_id = template.base_unit_id
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_default_code(self):
            // self._set_product_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> SetMessagePinAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id, object pinned) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def set_message_pin(self, message_id, pinned):
            // """ (Un)pin a message on the channel and send a notification to the
            // members.
            // :param message_id: id of the message to be pinned.
            // :param pinned: whether the message should be pinned or unpinned.
            // """
            // self.ensure_one()
            // message_to_update = self.env['mail.message'].search([
            //     ['id', '=', message_id],
            //     ['model', '=', 'discuss.channel'],
            //     ['res_id', '=', self.id],
            //     ['pinned_at', '=' if pinned else '!=', False]
            // ])
            // if not message_to_update:
            //     return
            // message_to_update.flush_recordset(['pinned_at'])
            // # Use SQL because by calling write method, write_date is going to be updated, but we don't want pin/unpin
            // # a message changes the write_date
            // self.env.cr.execute("UPDATE mail_message SET pinned_at=%s WHERE id=%s",
            //                     (fields.Datetime.now() if pinned else None, message_to_update.id))
            // message_to_update.invalidate_recordset(['pinned_at'])
            // 
            // Store(bus_channel=self).add(message_to_update, "pinned_at").bus_send()
            // if pinned:
            //     notification_text = '''
            //         <div data-oe-type="pin" class="o_mail_notification">
            //             %(user_pinned_a_message_to_this_channel)s
            //             <a href="#" data-oe-type="pin-menu">%(see_all_pins)s</a>
            //         </div>
            //     '''
            //     notification = Markup(notification_text) % {
            //         'user_pinned_a_message_to_this_channel': Markup('<a href="#" data-oe-type="highlight" data-oe-id="%s">%s</a>') % (
            //             message_id,
            //             _('%(user_name)s pinned a message to this channel.', user_name=self.self_member_id._get_html_link_title()),
            //         ),
            //         'see_all_pins': _('See all pinned messages.'),
            //     }
            //     self.message_post(body=notification, message_type="notification", subtype_xmlid="mail.mt_comment")
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_product_variant_field(self, fname):
            // """Propagate the value of the given field from the templates to their unique variant.
            // 
            // Only if it's a single variant product.
            // It's used to set fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field whose value should be propagated to the variant.
            //     (field name must be identical between product.product & product.template models)
            // """
            // for template in self:
            //     count = len(template.product_variant_ids)
            //     if count == 1:
            //         template.product_variant_ids[fname] = template[fname]
            //     elif count == 0:
            //         archived_variants = self.with_context(active_test=False).product_variant_ids
            //         if len(archived_variants) == 1:
            //             archived_variants[fname] = template[fname]
            */
            return default;
        }

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_bottom(self):
            // max_sequence = self.sudo().search([], order='website_sequence DESC', limit=1)
            // self.website_sequence = max_sequence.website_sequence + 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_down(self):
            // next_prodcut_tmpl = self.search([
            //     ('website_sequence', '>', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence ASC', limit=1)
            // if next_prodcut_tmpl:
            //     next_prodcut_tmpl.website_sequence, self.website_sequence = self.website_sequence, next_prodcut_tmpl.website_sequence
            // else:
            //     return self.set_sequence_bottom()
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_top(self):
            // min_sequence = self.sudo().search([], order='website_sequence ASC', limit=1)
            // self.website_sequence = min_sequence.website_sequence - 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_up(self):
            // previous_product_tmpl = self.sudo().search([
            //     ('website_sequence', '<', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence DESC', limit=1)
            // if previous_product_tmpl:
            //     previous_product_tmpl.website_sequence, self.website_sequence = self.website_sequence, previous_product_tmpl.website_sequence
            // else:
            //     self.set_sequence_top()
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_standard_price(self):
            // self._set_product_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_volume(self):
            // self._set_product_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_weight(self):
            // self._set_product_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> ShouldInviteMembersToJoinCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: discuss_channel.py) ---
            // def _should_invite_members_to_join_call(self):
            // if self.calendar_event_ids:
            //     return False
            // return super()._should_invite_members_to_join_call()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _should_invite_members_to_join_call(self):
            // self.ensure_one()
            // return len(self.rtc_session_ids) == 1 and self.channel_type != "channel"
            */
            return default;
        }

        public async Task<TEntity> ShouldOpenProductQuantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _should_open_product_quants(self):
            // return super()._should_open_product_quants() or self.is_kits
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _should_open_product_quants(self):
            // self.ensure_one()
            // advanced_option_groups = [
            //     'stock.group_stock_multi_locations',
            //     'stock.group_tracking_owner',
            //     'stock.group_tracking_lot',
            // ]
            // return (
            //     any(self.env.user.has_group(g) for g in advanced_option_groups)
            //     or self.tracking != "none"
            // )
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> StoreLivechatOperatorIdFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _store_livechat_operator_id_fields(self):
            // """Return the standard fields to include in Store for livechat_operator_id."""
            // return ["avatar_128", *self.env["res.partner"]._get_store_livechat_username_fields()]
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyGetMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically_get_members(self):
            // """ Auto-subscribe members of a department to a channel """
            // new_members = super()._subscribe_users_automatically_get_members()
            // for channel in self:
            //     new_members[channel.id] = list(
            //         set(new_members[channel.id]) |
            //         set((channel.subscription_department_ids.member_ids.user_id.partner_id.filtered(lambda p: p.active) - channel.channel_partner_ids).ids)
            //     )
            // return new_members
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically_get_members(self):
            // """ Return new members per channel ID """
            // return dict(
            //     (channel.id,
            //      ((channel.group_ids.all_user_ids.partner_id.filtered(lambda p: p.active) - channel.channel_partner_ids).ids))
            //         for channel in self
            //     )
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically(self):
            // if not (new_members_to_create := self._subscribe_users_automatically_get_members()):
            //     return
            // to_create = [
            //     {"channel_id": channel_id, "partner_id": partner_id}
            //     for channel_id in new_members_to_create
            //     for partner_id in new_members_to_create[channel_id]
            // ]
            // # sudo: discuss.channel.member - adding member of other users based on channel auto-subscribe
            // new_members = self.env["discuss.channel.member"].sudo().create(to_create)
            // notifications = defaultdict(lambda: self.env["discuss.channel.member"])
            // for member in new_members:
            //     bus_channel = member._bus_channel()
            //     notifications[bus_channel] |= member
            // for bus_channel, members in notifications.items():
            //     members = members.with_prefetch(new_members.ids)
            //     Store(bus_channel=bus_channel).add(members.channel_id).add(
            //         members,
            //         [
            //             Store.One("channel_id", [], as_thread=True),
            //             *self.env["discuss.channel.member"]._to_store_persona(),
            //             "unpin_dt",
            //         ],
            //     ).bus_send()
            */
            return default;
        }

        public async Task<TEntity> SyncFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _sync_field_names(self):
            // field_names = super()._sync_field_names()
            // field_names[None].append(
            //     Store.One(
            //         "livechat_operator_id",
            //         self.env["discuss.channel"]._store_livechat_operator_id_fields(),
            //         predicate=is_livechat_channel,
            //     ),
            // )
            // field_names["internal_users"].extend(
            //     [
            //         Store.Attr("description", predicate=is_livechat_channel),
            //         Store.Attr("livechat_note", predicate=is_livechat_channel),
            //         Store.Attr("livechat_status", predicate=is_livechat_channel),
            //         Store.Many("livechat_expertise_ids", ["name"], predicate=is_livechat_channel),
            //         # sudo: internal users having access to the channel can read its tags
            //         Store.Many(
            //             "livechat_conversation_tag_ids",
            //             ["name", "color"],
            //             predicate=is_livechat_channel,
            //             sudo=True,
            //         ),
            //     ],
            // )
            // return field_names
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return PROJECT_TASK_READABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_WRITABLE_FIELDS(self):
            // return PROJECT_TASK_WRITABLE_FIELDS
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IRatingMixinable
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

        public async Task<TEntity> ToMarkupDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _to_markup_data(self, website):
            // """ Generate JSON-LD markup data for the current product template.
            // 
            // If the template has multiple variants, the https://schema.org/ProductGroup schema is used.
            // Otherwise, the markup data generation is delegated to the variant to use the
            // https://schema.org/Product schema.
            // 
            // :param website website: The current website.
            // :return: The JSON-LD markup data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // if self.product_variant_count == 1:
            //     return self.product_variant_id._to_markup_data(website)
            // 
            // # perf: temporal solution to avoid slowness when product have many variants and pricelist rules
            // limit = self.env['ir.config_parameter'].sudo().get_param('website_sale.markup_data_limit_variants', False)
            // if limit:
            //     product_variant_ids = self.product_variant_ids[:int(limit)]
            // else:
            //     product_variant_ids = self.product_variant_ids
            // 
            // base_url = website.get_base_url()
            // markup_data = {
            //     '@context': 'https://schema.org/',
            //     '@type': 'ProductGroup',
            //     'name': self.name,
            //     'image': f'{base_url}{website.image_url(self, "image_1920")}',
            //     'url': f'{base_url}{self.website_url}',
            //     'hasVariant': [product._to_markup_data(website) for product in product_variant_ids]
            // }
            // if self.description_ecommerce:
            //     markup_data['description'] = text_from_html(self.description_ecommerce)
            // return markup_data
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _to_store_defaults(self, target: Store.Target):
            // fields = [
            //     "chatbot_current_step",
            //     Store.One("country_id", ["code", "name"], predicate=is_livechat_channel),
            //     Store.Attr("livechat_end_dt", predicate=is_livechat_channel),
            //     # sudo - res.partner: accessing livechat operator is allowed
            //     Store.One(
            //         "livechat_operator_id",
            //         self.env["discuss.channel"]._store_livechat_operator_id_fields(),
            //         predicate=is_livechat_channel,
            //         sudo=True,
            //     ),
            // ]
            // if target.is_internal(self.env):
            //     fields.append(
            //         Store.One(
            //             "livechat_channel_id", ["name"], predicate=is_livechat_channel, sudo=True
            //         )
            //     )
            //     fields.extend(
            //         [
            //             Store.Attr("description", predicate=is_livechat_channel),
            //             Store.Attr("livechat_note", predicate=is_livechat_channel),
            //             Store.Attr("livechat_outcome", predicate=is_livechat_channel),
            //             Store.Attr("livechat_status", predicate=is_livechat_channel),
            //             Store.Many("livechat_expertise_ids", ["name"], predicate=is_livechat_channel),
            //             # sudo: internal users having access to the channel can read its tags
            //             Store.Many(
            //                 "livechat_conversation_tag_ids",
            //                 ["name", "color"],
            //                 predicate=is_livechat_channel,
            //                 sudo=True,
            //             ),
            //         ],
            //     )
            // return super()._to_store_defaults(target) + fields
            */
            return default;
        }

        public async Task<TEntity> ToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store, fields):
            // """Extends the channel header by adding the livechat operator and the 'anonymous' profile"""
            // super()._to_store(store, [f for f in fields if f != "chatbot_current_step"])
            // if "chatbot_current_step" not in fields:
            //     return
            // lang = self.env["chatbot.script"]._get_chatbot_language()
            // for channel in self.filtered(lambda channel: channel.chatbot_current_step_id):
            //     # sudo: chatbot.script.step - returning the current script/step of the channel
            //     current_step_sudo = channel.chatbot_current_step_id.sudo().with_context(lang=lang)
            //     chatbot_script = current_step_sudo.chatbot_script_id
            //     step_message = self.env["chatbot.message"]
            //     if not current_step_sudo.is_forward_operator:
            //         step_message = channel.sudo().chatbot_message_ids.filtered(
            //             lambda m: m.script_step_id == current_step_sudo
            //             and m.mail_message_id.author_id == chatbot_script.operator_partner_id
            //         )[:1]
            //     current_step = {
            //         "scriptStep": current_step_sudo.id,
            //         "message": step_message.mail_message_id.id,
            //         "operatorFound": current_step_sudo.is_forward_operator
            //         and channel.livechat_operator_id != chatbot_script.operator_partner_id,
            //     }
            //     store.add(current_step_sudo)
            //     store.add(chatbot_script)
            //     chatbot_data = {
            //         "script": chatbot_script.id,
            //         "steps": [current_step],
            //         "currentStep": current_step,
            //     }
            //     store.add(channel, {"chatbot": chatbot_data})
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
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

        public async Task<TEntity> TypesAllowingSeenInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _types_allowing_seen_infos(self):
            // return super()._types_allowing_seen_infos() + ["livechat"]
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _types_allowing_unfollow(self):
            // return super()._types_allowing_unfollow() + ["livechat"]
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def unlink(self):
            // # Add subtasks to batch of tasks to delete
            // self |= self._get_all_subtasks()
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // for task in self:
            //     if task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id):
            //         task.recurrence_id.unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def unlink(self):
            // """" Necessary override to avoid cache issues in the ORM.
            // This signals the ORM to remove slides first to avoid having the SQL cascade the deletion,
            // which attempts to recompute slide statistics of removed slides and creates a cache failure.
            // 
            // Indeed, slides statistics are computed using a read_group which will try to flush the records
            // first and fail with a "Could not find all values of slide.slide.category_id to flush them".
            // (Fix suggested by the ORM team).
            // 
            // (See '_compute_slides_statistics' and '_compute_category_completion_time'). """
            // 
            // self.slide_ids.unlink()
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptAllEmployeeChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _unlink_except_all_employee_channel(self):
            // # Delete discuss.channel
            // try:
            //     all_emp_group = self.env.ref('mail.channel_all_employees')
            // except ValueError:
            //     all_emp_group = None
            // if all_emp_group and all_emp_group in self:
            //     raise UserError(_('You cannot delete those groups, as the Whole Company group is required by other modules.'))
            // for channel in self:
            //     channel._bus_send("discuss.channel/delete", {"id": channel.id})
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_template.py) ---
            // def _unlink_except_loyalty_products(self):
            // product_data = [
            //     self.env.ref('loyalty.gift_card_product_50', False),
            //     self.env.ref('loyalty.ewallet_product_50', False),
            // ]
            // for product in self.filtered(lambda p: p.product_variant_id in product_data):
            //     raise UserError(_(
            //         "You cannot delete %(name)s as it is used in 'Coupons & Loyalty'."
            //         " Please archive it instead.",
            //         name=product.with_context(display_default_code=False).display_name
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _unlink_except_master_data(self):
            // time_product = self.env.ref('sale_timesheet.time_product')
            // if time_product.product_tmpl_id in self:
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived, deleted nor linked to a company.', time_product.name))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py) ---
            // def _unlink_except_open_session(self):
            // product_ctx = dict(self.env.context or {}, active_test=False)
            // if self.with_context(product_ctx).search_count([('id', 'in', self.ids), ('available_in_pos', '=', True)]):
            //     if self.env['pos.session'].sudo().search_count([('state', '!=', 'closed')]):
            //         raise UserError(_(
            //             "To delete a product, make sure all point of sale sessions are closed.\n\n"
            //             "Deleting a product available in a session would be like attempting to snatch a hamburger from a customer’s hand mid-bite; chaos will ensue as ketchup and mayo go flying everywhere!",
            //         ))
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _unsubscribe_portal_users(self):
            // self.message_unsubscribe(partner_ids=self.message_partner_ids.filtered('user_ids.share').ids)
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IRatingMixinable
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

        protected async Task<object> UpdateForwardedChannelDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _update_forwarded_channel_data(self, /, *, livechat_failure, livechat_operator_id, operator_name):
            // self.write(
            //     {
            //         "livechat_failure": livechat_failure,
            //         "livechat_operator_id": livechat_operator_id,
            //         "name": " ".join(
            //             [
            //                 self.env.user.display_name
            //                 if not self.env.user._is_public()
            //                 else self.sudo().self_member_id.guest_id.name,
            //                 operator_name
            //             ]
            //         )
            //     }
            // )
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _website_show_quick_add(self):
            // self.ensure_one()
            // if not self.filtered_domain(self.env['website']._product_domain()):
            //     return False
            // return not request.website.prevent_zero_price_sale or self._get_contextual_price()
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def write(self, vals):
            // if "livechat_status" not in vals and "livechat_expertise_ids" not in vals:
            //     return super().write(vals)
            // need_help_before = self.filtered(lambda c: c.livechat_status == "need_help")
            // result = super().write(vals)
            // need_help_after = self.filtered(lambda c: c.livechat_status == "need_help")
            // group_livechat_user = self.env.ref("im_livechat.im_livechat_group_user")
            // store = Store(bus_channel=group_livechat_user, bus_subchannel="LOOKING_FOR_HELP")
            // added_need_help = need_help_after - need_help_before
            // removed_need_help = need_help_before - need_help_after
            // store.add(added_need_help)
            // store.add(removed_need_help, ["livechat_status"])
            // if "livechat_expertise_ids" in vals:
            //     store.add(self, Store.Many("livechat_expertise_ids"))
            // if added_need_help or removed_need_help:
            //     group_livechat_user._bus_send(
            //         "im_livechat.looking_for_help/update",
            //         {
            //             "added_channel_ids": added_need_help.ids,
            //             "removed_channel_ids": removed_need_help.ids,
            //         },
            //         subchannel="LOOKING_FOR_HELP",
            //     )
            // store.bus_send()
            // return result
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
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py) ---
            // def write(self, vals):
            // """ If the rated ressource name is modified, we should update the rating res_name too.
            //     If the rated ressource parent is changed we should update the parent_res_id too"""
            // result = super().write(vals)
            // for record in self.sudo():  # ratings may be inaccessible
            //     if record._rec_name in vals:  # set the res_name of ratings to be recomputed
            //         res_name_field = self.env['rating.rating']._fields['res_name']
            //         self.env.add_to_compute(res_name_field, record.rating_ids)
            //     if record._rating_get_parent_field_name() in vals:
            //         record.rating_ids.write({'parent_res_id': record[record._rating_get_parent_field_name()].id})
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def write(self, vals):
            // # Clear empty ecommerce description content to avoid side-effects on product pages
            // # when there is no content to display anyway.
            // if (
            //     (description_ecommerce := vals.get('description_ecommerce'))
            //     and is_html_empty(description_ecommerce)
            //     and not ('media_iframe_video' in description_ecommerce or 'data-embedded' in description_ecommerce)  # don't remove "empty" video div
            // ):
            //     vals['description_ecommerce'] = ''
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def write(self, vals):
            // # If description_short wasn't manually modified, there is an implicit link between this field and description.
            // if not is_html_empty(vals.get('description')) and is_html_empty(vals.get('description_short')) and self.description == self.description_short:
            //     vals['description_short'] = vals.get('description')
            // 
            // res = super().write(vals)
            // 
            // if vals.get('user_id'):
            //     self._action_add_members(self.env['res.users'].sudo().browse(vals['user_id']).partner_id)
            //     self.activity_reschedule(
            //         ['mail_activity_data_todo'],
            //         new_user_id=vals.get('user_id'),
            //     )
            // if 'enroll_group_ids' in vals:
            //     self._add_groups_members()
            // 
            // return res
            */
            return default;
        }
    }
}