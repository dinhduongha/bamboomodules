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
    public interface IThemeUtilsAppService : IMixinAppService
    {
        Task<TEntity> DisableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> DisableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> EnableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> EnableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> FooterTemplatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> PostCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mod) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> ResetDefaultConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> ToggleAssetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object active) where TEntity : IEntity<Guid>, IThemeUtilsable;
        Task<TEntity> ToggleViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id, object active) where TEntity : IEntity<Guid>, IThemeUtilsable;
    }
}