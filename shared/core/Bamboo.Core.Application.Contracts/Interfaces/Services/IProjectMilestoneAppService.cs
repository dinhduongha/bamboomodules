using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IProjectMilestoneAppService : IGenericApplicationService<ProjectMilestone>
    {
        Task<ProjectMilestone> ToggleIsReachedAsync(Guid id, ProjectMilestoneToggleIsReachedRequestDto input);
        Task<ProjectMilestone> ViewSaleOrderAsync(Guid id);
        Task<ProjectMilestone> ViewTasksAsync(Guid id);
    }
}