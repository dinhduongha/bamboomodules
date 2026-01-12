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
    public interface ITransifexCodeTranslationAppService : IMixinAppService
    {
        Task<TEntity> ComputeTransifexUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable;
        Task<TEntity> GetLanguagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable;
        Task<TEntity> LoadCodeTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module_names, object langs) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable;
        Task<TEntity> OpenCodeTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable;
        Task<TEntity> ReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable;
    }
}