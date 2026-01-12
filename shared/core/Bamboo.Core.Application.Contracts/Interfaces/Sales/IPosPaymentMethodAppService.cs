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
    public interface IPosPaymentMethodAppService : IGenericApplicationService<PosPaymentMethod>
    {
        Task<PosPaymentMethod> CopyDataAsync(Guid id, PosPaymentMethodCopyDataRequestDto input);
        Task<PosPaymentMethod> ForcePdvAsync(Guid id);
        Task<PosPaymentMethod> GetLatestAdyenStatusAsync(Guid id);
        Task<PosPaymentMethod> GetLatestVivaWalletStatusAsync(Guid id);
        Task<PosPaymentMethod> GetQrCodeAsync(Guid id, PosPaymentMethodGetQrCodeRequestDto input);
        Task<PosPaymentMethod> MpGetPaymentStatusAsync(Guid id, PosPaymentMethodMpGetPaymentStatusRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentCancelAsync(Guid id, PosPaymentMethodMpPaymentIntentCancelRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentCreateAsync(Guid id, PosPaymentMethodMpPaymentIntentCreateRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentGetAsync(Guid id, PosPaymentMethodMpPaymentIntentGetRequestDto input);
        Task<PosPaymentMethod> PaytmFetchPaymentStatusAsync(Guid id, PosPaymentMethodPaytmFetchPaymentStatusRequestDto input);
        Task<PosPaymentMethod> PaytmMakePaymentRequestAsync(Guid id, PosPaymentMethodPaytmMakePaymentRequestRequestDto input);
        Task<PosPaymentMethod> PineLabsCancelPaymentRequestAsync(Guid id, PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input);
        Task<PosPaymentMethod> PineLabsFetchPaymentStatusAsync(Guid id, PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input);
        Task<PosPaymentMethod> PineLabsMakePaymentRequestAsync(Guid id, PosPaymentMethodPineLabsMakePaymentRequestRequestDto input);
        Task<PosPaymentMethod> ProxyAdyenRequestAsync(Guid id, PosPaymentMethodProxyAdyenRequestRequestDto input);
        Task<PosPaymentMethod> RazorpayCancelPaymentRequestAsync(Guid id, PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input);
        Task<PosPaymentMethod> RazorpayFetchPaymentStatusAsync(Guid id, PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input);
        Task<PosPaymentMethod> RazorpayMakePaymentRequestAsync(Guid id, PosPaymentMethodRazorpayMakePaymentRequestRequestDto input);
        Task<PosPaymentMethod> StripeCapturePaymentAsync(Guid id, PosPaymentMethodStripeCapturePaymentRequestDto input);
        Task<PosPaymentMethod> StripeConnectionTokenAsync(Guid id);
        Task<PosPaymentMethod> StripeKeyAsync(Guid id);
        Task<PosPaymentMethod> StripePaymentIntentAsync(Guid id, PosPaymentMethodStripePaymentIntentRequestDto input);
        Task<PosPaymentMethod> VivaWalletGetPaymentStatusAsync(Guid id, PosPaymentMethodVivaWalletGetPaymentStatusRequestDto input);
        Task<PosPaymentMethod> VivaWalletSendPaymentCancelAsync(Guid id, PosPaymentMethodVivaWalletSendPaymentCancelRequestDto input);
        Task<PosPaymentMethod> VivaWalletSendPaymentRequestAsync(Guid id, PosPaymentMethodVivaWalletSendPaymentRequestRequestDto input);
    }
}