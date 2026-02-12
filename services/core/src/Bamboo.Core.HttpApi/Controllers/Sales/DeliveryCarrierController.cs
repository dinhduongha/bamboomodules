using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/sales/DeliveryCarrier")]
    public partial class DeliveryCarrierController : AbpController
    {
        protected readonly IDeliveryCarrierAppService _appService;
        public DeliveryCarrierController(IDeliveryCarrierAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("available-carriers")]
        public async Task<IActionResult> AvailableCarriersAsync([FromBody] DeliveryCarrierAvailableCarriersRequestDto input)
        {
            var result = await _appService.AvailableCarriersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-cancel-shipment")]
        public async Task<IActionResult> BaseOnRuleCancelShipmentAsync([FromBody] DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input)
        {
            var result = await _appService.BaseOnRuleCancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-get-tracking-link")]
        public async Task<IActionResult> BaseOnRuleGetTrackingLinkAsync([FromBody] DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input)
        {
            var result = await _appService.BaseOnRuleGetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-rate-shipment")]
        public async Task<IActionResult> BaseOnRuleRateShipmentAsync([FromBody] DeliveryCarrierBaseOnRuleRateShipmentRequestDto input)
        {
            var result = await _appService.BaseOnRuleRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("base-on-rule-send-shipping")]
        public async Task<IActionResult> BaseOnRuleSendShippingAsync([FromBody] DeliveryCarrierBaseOnRuleSendShippingRequestDto input)
        {
            var result = await _appService.BaseOnRuleSendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel-shipment")]
        public async Task<IActionResult> CancelShipmentAsync([FromBody] DeliveryCarrierCancelShipmentRequestDto input)
        {
            var result = await _appService.CancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] DeliveryCarrierCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-cancel-shipment")]
        public async Task<IActionResult> FixedCancelShipmentAsync([FromBody] DeliveryCarrierFixedCancelShipmentRequestDto input)
        {
            var result = await _appService.FixedCancelShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-get-tracking-link")]
        public async Task<IActionResult> FixedGetTrackingLinkAsync([FromBody] DeliveryCarrierFixedGetTrackingLinkRequestDto input)
        {
            var result = await _appService.FixedGetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-rate-shipment")]
        public async Task<IActionResult> FixedRateShipmentAsync([FromBody] DeliveryCarrierFixedRateShipmentRequestDto input)
        {
            var result = await _appService.FixedRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fixed-send-shipping")]
        public async Task<IActionResult> FixedSendShippingAsync([FromBody] DeliveryCarrierFixedSendShippingRequestDto input)
        {
            var result = await _appService.FixedSendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("gelato-rate-shipment")]
        public async Task<IActionResult> GelatoRateShipmentAsync([FromBody] DeliveryCarrierGelatoRateShipmentRequestDto input)
        {
            var result = await _appService.GelatoRateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-return-label")]
        public async Task<IActionResult> GetReturnLabelAsync([FromBody] DeliveryCarrierGetReturnLabelRequestDto input)
        {
            var result = await _appService.GetReturnLabelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-return-label-prefix")]
        public async Task<IActionResult> GetReturnLabelPrefixAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetReturnLabelPrefixAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tracking-link")]
        public async Task<IActionResult> GetTrackingLinkAsync([FromBody] DeliveryCarrierGetTrackingLinkRequestDto input)
        {
            var result = await _appService.GetTrackingLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("in-store-rate-shipment")]
        public async Task<IActionResult> InStoreRateShipmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InStoreRateShipmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-more-provider")]
        public async Task<IActionResult> InstallMoreProviderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InstallMoreProviderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-xml")]
        public async Task<IActionResult> LogXmlAsync([FromBody] DeliveryCarrierLogXmlRequestDto input)
        {
            var result = await _appService.LogXmlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rate-shipment")]
        public async Task<IActionResult> RateShipmentAsync([FromBody] DeliveryCarrierRateShipmentRequestDto input)
        {
            var result = await _appService.RateShipmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-shipping")]
        public async Task<IActionResult> SendShippingAsync([FromBody] DeliveryCarrierSendShippingRequestDto input)
        {
            var result = await _appService.SendShippingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-debug")]
        public async Task<IActionResult> ToggleDebugAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleDebugAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-prod-environment")]
        public async Task<IActionResult> ToggleProdEnvironmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleProdEnvironmentAsync(ids);
            return Ok(result);
        }
    }
    
}