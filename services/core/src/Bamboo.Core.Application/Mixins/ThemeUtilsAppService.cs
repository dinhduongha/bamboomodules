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
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class ThemeUtilsAppService : ApplicationService, IThemeUtilsAppService
    {

        public ThemeUtilsAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> DisableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: disable_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DisableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: disable_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnableAssetAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: enable_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnableViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: enable_view) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: theme_utils.py, METHOD: enable_view) ---
            */
            return default;
        }

        public async Task<TEntity> FooterTemplatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: theme_utils.py, METHOD: _footer_templates) ---
            */
            return default;
        }

        public async Task<TEntity> PostCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mod) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: _post_copy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ResetDefaultConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: _reset_default_config) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToggleAssetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object active) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: _toggle_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToggleViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id, object active) where TEntity : IEntity<Guid>, IThemeUtilsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: _toggle_view) ---
            */
            return default;
        }
    }
}