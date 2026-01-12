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
    [Module("base", Category = "Base")]
    public class IrActionsActionsAppService : ApplicationService, IIrActionsActionsAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrActionsActionsAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionConfigureExternalReportLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _action_configure_external_report_layout(self, report_action, xml_id="web.action_base_document_layout_configurator"):
            // action = self.env["ir.actions.actions"]._for_xml_id(xml_id)
            // py_ctx = json.loads(action.get('context', {}))
            // report_action['close_on_report_download'] = True
            // py_ctx['report_action'] = report_action
            // action['context'] = py_ctx
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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
            return default;
        }

        public async Task<TEntity> ActionOpenScheduledActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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
            return default;
        }

        public async Task<TEntity> AssociatedViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def associated_view(self):
            // """Used in the ir.actions.report form view in order to search naively after the view(s)
            // used in the rendering.
            // """
            // self.ensure_one()
            // action_ref = self.env.ref('base.action_ui_view')
            // if not action_ref or len(self.report_name.split('.')) < 2:
            //     return False
            // action_data = action_ref.read()[0]
            // action_data['domain'] = [('name', 'ilike', self.report_name.split('.')[1]), ('type', '=', 'qweb')]
            // return action_data
            */
            return default;
        }

        public async Task<TEntity> BarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode_type, object @value) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def barcode(self, barcode_type, value, **kwargs):
            // defaults = {
            //     'width': (600, int),
            //     'height': (100, int),
            //     'humanreadable': (False, lambda x: bool(int(x))),
            //     'quiet': (True, lambda x: bool(int(x))),
            //     'mask': (None, lambda x: x),
            //     'barBorder': (4, int),
            //     # The QR code can have different layouts depending on the Error Correction Level
            //     # See: https://en.wikipedia.org/wiki/QR_code#Error_correction
            //     # Level 'L' – up to 7% damage   (default)
            //     # Level 'M' – up to 15% damage  (i.e. required by l10n_ch QR bill)
            //     # Level 'Q' – up to 25% damage
            //     # Level 'H' – up to 30% damage
            //     'barLevel': ('L', lambda x: x in ('L', 'M', 'Q', 'H') and x or 'L'),
            // }
            // kwargs = {k: validator(kwargs.get(k, v)) for k, (v, validator) in defaults.items()}
            // kwargs['humanReadable'] = kwargs.pop('humanreadable')
            // if kwargs['humanReadable']:
            //     kwargs['fontName'] = get_barcode_font()
            // 
            // if kwargs['width'] * kwargs['height'] > 1200000 or max(kwargs['width'], kwargs['height']) > 10000:
            //     raise ValueError("Barcode too large")
            // 
            // if barcode_type == 'UPCA' and len(value) in (11, 12, 13):
            //     barcode_type = 'EAN13'
            //     if len(value) in (11, 12):
            //         value = '0%s' % value
            // elif barcode_type == 'auto':
            //     symbology_guess = {8: 'EAN8', 13: 'EAN13'}
            //     barcode_type = symbology_guess.get(len(value), 'Code128')
            // elif barcode_type == 'QR':
            //     # for `QR` type, `quiet` is not supported. And is simply ignored.
            //     # But we can use `barBorder` to get a similar behaviour.
            //     # quiet=True & barBorder=4 by default cf above, remove border only if quiet=False
            //     if not kwargs['quiet']:
            //         kwargs['barBorder'] = 0
            // 
            // if barcode_type in ('EAN8', 'EAN13') and not check_barcode_encoding(value, barcode_type):
            //     # If the barcode does not respect the encoding specifications, convert its type into Code128.
            //     # Otherwise, the report-lab method may return a barcode different from its value. For instance,
            //     # if the barcode type is EAN-8 and the value 11111111, the report-lab method will take the first
            //     # seven digits and will compute the check digit, which gives: 11111115 -> the barcode does not
            //     # match the expected value.
            //     barcode_type = 'Code128'
            // 
            // try:
            //     barcode = createBarcodeDrawing(barcode_type, value=value, format='png', **kwargs)
            // 
            //     # If a mask is asked and it is available, call its function to
            //     # post-process the generated QR-code image
            //     if kwargs['mask']:
            //         available_masks = self.get_available_barcode_masks()
            //         mask_to_apply = available_masks.get(kwargs['mask'])
            //         if mask_to_apply:
            //             mask_to_apply(kwargs['width'], kwargs['height'], barcode)
            // 
            //     return barcode.asString('png')
            // except (ValueError, AttributeError):
            //     if barcode_type == 'Code128':
            //         raise ValueError("Cannot convert into barcode.")
            //     elif barcode_type == 'QR':
            //         raise ValueError("Cannot convert into QR code.")
            //     else:
            //         return self.barcode('Code128', value, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> BuildWkhtmltopdfArgsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid paperformat_id, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _build_wkhtmltopdf_args(
            //     self,
            //     paperformat_id,
            //     landscape,
            //     specific_paperformat_args=None,
            //     set_viewport_size=False):
            // '''Build arguments understandable by wkhtmltopdf bin.
            // 
            // :param paperformat_id: A report.paperformat record.
            // :param landscape: Force the report orientation to be landscape.
            // :param specific_paperformat_args: A dictionary containing prioritized wkhtmltopdf arguments.
            // :param set_viewport_size: Enable a viewport sized '1024x1280' or '1280x1024' depending of landscape arg.
            // :return: A list of string representing the wkhtmltopdf process command args.
            // '''
            // if landscape is None and specific_paperformat_args and specific_paperformat_args.get('data-report-landscape'):
            //     landscape = specific_paperformat_args.get('data-report-landscape')
            // 
            // command_args = ['--disable-local-file-access']
            // if set_viewport_size:
            //     command_args.extend(['--viewport-size', landscape and '1024x1280' or '1280x1024'])
            // 
            // # Less verbose error messages
            // command_args.extend(['--quiet'])
            // 
            // # Build paperformat args
            // if paperformat_id:
            //     if paperformat_id.format and paperformat_id.format != 'custom':
            //         command_args.extend(['--page-size', paperformat_id.format])
            // 
            //     if paperformat_id.page_height and paperformat_id.page_width and paperformat_id.format == 'custom':
            //         command_args.extend(['--page-width', str(paperformat_id.page_width) + 'mm'])
            //         command_args.extend(['--page-height', str(paperformat_id.page_height) + 'mm'])
            // 
            //     if specific_paperformat_args and 'data-report-margin-top' in specific_paperformat_args:
            //         command_args.extend(['--margin-top', str(specific_paperformat_args['data-report-margin-top'])])
            //     else:
            //         command_args.extend(['--margin-top', str(paperformat_id.margin_top)])
            // 
            //     dpi = None
            //     if specific_paperformat_args and specific_paperformat_args.get('data-report-dpi'):
            //         dpi = int(specific_paperformat_args['data-report-dpi'])
            //     elif paperformat_id.dpi:
            //         if os.name == 'nt' and int(paperformat_id.dpi) <= 95:
            //             _logger.info("Generating PDF on Windows platform require DPI >= 96. Using 96 instead.")
            //             dpi = 96
            //         else:
            //             dpi = paperformat_id.dpi
            //     if dpi:
            //         command_args.extend(['--dpi', str(dpi)])
            //         if _wkhtml().dpi_zoom_ratio:
            //             command_args.extend(['--zoom', str(96.0 / dpi)])
            // 
            //     if specific_paperformat_args and 'data-report-header-spacing' in specific_paperformat_args:
            //         command_args.extend(['--header-spacing', str(specific_paperformat_args['data-report-header-spacing'])])
            //     elif paperformat_id.header_spacing:
            //         command_args.extend(['--header-spacing', str(paperformat_id.header_spacing)])
            // 
            //     command_args.extend(['--margin-left', str(paperformat_id.margin_left)])
            // 
            //     if specific_paperformat_args and 'data-report-margin-bottom' in specific_paperformat_args:
            //         command_args.extend(['--margin-bottom', str(specific_paperformat_args['data-report-margin-bottom'])])
            //     else:
            //         command_args.extend(['--margin-bottom', str(paperformat_id.margin_bottom)])
            // 
            //     command_args.extend(['--margin-right', str(paperformat_id.margin_right)])
            //     if not landscape and paperformat_id.orientation:
            //         command_args.extend(['--orientation', str(paperformat_id.orientation)])
            //     if paperformat_id.header_line:
            //         command_args.extend(['--header-line'])
            //     if paperformat_id.disable_shrinking:
            //         command_args.extend(['--disable-smart-shrinking'])
            // 
            // # Add extra time to allow the page to render
            // delay = self.env['ir.config_parameter'].sudo().get_param('report.print_delay', '1000')
            // command_args.extend(['--javascript-delay', delay])
            // 
            // if landscape:
            //     command_args.extend(['--orientation', 'landscape'])
            // 
            // return command_args
            */
            return default;
        }

        public async Task<TEntity> CanExecuteActionOnRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> CheckChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> CheckModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_model(self):
            // for action in self:
            //     if action.res_model not in self.env:
            //         raise ValidationError(_('Invalid model name “%s” in action definition.', action.res_model))
            //     if action.binding_model_id and action.binding_model_id.model not in self.env:
            //         raise ValidationError(_('Invalid model name “%s” in action definition.', action.binding_model_id.model))
            */
            return default;
        }

        public async Task<TEntity> CheckPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_path(self):
            // for action in self:
            //     if action.path:
            //         if not re.fullmatch(r'[a-z][a-z0-9_-]*', action.path):
            //             raise ValidationError(_('The path should contain only lowercase alphanumeric characters, underscore, and dash, and it should start with a letter.'))
            //         if action.path.startswith("m-"):
            //             raise ValidationError(_("'m-' is a reserved prefix."))
            //         if action.path.startswith("action-"):
            //             raise ValidationError(_("'action-' is a reserved prefix."))
            //         if action.path == "new":
            //             raise ValidationError(_("'new' is reserved, and can not be used as path."))
            //         # Tables ir_act_window, ir_act_report_xml, ir_act_url, ir_act_server and ir_act_client
            //         # inherit from table ir_actions (see base_data.sql). The path must be unique across
            //         # all these tables. The unique constraint is not enough because a big limitation of
            //         # the inheritance feature is that unique indexes only apply to single tables, and
            //         # not accross all the tables. So we need to check the uniqueness of the path manually.
            //         # For more information, see: https://www.postgresql.org/docs/14/ddl-inherit.html#DDL-INHERIT-CAVEATS
            // 
            //         # Note that, we leave the unique constraint in place to check the uniqueness of the path
            //         # within the same table before checking the uniqueness across all the tables.
            //         if (self.env['ir.actions.actions'].search_count([('path', '=', action.path)]) > 1):
            //             raise ValidationError(_("Path to show in the URL must be unique! Please choose another one."))
            */
            return default;
        }

        public async Task<TEntity> CheckPythonCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> CheckViewModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _check_view_mode(self):
            // for rec in self:
            //     modes = rec.view_mode.split(',')
            //     if len(modes) != len(set(modes)):
            //         raise ValidationError(_('The modes in view_mode must not be duplicated: %s', modes))
            //     if ' ' in modes:
            //         raise ValidationError(_('No spaces allowed in view_mode: “%s”', modes))
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_allowed_states(self):
            // self.allowed_states = [value for value, __ in self._fields['state'].selection]
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableModelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_available_model_ids(self):
            // allowed_models = self.env['ir.model'].search(
            //     [('model', 'in', list(self.env['ir.model.access']._get_allowed_models()))]
            // )
            // self.available_model_ids = allowed_models.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeCrudRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_embedded_actions(self):
            // embedded_actions = self.env["ir.embedded.actions"].search([('parent_action_id', 'in', self.ids)]).filtered(lambda x: x.is_visible)
            // for action in self:
            //     action.embedded_action_ids = embedded_actions.filtered(lambda rec: rec.parent_action_id == action)
            */
            return default;
        }

        public async Task<TEntity> ComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _compute_model_id(self):
            // for action in self:
            //     action.model_id = self.env['ir.model']._get(action.model).id
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_params(self):
            // self_bin = self.with_context(bin_size=False, bin_size_params_store=False)
            // for record, record_bin in zip(self, self_bin):
            //     record.params = record_bin.params_store and safe_eval(record_bin.params_store, {'uid': self.env.uid})
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCodeHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeValueFieldToShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_views(self):
            // """ Compute an ordered list of the specific view modes that should be
            //     enabled when displaying the result of this action, along with the
            //     ID of the specific view to use for each mode, if any were required.
            // 
            //     This function hides the logic of determining the precedence between
            //     the view_modes string, the view_ids o2m, and the view_id m2o that
            //     can be set on the action.
            // """
            // for act in self:
            //     act.views = [(view.view_id.id, view.view_mode) for view in act.view_ids]
            //     got_modes = [view.view_mode for view in act.view_ids]
            //     all_modes = act.view_mode.split(',')
            //     missing_modes = [mode for mode in all_modes if mode not in got_modes]
            //     if missing_modes:
            //         if act.view_id.type in missing_modes:
            //             # reorder missing modes to put view_id first if present
            //             missing_modes.remove(act.view_id.type)
            //             act.views.append((act.view_id.id, act.view_id.type))
            //         act.views.extend([(False, mode) for mode in missing_modes])
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeWebhookSamplePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ComputeXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _compute_xml_id(self):
            // res = self.get_external_id()
            // for record in self:
            //     record.xml_id = res.get(record.id)
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IIrActionsActionsable
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
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def create_action(self):
            // """ Create a contextual action for each server action. """
            // for action in self:
            //     action.write({'binding_model_id': action.model_id.id,
            //                   'binding_type': 'action'})
            // return True
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def create_action(self):
            // """ Create a contextual action for each report. """
            // for report in self:
            //     model = self.env['ir.model']._get(report.model)
            //     report.write({'binding_model_id': model.id, 'binding_type': 'report'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // # self.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def create(self, vals_list):
            // self.env.registry.clear_cache()
            // for vals in vals_list:
            //     if not vals.get('name') and vals.get('res_model'):
            //         vals['name'] = self.env[vals['res_model']]._description
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if parent_id := vals.get('parent_id'):
            //         parent = self.browse(parent_id)
            //         vals['model_id'] = parent.model_id.id
            //         vals['group_ids'] = parent.group_ids.ids
            // actions = super().create(vals_list)
            // 
            // # create first history entries
            // history_vals = []
            // for action, vals in zip(actions, vals_list):
            //     if "code" in vals:
            //         history_vals.append({"action_id": action.id, "code": vals.get("code")})
            // if history_vals:
            //     self.env["ir.actions.server.history"].create(history_vals)
            // 
            // return actions
            */
            return default;
        }

        public async Task<TEntity> DefaultUpdatePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> EvalValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> ExistingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _existing(self):
            // self.env.cr.execute("SELECT id FROM %s" % self._table)
            // return {row[0] for row in self.env.cr.fetchall()}
            */
            return default;
        }

        public async Task<TEntity> ExistsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def exists(self):
            // ids = self._existing()
            // existing = self.filtered(lambda rec: rec.id in ids)
            // return existing
            */
            return default;
        }

        public async Task<TEntity> ForXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid full_xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _for_xml_id(self, full_xml_id):
            // """ Returns the action content for the provided xml_id
            // 
            // :param full_xml_id: the namespace-less id of the action (the @id
            //     attribute from the XML file)
            // :return: A read() view of the ir.actions.action safe for web use
            // """
            // record = self.env.ref(full_xml_id)
            // assert isinstance(self.env[record._name], self.env.registry[self._name])
            // return record._get_action_dict()
            */
            return default;
        }

        public async Task<TEntity> GenerateActionNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
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

        public async Task<TEntity> GetActionDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_action_dict(self):
            // """ Returns the action content for the provided action record.
            // """
            // self.ensure_one()
            // readable_fields = self._get_readable_fields()
            // return {
            //     field: value
            //     for field, value in self.sudo().read()[0].items()
            //     if field in readable_fields
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_action_dict(self):
            // """ Override to return action content with detailed embedded actions data if available.
            // 
            //     :return: A dict with updated action dictionary including embedded actions information.
            // """
            // result = super()._get_action_dict()
            // if embedded_action_ids := result["embedded_action_ids"]:
            //     EmbeddedActions = self.env["ir.embedded.actions"]
            //     embedded_fields = EmbeddedActions._get_readable_fields()
            //     result["embedded_action_ids"] = EmbeddedActions.browse(embedded_action_ids).read(embedded_fields)
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetAvailableBarcodeMasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_available_barcode_masks(self):
            // """ Hook for extension.
            // 
            // This function returns the available QR-code masks, in the form of a
            // list of (code, mask_function) elements, where code is a string identifying
            // the mask uniquely, and mask_function is a function returning a reportlab
            // Drawing object with the result of the mask, and taking as parameters:
            // 
            //     - width of the QR-code, in pixels
            //     - height of the QR-code, in pixels
            //     - reportlab Drawing object containing the barcode to apply the mask on
            // """
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetBindingsAsync<TEntity>(IEnumerable<TEntity> entities, object model_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def get_bindings(self, model_name):
            // """ Retrieve the list of actions bound to the given model.
            // 
            //    :return: a dict mapping binding types to a list of dict describing
            //             actions, where the latter is given by calling the method
            //             ``read`` on the action record.
            // """
            // result = {}
            // for action_type, all_actions in self._get_bindings(model_name).items():
            //     actions = []
            //     for action in all_actions:
            //         action = dict(action)
            //         groups = action.pop('group_ids', None)
            //         if groups and not any(self.env.user.has_group(ext_id) for ext_id in groups):
            //             # the user may not perform this action
            //             continue
            //         res_model = action.pop('res_model', None)
            //         if res_model and not self.env['ir.model.access'].check(
            //             res_model,
            //             mode='read',
            //             raise_exception=False
            //         ):
            //             # the user won't be able to read records
            //             continue
            //         actions.append(action)
            //     if actions:
            //         result[action_type] = actions
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetBindingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_bindings(self, model_name):
            // cr = self.env.cr
            // 
            // # discard unauthorized actions, and read action definitions
            // result = defaultdict(list)
            // 
            // self.env.flush_all()
            // cr.execute("""
            //     SELECT a.id, a.type, a.binding_type
            //       FROM ir_actions a
            //       JOIN ir_model m ON a.binding_model_id = m.id
            //      WHERE m.model = %s
            //   ORDER BY a.id
            // """, [model_name])
            // for action_id, action_model, binding_type in cr.fetchall():
            //     try:
            //         action = self.env[action_model].sudo().browse(action_id)
            //         fields = ['name', 'binding_view_types']
            //         for field in ('group_ids', 'res_model', 'sequence', 'domain'):
            //             if field in action._fields:
            //                 fields.append(field)
            //         action = action.read(fields)[0]
            //         if action.get('group_ids'):
            //             # transform the list of ids into a list of xml ids
            //             groups = self.env['res.groups'].browse(action['group_ids'])
            //             action['group_ids'] = list(groups._ensure_xml_id().values())
            //         if 'domain' in action and not action.get('domain'):
            //             action.pop('domain')
            //         result[binding_type].append(frozendict(action))
            //     except (MissingError):
            //         continue
            // 
            // # sort actions by their sequence if sequence available
            // if result.get('action'):
            //     result['action'] = tuple(sorted(result['action'], key=lambda vals: vals.get('sequence', 0)))
            // return frozendict(result)
            */
            return default;
        }

        public async Task<TEntity> GetChildrenDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
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

        public async Task<TEntity> GetEvalContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_eval_context(self, action=None):
            // """ evaluation context to pass to safe_eval """
            // return {
            //     'uid': self.env.uid,
            //     'user': self.env.user,
            //     'time': tools.safe_eval.time,
            //     'datetime': tools.safe_eval.datetime,
            //     'dateutil': tools.safe_eval.dateutil,
            //     'timezone': timezone,
            //     'float_compare': float_compare,
            //     'b64encode': base64.b64encode,
            //     'b64decode': base64.b64decode,
            //     'Command': Command,
            // }
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

        public async Task<TEntity> GetLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_layout(self):
            // return self.env.ref('web.minimal_layout', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_paperformat(self):
            // return self.paperformat_id or self.env.company.paperformat_id
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatByXmlidAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_paperformat_by_xmlid(self, xml_id):
            // return self.env.ref(xml_id).get_paperformat() if xml_id else self.env.company.paperformat_id
            */
            return default;
        }

        public async Task<TEntity> GetReadableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // """ return the list of fields that are safe to read
            // 
            // Fetched via /web/action/load or _for_xml_id method
            // Only fields used by the web client should included
            // Accessing content useful for the server-side must
            // be done manually with superuser
            // """
            // return {
            //     "binding_model_id", "binding_type", "binding_view_types",
            //     "display_name", "help", "id", "name", "type", "xml_id",
            //     "path",
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "context", "cache", "mobile_view_mode", "domain", "filter", "group_ids", "limit",
            //     "res_id", "res_model", "search_view_id", "target", "view_id", "view_mode", "views", "embedded_action_ids",
            //     # this is used by frontend, with the document layout wizard before send and print
            //     "close_on_report_download",
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     # 'effect' and 'infos' are not real fields of `ir.actions.act_window_close` but they are
            //     # used to display the rainbowman ('effect') and waited by the action_service ('infos').
            //     "effect", "infos"
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "target", "url", "close",
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "group_ids", "model_name",
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "context", "params", "res_model", "tag", "target",
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "report_name", "report_type", "target",
            //     # these two are not real fields of ir.actions.report but are
            //     # expected in the route /report/<converter>/<reportname> and must
            //     # not be removed by clean_action
            //     "context", "data",
            //     # and this one is used by the frontend later on.
            //     "close_on_report_download",
            //     "domain",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRelationChainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object searched_field_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> GetRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_rendering_context(self, report, docids, data):
            // # If the report is using a custom model to render its html, we must use it.
            // # Otherwise, fallback on the generic html rendering.
            // report_model = self._get_rendering_context_model(report)
            // 
            // data = data and dict(data) or {}
            // 
            // if report_model is not None:
            //     data.update(report_model._get_report_values(docids, data=data))
            // else:
            //     docs = self.env[report.model].browse(docids)
            //     data.update({
            //         'doc_ids': docids,
            //         'doc_model': report.model,
            //         'docs': docs,
            //     })
            // data['is_html_empty'] = is_html_empty
            // return data
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_rendering_context_model(self, report):
            // report_model_name = 'report.%s' % report.report_name
            // return self.env.get(report_model_name)
            */
            return default;
        }

        public async Task<TEntity> GetReportFromNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_name) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report_from_name(self, report_name):
            // """Get the first record of ir.actions.report having the ``report_name`` as value for
            // the field report_name.
            // """
            // report_obj = self.env['ir.actions.report']
            // conditions = [('report_name', '=', report_name)]
            // context = self.env['res.users'].context_get()
            // return report_obj.with_context(context).sudo().search(conditions, limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report(self, report_ref):
            // """Get the report (with sudo) from a reference
            // 
            // :param report_ref: can be one of
            // 
            //     - ir.actions.report id
            //     - ir.actions.report record
            //     - ir.model.data reference to ir.actions.report
            //     - ir.actions.report report_name
            // """
            // ReportSudo = self.env['ir.actions.report'].sudo()
            // if isinstance(report_ref, int):
            //     return ReportSudo.browse(report_ref)
            // if isinstance(report_ref, models.Model):
            //     if report_ref._name != self._name:
            //         raise ValueError("Expected report of type %s, got %s" % (self._name, report_ref._name))
            //     return report_ref.sudo()
            // report = ReportSudo.search([('report_name', '=', report_ref)], limit=1)
            // if report:
            //     return report
            // report = self.env.ref(report_ref)
            // if report:
            //     if report._name != "ir.actions.report":
            //         raise ValueError("Fetching report %r: type %s, expected ir.actions.report" % (report_ref, report._name))
            //     return report.sudo()
            // raise ValueError("Fetching report %r: report not found" % report_ref)
            */
            return default;
        }

        public async Task<TEntity> GetReportUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report_url(self, layout=None):
            // report_url = self.env['ir.config_parameter'].sudo().get_param('report.url')
            // return report_url or (layout or self._get_layout() or self).get_base_url()
            */
            return default;
        }

        public async Task<TEntity> GetRunnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> GetValidActionReportsAsync<TEntity>(IEnumerable<TEntity> entities, object model, List<Guid> record_ids) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_valid_action_reports(self, model, record_ids):
            // """ Return the list of ids of actions for which the domain is
            // satisfied by at least one record in record_ids.
            // :param model: the model of the records to validate
            // :param record_ids: list of ids of records to validate
            // """
            // records = self.env[model].browse(record_ids)
            // actions_with_domain = self.filtered('domain')
            // valid_action_report_ids = (self - actions_with_domain).ids  # actions without domain are always valid
            // for action in actions_with_domain:
            //     if records.filtered_domain(literal_eval(action.domain)):
            //         valid_action_report_ids.append(action.id)
            // return valid_action_report_ids
            */
            return default;
        }

        public async Task<TEntity> GetWarningMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
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

        public async Task<TEntity> GetWkhtmltopdfStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_wkhtmltopdf_state(self):
            // '''Get the current state of wkhtmltopdf: install, ok, upgrade, workers or broken.
            // * install: Starting state.
            // * upgrade: The binary is an older version (< 0.12.0).
            // * ok: A binary was found with a recent version (>= 0.12.0).
            // * workers: Not enough workers found to perform the pdf rendering process (< 2 workers).
            // * broken: A binary was found but not responding.
            // 
            // :return: wkhtmltopdf_state
            // '''
            // return _wkhtml().state
            */
            return default;
        }

        public async Task<TEntity> HandleMergePdfsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, object error_stream) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _handle_merge_pdfs_error(self, error=None, error_stream=None):
            // raise UserError(_("Odoo is unable to merge the generated PDFs."))
            */
            return default;
        }

        public async Task<TEntity> HistoryWizardActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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
            return default;
        }

        public async Task<TEntity> InverseParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _inverse_params(self):
            // for record in self:
            //     params = record.params
            //     record.params_store = repr(params) if isinstance(params, dict) else params
            */
            return default;
        }

        public async Task<TEntity> MergePdfsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object streams, object handle_error) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _merge_pdfs(self, streams, handle_error=_handle_merge_pdfs_error):
            // writer = PdfFileWriter()
            // for stream in streams:
            //     try:
            //         reader = PdfFileReader(stream)
            //         writer.appendPagesFromReader(reader)
            //     except (PdfReadError, TypeError, NotImplementedError, ValueError) as e:
            //         handle_error(error=e, error_stream=stream)
            // result_stream = io.BytesIO()
            // streams.append(result_stream)
            // try:
            //     writer.write(result_stream)
            // except PdfReadError:
            //     raise UserError(_("Odoo is unable to merge the generated PDFs."))
            // return result_stream
            */
            return default;
        }

        public async Task<TEntity> NameDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
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

        public async Task<TEntity> OnchangeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> PreRenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _pre_render_qweb_pdf(self, report_ref, res_ids=None, data=None):
            // if not data:
            //     data = {}
            // if isinstance(res_ids, int):
            //     res_ids = [res_ids]
            // data.setdefault('report_type', 'pdf')
            // # In case of test environment without enough workers to perform calls to wkhtmltopdf,
            // # fallback to render_html.
            // if (modules.module.current_test or tools.config['test_enable']) and not self.env.context.get('force_report_rendering'):
            //     return self._render_qweb_html(report_ref, res_ids, data=data)
            // 
            // self = self.with_context(webp_as_jpg=True)
            // return self._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids), 'pdf'
            */
            return default;
        }

        public async Task<TEntity> PrepareHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object report_model) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_html(self, html, report_model=False):
            // '''Divide and recreate the header/footer html by merging all found in html.
            // The bodies are extracted and added to a list. Then, extract the specific_paperformat_args.
            // The idea is to put all headers/footers together. Then, we will use a javascript trick
            // (see minimal_layout template) to set the right header/footer during the processing of wkhtmltopdf.
            // This allows the computation of multiple reports in a single call to wkhtmltopdf.
            // '''
            // 
            // # Return empty dictionary if 'web.minimal_layout' not found.
            // layout = self._get_layout()
            // if not layout:
            //     return {}
            // base_url = self._get_report_url(layout=layout)
            // 
            // root = lxml.html.fromstring(html, parser=lxml.html.HTMLParser(encoding='utf-8'))
            // match_klass = "//div[contains(concat(' ', normalize-space(@class), ' '), ' {} ')]"
            // 
            // header_node = etree.Element('div', id='minimal_layout_report_headers')
            // footer_node = etree.Element('div', id='minimal_layout_report_footers')
            // bodies = []
            // res_ids = []
            // 
            // body_parent = root.xpath('//main')[0]
            // # Retrieve headers
            // for node in root.xpath(match_klass.format('header')):
            //     body_parent = node.getparent()
            //     node.getparent().remove(node)
            //     header_node.append(node)
            // 
            // # Retrieve footers
            // for node in root.xpath(match_klass.format('footer')):
            //     body_parent = node.getparent()
            //     node.getparent().remove(node)
            //     footer_node.append(node)
            // 
            // # Retrieve bodies
            // for node in root.xpath(match_klass.format('article')):
            //     # set context language to body language
            //     IrQweb = self.env['ir.qweb']
            //     if node.get('data-oe-lang'):
            //         IrQweb = IrQweb.with_context(lang=node.get('data-oe-lang'))
            //     body = IrQweb._render(layout.id, {
            //             'subst': False,
            //             'body': Markup(lxml.html.tostring(node, encoding='unicode')),
            //             'base_url': base_url,
            //             'report_xml_id': self.xml_id,
            //             'debug': self.env.context.get("debug"),
            //         }, raise_if_not_found=False)
            //     bodies.append(body)
            //     if node.get('data-oe-model') == report_model:
            //         res_ids.append(int(node.get('data-oe-id', 0)))
            //     else:
            //         res_ids.append(None)
            // 
            // if not bodies:
            //     body = ''.join(lxml.html.tostring(c, encoding='unicode') for c in body_parent.getchildren())
            //     bodies.append(body)
            // 
            // # Get paperformat arguments set in the root html tag. They are prioritized over
            // # paperformat-record arguments.
            // specific_paperformat_args = {}
            // for attribute in root.items():
            //     if attribute[0].startswith('data-report-'):
            //         specific_paperformat_args[attribute[0]] = attribute[1]
            // 
            // header = self.env['ir.qweb']._render(layout.id, {
            //     'subst': True,
            //     'body': Markup(lxml.html.tostring(header_node, encoding='unicode')),
            //     'base_url': base_url,
            //     'report_xml_id': self.xml_id,
            //     'debug': self.env.context.get("debug"),
            // })
            // footer = self.env['ir.qweb']._render(layout.id, {
            //     'subst': True,
            //     'body': Markup(lxml.html.tostring(footer_node, encoding='unicode')),
            //     'base_url': base_url,
            //     'report_xml_id': self.xml_id,
            //     'debug': self.env.context.get("debug"),
            // })
            // 
            // return bodies, res_ids, header, footer, specific_paperformat_args
            */
            return default;
        }

        public async Task<TEntity> PrepareLocalAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_local_attachments(self, attachments):
            // for attachment in attachments:
            //     if attachment._is_remote_source():
            //         try:
            //             attachment._migrate_remote_to_local()
            //         except (ValidationError, requests.exceptions.RequestException) as e:
            //             _logger.error("Failed to migrate attachment %s to local: %s", attachment.id, e)
            // return attachments.filtered(lambda a: not a._is_remote_source())
            */
            return default;
        }

        public async Task<TEntity> PreparePdfReportAttachmentValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object streams) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_pdf_report_attachment_vals_list(self, report, streams):
            // """Hook to prepare attachment values needed for attachments creation
            // during the pdf report generation.
            // 
            // :param report: The report (with sudo) from a reference report_ref.
            // :param streams: Dict of streams for each report containing the pdf content and existing attachments.
            // :return: attachment values list needed for attachments creation.
            // """
            // attachment_vals_list = []
            // for res_id, stream_data in streams.items():
            //     # An attachment already exists.
            //     if stream_data['attachment']:
            //         continue
            // 
            //     # if res_id is false
            //     # we are unable to fetch the record, it won't be saved as we can't split the documents unambiguously
            //     if not res_id or not stream_data['stream']:
            //         _logger.warning(
            //             "These documents were not saved as an attachment because the template of %s doesn't "
            //             "have any headers seperating different instances of it. If you want it saved,"
            //             "please print the documents separately", report.report_name)
            //         continue
            //     record = self.env[report.model].browse(res_id)
            //     attachment_name = safe_eval(report.attachment, {'object': record, 'time': time})
            // 
            //     # Unable to compute a name for the attachment.
            //     if not attachment_name:
            //         continue
            // 
            //     attachment_vals_list.append({
            //         'name': attachment_name,
            //         'raw': stream_data['stream'].getvalue(),
            //         'res_model': report.model,
            //         'res_id': record.id,
            //         'type': 'binary',
            //     })
            // return attachment_vals_list
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def read(self, fields=None, load='_classic_read'):
            // """ call the method get_empty_list_help of the model and set the window action help message
            // """
            // result = super().read(fields, load=load)
            // if not fields or 'help' in fields:
            //     for values in result:
            //         model = values.get('res_model')
            //         if model in self.env:
            //             eval_ctx = dict(self.env.context)
            //             try:
            //                 ctx = safe_eval(values.get('context', '{}'), eval_ctx)
            //             except:
            //                 ctx = {}
            //             values['help'] = self.with_context(**ctx).env[model].get_empty_list_help(values.get('help', ''))
            // return result
            */
            return default;
        }

        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render(self, report_ref, res_ids, data=None):
            // report = self._get_report(report_ref)
            // report_type = report.report_type.lower().replace('-', '_')
            // render_func = getattr(self, '_render_' + report_type, None)
            // if not render_func:
            //     return None
            // return render_func(report_ref, res_ids, data=data)
            */
            return default;
        }

        public async Task<TEntity> RenderQwebHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_html(self, report_ref, docids, data=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'html')
            // report = self._get_report(report_ref)
            // data = self._get_rendering_context(report, docids, data)
            // return self._render_template(report.report_name, data), 'html'
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf(self, report_ref, res_ids=None, data=None):
            // if not data:
            //     data = {}
            // if isinstance(res_ids, int):
            //     res_ids = [res_ids]
            // data.setdefault('report_type', 'pdf')
            // 
            // collected_streams, report_type = self._pre_render_qweb_pdf(report_ref, res_ids=res_ids, data=data)
            // if report_type != 'pdf':
            //     return collected_streams, report_type
            // 
            // has_duplicated_ids = res_ids and len(res_ids) != len(set(res_ids))
            // 
            // # access the report details with sudo() but keep evaluation context as current user
            // report_sudo = self._get_report(report_ref)
            // 
            // # Generate the ir.attachment if needed.
            // if not has_duplicated_ids and report_sudo.attachment and not self.env.context.get("report_pdf_no_attachment"):
            //     attachment_vals_list = self._prepare_pdf_report_attachment_vals_list(report_sudo, collected_streams)
            //     if attachment_vals_list:
            //         attachment_names = ', '.join(x['name'] for x in attachment_vals_list)
            //         try:
            //             self.env['ir.attachment'].create(attachment_vals_list)
            //         except AccessError:
            //             _logger.info("Cannot save PDF report %r attachments for user %r", attachment_names, self.env.user.display_name)
            //         else:
            //             _logger.info("The PDF documents %r are now saved in the database", attachment_names)
            // 
            // def custom_handle_merge_pdfs_error(error, error_stream):
            //     error_record_ids.append(stream_to_ids[error_stream])
            // 
            // stream_to_ids = {v['stream']: k for k, v in collected_streams.items() if v['stream']}
            // # Merge all streams together for a single record.
            // streams_to_merge = list(stream_to_ids.keys())
            // error_record_ids = []
            // 
            // if len(streams_to_merge) == 1:
            //     pdf_content = streams_to_merge[0].getvalue()
            // else:
            //     with self._merge_pdfs(streams_to_merge, custom_handle_merge_pdfs_error) as pdf_merged_stream:
            //         pdf_content = pdf_merged_stream.getvalue()
            // 
            // if error_record_ids:
            //     action = {
            //         'type': 'ir.actions.act_window',
            //         'name': _('Problematic record(s)'),
            //         'res_model': report_sudo.model,
            //         'domain': [('id', 'in', error_record_ids)],
            //         'views': [(False, 'list'), (False, 'form')],
            //     }
            //     num_errors = len(error_record_ids)
            //     if num_errors == 1:
            //         action.update({
            //             'views': [(False, 'form')],
            //             'res_id': error_record_ids[0],
            //         })
            //     raise RedirectWarning(
            //         message=_('Odoo is unable to merge the generated PDFs because of %(num_errors)s corrupted file(s)', num_errors=num_errors),
            //         action=action,
            //         button_text=_('View Problematic Record(s)'),
            //     )
            // 
            // for stream in streams_to_merge:
            //     stream.close()
            // 
            // if res_ids:
            //     _logger.info("The PDF report has been generated for model: %s, records %s.", report_sudo.model, str(res_ids))
            // 
            // return pdf_content, 'pdf'
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfPrepareStreamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object data, List<Guid> res_ids) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'pdf')
            // 
            // # access the report details with sudo() but evaluation context as current user
            // report_sudo = self._get_report(report_ref)
            // has_duplicated_ids = res_ids and len(res_ids) != len(set(res_ids))
            // 
            // collected_streams = OrderedDict()
            // 
            // # Fetch the existing attachments from the database for later use.
            // # Reload the stream from the attachment in case of 'attachment_use'.
            // if res_ids:
            //     records = self.env[report_sudo.model].browse(res_ids)
            //     for record in records:
            //         res_id = record.id
            //         if res_id in collected_streams:
            //             continue
            // 
            //         stream = None
            //         attachment = None
            //         if not has_duplicated_ids and report_sudo.attachment and not self.env.context.get("report_pdf_no_attachment"):
            //             attachment = report_sudo.retrieve_attachment(record)
            // 
            //             # Extract the stream from the attachment.
            //             if attachment and report_sudo.attachment_use:
            //                 stream = io.BytesIO(attachment.raw)
            // 
            //                 # Ensure the stream can be saved in Image.
            //                 if attachment.mimetype.startswith('image'):
            //                     img = Image.open(stream)
            //                     new_stream = io.BytesIO()
            //                     img.convert("RGB").save(new_stream, format="pdf")
            //                     stream.close()
            //                     stream = new_stream
            // 
            //         collected_streams[res_id] = {
            //             'stream': stream,
            //             'attachment': attachment,
            //         }
            // 
            // # Call 'wkhtmltopdf' to generate the missing streams.
            // res_ids_wo_stream = [res_id for res_id, stream_data in collected_streams.items() if not stream_data['stream']]
            // all_res_ids_wo_stream = res_ids if has_duplicated_ids else res_ids_wo_stream
            // is_whtmltopdf_needed = not res_ids or res_ids_wo_stream
            // 
            // if is_whtmltopdf_needed:
            // 
            //     if self.get_wkhtmltopdf_state() == 'install':
            //         # wkhtmltopdf is not installed
            //         # the call should be catched before (cf /report/check_wkhtmltopdf) but
            //         # if get_pdf is called manually (email template), the check could be
            //         # bypassed
            //         raise UserError(_("Unable to find Wkhtmltopdf on this system. The PDF can not be created."))
            // 
            //     # Disable the debug mode in the PDF rendering in order to not split the assets bundle
            //     # into separated files to load. This is done because of an issue in wkhtmltopdf
            //     # failing to load the CSS/Javascript resources in time.
            //     # Without this, the header/footer of the reports randomly disappear
            //     # because the resources files are not loaded in time.
            //     # https://github.com/wkhtmltopdf/wkhtmltopdf/issues/2083
            //     additional_context = {'debug': False}
            //     data.setdefault("debug", False)
            // 
            //     html = self.with_context(**additional_context)._render_qweb_html(report_ref, all_res_ids_wo_stream, data=data)[0]
            // 
            //     bodies, html_ids, header, footer, specific_paperformat_args = report_sudo.with_context(**additional_context)._prepare_html(html, report_model=report_sudo.model)
            // 
            //     if not has_duplicated_ids and report_sudo.attachment and set(res_ids_wo_stream) != set(html_ids):
            //         raise UserError(_(
            //             "Report template “%s” has an issue, please contact your administrator. \n\n"
            //             "Cannot separate file to save as attachment because the report's template does not contain the"
            //             " attributes 'data-oe-model' and 'data-oe-id' as part of the div with 'article' classname.",
            //             report_sudo.name,
            //         ))
            // 
            //     pdf_content = self._run_wkhtmltopdf(
            //         bodies,
            //         report_ref=report_ref,
            //         header=header,
            //         footer=footer,
            //         landscape=self.env.context.get('landscape'),
            //         specific_paperformat_args=specific_paperformat_args,
            //         set_viewport_size=self.env.context.get('set_viewport_size'),
            //     )
            //     pdf_content_stream = io.BytesIO(pdf_content)
            // 
            //     # Printing a PDF report without any records. The content could be returned directly.
            //     if has_duplicated_ids or not res_ids:
            //         return {
            //             False: {
            //                 'stream': pdf_content_stream,
            //                 'attachment': None,
            //             }
            //         }
            // 
            //     # Split the pdf for each record using the PDF outlines.
            // 
            //     # Only one record: append the whole PDF.
            //     if len(res_ids_wo_stream) == 1:
            //         collected_streams[res_ids_wo_stream[0]]['stream'] = pdf_content_stream
            //         return collected_streams
            // 
            //     # In case of multiple docs, we need to split the pdf according the records.
            //     # In the simplest case of 1 res_id == 1 page, we use the PDFReader to print the
            //     # pages one by one.
            //     html_ids_wo_none = [x for x in html_ids if x]
            //     reader = PdfFileReader(pdf_content_stream)
            //     if reader.numPages == len(res_ids_wo_stream):
            //         for i in range(reader.numPages):
            //             attachment_writer = PdfFileWriter()
            //             attachment_writer.addPage(reader.getPage(i))
            //             stream = io.BytesIO()
            //             attachment_writer.write(stream)
            //             collected_streams[res_ids_wo_stream[i]]['stream'] = stream
            //         return collected_streams
            // 
            //     # In cases where the number of res_ids != the number of pages,
            //     # we split the pdf based on top outlines computed by wkhtmltopdf.
            //     # An outline is a <h?> html tag found on the document. To retrieve this table,
            //     # we look on the pdf structure using pypdf to compute the outlines_pages from
            //     # the top level heading in /Outlines.
            //     if len(res_ids_wo_stream) > 1 and set(res_ids_wo_stream) == set(html_ids_wo_none):
            //         root = reader.trailer['/Root']
            //         has_valid_outlines = '/Outlines' in root and '/First' in root['/Outlines']
            //         if not has_valid_outlines:
            //             return {False: {
            //                 'report_action': self,
            //                 'stream': pdf_content_stream,
            //                 'attachment': None,
            //             }}
            // 
            //         outlines_pages = []
            //         node = root['/Outlines']['/First']
            //         while True:
            //             outlines_pages.append(root['/Dests'][node['/Dest']][0])
            //             if '/Next' not in node:
            //                 break
            //             node = node['/Next']
            //         outlines_pages = sorted(set(outlines_pages))
            // 
            //         # The number of outlines must be equal to the number of records to be able to split the document.
            //         has_same_number_of_outlines = len(outlines_pages) == len(res_ids_wo_stream)
            // 
            //         # There should be a top-level heading on first page
            //         has_top_level_heading = outlines_pages[0] == 0
            // 
            //         if has_same_number_of_outlines and has_top_level_heading:
            //             # Split the PDF according to outlines.
            //             for i, num in enumerate(outlines_pages):
            //                 to = outlines_pages[i + 1] if i + 1 < len(outlines_pages) else reader.numPages
            //                 attachment_writer = PdfFileWriter()
            //                 for j in range(num, to):
            //                     attachment_writer.addPage(reader.getPage(j))
            //                 stream = io.BytesIO()
            //                 attachment_writer.write(stream)
            //                 collected_streams[res_ids_wo_stream[i]]['stream'] = stream
            //             return collected_streams
            //         else:
            //             for res_id in res_ids_wo_stream:
            //                 individual_collected_stream = self._render_qweb_pdf_prepare_streams(report_ref=report_ref, data=data, res_ids=[res_id])
            //                 collected_streams[res_id]['stream'] = individual_collected_stream[res_id]['stream']
            //     collected_streams[False] = {'stream': pdf_content_stream, 'attachment': None}
            // 
            // return collected_streams
            */
            return default;
        }

        public async Task<TEntity> RenderQwebTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_text(self, report_ref, docids, data=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'text')
            // report = self._get_report(report_ref)
            // data = self._get_rendering_context(report, docids, data)
            // return self._render_template(report.report_name, data), 'text'
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_template(self, template, values=None):
            // """Allow to render a QWeb template python-side. This function returns the 'ir.ui.view'
            // render but embellish it with some variables/methods used in reports.
            // :param values: additional methods/variables used in the rendering
            // :returns: html representation of the template
            // :rtype: bytes
            // """
            // if values is None:
            //     values = {}
            // 
            // # Browse the user instead of using the sudo self.env.user
            // user = self.env['res.users'].browse(self.env.uid)
            // view_obj = self.env['ir.ui.view'].with_context(inherit_branding=False)
            // values.update(
            //     time=time,
            //     context_timestamp=lambda t: fields.Datetime.context_timestamp(self.with_context(tz=user.tz), t),
            //     user=user,
            //     res_company=self.env.company,
            //     web_base_url=self.env['ir.config_parameter'].sudo().get_param('web.base.url', default=''),
            // )
            // return view_obj._render_template(template, values).encode()
            */
            return default;
        }

        public async Task<TEntity> ReportActionAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data, object config) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def report_action(self, docids, data=None, config=True):
            // """Return an action of type ir.actions.report.
            // 
            // :param docids: id/ids/browse record of the records to print (if not used, pass an empty list)
            // :param data:
            // :param bool config:
            // :rtype: bytes
            // """
            // context = self.env.context
            // if docids:
            //     if isinstance(docids, models.Model):
            //         active_ids = docids.ids
            //     elif isinstance(docids, int):
            //         active_ids = [docids]
            //     elif isinstance(docids, list):
            //         active_ids = docids
            //     context = dict(self.env.context, active_ids=active_ids)
            // 
            // report_action = {
            //     'context': context,
            //     'data': data,
            //     'type': 'ir.actions.report',
            //     'report_name': self.report_name,
            //     'report_type': self.report_type,
            //     'report_file': self.report_file,
            //     'name': self.name,
            // }
            // 
            // discard_logo_check = self.env.context.get('discard_logo_check')
            // if self.env.is_admin() and not self.env.company.external_report_layout_id and config and not discard_logo_check:
            //     return self._action_configure_external_report_layout(report_action)
            // 
            // return report_action
            */
            return default;
        }

        public async Task<TEntity> RetrieveAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def retrieve_attachment(self, record):
            // '''Retrieve an attachment for a specific record.
            // 
            // :param record: The record owning of the attachment.
            // :return: A recordset of length <=1 or None
            // '''
            // attachment_name = safe_eval(self.attachment, {'object': record, 'time': time}) if self.attachment else ''
            // if not attachment_name:
            //     return None
            // return self.env['ir.attachment'].search([
            //         ('name', '=', attachment_name),
            //         ('res_model', '=', self.model),
            //         ('res_id', '=', record.id)
            // ], limit=1)
            */
            return default;
        }

        public async Task<TEntity> RunActionCodeMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _run_action_code_multi(self, eval_context):
            // if not self.code:
            //     return
            // safe_eval(self.code.strip(), eval_context, mode="exec", filename=str(self))
            // return eval_context.get('action')
            */
            return default;
        }

        public async Task<TEntity> RunActionMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> RunActionObjectCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> RunActionObjectCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> RunActionObjectWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> RunActionWebhookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> RunAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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
            return default;
        }

        public async Task<TEntity> RunInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object eval_context) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<List<object>> RunWkhtmltoimageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object width, object height, object image_format) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _run_wkhtmltoimage(self, bodies, width, height, image_format="jpg") -> list[bytes | None]:
            // """
            // :param str bodies: valid html documents as strings
            // :param int width: width in pixels
            // :param int height: height in pixels
            // :param image_format: format of the image
            // :type image_format: typing.Literal['jpg', 'png']
            // """
            // if modules.module.current_test:
            //     return [None] * len(bodies)
            // wkhtmltoimage_version = _wkhtml().wkhtmltoimage_version
            // if not wkhtmltoimage_version or wkhtmltoimage_version < parse_version('0.12.0'):
            //     raise UserError(_('wkhtmltoimage 0.12.0^ is required in order to render images from html'))
            // command_args = [
            //     '--disable-local-file-access', '--disable-javascript',
            //     '--quiet',
            //     '--width', str(width), '--height', str(height),
            //     '--format', image_format,
            // ]
            // with ExitStack() as stack:
            //     files = []
            //     for body in bodies:
            //         (input_fd, input_path) = tempfile.mkstemp(suffix='.html', prefix='report_image_html_input.tmp.')
            //         (output_fd, output_path) = tempfile.mkstemp(suffix=f'.{image_format}', prefix='report_image_output.tmp.')
            //         stack.callback(os.remove, input_path)
            //         stack.callback(os.remove, output_path)
            //         os.close(output_fd)
            //         with closing(os.fdopen(input_fd, 'wb')) as input_file:
            //             input_file.write(body.encode())
            //         files.append((input_path, output_path))
            //     output_images = []
            //     for (input_path, output_path) in files:
            //         wkhtmltoimage = [_wkhtml().wkhtmltoimage_bin, *command_args, input_path, output_path]
            //         # start and block, no need for parallelism for now
            //         completed_process = subprocess.run(wkhtmltoimage, stdout=subprocess.DEVNULL, stderr=subprocess.PIPE, check=False, encoding='utf-8')
            //         if completed_process.returncode:
            //             message = _(
            //                 'Wkhtmltoimage failed (error code: %(error_code)s). Message: %(error_message_end)s',
            //                 error_code=completed_process.returncode,
            //                 error_message_end=completed_process.stderr[-1000:],
            //             )
            //             _logger.warning(message)
            //             output_images.append(None)
            //         else:
            //             with open(output_path, 'rb') as output_file:
            //                 output_images.append(output_file.read())
            // return output_images
            */
            return default;
        }

        public async Task<TEntity> RunWkhtmltopdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object report_ref, object header, object footer, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _run_wkhtmltopdf(
            //     self,
            //     bodies,
            //     report_ref=False,
            //     header=None,
            //     footer=None,
            //     landscape=False,
            //     specific_paperformat_args=None,
            //     set_viewport_size=False):
            // '''Execute wkhtmltopdf as a subprocess in order to convert html given in input into a pdf
            // document.
            // 
            // :param Iterable[str] bodies: The html bodies of the report, one per page.
            // :param report_ref: report reference that is needed to get report paperformat.
            // :param str header: The html header of the report containing all headers.
            // :param str footer: The html footer of the report containing all footers.
            // :param landscape: Force the pdf to be rendered under a landscape format.
            // :param specific_paperformat_args: dict of prioritized paperformat arguments.
            // :param set_viewport_size: Enable a viewport sized '1024x1280' or '1280x1024' depending of landscape arg.
            // :return: Content of the pdf as bytes
            // :rtype: bytes
            // '''
            // paperformat_id = self._get_report(report_ref).get_paperformat() if report_ref else self.get_paperformat()
            // 
            // # Build the base command args for wkhtmltopdf bin
            // command_args = self._build_wkhtmltopdf_args(
            //     paperformat_id,
            //     landscape,
            //     specific_paperformat_args=specific_paperformat_args,
            //     set_viewport_size=set_viewport_size)
            // 
            // files_command_args = []
            // 
            // def delete_file(file_path):
            //     try:
            //         os.unlink(file_path)
            //     except OSError:
            //         _logger.error('Error when trying to remove file %s', file_path)
            // 
            // with ExitStack() as stack:
            // 
            //     # Passing the cookie to wkhtmltopdf in order to resolve internal links.
            //     if request and request.db:
            //         # Create a temporary session which will not create device logs
            //         temp_session = root.session_store.new()
            //         temp_session.update({
            //             **request.session,
            //             'debug': '',
            //             '_trace_disable': True,
            //         })
            //         if temp_session.uid:
            //             temp_session.session_token = security.compute_session_token(temp_session, self.env)
            //         root.session_store.save(temp_session)
            //         stack.callback(root.session_store.delete, temp_session)
            // 
            //         base_url = self._get_report_url()
            //         domain = urlparse(base_url).hostname
            //         cookie = f'session_id={temp_session.sid}; HttpOnly; domain={domain}; path=/;'
            //         cookie_jar_file_fd, cookie_jar_file_path = tempfile.mkstemp(suffix='.txt', prefix='report.cookie_jar.tmp.')
            //         stack.callback(delete_file, cookie_jar_file_path)
            //         with closing(os.fdopen(cookie_jar_file_fd, 'wb')) as cookie_jar_file:
            //             cookie_jar_file.write(cookie.encode())
            //         command_args.extend(['--cookie-jar', cookie_jar_file_path])
            // 
            //     if header:
            //         head_file_fd, head_file_path = tempfile.mkstemp(suffix='.html', prefix='report.header.tmp.')
            //         with closing(os.fdopen(head_file_fd, 'wb')) as head_file:
            //             head_file.write(header.encode())
            //         stack.callback(delete_file, head_file_path)
            //         files_command_args.extend(['--header-html', head_file_path])
            //     if footer:
            //         foot_file_fd, foot_file_path = tempfile.mkstemp(suffix='.html', prefix='report.footer.tmp.')
            //         with closing(os.fdopen(foot_file_fd, 'wb')) as foot_file:
            //             foot_file.write(footer.encode())
            //         stack.callback(delete_file, foot_file_path)
            //         files_command_args.extend(['--footer-html', foot_file_path])
            // 
            //     paths = []
            //     body_idx = 0
            //     for body_idx, body in enumerate(bodies):
            //         prefix = f'report.body.tmp.{body_idx}.'
            //         body_file_fd, body_file_path = tempfile.mkstemp(suffix='.html', prefix=prefix)
            //         with closing(os.fdopen(body_file_fd, 'wb')) as body_file:
            //             # HACK: wkhtmltopdf doesn't like big table at all and the
            //             #       processing time become exponential with the number
            //             #       of rows (like 1H for 250k rows).
            //             #
            //             #       So we split the table into multiple tables containing
            //             #       500 rows each. This reduce the processing time to 1min
            //             #       for 250k rows. The number 500 was taken from opw-1689673
            //             if len(body) < 4 * 1024 * 1024:  # 4Mib
            //                 body_file.write(body.encode())
            //             else:
            //                 tree = lxml.html.fromstring(body)
            //                 _split_table(tree, 500)
            //                 body_file.write(lxml.html.tostring(tree))
            //         paths.append(body_file_path)
            //         stack.callback(delete_file, body_file_path)
            // 
            //     pdf_report_fd, pdf_report_path = tempfile.mkstemp(suffix='.pdf', prefix='report.tmp.')
            //     os.close(pdf_report_fd)
            //     stack.callback(delete_file, pdf_report_path)
            // 
            //     process = _run_wkhtmltopdf(command_args + files_command_args + paths + [pdf_report_path])
            //     err = process.stderr
            // 
            //     match process.returncode:
            //         case 0:
            //             pass
            //         case 1:
            //             if body_idx:
            //                 if not _wkhtml().is_patched_qt:
            //                     if modules.module.current_test:
            //                         raise unittest.SkipTest("Unable to convert multiple documents via wkhtmltopdf using unpatched QT")
            //                     raise UserError(_("Tried to convert multiple documents in wkhtmltopdf using unpatched QT"))
            // 
            //             _logger.warning("wkhtmltopdf: %s", err)
            //         case c:
            //             message = _(
            //                 'Wkhtmltopdf failed (error code: %(error_code)s). Memory limit too low or maximum file number of subprocess reached. Message : %(message)s',
            //                 error_code=c,
            //                 message=err[-1000:],
            //             ) if c == -11 else _(
            //                 'Wkhtmltopdf failed (error code: %(error_code)s). Message: %(message)s',
            //                 error_code=c,
            //                 message=err[-1000:],
            //             )
            //             _logger.warning(message)
            //             raise UserError(message)
            // 
            //     with open(pdf_report_path, 'rb') as pdf_document:
            //         pdf_content = pdf_document.read()
            // 
            // return pdf_content
            */
            return default;
        }

        public async Task<TEntity> SearchModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _search_model_id(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // models = self.env['ir.model']
            // if isinstance(value, str):
            //     models = models.search(Domain('display_name', operator, value))
            // elif isinstance(value, Domain):
            //     models = models.search(value)
            // elif operator == 'any!':
            //     models = models.sudo().search(Domain('id', operator, value))
            // elif operator == 'any' or isinstance(value, int):
            //     models = models.search(Domain('id', operator, value))
            // elif operator == 'in':
            //     models = models.search(Domain.OR(
            //         Domain('id' if isinstance(v, int) else 'display_name', operator, v)
            //         for v in value
            //         if v
            //     ))
            // return Domain('model', 'in', models.mapped('model'))
            */
            return default;
        }

        public async Task<TEntity> SelectionTargetModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _selection_target_model(self):
            // return [(model.model, model.name) for model in self.env['ir.model'].sudo().search([])]
            */
            return default;
        }

        public async Task<TEntity> SetCrudModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> SetResourceRefInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> SetSelectionValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> TraversePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
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

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def unlink_action(self):
            // """ Remove the contextual actions created for the server actions. """
            // self.check_access('write')
            // self.filtered('binding_model_id').write({'binding_model_id': False})
            // return True
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def unlink_action(self):
            // """ Remove the contextual actions created for the reports. """
            // self.check_access('write')
            // self.filtered('binding_model_id').write({'binding_model_id': False})
            // return True
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def unlink(self):
            // """unlink ir.action.todo/ir.filters which are related to actions which will be deleted.
            //    NOTE: ondelete cascade will not work on ir.actions.actions so we will need to do it manually."""
            // todos = self.env['ir.actions.todo'].search([('action_id', 'in', self.ids)])
            // todos.unlink()
            // filters = self.env['ir.filters'].search([('action_id', 'in', self.ids)])
            // filters.unlink()
            // res = super().unlink()
            // # self.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def unlink(self):
            // self.env.registry.clear_cache()
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkCheckHomeActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def _unlink_check_home_action(self):
            // self.env['res.users'].with_context(active_test=False).search([('action_id', 'in', self.ids)]).sudo().write({'action_id': None})
            */
            return default;
        }

        public async Task<TEntity> WarningDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IIrActionsActionsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // # self.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def write(self, vals):
            // if (new_code := vals.get("code")) and new_code != self.code:
            //     self.env["ir.actions.server.history"].create({"action_id": self.id, "code": new_code})
            // return super().write(vals)
            */
            return default;
        }
    }
}