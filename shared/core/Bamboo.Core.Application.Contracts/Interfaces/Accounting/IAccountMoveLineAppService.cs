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
    public interface IAccountMoveLineAppService : IGenericApplicationService<AccountMoveLine>
    {
        Task<AccountMoveLine> AddFromCatalogAsync(Guid id);
        Task<AccountMoveLine> AssetCreateAsync(Guid id);
        Task<AccountMoveLine> AutomaticEntryAsync(Guid id, AccountMoveLineAutomaticEntryRequestDto input);
        Task<AccountMoveLine> CopyDataAsync(Guid id, AccountMoveLineCopyDataRequestDto input);
        Task<AccountMoveLine> FlushModelAsync(Guid id, AccountMoveLineFlushModelRequestDto input);
        Task<AccountMoveLine> FlushRecordsetAsync(Guid id, AccountMoveLineFlushRecordsetRequestDto input);
        Task<AccountMoveLine> GetImportTemplatesAsync(Guid id);
        Task<AccountMoveLine> GetInvoiceLineAccountAsync(Guid id, AccountMoveLineGetInvoiceLineAccountRequestDto input);
        Task<AccountMoveLine> GetViewsAsync(Guid id, AccountMoveLineGetViewsRequestDto input);
        Task<AccountMoveLine> InitAsync(Guid id);
        Task<AccountMoveLine> InvalidateModelAsync(Guid id, AccountMoveLineInvalidateModelRequestDto input);
        Task<AccountMoveLine> InvalidateRecordsetAsync(Guid id, AccountMoveLineInvalidateRecordsetRequestDto input);
        Task<AccountMoveLine> OnchangeAssetCategoryIdAsync(Guid id);
        Task<AccountMoveLine> OpenBusinessDocAsync(Guid id);
        Task<AccountMoveLine> OpenReconcileViewAsync(Guid id);
        Task<AccountMoveLine> PaymentItemsRegisterPaymentAsync(Guid id);
        Task<AccountMoveLine> ReconcileAsync(Guid id);
        Task<AccountMoveLine> RegisterPaymentAsync(Guid id, AccountMoveLineRegisterPaymentRequestDto input);
        Task<AccountMoveLine> RemoveMoveReconcileAsync(Guid id);
        Task<AccountMoveLine> SearchFetchAsync(Guid id, AccountMoveLineSearchFetchRequestDto input);
        Task<AccountMoveLine> UnreconcileMatchEntriesAsync(Guid id);
    }
}