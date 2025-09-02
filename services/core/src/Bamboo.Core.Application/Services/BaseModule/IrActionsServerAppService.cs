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
    [Module("BaseModule")]
    public class IrActionsServerAppService : GenericApplicationService<IrActServer>, IIrActionsServerAppService
    {
        private readonly IIrActionsActionsAppService _irActionsActionsAppService;
        public IrActionsServerAppService(IRepository<IrActServer, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IIrActionsActionsAppService irActionsActionsAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _irActionsActionsAppService = irActionsActionsAppService;
        }

        protected async Task<IrActServer> CheckActivityDateDeadlineRangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _check_activity_date_deadline_range(self):
            // if any(action.activity_date_deadline_range < 0 for action in self):
            //     raise ValidationError(_("The 'Due Date In' value can't be negative."))
            */
            return default;
        }

        protected async Task<IrActServer> CheckChildRecursionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_child_recursion(self):
            // if self._has_cycle('child_ids'):
            //     raise ValidationError(_('Recursion found in child server actions'))
            */
            return default;
        }

        protected async Task<IrActServer> CheckMailModelCoherencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _check_mail_model_coherency(self):
            // for action in self:
            //     if action.state in {'mail_post', 'followers', 'remove_followers', 'next_activity'} and action.model_id.transient:
            //         raise ValidationError(_("This action cannot be done on transient models."))
            //     if (
            //         (action.state in {"followers", "remove_followers"}
            //         or (action.state == "mail_post" and action.mail_post_method != "email"))
            //         and not action.model_id.is_mail_thread
            //     ):
            //         raise ValidationError(_("This action can only be done on a mail thread models"))
            //     if action.state == 'next_activity' and not action.model_id.is_mail_activity:
            //         raise ValidationError(_("A next activity can only be planned on models that use activities."))
            */
            return default;
        }

        protected async Task<IrActServer> CheckMailTemplateModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _check_mail_template_model(self):
            // for action in self.filtered(lambda action: action.state == 'mail_post'):
            //     if action.template_id and action.template_id.model_id != action.model_id:
            //         raise ValidationError(
            //             _('Mail template model of %(action_name)s does not match action model.',
            //               action_name=action.name
            //              )
            //         )
            */
            return default;
        }

        protected async Task<IrActServer> CheckModelCoherencyWithAutomationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _check_model_coherency_with_automation(self):
            // for action in self.filtered('base_automation_id'):
            //     if action.model_id != action.base_automation_id.model_id:
            //         raise exceptions.ValidationError(
            //             _("Model of action %(action_name)s should match the one from automated rule %(rule_name)s.",
            //               action_name=action.name,
            //               rule_name=action.base_automation_id.name
            //              )
            //         )
            */
            return default;
        }

        protected async Task<IrActServer> CheckPythonCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_python_code(self):
            // for action in self.sudo().filtered('code'):
            //     msg = test_python_expr(expr=action.code.strip(), mode="exec")
            //     if msg:
            //         raise ValidationError(msg)
            */
            return default;
        }

        protected async Task<IrActServer> CheckSmsModelCoherencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _check_sms_model_coherency(self):
            // for action in self:
            //     if action.state == 'sms' and (action.model_id.transient or not action.model_id.is_mail_thread):
            //         raise ValidationError(_("Sending SMS can only be done on a not transient mail.thread model"))
            */
            return default;
        }

        protected async Task<IrActServer> CheckSmsTemplateModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _check_sms_template_model(self):
            // for action in self.filtered(lambda action: action.state == 'sms'):
            //     if action.sms_template_id and action.sms_template_id.model_id != action.model_id:
            //         raise ValidationError(
            //             _('SMS template model of %(action_name)s does not match action model.',
            //               action_name=action.name
            //              )
            //         )
            */
            return default;
        }

        protected async Task<IrActServer> CheckWebhookFieldIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_webhook_field_ids(self):
            // """Check that the selected fields don't have group restrictions"""
            // restricted_fields = dict()
            // for action in self:
            //     Model = self.env[action.model_id.model]
            //     for model_field in action.webhook_field_ids:
            //         # you might think that the ir.model.field record holds references
            //         # to the groups, but that's not the case - we need to field object itself
            //         field = Model._fields[model_field.name]
            //         if field.groups:
            //             restricted_fields.setdefault(action.name, []).append(model_field.field_description)
            // if restricted_fields:
            //     restricted_field_per_action = "\n".join([f"{action}: {', '.join(f for f in fields)}" for action, fields in restricted_fields.items()])
            //     raise ValidationError(_("Group-restricted fields cannot be included in "
            //                             "webhook payloads, as it could allow any user to "
            //                             "accidentally leak sensitive information. You will "
            //                             "have to remove the following fields from the webhook payload "
            //                             "in the following actions:\n %s", restricted_field_per_action))
            */
            return default;
        }

        protected async Task<IrActServer> ComputeActivityInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_activity_info(self):
            // to_reset = self.filtered(lambda act: act.state != 'next_activity')
            // if to_reset:
            //     to_reset.activity_summary = False
            //     to_reset.activity_note = False
            //     to_reset.activity_date_deadline_range = False
            //     to_reset.activity_date_deadline_range_type = False
            //     to_reset.activity_user_type = False
            //     to_reset.activity_user_id = False
            //     to_reset.activity_user_field_name = False
            // to_default = self.filtered(lambda act: act.state == 'next_activity')
            // for action in to_default:
            //     if not action.activity_summary:
            //         action.activity_summary = action.activity_type_id.summary
            //     if not action.activity_date_deadline_range_type:
            //         action.activity_date_deadline_range_type = 'days'
            //     if not action.activity_user_type:
            //         action.activity_user_type = 'specific'
            //     if not action.activity_user_field_name:
            //         action.activity_user_field_name = 'user_id'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeActivityTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_activity_type_id(self):
            // to_reset = self.filtered(
            //     lambda act: act.state != 'next_activity' or \
            //                 (act.model_id.model != act.activity_type_id.res_model)
            // )
            // if to_reset:
            //     to_reset.activity_type_id = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeAvailableModelIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _compute_available_model_ids(self):
            // """ Stricter model limit: based on automation rule """
            // super()._compute_available_model_ids()
            // rule_based = self.filtered(lambda action: action.usage == 'base_automation')
            // for action in rule_based:
            //     rule_model = action.base_automation_id.model_id
            //     action.available_model_ids = rule_model.ids if rule_model in action.available_model_ids else []
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_available_model_ids(self):
            // mail_thread_based = self.filtered(
            //     lambda action: action.state in {'mail_post', 'followers', 'remove_followers', 'next_activity'}
            // )
            // if mail_thread_based:
            //     mail_models = self.env['ir.model'].search([('is_mail_thread', '=', True), ('transient', '=', False)])
            //     for action in mail_thread_based:
            //         action.available_model_ids = mail_models.ids
            // super(ServerActions, self - mail_thread_based)._compute_available_model_ids()
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _compute_available_model_ids(self):
            // mail_thread_based = self.filtered(lambda action: action.state == 'sms')
            // if mail_thread_based:
            //     mail_models = self.env['ir.model'].search([('is_mail_thread', '=', True), ('transient', '=', False)])
            //     for action in mail_thread_based:
            //         action.available_model_ids = mail_models.ids
            // super(ServerActions, self - mail_thread_based)._compute_available_model_ids()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_available_model_ids(self):
            // allowed_models = self.env['ir.model'].search(
            //     [('model', 'in', list(self.env['ir.model.access']._get_allowed_models()))]
            // )
            // self.available_model_ids = allowed_models.ids
            */
            return default;
        }

        protected async Task<IrActServer> ComputeCrudRelationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_crud_relations(self):
            // """ Compute the crud_model_id and update_field_id fields.
            // 
            // The crud_model_id is the model on which the action will create or update
            // records. In the case of record creation, it is the same as the main model
            // of the action. For record update, it will be the model linked to the last
            // field in the update_path.
            // This is only used for object_create and object_write actions.
            // The update_field_id is the field at the end of the update_path that will
            // be updated by the action - only used for object_write actions.
            // """
            // for action in self:
            //     if action.model_id and action.state in ('object_write', 'object_create'):
            //         if action.state == 'object_create':
            //             action.crud_model_id = action.model_id
            //             action.update_field_id = False
            //             action.update_path = False
            //         elif action.state == 'object_write':
            //             if action.update_path:
            //                 # we need to traverse relations to find the target model and field
            //                 model, field, _ = action._traverse_path()
            //                 action.crud_model_id = model
            //                 action.update_field_id = field
            //                 need_update_model = action.evaluation_type == 'value' and action.update_field_id and action.update_field_id.relation
            //                 action.update_related_model_id = action.env["ir.model"]._get_id(field.relation) if need_update_model else False
            //             else:
            //                 action.crud_model_id = action.model_id
            //                 action.update_field_id = False
            //     else:
            //         action.crud_model_id = False
            //         action.update_field_id = False
            //         action.update_path = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeLinkFieldIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_link_field_id(self):
            // invalid = self.filtered(lambda act: act.link_field_id.model_id != act.model_id)
            // if invalid:
            //     invalid.link_field_id = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeMailPostAutofollowInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_mail_post_autofollow(self):
            // to_reset = self.filtered(lambda act: act.state != 'mail_post' or act.mail_post_method == 'email')
            // if to_reset:
            //     to_reset.mail_post_autofollow = False
            // other = self - to_reset
            // if other:
            //     other.mail_post_autofollow = True
            */
            return default;
        }

        protected async Task<IrActServer> ComputeMailPostMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_mail_post_method(self):
            // to_reset = self.filtered(lambda act: act.state != 'mail_post')
            // if to_reset:
            //     to_reset.mail_post_method = False
            // other = self - to_reset
            // if other:
            //     other.mail_post_method = 'comment'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _compute_name(self):
            // ''' Only server actions linked to a base_automation get an automatic name. '''
            // to_update = self.filtered('base_automation_id')
            // for action in to_update:
            //     match action.state:
            //         case 'object_write':
            //             action_type = _("Update") if action.evaluation_type == 'value' else _("Compute")
            //             action.name = f"{action_type} {action._stringify_path()}"
            //         case 'object_create':
            //             action.name = _(
            //             "Create %(model_name)s with name %(value)s",
            //                 model_name=action.crud_model_id.name,
            //                 value=action.value
            //             )
            //         case 'webhook':
            //             action.name = _("Send Webhook Notification")
            //         case 'sms':
            //             action.name = _(
            //             'Send SMS: %(template_name)s',
            //             template_name=action.sms_template_id.name
            //         )
            //         case 'mail_post':
            //             action.name = _(
            //                 'Send email: %(template_name)s',
            //                 template_name=action.template_id.name
            //             )
            //         case 'followers':
            //             action.name = _(
            //                 'Add followers: %(partner_names)s',
            //                 partner_names=', '.join(action.partner_ids.mapped('name'))
            //             )
            //         case 'remove_followers':
            //             action.name = _(
            //                 'Remove followers: %(partner_names)s',
            //                 partner_names=', '.join(action.partner_ids.mapped('name'))
            //             )
            //         case 'next_activity':
            //             action.name = _(
            //                 'Create activity: %(activity_name)s',
            //                 activity_name=action.activity_summary or action.activity_type_id.name
            //             )
            //         case other:
            //             action.name = dict(action._fields['state']._description_selection(self.env))[action.state]
            // # Not sure, but IIRC assignation is mandatory and I don't want the name to be reset by accident
            // for action in (self - to_update):
            //     action.name = action.name or ''
            */
            return default;
        }

        protected async Task<IrActServer> ComputePartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_partner_ids(self):
            // to_reset = self.filtered(lambda act: act.state != 'followers')
            // if to_reset:
            //     to_reset.partner_ids = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeSmsMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _compute_sms_method(self):
            // to_reset = self.filtered(lambda act: act.state != 'sms')
            // if to_reset:
            //     to_reset.sms_method = False
            // other = self - to_reset
            // if other:
            //     other.sms_method = 'sms'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeSmsTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _compute_sms_template_id(self):
            // to_reset = self.filtered(
            //     lambda act: act.state != 'sms' or \
            //                 (act.model_id != act.sms_template_id.model_id)
            // )
            // if to_reset:
            //     to_reset.sms_template_id = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_template_id(self):
            // to_reset = self.filtered(
            //     lambda act: act.state != 'mail_post' or \
            //                 (act.model_id != act.template_id.model_id)
            // )
            // if to_reset:
            //     to_reset.template_id = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeValueFieldToShowInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_value_field_to_show(self):  # check if value_field_to_show can be removed and use ttype in xml view instead
            // for action in self:
            //     if action.update_field_id.ttype in ('one2many', 'many2one', 'many2many'):
            //         action.value_field_to_show = 'resource_ref'
            //     elif action.update_field_id.ttype == 'selection':
            //         action.value_field_to_show = 'selection_value'
            //     elif action.update_field_id.ttype == 'boolean':
            //         action.value_field_to_show = 'update_boolean_value'
            //     else:
            //         action.value_field_to_show = 'value'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWebhookSamplePayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_webhook_sample_payload(self):
            // for action in self:
            //     if action.state != 'webhook':
            //         action.webhook_sample_payload = False
            //         continue
            //     payload = {
            //         '_id': 1,
            //         '_model': self.model_id.model,
            //         '_action': f'{action.name}(#{action.id})',
            //     }
            //     if self.model_id:
            //         sample_record = self.env[self.model_id.model].with_context(active_test=False).search([], limit=1)
            //         for field in action.webhook_field_ids:
            //             if sample_record:
            //                 payload['_id'] = sample_record.id
            //                 payload.update(sample_record.read(self.webhook_field_ids.mapped('name'), load=None)[0])
            //             else:
            //                 payload[field.name] = WEBHOOK_SAMPLE_VALUES[field.ttype] if field.ttype in WEBHOOK_SAMPLE_VALUES else WEBHOOK_SAMPLE_VALUES[None]
            //     action.webhook_sample_payload = json.dumps(payload, indent=4, sort_keys=True, default=str)
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWebsiteUrlInternalAsync(object website_path, Guid xml_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _compute_website_url(self, website_path, xml_id):
            // base_url = self.get_base_url()
            // link = website_path or xml_id or (self.id and '%d' % self.id) or ''
            // if base_url and link:
            //     path = '%s/%s' % ('/website/action', link)
            //     return urls.url_join(base_url, path)
            // return ''
            */
            return default;
        }

        protected async Task<IrActServer> ComputeXmlIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _compute_xml_id(self):
            // res = self.get_external_id()
            // for action in self:
            //     action.xml_id = res.get(action.id)
            */
            return default;
        }

        public async Task<IrActServer> CopyDataAsync(Guid id, IrActionsServerCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def copy_data(self, default=None):
            // default = default or {}
            // vals_list = super().copy_data(default=default)
            // if not default.get('name'):
            //     for vals in vals_list:
            //         vals['name'] = _('%s (copy)', vals.get('name', ''))
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrActServer> CreateActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def create_action(self):
            // """ Create a contextual action for each server action. """
            // for action in self:
            //     action.write({'binding_model_id': action.model_id.id,
            //                   'binding_type': 'action'})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrActServer> DefaultUpdatePathInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _default_update_path(self):
            // if not self.env.context.get('default_model_id'):
            //     return ''
            // ir_model = self.env['ir.model'].browse(self.env.context['default_model_id'])
            // model = self.env[ir_model.model]
            // sensible_default_fields = ['partner_id', 'user_id', 'user_ids', 'stage_id', 'state', 'active']
            // for field_name in sensible_default_fields:
            //     if field_name in model._fields and not model._fields[field_name].readonly:
            //         return field_name
            // return ''
            */
            return default;
        }

        protected async Task<IrActServer> EvalValueInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _eval_value(self, eval_context=None):
            // result = {}
            // for action in self:
            //     expr = action.value
            //     if action.evaluation_type == 'equation':
            //         expr = safe_eval(action.value, eval_context)
            //     elif action.update_field_id.ttype in ['one2many', 'many2many']:
            //         operation = action.update_m2m_operation
            //         if operation == 'add':
            //             expr = [Command.link(int(action.value))]
            //         elif operation == 'remove':
            //             expr = [Command.unlink(int(action.value))]
            //         elif operation == 'set':
            //             expr = [Command.set([int(action.value)])]
            //         elif operation == 'clear':
            //             expr = [Command.clear()]
            //     elif action.update_field_id.ttype == 'boolean':
            //         expr = action.update_boolean_value == 'true'
            //     elif action.update_field_id.ttype in ['many2one', 'integer']:
            //         try:
            //             expr = int(action.value)
            //             if expr == 0 and action.update_field_id.ttype == 'many2one':
            //                 expr = False
            //         except Exception:
            //             pass
            //     elif action.update_field_id.ttype == 'float':
            //         with contextlib.suppress(Exception):
            //             expr = float(action.value)
            //     result[action.id] = expr
            // return result
            */
            return default;
        }

        protected async Task<IrActServer> GetEvalContextInternalAsync(object action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _get_eval_context(self, action=None):
            // eval_context = super()._get_eval_context(action)
            // if action and action.state == "code":
            //     eval_context['json'] = json_scriptsafe
            //     payload = get_webhook_request_payload()
            //     if payload:
            //         eval_context["payload"] = payload
            // return eval_context
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _get_eval_context(self, action=None):
            // """ Override the method giving the evaluation context but also the
            // context used in all subsequent calls. Add the mail_notify_force_send
            // key set to False in the context. This way all notification emails linked
            // to the currently executed action will be set in the queue instead of
            // sent directly. This will avoid possible break in transactions. """
            // eval_context = super(ServerActions, self)._get_eval_context(action=action)
            // ctx = dict(eval_context['env'].context)
            // ctx['mail_notify_force_send'] = False
            // eval_context['env'].context = ctx
            // return eval_context
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _get_eval_context(self, action):
            // """ Override to add the request object in eval_context. """
            // eval_context = super(ServerAction, self)._get_eval_context(action)
            // if action.state == 'code':
            //     eval_context['request'] = request
            //     eval_context['json'] = json_scriptsafe
            // return eval_context
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_eval_context(self, action=None):
            // """ Prepare the context used when evaluating python code, like the
            // python formulas or code server actions.
            // 
            // :param action: the current server action
            // :type action: browse record
            // :returns: dict -- evaluation context given to (safe_)safe_eval """
            // def log(message, level="info"):
            //     with self.pool.cursor() as cr:
            //         cr.execute("""
            //             INSERT INTO ir_logging(create_date, create_uid, type, dbname, name, level, message, path, line, func)
            //             VALUES (NOW() at time zone 'UTC', %s, %s, %s, %s, %s, %s, %s, %s, %s)
            //         """, (self.env.uid, 'server', self._cr.dbname, __name__, level, message, "action", action.id, action.name))
            // 
            // eval_context = super(IrActionsServer, self)._get_eval_context(action=action)
            // model_name = action.model_id.sudo().model
            // model = self.env[model_name]
            // record = None
            // records = None
            // if self._context.get('active_model') == model_name and self._context.get('active_id'):
            //     record = model.browse(self._context['active_id'])
            // if self._context.get('active_model') == model_name and self._context.get('active_ids'):
            //     records = model.browse(self._context['active_ids'])
            // if self._context.get('onchange_self'):
            //     record = self._context['onchange_self']
            // eval_context.update({
            //     # orm
            //     'env': self.env,
            //     'model': model,
            //     # Exceptions
            //     'UserError': odoo.exceptions.UserError,
            //     # record
            //     'record': record,
            //     'records': records,
            //     # helpers
            //     'log': log,
            //     '_logger': LoggerProxy,
            // })
            // return eval_context
            */
            return default;
        }

        protected async Task<IrActServer> GetReadableFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "groups_id", "model_name",
            // }
            */
            return default;
        }

        protected async Task<IrActServer> GetRunnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_runner(self):
            // multi = True
            // t = self.env.registry[self._name]
            // fn = getattr(t, f'_run_action_{self.state}_multi', None)\
            //   or getattr(t, f'run_action_{self.state}_multi', None)
            // if not fn:
            //     multi = False
            //     fn = getattr(t, f'_run_action_{self.state}', None)\
            //       or getattr(t, f'run_action_{self.state}', None)
            // if fn and fn.__name__.startswith('run_action_'):
            //     fn = partial(fn, self)
            // return fn, multi
            */
            return default;
        }

        protected async Task<IrActServer> GetWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _get_website_url(self):
            // for action in self:
            //     if action.state == 'code' and action.website_published:
            //         action.website_url = action._compute_website_url(action.website_path, action.xml_id)
            //     else:
            //         action.website_url = False
            */
            return default;
        }

        protected async Task<IrActServer> IsRecomputeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _is_recompute(self):
            // """When an activity is set on update of a record,
            // update might be triggered many times by recomputes.
            // When need to know it to skip these steps.
            // Except if the computed field is supposed to trigger the action
            // """
            // records = self.env[self.model_name].browse(
            //     self._context.get('active_ids', self._context.get('active_id')))
            // old_values = self._context.get('old_values')
            // if old_values:
            //     domain_post = self._context.get('domain_post')
            //     tracked_fields = []
            //     if domain_post:
            //         for leaf in domain_post:
            //             if isinstance(leaf, (tuple, list)):
            //                 tracked_fields.append(leaf[0])
            //     fields_to_check = [field for record, field_names in old_values.items() for field in field_names if field not in tracked_fields]
            //     if fields_to_check:
            //         field = records._fields[fields_to_check[0]]
            //         # Pick an arbitrary field; if it is marked to be recomputed,
            //         # it means we are in an extraneous write triggered by the recompute.
            //         # In this case, we should not create a new activity.
            //         if records & self.env.records_to_compute(field):
            //             return True
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RaiseMany2manyErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _raise_many2many_error(self):
            // pass
            */
            return default;
        }

        protected async Task<IrActServer> RegisterHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _register_hook(self):
            // super()._register_hook()
            // 
            // for cls in self.env.registry[self._name].mro():
            //     for symbol in vars(cls).keys():
            //         if symbol.startswith('run_action_'):
            //             _logger.warning(
            //                 "RPC-public action methods are deprecated, found %r (in class %s.%s)",
            //                 symbol, cls.__module__, cls.__name__
            //             )
            */
            return default;
        }

        protected async Task<IrActServer> RunActionCodeMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _run_action_code_multi(self, eval_context=None):
            // """ Override to allow returning response the same way action is already
            //     returned by the basic server action behavior. Note that response has
            //     priority over action, avoid using both.
            // """
            // res = super(ServerAction, self)._run_action_code_multi(eval_context)
            // return eval_context.get('response', res)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_code_multi(self, eval_context):
            // safe_eval(self.code.strip(), eval_context, mode="exec", nocopy=True, filename=str(self))  # nocopy allows to return 'action'
            // return eval_context.get('action')
            */
            return default;
        }

        protected async Task<IrActServer> RunActionFollowersMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _run_action_followers_multi(self, eval_context=None):
            // Model = self.env[self.model_name]
            // if self.partner_ids and hasattr(Model, 'message_subscribe'):
            //     records = Model.browse(self._context.get('active_ids', self._context.get('active_id')))
            //     records.message_subscribe(partner_ids=self.partner_ids.ids)
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionMailPostMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _run_action_mail_post_multi(self, eval_context=None):
            // # TDE CLEANME: when going to new api with server action, remove action
            // if not self.template_id or (not self._context.get('active_ids') and not self._context.get('active_id')) or self._is_recompute():
            //     return False
            // res_ids = self._context.get('active_ids', [self._context.get('active_id')])
            // 
            // # Clean context from default_type to avoid making attachment
            // # with wrong values in subsequent operations
            // cleaned_ctx = dict(self.env.context)
            // cleaned_ctx.pop('default_type', None)
            // cleaned_ctx.pop('default_parent_id', None)
            // cleaned_ctx['mail_create_nosubscribe'] = True  # do not subscribe random people to records
            // cleaned_ctx['mail_post_autofollow'] = self.mail_post_autofollow
            // 
            // if self.mail_post_method in ('comment', 'note'):
            //     records = self.env[self.model_name].with_context(cleaned_ctx).browse(res_ids)
            //     message_type = 'auto_comment' if self.state == 'mail_post' else 'notification'
            //     if self.mail_post_method == 'comment':
            //         subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            //     else:
            //         subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note')
            //     records.message_post_with_source(
            //         self.template_id,
            //         message_type=message_type,
            //         subtype_id=subtype_id,
            //     )
            // else:
            //     template = self.template_id.with_context(cleaned_ctx)
            //     for res_id in res_ids:
            //         template.send_mail(
            //             res_id,
            //             force_send=False,
            //             raise_exception=False
            //         )
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_multi(self, eval_context=None):
            // res = False
            // for act in self.child_ids.sorted():
            //     res = act.run() or res
            // return res
            */
            return default;
        }

        protected async Task<IrActServer> RunActionNextActivityInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _run_action_next_activity(self, eval_context=None):
            // if not self.activity_type_id or not self._context.get('active_id') or self._is_recompute():
            //     return False
            // 
            // records = self.env[self.model_name].browse(self._context.get('active_ids', self._context.get('active_id')))
            // 
            // vals = {
            //     'summary': self.activity_summary or '',
            //     'note': self.activity_note or '',
            //     'activity_type_id': self.activity_type_id.id,
            // }
            // if self.activity_date_deadline_range > 0:
            //     vals['date_deadline'] = fields.Date.context_today(self) + relativedelta(**{
            //         self.activity_date_deadline_range_type or 'days': self.activity_date_deadline_range})
            // for record in records:
            //     user = False
            //     if self.activity_user_type == 'specific':
            //         user = self.activity_user_id
            //     elif self.activity_user_type == 'generic' and self.activity_user_field_name in record:
            //         user = record[self.activity_user_field_name]
            //     if user:
            //         vals['user_id'] = user.id
            //     record.activity_schedule(**vals)
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectCreateInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_object_create(self, eval_context=None):
            // """Create specified model object with specified name contained in value.
            // 
            // If applicable, link active_id.<self.link_field_id> to the new record.
            // """
            // res_id, _res_name = self.env[self.crud_model_id.model].name_create(self.value)
            // 
            // if self.link_field_id:
            //     record = self.env[self.model_id.model].browse(self._context.get('active_id'))
            //     if self.link_field_id.ttype in ['one2many', 'many2many']:
            //         record.write({self.link_field_id.name: [Command.link(res_id)]})
            //     else:
            //         record.write({self.link_field_id.name: res_id})
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectWriteInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_object_write(self, eval_context=None):
            // """Apply specified write changes to active_id."""
            // vals = self._eval_value(eval_context=eval_context)
            // res = {action.update_field_id.name: vals[action.id] for action in self}
            // 
            // if self._context.get('onchange_self'):
            //     record_cached = self._context['onchange_self']
            //     for field, new_value in res.items():
            //         record_cached[field] = new_value
            // elif self.update_path:
            //     starting_record = self.env[self.model_id.model].browse(self._context.get('active_id'))
            //     _, _, target_records = self._traverse_path(record=starting_record)
            //     target_records.write(res)
            */
            return default;
        }

        protected async Task<IrActServer> RunActionRemoveFollowersMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _run_action_remove_followers_multi(self, eval_context=None):
            // Model = self.env[self.model_name]
            // if self.partner_ids and hasattr(Model, 'message_unsubscribe'):
            //     records = Model.browse(self._context.get('active_ids', self._context.get('active_id')))
            //     records.message_unsubscribe(partner_ids=self.partner_ids.ids)
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionSmsMultiInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _run_action_sms_multi(self, eval_context=None):
            // # TDE CLEANME: when going to new api with server action, remove action
            // if not self.sms_template_id or self._is_recompute():
            //     return False
            // 
            // records = eval_context.get('records') or eval_context.get('record')
            // if not records:
            //     return False
            // 
            // composer = self.env['sms.composer'].with_context(
            //     default_res_model=records._name,
            //     default_res_ids=records.ids,
            //     default_composition_mode='comment' if self.sms_method == 'comment' else 'mass',
            //     default_template_id=self.sms_template_id.id,
            //     default_mass_keep_log=self.sms_method == 'note',
            // ).create({})
            // composer.action_send_sms()
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionWebhookInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_webhook(self, eval_context=None):
            // """Send a post request with a read of the selected field on active_id."""
            // record = self.env[self.model_id.model].browse(self._context.get('active_id'))
            // url = self.webhook_url
            // if not record:
            //     return
            // if not url:
            //     raise UserError(_("I'll be happy to send a webhook for you, but you really need to give me a URL to reach out to..."))
            // vals = {
            //     '_model': self.model_id.model,
            //     '_id': record.id,
            //     '_action': f'{self.name}(#{self.id})',
            // }
            // if self.webhook_field_ids:
            //     # you might think we could use the default json serializer of the requests library
            //     # but it will fail on many fields, e.g. datetime, date or binary
            //     # so we use the json.dumps serializer instead with the str() function as default
            //     vals.update(record.read(self.webhook_field_ids.mapped('name'), load=None)[0])
            // json_values = json.dumps(vals, sort_keys=True, default=str)
            // _logger.info("Webhook call to %s", url)
            // _logger.debug("POST JSON data for webhook call: %s", json_values)
            // try:
            //     # 'send and forget' strategy, and avoid locking the user if the webhook
            //     # is slow or non-functional (we still allow for a 1s timeout so that
            //     # if we get a proper error response code like 400, 404 or 500 we can log)
            //     response = requests.post(url, data=json_values, headers={'Content-Type': 'application/json'}, timeout=1)
            //     response.raise_for_status()
            // except requests.exceptions.ReadTimeout:
            //     _logger.warning("Webhook call timed out after 1s - it may or may not have failed. "
            //                     "If this happens often, it may be a sign that the system you're "
            //                     "trying to reach is slow or non-functional.")
            // except requests.exceptions.RequestException as e:
            //     _logger.warning("Webhook call failed: %s", e)
            // except Exception as e:  # noqa: BLE001
            //     raise UserError(_("Wow, your webhook call failed with a really unusual error: %s", e)) from e
            */
            return default;
        }

        public async Task<IrActServer> RunAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def run(self):
            // """ Runs the server action. For each server action, the
            // :samp:`_run_action_{TYPE}[_multi]` method is called. This allows easy
            // overriding of the server actions.
            // 
            // The ``_multi`` suffix means the runner can operate on multiple records,
            // otherwise if there are multiple records the runner will be called once
            // for each.
            // 
            // The call context should contain the following keys:
            // 
            // active_id
            //     id of the current object (single mode)
            // active_model
            //     current model that should equal the action's model
            // active_ids (optional)
            //    ids of the current records (mass mode). If ``active_ids`` and
            //    ``active_id`` are present, ``active_ids`` is given precedence.
            // :return: an ``action_id`` to be executed, or ``False`` is finished
            //          correctly without return action
            // """
            // res = False
            // for action in self.sudo():
            //     action_groups = action.groups_id
            //     if action_groups:
            //         if not (action_groups & self.env.user.groups_id):
            //             raise AccessError(_("You don't have enough access rights to run this action."))
            //     else:
            //         model_name = action.model_id.model
            //         try:
            //             self.env[model_name].check_access("write")
            //         except AccessError:
            //             _logger.warning("Forbidden server action %r executed while the user %s does not have access to %s.",
            //                 action.name, self.env.user.login, model_name,
            //             )
            //             raise
            // 
            //     eval_context = self._get_eval_context(action)
            //     records = eval_context.get('record') or eval_context['model']
            //     records |= eval_context.get('records') or eval_context['model']
            //     if not action_groups and records.ids:
            //         # check access rules on real records only; base automations of
            //         # type 'onchange' can run server actions on new records
            //         try:
            //             records.check_access('write')
            //         except AccessError:
            //             _logger.warning("Forbidden server action %r executed while the user %s does not have access to %s.",
            //                 action.name, self.env.user.login, records,
            //             )
            //             raise
            // 
            //     runner, multi = action._get_runner()
            //     if runner and multi:
            //         # call the multi method
            //         run_self = action.with_context(eval_context['env'].context)
            //         res = runner(run_self, eval_context=eval_context)
            //     elif runner:
            //         active_id = self._context.get('active_id')
            //         if not active_id and self._context.get('onchange_self'):
            //             active_id = self._context['onchange_self']._origin.id
            //             if not active_id:  # onchange on new record
            //                 res = runner(action, eval_context=eval_context)
            //         active_ids = self._context.get('active_ids', [active_id] if active_id else [])
            //         for active_id in active_ids:
            //             # run context dedicated to a particular active_id
            //             run_self = action.with_context(active_ids=[active_id], active_id=active_id)
            //             eval_context["env"].context = run_self._context
            //             eval_context['records'] = eval_context['record'] = records.browse(active_id)
            //             res = runner(run_self, eval_context=eval_context)
            //     else:
            //         _logger.warning(
            //             "Found no way to execute server action %r of type %r, ignoring it. "
            //             "Verify that the type is correct or add a method called "
            //             "`_run_action_<type>` or `_run_action_<type>_multi`.",
            //             action.name, action.state
            //         )
            // return res or False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrActServer> SelectionTargetModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _selection_target_model(self):
            // return [(model.model, model.name) for model in self.env['ir.model'].sudo().search([])]
            */
            return default;
        }

        protected async Task<IrActServer> SetResourceRefInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _set_resource_ref(self):
            // for action in self.filtered(lambda action: action.value_field_to_show == 'resource_ref'):
            //     if action.resource_ref:
            //         action.value = str(action.resource_ref.id)
            */
            return default;
        }

        protected async Task<IrActServer> SetSelectionValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _set_selection_value(self):
            // for action in self.filtered(lambda action: action.value_field_to_show == 'selection_value'):
            //     if action.selection_value:
            //         action.value = action.selection_value.value
            */
            return default;
        }

        protected async Task<IrActServer> StringifyPathInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _stringify_path(self):
            // """ Returns a string representation of the update_path, with the field names
            // separated by the `>` symbol."""
            // self.ensure_one()
            // path = self.update_path
            // if not path:
            //     return ''
            // model = self.env[self.model_id.model]
            // pretty_path = []
            // field = None
            // for field_name in path.split('.'):
            //     if field and field.type == 'properties':
            //         pretty_path.append(field_name)
            //         continue
            //     field = model._fields[field_name]
            //     field_id = self.env['ir.model.fields']._get(model._name, field_name)
            //     if field.relational:
            //         model = self.env[field.comodel_name]
            //     pretty_path.append(field_id.field_description)
            // return ' > '.join(pretty_path)
            */
            return default;
        }

        protected async Task<IrActServer> TraversePathInternalAsync(object record)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _traverse_path(self, record=None):
            // """ Traverse the update_path to find the target model and field, and optionally
            // the target record of an action of type 'object_write'.
            // 
            // :param record: optional record to use as starting point for the path traversal
            // :return: a tuple (model, field, records) where model is the target model and field is the
            //          target field; if no record was provided, records is None, otherwise it is the
            //             recordset at the end of the path starting from the provided record
            // """
            // self.ensure_one()
            // path = self.update_path.split('.')
            // Model = self.env[self.model_id.model]
            // # sanity check: we're starting from a record that belongs to the model
            // if record and record._name != Model._name:
            //     raise ValidationError(_("I have no idea how you *did that*, but you're trying to use a gibberish configuration: the model of the record on which the action is triggered is not the same as the model of the action."))
            // for field_name in path:
            //     is_last_field = field_name == path[-1]
            //     field = Model._fields[field_name]
            //     if field.relational and not is_last_field:
            //         Model = self.env[field.comodel_name]
            //     elif not field.relational:
            //         # sanity check: this should be the last field in the path
            //         if not is_last_field:
            //             raise ValidationError(_("The path to the field to update contains a non-relational field (%s) that is not the last field in the path. You can't traverse non-relational fields (even in the quantum realm). Make sure only the last field in the path is non-relational.", field_name))
            //         if isinstance(field, fields.Json):
            //             raise ValidationError(_("I'm sorry to say that JSON fields (such as %s) are currently not supported.", field_name))
            // target_records = None
            // if record is not None:
            //     target_records = reduce(getitem, path[:-1], record)
            // model_id = self.env['ir.model']._get(Model._name)
            // field_id = self.env['ir.model.fields']._get(Model._name, field_name)
            // return model_id, field_id, target_records
            */
            return default;
        }

        public async Task<IrActServer> UnlinkActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def unlink_action(self):
            // """ Remove the contextual actions created for the server actions. """
            // self.check_access('write')
            // self.filtered('binding_model_id').write({'binding_model_id': False})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}