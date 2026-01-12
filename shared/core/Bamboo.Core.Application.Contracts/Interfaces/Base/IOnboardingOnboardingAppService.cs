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
    public interface IOnboardingOnboardingAppService : IGenericApplicationService<OnboardingOnboarding>
    {
        Task<OnboardingOnboarding> CloseAsync(Guid id);
        Task<OnboardingOnboarding> ClosePanelAccountDashboardAsync(Guid id);
        Task<OnboardingOnboarding> ClosePanelAccountInvoiceAsync(Guid id);
        Task<OnboardingOnboarding> ClosePanelAsync(Guid id, OnboardingOnboardingClosePanelRequestDto input);
        Task<OnboardingOnboarding> RefreshProgressIdsAsync(Guid id);
        Task<OnboardingOnboarding> ToggleVisibilityAsync(Guid id);
    }
}