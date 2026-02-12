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
    [Module("Delivery", Category = "Sales", Depends = new[] { "sale", "payment_custom" })]
    public partial class DeliveryCarrierAppService : GenericAppService<DeliveryCarrier>, IDeliveryCarrierAppService
    {
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        public DeliveryCarrierAppService(IRepository<DeliveryCarrier, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
        }

        public async Task<DeliveryCarrier> AvailableCarriersAsync(DeliveryCarrierAvailableCarriersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: available_carriers) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: available_carriers) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> BaseOnRuleCancelShipmentAsync(DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_cancel_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> BaseOnRuleGetTrackingLinkAsync(DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: base_on_rule_get_tracking_link) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_get_tracking_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> BaseOnRuleRateShipmentAsync(DeliveryCarrierBaseOnRuleRateShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_rate_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> BaseOnRuleSendShippingAsync(DeliveryCarrierBaseOnRuleSendShippingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_send_shipping) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> CancelShipmentAsync(DeliveryCarrierCancelShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: cancel_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> CopyDataAsync(DeliveryCarrierCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<DeliveryCarrier> CreateAsync(CreateRequestDto<DeliveryCarrier> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<DeliveryCarrier> FixedCancelShipmentAsync(DeliveryCarrierFixedCancelShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_cancel_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> FixedGetTrackingLinkAsync(DeliveryCarrierFixedGetTrackingLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: fixed_get_tracking_link) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_get_tracking_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> FixedRateShipmentAsync(DeliveryCarrierFixedRateShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: fixed_rate_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> FixedSendShippingAsync(DeliveryCarrierFixedSendShippingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_send_shipping) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> GelatoRateShipmentAsync(DeliveryCarrierGelatoRateShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: gelato_rate_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> GetReturnLabelAsync(DeliveryCarrierGetReturnLabelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_return_label) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> GetReturnLabelPrefixAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_return_label_prefix) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> GetTrackingLinkAsync(DeliveryCarrierGetTrackingLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_tracking_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> InStoreRateShipmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: in_store_rate_shipment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> InstallMoreProviderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: install_more_provider) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> LogXmlAsync(DeliveryCarrierLogXmlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: log_xml) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> RateShipmentAsync(DeliveryCarrierRateShipmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: rate_shipment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> SendShippingAsync(DeliveryCarrierSendShippingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: send_shipping) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> ToggleDebugAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: toggle_debug) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DeliveryCarrier> ToggleProdEnvironmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: toggle_prod_environment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<DeliveryCarrier> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}