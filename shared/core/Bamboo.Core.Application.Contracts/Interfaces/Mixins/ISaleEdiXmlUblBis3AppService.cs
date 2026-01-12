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
    public interface ISaleEdiXmlUblBis3AppService : IMixinAppService
    {
        Task<TEntity> AddSaleOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> AddSaleOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ExportOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> GetProductXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> GetSaleOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
    }
}