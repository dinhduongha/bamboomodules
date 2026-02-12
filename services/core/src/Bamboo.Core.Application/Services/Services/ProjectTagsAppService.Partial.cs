using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class ProjectTagsAppService
    {

        protected async Task<ProjectTags> GetDefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_tags.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        protected async Task<ProjectTags> GetProjectTagsDomainInternalAsync(object domain, Guid project_id)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_tags.py, METHOD: _get_project_tags_domain) ---
            */
            return default;
        }
    }
}