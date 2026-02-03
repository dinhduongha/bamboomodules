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
    public interface IAccountPaymentAppService : IGenericApplicationService<AccountPayment>
    {
        Task<AccountPayment> ButtonOpenBillsAsync(Guid[] ids);
        Task<AccountPayment> ButtonOpenInvoicesAsync(Guid[] ids);
        Task<AccountPayment> ButtonOpenJournalEntryAsync(Guid[] ids);
        Task<AccountPayment> ButtonOpenStatementLinesAsync(Guid[] ids);
        Task<AccountPayment> ButtonRequestCancelAsync(Guid[] ids);
        Task<AccountPayment> CancelAsync(Guid[] ids);
        Task<AccountPayment> CopyDataAsync(AccountPaymentCopyDataRequestDto input);
        Task<AccountPayment> DoPrintChecksAsync(Guid[] ids);
        Task<AccountPayment> DraftAsync(Guid[] ids);
        Task<AccountPayment> MarkAsSentAsync(Guid[] ids);
        Task<AccountPayment> OpenBusinessDocAsync(Guid[] ids);
        Task<AccountPayment> OpenExpenseAsync(Guid[] ids);
        Task<AccountPayment> PostAsync(Guid[] ids);
        Task<AccountPayment> PrintChecksAsync(Guid[] ids);
        Task<AccountPayment> RefundWizardAsync(Guid[] ids);
        Task<AccountPayment> RejectAsync(Guid[] ids);
        Task<AccountPayment> UnmarkAsSentAsync(Guid[] ids);
        Task<AccountPayment> ValidateAsync(Guid[] ids);
        Task<AccountPayment> ViewPosOrderAsync(Guid[] ids);
        Task<AccountPayment> ViewRefundsAsync(Guid[] ids);
        Task<AccountPayment> VoidCheckAsync(Guid[] ids);
    }
}