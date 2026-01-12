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
        Task<HrApplicant> AddToJobAsync(Guid id);
        Task<HrApplicant> ArchiveApplicantAsync(Guid id);
        Task<HrApplicant> ArchiveAsync(Guid id);
        Task<HrApplicant> CopyDataAsync(Guid id, HrApplicantCopyDataRequestDto input);
        Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid id);
        Task<HrApplicant> CreateMeetingAsync(Guid id);
        Task<HrApplicant> GetEmptyListHelpAsync(Guid id, HrApplicantGetEmptyListHelpRequestDto input);
        Task<HrApplicant> GetViewAsync(Guid id, HrApplicantGetViewRequestDto input);
        Task<HrApplicant> JobAddApplicantsAsync(Guid id);
        Task<HrApplicant> LinkApplicantToTalentAsync(Guid id);
        Task<HrApplicant> MessageNewAsync(Guid id, HrApplicantMessageNewRequestDto input);
        Task<HrApplicant> OpenApplicationsAsync(Guid id);
        Task<HrApplicant> OpenAttachmentsAsync(Guid id);
        Task<HrApplicant> OpenEmployeeAsync(Guid id);
        Task<HrApplicant> PrintSurveyAsync(Guid id);
        Task<HrApplicant> ResetApplicantAsync(Guid id);
        Task<HrApplicant> SendEmailAsync(Guid id);
        Task<HrApplicant> SendSmsAsync(Guid id);
        Task<HrApplicant> SendSurveyAsync(Guid id);
        Task<HrApplicant> TalentPoolAddApplicantsAsync(Guid id);
        Task<HrApplicant> TalentPoolStatButtonAsync(Guid id);
        Task<HrApplicant> UnarchiveAsync(Guid id);
        Task<HrApplicant> WebsiteFormInputFilterAsync(Guid id, HrApplicantWebsiteFormInputFilterRequestDto input);
    }
}