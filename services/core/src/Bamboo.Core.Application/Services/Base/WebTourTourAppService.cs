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

namespace Bamboo.Core.Application.Services
{
    [Module("WebTour", Depends = new[] { "web" })]
    public class WebTourTourAppService : GenericApplicationService<WebTourTour>, IWebTourTourAppService
    {

        public WebTourTourAppService(IRepository<WebTourTour, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<WebTourTour> ComputeSharingUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def _compute_sharing_url(self):
            // for tour in self:
            //     tour.sharing_url = f"{tour.get_base_url()}/odoo?tour={tour.name}"
            */
            return default;
        }

        public async Task<WebTourTour> ConsumeAsync(Guid id, WebTourTourConsumeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def consume(self, tourName):
            // if self.env.user and self.env.user._is_internal():
            //     tour_id = self.search([("name", "=", tourName)])
            //     if tour_id:
            //         tour_id.sudo().user_consumed_ids = [Command.link(self.env.user.id)]
            // return self.get_current_tour()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<WebTourTour> ExportJsFileAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def export_js_file(self):
            //         js_content = f"""import {{ registry }} from '@web/core/registry';
            // 
            // registry.category("web_tour.tours").add("{self.name}", {{
            //     url: "{self.url}",
            //     steps: () => {json.dumps(self.step_ids.get_steps_json(), indent=4)}
            // }})"""
            // 
            //         attachment_id = self.env["ir.attachment"].create({
            //             "datas": base64.b64encode(bytes(js_content, 'utf-8')),
            //             "name": f"{self.name}.js",
            //             "mimetype": "application/javascript",
            //             "res_model": "web_tour.tour",
            //             "res_id": self.id,
            //         })
            // 
            //         return {
            //             "type": "ir.actions.act_url",
            //             "url": f"/web/content/{attachment_id.id}?download=true",
            //         }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<WebTourTour> GetCurrentTourAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def get_current_tour(self):
            // if self.env.user and self.env.user.tour_enabled and self.env.user._is_internal():
            //     tours_to_run = self.search([("custom", "=", False), ("user_consumed_ids", "not in", self.env.user.id)])
            //     return bool(tours_to_run[:1]) and tours_to_run[:1]._get_tour_json()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<WebTourTour> GetTourJsonByNameAsync(Guid id, WebTourTourGetTourJsonByNameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def get_tour_json_by_name(self, tour_name):
            // tour_id = self.search([("name", "=", tour_name)])
            // return tour_id._get_tour_json()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebTourTour> GetTourJsonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def _get_tour_json(self):
            // tour_json = self.read(fields={
            //     "name",
            //     "url",
            //     "custom"
            // })[0]
            // 
            // del tour_json["id"]
            // tour_json["steps"] = self.step_ids.get_steps_json()
            // tour_json["rainbowManMessage"] = self.rainbow_man_message
            // return tour_json
            */
            return default;
        }
    }
}