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
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteModule", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class WebsiteAppService : GenericApplicationService<Website>, IWebsiteAppService
    {

        public WebsiteAppService(IRepository<Website, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<Website> ActiveLanguagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _active_languages(self):
            // return self.env['res.lang'].search([]).ids
            */
            return default;
        }

        protected async Task<Website> AllConsentsGrantedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _allConsentsGranted(self):
            // """
            // Checks if all (cookies) consents have been granted. Note that in the
            // case no cookies bar has been enabled, this considers that full consent
            // has been immediately given. Indeed, in that case, we suppose that the
            // user implemented his own consent behavior through custom code / app.
            // That custom code / app is able to override this function as desired and
            // xpath the `tracking_code_config` script in `website.layout`.
            // 
            // :return: True if all consents have been granted, False otherwise
            // """
            // self.ensure_one()
            // return not self.cookies_bar or self.env['ir.http']._is_allowed_cookie('optional')
            */
            return default;
        }

        protected async Task<Website> ApiRpcInternalAsync(object route, object @params, object endpoint_param_name, object default_endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _api_rpc(self, route, params, endpoint_param_name, default_endpoint, **kwargs):
            // params['version'] = release.version
            // IrConfigParameter = self.env['ir.config_parameter'].sudo()
            // api_endpoint = IrConfigParameter.get_param(endpoint_param_name, default_endpoint)
            // return iap_tools.iap_jsonrpc(api_endpoint + route, params=params, **kwargs)
            */
            return default;
        }

        protected async Task<Website> BasicEnumerateWordsInternalAsync(object search_details, object search, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _basic_enumerate_words(self, search_details, search, limit):
            // """
            // Browses through all words that need to be compared to the search term.
            // It extracts all words of every field associated to models in the fields_per_model parameter.
            // 
            // :param search_details: obtained from `_search_get_details()`
            // :param search: search term to which words must be matched against
            // :param limit: maximum number of records fetched per model to build the word list
            // :return: yields words
            // """
            // match_pattern = r'[\w./-]{%s,}' % min(4, len(search) - 3)
            // first = sqltools.escape_psql(search[0])
            // for search_detail in search_details:
            //     model_name, fields = search_detail['model'], search_detail['search_fields']
            //     model = self.env[model_name]
            //     if search_detail.get('requires_sudo'):
            //         model = model.sudo()
            //     domain = search_detail['base_domain'].copy()
            //     fields_domain = []
            //     direct_fields = set(fields).intersection(model._fields)
            //     indirect_fields = self._search_get_indirect_fields(fields, model)
            //     fields = direct_fields.union(indirect_fields)
            //     for field in fields:
            //         fields_domain.append([(field, '=ilike', '%s%%' % first)])
            //         fields_domain.append([(field, '=ilike', '%% %s%%' % first)])
            //         fields_domain.append([(field, '=ilike', '%%>%s%%' % first)])  # HTML
            //     domain.append(OR(fields_domain))
            //     domain = AND(domain)
            //     perf_limit = 1000
            //     records = model.search_read(domain, direct_fields, limit=perf_limit)
            //     if len(records) == perf_limit:
            //         # Exact match might have been missed because the fetched
            //         # results are limited for performance reasons.
            //         exact_records, _ = model._search_fetch(search_detail, search, 1, None)
            //         if exact_records:
            //             yield search
            //     for record in records:
            //         for field, value in record.items():
            //             if isinstance(value, str):
            //                 value = value.lower()
            //                 if field == 'arch_db':
            //                     value = text_from_html(value)
            //                 for word in re.findall(match_pattern, value):
            //                     if word[0] == search[0]:
            //                         yield word.lower()
            //     if indirect_fields:
            //         records = model.search(domain, limit=limit)
            //         for indirect_field in indirect_fields:
            //             for value in records.mapped(indirect_field):
            //                 if isinstance(value, str):
            //                     value = value.lower()
            //                     yield from re.findall(match_pattern, value)
            */
            return default;
        }

        protected async Task<Website> BootstrapHomepageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _bootstrap_homepage(self):
            //         Page = self.env['website.page']
            //         standard_homepage = self.env.ref('website.homepage', raise_if_not_found=False)
            //         if not standard_homepage:
            //             return
            // 
            //         # keep strange indentation in python file, to get it correctly in database
            //         new_homepage_view = '''<t name="Homepage" t-name="website.homepage">
            //     <t t-call="website.layout">
            //         <t t-set="pageName" t-value="'homepage'"/>
            //         <div id="wrap" class="oe_structure oe_empty"/>
            //     </t>
            // </t>'''
            //         standard_homepage.with_context(website_id=self.id).arch_db = new_homepage_view
            // 
            //         homepage_page = Page.search([
            //             ('website_id', '=', self.id),
            //             ('key', '=', standard_homepage.key),
            //         ], limit=1)
            //         if not homepage_page:
            //             homepage_page = Page.create({
            //                 'website_published': True,
            //                 'url': '/',
            //                 'view_id': self.with_context(website_id=self.id).viewref('website.homepage').id,
            //             })
            //         # prevent /-1 as homepage URL
            //         homepage_page.url = '/'
            // 
            //         # Bootstrap default menu hierarchy, create a new minimalist one if no default
            //         default_menu = self.env.ref('website.main_menu')
            //         self.copy_menu_hierarchy(default_menu)
            //         home_menu = self.env['website.menu'].search([('website_id', '=', self.id), ('url', '=', '/')])
            //         home_menu.page_id = homepage_page
            */
            return default;
        }

        public async Task<Website> ButtonGoWebsiteAsync(Guid id, WebsiteButtonGoWebsiteRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def button_go_website(self, path='/'):
            // self._force()
            // return self.get_client_action(path)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> CheckEventsAppNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: website.py) ---
            // def _check_events_app_name(self):
            // for website in self:
            //     if not website.events_app_name:
            //         raise ValidationError(_('"Events App Name" field is required.'))
            */
            return default;
        }

        protected async Task<Website> CheckHomepageUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _check_homepage_url(self):
            // for website in self.filtered('homepage_url'):
            //     if not website.homepage_url.startswith('/'):
            //         raise ValidationError(_("The homepage URL should be relative and start with '/'."))
            */
            return default;
        }

        protected async Task<Website> CheckSnippetUsedInternalAsync(object snippet_occurences, object asset_type, object asset_version)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _check_snippet_used(self, snippet_occurences, asset_type, asset_version):
            // for snippet in snippet_occurences:
            //     if asset_version == '000':
            //         if f'data-v{asset_type}' not in snippet:
            //             return True
            //     else:
            //         if f'data-v{asset_type}="{asset_version}"' in snippet:
            //             return True
            // return False
            */
            return default;
        }

        protected async Task<Website> CheckUserCanModifyInternalAsync(object record)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _check_user_can_modify(self, record):
            // """ Verify that the current user can modify the given record.
            // 
            // :param record: record on which to perform the check
            // :raise AccessError: if the operation is forbidden
            // """
            // record.check_access('write')
            */
            return default;
        }

        protected async Task<Website> ComputeAppIconInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: website.py) ---
            // def _compute_app_icon(self):
            // """ Computes a squared image based on the favicon to be used as mobile webapp icon.
            //     App Icon should be in PNG format and size of at least 512x512.
            // 
            //     If the favicon is an SVG image, it will be skipped and the app_icon will be set to False.
            // 
            // """
            // for website in self:
            //     image = ImageProcess(base64.b64decode(website.favicon)) if website.favicon else None
            //     if not (image and image.image):
            //         website.app_icon = False
            //         continue
            //     w, h = image.image.size
            //     square_size = w if w > h else h
            //     image.crop_resize(square_size, square_size)
            //     image.image = image.image.resize((512, 512))
            //     image.operationsCount += 1
            //     website.app_icon = base64.b64encode(image.image_quality(output_format='PNG'))
            */
            return default;
        }

        protected async Task<Website> ComputeBlockedThirdPartyDomainsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _compute_blocked_third_party_domains(self):
            // for website in self:
            //     custom_list = website.sudo().custom_blocked_third_party_domains
            // 
            //     full_list = DEFAULT_BLOCKED_THIRD_PARTY_DOMAINS
            //     if custom_list:
            //         # Note: each line of the custom list is already ensured to not
            //         # have leading or trailing whitespaces.
            //         lines = custom_list.splitlines()
            //         custom_domains = '\n'.join([line for line in lines if line[0] != '#'])
            //         if lines[0].startswith("#ignore_default"):
            //             full_list = custom_domains
            //         else:
            //             full_list += f"\n{custom_domains}"
            // 
            //     website.blocked_third_party_domains = full_list
            */
            return default;
        }

        protected async Task<Website> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _compute_currency_id(self):
            // for website in self:
            //     website.currency_id = website.pricelist_id.currency_id or website.company_id.currency_id
            */
            return default;
        }

        protected async Task<Website> ComputeDomainPunycodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _compute_domain_punycode(self):
            // """Compute the punycode (ASCII-safe) version of the domain."""
            // for website in self:
            //     website_domain = website.domain or ''
            //     hostname = urlparse(website_domain).hostname or ''
            //     punycode_hostname = hostname.encode('idna').decode('ascii')
            //     website.domain_punycode = website_domain.replace(hostname, punycode_hostname)
            */
            return default;
        }

        protected async Task<Website> ComputeEventsAppNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: website.py) ---
            // def _compute_events_app_name(self):
            // for website in self:
            //     if not website.events_app_name:
            //         website.events_app_name = _('%s Events') % website.name
            */
            return default;
        }

        protected async Task<Website> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _compute_fiscal_position_id(self):
            // for website in self:
            //     website.fiscal_position_id = website._get_current_fiscal_position()
            */
            return default;
        }

        protected async Task<Website> ComputeHasSocialDefaultImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _compute_has_social_default_image(self):
            // for website in self:
            //     website.has_social_default_image = bool(website.social_default_image)
            */
            return default;
        }

        protected async Task<Website> ComputeInStoreDmIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py) ---
            // def _compute_in_store_dm_id(self):
            // in_store_delivery_methods = self.env['delivery.carrier'].search(
            //     [('delivery_type', '=', 'in_store'), ('is_published', '=', True)]
            // )
            // for website in self:
            //     website.in_store_dm_id = in_store_delivery_methods.filtered_domain([
            //        '|', ('website_id', '=', False), ('website_id', '=', website.id),
            //        '|', ('company_id', '=', False), ('company_id', '=', website.company_id.id),
            //     ])[:1]
            */
            return default;
        }

        protected async Task<Website> ComputeLanguageCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _compute_language_count(self):
            // for website in self:
            //     website.language_count = len(website.language_ids)
            */
            return default;
        }

        protected async Task<Website> ComputeMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _compute_menu(self):
            // for website in self:
            //     menus = self.env['website.menu'].browse(website._get_menu_ids())
            // 
            //     # use field parent_id (1 query) to determine field child_id (2 queries by level)"
            //     for menu in menus:
            //         menu._cache['child_id'] = ()
            //     for menu in menus:
            //         # don't add child menu if parent is forbidden
            //         if menu.parent_id and menu.parent_id in menus:
            //             menu.parent_id._cache['child_id'] += (menu.id,)
            // 
            //     # prefetch every website.page and ir.ui.view at once
            //     menus.mapped('is_visible')
            // 
            //     top_menus = menus.filtered(lambda m: not m.parent_id)
            //     website.menu_id = top_menus and top_menus[0].id or False
            */
            return default;
        }

        protected async Task<Website> ComputePricelistIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _compute_pricelist_id(self):
            // for website in self:
            //     website.pricelist_id = website._get_current_pricelist()
            */
            return default;
        }

        protected async Task<Website> ComputePricelistIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _compute_pricelist_ids(self):
            // for website in self:
            //     website = website.with_company(website.company_id)
            //     ProductPricelist = website.env['product.pricelist']  # with correct company in env
            //     website.pricelist_ids = ProductPricelist.sudo().search(
            //         ProductPricelist._get_website_pricelists_domain(website)
            //     )
            */
            return default;
        }

        public async Task<Website> ConfiguratorApplyAsync(Guid id)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_apply(self, **kwargs):
            // website = self.get_current_website()
            // theme_name = kwargs['theme_name']
            // theme = self.env['ir.module.module'].search([('name', '=', theme_name)])
            // redirect_url = theme.button_choose_theme()
            // 
            // website.configurator_done = True
            // 
            // # Enable tour
            // tour_asset_id = self.env.ref('website.configurator_tour')
            // tour_asset_id.copy({'key': tour_asset_id.key, 'website_id': website.id, 'active': True})
            // 
            // # Set logo from generated attachment or from company's logo
            // logo_attachment_id = kwargs.get('logo_attachment_id')
            // company = website.company_id
            // if logo_attachment_id:
            //     attachment = self.env['ir.attachment'].browse(logo_attachment_id)
            //     attachment.write({
            //         'res_model': 'website',
            //         'res_field': 'logo',
            //         'res_id': website.id,
            //     })
            // elif not logo_attachment_id and not company.uses_default_logo:
            //     website.logo = company.logo.decode('utf-8')
            // 
            // # Configure the color palette
            // selected_palette = kwargs.get('selected_palette')
            // if selected_palette:
            //     Assets = self.env['web_editor.assets']
            //     selected_palette_name = selected_palette if isinstance(selected_palette, str) else 'base-1'
            //     Assets.make_scss_customization(
            //         '/website/static/src/scss/options/user_values.scss',
            //         {'color-palettes-name': "'%s'" % selected_palette_name}
            //     )
            //     if isinstance(selected_palette, list):
            //         Assets.make_scss_customization(
            //             '/website/static/src/scss/options/colors/user_color_palette.scss',
            //             {f'o-color-{i}': color for i, color in enumerate(selected_palette, 1)}
            //         )
            // 
            // # Update CTA
            // cta_data = website.get_cta_data(kwargs.get('website_purpose'), kwargs.get('website_type'))
            // if cta_data['cta_btn_text']:
            //     xpath_view = 'website.snippets'
            //     parent_view = self.env['website'].with_context(website_id=website.id).viewref(xpath_view)
            //     self.env['ir.ui.view'].create({
            //         'name': parent_view.key + ' CTA',
            //         'key': parent_view.key + "_cta",
            //         'inherit_id': parent_view.id,
            //         'website_id': website.id,
            //         'type': 'qweb',
            //         'priority': 32,
            //         'arch_db': """
            //             <data>
            //                 <xpath expr="//t[@t-set='cta_btn_href']" position="replace">
            //                     <t t-set="cta_btn_href">%s</t>
            //                 </xpath>
            //                 <xpath expr="//t[@t-set='cta_btn_text']" position="replace">
            //                     <t t-set="cta_btn_text">%s</t>
            //                 </xpath>
            //             </data>
            //         """ % (cta_data['cta_btn_href'], cta_data['cta_btn_text'])
            //     })
            //     try:
            //         view_id = self.env['website'].viewref('website.header_call_to_action')
            //         if view_id:
            //             el = etree.fromstring(view_id.arch_db)
            //             btn_cta_el = el.xpath("//a[hasclass('btn_cta')]")
            //             if btn_cta_el:
            //                 btn_cta_el[0].attrib['href'] = cta_data['cta_btn_href']
            //                 btn_cta_el[0].text = cta_data['cta_btn_text']
            //             view_id.with_context(website_id=website.id).write({'arch_db': etree.tostring(el)})
            //     except ValueError as e:
            //         logger.warning(e)
            // 
            // # Configure the features
            // features = self.env['website.configurator.feature'].browse(kwargs.get('selected_features'))
            // 
            // menu_company = self.env['website.menu']
            // if len(features.filtered('menu_sequence')) > 5 and len(features.filtered('menu_company')) > 1:
            //     menu_company = self.env['website.menu'].create({
            //         'name': _('Company'),
            //         'parent_id': website.menu_id.id,
            //         'website_id': website.id,
            //         'sequence': 40,
            //     })
            // 
            // pages_views = {}
            // modules = self.env['ir.module.module']
            // module_data = {}
            // for feature in features:
            //     add_menu = bool(feature.menu_sequence)
            //     if feature.module_id:
            //         if feature.module_id.state != 'installed':
            //             modules += feature.module_id
            //         if add_menu:
            //             if feature.module_id.name != 'website_blog':
            //                 module_data[feature.feature_url] = {'sequence': feature.menu_sequence}
            //             else:
            //                 blogs = module_data.setdefault('#blog', [])
            //                 blogs.append({'name': feature.name, 'sequence': feature.menu_sequence})
            //     elif feature.page_view_id:
            //         result = self.env['website'].new_page(
            //             name=feature.name,
            //             add_menu=add_menu,
            //             page_values=dict(url=feature.feature_url, is_published=True),
            //             menu_values=add_menu and {
            //                 'url': feature.feature_url,
            //                 'sequence': feature.menu_sequence,
            //                 'parent_id': feature.menu_company and menu_company.id or website.menu_id.id,
            //             },
            //             template=feature.page_view_id.key
            //         )
            //         pages_views[feature.iap_page_code] = result['view_id']
            // 
            // if modules:
            //     modules.button_immediate_install()
            // 
            // self.env['website'].browse(website.id).configurator_set_menu_links(menu_company, module_data)
            // 
            // # We need to refresh the environment of the website because we installed
            // # some new module and we need the overrides of these new menus e.g. for
            // # the call to `get_cta_data`.
            // website = self.env['website'].browse(website.id)
            // 
            // # Update footers links, needs to be done after "Features" addition to go
            // # through module overrides of `configurator_get_footer_links`.
            // footer_links = website.configurator_get_footer_links()
            // footer_ids = [
            //     'website.template_footer_contact', 'website.template_footer_headline',
            //     'website.footer_custom', 'website.template_footer_links',
            //     'website.template_footer_minimalist',
            // ]
            // for footer_id in footer_ids:
            //     try:
            //         view_id = self.env['website'].viewref(footer_id)
            //         if view_id:
            //             # Deliberately hardcode dynamic code inside the view arch,
            //             # it will be transformed into static nodes after a save/edit
            //             # thanks to the t-ignore in parents node.
            //             arch_string = etree.fromstring(view_id.arch_db)
            //             el = arch_string.xpath("//t[@t-set='configurator_footer_links']")[0]
            //             el.attrib['t-value'] = json.dumps(footer_links)
            //             view_id.with_context(website_id=website.id).write({'arch_db': etree.tostring(arch_string)})
            //     except Exception as e:
            //         # The xml view could have been modified in the backend, we don't
            //         # want the xpath error to break the configurator feature
            //         logger.warning(e)
            // 
            // # Load suggestion from iap for selected pages
            // industry_id = kwargs['industry_id']
            // custom_resources = self._website_api_rpc(
            //     '/api/website/2/configurator/custom_resources/%s' % (industry_id if industry_id > 0 else ''),
            //     {'theme': theme_name}
            // )
            // 
            // # Generate text for the pages
            // requested_pages = set(pages_views.keys()).union({'homepage'})
            // configurator_snippets = website.get_theme_configurator_snippets(theme_name)
            // industry = kwargs['industry_name']
            // 
            // IrQweb = self.env['ir.qweb'].with_context(website_id=website.id, lang=website.default_lang_id.code)
            // snippets_cache = {}
            // translated_content = {}
            // hashes_to_tags_and_attributes = {}
            // html_string_to_wrapping_tags = {}
            // 
            // def _compute_placeholder(html_string):
            //     """
            //     Transforms an HTML string by converting specific HTML tags into a
            //     custom pseudo-markdown format.
            // 
            //     The function wraps the input `html_string` with a root `<div>`
            //     element, parses it into a tree, and iterates through the HTML
            //     elements. It replaces recognized HTML tags with a custom pseudo-
            //     markdown format like `#[text](hash_value)`, where `text` is the
            //     content of the tag and `hash_value` is the key to fetch the tag name
            //     and the attributes.
            // 
            //     Args:
            //         html_string (str): The input HTML string to be transformed.
            // 
            //     Returns:
            //         str: The transformed string with HTML tags replaced by
            //              pseudo-markdown.
            //     """
            //     tree = etree.fromstring(f'<div>{html_string}</div>')
            // 
            //     # Identifying one or more wrapping tags that enclose the entire HTML
            //     # content e.g., <strong><em>text ...</em></strong>. Store them to
            //     # reapply them after processing with chatGPT.
            //     wrapping_html = []
            //     for element in tree.iter():
            //         wrapping_html.append({"tag": element.tag, "attr": element.attrib})
            //         if len(element) != 1 \
            //                 or (element.text and element.text.strip()) \
            //                 or (element[-1].tail and element[-1].tail.strip()):
            //             break
            //     # Remove the wrapping element used for parsing into a tree
            //     wrapping_html = wrapping_html[1:]
            // 
            //     # Loop through all nodes, ignoring wrapping ones, to mark them with
            //     # a pseudo-markdown identifier if they are leaf nodes.
            //     nb_tags_to_skip = len(wrapping_html) + 1
            //     for cursor, element in enumerate(tree.iter()):
            //         if cursor < nb_tags_to_skip or len(element) > 0:
            //             continue
            // 
            //         # Generate a unique hash based on the element's text, tag
            //         # and attributes.
            //         attrib_string = ','.join(f'{key}={value}' for key, value in sorted(element.attrib.items()))
            //         combined_string = f'{element.text or ""}-{element.tag}-{attrib_string}'
            //         unique_uuid = uuid.uuid5(uuid.NAMESPACE_DNS, combined_string)
            //         hash_value = unique_uuid.hex[:12]
            // 
            //         hashes_to_tags_and_attributes[hash_value] = {"tag": element.tag, "attr": element.attrib}
            //         element.text = f'#[{element.text or "0"}]({hash_value})'
            // 
            //     res = tree.xpath('string()')
            // 
            //     # If there is at least one wrapping tag, save the way it needs to
            //     # be re-applied.
            //     if wrapping_html:
            //         tags = [
            //             (
            //                 f'<{tag}{" " if attrs else ""}{attrs}>',
            //                 f'</{tag}>'
            //             )
            //             for el in wrapping_html
            //             for tag, attrs in [(el["tag"], " ".join([f'{k}="{v}"' for k, v in el["attr"].items()]))]
            //         ]
            //         opening_tags, closing_tags = zip(*tags)
            //         html_string_to_wrapping_tags[html_string] = f'{"".join(opening_tags)}$0{"".join(closing_tags[::-1])}'
            // 
            //     # Note that `get_text_content` here is still needed despite the use
            //     # of `string()` in the XPath expression above. Indeed, it allows to
            //     # strip newlines and double-spaces, which would confuse IAP (without
            //     # this, it does not perform any replacement for some reason).
            //     return xml_translate.get_text_content(res.strip())
            // 
            // def _render_snippet(key):
            //     # Using this avoids rendering the same snippet multiple times
            //     data = snippets_cache.get(key)
            //     if data:
            //         return data
            // 
            //     render = IrQweb._render(key, cta_data)
            // 
            //     terms = []
            //     xml_translate(terms.append, render)
            //     placeholders = [_compute_placeholder(term) for term in terms]
            // 
            //     if text_must_be_translated_for_openai:
            //         # Check if terms are translated.
            //         translation_dictionary = self.env['website.page']._fields['arch_db'].get_translation_dictionary(
            //             str(IrQweb._render(key, cta_data, lang="en_US")),
            //             {text_generation_target_lang: str(render)},
            //         )
            //         # Remove all numeric keys.
            //         translation_dictionary = {
            //             k: v
            //             for k, v in translation_dictionary.items()
            //             if not xml_translate.get_text_content(k).strip().isnumeric()
            //         }
            //         for from_lang_term, to_lang_terms in translation_dictionary.items():
            //             translated_content[from_lang_term] = to_lang_terms[text_generation_target_lang]
            // 
            //     data = (render, placeholders)
            //     snippets_cache[key] = data
            //     return data
            // 
            // text_generation_target_lang = self.get_current_website().default_lang_id.code
            // # If the target language is not English, we need a good translation
            // # coverage. But if the target lang is en_XX it's ok to have en_US text.
            // text_must_be_translated_for_openai = not text_generation_target_lang.startswith('en_')
            // generated_content = {}
            // for page_code in requested_pages - {'privacy_policy'}:
            //     snippet_list = configurator_snippets.get(page_code, [])
            //     for snippet in snippet_list:
            //         render, placeholders = _render_snippet(f'website.configurator_{page_code}_{snippet}')
            //         for placeholder in placeholders:
            //             generated_content[placeholder] = ''
            // if text_must_be_translated_for_openai:
            //     nb_terms_translated = len([k for k, v in translated_content.items() if k != v])
            //     nb_terms_total = len(translated_content)
            // else:
            //     nb_terms_translated = len(generated_content)
            //     nb_terms_total = len(generated_content)
            // translated_ratio = nb_terms_translated / nb_terms_total
            // logger.debug("Ratio of translated content: %s%% (%s/%s)", translated_ratio * 100, nb_terms_translated, nb_terms_total)
            // 
            // if translated_ratio > 0.8:
            //     try:
            //         database_id = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            //         response = self._OLG_api_rpc('/api/olg/1/generate_placeholder', {
            //             'placeholders': list(generated_content.keys()),
            //             'lang': website.default_lang_id.name,
            //             'industry': industry,
            //             'database_id': database_id,
            //         })
            //         name_replace_parser = re.compile(r"XXXX", re.MULTILINE)
            //         for key in generated_content:
            //             if response.get(key):
            //                 generated_content[key] = (name_replace_parser.sub(website.name, response[key], 0))
            //     except AccessError:
            //         # If IAP is broken continue normally (without generating text)
            //         pass
            // else:
            //     logger.info("Skip AI text generation because translation coverage is too low (%s%%)", translated_ratio * 100)
            // 
            // def _format_replacement(html_string):
            //     """
            //     Reapplies original HTML formatting by replacing pseudo-markdown
            //     with corresponding HTML tags.
            // 
            //     The function searches for the replacement of the given HTML string
            //     then processes it by identifying and replacing pseudo-markdown
            //     in the form of `#[string](hash)` with actual HTML tags. It uses
            //     stored tag and attribute information and reconstructs the correct
            //     HTML structure. Additionally, it handles any wrapping tags that was
            //     identified for the given HTML.
            // 
            //     Args:
            //         html_string (str): The source HTML whose replacement has to
            //             receive original formatting
            // 
            //     Returns:
            //         str: The text with HTML tags re-applied.
            //     """
            //     replacement = generated_content.get(_compute_placeholder(html_string))
            //     if not replacement:
            //         return html_string
            // 
            //     # Replace #[string](hash) with <tag>...</tag> based on stored tag
            //     # and attribute information
            //     def _replace_tag(match):
            //         content = match.group(1)  # The string inside the square brackets
            //         hash_value = match.group(2)  # The hash value inside the parentheses
            //         if hash_value not in hashes_to_tags_and_attributes:
            //             return content
            // 
            //         tag = hashes_to_tags_and_attributes[hash_value]['tag']
            //         attr = hashes_to_tags_and_attributes[hash_value]['attr']
            //         attr_string = (" " + " ".join([f'{key}="{value}"' for key, value in attr.items()])) if attr else ''
            // 
            //         # Handle self-closing tag if content is "0"
            //         if content == "0":
            //             return f'<{tag}{attr_string}/>'
            // 
            //         return f'<{tag}{attr_string}>{content}</{tag}>'
            // 
            //     # Use regular expression to find instances of #[string](hash) and
            //     # replace them
            //     tag_pattern = r'#\[([^\]]+)\]\(([^)]+)\)'
            //     replacement = re.sub(tag_pattern, _replace_tag, replacement)
            // 
            //     # Handle possible wrapping tags identified
            //     if html_string in html_string_to_wrapping_tags:
            //         replacement = html_string_to_wrapping_tags[html_string].replace('$0', replacement)
            // 
            //     return replacement
            // 
            // # Configure the pages
            // for page_code in requested_pages:
            //     snippet_list = configurator_snippets.get(page_code, [])
            //     if page_code == 'homepage':
            //         page_view_id = self.with_context(website_id=website.id).viewref('website.homepage')
            //     else:
            //         page_view_id = self.env['ir.ui.view'].browse(pages_views[page_code])
            //     rendered_snippets = []
            //     nb_snippets = len(snippet_list)
            //     for i, snippet in enumerate(snippet_list, start=1):
            //         try:
            //             render, placeholders = _render_snippet(f'website.configurator_{page_code}_{snippet}')
            //             # Fill rendered block with AI text
            //             render = xml_translate(_format_replacement, render)
            // 
            //             el = html.fromstring(render)
            // 
            //             # Add the data-snippet attribute to identify the snippet
            //             # for compatibility code
            //             el.attrib['data-snippet'] = snippet
            // 
            //             # Remove the previews needed for the snippets dialog
            //             dialog_preview_els = el.find_class('s_dialog_preview')
            //             for preview_el in dialog_preview_els:
            //                 preview_el.getparent().remove(preview_el)
            // 
            //             # Tweak the shape of the first snippet to connect it
            //             # properly with the header color in some themes
            //             if i == 1:
            //                 shape_el = el.xpath("//*[hasclass('o_we_shape')]")
            //                 if shape_el:
            //                     shape_el[0].attrib['class'] += ' o_header_extra_shape_mapping'
            // 
            //             # Tweak the shape of the last snippet to connect it
            //             # properly with the footer color in some themes
            //             if i == nb_snippets:
            //                 shape_el = el.xpath("//*[hasclass('o_we_shape')]")
            //                 if shape_el:
            //                     shape_el[0].attrib['class'] += ' o_footer_extra_shape_mapping'
            //             rendered_snippet = etree.tostring(el, encoding='unicode')
            //             rendered_snippets.append(rendered_snippet)
            //         except ValueError as e:
            //             logger.warning(e)
            //     page_view_id.save(value=f'<div class="oe_structure">{"".join(rendered_snippets)}</div>',
            //                       xpath="(//div[hasclass('oe_structure')])[last()]")
            // 
            // # Configure the images
            // images = custom_resources.get('images', {})
            // names = self.env['ir.model.data'].search([
            //     ('name', '=ilike', f'configurator\\_{website.id}\\_%'),
            //     ('module', '=', 'website'),
            //     ('model', '=', 'ir.attachment')
            // ]).mapped('name')
            // for name, image_src in images.items():
            //     extn_identifier = 'configurator_%s_%s' % (website.id, name.split('.')[1])
            //     if extn_identifier in names:
            //         continue
            //     try:
            //         response = requests.get(image_src, timeout=3)
            //         response.raise_for_status()
            //     except Exception as e:
            //         logger.warning("Failed to download image: %s.\n%s", image_src, e)
            //     else:
            //         attachment = self.env['ir.attachment'].create({
            //             'name': name,
            //             'website_id': website.id,
            //             'key': name,
            //             'type': 'binary',
            //             'raw': response.content,
            //             'public': True,
            //         })
            //         self.env['ir.model.data'].create({
            //             'name': extn_identifier,
            //             'module': 'website',
            //             'model': 'ir.attachment',
            //             'res_id': attachment.id,
            //             'noupdate': True,
            //         })
            // 
            // def fallback_create_missing_industry_image(image_name, fallback_img_name):
            //     """ If an industry did not specify an image, this method allows that
            //     specific image to be using the same image as another fallback one.
            //     """
            //     image_name = f'website.{image_name}'
            //     if (
            //         image_name not in images.keys()
            //         and f'website.{fallback_img_name}' in images.keys()
            //     ):
            //         extn_identifier = 'configurator_%s_%s' % (website.id, image_name.split('.')[1])
            //         if extn_identifier not in names:
            //             attachment = self.env['ir.attachment'].create({
            //                 'name': image_name,
            //                 'website_id': website.id,
            //                 'key': image_name,
            //                 'type': 'binary',
            //                 'raw': self.env.ref(f'website.configurator_{website.id}_{fallback_img_name}').raw,
            //                 'public': True,
            //             })
            //             self.env['ir.model.data'].create({
            //                 'name': extn_identifier,
            //                 'module': 'website',
            //                 'model': 'ir.attachment',
            //                 'res_id': attachment.id,
            //                 'noupdate': True,
            //             })
            // 
            // try:
            //     # TODO: Remove this try/except, safety net because it was merged
            //     #       to close to OXP.
            //     fallback_create_missing_industry_image('s_intro_pill_default_image', 'library_image_10')
            //     fallback_create_missing_industry_image('s_intro_pill_default_image_2', 'library_image_14')
            //     fallback_create_missing_industry_image('s_banner_default_image_2', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_banner_default_image_3', 's_product_list_default_image_1')
            //     fallback_create_missing_industry_image('s_striped_top_default_image', 's_picture_default_image')
            //     fallback_create_missing_industry_image('s_text_cover_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_showcase_default_image', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_image_hexagonal_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_image_hexagonal_default_image_1', 's_company_team_image_1')
            //     fallback_create_missing_industry_image('s_accordion_image_default_image', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_pricelist_boxed_default_background', 's_product_catalog_default_image')
            //     fallback_create_missing_industry_image('s_image_title_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_key_images_default_image_1', 's_media_list_default_image_1')
            //     fallback_create_missing_industry_image('s_key_images_default_image_2', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_key_images_default_image_3', 's_media_list_default_image_2')
            //     fallback_create_missing_industry_image('s_key_images_default_image_4', 's_text_image_default_image')
            //     fallback_create_missing_industry_image('s_kickoff_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_quadrant_default_image_1', 'library_image_03')
            //     fallback_create_missing_industry_image('s_quadrant_default_image_2', 'library_image_10')
            //     fallback_create_missing_industry_image('s_quadrant_default_image_3', 'library_image_13')
            //     fallback_create_missing_industry_image('s_quadrant_default_image_4', 'library_image_05')
            //     fallback_create_missing_industry_image('s_sidegrid_default_image_1', 'library_image_03')
            //     fallback_create_missing_industry_image('s_sidegrid_default_image_2', 'library_image_10')
            //     fallback_create_missing_industry_image('s_sidegrid_default_image_3', 'library_image_13')
            //     fallback_create_missing_industry_image('s_sidegrid_default_image_4', 'library_image_05')
            //     fallback_create_missing_industry_image('s_cta_box_default_image', 'library_image_02')
            //     fallback_create_missing_industry_image('s_image_punchy_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_image_frame_default_image', 's_carousel_default_image_2')
            //     fallback_create_missing_industry_image('s_carousel_intro_default_image_1', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_carousel_intro_default_image_2', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_carousel_intro_default_image_3', 's_text_image_default_image')
            // 
            //     fallback_create_missing_industry_image('s_framed_intro_default_image', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_wavy_grid_default_image_1', 's_cover_default_image')
            //     fallback_create_missing_industry_image('s_wavy_grid_default_image_2', 's_image_text_default_image')
            //     fallback_create_missing_industry_image('s_wavy_grid_default_image_3', 's_text_image_default_image')
            //     fallback_create_missing_industry_image('s_wavy_grid_default_image_4', 's_carousel_default_image_1')
            // 
            // except Exception:
            //     pass
            // 
            // return {'url': redirect_url, 'website_id': website.id}
            #endif
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorGetFooterLinksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_get_footer_links(self):
            // return [
            //     {'text': _("Privacy Policy"), 'href': '/privacy'},
            // ]
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def configurator_get_footer_links(self):
            // links = super().configurator_get_footer_links()
            // links.append({'text': _("Forum"), 'href': '/forum'})
            // return links
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorInitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_init(self):
            // r = dict()
            // theme = self.env["ir.module.module"].search([("name", "=", "theme_default")])
            // current_website = self.get_current_website()
            // company = current_website.company_id
            // configurator_features = self.env['website.configurator.feature'].search([])
            // r['features'] = [{
            //     'id': feature.id,
            //     'name': feature.name,
            //     'description': feature.description,
            //     'type': 'page' if feature.page_view_id else 'app',
            //     'icon': feature.icon,
            //     'website_config_preselection': feature.website_config_preselection,
            //     'module_state': feature.module_id.state,
            // } for feature in configurator_features]
            // r['logo'] = False
            // if not company.uses_default_logo:
            //     r['logo'] = company.logo.decode('utf-8')
            // if current_website.configurator_done:
            //     r['redirect_url'] = theme.button_choose_theme()
            // try:
            //     result = self._website_api_rpc('/api/website/1/configurator/industries', {'lang': self.env.context.get('lang')})
            //     r['industries'] = result['industries']
            // except AccessError as e:
            //     logger.warning(e.args[0])
            //     r['industries'] = []
            // return r
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorMissingIndustryAsync(Guid id, WebsiteConfiguratorMissingIndustryRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_missing_industry(self, unknown_industry):
            // self._website_api_rpc(
            //     '/api/website/unknown_industry',
            //     {
            //         'unknown_industry': unknown_industry,
            //         'lang': self.env.context.get('lang'),
            //     }
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorRecommendedThemesAsync(Guid id, WebsiteConfiguratorRecommendedThemesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_recommended_themes(self, industry_id, palette, result_nbr_max=3):
            // Module = request.env['ir.module.module']
            // domain = Module.get_themes_domain()
            // domain = AND([[('name', '!=', 'theme_default')], domain])
            // client_themes = Module.search(domain).mapped('name')
            // client_themes_img = {t: get_manifest(t).get('images_preview_theme', {}) for t in client_themes if get_manifest(t)}
            // themes_suggested = self._website_api_rpc(
            //     '/api/website/2/configurator/recommended_themes/%s' % (industry_id if industry_id > 0 else ''),
            //     {
            //         'client_themes': client_themes_img,
            //         'result_nbr_max': result_nbr_max,
            //     }
            // )
            // process_svg = self.env['website.configurator.feature']._process_svg
            // for theme in themes_suggested:
            //     theme['svg'] = process_svg(theme['name'], palette, theme.pop('image_urls'))
            // return themes_suggested
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorSetMenuLinksAsync(Guid id, WebsiteConfiguratorSetMenuLinksRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_set_menu_links(self, menu_company, module_data):
            // menus = self.env['website.menu'].search([('url', 'in', list(module_data.keys())), ('website_id', '=', self.id)])
            // for m in menus:
            //     m.sequence = module_data[m.url]['sequence']
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website.py) ---
            // def configurator_set_menu_links(self, menu_company, module_data):
            // blogs = module_data.get('#blog', [])
            // for idx, blog in enumerate(blogs):
            //     new_blog = self.env['blog.blog'].create({
            //         'name': blog['name'],
            //         'website_id': self.id,
            //     })
            //     blog_menu_values = {
            //         'name': blog['name'],
            //         'url': '/blog/%s' % new_blog.id,
            //         'sequence': blog['sequence'],
            //         'parent_id': menu_company.id if menu_company else self.menu_id.id,
            //         'website_id': self.id,
            //     }
            //     if idx == 0:
            //         blog_menu = self.env['website.menu'].search([('url', '=', '/blog'), ('website_id', '=', self.id)])
            //         blog_menu.write(blog_menu_values)
            //     else:
            //         self.env['website.menu'].create(blog_menu_values)
            // super().configurator_set_menu_links(menu_company, module_data)
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def configurator_set_menu_links(self, menu_company, module_data):
            // # Forum menu should only be a footer link, not a menu
            // forum_menu = self.env['website.menu'].search([('url', '=', '/forum'), ('website_id', '=', self.id)])
            // forum_menu.unlink()
            // super().configurator_set_menu_links(menu_company, module_data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> ConfiguratorSkipAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def configurator_skip(self):
            // website = self.get_current_website()
            // website.configurator_done = True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> CopyMenuHierarchyAsync(Guid id, WebsiteCopyMenuHierarchyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def copy_menu_hierarchy(self, top_menu):
            // def copy_menu(menu, t_menu):
            //     new_menu = menu.copy({
            //         'parent_id': t_menu.id,
            //         'website_id': self.id,
            //     })
            //     for submenu in menu.child_id:
            //         copy_menu(submenu, new_menu)
            // for website in self:
            //     new_top_menu = top_menu.copy({
            //         'name': _('Top Menu for Website %s', website.id),
            //         'website_id': website.id,
            //     })
            //     for submenu in top_menu.child_id:
            //         copy_menu(submenu, new_top_menu)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> CreateAndRedirectConfiguratorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def create_and_redirect_configurator(self):
            // self._force()
            // configurator_action_todo = self.env.ref('website.website_configurator_todo')
            // return configurator_action_todo.action_launch()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<Website> CreateAsync(Website entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._handle_create_write(vals)
            // 
            //     if 'user_id' not in vals:
            //         company = self.env['res.company'].browse(vals.get('company_id'))
            //         vals['user_id'] = company._get_public_user().id if company else self.env.ref('base.public_user').id
            // 
            // websites = super().create(vals_list)
            // websites.company_id._compute_website_id()
            // for website in websites:
            //     website._bootstrap_homepage()
            // 
            // if not self.env.user.has_group('website.group_multi_website') and self.search_count([]) > 1:
            //     all_user_groups = 'base.group_portal,base.group_user,base.group_public'
            //     groups = self.env['res.groups'].concat(*(self.env.ref(it) for it in all_user_groups.split(',')))
            //     groups.write({'implied_ids': [(4, self.env.ref('website.group_multi_website').id)]})
            // 
            // return websites
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def create(self, vals_list):
            // websites = super().create(vals_list)
            // websites._update_forum_count()
            // return websites
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<Website> DashboardRedirectAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def action_dashboard_redirect(self):
            // if (self.env.user.has_group('base.group_system')
            //         or self.env.user.has_group('website.group_website_designer')):
            //     return self.env["ir.actions.actions"]._for_xml_id("website.backend_dashboard")
            // return self.env["ir.actions.actions"]._for_xml_id("website.action_website")
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def action_dashboard_redirect(self):
            // if self.env.user.has_group('sales_team.group_sale_salesman'):
            //     return self.env['ir.actions.actions']._for_xml_id('website.backend_dashboard')
            // return super().action_dashboard_redirect()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> DefaultFaviconInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_favicon(self):
            // with tools.file_open('web/static/img/favicon.ico', 'rb') as f:
            //     return base64.b64encode(f.read())
            */
            return default;
        }

        protected async Task<Website> DefaultLanguageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_language(self):
            // lang_code = self.env['ir.default']._get('res.partner', 'lang')
            // def_lang_id = self.env['res.lang']._get_data(code=lang_code).id
            // return def_lang_id or self._active_languages()[0]
            */
            return default;
        }

        protected async Task<Website> DefaultLogoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_logo(self):
            // with tools.file_open('website/static/src/img/website_logo.svg', 'rb') as f:
            //     return base64.b64encode(f.read())
            */
            return default;
        }

        protected async Task<Website> DefaultRecoveryMailTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _default_recovery_mail_template(self):
            // try:
            //     return self.env.ref('website_sale.mail_template_sale_cart_recovery').id
            // except ValueError:
            //     return False
            */
            return default;
        }

        protected async Task<Website> DefaultSalesteamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _default_salesteam_id(self):
            // team = self.env.ref('sales_team.salesteam_website_sales', raise_if_not_found=False)
            // if team and team.active:
            //     return team.id
            // return None
            */
            return default;
        }

        protected async Task<Website> DefaultSocialFacebookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_facebook(self):
            // return self.env.ref('base.main_company').social_facebook
            */
            return default;
        }

        protected async Task<Website> DefaultSocialGithubInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_github(self):
            // return self.env.ref('base.main_company').social_github
            */
            return default;
        }

        protected async Task<Website> DefaultSocialInstagramInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_instagram(self):
            // return self.env.ref('base.main_company').social_instagram
            */
            return default;
        }

        protected async Task<Website> DefaultSocialLinkedinInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_linkedin(self):
            // return self.env.ref('base.main_company').social_linkedin
            */
            return default;
        }

        protected async Task<Website> DefaultSocialTiktokInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_tiktok(self):
            // return self.env.ref('base.main_company').social_tiktok
            */
            return default;
        }

        protected async Task<Website> DefaultSocialTwitterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_twitter(self):
            // return self.env.ref('base.main_company').social_twitter
            */
            return default;
        }

        protected async Task<Website> DefaultSocialYoutubeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _default_social_youtube(self):
            // return self.env.ref('base.main_company').social_youtube
            */
            return default;
        }

        protected async Task<Website> DisableUnusedSnippetsAssetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _disable_unused_snippets_assets(self):
            // snippet_assets = self.env['ir.asset'].with_context(active_test=False).search_fetch(
            //     [('path', 'like', '/static%/snippets/')],
            //     ['active', 'path'], order='id')
            // snippet_re = re.compile(r'(\w*)\/.*\/snippets\/(\w*)\/(\d{3})(?:_\w*)?\.(js|scss)')
            // # regex will match /module/static/[.../]/snippets/snippet_id/XXX[_variable].asset_type
            // # _variable is not kept since only module, snippet_id, asset_version (XXX), asset_type are relevant
            // html_fields = self._get_html_fields()
            // snippet_used = {}
            // for snippet_asset in snippet_assets:
            //     match = snippet_re.match(snippet_asset.path)
            //     if not match:
            //         continue
            //     (snippet_module, snippet_id, asset_version, asset_type) = match.groups()
            //     if asset_type == 'scss':
            //         asset_type = 'css'
            //     key = (snippet_id, asset_version, asset_type)  # module is not relevant, we want the first one in the asset id order to filter module extension
            //     if key not in snippet_used:
            //         snippet_used[key] = self._is_snippet_used(snippet_module, snippet_id, asset_version, asset_type, html_fields)
            //     is_snippet_used = snippet_used[key]
            //     if is_snippet_used != snippet_asset.active:
            //         snippet_asset.active = is_snippet_used
            //         # Handle missing data-snippet attributes
            //         if snippet_id == 's_quotes_carousel' and asset_type == 'css' and asset_version in ['000', '001']:
            //             old_blockquote_key = ('s_blockquote', '000', 'css')
            //             if not snippet_used.get(old_blockquote_key):
            //                 snippet_used[old_blockquote_key] = True
            //                 old_blockquote_asset = snippet_assets.filtered(lambda asset: asset.path == 'website/static/src/snippets/s_blockquote/000.scss')
            //                 if old_blockquote_asset and not old_blockquote_asset.active:
            //                     old_blockquote_asset.active = True
            // self.env['ir.asset'].flush_model()
            */
            return default;
        }

        protected async Task<Website> DisplayPartnerB2bFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _display_partner_b2b_fields(self):
            // """ This method is to be inherited by localizations and return
            // True if localization should always displayed b2b fields """
            // self.ensure_one()
            // 
            // return self.is_view_active('website_sale.address_b2b')
            */
            return default;
        }

        protected async Task<Website> EnumeratePagesInternalAsync(object query_string, object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _enumerate_pages(self, query_string=None, force=False):
            // """ Available pages in the website/CMS. This is mostly used for links
            //     generation and can be overridden by modules setting up new HTML
            //     controllers for dynamic pages (e.g. blog).
            //     By default, returns template views marked as pages.
            //     :param str query_string: a (user-provided) string, fetches pages
            //                              matching the string
            //     :returns: a list of mappings with two keys: ``name`` is the displayable
            //               name of the resource (page), ``url`` is the absolute URL
            //               of the same.
            //     :rtype: list({name: str, url: str})
            // """
            // # ==== WEBSITE.PAGES ====
            // # '/' already has a http.route & is in the routing_map so it will already have an entry in the xml
            // domain = [('url', '!=', '/')]
            // if not force:
            //     domain += [('website_indexed', '=', True), ('visibility', '=', False)]
            //     # is_visible
            //     domain += [
            //         ('website_published', '=', True), ('visibility', '=', False),
            //         '|', ('date_publish', '=', False), ('date_publish', '<=', fields.Datetime.now())
            //     ]
            // 
            // if query_string:
            //     domain += [('url', 'like', query_string)]
            // 
            // pages = self._get_website_pages(domain)
            // 
            // for page in pages:
            //     record = {'loc': page['url'], 'id': page['id'], 'name': page['name']}
            //     if page.view_id and page.view_id.priority != 16:
            //         record['priority'] = min(round(page.view_id.priority / 32.0, 1), 1)
            //     last_updated_date = max(
            //         [d for d in (page.write_date, page.view_id.write_date) if isinstance(d, datetime)],
            //         default=None,
            //     )
            //     if last_updated_date:
            //         record['lastmod'] = last_updated_date.date()
            //     yield record
            // 
            // # ==== CONTROLLERS ====
            // router = self.env['ir.http'].routing_map()
            // url_set = set()
            // 
            // sitemap_endpoint_done = set()
            // 
            // for rule in router.iter_rules():
            //     if 'sitemap' in rule.endpoint.routing and rule.endpoint.routing['sitemap'] is not True:
            //         endpoint_func = rule.endpoint.func
            //         if isinstance(endpoint_func, functools.partial): # follow partial in case of redirect
            //             endpoint_func = endpoint_func.func
            //         if endpoint_func.__func__ in sitemap_endpoint_done:
            //             continue
            //         sitemap_endpoint_done.add(endpoint_func.__func__)
            // 
            //         func = rule.endpoint.routing['sitemap']
            //         if func is False:
            //             continue
            //         for loc in func(self.with_context(lang=self.default_lang_id.code).env, rule, query_string):
            //             yield loc
            //         continue
            // 
            //     if not self.rule_is_enumerable(rule):
            //         continue
            // 
            //     if 'sitemap' not in rule.endpoint.routing:
            //         logger.warning('No Sitemap value provided for controller %s (%s)' %
            //                        (rule.endpoint.original_endpoint, ','.join(rule.endpoint.routing['routes'])))
            // 
            //     converters = rule._converters or {}
            //     if query_string and not converters and (query_string not in rule.build({}, append_unknown=False)[1]):
            //         continue
            // 
            //     values = [{}]
            //     # converters with a domain are processed after the other ones
            //     convitems = sorted(
            //         converters.items(),
            //         key=lambda x: (hasattr(x[1], 'domain') and (x[1].domain != '[]'), rule._trace.index((True, x[0]))))
            // 
            //     for (i, (name, converter)) in enumerate(convitems):
            //         if 'website_id' in self.env[converter.model]._fields and (not converter.domain or converter.domain == '[]'):
            //             converter.domain = "[('website_id', 'in', (False, current_website_id))]"
            // 
            //         newval = []
            //         for val in values:
            //             query = i == len(convitems) - 1 and query_string
            //             if query:
            //                 r = "".join([x[1] for x in rule._trace[1:] if not x[0]])  # remove model converter from route
            //                 query = sitemap_qs2dom(query, r, self.env[converter.model]._rec_name)
            //                 if query == FALSE_DOMAIN:
            //                     continue
            // 
            //             for rec in converter.generate(self.env, args=val, dom=query):
            //                 newval.append(val.copy())
            //                 newval[-1].update({name: rec.with_context(lang=self.default_lang_id.code)})
            //         values = newval
            // 
            //     for value in values:
            //         domain_part, url = rule.build(value, append_unknown=False)
            //         pattern = query_string and '*%s*' % "*".join(query_string.split('/'))
            //         if not query_string or fnmatch.fnmatch(url.lower(), pattern):
            //             page = {'loc': url}
            //             if url in url_set:
            //                 continue
            //             url_set.add(url)
            // 
            //             yield page
            */
            return default;
        }

        protected async Task<Website> ForceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _force(self):
            // self._force_website(self.id)
            */
            return default;
        }

        protected async Task<Website> ForceWebsiteInternalAsync(Guid website_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _force_website(self, website_id):
            // if request:
            //     request.session['force_website_id'] = website_id and str(website_id).isdigit() and int(website_id)
            */
            return default;
        }

        protected async Task<Website> GetBlockedIframeContainersClassesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_blocked_iframe_containers_classes(self):
            // return {
            //     's_map',
            //     's_instagram_page',
            //     'o_facebook_page',
            //     'o_background_video',
            //     'media_iframe_video',
            // }
            */
            return default;
        }

        protected async Task<Website> GetBlockedThirdPartyDomainsListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_blocked_third_party_domains_list(self):
            // return self.blocked_third_party_domains.split('\n')
            */
            return default;
        }

        protected async Task<Website> GetCachedInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_cached(self, field):
            // return self._get_cached_values()[field]
            */
            return default;
        }

        protected async Task<Website> GetCachedPricelistIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_cached_pricelist_id(self):
            // return request and request.session.get('website_sale_current_pl') or None
            */
            return default;
        }

        protected async Task<Website> GetCachedValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_cached_values(self):
            // self.ensure_one()
            // # ir.http:_match is called by ir.http:_serve_db at a time when the
            // # environment hasn't been completely initialized (i.e. before the method
            // # ir.http:_authenticate is called by ir.http:_serve_ir_http), and its
            // # context language hasn't been checked against activated languages yet.
            // 
            // # Inside ir.http:_match, the http_routing module is trying to retrieve
            // # the default language via _get_default_lang, which is overridden by the
            // # website module and calls website._get_cached('default_lang_id'), which
            // # eventually calls this method.
            // 
            // # Here, we manually prefetch the needed fields only to avoid prefetching
            // # any translatable field, such as contact_us_button_url by website_sale,
            // # as translating to an invalid language would result in an error.
            // self.fetch(['user_id', 'company_id', 'default_lang_id', 'homepage_url'])
            // return {
            //     'user_id': self.user_id.id,
            //     'company_id': self.company_id.id,
            //     'default_lang_id': self.default_lang_id.id,
            //     'homepage_url': self.homepage_url,
            // }
            */
            return default;
        }

        public async Task<Website> GetCdnUrlAsync(Guid id, WebsiteGetCdnUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_cdn_url(self, uri):
            // self.ensure_one()
            // if not uri:
            //     return ''
            // cdn_url = self.cdn_url
            // cdn_filters = (self.cdn_filters or '').splitlines()
            // for flt in cdn_filters:
            //     if flt and re.match(flt, uri):
            //         return urls.url_join(cdn_url, uri)
            // return uri
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetCheckoutStepListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_checkout_step_list(self):
            // """ Return an ordered list of steps according to the current template rendered.
            // 
            // :rtype: list
            // :return: A list with the following structure:
            //     [
            //         [xmlid],
            //         {
            //             'name': str,
            //             'current_href': str,
            //             'main_button': str,
            //             'main_button_href': str,
            //             'back_button': str,
            //             'back_button_href': str
            //         }
            //     ]
            // """
            // self.ensure_one()
            // is_extra_step_active = self.viewref('website_sale.extra_info').active
            // redirect_to_sign_in = self.account_on_checkout == 'mandatory' and self.is_public_user()
            // 
            // steps = [(['website_sale.cart'], {
            //     'name': _lt("Review Order"),
            //     'current_href': '/shop/cart',
            //     'main_button': _lt("Sign In") if redirect_to_sign_in else _lt("Checkout"),
            //     'main_button_href': f'{"/web/login?redirect=" if redirect_to_sign_in else ""}/shop/checkout?try_skip_step=true',
            //     'back_button':  _lt("Continue shopping"),
            //     'back_button_href': '/shop',
            // }), (['website_sale.checkout', 'website_sale.address'], {
            //     'name': _lt("Delivery"),
            //     'current_href': '/shop/checkout',
            //     'main_button': _lt("Confirm"),
            //     'main_button_href': f'{"/shop/extra_info" if is_extra_step_active else "/shop/confirm_order"}',
            //     'back_button':  _lt("Back to cart"),
            //     'back_button_href': '/shop/cart',
            // })]
            // if is_extra_step_active:
            //     steps.append((['website_sale.extra_info'], {
            //         'name': _lt("Extra Info"),
            //         'current_href': '/shop/extra_info',
            //         'main_button': _lt("Continue checkout"),
            //         'main_button_href': '/shop/confirm_order',
            //         'back_button':  _lt("Back to delivery"),
            //         'back_button_href': '/shop/checkout',
            //     }))
            // steps.append((['website_sale.payment'], {
            //     'name': _lt("Payment"),
            //     'current_href': '/shop/payment',
            //     'back_button':  _lt("Back to delivery"),
            //     'back_button_href': '/shop/checkout',
            // }))
            // return steps
            */
            return default;
        }

        protected async Task<Website> GetCheckoutStepsInternalAsync(object current_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_checkout_steps(self, current_step=None):
            // """ Return an ordered list of steps according to the current template rendered.
            // If `current_step` is provided, returns only the corresponding step.
            // Note: self.ensure_one()
            // :param str current_step: The xmlid of the current step, defaults to None.
            // :rtype: list
            // :return: A list containing the steps generated by :meth:`_get_checkout_step_list`.
            // """
            // self.ensure_one()
            // 
            // steps = self._get_checkout_step_list()
            // 
            // if current_step:
            //     return next(step for step in steps if current_step in step[0])[1]
            // return steps
            */
            return default;
        }

        public async Task<Website> GetClientActionAsync(Guid id, WebsiteGetClientActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_client_action(self, url, mode_edit=False, website_id=False):
            // action = self.env["ir.actions.actions"]._for_xml_id("website.website_preview")
            // action['context'] = {
            //     'params': {
            //         'path': url,
            //         'enable_editor': mode_edit,
            //         'website_id': website_id,
            //     }
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> GetClientUrlAsync(Guid id, WebsiteGetClientUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_client_action_url(self, url, mode_edit=False):
            // action_params = {
            //     "path": url,
            // }
            // if mode_edit:
            //     action_params["enable_editor"] = 1
            // return "/odoo/action-website.website_preview?" + urls.url_encode(action_params)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetCrmDefaultTeamDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm, FILE: website.py) ---
            // def _get_crm_default_team_domain(self):
            // if not self.env.user.has_group('crm.group_use_lead'):
            //     return [('use_opportunities', '=', True)]
            // return [('use_leads', '=', True)]
            */
            return default;
        }

        public async Task<Website> GetCtaDataAsync(Guid id, WebsiteGetCtaDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_cta_data(self, website_purpose, website_type):
            // return {'cta_btn_text': False, 'cta_btn_href': '/contactus'}
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: website.py) ---
            // def get_cta_data(self, website_purpose, website_type):
            // cta_data = super(Website, self).get_cta_data(website_purpose, website_type)
            // if website_purpose == 'sell_more' and website_type == 'event':
            //     cta_btn_text = _('Next Events')
            //     return {'cta_btn_text': cta_btn_text, 'cta_btn_href': '/event'}
            // return cta_data
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetCurrentFiscalPositionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_current_fiscal_position(self):
            // AccountFiscalPosition = self.env['account.fiscal.position'].sudo()
            // fpos = AccountFiscalPosition
            // partner_sudo = self.env.user.partner_id
            // 
            // # If the current user is the website public user, the fiscal position
            // # is computed according to geolocation.
            // if request and request.geoip.country_code and self.partner_id.id == partner_sudo.id:
            //     country = self.env['res.country'].search(
            //         [('code', '=', request.geoip.country_code)],
            //         limit=1,
            //     )
            //     partner_geoip = self.env["res.partner"].new({'country_id': country.id})
            //     fpos = AccountFiscalPosition._get_fiscal_position(partner_geoip)
            // 
            // if not fpos:
            //     fpos = AccountFiscalPosition._get_fiscal_position(partner_sudo)
            // 
            // return fpos
            */
            return default;
        }

        protected async Task<Website> GetCurrentPricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_current_pricelist(self):
            // """
            // :returns: The current pricelist record
            // """
            // self = self.with_company(self.company_id)
            // ProductPricelist = self.env['product.pricelist']
            // 
            // pricelist = ProductPricelist
            // if request and request.session.get('website_sale_current_pl'):
            //     # `website_sale_current_pl` is set only if the user specifically chose it:
            //     #  - Either, he chose it from the pricelist selection
            //     #  - Either, he entered a coupon code
            //     pricelist = ProductPricelist.browse(request.session['website_sale_current_pl']).exists().sudo()
            //     country_code = self._get_geoip_country_code()
            //     if not pricelist or not pricelist._is_available_on_website(self) or not pricelist._is_available_in_country(country_code):
            //         request.session.pop('website_sale_current_pl')
            //         pricelist = ProductPricelist
            // 
            // if not pricelist:
            //     partner_sudo = self.env.user.partner_id
            // 
            //     # If the user has a saved cart, it take the pricelist of this last unconfirmed cart
            //     pricelist = partner_sudo.last_website_so_id.pricelist_id
            //     if not pricelist:
            //         # The pricelist of the user set on its partner form.
            //         # If the user is not signed in, it's the public user pricelist
            //         pricelist = partner_sudo.property_product_pricelist
            // 
            //     # The list of available pricelists for this user.
            //     # If the user is signed in, and has a pricelist set different than the public user pricelist
            //     # then this pricelist will always be considered as available
            //     available_pricelists = self.get_pricelist_available()
            //     if available_pricelists and pricelist not in available_pricelists:
            //         # If there is at least one pricelist in the available pricelists
            //         # and the chosen pricelist is not within them
            //         # it then choose the first available pricelist.
            //         # This can only happen when the pricelist is the public user pricelist and this pricelist is not in the available pricelist for this localization
            //         # If the user is signed in, and has a special pricelist (different than the public user pricelist),
            //         # then this special pricelist is amongs these available pricelists, and therefore it won't fall in this case.
            //         pricelist = available_pricelists[0]
            // 
            // return pricelist
            */
            return default;
        }

        public async Task<Website> GetCurrentWebsiteAsync(Guid id, WebsiteGetCurrentWebsiteRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_current_website(self, fallback=True):
            // """ The current website is returned in the following order:
            // - the website forced in session `force_website_id`
            // - the website set in context
            // - (if frontend or fallback) the website matching the request's "domain"
            // - arbitrary the first website found in the database if `fallback` is set
            //   to `True`
            // - empty browse record
            // """
            // is_frontend_request = request and getattr(request, 'is_frontend', False)
            // if request and request.session.get('force_website_id'):
            //     website_id = self.browse(request.session['force_website_id']).exists()
            //     if not website_id:
            //         # Don't crash is session website got deleted
            //         request.session.pop('force_website_id')
            //     else:
            //         return website_id
            // 
            // website_id = self.env.context.get('website_id')
            // if website_id:
            //     return self.browse(website_id)
            // 
            // if not is_frontend_request and not fallback:
            //     # It's important than backend requests with no fallback requested
            //     # don't go through
            //     return self.browse(False)
            // 
            // # Reaching this point means that:
            // # - We didn't find a website in the session or in the context.
            // # - And we are either:
            // #   - in a frontend context
            // #   - in a backend context (or early in the dispatch stack) and a
            // #     fallback website is requested.
            // # We will now try to find a website matching the request host/domain (if
            // # there is one on request) or return a random one.
            // 
            // # The format of `httprequest.host` is `domain:port`
            // domain_name = (
            //     request and request.httprequest.host
            //     or hasattr(threading.current_thread(), 'url') and threading.current_thread().url
            //     or '')
            // website_id = self.sudo()._get_current_website_id(domain_name, fallback=fallback)
            // return self.browse(website_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetCurrentWebsiteIdInternalAsync(object domain_name, object fallback)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_current_website_id(self, domain_name, fallback=True):
            // """Get the current website id.
            // 
            // First find the website for which the configured `domain` (after
            // ignoring a potential scheme) is equal to the given
            // `domain_name`. If a match is found, return it immediately.
            // 
            // If there is no website found for the given `domain_name`, either
            // fallback to the first found website (no matter its `domain`) or return
            // False depending on the `fallback` parameter.
            // 
            // :param domain_name: the domain for which we want the website.
            //     In regard to the `url_parse` method, only the `netloc` part should
            //     be given here, no `scheme`.
            // :type domain_name: string
            // 
            // :param fallback: if True and no website is found for the specificed
            //     `domain_name`, return the first website (without filtering them)
            // :type fallback: bool
            // 
            // :return: id of the found website, or False if no website is found and
            //     `fallback` is False
            // :rtype: int or False
            // 
            // :raises: if `fallback` is True but no website at all is found
            // """
            // def _remove_port(domain_name):
            //     return (domain_name or '').split(':')[0]
            // 
            // def _filter_domain(website, domain_name, ignore_port=False):
            //     """Ignore `scheme` from the `domain`, just match the `netloc` which
            //     is host:port in the version of `url_parse` we use."""
            //     website_domain = get_base_domain(website.domain_punycode)
            //     if ignore_port:
            //         website_domain = _remove_port(website_domain)
            //         domain_name = _remove_port(domain_name)
            //     return website_domain.lower() == (domain_name or '').lower()
            // 
            // # We need to test two possibilities unicode or punycode (safety guard)
            // domain_name = domain_name.encode("idna").decode("ascii")
            // domain_name_idna = domain_name.encode("ascii").decode("idna")
            // 
            // # TODO: in master, store the computed field domain_punycode to avoid
            // #       the need to search on domain_name and domain_name_idna.
            // found_websites = self.search([
            //     '|',
            //     ('domain', 'ilike', _remove_port(domain_name)),
            //     ('domain', 'ilike', _remove_port(domain_name_idna)),
            // ])
            // # Filter for the exact domain (to filter out potential subdomains) due
            // # to the use of ilike.
            // # `domain_name` could be an empty string, in that case multiple website
            // # without a domain will be returned
            // websites = found_websites.filtered(lambda w: _filter_domain(w, domain_name))
            // # If there is no domain matching for the given port, ignore the port.
            // websites = websites or found_websites.filtered(lambda w: _filter_domain(w, domain_name, ignore_port=True))
            // 
            // if not websites:
            //     if not fallback:
            //         return False
            //     return self.search([], limit=1).id
            // 
            // return websites[0].id
            */
            return default;
        }

        protected async Task<Website> GetGeoipCountryCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_geoip_country_code(self):
            // return request and request.geoip.country_code or False
            */
            return default;
        }

        protected async Task<Website> GetHtmlFieldsBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_html_fields_blacklist(self):
            // return (
            //     'mail.message', 'mail.activity', 'digest.tip',
            // )
            */
            return default;
        }

        protected async Task<Website> GetHtmlFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_html_fields(self):
            // html_fields = [('ir.ui.view', 'arch_db')]
            // cr = self.env.cr
            // cr.execute("""
            //     SELECT f.model,
            //            f.name
            //       FROM ir_model_fields f
            //       JOIN ir_model m
            //         ON m.id = f.model_id
            //      WHERE f.ttype = 'html'
            //        AND f.store = true
            //        AND m.transient = false
            //        AND f.model NOT LIKE 'ir.actions%%'
            //        AND f.model NOT IN %s
            // """, ([self._get_html_fields_blacklist()]))
            // for model_name, field_name, in cr.fetchall():
            //     try:
            //         model = self.env[model_name]
            //         field = model._fields[field_name]
            //         if model._abstract or model._table_query is not None or not field.store:
            //             continue
            //     except KeyError:
            //         continue
            // 
            //     html_fields.append((model_name, field_name))
            // return html_fields
            */
            return default;
        }

        protected async Task<Website> GetLivechatChannelInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: website.py) ---
            // def _get_livechat_channel_info(self):
            // """ Get the livechat info dict (button text, channel name, ...) for the livechat channel of
            //     the current website.
            // """
            // self.ensure_one()
            // if self.channel_id:
            //     livechat_info = self.channel_id.sudo().get_livechat_info()
            //     if livechat_info['available']:
            //         livechat_request_session = self._get_livechat_request_session()
            //         if livechat_request_session:
            //             livechat_info['options']['force_thread'] = livechat_request_session
            //     return livechat_info
            // return {}
            */
            return default;
        }

        protected async Task<Website> GetLivechatRequestSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: website.py) ---
            // def _get_livechat_request_session(self):
            // """
            // Check if there is an opened chat request for the website livechat channel and the current visitor (from request).
            // If so, prepare the livechat session information that will be stored in visitor's cookies
            // and used by livechat widget to directly open this session instead of allowing the visitor to
            // initiate a new livechat session.
            // :param {int} channel_id: channel
            // :return: {dict} livechat request session information
            // """
            // visitor = self.env['website.visitor']._get_visitor_from_request()
            // chat_request_session = {}
            // if visitor:
            //     # get active chat_request linked to visitor
            //     chat_request_channel = self.env['discuss.channel'].sudo().search([
            //         ("channel_type", "=", "livechat"),
            //         ('livechat_visitor_id', '=', visitor.id),
            //         ('livechat_channel_id', '=', self.channel_id.id),
            //         ('livechat_active', '=', True),
            //         ('has_message', '=', True)
            //     ], order='create_date desc', limit=1)
            //     if chat_request_channel:
            //         if not visitor.partner_id:
            //             current_guest = self.env['mail.guest']._get_guest_from_context()
            //             channel_guest_member = chat_request_channel.channel_member_ids.filtered(lambda m: m.guest_id)
            //             if current_guest and current_guest != channel_guest_member.guest_id:
            //                 # Channel was created with a guest but the visitor was
            //                 # linked to another guest in the meantime. We need to
            //                 # update the channel to link it to the current guest.
            //                 chat_request_channel.write({'channel_member_ids': [
            //                     Command.unlink(channel_guest_member.id),
            //                     Command.create({'guest_id': current_guest.id, 'fold_state': 'open'})
            //                 ]})
            //             if not current_guest and channel_guest_member:
            //                 channel_guest_member.guest_id._set_auth_cookie()
            //                 chat_request_channel = chat_request_channel.with_context(guest=channel_guest_member.guest_id.sudo(False))
            //         if chat_request_channel.is_member:
            //             chat_request_session = {
            //                 "id": chat_request_channel.id,
            //                 "model": "discuss.channel",
            //             }
            // return chat_request_session
            */
            return default;
        }

        protected async Task<Website> GetMaxInStoreProductAvailableQtyInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py) ---
            // def _get_max_in_store_product_available_qty(self, product):
            // """ Return maximum amount of product available to deliver with in store delivery method. """
            // return max([
            //     product.with_context(warehouse_id=wh.id).free_qty
            //     for wh in self.sudo().in_store_dm_id.warehouse_ids
            // ], default=0)
            */
            return default;
        }

        protected async Task<Website> GetMenuIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_menu_ids(self):
            // return self.env['website.menu'].search([('website_id', '=', self.id)]).ids
            */
            return default;
        }

        protected async Task<Website> GetPlPartnerOrderInternalAsync(object country_code, object show_visible, Guid current_pl_id, List<Guid> website_pricelist_ids, Guid partner_pl_id, Guid order_pl_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_pl_partner_order(
            //     self, country_code, show_visible, current_pl_id, website_pricelist_ids,
            //     partner_pl_id=False, order_pl_id=False
            // ):
            //     """ Return the list of pricelists that can be used on website for the current user.
            // 
            //     :param str country_code: code iso or False, If set, we search only price list available for this country
            //     :param bool show_visible: if True, we don't display pricelist where selectable is False (Eg: Code promo)
            //     :param int current_pl_id: The current pricelist used on the website
            //         (If not selectable but currently used anyway, e.g. pricelist with promo code)
            //     :param tuple website_pricelist_ids: List of ids of pricelists available for this website
            //     :param int partner_pl_id: the partner pricelist
            //     :param int order_pl_id: the current cart pricelist
            //     :returns: list of product.pricelist ids
            //     :rtype: list
            //     """
            //     self.ensure_one()
            //     pricelists = self.env['product.pricelist']
            // 
            //     if show_visible:
            //         # Only show selectable or currently used pricelist (cart or session)
            //         check_pricelist = lambda pl: pl.selectable or pl.id in (current_pl_id, order_pl_id)
            //     else:
            //         check_pricelist = lambda _pl: True
            // 
            //     # Note: 1. pricelists from all_pl are already website compliant (went through
            //     #          `_get_website_pricelists_domain`)
            //     #       2. do not read `property_product_pricelist` here as `_get_pl_partner_order`
            //     #          is cached and the result of this method will be impacted by that field value.
            //     #          Pass it through `partner_pl_id` parameter instead to invalidate the cache.
            // 
            //     # If there is a GeoIP country, find a pricelist for it
            //     if country_code:
            //         pricelists |= self.env['res.country.group'].search(
            //             [('country_ids.code', '=', country_code)]
            //         ).pricelist_ids.filtered(
            //             lambda pl: pl._is_available_on_website(self) and check_pricelist(pl)
            //         )
            // 
            //     # no GeoIP or no pricelist for this country
            //     if not pricelists:
            //         pricelists = pricelists.browse(website_pricelist_ids).filtered(
            //             lambda pl: check_pricelist(pl) and not (country_code and pl.country_group_ids))
            // 
            //     # if logged in, add partner pl (which is `property_product_pricelist`, might not be website compliant)
            //     if not self.env.user._is_public():
            //         # keep partner_pricelist only if website compliant
            //         partner_pricelist = pricelists.browse(partner_pl_id).filtered(
            //             lambda pl:
            //                 pl._is_available_on_website(self)
            //                 and check_pricelist(pl)
            //                 and pl._is_available_in_country(country_code)
            //         )
            //         pricelists |= partner_pricelist
            // 
            //     # This method is cached, must not return records! See also #8795
            //     # sudo is needed to ensure no records rules are applied during the sorted call,
            //     # we only want to reorder the records on hand, not filter them.
            //     return pricelists.sudo().sorted().ids
            */
            return default;
        }

        protected async Task<Website> GetPlausibleScriptUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_plausible_script_url(self):
            // return self.env['ir.config_parameter'].sudo().get_param(
            //     'website.plausible_script',
            //     'https://plausible.io/js/plausible.js'
            // )
            */
            return default;
        }

        protected async Task<Website> GetPlausibleServerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_plausible_server(self):
            // return self.env['ir.config_parameter'].sudo().get_param(
            //     'website.plausible_server',
            //     'https://plausible.io'
            // )
            */
            return default;
        }

        protected async Task<Website> GetPlausibleShareUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_plausible_share_url(self):
            // embed_url = f'/share/{self.plausible_site}?auth={self.plausible_shared_key}&embed=true&theme=system'
            // return self.plausible_shared_key and urls.url_join(self._get_plausible_server(), embed_url) or ''
            */
            return default;
        }

        public async Task<Website> GetPricelistAvailableAsync(Guid id, WebsiteGetPricelistAvailableRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def get_pricelist_available(self, show_visible=False):
            // """ Return the list of pricelists that can be used on website for the current user.
            // Country restrictions will be detected with GeoIP (if installed).
            // :param bool show_visible: if True, we don't display pricelist where selectable is False (Eg: Code promo)
            // :returns: pricelist recordset
            // """
            // self.ensure_one()
            // 
            // country_code = self._get_geoip_country_code()
            // website = self.with_company(self.company_id)
            // 
            // partner_sudo = website.env.user.partner_id
            // is_user_public = self.env.user._is_public()
            // if not is_user_public:
            //     last_order_pricelist = partner_sudo.last_website_so_id.pricelist_id
            //     # Don't needlessly trigger `depends_context` recompute
            //     ctx = {'country_code': country_code} if country_code else {}
            //     partner_pricelist = partner_sudo.with_context(**ctx).property_product_pricelist
            // else:  # public user: do not compute partner pl (not used)
            //     last_order_pricelist = self.env['product.pricelist']
            //     partner_pricelist = self.env['product.pricelist']
            // website_pricelists = website.sudo().pricelist_ids
            // 
            // current_pricelist_id = self._get_cached_pricelist_id()
            // 
            // pricelist_ids = website._get_pl_partner_order(
            //     country_code,
            //     show_visible,
            //     current_pl_id=current_pricelist_id,
            //     website_pricelist_ids=tuple(website_pricelists.ids),
            //     partner_pl_id=partner_pricelist.id,
            //     order_pl_id=last_order_pricelist.id)
            // 
            // return self.env['product.pricelist'].browse(pricelist_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetProductAvailableQtyInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py) ---
            // def _get_product_available_qty(self, product, **kwargs):
            // """ Override of `website_sale_stock` to include free quantities of the product in warehouses
            //  of in-store delivery method and return maximum possible for one order. Needed only if a
            //  warehouse is set on website, otherwise free quantity is already calculated from all
            //  warehouses."""
            // free_qty = super()._get_product_available_qty(product, **kwargs)
            // if self.warehouse_id and self.sudo().in_store_dm_id:  # If warehouse is set on website.
            //     # Check free quantities in the in-store warehouses.
            //     free_qty = max(free_qty, self._get_max_in_store_product_available_qty(product))
            // return free_qty
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: website.py) ---
            // def _get_product_available_qty(self, product, **kwargs):
            // return product.with_context(warehouse_id=self.warehouse_id.id).free_qty
            */
            return default;
        }

        protected async Task<Website> GetProductPageGridImageSpacingClassesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_product_page_grid_image_spacing_classes(self):
            // spacing_map = {
            //     'none': 'm-0',
            //     'small': 'm-1',
            //     'medium': 'm-2',
            //     'big': 'm-3',
            // }
            // return spacing_map.get(self.product_page_image_spacing)
            */
            return default;
        }

        protected async Task<Website> GetProductPageProportionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_product_page_proportions(self):
            // """
            // Returns the number of columns (css) that both the images and the product details should take.
            // """
            // self.ensure_one()
            // 
            // return {
            //     'none': (0, 12),
            //     '50_pc': (6, 6),
            //     '66_pc': (8, 4),
            //     '100_pc': (12, 12),
            // }.get(self.product_page_image_width)
            */
            return default;
        }

        protected async Task<Website> GetProductSortMappingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _get_product_sort_mapping():
            // return [
            //     ('website_sequence asc', _("Featured")),
            //     ('create_date desc', _("Newest Arrivals")),
            //     ('name asc', _("Name (A-Z)")),
            //     ('list_price asc', _("Price - Low to High")),
            //     ('list_price desc', _("Price - High to Low")),
            // ]
            */
            return default;
        }

        public async Task<Website> GetSuggestedControllersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // """
            //     Returns a tuple (name, url, icon).
            //     Where icon can be a module name, or a path
            // """
            // suggested_controllers = [
            //     (_('Homepage'), self.env['ir.http']._url_for('/'), 'website'),
            //     (_('Contact Us'), self.env['ir.http']._url_for('/contactus'), 'website_crm'),
            // ]
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Blog'), self.env['ir.http']._url_for('/blog'), 'website_blog'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Resellers'), self.env['ir.http']._url_for('/partners'), 'website_crm_partner_assign'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('References'), self.env['ir.http']._url_for('/customers'), 'website_customer'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Events'), self.env['ir.http']._url_for('/event'), 'website_event'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Forum'), self.env['ir.http']._url_for('/forum'), 'website_forum'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Jobs'), self.env['ir.http']._url_for('/jobs'), 'website_hr_recruitment'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Live Support'), self.env['ir.http']._url_for('/livechat'), 'website_livechat'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_membership, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Members'), self.env['ir.http']._url_for('/members'), 'website_membership'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super().get_suggested_controllers()
            // suggested_controllers.append((_('eCommerce'), self.env['ir.http']._url_for('/shop'), 'website_sale'))
            // return suggested_controllers
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: website.py) ---
            // def get_suggested_controllers(self):
            // suggested_controllers = super(Website, self).get_suggested_controllers()
            // suggested_controllers.append((_('Courses'), self.env['ir.http']._url_for('/slides'), 'website_slides'))
            // return suggested_controllers
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> GetTemplateAsync(Guid id, WebsiteGetTemplateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_template(self, template):
            // if isinstance(template, str) and '.' not in template:
            //     template = 'website.%s' % template
            // view = self.env['ir.ui.view']._get(template).sudo()
            // if not view:
            //     raise NotFound
            // return view
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> GetThemeConfiguratorSnippetsAsync(Guid id, WebsiteGetThemeConfiguratorSnippetsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_theme_configurator_snippets(self, theme_name):
            // return {
            //     **get_manifest('website')['configurator_snippets'],
            //     **get_manifest(theme_name).get('configurator_snippets', {}),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> GetUniqueKeyAsync(Guid id, WebsiteGetUniqueKeyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_unique_key(self, string, template_module=False):
            // """ Given a string, return an unique key including module prefix.
            //     It will be suffixed by a counter if it already exists to garantee uniqueness.
            //     :param string : the key to be checked for uniqueness, you can pass it with 'website.' or not
            //     :param template_module : the module to be prefixed on the key, if not set, we will use website
            // """
            // if template_module:
            //     string = template_module + '.' + string
            // else:
            //     if not string.startswith('website.'):
            //         string = 'website.' + string
            // 
            // # Look for unique key
            // key_copy = string
            // inc = 0
            // domain_static = self.get_current_website().website_domain()
            // website_id = self.env.context.get('website_id', False)
            // if website_id:
            //     domain_static = [('website_id', 'in', (False, website_id))]
            // while self.env['ir.ui.view'].with_context(active_test=False).sudo().search([('key', '=', key_copy)] + domain_static):
            //     inc += 1
            //     key_copy = string + (inc and "-%s" % inc or "")
            // return key_copy
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> GetUniquePathAsync(Guid id, WebsiteGetUniquePathRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_unique_path(self, page_url):
            // """ Given an url, return that url suffixed by counter if it already exists
            //     :param page_url : the url to be checked for uniqueness
            // """
            // inc = 0
            // # we only want a unique_path for website specific.
            // # we need to be able to have /url for website=False, and /url for website=1
            // # in case of duplicate, page manager will allow you to manage this case
            // website_id = self.env.context.get('website_id', False) or self.get_current_website().id
            // domain_static = [('website_id', '=', website_id)]  # .website_domain()
            // page_temp = page_url
            // while self.env['website.page'].with_context(active_test=False).sudo().search([('url', '=', page_temp)] + domain_static):
            //     inc += 1
            //     page_temp = page_url + (inc and "-%s" % inc or "")
            // return page_temp
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetWarehouseAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: website.py) ---
            // def _get_warehouse_available(self):
            // return (
            //     self.warehouse_id.id or
            //     self.env['ir.default'].sudo()._get('sale.order', 'warehouse_id', company_id=self.company_id.id) or
            //     self.env['ir.default'].sudo()._get('sale.order', 'warehouse_id') or
            //     self.env['stock.warehouse'].sudo().search([('company_id', '=', self.company_id.id)], limit=1).id
            // )
            */
            return default;
        }

        public async Task<Website> GetWebsitePageIdsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def get_website_page_ids(self):
            // if not self.env.user.has_group('website.group_website_restricted_editor'):
            //     # Note that `website.pages` have `0,0,0,0` ACL rights by default for
            //     # everyone except for the website designer which receive `1,0,0,0`.
            //     # So the "Website/Site/Content/Pages" menu to reach the page manager
            //     # is not shown to the restricted users, as the action linked model
            //     # (website.page) can't be access. It's how the Odoo framework works.
            //     # Still, we let the restricted editor access this resource for
            //     # custos granting them read and/or write access on page.
            //     raise AccessError(_("Access Denied"))
            // 
            // domain = [('url', '!=', False)]
            // if self:
            //     domain = AND([domain, self.website_domain()])
            // pages = self.env['website.page'].sudo().search(domain)
            // if self:
            //     pages = pages.with_context(website_id=self.id)._get_most_specific_pages()
            // return pages.ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> GetWebsitePagesInternalAsync(object domain, object order, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _get_website_pages(self, domain=None, order='name', limit=None):
            // website = self.get_current_website()
            // if domain is None:
            //     domain = []
            // domain += website.website_domain()
            // pages = self.env['website.page'].sudo().search(domain, order=order, limit=limit)
            // pages = pages.with_context(website_id=website.id)._get_most_specific_pages()
            // return pages
            */
            return default;
        }

        protected async Task<Website> HandleCreateWriteInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _handle_create_write(self, vals):
            // self._handle_favicon(vals)
            // self._handle_domain(vals)
            // self._handle_homepage_url(vals)
            */
            return default;
        }

        protected async Task<Website> HandleDomainInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _handle_domain(self, vals):
            // if 'domain' in vals and vals['domain']:
            //     vals['domain'] = self._normalize_domain_url(vals['domain'])
            */
            return default;
        }

        protected async Task<Website> HandleFaviconInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _handle_favicon(self, vals):
            // if vals.get('favicon'):
            //     vals['favicon'] = base64.b64encode(tools.image_process(base64.b64decode(vals['favicon']), size=(256, 256), crop='center', output_format='ICO'))
            */
            return default;
        }

        protected async Task<Website> HandleHomepageUrlInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _handle_homepage_url(self, vals):
            // homepage_url = vals.get('homepage_url')
            // if homepage_url:
            //     vals['homepage_url'] = homepage_url.rstrip('/')
            */
            return default;
        }

        public async Task<Website> HasEcommerceAccessAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def has_ecommerce_access(self):
            // """ Return whether the current user is allowed to access eCommerce-related content. """
            // return not (self.env.user._is_public() and self.ecommerce_access == 'logged_in')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> HasGooglePlacesApiKeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_autocomplete, FILE: website.py) ---
            // def has_google_places_api_key(self):
            // return bool(self.sudo().google_places_api_key)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> IdnaUrlInternalAsync(object url)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _idna_url(self, url):
            // return get_base_domain(url.lower(), True).encode('idna').decode('ascii')
            */
            return default;
        }

        public async Task<Website> ImageUrlAsync(Guid id, WebsiteImageUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def image_url(self, record, field, size=None):
            // """ Returns a local url that points to the image field of a given browse record. """
            // sudo_record = record.sudo()
            // sha = hashlib.sha512(str(sudo_record.write_date).encode('utf-8')).hexdigest()[:7]
            // size = '' if size is None else '/%s' % size
            // return '/web/image/%s/%s/%s%s?unique=%s' % (record._name, record.id, field, size, sha)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> IsCanonicalUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _is_canonical_url(self):
            // """Returns whether the current request URL is canonical."""
            // self.ensure_one()
            // # Compare URL at the first routing iteration because it's the one with
            // # the language in the path. It is important to also test the domain of
            // # the current URL.
            // current_url = request.httprequest.url_root[:-1] + request.httprequest.environ['REQUEST_URI']
            // canonical_url = self.env['ir.http']._url_localized(lang_code=request.lang.code, canonical_domain=self.get_base_url())
            // # A request path with quotable characters (such as ",") is never
            // # canonical because request.httprequest.base_url is always unquoted,
            // # and canonical url is always quoted, so it is never possible to tell
            // # if the current URL is indeed canonical or not.
            // return current_url == canonical_url
            */
            return default;
        }

        protected async Task<Website> IsIndexableUrlInternalAsync(object url)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _is_indexable_url(self, url):
            // """
            // Returns True if the given url has to be indexed by search engines.
            // It is considered that the website must be indexed if the domain name
            // matches the URL. We check if they are equal while ignoring the www. and
            // http(s). This is to index the site even if the user put the www. in the
            // settings while he has a configuration that redirects the www. to the
            // naked domain for example (same thing for http and https).
            // 
            // :param url: the url to check
            // :return: True if the url has to be indexed, False otherwise
            // """
            // return self._idna_url(url) == self._idna_url(self.domain)
            */
            return default;
        }

        public async Task<Website> IsMenuCacheDisabledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def is_menu_cache_disabled(self):
            // """
            // Checks if the website menu contains a record like url.
            // :return: True if the menu contains a record like url
            // """
            // return any(self.env['website.menu'].browse(self._get_menu_ids()).filtered(
            //     lambda menu: (menu.url and re.search(r"[/](([^/=?&]+-)?[0-9]+)([/]|$)", menu.url)) or menu.group_ids
            // ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> IsPricelistAvailableAsync(Guid id, WebsiteIsPricelistAvailableRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def is_pricelist_available(self, pl_id):
            // """ Return a boolean to specify if a specific pricelist can be manually set on the website.
            // Warning: It check only if pricelist is in the 'selectable' pricelists or the current pricelist.
            // :param int pl_id: The pricelist id to check
            // :returns: Boolean, True if valid / available
            // """
            // return pl_id in self.get_pricelist_available(show_visible=False).ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> IsPublicUserAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def is_public_user(self):
            // return request.env.user.id == request.website._get_cached('user_id')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> IsSnippetUsedInternalAsync(object snippet_module, Guid snippet_id, object asset_version, object asset_type, object html_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _is_snippet_used(self, snippet_module, snippet_id, asset_version, asset_type, html_fields):
            // snippet_occurences = []
            // # Check snippet template definition to avoid disabling its related assets.
            // # This special case is needed because snippet template definitions do not
            // # have a `data-snippet` attribute (which is added during drag&drop).
            // snippet_template_html = self.env['ir.qweb']._render(f'{snippet_module}.{snippet_id}', raise_if_not_found=False)
            // if snippet_template_html:
            //     match = re.search('<([^>]*class="[^>]*)>', snippet_template_html)
            //     snippet_occurences.append(match.group())
            // 
            // if self._check_snippet_used(snippet_occurences, asset_type, asset_version):
            //     return True
            // 
            // html_fields = [(self.env[model_name], field_name) for model_name, field_name in html_fields]
            // # As well as every snippet dropped in html fields
            // self.env.cr.execute(SQL(" UNION ").join(
            //     SQL("SELECT regexp_matches(%s, %s, 'g') FROM %s",
            //         model._field_to_sql(model._table, field_name),
            //         f'<([^>]*data-snippet="{snippet_id}"[^>]*)>',
            //         SQL.identifier(model._table)
            //     )
            //     for model, field_name in html_fields
            // ))
            // 
            // snippet_occurences = [r[0][0] for r in self.env.cr.fetchall()]
            // return self._check_snippet_used(snippet_occurences, asset_type, asset_version)
            */
            return default;
        }

        public async Task<Website> IsViewActiveAsync(Guid id, WebsiteIsViewActiveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def is_view_active(self, key):
            // """
            //     Return True if active, False if not active, None if not found
            // """
            // view = self.viewref(key, raise_if_not_found=False)
            // return view.active if view else None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> NewPageAsync(Guid id, WebsiteNewPageRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def new_page(self, name=False, add_menu=False, template='website.default_page', ispage=True, namespace=None, page_values=None, menu_values=None, sections_arch=None):
            // """ Create a new website page, and assign it a xmlid based on the given one
            //     :param name: the name of the page
            //     :param add_menu: if True, add a menu for that page
            //     :param template: potential xml_id of the page to create
            //     :param namespace: module part of the xml_id if none, the template module name is used
            //     :param page_values: default values for the page to be created
            //     :param menu_values: default values for the menu to be created
            //     :param sections_arch: HTML content of sections
            // """
            // if namespace:
            //     template_module = namespace
            // else:
            //     template_module, _ = template.split('.')
            // page_url = '/' + self.env['ir.http']._slugify(name, max_length=1024, path=True)
            // page_url = self.get_unique_path(page_url)
            // page_key = self.env['ir.http']._slugify(name)
            // result = {'url': page_url}
            // 
            // if not name:
            //     name = 'Home'
            //     page_key = 'home'
            // 
            // template_record = self.env.ref(template)
            // arch = template_record.arch
            // if sections_arch:
            //     tree = html.fromstring(arch)
            //     wrap = tree.xpath('//div[@id="wrap"]')[0]
            //     for section in html.fromstring(f'<wrap>{sections_arch}</wrap>'):
            //         wrap.append(section)
            //     arch = etree.tostring(tree, encoding="unicode")
            // website_id = self._context.get('website_id')
            // key = self.get_unique_key(page_key, template_module)
            // view = template_record.copy({'website_id': website_id, 'key': key})
            // 
            // view.with_context(lang=None).write({
            //     'arch': arch.replace(template, key),
            //     'name': name,
            // })
            // result['view_id'] = view.id
            // 
            // if view.arch_fs:
            //     view.arch_fs = False
            // 
            // website = self.get_current_website()
            // if ispage:
            //     default_page_values = {
            //         'url': page_url,
            //         'website_id': website.id,  # remove it if only one website or not?
            //         'view_id': view.id,
            //         'track': True,
            //     }
            //     if page_values:
            //         default_page_values.update(page_values)
            //     page = self.env['website.page'].create(default_page_values)
            //     result['page_id'] = page.id
            // if add_menu:
            //     default_menu_values = {
            //         'name': name,
            //         'url': page_url,
            //         'parent_id': website.menu_id.id,
            //         'page_id': page.id,
            //         'website_id': website.id,
            //     }
            //     if menu_values:
            //         default_menu_values.update(menu_values)
            //     menu = self.env['website.menu'].create(default_menu_values)
            //     result['menu_id'] = menu.id
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> NormalizeDomainUrlInternalAsync(object url)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _normalize_domain_url(self, url):
            // """
            // This method:
            // - Prefixes 'https://' if it doesn't start with 'http'
            // - Strips any tailing '/'
            // """
            // normalized_url = url
            // if not normalized_url.startswith('http'):
            //     normalized_url = 'https://%s' % normalized_url
            // normalized_url = normalized_url.rstrip('/')
            // return normalized_url
            */
            return default;
        }

        protected async Task<Website> OLGApiRpcInternalAsync(object route, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _OLG_api_rpc(self, route, params):
            // # For text content generation
            // return self._api_rpc(route, params, 'website.olg_api_endpoint', DEFAULT_OLG_ENDPOINT, timeout=45)
            */
            return default;
        }

        protected async Task<Website> OnchangeLanguageIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _onchange_language_ids(self):
            // language_ids = self.language_ids._origin
            // if language_ids and self.default_lang_id not in language_ids:
            //     self.default_lang_id = language_ids[0]
            */
            return default;
        }

        public async Task<Website> PagerAsync(Guid id, WebsitePagerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def pager(self, url, total, page=1, step=30, scope=5, url_args=None):
            // return pager(url, total, page=page, step=step, scope=scope, url_args=url_args)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> PrepareSaleOrderValuesInternalAsync(object partner_sudo)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _prepare_sale_order_values(self, partner_sudo):
            // self.ensure_one()
            // affiliate_id = request.session.get('affiliate_id')
            // salesperson_user_sudo = self.env['res.users'].sudo().browse(affiliate_id).exists()
            // if not salesperson_user_sudo:
            //     salesperson_user_sudo = self.salesperson_id or partner_sudo.user_id or partner_sudo.parent_id.user_id
            // 
            // return {
            //     'company_id': self.company_id.id,
            //     'fiscal_position_id': self.fiscal_position_id.id,
            //     'partner_id': partner_sudo.id,
            //     'pricelist_id': self.pricelist_id.id,
            //     'team_id': self.salesteam_id.id,
            //     'user_id': salesperson_user_sudo.id,
            //     'website_id': self.id,
            // }
            */
            return default;
        }

        protected async Task<Website> ProductDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _product_domain(self):
            // return [('sale_ok', '=', True)]
            */
            return default;
        }

        protected async Task<Website> RemoveAttachmentsOnWebsiteUnlinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _remove_attachments_on_website_unlink(self):
            // # Do not delete invoices, delete what's strictly necessary
            // attachments_to_unlink = self.env['ir.attachment'].search([
            //     ('website_id', 'in', self.ids),
            //     '|', '|',
            //     ('key', '!=', False),  # theme attachment
            //     ('url', '=like', '/_custom/%'),  # customized theme attachment
            //     ('url', 'ilike', '.assets\\_'),
            // ])
            // attachments_to_unlink.unlink()
            */
            return default;
        }

        public async Task<Website> RuleIsEnumerableAsync(Guid id, WebsiteRuleIsEnumerableRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def rule_is_enumerable(self, rule):
            // """ Checks that it is possible to generate sensible GET queries for
            //     a given rule (if the endpoint matches its own requirements)
            //     :type rule: werkzeug.routing.Rule
            //     :rtype: bool
            // """
            // endpoint = rule.endpoint
            // methods = endpoint.routing.get('methods') or ['GET']
            // 
            // converters = list(rule._converters.values())
            // if not ('GET' in methods
            //         and endpoint.routing['type'] == 'http'
            //         and endpoint.routing['auth'] in ('none', 'public')
            //         and endpoint.routing.get('website', False)
            //         and all(hasattr(converter, 'generate') for converter in converters)):
            //     return False
            // 
            // # dont't list routes without argument having no default value or converter
            // sign = inspect.signature(endpoint.original_endpoint)
            // params = list(sign.parameters.values())[1:]  # skip self
            // supported_kinds = (inspect.Parameter.POSITIONAL_ONLY,
            //                    inspect.Parameter.POSITIONAL_OR_KEYWORD)
            // 
            // # check that all args have a converter
            // return all(p.name in rule._converters for p in params
            //            if p.kind in supported_kinds and p.default is inspect.Parameter.empty)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> SaleGetOrderAsync(Guid id, WebsiteSaleGetOrderRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def sale_get_order(self, force_create=False):
            // """ Return the current sales order after mofications specified by params.
            // 
            // :param bool force_create: Create sales order if not already existing
            // 
            // :returns: current cart, as a sudoed `sale.order` recordset (might be empty)
            // """
            // self.ensure_one()
            // 
            // self = self.with_company(self.company_id)
            // SaleOrder = self.env['sale.order'].sudo()
            // 
            // sale_order_id = request.session.get('sale_order_id')
            // 
            // if sale_order_id:
            //     sale_order_sudo = SaleOrder.browse(sale_order_id).exists()
            // elif self.env.user and not self.env.user._is_public():
            //     sale_order_sudo = self.env.user.partner_id.last_website_so_id
            //     if sale_order_sudo:
            //         available_pricelists = self.get_pricelist_available()
            //         so_pricelist_sudo = sale_order_sudo.pricelist_id
            //         if so_pricelist_sudo and so_pricelist_sudo not in available_pricelists:
            //             # Do not reload the cart of this user last visit
            //             # if the cart uses a pricelist no longer available.
            //             sale_order_sudo = SaleOrder
            //         else:
            //             # Do not reload the cart of this user last visit
            //             # if the Fiscal Position has changed.
            //             fpos = sale_order_sudo.env['account.fiscal.position'].with_company(
            //                 sale_order_sudo.company_id
            //             )._get_fiscal_position(
            //                 sale_order_sudo.partner_id,
            //                 delivery=sale_order_sudo.partner_shipping_id
            //             )
            //             if fpos.id != sale_order_sudo.fiscal_position_id.id:
            //                 sale_order_sudo = SaleOrder
            // else:
            //     sale_order_sudo = SaleOrder
            // 
            // # Ignore the current order if a payment has been initiated. We don't want to retrieve the
            // # cart and allow the user to update it when the payment is about to confirm it.
            // if sale_order_sudo and sale_order_sudo.get_portal_last_transaction().state in (
            //     'pending', 'authorized', 'done'
            // ):
            //     sale_order_sudo = None
            // 
            // if not (sale_order_sudo or force_create):
            //     # Do not create a SO record unless needed
            //     if request.session.get('sale_order_id'):
            //         request.session.pop('sale_order_id')
            //         request.session.pop('website_sale_cart_quantity', None)
            //     return self.env['sale.order']
            // 
            // partner_sudo = self.env.user.partner_id
            // 
            // # cart creation was requested
            // if not sale_order_sudo:
            //     so_data = self._prepare_sale_order_values(partner_sudo)
            //     sale_order_sudo = SaleOrder.with_user(SUPERUSER_ID).create(so_data)
            // 
            //     request.session['sale_order_id'] = sale_order_sudo.id
            //     request.session['website_sale_cart_quantity'] = sale_order_sudo.cart_quantity
            //     # The order was created with SUPERUSER_ID, revert back to request user.
            //     return sale_order_sudo.with_user(self.env.user).sudo()
            // 
            // # Existing Cart:
            // #   * For logged user
            // #   * In session, for specified partner
            // 
            // # case when user emptied the cart
            // if not request.session.get('sale_order_id'):
            //     request.session['sale_order_id'] = sale_order_sudo.id
            //     request.session['website_sale_cart_quantity'] = sale_order_sudo.cart_quantity
            // 
            // # check for change of partner_id ie after signup
            // if partner_sudo.id not in (sale_order_sudo.partner_id.id, self.partner_id.id):
            //     sale_order_sudo._update_address(partner_sudo.id, ['partner_id'])
            // 
            // return sale_order_sudo
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> SaleProductDomainAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def sale_product_domain(self):
            // website_domain = self.get_current_website().website_domain()
            // if not self.env.user._is_internal():
            //     website_domain = expression.AND([website_domain, [
            //         ('is_published', '=', True),
            //         ('service_tracking', 'in', self.env['product.template']._get_saleable_tracking_types()),
            //     ]])
            // return expression.AND([self._product_domain(), website_domain])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<Website> SaleResetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def sale_reset(self):
            // request.session.pop('sale_order_id', None)
            // request.session.pop('website_sale_current_pl', None)
            // request.session.pop('website_sale_cart_quantity', None)
            // request.session.pop('website_sale_selected_pl_id', None)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> SearchBuildDomainInternalAsync(object domain, object search, object fields, object extra)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_build_domain(self, domain, search, fields, extra=None):
            // """
            // Builds a search domain AND-combining a base domain with partial matches of each term in
            // the search expression in any of the fields.
            // 
            // :param domain: base domain combined in the search expression
            // :param search: search expression string
            // :param fields: list of field names to match the terms of the search expression with
            // :param extra: function that returns an additional subdomain for a search term
            // 
            // :return: domain limited to the matches of the search expression
            // """
            // domains = domain.copy()
            // if search:
            //     for search_term in search.split(' '):
            //         subdomains = []
            //         for field in fields:
            //             subdomains.append([(field, 'ilike', sqltools.escape_psql(search_term))])
            //         if extra:
            //             subdomains.append(extra(self.env, search_term))
            //         domains.append(OR(subdomains))
            // return AND(domains)
            */
            return default;
        }

        protected async Task<Website> SearchExactInternalAsync(object search_details, object search, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_exact(self, search_details, search, limit, order):
            // """
            // Performs a search with a search text
            // 
            // :param search_details: see :meth:`_search_get_details`
            // :param search: text against which to match results
            // :param limit: maximum number of results per model type involved in the result
            // :param order: order on which to sort results within a model type
            // 
            // :return: tuple containing:
            //     - total number of results across all involved models
            //     - list of results per model made of:
            //         - initial search_detail for the model
            //         - count: number of results for the model
            //         - results: model list equivalent to a `model.search()`
            // """
            // all_results = []
            // total_count = 0
            // for search_detail in search_details:
            //     model = self.env[search_detail['model']]
            //     results, count = model._search_fetch(search_detail, search, limit, order)
            //     search_detail['results'] = results
            //     total_count += count
            //     search_detail['count'] = count
            //     all_results.append(search_detail)
            // return total_count, all_results
            */
            return default;
        }

        protected async Task<Website> SearchFindFuzzyTermInternalAsync(object search_details, object search, object limit, object word_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_find_fuzzy_term(self, search_details, search, limit=1000, word_list=None):
            // """
            // Returns the "closest" match of the search parameter within available words.
            // 
            // :param search_details: obtained from `_search_get_details()`
            // :param search: search term to which words must be matched against
            // :param limit: maximum number of records fetched per model to build the word list
            // :param word_list: if specified, this list of words is used as possible targets instead of
            //     the words contained in the match fields of each involved model
            // 
            // :return: term on which a search can be performed instead of the initial search
            // """
            // # No fuzzy search for less that 4 characters, multi-words nor 80%+ numbers.
            // if len(search) < 4 or ' ' in search or len(re.findall(r'\d', search)) / len(search) >= 0.8:
            //     return search
            // search = search.lower()
            // words = set()
            // best_score = 0
            // best_word = None
            // enumerate_words = self._trigram_enumerate_words if self.env.registry.has_trigram else self._basic_enumerate_words
            // for word in word_list or enumerate_words(search_details, search, limit):
            //     if search in word:
            //         return search
            //     if word[0] == search[0] and word not in words:
            //         similarity = similarity_score(search, word)
            //         if similarity > best_score:
            //             best_score = similarity
            //             best_word = word
            //         words.add(word)
            // return best_word
            */
            return default;
        }

        protected async Task<Website> SearchGetDetailsInternalAsync(object search_type, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // """
            // Returns indications on how to perform the searches
            // 
            // :param search_type: type of search
            // :param order: order in which the results are to be returned
            // :param options: search options
            // 
            // :return: list of search details obtained from the `website.searchable.mixin`'s `_search_get_detail()`
            // """
            // result = []
            // if search_type in ['pages', 'all']:
            //     result.append(self.env['website.page']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if search_type in ['blogs', 'blogs_only', 'all']:
            //     result.append(self.env['blog.blog']._search_get_detail(self, order, options))
            // if search_type in ['blogs', 'blog_posts_only', 'all']:
            //     result.append(self.env['blog.post']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if search_type in ['events', 'all']:
            //     result.append(self.env['event.event']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if search_type in ['forums', 'forums_only', 'all']:
            //     result.append(self.env['forum.forum']._search_get_detail(self, order, options))
            // if search_type in ['forums', 'forum_posts_only', 'all']:
            //     result.append(self.env['forum.post']._search_get_detail(self, order, options))
            // if search_type in ['forums', 'forum_tags_only', 'all']:
            //     result.append(self.env['forum.tag']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if search_type in ['jobs', 'all']:
            //     result.append(self.env['hr.job']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if not self.has_ecommerce_access():
            //     return result
            // if search_type in ['products', 'product_categories_only', 'all']:
            //     result.append(self.env['product.public.category']._search_get_detail(self, order, options))
            // if search_type in ['products', 'products_only', 'all']:
            //     result.append(self.env['product.template']._search_get_detail(self, order, options))
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: website.py) ---
            // def _search_get_details(self, search_type, order, options):
            // result = super()._search_get_details(search_type, order, options)
            // if search_type in ['slides', 'slide_channels_only', 'all']:
            //     result.append(self.env['slide.channel']._search_get_detail(self, order, options))
            // if search_type in ['slides', 'slides_only', 'all']:
            //     result.append(self.env['slide.slide']._search_get_detail(self, order, options))
            // return result
            */
            return default;
        }

        protected async Task<Website> SearchGetIndirectFieldsInternalAsync(object fields, object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_get_indirect_fields(self, fields, model):
            // """
            // Returns the list of indirect fields amongst the requested fields.
            // 
            // :param fields: list of field names to be searched
            // :param model: model within which to search
            // :return: dict of indirect field details per indirect field name
            // """
            // # Are considered valid indirect fields, fields that belong to the
            // # comodel behind a relational direct field.
            // indirect_fields = {}
            // for field in fields:
            //     field_parts = field.split('.')
            //     if len(field_parts) != 2:
            //         continue
            //     direct, indirect = field_parts
            //     if direct not in model._fields:
            //         continue
            //     direct_field = model._fields[direct]
            //     comodel_name = direct_field.comodel_name
            //     if comodel_name not in self.env:
            //         continue
            //     comodel_fields = self.env[comodel_name]._fields
            //     cofield = None
            //     if '_description_relation_field' in dir(direct_field):
            //         # One2many field's comodel reference to the model's id.
            //         cofield = direct_field._description_relation_field
            //         if cofield not in comodel_fields:
            //             continue
            //     if indirect in comodel_fields:
            //         indirect_fields[field] = {
            //             'direct': direct,
            //             'indirect': indirect,
            //             'comodel': self.env[comodel_name],
            //             'cofield': cofield,
            //         }
            // return indirect_fields
            */
            return default;
        }

        public async Task<Website> SearchPagesAsync(Guid id, WebsiteSearchPagesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def search_pages(self, needle=None, limit=None):
            // name = self.env['ir.http']._slugify(needle, max_length=50, path=True)
            // res = []
            // for page in self._enumerate_pages(query_string=name, force=True):
            //     res.append(page)
            //     if len(res) == limit:
            //         break
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> SearchRenderResultsInternalAsync(object search_details, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_render_results(self, search_details, limit):
            // """
            // Prepares data for the autocomplete and hybrid list rendering
            // 
            // :param search_details: obtained from `_search_exact()`
            // :param limit: maximum number or rows to render
            // 
            // :return: the updated `search_details` containing an additional `results_data` field equivalent
            //     to the result of a `model.read()`
            // """
            // for search_detail in search_details:
            //     fields = search_detail['fetch_fields']
            //     results = search_detail['results']
            //     icon = search_detail['icon']
            //     mapping = search_detail['mapping']
            //     results_data = results._search_render_results(fields, mapping, icon, limit)
            //     search_detail['results_data'] = results_data
            // return search_details
            */
            return default;
        }

        protected async Task<Website> SearchTextFromHtmlInternalAsync(object html_fragment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_text_from_html(self, html_fragment):
            // """
            // Returns the plain non-tag text from an html
            // 
            // :param html_fragment: document from which text must be extracted
            // 
            // :return text extracted from the html
            // """
            // # lxml requires one single root element
            // tree = etree.fromstring('<p>%s</p>' % html_fragment, etree.XMLParser(recover=True))
            // return ' '.join(tree.itertext())
            */
            return default;
        }

        public async Task<Website> SearchUrlDependenciesAsync(Guid id, WebsiteSearchUrlDependenciesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def search_url_dependencies(self, res_model, res_ids):
            // """ Search dependencies just for information. It will not catch 100%
            //     of dependencies and False positive is more than possible
            //     Each module could add dependences in this dict
            //     :returns a dictionnary where key is the 'categorie' of object related to the given
            //         view, and the value is the list of text and link to the resource using given page
            // """
            // dependencies = {}
            // current_website = self.get_current_website()
            // page_model_name = 'Page'
            // 
            // def _handle_views_and_pages(views):
            //     page_views = views.filtered('page_ids')
            //     views = views - page_views
            //     if page_views:
            //         dependencies.setdefault(page_model_name, [])
            //         dependencies[page_model_name] += [{
            //             'field_name': 'Content',
            //             'record_name': page.name,
            //             'link': page.url,
            //             'model_name': page_model_name,
            //         } for page in page_views.page_ids]
            //     return views
            // 
            // # Prepare what's needed to later generate the URL search domain for the
            // # given records
            // search_criteria = []
            // for record in self.env[res_model].browse([int(res_id) for res_id in res_ids]):
            //     website = 'website_id' in record and record.website_id or current_website
            //     url = 'website_url' in record and record.website_url or record.url
            //     search_criteria.append((url, website.website_domain()))
            // 
            // # Search the URL in every relevant field
            // html_fields = self._get_html_fields() + [
            //     ('website.menu', 'url'),
            // ]
            // for model_name, field_name in html_fields:
            //     Model = self.env[model_name]
            //     if not Model.has_access('read'):
            //         continue
            // 
            //     # Generate the exact domain to search for the URL in this field
            //     domains = []
            //     for url, website_domain in search_criteria:
            //         domains.append(AND([
            //             [(field_name, 'ilike', url)],
            //             website_domain if hasattr(Model, 'website_id') else [],
            //         ]))
            // 
            //     dependency_records = Model.search(OR(domains))
            //     if model_name == 'ir.ui.view':
            //         dependency_records = _handle_views_and_pages(dependency_records)
            //     if dependency_records:
            //         model_name = self.env['ir.model']._display_name_for([model_name])[0]['display_name']
            //         field_string = Model.fields_get()[field_name]['string']
            //         dependencies.setdefault(model_name, [])
            //         dependencies[model_name] += [{
            //             'field_name': field_string,
            //             'record_name': rec.display_name,
            //             'link': 'website_url' in rec and rec.website_url or f'/odoo/{model_name}/{rec.id}',
            //             'model_name': model_name,
            //         } for rec in dependency_records]
            // 
            // return dependencies
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> SearchWithFuzzyInternalAsync(object search_type, object search, object limit, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _search_with_fuzzy(self, search_type, search, limit, order, options):
            // """
            // Performs a search with a search text or with a resembling word
            // 
            // :param search_type: indicates what to search within, 'all' matches all available types
            // :param search: text against which to match results
            // :param limit: maximum number of results per model type involved in the result
            // :param order: order on which to sort results within a model type
            // :param options: search options from the submitted form containing:
            //     - allowFuzzy: boolean indicating whether the fuzzy matching must be done
            //     - other options used by `_search_get_details()`
            // 
            // :return: tuple containing:
            //     - count: total number of results across all involved models
            //     - results: list of results per model (see _search_exact)
            //     - fuzzy_term: similar word against which results were obtained, indicates there were
            //         no results for the initially requested search
            // """
            // fuzzy_term = False
            // search_details = self._search_get_details(search_type, order, options)
            // if search and options.get('allowFuzzy', True):
            //     fuzzy_term = self._search_find_fuzzy_term(search_details, search)
            //     if fuzzy_term:
            //         count, results = self._search_exact(search_details, fuzzy_term, limit, order)
            //         if fuzzy_term.lower() == search.lower():
            //             fuzzy_term = False
            //     else:
            //         count, results = self._search_exact(search_details, search, limit, order)
            // else:
            //     count, results = self._search_exact(search_details, search, limit, order)
            // return count, results, fuzzy_term
            */
            return default;
        }

        protected async Task<Website> SendAbandonedCartEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website.py) ---
            // def _send_abandoned_cart_email(self):
            // for website in self.search([]):
            //     if not website.send_abandoned_cart_email:
            //         continue
            //     all_abandoned_carts = self.env['sale.order'].search([
            //         ('is_abandoned_cart', '=', True),
            //         ('cart_recovery_email_sent', '=', False),
            //         ('website_id', '=', website.id),
            //     ])
            //     if not all_abandoned_carts:
            //         continue
            // 
            //     abandoned_carts = all_abandoned_carts._filter_can_send_abandoned_cart_mail()
            //     # Mark abandoned carts that failed the filter as sent to avoid rechecking them again and again.
            //     (all_abandoned_carts - abandoned_carts).cart_recovery_email_sent = True
            //     for sale_order in abandoned_carts:
            //         template = self.env.ref('website_sale.mail_template_sale_cart_recovery')
            //         # fallback email_vals in case partner_to and email_to were emptied
            //         email_vals = {} if template.email_to or template.partner_to else {
            //             'email_to': sale_order.partner_id.email_formatted
            //         }
            //         template.send_mail(sale_order.id, email_values=email_vals)
            //         sale_order.cart_recovery_email_sent = True
            */
            return default;
        }

        protected async Task<Website> TrigramEnumerateWordsInternalAsync(object search_details, object search, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _trigram_enumerate_words(self, search_details, search, limit):
            // """
            // Browses through all words that need to be compared to the search term.
            // It extracts all words of every field associated to models in the fields_per_model parameter.
            // The search is restricted to a records having the non-zero pg_trgm.word_similarity() score.
            // 
            // :param search_details: obtained from `_search_get_details()`
            // :param search: search term to which words must be matched against
            // :param limit: maximum number of records fetched per model to build the word list
            // :return: yields words
            // """
            // match_pattern = r'[\w./-]{%s,}' % min(4, len(search) - 3)
            // similarity_threshold = 0.3
            // for search_detail in search_details:
            //     model_name, fields = search_detail['model'], search_detail['search_fields']
            //     model = self.env[model_name]
            //     if search_detail.get('requires_sudo'):
            //         model = model.sudo()
            //     domain = search_detail['base_domain'].copy()
            //     direct_fields = set(fields).intersection(model._fields)
            //     indirect_fields = self._search_get_indirect_fields(fields, model)
            // 
            //     query = Query(self.env.cr, model._table, model._table_query)
            // 
            //     unaccent = self.env.registry.unaccent
            //     similarities = [
            //         SQL("word_similarity(%(search)s, %(field)s)",
            //             search=unaccent(SQL('%s', search)),
            //             field=unaccent(model._field_to_sql(model._table, field, query)),
            //             )
            //         for field in direct_fields
            //     ]
            //     indirect_similarities = []
            //     for field_info in indirect_fields.values():
            //         direct = field_info['direct']
            //         direct_field = model._fields[direct]
            //         comodel = field_info['comodel']
            //         coalias = query.make_alias(model._table, direct)
            //         cofield = field_info['cofield']
            //         if cofield:
            //             # One2many's comodel references the model's id.
            //             query.add_join('LEFT JOIN', coalias, comodel._table, SQL("%s = %s",
            //                 SQL.identifier(model._table, 'id'),
            //                 SQL.identifier(coalias, cofield),
            //             ))
            //         elif 'relation' in dir(direct_field):
            //             # Many2many's relation holds the model's id in column1 and
            //             # the comodel's record id in column2.
            //             rel_alias = coalias
            //             query.add_join('LEFT JOIN', rel_alias, direct_field.relation, SQL("%s = %s",
            //                 SQL.identifier(model._table, 'id'),
            //                 SQL.identifier(rel_alias, direct_field.column1),
            //             ))
            //             coalias = query.make_alias(coalias, direct_field.column2)
            //             query.add_join('LEFT JOIN', coalias, comodel._table, SQL("%s = %s",
            //                 SQL.identifier(rel_alias, direct_field.column2),
            //                 SQL.identifier(coalias, 'id'),
            //             ))
            //         indirect_similarities.append(SQL("word_similarity(%(search)s, %(field)s)",
            //             search=unaccent(SQL('%s', search)),
            //             field=unaccent(comodel._field_to_sql(coalias, field_info['indirect'], query)),
            //         ))
            //     similarities.extend(indirect_similarities)
            //     best_similarity = SQL('GREATEST(%(similarities)s)', similarities=SQL(', ').join(similarities))
            // 
            //     # Filter unpublished records for portal and public user for
            //     # performance.
            //     # TODO: Same for `active` field?
            //     filter_is_published = (
            //         'is_published' in model._fields
            //         and model._fields['is_published'].base_field.model_name == model_name
            //         and not self.env.user._is_internal()
            //     )
            //     if filter_is_published:
            //         query.add_where('is_published')
            // 
            //     query.order = '_best_similarity desc'
            //     query.limit = 1000
            //     self.env.cr.execute(query.select(
            //         SQL.identifier(model._table, 'id'),
            //         SQL('%s AS _best_similarity', best_similarity),
            //     ))
            //     ids = {row[0] for row in self.env.cr.fetchall() if row[1] and row[1] >= similarity_threshold}
            //     domain.append([('id', 'in', list(ids))])
            //     domain = AND(domain)
            //     records = model.search_read(domain, direct_fields, limit=limit)
            //     for record in records:
            //         for field, value in record.items():
            //             if isinstance(value, str):
            //                 value = value.lower()
            //                 yield from re.findall(match_pattern, value)
            //     if indirect_fields:
            //         records = model.search(domain, limit=limit)
            //         for indirect_field in indirect_fields:
            //             for value in records.mapped(indirect_field):
            //                 if isinstance(value, str):
            //                     value = value.lower()
            //                     yield from re.findall(match_pattern, value)
            */
            return default;
        }

        protected async Task<Website> UnlinkExceptDefaultWebsiteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _unlink_except_default_website(self):
            // default_website = self.env.ref('website.default_website', raise_if_not_found=False)
            // if default_website and default_website in self:
            //     raise UserError(_("You cannot delete default website %s. Try to change its settings instead", default_website.name))
            */
            return default;
        }

        protected async Task<Website> UpdateForumCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: website.py) ---
            // def _update_forum_count(self):
            // """ Update count of forum linked to some websites. This has to be
            // done manually as website_id=False on forum model means a shared forum.
            // There is therefore no straightforward relationship to be used between
            // forum and website.
            // 
            // This method either runs on self (if not void), either on all existing
            // websites (to update globally counters, notably when a new forum is
            // created). """
            // websites = self if self else self.search([])
            // forums_all = self.env['forum.forum'].search([])
            // for website in websites:
            //     website.forum_count = len(forums_all.filtered_domain(website.website_domain()))
            */
            return default;
        }

        public async Task<Website> ViewrefAsync(Guid id, WebsiteViewrefRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def viewref(self, view_id, raise_if_not_found=True):
            // ''' Given an xml_id or a view_id, return the corresponding view record.
            //     In case of website context, return the most specific one.
            // 
            //     If no website_id is in the context, it will return the generic view,
            //     instead of a random one like `_get_view_id`.
            // 
            //     Look also for archived views, no matter the context.
            // 
            //     :param view_id: either a string xml_id or an integer view_id
            //     :param raise_if_not_found: should the method raise an error if no view found
            //     :return: The view record or empty recordset
            // '''
            // View = self.env['ir.ui.view'].sudo()
            // view = View
            // if isinstance(view_id, str):
            //     if 'website_id' in self._context:
            //         domain = [('key', '=', view_id)] + self.env['website'].website_domain(self._context.get('website_id'))
            //         order = 'website_id'
            //     else:
            //         domain = [('key', '=', view_id)]
            //         order = View._order
            //     views = View.with_context(active_test=False).search(domain, order=order)
            //     if views:
            //         view = views.filter_duplicate()[:1]
            //     else:
            //         # we handle the raise below
            //         view = self.env.ref(view_id, raise_if_not_found=False)
            //         # self.env.ref might return something else than an ir.ui.view (eg: a theme.ir.ui.view)
            //         if not view or view._name != 'ir.ui.view':
            //             # make sure we always return a recordset
            //             view = View
            // elif isinstance(view_id, int):
            //     view = View.browse(view_id)
            // else:
            //     raise ValueError('Expecting a string or an integer, not a %s.' % (type(view_id)))
            // 
            // if not view and raise_if_not_found:
            //     raise ValueError('No record found for unique ID %s. It may have been deleted.' % (view_id))
            // return view
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> WebsiteApiRpcInternalAsync(object route, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def _website_api_rpc(self, route, params):
            // # For industries, theme suggestions, ...
            // return self._api_rpc(route, params, 'website.website_api_endpoint', DEFAULT_WEBSITE_ENDPOINT)
            */
            return default;
        }

        public async Task<Website> WebsiteDomainAsync(Guid id, WebsiteWebsiteDomainRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website.py) ---
            // def website_domain(self, website_id=False):
            // return [('website_id', 'in', (False, website_id or self.id))]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<Website> WebsiteFormLastRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def _website_form_last_record(self):
            // if request and request.session.form_builder_model_model:
            //     return request.env[request.session.form_builder_model_model].browse(request.session.form_builder_id)
            // return False
            */
            return default;
        }
    }
}