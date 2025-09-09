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
    public interface ISurveyUserInputAppService : IGenericApplicationService<SurveyUserInput>
    {
        Task<SurveyUserInput> GetPrintUrlAsync(Guid id);
        Task<SurveyUserInput> GetStartUrlAsync(Guid id);
        Task<SurveyUserInput> PrintAnswersAsync(Guid id);
        Task<SurveyUserInput> RedirectToAttemptsAsync(Guid id);
        Task<SurveyUserInput> ResendAsync(Guid id);
    }
}