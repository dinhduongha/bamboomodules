using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface ITransifexTranslationAppService : IMixinAppService
    {
        Task<TEntity> GetTransifexProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexTranslationable;
        Task<TEntity> UpdateTransifexUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object translations) where TEntity : IEntity<Guid>, ITransifexTranslationable;
    }
}