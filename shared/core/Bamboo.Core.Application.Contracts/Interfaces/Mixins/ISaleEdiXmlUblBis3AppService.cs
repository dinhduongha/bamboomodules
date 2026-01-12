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
        Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
        Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able;
    }
}