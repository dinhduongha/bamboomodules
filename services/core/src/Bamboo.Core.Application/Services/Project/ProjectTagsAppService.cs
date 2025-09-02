using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Project", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public class ProjectTagsAppService : GenericApplicationService<ProjectTags>, IProjectTagsAppService
    {

        public ProjectTagsAppService(IRepository<ProjectTags, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ProjectTags> ArrangeTagListByIdAsync(Guid id, ProjectTagsArrangeTagListByIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_tags.py) ---
            // def arrange_tag_list_by_id(self, tag_list, id_order):
            // """arrange_tag_list_by_id re-order a list of record values (dict) following a given id sequence
            //    complexity: O(n)
            //    param:
            //         - tag_list: ordered (by id) list of record values, each record being a dict
            //           containing at least an 'id' key
            //         - id_order: list of value (int) corresponding to the id of the records to re-arrange
            //    result:
            //         - Sorted list of record values (dict)
            // """
            // tags_by_id = {tag['id']: tag for tag in tag_list}
            // return [tags_by_id[id] for id in id_order if id in tags_by_id]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTags> GetDefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_tags.py) ---
            // def _get_default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        protected async Task<ProjectTags> GetProjectTagsDomainInternalAsync(object domain, Guid project_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_tags.py) ---
            // def _get_project_tags_domain(self, domain, project_id):
            // # TODO: Remove in master
            // return domain
            */
            return default;
        }
    }
}