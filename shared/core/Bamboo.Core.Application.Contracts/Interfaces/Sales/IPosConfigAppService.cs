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
    public interface IPosConfigAppService : IGenericAppService<PosConfig>
    {
        Task<PosConfig> CloseKioskSessionAsync(Guid[] ids);
        Task<PosConfig> CloseUiAsync(Guid[] ids);
        Task<PosConfig> ExecuteAsync(Guid[] ids);
        Task<PosConfig> GetKioskUrlAsync(Guid[] ids);
        Task<PosConfig> GetLimitedPartnersLoadingAsync(PosConfigGetLimitedPartnersLoadingRequestDto input);
        Task<PosConfig> GetLimitedProductCountAsync(Guid[] ids);
        Task<PosConfig> GetPosKanbanViewStateAsync(Guid[] ids);
        Task<PosConfig> GetPosQrOrderDataAsync(Guid[] ids);
        Task<PosConfig> GetRecordByRefAsync(PosConfigGetRecordByRefRequestDto input);
        Task<PosConfig> GetStatisticsForSessionAsync(PosConfigGetStatisticsForSessionRequestDto input);
        Task<PosConfig> HasValidSelfPaymentMethodAsync(Guid[] ids);
        Task<PosConfig> InstallPosRestaurantAsync(Guid[] ids);
        Task<PosConfig> LoadDataParamsAsync(Guid[] ids);
        Task<PosConfig> LoadDemoDataAsync(Guid[] ids);
        Task<PosConfig> LoadOnboardingBakeryScenarioAsync(PosConfigLoadOnboardingBakeryScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingBarScenarioAsync(PosConfigLoadOnboardingBarScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingClothesScenarioAsync(PosConfigLoadOnboardingClothesScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingFurnitureScenarioAsync(PosConfigLoadOnboardingFurnitureScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingKioskScenarioAsync(Guid[] ids);
        Task<PosConfig> LoadOnboardingRestaurantScenarioAsync(PosConfigLoadOnboardingRestaurantScenarioRequestDto input);
        Task<PosConfig> LoadOnboardingRetailScenarioAsync(PosConfigLoadOnboardingRetailScenarioRequestDto input);
        Task<PosConfig> LoadSelfDataAsync(Guid[] ids);
        Task<PosConfig> NotifySynchronisationAsync(PosConfigNotifySynchronisationRequestDto input);
        Task<PosConfig> OpenExistingSessionCbAsync(Guid[] ids);
        Task<PosConfig> OpenOpenedRescueSessionFormAsync(Guid[] ids);
        Task<PosConfig> OpenUiAsync(Guid[] ids);
        Task<PosConfig> OpenWizardAsync(Guid[] ids);
        Task<PosConfig> PosConfigModalEditAsync(Guid[] ids);
        Task<PosConfig> PreviewSelfOrderAppAsync(Guid[] ids);
        Task<PosConfig> ReadConfigOpenOrdersAsync(PosConfigReadConfigOpenOrdersRequestDto input);
        Task<PosConfig> RegisterNewDeviceIdentifierAsync(Guid[] ids);
        Task<PosConfig> UpdateCustomerDisplayAsync(PosConfigUpdateCustomerDisplayRequestDto input);
        Task<PosConfig> UseCouponCodeAsync(PosConfigUseCouponCodeRequestDto input);
    }
}