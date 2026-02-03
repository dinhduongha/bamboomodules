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
        Task<HrJob> ArchiveAsync(Guid[] ids);
        Task<HrJob> CopyDataAsync(HrJobCopyDataRequestDto input);
        Task<HrJob> GetBackendMenuIdAsync(Guid[] ids);
        Task<HrJob> NewSurveyAsync(Guid[] ids);
        Task<HrJob> OpenActivitiesAsync(Guid[] ids);
        Task<HrJob> OpenAttachmentsAsync(Guid[] ids);
        Task<HrJob> OpenEmployeesAsync(Guid[] ids);
        Task<HrJob> SearchMatchingApplicantsAsync(Guid[] ids);
        Task<HrJob> SetOpenAsync(Guid[] ids);
        Task<HrJob> TestSurveyAsync(Guid[] ids);
    }
}