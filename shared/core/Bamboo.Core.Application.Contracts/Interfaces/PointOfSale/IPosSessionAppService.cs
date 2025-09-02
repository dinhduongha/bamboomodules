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
    public interface IPosSessionAppService : IGenericApplicationService<PosSession>
    {
        Task<PosSession> CloseSessionFromUiAsync(Guid id, PosSessionCloseSessionFromUiRequestDto input);
        Task<PosSession> DeleteOpeningControlSessionAsync(Guid id);
        Task<PosSession> FindProductByBarcodeAsync(Guid id, PosSessionFindProductByBarcodeRequestDto input);
        Task<PosSession> GetClosingControlDataAsync(Guid id);
        Task<PosSession> GetPosUiProductPricelistItemByProductAsync(Guid id, PosSessionGetPosUiProductPricelistItemByProductRequestDto input);
        Task<PosSession> GetSessionOrdersAsync(Guid id);
        Task<PosSession> GetTotalDiscountAsync(Guid id);
        Task<PosSession> LoadDataAsync(Guid id, PosSessionLoadDataRequestDto input);
        Task<PosSession> LogPartnerMessageAsync(Guid id, PosSessionLogPartnerMessageRequestDto input);
        Task<PosSession> LoginAsync(Guid id);
        Task<PosSession> OpenFrontendCbAsync(Guid id);
        Task<PosSession> PosSessionCloseAsync(Guid id, PosSessionPosSessionCloseRequestDto input);
        Task<PosSession> PosSessionClosingControlAsync(Guid id, PosSessionPosSessionClosingControlRequestDto input);
        Task<PosSession> PosSessionOpenAsync(Guid id);
        Task<PosSession> PosSessionValidateAsync(Guid id, PosSessionPosSessionValidateRequestDto input);
        Task<PosSession> PostCloseRegisterMessageAsync(Guid id);
        Task<PosSession> PostClosingCashDetailsAsync(Guid id, PosSessionPostClosingCashDetailsRequestDto input);
        Task<PosSession> SetOpeningControlAsync(Guid id, PosSessionSetOpeningControlRequestDto input);
        Task<PosSession> ShowCashRegisterAsync(Guid id);
        Task<PosSession> ShowJournalItemsAsync(Guid id);
        Task<PosSession> ShowPaymentsListAsync(Guid id);
        Task<PosSession> StockPickingAsync(Guid id);
        Task<PosSession> TryCashInOutAsync(Guid id, PosSessionTryCashInOutRequestDto input);
        Task<PosSession> UpdateClosingControlStateSessionAsync(Guid id, PosSessionUpdateClosingControlStateSessionRequestDto input);
        Task<PosSession> ViewOrderAsync(Guid id);
    }
}