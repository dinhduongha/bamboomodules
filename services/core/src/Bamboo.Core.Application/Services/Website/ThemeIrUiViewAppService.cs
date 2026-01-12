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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class ThemeIrUiViewAppService : GenericApplicationService<ThemeIrUiView>, IThemeIrUiViewAppService
    {

        public ThemeIrUiViewAppService(IRepository<ThemeIrUiView, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ThemeIrUiView> ComputeArchFsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def compute_arch_fs(self):
            // if 'install_filename' not in self._context:
            //     return ''
            // path_info = get_resource_from_path(self._context['install_filename'])
            // if path_info:
            //     return '/'.join(path_info[0:2])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ThemeIrUiView> ConvertToBaseModelInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _convert_to_base_model(self, website, **kwargs):
            // self.ensure_one()
            // inherit = self.inherit_id
            // if self.inherit_id and self.inherit_id._name == 'theme.ir.ui.view':
            //     inherit = self.inherit_id.with_context(active_test=False).copy_ids.filtered(lambda x: x.website_id == website)
            //     if not inherit:
            //         # inherit_id not yet created, add to the queue
            //         return False
            // 
            // if inherit and inherit.website_id != website:
            //     website_specific_inherit = self.env['ir.ui.view'].with_context(active_test=False).search([
            //         ('key', '=', inherit.key),
            //         ('website_id', '=', website.id)
            //     ], limit=1)
            //     if website_specific_inherit:
            //         inherit = website_specific_inherit
            // 
            // new_view = {
            //     'type': self.type or 'qweb',
            //     'name': self.name,
            //     'arch': self.arch,
            //     'key': self.key,
            //     'inherit_id': inherit and inherit.id,
            //     'arch_fs': self.arch_fs,
            //     'priority': self.priority,
            //     'active': self.active,
            //     'theme_template_id': self.id,
            //     'website_id': website.id,
            //     'customize_show': self.customize_show,
            // }
            // 
            // if self.mode:  # if not provided, it will be computed automatically (if inherit_id or not)
            //     new_view['mode'] = self.mode
            // 
            // return new_view
            */
            return default;
        }
    }
}