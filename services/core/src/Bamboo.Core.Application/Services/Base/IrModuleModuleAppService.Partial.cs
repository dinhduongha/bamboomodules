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
    public partial class IrModuleModuleAppService
    {

        protected async Task<IrModuleModule> ButtonImmediateFunctionInternalAsync(object function)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _button_immediate_function) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> CallAppsInternalAsync(object payload)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _call_apps) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> CheckInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _check) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _check) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ComputeAccountTemplatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_module.py, METHOD: _compute_account_templates) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ComputeHasIapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _compute_has_iap) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ComputeIsInstalledOnCurrentWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _compute_is_installed_on_current_website) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> CreateModelDataInternalAsync(object views)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _create_model_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> ExtractResourceAttachmentTranslationsInternalAsync(object module, object lang)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _extract_resource_attachment_translations) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _extract_resource_attachment_translations) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GeneratePrimaryPageTemplatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _generate_primary_page_templates) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GeneratePrimarySnippetTemplatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _generate_primary_snippet_templates) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetDescInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_desc) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetIconImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_icon_image) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_icon_image) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetIdInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> GetImportedModuleNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_imported_module_names) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> GetImportedModuleTranslationsForWebclientInternalAsync(object module, object lang)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_imported_module_translations_for_webclient) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> GetIndustryCategoriesFromAppsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_industry_categories_from_apps) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetLatestVersionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_latest_version) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_latest_version) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> GetMissingDependenciesInternalAsync(object zip_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_missing_dependencies) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetMissingDependenciesModulesInternalAsync(object zip_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_missing_dependencies_modules) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetModuleDataInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _get_module_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> GetModulesFromAppsInternalAsync(object fields, object module_type, object module_name, object domain, object limit, object offset)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_modules_from_apps) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetModulesToLoadDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _get_modules_to_load_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_modules_to_load_domain) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> GetViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _get_views) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ImportModuleInternalAsync(object module, object path, object force, object with_demo)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _import_module) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> ImportZipfileInternalAsync(object module_file, object force, object with_demo)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _import_zipfile) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> InstalledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _installed) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> LoadModuleTermsInternalAsync(object modules, object langs, object overwrite)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_module.py, METHOD: _load_module_terms) ---
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: _load_module_terms) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _load_module_terms) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: ir_module_module.py, METHOD: _load_module_terms) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _load_module_terms) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: ir_module_module.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: ir_module_module.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> PostCopyInternalAsync(object old_rec, object new_rec)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _post_copy) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> RegisterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_module.py, METHOD: _register_hook) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> RemoveCopiedViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _remove_copied_views) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> StateUpdateInternalAsync(object newstate, object states_to_update, object level)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _state_update) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeCleanupInternalAsync(object model_name, object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_cleanup) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetDownstreamInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_get_downstream) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetStreamThemesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_get_stream_themes) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetStreamWebsiteIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_get_stream_website_ids) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetUpstreamInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_get_upstream) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeLoadInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_load) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModuleModule> ThemeRemoveInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_remove) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeUnloadInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_unload) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeUpgradeUpstreamInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _theme_upgrade_upstream) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UnlinkExceptInstalledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _unlink_except_installed) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateCategoryInternalAsync(object category)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_category) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateCountriesInternalAsync(object countries)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_countries) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateDependenciesInternalAsync(object depends, object auto_install_requirements)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_dependencies) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateExclusionsInternalAsync(object excludes)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_exclusions) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateFromTerpInternalAsync(object terp)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_from_terp) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateRecordsInternalAsync(object model_name, object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: _update_records) ---
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateTranslationsInternalAsync(object filter_lang, object overwrite)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _update_translations) ---
            */
            return default;
        }
    }
}