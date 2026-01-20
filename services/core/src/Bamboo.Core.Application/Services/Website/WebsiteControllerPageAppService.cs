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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsiteControllerPageAppService : GenericApplicationService<WebsiteControllerPage>, IWebsiteControllerPageAppService
    {
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        public WebsiteControllerPageAppService(IRepository<WebsiteControllerPage, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
        }

        protected async Task<WebsiteControllerPage> CheckUserHasModelAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _check_user_has_model_access(self):
            // for record in self:
            //     self.env[record.model_id.model].check_access('read')
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name(self):
            // for rec in self:
            //     rec.name = rec.view_id.name
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeNameSlugifiedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name_slugified(self):
            // for rec in self:
            //     if not rec.model_id:
            //         rec.name_slugified = False
            //         continue
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name or '')
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeUrlDemoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_url_demo(self):
            // for rec in self:
            //     if not rec.name_slugified:
            //         rec.url_demo = ""
            //         continue
            //     url = ["", "model", rec.name_slugified]
            //     rec.url_demo = "/".join(url)
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> DefaultIsPublishedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _default_is_published(self):
            // return False
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> InverseNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name(self):
            // for rec in self:
            //     if rec.view_id:
            //         rec.view_id.name = rec.name
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> InverseNameSlugifiedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name_slugified(self):
            // for rec in self:
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name_slugified)
            */
            return default;
        }

        public async Task<WebsiteControllerPage> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def open_website_url(self):
            // url = f"/model/{self.name_slugified}"
            // return {
            //     "type": "ir.actions.act_url",
            //     "url": url
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}