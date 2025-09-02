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
    public interface IAccountPaymentAppService : IGenericApplicationService<AccountPayment>
    {
        Task<AccountPayment> ButtonOpenBillsAsync(Guid id);
        Task<AccountPayment> ButtonOpenInvoicesAsync(Guid id);
        Task<AccountPayment> ButtonOpenJournalEntryAsync(Guid id);
        Task<AccountPayment> ButtonOpenStatementLinesAsync(Guid id);
        Task<AccountPayment> ButtonRequestCancelAsync(Guid id);
        Task<AccountPayment> CancelAsync(Guid id);
        Task<AccountPayment> CopyDataAsync(Guid id, AccountPaymentCopyDataRequestDto input);
        Task<AccountPayment> DoPrintChecksAsync(Guid id);
        Task<AccountPayment> DraftAsync(Guid id);
        Task<AccountPayment> InitAsync(Guid id);
        Task<AccountPayment> MarkAsSentAsync(Guid id);
        Task<AccountPayment> OpenBusinessDocAsync(Guid id);
        Task<AccountPayment> OpenExpenseReportAsync(Guid id);
        Task<AccountPayment> PostAsync(Guid id);
        Task<AccountPayment> PrintChecksAsync(Guid id);
        Task<AccountPayment> RefundWizardAsync(Guid id);
        Task<AccountPayment> RejectAsync(Guid id);
        Task<AccountPayment> UnmarkAsSentAsync(Guid id);
        Task<AccountPayment> ValidateAsync(Guid id);
        Task<AccountPayment> ViewPosOrderAsync(Guid id);
        Task<AccountPayment> ViewRefundsAsync(Guid id);
        Task<AccountPayment> VoidCheckAsync(Guid id);
    }
}