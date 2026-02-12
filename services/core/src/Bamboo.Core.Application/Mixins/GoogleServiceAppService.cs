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
    [Module("google_account", Category = "Misc", Depends = new[] { "base_setup" })]
    public partial class GoogleServiceAppService : ApplicationService, IGoogleServiceAppService
    {

        public GoogleServiceAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: google_account, FILE: google_service.py, METHOD: _do_request) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object scope, object redirect_uri, object state, object approval_prompt, object access_type) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: google_account, FILE: google_service.py, METHOD: _get_authorize_uri) ---
            */
            return default;
        }

        public async Task<TEntity> GetClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: google_account, FILE: google_service.py, METHOD: _get_client_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetGoogleTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: google_account, FILE: google_service.py, METHOD: _get_google_tokens) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshGoogleTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- METHOD SOURCE (MODULE: google_account, FILE: google_service.py, METHOD: _refresh_google_token) ---
            */
            return default;
        }
    }
}