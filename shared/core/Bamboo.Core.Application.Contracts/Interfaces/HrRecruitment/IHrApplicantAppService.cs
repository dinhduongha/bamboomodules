using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrApplicantAppService : IGenericApplicationService<HrApplicant>
    {
        Task<HrApplicant> ArchiveApplicantAsync(Guid id);
        Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid id);
        Task<HrApplicant> CreateMeetingAsync(Guid id);
        Task<HrApplicant> GetEmptyListHelpAsync(Guid id, HrApplicantGetEmptyListHelpRequestDto input);
        Task<HrApplicant> GetViewAsync(Guid id, HrApplicantGetViewRequestDto input);
        Task<HrApplicant> InitAsync(Guid id);
        Task<HrApplicant> MessageNewAsync(Guid id, HrApplicantMessageNewRequestDto input);
        Task<HrApplicant> OpenAttachmentsAsync(Guid id);
        Task<HrApplicant> OpenEmployeeAsync(Guid id);
        Task<HrApplicant> OpenOtherApplicationsAsync(Guid id);
        Task<HrApplicant> PrintSurveyAsync(Guid id);
        Task<HrApplicant> ResetApplicantAsync(Guid id);
        Task<HrApplicant> SendEmailAsync(Guid id);
        Task<HrApplicant> SendSurveyAsync(Guid id);
        Task<HrApplicant> ToggleActiveAsync(Guid id);
        Task<HrApplicant> WebsiteFormInputFilterAsync(Guid id, HrApplicantWebsiteFormInputFilterRequestDto input);
    }
}