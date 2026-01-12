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
    public interface IIrQwebFieldHtmlAppService : IMixinAppService
    {
        Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable;
        Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable;
        Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable;
    }
}