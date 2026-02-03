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
    public interface ISurveySurveyAppService : IGenericAppService<SurveySurvey>
    {
        Task<SurveySurvey> ArchiveAsync(Guid[] ids);
        Task<SurveySurvey> CheckValidityAsync(Guid[] ids);
        Task<SurveySurvey> CopyDataAsync(SurveySurveyCopyDataRequestDto input);
        Task<SurveySurvey> EndSessionAsync(Guid[] ids);
        Task<SurveySurvey> GetFormviewIdAsync(SurveySurveyGetFormviewIdRequestDto input);
        Task<SurveySurvey> GetPrintUrlAsync(Guid[] ids);
        Task<SurveySurvey> GetStartShortUrlAsync(Guid[] ids);
        Task<SurveySurvey> GetStartUrlAsync(Guid[] ids);
        Task<SurveySurvey> GetSurveyTemplatesDataAsync(Guid[] ids);
        Task<SurveySurvey> LoadSampleCustomAsync(Guid[] ids);
        Task<SurveySurvey> LoadSurveyTemplateSampleAsync(SurveySurveyLoadSurveyTemplateSampleRequestDto input);
        Task<SurveySurvey> OpenSessionManagerAsync(Guid[] ids);
        Task<SurveySurvey> PrintSurveyAsync(SurveySurveyPrintSurveyRequestDto input);
        Task<SurveySurvey> ResultSurveyAsync(Guid[] ids);
        Task<SurveySurvey> SendSurveyAsync(Guid[] ids);
        Task<SurveySurvey> ShowSampleAsync(Guid[] ids);
        Task<SurveySurvey> StartSessionAsync(Guid[] ids);
        Task<SurveySurvey> StartSurveyAsync(SurveySurveyStartSurveyRequestDto input);
        Task<SurveySurvey> SurveyPreviewCertificationTemplateAsync(Guid[] ids);
        Task<SurveySurvey> SurveySeeLeadsAsync(Guid[] ids);
        Task<SurveySurvey> SurveyUserInputAsync(Guid[] ids);
        Task<SurveySurvey> SurveyUserInputCertifiedAsync(Guid[] ids);
        Task<SurveySurvey> SurveyUserInputCompletedAsync(Guid[] ids);
        Task<SurveySurvey> SurveyViewSlideChannelsAsync(Guid[] ids);
        Task<SurveySurvey> TestSurveyAsync(Guid[] ids);
        Task<SurveySurvey> UnarchiveAsync(Guid[] ids);
    }
}