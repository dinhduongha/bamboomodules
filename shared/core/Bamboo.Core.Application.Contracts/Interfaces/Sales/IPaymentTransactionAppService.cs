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
    public interface IPaymentTransactionAppService : IGenericAppService<PaymentTransaction>
    {
        Task<PaymentTransaction> CaptureAsync(Guid[] ids);
        Task<PaymentTransaction> DemoSetCanceledAsync(Guid[] ids);
        Task<PaymentTransaction> DemoSetDoneAsync(Guid[] ids);
        Task<PaymentTransaction> DemoSetErrorAsync(Guid[] ids);
        Task<PaymentTransaction> PostProcessAsync(Guid[] ids);
        Task<PaymentTransaction> RefundAsync(PaymentTransactionRefundRequestDto input);
        Task<PaymentTransaction> ViewInvoicesAsync(Guid[] ids);
        Task<PaymentTransaction> ViewPosOrderAsync(Guid[] ids);
        Task<PaymentTransaction> ViewRefundsAsync(Guid[] ids);
        Task<PaymentTransaction> ViewSalesOrdersAsync(Guid[] ids);
        Task<PaymentTransaction> VoidAsync(Guid[] ids);
    }
}