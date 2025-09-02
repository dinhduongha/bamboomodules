using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class TemplateResetMixinAppService : ApplicationService, ITemplateResetMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public TemplateResetMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCreateSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_create_sidebar_action(self):
            // ActWindow = self.env['ir.actions.act_window']
            // view = self.env.ref('sms.sms_composer_view_form')
            // 
            // for template in self:
            //     button_name = _('Send SMS (%s)', template.name)
            //     action = ActWindow.create({
            //         'name': button_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'sms.composer',
            //         # Add default_composition_mode to guess to determine if need to use mass or comment composer
            //         'context': "{'default_template_id' : %d, 'sms_composition_mode': 'guess', 'default_res_ids': active_ids, 'default_res_id': active_id}" % (template.id),
            //         'view_mode': 'form',
            //         'view_id': view.id,
            //         'target': 'new',
            //         'binding_model_id': template.model_id.id,
            //     })
            //     template.write({'sidebar_action_id': action.id})
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_unlink_sidebar_action(self):
            // for template in self:
            //     if template.sidebar_action_id:
            //         template.sidebar_action_id.unlink()
            // return True
            */
            return default;
        }

        public async Task<TEntity> CancelUnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def cancel_unlink(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_id': self.id,
            //     'res_model': self._name,
            //     'target': 'new',
            //     'context': {'dialog_size': 'large'},
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckAbstractModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _check_abstract_models(self, vals_list):
            // model_names = self.sudo().env['ir.model'].browse(filter(None, (
            //     vals.get('model_id') for vals in vals_list
            // ))).mapped('model')
            // for model in model_names:
            //     if self.env[model]._abstract:
            //         raise ValidationError(_('You may not define a template on an abstract model: %s', model))
            */
            return default;
        }

        public async Task<TEntity> ComputeCanWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_can_write(self):
            // writable_templates = self._filtered_access('write')
            // for template in self:
            //     template.can_write = template in writable_templates
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_is_template_editor(self):
            // self.is_template_editor = self.env.user.has_group('mail.group_mail_template_editor')
            */
            return default;
        }

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_render_model(self):
            // for template in self:
            //     template.render_model = template.model
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def _compute_render_model(self):
            // for template in self:
            //     template.render_model = template.model
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_template_category(self):
            // """ Base templates (or master templates) are active templates having
            // a description and an XML ID. User defined templates (no xml id),
            // templates without description or archived templates are not
            // base templates anymore. """
            // deactivated = self.filtered(lambda template: not template.active)
            // if deactivated:
            //     deactivated.template_category = 'hidden_template'
            // remaining = self - deactivated
            // if remaining:
            //     template_external_ids = remaining.get_external_id()
            //     for template in remaining:
            //         if bool(template_external_ids[template.id]) and template.description:
            //             template.template_category = 'base_template'
            //         elif bool(template_external_ids[template.id]):
            //             template.template_category = 'hidden_template'
            //         else:
            //             template.template_category = 'custom_template'
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", template.name)) for template, vals in zip(self, vals_list)]
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", template.name)) for template, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def create_action(self):
            // ActWindow = self.env['ir.actions.act_window']
            // view = self.env.ref('mail.email_compose_message_wizard_form')
            // for template in self:
            //     context = {
            //         'default_composition_mode': 'mass_mail',
            //         'default_model': template.model,
            //         'default_template_id' : template.id,
            //     }
            //     button_name = _('Send Mail (%s)', template.name)
            //     action = ActWindow.create({
            //         'name': button_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'mail.compose.message',
            //         'context': repr(context),
            //         'view_mode': 'form,list',
            //         'view_id': view.id,
            //         'target': 'new',
            //         'binding_model_id': template.model_id.id,
            //     })
            //     template.write({'ref_ir_act_window': action.id})
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def create(self, vals_list):
            // self._check_abstract_models(vals_list)
            // return super().create(vals_list)\
            //     ._fix_attachment_ownership()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if 'template_fs' not in vals and 'install_filename' in self.env.context:
            //         # we store the relative path to the resource instead of the absolute path, if found
            //         # (it will be missing e.g. when importing data-only modules using base_import_module)
            //         path_info = get_resource_from_path(self.env.context['install_filename'])
            //         if path_info:
            //             vals['template_fs'] = '/'.join(path_info[0:2])
            // return super().create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def default_get(self, fields):
            // res = super(MailTemplate, self).default_get(fields)
            // if res.get('model'):
            //     res['model_id'] = self.env['ir.model']._get(res.pop('model')).id
            // return res
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def default_get(self, fields):
            // res = super().default_get(fields)
            // if 'model_id' in fields and not res.get('model_id') and res.get('model'):
            //     res['model_id'] = self.env['ir.model']._get(res['model']).id
            // return res
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _fix_attachment_ownership(self):
            // for record in self:
            //     record.attachment_ids.write({'res_model': record._name, 'res_id': record.id})
            // return self
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_attachments(self, res_ids, render_fields,
            //                                render_results=None):
            // """ Render attachments of template 'self', returning values for records
            // given by 'res_ids'. Note that ``report_template_ids`` returns values for
            // 'attachments', as we have a list of tuple (report_name, base64 value)
            // for those reports. It is considered as being the job of callers to
            // transform those attachments into valid ``ir.attachment`` records.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template which
            //   are specific to attachments, e.g. attachment_ids or report_template_ids;
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // # generating reports is done on a per-record basis, better ensure cache
            // # is filled up to avoid rendering and browsing in a loop
            // if res_ids and 'report_template_ids' in render_fields and self.report_template_ids:
            //     self.env[self.model].browse(res_ids)
            // 
            // for res_id in res_ids:
            //     values = render_results.setdefault(res_id, {})
            // 
            //     # link template attachments directly
            //     if 'attachment_ids' in render_fields:
            //         values['attachment_ids'] = self.attachment_ids.ids
            // 
            //     # generate attachments (reports)
            //     if 'report_template_ids' in render_fields and self.report_template_ids:
            //         for report in self.report_template_ids:
            //             # generate content
            //             if report.report_type in ['qweb-html', 'qweb-pdf']:
            //                 report_content, report_format = self.env['ir.actions.report']._render_qweb_pdf(report, [res_id])
            //             else:
            //                 render_res = self.env['ir.actions.report']._render(report, [res_id])
            //                 if not render_res:
            //                     raise UserError(_('Unsupported report type %s found.', report.report_type))
            //                 report_content, report_format = render_res
            //             report_content = base64.b64encode(report_content)
            //             # generate name
            //             if report.print_report_name:
            //                 report_name = safe_eval(
            //                     report.print_report_name,
            //                     {
            //                         'object': self.env[self.model].browse(res_id),
            //                         'time': time,
            //                     }
            //                 )
            //             else:
            //                 report_name = _('Report')
            //             extension = "." + report_format
            //             if not report_name.endswith(extension):
            //                 report_name += extension
            //             values.setdefault('attachments', []).append((report_name, report_content))
            //     elif 'report_template_ids' in render_fields:
            //         values['attachments'] = []
            // 
            // # hook for attachments-specific computation, used currently only for accounting
            // if hasattr(self.env[self.model], '_process_attachments_for_template_post'):
            //     records_attachments = self.env[self.model].browse(res_ids)._process_attachments_for_template_post(self)
            //     for res_id, additional_attachments in records_attachments.items():
            //         if not additional_attachments:
            //             continue
            //         if additional_attachments.get('attachment_ids'):
            //             render_results[res_id].setdefault('attachment_ids', []).extend(additional_attachments['attachment_ids'])
            //         if additional_attachments.get('attachments'):
            //             render_results[res_id].setdefault('attachments', []).extend(additional_attachments['attachments'])
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template(self, res_ids, render_fields,
            //                    find_or_create_partners=False):
            // """ Render values from template 'self' on records given by 'res_ids'.
            // Those values are generally used to create a mail.mail or a mail.message.
            // Model of records is the one defined on template.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template;
            // :param boolean find_or_create_partners: transform emails into partners
            //   (see ``_generate_template_recipients``);
            // 
            // :returns: a dict of (res_ids, values) where values contains all rendered
            //   fields asked in ``render_fields``. Asking for attachments adds an
            //   'attachments' key using the format [(report_name, data)] where data
            //   is base64 encoded. Asking for recipients adds a 'partner_ids' key.
            //   Note that 2many fields contain a list of IDs, not commands.
            // """
            // self.ensure_one()
            // render_fields_set = set(render_fields)
            // fields_specific = {
            //     'attachment_ids',  # attachments
            //     'email_cc',  # recipients
            //     'email_to',  # recipients
            //     'partner_to',  # recipients
            //     'report_template_ids',  # attachments
            //     'scheduled_date',  # specific
            //     # not rendered (static)
            //     'auto_delete',
            //     'email_layout_xmlid',
            //     'mail_server_id',
            //     'model',
            //     'res_id',
            // }
            // 
            // render_results = {}
            // for _lang, (template, template_res_ids) in self._classify_per_lang(res_ids).items():
            //     # render fields not rendered by sub methods
            //     fields_torender = {
            //         field for field in render_fields_set
            //         if field not in fields_specific
            //     }
            //     for field in fields_torender:
            //         generated_field_values = template._render_field(
            //             field, template_res_ids
            //         )
            //         for res_id, field_value in generated_field_values.items():
            //             render_results.setdefault(res_id, {})[field] = field_value
            // 
            //     # render recipients
            //     if render_fields_set & {'email_cc', 'email_to', 'partner_to'}:
            //         template._generate_template_recipients(
            //             template_res_ids, render_fields_set,
            //             render_results=render_results,
            //             find_or_create_partners=find_or_create_partners
            //         )
            // 
            //     # render scheduled_date
            //     if 'scheduled_date' in render_fields_set:
            //         template._generate_template_scheduled_date(
            //             template_res_ids,
            //             render_results=render_results
            //     )
            // 
            //     # add values static for all res_ids
            //     template._generate_template_static_values(
            //         template_res_ids,
            //         render_fields_set,
            //         render_results=render_results
            //     )
            // 
            //     # generate attachments if requested
            //     if render_fields_set & {'attachment_ids', 'report_template_ids'}:
            //         template._generate_template_attachments(
            //             template_res_ids,
            //             render_fields_set,
            //             render_results=render_results
            //         )
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_recipients(self, res_ids, render_fields,
            //                               find_or_create_partners=False,
            //                               render_results=None):
            // """ Render recipients of the template 'self', returning values for records
            // given by 'res_ids'. Default values can be generated instead of the template
            // values if requested by template (see 'use_default_to' field). Email fields
            // ('email_cc', 'email_to') are transformed into partners if requested
            // (finding or creating partners). 'partner_to' field is transformed into
            // 'partner_ids' field.
            // 
            // Note: for performance reason, information from records are transferred to
            // created partners no matter the company. For example, if we have a record of
            // company A and one of B with the same email and no related partner, a partner
            // will be created with company A or B but populated with information from the 2
            // records. So some info might be leaked from one company to the other through
            // the partner.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template which
            //   are specific to recipients, e.g. email_cc, email_to, partner_to);
            // :param boolean find_or_create_partners: transform emails into partners
            //   (calling ``find_or_create`` on partner model);
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results. It holds a 'partner_ids' key
            //   holding partners given by ``_message_get_default_recipients`` and/or
            //   generated based on 'partner_to'. If ``find_or_create_partners`` is
            //   False emails are present, otherwise they are included as partners
            //   contained in ``partner_ids``.
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // ModelSudo = self.env[self.model].with_prefetch(res_ids).sudo()
            // 
            // # if using default recipients -> ``_message_get_default_recipients`` gives
            // # values for email_to, email_cc and partner_ids
            // if self.use_default_to and self.model:
            //     default_recipients = ModelSudo.browse(res_ids)._message_get_default_recipients()
            //     for res_id, recipients in default_recipients.items():
            //         render_results.setdefault(res_id, {}).update(recipients)
            // # render fields dynamically which generates recipients
            // else:
            //     for field in set(render_fields) & {'email_cc', 'email_to', 'partner_to'}:
            //         generated_field_values = self._render_field(field, res_ids)
            //         for res_id in res_ids:
            //             render_results.setdefault(res_id, {})[field] = generated_field_values[res_id]
            // 
            // # create partners from emails if asked to
            // if find_or_create_partners:
            //     res_id_to_company = {}
            //     if self.model and 'company_id' in ModelSudo._fields:
            //         for read_record in ModelSudo.browse(res_ids).read(['company_id']):
            //             company_id = read_record['company_id'][0] if read_record['company_id'] else False
            //             res_id_to_company[read_record['id']] = company_id
            // 
            //     all_emails = []
            //     email_to_res_ids = {}
            //     email_to_company = {}
            //     for res_id in res_ids:
            //         record_values = render_results.setdefault(res_id, {})
            //         mails = tools.email_split(record_values.pop('email_to', '')) + \
            //                 tools.email_split(record_values.pop('email_cc', ''))
            //         all_emails += mails
            //         record_company = res_id_to_company.get(res_id)
            //         for mail in mails:
            //             email_to_res_ids.setdefault(mail, []).append(res_id)
            //             if record_company:
            //                 email_to_company[mail] = record_company
            // 
            //     if all_emails:
            //         customers_information = ModelSudo.browse(res_ids)._get_customer_information()
            //         partners = self.env['res.partner']._find_or_create_from_emails(
            //             all_emails,
            //             additional_values={
            //                 email: {
            //                     'company_id': email_to_company.get(email),
            //                     **customers_information.get(email, {}),
            //                 }
            //                 for email in itertools.chain(all_emails, [False])
            //             })
            //         for original_email, partner in zip(all_emails, partners):
            //             if not partner:
            //                 continue
            //             for res_id in email_to_res_ids[original_email]:
            //                 render_results[res_id].setdefault('partner_ids', []).append(partner.id)
            // 
            // # update 'partner_to' rendered value to 'partner_ids'
            // all_partner_to = {
            //     pid
            //     for record_values in render_results.values()
            //     for pid in self._parse_partner_to(record_values.get('partner_to', ''))
            // }
            // existing_pids = set()
            // if all_partner_to:
            //     existing_pids = set(self.env['res.partner'].sudo().browse(list(all_partner_to)).exists().ids)
            // for res_id, record_values in render_results.items():
            //     partner_to = record_values.pop('partner_to', '')
            //     if partner_to:
            //         tpl_partner_ids = set(self._parse_partner_to(partner_to)) & existing_pids
            //         record_values.setdefault('partner_ids', []).extend(tpl_partner_ids)
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_scheduled_date(self, res_ids, render_results=None):
            // """ Render scheduled date based on template 'self'. Specific parsing is
            // done to ensure value matches ORM expected value: UTC but without
            // timezone set in value.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // scheduled_dates = self._render_field('scheduled_date', res_ids)
            // for res_id in res_ids:
            //     scheduled_date = self._process_scheduled_date(scheduled_dates.get(res_id))
            //     render_results.setdefault(res_id, {})['scheduled_date'] = scheduled_date
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateStaticValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_static_values(self, res_ids, render_fields, render_results=None):
            // """ Return values based on template 'self'. Those are not rendered nor
            // dynamic, just static values used for configuration of emails.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render, currently limited
            //   to a subset (i.e. auto_delete, mail_server_id, model, res_id);
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // for res_id in res_ids:
            //     values = render_results.setdefault(res_id, {})
            // 
            //     # technical settings
            //     if 'auto_delete' in render_fields:
            //         values['auto_delete'] = self.auto_delete
            //     if 'email_layout_xmlid' in render_fields:
            //         values['email_layout_xmlid'] = self.email_layout_xmlid
            //     if 'mail_server_id' in render_fields:
            //         values['mail_server_id'] = self.mail_server_id.id
            //     if 'model' in render_fields:
            //         values['model'] = self.model
            //     if 'res_id' in render_fields:
            //         values['res_id'] = res_id or False
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py) ---
            // def _load_records_write(self, values):
            // # OVERRIDE to make the fields blank that are not present in xml record
            // if self.env.context.get('reset_template'):
            //     # We don't want to change anything for magic columns, values present in XML record, and 'template_fs'
            //     fields_in_xml_record = values.keys()
            //     fields_not_to_touch = set(models.MAGIC_COLUMNS) | fields_in_xml_record | {'template_fs'}
            //     fields_to_empty = self._fields.keys() - fields_not_to_touch
            //     # For the fields not defined in xml record, if they have default values, we should not
            //     # enforce empty values for them and the default values should be kept
            //     field_defaults = self.default_get(list(fields_to_empty))
            //     # Update the values to be written and include the default values, prevent fields with
            //     # default values from being empty
            //     values.update(field_defaults)
            //     fields_to_empty = fields_to_empty - set(field_defaults.keys())
            //     # Finally, update the values with fields that should be empty
            //     values.update(dict.fromkeys(fields_to_empty, False))
            // return super()._load_records_write(values)
            */
            return default;
        }

        public async Task<TEntity> OpenDeleteConfirmationModalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def open_delete_confirmation_modal(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_id': self.id,
            //     'res_model': self._name,
            //     'target': 'new',
            //     'view_id': self.env.ref('mail.mail_template_view_form_confirm_delete').id,
            //     'context': {'dialog_size': 'medium'},
            //     'name': _('Confirmation'),
            // }
            */
            return default;
        }

        public async Task<TEntity> OverrideTranslationTermInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module_name, List<Guid> xml_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py) ---
            // def _override_translation_term(self, module_name, xml_ids):
            // translation_importer = TranslationImporter(self.env.cr)
            // 
            // for lang, _ in self.env['res.lang'].get_installed():
            //     for po_path in get_po_paths(module_name, lang):
            //         translation_importer.load_file(po_path, lang, xmlids=xml_ids)
            // 
            // translation_importer.save(overwrite=True, force_overwrite=True)
            */
            return default;
        }

        protected async Task<object> ParsePartnerToInternalAsync(object partner_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _parse_partner_to(cls, partner_to):
            // try:
            //     partner_to = literal_eval(partner_to or '[]')
            // except (ValueError, SyntaxError):
            //     partner_to = partner_to.split(',')
            // if not isinstance(partner_to, (list, tuple)):
            //     partner_to = [partner_to]
            // return [
            //     int(pid.strip()) if isinstance(pid, str) else int(pid) for pid in partner_to
            //     if (isinstance(pid, str) and pid.strip().isdigit()) or (pid and not isinstance(pid, str))
            // ]
            */
            return default;
        }

        public async Task<TEntity> ResetTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: template_reset_mixin.py) ---
            // def reset_template(self):
            // """Resets the Template with values given in source file. We ignore the case of
            // template being overridden in another modules because it is extremely less likely
            // to happen. This method also tries to reset the translation terms for the current
            // user lang (all langs are not supported due to costly file operation). """
            // expr = "//*[local-name() = $tag and (@id = $xml_id or @id = $external_id)]"
            // templates_with_missing_source = []
            // lang_false = {code: False for code, _ in self.env['res.lang'].get_installed() if code != 'en_US'}
            // for template in self.filtered('template_fs'):
            //     external_id = template.get_external_id().get(template.id)
            //     module, xml_id = external_id.split('.')
            //     fullpath = file_path(template.template_fs)
            //     if fullpath:
            //         for field_name, field in template._fields.items():
            //             if field.translate is True:
            //                 template.update_field_translations(field_name, lang_false)
            //         doc = etree.parse(fullpath)
            //         for rec in doc.xpath(expr, tag='record', xml_id=xml_id, external_id=external_id):
            //             # We don't have a way to pass context while loading record from a file, so we use this hack
            //             # to pass the context key that is needed to reset the fields not available in data file
            //             rec.set('context', json.dumps({'reset_template': 'True'}))
            //             obj = xml_import(template.env, module, {}, mode='init', xml_filename=fullpath)
            //             obj._tag_record(rec)
            //             template._override_translation_term(module, [xml_id, external_id])
            //     else:
            //         templates_with_missing_source.append(template.display_name)
            // if templates_with_missing_source:
            //     raise UserError(_("The following email templates could not be reset because their related source files could not be found:\n- %s", "\n- ".join(templates_with_missing_source)))
            #endif
            return default;
        }

        public async Task<TEntity> SearchTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _search_template_category(self, operator, value):
            // if operator not in ['in', 'not in', '=', '!=']:
            //     raise NotImplementedError(_('Operation not supported'))
            // 
            // value = [value] if isinstance(value, str) else value
            // operator = 'in' if operator in ("in", "=") else 'not in'
            // 
            // templates_with_xmlid = self.env['ir.model.data'].sudo()._search([
            //     ('model', '=', 'mail.template'),
            //     ('module', '!=', '__export__')
            // ]).subselect('res_id')
            // 
            // domain = []
            // if 'hidden_template' in value:
            //     domain.append(['|', ('active', '=', False), '&', ('description', '=', False), ('id', 'in', templates_with_xmlid)])
            // 
            // if 'base_template' in value:
            //     domain.append(['&', ('description', '!=', False), ('id', 'in', templates_with_xmlid)])
            // 
            // if 'custom_template' in value:
            //     domain.append([('template_category', 'not in', ['base_template', 'hidden_template'])])
            // 
            // if operator == 'not in':
            //     for dom in domain:
            //         dom.insert(0, "!")
            // 
            // if len(domain) > 1:
            //     domain = (expression.OR if operator == 'in' else expression.AND)(domain)
            // else:
            //     domain = domain[0]
            // 
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SendCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _send_check_access(self, res_ids):
            // records = self.env[self.model].browse(res_ids)
            // records.check_access('read')
            */
            return default;
        }

        public async Task<TEntity> SendMailAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def send_mail(self, res_id, force_send=False, raise_exception=False, email_values=None,
            //           email_layout_xmlid=False):
            // """ Generates a new mail.mail. Template is rendered on record given by
            // res_id and model coming from template.
            // 
            // :param int res_id: id of the record to render the template
            // :param bool force_send: send email immediately; otherwise use the mail
            //     queue (recommended);
            // :param dict email_values: update generated mail with those values to further
            //     customize the mail;
            // :param str email_layout_xmlid: optional notification layout to encapsulate the
            //     generated email;
            // :returns: id of the mail.mail that was created """
            // 
            // # Grant access to send_mail only if access to related document
            // self.ensure_one()
            // return self.send_mail_batch(
            //     [res_id],
            //     force_send=force_send,
            //     raise_exception=raise_exception,
            //     email_values=email_values,
            //     email_layout_xmlid=email_layout_xmlid
            // )[0].id
            */
            return default;
        }

        public async Task<TEntity> SendMailBatchAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def send_mail_batch(self, res_ids, force_send=False, raise_exception=False, email_values=None,
            //           email_layout_xmlid=False):
            // """ Generates new mail.mails. Batch version of 'send_mail'.'
            // 
            // :param list res_ids: IDs of modelrecords on which template will be rendered
            // 
            // :returns: newly created mail.mail
            // """
            // # Grant access to send_mail only if access to related document
            // self.ensure_one()
            // self._send_check_access(res_ids)
            // sending_email_layout_xmlid = email_layout_xmlid or self.email_layout_xmlid
            // 
            // mails_sudo = self.env['mail.mail'].sudo()
            // batch_size = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.batch_size')
            // ) or 50  # be sure to not have 0, as otherwise no iteration is done
            // RecordModel = self.env[self.model].with_prefetch(res_ids)
            // record_ir_model = self.env['ir.model']._get(self.model)
            // 
            // for res_ids_chunk in tools.split_every(batch_size, res_ids):
            //     res_ids_values = self._generate_template(
            //         res_ids_chunk,
            //         ('attachment_ids',
            //          'auto_delete',
            //          'body_html',
            //          'email_cc',
            //          'email_from',
            //          'email_to',
            //          'mail_server_id',
            //          'model',
            //          'partner_to',
            //          'reply_to',
            //          'report_template_ids',
            //          'res_id',
            //          'scheduled_date',
            //          'subject',
            //         )
            //     )
            //     values_list = [res_ids_values[res_id] for res_id in res_ids_chunk]
            // 
            //     # get record in batch to use the prefetch
            //     records = RecordModel.browse(res_ids_chunk)
            //     attachments_list = []
            // 
            //     # lang and company is used for rendering layout
            //     res_ids_langs, res_ids_companies = {}, {}
            //     if sending_email_layout_xmlid:
            //         if self.lang:
            //             res_ids_langs = self._render_lang(res_ids_chunk)
            //         res_ids_companies = records._mail_get_companies(default=self.env.company)
            // 
            //     for record in records:
            //         values = res_ids_values[record.id]
            //         values['recipient_ids'] = [(4, pid) for pid in (values.get('partner_ids') or [])]
            //         values['attachment_ids'] = [(4, aid) for aid in (values.get('attachment_ids') or [])]
            //         values.update(email_values or {})
            // 
            //         # delegate attachments after creation due to ACL check
            //         attachments_list.append(values.pop('attachments', []))
            // 
            //         # add a protection against void email_from
            //         if 'email_from' in values and not values.get('email_from'):
            //             values.pop('email_from')
            // 
            //         # encapsulate body
            //         if not sending_email_layout_xmlid:
            //             values['body'] = values['body_html']
            //             continue
            // 
            //         lang = res_ids_langs.get(record.id) or False
            //         company = res_ids_companies.get(record.id) or self.env.company
            //         model_lang = record_ir_model.with_context(lang=lang) if lang else record_ir_model
            // 
            //         template_ctx = {
            //             # message
            //             'message': self.env['mail.message'].sudo().new(dict(body=values['body_html'], record_name=record.display_name)),
            //             'subtype': self.env['mail.message.subtype'].sudo(),
            //             # record
            //             'model_description': model_lang.display_name,
            //             'record': record,
            //             'record_name': False,
            //             'subtitles': False,
            //             # user / environment
            //             'company': company,
            //             'email_add_signature': False,
            //             'signature': '',
            //             'website_url': '',
            //             # tools
            //             'is_html_empty': is_html_empty,
            //         }
            //         body = model_lang.env['ir.qweb']._render(sending_email_layout_xmlid, template_ctx, minimal_qcontext=True, raise_if_not_found=False)
            //         if not body:
            //             _logger.warning(
            //                 'QWeb template %s not found when sending template %s. Sending without layout.',
            //                 sending_email_layout_xmlid,
            //                 self.name,
            //             )
            //             body = values['body_html']
            // 
            //         values['body_html'] = self.env['mail.render.mixin']._replace_local_links(body)
            //         values['body'] = values['body_html']
            // 
            //     mails = self.env['mail.mail'].sudo().create(values_list)
            // 
            //     # manage attachments
            //     for mail, attachments in zip(mails, attachments_list):
            //         if attachments:
            //             attachments_values = [
            //                 (0, 0, {
            //                     'name': name,
            //                     'datas': datas,
            //                     'type': 'binary',
            //                     'res_model': 'mail.message',
            //                     'res_id': mail.mail_message_id.id,
            //                 })
            //                 for (name, datas) in attachments
            //             ]
            //             mail.with_context(default_type=None).write({'attachment_ids': attachments_values})
            // 
            //     mails_sudo += mails
            // 
            // if force_send:
            //     mails_sudo.send(raise_exception=raise_exception)
            // return mails_sudo
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def unlink_action(self):
            // for template in self:
            //     if template.ref_ir_act_window:
            //         template.ref_ir_act_window.unlink()
            // return True
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def unlink(self):
            // self.unlink_action()
            // return super(MailTemplate, self).unlink()
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def unlink(self):
            // self.sudo().mapped('sidebar_action_id').unlink()
            // return super(SMSTemplate, self).unlink()
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ITemplateResetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def write(self, vals):
            // self._check_abstract_models([vals])
            // super().write(vals)
            // self._fix_attachment_ownership()
            // return True
            */
            return default;
        }
    }
}