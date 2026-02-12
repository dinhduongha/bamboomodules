using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class WebTourTourAppService : GenericAppService<WebTourTour>, IWebTourTourAppService
    {

        public WebTourTourAppService(IRepository<WebTourTour, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<WebTourTour> ConsumeAsync(WebTourTourConsumeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: tour.py, METHOD: consume) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<WebTourTour> ExportJsFileAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: tour.py, METHOD: export_js_file) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<WebTourTour> GetCurrentTourAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: tour.py, METHOD: get_current_tour) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<WebTourTour> GetTourJsonByNameAsync(WebTourTourGetTourJsonByNameRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: tour.py, METHOD: get_tour_json_by_name) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}