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
    public interface IAccountJournalAppService : IGenericApplicationService<AccountJournal>
    {
        Task<AccountJournal> ArchiveAsync(Guid id);
        Task<AccountJournal> ChecksToPrintAsync(Guid id);
        Task<AccountJournal> ConfigureBankJournalAsync(Guid id);
        Task<AccountJournal> CopyDataAsync(Guid id, AccountJournalCopyDataRequestDto input);
        Task<AccountJournal> CreateBankStatementAsync(Guid id);
        Task<AccountJournal> CreateCustomerPaymentAsync(Guid id);
        Task<AccountJournal> CreateDocumentFromAttachmentAsync(Guid id, AccountJournalCreateDocumentFromAttachmentRequestDto input);
        Task<AccountJournal> CreateNewAsync(Guid id);
        Task<AccountJournal> CreateSupplierPaymentAsync(Guid id);
        Task<AccountJournal> CreateVendorBillAsync(Guid id);
        Task<AccountJournal> GetNextBankCashDefaultCodeAsync(Guid id, AccountJournalGetNextBankCashDefaultCodeRequestDto input);
        Task<AccountJournal> OpenActionAsync(Guid id);
        Task<AccountJournal> OpenBankDifferenceActionAsync(Guid id);
        Task<AccountJournal> OpenPaymentsActionAsync(Guid id, AccountJournalOpenPaymentsActionRequestDto input);
        Task<AccountJournal> OpenWithContextAsync(Guid id);
        Task<AccountJournal> PeppolGetMessageStatusAsync(Guid id);
        Task<AccountJournal> PeppolGetNewDocumentsAsync(Guid id);
        Task<AccountJournal> PeppolReadyMovesAsync(Guid id);
        Task<AccountJournal> SetBankAccountAsync(Guid id, AccountJournalSetBankAccountRequestDto input);
        Task<AccountJournal> ShowSequenceHolesAsync(Guid id);
        Task<AccountJournal> ShowUnhashedEntriesAsync(Guid id);
        Task<AccountJournal> ToCheckIdsAsync(Guid id);
    }
}