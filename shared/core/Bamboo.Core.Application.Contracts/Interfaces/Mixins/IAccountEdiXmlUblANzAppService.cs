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
        Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
        Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable;
    }
}