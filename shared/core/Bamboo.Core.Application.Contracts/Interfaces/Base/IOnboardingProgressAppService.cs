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
    public interface IOnboardingProgressAppService : IGenericApplicationService<OnboardingProgress>
    {
        Task<OnboardingProgress> CloseAsync(Guid id);
        Task<OnboardingProgress> InitAsync(Guid id);
        Task<OnboardingProgress> ToggleVisibilityAsync(Guid id);
    }
}