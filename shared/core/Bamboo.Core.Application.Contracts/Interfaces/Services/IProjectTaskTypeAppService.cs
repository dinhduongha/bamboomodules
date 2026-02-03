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
    public interface IProjectTaskTypeAppService : IGenericApplicationService<ProjectTaskType>
    {
        Task<ProjectTaskType> CopyDataAsync(ProjectTaskTypeCopyDataRequestDto input);
        Task<ProjectTaskType> UnarchiveAsync(Guid[] ids);
        Task<ProjectTaskType> UnlinkWizardAsync(ProjectTaskTypeUnlinkWizardRequestDto input);
    }
}