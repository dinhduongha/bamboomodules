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
    public interface ITransifexTranslationAppService : IMixinAppService
    {
        Task<TEntity> GetTransifexProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexTranslationable;
        Task<TEntity> UpdateTransifexUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object translations) where TEntity : IEntity<Guid>, ITransifexTranslationable;
    }
}