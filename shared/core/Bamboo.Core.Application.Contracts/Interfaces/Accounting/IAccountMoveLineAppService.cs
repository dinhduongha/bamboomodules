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
    public interface IAccountMoveLineAppService : IGenericAppService<AccountMoveLine>
    {
        Task<AccountMoveLine> AddFromCatalogAsync(Guid[] ids);
        Task<AccountMoveLine> AssetCreateAsync(Guid[] ids);
        Task<AccountMoveLine> AutomaticEntryAsync(AccountMoveLineAutomaticEntryRequestDto input);
        Task<AccountMoveLine> CopyDataAsync(AccountMoveLineCopyDataRequestDto input);
        Task<AccountMoveLine> FlushModelAsync(AccountMoveLineFlushModelRequestDto input);
        Task<AccountMoveLine> FlushRecordsetAsync(AccountMoveLineFlushRecordsetRequestDto input);
        Task<AccountMoveLine> GetColumnToExcludeForColspanCalculationAsync(AccountMoveLineGetColumnToExcludeForColspanCalculationRequestDto input);
        Task<AccountMoveLine> GetImportTemplatesAsync(Guid[] ids);
        Task<AccountMoveLine> GetInvoiceLineAccountAsync(AccountMoveLineGetInvoiceLineAccountRequestDto input);
        Task<AccountMoveLine> GetParentSectionLineAsync(Guid[] ids);
        Task<AccountMoveLine> GetSectionSubtotalAsync(Guid[] ids);
        Task<AccountMoveLine> GetViewsAsync(AccountMoveLineGetViewsRequestDto input);
        Task<AccountMoveLine> InvalidateModelAsync(AccountMoveLineInvalidateModelRequestDto input);
        Task<AccountMoveLine> InvalidateRecordsetAsync(AccountMoveLineInvalidateRecordsetRequestDto input);
        Task<AccountMoveLine> OnchangeAssetCategoryIdAsync(Guid[] ids);
        Task<AccountMoveLine> OpenBusinessDocAsync(Guid[] ids);
        Task<AccountMoveLine> OpenReconcileViewAsync(Guid[] ids);
        Task<AccountMoveLine> PaymentItemsRegisterPaymentAsync(Guid[] ids);
        Task<AccountMoveLine> ReconcileAsync(Guid[] ids);
        Task<AccountMoveLine> RegisterPaymentAsync(AccountMoveLineRegisterPaymentRequestDto input);
        Task<AccountMoveLine> RemoveMoveReconcileAsync(Guid[] ids);
        Task<AccountMoveLine> SearchFetchAsync(AccountMoveLineSearchFetchRequestDto input);
        Task<AccountMoveLine> UnreconcileMatchEntriesAsync(Guid[] ids);
    }
}