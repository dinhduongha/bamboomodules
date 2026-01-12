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
        Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddDocumentLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceConstraintsNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object convert_fixed_taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetCustomizationIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetDocumentAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetFinancialInstitutionBranchValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> GetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsCenEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
        Task<TEntity> InvoiceConstraintsPeppolEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able;
    }
}