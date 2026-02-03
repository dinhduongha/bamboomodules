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
    public interface IDeliveryCarrierAppService : IGenericAppService<DeliveryCarrier>
    {
        Task<DeliveryCarrier> AvailableCarriersAsync(DeliveryCarrierAvailableCarriersRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleCancelShipmentAsync(DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleGetTrackingLinkAsync(DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleRateShipmentAsync(DeliveryCarrierBaseOnRuleRateShipmentRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleSendShippingAsync(DeliveryCarrierBaseOnRuleSendShippingRequestDto input);
        Task<DeliveryCarrier> CancelShipmentAsync(DeliveryCarrierCancelShipmentRequestDto input);
        Task<DeliveryCarrier> CopyDataAsync(DeliveryCarrierCopyDataRequestDto input);
        Task<DeliveryCarrier> FixedCancelShipmentAsync(DeliveryCarrierFixedCancelShipmentRequestDto input);
        Task<DeliveryCarrier> FixedGetTrackingLinkAsync(DeliveryCarrierFixedGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> FixedRateShipmentAsync(DeliveryCarrierFixedRateShipmentRequestDto input);
        Task<DeliveryCarrier> FixedSendShippingAsync(DeliveryCarrierFixedSendShippingRequestDto input);
        Task<DeliveryCarrier> GelatoRateShipmentAsync(DeliveryCarrierGelatoRateShipmentRequestDto input);
        Task<DeliveryCarrier> GetReturnLabelAsync(DeliveryCarrierGetReturnLabelRequestDto input);
        Task<DeliveryCarrier> GetReturnLabelPrefixAsync(Guid[] ids);
        Task<DeliveryCarrier> GetTrackingLinkAsync(DeliveryCarrierGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> InStoreRateShipmentAsync(Guid[] ids);
        Task<DeliveryCarrier> InstallMoreProviderAsync(Guid[] ids);
        Task<DeliveryCarrier> LogXmlAsync(DeliveryCarrierLogXmlRequestDto input);
        Task<DeliveryCarrier> RateShipmentAsync(DeliveryCarrierRateShipmentRequestDto input);
        Task<DeliveryCarrier> SendShippingAsync(DeliveryCarrierSendShippingRequestDto input);
        Task<DeliveryCarrier> ToggleDebugAsync(Guid[] ids);
        Task<DeliveryCarrier> ToggleProdEnvironmentAsync(Guid[] ids);
    }
}