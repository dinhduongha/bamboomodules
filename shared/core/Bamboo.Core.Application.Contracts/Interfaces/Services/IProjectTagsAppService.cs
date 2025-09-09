using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IProjectTagsAppService : IGenericApplicationService<ProjectTags>
    {
        Task<ProjectTags> ArrangeTagListByIdAsync(Guid id, ProjectTagsArrangeTagListByIdRequestDto input);
    }
}