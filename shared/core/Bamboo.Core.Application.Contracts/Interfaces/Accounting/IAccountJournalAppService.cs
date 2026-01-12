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
    public interface IAccountJournalAppService : IGenericApplicationService<AccountJournal>
    {
        Task<AccountJournal> ArchiveAsync(Guid id);
        Task<AccountJournal> ButtonFetchInEinvoicesAsync(Guid id);
        Task<AccountJournal> ButtonRefreshOutEinvoicesStatusAsync(Guid id);
        Task<AccountJournal> ButtonUnsubscribeFromInvoiceNotificationsAsync(Guid id);
        Task<AccountJournal> ChecksToPrintAsync(Guid id);
        Task<AccountJournal> ConfigureBankJournalAsync(Guid id);
        Task<AccountJournal> CopyDataAsync(Guid id, AccountJournalCopyDataRequestDto input);
        Task<AccountJournal> CreateBankStatementAsync(Guid id);
        Task<AccountJournal> CreateCustomerPaymentAsync(Guid id);
        Task<AccountJournal> CreateDocumentFromAttachmentAsync(Guid id, AccountJournalCreateDocumentFromAttachmentRequestDto input);
        Task<AccountJournal> CreateNewAsync(Guid id);
        Task<AccountJournal> CreateSupplierPaymentAsync(Guid id);
        Task<AccountJournal> CreateVendorBillAsync(Guid id);
        Task<AccountJournal> OpenActionAsync(Guid id);
        Task<AccountJournal> OpenBankDifferenceActionAsync(Guid id);
        Task<AccountJournal> OpenInvalidStatementsActionAsync(Guid id);
        Task<AccountJournal> OpenPaymentsActionAsync(Guid id, AccountJournalOpenPaymentsActionRequestDto input);
        Task<AccountJournal> OpenWithContextAsync(Guid id);
        Task<AccountJournal> PostAllEntriesAsync(Guid id);
        Task<AccountJournal> SetBankAccountAsync(Guid id, AccountJournalSetBankAccountRequestDto input);
        Task<AccountJournal> ShowSequenceHolesAsync(Guid id);
        Task<AccountJournal> ShowUnhashedEntriesAsync(Guid id);
        Task<AccountJournal> ToCheckIdsAsync(Guid id);
    }
}