using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class IrAssetAppService
    {

        protected async Task<IrAsset> FillAssetPathsInternalAsync(object bundle, object asset_paths, object seen, object addons, object installed)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _fill_asset_paths) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetActiveAddonsListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: _get_active_addons_list) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_active_addons_list) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetBundleUrlInternalAsync(object filename, object unique, object assets_params, object ignore_params)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: _get_asset_bundle_url) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_asset_bundle_url) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: _get_asset_params) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_asset_params) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetPathsInternalAsync(object bundle, object assets_params)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_asset_paths) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAsset> GetInstalledAddonsListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_installed_addons_list) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetPathsInternalAsync(object path_def, object installed)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_paths) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetRelatedAssetsInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: _get_related_assets) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_related_assets) ---
            */
            return default;
        }

        protected async Task<IrAsset> GetRelatedBundleInternalAsync(object target_path_def, object root_bundle)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _get_related_bundle) ---
            */
            return default;
        }

        protected async Task<IrAsset> ParseBundleNameInternalAsync(object bundle_name, object debug_assets)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _parse_bundle_name) ---
            */
            return default;
        }

        protected async Task<IrAsset> ProcessCommandInternalAsync(object command)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _process_command) ---
            */
            return default;
        }

        protected async Task<IrAsset> ProcessPathInternalAsync(object bundle, object directive, object target, object path_def, object asset_paths, object seen, object addons, object installed, object bundle_start_index)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _process_path) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAsset> TopologicalSortInternalAsync(object addons_tuple)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: _topological_sort) ---
            */
            return default;
        }
    }
}