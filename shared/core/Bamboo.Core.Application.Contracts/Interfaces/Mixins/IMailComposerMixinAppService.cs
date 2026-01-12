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
    public interface IMailComposerMixinAppService : IMixinAppService
    {
        Task<TEntity> ComputeBodyHasTemplateValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> ComputeBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> ComputeCanEditBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> ComputeIsMailTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> ComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> RenderFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMailComposerMixinable;
        Task<TEntity> RenderLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable;
    }
}