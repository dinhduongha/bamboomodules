using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("microsoft_account", Category = "Misc", Depends = new[] { "base_setup" })]
    public partial class MicrosoftServiceAppService : ApplicationService, IMicrosoftServiceAppService
    {

        public MicrosoftServiceAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _do_request) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAuthEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_auth_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_url, object service, object scope, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_authorize_uri) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_calendar_scope) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_microsoft_client_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMicrosoftTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_microsoft_tokens) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTokenEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _get_token_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RefreshMicrosoftTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py, METHOD: _refresh_microsoft_token) ---
            */
            return default;
        }
    }
}