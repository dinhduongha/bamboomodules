using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DeliveryCarrierController
    {
        
        [HttpPost]
        [Route("available-carriers")]
        public async Task<IActionResult> AvailableCarriersAsync(DeliveryCarrierAvailableCarriersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AvailableCarriersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-cancel-shipment")]
        public async Task<IActionResult> BaseOnRuleCancelShipmentAsync(DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BaseOnRuleCancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-get-tracking-link")]
        public async Task<IActionResult> BaseOnRuleGetTrackingLinkAsync(DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BaseOnRuleGetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-rate-shipment")]
        public async Task<IActionResult> BaseOnRuleRateShipmentAsync(DeliveryCarrierBaseOnRuleRateShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BaseOnRuleRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-send-shipping")]
        public async Task<IActionResult> BaseOnRuleSendShippingAsync(DeliveryCarrierBaseOnRuleSendShippingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BaseOnRuleSendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel-shipment")]
        public async Task<IActionResult> CancelShipmentAsync(DeliveryCarrierCancelShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(DeliveryCarrierCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-cancel-shipment")]
        public async Task<IActionResult> FixedCancelShipmentAsync(DeliveryCarrierFixedCancelShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FixedCancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-get-tracking-link")]
        public async Task<IActionResult> FixedGetTrackingLinkAsync(DeliveryCarrierFixedGetTrackingLinkRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FixedGetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-rate-shipment")]
        public async Task<IActionResult> FixedRateShipmentAsync(DeliveryCarrierFixedRateShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FixedRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-send-shipping")]
        public async Task<IActionResult> FixedSendShippingAsync(DeliveryCarrierFixedSendShippingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FixedSendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("gelato-rate-shipment")]
        public async Task<IActionResult> GelatoRateShipmentAsync(DeliveryCarrierGelatoRateShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GelatoRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-return-label")]
        public async Task<IActionResult> GetReturnLabelAsync(DeliveryCarrierGetReturnLabelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetReturnLabelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-return-label-prefix")]
        public async Task<IActionResult> GetReturnLabelPrefixAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetReturnLabelPrefixAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tracking-link")]
        public async Task<IActionResult> GetTrackingLinkAsync(DeliveryCarrierGetTrackingLinkRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("in-store-rate-shipment")]
        public async Task<IActionResult> InStoreRateShipmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InStoreRateShipmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-more-provider")]
        public async Task<IActionResult> InstallMoreProviderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InstallMoreProviderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-xml")]
        public async Task<IActionResult> LogXmlAsync(DeliveryCarrierLogXmlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LogXmlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rate-shipment")]
        public async Task<IActionResult> RateShipmentAsync(DeliveryCarrierRateShipmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-shipping")]
        public async Task<IActionResult> SendShippingAsync(DeliveryCarrierSendShippingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-debug")]
        public async Task<IActionResult> ToggleDebugAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleDebugAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-prod-environment")]
        public async Task<IActionResult> ToggleProdEnvironmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleProdEnvironmentAsync(ids);
            return Ok(result);
        }
    }
}