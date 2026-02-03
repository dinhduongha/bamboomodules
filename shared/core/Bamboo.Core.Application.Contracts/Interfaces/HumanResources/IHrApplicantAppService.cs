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
    public interface IHrApplicantAppService : IGenericApplicationService<HrApplicant>
    {
        Task<HrApplicant> AddToJobAsync(Guid[] ids);
        Task<HrApplicant> ArchiveApplicantAsync(Guid[] ids);
        Task<HrApplicant> ArchiveAsync(Guid[] ids);
        Task<HrApplicant> CopyDataAsync(HrApplicantCopyDataRequestDto input);
        Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid[] ids);
        Task<HrApplicant> CreateMeetingAsync(Guid[] ids);
        Task<HrApplicant> GetEmptyListHelpAsync(HrApplicantGetEmptyListHelpRequestDto input);
        Task<HrApplicant> GetViewAsync(HrApplicantGetViewRequestDto input);
        Task<HrApplicant> JobAddApplicantsAsync(Guid[] ids);
        Task<HrApplicant> LinkApplicantToTalentAsync(Guid[] ids);
        Task<HrApplicant> MessageNewAsync(HrApplicantMessageNewRequestDto input);
        Task<HrApplicant> OpenApplicationsAsync(Guid[] ids);
        Task<HrApplicant> OpenAttachmentsAsync(Guid[] ids);
        Task<HrApplicant> OpenEmployeeAsync(Guid[] ids);
        Task<HrApplicant> PrintSurveyAsync(Guid[] ids);
        Task<HrApplicant> ResetApplicantAsync(Guid[] ids);
        Task<HrApplicant> SendEmailAsync(Guid[] ids);
        Task<HrApplicant> SendSmsAsync(Guid[] ids);
        Task<HrApplicant> SendSurveyAsync(Guid[] ids);
        Task<HrApplicant> TalentPoolAddApplicantsAsync(Guid[] ids);
        Task<HrApplicant> TalentPoolStatButtonAsync(Guid[] ids);
        Task<HrApplicant> UnarchiveAsync(Guid[] ids);
        Task<HrApplicant> WebsiteFormInputFilterAsync(HrApplicantWebsiteFormInputFilterRequestDto input);
    }
}