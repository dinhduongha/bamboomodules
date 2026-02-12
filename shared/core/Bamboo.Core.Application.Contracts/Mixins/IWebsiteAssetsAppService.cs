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
    public interface IWebsiteAssetsAppService : IMixinAppService
    {
        Task<TEntity> AddWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> GetContentFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object url_info, object custom_attachments) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> GetCustomAssetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_url) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> GetCustomAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_url, object op) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> GetDataFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> MakeCustomAssetUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle_xmlid) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> MakeScssCustomizationAsync<TEntity>(IEnumerable<TEntity> entities, object url, object values) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> ResetAssetAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
        Task<TEntity> SaveAssetAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle, object content, object file_type) where TEntity : IEntity<Guid>, IWebsiteAssetsable;
    }
}