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
    public interface ISurveyUserInputAppService : IGenericApplicationService<SurveyUserInput>
    {
        Task<SurveyUserInput> GetPrintUrlAsync(Guid[] ids);
        Task<SurveyUserInput> GetStartUrlAsync(Guid[] ids);
        Task<SurveyUserInput> PrintAnswersAsync(Guid[] ids);
        Task<SurveyUserInput> RedirectLeadAsync(Guid[] ids);
        Task<SurveyUserInput> RedirectToAttemptsAsync(Guid[] ids);
        Task<SurveyUserInput> ResendAsync(Guid[] ids);
    }
}