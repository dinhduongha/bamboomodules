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
    public interface ISurveySurveyAppService : IGenericApplicationService<SurveySurvey>
    {
        Task<SurveySurvey> CheckValidityAsync(Guid id);
        Task<SurveySurvey> CopyDataAsync(Guid id, SurveySurveyCopyDataRequestDto input);
        Task<SurveySurvey> EndSessionAsync(Guid id);
        Task<SurveySurvey> GetFormviewIdAsync(Guid id, SurveySurveyGetFormviewIdRequestDto input);
        Task<SurveySurvey> GetPrintUrlAsync(Guid id);
        Task<SurveySurvey> GetStartShortUrlAsync(Guid id);
        Task<SurveySurvey> GetStartUrlAsync(Guid id);
        Task<SurveySurvey> LoadSampleAssessmentAsync(Guid id);
        Task<SurveySurvey> LoadSampleCustomAsync(Guid id);
        Task<SurveySurvey> LoadSampleLiveSessionAsync(Guid id);
        Task<SurveySurvey> LoadSampleSurveyAsync(Guid id);
        Task<SurveySurvey> OpenSessionManagerAsync(Guid id);
        Task<SurveySurvey> PrintSurveyAsync(Guid id, SurveySurveyPrintSurveyRequestDto input);
        Task<SurveySurvey> ResultSurveyAsync(Guid id);
        Task<SurveySurvey> SendSurveyAsync(Guid id);
        Task<SurveySurvey> ShowSampleAsync(Guid id);
        Task<SurveySurvey> StartSessionAsync(Guid id);
        Task<SurveySurvey> StartSurveyAsync(Guid id, SurveySurveyStartSurveyRequestDto input);
        Task<SurveySurvey> SurveyPreviewCertificationTemplateAsync(Guid id);
        Task<SurveySurvey> SurveyUserInputAsync(Guid id);
        Task<SurveySurvey> SurveyUserInputCertifiedAsync(Guid id);
        Task<SurveySurvey> SurveyUserInputCompletedAsync(Guid id);
        Task<SurveySurvey> SurveyViewSlideChannelsAsync(Guid id);
        Task<SurveySurvey> TestSurveyAsync(Guid id);
        Task<SurveySurvey> ToggleActiveAsync(Guid id);
    }
}