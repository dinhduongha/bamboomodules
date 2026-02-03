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
        Task<AccountJournal> ArchiveAsync(Guid[] ids);
        Task<AccountJournal> ButtonFetchInEinvoicesAsync(Guid[] ids);
        Task<AccountJournal> ButtonRefreshOutEinvoicesStatusAsync(Guid[] ids);
        Task<AccountJournal> ButtonUnsubscribeFromInvoiceNotificationsAsync(Guid[] ids);
        Task<AccountJournal> ChecksToPrintAsync(Guid[] ids);
        Task<AccountJournal> ConfigureBankJournalAsync(Guid[] ids);
        Task<AccountJournal> CopyDataAsync(AccountJournalCopyDataRequestDto input);
        Task<AccountJournal> CreateBankStatementAsync(Guid[] ids);
        Task<AccountJournal> CreateCustomerPaymentAsync(Guid[] ids);
        Task<AccountJournal> CreateDocumentFromAttachmentAsync(AccountJournalCreateDocumentFromAttachmentRequestDto input);
        Task<AccountJournal> CreateNewAsync(Guid[] ids);
        Task<AccountJournal> CreateSupplierPaymentAsync(Guid[] ids);
        Task<AccountJournal> CreateVendorBillAsync(Guid[] ids);
        Task<AccountJournal> OpenActionAsync(Guid[] ids);
        Task<AccountJournal> OpenBankDifferenceActionAsync(Guid[] ids);
        Task<AccountJournal> OpenInvalidStatementsActionAsync(Guid[] ids);
        Task<AccountJournal> OpenPaymentsActionAsync(AccountJournalOpenPaymentsActionRequestDto input);
        Task<AccountJournal> OpenWithContextAsync(Guid[] ids);
        Task<AccountJournal> PostAllEntriesAsync(Guid[] ids);
        Task<AccountJournal> SetBankAccountAsync(AccountJournalSetBankAccountRequestDto input);
        Task<AccountJournal> ShowSequenceHolesAsync(Guid[] ids);
        Task<AccountJournal> ShowUnhashedEntriesAsync(Guid[] ids);
        Task<AccountJournal> ToCheckIdsAsync(Guid[] ids);
    }
}