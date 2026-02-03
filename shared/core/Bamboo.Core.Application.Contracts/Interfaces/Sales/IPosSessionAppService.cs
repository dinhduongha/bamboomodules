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
    public interface IPosSessionAppService : IGenericAppService<PosSession>
    {
        Task<PosSession> CloseSessionFromUiAsync(PosSessionCloseSessionFromUiRequestDto input);
        Task<PosSession> DeleteCashInOutAsync(PosSessionDeleteCashInOutRequestDto input);
        Task<PosSession> DeleteOpeningControlSessionAsync(Guid[] ids);
        Task<PosSession> FilterLocalDataAsync(PosSessionFilterLocalDataRequestDto input);
        Task<PosSession> FindProductByBarcodeAsync(PosSessionFindProductByBarcodeRequestDto input);
        Task<PosSession> GetCashInOutListAsync(Guid[] ids);
        Task<PosSession> GetClosingControlDataAsync(Guid[] ids);
        Task<PosSession> GetPosUiProductPricelistItemByProductAsync(PosSessionGetPosUiProductPricelistItemByProductRequestDto input);
        Task<PosSession> GetSessionOrdersAsync(Guid[] ids);
        Task<PosSession> GetTotalDiscountAsync(Guid[] ids);
        Task<PosSession> LoadDataAsync(PosSessionLoadDataRequestDto input);
        Task<PosSession> LoadDataParamsAsync(Guid[] ids);
        Task<PosSession> LogPartnerMessageAsync(PosSessionLogPartnerMessageRequestDto input);
        Task<PosSession> OpenFrontendCbAsync(Guid[] ids);
        Task<PosSession> PosSessionCloseAsync(PosSessionPosSessionCloseRequestDto input);
        Task<PosSession> PosSessionClosingControlAsync(PosSessionPosSessionClosingControlRequestDto input);
        Task<PosSession> PosSessionOpenAsync(Guid[] ids);
        Task<PosSession> PosSessionValidateAsync(PosSessionPosSessionValidateRequestDto input);
        Task<PosSession> PostCloseRegisterMessageAsync(Guid[] ids);
        Task<PosSession> PostClosingCashDetailsAsync(PosSessionPostClosingCashDetailsRequestDto input);
        Task<PosSession> SetOpeningControlAsync(PosSessionSetOpeningControlRequestDto input);
        Task<PosSession> ShowCashRegisterAsync(Guid[] ids);
        Task<PosSession> ShowJournalItemsAsync(Guid[] ids);
        Task<PosSession> ShowPaymentsListAsync(Guid[] ids);
        Task<PosSession> StockPickingAsync(Guid[] ids);
        Task<PosSession> TryCashInOutAsync(PosSessionTryCashInOutRequestDto input);
        Task<PosSession> UpdateClosingControlStateSessionAsync(PosSessionUpdateClosingControlStateSessionRequestDto input);
        Task<PosSession> ViewOrderAsync(Guid[] ids);
    }
}