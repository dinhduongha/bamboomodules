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
        Task<ProjectMilestone> ToggleIsReachedAsync(ProjectMilestoneToggleIsReachedRequestDto input);
        Task<ProjectMilestone> ViewSaleOrderAsync(Guid[] ids);
        Task<ProjectMilestone> ViewTasksAsync(Guid[] ids);
    }
}