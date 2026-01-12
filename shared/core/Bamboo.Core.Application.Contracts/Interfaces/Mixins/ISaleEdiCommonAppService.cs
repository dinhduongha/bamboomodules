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
    public interface ISaleEdiCommonAppService : IMixinAppService
    {
        Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> GetPartnerDetailStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportDeliveryPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object name, object phone, object email) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xpath) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportPaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xapth) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
        Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable;
    }
}