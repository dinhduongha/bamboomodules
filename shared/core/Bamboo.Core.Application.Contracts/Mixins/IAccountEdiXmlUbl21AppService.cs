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
    public interface IAccountEdiXmlUbl21AppService : IMixinAppService
    {
        Task<TEntity> AddDocumentAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> CanExportSelfbillingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ImportOrderPaymentTermsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> IsCustomerBehindChorusProInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> SetupBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
    }
}