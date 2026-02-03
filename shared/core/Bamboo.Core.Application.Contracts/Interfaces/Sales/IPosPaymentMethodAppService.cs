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
    public interface IPosPaymentMethodAppService : IGenericAppService<PosPaymentMethod>
    {
        Task<PosPaymentMethod> CopyDataAsync(PosPaymentMethodCopyDataRequestDto input);
        Task<PosPaymentMethod> ForcePdvAsync(Guid[] ids);
        Task<PosPaymentMethod> GetLatestAdyenStatusAsync(Guid[] ids);
        Task<PosPaymentMethod> GetLatestVivaComStatusAsync(Guid[] ids);
        Task<PosPaymentMethod> GetProviderStatusAsync(PosPaymentMethodGetProviderStatusRequestDto input);
        Task<PosPaymentMethod> GetQrCodeAsync(PosPaymentMethodGetQrCodeRequestDto input);
        Task<PosPaymentMethod> MpGetPaymentStatusAsync(PosPaymentMethodMpGetPaymentStatusRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentCancelAsync(PosPaymentMethodMpPaymentIntentCancelRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentCreateAsync(PosPaymentMethodMpPaymentIntentCreateRequestDto input);
        Task<PosPaymentMethod> MpPaymentIntentGetAsync(PosPaymentMethodMpPaymentIntentGetRequestDto input);
        Task<PosPaymentMethod> PineLabsCancelPaymentRequestAsync(PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input);
        Task<PosPaymentMethod> PineLabsFetchPaymentStatusAsync(PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input);
        Task<PosPaymentMethod> PineLabsMakePaymentRequestAsync(PosPaymentMethodPineLabsMakePaymentRequestRequestDto input);
        Task<PosPaymentMethod> ProxyAdyenRequestAsync(PosPaymentMethodProxyAdyenRequestRequestDto input);
        Task<PosPaymentMethod> QfpaySignRequestAsync(PosPaymentMethodQfpaySignRequestRequestDto input);
        Task<PosPaymentMethod> RazorpayCancelPaymentRequestAsync(PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input);
        Task<PosPaymentMethod> RazorpayFetchPaymentStatusAsync(PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input);
        Task<PosPaymentMethod> RazorpayMakePaymentRequestAsync(PosPaymentMethodRazorpayMakePaymentRequestRequestDto input);
        Task<PosPaymentMethod> RazorpayMakeRefundRequestAsync(PosPaymentMethodRazorpayMakeRefundRequestRequestDto input);
        Task<PosPaymentMethod> SendDpopayRequestAsync(PosPaymentMethodSendDpopayRequestRequestDto input);
        Task<PosPaymentMethod> StripeCapturePaymentAsync(PosPaymentMethodStripeCapturePaymentRequestDto input);
        Task<PosPaymentMethod> StripeConnectionTokenAsync(Guid[] ids);
        Task<PosPaymentMethod> StripeKeyAsync(Guid[] ids);
        Task<PosPaymentMethod> StripePaymentIntentAsync(PosPaymentMethodStripePaymentIntentRequestDto input);
        Task<PosPaymentMethod> VivaComGetPaymentStatusAsync(PosPaymentMethodVivaComGetPaymentStatusRequestDto input);
        Task<PosPaymentMethod> VivaComSendPaymentCancelAsync(PosPaymentMethodVivaComSendPaymentCancelRequestDto input);
        Task<PosPaymentMethod> VivaComSendPaymentRequestAsync(PosPaymentMethodVivaComSendPaymentRequestRequestDto input);
        Task<PosPaymentMethod> VivaComSendRefundRequestAsync(PosPaymentMethodVivaComSendRefundRequestRequestDto input);
    }
}