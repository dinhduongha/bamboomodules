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
    public interface IProjectProjectStageAppService : IGenericApplicationService<ProjectProjectStage>
    {
        Task<ProjectProjectStage> CopyDataAsync(Guid id, ProjectProjectStageCopyDataRequestDto input);
        Task<ProjectProjectStage> UnarchiveAsync(Guid id);
        Task<ProjectProjectStage> UnlinkWizardAsync(Guid id, ProjectProjectStageUnlinkWizardRequestDto input);
    }
}