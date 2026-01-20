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
    [Module("WebTour", Category = "Base", Depends = new[] { "web" })]
    public partial class WebTourTourStepAppService : GenericApplicationService<WebTourTourStep>, IWebTourTourStepAppService
    {

        public WebTourTourStepAppService(IRepository<WebTourTourStep, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<WebTourTourStep> GetStepsJsonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def get_steps_json(self):
            // steps = []
            // 
            // for step in self.read(fields=["trigger", "content", "run", "tooltip_position"]):
            //     del step["id"]
            //     step["tooltipPosition"] = step["tooltip_position"]
            //     del step["tooltip_position"]
            // 
            //     if not step["content"]:
            //         del step["content"]
            //     steps.append(step)
            // 
            // return steps
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}