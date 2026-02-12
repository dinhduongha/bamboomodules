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
    public partial class PosSessionAppService : GenericAppService<PosSession>, IPosSessionAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosBusMixinAppService _posBusMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosSessionAppService(IRepository<PosSession, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosBusMixinAppService posBusMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posBusMixinAppService = posBusMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<PosSession> CloseSessionFromUiAsync(PosSessionCloseSessionFromUiRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: close_session_from_ui) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> DeleteCashInOutAsync(PosSessionDeleteCashInOutRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_cash_in_out) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> DeleteOpeningControlSessionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_opening_control_session) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> FilterLocalDataAsync(PosSessionFilterLocalDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: filter_local_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> FindProductByBarcodeAsync(PosSessionFindProductByBarcodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: find_product_by_barcode) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> GetCashInOutListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_cash_in_out_list) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: get_cash_in_out_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> GetClosingControlDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_closing_control_data) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: get_closing_control_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> GetPosUiProductPricelistItemByProductAsync(PosSessionGetPosUiProductPricelistItemByProductRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_pos_ui_product_pricelist_item_by_product) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> GetSessionOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_session_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> GetTotalDiscountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_total_discount) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> LoadDataAsync(PosSessionLoadDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> LoadDataParamsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data_params) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> LogPartnerMessageAsync(PosSessionLogPartnerMessageRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: log_partner_message) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> OpenFrontendCbAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: open_frontend_cb) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PosSessionCloseAsync(PosSessionPosSessionCloseRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_close) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PosSessionClosingControlAsync(PosSessionPosSessionClosingControlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_closing_control) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PosSessionOpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PosSessionValidateAsync(PosSessionPosSessionValidateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_validate) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PostCloseRegisterMessageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_close_register_message) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: post_close_register_message) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> PostClosingCashDetailsAsync(PosSessionPostClosingCashDetailsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_closing_cash_details) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> SetOpeningControlAsync(PosSessionSetOpeningControlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: set_opening_control) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> ShowCashRegisterAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_cash_register) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> ShowJournalItemsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_journal_items) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> ShowPaymentsListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_show_payments_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> StockPickingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_stock_picking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> TryCashInOutAsync(PosSessionTryCashInOutRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: try_cash_in_out) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> UpdateClosingControlStateSessionAsync(PosSessionUpdateClosingControlStateSessionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: update_closing_control_state_session) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosSession> ViewOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_view_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}