using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IPaymentTransactionAppService : IGenericApplicationService<PaymentTransaction>
    {
        Task<PaymentTransaction> CaptureAsync(Guid id);
        Task<PaymentTransaction> DemoSetCanceledAsync(Guid id);
        Task<PaymentTransaction> DemoSetDoneAsync(Guid id);
        Task<PaymentTransaction> DemoSetErrorAsync(Guid id);
        Task<PaymentTransaction> RefundAsync(Guid id, PaymentTransactionRefundRequestDto input);
        Task<PaymentTransaction> ViewInvoicesAsync(Guid id);
        Task<PaymentTransaction> ViewPosOrderAsync(Guid id);
        Task<PaymentTransaction> ViewRefundsAsync(Guid id);
        Task<PaymentTransaction> ViewSalesOrdersAsync(Guid id);
        Task<PaymentTransaction> VoidAsync(Guid id);
    }
}