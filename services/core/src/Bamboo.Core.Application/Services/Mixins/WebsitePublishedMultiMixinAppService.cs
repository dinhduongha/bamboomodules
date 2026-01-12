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
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class WebsitePublishedMultiMixinAppService : ApplicationService, IWebsitePublishedMultiMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public WebsitePublishedMultiMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // allowed_channels = self._filter_add_members(target_partners, raise_on_access=raise_on_access)
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

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_archive(self):
            // filtered_products = self.env['mrp.bom.line'].search([('product_id', 'in', self.product_variant_ids.ids), ('bom_id.active', '=', True)]).product_id.mapped('display_name')
            // res = super().action_archive()
            // if filtered_products:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //         'title': _("Note that product(s): '%s' is/are still linked to active Bill of Materials, "
            //                     "which means that the product can still be used on it/them.", filtered_products),
            //         'type': 'warning',
            //         'sticky': True,  #True/False will display for few seconds if false
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_enroll(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_enroll', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template, enroll_mode=True)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_invite(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_invite', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def action_done(self):
            // return self.write({'payment_next_action_date': False,
            //                    'payment_next_action': '',
            //                    'payment_responsible_id': False})
            */
            return default;
        }

        public async Task<TEntity> ActionEventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def action_event_view(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("event.action_event_view")
            // action['context'] = {}
            // action['domain'] = [('registration_ids.partner_id', 'child_of', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def action_generate_leads(self):
            // """ Re-generate leads based on event.lead.rules.
            // The method is ran synchronously if there is a low amount of registrations, otherwise it
            // goes through a CRON job that runs in batches. """
            // 
            // if not self.env.user.has_group('event.group_event_manager'):
            //     raise UserError(_("Only Event Managers are allowed to re-generate all leads."))
            // 
            // self.ensure_one()
            // registrations_count = self.env['event.registration'].search_count([
            //     ('event_id', '=', self.id),
            //     ('state', 'not in', ['draft', 'cancel']),
            // ])
            // 
            // if registrations_count <= self.env['event.lead.request']._REGISTRATIONS_BATCH_SIZE:
            //     leads = self.env['event.registration'].search([
            //         ('event_id', '=', self.id),
            //         ('state', 'not in', ['draft', 'cancel']),
            //     ])._apply_lead_generation_rules()
            //     if leads:
            //         notification = _("Yee-ha, %(leads_count)s Leads have been created!", leads_count=len(leads))
            //     else:
            //         notification = _("Aww! No Leads created, check your Lead Generation Rules and try again.")
            // else:
            //     self.env['event.lead.request'].sudo().create({'event_id': self.id})
            //     self.env.ref('event_crm.ir_cron_generate_leads')._trigger()
            //     notification = _("Got it! We've noted your request. Your leads will be created soon!")
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'info',
            //         'sticky': False,
            //         'message': notification,
            //         'next': {'type': 'ir.actions.act_window_close'},  # force a form reload
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_grant_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     if self._action_add_members(partner):
            //         self.activity_search(
            //             ['website_slides.mail_activity_data_access_request'],
            //             user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)]
            //         ).action_feedback(feedback=_('Access Granted'))
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_invite_contacts(self):
            // return {
            //     'name': 'Mass Mail Invitation',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('base.model_res_partner').id,
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_invite_contacts(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_invite_contacts()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _action_load_recruitment_scenario(self):
            // 
            // convert_file(
            //     self.sudo().env,
            //     "hr_recruitment",
            //     "data/scenarios/hr_recruitment_scenario.xml",
            //     None,
            //     mode="init",
            //     kind="data",
            // )
            // 
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "reload",
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_mass_mailing_attendees(self):
            // return {
            //     'name': 'Mass Mail Attendees',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('event.model_event_registration').id,
            //         'default_mailing_domain': repr([('event_id', 'in', self.ids), ('state', 'not in', ['cancel', 'draft'])]),
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_mass_mailing_attendees(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_attendees()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // mass_mailing_action = dict(
            //     name='Mass Mail Attendees',
            //     type='ir.actions.act_window',
            //     res_model='mailing.mailing',
            //     view_mode='form',
            //     target='current',
            //     context=dict(
            //         default_mailing_model_id=self.env.ref('website_event_track.model_event_track').id,
            //         default_mailing_domain=repr([('event_id', 'in', self.ids), ('stage_id.is_cancel', '!=', True)]),
            //         default_subject=_("Event: %s", self.name),
            //     ),
            // )
            // return mass_mailing_action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_track_speakers()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionNewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_new_survey(self):
            // self.ensure_one()
            // survey = self.env['survey.survey'].create({
            //     'title': _("Interview Form: %s", self.name),
            // })
            // self.write({'survey_id': survey.id})
            // 
            // action = {
            //         'name': _('Survey'),
            //         'view_mode': 'form,list',
            //         'res_model': 'survey.survey',
            //         'type': 'ir.actions.act_window',
            //         'res_id': survey.id,
            //     }
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_activities(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_recruitment.action_hr_job_applications")
            // views = ['activity'] + [view for view in action['view_mode'].split(',') if view != 'activity']
            // action['view_mode'] = ','.join(views)
            // action['views'] = [(False, view) for view in views]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list')
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': ['|',
            //         '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //         '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.application_ids.ids),
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_open_business_doc(self):
            // return self._get_records_action()
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //             <a class="oe_link" href="https://www.odoo.com/documentation/18.0/_downloads/c2c6ce32294dfddffcfefcf2775f7a09/pdfquotebuilderexamples.zip">
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

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def action_open_employees(self):
            // self.ensure_one()
            // if self.employees_count > 1:
            //     return {
            //         'name': _('Related Employees'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'hr.employee',
            //         'view_mode': 'kanban',
            //         'domain': [('id', 'in', self.employee_ids.ids),
            //                    ('company_id', 'in', self.env.companies.ids)],
            //     }
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'res_id': self.employee_ids.filtered(lambda e: e.company_id in self.env.companies).id,
            //     'view_mode': 'form',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_label_layout(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_tmpl_ids': self.ids}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLateActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_late_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_overdue': True,
            //     'search_default_running_applicant_activities': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_product_lot(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_product_production_lot_form")
            // action['domain'] = [
            //     ('product_id.product_tmpl_id', '=', self.id),
            //     '|', ('location_id', '=', False),
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self._context['allowed_company_ids']))
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

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionOpenTodayActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_today_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_today': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def action_page_debug_view(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.ui.view',
            //     'res_id': self.view_id.id,
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('website.view_view_form_extend').id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py) ---
            // def action_privacy_lookup(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('privacy_lookup.action_privacy_lookup_wizard')
            // action['context'] = {
            //     'default_email': self.email,
            //     'default_name': self.name,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_product_tmpl_forecast_report(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('stock.stock_forecasted_product_template_action')
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_completed_members(self):
            // return self.action_redirect_to_members('completed')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_engaged_members(self):
            // return self.action_redirect_to_members('engaged')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_invited_members(self):
            // return self.action_redirect_to_members('invited')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_refuse_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     self.activity_search(
            //         ['website_slides.mail_activity_data_access_request'],
            //         user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)]
            //     ).action_feedback(feedback=_('Access Refused'))
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_request_access(self, partner):
            // activities = self.env['mail.activity']
            // requested_cids = self.sudo().activity_search(
            //     ['website_slides.mail_activity_data_access_request'],
            //     additional_domain=[('request_partner_id', '=', partner.id)]
            // ).mapped('res_id')
            // for channel in self:
            //     if channel.id not in requested_cids and channel.user_id:
            //         activities += channel.activity_schedule(
            //             'website_slides.mail_activity_data_access_request',
            //             note=_('<b>%s</b> is requesting access to this course.', partner.name),
            //             user_id=channel.user_id.id,
            //             request_partner_id=partner.id
            //         )
            // return activities
            */
            return default;
        }

        public async Task<TEntity> ActionSearchMatchingCandidatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py) ---
            // def action_search_matching_candidates(self):
            // self.ensure_one()
            // help_message_1 = _("No Matching Candidates")
            // help_message_2 = _("We do not have any candidates who meet the skill requirements for this job position in the database at the moment.")
            // action = self.env['ir.actions.actions']._for_xml_id('hr_recruitment.action_hr_candidate')
            // context = literal_eval(action['context'])
            // context['active_id'] = self.id
            // matching_candidates = self.env['hr.candidate'].search([('skill_ids', 'in', self.skill_ids.ids)]).filtered(lambda c: self.id not in c.applicant_ids.job_id.ids)
            // action.update({
            //     'name': _("Matching Candidates"),
            //     'views': [
            //         (self.env.ref('hr_recruitment_skills.hr_candidate_view_tree').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'context': context,
            //     'domain': [('id', 'in', matching_candidates.ids)],
            //     'help': Markup("<p class='o_view_nocontent_empty_folder'>%s</p><p>%s</p>") % (help_message_1, help_message_2),
            // })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def action_set_done(self):
            // """
            // Action which will move the events
            // into the first next (by sequence) stage defined as "Ended"
            // (if they are not already in an ended stage)
            // """
            // first_ended_stage = self.env['event.stage'].search([('pipe_end', '=', True)], limit=1, order='sequence')
            // if first_ended_stage:
            //     self.write({'stage_id': first_ended_stage.id})
            */
            return default;
        }

        public async Task<TEntity> ActionSignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def action_signup_prepare(self):
            // return self.signup_prepare()
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_test_survey(self):
            // self.ensure_one()
            // action = self.survey_id.action_test_survey()
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateQuantityOnHandAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_update_quantity_on_hand(self):
            // advanced_option_groups = [
            //     'stock.group_stock_multi_locations',
            //     'stock.group_tracking_owner',
            //     'stock.group_tracking_lot'
            // ]
            // if any(self.env.user.has_group(g) for g in advanced_option_groups) or self.tracking != 'none':
            //     return self.action_open_quants()
            // else:
            //     default_product_id = self.env.context.get('default_product_id', len(self.product_variant_ids) == 1 and self.product_variant_id.id)
            //     action = self.env["ir.actions.actions"]._for_xml_id("stock.action_change_product_quantity")
            //     action['context'] = dict(
            //         self.env.context,
            //         default_product_id=default_product_id,
            //         default_product_tmpl_id=self.id
            //     )
            //     return action
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def action_view_certifications(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("survey.res_partner_action_certifications")
            // action['view_mode'] = 'list'
            // action['domain'] = ['|', ('partner_id', 'in', self.ids), ('partner_id', 'in', self.child_ids.ids)]
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def action_view_courses(self):
            // """ View partners courses. In singleton mode, return courses followed
            // by all its contacts (if company) or by themselves (if not a company).
            // Otherwise simply set a domain on required partners. The courses to which
            // the partner(s) is not enrolled (e.g. invited) are not shown. """
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_channel_partner_action")
            // action['display_name'] = _('Courses')
            // action['domain'] = [('member_status', '!=', 'invited')]
            // if len(self) == 1 and self.is_company:
            //     action['domain'] = expression.AND([action['domain'], [('partner_id', 'in', self.child_ids.ids)]])
            // elif len(self) == 1:
            //     action['context'] = {'search_default_partner_id': self.id}
            // else:
            //     action['domain'] = expression.AND([action['domain'], [('partner_id', 'in', self.ids)]])
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def action_view_linked_orders(self):
            // """ Redirects to the orders linked to the current events """
            // sale_order_action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // sale_order_action.update({
            //     'domain': [('state', '!=', 'cancel'), ('order_line.event_id', 'in', self.ids)],
            //     'context': {'create': 0},
            // })
            // return sale_order_action
            */
            return default;
        }

        public async Task<TEntity> ActionViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py) ---
            // def action_view_loyalty_cards(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('loyalty.loyalty_card_action')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action['domain'] = [('partner_id', 'in', all_child.ids)]
            // action['context'] = {'search_default_active' : True, 'create': False}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_partner.py) ---
            // def action_view_opportunity(self):
            // '''
            // This function returns an action that displays the opportunities from partner.
            // '''
            // action = self.env['ir.actions.act_window']._for_xml_id('crm.crm_lead_opportunities')
            // action['context'] = {}
            // if self.is_company:
            //     action['domain'] = [('partner_id.commercial_partner_id', '=', self.id)]
            // else:
            //     action['domain'] = [('partner_id', '=', self.id)]
            // action['domain'] = expression.AND([action['domain'], [('active', 'in', [True, False])]])
            // return action
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def action_view_opportunity(self):
            // self.ensure_one()  # especially here as we are doing an id, in, IDS domain
            // action = super().action_view_opportunity()
            // action_domain_origin = action.get('domain')
            // action_context_origin = action.get('context') or {}
            // action_domain_assign = [('partner_assigned_id', '=', self.id)]
            // if not action_domain_origin:
            //     action['domain'] = action_domain_assign
            //     return action
            // # perform searches independently as having OR with those leaves seems to
            // # be counter productive
            // Lead = self.env['crm.lead'].with_context(**action_context_origin, active_test=False)
            // ids_origin = Lead.search(action_domain_origin).ids
            // ids_new = Lead.search(action_domain_assign).ids
            // action['domain'] = [('id', 'in', sorted(list(set(ids_origin) | set(ids_new))))]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_orderpoints(self):
            // return self.product_variant_ids.action_view_orderpoints()
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_view_partner_invoices(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_out_invoice_type")
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action['domain'] = [
            //     ('move_type', 'in', ('out_invoice', 'out_refund')),
            //     ('partner_id', 'in', all_child.ids)
            // ]
            // action['context'] = {'default_move_type': 'out_invoice', 'move_type': 'out_invoice', 'journal_type': 'sale', 'search_default_unpaid': 1}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerWithSameBankAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_view_partner_with_same_bank(self):
            // self.ensure_one()
            // bank_partners = self._get_duplicated_bank_accounts()
            // # Open a list view or form view of the partner(s) with the same bank accounts
            // if self.duplicated_bank_account_partners_count == 1:
            //     action_vals = {
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': bank_partners.partner_id.id,
            //         'views': [(False, 'form')],
            //     }
            // else:
            //     action_vals = {
            //         'name': _("Partners"),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'list,form',
            //         'views': [(False, 'list'), (False, 'form')],
            //         'domain': [('id', 'in', bank_partners.partner_id.ids)],
            //     }
            // 
            // return action_vals
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def action_view_po(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = [
            //     ('state', 'in', ['purchase', 'done']),
            //     ('product_id', 'in', self.with_context(active_test=False).product_variant_ids.ids),
            // ]
            // action['display_name'] = _("Purchase History for %s", self.display_name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def action_view_pos_order(self):
            // '''
            // This function returns an action that displays the pos orders from partner.
            // '''
            // action = self.env['ir.actions.act_window']._for_xml_id('point_of_sale.action_pos_pos_form')
            // if self.is_company:
            //     action['domain'] = [('partner_id.commercial_partner_id', '=', self.id)]
            // else:
            //     action['domain'] = [('partner_id', '=', self.id)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_view_ratings(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.rating_rating_action_slide_channel")
            // action['name'] = _('Rating of %s', self.name)
            // action['domain'] = expression.AND([ast.literal_eval(action.get('domain', '[]')), [('res_id', 'in', self.ids)]])
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionViewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def action_view_sale_order(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('sale.act_res_partner_2_sale_order')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action["domain"] = [("partner_id", "in", all_child.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def action_view_sales(self):
            // action = self.env['ir.actions.actions']._for_xml_id('sale.report_all_channels_sales_action')
            // action['domain'] = [('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'pivot_measures': ['product_uom_qty'],
            //     'active_id': self._context.get('active_id'),
            //     'active_model': 'sale.report',
            //     'search_default_Sales': 1,
            //     'search_default_filter_order_date': 1,
            //     'search_default_group_by_date': 1,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionViewStockLotsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_partner.py) ---
            // def action_view_stock_lots(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_lot_report')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action["domain"] = [("partner_id", "in", all_child.ids)]
            // action["context"] = {'search_default_filter_not_has_return': True}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_storage_category_capacity(self):
            // self.ensure_one()
            // return self.product_variant_ids.action_view_storage_category_capacity()
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def action_view_tasks(self):
            // self.ensure_one()
            // action = {
            //     **self.env["ir.actions.actions"]._for_xml_id("project.project_task_action_from_partner"),
            //     'display_name': _("%(partner_name)s's Tasks", partner_name=self.name),
            //     'context': {
            //         'default_partner_id': self.id,
            //     },
            // }
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // search_domain = [('partner_id', 'in', (self | all_child).ids)]
            // if self.task_count <= 1:
            //     task_id = self.env['project.task'].search(search_domain, limit=1)
            //     action['res_id'] = task_id.id
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == "form"]
            // else:
            //     action['domain'] = search_domain
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _add_groups_members(self):
            // for channel in self:
            //     channel._action_add_members(channel.mapped('enroll_group_ids.users.partner_id'))
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _address_fields(self):
            // return super()._address_fields() + ['city_id']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def address_get(self, adr_pref=None):
            // """ Find contacts/addresses of the right type(s) by doing a depth-first-search
            // through descendants within company boundaries (stop at entities flagged ``is_company``)
            // then continuing the search at the ancestors that are within the same company boundaries.
            // Defaults to partners of type ``'default'`` when the exact type is not found, or to the
            // provided partner itself if no type ``'default'`` is found either. """
            // adr_pref = set(adr_pref or [])
            // if 'contact' not in adr_pref:
            //     adr_pref.add('contact')
            // result = {}
            // visited = set()
            // for partner in self:
            //     current_partner = partner
            //     while current_partner:
            //         to_scan = [current_partner]
            //         # Scan descendants, DFS
            //         while to_scan:
            //             record = to_scan.pop(0)
            //             visited.add(record)
            //             if record.type in adr_pref and not result.get(record.type):
            //                 result[record.type] = record.id
            //             if len(result) == len(adr_pref):
            //                 return result
            //             to_scan = [c for c in record.child_ids
            //                          if c not in visited
            //                          if not c.is_company] + to_scan
            // 
            //         # Continue scanning at ancestor if current_partner is not a commercial entity
            //         if current_partner.is_company or not current_partner.parent_id:
            //             break
            //         current_partner = current_partner.parent_id
            // 
            // # default to type 'contact' or the partner itself
            // default = result.get('contact', self.id or False)
            // for adr_type in adr_pref:
            //     result[adr_type] = result.get(adr_type) or default
            // return result
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _address_id_domain(self):
            // return ['|', '&', '&', ('type', '!=', 'contact'), ('type', '!=', 'private'),
            //         ('id', 'in', self.sudo().env.companies.partner_id.child_ids.ids),
            //         ('id', 'in', self.sudo().env.companies.partner_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('hr.applicant').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults.update({
            //         'job_id': self.id,
            //         'department_id': self.department_id.id,
            //         'company_id': self.department_id.company_id.id if self.department_id else self.company_id.id,
            //         'user_id': self.user_id.id,
            //     })
            // return values
            */
            return default;
        }

        public async Task<TEntity> ApplyMarginsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _apply_margins(self, price):
            // self.ensure_one()
            // if self.delivery_type == 'fixed':
            //     return float(price)
            // order = self.env.context.get('order', self.env['sale.order'])
            // fixed_margin_in_sale_currency = self._compute_currency(order, self.fixed_margin, 'company_to_pricelist') if order else self.fixed_margin
            // return float(price) * (1.0 + self.margin) + fixed_margin_in_sale_currency
            */
            return default;
        }

        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _asset_difference_search(self, account_type, operator, operand):
            // if operator not in ('<', '=', '>', '>=', '<='):
            //     return []
            // if not isinstance(operand, (float, int)):
            //     return []
            // sign = 1
            // if account_type == 'liability_payable':
            //     sign = -1
            // res = self._cr.execute(f'''
            //     SELECT aml.partner_id
            //       FROM res_partner partner
            //  LEFT JOIN account_move_line aml ON aml.partner_id = partner.id
            //       JOIN account_move move ON move.id = aml.move_id
            //       JOIN res_company line_company ON line_company.id = aml.company_id
            // RIGHT JOIN account_account acc ON aml.account_id = acc.id
            //      WHERE acc.account_type = %s
            //        AND NOT acc.deprecated
            //        AND SPLIT_PART(line_company.parent_path, '/', 1)::int = %s
            //        AND move.state = 'posted'
            //   GROUP BY aml.partner_id
            //     HAVING %s * COALESCE(SUM(aml.amount_residual), 0) {operator} %s''',
            //     (account_type, self.env.company.root_id.id, sign, operand)
            // )
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [r[0] for r in res])]
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _auto_init(self):
            // if not column_exists(self.env.cr, "product_template", "can_be_expensed"):
            //     create_column(self.env.cr, "product_template", "can_be_expensed", "boolean")
            //     self.env.cr.execute(
            //         """
            //         UPDATE product_template
            //         SET can_be_expensed = false
            //         WHERE type NOT IN ('consu', 'service')
            //         """
            //     )
            // return super()._auto_init()
            */
            return default;
        }

        public async Task<TEntity> AutocompleteAsync<TEntity>(IEnumerable<TEntity> entities, object query, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete(self, query, timeout=15):
            // return []
            */
            return default;
        }

        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete_by_name(self, query, query_country_id, timeout=15):
            // if query_country_id is False:  # If it's 0, we purposely do not want to filter on the country
            //     query_country_id = self.env.company.country_id.id
            // query_country_code = self.env['res.country'].browse(query_country_id).code
            // response, _ = self.env['iap.autocomplete.api']._request_partner_autocomplete('search_by_name', {
            //     'query': query,
            //     'query_country_code': query_country_code,
            // }, timeout=timeout)
            // if response and not response.get("error"):
            //     results = []
            //     for suggestion in response.get("data"):
            //         results.append(self._format_data_company(suggestion))
            //     return results
            // else:
            //     return []
            */
            return default;
        }

        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete_by_vat(self, vat, query_country_id, timeout=15):
            // query_country_id = query_country_id or self.env.company.country_id.id
            // query_country_code = self.env['res.country'].browse(query_country_id).code
            // response, _ = self.env['iap.autocomplete.api']._request_partner_autocomplete('search_by_vat', {
            //     'query': vat,
            //     'query_country_code': query_country_code,
            // }, timeout=timeout)
            // if response and not response.get("error"):
            //     results = []
            //     for suggestion in response.get("data"):
            //         results.append(self._format_data_company(suggestion))
            //     return results
            // else:
            //     vies_result = None
            //     try:
            //         _logger.info('Calling VIES service to check VAT for autocomplete: %s', vat)
            //         vies_result = check_vies(vat, timeout=timeout)
            //     except Exception:
            //         _logger.warning("Failed VIES VAT check.", exc_info=True)
            //     if vies_result:
            //         name = vies_result['name']
            //         if vies_result['valid'] and name != '---':
            //             address = list(filter(bool, vies_result['address'].split('\n')))
            //             street = address[0]
            //             zip_city_record = next(filter(lambda addr: re.match(r'^\d.*', addr), address[1:]), None)
            //             zip_city = zip_city_record.split(' ', 1) if zip_city_record else [None, None]
            //             street2 = next((addr for addr in filter(lambda addr: addr != zip_city_record, address[1:])), None)
            //             return [self._iap_replace_location_codes({
            //                 'name': name,
            //                 'vat': vat,
            //                 'street': street,
            //                 'street2': street2,
            //                 'city': zip_city[1],
            //                 'zip': zip_city[0],
            //                 'country_code': vies_result['countryCode'],
            //             })]
            //     return []
            */
            return default;
        }

        public async Task<TEntity> AvailableCarriersAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def available_carriers(self, partner, order):
            // return self.filtered(lambda c: c._match(partner, order))
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def available_carriers(self, partner, order):
            // """ Override of `delivery` to filter out regular delivery methods from Gelato orders and
            // Gelato delivery methods from non-Gelato orders.
            // 
            // :param res.partner partner: The partner to check.
            // :param sale.order order: The current order.
            // :return: The available delivery methods.
            // :rtype: delivery.carrier
            // """
            // available_delivery_methods = super().available_carriers(partner, order)
            // is_gelato_order = any(order.order_line.product_id.mapped('gelato_product_uid'))
            // if is_gelato_order:
            //     return available_delivery_methods.filtered(lambda m: m.delivery_type == 'gelato')
            // else:
            //     return available_delivery_methods.filtered(lambda m: m.delivery_type != 'gelato')
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_mondialrelay:
            //     return "delivery_mondialrelay/static/src/img/truck_mr.png"
            // return super()._avatar_get_placeholder_path()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_company:
            //     return "base/static/img/company_image.png"
            // if self.type == 'delivery':
            //     return "base/static/img/truck.png"
            // if self.type == 'invoice':
            //     return "base/static/img/money.png"
            // return super()._avatar_get_placeholder_path()
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleCancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_cancel_shipment(self, pickings):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleGetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def base_on_rule_get_tracking_link(self, picking):
            // if self.is_mondialrelay:
            //     return 'https://www.mondialrelay.com/public/permanent/tracking.aspx?ens=%(brand)s&exp=%(track)s&language=%(lang)s' % {
            //         'brand': picking.carrier_id.mondialrelay_brand,
            //         'track': picking.carrier_tracking_ref,
            //         'lang': (picking.partner_id.lang or 'fr').split('_')[0],
            //     }
            // return super().base_on_rule_get_tracking_link(picking)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_get_tracking_link(self, picking):
            // if self.tracking_url and picking.carrier_tracking_ref:
            //     return self.tracking_url.replace("<shipmenttrackingnumber>", picking.carrier_tracking_ref)
            // return False
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_rate_shipment(self, order):
            // carrier = self._match_address(order.partner_shipping_id)
            // if not carrier:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': _('Error: this delivery method is not available for this address.'),
            //             'warning_message': False}
            // 
            // try:
            //     price_unit = self._get_price_available(order)
            // except UserError as e:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': e.args[0],
            //             'warning_message': False}
            // 
            // price_unit = self._compute_currency(order, price_unit, 'company_to_pricelist')
            // 
            // return {'success': True,
            //         'price': price_unit,
            //         'error_message': False,
            //         'warning_message': False}
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleSendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def base_on_rule_send_shipping(self, pickings):
            // res = []
            // for p in pickings:
            //     carrier = self._match_address(p.partner_id)
            //     if not carrier:
            //         raise ValidationError(_('There is no matching delivery rule.'))
            //     res = res + [{'exact_price': p.carrier_id._get_price_available(p.sale_id) if p.sale_id else 0.0,  # TODO cleanme
            //                   'tracking_number': False}]
            // return res
            */
            return default;
        }

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _build_error_peppol_endpoint(self, eas, endpoint):
            // """ This function contains all the rules regarding the peppol_endpoint."""
            // if eas == '0208' and not re.match(r"^\d{10}$", endpoint):
            //     return _("The Peppol endpoint is not valid. The expected format is: 0239843188")
            // if eas == '0009' and not siret.is_valid(endpoint):
            //     return _("The Peppol endpoint is not valid. The expected format is: 73282932000074")
            // if eas == '0007' and not re.match(r"^\d{10}$", endpoint):
            //     return _("The Peppol endpoint is not valid. "
            //              "It should contain exactly 10 digits (Company Registry number)."
            //              "The expected format is: 1234567890")
            */
            return default;
        }

        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _build_vat_error_message(self, country_code, wrong_vat, record_label):
            // """ Prepare an error message for the VAT number that failed validation
            // 
            // :param country_code: string of lowercase country code
            // :param wrong_vat: the vat number that was validated
            // :param record_label: a string to desribe the record that failed a VAT validation check
            // 
            // :return: The error message string
            // """
            // return ""
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _build_vat_error_message(self, country_code, wrong_vat, record_label):
            // # OVERRIDE account
            // if self.env.context.get('company_id'):
            //     company = self.env['res.company'].browse(self.env.context['company_id'])
            // else:
            //     company = self.env.company
            // 
            // vat_label = _("VAT")
            // if country_code and company.country_id and country_code == company.country_id.code.lower() and company.country_id.vat_label:
            //     vat_label = company.country_id.vat_label
            // 
            // expected_format = _ref_vat.get(country_code, "'CC##' (CC=Country Code, ##=VAT Number)")
            // 
            // # Catch use case where the record label is about the public user (name: False)
            // if 'False' not in record_label:
            //     return '\n' + _(
            //         'The %(vat_label)s number [%(wrong_vat)s] for %(record_label)s does not seem to be valid. \nNote: the expected format is %(expected_format)s',
            //         vat_label=vat_label,
            //         wrong_vat=wrong_vat,
            //         record_label=record_label,
            //         expected_format=expected_format,
            //     )
            // else:
            //     return '\n' + _(
            //         'The %(vat_label)s number [%(wrong_vat)s] does not seem to be valid. \nNote: the expected format is %(expected_format)s',
            //         vat_label=vat_label,
            //         wrong_vat=wrong_vat,
            //         expected_format=expected_format,
            //     )
            */
            return default;
        }

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_partner.py) ---
            // def _build_vcard(self):
            // """ Build the partner's vCard.
            //     :returns a vobject.vCard object
            // """
            // if not vobject:
            //     return False
            // vcard = vobject.vCard()
            // # Name
            // n = vcard.add('n')
            // n.value = vobject.vcard.Name(family=self.name or self.complete_name or '')
            // if self.title:
            //     n.value.prefix = self.title.name
            // # Formatted Name
            // fn = vcard.add('fn')
            // fn.value = self.name or self.complete_name or ''
            // # Address
            // adr = vcard.add('adr')
            // adr.value = vobject.vcard.Address(street=self.street or '', city=self.city or '', code=self.zip or '')
            // if self.state_id:
            //     adr.value.region = self.state_id.name
            // if self.country_id:
            //     adr.value.country = self.country_id.name
            // # Email
            // if self.email:
            //     email = vcard.add('email')
            //     email.value = self.email
            //     email.type_param = 'INTERNET'
            // # Telephone numbers
            // if self.phone:
            //     tel = vcard.add('tel')
            //     tel.type_param = 'work'
            //     tel.value = self.phone
            // if self.mobile:
            //     tel = vcard.add('tel')
            //     tel.type_param = 'cell'
            //     tel.value = self.mobile
            // # URL
            // if self.website:
            //     url = vcard.add('url')
            //     url.value = self.website
            // # Organisation
            // if self.commercial_company_name:
            //     org = vcard.add('org')
            //     org.value = [self.commercial_company_name]
            // if self.function:
            //     function = vcard.add('title')
            //     function.value = self.function
            // # Photo
            // photo = vcard.add('photo')
            // photo.value = b64decode(self.avatar_512)
            // photo.encoding_param = 'B'
            // photo.type_param = 'JPG'
            // return VComponentProxy(vcard)
            */
            return default;
        }

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _bus_send_history_message(self, channel, page_history):
            // message_body = _("No history found")
            // if page_history:
            //     message_body = Markup("<ul>%s</ul>") % (
            //         Markup("").join(
            //             Markup('<li><a href="%(page)s" target="_blank">%(page)s</a></li>')
            //             % {"page": page}
            //             for page in page_history
            //         )
            //     )
            // self._bus_send_transient_message(channel, message_body)
            */
            return default;
        }

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def button_account_peppol_check_partner_endpoint(self, company=None):
            // """ A basic check for whether a participant is reachable at the given
            // Peppol participant ID - peppol_eas:peppol_endpoint (ex: '9999:test')
            // The SML (Service Metadata Locator) assigns a DNS name to each peppol participant.
            // This DNS name resolves into the SMP (Service Metadata Publisher) of the participant.
            // The DNS address is of the following form:
            // - "http://B-" + hexstring(md5(lowercase(ID-VALUE))) + "." + ID-SCHEME + "." + SML-ZONE-NAME + "/" + url_encoded(ID-SCHEME + "::" + ID-VALUE)
            // (ref:https://peppol.helger.com/public/locale-en_US/menuitem-docs-doc-exchange)
            // """
            // self.ensure_one()
            // if not company:
            //     company = self.env.company
            // 
            // self_partner = self.with_company(company)
            // old_value = self_partner.peppol_verification_state
            // self_partner.peppol_verification_state = self._get_peppol_verification_state(
            //     self.peppol_endpoint,
            //     self.peppol_eas,
            //     self_partner._get_peppol_edi_format(),
            // )
            // if self_partner.peppol_verification_state == 'valid' and not self_partner.invoice_sending_method:
            //     self_partner.invoice_sending_method = 'peppol'
            // 
            // self._log_verification_state_update(company, old_value, self_partner.peppol_verification_state)
            // return False
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _can_be_added_to_cart(self):
            // """
            // Pre-check to `_is_add_to_cart_possible` to know if product can be sold.
            // """
            // return self.sale_ok
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _can_be_edited_by_current_customer(self, sale_order, address_type):
            // self.ensure_one()
            // children_partner_ids = self.env['res.partner']._search([
            //     ('id', 'child_of', sale_order.partner_id.commercial_partner_id.id),
            //     ('type', 'in', ('invoice', 'delivery', 'other')),
            // ])
            // return self == sale_order.partner_id or self.id in children_partner_ids
            --- ODOO METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: res_partner.py) ---
            // def _can_be_edited_by_current_customer(self, *args, **kwargs):
            // return super()._can_be_edited_by_current_customer(*args, **kwargs) and not self.is_mondialrelay
            */
            return default;
        }

        public async Task<TEntity> CanEditNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _can_edit_name(self):
            // """ Can't edit `name` if there is (non draft) issued invoices. """
            // return super()._can_edit_name() and not self._has_invoice(
            //     [('partner_id', '=', self.id)]
            // )
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: res_partner.py) ---
            // def _can_edit_name(self):
            // """ Name can be changed more often than the VAT """
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _can_edit_name(self):
            // """ Can't edit `name` if there is (non draft) issued SO. """
            // return super()._can_edit_name() and not self._has_order(
            //     [
            //         ('partner_invoice_id', '=', self.id),
            //         ('partner_id', '=', self.id),
            //     ]
            // )
            */
            return default;
        }

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def can_edit_vat(self):
            // """ Can't edit `vat` if there is (non draft) issued invoices. """
            // return super().can_edit_vat() and not self._has_invoice(
            //     [('partner_id', 'child_of', self.commercial_partner_id.id)]
            // )
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: res_partner.py) ---
            // def can_edit_vat(self):
            // """ `vat` is a commercial field, synced between the parent (commercial
            // entity) and the children. Only the commercial entity should be able to
            // edit it (as in backend)."""
            // self.ensure_one()
            // return not self.parent_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def can_edit_vat(self):
            // """ Can't edit `vat` if there is (non draft) issued SO. """
            // return super().can_edit_vat() and not self._has_order(
            //     [('partner_id', 'child_of', self.commercial_partner_id.id)]
            // )
            */
            return default;
        }

        public async Task<TEntity> CancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def cancel_shipment(self, pickings):
            // ''' Cancel a shipment
            // 
            // :param pickings: A recordset of pickings
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_cancel_shipment' % self.delivery_type):
            //     return getattr(self, '%s_cancel_shipment' % self.delivery_type)(pickings)
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_barcode_unicity(self):
            // for partner in self:
            //     if partner.barcode and self.env['res.partner'].search_count([('barcode', '=', partner.barcode)]) > 1:
            //         raise ValidationError(_('Another partner already has this barcode'))
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_barcode_uniqueness(self):
            // for template in self:
            //     template.product_variant_ids._check_barcode_uniqueness()
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_closing_date(self):
            // for event in self:
            //     if event.date_end < event.date_begin:
            //         raise ValidationError(_('The closing date cannot be earlier than the beginning date.'))
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _check_combo_inclusions(self):
            // for product in self:
            //     if not product.available_in_pos:
            //         combo_name = self.env['product.combo.item'].sudo().search([('product_id', 'in', product.product_variant_ids.ids)], limit=1).combo_id.name
            //         if combo_name:
            //             raise UserError(_('You must first remove this product from the %s combo', combo_name))
            */
            return default;
        }

        public async Task<TEntity> CheckDataSourceIsProvidedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _check_data_source_is_provided(self):
            // for record in self:
            //     if bool(record.action_server_id) == bool(record.filter_id):
            //         raise ValidationError(_("Either action_server_id or filter_id must be provided."))
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _check_document_type_support(self, participant_info, ubl_cii_format):
            // service_references = participant_info.findall(
            //     '{*}ServiceMetadataReferenceCollection/{*}ServiceMetadataReference'
            // )
            // document_type = self.env['account.edi.xml.ubl_21']._get_customization_ids()[ubl_cii_format]
            // for service in service_references:
            //     if document_type in parse.unquote_plus(service.attrib.get('href', '')):
            //         return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _check_field_names(self):
            // for record in self:
            //     for field_name in record.field_names.split(","):
            //         if not field_name.strip():
            //             raise ValidationError(_("Empty field name in “%s”", record.field_names))
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _check_for_publication(self, vals):
            // if vals.get('is_published'):
            //     for post in self.filtered(lambda p: p.active):
            //         post.blog_id.message_post_with_source(
            //             'website_blog.blog_post_template_new_post',
            //             subject=post.name,
            //             render_values={'post': post},
            //             subtype_xmlid='website_blog.mt_blog_blog_published',
            //         )
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckGstInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def check_gst_in(self, vat):
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_import_consistency(self, vals_list):
            // """
            // The values created by an import are generated by a name search, field by field.
            // As a result there is no check that the field values are consistent with each others.
            // We check that if the state is given a value, it does belong to the given country, or we remove it.
            // """
            // States = self.env['res.country.state']
            // states_ids = {vals['state_id'] for vals in vals_list if vals.get('state_id')}
            // state_to_country = States.search_read([('id', 'in', list(states_ids))], ['country_id'])
            // for vals in vals_list:
            //     if vals.get('state_id'):
            //         country_id = next(c['country_id'][0] for c in state_to_country if c['id'] == vals.get('state_id'))
            //         state = States.browse(vals['state_id'])
            //         if state.country_id.id != country_id:
            //             state_domain = [('code', '=', state.code),
            //                             ('country_id', '=', country_id)]
            //             state = States.search(state_domain, limit=1)
            //             vals['state_id'] = state.id
            */
            return default;
        }

        public async Task<TEntity> CheckInStoreDmHasWarehousesWhenPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _check_in_store_dm_has_warehouses_when_published(self):
            // if any(self.filtered(
            //     lambda dm: dm.delivery_type == 'in_store'
            //     and dm.is_published
            //     and not dm.warehouse_ids
            // )):
            //     raise ValidationError(
            //         _("The delivery method must have at least one warehouse to be published.")
            //     )
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //             value_list=format_list(self.env, [field_descriptions[v] for v in incompatible_fields]),
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _check_limit(self):
            // """Limit must be between 1 and 16."""
            // for record in self:
            //     if not 0 < record.limit <= 16:
            //         raise ValidationError(_("The limit must be between 1 and 16."))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_partner_company(self):
            // """
            // Check that for every partner which has a company,
            // if there exists a company linked to that partner,
            // the company_id set on the partner is that company
            // """
            // partners = self.filtered(lambda p: p.is_company and p.company_id)
            // companies = self.env['res.company'].search_fetch([('partner_id', 'in', partners.ids)], ['partner_id'])
            // for company in companies:
            //     if company != company.partner_id.company_id:
            //         raise ValidationError(_('The company assigned to this partner does not match the company this partner represents.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _check_peppol_fields(self):
            // for partner in self:
            //     if partner.peppol_endpoint and partner.peppol_eas:
            //         error = self._build_error_peppol_endpoint(partner.peppol_eas, partner.peppol_endpoint)
            //         if error:
            //             raise ValidationError(error)
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification, object check_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _check_peppol_participant_exists(self, participant_info, edi_identification, check_company=False):
            // participant_identifier = participant_info.findtext('{*}ParticipantIdentifier')
            // service_metadata = participant_info.find('.//{*}ServiceMetadataReference')
            // service_href = ''
            // if service_metadata is not None:
            //     service_href = service_metadata.attrib.get('href', '')
            // 
            // if edi_identification != participant_identifier or 'hermes-belgium' in service_href:
            //     # all Belgian companies are pre-registered on hermes-belgium, so they will
            //     # technically have an existing SMP url but they are not real Peppol participants
            //     return False
            // 
            // if check_company:
            //     # if we are only checking company's existence on the network, we don't care about what documents they can receive
            //     if not service_href:
            //         return True
            // 
            //     access_point_contact = True
            //     with contextlib.suppress(requests.exceptions.RequestException, etree.XMLSyntaxError):
            //         response = requests.get(service_href, timeout=TIMEOUT)
            //         if response.status_code == 200:
            //             access_point_info = etree.fromstring(response.content)
            //             access_point_contact = access_point_info.findtext('.//{*}TechnicalContactUrl') or access_point_info.findtext('.//{*}TechnicalInformationUrl')
            //     return access_point_contact
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckRecursionAssociateMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _check_recursion_associate_member(self):
            // if self._has_cycle('associate_member'):
            //     raise ValidationError(_('You cannot create recursive associated members.'))
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object minimal_availability) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_seats_availability(self, minimal_availability=0):
            // sold_out_events = []
            // for event in self:
            //     if event.seats_limited and event.seats_max and event.seats_available < minimal_availability:
            //         sold_out_events.append(_(
            //             '- "%(event_name)s": Missing %(nb_too_many)i seats.',
            //             event_name=event.name,
            //             nb_too_many=minimal_availability - event.seats_available,
            //         ))
            // if sold_out_events:
            //     raise ValidationError(_('There are not enough seats available for:')
            //                           + '\n%s\n' % '\n'.join(sold_out_events))
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CheckTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _check_tags(self):
            // for carrier in self:
            //     if carrier.must_have_tag_ids & carrier.excluded_tag_ids:
            //         raise UserError(_("Carrier %s cannot have the same tag in both Must Have Tags and Excluded Tags.") % carrier.name)
            */
            return default;
        }

        public async Task<TEntity> CheckUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_uom(self):
            // if any(template.uom_id and template.uom_po_id and template.uom_id.category_id != template.uom_po_id.category_id for template in self):
            //     raise ValidationError(_('The default Unit of Measure and the purchase Unit of Measure must be in the same category.'))
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _check_uom_not_in_invoice(self):
            // self.env['product.template'].flush_model(['uom_id'])
            // self._cr.execute("""
            //     SELECT prod_template.id
            //       FROM account_move_line line
            //       JOIN product_product prod_variant ON line.product_id = prod_variant.id
            //       JOIN product_template prod_template ON prod_variant.product_tmpl_id = prod_template.id
            //       JOIN uom_uom template_uom ON prod_template.uom_id = template_uom.id
            //       JOIN uom_category template_uom_cat ON template_uom.category_id = template_uom_cat.id
            //       JOIN uom_uom line_uom ON line.product_uom_id = line_uom.id
            //       JOIN uom_category line_uom_cat ON line_uom.category_id = line_uom_cat.id
            //      WHERE prod_template.id IN %s
            //        AND line.parent_state = 'posted'
            //        AND template_uom_cat.id != line_uom_cat.id
            //      LIMIT 1
            // """, [tuple(self.ids)])
            // if self._cr.fetchall():
            //     raise ValidationError(_(
            //         "This product is already being used in posted Journal Entries.\n"
            //         "If you want to change its Unit of Measure, please archive this product and create a new one."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckUserHasModelAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _check_user_has_model_access(self):
            // for record in self:
            //     self.env[record.model_id.model].check_access('read')
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_al(self, vat):
            // """Check Albania VAT number"""
            // number = stdnum.util.get_cc_module('al', 'vat').compact(vat)
            // 
            // if len(number) == 10 and self.__check_vat_al_re.match(number):
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat(self):
            // # The context key 'no_vat_validation' allows you to store/set a VAT number without doing validations.
            // # This is for API pushes from external platforms where you have no control over VAT numbers.
            // if self.env.context.get('no_vat_validation'):
            //     return
            // 
            // for partner in self:
            //     # Skip checks when only one character is used. Some users like to put '/' or other as VAT to differentiate between
            //     # A partner for which they didn't input VAT, and the one not subject to VAT
            //     if not partner.vat or len(partner.vat) == 1:
            //         continue
            //     country = partner.commercial_partner_id.country_id
            //     if self._run_vat_test(partner.vat, country, partner.is_company) is False:
            //         partner_label = _("partner [%s]", partner.name)
            //         msg = partner._build_vat_error_message(country and country.code.lower() or None, partner.vat, partner_label)
            //         raise ValidationError(msg)
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_br(self, vat):
            // is_cpf_valid = stdnum.get_cc_module('br', 'cpf').is_valid
            // is_cnpj_valid = stdnum.get_cc_module('br', 'cnpj').is_valid
            // return is_cpf_valid(vat) or is_cnpj_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ch(self, vat):
            // '''
            // Check Switzerland VAT number.
            // '''
            // # A new VAT number format in Switzerland has been introduced between 2011 and 2013
            // # https://www.estv.admin.ch/estv/fr/home/mehrwertsteuer/fachinformationen/steuerpflicht/unternehmens-identifikationsnummer--uid-.html
            // # The old format "TVA 123456" is not valid since 2014
            // # Accepted format are: (spaces are ignored)
            // #     CHE#########MWST
            // #     CHE#########TVA
            // #     CHE#########IVA
            // #     CHE-###.###.### MWST
            // #     CHE-###.###.### TVA
            // #     CHE-###.###.### IVA
            // #
            // # /!\ The english abbreviation VAT is not valid /!\
            // 
            // match = self.__check_vat_ch_re.match(vat)
            // 
            // if match:
            //     # For new TVA numbers, the last digit is a MOD11 checksum digit build with weighting pattern: 5,4,3,2,7,6,5,4
            //     num = [s for s in match.group(1) if s.isdigit()]        # get the digits only
            //     factor = (5, 4, 3, 2, 7, 6, 5, 4)
            //     csum = sum([int(num[i]) * factor[i] for i in range(8)])
            //     check = (11 - (csum % 11)) % 11
            //     return check == int(num[8])
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_cr(self, vat):
            // # CÉDULA FÍSICA: 9 digits
            // # CÉDULA JURÍDICA: 10 digits
            // # CÉDULA DIMEX: 11 or 12 digits
            // # CÉDULA NITE: 10 digits
            // 
            // return self.__check_vat_cr_re.match(vat) or False
            */
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_de(self, vat):
            // is_valid_vat = stdnum.util.get_cc_module("de", "vat").is_valid
            // is_valid_stnr = stdnum.util.get_cc_module("de", "stnr").is_valid
            // return is_valid_vat(vat) or is_valid_stnr(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ec(self, vat):
            // vat = clean(vat, ' -.').upper().strip()
            // return self.is_valid_ruc_ec(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_gr(self, vat):
            // """ Allows some custom test VAT number to be valid to allow testing Greece EDI. """
            // greece_test_vats = ('047747270', '047747210', '047747220', '117747270', '127747270')
            // if vat in greece_test_vats:
            //     return True
            // return stdnum.util.get_cc_module('gr', 'vat').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_hu(self, vat):
            // """
            //     Check Hungary VAT number that can be for example 'HU12345676 or 'xxxxxxxx-y-zz' or '8xxxxxxxxy'
            //     - For xxxxxxxx-y-zz, 'x' can be any number, 'y' is a number between 1 and 5 depending on the person and the 'zz'
            //       is used for region code.
            //     - 8xxxxxxxxy, Tin number for individual, it has to start with an 8 and finish with the check digit
            //     - In case of EU format it will be the first 8 digits of the full VAT
            // """
            // companies = self.__check_tin_hu_companies_re.match(vat)
            // if companies:
            //     return True
            // individual = self.__check_tin_hu_individual_re.match(vat)
            // if individual:
            //     return True
            // european = self.__check_tin_hu_european_re.match(vat)
            // if european:
            //     return True
            // # Check the vat number
            // return stdnum.util.get_cc_module('hu', 'vat').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_id(self, vat):
            // """ Temporary Indonesian VAT validation to support the new format
            // introduced in January 2024."""
            // vat = clean(vat, ' -.').strip()
            // 
            // if len(vat) not in (15, 16) or not vat.isdecimal():
            //     return False
            // 
            // # VAT could be 15 (old numbers) or 16 digits. If there are 15 digits long, the 10th digit is a luhn checksum
            // # In some cases, the 15 digits can be transformed in a 16-digit by adding a 0 in front. In such case, we
            // # we can verify the luhn checksum like for the 15 digits by removing the 0. 
            // # However, for newly created VAT 16-digits VAT number, there is no checksum.
            // if (len(vat) == 16 and vat[0] != '0'):
            //     return True
            // 
            // try:
            //     luhn.validate(vat[0:9] if len(vat) == 15 else vat[1:10])
            // except (InvalidFormat, InvalidChecksum):
            //     return False
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ie(self, vat):
            // return stdnum.util.get_cc_module('ie', 'vat').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_il(self, vat):
            // check_func = stdnum.util.get_cc_module('il', 'idnr').is_valid
            // return check_func(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_in(self, vat):
            // #reference from https://www.gstzen.in/a/format-of-a-gst-number-gstin.html
            // if vat and len(vat) == 15:
            //     all_gstin_re = [
            //         r'[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Zz1-9A-Ja-j]{1}[0-9a-zA-Z]{1}', # Normal, Composite, Casual GSTIN
            //         r'[0-9]{4}[A-Z]{3}[0-9]{5}[UO]{1}[N][A-Z0-9]{1}', #UN/ON Body GSTIN
            //         r'[0-9]{4}[a-zA-Z]{3}[0-9]{5}[N][R][0-9a-zA-Z]{1}', #NRI GSTIN
            //         r'[0-9]{2}[a-zA-Z]{4}[a-zA-Z0-9]{1}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[DK]{1}[0-9a-zA-Z]{1}', #TDS GSTIN
            //         r'[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[C]{1}[0-9a-zA-Z]{1}' #TCS GSTIN
            //     ]
            //     return any(re.compile(rx).match(vat) for rx in all_gstin_re)
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ma(self, vat):
            // return vat.isdigit() and len(vat) == 8
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_mx(self, vat):
            // ''' Mexican VAT verification
            // 
            // Verificar RFC México
            // '''
            // m = self.__check_vat_mx_re.fullmatch(vat)
            // if not m:
            //     #No valid format
            //     return False
            // ano = int(m['ano'])
            // if ano > 30:
            //     ano = 1900 + ano
            // else:
            //     ano = 2000 + ano
            // try:
            //     datetime.date(ano, int(m['mes']), int(m['dia']))
            // except ValueError:
            //     return False
            // 
            // # Valid format and valid date
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_no(self, vat):
            // """
            // Check Norway VAT number.See http://www.brreg.no/english/coordination/number.html
            // """
            // if len(vat) == 12 and vat.upper().endswith('MVA'):
            //     vat = vat[:-3] # Strictly speaking we should enforce the suffix MVA but...
            // 
            // if len(vat) != 9:
            //     return False
            // try:
            //     int(vat)
            // except ValueError:
            //     return False
            // 
            // sum = (3 * int(vat[0])) + (2 * int(vat[1])) + \
            //     (7 * int(vat[2])) + (6 * int(vat[3])) + \
            //     (5 * int(vat[4])) + (4 * int(vat[5])) + \
            //     (3 * int(vat[6])) + (2 * int(vat[7]))
            // 
            // check = 11 - (sum % 11)
            // if check == 11:
            //     check = 0
            // if check == 10:
            //     # 10 is not a valid check digit for an organization number
            //     return False
            // return check == int(vat[8])
            */
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_pe(self, vat):
            // if len(vat) != 11 or not vat.isdigit():
            //     return False
            // dig_check = 11 - (sum([int('5432765432'[f]) * int(vat[f]) for f in range(0, 10)]) % 11)
            // if dig_check == 10:
            //     dig_check = 0
            // elif dig_check == 11:
            //     dig_check = 1
            // return int(vat[10]) == dig_check
            */
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ph(self, vat):
            // return len(vat) >= 11 and len(vat) <= 17 and self.__check_vat_ph_re.match(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ro(self, vat):
            // """
            //     Check Romanian VAT number that can be for example 'RO1234567897 or 'xyyzzaabbxxxx' or '9000xxxxxxxx'.
            //     - For xyyzzaabbxxxx, 'x' can be any number, 'y' is the two last digit of a year (in the range 00…99),
            //       'a' is a month, b is a day of the month, the number 8 and 9 are Country or district code
            //       (For those twos digits, we decided to let some flexibility  to avoid complexifying the regex and also
            //       for maintainability)
            //     - 9000xxxxxxxx, start with 9000 and then is filled by number In the range 0...9
            // 
            //     Also stdum also checks the CUI or CIF (Romanian company identifier). So a number like '123456897' will pass.
            // """
            // tin1 = self.__check_tin1_ro_natural_persons.match(vat)
            // if tin1:
            //     return True
            // tin2 = self.__check_tin2_ro_natural_persons.match(vat)
            // if tin2:
            //     return True
            // # Check the vat number
            // return stdnum.util.get_cc_module('ro', 'vat').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ru(self, vat):
            // '''
            // Check Russia VAT number.
            // Method copied from vatnumber 1.2 lib https://code.google.com/archive/p/vatnumber/
            // '''
            // if len(vat) != 10 and len(vat) != 12:
            //     return False
            // try:
            //     int(vat)
            // except ValueError:
            //     return False
            // 
            // if len(vat) == 10:
            //     check_sum = 2 * int(vat[0]) + 4 * int(vat[1]) + 10 * int(vat[2]) + \
            //         3 * int(vat[3]) + 5 * int(vat[4]) + 9 * int(vat[5]) + \
            //         4 * int(vat[6]) + 6 * int(vat[7]) + 8 * int(vat[8])
            //     check = check_sum % 11
            //     if check % 10 != int(vat[9]):
            //         return False
            // else:
            //     check_sum1 = 7 * int(vat[0]) + 2 * int(vat[1]) + 4 * int(vat[2]) + \
            //         10 * int(vat[3]) + 3 * int(vat[4]) + 5 * int(vat[5]) + \
            //         9 * int(vat[6]) + 4 * int(vat[7]) + 6 * int(vat[8]) + \
            //         8 * int(vat[9])
            //     check = check_sum1 % 11
            // 
            //     if check != int(vat[10]):
            //         return False
            //     check_sum2 = 3 * int(vat[0]) + 7 * int(vat[1]) + 2 * int(vat[2]) + \
            //         4 * int(vat[3]) + 10 * int(vat[4]) + 3 * int(vat[5]) + \
            //         5 * int(vat[6]) + 9 * int(vat[7]) + 4 * int(vat[8]) + \
            //         6 * int(vat[9]) + 8 * int(vat[10])
            //     check = check_sum2 % 11
            //     if check != int(vat[11]):
            //         return False
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_sa(self, vat):
            // """
            //     Check company VAT TIN according to ZATCA specifications: The VAT number should start and begin with a '3'
            //     and be 15 digits long
            // """
            // return self.__check_vat_sa_re.match(vat) or False
            */
            return default;
        }

        public async Task<TEntity> CheckVatTAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_t(self, vat):
            // if self.country_id.code == 'JP':
            //     return self.simple_vat_check('jp', vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_tr(self, vat):
            // return stdnum.util.get_cc_module('tr', 'tckimlik').is_valid(vat) or stdnum.util.get_cc_module('tr', 'vkn').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ua(self, vat):
            // res = []
            // for partner in self:
            //     if partner.commercial_partner_id.country_id.code == 'MX':
            //         if len(vat) == 10:
            //             res.append(True)
            //         else:
            //             res.append(False)
            //     elif partner.commercial_partner_id.is_company:
            //         if len(vat) == 12:
            //             res.append(True)
            //         else:
            //             res.append(False)
            //     else:
            //         if len(vat) == 10 or len(vat) == 9:
            //             res.append(True)
            //         else:
            //             res.append(False)
            // return all(res)
            */
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_uy(self, vat):
            // """ Taken from python-stdnum's master branch, as the release doesn't handle RUT numbers starting with 22.
            // origin https://github.com/arthurdejong/python-stdnum/blob/master/stdnum/uy/rut.py
            // FIXME Can be removed when python-stdnum does a new release. """
            // 
            // def compact(number):
            //     """Convert the number to its minimal representation."""
            //     number = clean(number, ' -').upper().strip()
            //     if number.startswith('UY'):
            //         return number[2:]
            //     return number
            // 
            // def calc_check_digit(number):
            //     """Calculate the check digit."""
            //     weights = (4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2)
            //     total = sum(int(n) * w for w, n in zip(weights, number))
            //     return str(-total % 11)
            // 
            // vat = compact(vat)
            // 
            // return (
            //     vat.isdigit()  # InvalidFormat
            //     and len(vat) == 12  # InvalidLength
            //     and '01' <= vat[:2] <= '22'  # InvalidComponent
            //     and vat[2:8] != '000000'
            //     and vat[8:11] == '001'
            //     and vat[-1] == calc_check_digit(vat)  # Invalid Check Digit
            // )
            */
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ve(self, vat):
            // # https://tin-check.com/en/venezuela/
            // # https://techdocs.broadcom.com/us/en/symantec-security-software/information-security/data-loss-prevention/15-7/About-content-packs/What-s-included-in-Content-Pack-2021-02/Updated-data-identifiers-in-Content-Pack-2021-02/venezuela-national-identification-number-v115451096-d327e108002-CP2021-02.html
            // # Sources last visited on 2022-12-09
            // 
            // # VAT format: (kind - 1 letter)(identifier number - 8-digit number)(check digit - 1 digit)
            // vat_regex = re.compile(r"""
            //     ([vecjpg])                          # group 1 - kind
            //     (
            //         (?P<optional_1>-)?                      # optional '-' (1)
            //         [0-9]{2}
            //         (?(optional_1)(?P<optional_2>[.])?)     # optional '.' (2) only if (1)
            //         [0-9]{3}
            //         (?(optional_2)[.])                      # mandatory '.' if (2)
            //         [0-9]{3}
            //         (?(optional_1)-)                        # mandatory '-' if (1)
            //     )                                   # group 2 - identifier number
            //     ([0-9]{1})                          # group X - check digit
            // """, re.VERBOSE | re.IGNORECASE)
            // 
            // matches = re.fullmatch(vat_regex, vat)
            // if not matches:
            //     return False
            // 
            // kind, identifier_number, *_, check_digit = matches.groups()
            // kind = kind.lower()
            // identifier_number = identifier_number.replace("-", "").replace(".", "")
            // check_digit = int(check_digit)
            // 
            // if kind == 'v':                   # Venezuela citizenship
            //     kind_digit = 1
            // elif kind == 'e':                 # Foreigner
            //     kind_digit = 2
            // elif kind == 'c' or kind == 'j':  # Township/Communal Council or Legal entity
            //     kind_digit = 3
            // elif kind == 'p':                 # Passport
            //     kind_digit = 4
            // else:                             # Government ('g')
            //     kind_digit = 5
            // 
            // # === Checksum validation ===
            // multipliers = [3, 2, 7, 6, 5, 4, 3, 2]
            // checksum = kind_digit * 4
            // checksum += sum(map(lambda n, m: int(n) * m, identifier_number, multipliers))
            // 
            // checksum_digit = 11 - checksum % 11
            // if checksum_digit > 9:
            //     checksum_digit = 0
            // 
            // return check_digit == checksum_digit
            */
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_vn(self, vat):
            // """
            // VAT format validator for Vietnam.
            // Supported formats:
            // - 10-digit format (Enterprise tax ID): e.g., 0101243150
            // - 13-digit format with branch suffix: e.g., 0101243150-001
            // - 12-digit format (Personal ID / Citizen ID - CCCD): e.g., 079123456789
            //   (used as tax ID for individuals from July 1st, 2025)
            // 
            // Note:
            // - stdnum.vn.mst.validate() currently only supports 10- and 13-digit VAT numbers
            // - and does not accept the 12-digit personal tax ID (CCCD) format introduced from 01/07/2025.
            // - This helper provides a lightweight format-level validator for use in the meantime.
            // - Can be removed once stdnum.vn.mst adds CCCD support.
            // """
            // vat = vat.strip()
            // return bool(self.__check_vat_vn_re.match(vat))
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_vendor_for_service_to_purchase(self, sellers):
            // if not sellers:
            //     raise ValidationError(_("Please define the vendor from whom you would like to purchase this service automatically."))
            */
            return default;
        }

        public async Task<TEntity> CheckWarehousesHaveSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _check_warehouses_have_same_company(self):
            // for dm in self:
            //     if dm.delivery_type == 'in_store' and dm.company_id and any(
            //         wh.company_id and dm.company_id != wh.company_id for wh in dm.warehouse_ids
            //     ):
            //         raise ValidationError(
            //             _("The delivery method and a warehouse must share the same company")
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _check_website_id(self):
            // for event in self:
            //     if event.website_id and event.website_id.company_id != event.company_id:
            //         raise ValidationError(_("The website must be from the same company as the event."))
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _children_sync(self, values):
            // if not self.child_ids:
            //     return
            // # 2a. Commercial Fields: sync if commercial entity
            // if self.commercial_partner_id == self:
            //     fields_to_sync = values.keys() & self._commercial_fields()
            //     self.sudo()._commercial_sync_to_children(fields_to_sync)
            // # 2b. Address fields: sync if address changed
            // address_fields = self._address_fields()
            // if any(field in values for field in address_fields):
            //     contacts = self.child_ids.filtered(lambda c: c.type == 'contact')
            //     contacts.update_address(values)
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _clean_website(self, website):
            // url = urls.url_parse(website)
            // if not url.scheme:
            //     if not url.netloc:
            //         url = url.replace(netloc=url.path, path='')
            //     website = url.replace(scheme='http').to_url()
            // return website
            */
            return default;
        }

        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def clone_page(self, page_id, page_name=None, clone_menu=True):
            // """ Clone a page, given its identifier
            //     :param page_id : website.page identifier
            // """
            // page = self.browse(int(page_id))
            // copy_param = dict(name=page_name or page.name, website_id=self.env['website'].get_current_website().id)
            // if page_name:
            //     url = '/' + self.env['ir.http']._slugify(page_name, max_length=1024, path=True)
            //     copy_param['url'] = self.env['website'].get_unique_path(url)
            // 
            // new_page = page.copy(copy_param)
            // # Should not clone menu if the page was cloned from one website to another
            // # Eg: Cloning a generic page (no website) will create a page with a website, we can't clone menu (not same container)
            // if clone_menu and new_page.website_id == page.website_id:
            //     menu = self.env['website.menu'].search([('page_id', '=', page_id)], limit=1)
            //     if menu:
            //         # If the page being cloned has a menu, clone it too
            //         menu.copy({'url': new_page.url, 'name': new_page.name, 'page_id': new_page.id})
            // 
            // return new_page.url
            */
            return default;
        }

        public async Task<TEntity> CloseDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def close_dialog(self):
            // return {'type': 'ir.actions.act_window_close'}
            */
            return default;
        }

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _commercial_fields(self):
            // return super(ResPartner, self)._commercial_fields() + \
            //     ['debit_limit', 'property_account_payable_id', 'property_account_receivable_id', 'property_account_position_id',
            //      'property_payment_term_id', 'property_supplier_payment_term_id', 'credit_limit']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['property_product_pricelist']
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super(res_partner, self)._commercial_fields()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. These fields are meant to be hidden on
            // partners that aren't `commercial entities` themselves, and will be
            // delegated to the parent `commercial entity`. The list is meant to be
            // extended by inheriting classes. """
            // return ['vat', 'company_registry', 'industry_id']
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_from_company(self):
            // """ Handle sync of commercial fields when a new parent commercial entity is set,
            // as if they were related fields """
            // commercial_partner = self.commercial_partner_id
            // if commercial_partner != self:
            //     sync_vals = commercial_partner._update_fields_values(self._commercial_fields())
            //     self.write(sync_vals)
            //     self._company_dependent_commercial_sync()
            //     self._commercial_sync_to_children()
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_to_children(self, fields_to_sync=None):
            // """ Handle sync of commercial fields to descendants """
            // commercial_partner = self.commercial_partner_id
            // if fields_to_sync is None:
            //     fields_to_sync = self._commercial_fields()
            // sync_vals = commercial_partner._update_fields_values(fields_to_sync)
            // sync_children = self.child_ids.filtered(lambda c: not c.is_company)
            // for child in sync_children:
            //     child._commercial_sync_to_children(fields_to_sync)
            // res = sync_children.write(sync_vals)
            // return res
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     *super()._company_dependent_commercial_fields(),
            //     'specific_property_product_pricelist'
            // ]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     fname for fname in self._commercial_fields()
            //     if self._fields[fname].company_dependent
            // ]
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_sync(self):
            // if not (fields_to_sync := self._company_dependent_commercial_fields()):
            //     return
            // 
            // for company_sudo in self.env['res.company'].sudo().search([]):
            //     if company_sudo == self.env.company:
            //         continue  # already handled by _commercial_sync_from_company
            //     self_in_company = self.with_company(company_sudo)
            //     self_in_company.write(
            //         self_in_company.commercial_partner_id._update_fields_values(fields_to_sync)
            //     )
            */
            return default;
        }

        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_active_lang_count(self):
            // lang_count = len(self.env['res.lang'].get_installed())
            // for partner in self:
            //     partner.active_lang_count = lang_count
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_activities(self):
            // self.env.cr.execute("""
            //     SELECT
            //         app.job_id,
            //         COUNT(*) AS act_count,
            //         CASE
            //             WHEN %(today)s::date - act.date_deadline::date = 0 THEN 'today'
            //             WHEN %(today)s::date - act.date_deadline::date > 0 THEN 'overdue'
            //         END AS act_state
            //      FROM mail_activity act
            //      JOIN hr_applicant app ON app.id = act.res_id
            //      JOIN hr_recruitment_stage sta ON app.stage_id = sta.id
            //     WHERE act.user_id = %(user_id)s AND act.res_model = 'hr.applicant'
            //       AND act.date_deadline <= %(today)s::date AND app.active
            //       AND app.job_id IN %(job_ids)s
            //       AND sta.hired_stage IS NOT TRUE
            //     GROUP BY app.job_id, act_state
            // """, {
            //     'today': fields.Date.context_today(self),
            //     'user_id': self.env.uid,
            //     'job_ids': tuple(self.ids),
            // })
            // job_activities = defaultdict(dict)
            // for activity in self.env.cr.dictfetchall():
            //     job_activities[activity['job_id']][activity['act_state']] = activity['act_count']
            // for job in self:
            //     job.activities_overdue = job_activities[job.id].get('overdue', 0)
            //     job.activities_today = job_activities[job.id].get('today', 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_inline(self):
            // """Use venue address if available, otherwise its name, finally ''. """
            // for event in self:
            //     if (event.address_id.contact_address or '').strip():
            //         event.address_inline = ', '.join(
            //             frag.strip()
            //             for frag in event.address_id.contact_address.split('\n') if frag.strip()
            //         )
            //     else:
            //         event.address_inline = event.address_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_search(self):
            // for event in self:
            //     event.address_search = event.address_id
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_all_application_count(self):
            // read_group_result = self.env['hr.applicant'].with_context(active_test=False)._read_group([
            //     ('job_id', 'in', self.ids),
            //     '|',
            //         ('active', '=', True),
            //         '&',
            //         ('active', '=', False), ('refuse_reason_id', '!=', False),
            // ], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.all_application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_applicant_hired(self):
            // hired_stages = self.env['hr.recruitment.stage'].search([('hired_stage', '=', True)])
            // hired_data = self.env['hr.applicant']._read_group([
            //     ('job_id', 'in', self.ids),
            //     ('stage_id', 'in', hired_stages.ids),
            // ], ['job_id'], ['__count'])
            // job_hires = {job.id: count for job, count in hired_data}
            // for job in self:
            //     job.applicant_hired = job_hires.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_application_count(self):
            // read_group_result = self.env['hr.applicant']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _compute_available_peppol_edi_formats(self):
            // for partner in self:
            //     if partner.invoice_sending_method == 'peppol':
            //         partner.available_peppol_edi_formats = self._get_peppol_formats()
            //     else:
            //         partner.available_peppol_edi_formats = list(dict(self._fields['invoice_edi_format'].selection))
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _compute_available_peppol_sending_methods(self):
            // methods = dict(self._fields['invoice_sending_method'].selection)
            // if self.env.company.country_code not in PEPPOL_LIST:
            //     methods.pop('peppol')
            // self.available_peppol_sending_methods = list(methods)
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // partners_with_internal_user = self.filtered(lambda partner: partner.user_ids - partner.user_ids.filtered('share'))
            // super(Partner, partners_with_internal_user)._compute_avatar(avatar_field, image_field)
            // partners_without_image = (self - partners_with_internal_user).filtered(lambda p: not p[image_field])
            // for _, group in tools.groupby(partners_without_image, key=lambda p: p._avatar_get_placeholder_path()):
            //     group_partners = self.env['res.partner'].concat(*group)
            //     group_partners[avatar_field] = base64.b64encode(group_partners[0]._avatar_get_placeholder())
            // 
            // for partner in self - partners_with_internal_user - partners_without_image:
            //     partner[avatar_field] = partner[image_field]
            */
            return default;
        }

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_bank_count(self):
            // bank_data = self.env['res.partner.bank']._read_group([('partner_id', 'in', self.ids)], ['partner_id'], ['__count'])
            // mapped_data = {partner.id: count for partner, count in bank_data}
            // for partner in self:
            //     partner.bank_account_count = mapped_data.get(partner.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_barcode(self):
            // self._compute_template_field_from_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_name(self):
            // for template in self:
            //     template.base_unit_name = template.base_unit_id.name or template.uom_name
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_price(self):
            // for template in self:
            //     template.base_unit_price = template._get_base_unit_price(template.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_bom_count(self):
            // for product in self:
            //     product.bom_count = self.env['mrp.bom'].search_count(['|', ('product_tmpl_id', '=', product.id), ('byproduct_ids.product_id.product_tmpl_id', '=', product.id)])
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_bom_ids(self):
            // results = self.env['mrp.bom']._read_group([('subcontractor_ids.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['subcontractor_ids'], ['id:array_agg'])
            // for partner in self:
            //     bom_ids = []
            //     for subcontractor, ids in results:
            //         if partner.id == subcontractor.id or subcontractor.id in partner.child_ids.ids:
            //             bom_ids += ids
            //     partner.bom_ids = bom_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _compute_booth_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.booth_menu = event.event_type_id.booth_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.booth_menu):
            //         event.booth_menu = True
            //     elif not event.website_menu:
            //         event.booth_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_can_be_expensed(self):
            // self.filtered(lambda p: p.type not in ['consu', 'service'] or not p.purchase_ok).update({'can_be_expensed': False})
            */
            return default;
        }

        public async Task<TEntity> ComputeCanGenerateReturnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_can_generate_return(self):
            // for carrier in self:
            //     carrier.can_generate_return = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for template in self.with_context(bin_size=False):
            //     template.can_image_1024_be_zoomed = template.image_1920 and is_image_size_above(template.image_1920, template.image_1024)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def _compute_can_publish(self):
            // self2 = self.with_context(can_publish_unsudo_main_object=False)
            // super(Partner, self2)._compute_can_publish()
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_can_publish(self):
            // if self.env.user.has_group('website.group_website_designer'):
            //     for record in self:
            //         record.can_publish = True
            // # FIXME this makes it so no-rights internal users *see* the publish
            // # button for website pages (although they cannot use it)
            // else:
            //     super()._compute_can_publish()
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

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_can_upload(self):
            // for record in self:
            //     if record.user_id == self.env.user:
            //         record.can_upload = True
            //     elif record.upload_group_ids:
            //         record.can_upload = bool(record.upload_group_ids & self.env.user.groups_id)
            //     else:
            //         record.can_upload = self.env.user.has_group('website_slides.group_website_slides_manager')
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def _compute_certifications_company_count(self):
            // self.certifications_company_count = sum(child.certifications_count for child in self.child_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def _compute_certifications_count(self):
            // read_group_res = self.env['survey.user_input'].sudo()._read_group(
            //     [('partner_id', 'in', self.ids), ('scoring_success', '=', True)],
            //     ['partner_id'], ['__count']
            // )
            // data = {partner.id: count for partner, count in read_group_res}
            // for partner in self:
            //     partner.certifications_count = data.get(partner.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _compute_color(self):
            // """Automatically set the color field based on the selected category."""
            // for product in self:
            //     if product.pos_categ_ids:
            //         product.color = product.pos_categ_ids[0].color
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_company_name(self):
            // for partner in self:
            //     p = partner.commercial_partner_id
            //     partner.commercial_company_name = p.is_company and p.name or partner.company_name
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_partner(self):
            // for partner in self:
            //     if partner.is_company or not partner.parent_id:
            //         partner.commercial_partner_id = partner
            //     else:
            //         partner.commercial_partner_id = partner.parent_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ Set False in base module. Sub modules will add their own logic
            // (meet or track_quiz). """
            // for event in self:
            //     event.community_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # exists to allow overrides
            // for company in self:
            //     company.company_registry = company.company_registry
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_label(self):
            // label_by_country = self._get_company_registry_labels()
            // for company in self:
            //     country_code = company.country_id.code
            //     company.company_registry_label = label_by_country.get(country_code, _("Company ID"))
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _compute_contact_address_inline(self):
            // """Compute an inline-friendly address based on contact_address."""
            // for partner in self:
            //     # replace any successive \n with a single comma
            //     partner.contact_address_inline = re.sub(r'\n(\s|\n)*', ', ', partner.contact_address).strip().strip(',')
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py) ---
            // def _compute_count_active_cards(self):
            // loyalty_groups = self.env['loyalty.card']._read_group(
            //     domain=[
            //         '|', ('company_id', '=', False), ('company_id', 'in', self.env.companies.ids),
            //         ('partner_id', 'in', self.with_context(active_test=False)._search([('id', 'child_of', self.ids)])),
            //         ('points', '>', '0'),
            //         ('program_id.active', '=', True),
            //         '|',
            //             ('expiration_date', '>=', fields.Date().context_today(self)),
            //             ('expiration_date', '=', False),
            //     ],
            //     groupby=['partner_id'],
            //     aggregates=['__count'],
            // )
            // self.loyalty_card_count = 0
            // for partner, count in loyalty_groups:
            //     while partner:
            //         if partner in self:
            //             partner.loyalty_card_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_credit_to_invoice(self):
            // # To be overridden in Sales
            // self.credit_to_invoice = False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _compute_credit_to_invoice(self):
            // # EXTENDS 'account'
            // super()._compute_credit_to_invoice()
            // if not (commercial_partners := self.commercial_partner_id & self):
            //     return  # nothing to compute
            // company = self.env.company
            // if not company.account_use_credit_limit:
            //     return
            // 
            // sale_orders = self.env['sale.order'].search([
            //     ('company_id', '=', company.id),
            //     ('partner_invoice_id', 'any', [
            //         ('commercial_partner_id', 'in', commercial_partners.ids),
            //     ]),
            //     ('order_line', 'any', [('untaxed_amount_to_invoice', '>', 0)]),
            //     ('state', '=', 'sale'),
            // ])
            // for (partner, currency), orders in sale_orders.grouped(
            //     lambda so: (so.partner_invoice_id, so.currency_id),
            // ).items():
            //     amount_to_invoice_sum = sum(orders.mapped('amount_to_invoice'))
            //     credit_company_currency = currency._convert(
            //         amount_to_invoice_sum,
            //         company.currency_id,
            //         company,
            //         fields.Date.context_today(self),
            //     )
            //     partner.commercial_partner_id.credit_to_invoice += credit_company_currency
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object price, object conversion) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_currency(self, order, price, conversion):
            // from_currency, to_currency = self._get_conversion_currencies(order, conversion)
            // if from_currency.id == to_currency.id:
            //     return price
            // return from_currency._convert(price, to_currency, order.company_id, order.date_order or fields.Date.today())
            */
            return default;
        }

        public async Task<TEntity> ComputeDateBeginTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_begin_tz(self):
            // for event in self:
            //     if event.date_begin:
            //         event.date_begin_located = format_datetime(
            //             self.env, event.date_begin, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_begin_located = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateEndTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_end_tz(self):
            // for event in self:
            //     if event.date_end:
            //         event.date_end_located = format_datetime(
            //             self.env, event.date_end, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_end_located = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_tz(self):
            // for event in self:
            //     if event.event_type_id.default_timezone:
            //         event.date_tz = event.event_type_id.default_timezone
            //     if not event.date_tz:
            //         event.date_tz = self.env.user.tz or 'UTC'
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_days_sales_outstanding(self):
            // commercial_partners = {
            //     commercial_partner: (invoice_date_min, amount_total_signed_sum)
            //     for commercial_partner, invoice_date_min, amount_total_signed_sum in self.env['account.move']._read_group(
            //         domain=[
            //             ('state', 'not in', ['draft', 'cancel']),
            //             ('move_type', 'in', self.env["account.move"].get_sale_types(include_receipts=True)),
            //             ('company_id', '=', self.env.company.id),
            //             ('commercial_partner_id', 'in', self.commercial_partner_id.ids),
            //         ],
            //         groupby=['commercial_partner_id'],
            //         aggregates=['invoice_date:min', 'amount_total_signed:sum'],
            //     )
            // }
            // for partner in self:
            //     oldest_invoice_date, total_invoiced_tax_included = commercial_partners.get(partner, (fields.Date.context_today(self), 0))
            //     days_since_oldest_invoice = (fields.Date.context_today(self) - oldest_invoice_date).days
            //     partner.days_sales_outstanding = ((partner.credit / total_invoiced_tax_included) * days_since_oldest_invoice) if total_invoiced_tax_included else 0
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_default_code(self):
            // self._compute_template_field_from_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if not self._context.get('display_website') or not self.env.user.has_group('website.group_multi_website'):
            //     return
            // for partner in self:
            //     if partner.website_id:
            //         partner.display_name += f' [{partner.website_id.name}]'
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_document_ids(self):
            // applicants = self.mapped('application_ids').filtered(lambda self: not self.employee_id)
            // app_to_job = dict((applicant.id, applicant.job_id.id) for applicant in applicants)
            // attachments = self.env['ir.attachment'].search([
            //     '|',
            //     '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //     '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', applicants.ids)])
            // result = dict.fromkeys(self.ids, self.env['ir.attachment'])
            // for attachment in attachments:
            //     if attachment.res_model == 'hr.applicant':
            //         result[app_to_job[attachment.res_id]] |= attachment
            //     else:
            //         result[attachment.res_id] |= attachment
            // 
            // for job in self:
            //     job.document_ids = result.get(job.id, False)
            //     job.documents_count = len(job.document_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedBankAccountPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_duplicated_bank_account_partners_count(self):
            // for partner in self:
            //     partner.duplicated_bank_account_partners_count = len(partner._get_duplicated_bank_accounts())
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_email_formatted(self):
            // """ Compute formatted email for partner, using formataddr. Be defensive
            // in computation, notably
            // 
            //   * double format: if email already holds a formatted email like
            //     'Name' <email@domain.com> we should not use it as it to compute
            //     email formatted like "Name <'Name' <email@domain.com>>";
            //   * multi emails: sometimes this field is used to hold several addresses
            //     like email1@domain.com, email2@domain.com. We currently let this value
            //     untouched, but remove any formatting from multi emails;
            //   * invalid email: if something is wrong, keep it in email_formatted as
            //     this eases management and understanding of failures at mail.mail,
            //     mail.notification and mailing.trace level;
            //   * void email: email_formatted is False, as we cannot do anything with
            //     it;
            // """
            // self.email_formatted = False
            // for partner in self:
            //     emails_normalized = tools.email_normalize_all(partner.email)
            //     if emails_normalized:
            //         # note: multi-email input leads to invalid email like "Name" <email1, email2>
            //         # but this is current behavior in Odoo 14+ and some servers allow it
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             ','.join(emails_normalized)
            //         ))
            //     elif partner.email:
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             partner.email
            //         ))
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _compute_employees_count(self):
            // for partner in self:
            //     partner.employees_count = len(partner.sudo().employee_ids.filtered(lambda e: e.company_id in self.env.companies))
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def _compute_employees(self):
            // employee_data = self.env['hr.employee']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in employee_data}
            // for job in self:
            //     job.no_of_employee = result.get(job.id, 0)
            //     job.expected_employees = result.get(job.id, 0) + job.no_of_recruitment
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_enroll(self):
            // self.filtered(lambda channel: channel.visibility == 'members').enroll = 'invite'
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_available_ids(self):
            // for event in self:
            //     event.event_booth_category_available_ids = event.event_booth_ids.filtered(lambda booth: booth.is_available).mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_ids(self):
            // for event in self:
            //     event.event_booth_category_ids = event.event_booth_ids.mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_count(self):
            // if self.ids and all(bool(event.id) for event in self):  # no new/onchange mode -> optimized
            //     booths_available_count, booths_total_count = self._get_booth_stat_count()
            //     for event in self:
            //         event.event_booth_count_available = booths_available_count.get(event.id, 0)
            //         event.event_booth_count = booths_total_count.get(event.id, 0)
            // else:
            //     for event in self:
            //         event.event_booth_count = len(event.event_booth_ids)
            //         event.event_booth_count_available = len(event.event_booth_ids.filtered(lambda booth: booth.is_available))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing booths:
            // 
            //   * lines that are available are removed;
            //   * template lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_booth_ids:
            //         event.event_booth_ids = False
            //         continue
            // 
            //     # booths to keep: those that are not available
            //     booths_to_remove = event.event_booth_ids.filtered(lambda booth: booth.is_available)
            //     command = [Command.unlink(booth.id) for booth in booths_to_remove]
            //     if event.event_type_id.event_type_booth_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.booth']._get_event_booth_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_booth_ids
            //         ]
            //     event.event_booth_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_event_count(self):
            // self.event_count = 0
            // for partner in self:
            //     partner.event_count = self.env['event.event'].search_count([('registration_ids.partner_id', 'child_of', partner.ids)])
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_mail_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing mails:
            // 
            //   * lines that are not sent and have no registrations linked are remove;
            //   * type lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_mail_ids:
            //         event.event_mail_ids = self._default_event_mail_ids()
            //         continue
            // 
            //     # lines to keep: those with already sent emails or registrations
            //     mails_to_remove = event.event_mail_ids.filtered(
            //         lambda mail: not(mail._origin.mail_done) and not(mail._origin.mail_registration_ids)
            //     )
            //     command = [Command.unlink(mail.id) for mail in mails_to_remove]
            // 
            //     # lines to add: those which do not have the exact copy available in lines to keep
            //     if event.event_type_id.event_type_mail_ids:
            //         mails_to_keep_vals = {frozendict(mail._prepare_event_mail_values()) for mail in event.event_mail_ids - mails_to_remove}
            //         for mail in event.event_type_id.event_type_mail_ids:
            //             mail_values = frozendict(mail._prepare_event_mail_values())
            //             if mail_values not in mails_to_keep_vals:
            //                 command.append(Command.create(mail_values))
            //     if command:
            //         event.event_mail_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_register_url(self):
            // for event in self:
            //     event.event_register_url = werkzeug.urls.url_join(event.get_base_url(), f"{event.website_url}/register")
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_open(self):
            // """ Compute whether people may take registrations for this event
            // 
            //   * event.date_end -> if event is done, registrations are not open anymore;
            //   * event.start_sale_datetime -> lowest start date of tickets (if any; start_sale_datetime
            //     is False if no ticket are defined, see _compute_start_sale_date);
            //   * any ticket is available for sale (seats available) if any;
            //   * seats are unlimited or seats are available;
            // """
            // for event in self:
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     date_end_tz = event.date_end.astimezone(pytz.timezone(event.date_tz or 'UTC')) if event.date_end else False
            //     event.event_registrations_open = event.event_registrations_started and \
            //         (date_end_tz >= current_datetime if date_end_tz else True) and \
            //         (not event.seats_limited or not event.seats_max or event.seats_available) and \
            //         (not event.event_ticket_ids or any(ticket.sale_available for ticket in event.event_ticket_ids))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_sold_out(self):
            // """Note that max seats limits for events and sum of limits for all its tickets may not be
            // equal to enable flexibility.
            // E.g. max 20 seats for ticket A, 20 seats for ticket B
            //     * With max 20 seats for the event
            //     * Without limit set on the event (=40, but the customer didn't explicitly write 40)
            // """
            // for event in self:
            //     event.event_registrations_sold_out = (
            //         (event.seats_limited and event.seats_max and not event.seats_available)
            //         or (event.event_ticket_ids and all(ticket.is_sold_out for ticket in event.event_ticket_ids))
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_started(self):
            // for event in self:
            //     event = event._set_tz_context()
            //     if event.start_sale_datetime:
            //         current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //         start_sale_datetime = fields.Datetime.context_timestamp(event, event.start_sale_datetime)
            //         event.event_registrations_started = (current_datetime >= start_sale_datetime)
            //     else:
            //         event.event_registrations_started = True
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_ticket_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing tickets:
            // 
            //   * lines that have no registrations linked are remove;
            //   * type lines are added;
            // 
            // Note that updating event_ticket_ids triggers _compute_start_sale_date
            // (start_sale_datetime computation) so ensure result to avoid cache miss.
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_ticket_ids:
            //         event.event_ticket_ids = False
            //         continue
            // 
            //     # lines to keep: those with existing registrations
            //     tickets_to_remove = event.event_ticket_ids.filtered(lambda ticket: not ticket._origin.registration_ids)
            //     command = [Command.unlink(ticket.id) for ticket in tickets_to_remove]
            //     if event.event_type_id.event_type_ticket_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.ticket']._get_event_ticket_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_ticket_ids
            //         ]
            //     event.event_ticket_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_exhibitor_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.exhibitor_menu = event.event_type_id.exhibitor_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.exhibitor_menu):
            //         event.exhibitor_menu = True
            //     elif not event.website_menu:
            //         event.exhibitor_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_extended_interviewer_ids(self):
            // # Use SUPERUSER_ID as the search_read is protected in hr_referral
            // results_raw = self.env['hr.applicant'].with_user(SUPERUSER_ID).search_read([
            //     ('job_id', 'in', self.ids),
            //     ('interviewer_ids', '!=', False)
            // ], ['interviewer_ids', 'job_id'])
            // interviewers_by_job = defaultdict(set)
            // for result_raw in results_raw:
            //     interviewers_by_job[result_raw['job_id'][0]] |= set(result_raw['interviewer_ids'])
            // for job in self:
            //     job.extended_interviewer_ids = [(6, 0, list(interviewers_by_job[job.id]))]
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_field_is_one_day(self):
            // for event in self:
            //     # Need to localize because it could begin late and finish early in
            //     # another timezone
            //     event = event._set_tz_context()
            //     begin_tz = fields.Datetime.context_timestamp(event, event.date_begin)
            //     end_tz = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_one_day = (begin_tz.date() == end_tz.date())
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeFixedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_fixed_price(self):
            // for carrier in self:
            //     carrier.fixed_price = carrier.product_id.list_price
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_full_url(self):
            // for job in self:
            //     job.full_url = url_join(job.get_base_url(), (job.website_url or '/jobs'))
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_product_uid(self):
            // self._compute_template_field_from_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_has_available_route_ids(self):
            // self.has_available_route_ids = self.env['stock.route'].search_count([('product_selectable', '=', True)])
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeHasLeadRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_has_lead_request(self):
            // lead_requests_data = self.env['event.lead.request']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_requests_data}
            // for event in self:
            //     event.has_lead_request = mapped_data.get(event.id, 0) != 0
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_has_requested_access(self):
            // requested_cids = self.sudo().activity_search(
            //     ['website_slides.mail_activity_data_access_request'],
            //     additional_domain=[('request_partner_id', '=', self.env.user.partner_id.id)]
            // ).mapped('res_id')
            // for channel in self:
            //     channel.has_requested_access = channel.id in requested_cids
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // status_by_partner = {}
            // for presence in self.env["bus.presence"].search([("user_id", "in", self.user_ids.ids)]):
            //     partner = presence.user_id.partner_id
            //     if (
            //         status_by_partner.get(partner, "offline") == "offline"
            //         or presence.status == "online"
            //     ):
            //         status_by_partner[partner] = presence.status
            // for partner in self:
            //     default_status = "offline" if partner.user_ids else "im_partner"
            //     partner.im_status = status_by_partner.get(partner, default_status)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super(ResPartner, self)._compute_im_status()
            // absent_now = self._get_on_leave_ids()
            // for partner in self:
            //     if partner.id in absent_now:
            //         if partner.im_status == 'online':
            //             partner.im_status = 'leave_online'
            //         elif partner.im_status == 'away':
            //             partner.im_status = 'leave_away'
            //         elif partner.im_status == 'offline':
            //             partner.im_status = 'leave_offline'
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // for user in self.user_ids:
            //     dayfield = self.env['hr.employee']._get_current_day_location_field()
            //     location_type = user[dayfield].location_type
            //     if not location_type:
            //         continue
            //     im_status = user.partner_id.im_status
            //     if im_status == "online" or im_status == "away" or im_status == "offline":
            //         user.partner_id.im_status = location_type + "_" + im_status
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // odoobot_id = self.env['ir.model.data']._xmlid_to_res_id('base.partner_root')
            // odoobot = self.env['res.partner'].browse(odoobot_id)
            // if odoobot in self:
            //     odoobot.im_status = 'bot'
            */
            return default;
        }

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_implemented_partner_count(self):
            // rg_result = self.env['res.partner']._read_group(
            //     [('assigned_partner_id', 'in', self.ids),
            //      ('is_published', '=', True)],
            //     ['assigned_partner_id'],
            //     ['__count'],
            // )
            // rg_data = {assigned_partner.id: count for assigned_partner, count in rg_result}
            // for partner in self:
            //     partner.implemented_partner_count = rg_data.get(partner.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_invoice_edi_format(self):
            // for partner in self:
            //     if not partner.commercial_partner_id or partner.commercial_partner_id.invoice_edi_format_store == 'none':
            //         partner.invoice_edi_format = False
            //     else:
            //         partner.invoice_edi_format = partner.commercial_partner_id.invoice_edi_format_store or partner.commercial_partner_id._get_suggested_invoice_edi_format()
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_invoice_policy(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.invoice_policy).invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_is_favorite(self):
            // for job in self:
            //     job.is_favorite = self.env.user in job.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_finished(self):
            // for event in self:
            //     if not event.date_end:
            //         event.is_finished = False
            //         continue
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     datetime_end = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_finished = datetime_end <= current_datetime
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_is_homepage(self):
            // website = self.env['website'].get_current_website()
            // for page in self:
            //     page.is_homepage = page.url == (website.homepage_url or page.website_id == website and '/')
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def _compute_is_mondialrelay(self):
            // for c in self:
            //     c.is_mondialrelay = c.product_id.default_code == "MR"
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_ongoing(self):
            // now = fields.Datetime.now()
            // for event in self:
            //     event.is_ongoing = event.date_begin <= now < event.date_end
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_participating(self):
            // participating_events = self._fetch_is_participating_events()
            // participating_events.is_participating = True
            // (self - participating_events).is_participating = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_peppol_edi_format(self):
            // for partner in self:
            //     partner.is_peppol_edi_format = partner.invoice_edi_format in self._get_peppol_formats()
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_is_public(self):
            // for partner in self.with_context(active_test=False):
            //     users = partner.user_ids
            //     partner.is_public = users and any(user._is_public() for user in users)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def compute_is_storable(self):
            // self.filtered(lambda t: t.type != 'consu' and t.is_storable).is_storable = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_is_subcontractor(self):
            // """ Determine whether the partner is a subcontractor (for giving sudo access) """
            // for partner in self:
            //     partner.is_subcontractor = (
            //         any(user._is_portal() for user in partner.user_ids)
            //         and partner.env['mrp.bom'].search_count([
            //             ('type', '=', 'subcontract'),
            //             ('subcontractor_ids', 'in', (partner | partner.commercial_partner_id).ids),
            //         ], limit=1)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_ubl_format(self):
            // for partner in self:
            //     partner.is_ubl_format = partner.invoice_edi_format in self._get_ubl_cii_formats()
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_visible_on_website(self):
            // if all(event.website_visibility == 'public' for event in self):
            //     self.is_visible_on_website = True
            //     return
            // for event in self:
            //     if event.website_visibility == 'public' or event.is_participating:
            //         event.is_visible_on_website = True
            //     elif not self.env.user._is_public() and event.website_visibility == 'logged_users':
            //         event.is_visible_on_website = True
            //     else:
            //         event.is_visible_on_website = False
            */
            return default;
        }

        public async Task<TEntity> ComputeItemCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_item_count(self):
            // for template in self:
            //     # Pricelist item count counts the rules applicable on current template or on its variants.
            //     template.pricelist_item_count = template.env['product.pricelist.item'].search_count([
            //         '&',
            //         '|', ('product_tmpl_id', '=', template.id), ('product_id', 'in', template.product_variant_ids.ids),
            //         ('pricelist_id.active', '=', True),
            //         ('compute_price', '=', 'fixed'),
            //     ])
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalItemCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_journal_item_count(self):
            // AccountMoveLine = self.env['account.move.line']
            // for partner in self:
            //     partner.journal_item_count = AccountMoveLine.search_count([('partner_id', '=', partner.id)])
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_kanban_state_label(self):
            // for event in self:
            //     if event.kanban_state == 'normal':
            //         event.kanban_state_label = event.stage_id.legend_normal
            //     elif event.kanban_state == 'blocked':
            //         event.kanban_state_label = event.stage_id.legend_blocked
            //     else:
            //         event.kanban_state_label = event.stage_id.legend_done
            */
            return default;
        }

        public async Task<TEntity> ComputeLastWebsiteSoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _compute_last_website_so_id(self):
            // SaleOrder = self.env['sale.order']
            // for partner in self:
            //     is_public = partner.is_public
            //     website = ir_http.get_request_website()
            //     if website and not is_public:
            //         partner.last_website_so_id = SaleOrder.search([
            //             ('partner_id', '=', partner.id),
            //             ('pricelist_id', '=', partner.property_product_pricelist.id),
            //             ('website_id', '=', website.id),
            //             ('state', '=', 'draft'),
            //         ], order='write_date desc', limit=1)
            //     else:
            //         partner.last_website_so_id = SaleOrder
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_lead_count(self):
            // lead_data = self.env['crm.lead']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_data}
            // for event in self:
            //     event.lead_count = mapped_data.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _compute_meeting_count(self):
            // result = self._compute_meeting()
            // for p in self:
            //     p.meeting_count = len(result.get(p.id, []))
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _compute_meeting(self):
            // if self.ids:
            //     # prefetch 'parent_id'
            //     all_partners = self.with_context(active_test=False).search_fetch(
            //         [('id', 'child_of', self.ids)], ['parent_id'],
            //     )
            // 
            //     query = self.env['calendar.event']._search([])  # ir.rules will be applied
            //     meeting_data = self.env.execute_query(SQL("""
            //         SELECT res_partner_id, calendar_event_id, count(1)
            //           FROM calendar_event_res_partner_rel
            //          WHERE res_partner_id IN %s AND calendar_event_id IN %s
            //       GROUP BY res_partner_id, calendar_event_id
            //         """,
            //         all_partners._ids,
            //         query.subselect(),
            //     ))
            // 
            //     # Create a dict {partner_id: event_ids} and fill with events linked to the partner
            //     meetings = {}
            //     for p_id, m_id, _ in meeting_data:
            //         meetings.setdefault(p_id, set()).add(m_id)
            // 
            //     # Add the events linked to the children of the partner
            //     for p in self.browse(meetings.keys()):
            //         partner = p
            //         while partner.parent_id:
            //             partner = partner.parent_id
            //             if partner in self:
            //                 meetings[partner.id] = meetings.get(partner.id, set()) | meetings[p.id]
            //     return {p_id: list(meetings.get(p_id, set())) for p_id in self.ids}
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingRoomAllowCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_allow_creation(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.meeting_room_allow_creation = event.event_type_id.meeting_room_allow_creation
            //     elif event.community_menu and event.community_menu != event._origin.community_menu:
            //         event.meeting_room_allow_creation = True
            //     elif not event.community_menu or not event.meeting_room_allow_creation:
            //         event.meeting_room_allow_creation = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingRoomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_count(self):
            // meeting_room_count = self.env["event.meeting.room"].sudo()._read_group(
            //     domain=[("event_id", "in", self.ids)],
            //     groupby=['event_id'],
            //     aggregates=['__count'],
            // )
            // 
            // meeting_room_count = {
            //     event.id: count
            //     for event, count in meeting_room_count
            // }
            // 
            // for event in self:
            //     event.meeting_room_count = meeting_room_count.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeMembershipStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _compute_membership_state(self):
            // today = fields.Date.today()
            // for partner in self:
            //     partner.membership_start = self.env['membership.membership_line'].search([
            //         ('partner', 'in', (partner.associate_member or partner).ids), ('date_cancel', '=', False)
            //     ], limit=1, order='date_from').date_from
            //     partner.membership_stop = self.env['membership.membership_line'].search([
            //         ('partner', 'in', (partner.associate_member or partner).ids), ('date_cancel', '=', False)
            //     ], limit=1, order='date_to desc').date_to
            //     partner.membership_cancel = self.env['membership.membership_line'].search([
            //         ('partner', 'in', partner.ids)
            //     ], limit=1, order='date_cancel').date_cancel
            // 
            //     if partner.associate_member:
            //         partner.membership_state = partner.associate_member.membership_state
            //         continue
            // 
            //     if partner.free_member and partner.membership_state != 'paid':
            //         partner.membership_state = 'free'
            //         continue
            // 
            //     for mline in partner.member_lines:
            //         if (mline.date_to or date.min) >= today and (mline.date_from or date.min) <= today:
            //             partner.membership_state = mline.state
            //             break
            //         elif ((mline.date_from or date.min) < today and (mline.date_to or date.min) <= today and \
            //               (mline.date_from or date.min) < (mline.date_to or date.min)):
            //             if mline.account_invoice_id and mline.account_invoice_id.payment_state in ('in_payment', 'paid'):
            //                 partner.membership_state = 'old'
            //             elif mline.account_invoice_id and mline.account_invoice_id.state == 'cancel':
            //                 partner.membership_state = 'canceled'
            //             break
            //     else:
            //         partner.membership_state = 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeModelNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _compute_model_name(self):
            // for snippet_filter in self:
            //     if snippet_filter.filter_id:
            //         snippet_filter.model_name = snippet_filter.filter_id.model_id
            //     else:  # self.action_server_id
            //         snippet_filter.model_name = snippet_filter.action_server_id.model_id.model
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // for template in self:
            //     template.mrp_product_qty = float_round(sum(template.mapped('product_variant_ids').mapped('mrp_product_qty')), precision_rounding=template.uom_id.rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name(self):
            // for rec in self:
            //     rec.name = rec.view_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name_slugified(self):
            // for rec in self:
            //     if not rec.model_id:
            //         rec.name_slugified = False
            //         continue
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name or '')
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_new_application_count(self):
            // self.env.cr.execute(
            //     """
            //         WITH job_stage AS (
            //             SELECT DISTINCT ON (j.id) j.id AS job_id, s.id AS stage_id, s.sequence AS sequence
            //               FROM hr_job j
            //          LEFT JOIN hr_job_hr_recruitment_stage_rel rel
            //                 ON rel.hr_job_id = j.id
            //               JOIN hr_recruitment_stage s
            //                 ON s.id = rel.hr_recruitment_stage_id
            //                 OR s.id NOT IN (
            //                                 SELECT "hr_recruitment_stage_id"
            //                                   FROM "hr_job_hr_recruitment_stage_rel"
            //                                  WHERE "hr_recruitment_stage_id" IS NOT NULL
            //                                 )
            //              WHERE j.id in %s
            //           ORDER BY 1, 3 asc
            //         )
            //         SELECT s.job_id, COUNT(a.id) AS new_applicant
            //           FROM hr_applicant a
            //           JOIN job_stage s
            //             ON s.job_id = a.job_id
            //            AND a.stage_id = s.stage_id
            //            AND a.active IS TRUE
            //          WHERE a.company_id in %s
            //             OR a.company_id is NULL
            //       GROUP BY s.job_id
            //     """, [tuple(self.ids), tuple(self.env.companies.ids)]
            // )
            // 
            // new_applicant_count = dict(self.env.cr.fetchall())
            // for job in self:
            //     job.new_application_count = new_applicant_count.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_no_of_hired_employee(self):
            // counts = dict(self.env['hr.applicant']._read_group(
            //     domain=[
            //         ('job_id', 'in', self.ids),
            //         ('date_closed', '!=', False),
            //         '|',
            //             ('active', '=', False),
            //             ('active', '=', True),
            //     ],
            //     groupby=['job_id'],
            //     aggregates=['__count']))
            // for job in self:
            //     job.no_of_hired_employee = counts.get(job, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_note(self):
            // for event in self:
            //     if event.event_type_id and not is_html_empty(event.event_type_id.note):
            //         event.note = event.event_type_id.note
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_old_application_count(self):
            // for job in self:
            //     job.old_application_count = job.application_count - job.new_application_count
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py) ---
            // def _compute_on_time_rate(self):
            // date_order_days_delta = int(self.env['ir.config_parameter'].sudo().get_param('purchase_stock.on_time_delivery_days', default='365'))
            // order_lines = self.env['purchase.order.line'].search([
            //     ('partner_id', 'in', self.ids),
            //     ('date_order', '>', fields.Date.today() - timedelta(date_order_days_delta)),
            //     ('qty_received', '!=', 0),
            //     ('order_id.state', 'in', ['done', 'purchase']),
            //     ('product_id', 'in', self.env['product.product'].sudo()._search([('type', '!=', 'service')]))
            // ])
            // lines_quantity = defaultdict(lambda: 0)
            // moves = self.env['stock.move'].search([
            //     ('purchase_line_id', 'in', order_lines.ids),
            //     ('state', '=', 'done')])
            // # Fetch fields from db and put them in cache.
            // order_lines.read(['date_planned', 'partner_id', 'product_uom_qty'], load='')
            // moves.read(['purchase_line_id', 'date'], load='')
            // moves = moves.filtered(lambda m: m.date.date() <= m.purchase_line_id.date_planned.date())
            // for move, quantity in zip(moves, moves.mapped('quantity')):
            //     lines_quantity[move.purchase_line_id.id] += quantity
            // partner_dict = {}
            // for line in order_lines:
            //     on_time, ordered = partner_dict.get(line.partner_id, (0, 0))
            //     ordered += line.product_uom_qty
            //     on_time += lines_quantity[line.id]
            //     partner_dict[line.partner_id] = (on_time, ordered)
            // seen_partner = self.env['res.partner']
            // for partner, numbers in partner_dict.items():
            //     seen_partner |= partner
            //     on_time, ordered = numbers
            //     partner.on_time_rate = on_time / ordered * 100 if ordered else -1   # use negative number to indicate no data
            // (self - seen_partner).on_time_rate = -1
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_partner.py) ---
            // def _compute_opportunity_count(self):
            // self.opportunity_count = 0
            // if not self.env.user._has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)], ['parent_id'],
            // )
            // 
            // opportunity_data = self.env['crm.lead'].with_context(active_test=False)._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in opportunity_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.opportunity_count += count
            //         partner = partner.parent_id
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_opportunity_count(self):
            // super()._compute_opportunity_count()
            // if not self.env.user.has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // opportunity_data = self.env['crm.lead'].with_context(active_test=False)._read_group(
            //     [('partner_assigned_id', 'in', self.ids)],
            //     ['partner_assigned_id'], ['__count']
            // )
            // assign_counts = {partner_assigned.id: count for partner_assigned, count in opportunity_data}
            // for partner in self:
            //     partner.opportunity_count += assign_counts.get(partner.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputePackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.packaging_ids = p.product_variant_ids.packaging_ids
            //     else:
            //         p.packaging_ids = False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_partner_company_registry_placeholder(self):
            // """ Provides a dynamic placeholder on the company registry field for countries that may need it.
            // Add your country and the value you want in the _ref_company_registry map.
            // """
            // for partner in self:
            //     country_code = partner.country_id.code or ''
            //     partner.partner_company_registry_placeholder = _ref_company_registry.get(country_code.lower(), '')
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py) ---
            // def _compute_partner_iap_info(self):
            // partner_iaps = self.env['res.partner.iap'].sudo().search([('partner_id', 'in', self.ids)])
            // partner_iaps_per_partner = {
            //     partner_iap.partner_id: partner_iap
            //     for partner_iap in partner_iaps
            // }
            // 
            // for partner in self:
            //     partner_iap = partner_iaps_per_partner.get(partner)
            //     if partner_iap:
            //         partner.iap_enrich_info = partner_iap.iap_enrich_info
            //         partner.iap_search_domain = partner_iap.iap_search_domain
            //     else:
            //         partner.iap_enrich_info = False
            //         partner.iap_search_domain = False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_partner_share(self):
            // super_partner = self.env['res.users'].browse(SUPERUSER_ID).partner_id
            // if super_partner in self:
            //     super_partner.partner_share = False
            // for partner in self - super_partner:
            //     partner.partner_share = not partner.user_ids or not any(not user.share for user in partner.user_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_partner_vat_placeholder(self):
            // for partner in self:
            //     placeholder = _("/ if not applicable")
            //     if partner.country_id:
            //         expected_vat = _ref_vat.get(partner.country_id.code.lower())
            //         if expected_vat:
            //             placeholder = _("%s, or / if not applicable", expected_vat)
            // 
            //     partner.partner_vat_placeholder = placeholder
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_partner_weight(self):
            // for partner in self:
            //     partner.partner_weight = partner.grade_id.partner_weight if partner.grade_id else 0
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: res_partner.py) ---
            // def _compute_payment_token_count(self):
            // payments_data = self.env['payment.token']._read_group(
            //     [('partner_id', 'in', self.ids)], ['partner_id'], ['__count'],
            // )
            // partners_data = {partner.id: count for partner, count in payments_data}
            // for partner in self:
            //     partner.payment_token_count = partners_data.get(partner.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_peppol_eas(self):
            // """
            // If the country_code changes, recompute the EAS only if there is a country_code, it exists in the
            // EAS_MAPPING, and the current EAS is not consistent with the new country_code.
            // """
            // for partner in self:
            //     partner.peppol_eas = partner.peppol_eas
            //     country_code = partner._deduce_country_code()
            //     if country_code in EAS_MAPPING:
            //         eas_to_field = EAS_MAPPING[country_code]
            //         if partner.peppol_eas not in eas_to_field.keys():
            //             new_eas = next(iter(EAS_MAPPING[country_code].keys()))
            //             # Iterate on the possible EAS until a valid one is found
            //             for eas, field in eas_to_field.items():
            //                 if field and field in partner._fields and partner[field]:
            //                     if not partner._build_error_peppol_endpoint(eas, partner[field]):
            //                         new_eas = eas
            //                         break
            //             partner.peppol_eas = new_eas
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_peppol_endpoint(self):
            // """ If the EAS changes and a valid endpoint is available, set it. Otherwise, keep the existing value."""
            // for partner in self:
            //     partner.peppol_endpoint = partner.peppol_endpoint
            //     country_code = partner._deduce_country_code()
            //     if country_code in EAS_MAPPING:
            //         field = EAS_MAPPING[country_code].get(partner.peppol_eas)
            //         if field \
            //                 and field in partner._fields \
            //                 and partner[field] \
            //                 and not partner._build_error_peppol_endpoint(partner.peppol_eas, partner[field]):
            //             partner.peppol_endpoint = partner[field]
            */
            return default;
        }

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_perform_vies_validation(self):
            // """ Determine whether to show VIES validity on the current VAT number """
            // for partner in self:
            //     to_check = partner.vies_vat_to_check
            //     company_code = self.env.company.account_fiscal_country_id.code
            //     partner.perform_vies_validation = (
            //         to_check
            //         and not to_check[:2].upper() == company_code
            //         and self.env.company.vat_check_vies
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_picking_ids(self):
            // results = self.env['stock.picking']._read_group([('partner_id.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['partner_id'], ['id:array_agg'])
            // for partner in self:
            //     picking_ids = []
            //     for partner_rg, ids in results:
            //         if partner_rg.id == partner.id or partner_rg.id in partner.child_ids.ids:
            //             picking_ids += ids
            //     partner.picking_ids = picking_ids
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def _compute_pos_order(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // pos_order_data = self.env['pos.order']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.pos_order_count = 0
            // for partner, count in pos_order_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.pos_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_post_date(self):
            // for blog_post in self:
            //     if blog_post.published_date:
            //         blog_post.post_date = blog_post.published_date
            //     else:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _compute_product_pricelist(self):
            // res = self.env['product.pricelist']._get_partner_pricelist_multi(self._ids)
            // for partner in self:
            //     partner.property_product_pricelist = res.get(partner.id)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_count(self):
            // for template in self:
            //     template.product_variant_count = len(template.product_variant_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_id(self):
            // for p in self:
            //     p.product_variant_id = p.product_variant_ids[:1].id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_production_ids(self):
            // results = self.env['mrp.production']._read_group([('subcontractor_id.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['subcontractor_id'], ['id:array_agg'])
            // for partner in self:
            //     production_ids = []
            //     for subcontractor, ids in results:
            //         if partner.id == subcontractor.id or subcontractor.id in partner.child_ids.ids:
            //             production_ids += ids
            //     partner.production_ids = production_ids
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_published_date(self):
            // for job in self:
            //     job.published_date = job.website_published and fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: res_partner.py) ---
            // def _compute_purchase_order_count(self):
            // self.purchase_order_count = 0
            // if not self.env.user._has_group('purchase.group_purchase_user'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // purchase_order_groups = self.env['purchase.order']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count'],
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in purchase_order_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.purchase_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchased_product_qty(self):
            // for template in self.with_context(active_test=False):
            //     template.purchased_product_qty = float_round(sum(p.purchased_product_qty for
            //         p in template.product_variant_ids), precision_rounding=template.uom_id.rounding
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // res = self._compute_quantities_dict()
            // for template in self:
            //     template.qty_available = res[template.id]['qty_available']
            //     template.virtual_available = res[template.id]['virtual_available']
            //     template.incoming_qty = res[template.id]['incoming_qty']
            //     template.outgoing_qty = res[template.id]['outgoing_qty']
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_question_ids(self):
            // """ Update event questions from its event type. Depends are set only on
            // event_type_id itself to emulate an onchange. Changing event type content
            // itself should not trigger this method.
            // 
            // When synchronizing questions:
            // 
            //   * lines with no registered answers are removed;
            //   * type lines are added;
            // """
            // if self._origin.question_ids:
            //     # lines to keep: those with already given answers
            //     questions_tokeep_ids = self.env['event.registration.answer'].search(
            //         [('question_id', 'in', self._origin.question_ids.ids)]
            //     ).question_id.ids
            // else:
            //     questions_tokeep_ids = []
            // for event in self:
            //     if not event.event_type_id and not event.question_ids:
            //         event.question_ids = self._default_question_ids()
            //         continue
            // 
            //     if questions_tokeep_ids:
            //         questions_toremove = event._origin.question_ids.filtered(
            //             lambda question: question.id not in questions_tokeep_ids)
            //         command = [(3, question.id) for question in questions_toremove]
            //     else:
            //         command = [(5, 0)]
            //     event.question_ids = command
            // 
            //     # copy questions so changes in the event don't affect the event type
            //     event.question_ids += event.event_type_id.question_ids.copy({
            //         'event_type_id': False,
            //     })
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_rating_stats(self):
            // super(Channel, self)._compute_rating_stats()
            // for record in self:
            //     record.rating_avg_stars = record.rating_avg
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _compute_sale_order_count(self):
            // self.sale_order_count = 0
            // if not self.env.user._has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // sale_order_groups = self.env['sale.order']._read_group(
            //     domain=expression.AND([self._get_sale_order_domain_count(), [('partner_id', 'in', all_partners.ids)]]),
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in sale_order_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.sale_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceSubtotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def _compute_sale_price_subtotal(self):
            // """ Takes all the sale.order.lines related to this event and converts amounts
            // from the currency of the sale order to the currency of the event company.
            // 
            // To avoid extra overhead, we use conversion rates as of 'today'.
            // Meaning we have a number that can change over time, but using the conversion rates
            // at the time of the related sale.order would mean thousands of extra requests as we would
            // have to do one conversion per sale.order (and a sale.order is created every time
            // we sell a single event ticket). """
            // date_now = fields.Datetime.now()
            // event_subtotals = self.env['sale.order.line']._read_group(
            //     [('event_id', 'in', self.ids), ('price_subtotal', '!=', 0), ('state', '!=', 'cancel')],
            //     ['event_id', 'currency_id'],
            //     ['price_subtotal:sum'],
            // )
            // event_subtotals_mapping = dict.fromkeys(self._origin, 0)
            // for event, currency, sum_price_subtotal in event_subtotals:
            //     event_subtotals_mapping[event] += event.currency_id._convert(
            //         sum_price_subtotal,
            //         currency,
            //         event.company_id or self.env.company,
            //         date_now,
            //     )
            // 
            // for event in self:
            //     event.sale_price_subtotal = event_subtotals_mapping.get(event._origin, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_sales_count(self):
            // for product in self:
            //     product.sales_count = float_round(sum([p.sales_count for p in product.with_context(active_test=False).product_variant_ids]), precision_rounding=product.uom_id.rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_same_vat_partner_id(self):
            // for partner in self:
            //     # use _origin to deal with onchange()
            //     partner_id = partner._origin.id
            //     #active_test = False because if a partner has been deactivated you still want to raise the error,
            //     #so that you can reactivate it instead of creating a new one, which would loose its history.
            //     Partner = self.with_context(active_test=False).sudo()
            //     domain = [
            //         ('vat', '=', partner.vat),
            //     ]
            //     if partner.company_id:
            //         domain += [('company_id', 'in', [False, partner.company_id.id])]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     # For VAT number being only one character, we will skip the check just like the regular check_vat
            //     should_check_vat = partner.vat and len(partner.vat) != 1
            //     partner.same_vat_partner_id = should_check_vat and not partner.parent_id and Partner.search(domain, limit=1)
            //     # check company_registry
            //     domain = [
            //         ('company_registry', '=', partner.company_registry),
            //         ('company_id', 'in', [False, partner.company_id.id]),
            //     ]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     partner.same_company_registry_partner_id = bool(partner.company_registry) and not partner.parent_id and Partner.search(domain, limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats(self):
            // """ Determine available, reserved, used and taken seats. """
            // # initialize fields to 0
            // for event in self:
            //     event.seats_reserved = event.seats_used = event.seats_available = 0
            // # aggregate registrations by event and by state
            // state_field = {
            //     'open': 'seats_reserved',
            //     'done': 'seats_used',
            // }
            // base_vals = dict((fname, 0) for fname in state_field.values())
            // results = dict((event_id, dict(base_vals)) for event_id in self.ids)
            // if self.ids:
            //     query = """ SELECT event_id, state, count(event_id)
            //                 FROM event_registration
            //                 WHERE event_id IN %s AND state IN ('open', 'done') AND active = true
            //                 GROUP BY event_id, state
            //             """
            //     self.env['event.registration'].flush_model(['event_id', 'state', 'active'])
            //     self._cr.execute(query, (tuple(self.ids),))
            //     res = self._cr.fetchall()
            //     for event_id, state, num in res:
            //         results[event_id][state_field[state]] = num
            // 
            // # compute seats_available and expected
            // for event in self:
            //     event.update(results.get(event._origin.id or event.id, base_vals))
            //     if event.seats_max > 0:
            //         event.seats_available = event.seats_max - (event.seats_reserved + event.seats_used)
            // 
            //     event.seats_taken = event.seats_reserved + event.seats_used
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_limited(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if event.event_type_id.has_seats_limitation != event.seats_limited:
            //         event.seats_limited = event.event_type_id.has_seats_limitation
            //     if not event.seats_limited:
            //         event.seats_limited = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_max(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.event_type_id:
            //         event.seats_max = event.seats_max or 0
            //     else:
            //         event.seats_max = event.event_type_id.seats_max or 0
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_service_upsell_threshold_ratio(self):
            // product_uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_unit = self.env.ref('uom.product_uom_unit')
            // company_uom = self.env.company.timesheet_encode_uom_id
            // for record in self:
            //     if not record.uom_id or record.uom_id != uom_unit or\
            //        product_uom_hour.factor == record.uom_id.factor or\
            //        record.uom_id.category_id not in [product_uom_hour.category_id, uom_unit.category_id]:
            //         record.service_upsell_threshold_ratio = False
            //         continue
            //     else:
            //         timesheet_encode_uom = record.company_id.timesheet_encode_uom_id or company_uom
            //         record.service_upsell_threshold_ratio = f'(1 {record.uom_id.name} = {timesheet_encode_uom.factor / product_uom_hour.factor:.2f} {timesheet_encode_uom.name})'
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_show_credit_limit(self):
            // for partner in self:
            //     partner.show_credit_limit = self.env.company.account_use_credit_limit
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _compute_slide_channel_company_count(self):
            // for partner in self:
            //     if partner.is_company:
            //         partner.slide_channel_company_count = self.env['slide.channel'].sudo().search_count(
            //             [('partner_ids', 'in', partner.child_ids.ids)]
            //         )
            //     else:
            //         partner.slide_channel_company_count = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _compute_slide_channel_values(self):
            // data = {
            //     (partner.id, member_status): channel_ids
            //     for partner, member_status, channel_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         domain=[('partner_id', 'in', self.ids), ('member_status', '!=', 'invited')],
            //         groupby=['partner_id', 'member_status'],
            //         aggregates=['channel_id:array_agg']
            //     )
            // }
            // 
            // for partner in self:
            //     slide_channel_ids = data.get((partner.id, 'joined'), []) + data.get((partner.id, 'ongoing'), []) + data.get((partner.id, 'completed'), [])
            //     partner.slide_channel_ids = slide_channel_ids
            //     partner.slide_channel_completed_ids = self.env['slide.channel'].browse(data.get((partner.id, 'completed'), []))
            //     partner.slide_channel_count = len(slide_channel_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slide_last_update(self):
            // for record in self:
            //     record.slide_last_update = fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_sponsor_count(self):
            // data = self.env['event.sponsor']._read_group([('event_id', 'in', self.ids)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.sponsor_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_start_sale_date(self):
            // """ Compute the start sale date of an event. Currently lowest starting sale
            // date of tickets if they are used, of False. """
            // for event in self:
            //     start_dates = [ticket.start_sale_datetime for ticket in event.event_ticket_ids if not ticket.is_expired]
            //     event.start_sale_datetime = min(start_dates) if start_dates and all(start_dates) else False
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_static_map_url(self):
            // for partner in self:
            //     partner.static_map_url = partner._google_map_signed_img(zoom=13, width=598, height=200)
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_static_map_url_is_valid(self):
            // """Compute whether the link is valid.
            // 
            // This should only remain valid for a relatively short time.
            // Here, for the duration it is in cache.
            // """
            // session = requests.Session()
            // for partner in self:
            //     url = partner.static_map_url
            //     if not url:
            //         partner.static_map_url_is_valid = False
            //         continue
            // 
            //     is_valid = False
            //     # If the response isn't strictly successful, assume invalid url
            //     try:
            //         res = session.get(url, timeout=2)
            //         if res.ok and not res.headers.get('X-Staticmap-API-Warning'):
            //             is_valid = True
            //     except requests.exceptions.RequestException:
            //         pass
            // 
            //     partner.static_map_url_is_valid = is_valid
            */
            return default;
        }

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _compute_street_data(self):
            // """Splits street value into sub-fields.
            // Recomputes the fields of STREET_FIELDS when `street` of a partner is updated"""
            // for partner in self:
            //     partner.update(tools.street_split(partner.street))
            */
            return default;
        }

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_supplier_invoice_count(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // supplier_invoice_groups = self.env['account.move']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids),
            //             *self.env['account.move']._check_company_domain(self.env.company),
            //             ('move_type', 'in', ('in_invoice', 'in_refund'))],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.supplier_invoice_count = 0
            // for partner, count in supplier_invoice_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.supplier_invoice_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSupportsShippingInsuranceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _compute_supports_shipping_insurance(self):
            // for carrier in self:
            //     carrier.supports_shipping_insurance = False
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_tag_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.tag_ids and event.event_type_id.tag_ids:
            //         event.tag_ids = event.event_type_id.tag_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _compute_task_count(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // task_data = self.env['project.task']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.task_count = 0
            // for partner, count in task_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.task_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_tax_string(self):
            // for record in self:
            //     record.tax_string = record._construct_tax_string(record.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_teaser(self):
            // for blog_post in self:
            //     if blog_post.teaser_manual:
            //         blog_post.teaser = blog_post.teaser_manual
            //     else:
            //         content = text_from_html(blog_post.content, True)
            //         blog_post.teaser = content[:200] + '...'
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_ticket_instructions(self):
            // for event in self:
            //     if is_html_empty(event.ticket_instructions) and not \
            //        is_html_empty(event.event_type_id.ticket_instructions):
            //         event.ticket_instructions = event.event_type_id.ticket_instructions
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_time_data(self):
            // """ Compute start and remaining time. Do everything in UTC as we compute only
            // time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for event in self:
            //     date_begin_utc = utc.localize(event.date_begin, is_dst=False)
            //     date_end_utc = utc.localize(event.date_end, is_dst=False)
            //     event.is_ongoing = date_begin_utc <= now_utc <= date_end_utc
            //     event.is_done = now_utc > date_end_utc
            //     event.start_today = date_begin_utc.date() == now_utc.date()
            //     if date_begin_utc >= now_utc:
            //         td = date_begin_utc - now_utc
            //         event.start_remaining = int(td.total_seconds() / 60)
            //     else:
            //         event.start_remaining = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_track_count(self):
            // data = self.env['event.track']._read_group([('stage_id.is_cancel', '!=', True)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.track_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_tracking(self):
            // self.filtered(lambda t: not t.is_storable and t.tracking != 'none').tracking = 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_tracks_tag_ids(self):
            // for event in self:
            //     event.tracks_tag_ids = event.track_ids.mapped('tag_ids').filtered(lambda tag: tag.color != 0).ids
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUomPoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_uom_po_id(self):
            // for template in self:
            //     if not template.uom_po_id or template.uom_id.category_id != template.uom_po_id.category_id:
            //         template.uom_po_id = template.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_url_demo(self):
            // for rec in self:
            //     if not rec.name_slugified:
            //         rec.url_demo = ""
            //         continue
            //     url = ["", "model", rec.name_slugified]
            //     rec.url_demo = "/".join(url)
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_use_barcode(self):
            // use_barcode = self.env['ir.config_parameter'].sudo().get_param('event.use_event_barcode') == 'True'
            // for record in self:
            //     record.use_barcode = use_barcode
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_use_partner_credit_limit(self):
            // company_limit = self._fields['credit_limit'].get_company_dependent_fallback(self)
            // for partner in self:
            //     partner.use_partner_credit_limit = partner.credit_limit != company_limit
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_used_in_bom_count(self):
            // for template in self:
            //     template.used_in_bom_count = self.env['mrp.bom'].search_count(
            //         [('bom_line_ids.product_tmpl_id', '=', template.id)])
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_user_id(self):
            // """ Synchronize sales rep with parent if partner is a person """
            // for partner in self.filtered(lambda partner: not partner.user_id and partner.company_type == 'person' and partner.parent_id.user_id):
            //     partner.user_id = partner.parent_id.user_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _compute_user_livechat_username(self):
            // for partner in self:
            //     partner.user_livechat_username = next(iter(partner.user_ids.mapped('livechat_username')), False)
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_vies_valid(self):
            // """ Check the VAT number with VIES, if enabled."""
            // if not self.env['res.company'].sudo().search_count([('vat_check_vies', '=', True)]):
            //     self.vies_valid = False
            //     return
            // 
            // for partner in self:
            //     if not partner.vies_vat_to_check:
            //         partner.vies_valid = False
            //         continue
            //     if partner.parent_id and partner.parent_id.vies_vat_to_check == partner.vies_vat_to_check:
            //         partner.vies_valid = partner.parent_id.vies_valid
            //         continue
            //     try:
            //         _logger.info('Calling VIES service to check VAT for validation: %s', partner.vies_vat_to_check)
            //         vies_valid = check_vies(partner.vies_vat_to_check, timeout=10)
            //         partner.vies_valid = vies_valid['valid']
            //     except (OSError, InvalidComponent, zeep.exceptions.Fault) as e:
            //         if partner._origin.id:
            //             msg = ""
            //             if isinstance(e, OSError):
            //                 msg = _("Connection with the VIES server failed. The VAT number %s could not be validated.", partner.vies_vat_to_check)
            //             elif isinstance(e, InvalidComponent):
            //                 msg = _("The VAT number %s could not be interpreted by the VIES server.", partner.vies_vat_to_check)
            //             elif isinstance(e, zeep.exceptions.Fault):
            //                 msg = _('The request for VAT validation was not processed. VIES service has responded with the following error: %s', e.message)
            //             partner._origin.message_post(body=msg)
            //         _logger.warning("The VAT number %s failed VIES check.", partner.vies_vat_to_check)
            //         partner.vies_valid = False
            */
            return default;
        }

        public async Task<TEntity> ComputeViesVatToCheckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_vies_vat_to_check(self):
            // """ Retrieve the VAT number, if one such exists, to be used when checking against the VIES system """
            // eu_country_codes = self.env.ref('base.europe').country_ids.mapped('code')
            // for partner in self:
            //     # Skip checks when only one character is used. Some users like to put '/' or other as VAT to differentiate between
            //     # a partner for which they haven't yet input VAT, and one not subject to VAT
            //     if not partner.vat or len(partner.vat) == 1:
            //         partner.vies_vat_to_check = ''
            //         continue
            //     country_code, number = partner._split_vat(partner.vat)
            //     if not country_code.isalpha() and partner.country_id:
            //         country_code = partner.country_id.code
            //         number = partner.vat
            //     partner.vies_vat_to_check = (
            //         country_code.upper() in eu_country_codes or
            //         country_code.lower() in _region_specific_vat_codes
            //     ) and self._fix_vat_number(country_code + number, partner.country_id.id) or ''
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_visible(self):
            // for page in self:
            //     page.is_visible = page.website_published and (
            //         not page.date_publish or page.date_publish < fields.Datetime.now()
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume(self):
            // self._compute_template_field_from_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_default_background_image_url(self):
            // for channel in self:
            //     channel.website_default_background_image_url = f'website_slides/static/src/img/channel-{channel.channel_type}-default.jpg'
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu_data(self):
            // """ Synchronize with website_menu at change and let people update them
            // at will afterwards. """
            // for event in self:
            //     event.introduction_menu = event.website_menu
            //     event.location_menu = event.website_menu
            //     event.register_menu = event.website_menu
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_menu(self):
            // for page in self:
            //     page.is_in_menu = bool(page.menu_ids)
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu(self):
            // """ Also ensure a value for website_menu as it is a trigger notably for
            // track related menus. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_menu = event.event_type_id.website_menu
            //     elif not event.website_menu:
            //         event.website_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _compute_website_published(self):
            // current_website_id = self._context.get('website_id')
            // for record in self:
            //     if current_website_id:
            //         record.website_published = record.is_published and (not record.website_id or record.website_id.id == current_website_id)
            //     else:
            //         record.website_published = record.is_published
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_menu updated value. Also force True is track_proposal changes. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track = event.event_type_id.website_track
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.website_track):
            //         event.website_track = True
            //     elif not event.website_menu:
            //         event.website_track = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track_proposal(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_track updated value (both together True or False at update). """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track_proposal = event.event_type_id.website_track_proposal
            //     elif event.website_track != event._origin.website_track or not event.website_track or not event.website_track_proposal:
            //         event.website_track_proposal = event.website_track
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_url(self):
            // for page in self:
            //     page.website_url = page.url
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_website_url(self):
            // super(BlogPost, self)._compute_website_url()
            // for blog_post in self:
            //     if blog_post.id:
            //         blog_post.website_url = "/blog/%s/%s" % (self.env['ir.http']._slug(blog_post.blog_id), self.env['ir.http']._slug(blog_post))
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_url(self):
            // super(Event, self)._compute_website_url()
            // for event in self:
            //     if event.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         event.website_url = '/event/%s' % self.env['ir.http']._slug(event)
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_website_url(self):
            // super(Job, self)._compute_website_url()
            // for job in self:
            //     job.website_url = f'/jobs/{self.env["ir.http"]._slug(job)}'
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for product in self:
            //     if product.id:
            //         product.website_url = "/shop/%s" % self.env['ir.http']._slug(product)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_url(self):
            // super(Channel, self)._compute_website_url()
            // for channel in self:
            //     if channel.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = channel.get_base_url()
            //         channel.website_url = '%s/slides/%s' % (base_url, self.env['ir.http']._slug(channel))
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight(self):
            // self._compute_template_field_from_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _construct_tax_string(self, price):
            // currency = self.currency_id
            // res = self.taxes_id.filtered(lambda t: t.company_id == self.env.company).compute_all(
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

        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _convert_hu_local_to_eu_vat(self, local_vat):
            // if self.__check_tin_hu_companies_re.match(local_vat):
            //     return f'HU{local_vat[:8]}'
            // return False
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def copy(self, default=None):
            // res = super().copy(default=default)
            // # Since we don't copy the product template attribute values, we need to match the extra prices.
            // for ptal, copied_ptal in zip(self.attribute_line_ids, res.attribute_line_ids):
            //     for ptav, copied_ptav in zip(ptal.product_template_value_ids, copied_ptal.product_template_value_ids):
            //         if not ptav.price_extra:
            //             continue
            //         # security check
            //         if ptav.attribute_id == copied_ptav.attribute_id and ptav.product_attribute_value_id == copied_ptav.product_attribute_value_id:
            //             copied_ptav.price_extra = ptav.price_extra
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def copy(self, default=None):
            // new_products = super().copy(default=default)
            // # Since we don't copy product variants directly, we need to match the newly
            // # created product variants with the old one, and copy the storage category
            // # capacity from them.
            // new_product_dict = {}
            // for product in new_products.product_variant_ids:
            //     product_attribute_value = product.product_template_attribute_value_ids.product_attribute_value_id
            //     new_product_dict[product_attribute_value] = product.id
            // storage_category_capacity_vals = []
            // for storage_category_capacity in self.product_variant_ids.storage_category_capacity_ids:
            //     product_attribute_value = storage_category_capacity.product_id.product_template_attribute_value_ids.product_attribute_value_id
            //     storage_category_capacity_vals.append(storage_category_capacity.copy_data({'product_id': new_product_dict[product_attribute_value]})[0])
            // self.env['stock.storage.category.capacity'].create(storage_category_capacity_vals)
            // return new_products
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if not default:
            //     return vals_list
            // for page, vals in zip(self, vals_list):
            //     if not default.get('view_id'):
            //         new_view = page.view_id.copy({'website_id': default.get('website_id')})
            //         vals['view_id'] = new_view.id
            //         vals['key'] = new_view.key
            //     vals['url'] = default.get('url', self.env['website'].get_unique_path(page.url))
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", blog.name)) for blog, vals in zip(self, vals_list)]
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def create(self, vals_list):
            // posts = super(BlogPost, self.with_context(mail_create_nolog=True)).create(vals_list)
            // for post, vals in zip(posts, vals_list):
            //     post._check_for_publication(vals)
            // return posts
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def create(self, vals_list):
            // events = super().create(vals_list)
            // events._update_website_menus()
            // return events
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
            // channels = super(Channel, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
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

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create_company(self):
            // self.ensure_one()
            // if self.company_name:
            //     # Create parent company
            //     values = dict(name=self.company_name, is_company=True, vat=self.vat)
            //     values.update(self._update_fields_values(self._address_fields()))
            //     new_company = self.create(values)
            //     # Set new company as my parent
            //     self.write({
            //         'parent_id': new_company.id,
            //         'child_ids': [Command.update(partner_id, dict(parent_id=new_company.id)) for partner_id in self.child_ids.ids]
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CreateMembershipInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object product, object amount) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def create_membership_invoice(self, product, amount):
            // """ Create Customer Invoice of Membership for partners.
            // """
            // invoice_vals_list = []
            // for partner in self:
            //     addr = partner.address_get(['invoice'])
            //     if partner.free_member:
            //         raise UserError(_("Partner is a free Member."))
            //     if not addr.get('invoice', False):
            //         raise UserError(_("Partner doesn't have an address to make the invoice."))
            // 
            //     invoice_vals_list.append({
            //         'move_type': 'out_invoice',
            //         'partner_id': partner.id,
            //         'invoice_line_ids': [
            //             (
            //                 0,
            //                 None,
            //                 {
            //                     'product_id': product.id,
            //                     'quantity': 1,
            //                     'price_unit': amount,
            //                     'tax_ids': [(6, 0, product.taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(self.env.company)).ids)]
            //                 }
            //              )
            //         ]
            //     })
            // 
            // return self.env['account.move'].create(invoice_vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _create_menu(self, sequence, name, url, xml_id, menu_type):
            // """ Create a new menu for the current event.
            // 
            // If url: create a website menu. Menu leads directly to the URL that
            // should be a valid route.
            // 
            // If xml_id: create a new page using the qweb template given by its
            // xml_id. Take its url back thanks to new_page of website, then link
            // it to a menu. Template is duplicated and linked to a new url, meaning
            // each menu will have its own copy of the template. This is currently
            // limited to two menus: introduction and location.
            // 
            // :param menu_type: type of menu. Mainly used for inheritance purpose
            //   allowing more fine-grain tuning of menus.
            // """
            // self.browse().check_access('write')
            // view_id = False
            // if not url:
            //     # add_menu=False, ispage=False -> simply create a new ir.ui.view with name
            //     # and template
            //     page_result = self.env['website'].sudo().new_page(
            //         name=f'{name} {self.name}', template=xml_id,
            //         add_menu=False, ispage=False)
            //     view_id = page_result['view_id']
            //     view = self.env["ir.ui.view"].browse(view_id)
            //     url = f"/event/{self.env['ir.http']._slug(self)}/page/{view.key.split('.')[-1]}"  # url contains starting "/"
            // 
            // website_menu = self.env['website.menu'].sudo().create({
            //     'name': name,
            //     'url': url,
            //     'parent_id': self.menu_id.id,
            //     'sequence': sequence,
            //     'website_id': self.website_id.id,
            // })
            // self.env['website.event.menu'].create({
            //     'menu_id': website_menu.id,
            //     'event_id': self.id,
            //     'menu_type': menu_type,
            //     'view_id': view_id,
            // })
            // return website_menu
            */
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _create_portal_users(self):
            // partners_without_user = self.filtered(lambda partner: not partner.user_ids)
            // if not partners_without_user:
            //     return self.env['res.users']
            // created_users = self.env['res.users']
            // for partner in partners_without_user:
            //     created_users += self.env['res.users'].with_context(no_reset_password=True).sudo()._create_user_from_template({
            //         'email': email_normalize(partner.email),
            //         'login': email_normalize(partner.email),
            //         'partner_id': partner.id,
            //         'company_id': self.env.company.id,
            //         'company_ids': [(6, 0, self.env.company.ids)],
            //         'active': True,
            //     })
            // return created_users
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //     lot of useless variants. Unfortunately, after discussing the
            //     matter with ODO, there's no easy and user-friendly way to block
            //     that behavior.
            // 
            //     We would have to use captcha/server actions to clean/... that
            //     are all not user-friendly/overkill mechanisms.
            // 
            // - This method could be used to try to guess what product variant ids
            //     are created in the system and what product template ids are
            //     configured as "dynamic", but that does not seem like a big deal.
            // 
            // The error messages are identical on purpose to avoid giving too much
            // information to a potential attacker:
            //     - returning 0 when failing
            //     - returning the variant id whether it already existed or not
            // 
            // :param product_template_attribute_value_ids: the combination for which
            //     to get or create variant
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

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //                 len(combination) == len(lines_without_no_variants) and
            //                 combination.attribute_line_id == lines_without_no_variants
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

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_job_new')
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _credit_debit_get(self):
            // if not self.ids:
            //     self.debit = False
            //     self.credit = False
            //     return
            // query = self.env['account.move.line']._where_calc([
            //     ('parent_state', '=', 'posted'),
            //     ('company_id', 'child_of', self.env.company.root_id.id)
            // ])
            // self.env['account.move.line'].flush_model(
            //     ['account_id', 'amount_residual', 'company_id', 'parent_state', 'partner_id', 'reconciled']
            // )
            // self.env['account.account'].flush_model(['account_type'])
            // sql = SQL("""
            //     SELECT account_move_line.partner_id, a.account_type, SUM(account_move_line.amount_residual)
            //     FROM %s
            //     LEFT JOIN account_account a ON (account_move_line.account_id=a.id)
            //     WHERE a.account_type IN ('asset_receivable','liability_payable')
            //     AND account_move_line.partner_id IN %s
            //     AND account_move_line.reconciled IS NOT TRUE
            //     AND %s
            //     GROUP BY account_move_line.partner_id, a.account_type
            //     """,
            //     query.from_clause,
            //     tuple(self.ids),
            //     query.where_clause or SQL("TRUE"),
            // )
            // treated = self.browse()
            // for pid, account_type, val in self.env.execute_query(sql):
            //     partner = self.browse(pid)
            //     if account_type == 'asset_receivable':
            //         partner.credit = val
            //         if partner not in treated:
            //             partner.debit = False
            //             treated |= partner
            //     elif account_type == 'liability_payable':
            //         partner.debit = -val
            //         if partner not in treated:
            //             partner.credit = False
            //             treated |= partner
            // remaining = (self - treated)
            // remaining.debit = False
            // remaining.credit = False
            */
            return default;
        }

        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _credit_search(self, operator, operand):
            // return self._asset_difference_search('asset_receivable', operator, operand)
            */
            return default;
        }

        public async Task<TEntity> CronUpdateMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _cron_update_membership(self):
            // partners = self.search([('membership_state', 'in', ['invoiced', 'paid'])])
            // # mark the field to be recomputed, and recompute it
            // self.env.add_to_compute(self._fields['membership_state'], partners)
            */
            return default;
        }

        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _debit_search(self, operator, operand):
            // return self._asset_difference_search('liability_payable', operator, operand)
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _deduce_country_code(self):
            // """ deduce the country code based on the information available.
            // we have three cases:
            // - country_code is BE but the VAT number starts with FR, the country code is FR, not BE
            // - if a country-specific field is set (e.g. the codice_fiscale), that country is used for the country code
            // - if the VAT number has no ISO country code, use the country_code in that case.
            // """
            // self.ensure_one()
            // 
            // country_code = self.country_code
            // if self.vat and self.vat[:2].isalpha():
            //     country_code = self.vat[:2].upper()
            // return country_code
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _default_address_id(self):
            // last_used_address = self.env['hr.job'].search([('company_id', 'in', self.env.companies.ids)], order='id desc', limit=1)
            // if last_used_address:
            //     return last_used_address.address_id
            // else:
            //     return self.env.company.partner_id
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self._context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_tag.py) ---
            // def _default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_content(self):
            // text = html_escape(_("Start writing here..."))
            // return """
            //     <p class="o_default_snippet_text">%(text)s</p>
            // """ % {"text": text}
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_cover_properties(self):
            // res = super()._default_cover_properties()
            // res.update({
            //     'background-image': "url('/website_event/static/src/img/event_cover_4.jpg')",
            //     'opacity': '0.4',
            //     'resize_class': 'cover_auto'
            // })
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_cover_properties(self):
            // """ Cover properties defaults are overridden to keep a consistent look for the slides
            // channels headers across Odoo versions (pre-customization, with purple gradient fitting the
            // homepage images, etc). Furthermore, as adding padding to the cover would not look great,
            // its height is set to fit to content (snippet option to change this also disabled on the view)."""
            // res = super()._default_cover_properties()
            // res.update({
            //     "background_color_class": "o_cc3",
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

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_description(self):
            // # avoid template branding with rendering_bundle=True
            // return self.env['ir.ui.view'].with_context(rendering_bundle=True) \
            //     ._render_template('event.event_default_descripton')
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _default_display_invoice_template_pdf_report_id(self):
            // available_templates_count = self.env['ir.actions.report'].search_count([('is_invoice_report', '=', True)], limit=2)
            // return available_templates_count > 1
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_event_mail_ids(self):
            // return self.env['event.type']._default_event_mail_type_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_tag.py) ---
            // def default_get(self, fields_list):
            // result = super().default_get(fields_list)
            // if self.env.context.get('default_website_id'):
            //     result['website_id'] = self.env.context.get('default_website_id')
            // return result
            */
            return default;
        }

        public async Task<TEntity> DefaultIsPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _default_is_published(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_tag_category.py) ---
            // def _default_is_published(self):
            // return True
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_question_ids(self):
            // return self.env['event.type']._default_question_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_tag.py) ---
            // def _default_sequence(self):
            // """
            // Here we use a _default method instead of ordering on 'sequence, id' to
            // prevent adding a new related stored field in the 'event.tag' model that
            // would hold the category id.
            // """
            // return (self.search([], order="sequence desc", limit=1).sequence or 0) + 1
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_website_meta(self):
            // res = super(BlogPost, self)._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_opengraph']['og:type'] = 'article'
            // res['default_opengraph']['article:published_time'] = self.post_date
            // res['default_opengraph']['article:modified_time'] = self.write_date
            // res['default_opengraph']['article:tag'] = self.tag_ids.mapped('name')
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = json_scriptsafe.loads(self.cover_properties).get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_meta_description'] = self.subtitle
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_website_meta(self):
            // res = super(Event, self)._default_website_meta()
            // event_cover_properties = json.loads(self.cover_properties)
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = event_cover_properties.get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_twitter']['twitter:card'] = 'summary'
            // res['default_meta_description'] = self.subtitle
            // return res
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

        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address_depends(self):
            // # field dependencies of method _display_address()
            // return self._formatting_address_fields() + [
            //     'country_id', 'company_name', 'state_id',
            // ]
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address(self, without_company=False):
            // '''
            // The purpose of this function is to build and return an address formatted accordingly to the
            // standards of the country where it belongs.
            // 
            // :param without_company: if address contains company
            // :returns: the address formatted in a display that fit its country habits (or the default ones
            //     if not country is specified)
            // :rtype: string
            // '''
            // address_format, args = self._prepare_display_address(without_company)
            // return address_format % args
            */
            return default;
        }

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_button_print(self):
            // self.ensure_one()
            // company_id = self.env.user.company_id.id
            // if not self.env['account.move.line'].search(
            //         [('partner_id', '=', self.id),
            //          ('account_id.account_type', '=', 'asset_receivable'),
            //          ('full_reconcile_id', '=', False),
            //          ('company_id', '=', company_id),
            //          '|', ('date_maturity', '=', False),
            //          ('date_maturity', '<=', fields.Date.today())]):
            //     raise ValidationError(
            //         _("The partner does not have any accounting entries to "
            //           "print in the overdue report for the current company."))
            // self.message_post(body=_('Printed overdue payments report'))
            // self.message_post(body=_('Printed overdue payments report'))
            // 
            // wizard_partner_ids = [self.id * 10000 + company_id]
            // followup_ids = self.env['followup.followup'].search(
            //     [('company_id', '=', company_id)])
            // if not followup_ids:
            //     raise ValidationError(_(
            //         "There is no followup plan defined for the current company."))
            // data = {
            //     'date': fields.date.today(),
            //     'followup_id': followup_ids[0].id,
            // }
            // return self.do_partner_print(wizard_partner_ids, data)
            */
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_mail(self):
            // ctx = self.env.context.copy()
            // ctx['followup'] = True
            // template = 'om_account_followup.email_template_om_account_followup_default'
            // unknown_mails = 0
            // for partner in self:
            //     partners_to_email = [child for child in partner.child_ids if
            //                          child.type == 'invoice' and child.email]
            //     if not partners_to_email and partner.email:
            //         partners_to_email = [partner]
            //     if partners_to_email:
            //         level = partner.latest_followup_level_id_without_lit
            //         for partner_to_email in partners_to_email:
            //             if level and level.send_email and \
            //                     level.email_template_id and \
            //                     level.email_template_id.id:
            //                 level.email_template_id.with_context(ctx).send_mail(
            //                     partner_to_email.id)
            //             else:
            //                 mail_template_id = self.env.ref(template)
            //                 mail_template_id.with_context(ctx).send_mail(
            //                     partner_to_email.id)
            //         if partner not in partners_to_email:
            //             partner.message_post(body=_(
            //                 'Overdue email sent to %s' % ', '.join(
            //                     ['%s <%s>' % (partner.name, partner.email) for
            //                      partner in partners_to_email])))
            //     else:
            //         unknown_mails = unknown_mails + 1
            //         action_text = _("Email not sent because of email address "
            //                         "of partner not filled in")
            //         if partner.payment_next_action_date:
            //             payment_action_date = min(
            //                 fields.Date.today(),
            //                 partner.payment_next_action_date)
            //         else:
            //             payment_action_date = fields.Date.today()
            //         if partner.payment_next_action:
            //             payment_next_action = \
            //                 partner.payment_next_action + " \n " + action_text
            //         else:
            //             payment_next_action = action_text
            //         partner.with_context(ctx).write(
            //             {'payment_next_action_date': payment_action_date,
            //              'payment_next_action': payment_next_action})
            // return unknown_mails
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_manual_action(self, partner_ids):
            // for partner in self.browse(partner_ids):
            //     followup_without_lit = partner.latest_followup_level_id_without_lit
            //     if partner.payment_next_action:
            //         action_text = \
            //             (partner.payment_next_action or '') + "\n" + \
            //             (followup_without_lit.manual_action_note or '')
            //     else:
            //         action_text = followup_without_lit.manual_action_note or ''
            // 
            //     action_date = partner.payment_next_action_date or \
            //         fields.Date.today()
            // 
            //     if partner.payment_responsible_id:
            //         responsible_id = partner.payment_responsible_id.id
            //     else:
            //         p = followup_without_lit.manual_action_responsible_id
            //         responsible_id = p and p.id or False
            //     partner.write({'payment_next_action_date': action_date,
            //                    'payment_next_action': action_text,
            //                    'payment_responsible_id': responsible_id})
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_manual_action_dermanord(self, followup_line):
            // action_text = followup_line.manual_action_note or ''
            // 
            // action_date = self.payment_next_action_date or \
            //     fields.Date.today()
            // if self.payment_responsible_id:
            //     responsible_id = self.payment_responsible_id.id
            // else:
            //     p = followup_line.manual_action_responsible_id
            //     responsible_id = p and p.id or False
            // self.write({'payment_next_action_date': action_date,
            //             'payment_next_action': action_text,
            //             'payment_responsible_id': responsible_id})
            */
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_print(self, wizard_partner_ids, data):
            // if not wizard_partner_ids:
            //     return {}
            // data['partner_ids'] = wizard_partner_ids
            // datas = {
            //     'ids': wizard_partner_ids,
            //     'model': 'followup.followup',
            //     'form': data
            // }
            // return self.env.ref(
            //     'om_account_followup.action_report_followup').report_action(
            //     self, data=datas)
            */
            return default;
        }

        public async Task<TEntity> EditDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def edit_dialog(self):
            // form_view = self.env.ref('hr.view_hr_job_form')
            // return {
            //     'name': _('Job'),
            //     'res_model': 'hr.job',
            //     'res_id': self.id,
            //     'views': [(form_view.id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'target': 'inline'
            // }
            */
            return default;
        }

        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_domain(self, domain, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_domain', {
            //     'domain': domain,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_duns(self, duns, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_duns', {
            //     'duns': duns,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_gst(self, gst, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_gst', {
            //     'gst': gst,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichCompanyAsync<TEntity>(IEnumerable<TEntity> entities, object company_domain, object partner_gid, object vat, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_company(self, company_domain, partner_gid, vat, timeout=15):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> EnsurePartnerAddressIsCompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def _ensure_partner_address_is_complete(self, partner):
            // """ Ensure that all partner address fields required by Gelato are set.
            // 
            // :param res.partner partner: The partner address to check.
            // :return: An error message if the address is incomplete, None otherwise.
            // :rtype: str | None
            // """
            // required_address_fields = ['city', 'country_id', 'street']
            // if partner.country_id.code not in const.COUNTRIES_WITHOUT_ZIPCODE:
            //     required_address_fields.append('zip')
            // missing_fields = [
            //     partner._fields[field_name]
            //     for field_name in required_address_fields if not partner[field_name]
            // ]
            // if missing_fields:
            //     translated_field_names = [f._description_string(self.env) for f in missing_fields]
            //     return _(
            //         "The following required address fields are missing: %s",
            //         ", ".join(translated_field_names),
            //     )
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _ensure_same_company_than_projects(self):
            // for partner in self:
            //     if partner.company_id and partner.project_ids.company_id and partner.project_ids.company_id != partner.company_id:
            //         raise UserError(_("Partner company cannot be different from its assigned projects' company"))
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _ensure_same_company_than_tasks(self):
            // for partner in self:
            //     if partner.company_id and partner.task_ids.company_id and partner.task_ids.company_id != partner.company_id:
            //         raise UserError(_("Partner company cannot be different from its assigned tasks' company"))
            */
            return default;
        }

        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _fetch_is_participating_events(self):
            // """Heuristic
            // 
            //   * public, no visitor: not participating as we have no information;
            //   * check only confirmed and attended registrations, a draft registration
            //     does not make the attendee participating;
            //   * public and visitor: check visitor is linked to a registration. As
            //     visitors are merged on the top parent, current visitor check is
            //     sufficient even for successive visits;
            //   * logged, no visitor: check partner is linked to a registration. Do
            //     not check the email as it is not really secure;
            //   * logged as visitor: check partner or visitor are linked to a
            //     registration;
            // """
            // current_visitor = self.env['website.visitor']._get_visitor_from_request()
            // if self.env.user._is_public() and not current_visitor:
            //     return self.env['event.event']
            // 
            // base_domain = [('state', 'in', ['open', 'done'])]
            // if self:
            //     base_domain = expression.AND([[('event_id', 'in', self.ids)], base_domain])
            // 
            // visitor_domain = []
            // partner_id = self.env.user.partner_id
            // if current_visitor:
            //     visitor_domain = [('visitor_id', '=', current_visitor.id)]
            //     partner_id = current_visitor.partner_id
            // if partner_id:
            //     visitor_domain = expression.OR([visitor_domain, [('partner_id', '=', partner_id.id)]])
            // 
            // registrations_events = self.env['event.registration'].sudo()._read_group(
            //     expression.AND([visitor_domain, base_domain]),
            //     ['event_id'], ['__count'])
            // return self.env['event.event'].browse([event.id for event, _reg_count in registrations_events])
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _fields_sync(self, values):
            // """ Sync commercial fields and address fields from company and to children after create/update,
            // just as if those were all modeled as fields.related to the parent """
            // # 1. From UPSTREAM: sync from parent
            // if values.get('parent_id') or values.get('type') == 'contact':
            //     # 1a. Commercial fields: sync if parent changed
            //     if values.get('parent_id'):
            //         self.sudo()._commercial_sync_from_company()
            //     # 1b. Address fields: sync if parent or use_parent changed *and* both are now set
            //     if self.parent_id and self.type == 'contact':
            //         onchange_vals = self.onchange_parent_id().get('value', {})
            //         self.update_address(onchange_vals)
            // 
            // # 2. To DOWNSTREAM: sync children
            // self._children_sync(values)
            */
            return default;
        }

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def fields_view_get(self, view_id=None, view_type='form', toolbar=False,
            //                 submenu=False):
            // res = super(ResPartner, self).fields_view_get(
            //     view_id=view_id, view_type=view_type, toolbar=toolbar,
            //     submenu=submenu)
            // if view_type == 'form' and self.env.context.get('Followupfirst'):
            //     doc = etree.XML(res['arch'], parser=None, base_url=None)
            //     first_node = doc.xpath("//page[@name='followup_tab']")
            //     root = first_node[0].getparent()
            //     root.insert(0, first_node[0])
            //     res['arch'] = etree.tostring(doc, encoding="utf-8")
            // return res
            */
            return default;
        }

        public async Task<TEntity> FillSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sample, object index) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _fill_sample(self, sample, index):
            // """
            // Fills the missing fields of a sample
            // 
            // @param sample: Data structure to fill with values for each name in field_names
            // @param index: Index of the sample within the dataset
            // """
            // meta_data = self._get_filter_meta_data()
            // model = self.env[self.model_name]
            // for field_name, field_widget in meta_data.items():
            //     if field_name not in sample and field_name in model:
            //         if field_widget in ('image', 'binary'):
            //             sample[field_name] = None
            //         elif field_widget == 'monetary':
            //             sample[field_name] = randint(100, 10000) / 10.0
            //         elif field_widget in ('integer', 'float'):
            //             sample[field_name] = index
            //         else:
            //             sample[field_name] = _('Sample %s', index + 1)
            // return sample
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object raise_on_access) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _filter_add_members(self, target_partners, raise_on_access=False):
            // allowed = self.filtered(lambda channel: channel.enroll == 'public')
            // on_invite = self.filtered(lambda channel: channel.enroll == 'invite')
            // if on_invite:
            //     if on_invite.has_access('write'):
            //         allowed |= on_invite
            //     elif raise_on_access:
            //         raise AccessError(_('You are not allowed to add members to this course. Please contact the course responsible or an administrator.'))
            // return allowed
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> FilterRecordsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object is_sample) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _filter_records_to_values(self, records, is_sample=False):
            // """
            // Extract the fields from the data source 'records' and put them into a dictionary of values
            // 
            // @param records: Model records returned by the filter
            // @param is_sample: True if conversion if for sample records
            // 
            // @return List of dict associating the field value to each field name
            // """
            // self.ensure_one()
            // meta_data = self._get_filter_meta_data()
            // 
            // values = []
            // model = self.env[self.model_name]
            // Website = self.env['website']
            // for record in records:
            //     data = {}
            //     for field_name, field_widget in meta_data.items():
            //         field = model._fields.get(field_name)
            //         if field and field.type in ('binary', 'image'):
            //             if is_sample:
            //                 data[field_name] = record[field_name].decode('utf8') if field_name in record else '/web/image'
            //             else:
            //                 data[field_name] = Website.image_url(record, field_name)
            //         elif field_widget == 'monetary':
            //             model_currency = None
            //             if field and field.type == 'monetary':
            //                 model_currency = record[field.get_currency_field(record)]
            //             elif 'currency_id' in model._fields:
            //                 model_currency = record['currency_id']
            //             if model_currency:
            //                 website_currency = self._get_website_currency()
            //                 data[field_name] = model_currency._convert(
            //                     record[field_name],
            //                     website_currency,
            //                     Website.get_current_website().company_id,
            //                     fields.Date.today()
            //                 )
            //             else:
            //                 data[field_name] = record[field_name]
            //         else:
            //             data[field_name] = record[field_name]
            // 
            //     data['call_to_action_url'] = 'website_url' in record and record['website_url']
            //     data['_record'] = record
            //     values.append(data)
            // return values
            */
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _find_accounting_partner(self, partner):
            // ''' Find the partner for which the accounting entries will be created '''
            // return partner.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Override to use the email_normalized field. """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('%(email)s is not recognized as a valid email. This is required to create a new customer.'))
            // if parsed_email_normalized:
            //     partners = self.search([('email_normalized', '=', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // # We don't want to call `super()` to avoid searching twice on the email
            // # Especially when the search `email =ilike` cannot be as efficient as
            // # a search on email_normalized with a btree index
            // # If you want to override `find_or_create()` your module should depend on `mail`
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # otherwise keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Find a partner with the given ``email`` or use :py:method:`~.name_create`
            // to create a new one.
            // 
            // :param str email: email-like string, which should contain at least one email,
            //     e.g. ``"Raoul Grosbedon <r.g@grosbedon.fr>"``
            // :param boolean assert_valid_email: raise if no valid email is found
            // :return: newly created record
            // """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('A valid email is required for find_or_create to work properly.'))
            // 
            // if parsed_email_normalized:
            //     partners = self.search([('email', '=ilike', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object additional_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _find_or_create_from_emails(self, emails, additional_values=None):
            // """ Based on a list of emails, find or create partners. Additional values
            // can be given to newly created partners. If an email is not unique (e.g.
            // multi-email input), only the first found email is considered.
            // 
            // Additional values allow to customize the created partner when context
            // allows to give more information. It data is based on email normalized
            // as it is the main information used in this method to distinguish or
            // find partners.
            // 
            // If no valid email is found for a given item, the given value is used to
            // find partners with same invalid email or create a new one with the wrong
            // value. It allows updating it afterwards. Notably with notifications
            // resend it is possible to update emails, if only a typo prevents from
            // having a real email for example.
            // 
            // :param list emails: list of emails that may be formatted (each input
            //   will be parsed and normalized);
            // :param dict additional_values: additional values per normalized email
            //   given to create if the partner is not found. Typically used to
            //   propagate a company_id and customer information from related record.
            //   Values for key 'False' are used when creating partner for invalid
            //   emails;
            // 
            // :return: res.partner records in a list, following order of emails. It
            //   is not a recordset, to keep Falsy values.
            // """
            // additional_values = additional_values if additional_values else {}
            // partners, tocreate_vals_list = self.env['res.partner'], []
            // name_emails = [tools.parse_contact_from_email(email) for email in emails]
            // 
            // # find valid emails_normalized, filtering out false / void values, and search
            // # for existing partners based on those emails
            // emails_normalized = {email_normalized
            //                      for _name, email_normalized in name_emails
            //                      if email_normalized}
            // # find partners for invalid (but not void) emails, aka either invalid email
            // # either no email and a name that will be used as email
            // names = {
            //     name.strip()
            //     for name, email_normalized in name_emails
            //     if not email_normalized and name.strip()
            // }
            // if emails_normalized or names:
            //     domains = []
            //     if emails_normalized:
            //         domains.append([('email_normalized', 'in', list(emails_normalized))])
            //     if names:
            //         domains.append([('email', 'in', list(names))])
            //     partners += self.search(expression.OR(domains))
            // 
            // # create partners for valid email without any existing partner. Keep
            // # only first found occurrence of each normalized email, aka: ('Norbert',
            // # 'norbert@gmail.com'), ('Norbert With Surname', 'norbert@gmail.com')'
            // # -> a single partner is created for email 'norbert@gmail.com'
            // seen = set()
            // notfound_emails = (emails_normalized - set(partners.mapped('email_normalized'))) if partners else emails_normalized
            // notfound_name_emails = [
            //     name_email
            //     for name_email in name_emails
            //     if name_email[1] in notfound_emails and name_email[1] not in seen
            //        and not seen.add(name_email[1])
            // ]
            // tocreate_vals_list += [
            //     {
            //         self._rec_name: name or email_normalized,
            //         'email': email_normalized,
            //         **additional_values.get(email_normalized, {}),
            //     }
            //     for name, email_normalized in notfound_name_emails
            // ]
            // 
            // # create partners for invalid emails (aka name and not email_normalized)
            // # without any existing partner
            // tocreate_vals_list += [
            //     {
            //         self._rec_name: name,
            //         'email': name,
            //         **additional_values.get(False, {}),
            //     }
            //     for name in names if name not in partners.mapped('email')
            // ]
            // 
            // # create partners once
            // if tocreate_vals_list:
            //     partners += self.create(tocreate_vals_list)
            // 
            // return [
            //     next(
            //         (partner for partner in partners
            //             if (email_normalized and partner.email_normalized == email_normalized)
            //             or (not email_normalized and email and partner.email == email)
            //             or (not email_normalized and name and partner.name == name)
            //         ),
            //         self.env['res.partner']
            //     )
            //     for (name, email_normalized), email in zip(name_emails, emails)
            // ]
            */
            return default;
        }

        public async Task<TEntity> FixEuVatNumberAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def fix_eu_vat_number(self, country_id, vat):
            // europe = self.env.ref('base.europe')
            // country = self.env["res.country"].browse(country_id)
            // # In Romania, the CUI can be used as tax identifier and it is not prefixed with the country code
            // country_codes_to_not_prepend = ['RO']
            // if not europe:
            //     europe = self.env["res.country.group"].search([('name', '=', 'Europe')], limit=1)
            // if europe and country and country.id in europe.country_ids.ids:
            //     vat = re.sub('[^A-Za-z0-9]', '', vat).upper()
            //     country_code = _eu_country_vat.get(country.code, country.code).upper()
            //     if vat[:2] != country_code and (
            //         country_code not in country_codes_to_not_prepend or
            //         country_code != self.env.company.country_code
            //     ):
            //         vat = country_code + vat
            // return vat
            */
            return default;
        }

        public async Task<TEntity> FixVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid country_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _fix_vat_number(self, vat, country_id):
            // code = self.env['res.country'].browse(country_id).code if country_id else False
            // vat_country, vat_number = self._split_vat(vat)
            // if code and code.lower() != vat_country:
            //     return vat
            // stdnum_vat_fix_func = getattr(stdnum.util.get_cc_module(vat_country, 'vat'), 'compact', None)
            // #If any localization module need to define vat fix method for it's country then we give first priority to it.
            // format_func_name = 'format_vat_' + vat_country
            // format_func = getattr(self, format_func_name, None) or stdnum_vat_fix_func
            // if format_func:
            //     vat_number = format_func(vat_number)
            // return vat_country.upper() + vat_number
            */
            return default;
        }

        public async Task<TEntity> FixedCancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_cancel_shipment(self, pickings):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> FixedGetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def fixed_get_tracking_link(self, picking):
            // if self.is_mondialrelay:
            //     return self.base_on_rule_get_tracking_link(picking)
            // return super().fixed_get_tracking_link(picking)
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_get_tracking_link(self, picking):
            // if self.tracking_url and picking.carrier_tracking_ref:
            //     return self.tracking_url.replace("<shipmenttrackingnumber>", picking.carrier_tracking_ref)
            // return False
            */
            return default;
        }

        public async Task<TEntity> FixedRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def fixed_rate_shipment(self, order):
            // carrier = self._match_address(order.partner_shipping_id)
            // if not carrier:
            //     return {'success': False,
            //             'price': 0.0,
            //             'error_message': _('Error: this delivery method is not available for this address.'),
            //             'warning_message': False}
            // price = order.pricelist_id._get_product_price(self.product_id, 1.0)
            // return {'success': True,
            //         'price': price,
            //         'error_message': False,
            //         'warning_message': False}
            */
            return default;
        }

        public async Task<TEntity> FixedSendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def fixed_send_shipping(self, pickings):
            // res = []
            // for p in pickings:
            //     res = res + [{'exact_price': p.carrier_id.fixed_price,
            //                   'tracking_number': False}]
            // return res
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_purchase_tax(self, companies):
            // default_supplier_taxes = companies.filtered('account_purchase_tax_id').account_purchase_tax_id
            // for product_grouped_by_tax in self.grouped('supplier_taxes_id').values():
            //     product_grouped_by_tax.supplier_taxes_id += default_supplier_taxes
            // self.invalidate_recordset(['supplier_taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_sale_tax(self, companies):
            // default_customer_taxes = companies.filtered('account_sale_tax_id').account_sale_tax_id
            // for product_grouped_by_tax in self.grouped('taxes_id').values():
            //     product_grouped_by_tax.taxes_id += default_customer_taxes
            // self.invalidate_recordset(['taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_tax(self, companies):
            // self._force_default_sale_tax(companies)
            // self._force_default_purchase_tax(companies)
            */
            return default;
        }

        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _format_data_company(self, iap_data):
            // self._iap_replace_location_codes(iap_data)
            // self._iap_replace_language_codes(iap_data)
            // return iap_data
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_ch(self, vat):
            // stdnum_vat_format = getattr(stdnum.util.get_cc_module('ch', 'vat'), 'format', None)
            // return stdnum_vat_format('CH' + vat)[2:] if stdnum_vat_format else vat
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_eu(self, vat):
            // # Foreign companies that trade with non-enterprises in the EU
            // # may have a VATIN starting with "EU" instead of a country code.
            // return vat
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_sm(self, vat):
            // stdnum_vat_format = stdnum.util.get_cc_module('sm', 'vat').compact
            // return stdnum_vat_format('SM' + vat)[2:]
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _gc_mark_events_done(self):
            // """ move every ended events in the next 'ended stage' """
            // ended_events = self.env['event.event'].search([
            //     ('date_end', '<', fields.Datetime.now()),
            //     ('stage_id.pipe_end', '=', False),
            // ])
            // if ended_events:
            //     ended_events.action_set_done()
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py) ---
            // def _gelato_prepare_address_payload(self):
            // first_name, last_name = payment_utils.split_partner_name(self.name)
            // return {
            //     'companyName': self.commercial_company_name or '',
            //     'firstName': first_name or last_name,  # Gelato require a first name.
            //     'lastName': last_name,
            //     'addressLine1': self.street,
            //     'addressLine2': self.street2 or '',
            //     'state': self.state_id.code,
            //     'city': self.city,
            //     'postCode': self.zip,
            //     'country': self.country_id.code,
            //     'email': self.email,
            //     'phone': self.phone or ''
            // }
            */
            return default;
        }

        public async Task<TEntity> GelatoRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def gelato_rate_shipment(self, order):
            // """ Fetch the Gelato delivery price based on products, quantity and address.
            // 
            // This method is called by `delivery`'s `rate_shipment` method.
            // 
            // Note: `self._ensure_one()` from `rate_shipment`
            // 
            // :param sale.order order: The order for which to fetch the delivery price.
            // :return: The shipment rate request results.
            // :rtype: dict
            // """
            // if error_message := self._ensure_partner_address_is_complete(order.partner_id):
            //     return {
            //         'success': False,
            //         'price': 0,
            //         'error_message': error_message,
            //     }
            // 
            // # Fetch the delivery price from Gelato.
            // payload = {
            //     'orderReferenceId': order.id,
            //     'customerReferenceId': f'Odoo Partner #{order.partner_id.id}',
            //     'currency': order.currency_id.name,
            //     'allowMultipleQuotes': 'true',
            //     'products': order._gelato_prepare_items_payload(),
            //     'recipient': order.partner_shipping_id._gelato_prepare_address_payload(),
            // }
            // try:
            //     api_key = order.company_id.sudo().gelato_api_key  # In sudo mode to read on the company.
            //     order_data = utils.make_request(api_key, 'order', 'v4', 'orders:quote', payload=payload)
            // except UserError as e:
            //     return {
            //         'success': False,
            //         'price': 0,
            //         'error_message': str(e),
            //     }
            // 
            // # Find the total delivery price by summing all products' matching methods' minimum price.
            // total_delivery_price = 0
            // for quote_data in order_data['quotes']:
            //     matching_shipment_method_prices = [
            //         shipment_method_data['price']
            //         for shipment_method_data in quote_data['shipmentMethods']
            //         if shipment_method_data['type'] == self.gelato_shipping_service_type
            //     ]
            //     if not matching_shipment_method_prices:
            //         return {
            //             'success': False,
            //             'price': 0,
            //             'error_message': _("The delivery method is not available for this order."),
            //         }
            //     else:
            //         total_delivery_price += min(matching_shipment_method_prices)
            // 
            // return {
            //     'success': True,
            //     'price': total_delivery_price,
            // }
            */
            return default;
        }

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _generate_signup_token(self, expiration=None):
            // """ This function generate the signup token for the partner in self.
            //     pre-condition: self.signup_type must be either 'signup' or 'reset'
            //     :return: the signed payload/token that can be used to reset the password/signup.
            //         - 'expiration': the time in hours before the expiration of the token
            // Since the last_login_date is part of the payload, this token is invalidated as soon as the user logs in
            // """
            // self.ensure_one()
            // if not expiration:
            //     if self.signup_type == 'reset':
            //         expiration = int(self.env['ir.config_parameter'].get_param("auth_signup.reset_password.validity.hours", 4))
            //     else:
            //         expiration = int(self.env['ir.config_parameter'].get_param("auth_signup.signup.validity.hours", 144))
            // plist = [self.id, self.user_ids.ids, self._get_login_date(), self.signup_type]
            // payload = tools.hash_sign(self.sudo().env, 'signup', plist, expiration_hours=expiration)
            // return payload
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py) ---
            // def geo_localize(self):
            // # We need country names in English below
            // if not self._context.get('force_geo_localize') \
            //         and (self._context.get('import_file') \
            //              or any(config[key] for key in ['test_enable', 'test_file', 'init', 'update'])):
            //     return False
            // partners_not_geo_localized = self.env['res.partner']
            // for partner in self.with_context(lang='en_US'):
            //     result = self._geo_localize(partner.street,
            //                                 partner.zip,
            //                                 partner.city,
            //                                 partner.state_id.name,
            //                                 partner.country_id.name)
            // 
            //     if result:
            //         partner.write({
            //             'partner_latitude': result[0],
            //             'partner_longitude': result[1],
            //             'date_localization': fields.Date.context_today(partner)
            //         })
            //     else:
            //         partners_not_geo_localized |= partner
            // if partners_not_geo_localized:
            //     self.env.user._bus_send("simple_notification", {
            //         'type': 'danger',
            //         'title': _("Warning"),
            //         'message': _('No match found for %(partner_names)s address(es).', partner_names=', '.join(partners_not_geo_localized.mapped('name')))
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py) ---
            // def _geo_localize(self, street='', zip='', city='', state='', country=''):
            // geo_obj = self.env['base.geocoder']
            // search = geo_obj.geo_query_address(street=street, zip=zip, city=city, state=state, country=country)
            // result = geo_obj.geo_find(search, force_country=country)
            // if result is None:
            //     search = geo_obj.geo_query_address(city=city, state=state, country=country)
            //     result = geo_obj.geo_find(search, force_country=country)
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the post on website
            // directly if user is an employee or if the post is published. """
            // self.ensure_one()
            // user = self.env['res.users'].sudo().browse(access_uid) if access_uid else self.env.user
            // if not force_website and user.share and not self.sudo().website_published:
            //     return super(BlogPost, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.website_url,
            //     'target': 'self',
            //     'target_type': 'public',
            //     'res_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to append tracking data.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     data = super()._get_additional_configurator_data(
            //         product_or_template, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if ir_http.get_request_website():
            //         data.update({
            //             # The following fields are needed for tracking.
            //             'category_name': product_or_template.categ_id.name,
            //             'currency_name': currency.name,
            //         })
            //     return data
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // """Computes additional combination info, based on given parameters
            // 
            // :param product_or_template: `product.product` or `product.template` record
            //     as variant values must take precedence over template values (when we have a variant)
            // :param float quantity:
            // :param date date: today's date, avoids useless calls to today/context_today and harmonize
            //     behavior
            // :param website: `website` record holding the current website of the request (if any),
            //     or the contextual website (tests, ...)
            // :returns: additional product/template information
            // :rtype: dict
            // """
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // 
            // # Pricelist price doesn't have to be converted
            // pricelist_price, pricelist_rule_id = pricelist._get_product_price_rule(
            //     product=product_or_template,
            //     quantity=quantity,
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
            //         uom=product_or_template.uom_id,
            //         currency=currency,
            //     )
            // 
            // has_discounted_price = price_before_discount > pricelist_price
            // combination_info = {
            //     'list_price': max(pricelist_price, price_before_discount),
            //     'price': pricelist_price,
            //     'has_discounted_price': has_discounted_price,
            // }
            // 
            // comparison_price = None
            // if (
            //     not has_discounted_price
            //     and product_or_template.compare_list_price
            //     and self.env.user.has_group('website_sale.group_product_price_comparison')
            // ):
            //     comparison_price = product_or_template.currency_id._convert(
            //         from_amount=product_or_template.compare_list_price,
            //         to_currency=currency,
            //         company=self.env.company,
            //         date=date,
            //         round=False)
            // combination_info['compare_list_price'] = comparison_price
            // 
            // combination_info['price_extra'] = product_or_template.currency_id._convert(
            //     from_amount=product_or_template._get_attributes_extra_price(),
            //     to_currency=currency,
            //     company=self.env.company,
            //     date=date,
            //     round=False,
            // )
            // 
            // # Apply taxes
            // fiscal_position = website.fiscal_position_id.sudo()
            // 
            // product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            // taxes = self.env['account.tax']
            // if product_taxes:
            //     taxes = fiscal_position.map_tax(product_taxes)
            //     # We do not apply taxes on the compare_list_price value because it's meant to be
            //     # a strict value displayed as is.
            //     for price_key in ('price', 'list_price', 'price_extra'):
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
            //     'base_unit_name': product_or_template.base_unit_name,
            //     'base_unit_price': product_or_template._get_base_unit_price(combination_info['price']),
            // 
            //     # additional info to simplify overrides
            //     'currency': currency,  # displayed currency
            //     'date': date,
            //     'product_taxes': product_taxes,  # taxes before fpos mapping
            //     'taxes': taxes,  # taxes after fpos mapping
            // })
            // 
            // if combination_info['prevent_zero_price_sale']:
            //     combination_info['compare_list_price'] = 0
            // 
            // return combination_info
            */
            return default;
        }

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // # When sending a letter, the fields 'street' and 'street2' should be on a single line to fit in the address area
            // if self.env.context.get('snailmail_layout') and self.country_id.code == 'DE':
            //     # Germany requires specific address formatting for Pingen
            //     result = "%(street)s"
            //     if self.street2:
            //         result += " // %(street2)s"
            //     return result + "\n%(zip)s %(city)s\n%(country_name)s"
            // if self.env.context.get('snailmail_layout') and self.street2:
            //     return "%(street)s, %(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            // 
            // return super(ResPartner, self)._get_address_format()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // employee_id = self.env['hr.employee'].search(
            //     [('id', 'in', self.employee_ids.ids)],
            //     limit=1,
            // )
            // if not employee_id:
            //     return super()._get_all_addr()
            // 
            // pstl_addr = {
            //     'contact_type': 'employee',
            //     'street': employee_id.private_street,
            //     'zip': employee_id.private_zip,
            //     'city': employee_id.private_city,
            //     'country': employee_id.private_country_id.code,
            // }
            // return [pstl_addr] + super()._get_all_addr()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // return [{
            //     'contact_type': self.street,
            //     'street': self.street,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country': self.country_id.code,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_alternative_product_filter(self):
            // return self.env.ref('website_sale.dynamic_filter_cross_selling_alternative_products').id
            */
            return default;
        }

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_amounts_and_date(self):
            // company = self.env.user.company_id
            // current_date = fields.Date.today()
            // for partner in self:
            //     worst_due_date = False
            //     amount_due = amount_overdue = 0.0
            //     for aml in partner.unreconciled_aml_ids:
            //         if (aml.company_id == company):
            //             date_maturity = aml.date_maturity or aml.date
            //             if not worst_due_date or date_maturity < worst_due_date:
            //                 worst_due_date = date_maturity
            //             amount_due += aml.result
            //             if (date_maturity <= current_date):
            //                 amount_overdue += aml.result
            //     partner.payment_amount_due = amount_due
            //     partner.payment_amount_overdue = amount_overdue
            //     partner.payment_earliest_due_date = worst_due_date
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = {}
            // res['stock_input'] = False
            // res['stock_output'] = False
            // return res
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

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def get_attendee_detail(self, meeting_ids):
            // """ Return a list of dict of the given meetings with the attendees details
            //     Used by:
            //         - many2many_attendee.js: Many2ManyAttendee
            //         - calendar_model.js (calendar.CalendarModel)
            // """
            // attendees_details = []
            // meetings = self.env['calendar.event'].browse(meeting_ids)
            // for attendee in meetings.attendee_ids:
            //     if attendee.partner_id not in self:
            //         continue
            //     attendee_is_organizer = self.env.user == attendee.event_id.user_id and attendee.partner_id == self.env.user.partner_id
            //     attendees_details.append({
            //         'id': attendee.partner_id.id,
            //         'name': attendee.partner_id.display_name,
            //         'status': attendee.state,
            //         'event_id': attendee.event_id.id,
            //         'attendee_id': attendee.id,
            //         'is_alone': attendee.event_id.is_organizer_alone and attendee_is_organizer,
            //         # attendees data is sorted according to this key in JS.
            //         'is_organizer': 1 if attendee.partner_id == attendee.event_id.user_id.partner_id else 0,
            //     })
            // return attendees_details
            */
            return default;
        }

        public async Task<TEntity> GetAttribValuesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_attrib_values_domain(self, attribute_values):
            // attribute_id = None
            // attribute_value_ids = []
            // domains = []
            // for value in attribute_values:
            //     if not attribute_id:
            //         attribute_id = value[0]
            //         attribute_value_ids.append(value[1])
            //     elif value[0] == attribute_id:
            //         attribute_value_ids.append(value[1])
            //     else:
            //         domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            //         attribute_id = value[0]
            //         attribute_value_ids = [value[1]]
            // if attribute_id:
            //     domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            // return domains
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //     :param list combination: The combination of the product, as a
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

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('hr_recruitment.menu_hr_recruitment_root').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_base_unit_price(self, price):
            // self.ensure_one()
            // return self.base_unit_count and price / self.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _get_booth_stat_count(self):
            // elements = self.env['event.booth'].sudo()._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id', 'state'], ['__count']
            // )
            // elements_total_count = defaultdict(int)
            // elements_available_count = dict()
            // for event, state, count in elements:
            //     if state == 'available':
            //         elements_available_count[event.id] = count
            //     elements_total_count[event.id] += count
            // return elements_available_count, elements_total_count
            */
            return default;
        }

        public async Task<TEntity> GetBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_buy_route(self):
            // buy_route = self.env.ref('purchase_stock.route_warehouse0_buy', raise_if_not_found=False)
            // if buy_route:
            //     return self.env['stock.route'].search([('id', '=', buy_route.id)]).ids
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, object parent_combination, object only_template) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_combination_info(
            //     self, combination=False, product_id=False, add_qty=1.0,
            //     parent_combination=False, only_template=False,
            // ):
            //     """ Return info about a given combination.
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
            // 
            //     :param parent_combination: if no combination and no product_id are
            //         given, it will try to find the first possible combination, taking
            //         into account parent_combination (if set) for the exclusion rules.
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
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     website = self.env['website'].get_current_website().with_context(self.env.context)
            // 
            //     if not product_id and not combination and not only_template:
            //         combination = self._get_first_possible_combination(parent_combination)
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
            //         'display_image': bool(product_or_template.image_128),
            //         'is_combination_possible': self._is_combination_possible(combination=combination, parent_combination=parent_combination),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination=parent_combination),
            // 
            //         **self._get_additionnal_combination_info(
            //             product_or_template=product_or_template,
            //             quantity=add_qty or 1.0,
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
            //             in product_or_template.combo_ids.sudo().combo_item_ids.product_id.taxes_id
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

        public async Task<TEntity> GetCommoditiesFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_commodities_from_order(self, order):
            // commodities = []
            // 
            // for line in order.order_line.filtered(lambda line: not line.is_delivery and not line.display_type and line.product_id.type == 'consu'):
            //     unit_quantity = line.product_uom._compute_quantity(line.product_uom_qty, line.product_id.uom_id)
            //     rounded_qty = max(1, float_round(unit_quantity, precision_digits=0))
            //     country_of_origin = line.product_id.country_of_origin.code or order.warehouse_id.partner_id.country_id.code
            //     commodities.append(DeliveryCommodity(
            //         line.product_id,
            //         amount=rounded_qty,
            //         monetary_value=line.price_reduce_taxinc,
            //         country_of_origin=country_of_origin,
            //     ))
            // 
            // return commodities
            */
            return default;
        }

        public async Task<TEntity> GetCommoditiesFromStockMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_lines) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_commodities_from_stock_move_lines(self, move_lines):
            // commodities = []
            // 
            // product_lines = move_lines.filtered(lambda line: line.product_id.type == 'consu')
            // for product, lines in groupby(product_lines, lambda x: x.product_id):
            //     unit_quantity = sum(
            //         line.product_uom_id._compute_quantity(
            //             line.quantity,
            //             product.uom_id)
            //         for line in lines)
            //     rounded_qty = max(1, float_round(unit_quantity, precision_digits=0))
            //     country_of_origin = product.country_of_origin.code or lines[0].picking_id.picking_type_id.warehouse_id.partner_id.country_id.code
            //     unit_price = sum(line.sale_price for line in lines) / rounded_qty
            //     commodities.append(DeliveryCommodity(product, amount=rounded_qty, monetary_value=unit_price, country_of_origin=country_of_origin))
            // 
            // return commodities
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_company_currency(self):
            // for partner in self:
            //     if partner.company_id:
            //         partner.currency_id = partner.sudo().company_id.currency_id
            //     else:
            //         partner.currency_id = self.env.company.currency_id
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_complete_name(self):
            // self.ensure_one()
            // 
            // displayed_types = self._complete_name_displayed_types
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // 
            // name = self.name or ''
            // if self.company_name or self.parent_id:
            //     if not name and self.type in displayed_types:
            //         name = type_description[self.type]
            //     if not self.is_company:
            //         name = f"{self.commercial_company_name or self.sudo().parent_id.name}, {name}"
            // return name.strip()
            */
            return default;
        }

        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //             fiscal_position = website.fiscal_position_id.sudo()
            //             taxes = fiscal_position.map_tax(product_taxes)
            //             return self._apply_taxes_to_price(
            //                 price, currency, product_taxes, taxes, product_or_template, website=website
            //             ), pricelist_rule_id
            //     return price, pricelist_rule_id
            */
            return default;
        }

        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_contextual_price(self, product=None):
            // return self._get_contextual_price(product=product)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Override to fallback on website current pricelist """
            // pricelist = super()._get_contextual_pricelist()
            // if not pricelist:
            //     website = ir_http.get_request_website()
            //     if website:
            //         return website.pricelist_id
            // return pricelist
            */
            return default;
        }

        public async Task<TEntity> GetConversionCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object conversion) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_conversion_currencies(self, order, conversion):
            // company_currency = (self.company_id or self.env['res.company']._get_main_company()).currency_id
            // pricelist_currency = order.currency_id
            // 
            // if conversion == 'company_to_pricelist':
            //     return company_currency, pricelist_currency
            // elif conversion == 'pricelist_to_company':
            //     return pricelist_currency, company_currency
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // # when sending a letter, thus rendering the report with the snailmail_layout,
            // # we need to override the country name to its english version following the
            // # dictionary imported in country_utils.py
            // country_code = self.country_id.code
            // if self.env.context.get('snailmail_layout') and country_code in SNAILMAIL_COUNTRIES:
            //     return SNAILMAIL_COUNTRIES.get(country_code)
            // 
            // return super(ResPartner, self)._get_country_name()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_current_persona(self):
            // if not self.env.user or self.env.user._is_public():
            //     return (self.env["res.partner"], self.env["mail.guest"]._get_guest_from_context())
            // return (self.env.user.partner_id, self.env["mail.guest"])
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_date_range_str(self, lang_code=False):
            // self.ensure_one()
            // today_tz = pytz.utc.localize(fields.Datetime.now()).astimezone(pytz.timezone(self.date_tz))
            // event_date_tz = pytz.utc.localize(self.date_begin).astimezone(pytz.timezone(self.date_tz))
            // diff = (event_date_tz.date() - today_tz.date())
            // if diff.days <= 0:
            //     return _('today')
            // if diff.days == 1:
            //     return _('tomorrow')
            // if (diff.days < 7):
            //     return _('in %d days', diff.days)
            // if (diff.days < 14):
            //     return _('next week')
            // if event_date_tz.month == (today_tz + relativedelta(months=+1)).month:
            //     return _('next month')
            // return _('on %(date)s', date=format_date(self.env, self.date_begin, lang_code=lang_code, date_format='medium'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_category_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('product.product_category_all')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCustomPackageCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_default_custom_package_code(self):
            // """ Some delivery carriers require a prefix to be sent in order to use custom
            // packages (ie not official ones). This optional method will return it as a string.
            // """
            // self.ensure_one()
            // if hasattr(self, '_%s_get_default_custom_package_code' % self.delivery_type):
            //     return getattr(self, '_%s_get_default_custom_package_code' % self.delivery_type)()
            // else:
            //     return False
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_default_enroll_msg(self):
            // return _('Contact Responsible')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_favorite_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_job_details(self):
            // return _("""
            //     <span class="text-muted small">Time to Answer</span>
            //     <h6>2 open days</h6>
            //     <span class="text-muted small">Process</span>
            //     <h6>1 Phone Call</h6>
            //     <h6>1 Onsite Interview</h6>
            //     <span class="text-muted small">Days to get an Offer</span>
            //     <h6>4 Days after Interview</h6>
            // """)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_uom_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_website_description(self):
            // return self.env['ir.qweb']._render("website_hr_recruitment.default_website_description", raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryDocPrefixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_doc_prefix(self):
            // return 'ShippingDoc-%s' % self.delivery_type
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryLabelPrefixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_label_prefix(self):
            // return 'LabelShipping-%s' % self.delivery_type
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_delivery_type(self):
            // """Return the delivery type.
            // 
            // This method needs to be overridden by a delivery carrier module if the delivery type is not
            // stored on the field `delivery_type`.
            // """
            // self.ensure_one()
            // return self.delivery_type
            */
            return default;
        }

        public async Task<TEntity> GetDuplicatedBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_duplicated_bank_accounts(self):
            // self.ensure_one()
            // if not self.bank_ids:
            //     return self.env['res.partner.bank']
            // domains = []
            // for bank in self.bank_ids:
            //     domains.append([('acc_number', '=', bank.acc_number), ('bank_id', '=', bank.bank_id.id)])
            // domain = expression.OR(domains)
            // if self.company_id:
            //     domain = expression.AND([domain, [('company_id', 'in', (False, self.company_id.id))]])
            // domain = expression.AND([domain, [('partner_id', '!=', self._origin.id)]])
            // return self.env['res.partner.bank'].search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // if invoice_edi_format == 'xrechnung':
            //     return self.env['account.edi.xml.ubl_de']
            // if invoice_edi_format == 'facturx':
            //     return self.env['account.edi.xml.cii']
            // if invoice_edi_format == 'ubl_a_nz':
            //     return self.env['account.edi.xml.ubl_a_nz']
            // if invoice_edi_format == 'nlcius':
            //     return self.env['account.edi.xml.ubl_nl']
            // if invoice_edi_format == 'ubl_bis3':
            //     return self.env['account.edi.xml.ubl_bis3']
            // if invoice_edi_format == 'ubl_sg':
            //     return self.env['account.edi.xml.ubl_sg']
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _get_employees_from_attendees(self, everybody=False):
            // domain = [
            //     ('company_id', 'in', self.env.companies.ids),
            //     ('work_contact_id', '!=', False),
            // ]
            // if not everybody:
            //     domain = expression.AND([
            //         domain,
            //         [('work_contact_id', 'in', self.ids)]
            //     ])
            // return dict(self.env['hr.employee'].sudo()._read_group(domain, groupby=['work_contact_id'], aggregates=['id:recordset']))
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("product"),
            // )
            // return super(ProductTemplate, self).get_empty_list_help(help_message)
            */
            return default;
        }

        public async Task<TEntity> GetEventPrintDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_print_details(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'badge_image': self.badge_image,
            //     'timeframe': self._get_event_timeframe_string(),
            //     'address': self.address_id.name if self.address_id else None,
            //     'logo': self.company_id.logo,
            //     'sponsor_text': self._get_printing_sponsor_text()
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_event_resource_urls(self):
            // url_date_start = self.date_begin.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // url_date_stop = self.date_end.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // params = {
            //     'action': 'TEMPLATE',
            //     'text': self.name,
            //     'dates': f'{url_date_start}/{url_date_stop}',
            //     'ctz': self.date_tz,
            //     'details': self._get_external_description(),
            // }
            // if self.address_id:
            //     params.update(location=self.address_inline)
            // encoded_params = werkzeug.urls.url_encode(params)
            // google_url = GOOGLE_CALENDAR_URL + encoded_params
            // iCal_url = f'/event/{self.id:d}/ics?{encoded_params}'
            // return {'google_url': google_url, 'iCal_url': iCal_url}
            */
            return default;
        }

        public async Task<TEntity> GetEventTimeframeStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_timeframe_string(self):
            // self.ensure_one()
            // start_datetime = format_datetime(self.env, self.date_begin, self.date_tz, "short")
            // if self.is_one_day:
            //     end_datetime = format_time(self.env, self.date_end, self.date_tz, "short")
            // else:
            //     end_datetime = format_datetime(self.env, self.date_end, self.date_tz, "short")
            // return _("%(start_date)s to %(end_date)s", start_date=start_datetime, end_date=end_datetime)
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_external_description(self):
            // """ Adding the URL of the event into the description """
            // self.ensure_one()
            // event_url = f'<a href="{self.event_register_url}">{self.name}</a>'
            // description = event_url + '\n' + super()._get_external_description()
            // return description
            */
            return default;
        }

        public async Task<TEntity> GetFieldNameAndTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _get_field_name_and_type(self, model, field_name):
            // """
            // Separates the name and the widget type
            // 
            // @param model: Model to which the field belongs, without it type is deduced from field_name
            // @param field_name: Name of the field possibly followed by a colon and a forced field type
            // 
            // @return Tuple containing the field name and the field type
            // """
            // field_name, _, field_widget = field_name.partition(":")
            // if not field_widget:
            //     field = model._fields.get(field_name)
            //     if field:
            //         field_type = field.type
            //     elif 'image' in field_name:
            //         field_type = 'image'
            //     elif 'price' in field_name:
            //         field_type = 'monetary'
            //     else:
            //         field_type = 'text'
            // return field_name, field_widget or field_type
            */
            return default;
        }

        public async Task<TEntity> GetFilterMetaDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _get_filter_meta_data(self):
            // """
            // Extracts the meta data of each field
            // 
            // @return OrderedDict containing the widget type for each field name
            // """
            // model = self.env[self.model_name]
            // meta_data = OrderedDict({})
            // for field_name in self.field_names.split(","):
            //     field_name, field_widget = self._get_field_name_and_type(model, field_name)
            //     meta_data[field_name] = field_widget
            // return meta_data
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_first_stage(self):
            // self.ensure_one()
            // return self.env['hr.recruitment.stage'].search([
            //     '|',
            //     ('job_ids', '=', False),
            //     ('job_ids', '=', self.id)], order='sequence asc', limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_followup_overdue_query(self, args, overdue_only=False):
            // company_id = self.env.user.company_id.id
            // having_clauses = []
            // having_values = []
            // 
            // for field, operator, value in args:
            //     if operator in ['=', '!=', '>', '>=', '<', '<=']:
            //         having_clauses.append(f'SUM(bal2) {operator} %s')
            //         having_values.append(value)
            //     else:
            //         raise ValueError(f"Unsupported operator: {operator}")
            // 
            // having_where_clause = ' AND '.join(having_clauses)
            // overdue_only_str = 'AND date_maturity <= NOW()' if overdue_only else ''
            // 
            // query = ('''
            //     SELECT pid AS partner_id, SUM(bal2) FROM (
            //         SELECT 
            //             CASE WHEN bal IS NOT NULL THEN bal ELSE 0.0 END AS bal2, 
            //             p.id as pid 
            //         FROM (
            //             SELECT 
            //                 (debit - credit) AS bal, 
            //                 partner_id 
            //             FROM account_move_line l
            //             LEFT JOIN account_account a ON a.id = l.account_id
            //             WHERE a.account_type = 'asset_receivable'
            //             %s AND full_reconcile_id IS NULL
            //             AND l.company_id = %%s
            //         ) AS l
            //         RIGHT JOIN res_partner p ON p.id = partner_id 
            //     ) AS pl
            //     GROUP BY pid HAVING %s
            // ''') % (overdue_only_str, having_where_clause)
            // 
            // params = [company_id] + having_values
            // return query, params
            */
            return default;
        }

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def get_followup_table_html(self):
            // self.ensure_one()
            // partner = self.commercial_partner_id
            // followup_table = ''
            // if partner.unreconciled_aml_ids:
            //     company = self.env.user.company_id
            //     current_date = fields.Date.today()
            //     report = self.env['report.om_account_followup.report_followup']
            //     final_res = report._lines_get_with_partner(partner, company.id)
            // 
            //     for currency_dict in final_res:
            //         currency = currency_dict.get('line', [
            //             {'currency_id': company.currency_id}])[0]['currency_id']
            //         followup_table += '''
            //         <table border="2" width=100%%>
            //         <tr>
            //             <td>''' + _("Invoice Date") + '''</td>
            //             <td>''' + _("Description") + '''</td>
            //             <td>''' + _("Reference") + '''</td>
            //             <td>''' + _("Due Date") + '''</td>
            //             <td>''' + _("Amount") + " (%s)" % (
            //             currency.symbol) + '''</td>
            //             <td>''' + _("Lit.") + '''</td>
            //         </tr>
            //         '''
            //         total = 0
            //         for aml in currency_dict['line']:
            //             total += aml['balance']
            //             strbegin = "<TD>"
            //             strend = "</TD>"
            //             date = aml['date_maturity'] or aml['date']
            //             date = datetime.strptime(date, "%d/%m/%Y").date()
            //             if date <= current_date and aml['balance'] > 0:
            //                 strbegin = "<TD><B>"
            //                 strend = "</B></TD>"
            //             followup_table += "<TR>" + strbegin + str(aml['date']) + \
            //                               strend + strbegin + aml['name'] + \
            //                               strend + strbegin + \
            //                               (aml['ref'] or '') + strend + \
            //                               strbegin + str(date) + strend + \
            //                               strbegin + str(aml['balance']) + \
            //                               strend + "</TR>"
            // 
            //         total = reduce(lambda x, y: x + y['balance'],
            //                        currency_dict['line'], 0.00)
            //         total = formatLang(self.env, total, currency_obj=currency)
            //         followup_table += '''<tr> </tr>
            //                         </table>
            //                         <center>''' + _(
            //             "Amount due") + ''' : %s </center>''' % (total)
            // return followup_table
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service(self, invoice_policy, service_type):
            // general_to_service = self._get_general_to_service_map()
            // return general_to_service.get((invoice_policy, service_type), False)
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service_map(self):
            // return {v: k for k, v in self._get_service_to_general_map().items()}
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetGravatarImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_gravatar_image(self, email):
            // email_hash = hashlib.md5(email.lower().encode('utf-8')).hexdigest()
            // url = "https://www.gravatar.com/avatar/" + email_hash
            // try:
            //     res = requests.get(url, params={'d': '404', 's': '128'}, timeout=5)
            //     if res.status_code != requests.codes.ok:
            //         return False
            // except requests.exceptions.ConnectionError as e:
            //     return False
            // except requests.exceptions.Timeout as e:
            //     return False
            // return base64.b64encode(res.content)
            */
            return default;
        }

        public async Task<TEntity> GetHardcodedSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _get_hardcoded_sample(self, model):
            // """
            // Returns a hard-coded sample
            // 
            // @param model: Model of the currently rendered view
            // 
            // @return Sample data records with field values
            // """
            // return [{}]
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_ics_file(self):
            // """ Returns iCalendar file for the event invitation.
            //     :returns a dict of .ics file content for each event
            // """
            // result = {}
            // if not vobject:
            //     return result
            // 
            // for event in self:
            //     cal = vobject.iCalendar()
            //     cal_event = cal.add('vevent')
            // 
            //     cal_event.add('created').value = fields.Datetime.now().replace(tzinfo=pytz.timezone('UTC'))
            //     cal_event.add('dtstart').value = event.date_begin.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('dtend').value = event.date_end.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('summary').value = event.name
            //     cal_event.add('description').value = event._get_external_description()
            //     if event.address_id:
            //         cal_event.add('location').value = event.address_inline
            // 
            //     result[event.id] = cal.serialize().encode('utf-8')
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Products'),
            //     'template': '/product/static/xls/product_template.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('purchase_product_template'):
            //     return [{
            //         'label': _('Import Template for Products'),
            //         'template': '/purchase/static/xls/product_purchase.xls'
            //     }]
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('sale_multi_pricelist_product_template'):
            //     if self.env.user.has_group('product.group_product_pricelist'):
            //         return [{
            //             'label': _("Import Template for Products"),
            //             'template': '/product/static/xls/product_template.xls'
            //         }]
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_incompatible_types(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/odoo/registration-desk"
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_latest(self):
            // company = self.env.user.company_id
            // for partner in self:
            //     amls = partner.unreconciled_aml_ids
            //     latest_date = False
            //     latest_level = False
            //     latest_days = False
            //     latest_level_without_lit = False
            //     latest_days_without_lit = False
            //     for aml in amls:
            //         aml_followup = aml.followup_line_id
            //         if (aml.company_id == company) and aml_followup and \
            //                 (not latest_days or latest_days < aml_followup.delay):
            //             latest_days = aml_followup.delay
            //             latest_level = aml_followup.id
            //         if (aml.company_id == company) and aml.followup_date and (
            //                 not latest_date or latest_date < aml.followup_date):
            //             latest_date = aml.followup_date
            //         if (aml.company_id == company) and \
            //                 (aml_followup and (not latest_days_without_lit or
            //                  latest_days_without_lit < aml_followup.delay)):
            //             latest_days_without_lit = aml_followup.delay
            //             latest_level_without_lit = aml_followup.id
            //     partner.latest_followup_date = latest_date
            //     partner.latest_followup_level_id = latest_level
            //     partner.latest_followup_level_id_without_lit = latest_level_without_lit
            */
            return default;
        }

        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_name_from_ir_config_parameter(self):
            // return self._get_length_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_login_date(self):
            // self.ensure_one()
            // users_login_dates = self.user_ids.mapped('login_date')
            // users_login_dates = list(filter(None, users_login_dates))  # remove falsy values
            // if any(users_login_dates):
            //     return int(max(map(datetime.timestamp, users_login_dates)))
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetMailMessageAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object operation, object model_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // if (
            //     operation == 'create'
            //     and self.env.user.has_group('event.group_event_registration_desk')
            //     and (not model_name or model_name == 'event.event')
            // ):
            //     # allow the registration desk users to post messages on Event
            //     # can not be done with "_mail_post_access" otherwise public user will be
            //     # able to post on published Event (see website_event)
            //     return 'read'
            // return super(EventEvent, self)._get_mail_message_access(res_ids, operation, model_name)
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """ Return 'limit'-first partners' such that the name or email matches a 'search' string.
            //     Prioritize partners that are also (internal) users, and then extend the research to all partners.
            //     The return format is a list of partner data (as per returned by `_to_store()`).
            // """
            // domain = self._get_mention_suggestions_domain(search)
            // partners = self._search_mention_suggestions(domain, limit)
            // return Store(partners).get_result()
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_mention_suggestions_domain(self, search):
            // return expression.AND([
            //     expression.OR([
            //         [('name', 'ilike', search)],
            //         [('email', 'ilike', search)],
            //     ]),
            //     [('active', '=', True)],
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def get_mention_suggestions_from_channel(self, channel_id, search, limit=8):
            // """Return 'limit'-first partners' such that the name or email matches a 'search' string.
            // Prioritize partners that are also (internal) users, and then extend the research to all partners.
            // Only members of the given channel are returned.
            // The return format is a list of partner data (as per returned by `_to_store()`).
            // """
            // channel = self.env["discuss.channel"].search([("id", "=", channel_id)])
            // if not channel:
            //     return []
            // domain = expression.AND(
            //     [
            //         self._get_mention_suggestions_domain(search),
            //         [("channel_ids", "in", channel.id)],
            //     ]
            // )
            // extra_domain = expression.AND([
            //     [('user_ids', '!=', False)],
            //     [('user_ids.active', '=', True)],
            //     [('partner_share', '=', False)]
            // ])
            // allowed_group = (channel.parent_channel_id or channel).group_public_id
            // if allowed_group:
            //     extra_domain = expression.AND(
            //         [
            //             extra_domain,
            //             [("user_ids.groups_id", "in", allowed_group.id)],
            //         ]
            //     )
            // partners = self._search_mention_suggestions(domain, limit, extra_domain)
            // members = self.env["discuss.channel.member"].search(
            //     [
            //         ("channel_id", "=", channel.id),
            //         ("partner_id", "in", partners.ids),
            //     ]
            // )
            // store = Store(members, fields={"channel": [], "persona": []})
            // if allowed_group:
            //     for p in partners:
            //         store.add(p, {"groups_id": [("ADD", (allowed_group & p.user_ids.groups_id).ids)]})
            // return store.get_result()
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // return {
            //     'community': 'community_menu',
            //     'introduction': 'introduction_menu',
            //     'location': 'location_menu',
            //     'register': 'register_menu',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // """" Return a list of fields triggering a split of menu to activate /
            // menu to de-activate. Due to saas-13.3 improvement of menu management
            // this is done using side-methods to ease inheritance.
            // 
            // :return list: list of fields, each of which triggering a menu update
            //   like website_menu, website_track, ... """
            // return ['community_menu', 'introduction_menu', 'location_menu', 'register_menu']
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menus_update_by_field(self, menus_state_by_field, force_update=None):
            // """ For each field linked to a menu, get the set of events requiring
            // this menu to be activated or de-activated based on previous recorded
            // value.
            // 
            // :param menus_state_by_field: see ``_split_menus_state_by_field``;
            // :param force_update: list of field to which we force update of menus. This
            //   is used notably when a direct write to a stored editable field messes with
            //   its pre-computed value, notably in a transient mode (aka demo for example);
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu toggled to True
            //   'deactivated': subset of self having its menu toggled to False
            // } """
            // menus_update_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     if fname in force_update:
            //         menus_update_by_field[fname] = self
            //     else:
            //         menus_update_by_field[fname] = self.env['event.event']
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['activated'].filtered(lambda event: not event[fname])
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['deactivated'].filtered(lambda event: event[fname])
            // return menus_update_by_field
            */
            return default;
        }

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_most_specific_pages(self):
            // ''' Returns the most specific pages in self. '''
            // ids = []
            // previous_page = None
            // page_keys = self.sudo().search(
            //     self.env['website'].website_domain(website_id=self._context.get('website_id'))
            // ).mapped('key')
            // # Iterate a single time on the whole list sorted on specific-website first.
            // for page in self.sorted(key=lambda p: (p.url, not p.website_id)):
            //     if (
            //         (not previous_page or page.url != previous_page.url)
            //         # If a generic page (niche case) has been COWed and that COWed
            //         # page received a URL change, it should not let you access the
            //         # generic page anymore, despite having a different URL.
            //         and (page.website_id or page_keys.count(page.key) == 1)
            //     ):
            //         ids.append(page.id)
            //     previous_page = page
            // return self.browse(ids)
            */
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_needaction_count(self):
            // """ compute the number of needaction of the current partner """
            // self.ensure_one()
            // self.env['mail.notification'].flush_model(['is_read', 'res_partner_id'])
            // self.env.cr.execute("""
            //     SELECT count(*) as needaction_count
            //     FROM mail_notification R
            //     WHERE R.res_partner_id = %s AND (R.is_read = false OR R.is_read IS NULL)""", (self.id,))
            // return self.env.cr.dictfetchall()[0].get('needaction_count')
            */
            return default;
        }

        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _get_on_leave_ids(self):
            // return self.env['res.users']._get_on_leave_ids(partner=True)
            */
            return default;
        }

        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_own_attribute_exclusions(self, combination_ids=None):
            // """Get exclusions coming from the current template.
            // 
            // :param list combination: The combination of the product, as a
            //     list of `product.template.attribute.value` ids.
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

        public async Task<TEntity> GetPackagesFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object default_package_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_packages_from_order(self, order, default_package_type):
            // packages = []
            // 
            // total_cost = 0
            // for line in order.order_line.filtered(lambda line: not line.is_delivery and not line.display_type):
            //     total_cost += self._product_price_to_company_currency(line.product_qty, line.product_id, order.company_id)
            // 
            // total_weight = order._get_estimated_weight() + default_package_type.base_weight
            // order_weight = self.env.context.get('order_weight', False)
            // total_weight = order_weight or total_weight
            // if total_weight == 0.0:
            //     weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            //     raise UserError(_("The package cannot be created because the total weight of the products in the picking is 0.0 %s", weight_uom_name))
            // # If max weight == 0 => division by 0. If this happens, we want to have
            // # more in the max weight than in the total weight, so that it only
            // # creates ONE package with everything.
            // max_weight = default_package_type.max_weight or total_weight + 1
            // total_full_packages = int(total_weight / max_weight)
            // last_package_weight = total_weight % max_weight
            // 
            // package_weights = [max_weight] * total_full_packages + ([last_package_weight] if last_package_weight else [])
            // partial_cost = total_cost / len(package_weights)  # separate the cost uniformly
            // order_commodities = self._get_commodities_from_order(order)
            // 
            // # Split the commodities value uniformly as well
            // for commodity in order_commodities:
            //     commodity.monetary_value /= len(package_weights)
            //     commodity.qty = max(1, commodity.qty // len(package_weights))
            // 
            // for weight in package_weights:
            //     packages.append(DeliveryPackage(
            //         order_commodities,
            //         weight,
            //         default_package_type,
            //         total_cost=partial_cost,
            //         currency=order.company_id.currency_id,
            //         order=order,
            //     ))
            // return packages
            */
            return default;
        }

        public async Task<TEntity> GetPackagesFromPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object picking, object default_package_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _get_packages_from_picking(self, picking, default_package_type):
            // packages = []
            // 
            // if picking.is_return_picking:
            //     commodities = self._get_commodities_from_stock_move_lines(picking.move_line_ids)
            //     weight = picking._get_estimated_weight() + default_package_type.base_weight
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         weight,
            //         default_package_type,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            //     return packages
            // 
            // # Create all packages.
            // for package in picking.move_line_ids.result_package_id:
            //     move_lines = picking.move_line_ids.filtered(lambda ml: ml.result_package_id == package)
            //     commodities = self._get_commodities_from_stock_move_lines(move_lines)
            //     package_total_cost = 0.0
            //     for quant in package.quant_ids:
            //         package_total_cost += self._product_price_to_company_currency(
            //             quant.quantity, quant.product_id, picking.company_id
            //         )
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         package.shipping_weight or package.weight,
            //         package.package_type_id,
            //         name=package.name,
            //         total_cost=package_total_cost,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            // 
            // # Create one package: either everything is in pack or nothing is.
            // if picking.weight_bulk:
            //     commodities = self._get_commodities_from_stock_move_lines(picking.move_line_ids)
            //     package_total_cost = 0.0
            //     for move_line in picking.move_line_ids:
            //         package_total_cost += self._product_price_to_company_currency(
            //             move_line.quantity, move_line.product_id, picking.company_id
            //         )
            //     packages.append(DeliveryPackage(
            //         commodities,
            //         picking.weight_bulk,
            //         default_package_type,
            //         name='Bulk Content',
            //         total_cost=package_total_cost,
            //         currency=picking.company_id.currency_id,
            //         picking=picking,
            //     ))
            // elif not packages:
            //     raise UserError(_(
            //         "The package cannot be created because the total weight of the "
            //         "products in the picking is 0.0 %s",
            //         picking.weight_uom_name
            //     ))
            // return packages
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _get_participant_info(self, edi_identification):
            // hash_participant = md5(edi_identification.lower().encode()).hexdigest()
            // endpoint_participant = parse.quote_plus(f"iso6523-actorid-upis::{edi_identification}")
            // edi_mode = self.env.company._get_peppol_edi_mode()
            // sml_zone = 'acc.edelivery' if edi_mode == 'test' else 'edelivery'
            // smp_url = f"http://B-{hash_participant}.iso6523-actorid-upis.{sml_zone}.tech.ec.europa.eu/{endpoint_participant}"
            // 
            // try:
            //     response = requests.get(smp_url, timeout=TIMEOUT)
            //     response.raise_for_status()
            // except requests.exceptions.RequestException as e:
            //     _logger.debug(e)
            //     return None
            // return etree.fromstring(response.content)
            */
            return default;
        }

        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_partner_from_token(self, token):
            // if payload := tools.verify_hash_signed(self.sudo().env, 'signup', token):
            //     partner_id, user_ids, login_date, signup_type = payload
            //     # login_date can be either an int or "None" as a string for signup
            //     partner = self.browse(partner_id)
            //     if login_date == partner._get_login_date() and partner.user_ids.ids == user_ids and signup_type == partner.browse(partner_id).signup_type:
            //         return partner
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def get_partner_localisation_fields_required_to_invoice(self, country_id):
            // """ Returns the list of fields that needs to be filled when creating an invoice for the selected country.
            // This is required for some flows that would allow a user to request an invoice from the portal.
            // Using these, we can get their information and dynamically create form inputs based for the fields required legally for the company country_id.
            // The returned fields must be of type ir.model.fields in order to handle translations
            // 
            // :param country_id: The country for which we want the fields.
            // :return: an array of ir.model.fields for which the user should provide values.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_partners(self):
            // partners = set()
            // for aml in self:
            //     if aml.partner_id:
            //         partners.add(aml.partner_id.id)
            // return list(partners)
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_edi_format(self):
            // self.ensure_one()
            // return self.invoice_edi_format or self._get_suggested_peppol_edi_format()
            */
            return default;
        }

        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_formats(self):
            // formats_info = self._get_ubl_cii_formats_info()
            // return [format_key for format_key, format_vals in formats_info.items() if format_vals.get('on_peppol')]
            */
            return default;
        }

        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _get_peppol_verification_state(self, peppol_endpoint, peppol_eas, invoice_edi_format):
            // if not (peppol_eas and peppol_endpoint) or invoice_edi_format not in self._get_peppol_formats():
            //     return 'not_verified'
            // 
            // edi_identification = f"{peppol_eas}:{peppol_endpoint}".lower()
            // participant_info = self._get_participant_info(edi_identification)
            // if participant_info is None:
            //     return 'not_valid'
            // else:
            //     is_participant_on_network = self._check_peppol_participant_exists(participant_info, edi_identification)
            //     if is_participant_on_network:
            //         is_valid_format = self._check_document_type_support(participant_info, invoice_edi_format)
            //         if is_valid_format:
            //             return 'valid'
            //         else:
            //             return 'not_valid_format'
            //     else:
            //         return 'not_valid'
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetPriceAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_available(self, order):
            // self.ensure_one()
            // self = self.sudo()
            // order = order.sudo()
            // total = weight = volume = quantity = wv = 0
            // total_delivery = 0.0
            // for line in order.order_line:
            //     if line.state == 'cancel':
            //         continue
            //     if line.is_delivery:
            //         total_delivery += line.price_total
            //     if not line.product_id or line.is_delivery:
            //         continue
            //     if line.product_id.type == "service":
            //         continue
            //     qty = line.product_uom._compute_quantity(line.product_uom_qty, line.product_id.uom_id)
            //     weight += (line.product_id.weight or 0.0) * qty
            //     volume += (line.product_id.volume or 0.0) * qty
            //     wv += (line.product_id.weight or 0.0) * (line.product_id.volume or 0.0) * qty
            //     quantity += qty
            // total = (order.amount_total or 0.0) - total_delivery
            // 
            // total = self._compute_currency(order, total, 'pricelist_to_company')
            // # weight is either,
            // # 1- weight chosen by user in choose.delivery.carrier wizard passed by context
            // # 2- saved weight to use on sale order
            // # 3- total order line weight as fallback
            // weight = self.env.context.get('order_weight') or order.shipping_weight or weight
            // return self._get_price_from_picking(total, weight, volume, quantity, wv=wv)
            */
            return default;
        }

        public async Task<TEntity> GetPriceDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object total, object weight, object volume, object quantity, object wv) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_dict(self, total, weight, volume, quantity, wv=0.):
            // '''Hook allowing to retrieve dict to be used in _get_price_from_picking() function.
            // Hook to be overridden when we need to add some field to product and use it in variable factor from price rules. '''
            // return {
            //     'price': total,
            //     'volume': volume,
            //     'weight': weight,
            //     'wv': wv or volume * weight,
            //     'quantity': quantity
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPriceFromPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object total, object weight, object volume, object quantity, object wv) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _get_price_from_picking(self, total, weight, volume, quantity, wv=0.):
            // price = 0.0
            // criteria_found = False
            // price_dict = self._get_price_dict(total, weight, volume, quantity, wv=wv)
            // for line in self.price_rule_ids:
            //     test = safe_eval(line.variable + line.operator + str(line.max_value), price_dict)
            //     if test:
            //         price = line.list_base_price + line.list_price * price_dict[line.variable_factor]
            //         criteria_found = True
            //         break
            // if not criteria_found:
            //     raise UserError(_("Not available for current order"))
            // 
            // return price
            */
            return default;
        }

        public async Task<TEntity> GetPrintingSponsorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_printing_sponsor_text(self):
            // sponsor_text = self.env['ir.config_parameter'].sudo().get_param('event.badge_printing_sponsor_text')
            // return sponsor_text or "Powered by Odoo"
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // accounts = super(ProductTemplate, self).get_product_accounts(fiscal_pos=fiscal_pos)
            // accounts.update({'stock_journal': self.categ_id.property_stock_journal or False})
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // return {
            //     'income': self.property_account_income_id or self.categ_id.property_account_income_categ_id,
            //     'expense': self.property_account_expense_id or self.categ_id.property_account_expense_categ_id
            // }
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // accounts = super()._get_product_accounts()
            // accounts.update({
            //     'production': self.categ_id.property_stock_account_production_cost_id,
            // })
            // return accounts
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_product_accounts(self):
            // product_accounts = super()._get_product_accounts()
            // product_accounts['downpayment'] = self.categ_id.property_account_downpayment_categ_id
            // return product_accounts
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // """ Add the stock accounts related to product to the result of super()
            // @return: dictionary which contains information regarding stock accounts and super (income+expense accounts)
            // """
            // accounts = super(ProductTemplate, self)._get_product_accounts()
            // res = self._get_asset_accounts()
            // accounts.update({
            //     'stock_input': res['stock_input'] or self.categ_id.property_stock_account_input_categ_id,
            //     'stock_output': res['stock_output'] or self.categ_id.property_stock_account_output_categ_id,
            //     'stock_valuation': self.categ_id.property_stock_valuation_account_id,
            // })
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // self.ensure_one()
            // return expression.OR([
            //     expression.AND([[('res_model', '=', 'product.template')], [('res_id', '=', self.id)]]),
            //     expression.AND([
            //         [('res_model', '=', 'product.product')],
            //         [('res_id', 'in', self.product_variant_ids.ids)],
            //     ])
            // ])
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // """ Override of `product` to filter out gelato print images. """
            // domain = super()._get_product_document_domain()
            // return expression.AND([domain, [('is_gelato', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Return a list of fields present on template and variants models and that are related"""
            // return ['barcode', 'default_code', 'standard_price', 'volume', 'weight', 'packaging_ids', 'product_properties']
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Override of `product` to add `gelato_product_uid` as a related field. """
            // return super()._get_related_fields_variant_template() + ['gelato_product_uid']
            */
            return default;
        }

        public async Task<TEntity> GetReturnLabelAsync<TEntity>(IEnumerable<TEntity> entities, object pickings, object tracking_number, object origin_date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_return_label(self, pickings, tracking_number=None, origin_date=None):
            // self.ensure_one()
            // if self.can_generate_return:
            //     res = getattr(self, '%s_get_return_label' % self.delivery_type)(
            //         pickings, tracking_number, origin_date
            //     )
            //     if self.get_return_label_from_portal:
            //         pickings.return_label_ids.generate_access_token()
            //     return res
            */
            return default;
        }

        public async Task<TEntity> GetReturnLabelPrefixAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_return_label_prefix(self):
            // return 'LabelReturn-%s' % self.delivery_type
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _get_sale_order_domain_count(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
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

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_sales_prices(self, website):
            // if not self:
            //     return {}
            // 
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // fiscal_position = website.fiscal_position_id.sudo()
            // date = fields.Date.context_today(self)
            // 
            // pricelist_prices = pricelist._compute_price_rule(self, 1.0)
            // comparison_prices_enabled = self.env.user.has_group('website_sale.group_product_price_comparison')
            // 
            // res = {}
            // for template in self:
            //     pricelist_price, pricelist_rule_id = pricelist_prices[template.id]
            // 
            //     product_taxes = template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            //     taxes = fiscal_position.map_tax(product_taxes)
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

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _get_schedule(self, start_period, stop_period, everybody=False, merge=True):
            // """
            // This method implements the general case where employees might have different resource calendars at different
            // times, even though this is not the case with only this module installed.
            // This way it will work with these other modules by just overriding
            // `_get_calendar_periods`.
            // 
            // :param datetime start_period: the start of the period
            // :param datetime stop_period: the stop of the period
            // :param boolean everybody: represents the "everybody" filter on calendar
            // :param boolean merge: specifies if calendar's work_intervals needs to be merged
            // :return: schedule (merged or not) by partner
            // :rtype: defaultdict
            // """
            // employees_by_partner = self._get_employees_from_attendees(everybody)
            // if not employees_by_partner:
            //     return {}
            // interval_by_calendar = defaultdict()
            // calendar_periods_by_employee = defaultdict(list)
            // resources_by_calendar = defaultdict(lambda: self.env['resource.resource'])
            // 
            // # Compute employee's calendars's period and order employee by his involved calendars
            // employees = sum(employees_by_partner.values(), start=self.env['hr.employee'])
            // calendar_periods_by_employee = employees._get_calendar_periods(start_period, stop_period)
            // for employee, calendar_periods in calendar_periods_by_employee.items():
            //     for (start, stop, calendar) in calendar_periods:
            //         calendar = calendar or self.env.company.resource_calendar_id  # No calendar if fully flexible
            //         resources_by_calendar[calendar] += employee.resource_id
            // 
            // # Compute all work intervals per calendar
            // for calendar, resources in resources_by_calendar.items():
            //     work_intervals = calendar._work_intervals_batch(start_period, stop_period, resources=resources, tz=timezone(calendar.tz))
            //     del work_intervals[False]
            //     # Merge all employees intervals to avoid to compute it multiples times
            //     if merge:
            //         interval_by_calendar[calendar] = reduce(Intervals.__and__, work_intervals.values())
            //     else:
            //         interval_by_calendar[calendar] = work_intervals
            // 
            // # Compute employee's schedule based own his calendar's periods
            // schedule_by_employee = defaultdict(list)
            // for employee, calendar_periods in calendar_periods_by_employee.items():
            //     employee_interval = Intervals([])
            //     for (start, stop, calendar) in calendar_periods:
            //         calendar = calendar or self.env.company.resource_calendar_id # No calendar if fully flexible
            //         interval = Intervals([(start, stop, self.env['resource.calendar'])])
            //         if merge:
            //             calendar_interval = interval_by_calendar[calendar]
            //         else:
            //             calendar_interval = interval_by_calendar[calendar][employee.resource_id.id]
            //         employee_interval = employee_interval | (calendar_interval & interval)
            //     schedule_by_employee[employee] = employee_interval
            // 
            // # Compute partner's schedule equals to the union between his employees's schedule
            // schedules = defaultdict()
            // for partner, employees in employees_by_partner.items():
            //     partner_schedule = Intervals([])
            //     for employee in employees:
            //         if schedule_by_employee[employee]:
            //             partner_schedule = partner_schedule | schedule_by_employee[employee]
            //     schedules[partner] = partner_schedule
            // return schedules
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general(self, service_policy):
            // return self._get_service_to_general_map().get(service_policy, (False, False))
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_signup_url_for_action(self, url=None, action=None, view_type=None, menu_id=None, res_id=None, model=None):
            // """ generate a signup url for the given partner ids and action, possibly overriding
            //     the url state components (menu_id, id, view_type) """
            // 
            // res = dict.fromkeys(self.ids, False)
            // for partner in self:
            //     base_url = partner.get_base_url()
            //     # when required, make sure the partner has a valid signup token
            //     if self.env.context.get('signup_valid') and not partner.user_ids:
            //         partner.sudo().signup_prepare()
            // 
            //     route = 'login'
            //     # the parameters to encode for the query
            //     query = {'db': self.env.cr.dbname}
            //     if self.env.context.get('create_user'):
            //         query['signup_email'] = partner.email
            // 
            //     signup_type = self.env.context.get('signup_force_type_in_url', partner.sudo().signup_type or '')
            //     if signup_type:
            //         route = 'reset_password' if signup_type == 'reset' else signup_type
            // 
            //     query['token'] = partner.sudo()._generate_signup_token()
            // 
            //     if url:
            //         query['redirect'] = url
            //     else:
            //         fragment = dict()
            //         base = '/odoo/'
            //         if action == '/mail/view':
            //             base = '/mail/view?'
            //         elif action:
            //             fragment['action'] = action
            //         if view_type:
            //             fragment['view_type'] = view_type
            //         if menu_id:
            //             fragment['menu_id'] = menu_id
            //         if model:
            //             fragment['model'] = model
            //         if res_id:
            //             fragment['res_id'] = res_id
            // 
            //         if fragment:
            //             query['redirect'] = base + werkzeug.urls.url_encode(fragment)
            // 
            //     signup_url = "/web/%s?%s" % (route, werkzeug.urls.url_encode(query))
            //     if not self.env.context.get('relative_url'):
            //         signup_url = werkzeug.urls.url_join(base_url, signup_url)
            //     res[partner.id] = signup_url
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_signup_url(self):
            // self.ensure_one()
            // result = self.sudo()._get_signup_url_for_action()
            // if any(u._is_internal() for u in self.user_ids if u != self.env.user):
            //     self.env['res.users'].check_access('write')
            // if any(u._is_portal() for u in self.user_ids if u != self.env.user):
            //     self.env['res.partner'].check_access('write')
            // return result.get(self.id, False)
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // if self.sale_line_warn != 'no-message':
            //     res['sale_warning'] = {
            //         'type': self.sale_line_warn,
            //         'title': _("Warning for %s", self.name),
            //         'message': self.sale_line_warn_msg,
            //     }
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

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return {
            //     'street_name': self.street_name,
            //     'street_number': self.street_number,
            //     'street_number2': self.street_number2
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_suggested_invoice_edi_format(self):
            // # TO OVERRIDE
            // self.ensure_one()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_suggested_peppol_edi_format(self):
            // self.ensure_one()
            // suggested_format = self.commercial_partner_id._get_suggested_ubl_cii_edi_format()
            // return suggested_format if suggested_format in self.env['res.partner']._get_peppol_formats() else 'ubl_bis3'
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_suggested_ubl_cii_edi_format(self):
            // self.ensure_one()
            // format_mapping = self._get_ubl_cii_formats_by_country()
            // country_code = self.commercial_partner_id._deduce_country_code()
            // if country_code in format_mapping:
            //     formats_by_country = format_mapping[country_code]
            //     # return the format with the smallest sequence
            //     if len(formats_by_country) == 1:
            //         return formats_by_country[0]
            //     else:
            //         formats_info = self._get_ubl_cii_formats_info()
            //         return min(formats_by_country, key=lambda e: formats_info[e].get('sequence', 100))  # we use a sequence of 100 by default
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_tickets_access_hash(self, registration_ids):
            // """ Returns the ground truth hash for accessing the tickets in route /event/<int:event_id>/my_tickets.
            // The dl links are always made event-dependant, hence the method linked to the record in self.
            // """
            // self.ensure_one()
            // return tools.hmac(self.env(su=True), 'event-registration-ticket-report-access', (self.id, sorted(registration_ids)))
            */
            return default;
        }

        public async Task<TEntity> GetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def get_tracking_link(self, picking):
            // ''' Ask the tracking link to the service provider
            // 
            // :param picking: record of stock.picking
            // :return str: an URL containing the tracking link or False
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_get_tracking_link' % self.delivery_type):
            //     return getattr(self, '%s_get_tracking_link' % self.delivery_type)(picking)
            */
            return default;
        }

        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_by_country(self):
            // formats_info = self._get_ubl_cii_formats_info()
            // countries = {country for format_val in formats_info.values() for country in (format_val.get('countries') or [])}
            // return {
            //     country_code: [
            //         format_key
            //         for format_key, format_val in formats_info.items() if country_code in (format_val.get('countries') or [])
            //     ]
            //     for country_code in countries
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // return {
            //     'ubl_bis3': {'countries': list(PEPPOL_DEFAULT_COUNTRIES), 'on_peppol': True, 'sequence': 200},
            //     'xrechnung': {'countries': ['DE'], 'on_peppol': True},
            //     'ubl_a_nz': {'countries': ['NZ', 'AU'], 'on_peppol': False},  # Not yet available through Odoo's Access Point, although it's a Peppol valid format
            //     'nlcius': {'countries': ['NL'], 'on_peppol': True},
            //     'ubl_sg': {'countries': ['SG'], 'on_peppol': False},  # Same.
            //     'facturx': {'countries': ['FR'], 'on_peppol': False},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats(self):
            // return list(self._get_ubl_cii_formats_info().keys())
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // domain = [('product_tmpl_id', '=', self.id)]
            // combination_indices_ids = filtered_combination._ids2str()
            // 
            // if combination_indices_ids:
            //     domain = expression.AND([domain, [('combination_indices', '=', combination_indices_ids)]])
            // else:
            //     domain = expression.AND([domain, [('combination_indices', 'in', ['', False])]])
            // 
            // return self.env['product.product'].sudo().with_context(active_test=False).search(domain, order='active DESC', limit=1).id
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_partner.py) ---
            // def _get_vcard_file(self):
            // vcard = self._build_vcard()
            // if vcard:
            //     return vcard.serialize().encode()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """Add context variable force_email in the key as _get_view depends on it."""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self._context.get('force_email'),)
            */
            return default;
        }

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // 
            // if view_type == 'form':
            //     for node in arch.xpath("//field[@name='name' or @name='vat']"):
            //         node.set('widget', 'field_partner_autocomplete')
            // 
            // return arch, view
            */
            return default;
        }

        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_name_from_ir_config_parameter(self):
            // return self._get_volume_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_accessory_product(self):
            // domain = self.env['website'].sale_product_domain()
            // if not self.env.user._is_internal():
            //     domain = expression.AND([domain, [('is_published', '=', True)]])
            // return self.accessory_product_ids.filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_alternative_product(self):
            // domain = self.env['website'].sale_product_domain()
            // return self.alternative_product_ids.filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _get_website_currency(self):
            // company = self.env['website'].get_current_website().company_id
            // return company.currency_id
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // """ Method returning menu entries to display on the website view of the
            // event, possibly depending on some options in inheriting modules.
            // 
            // Each menu entry is a tuple containing :
            //   * name: menu item name
            //   * url: if set, url to a route (do not use xml_id in that case);
            //   * xml_id: template linked to the page (do not use url in that case);
            //   * sequence: specific sequence of menu entry to be set on the menu;
            //   * menu_type: type of menu entry (used in inheriting modules to ease
            //     menu management; not used in this module in 13.3 due to technical
            //     limitations);
            // """
            // self.ensure_one()
            // return [
            //     (_('Introduction'), False, 'website_event.template_intro', 1, 'introduction'),
            //     (_('Location'), False, 'website_event.template_location', 50, 'location'),
            //     (_('Info'), '/event/%s/register' % self.env['ir.http']._slug(self), False, 100, 'register'),
            //     (_('Community'), '/event/%s/community' % self.env['ir.http']._slug(self), False, 80, 'community'),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def get_website_meta(self):
            // self.ensure_one()
            // return self.view_id.get_website_meta()
            */
            return default;
        }

        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_name_from_ir_config_parameter(self):
            // return self._get_weight_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def get_working_hours_for_all_attendees(self, attendee_ids, date_from, date_to, everybody=False):
            // 
            // start_period = datetime.fromisoformat(date_from).replace(hour=0, minute=0, second=0, tzinfo=UTC)
            // stop_period = datetime.fromisoformat(date_to).replace(hour=23, minute=59, second=59, tzinfo=UTC)
            // 
            // schedule_by_partner = self.env['res.partner'].browse(attendee_ids)._get_schedule(start_period, stop_period, everybody)
            // if not schedule_by_partner:
            //     return []
            // return self._interval_to_business_hours(reduce(Intervals.__and__, schedule_by_partner.values()))
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py) ---
            // def get_worklocation(self, start_date, end_date):
            // employee_id = self.env['hr.employee'].search([
            //     ('work_contact_id.id', 'in', self.ids),
            //     ('company_id.id', '=', self.env.company.id)])
            // return employee_id._get_worklocation(start_date, end_date)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def google_map_img(self, zoom=8, width=298, height=298):
            // google_maps_api_key = self.env['website'].get_current_website().google_maps_api_key
            // if not google_maps_api_key:
            //     return False
            // params = {
            //     'center': '%s, %s %s, %s' % (self.street or '', self.city or '', self.zip or '', self.country_id and self.country_id.display_name or ''),
            //     'size': "%sx%s" % (width, height),
            //     'zoom': zoom,
            //     'sensor': 'false',
            //     'key': google_maps_api_key,
            // }
            // return '//maps.googleapis.com/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def google_map_link(self, zoom=10):
            // params = {
            //     'q': '%s, %s %s, %s' % (self.street or '', self.city or '', self.zip or '', self.country_id and self.country_id.display_name or ''),
            //     'z': zoom,
            // }
            // return 'https://maps.google.com/maps?' + werkzeug.urls.url_encode(params)
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def google_map_link(self, zoom=8):
            // """ Temporary method for stable """
            // return self._google_map_link(zoom=zoom)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _google_map_link(self, zoom=8):
            // self.ensure_one()
            // if self.address_id:
            //     return self.sudo().address_id.google_map_link(zoom=zoom)
            // return None
            */
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _google_map_signed_img(self, zoom=13, width=298, height=298):
            // """Create a signed static image URL for the location of this partner."""
            // GOOGLE_MAPS_STATIC_API_KEY = self.env['ir.config_parameter'].sudo().get_param('google_maps.signed_static_api_key')
            // GOOGLE_MAPS_STATIC_API_SECRET = self.env['ir.config_parameter'].sudo().get_param('google_maps.signed_static_api_secret')
            // if not GOOGLE_MAPS_STATIC_API_KEY or not GOOGLE_MAPS_STATIC_API_SECRET:
            //     return None
            // # generate signature as per https://developers.google.com/maps/documentation/maps-static/digital-signature#server-side-signing
            // location_string = f"{self.street}, {self.city} {self.zip}, {self.country_id and self.country_id.display_name or ''}"
            // params = {
            //     'center': location_string,
            //     'markers': f'size:mid|{location_string}',
            //     'size': f"{width}x{height}",
            //     'zoom': zoom,
            //     'sensor': "false",
            //     'key': GOOGLE_MAPS_STATIC_API_KEY,
            // }
            // unsigned_path = '/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            // try:
            //     api_secret_bytes = base64.urlsafe_b64decode(GOOGLE_MAPS_STATIC_API_SECRET + "====")
            // except binascii.Error:
            //     return None
            // url_signature_bytes = hmac.digest(api_secret_bytes, unsigned_path.encode(), 'sha1')
            // params['signature'] = base64.urlsafe_b64encode(url_signature_bytes)
            // 
            // return 'https://maps.googleapis.com/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _handle_first_contact_creation(self):
            // """ On creation of first contact for a company (or root) that has no address, assume contact address
            // was meant to be company address """
            // parent = self.parent_id
            // address_fields = self._address_fields()
            // if (
            //     (parent.is_company or not parent.parent_id)
            //     and any(self[f] for f in address_fields)
            //     and not any(parent[f] for f in address_fields)
            //     and len(parent.child_ids) == 1
            // ):
            //     addr_vals = self._update_fields_values(address_fields)
            //     parent.update_address(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _has_invoice(self, partner_domain):
            // self.ensure_one()
            // invoice = self.env['account.move'].sudo().search(
            //     expression.AND([
            //         partner_domain,
            //         [
            //             ('move_type', 'in', ['out_invoice', 'out_refund']),
            //             ('state', '=', 'posted'),
            //         ]
            //     ]),
            //     limit=1
            // )
            // return bool(invoice)
            */
            return default;
        }

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _has_order(self, partner_domain):
            // self.ensure_one()
            // sale_order = self.env['sale.order'].sudo().search(
            //     expression.AND([
            //         partner_domain,
            //         [
            //             ('state', 'in', ('sent', 'sale')),
            //         ]
            //     ]),
            //     limit=1,
            // )
            // return bool(sale_order)
            */
            return default;
        }

        public async Task<TEntity> IapPartnerAutocompleteAddTagsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def iap_partner_autocomplete_add_tags(self, unspsc_codes):
            // """Called by JS to create the activity tags from the UNSPSC codes"""
            // # If the UNSPSC module is installed, we might have a translation, so let's use it
            // if self.env['ir.module.module']._get('product_unspsc').state == 'installed':
            //     tag_names = self.env['product.unspsc.code']\
            //                     .with_context(active_test=False)\
            //                     .search([('code', 'in', [unspsc_code for unspsc_code, __ in unspsc_codes])])\
            //                     .mapped('name')
            // # If it's not, then we use the default English name provided by DnB
            // else:
            //     tag_names = [unspsc_name for __, unspsc_name in unspsc_codes]
            // 
            // tag_ids = self.env['res.partner.category']
            // for tag_name in tag_names:
            //     if existing_tag := self.env['res.partner.category'].search([('name', '=', tag_name)]):
            //         tag_ids |= existing_tag
            //     else:
            //         tag_ids |= self.env['res.partner.category'].create({'name': tag_name})
            // return tag_ids.ids
            */
            return default;
        }

        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _iap_replace_language_codes(self, iap_data):
            // if lang := iap_data.pop('preferred_language', False):
            //     if installed_lang := (
            //         self.env['res.lang'].search([('code', '=', lang), ('iso_code', '=', lang)])  # specific lang (e.g.: fr_BE)
            //         or
            //         self.env['res.lang'].search([('code', 'ilike', lang[:2]), ('iso_code', 'ilike', lang[:2])], limit=1)  # fallback to generic lang (e.g. fr)
            //     ):
            //         iap_data['lang'] = installed_lang.code
            // return iap_data
            */
            return default;
        }

        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _iap_replace_location_codes(self, iap_data):
            // country_code, country_name = iap_data.pop('country_code', False), iap_data.pop('country_name', False)
            // state_code, state_name = iap_data.pop('state_code', False), iap_data.pop('state_name', False)
            // 
            // country, state = None, None
            // if country_code:
            //     country = self.env['res.country'].search([['code', '=ilike', country_code]])
            // if not country and country_name:
            //     country = self.env['res.country'].search([['name', '=ilike', country_name]])
            // 
            // if country:
            //     if state_code:
            //         state = self.env['res.country.state'].search([
            //             ('country_id', '=', country.id), ('code', '=ilike', state_code)
            //         ], limit=1)
            //     if not state and state_name:
            //         state = self.env['res.country.state'].search([
            //             ('country_id', '=', country.id), ('name', '=ilike', state_name)
            //         ], limit=1)
            // 
            // if country:
            //     iap_data['country_id'] = {'id': country.id, 'display_name': country.display_name}
            // if state:
            //     iap_data['state_id'] = {'id': state.id, 'display_name': state.display_name}
            // 
            // return iap_data
            */
            return default;
        }

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _ie_check_char(self, vat):
            // vat = vat.zfill(8)
            // extra = 0
            // if vat[7] not in ' W':
            //     if vat[7].isalpha():
            //         extra = 9 * (ord(vat[7]) - 64)
            //     else:
            //         # invalid
            //         return -1
            // checksum = extra + sum((8-i) * int(x) for i, x in enumerate(vat[:7]))
            // return 'WABCDEFGHIJKLMNOPQRSTUV'[checksum % 23]
            */
            return default;
        }

        public async Task<TEntity> ImSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object limit, List<Guid> excluded_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def im_search(self, name, limit=20, excluded_ids=None):
            // """ Search partner with a name and return its id, name and im_status.
            //     Note : the user must be logged
            //     :param name : the partner name to search
            //     :param limit : the limit of result to return
            //     :param excluded_ids : the ids of excluded partners
            // """
            // # This method is supposed to be used only in the context of channel creation or
            // # extension via an invite. As both of these actions require the 'create' access
            // # right, we check this specific ACL.
            // if excluded_ids is None:
            //     excluded_ids = []
            // users = self.env['res.users'].search([
            //     ('id', '!=', self.env.user.id),
            //     ('name', 'ilike', name),
            //     ('active', '=', True),
            //     ('share', '=', False),
            //     ('partner_id', 'not in', excluded_ids)
            // ], order='name, id', limit=limit)
            // return Store(users.partner_id).get_result()
            */
            return default;
        }

        public async Task<TEntity> InStoreGetCloseLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_address, Guid product_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def _in_store_get_close_locations(self, partner_address, product_id=None):
            // """ Get the formatted close pickup locations sorted by distance to the partner address.
            // 
            // :param res.partner partner_address: The address to use to sort the pickup locations.
            // :param str product_id: The product whose product page was used to open the location
            //                        selector, if any, as a `product.product` id.
            // :return: The sorted and formatted close pickup locations.
            // :rtype: list[dict]
            // """
            // try:
            //     product_id = product_id and int(product_id)
            // except ValueError:
            //     product = self.env['product.product']
            // else:
            //     product = self.env['product.product'].browse(product_id)
            // 
            // partner_address.geo_localize()  # Calculate coordinates.
            // 
            // pickup_locations = []
            // order_sudo = request.website.sale_get_order()
            // for wh in self.warehouse_ids:
            //     # Prepare the stock data based on either the product or the order.
            //     if product:  # Called from the product page.
            //         in_store_stock_data = utils.format_product_stock_values(product, wh.id)
            //     else:  # Called from the checkout page.
            //         in_store_stock_data = {'in_stock': order_sudo._is_in_stock(wh.id)}
            // 
            //     # Prepare the warehouse location.
            //     wh_location = wh.partner_id
            //     if not wh_location.partner_latitude or not wh_location.partner_longitude:
            //         wh_location.geo_localize()  # Find the longitude and latitude of the warehouse.
            // 
            //     # Format the pickup location values of the warehouse.
            //     try:
            //         pickup_location_values = {
            //             'id': wh.id,
            //             'name': wh_location['name'].title(),
            //             'street': wh_location['street'].title(),
            //             'city': wh_location.city.title(),
            //             'zip_code': wh_location.zip or '',
            //             'country_code': wh_location.country_code,
            //             'state': wh_location.state_id.code,
            //             'latitude': wh_location.partner_latitude,
            //             'longitude': wh_location.partner_longitude,
            //             'additional_data': {'in_store_stock': in_store_stock_data},
            //         }
            //     except AttributeError:
            //         continue  # Ignore warehouses with badly configured address.
            // 
            //     # Prepare the opening hours data.
            //     if wh.opening_hours:
            //         opening_hours_dict = {str(i): [] for i in range(7)}
            //         for att in wh.opening_hours.attendance_ids:
            //             if att.day_period in ('morning', 'afternoon'):
            //                 opening_hours_dict[att.dayofweek].append(
            //                     f'{format_duration(att.hour_from)} - {format_duration(att.hour_to)}'
            //                 )
            //         pickup_location_values['opening_hours'] = opening_hours_dict
            //     else:
            //         pickup_location_values['opening_hours'] = {}
            // 
            //     # Calculate the distance between the partner address and the warehouse location.
            //     pickup_location_values['distance'] = utils.calculate_partner_distance(
            //         partner_address, wh_location
            //     )
            //     pickup_locations.append(pickup_location_values)
            // 
            // return sorted(pickup_locations, key=lambda k: k['distance'])
            */
            return default;
        }

        public async Task<TEntity> InStoreRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py) ---
            // def in_store_rate_shipment(self, *_args):
            // return {
            //     'success': True,
            //     'price': self.product_id.list_price,
            //     'error_message': False,
            //     'warning_message': False,
            // }
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object n) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _increase_rank(self, field, n=1):
            // if self.ids and field in ['customer_rank', 'supplier_rank']:
            //     try:
            //         with self.env.cr.savepoint(flush=False), mute_logger('odoo.sql_db'):
            //             self.env.execute_query(SQL("""
            //                 SELECT %(field)s FROM res_partner WHERE ID IN %(partner_ids)s FOR NO KEY UPDATE NOWAIT;
            //                 UPDATE res_partner SET %(field)s = %(field)s + %(n)s
            //                 WHERE id IN %(partner_ids)s
            //                 """,
            //                 field=SQL.identifier(field),
            //                 partner_ids=tuple(self.ids),
            //                 n=n,
            //             ))
            //             self.invalidate_recordset([field])
            //             self.modified([field])
            //     except (pgerrors.LockNotAvailable, pgerrors.SerializationFailure):
            //         _logger.debug('Another transaction already locked partner rows. Cannot update partner ranks.')
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //     query = """
            //         UPDATE {table}
            //         SET website_sequence = p.web_seq
            //         FROM (VALUES %s) AS p(p_id, web_seq)
            //         WHERE id = p.p_id
            //     """.format(table=self._table)
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
            //     super(Channel, self)._init_column(column_name)
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

        public async Task<TEntity> InstallMoreProviderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def install_more_provider(self):
            // exclude_apps = ['delivery_barcode', 'delivery_stock_picking_batch', 'delivery_iot']
            // return {
            //     'name': _('New Providers'),
            //     'view_mode': 'kanban,form',
            //     'res_model': 'ir.module.module',
            //     'domain': [['name', '=like', 'delivery_%'], ['name', 'not in', exclude_apps]],
            //     'type': 'ir.actions.act_window',
            //     'help': _('''<p class="o_view_nocontent">
            //             Buy Odoo Enterprise now to get more providers.
            //         </p>'''),
            // }
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _interval_to_business_hours(self, working_intervals):
            // # This is the format expected by the fullcalendar library to do the overlay
            // return [{
            //     "daysOfWeek": [(interval[0].weekday() + 1) % 7],
            //     "startTime":  interval[0].astimezone(timezone(self.env.user.tz or 'UTC')).strftime("%H:%M"),
            //     "endTime": interval[1].astimezone(timezone(self.env.user.tz or 'UTC')).strftime("%H:%M"),
            // } for interval in working_intervals] if working_intervals else [{
            //     # 7 is used a dummy value to gray the full week
            //     # Returning an empty list would leave the week uncolored
            //     "daysOfWeek": [7],
            //     "startTime":  datetime.today().strftime("00:00"),
            //     "endTime": datetime.today().strftime("00:00"),
            // }]
            */
            return default;
        }

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _inverse_gelato_product_uid(self):
            // self._set_product_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_invoice_edi_format(self):
            // for partner in self:
            //     if partner.invoice_edi_format == partner._get_suggested_invoice_edi_format():
            //         partner.invoice_edi_format_store = False
            //     elif not partner.invoice_edi_format:
            //         partner.invoice_edi_format_store = 'none'
            //     else:
            //         partner.invoice_edi_format_store = partner.invoice_edi_format
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _inverse_is_favorite(self):
            // unfavorited_jobs = favorited_jobs = self.env['hr.job']
            // for job in self:
            //     if self.env.user in job.favorite_user_ids:
            //         unfavorited_jobs |= job
            //     else:
            //         favorited_jobs |= job
            // favorited_jobs.write({'favorite_user_ids': [(4, self.env.uid)]})
            // unfavorited_jobs.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name(self):
            // for rec in self:
            //     if rec.view_id:
            //         rec.view_id.name = rec.name
            */
            return default;
        }

        public async Task<TEntity> InverseNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name_slugified(self):
            // for rec in self:
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name_slugified)
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _inverse_product_pricelist(self):
            // for partner in self:
            //     pls = self.env['product.pricelist'].search(
            //         [('country_group_ids.country_ids.code', '=', partner.country_id and partner.country_id.code or False)],
            //         limit=1
            //     )
            //     default_for_country = pls
            //     actual = partner.specific_property_product_pricelist
            //     # update at each change country, and so erase old pricelist
            //     if partner.property_product_pricelist or (actual and default_for_country and default_for_country.id != actual.id):
            //         partner.specific_property_product_pricelist = False if partner.property_product_pricelist.id == default_for_country.id else partner.property_product_pricelist.id
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _inverse_street_data(self):
            // """ update self.street based on street_name, street_number and street_number2 """
            // for partner in self:
            //     street = ((partner.street_name or '') + " " + (partner.street_number or '')).strip()
            //     if partner.street_number2:
            //         street = street + " - " + partner.street_number2
            //     partner.street = street
            */
            return default;
        }

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_use_partner_credit_limit(self):
            // company_limit = self._fields['credit_limit'].get_company_dependent_fallback(self)
            // for partner in self:
            //     if not partner.use_partner_credit_limit:
            //         partner.credit_limit = company_limit
            */
            return default;
        }

        public async Task<TEntity> InverseWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _inverse_website_published(self):
            // for record in self:
            //     record.is_published = record.website_published
            */
            return default;
        }

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _invoice_total(self):
            // self.total_invoiced = 0
            // if not self.ids:
            //     return True
            // 
            // all_partners_and_children = {}
            // all_partner_ids = []
            // for partner in self.filtered('id'):
            //     # price_total is in the company currency
            //     all_partners_and_children[partner] = self.with_context(active_test=False).search([('id', 'child_of', partner.id)]).ids
            //     all_partner_ids += all_partners_and_children[partner]
            // 
            // domain = [
            //     ('partner_id', 'in', all_partner_ids),
            //     ('state', 'not in', ['draft', 'cancel']),
            //     ('move_type', 'in', ('out_invoice', 'out_refund')),
            // ]
            // price_totals = self.env['account.invoice.report']._read_group(domain, ['partner_id'], ['price_subtotal:sum'])
            // for partner, child_ids in all_partners_and_children.items():
            //     partner.total_invoiced = sum(price_subtotal_sum for partner, price_subtotal_sum in price_totals if partner.id in child_ids)
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> IsAvailableForOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _is_available_for_order(self, order):
            // self.ensure_one()
            // order.ensure_one()
            // if not self._match(order.partner_shipping_id, order):
            //     return False
            // 
            // if self.delivery_type == 'base_on_rule':
            //     return self.rate_shipment(order).get('success')
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py) ---
            // def _is_available_for_order(self, order):
            // """ Override of `delivery` to exclude regular delivery methods from Gelato orders and Gelato
            // delivery methods from non-Gelato orders.
            // 
            // :param sale.order order: The current order.
            // :return: Whether the delivery method is available for the order.
            // :rtype: bool
            // """
            // is_gelato_order = any(order.order_line.product_id.mapped('gelato_product_uid'))
            // is_gelato_delivery = self.delivery_type == 'gelato'
            // if is_gelato_order and not is_gelato_delivery or not is_gelato_order and is_gelato_delivery:
            //     return False
            // return super()._is_available_for_order(order)
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _is_in_wishlist(self):
            // self.ensure_one()
            // return self in self.env['product.wishlist'].current().mapped('product_id.product_tmpl_id')
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _is_sold_out(self):
            // return self.is_storable and self.product_variant_id._is_sold_out()
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def is_valid_ruc_ec(self, vat):
            // if len(vat) in (10, 13) and vat.isdecimal():
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('event_ticket_ids', 'in', [ticket['id'] for ticket in data['event.event.ticket']['data']])]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'seats_available', 'event_ticket_ids', 'registration_ids', 'seats_limited', 'write_date',
            //         'question_ids', 'general_question_ids', 'specific_question_ids', 'badge_format']
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _load_records_create(self, vals_list):
            // partners = super(Partner, self.with_context(_partners_skip_fields_sync=True))._load_records_create(vals_list)
            // 
            // # batch up first part of _fields_sync
            // # group partners by commercial_partner_id (if not self) and parent_id (if type == contact)
            // groups = collections.defaultdict(list)
            // for partner, vals in zip(partners, vals_list):
            //     cp_id = None
            //     if vals.get('parent_id') and partner.commercial_partner_id != partner:
            //         cp_id = partner.commercial_partner_id.id
            // 
            //     add_id = None
            //     if partner.parent_id and partner.type == 'contact':
            //         add_id = partner.parent_id.id
            //     groups[(cp_id, add_id)].append(partner.id)
            // 
            // for (cp_id, add_id), children in groups.items():
            //     # values from parents (commercial, regular) written to their common children
            //     to_write = {}
            //     # commercial fields from commercial partner
            //     if cp_id:
            //         to_write = self.browse(cp_id)._update_fields_values(self._commercial_fields())
            //     # address fields from parent
            //     if add_id:
            //         parent = self.browse(add_id)
            //         for f in self._address_fields():
            //             v = parent[f]
            //             if v:
            //                 to_write[f] = v.id if isinstance(v, models.BaseModel) else v
            //     if to_write:
            //         self.sudo().browse(children).write(to_write)
            // 
            // # do the second half of _fields_sync the "normal" way
            // for partner, vals in zip(partners, vals_list):
            //     partner._children_sync(vals)
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _log_verification_state_update(self, company, old_value, new_value):
            // # log the update of the peppol verification state
            // # we do this instead of regular tracking because of the customized message
            // # and because we want to log the change for every company in the db
            // if old_value == new_value:
            //     return
            // 
            // peppol_verification_state_field = self._fields['peppol_verification_state']
            // selection_values = dict(peppol_verification_state_field.selection)
            // old_label = selection_values[old_value] if old_value else False  # get translated labels
            // new_label = selection_values[new_value] if new_value else False
            // 
            // body = Markup("""
            //     <ul>
            //         <li>
            //             <span class='o-mail-Message-trackingOld me-1 px-1 text-muted fw-bold'>{old}</span>
            //             <i class='o-mail-Message-trackingSeparator fa fa-long-arrow-right mx-1 text-600'/>
            //             <span class='o-mail-Message-trackingNew me-1 fw-bold text-info'>{new}</span>
            //             <span class='o-mail-Message-trackingField ms-1 fst-italic text-muted'>({field})</span>
            //             <span class='o-mail-Message-trackingCompany ms-1 fst-italic text-muted'>({company})</span>
            //         </li>
            //     </ul>
            // """).format(
            //     old=old_label,
            //     new=new_label,
            //     field=peppol_verification_state_field.string,
            //     company=company.display_name,
            // )
            // self._message_log(body=body)
            */
            return default;
        }

        public async Task<TEntity> LogXmlAsync<TEntity>(IEnumerable<TEntity> entities, object xml_string, object func) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def log_xml(self, xml_string, func):
            // self.ensure_one()
            // 
            // if self.debug_logging:
            //     self.env.flush_all()
            //     db_name = self._cr.dbname
            // 
            //     # Use a new cursor to avoid rollback that could be caused by an upper method
            //     try:
            //         db_registry = Registry(db_name)
            //         with db_registry.cursor() as cr:
            //             env = api.Environment(cr, SUPERUSER_ID, {})
            //             IrLogging = env['ir.logging']
            //             IrLogging.sudo().create({'name': 'delivery.carrier',
            //                       'type': 'server',
            //                       'dbname': db_name,
            //                       'level': 'DEBUG',
            //                       'message': xml_string,
            //                       'path': self.delivery_type,
            //                       'func': func,
            //                       'line': 1})
            //     except psycopg2.Error:
            //         pass
            */
            return default;
        }

        public async Task<TEntity> MailAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id, object force_send, object filter_func) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def mail_attendees(self, template_id, force_send=False, filter_func=lambda self: self.state not in ('cancel', 'draft')):
            // for event in self:
            //     for attendee in event.registration_ids.filtered(filter_func):
            //         self.env['mail.template'].browse(template_id).send_mail(attendee.id, force_send=force_send)
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _mail_get_partners(self, introspect_fields=False):
            // return dict((partner.id, partner) for partner in self)
            */
            return default;
        }

        public async Task<TEntity> MatchAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_address(self, partner):
            // self.ensure_one()
            // if self.country_ids and partner.country_id not in self.country_ids:
            //     return False
            // if self.state_ids and partner.state_id not in self.state_ids:
            //     return False
            // if self.zip_prefix_ids:
            //     regex = re.compile('|'.join(['^' + zip_prefix for zip_prefix in self.zip_prefix_ids.mapped('name')]))
            //     if not partner.zip or not re.match(regex, partner.zip.upper()):
            //         return False
            // return True
            */
            return default;
        }

        public async Task<TEntity> MatchExcludedTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_excluded_tags(self, order):
            // self.ensure_one()
            // return not any(tag in order.order_line.product_id.all_product_tag_ids for tag in self.excluded_tag_ids)
            */
            return default;
        }

        public async Task<TEntity> MatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match(self, partner, order):
            // self.ensure_one()
            // return self._match_address(partner) and self._match_must_have_tags(order) and self._match_excluded_tags(order) and self._match_weight(order) and self._match_volume(order)
            */
            return default;
        }

        public async Task<TEntity> MatchMustHaveTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_must_have_tags(self, order):
            // self.ensure_one()
            // return not self.must_have_tag_ids or any(
            //     tag in order.order_line.product_id.all_product_tag_ids
            //     for tag in self.must_have_tag_ids
            // )
            */
            return default;
        }

        public async Task<TEntity> MatchVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_volume(self, order):
            // self.ensure_one()
            // return not self.max_volume or sum(order_line.product_id.volume * order_line.product_qty for order_line in order.order_line) <= self.max_volume
            */
            return default;
        }

        public async Task<TEntity> MatchWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _match_weight(self, order):
            // self.ensure_one()
            // return not self.max_weight or sum(order_line.product_id.weight * order_line.product_qty for order_line in order.order_line) <= self.max_weight
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _merge_method(self, destination, source):
            // """
            // Prevent merging partners that are linked to already hashed journal items.
            // """
            // if self.env['account.move.line'].sudo().search_count([('move_id.inalterable_hash', '!=', False), ('partner_id', 'in', source.ids)], limit=1):
            //     raise UserError(_('Partners that are used in hashed entries cannot be merged.'))
            // return super()._merge_method(destination, source)
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id:
            //     {'partner_ids': [r.id],
            //      'email_to': False,
            //      'email_cc': False
            //     }
            //     for r in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // self._message_add_suggested_recipient(recipients, partner=self, reason=_('Partner Profile'))
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            //     ]
            //     if self.env["mail.message"].search_count(domain, limit=2) > 1:
            //         raise ValidationError(_("Only a single review can be posted per course."))
            // if message.rating_value and message.is_current_user_or_guest_author:
            //     self.env.user._add_karma(self.karma_gen_channel_rank, self, _("Course Ranked"))
            // return message
            */
            return default;
        }

        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _mondialrelay_search_or_create(self, data):
            // ref = 'MR#%s' % data['id']
            // partner = self.search([
            //     ('id', 'child_of', self.commercial_partner_id.ids),
            //     ('ref', '=', ref),
            //     # fast check that address always the same
            //     ('street', '=', data['street']),
            //     ('zip', '=', data['zip']),
            // ])
            // if not partner:
            //     partner = self.create({
            //         'ref': ref,
            //         'name': data['name'],
            //         'street': data['street'],
            //         'street2': data['street2'],
            //         'zip': data['zip'],
            //         'city': data['city'],
            //         'country_id': self.env.ref('base.%s' % data['country_code']).id,
            //         'type': 'delivery',
            //         'parent_id': self.id,
            //     })
            // return partner
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def name_create(self, name):
            // """ Override of orm's name_create method for partners. The purpose is
            //     to handle some basic formats to create partners using the
            //     name_create.
            //     If only an email address is received and that the regex cannot find
            //     a name, the name will have the email value.
            //     If 'force_email' key in context: must find the email address. """
            // default_type = self._context.get('default_type')
            // if default_type and default_type not in self._fields['type'].get_values(self.env):
            //     context = dict(self._context)
            //     context.pop('default_type')
            //     self = self.with_context(context)
            // name, email_normalized = tools.parse_contact_from_email(name)
            // if self._context.get('force_email') and not email_normalized:
            //     raise ValidationError(_("Couldn't create contact without email address!"))
            // 
            // create_values = {self._rec_name: name or email_normalized}
            // if email_normalized:  # keep default_email in context
            //     create_values['email'] = email_normalized
            // partner = self.create(create_values)
            // return partner.id, partner.display_name
            */
            return default;
        }

        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object args, object @operator, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def name_search(self, name='', args=None, operator='ilike', limit=100):
            // # Only use the product.product heuristics if there is a search term and the domain
            // # does not specify a match on `product.template` IDs.
            // self_obj = self
            // if 'search_product_product' not in self.env.context and any(term[0] == 'id' for term in (args or [])):
            //     self_obj = self_obj.with_context(search_product_product=False)
            // return super(ProductTemplate, self_obj).name_search(name, args, operator, limit)
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Add access button to everyone if the document is published. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.website_published:
            //     for _group_name, _group_method, group_data in groups:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_thread_by_inbox(self, message, recipients_data, msg_vals=False, **kwargs):
            // """ Override to avoid keeping all notified recipients of a comment.
            // We avoid tracking needaction on post comments. Only emails should be
            // sufficient. """
            // if msg_vals is None:
            //     msg_vals = {}
            // if msg_vals.get('message_type', message.message_type) == 'comment':
            //     return
            // return super(BlogPost, self)._notify_thread_by_inbox(message, recipients_data, msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_available_in_pos(self):
            // if self.available_in_pos and not self.sale_ok:
            //     self.sale_ok = True
            */
            return default;
        }

        public async Task<TEntity> OnchangeCanGenerateReturnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_can_generate_return(self):
            // if not self.can_generate_return:
            //     self.return_label_on_delivery = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _onchange_city_id(self):
            // if self.city_id:
            //     self.city = self.city_id.name
            //     self.zip = self.city_id.zipcode
            //     self.state_id = self.city_id.state_id
            // elif self._origin:
            //     self.city = False
            //     self.zip = False
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_country_ids(self):
            // self.state_ids -= self.state_ids.filtered(
            //     lambda state: state._origin.id not in self.country_ids.state_ids.ids
            // )
            // if not self.country_ids:
            //     self.zip_prefix_ids = [Command.clear()]
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> OnchangeEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_email(self):
            // if not self.image_1920 and self._context.get('gravatar_image') and self.email:
            //     self.image_1920 = self._get_gravatar_image(self.email)
            */
            return default;
        }

        public async Task<TEntity> OnchangeIntegrationLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_integration_level(self):
            // if self.integration_level == 'rate':
            //     self.invoice_policy = 'estimated'
            */
            return default;
        }

        public async Task<TEntity> OnchangeMobileValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_parent_id(self):
            // # return values in result, as this method is used by _fields_sync()
            // if not self.parent_id:
            //     return
            // result = {}
            // partner = self._origin
            // if partner.parent_id and partner.parent_id != self.parent_id:
            //     result['warning'] = {
            //         'title': _('Warning'),
            //         'message': _('Changing the company of a contact should only be done if it '
            //                      'was never correctly set. If an existing contact starts working for a new '
            //                      'company then a new contact should be created under that new '
            //                      'company. You can use the "Discard" button to abandon this change.')}
            // if partner.type == 'contact' or self.type == 'contact':
            //     # for contacts: copy the parent address, if set (aka, at least one
            //     # value is set in the address: otherwise, keep the one from the
            //     # contact)
            //     address_fields = self._address_fields()
            //     if any(self.parent_id[key] for key in address_fields):
            //         def convert(value):
            //             return value.id if isinstance(value, models.BaseModel) else value
            //         result['value'] = {key: convert(self.parent_id[key]) for key in address_fields}
            // return result
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdForLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_parent_id_for_lang(self):
            // # While creating / updating child contact, take the parent lang by default if any
            // # otherwise, fallback to default context / DB lang
            // if self.parent_id:
            //     self.lang = self.parent_id.lang or self.env.context.get('default_lang') or self.env.lang
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _onchange_property_product_pricelist(self):
            // open_order = self.env['sale.order'].sudo().search([
            //     ('partner_id', '=', self._origin.id),
            //     ('pricelist_id', '=', self._origin.property_product_pricelist.id),
            //     ('pricelist_id', '!=', self.property_product_pricelist.id),
            //     ('website_id', '!=', False),
            //     ('state', '=', 'draft'),
            // ], limit=1)
            // 
            // if open_order:
            //     return {'warning': {
            //         'title': _('Open Sale Orders'),
            //         'message': _(
            //             "This partner has an open cart. "
            //             "Please note that the pricelist will not be updated on that cart. "
            //             "Also, the cart might not be visible for the customer until you update the pricelist of that cart."
            //         ),
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeReturnLabelOnDeliveryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _onchange_return_label_on_delivery(self):
            // if not self.return_label_on_delivery:
            //     self.get_return_label_from_portal = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_sale_ok(self):
            // if not self.sale_ok:
            //     self.available_in_pos = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_fields(self):
            // for record in self:
            //     default_uom_id = self.env['ir.default']._get_model_defaults('product.template').get('uom_id')
            //     default_uom = self.env['uom.uom'].browse(default_uom_id)
            //     if record.type == 'service' and record.service_type == 'timesheet' and \
            //        not (record._origin.service_policy and record.service_policy == record._origin.service_policy):
            //         if default_uom and default_uom.category_id == self.env.ref('uom.uom_categ_wtime'):
            //             record.uom_id = default_uom
            //         else:
            //             record.uom_id = self.env.ref('uom.product_uom_hour')
            //     elif record._origin.uom_id:
            //         record.uom_id = record._origin.uom_id
            //     elif default_uom:
            //         record.uom_id = default_uom
            //     else:
            //         record.uom_id = self.default_get(['uom_id']).get('uom_id')
            //     record.uom_po_id = record.uom_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _onchange_service_to_purchase(self):
            // products_template = self.filtered(lambda p: p.type != 'service' or p.expense_policy != 'no')
            // products_template.service_to_purchase = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _onchange_standard_price(self):
            //         if self.lot_valuated and any(p.quantity_svl for p in self.product_variant_ids):
            //             return {
            //                 'warning': {
            //                     'title': _("Warning"),
            //                     'message': _("This product is valuated by lot/serial number. Changing the cost \
            // will update the cost of every lot/serial number in stock."),
            //                 }
            //             }
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_tracking(self):
            // return self.mapped('product_variant_ids')._onchange_tracking()
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _onchange_type_event_booth(self):
            // if self.service_tracking == 'event_booth':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _onchange_type_event(self):
            // if self.service_tracking == 'event':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_uom_id(self):
            // if self.uom_id:
            //     self.uom_po_id = self.uom_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _onchange_website_published(self):
            // if self.website_published:
            //     self.is_published = True
            // else:
            //     self.is_published = False
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // return {
            //     **super().open_commercial_entity(),
            //     **({'target': 'new'} if self.env.context.get('target') == 'new' else {}),
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // """ Utility method used to add an "Open Company" button in partner views """
            // self.ensure_one()
            // return {'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': self.commercial_partner_id.id,
            //         'target': 'current',
            //         }
            */
            return default;
        }

        public async Task<TEntity> OpenPricelistRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def open_pricelist_rules(self):
            // self.ensure_one()
            // domain = ['|',
            //     ('product_tmpl_id', '=', self.id),
            //     ('product_id', 'in', self.product_variant_ids.ids),
            //     ('compute_price', '=', 'fixed'),
            // ]
            // return {
            //     'name': _('Price Rules'),
            //     'view_mode': 'list,form',
            //     'views': [(self.env.ref('product.product_pricelist_item_tree_view_from_product').id, 'list')],
            //     'res_model': 'product.pricelist.item',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'domain': domain,
            //     'context': {
            //         'default_product_tmpl_id': self.id,
            //         'default_applied_on': '1_product',
            //         'product_without_variants': self.product_variant_count == 1,
            //         'search_default_visible': True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def open_website_url(self):
            // website_id = False
            // if self.website_id:
            //     website_id = self.website_id.id
            //     if self.website_id.domain:
            //         client_action_url = self.env['website'].get_client_action_url(self.website_url)
            //         client_action_url = f'{client_action_url}&website_id={website_id}'
            //         return {
            //             'type': 'ir.actions.act_url',
            //             'url': url_join(self.website_id.domain, client_action_url),
            //             'target': 'self',
            //         }
            // return self.env['website'].get_client_action(self.website_url, False, website_id)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def open_website_url(self):
            // url = f"/model/{self.name_slugified}"
            // return {
            //     "type": "ir.actions.act_url",
            //     "url": url
            // }
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/slides/{self.env["ir.http"]._slug(self)}')
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT job_id FROM job_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _order(self):
            // res = super()._order
            // partner_search_mode = self.env.context.get('res_partner_search_mode')
            // if partner_search_mode not in ('customer', 'supplier'):
            //     return res
            // order_by_field = f"{partner_search_mode}_rank DESC"
            // return '%s, %s' % (order_by_field, res) if res else order_by_field
            */
            return default;
        }

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_due_search(self, operator, operand):
            // args = [('payment_amount_due', operator, operand)]
            // query, params = self._get_followup_overdue_query(args, overdue_only=False)
            // self._cr.execute(query, params)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_earliest_date_search(self, operator, operand):
            // args = [('payment_earliest_due_date', operator, operand)]
            // company_id = self.env.user.company_id.id
            // having_where_clause = ' AND '.join(
            //     map(lambda x: "(MIN(l.date_maturity) %s '%%s')" % (x[1]), args))
            // having_values = [x[2] for x in args]
            // having_where_clause = having_where_clause % (having_values[0])
            // query = """SELECT partner_id FROM account_move_line l
            //         LEFT JOIN account_account a ON a.id = l.account_id
            //         WHERE a.account_type = 'asset_receivable' 
            //         AND l.company_id = %s 
            //         AND l.full_reconcile_id IS NULL 
            //         AND partner_id IS NOT NULL GROUP BY partner_id"""
            // query = query % company_id
            // if having_where_clause:
            //     query += ' HAVING %s ' % (having_where_clause)
            // self._cr.execute(query)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_overdue_search(self, operator, operand):
            // args = [('payment_amount_overdue', operator, operand)]
            // query, params = self._get_followup_overdue_query(args, overdue_only=True)
            // self._cr.execute(query, params)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # field dependencies of methods _compute_peppol_endpoint() and _compute_peppol_eas()
            // # because we need to extend depends in l10n modules
            // return ['country_code', 'vat', 'company_registry']
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _prepare_display_address(self, without_company=False):
            // # get the information that will be injected into the display format
            // # get the address format
            // address_format = self._get_address_format()
            // args = defaultdict(str, {
            //     'state_code': self.state_id.code or '',
            //     'state_name': self.state_id.name or '',
            //     'country_code': self.country_id.code or '',
            //     'country_name': self._get_country_name(),
            //     'company_name': self.commercial_company_name or '',
            // })
            // for field in self._formatting_address_fields():
            //     args[field] = self[field] or ''
            // if without_company:
            //     args['company_name'] = ''
            // elif self.commercial_company_name:
            //     address_format = '%(company_name)s\n' + address_format
            // return address_format, args
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.invoice_policy == 'delivery':
            //     return _("Invoice after delivery, based on quantities delivered, not ordered.")
            // elif self.invoice_policy == 'order':
            //     if self.type == 'consu':
            //         return _("You can invoice goods before they are delivered.")
            //     elif self.type == 'service':
            //         return _("Invoice ordered quantities as soon as this service is sold.")
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

        public async Task<TEntity> PrepareSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object length) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _prepare_sample(self, length=6):
            // """
            // Generates sample data and returns it the right format for render.
            // 
            // @param length: Number of sample records to generate
            // 
            // @return Array of objets with a value associated to each name in field_names
            // """
            // if not length:
            //     return []
            // records = self._prepare_sample_records(length)
            // return self._filter_records_to_values(records, is_sample=True)
            */
            return default;
        }

        public async Task<TEntity> PrepareSampleRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object length) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _prepare_sample_records(self, length):
            // """
            // Generates sample records.
            // 
            // @param length: Number of sample records to generate
            // 
            // @return List of of sample records
            // """
            // if not length:
            //     return []
            // 
            // sample = []
            // model = self.env[self.model_name]
            // sample_data = self._get_hardcoded_sample(model)
            // if sample_data:
            //     for index in range(0, length):
            //         single_sample_data = sample_data[index % len(sample_data)].copy()
            //         self._fill_sample(single_sample_data, index)
            //         sample.append(model.new(single_sample_data))
            // return sample
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> PrepareValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit, object search_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _prepare_values(self, limit=None, search_domain=None):
            // """Gets the data and returns it the right format for render."""
            // self.ensure_one()
            // 
            // # The "limit" field is there to prevent loading an arbitrary number of
            // # records asked by the client side. This here makes sure you can always
            // # load at least 16 records as it is what the editor allows.
            // max_limit = max(self.limit, 16)
            // limit = limit and min(limit, max_limit) or max_limit
            // 
            // if self.filter_id:
            //     filter_sudo = self.filter_id.sudo()
            //     domain = filter_sudo._get_eval_domain()
            //     if 'website_id' in self.env[filter_sudo.model_id]:
            //         domain = expression.AND([domain, self.env['website'].get_current_website().website_domain()])
            //     if 'company_id' in self.env[filter_sudo.model_id]:
            //         website = self.env['website'].get_current_website()
            //         domain = expression.AND([domain, [('company_id', 'in', [False, website.company_id.id])]])
            //     if 'is_published' in self.env[filter_sudo.model_id]:
            //         domain = expression.AND([domain, [('is_published', '=', True)]])
            //     if search_domain:
            //         domain = expression.AND([domain, search_domain])
            //     try:
            //         records = self.env[filter_sudo.model_id].sudo(False).with_context(**literal_eval(filter_sudo.context)).search(
            //             domain,
            //             order=','.join(literal_eval(filter_sudo.sort)) or None,
            //             limit=limit
            //         )
            //         return self._filter_records_to_values(records.sudo())
            //     except MissingError:
            //         _logger.warning("The provided domain %s in 'ir.filters' generated a MissingError in '%s'", domain, self._name)
            //         return []
            // elif self.action_server_id:
            //     try:
            //         return self.action_server_id.with_context(
            //             dynamic_filter=self,
            //             limit=limit,
            //             search_domain=search_domain,
            //         ).sudo().run() or []
            //     except MissingError:
            //         _logger.warning("The provided domain %s in 'ir.actions.server' generated a MissingError in '%s'", search_domain, self._name)
            //         return []
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _process_enriched_response(self, response, error):
            // if response and response.get('data'):
            //     result = self._format_data_company(response.get('data'))
            // else:
            //     result = {}
            // 
            // if response and response.get('credit_error'):
            //     result.update({
            //         'error': True,
            //         'error_message': 'Insufficient Credit'
            //     })
            // elif response and response.get('error'):
            //     result.update({
            //         'error': True,
            //         'error_message': _('Unable to enrich company (no credit was consumed).'),
            //     })
            // elif error:
            //     result.update({
            //         'error': True,
            //         'error_message': error
            //     })
            // return result
            */
            return default;
        }

        public async Task<TEntity> ProductPriceToCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object quantity, object product, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def _product_price_to_company_currency(self, quantity, product, company):
            // return company.currency_id._convert(quantity * product.standard_price, product.currency_id, company, fields.Date.today())
            */
            return default;
        }

        public async Task<TEntity> RateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def rate_shipment(self, order):
            // ''' Compute the price of the order shipment
            // 
            // :param order: record of sale.order
            // :return dict: {'success': boolean,
            //                'price': a float,
            //                'error_message': a string containing an error message,
            //                'warning_message': a string containing a warning message}
            //                # TODO maybe the currency code?
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_rate_shipment' % self.delivery_type):
            //     res = getattr(self, '%s_rate_shipment' % self.delivery_type)(order)
            //     # apply fiscal position
            //     company = self.company_id or order.company_id or self.env.company
            //     res['price'] = self.product_id._get_tax_included_unit_price(
            //         company,
            //         company.currency_id,
            //         order.date_order,
            //         'sale',
            //         fiscal_position=order.fiscal_position_id,
            //         product_price_unit=res['price'],
            //         product_currency=company.currency_id
            //     )
            //     # apply margin on computed price
            //     res['price'] = self.with_context(order=order)._apply_margins(res['price'])
            //     # save the real price in case a free_over rule overide it to 0
            //     res['carrier_price'] = res['price']
            //     # free when order is large enough
            //     amount_without_delivery = order._compute_amount_total_without_delivery()
            //     if (
            //         res['success']
            //         and self.free_over
            //         and self.delivery_type != 'base_on_rule'
            //         and self._compute_currency(order, amount_without_delivery, 'pricelist_to_company') >= self.amount
            //     ):
            //         res['warning_message'] = _('The shipping is free since the order amount exceeds %.2f.', self.amount)
            //         res['price'] = 0.0
            //     return res
            // else:
            //     return {
            //         'success': False,
            //         'price': 0.0,
            //         'error_message': _('Error: this delivery method is not available.'),
            //         'warning_message': False,
            //     }
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super()._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super(Channel, self)._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> ReadByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def read_by_vat(self, vat, timeout=15):
            // return []
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // removed_channel_partner_domain = expression.OR([
            //     [('partner_id', 'in', partner_ids),
            //      ('channel_id', '=', channel.id)]
            //     for channel in self
            // ])
            // 
            // self.message_unsubscribe(partner_ids=partner_ids)
            // if self:
            //     removed_channel_partner = self.env['slide.channel.partner'].sudo().search(removed_channel_partner_domain)
            //     if removed_channel_partner:
            //         removed_channel_partner.action_archive()
            */
            return default;
        }

        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_key, object limit, object search_domain, object with_sample) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py) ---
            // def _render(self, template_key, limit, search_domain=None, with_sample=False, **custom_template_data):
            // """Renders the website dynamic snippet items"""
            // self.ensure_one()
            // assert '.dynamic_filter_template_' in template_key, _("You can only use template prefixed by dynamic_filter_template_ ")
            // if search_domain is None:
            //     search_domain = []
            // 
            // if self.website_id and self.env['website'].get_current_website() != self.website_id:
            //     return ''
            // 
            // if self.model_name.replace('.', '_') not in template_key:
            //     return ''
            // 
            // records = self._prepare_values(limit=limit, search_domain=search_domain)
            // is_sample = with_sample and not records
            // if is_sample:
            //     records = self._prepare_sample(limit)
            // content = self.env['ir.qweb'].with_context(inherit_branding=False)._render(template_key, dict(
            //     records=records,
            //     is_sample=is_sample,
            //     **custom_template_data,
            // ))
            // return [etree.tostring(el, encoding='unicode', method='html') for el in html.fromstring('<root>%s</root>' % str(content)).getchildren()]
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner(self, name=None, phone=None, email=None, vat=None, domain=None, company=None):
            // '''Search all partners and find one that matches one of the parameters.
            // :param name:    The name of the partner.
            // :param phone:   The phone or mobile of the partner.
            // :param mail:    The mail of the partner.
            // :param vat:     The vat number of the partner.
            // :param domain:  An extra domain to apply.
            // :param company: The company of the partner.
            // :returns:       A partner or an empty recordset if not found.
            // '''
            // 
            // def search_with_vat(extra_domain):
            //     return self._retrieve_partner_with_vat(vat, extra_domain)
            // 
            // def search_with_phone_mail(extra_domain):
            //     return self._retrieve_partner_with_phone_email(phone, email, extra_domain)
            // 
            // def search_with_name(extra_domain):
            //     return self._retrieve_partner_with_name(name, extra_domain)
            // 
            // def search_with_domain(extra_domain):
            //     if not domain:
            //         return None
            //     return self.env['res.partner'].search(domain + extra_domain, limit=1)
            // 
            // for search_method in (search_with_vat, search_with_domain, search_with_phone_mail, search_with_name):
            //     for extra_domain in (
            //         [*self.env['res.partner']._check_company_domain(company or self.env.company), ('company_id', '!=', False)],
            //         [('company_id', '=', False)],
            //     ):
            //         partner = search_method(extra_domain)
            // 
            //         # The VAT should be a sufficiently distinctive criterion
            //         if partner and search_method == search_with_vat:
            //             return partner[:1]
            //         if partner and len(partner) == 1:
            //             return partner
            // return self.env['res.partner']
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_name(self, name, extra_domain):
            // if not name:
            //     return None
            // return self.env['res.partner'].search([('name', 'ilike', name)] + extra_domain, limit=2)
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_phone_email(self, phone, email, extra_domain):
            // domains = []
            // if phone:
            //     domains.append([('phone', '=', phone)])
            //     domains.append([('mobile', '=', phone)])
            // if email:
            //     domains.append([('email', '=', email)])
            // 
            // if not domains:
            //     return None
            // 
            // domain = expression.OR(domains)
            // if extra_domain:
            //     domain = expression.AND([domain, extra_domain])
            // return self.env['res.partner'].search(domain, limit=2)
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_vat(self, vat, extra_domain):
            // if not vat:
            //     return None
            // 
            // # Sometimes, the vat is specified with some whitespaces.
            // normalized_vat = vat.replace(' ', '')
            // country_prefix = re.match('^[a-zA-Z]{2}|^', vat).group()
            // 
            // partner = self.env['res.partner'].search(extra_domain + [('vat', 'in', (normalized_vat, vat))], limit=2)
            // 
            // # Try to remove the country code prefix from the vat.
            // if not partner and country_prefix:
            //     partner = self.env['res.partner'].search(extra_domain + [
            //         ('vat', 'in', (normalized_vat[2:], vat[2:])),
            //         ('country_id.code', '=', country_prefix.upper()),
            //     ], limit=2)
            // 
            //     # The country could be not specified on the partner.
            //     if not partner:
            //         partner = self.env['res.partner'].search(extra_domain + [
            //             ('vat', 'in', (normalized_vat[2:], vat[2:])),
            //             ('country_id', '=', False),
            //         ], limit=2)
            // 
            // # The vat could be a string of alphanumeric values without country code but with missing zeros at the
            // # beginning.
            // if not partner:
            //     try:
            //         vat_only_numeric = str(int(re.sub(r'^\D{2}', '', normalized_vat) or 0))
            //     except ValueError:
            //         vat_only_numeric = None
            // 
            //     if vat_only_numeric:
            //         if country_prefix:
            //             vat_prefix_regex = f'({country_prefix})?'
            //         else:
            //             vat_prefix_regex = '([A-z]{2})?'
            //         Partner = self.env['res.partner']
            //         query = Partner._search(extra_domain + [('active', '=', True)], limit=2)
            //         query.add_where(SQL(
            //             "%s ~ %s",
            //             Partner._field_to_sql(Partner._table, 'vat'),
            //             f'^{vat_prefix_regex}0*{vat_only_numeric}$',
            //         ))
            //         partner_row = list(query)
            //         if partner_row and len(partner_row) == 1:
            //             partner = Partner.browse(partner_row[0])
            // 
            // return partner
            */
            return default;
        }

        public async Task<TEntity> RunVatTestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat_number, object default_country, object partner_is_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _run_vat_test(self, vat_number, default_country, partner_is_company=True):
            // """ Checks a VAT number syntactically to ensure its validity upon saving.
            // 
            // :param vat_number: a string with the VAT number to check.
            // :param default_country: a res.country object
            // :param partner_is_company: True if the partner is a company, else False.
            //     .. deprecated:: 16.0
            //         Will be removed in 16.2
            // 
            // :return: The country code (in lower case) of the country the VAT number
            //          was validated for, if it was validated. False if it could not be validated
            //          against the provided or guessed country. None if no country was available
            //          for the check, and no conclusion could be made with certainty.
            // """
            // return default_country.code.lower()
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _run_vat_test(self, vat_number, default_country, partner_is_company=True):
            // # OVERRIDE account
            // check_result = None
            // 
            // # First check with country code as prefix of the TIN
            // vat_country_code, vat_number_split = self._split_vat(vat_number)
            // 
            // if vat_country_code == 'eu' and default_country not in self.env.ref('base.europe').country_ids:
            //     # Foreign companies that trade with non-enterprises in the EU
            //     # may have a VATIN starting with "EU" instead of a country code.
            //     return True
            // 
            // vat_has_legit_country_code = self.env['res.country'].search([('code', '=', vat_country_code.upper())], limit=1)
            // if not vat_has_legit_country_code:
            //     vat_has_legit_country_code = vat_country_code.lower() in _region_specific_vat_codes
            // if vat_has_legit_country_code:
            //     check_result = self.simple_vat_check(vat_country_code, vat_number_split)
            //     if check_result:
            //         return vat_country_code
            // 
            // # If it fails, check with default_country (if it exists)
            // if default_country:
            //     check_result = self.simple_vat_check(default_country.code.lower(), vat_number)
            //     if check_result:
            //         return default_country.code.lower()
            // 
            // # We allow any number if it doesn't start with a country code and the partner has no country.
            // # This is necessary to support an ORM limitation: setting vat and country_id together on a company
            // # triggers two distinct write on res.partner, one for each field, both triggering this constraint.
            // # If vat is set before country_id, the constraint must not break.
            // return check_result
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def schedule_meeting(self):
            // self.ensure_one()
            // partner_ids = self.ids
            // partner_ids.append(self.env.user.partner_id.id)
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // action['context'] = {
            //     'default_partner_ids': partner_ids,
            // }
            // action['domain'] = ['|', ('id', 'in', self._compute_meeting()[self.id]), ('partner_ids', 'in', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_address_search(self, operator, value):
            // if operator != 'ilike' or not isinstance(value, str):
            //     raise NotImplementedError(_('Operation not supported.'))
            // 
            // return expression.OR([
            //     [('address_id.name', 'ilike', value)],
            //     [('address_id.street', 'ilike', value)],
            //     [('address_id.street2', 'ilike', value)],
            //     [('address_id.city', 'ilike', value)],
            //     [('address_id.zip', 'ilike', value)],
            //     [('address_id.state_id', 'ilike', value)],
            //     [('address_id.country_id', 'ilike', value)],
            // ])
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_build_dates(self):
            // today = fields.Datetime.today()
            // 
            // def sdn(date):
            //     return fields.Datetime.to_string(date.replace(hour=23, minute=59, second=59))
            // 
            // def sd(date):
            //     return fields.Datetime.to_string(date)
            // 
            // def get_month_filter_domain(filter_name, months_delta):
            //     first_day_of_the_month = today.replace(day=1)
            //     filter_string = _('This month') if months_delta == 0 \
            //         else format_date(self.env, value=today + relativedelta(months=months_delta),
            //             date_format='LLLL', lang_code=get_lang(self.env).code).capitalize()
            //     return [filter_name, filter_string, [
            //         ("date_end", ">=", sd(first_day_of_the_month + relativedelta(months=months_delta))),
            //         ("date_begin", "<", sd(first_day_of_the_month + relativedelta(months=months_delta+1)))],
            //         0]
            // 
            // return [
            //     ['upcoming', _('Upcoming Events'), [("date_end", ">", sd(today))], 0],
            //     ['today', _('Today'), [
            //         ("date_end", ">", sd(today)),
            //         ("date_begin", "<", sdn(today))],
            //         0],
            //     get_month_filter_domain('month', 0),
            //     ['old', _('Past Events'), [
            //         ("date_end", "<", sd(today))],
            //         0],
            //     ['all', _('All Events'), [], 0]
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_display_name(self, operator, value):
            // domain = super()._search_display_name(operator, value)
            // if self.env.context.get('search_product_product', bool(value)):
            //     combine = expression.OR if operator not in expression.NEGATIVE_TERM_OPERATORS else expression.AND
            //     domain = combine([domain, [('product_variant_ids', operator, value)]])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_fetch(self, search_detail, search, limit, order):
            // with_description = 'description' in search_detail['mapping']
            // # Cannot rely on the super's _search_fetch because the search must be
            // # performed among the most specific pages only.
            // fields = search_detail['search_fields']
            // base_domain = search_detail['base_domain']
            // domain = self._search_build_domain(base_domain, search, fields, search_detail.get('search_extra'))
            // most_specific_pages = self.env['website']._get_website_pages(
            //     domain=expression.AND(base_domain), order=order
            // )
            // results = most_specific_pages.filtered_domain(domain)  # already sudo
            // v_arch_db = self.env['ir.ui.view']._field_to_sql('v', 'arch_db')
            // 
            // if with_description and search and most_specific_pages:
            //     # Perform search in translations
            //     # TODO Remove when domains will support xml_translate fields
            //     self.env.cr.execute(SQL(
            //         """
            //         SELECT DISTINCT %(table)s.id
            //         FROM %(table)s
            //         LEFT JOIN ir_ui_view v ON %(table)s.view_id = v.id
            //         WHERE (v.name ILIKE %(search)s
            //         OR %(v_arch_db)s ILIKE %(search)s)
            //         AND %(table)s.id IN %(ids)s
            //         LIMIT %(limit)s
            //         """,
            //         table=SQL.identifier(self._table),
            //         search=f"%{escape_psql(search)}%",
            //         v_arch_db=v_arch_db,
            //         ids=tuple(most_specific_pages.ids),
            //         limit=len(most_specific_pages.ids),
            //     ))
            //     ids = {row[0] for row in self.env.cr.fetchall()}
            //     if ids:
            //         ids.update(results.ids)
            //         domains = search_detail['base_domain'].copy()
            //         domains.append([('id', 'in', list(ids))])
            //         domain = expression.AND(domains)
            //         model = self.sudo() if search_detail.get('requires_sudo') else self
            //         results = model.search(
            //             domain,
            //             limit=len(ids),
            //             order=search_detail.get('order', order)
            //         )
            // 
            // def filter_page(search, page, all_pages):
            //     # Search might have matched words in the xml tags and parameters therefore we make
            //     # sure the terms actually appear inside the text.
            //     text = '%s %s %s' % (page.name, page.url, text_from_html(page.arch))
            //     pattern = '|'.join([re.escape(search_term) for search_term in search.split()])
            //     return re.findall('(%s)' % pattern, text, flags=re.I) if pattern else False
            // if search and with_description:
            //     results = results.filtered(lambda result: filter_page(search, result, results))
            // return results[:limit], len(results)
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def search_for_channel_invite(self, search_term, channel_id=None, limit=30):
            // """Returns partners matching search_term that can be invited to a channel.
            // If the channel_id is specified, only partners that can actually be invited to the channel
            // are returned (not already members, and in accordance to the channel configuration).
            // """
            // domain = expression.AND(
            //     [
            //         expression.OR(
            //             [
            //                 [("name", "ilike", search_term)],
            //                 [("email", "ilike", search_term)],
            //             ]
            //         ),
            //         [("active", "=", True)],
            //         [("user_ids", "!=", False)],
            //         [("user_ids.active", "=", True)],
            //         [("user_ids.share", "=", False)],
            //     ]
            // )
            // channel = self.env["discuss.channel"]
            // if channel_id:
            //     channel = self.env["discuss.channel"].search([("id", "=", int(channel_id))])
            //     domain = expression.AND([domain, [("channel_ids", "not in", channel.id)]])
            //     if channel.group_public_id:
            //         domain = expression.AND(
            //             [domain, [("user_ids.groups_id", "in", channel.group_public_id.id)]]
            //         )
            // query = self._search(domain, limit=limit)
            // # bypass lack of support for case insensitive order in search()
            // query.order = SQL('LOWER(%s), "res_partner"."id"', self._field_to_sql(self._table, "name"))
            // store = Store()
            // self.env["res.partner"].browse(query)._search_for_channel_invite_to_store(store, channel)
            // return {
            //     "count": self.env["res.partner"].search_count(domain),
            //     "data": store.get_result(),
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _search_for_channel_invite_to_store(self, store: Store, channel):
            // super()._search_for_channel_invite_to_store(store, channel)
            // if channel.channel_type != "livechat" or not self:
            //     return
            // lang_name_by_code = dict(self.env["res.lang"].get_installed())
            // invite_by_self_count_by_partner_id = dict(
            //     self.env["discuss.channel.member"]._read_group(
            //         [["create_uid", "=", self.env.user.id], ["partner_id", "in", self.ids]],
            //         groupby=["partner_id"],
            //         aggregates=["__count"],
            //     )
            // )
            // active_livechat_partners = (
            //     self.env["im_livechat.channel"].search([]).available_operator_ids.partner_id
            // )
            // for partner in self:
            //     store.add(
            //         partner,
            //         {
            //             "invite_by_self_count": invite_by_self_count_by_partner_id.get(partner, 0),
            //             "is_available": partner in active_livechat_partners,
            //             "lang_name": lang_name_by_code[partner.lang],
            //         },
            //     )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _search_for_channel_invite_to_store(self, store: Store, channel):
            // store.add(self)
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // # Read access on website.page requires sudo.
            // requires_sudo = True
            // domain = [website.website_domain()]
            // if not self.env.user.has_group('website.group_website_designer'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // search_fields = ['name', 'url']
            // fetch_fields = ['id', 'name', 'url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('arch_db')
            //     fetch_fields.append('arch')
            //     mapping['description'] = {'name': 'arch', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'website.page',
            //     'base_domain': domain,
            //     'requires_sudo': requires_sudo,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-file-o',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // blog = options.get('blog')
            // tags = options.get('tag')
            // date_begin = options.get('date_begin')
            // date_end = options.get('date_end')
            // state = options.get('state')
            // domain = [website.website_domain()]
            // if blog:
            //     domain.append([('blog_id', '=', self.env['ir.http']._unslug(blog)[1])])
            // if tags:
            //     active_tag_ids = [self.env['ir.http']._unslug(tag)[1] for tag in tags.split(',')] or []
            //     if active_tag_ids:
            //         domain.append([('tag_ids', 'in', active_tag_ids)])
            // if date_begin and date_end:
            //     domain.append([("post_date", ">=", date_begin), ("post_date", "<=", date_end)])
            // if self.env.user.has_group('website.group_website_designer'):
            //     if state == "published":
            //         domain.append([("website_published", "=", True), ("post_date", "<=", fields.Datetime.now())])
            //     elif state == "unpublished":
            //         domain.append(['|', ("website_published", "=", False), ("post_date", ">", fields.Datetime.now())])
            // else:
            //     domain.append([("post_date", "<=", fields.Datetime.now())])
            // search_fields = ['name', 'author_name']
            // def search_in_tags(env, search_term):
            //     tags_like_search = env['blog.tag'].search([('name', 'ilike', search_term)])
            //     return [('tag_ids', 'in', tags_like_search.ids)]
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('content')
            //     fetch_fields.append('content')
            //     mapping['description'] = {'name': 'content', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('published_date')
            //     mapping['detail'] = {'name': 'published_date', 'type': 'date'}
            // return {
            //     'model': 'blog.post',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_tags,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-rss',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // date = options.get('date', 'all')
            // country = options.get('country')
            // tags = options.get('tags')
            // event_type = options.get('type', 'all')
            // 
            // domain = [website.website_domain()]
            // domain.append([('is_visible_on_website', '=', True)])
            // 
            // if event_type != 'all':
            //     domain.append([("event_type_id", "=", int(event_type))])
            // search_tags = self.env['event.tag']
            // if tags:
            //     try:
            //         tag_ids = literal_eval(tags)
            //     except SyntaxError:
            //         pass
            //     else:
            //         # perform a search to filter on existing / valid tags implicitely + apply rules on color
            //         search_tags = self.env['event.tag'].search([('id', 'in', tag_ids)])
            // 
            //     # Example: You filter on age: 10-12 and activity: football.
            //     # Doing it this way allows to only get events who are tagged "age: 10-12" AND "activity: football".
            //     # Add another tag "age: 12-15" to the search and it would fetch the ones who are tagged:
            //     # ("age: 10-12" OR "age: 12-15") AND "activity: football
            //     for tags in search_tags.grouped('category_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
            // 
            // no_country_domain = domain.copy()
            // if country:
            //     if country == 'online':
            //         domain.append([("country_id", "=", False)])
            //     elif country != 'all':
            //         domain.append([("country_id", "=", int(country))])
            // 
            // no_date_domain = domain.copy()
            // dates = self._search_build_dates()
            // current_date = None
            // for date_details in dates:
            //     if date == date_details[0]:
            //         domain.append(date_details[2])
            //         no_country_domain.append(date_details[2])
            //         if date_details[0] != 'upcoming':
            //             current_date = date_details[1]
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url', 'address_name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            //     'address_name': {'name': 'address_name', 'type': 'text', 'match': True},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // if with_date:
            //     mapping['detail'] = {'name': 'range', 'type': 'html'}
            // 
            // # Bypassing the access rigths of partner to search the address.
            // def search_in_address(env, search_term):
            //     ret = env['event.event'].sudo()._search([
            //        ('address_search', 'ilike', search_term),
            //     ])
            //     return [('id', 'in', ret)]
            // 
            // return {
            //     'model': 'event.event',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_address,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-ticket',
            //     # for website_event main controller:
            //     'dates': dates,
            //     'current_date': current_date,
            //     'search_tags': search_tags,
            //     'no_date_domain': no_date_domain,
            //     'no_country_domain': no_country_domain,
            // }
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _search_get_detail(self, website, order, options):
            // requires_sudo = False
            // with_description = options['displayDescription']
            // country_id = options.get('country_id')
            // department_id = options.get('department_id')
            // office_id = options.get('office_id')
            // contract_type_id = options.get('contract_type_id')
            // is_remote = options.get('is_remote')
            // is_other_department = options.get('is_other_department')
            // is_untyped = options.get('is_untyped')
            // 
            // domain = [website.website_domain()]
            // if country_id:
            //     domain.append([('address_id.country_id', '=', int(country_id))])
            //     requires_sudo = True
            // if department_id:
            //     domain.append([('department_id', '=', int(department_id))])
            // elif is_other_department:
            //     domain.append([('department_id', '=', None)])
            // if office_id:
            //     domain.append([('address_id', '=', int(office_id))])
            // elif is_remote:
            //     domain.append([('address_id', '=', None)])
            // if contract_type_id:
            //     domain.append([('contract_type_id', '=', int(contract_type_id))])
            // elif is_untyped:
            //     domain.append([('contract_type_id', '=', None)])
            // 
            // if requires_sudo and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate':  False},
            // }
            // if with_description:
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     mapping['description'] = {'name': 'description', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'hr.job',
            //     'requires_sudo': requires_sudo,
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-briefcase',
            // }
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
            // attrib_values = options.get('attrib_values')
            // if category:
            //     domains.append([('public_categ_ids', 'child_of', self.env['ir.http']._unslug(category)[1])])
            // if tags:
            //     if isinstance(tags, str):
            //         tags = tags.split(',')
            //     domains.append([('product_variant_ids.all_product_tag_ids', 'in', tags)])
            // if min_price:
            //     domains.append([('list_price', '>=', min_price)])
            // if max_price:
            //     domains.append([('list_price', '<=', max_price)])
            // if attrib_values:
            //     domains.extend(self._get_attrib_values_domain(attrib_values))
            // search_fields = ['name', 'default_code', 'product_variant_ids.default_code']
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
            // domain = [website.website_domain()]
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
            //     for tags in tags.grouped('group_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
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

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_finished(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise ValueError(_('Value should be True or False (not %s)'), value)
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_end', '<=', now)]
            // else:
            //     domain = [('date_end', '>', now)]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // assert operator in ('=', '!='), 'Unsupported operator'
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('active', '=', True)])
            // neg = ''
            // if (operator == '=' and not value) or (operator == '!=' and value):
            //     neg = 'not '
            // return [('id', neg + 'in', bom_tmpl_query.subselect('product_tmpl_id'))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // check_has_access = operator == '=' and value or operator == '!=' and not value
            // return [('id', 'in' if check_has_access else 'not in', self._search_is_member_channel_ids())]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member_invited(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // check_has_access = operator == '=' and value or operator == '!=' and not value
            // return [('id', 'in' if check_has_access else 'not in', self._search_is_member_channel_ids(invited=True))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py) ---
            // def _search_is_mondialrelay(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise UserError(_("Operation not supported"))
            // if not value:
            //     operator = '!=' if operator == '=' else '='
            // return [('product_id.default_code', operator, 'MR')]
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_ongoing(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise UserError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %s)', value))
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_begin', '<=', now), ('date_end', '>', now)]
            // else:
            //     domain = ['|', ('date_begin', '>', now), ('date_end', '<=', now)]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_participating(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_participating = operator == '=' and value or operator == '!=' and not value
            // 
            // return [('id', 'in' if check_is_participating else 'not in', self._fetch_is_participating_events().ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _search_is_subcontractor(self, operator, value):
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // subcontractor_ids = self.env['mrp.bom'].search(
            //     [('type', '=', 'subcontract')]).subcontractor_ids.ids
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // return [('id', search_operator, subcontractor_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_visible_on_website(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_visible_on_website = operator == '=' and value or operator == '!=' and not value
            // user = self.env.user
            // domain = [('is_participating', '=', True)]
            // 
            // if not user._is_public():
            //     domain = expression.OR([domain, [('website_visibility', 'in', ['public', 'logged_users'])]])
            // else:
            //     domain = expression.OR([domain, [('website_visibility', '=', 'public')]])
            // 
            // event_ids = self.env['event.event']._search(domain)
            // return [('id', 'in' if check_is_visible_on_website else 'not in', event_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _search_mention_suggestions(self, domain, limit, extra_domain=None):
            // domain_is_user = expression.AND([[('user_ids', '!=', False)], [('user_ids.active', '=', True)], domain])
            // priority_conditions = [
            //     expression.AND([domain_is_user, [('partner_share', '=', False)]]),  # Search partners that are internal users
            //     domain_is_user,  # Search partners that are users
            //     domain,  # Search partners that are not users
            // ]
            // if extra_domain:
            //     priority_conditions.append(extra_domain)
            // partners = self.env['res.partner']
            // for domain in priority_conditions:
            //     remaining_limit = limit - len(partners)
            //     if remaining_limit <= 0:
            //         break
            //     # We are using _search to avoid the default order that is
            //     # automatically added by the search method. "Order by" makes the query
            //     # really slow.
            //     query = self._search(expression.AND([[('id', 'not in', partners.ids)], domain]), limit=remaining_limit)
            //     partners |= self.browse(query)
            // return partners
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_partner_ids(self, operator, value):
            // if isinstance(value, int) and operator == 'in':
            //     value = [value]
            // return [(
            //     'channel_partner_ids', '=', self.env['slide.channel.partner'].sudo()._search(
            //         [('partner_id', operator, value),
            //          ('active', '=', True),
            //          ('member_status', '!=', 'invited')],
            //     )
            // )]
            */
            return default;
        }

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_date = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // if with_date:
            //     for event, data in zip(self, results_data):
            //         begin = self.env['ir.qweb.field.date'].record_to_html(event, 'date_begin', {})
            //         end = self.env['ir.qweb.field.date'].record_to_html(event, 'date_end', {})
            //         data['range'] = (
            //             Markup('{} <i class="fa fa-long-arrow-right"></i> {}').format(begin, end)
            //             if begin != end else begin
            //         )
            // return results_data
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
            //             {'categories': categ_ids, 'slug': self.env['ir.http']._slug}
            //         )
            // return results_data
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results_prices(self, mapping, combination_info):
            // if combination_info.get('prevent_zero_price_sale'):
            //     website = self.env['website'].get_current_website()
            //     return website.prevent_zero_price_sale_text, None
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
            // if combination_info['compare_list_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['compare_list_price'], monetary_options
            //     )
            // 
            // return price, list_price
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _search_slide_channel_completed_ids(self, operator, value):
            // cp_done = self.env['slide.channel.partner'].sudo().search([
            //     ('channel_id', operator, value),
            //     ('member_status', '=', 'completed')
            // ])
            // return [('id', 'in', cp_done.partner_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _search_slide_channel_ids(self, operator, value):
            // cp_enrolled = self.env['slide.channel.partner'].search([
            //     ('channel_id', operator, value),
            //     ('member_status', '!=', 'invited')
            // ])
            // return [('id', 'in', cp_enrolled.partner_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_standard_price(self, operator, value):
            // return [('product_variant_ids.standard_price', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SearchWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_website_published(self, operator, value):
            // if not isinstance(value, bool) or operator not in ('=', '!='):
            //     logger.warning('unsupported search on website_published: %s, %s', operator, value)
            //     return [()]
            // 
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     value = not value
            // 
            // current_website_id = self._context.get('website_id')
            // is_published = [('is_published', '=', value)]
            // if current_website_id:
            //     on_current_website = self.env['website'].website_domain(current_website_id)
            //     return (['!'] if value is False else []) + expression.AND([is_published, on_current_website])
            // else:  # should be in the backend, return things that are published anywhere
            //     return is_published
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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
            // user = self.env['res.users'].sudo().browse(SUPERUSER_ID)
            // if (self.env.user.has_group('project.group_project_milestone') or
            //         (self.env.user.has_group('base.group_public') and user.has_group('project.group_project_milestone'))
            // ):
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

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py) ---
            // def send_shipping(self, pickings):
            // ''' Send the package to the service provider
            // 
            // :param pickings: A recordset of pickings
            // :return list: A list of dictionaries (one per picking) containing of the form::
            //                  { 'exact_price': price,
            //                    'tracking_number': number }
            //                    # TODO missing labels per package
            //                    # TODO missing currency
            //                    # TODO missing success, error, warnings
            // '''
            // self.ensure_one()
            // if hasattr(self, '%s_send_shipping' % self.delivery_type):
            //     return getattr(self, '%s_send_shipping' % self.delivery_type)(pickings)
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event_booth']
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
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

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_barcode(self):
            // self._set_product_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _set_calendar_last_notif_ack(self):
            // partner = self.env['res.users'].browse(self.env.context.get('uid', self.env.uid)).partner_id
            // partner.write({'calendar_last_notif_ack': datetime.now()})
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_default_code(self):
            // self._set_product_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def set_open(self):
            // self.write({'website_published': False})
            // return super(Job, self).set_open()
            */
            return default;
        }

        public async Task<TEntity> SetPackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.product_variant_ids.packaging_ids = p.packaging_ids
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_post_date(self):
            // for blog_post in self:
            //     blog_post.published_date = blog_post.post_date
            //     if not blog_post.published_date:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> SetProductFixedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def _set_product_fixed_price(self):
            // for carrier in self:
            //     carrier.product_id.list_price = carrier.fixed_price
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_bottom(self):
            // max_sequence = self.sudo().search([], order='website_sequence DESC', limit=1)
            // self.website_sequence = max_sequence.website_sequence + 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_top(self):
            // min_sequence = self.sudo().search([], order='website_sequence ASC', limit=1)
            // self.website_sequence = min_sequence.website_sequence - 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_standard_price(self):
            // self._set_product_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_teaser(self):
            // for blog_post in self:
            //     if not blog_post.with_context(lang='en_US').teaser_manual:
            //         # By default, if no teaser is set in english, it will use the
            //         # first 200 characters of the content. We don't want to break
            //         # that when adding a manual teaser in a translation.
            //         # That's how the ORM work: when setting a translation value, if
            //         # there is no source value, the source will also receive the
            //         # translation value
            //         blog_post.update_field_translations('teaser_manual', {'en_US': ''})
            //     blog_post.teaser_manual = blog_post.teaser
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _set_tz_context(self):
            // self.ensure_one()
            // return self.with_context(tz=self.date_tz or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_volume(self):
            // self._set_product_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_weight(self):
            // self._set_product_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_cancel(self):
            // return self.write({'signup_type': None})
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_get_auth_param(self):
            // """ Get a signup token related to the partner if signup is enabled.
            //     If the partner already has a user, get the login parameter.
            // """
            // if not self.env.user._is_internal() and not self.env.is_admin():
            //     raise exceptions.AccessDenied()
            // 
            // res = defaultdict(dict)
            // 
            // allow_signup = self.env['res.users']._get_signup_invitation_scope() == 'b2c'
            // for partner in self:
            //     partner = partner.sudo()
            //     if allow_signup and not partner.user_ids:
            //         partner.signup_prepare()
            //         res[partner.id]['auth_signup_token'] = partner._generate_signup_token()
            //     elif partner.user_ids:
            //         res[partner.id]['auth_login'] = partner.user_ids[0].login
            // return res
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_prepare(self, signup_type="signup"):
            // """ generate a new token for the partners with the given validity, if necessary
            //     :param expiration: the expiration datetime of the token (string, optional)
            // """
            // self.write({'signup_type': signup_type})
            // return True
            */
            return default;
        }

        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _signup_retrieve_info(self, token):
            // """ retrieve the user info about the token
            //     :return: a dictionary with the user information if the token is valid, None otherwise:
            //         - 'db': the name of the database
            //         - 'token': the token, if token is valid
            //         - 'name': the name of the partner, if token is valid
            //         - 'login': the user login, if the user already exists
            //         - 'email': the partner email, if the user does not exist
            // """
            // partner = self._get_partner_from_token(token)
            // if not partner:
            //     return None
            // res = {'db': self.env.cr.dbname}
            // res['token'] = token
            // res['name'] = partner.name
            // if partner.user_ids:
            //     res['login'] = partner.user_ids[0].login
            // else:
            //     res['email'] = res['login'] = partner.email or ''
            // return res
            */
            return default;
        }

        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _signup_retrieve_partner(self, token, check_validity=False, raise_exception=False):
            // """ find the partner corresponding to a token, and possibly check its validity
            //     :param token: the token to resolve
            //     :param check_validity: if True, also check validity
            //     :param raise_exception: if True, raise exception instead of returning False
            //     :return: partner (browse record) or False (if raise_exception is False)
            // """
            // partner = self._get_partner_from_token(token)
            // if not partner:
            //     raise exceptions.UserError(_("Signup token '%s' is not valid or expired", token))
            // return partner
            */
            return default;
        }

        public async Task<TEntity> SimpleVatCheckAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def simple_vat_check(self, country_code, vat_number):
            // '''
            // Check the VAT number depending of the country.
            // http://sima-pc.com/nif.php
            // '''
            // if not country_code.encode().isalpha():
            //     return False
            // check_func_name = 'check_vat_' + country_code
            // check_func = getattr(self, check_func_name, None) or getattr(stdnum.util.get_cc_module(country_code, 'vat'), 'is_valid', None)
            // if not check_func:
            //     # No VAT validation available, default to check that the country code exists
            //     country_code = _eu_country_vat_inverse.get(country_code, country_code)
            //     return bool(self.env['res.country'].search([('code', '=ilike', country_code)]))
            // return check_func(vat_number)
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _split_menus_state_by_field(self):
            // """ For each field linked to a menu, get the set of events having this
            // menu activated and de-activated. Purpose is to find those whose value
            // changed and update the underlying menus.
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu currently set to True
            //   'deactivated': subset of self having its menu currently set to False
            // } """
            // menus_state_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     activated = self.filtered(lambda event: event[fname])
            //     menus_state_by_field[fname] = {
            //         'activated': activated,
            //         'deactivated': self - activated,
            //     }
            // return menus_state_by_field
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _split_vat(self, vat):
            // '''
            // Splits the VAT Number to get the country code in a first place and the code itself in a second place.
            // This has to be done because some countries' code are one character long instead of two (i.e. "T" for Japan)
            // '''
            // if len(vat) > 1 and vat[1].isalpha():
            //     vat_country, vat_number = vat[:2].lower(), vat[2:].replace(' ', '')
            // else:
            //     vat_country, vat_number = vat[:1].lower(), vat[1:].replace(' ', '')
            // return vat_country, vat_number
            */
            return default;
        }

        protected async Task<object> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, **kwargs):
            // """Override to add the current leave status."""
            // super()._to_store(store, fields=fields, **kwargs)
            // if fields is None:
            //     fields = ["out_of_office_date_end"]
            // for partner in self:
            //     if "out_of_office_date_end" in fields:
            //         # in the rare case of multi-user partner, return the earliest possible return date
            //         dates = partner.mapped("user_ids.leave_date_to")
            //         states = partner.mapped("user_ids.current_leave_state")
            //         date = sorted(dates)[0] if dates and all(dates) else False
            //         state = sorted(states)[0] if states and all(states) else False
            //         store.add(
            //             partner, {"out_of_office_date_end": date if state == "validate" else False}
            //         )
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, **kwargs):
            // """Override to add name when user_livechat_username is not set."""
            // super()._to_store(store, fields=fields, **kwargs)
            // if fields and "user_livechat_username" in fields:
            //     if partners := self.filtered(lambda p: not p.user_livechat_username):
            //         super(Partners, partners)._to_store(store, fields=["name"])
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, main_user_by_partner=None):
            // if fields is None:
            //     fields = ["active", "avatar_128", "email", "im_status", "is_company", "name", "user"]
            // if not self.env.user._is_internal() and "email" in fields:
            //     fields.remove("email")
            // for partner in self:
            //     data = partner._read_format(
            //         [
            //             field
            //             for field in fields
            //             if field
            //             not in [
            //                 "avatar_128",
            //                 "country",
            //                 "display_name",
            //                 "isAdmin",
            //                 "notification_type",
            //                 "signature",
            //                 "user",
            //             ]
            //         ],
            //         load=False,
            //     )[0]
            //     if "avatar_128" in fields:
            //         data["avatar_128_access_token"] = limited_field_access_token(partner, "avatar_128")
            //         data["write_date"] = partner.write_date
            //     if "country" in fields:
            //         c = partner.country_id
            //         data["country"] = {"code": c.code, "id": c.id, "name": c.name} if c else False
            //     if "display_name" in fields:
            //         data["displayName"] = partner.display_name
            //     if 'user' in fields:
            //         main_user = main_user_by_partner and main_user_by_partner.get(partner)
            //         if not main_user:
            //             users = partner.with_context(active_test=False).user_ids
            //             internal_users = users - users.filtered("share")
            //             main_user = (
            //                 internal_users[0]
            //                 if len(internal_users) > 0
            //                 else users[0] if len(users) > 0 else self.env["res.users"]
            //             )
            //         data['userId'] = main_user.id
            //         data["isInternalUser"] = not main_user.share if main_user else False
            //         if "isAdmin" in fields:
            //             data["isAdmin"] = main_user._is_admin()
            //         if "notification_type" in fields:
            //             data["notification_preference"] = main_user.notification_type
            //         if "signature" in fields:
            //             data["signature"] = main_user.signature
            //     store.add(partner, data)
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def toggle_active(self):
            // self.filtered('active').website_published = False
            // return super().toggle_active()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def toggle_active(self):
            // """ Archiving/unarchiving a channel does it on its slides, too.
            // 1. When archiving
            // We want to be archiving the channel FIRST.
            // So that when slides are archived and the recompute is triggered,
            // it does not try to mark the channel as "completed".
            // That happens because it counts slide_done / slide_total, but slide_total
            // will be 0 since all the slides for the course have been archived as well.
            // 
            // 2. When un-archiving
            // We want to archive the channel LAST.
            // So that when it recomputes stats for the channel and completion, it correctly
            // counts the slides_total by counting slides that are already un-archived. """
            // 
            // to_archive = self.filtered(lambda channel: channel.active)
            // to_activate = self.filtered(lambda channel: not channel.active)
            // if to_archive:
            //     super(Channel, to_archive).toggle_active()
            //     to_archive.is_published = False
            //     to_archive.mapped('slide_ids').action_archive()
            // if to_activate:
            //     to_activate.with_context(active_test=False).mapped('slide_ids').action_unarchive()
            //     super(Channel, to_activate).toggle_active()
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def toggle_booth_menu(self, val):
            // self.booth_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleDebugAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def toggle_debug(self):
            // for c in self:
            //     c.debug_logging = not c.debug_logging
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def toggle_exhibitor_menu(self, val):
            // self.exhibitor_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleProdEnvironmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py) ---
            // def toggle_prod_environment(self):
            // for c in self:
            //     c.prod_environment = not c.prod_environment
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def toggle_website_menu(self, val):
            // self.website_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track(self, val):
            // self.website_track = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track_proposal(self, val):
            // self.website_track_proposal = val
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if init_values.keys() & {'is_published', 'website_published'}:
            //     if self.is_published:
            //         return self.env.ref('website_event.mt_event_published', raise_if_not_found=False)
            //     return self.env.ref('website_event.mt_event_unpublished', raise_if_not_found=False)
            // return super(Event, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def unlink(self):
            // # When a website_controller_page is deleted, the ORM does not delete its
            // # ir_ui_view. So we got to delete it ourself, but only if the
            // # ir_ui_view is not used by another website_page.
            // views_to_delete = self.view_id.filtered(
            //     lambda v: v.controller_page_ids <= self and not v.inherit_children_ids
            // )
            // # Rebind self to avoid unlink already deleted records from `ondelete="cascade"`
            // self = self - views_to_delete.controller_page_ids
            // views_to_delete.unlink()
            // 
            // # Make sure website._get_menu_ids() will be recomputed
            // self.env.registry.clear_cache()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def unlink(self):
            // # When a website_page is deleted, the ORM does not delete its
            // # ir_ui_view. So we got to delete it ourself, but only if the
            // # ir_ui_view is not used by another website_page.
            // views_to_delete = self.view_id.filtered(
            //     lambda v: v.page_ids <= self and not v.inherit_children_ids
            // )
            // # Rebind self to avoid unlink already deleted records from `ondelete="cascade"`
            // self = self - views_to_delete.page_ids
            // views_to_delete.unlink()
            // 
            // # Make sure website._get_menu_ids() will be recomputed
            // self.env.registry.clear_cache()
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

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _unlink_except_master_data(self):
            // time_product = self.env.ref('sale_timesheet.time_product')
            // if time_product.product_tmpl_id in self:
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
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

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _unlink_except_user(self):
            // users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            // if not users:
            //     return  # no linked user, operation is allowed
            // if self.env['res.users'].sudo(False).has_access('write'):
            //     error_msg = _('You cannot delete contacts linked to an active user.\n'
            //                   'You should rather archive them after archiving their associated user.\n\n'
            //                   'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //     action_error = users._action_show()
            //     raise RedirectWarning(error_msg, action_error, _('Go to users'))
            // else:
            //     raise ValidationError(_('You cannot delete contacts linked to an active user.\n'
            //                             'Ask an administrator to archive their associated user first.\n\n'
            //                             'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _unlink_if_partner_in_account_move(self):
            // """
            // Prevent the deletion of a partner "Individual", child of a company if:
            // - partner in 'account.move'
            // - state: all states (draft and posted)
            // """
            // moves = self.sudo().env['account.move'].search_count([
            //     ('partner_id', 'in', self.ids),
            //     ('state', 'in', ['draft', 'posted']),
            // ])
            // if moves:
            //     raise UserError(_("The partner cannot be deleted because it is used in Accounting"))
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def update_address(self, vals):
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     return super().write(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _update_fields_values(self, fields):
            // """ Returns dict of write() values for synchronizing ``fields`` """
            // values = {}
            // for fname in fields:
            //     field = self._fields[fname]
            //     if field.type == 'many2one':
            //         values[fname] = self[fname].id
            //     elif field.type == 'one2many':
            //         raise AssertionError(_('One2Many fields cannot be synchronized as part of `commercial_fields` or `address fields`'))
            //     elif field.type == 'many2many':
            //         values[fname] = [Command.set(self[fname].ids)]
            //     else:
            //         values[fname] = self[fname]
            // return values
            */
            return default;
        }

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _update_peppol_state_per_company(self, vals=None):
            // partners = self.env['res.partner']
            // if vals is None:
            //     partners = self.filtered(lambda p: all([p.peppol_eas, p.peppol_endpoint, p.is_ubl_format, p.country_code in PEPPOL_LIST]))
            // elif {'peppol_eas', 'peppol_endpoint', 'invoice_edi_format'}.intersection(vals.keys()):
            //     partners = self.filtered(lambda p: p.country_code in PEPPOL_LIST)
            // 
            // all_companies = None
            // for partner in partners.sudo():
            //     if partner.company_id:
            //         partner.button_account_peppol_check_partner_endpoint(company=partner.company_id)
            //         continue
            // 
            //     if all_companies is None:
            //         all_companies = self.env['res.company'].sudo().search([])
            // 
            //     for company in all_companies:
            //         partner.button_account_peppol_check_partner_endpoint(company=company)
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menu_entry(self, fname_bool, fname_o2m, fmenu_type):
            // """ Generic method to create menu entries based on a flag on event. This
            // method is a bit obscure, but is due to preparation of adding new menus
            // entries and pages for event in a stable version, leading to some constraints
            // while developing.
            // 
            // :param fname_bool: field name (e.g. website_track)
            // :param fname_o2m: o2m linking towards website.event.menu matching the
            //   boolean fields (normally an entry of website.event.menu with type matching
            //   the boolean field name)
            // :param method_name: method returning menu entries information: url, sequence, ...
            // """
            // self.ensure_one()
            // new_menu = None
            // 
            // menu_data = [menu_info for menu_info in self._get_website_menu_entries()
            //              if menu_info[4] == fmenu_type]
            // if self[fname_bool] and not self[fname_o2m]:
            //     # menus not found but boolean True: get menus to create
            //     for name, url, xml_id, menu_sequence, menu_type in menu_data:
            //         new_menu = self._create_menu(menu_sequence, name, url, xml_id, menu_type)
            // elif not self[fname_bool]:
            //     # will cascade delete to the website.event.menu
            //     self[fname_o2m].mapped('menu_id').sudo().unlink()
            // 
            // return new_menu
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // """ Synchronize event configuration and its menu entries for frontend.
            // 
            // :param menus_update_by_field: see ``_get_menus_update_by_field``"""
            // for event in self:
            //     if event.menu_id and not event.website_menu:
            //         # do not rely on cascade, as it is done in SQL -> not calling override and
            //         # letting some ir.ui.views in DB
            //         (event.menu_id + event.menu_id.child_id).sudo().unlink()
            //     elif event.website_menu and not event.menu_id:
            //         root_menu = self.env['website.menu'].sudo().create({'name': event.name, 'website_id': event.website_id.id})
            //         event.menu_id = root_menu
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('community_menu')):
            //         event._update_website_menu_entry('community_menu', 'community_menu_ids', 'community')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('introduction_menu')):
            //         event._update_website_menu_entry('introduction_menu', 'introduction_menu_ids', 'introduction')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('location_menu')):
            //         event._update_website_menu_entry('location_menu', 'location_menu_ids', 'location')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('register_menu')):
            //         event._update_website_menu_entry('register_menu', 'register_menu_ids', 'register')
            */
            return default;
        }

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self.env.context.get('category_id'):
            //     return  _(
            //         'Partners: %(category)s',
            //         category=self.env['res.partner.category'].browse(self.env.context['category_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _website_show_quick_add(self):
            // self.ensure_one()
            // # TODO VFE pass website as param and avoid existence check
            // website = self.env['website'].get_current_website()
            // return self.sale_ok and (not website.prevent_zero_price_sale or self._get_contextual_price())
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // for rec in self:
            //     rec.menu_ids.write({
            //         "url": f"/model/{rec.name_slugified}",
            //         "name": rec.name,
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def write(self, vals):
            // for page in self:
            //     website_id = False
            //     if vals.get('website_id') or page.website_id:
            //         website_id = vals.get('website_id') or page.website_id.id
            // 
            //     # If URL has been edited, slug it
            //     if 'url' in vals:
            //         url = vals['url'] or ''
            //         url = '/' + self.env['ir.http']._slugify(url, max_length=1024, path=True)
            //         if page.url != url:
            //             url = self.env['website'].with_context(website_id=website_id).get_unique_path(url)
            //             page.menu_ids.write({'url': url})
            //             # Sync website's homepage URL
            //             website = self.env['website'].get_current_website()
            //             page_url_normalized = {'homepage_url': page.url}
            //             website._handle_homepage_url(page_url_normalized)
            //             if website.homepage_url == page_url_normalized['homepage_url']:
            //                 website.homepage_url = url
            //         vals['url'] = url
            // 
            //     # If name has changed, check for key uniqueness
            //     if 'name' in vals and page.name != vals['name']:
            //         vals['key'] = self.env['website'].with_context(website_id=website_id).get_unique_key(self.env['ir.http']._slugify(vals['name'] or ''))
            //     if 'visibility' in vals:
            //         if vals['visibility'] != 'restricted_group':
            //             vals['groups_id'] = False
            // self.env.registry.clear_cache()  # write on page == write on view that invalid cache
            // return super(Page, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def write(self, vals):
            // result = True
            // # archiving a blog post, unpublished the blog post
            // if 'active' in vals and not vals['active']:
            //     vals['is_published'] = False
            // for post in self:
            //     copy_vals = dict(vals)
            //     published_in_vals = set(vals.keys()) & {'is_published', 'website_published'}
            //     if (published_in_vals and 'published_date' not in vals and
            //             (not post.published_date or post.published_date <= fields.Datetime.now())):
            //         copy_vals['published_date'] = vals[list(published_in_vals)[0]] and fields.Datetime.now() or False
            //     result &= super(BlogPost, post).write(copy_vals)
            // self._check_for_publication(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def write(self, vals):
            // menus_state_by_field = self._split_menus_state_by_field()
            // res = super(Event, self).write(vals)
            // menus_update_by_field = self._get_menus_update_by_field(menus_state_by_field, force_update=vals.keys())
            // self._update_website_menus(menus_update_by_field=menus_update_by_field)
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def write(self, vals):
            // # Clear empty ecommerce description content to avoid side-effects on product pages
            // # when there is no content to display anyway.
            // if vals.get('description_ecommerce') and is_html_empty(vals['description_ecommerce']):
            //     vals['description_ecommerce'] = ''
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def write(self, vals):
            // # If description_short wasn't manually modified, there is an implicit link between this field and description.
            // if not is_html_empty(vals.get('description')) and is_html_empty(vals.get('description_short')) and self.description == self.description_short:
            //     vals['description_short'] = vals.get('description')
            // 
            // res = super(Channel, self).write(vals)
            // 
            // if vals.get('user_id'):
            //     self._action_add_members(self.env['res.users'].sudo().browse(vals['user_id']).partner_id)
            //     self.activity_reschedule(['website_slides.mail_activity_data_access_request'], new_user_id=vals.get('user_id'))
            // if 'enroll_group_ids' in vals:
            //     self._add_groups_members()
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }
    }
}