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
    public interface IAccountEdiXmlUblSgAppService : IMixinAppService
    {
        Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
        Task<TEntity> GetTaxSgCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable;
    }
}