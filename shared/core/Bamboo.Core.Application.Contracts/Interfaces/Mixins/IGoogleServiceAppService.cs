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
    public interface IGoogleServiceAppService : IMixinAppService
    {
        Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IGoogleServiceable;
        Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object scope, object redirect_uri, object state, object approval_prompt, object access_type) where TEntity : IEntity<Guid>, IGoogleServiceable;
        Task<TEntity> GetClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IGoogleServiceable;
        Task<TEntity> GetGoogleTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IGoogleServiceable;
        Task<TEntity> RefreshGoogleTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IGoogleServiceable;
    }
}