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
    public interface IOnboardingProgressAppService : IGenericApplicationService<OnboardingProgress>
    {
        Task<OnboardingProgress> CloseAsync(Guid id);
        Task<OnboardingProgress> InitAsync(Guid id);
        Task<OnboardingProgress> ToggleVisibilityAsync(Guid id);
    }
}