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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsiteTechnicalPageAppService : GenericApplicationService<WebsiteTechnicalPage>, IWebsiteTechnicalPageAppService
    {

        public WebsiteTechnicalPageAppService(IRepository<WebsiteTechnicalPage, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<WebsiteTechnicalPage> GetStaticRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_technical_page.py) ---
            // def get_static_routes(self):
            // """
            // Returns a set of website content static routes.
            // """
            // dynamic_route_re = re.compile(r"<[^>]+>")
            // routes = set()
            // for rule in self.env["ir.http"].routing_map().iter_rules():
            //     endpoint = rule.endpoint.routing
            //     route_title = endpoint.get("list_as_website_content")
            //     if route_title:
            //         last_static_route = next(
            //             r for r in reversed(endpoint.get("routes", []))
            //             if not dynamic_route_re.search(r)
            //         )
            //         routes.add((str(route_title), last_static_route))
            // return routes
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<WebsiteTechnicalPage> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_technical_page.py) ---
            // def open_website_url(self):
            // """
            // Opens the technical page for the given URL and website.
            // """
            // return self.env["website"].get_client_action(self.website_url)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsiteTechnicalPage> TableQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_technical_page.py) ---
            // def _table_query(self):
            // routes = self.get_static_routes()
            // values = SQL(", ").join(
            //     SQL('(%s, %s)', route_title, route_path)
            //     for route_title, route_path in routes
            // )
            // 
            // return SQL("""
            //     SELECT row_number() OVER () AS id,
            //         column1 AS name,
            //         column2 AS website_url
            //     FROM (VALUES %s) AS t(column1, column2)
            // """, values)
            */
            return default;
        }
    }
}