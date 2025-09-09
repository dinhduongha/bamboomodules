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
    public interface IIrQwebFieldFloatTimeAppService : IMixinAppService
    {
        Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldFloatTimeable;
    }
}