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
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class ThemeUtilsAppService : ApplicationService, IThemeUtilsAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ThemeUtilsAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> DisableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def disable_asset(self, name):
            // self._toggle_asset(name, False)
            */
            return default;
        }

        public async Task<TEntity> DisableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def disable_view(self, xml_id):
            // self._toggle_view(xml_id, False)
            */
            return default;
        }

        public async Task<TEntity> EnableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def enable_asset(self, name):
            // self._toggle_asset(name, True)
            */
            return default;
        }

        public async Task<TEntity> EnableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def enable_view(self, xml_id):
            // if xml_id in self._header_templates:
            //     for view in self._header_templates:
            //         self.disable_view(view)
            // elif xml_id in self._footer_templates:
            //     for view in self._footer_templates:
            //         self.disable_view(view)
            // self._toggle_view(xml_id, True)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: theme_utils.py) ---
            // def enable_view(self, xml_id):
            // """Override of `theme.utils` to disable all category style templates when enabling one."""
            // if xml_id in self.category_style_templates:
            //     for template in self.category_style_templates:
            //         self.disable_view(template)
            // super().enable_view(xml_id)
            */
            return default;
        }

        public async Task<TEntity> FooterTemplatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: theme_utils.py) ---
            // def _footer_templates(self):
            // return ['website_sale.template_footer_website_sale'] + super()._footer_templates
            */
            return default;
        }

        public async Task<TEntity> PostCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mod) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _post_copy(self, mod):
            // # Call specific theme post copy
            // theme_post_copy = '_%s_post_copy' % mod.name
            // if hasattr(self, theme_post_copy):
            //     _logger.info('Executing method %s' % theme_post_copy)
            //     method = getattr(self, theme_post_copy)
            //     return method(mod)
            // return False
            */
            return default;
        }

        public async Task<TEntity> ResetDefaultConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _reset_default_config(self):
            // # Reinitialize some css customizations
            // self.env['website.assets'].make_scss_customization(
            //     '/website/static/src/scss/options/user_values.scss',
            //     {
            //         'font': 'null',
            //         'headings-font': 'null',
            //         'navbar-font': 'null',
            //         'buttons-font': 'null',
            //         'color-palettes-number': 'null',
            //         'color-palettes-name': 'null',
            //         'btn-ripple': 'null',
            //         'header-template': 'null',
            //         'footer-template': 'null',
            //         'footer-scrolltop': 'null',
            //     }
            // )
            // 
            // # Reinitialize effets
            // self.disable_asset("website.ripple_effect_scss")
            // self.disable_asset("website.ripple_effect_js")
            // 
            // # Reinitialize header templates
            // for view in self._header_templates[:-1]:
            //     self.disable_view(view)
            // self.enable_view(self._header_templates[-1])
            // 
            // # Reinitialize footer templates
            // for view in self._footer_templates[:-1]:
            //     self.disable_view(view)
            // self.enable_view(self._footer_templates[-1])
            // 
            // # Reinitialize footer scrolltop template
            // self.disable_view('website.option_footer_scrolltop')
            */
            return default;
        }

        public async Task<TEntity> ToggleAssetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object active) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _toggle_asset(self, key, active):
            // ThemeIrAsset = self.env['theme.ir.asset'].sudo().with_context(active_test=False)
            // obj = ThemeIrAsset.search([('key', '=', key)])
            // website = self.env['website'].get_current_website()
            // if obj:
            //     obj = obj.copy_ids.filtered(lambda x: x.website_id == website)
            // else:
            //     Asset = self.env['ir.asset'].sudo().with_context(active_test=False)
            //     obj = Asset.search([('key', '=', key)], limit=1)
            //     has_specific = obj.key and Asset.search_count([
            //         ('key', '=', obj.key),
            //         ('website_id', '=', website.id)
            //     ]) >= 1
            //     if not has_specific and active == obj.active:
            //         return
            // obj.write({'active': active})
            */
            return default;
        }

        public async Task<TEntity> ToggleViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id, object active) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _toggle_view(self, xml_id, active):
            // obj = self.env.ref(xml_id)
            // website = self.env['website'].get_current_website()
            // if obj._name == 'theme.ir.ui.view':
            //     obj = obj.with_context(active_test=False)
            //     obj = obj.copy_ids.filtered(lambda x: x.website_id == website)
            // else:
            //     # If a theme post copy wants to enable/disable a view, this is to
            //     # enable/disable a given functionality which is disabled/enabled
            //     # by default. So if a post copy asks to enable/disable a view which
            //     # is already enabled/disabled, we would not consider it otherwise it
            //     # would COW the view for nothing.
            //     View = self.env['ir.ui.view'].with_context(active_test=False)
            //     has_specific = obj.key and View.search_count([
            //         ('key', '=', obj.key),
            //         ('website_id', '=', website.id)
            //     ]) >= 1
            //     if not has_specific and active == obj.active:
            //         return
            // obj.write({'active': active})
            */
            return default;
        }
    }
}