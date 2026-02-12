using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IPurchaseEdiXmlUblBis3AppService : IMixinAppService
    {
        Task<TEntity> AddPurchaseOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> AddPurchaseOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_order) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> GetPurchaseOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
        Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IPurchaseEdiXmlUblBis3able;
    }
}