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
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
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
            // """Re-order a list of record values (dict) following a given id sequence, in O(n).
            // 
            // :param tag_list: ordered (by id) list of record values, each record being a dict
            //     containing at least an 'id' key
            // 
            // :param id_order: list of value (int) corresponding to the id of the records to re-arrange
            // :returns: Sorted list of record values (dict)
            // """
            // tags_by_id = {tag['id']: tag for tag in tag_list}
            // return [tags_by_id[id] for id in id_order if id in tags_by_id]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<List<Dictionary<string, object>>> FormattedReadGroupAsync(Guid id, ProjectTagsFormattedReadGroupRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_tags.py) ---
            // def formatted_read_group(self, domain, groupby=(), aggregates=(), having=(), offset=0, limit=None, order=None) -> list[dict]:
            // if 'project_id' in self.env.context:
            //     tag_ids = [id_ for id_, _label in self.name_search()]
            //     domain = Domain.AND([domain, [('id', 'in', tag_ids)]])
            // return super().formatted_read_group(domain, groupby, aggregates, having=having, offset=offset, limit=limit, order=order)
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