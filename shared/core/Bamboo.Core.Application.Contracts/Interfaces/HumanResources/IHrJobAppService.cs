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
        Task<HrJob> ArchiveAsync(Guid id);
        Task<HrJob> CopyDataAsync(Guid id, HrJobCopyDataRequestDto input);
        Task<HrJob> GetBackendMenuIdAsync(Guid id);
        Task<HrJob> NewSurveyAsync(Guid id);
        Task<HrJob> OpenActivitiesAsync(Guid id);
        Task<HrJob> OpenAttachmentsAsync(Guid id);
        Task<HrJob> OpenEmployeesAsync(Guid id);
        Task<HrJob> SearchMatchingApplicantsAsync(Guid id);
        Task<HrJob> SetOpenAsync(Guid id);
        Task<HrJob> TestSurveyAsync(Guid id);
    }
}