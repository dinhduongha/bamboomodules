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
    public interface IHrJobAppService : IGenericApplicationService<HrJob>
    {
        Task<HrJob> CloseDialogAsync(Guid id);
        Task<HrJob> CopyDataAsync(Guid id, HrJobCopyDataRequestDto input);
        Task<HrJob> EditDialogAsync(Guid id);
        Task<HrJob> GetBackendMenuIdAsync(Guid id);
        Task<HrJob> NewSurveyAsync(Guid id);
        Task<HrJob> OpenActivitiesAsync(Guid id);
        Task<HrJob> OpenAttachmentsAsync(Guid id);
        Task<HrJob> OpenLateActivitiesAsync(Guid id);
        Task<HrJob> OpenTodayActivitiesAsync(Guid id);
        Task<HrJob> SearchMatchingCandidatesAsync(Guid id);
        Task<HrJob> SetOpenAsync(Guid id);
        Task<HrJob> TestSurveyAsync(Guid id);
        Task<HrJob> ToggleActiveAsync(Guid id);
    }
}