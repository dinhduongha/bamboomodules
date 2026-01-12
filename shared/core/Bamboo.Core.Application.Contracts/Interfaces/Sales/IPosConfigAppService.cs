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
    public interface IPosConfigAppService : IGenericApplicationService<PosConfig>
    {
        Task<PosConfig> CloseKioskSessionAsync(Guid id);
        Task<PosConfig> ExecuteAsync(Guid id);
        Task<PosConfig> GetCategoriesAsync(Guid id, PosConfigGetCategoriesRequestDto input);
        Task<PosConfig> GetKioskUrlAsync(Guid id);
        Task<PosConfig> GetLimitedPartnersLoadingAsync(Guid id);
        Task<PosConfig> GetLimitedProductCountAsync(Guid id);
        Task<PosConfig> GetLimitedProductsLoadingAsync(Guid id, PosConfigGetLimitedProductsLoadingRequestDto input);
        Task<PosConfig> GetPosKanbanViewStateAsync(Guid id);
        Task<PosConfig> GetRecordsAsync(Guid id, PosConfigGetRecordsRequestDto input);
        Task<PosConfig> InstallPosRestaurantAsync(Guid id);
        Task<PosConfig> LoadOnboardingBakeryScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingBarScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingClothesScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingFurnitureScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingKioskScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingRestaurantScenarioAsync(Guid id);
        Task<PosConfig> LoadSelfDataAsync(Guid id);
        Task<PosConfig> NotifySynchronisationAsync(Guid id, PosConfigNotifySynchronisationRequestDto input);
        Task<PosConfig> OpenExistingSessionCbAsync(Guid id);
        Task<PosConfig> OpenOpenedRescueSessionFormAsync(Guid id);
        Task<PosConfig> OpenUiAsync(Guid id);
        Task<PosConfig> OpenWizardAsync(Guid id);
        Task<PosConfig> PosConfigModalEditAsync(Guid id);
        Task<PosConfig> PreviewSelfOrderAppAsync(Guid id);
        Task<PosConfig> ReadConfigOpenOrdersAsync(Guid id, PosConfigReadConfigOpenOrdersRequestDto input);
        Task<PosConfig> UpdateCustomerDisplayAsync(Guid id, PosConfigUpdateCustomerDisplayRequestDto input);
        Task<PosConfig> UseCouponCodeAsync(Guid id, PosConfigUseCouponCodeRequestDto input);
    }
}