using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDeliveryCarrierAppService : IGenericApplicationService<DeliveryCarrier>
    {
        Task<DeliveryCarrier> AvailableCarriersAsync(Guid id, DeliveryCarrierAvailableCarriersRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleCancelShipmentAsync(Guid id, DeliveryCarrierBaseOnRuleCancelShipmentRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleGetTrackingLinkAsync(Guid id, DeliveryCarrierBaseOnRuleGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleRateShipmentAsync(Guid id, DeliveryCarrierBaseOnRuleRateShipmentRequestDto input);
        Task<DeliveryCarrier> BaseOnRuleSendShippingAsync(Guid id, DeliveryCarrierBaseOnRuleSendShippingRequestDto input);
        Task<DeliveryCarrier> CancelShipmentAsync(Guid id, DeliveryCarrierCancelShipmentRequestDto input);
        Task<DeliveryCarrier> CopyDataAsync(Guid id, DeliveryCarrierCopyDataRequestDto input);
        Task<DeliveryCarrier> FixedCancelShipmentAsync(Guid id, DeliveryCarrierFixedCancelShipmentRequestDto input);
        Task<DeliveryCarrier> FixedGetTrackingLinkAsync(Guid id, DeliveryCarrierFixedGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> FixedRateShipmentAsync(Guid id, DeliveryCarrierFixedRateShipmentRequestDto input);
        Task<DeliveryCarrier> FixedSendShippingAsync(Guid id, DeliveryCarrierFixedSendShippingRequestDto input);
        Task<DeliveryCarrier> GelatoRateShipmentAsync(Guid id, DeliveryCarrierGelatoRateShipmentRequestDto input);
        Task<DeliveryCarrier> GetReturnLabelAsync(Guid id, DeliveryCarrierGetReturnLabelRequestDto input);
        Task<DeliveryCarrier> GetReturnLabelPrefixAsync(Guid id);
        Task<DeliveryCarrier> GetTrackingLinkAsync(Guid id, DeliveryCarrierGetTrackingLinkRequestDto input);
        Task<DeliveryCarrier> InStoreRateShipmentAsync(Guid id);
        Task<DeliveryCarrier> InstallMoreProviderAsync(Guid id);
        Task<DeliveryCarrier> LogXmlAsync(Guid id, DeliveryCarrierLogXmlRequestDto input);
        Task<DeliveryCarrier> RateShipmentAsync(Guid id, DeliveryCarrierRateShipmentRequestDto input);
        Task<DeliveryCarrier> SendShippingAsync(Guid id, DeliveryCarrierSendShippingRequestDto input);
        Task<DeliveryCarrier> ToggleDebugAsync(Guid id);
        Task<DeliveryCarrier> ToggleProdEnvironmentAsync(Guid id);
    }
}