using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosConfigAppService : GenericAppService<PosConfig>, IPosConfigAppService
    {
        protected readonly IHrMixinAppService _hrMixinAppService;
        protected readonly IPosBusMixinAppService _posBusMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosConfigAppService(IRepository<PosConfig, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IHrMixinAppService hrMixinAppService, IPosBusMixinAppService posBusMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _hrMixinAppService = hrMixinAppService;
            _posBusMixinAppService = posBusMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<PosConfig> CloseKioskSessionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: action_close_kiosk_session) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> CloseUiAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: close_ui) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: close_ui) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PosConfig> CreateAsync(CreateRequestDto<PosConfig> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PosConfig> ExecuteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: execute) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetKioskUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: get_kiosk_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetLimitedPartnersLoadingAsync(PosConfigGetLimitedPartnersLoadingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_partners_loading) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetLimitedProductCountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_product_count) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> GetPosKanbanViewStateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_pos_kanban_view_state) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetPosQrOrderDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: get_pos_qr_order_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetRecordByRefAsync(PosConfigGetRecordByRefRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_record_by_ref) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> GetStatisticsForSessionAsync(PosConfigGetStatisticsForSessionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_statistics_for_session) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> HasValidSelfPaymentMethodAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: has_valid_self_payment_method) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: has_valid_self_payment_method) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> InstallPosRestaurantAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: install_pos_restaurant) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> LoadDataParamsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_data_params) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> LoadDemoDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_demo_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingBakeryScenarioAsync(PosConfigLoadOnboardingBakeryScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_bakery_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingBarScenarioAsync(PosConfigLoadOnboardingBarScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: load_onboarding_bar_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingClothesScenarioAsync(PosConfigLoadOnboardingClothesScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_clothes_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingFurnitureScenarioAsync(PosConfigLoadOnboardingFurnitureScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_furniture_scenario) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: load_onboarding_furniture_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingKioskScenarioAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_onboarding_kiosk_scenario) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingRestaurantScenarioAsync(PosConfigLoadOnboardingRestaurantScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: load_onboarding_restaurant_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosConfig> LoadOnboardingRetailScenarioAsync(PosConfigLoadOnboardingRetailScenarioRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_retail_scenario) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> LoadSelfDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_self_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> NotifySynchronisationAsync(PosConfigNotifySynchronisationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: notify_synchronisation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> OpenExistingSessionCbAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_existing_session_cb) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> OpenOpenedRescueSessionFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_opened_rescue_session_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> OpenUiAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_ui) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: open_ui) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> OpenWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: action_open_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> PosConfigModalEditAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: action_pos_config_modal_edit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> PreviewSelfOrderAppAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: preview_self_order_app) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> ReadConfigOpenOrdersAsync(PosConfigReadConfigOpenOrdersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: read_config_open_orders) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> RegisterNewDeviceIdentifierAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: register_new_device_identifier) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> UpdateCustomerDisplayAsync(PosConfigUpdateCustomerDisplayRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: update_customer_display) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosConfig> UseCouponCodeAsync(PosConfigUseCouponCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: use_coupon_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PosConfig> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}