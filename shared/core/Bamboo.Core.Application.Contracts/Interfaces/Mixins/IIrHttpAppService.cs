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
    public interface IIrHttpAppService : IMixinAppService
    {
        Task<TEntity> AddPublicKeyToSessionInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session_info) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GcSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GenerateRoutingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object converters) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetCurrenciesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetFrontendSessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetNearestLangAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetRewritesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetTimesheetUomsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<List<string>> GetTranslationFrontendModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> GetTranslationsForWebclientAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<object> GetUtmDomainCookiesAsync();
        Task<TEntity> GetWebTranslationsHashAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<object> IsABotAsync();
        Task<int> RewriteLenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> RoutingMapAsync<TEntity>(IEnumerable<TEntity> entities, object key) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> SessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> UrlRewriteAsync<TEntity>(IEnumerable<TEntity> entities, object path, object query_args) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> VerifyRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> VerifyRequestRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> VerifyTurnstileTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable;
        Task<TEntity> WebclientRenderingContextAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable;
    }
}