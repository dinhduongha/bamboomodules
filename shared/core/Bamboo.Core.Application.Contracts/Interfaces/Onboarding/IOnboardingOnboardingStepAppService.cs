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
    public interface IOnboardingOnboardingStepAppService : IGenericApplicationService<OnboardingOnboardingStep>
    {
        Task<OnboardingOnboardingStep> CheckStepOnOnboardingHasActionAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepBankAccountAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepBaseDocumentLayoutAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepChartOfAccountsAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepCompanyDataAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepCreateInvoiceAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepFiscalYearAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepPaymentProviderAsync(Guid id);
        Task<OnboardingOnboardingStep> OpenStepSalesTaxAsync(Guid id);
        Task<OnboardingOnboardingStep> SetJustDoneAsync(Guid id);
        Task<OnboardingOnboardingStep> ValidateStepAsync(Guid id, OnboardingOnboardingStepValidateStepRequestDto input);
        Task<OnboardingOnboardingStep> ValidateStepBaseDocumentLayoutAsync(Guid id);
        Task<OnboardingOnboardingStep> ValidateStepPaymentProviderAsync(Guid id);
    }
}