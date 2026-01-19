using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class IrActionsServerAppService : GenericApplicationService<IrActServer>, IIrActionsServerAppService
    {
        private readonly IIrActionsActionsAppService _irActionsActionsAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public IrActionsServerAppService(IRepository<IrActServer, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IIrActionsActionsAppService irActionsActionsAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _irActionsActionsAppService = irActionsActionsAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<IrActServer> CanExecuteActionOnRecordsInternalAsync(object records)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _can_execute_action_on_records(self, records):
            // self.ensure_one()
            // 
            // action_groups = self.group_ids
            // if action_groups:
            //     if not (action_groups & self.env.user.all_group_ids):
            //         raise AccessError(_("You don't have enough access rights to run this action."))
            // else:
            //     model_name = self.model_id.model
            //     try:
            //         self.env[model_name].check_access("write")
            //     except AccessError:
            //         _logger.warning("Forbidden server action %r executed while the user %s does not have access to %s.",
            //             self.name, self.env.user.login, model_name,
            //         )
            //         raise
            // 
            // if not self.group_ids and records.ids:
            //     # check access rules on real records only; base automations of
            //     # type 'onchange' can run server actions on new records
            //     try:
            //         records.check_access('write')
            //     except AccessError:
            //         _logger.warning("Forbidden server action %r executed while the user %s does not have access to %s.",
            //             self.name, self.env.user.login, records,
            //         )
            //         raise
            */
            return default;
        }

        protected async Task<IrActServer> CheckChildrenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_children(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Recursion found in child server actions'))
            // 
            // if (children_with_warnings := self.child_ids.filtered('warning')):
            //     raise ValidationError(_("Following child actions have warnings: %(children)s", children=', '.join(children_with_warnings.mapped('name'))))
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

        protected async Task<IrActServer> ComputeActivityInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_activity_info(self):
            // to_reset = self.filtered(lambda act: not act.model_id or act.state != 'next_activity')
            // if to_reset:
            //     to_reset.activity_type_id = False
            //     to_reset.activity_summary = False
            //     to_reset.activity_note = False
            //     to_reset.activity_date_deadline_range = False
            //     to_reset.activity_date_deadline_range_type = False
            //     to_reset.activity_user_type = False
            // for action in (self - to_reset):
            //     if action.activity_type_id.res_model and action.model_id.model != action.activity_type_id.res_model:
            //         action.activity_type_id = False
            //     if not action.activity_summary:
            //         action.activity_summary = action.activity_type_id.summary
            //     if not action.activity_date_deadline_range_type:
            //         action.activity_date_deadline_range_type = 'days'
            //     if not action.activity_user_type:
            //         action.activity_user_type = 'specific'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeActivityUserInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_activity_user_info(self):
            // to_compute = self.filtered("activity_user_type")
            // (self - to_compute).activity_user_id = False
            // (self - to_compute).activity_user_field_name = False
            // for action in to_compute:
            //     if action.activity_user_type == 'specific':
            //         action.activity_user_field_name = False
            //     else:
            //         action.activity_user_id = False
            //         IrModelFields = self.env['ir.model.fields']
            //         domain = [('model', '=', action.model_id.model), ("relation", "=", "res.users")]
            //         action.activity_user_field_name = (
            //             IrModelFields.search([*domain, ("name", "=", "user_id")], limit=1)
            //             or IrModelFields.search(domain, limit=1)
            //         ).name
            */
            return default;
        }

        protected async Task<IrActServer> ComputeAllowedStatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_allowed_states(self):
            // self.allowed_states = [value for value, __ in self._fields['state'].selection]
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
            // super(IrActionsServer, self - mail_thread_based)._compute_available_model_ids()
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _compute_available_model_ids(self):
            // mail_thread_based = self.filtered(lambda action: action.state == 'sms')
            // if mail_thread_based:
            //     mail_models = self.env['ir.model'].search([('is_mail_thread', '=', True), ('transient', '=', False)])
            //     for action in mail_thread_based:
            //         action.available_model_ids = mail_models.ids
            // super(IrActionsServer, self - mail_thread_based)._compute_available_model_ids()
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
            //     if action.model_id and action.state in ('object_write', 'object_create', 'object_copy'):
            //         if action.state in ('object_create', 'object_copy'):
            //             action.crud_model_id = action.model_id
            //             action.update_field_id = False
            //             action.update_path = False
            //         elif action.state == 'object_write':
            //             if action.update_path:
            //                 # we need to traverse relations to find the target model and field
            //                 model, field = action._traverse_path()
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

        protected async Task<IrActServer> ComputeFollowersInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_followers_info(self):
            // for action in self:
            //     if action.followers_type == 'specific':
            //         action.followers_partner_field_name = False
            //     elif action.followers_type == 'generic':
            //         action.partner_ids = False
            //         IrModelFields = self.env['ir.model.fields']
            //         domain = [('model', '=', action.model_id.model), ("relation", "=", "res.partner")]
            //         action.followers_partner_field_name = (
            //             IrModelFields.search([*domain, ("name", "=", "partner_id")], limit=1)
            //             or IrModelFields.search(domain, limit=1)
            //         ).name
            //     else:
            //         action.partner_ids = False
            //         action.followers_partner_field_name = False
            */
            return default;
        }

        protected async Task<IrActServer> ComputeFollowersTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _compute_followers_type(self):
            // to_reset = self.filtered(lambda act: not act.model_id or act.state not in ['followers', 'remove_followers'])
            // to_reset.followers_type = False
            // to_default = (self - to_reset).filtered(lambda act: not act.followers_type)
            // to_default.followers_type = 'specific'
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
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_name(self):
            // for action in self:
            //     was_automated = action.name == action.automated_name
            //     action.automated_name = action._generate_action_name()
            //     if was_automated:
            //         action.name = action.automated_name
            */
            return default;
        }

        protected async Task<IrActServer> ComputeShowCodeHistoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_show_code_history(self):
            // self.show_code_history = False
            // History = self.env["ir.actions.server.history"]
            // for action in self.filtered(lambda a: a.state == "code"):
            //     action.show_code_history = History.search_count([
            //         ("action_id", "=", action.id),
            //         ("code", "!=", action.code),
            //     ]) > 0
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
            //     if action.evaluation_type == 'sequence':
            //         action.value_field_to_show = 'sequence_id'
            //     elif action.update_field_id.ttype in ('one2many', 'many2one', 'many2many'):
            //         action.value_field_to_show = 'resource_ref'
            //     elif action.update_field_id.ttype == 'selection':
            //         action.value_field_to_show = 'selection_value'
            //     elif action.update_field_id.ttype == 'boolean':
            //         action.value_field_to_show = 'update_boolean_value'
            //     elif action.update_field_id.ttype == 'html':
            //         action.value_field_to_show = 'html_value'
            //     else:
            //         action.value_field_to_show = 'value'
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_warning(self):
            // for action in self:
            //     if (warnings := action._get_warning_messages()):
            //         action.warning = "\n\n".join(warnings)
            //     else:
            //         action.warning = False
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
            //     return urls.urljoin(base_url, path)
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
            //     elif action.evaluation_type == 'sequence':
            //         expr = action.sequence_id.next_by_id()
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
            //     elif action.update_field_id.ttype == 'html':
            //         expr = action.html_value
            //     result[action.id] = expr
            // return result
            */
            return default;
        }

        protected async Task<IrActServer> GenerateActionNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _generate_action_name(self):
            // self.ensure_one()
            // if self.state == 'mail_post' and self.template_id:
            //     return _('Send %(template_name)s', template_name=self.template_id.name)
            // if self.state == 'next_activity' and self.activity_type_id:
            //     return _('Create %(activity_name)s', activity_name=self.activity_type_id.name)
            // return super()._generate_action_name()
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _generate_action_name(self):
            // self.ensure_one()
            // if self.state == 'sms' and self.sms_template_id:
            //     return _('Send %(template_name)s', template_name=self.sms_template_id.name)
            // return super()._generate_action_name()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _generate_action_name(self):
            // self.ensure_one()
            // if self.state == 'object_create':
            //     return _("Create %(model_name)s", model_name=self.crud_model_id.name)
            // if self.state == 'object_write':
            //     return _("Update %(model_name)s", model_name=self.crud_model_id.name)
            // if self.state == "object_copy":
            //     if not self.crud_model_id or not self.resource_ref:
            //         return _("Duplicate ...")
            //     record = self.env[self.crud_model_id.model].browse(self.resource_ref.id)
            //     return _("Duplicate %(record)s", record=record.display_name)
            // return dict(self._fields["state"]._description_selection(self.env)).get(
            //     self.state, ""
            // )
            */
            return default;
        }

        protected async Task<IrActServer> GetChildrenDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _get_children_domain(self):
            // # As automation rules' actions does not have a parent,
            // # we make sure multi actions can not link to automation rules' actions.
            // return super()._get_children_domain() & Domain("base_automation_id", "=", False)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_children_domain(self):
            // domain = Domain([
            //     ("model_id", "=", unquote("model_id")),
            //     ("parent_id", "=", False),
            //     ("id", "!=", unquote("id")),
            // ])
            // return domain
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
            // eval_context = super()._get_eval_context(action=action)
            // env = eval_context['env']
            // eval_context['env'] = env(context={**env.context, 'mail_notify_force_send': False})
            // return eval_context
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py) ---
            // def _get_eval_context(self, action):
            // """ Override to add the request object in eval_context. """
            // eval_context = super()._get_eval_context(action)
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
            //         """, (self.env.uid, 'server', self.env.cr.dbname, __name__, level, message, "action", action.id, action.name))
            // 
            // eval_context = super(IrActionsServer, self)._get_eval_context(action=action)
            // model_name = action.model_id.sudo().model
            // model = self.env[model_name]
            // record = None
            // records = None
            // if self.env.context.get('active_model') == model_name and self.env.context.get('active_id'):
            //     record = model.browse(self.env.context['active_id'])
            // if self.env.context.get('active_model') == model_name and self.env.context.get('active_ids'):
            //     records = model.browse(self.env.context['active_ids'])
            // if self.env.context.get('onchange_self'):
            //     record = self.env.context['onchange_self']
            // eval_context.update({
            //     # orm
            //     'env': self.env,
            //     'model': model,
            //     # Exceptions
            //     'UserError': UserError,
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
            //     "group_ids", "model_name",
            // }
            */
            return default;
        }

        protected async Task<IrActServer> GetRelationChainInternalAsync(object searched_field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_relation_chain(self, searched_field_name):
            // self.ensure_one()
            // if (
            //     not searched_field_name
            //     or not searched_field_name in self._fields
            //     or not self[searched_field_name]
            //     or not self.model_id
            // ):
            //     return [], ""
            // path = self[searched_field_name].split('.')
            // if not path:
            //     return [], ""
            // model = self.env[self.model_id.model]
            // chain = []
            // for field_name in path:
            //     is_last_field = field_name == path[-1]
            //     field = model._fields[field_name]
            //     if not is_last_field:
            //         if not field.relational:
            //             # sanity check: this should be the last field in the path
            //             current_field = field.get_description(self.env)["string"]
            //             searched_field = self._fields[searched_field_name].get_description(self.env)["string"]
            //             raise ValidationError(_("The path contained by the field '%(searched_field)s' contains a non-relational field (%(current_field)s) that is not the last field in the path. You can't traverse non-relational fields (even in the quantum realm). Make sure only the last field in the path is non-relational.", searched_field=searched_field, current_field=current_field))
            //         model = self.env[field.comodel_name]
            //     chain.append(field)
            // stringified_path = ' > '.join([field.get_description(self.env)["string"] for field in chain])
            // return chain, stringified_path
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
            // fn = getattr(t, f'_run_action_{self.state}_multi', None)
            // if not fn:
            //     multi = False
            //     fn = getattr(t, f'_run_action_{self.state}', None)
            // return fn, multi
            */
            return default;
        }

        protected async Task<IrActServer> GetWarningMessagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _get_warning_messages(self):
            // self.ensure_one()
            // warnings = super()._get_warning_messages()
            // 
            // if self.base_automation_id and self.model_id != self.base_automation_id.model_id:
            //     warnings.append(
            //         _("Model of action %(action_name)s should match the one from automated rule %(rule_name)s.",
            //             action_name=self.name,
            //             rule_name=self.base_automation_id.name
            //             )
            //     )
            // 
            // return warnings
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _get_warning_messages(self):
            // warnings = super()._get_warning_messages()
            // 
            // if self.activity_date_deadline_range < 0:
            //     warnings.append(_("The 'Due Date In' value can't be negative."))
            // 
            // if self.state == 'mail_post' and self.template_id and self.template_id.model_id != self.model_id:
            //     warnings.append(_("Mail template model of $(action_name)s does not match action model.", action_name=self.name))
            // 
            // if self.state in {'mail_post', 'followers', 'remove_followers', 'next_activity'} and self.model_id.transient:
            //     warnings.append(_("This action cannot be done on transient models."))
            // 
            // if (
            //     (self.state in {"followers", "remove_followers"}
            //     or (self.state == "mail_post" and self.mail_post_method != "email"))
            //     and not self.model_id.is_mail_thread
            // ):
            //     warnings.append(_("This action can only be done on a mail thread models"))
            // 
            // if self.state == 'next_activity' and not self.model_id.is_mail_activity:
            //     warnings.append(_("A next activity can only be planned on models that use activities."))
            // 
            // if self.state in ('followers', 'remove_followers') and self.followers_type == 'generic' and self.followers_partner_field_name:
            //     fields, field_chain_str = self._get_relation_chain("followers_partner_field_name")
            //     if fields and fields[-1].comodel_name != "res.partner":
            //         warnings.append(_(
            //             "The field '%(field_chain_str)s' is not a partner field.",
            //             field_chain_str=field_chain_str,
            //         ))
            // 
            // if self.state == 'next_activity' and self.activity_user_type == 'generic' and self.activity_user_field_name:
            //     fields, field_chain_str = self._get_relation_chain("activity_user_field_name")
            //     if fields and fields[-1].comodel_name != "res.users":
            //         warnings.append(_(
            //             "The field '%(field_chain_str)s' is not a user field.",
            //             field_chain_str=field_chain_str,
            //         ))
            // 
            // return warnings
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _get_warning_messages(self):
            // self.ensure_one()
            // warnings = super()._get_warning_messages()
            // 
            // if self.state == 'sms':
            //     if self.model_id.transient or not self.model_id.is_mail_thread:
            //         warnings.append(_("Sending SMS can only be done on a not transient mail.thread model"))
            // 
            //     if self.sms_template_id and self.sms_template_id.model_id != self.model_id:
            //         warnings.append(
            //             _('SMS template model of %(action_name)s does not match action model.',
            //               action_name=self.name
            //              )
            //         )
            // 
            // return warnings
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_warning_messages(self):
            // self.ensure_one()
            // warnings = []
            // 
            // if self.model_id and (children_with_different_model := self.child_ids.filtered(lambda a: a.model_id != self.model_id)):
            //     warnings.append(_("Following child actions should have the same model (%(model)s): %(children)s",
            //                       model=self.model_id.name,
            //                       children=', '.join(children_with_different_model.mapped('name'))))
            // 
            // if self.group_ids and (children_with_different_groups := self.child_ids.filtered(lambda a: a.group_ids != self.group_ids)):
            //     warnings.append(_("Following child actions should have the same groups (%(groups)s): %(children)s",
            //                       groups=', '.join(self.group_ids.mapped('name')),
            //                       children=', '.join(children_with_different_groups.mapped('name'))))
            // 
            // if (children_with_warnings := self.child_ids.filtered('warning')):
            //     warnings.append(_("Following child actions have warnings: %(children)s", children=', '.join(children_with_warnings.mapped('name'))))
            // 
            // if (relation_chain := self._get_relation_chain("update_path")) and relation_chain[0] and isinstance(relation_chain[0][-1], fields.Json):
            //     warnings.append(_("I'm sorry to say that JSON fields (such as '%s') are currently not supported.", relation_chain[0][-1].string))
            // 
            // if self.state == 'object_write' and self.evaluation_type == 'sequence' and self.update_field_type and self.update_field_type not in ('char', 'text'):
            //     warnings.append(_("A sequence must only be used with character fields."))
            // 
            // if self.state == 'webhook' and self.model_id:
            //     restricted_fields = []
            //     Model = self.env[self.model_id.model]
            //     for model_field in self.webhook_field_ids:
            //         # you might think that the ir.model.field record holds references
            //         # to the groups, but that's not the case - we need to field object itself
            //         field = Model._fields[model_field.name]
            //         if field.groups:
            //             restricted_fields.append(f"- {model_field.field_description}")
            //     if restricted_fields:
            //         warnings.append(_("Group-restricted fields cannot be included in "
            //                         "webhook payloads, as it could allow any user to "
            //                         "accidentally leak sensitive information. You will "
            //                         "have to remove the following fields from the webhook payload:\n%(restricted_fields)s", restricted_fields="\n".join(restricted_fields)))
            // 
            // return warnings
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

        public async Task<IrActServer> HistoryWizardActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def history_wizard_action(self):
            // self.ensure_one()
            // return {
            //     "type": "ir.actions.act_window",
            //     "name": _("Code History"),
            //     "target": "new",
            //     "views": [(False, "form")],
            //     "res_model": "server.action.history.wizard",
            //     "context": {"default_action_id": self.id},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     self.env.context.get('active_ids', self.env.context.get('active_id')))
            // old_values = self.env.context.get('old_values')
            // if old_values:
            //     domain_post = self.env.context.get('domain_post')
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

        protected async Task<IrActServer> NameDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _name_depends(self):
            // return [*super()._name_depends(), "template_id", "activity_type_id"]
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _name_depends(self):
            // return [*super()._name_depends(), "sms_template_id"]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _name_depends(self):
            // return [
            //     "state",
            //     "crud_model_id",
            //     "resource_ref",
            // ]
            */
            return default;
        }

        protected async Task<IrActServer> OnchangeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _onchange_name(self):
            // if not self.name:
            //     self.automated_name = self._generate_action_name()
            //     self.name = self.automated_name
            */
            return default;
        }

        public async Task<IrActServer> OpenAutomationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def action_open_automation(self):
            // return {
            //     "type": "ir.actions.act_window",
            //     "target": "current",
            //     "views": [[False, "form"]],
            //     "res_model": self.base_automation_id._name,
            //     "res_id": self.base_automation_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrActServer> OpenParentActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def action_open_parent_action(self):
            // return {
            //     "type": "ir.actions.act_window",
            //     "target": "current",
            //     "views": [[False, "form"]],
            //     "res_model": self._name,
            //     "res_id": self.parent_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrActServer> OpenScheduledActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def action_open_scheduled_action(self):
            // return {
            //     "type": "ir.actions.act_window",
            //     "target": "current",
            //     "views": [[False, "form"]],
            //     "res_model": "ir.cron",
            //     "res_id": self.ir_cron_ids.ids[0],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // res = super()._run_action_code_multi(eval_context)
            // return eval_context.get('response', res)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_code_multi(self, eval_context):
            // if not self.code:
            //     return
            // safe_eval(self.code.strip(), eval_context, mode="exec", filename=str(self))
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
            // if hasattr(Model, 'message_subscribe'):
            //     records = Model.browse(self.env.context.get('active_ids', self.env.context.get('active_id')))
            //     if self.followers_type == 'specific':
            //         partner_ids = self.partner_ids
            //     else:
            //         followers_field = self.followers_partner_field_name
            //         partner_ids = records.mapped(followers_field)
            //     records.message_subscribe(partner_ids=partner_ids.ids)
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
            // if not self.template_id or (not self.env.context.get('active_ids') and not self.env.context.get('active_id')) or self._is_recompute():
            //     return False
            // res_ids = self.env.context.get('active_ids', [self.env.context.get('active_id')])
            // 
            // # Clean context from default_type to avoid making attachment
            // # with wrong values in subsequent operations
            // cleaned_ctx = dict(self.env.context)
            // cleaned_ctx.pop('default_type', None)
            // cleaned_ctx.pop('default_parent_id', None)
            // cleaned_ctx['mail_post_autofollow_author_skip'] = True  # do not subscribe random people to records
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
            // if not self.activity_type_id or not self.env.context.get('active_id') or self._is_recompute():
            //     return False
            // 
            // records = self.env[self.model_name].browse(self.env.context.get('active_ids', self.env.context.get('active_id')))
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
            //         # if x2m field, assign to the first user found
            //         # (same behavior as Field.traverse_related)
            //         vals['user_id'] = user.ids[0]
            //     record.activity_schedule(**vals)
            // return False
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectCopyInternalAsync(object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_object_copy(self, eval_context=None):
            // """ Duplicate specified model object.
            //     If applicable, link active_id.<self.link_field_id> to the new record.
            // """
            // dupe = self.env[self.crud_model_id.model].browse(self.resource_ref.id).copy()
            // 
            // if self.link_field_id:
            //     record = self.env[self.model_id.model].browse(self.env.context.get('active_id'))
            //     if self.link_field_id.ttype in ['one2many', 'many2many']:
            //         record.write({self.link_field_id.name: [Command.link(dupe.id)]})
            //     else:
            //         record.write({self.link_field_id.name: dupe.id})
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
            //     record = self.env[self.model_id.model].browse(self.env.context.get('active_id'))
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
            // if self.env.context.get('onchange_self'):
            //     record_cached = self.env.context['onchange_self']
            //     for field, new_value in res.items():
            //         record_cached[field] = new_value
            // elif self.update_path:
            //     starting_record = self.env[self.model_id.model].browse(self.env.context.get('active_id'))
            //     path = self.update_path.split('.')
            //     target_records = reduce(getitem, path[:-1], starting_record)
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
            // if hasattr(Model, 'message_unsubscribe'):
            //     records = Model.browse(self.env.context.get('active_ids', self.env.context.get('active_id')))
            //     if self.followers_type == 'specific':
            //         partner_ids = self.partner_ids
            //     else:
            //         followers_field = self.followers_partner_field_name
            //         partner_ids = records.mapped(followers_field)
            //     records.message_unsubscribe(partner_ids=partner_ids.ids)
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
            // record = self.env[self.model_id.model].browse(self.env.context.get('active_id'))
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
            // 
            // @self.env.cr.postrollback.add
            // def _add_post_rollback():
            //     _logger.warning("Webhook call to %s - cancelled due to a rollback", url)
            // 
            // @self.env.cr.postcommit.add
            // def _add_post_commit():
            //     _logger.debug("Webhook call to %s - start", url)
            //     import requests  # noqa: PLC0415
            //     try:
            //         # 'send and forget' strategy, and avoid locking the user if the webhook
            //         # is slow or non-functional (we still allow for a 1s timeout so that
            //         # if we get a proper error response code like 400, 404 or 500 we can log)
            //         response = requests.post(url, data=json_values, headers={'Content-Type': 'application/json'}, timeout=1)
            //         response.raise_for_status()
            //         _logger.info("Webhook call to %s - succeeded", url)
            //     except requests.exceptions.ReadTimeout:
            //         _logger.warning("Webhook call timed out after 1s - it may or may not have failed. "
            //                         "If this happens often, it may be a sign that the system you're "
            //                         "trying to reach is slow or non-functional.")
            //     except requests.exceptions.RequestException as e:
            //         _logger.warning("Webhook call failed: %s", e)
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
            // 
            // :return: an ``action_id`` to be executed, or ``False`` is finished
            //          correctly without return action
            // """
            // res = False
            // for action in self.sudo():
            //     eval_context = self._get_eval_context(action)
            //     records = eval_context.get('record') or eval_context['model']
            //     records |= eval_context.get('records') or eval_context['model']
            //     action._can_execute_action_on_records(records)
            //     res = action._run(records, eval_context)
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrActServer> RunInternalAsync(object records, object eval_context)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run(self, records, eval_context):
            // self.ensure_one()
            // if self.warning:
            //     raise ServerActionWithWarningsError(_("Server action %(action_name)s has one or more warnings, address them first.", action_name=self.name))
            // 
            // runner, multi = self._get_runner()
            // res = False
            // if runner and multi:
            //     # call the multi method
            //     run_self = self.with_context(eval_context['env'].context)
            //     res = runner(run_self, eval_context=eval_context)
            // elif runner:
            //     active_id = self.env.context.get('active_id')
            //     if not active_id and self.env.context.get('onchange_self'):
            //         active_id = self.env.context['onchange_self']._origin.id
            //         if not active_id:  # onchange on new record
            //             res = runner(self, eval_context=eval_context)
            //     active_ids = self.env.context.get('active_ids', [active_id] if active_id else [])
            //     for active_id in active_ids:
            //         # run context dedicated to a particular active_id
            //         run_self = self.with_context(active_ids=[active_id], active_id=active_id)
            //         eval_context['env'] = eval_context['env'](context=run_self.env.context)
            //         eval_context['records'] = eval_context['record'] = records.browse(active_id)
            //         res = runner(run_self, eval_context=eval_context)
            // else:
            //     _logger.warning(
            //         "Found no way to execute server action %r of type %r, ignoring it. "
            //         "Verify that the type is correct or add a method called "
            //         "`_run_action_<type>` or `_run_action_<type>_multi`.",
            //         self.name, self.state
            //     )
            // return res or False
            */
            return default;
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

        protected async Task<IrActServer> SetCrudModelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _set_crud_model_id(self):
            // invalid = self.filtered(lambda a: a.state == 'object_copy' and a.resource_ref and a.resource_ref._name != a.crud_model_id.model)
            // invalid.resource_ref = False
            // invalid = self.filtered(lambda a: a.link_field_id and not (
            //     a.link_field_id.model == a.model_id.model and a.link_field_id.relation == a.crud_model_id.model
            // ))
            // invalid.link_field_id = False
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

        protected async Task<IrActServer> TraversePathInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _traverse_path(self):
            // """ Traverse the update_path to find the target model and field.
            // 
            // :return: a tuple (model, field) where model is the target model and field is the target field
            // """
            // self.ensure_one()
            // field_chain, _field_chain_str = self._get_relation_chain("update_path")
            // last_field = field_chain[-1]
            // model_id = self.env['ir.model']._get(last_field.model_name)
            // field_id = self.env['ir.model.fields']._get(last_field.model_name, last_field.name)
            // return model_id, field_id
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

        protected async Task<IrActServer> WarningDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py) ---
            // def _warning_depends(self):
            // return super()._warning_depends() + [
            //     'model_id',
            //     'base_automation_id',
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py) ---
            // def _warning_depends(self):
            // return super()._warning_depends() + [
            //     'activity_date_deadline_range',
            //     'model_id',
            //     'template_id',
            //     'state',
            //     'followers_type',
            //     'followers_partner_field_name',
            //     'activity_user_type',
            //     'activity_user_field_name',
            // ]
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py) ---
            // def _warning_depends(self):
            // return super()._warning_depends() + [
            //     'model_id',
            //     'state',
            //     'sms_template_id',
            // ]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _warning_depends(self):
            // return [
            //     'state',
            //     'model_id',
            //     'group_ids',
            //     'parent_id',
            //     'child_ids.warning',
            //     'child_ids.model_id',
            //     'child_ids.group_ids',
            //     'update_path',
            //     'update_field_type',
            //     'evaluation_type',
            //     'webhook_field_ids'
            // ]
            */
            return default;
        }
    }
}