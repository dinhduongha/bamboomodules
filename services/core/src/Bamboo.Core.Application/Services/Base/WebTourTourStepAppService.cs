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
    [Module("WebTour", Category = "Base", Depends = new[] { "web" })]
    public class WebTourTourStepAppService : GenericApplicationService<WebTourTourStep>, IWebTourTourStepAppService
    {

        public WebTourTourStepAppService(IRepository<WebTourTourStep, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<WebTourTourStep> GetStepsJsonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: tour.py) ---
            // def get_steps_json(self):
            // steps = []
            // 
            // for step in self.read(fields=["trigger", "content", "run"]):
            //     del step["id"]
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