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
    public interface IAccountEdiXmlUblNlAppService : IMixinAppService
    {
        Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
        Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable;
    }
}