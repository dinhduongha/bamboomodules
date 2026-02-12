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
    [Module("spreadsheet", Category = "Productivity", Depends = new[] { "bus", "web", "portal" })]
    public partial class SpreadsheetMixinAppService : ApplicationService, ISpreadsheetMixinAppService
    {

        public SpreadsheetMixinAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> ActionGetShareUrlAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: action_get_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: action_toggle_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDashboardAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _check_dashboard_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _check_spreadsheet_data) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _check_token) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _compute_spreadsheet_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSpreadsheetFileNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _compute_spreadsheet_file_name) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> DashboardIsEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _dashboard_is_empty) ---
            */
            return default;
        }

        public async Task<TEntity> EmptySpreadsheetDataBase64InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _empty_spreadsheet_data_base64) ---
            */
            return default;
        }

        public async Task<TEntity> EmptySpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _empty_spreadsheet_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetDashboardTranslationNamespaceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_dashboard_translation_namespace) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDisplayNamesForSpreadsheetAsync<TEntity>(IEnumerable<TEntity> entities, object args) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: get_display_names_for_spreadsheet) ---
            */
            return default;
        }

        public async Task<TEntity> GetFileContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_path) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _get_file_content) ---
            */
            return default;
        }

        public async Task<TEntity> GetSampleDashboardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_sample_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> GetSerializedReadonlyDashboardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_serialized_readonly_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _inverse_spreadsheet_data) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _onchange_data_) ---
            */
            return default;
        }

        public async Task<TEntity> ZipXslxFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files) where TEntity : IEntity<Guid>, ISpreadsheetMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: spreadsheet_mixin.py, METHOD: _zip_xslx_files) ---
            */
            return default;
        }
    }
}