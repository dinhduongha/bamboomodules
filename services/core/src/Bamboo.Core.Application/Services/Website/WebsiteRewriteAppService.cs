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
    public class WebsiteRewriteAppService : GenericApplicationService<WebsiteRewrite>, IWebsiteRewriteAppService
    {

        public WebsiteRewriteAppService(IRepository<WebsiteRewrite, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<WebsiteRewrite> CheckUrlToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_rewrite.py) ---
            // def _check_url_to(self):
            // for rewrite in self:
            //     if rewrite.redirect_type in ['301', '302', '308']:
            //         if not rewrite.url_to:
            //             raise ValidationError(_('"URL to" can not be empty.'))
            //         if not rewrite.url_from:
            //             raise ValidationError(_('"URL from" can not be empty.'))
            //         if rewrite.url_to.startswith('#') or rewrite.url_from.startswith('#'):
            //             raise ValidationError(_("URL must not start with '#'."))
            //         if rewrite.url_to.split('#')[0] == rewrite.url_from.split('#')[0]:
            //             raise ValidationError(_("base URL of 'URL to' should not be same as 'URL from'."))
            // 
            //     if rewrite.redirect_type == '308':
            //         if not rewrite.url_to.startswith('/'):
            //             raise ValidationError(_('"URL to" must start with a leading slash.'))
            //         for param in re.findall('/<.*?>', rewrite.url_from):
            //             if param not in rewrite.url_to:
            //                 raise ValidationError(_('"URL to" must contain parameter %s used in "URL from".', param))
            //         for param in re.findall('/<.*?>', rewrite.url_to):
            //             if param not in rewrite.url_from:
            //                 raise ValidationError(_('"URL to" cannot contain parameter %s which is not used in "URL from".', param))
            // 
            //         if rewrite.url_to == '/':
            //             raise ValidationError(_('"URL to" cannot be set to "/". To change the homepage content, use the "Homepage URL" field in the website settings or the page properties on any custom page.'))
            // 
            //         if any(
            //             rule for rule in self.env['ir.http'].routing_map().iter_rules()
            //             # Odoo routes are normally always defined without trailing
            //             # slashes + strict_slashes=False, but there are exceptions.
            //             if rule.rule.rstrip('/') == rewrite.url_to.rstrip('/')
            //         ):
            //             raise ValidationError(_('"URL to" cannot be set to an existing page.'))
            // 
            //         try:
            //             converters = self.env['ir.http']._get_converters()
            //             routing_map = werkzeug.routing.Map(strict_slashes=False, converters=converters)
            //             rule = werkzeug.routing.Rule(rewrite.url_to)
            //             routing_map.add(rule)
            //         except ValueError as e:
            //             raise ValidationError(_('"URL to" is invalid: %s', e)) from e
            */
            return default;
        }

        protected async Task<WebsiteRewrite> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_rewrite.py) ---
            // def _compute_display_name(self):
            // for rewrite in self:
            //     rewrite.display_name = f"{rewrite.redirect_type} - {rewrite.name}"
            */
            return default;
        }

        protected async Task<WebsiteRewrite> InvalidateRoutingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_rewrite.py) ---
            // def _invalidate_routing(self):
            // # Call clear_cache for routing on all workers to reload routing table.
            // # Note that only 404 and 308 redirection alter the routing map:
            // # - 404: remove entry from routing map
            // # - 301/302: served as fallback later if path not found in routing map
            // # - 308: add "alias" (`redirect_to`) in routing map
            // self.env.registry.clear_cache('routing')
            */
            return default;
        }

        protected async Task<WebsiteRewrite> OnchangeRouteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_rewrite.py) ---
            // def _onchange_route_id(self):
            // self.url_from = self.route_id.path
            // self.url_to = self.route_id.path
            */
            return default;
        }

        public async Task<WebsiteRewrite> RefreshRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_rewrite.py) ---
            // def refresh_routes(self):
            // self.env['website.route']._refresh()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}