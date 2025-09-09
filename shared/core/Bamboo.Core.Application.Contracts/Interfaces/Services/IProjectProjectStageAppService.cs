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
    public interface IProjectProjectStageAppService : IGenericApplicationService<ProjectProjectStage>
    {
        Task<ProjectProjectStage> CopyDataAsync(Guid id, ProjectProjectStageCopyDataRequestDto input);
        Task<ProjectProjectStage> ToggleActiveAsync(Guid id);
        Task<ProjectProjectStage> UnlinkWizardAsync(Guid id, ProjectProjectStageUnlinkWizardRequestDto input);
    }
}