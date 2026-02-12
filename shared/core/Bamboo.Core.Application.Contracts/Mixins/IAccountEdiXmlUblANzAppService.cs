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
    public interface IAccountEdiXmlUblANzAppService : IMixinAppService
    {
        Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
    }
}