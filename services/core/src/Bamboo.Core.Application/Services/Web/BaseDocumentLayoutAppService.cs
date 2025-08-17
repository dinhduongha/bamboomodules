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
    [Module("Web", Depends = new[] { "base" })]
    public class BaseDocumentLayoutAppService : GenericApplicationService<BaseDocumentLayout>, IBaseDocumentLayoutAppService
    {

        public BaseDocumentLayoutAppService(IRepository<BaseDocumentLayout, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<BaseDocumentLayout> CleanAddressFormatInternalAsync(object address_format, object company_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _clean_address_format(self, address_format, company_data):
            // missing_company_data = [k for k, v in company_data.items() if not v]
            // for key in missing_company_data:
            //     if key in address_format:
            //         address_format = address_format.replace(f'%({key})s\n', '')
            // return address_format
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> CompileScssInternalAsync(object scss_source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _compile_scss(self, scss_source):
            // """
            // This code will compile valid scss into css.
            // Parameters are the same from odoo/addons/base/models/assetsbundle.py
            // Simply copied and adapted slightly
            // """
            // 
            // def scss_importer(path, *args):
            //     *parent_path, file = os.path.split(path)
            //     try:
            //         parent_path = file_path(os.path.join(*parent_path))
            //     except FileNotFoundError:
            //         parent_path = file_path(os.path.join(bootstrap_path, *parent_path))
            //     return [(os.path.join(parent_path, file),)]
            // 
            // # No scss ? still valid, returns empty css
            // if not scss_source.strip():
            //     return ""
            // 
            // precision = 8
            // output_style = 'expanded'
            // bootstrap_path = file_path('web/static/lib/bootstrap/scss')
            // 
            // try:
            //     compiled_css = libsass.compile(
            //         string=scss_source,
            //         include_paths=[
            //             bootstrap_path,
            //         ],
            //         importers=[(0, scss_importer)],
            //         output_style=output_style,
            //         precision=precision,
            //     )
            //     return Markup(compiled_css) if isinstance(compiled_css, Markup) else compiled_css
            // except libsass.CompileError as e:
            //     raise libsass.CompileError(e.args[0])
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeCustomColorsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _compute_custom_colors(self):
            // for wizard in self:
            //     logo_primary = wizard.logo_primary_color or ''
            //     logo_secondary = wizard.logo_secondary_color or ''
            //     # Force lower case on color to ensure that FF01AA == ff01aa
            //     wizard.custom_colors = (
            //         wizard.logo and wizard.primary_color and wizard.secondary_color
            //         and not(
            //             wizard.primary_color.lower() == logo_primary.lower()
            //             and wizard.secondary_color.lower() == logo_secondary.lower()
            //         )
            //     )
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeEmptyCompanyDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _compute_empty_company_details(self):
            // # In recent change when an html field is empty a <p> balise remains with a <br> in it,
            // # but when company details is empty we want to put the info of the company
            // for record in self:
            //     record.is_company_details_empty = not html2plaintext(record.company_details or '')
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeLogoColorsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _compute_logo_colors(self):
            // for wizard in self:
            //     if wizard._context.get('bin_size'):
            //         wizard_for_image = wizard.with_context(bin_size=False)
            //     else:
            //         wizard_for_image = wizard
            //     wizard.logo_primary_color, wizard.logo_secondary_color = wizard.extract_image_primary_secondary_colors(wizard_for_image.logo)
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputePreviewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _compute_preview(self):
            // """ compute a qweb based preview to display on the wizard """
            // styles = self._get_asset_style()
            // 
            // for wizard in self:
            //     if wizard.report_layout_id:
            //         if wizard.env.context.get('bin_size'):
            //             # guarantees that bin_size is always set to False,
            //             # so the logo always contains the bin data instead of the binary size
            //             wizard = wizard.with_context(bin_size=False)
            //         wizard.preview = wizard.env['ir.ui.view']._render_template(
            //             wizard._get_preview_template(),
            //             wizard._get_render_information(styles),
            //         )
            //     else:
            //         wizard.preview = False
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> DefaultCompanyDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_din5008, FILE: base_document_layout.py) ---
            // def _default_company_details(self):
            // # OVERRIDE web/models/base_document_layout
            // default_company_details = super()._default_company_details()
            // if self.env.company.external_report_layout_id == self.env.ref('l10n_din5008.external_layout_din5008'):
            //     # In order to respect the strict formatting of DIN5008, we need to remove empty lines from the address
            //     return re.sub(r'(( )*<br>( )*\n)+', r'<br>\n', default_company_details)
            // return default_company_details
            --- ODOO METHOD SOURCE (MODULE: l10n_ma, FILE: base_document_layout.py) ---
            // def _default_company_details(self):
            // # OVERRIDE web/models/base_document_layout
            // company_details = super()._default_company_details()
            // if self.env.company.country_code == 'MA':
            //     company_details += Markup('<br> ICE: %s') % self.env.company.company_registry
            // return company_details
            --- ODOO METHOD SOURCE (MODULE: l10n_mu_account, FILE: base_document_layout.py) ---
            // def _default_company_details(self):
            // company_details = super()._default_company_details()
            // company = self.env.company
            // if company.company_registry and company.country_code == 'MU':
            //     return company_details + Markup('<br/> %s') % company.company_registry
            // return company_details
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _default_company_details(self):
            // company = self.env.company
            // address_format, company_data = company.partner_id._prepare_display_address()
            // address_format = self._clean_address_format(address_format, company_data)
            // # company_name may *still* be missing from prepared address in case commercial_company_name is falsy
            // if 'company_name' not in address_format:
            //     address_format = '%(company_name)s\n' + address_format
            //     company_data['company_name'] = company_data['company_name'] or company.name
            // return nl2br(address_format) % company_data
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> DefaultReportFooterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_din5008, FILE: base_document_layout.py) ---
            // def _default_report_footer(self):
            // # OVERRIDE web/models/base_document_layout
            // if self.env.company.external_report_layout_id == self.env.ref('l10n_din5008.external_layout_din5008'):
            //     company = self.env.company
            //     # Company VAT should not be present in this footer, as it is displayed elsewhere in the DIN5008 layout
            //     footer_fields = [field for field in [company.phone, company.email, company.website] if isinstance(field, str) and len(field) > 0]
            //     return Markup('<br>').join(footer_fields)
            // return super()._default_report_footer()
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _default_report_footer(self):
            // company = self.env.company
            // footer_fields = [field for field in [company.phone, company.email, company.website, company.vat] if isinstance(field, str) and len(field) > 0]
            // return Markup(' ').join(footer_fields)
            */
            return default;
        }

        public async Task<BaseDocumentLayout> DocumentLayoutSaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def document_layout_save(self):
            // # meant to be overridden
            // return self.env.context.get('report_action') or {'type': 'ir.actions.act_window_close'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BaseDocumentLayout> ExtractImagePrimarySecondaryColorsAsync(Guid id, object logo, object white_threshold, object mitigate)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def extract_image_primary_secondary_colors(self, logo, white_threshold=225, mitigate=175):
            // """
            // Identifies dominant colors
            // 
            // First resizes the original image to improve performance, then discards
            // transparent colors and white-ish colors, then calls the averaging
            // method twice to evaluate both primary and secondary colors.
            // 
            // :param logo: logo to process
            // :param white_threshold: arbitrary value defining the maximum value a color can reach
            // :param mitigate: arbitrary value defining the maximum value a band can reach
            // 
            // :return colors: hex values of primary and secondary colors
            // """
            // if not logo:
            //     return False, False
            // # The "===" gives different base64 encoding a correct padding
            // logo += b'===' if isinstance(logo, bytes) else '==='
            // try:
            //     # Catches exceptions caused by logo not being an image
            //     image = tools.image_fix_orientation(tools.base64_to_image(logo))
            // except Exception:
            //     return False, False
            // 
            // base_w, base_h = image.size
            // w = ceil(50 * base_w / base_h)
            // h = 50
            // 
            // # Converts to RGBA (if already RGBA, this is a noop)
            // image_converted = image.convert('RGBA')
            // image_resized = image_converted.resize((w, h), resample=Resampling.NEAREST)
            // 
            // colors = []
            // for color in image_resized.getcolors(w * h):
            //     if not(color[1][0] > white_threshold and
            //            color[1][1] > white_threshold and
            //            color[1][2] > white_threshold) and color[1][3] > 0:
            //         colors.append(color)
            // 
            // if not colors:  # May happen when the whole image is white
            //     return False, False
            // primary, remaining = tools.average_dominant_color(colors, mitigate=mitigate)
            // secondary = tools.average_dominant_color(remaining, mitigate=mitigate)[0] if remaining else primary
            // 
            // # Lightness and saturation are calculated here.
            // # - If both colors have a similar lightness, the most colorful becomes primary
            // # - When the difference in lightness is too great, the brightest color becomes primary
            // l_primary = tools.get_lightness(primary)
            // l_secondary = tools.get_lightness(secondary)
            // if (l_primary < 0.2 and l_secondary < 0.2) or (l_primary >= 0.2 and l_secondary >= 0.2):
            //     s_primary = tools.get_saturation(primary)
            //     s_secondary = tools.get_saturation(secondary)
            //     if s_primary < s_secondary:
            //         primary, secondary = secondary, primary
            // elif l_secondary > l_primary:
            //     primary, secondary = secondary, primary
            // 
            // return tools.rgb_to_hex(primary), tools.rgb_to_hex(secondary)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BaseDocumentLayout> GetAssetStyleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _get_asset_style(self):
            // """
            // Compile the style template. It is a qweb template expecting company ids to generate all the code in one batch.
            // We give a useless company_ids arg, but provide the PREVIEW_ID arg that will prepare the template for
            // '_get_css_for_preview' processing later.
            // :return:
            // """
            // company_styles = self.env['ir.qweb']._render('web.styles_company_report', {
            //     'company_ids': self,
            // }, raise_if_not_found=False)
            // 
            // return company_styles
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetCssForPreviewInternalAsync(object scss, Guid new_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _get_css_for_preview(self, scss, new_id):
            // """
            // Compile the scss into css.
            // """
            // css_code = self._compile_scss(scss)
            // return css_code
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetPreviewTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _get_preview_template(self):
            // return 'web.report_invoice_wizard_preview'
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetRenderInformationInternalAsync(object styles)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _get_render_information(self, styles):
            // self.ensure_one()
            // preview_css = self._get_css_for_preview(styles, self.id)
            // return {
            //     'company': self,
            //     'preview_css': preview_css,
            //     'is_html_empty': is_html_empty,
            // }
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _onchange_company_id(self):
            // for wizard in self:
            //     wizard.logo = wizard.company_id.logo
            //     wizard.report_header = wizard.company_id.report_header
            //     # company_details and report_footer can store empty strings (set by the user) or false (meaning the user didn't set a value). Since both are falsy values, we use isinstance of string to differentiate them
            //     wizard.report_footer = wizard.company_id.report_footer if isinstance(wizard.company_id.report_footer, str) else wizard.report_footer
            //     wizard.company_details = wizard.company_id.company_details if isinstance(wizard.company_id.company_details, str) else wizard.company_details
            //     wizard.paperformat_id = wizard.company_id.paperformat_id
            //     wizard.external_report_layout_id = wizard.company_id.external_report_layout_id
            //     wizard.font = wizard.company_id.font
            //     wizard.primary_color = wizard.company_id.primary_color
            //     wizard.secondary_color = wizard.company_id.secondary_color
            //     wizard_layout = wizard.env["report.layout"].search([
            //         ('view_id.key', '=', wizard.company_id.external_report_layout_id.key)
            //     ])
            //     wizard.report_layout_id = wizard_layout or wizard_layout.search([], limit=1)
            // 
            //     if not wizard.primary_color:
            //         wizard.primary_color = wizard.logo_primary_color or DEFAULT_PRIMARY
            //     if not wizard.secondary_color:
            //         wizard.secondary_color = wizard.logo_secondary_color or DEFAULT_SECONDARY
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeCustomColorsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _onchange_custom_colors(self):
            // for wizard in self:
            //     if wizard.logo and not wizard.custom_colors:
            //         wizard.primary_color = wizard.logo_primary_color or DEFAULT_PRIMARY
            //         wizard.secondary_color = wizard.logo_secondary_color or DEFAULT_SECONDARY
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeLogoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _onchange_logo(self):
            // for wizard in self:
            //     # It is admitted that if the user puts the original image back, it won't change colors
            //     company = wizard.company_id
            //     # at that point wizard.logo has been assigned the value present in DB
            //     if wizard.logo == company.logo and company.primary_color and company.secondary_color:
            //         continue
            // 
            //     if wizard.logo_primary_color:
            //         wizard.primary_color = wizard.logo_primary_color
            //     if wizard.logo_secondary_color:
            //         wizard.secondary_color = wizard.logo_secondary_color
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeReportLayoutIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: base_document_layout.py) ---
            // def _onchange_report_layout_id(self):
            // for wizard in self:
            //     wizard.external_report_layout_id = wizard.report_layout_id.view_id
            */
            return default;
        }
    }
}