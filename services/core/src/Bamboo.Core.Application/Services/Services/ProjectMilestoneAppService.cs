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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public partial class ProjectMilestoneAppService : GenericAppService<ProjectMilestone>, IProjectMilestoneAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public ProjectMilestoneAppService(IRepository<ProjectMilestone, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<ProjectMilestone> ToggleIsReachedAsync(ProjectMilestoneToggleIsReachedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: toggle_is_reached) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectMilestone> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectMilestone> ViewTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: action_view_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}