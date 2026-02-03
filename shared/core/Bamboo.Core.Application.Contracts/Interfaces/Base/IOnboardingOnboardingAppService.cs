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
        Task<OnboardingOnboarding> CloseAsync(Guid[] ids);
        Task<OnboardingOnboarding> ClosePanelAccountDashboardAsync(Guid[] ids);
        Task<OnboardingOnboarding> ClosePanelAccountInvoiceAsync(Guid[] ids);
        Task<OnboardingOnboarding> ClosePanelAsync(OnboardingOnboardingClosePanelRequestDto input);
        Task<OnboardingOnboarding> RefreshProgressIdsAsync(Guid[] ids);
        Task<OnboardingOnboarding> ToggleVisibilityAsync(Guid[] ids);
    }
}