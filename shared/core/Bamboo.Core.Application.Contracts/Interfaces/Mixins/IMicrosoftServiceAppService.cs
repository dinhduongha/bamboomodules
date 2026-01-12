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
    public interface IMicrosoftServiceAppService : IMixinAppService
    {
        Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GenerateRefreshTokenAsync<TEntity>(IEnumerable<TEntity> entities, object service, object authorization_code) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetAuthEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_url, object service, object scope, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetCalendarScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetMicrosoftClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetMicrosoftTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> GetTokenEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
        Task<TEntity> RefreshMicrosoftTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IMicrosoftServiceable;
    }
}