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
    public interface IWebsitePageOptionsMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> AllowCacheInsertionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> AllowToUseCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> ConvertToBaseModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetPageInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetResponseCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetResponseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> PostProcessResponseFromCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request, object response) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable;
    }
}