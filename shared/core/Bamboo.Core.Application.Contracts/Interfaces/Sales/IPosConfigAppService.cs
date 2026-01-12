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
        Task<PosConfig> CloseUiAsync(Guid id);
        Task<PosConfig> ExecuteAsync(Guid id);
        Task<PosConfig> GetKioskUrlAsync(Guid id);
        Task<PosConfig> GetLimitedPartnersLoadingAsync(Guid id, PosConfigGetLimitedPartnersLoadingRequestDto input);
        Task<PosConfig> GetLimitedProductCountAsync(Guid id);
        Task<PosConfig> GetPosKanbanViewStateAsync(Guid id);
        Task<PosConfig> GetPosQrOrderDataAsync(Guid id);
        Task<PosConfig> GetRecordByRefAsync(Guid id, PosConfigGetRecordByRefRequestDto input);
        Task<PosConfig> GetStatisticsForSessionAsync(Guid id, PosConfigGetStatisticsForSessionRequestDto input);
        Task<PosConfig> HasValidSelfPaymentMethodAsync(Guid id);
        Task<PosConfig> InstallPosRestaurantAsync(Guid id);
        Task<PosConfig> LoadDataParamsAsync(Guid id);
        Task<PosConfig> LoadDemoDataAsync(Guid id);
        Task<PosConfig> LoadOnboardingBakeryScenarioAsync(Guid id, PosConfigLoadOnboardingBakeryScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingBarScenarioAsync(Guid id, PosConfigLoadOnboardingBarScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingClothesScenarioAsync(Guid id, PosConfigLoadOnboardingClothesScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingFurnitureScenarioAsync(Guid id, PosConfigLoadOnboardingFurnitureScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingKioskScenarioAsync(Guid id);
        Task<PosConfig> LoadOnboardingRestaurantScenarioAsync(Guid id, PosConfigLoadOnboardingRestaurantScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingRetailScenarioAsync(Guid id, PosConfigLoadOnboardingRetailScenarioRequestDto input);
        Task<PosConfig> LoadSelfDataAsync(Guid id);
        Task<PosConfig> NotifySynchronisationAsync(Guid id, PosConfigNotifySynchronisationRequestDto input);
        Task<PosConfig> OpenExistingSessionCbAsync(Guid id);
        Task<PosConfig> OpenOpenedRescueSessionFormAsync(Guid id);
        Task<PosConfig> OpenUiAsync(Guid id);
        Task<PosConfig> OpenWizardAsync(Guid id);
        Task<PosConfig> PosConfigModalEditAsync(Guid id);
        Task<PosConfig> PreviewSelfOrderAppAsync(Guid id);
        Task<PosConfig> ReadConfigOpenOrdersAsync(Guid id, PosConfigReadConfigOpenOrdersRequestDto input);
        Task<PosConfig> RegisterNewDeviceIdentifierAsync(Guid id);
        Task<PosConfig> UpdateCustomerDisplayAsync(Guid id, PosConfigUpdateCustomerDisplayRequestDto input);
        Task<PosConfig> UseCouponCodeAsync(Guid id, PosConfigUseCouponCodeRequestDto input);
    }
}