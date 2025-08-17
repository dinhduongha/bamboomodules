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
    [Module("spreadsheet", Depends = new[] { "bus", "web", "portal" })]
    public class SpreadsheetMixinAppService : ApplicationService, ISpreadsheetMixinAppService
    {

        public SpreadsheetMixinAppService() 
        {

        }

        public async Task<TEntity> CheckDashboardAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _check_dashboard_access(self, access_token):
            // self.ensure_one()
            // token_access = self._check_token(access_token)
            // dashboard = self.dashboard_id.with_user(self.create_uid)
            // user_access = dashboard.has_access("read")
            // if not (token_access and user_access):
            //     raise Forbidden(_("You don't have access to this dashboard. "))
            */
            return default;
        }

        public async Task<TEntity> CheckSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _check_spreadsheet_data(self):
            // for spreadsheet in self.filtered("spreadsheet_binary_data"):
            //     try:
            //         data = json.loads(base64.b64decode(spreadsheet.spreadsheet_binary_data).decode())
            //     except (json.JSONDecodeError, UnicodeDecodeError):
            //         raise ValidationError(_("Uh-oh! Looks like the spreadsheet file contains invalid data."))
            //     if not (tools.config['test_enable'] or tools.config['test_file']):
            //         continue
            //     if data.get("[Content_Types].xml"):
            //         # this is a xlsx file
            //         continue
            //     display_name = spreadsheet.display_name
            //     errors = []
            //     for model, field_chains in fields_in_spreadsheet(data).items():
            //         if model not in self.env:
            //             errors.append(f"- model '{model}' used in '{display_name}' does not exist")
            //             continue
            //         for field_chain in field_chains:
            //             field_model = model
            //             for fname in field_chain.split("."):  # field chain 'product_id.channel_ids'
            //                 if fname not in self.env[field_model]._fields:
            //                     errors.append(f"- field '{fname}' used in spreadsheet '{display_name}' does not exist on model '{field_model}'")
            //                     continue
            //                 field = self.env[field_model]._fields[fname]
            //                 if field.relational:
            //                     field_model = field.comodel_name
            // 
            //     for xml_id in menus_xml_ids_in_spreadsheet(data):
            //         record = self.env.ref(xml_id, raise_if_not_found=False)
            //         if not record:
            //             errors.append(f"- xml id '{xml_id}' used in spreadsheet '{display_name}' does not exist")
            //             continue
            //         # check that the menu has an action. Root menus always have an action.
            //         if not record.action and record.parent_id.id:
            //             errors.append(f"- menu with xml id '{xml_id}' used in spreadsheet '{display_name}' does not have an action")
            // 
            //     if errors:
            //         raise ValidationError(
            //             _(
            //                 "Uh-oh! Looks like the spreadsheet file contains invalid data.\n\n%(errors)s",
            //                 errors="\n".join(errors),
            //             ),
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _check_token(self, access_token):
            // if not access_token:
            //     return False
            // return consteq(access_token, self.access_token)
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def _compute_full_url(self):
            // for share in self:
            //     share.full_url = "%s/dashboard/share/%s/%s" % (share.get_base_url(), share.id, share.access_token)
            */
            return default;
        }

        public async Task<TEntity> ComputeSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _compute_spreadsheet_data(self):
            // attachments = self.env['ir.attachment'].with_context(bin_size=False).search([
            //     ('res_model', '=', self._name),
            //     ('res_field', '=', 'spreadsheet_binary_data'),
            //     ('res_id', 'in', self.ids),
            // ])
            // data = {
            //     attachment.res_id: attachment.raw
            //     for attachment in attachments
            // }
            // for spreadsheet in self:
            //     spreadsheet.spreadsheet_data = data.get(spreadsheet.id, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeSpreadsheetFileNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _compute_spreadsheet_file_name(self):
            // for spreadsheet in self:
            //     spreadsheet.spreadsheet_file_name = f"{spreadsheet.display_name}.osheet.json"
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for dashboard, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", dashboard.name)
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> DashboardIsEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _dashboard_is_empty(self):
            // return any(self.env[model].search_count([], limit=1) == 0 for model in self.main_data_model_ids.sudo().mapped("model"))
            */
            return default;
        }

        public async Task<TEntity> EmptySpreadsheetDataBase64InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _empty_spreadsheet_data_base64(self):
            // """Create an empty spreadsheet workbook.
            // Encoded as base64
            // """
            // data = json.dumps(self._empty_spreadsheet_data())
            // return base64.b64encode(data.encode())
            */
            return default;
        }

        public async Task<TEntity> EmptySpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _empty_spreadsheet_data(self):
            // """Create an empty spreadsheet workbook.
            // The sheet name should be the same for all users to allow consistent references
            // in formulas. It is translated for the user creating the spreadsheet.
            // """
            // lang = self.env["res.lang"]._lang_get(self.env.user.lang)
            // locale = lang._odoo_lang_to_spreadsheet_locale()
            // return {
            //     "version": 1,
            //     "sheets": [
            //         {
            //             "id": "sheet1",
            //             "name": _("Sheet1"),
            //         }
            //     ],
            //     "settings": {
            //         "locale": locale,
            //     },
            //     "revisionId": "START_REVISION",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDisplayNamesForSpreadsheetAsync<TEntity>(IEnumerable<TEntity> entities, object args) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def get_display_names_for_spreadsheet(self, args):
            // ids_per_model = defaultdict(list)
            // for arg in args:
            //     ids_per_model[arg["model"]].append(arg["id"])
            // display_names = defaultdict(dict)
            // for model, ids in ids_per_model.items():
            //     records = self.env[model].with_context(active_test=False).search([("id", "in", ids)])
            //     for record in records:
            //         display_names[model][record.id] = record.display_name
            // 
            // # return the display names in the same order as the input
            // return [
            //     display_names[arg["model"]].get(arg["id"])
            //     for arg in args
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetFileContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_path) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _get_file_content(self, file_path):
            // if file_path.startswith('data:image/png;base64,'):
            //     return base64.b64decode(file_path.split(',')[1])
            // match = re.match(r'/web/image/(\d+)', file_path)
            // file_record = self.env['ir.binary']._find_record(
            //     res_model='ir.attachment',
            //     res_id=int(match.group(1)),
            // )
            // return self.env['ir.binary']._get_stream_from(file_record).read()
            */
            return default;
        }

        public async Task<TEntity> GetReadonlyDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def get_readonly_dashboard(self):
            // self.ensure_one()
            // snapshot = json.loads(self.spreadsheet_data)
            // if self._dashboard_is_empty() and self.sample_dashboard_file_path:
            //     sample_data = self._get_sample_dashboard()
            //     if sample_data:
            //         return {
            //             "snapshot": sample_data,
            //             "is_sample": True,
            //         }
            // user_locale = self.env['res.lang']._get_user_spreadsheet_locale()
            // snapshot.setdefault('settings', {})['locale'] = user_locale
            // default_currency = self.env['res.currency'].get_company_currency_for_spreadsheet()
            // return {
            //     'snapshot': snapshot,
            //     'revisions': [],
            //     'default_currency': default_currency,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSampleDashboardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py) ---
            // def _get_sample_dashboard(self):
            // try:
            //     with file_open(self.sample_dashboard_file_path) as f:
            //         return json.load(f)
            // except FileNotFoundError:
            //     return
            */
            return default;
        }

        public async Task<TEntity> GetShareUrlAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py) ---
            // def action_get_share_url(self, vals):
            // if "excel_files" in vals:
            //     excel_zip = self._zip_xslx_files(
            //         vals["excel_files"]
            //     )
            //     del vals["excel_files"]
            //     vals["excel_export"] = base64.b64encode(excel_zip)
            // return self.create(vals).full_url
            */
            return default;
        }

        public async Task<TEntity> InverseSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _inverse_spreadsheet_data(self):
            // for spreadsheet in self:
            //     if not spreadsheet.spreadsheet_data:
            //         spreadsheet.spreadsheet_binary_data = False
            //     else:
            //         spreadsheet.spreadsheet_binary_data = base64.b64encode(spreadsheet.spreadsheet_data.encode())
            */
            return default;
        }

        public async Task<TEntity> OnchangeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _onchange_data_(self):
            // self._check_spreadsheet_data()
            */
            return default;
        }

        public async Task<TEntity> ZipXslxFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py) ---
            // def _zip_xslx_files(self, files):
            // stream = io.BytesIO()
            // with zipfile.ZipFile(stream, 'w', compression=zipfile.ZIP_DEFLATED) as doc_zip:
            //     for f in files:
            //         # to reduce networking load, only the image path is sent.
            //         # It's replaced by the image content here.
            //         if 'imageSrc' in f:
            //             try:
            //                 content = self._get_file_content(f['imageSrc'])
            //                 doc_zip.writestr(f['path'], content)
            //             except MissingError:
            //                 pass
            //         else:
            //             doc_zip.writestr(f['path'], f['content'])
            // 
            // return stream.getvalue()
            */
            return default;
        }
    }
}