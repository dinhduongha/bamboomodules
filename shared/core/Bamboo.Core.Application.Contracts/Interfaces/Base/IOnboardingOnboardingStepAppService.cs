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
    public interface IOnboardingOnboardingStepAppService : IGenericApplicationService<OnboardingOnboardingStep>
    {
        Task<OnboardingOnboardingStep> CheckStepOnOnboardingHasActionAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepBankAccountAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepBaseDocumentLayoutAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepChartOfAccountsAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepCompanyDataAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepCreateInvoiceAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepFiscalYearAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> OpenStepSalesTaxAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> SetJustDoneAsync(Guid[] ids);
        Task<OnboardingOnboardingStep> ValidateStepAsync(OnboardingOnboardingStepValidateStepRequestDto input);
        Task<OnboardingOnboardingStep> ValidateStepBaseDocumentLayoutAsync(Guid[] ids);
    }
}