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
    [Module("web_editor", Category = "Website", Depends = new[] { "bus", "web", "html_editor" })]
    public partial class WebEditorAssetsAppService : ApplicationService, IWebEditorAssetsAppService
    {

        public WebEditorAssetsAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> AddWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: _add_website_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetContentFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object url_info, object custom_attachments) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _get_content_from_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCustomAssetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_url) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _get_custom_asset) ---
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: _get_custom_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCustomAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_url, object op) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _get_custom_attachment) ---
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: _get_custom_attachment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDataFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _get_data_from_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MakeCustomAssetUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle_xmlid) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _make_custom_asset_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MakeScssCustomizationAsync<TEntity>(IEnumerable<TEntity> entities, object url, object values) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: make_scss_customization) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ResetAssetAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: reset_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveAssetAsync<TEntity>(IEnumerable<TEntity> entities, object url, object bundle, object content, object file_type) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: save_asset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveAssetAttachmentHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _save_asset_attachment_hook) ---
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: _save_asset_attachment_hook) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveAssetHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebEditorAssetsable
        {
            /*
            --- METHOD SOURCE (MODULE: web_editor, FILE: assets.py, METHOD: _save_asset_hook) ---
            --- METHOD SOURCE (MODULE: website, FILE: assets.py, METHOD: _save_asset_hook) ---
            */
            return default;
        }
    }
}