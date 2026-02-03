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
    public interface IPaymentProviderAppService : IGenericApplicationService<PaymentProvider>
    {
        Task<PaymentProvider> ButtonImmediateInstallAsync(Guid[] ids);
        Task<PaymentProvider> GetBaseUrlAsync(Guid[] ids);
        Task<PaymentProvider> PaypalCreateWebhookAsync(Guid[] ids);
        Task<PaymentProvider> RazorpayCreateWebhookAsync(Guid[] ids);
        Task<PaymentProvider> RecomputePendingMsgAsync(Guid[] ids);
        Task<PaymentProvider> ResetCredentialsAsync(Guid[] ids);
        Task<PaymentProvider> StartOnboardingAsync(PaymentProviderStartOnboardingRequestDto input);
        Task<PaymentProvider> StripeCreateWebhookAsync(Guid[] ids);
        Task<PaymentProvider> StripeVerifyApplePayDomainAsync(Guid[] ids);
        Task<PaymentProvider> SyncPaymobPaymentMethodsAsync(Guid[] ids);
        Task<PaymentProvider> ToggleIsPublishedAsync(Guid[] ids);
        Task<PaymentProvider> UpdateMerchantDetailsAsync(Guid[] ids);
        Task<PaymentProvider> ViewPaymentMethodsAsync(Guid[] ids);
    }
}