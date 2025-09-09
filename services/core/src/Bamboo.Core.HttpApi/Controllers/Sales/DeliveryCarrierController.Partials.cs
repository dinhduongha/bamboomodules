using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Delivery
{
    public partial class DeliveryCarrierController
    {
        
        [HttpPost]
        [Route("{id}/available-carriers")]
        public async Task<IActionResult> AvailableCarriersAsync(Guid id, [FromBody] DeliveryCarrierAvailableCarriersRequestDto input)
        {
            var result = await _appService.AvailableCarriersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/base-on-rule-cancel-shipment")]
        public async Task<IActionResult> BaseOnRuleCancelShipmentAsync(Guid id, [FromBody] DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input)
        {
            var result = await _appService.BaseOnRuleCancelShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/base-on-rule-get-tracking-link")]
        public async Task<IActionResult> BaseOnRuleGetTrackingLinkAsync(Guid id, [FromBody] DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input)
        {
            var result = await _appService.BaseOnRuleGetTrackingLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/base-on-rule-rate-shipment")]
        public async Task<IActionResult> BaseOnRuleRateShipmentAsync(Guid id, [FromBody] DeliveryCarrierBaseOnRuleRateShipmentRequestDto input)
        {
            var result = await _appService.BaseOnRuleRateShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/base-on-rule-send-shipping")]
        public async Task<IActionResult> BaseOnRuleSendShippingAsync(Guid id, [FromBody] DeliveryCarrierBaseOnRuleSendShippingRequestDto input)
        {
            var result = await _appService.BaseOnRuleSendShippingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel-shipment")]
        public async Task<IActionResult> CancelShipmentAsync(Guid id, [FromBody] DeliveryCarrierCancelShipmentRequestDto input)
        {
            var result = await _appService.CancelShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] DeliveryCarrierCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fixed-cancel-shipment")]
        public async Task<IActionResult> FixedCancelShipmentAsync(Guid id, [FromBody] DeliveryCarrierFixedCancelShipmentRequestDto input)
        {
            var result = await _appService.FixedCancelShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fixed-get-tracking-link")]
        public async Task<IActionResult> FixedGetTrackingLinkAsync(Guid id, [FromBody] DeliveryCarrierFixedGetTrackingLinkRequestDto input)
        {
            var result = await _appService.FixedGetTrackingLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fixed-rate-shipment")]
        public async Task<IActionResult> FixedRateShipmentAsync(Guid id, [FromBody] DeliveryCarrierFixedRateShipmentRequestDto input)
        {
            var result = await _appService.FixedRateShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fixed-send-shipping")]
        public async Task<IActionResult> FixedSendShippingAsync(Guid id, [FromBody] DeliveryCarrierFixedSendShippingRequestDto input)
        {
            var result = await _appService.FixedSendShippingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/gelato-rate-shipment")]
        public async Task<IActionResult> GelatoRateShipmentAsync(Guid id, [FromBody] DeliveryCarrierGelatoRateShipmentRequestDto input)
        {
            var result = await _appService.GelatoRateShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-return-label")]
        public async Task<IActionResult> GetReturnLabelAsync(Guid id, [FromBody] DeliveryCarrierGetReturnLabelRequestDto input)
        {
            var result = await _appService.GetReturnLabelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-return-label-prefix")]
        public async Task<IActionResult> GetReturnLabelPrefixAsync(Guid id)
        {
            var result = await _appService.GetReturnLabelPrefixAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-tracking-link")]
        public async Task<IActionResult> GetTrackingLinkAsync(Guid id, [FromBody] DeliveryCarrierGetTrackingLinkRequestDto input)
        {
            var result = await _appService.GetTrackingLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/in-store-rate-shipment")]
        public async Task<IActionResult> InStoreRateShipmentAsync(Guid id)
        {
            var result = await _appService.InStoreRateShipmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/install-more-provider")]
        public async Task<IActionResult> InstallMoreProviderAsync(Guid id)
        {
            var result = await _appService.InstallMoreProviderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/log-xml")]
        public async Task<IActionResult> LogXmlAsync(Guid id, [FromBody] DeliveryCarrierLogXmlRequestDto input)
        {
            var result = await _appService.LogXmlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/rate-shipment")]
        public async Task<IActionResult> RateShipmentAsync(Guid id, [FromBody] DeliveryCarrierRateShipmentRequestDto input)
        {
            var result = await _appService.RateShipmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-shipping")]
        public async Task<IActionResult> SendShippingAsync(Guid id, [FromBody] DeliveryCarrierSendShippingRequestDto input)
        {
            var result = await _appService.SendShippingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-debug")]
        public async Task<IActionResult> ToggleDebugAsync(Guid id)
        {
            var result = await _appService.ToggleDebugAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-prod-environment")]
        public async Task<IActionResult> ToggleProdEnvironmentAsync(Guid id)
        {
            var result = await _appService.ToggleProdEnvironmentAsync(id);
            return Ok(result);
        }
    }
}