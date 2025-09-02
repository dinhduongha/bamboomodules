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
    public interface IOnboardingProgressStepAppService : IGenericApplicationService<OnboardingProgressStep>
    {
        Task<OnboardingProgressStep> ConsolidateJustDoneAsync(Guid id);
        Task<OnboardingProgressStep> InitAsync(Guid id);
        Task<OnboardingProgressStep> SetJustDoneAsync(Guid id);
    }
}