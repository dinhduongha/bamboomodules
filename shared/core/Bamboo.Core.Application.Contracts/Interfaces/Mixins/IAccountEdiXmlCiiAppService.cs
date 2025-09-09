using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IAccountEdiXmlCiiAppService : IMixinAppService
    {
        Task<TEntity> CheckNon0RateTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> CheckRequiredTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> FindValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xpath, object tree, object nsmap) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetDocumentAllowanceChargeXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetExchangedDocumentValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetImportDocumentAmountSignInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetInvoiceLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetInvoicingPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetScheduledDeliveryTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> GetTaxNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ImportFillInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
        Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlCiiable;
    }
}