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
        Task<PaymentProvider> ButtonImmediateInstallAsync(Guid id);
        Task<PaymentProvider> GetBaseUrlAsync(Guid id);
        Task<PaymentProvider> PaypalCreateWebhookAsync(Guid id);
        Task<PaymentProvider> RazorpayCreateWebhookAsync(Guid id);
        Task<PaymentProvider> RazorpayRedirectToOauthUrlAsync(Guid id);
        Task<PaymentProvider> RazorpayResetOauthAccountAsync(Guid id);
        Task<PaymentProvider> RecomputePendingMsgAsync(Guid id);
        Task<PaymentProvider> StripeConnectAccountAsync(Guid id, PaymentProviderStripeConnectAccountRequestDto input);
        Task<PaymentProvider> StripeCreateWebhookAsync(Guid id);
        Task<PaymentProvider> StripeVerifyApplePayDomainAsync(Guid id);
        Task<PaymentProvider> ToggleIsPublishedAsync(Guid id);
        Task<PaymentProvider> UpdateMerchantDetailsAsync(Guid id);
        Task<PaymentProvider> ViewPaymentMethodsAsync(Guid id);
    }
}