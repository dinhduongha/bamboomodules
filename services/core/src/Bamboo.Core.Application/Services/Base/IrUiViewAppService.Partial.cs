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
    public partial class IrUiViewAppService
    {

        protected async Task<IrUiView> AddMissingFieldsInternalAsync(object node, object name_manager)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _add_missing_fields) ---
            */
            return default;
        }

        protected async Task<IrUiView> AddValidationFlagInternalAsync(object combined_arch, object view, object arch)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _add_validation_flag) ---
            #endif
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> AreArchsEqualInternalAsync(object arch1, object arch2)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _are_archs_equal) ---
            */
            return default;
        }

        protected async Task<IrUiView> BuildHierarchyDatastructureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _build_hierarchy_datastructure) ---
            */
            return default;
        }

        protected async Task<IrUiView> Check000InheritanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_000_inheritance) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckDropdownMenuInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_dropdown_menu) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckFieldPathsInternalAsync(object node, object field_paths, object model_name, object use)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_field_paths) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_groups) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckProgressBarInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_progress_bar) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckViewAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_view_access) ---
            */
            return default;
        }

        protected async Task<IrUiView> CheckXmlInternalAsync()
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_xml) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> ClearPreloadViewsCacheIfNeededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _clear_preload_views_cache_if_needed) ---
            */
            return default;
        }

        protected async Task<IrUiView> CombineInternalAsync(Dictionary<string, object> hierarchy)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _combine) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeArchBaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_arch_base) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeArchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_arch) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeDefaultsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_defaults) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeFirstPageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _compute_first_page_id) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeInvalidLocatorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_invalid_locators) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeModelDataIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_model_data_id) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeModelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_model_id) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeWarningInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_warning_info) ---
            */
            return default;
        }

        protected async Task<IrUiView> ComputeXmlIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_xml_id) ---
            */
            return default;
        }

        protected async Task<IrUiView> ContainsBrandedInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _contains_branded) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> CopyCustomSnippetTranslationsInternalAsync(object record, object html_field)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _copy_custom_snippet_translations) ---
            #endif
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> CopyFieldTermsTranslationsInternalAsync(object records_from, object name_field_from, object record_to, object name_field_to)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _copy_field_terms_translations) ---
            */
            return default;
        }

        protected async Task<IrUiView> CreateAllSpecificViewsInternalAsync(object processed_modules)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _create_all_specific_views) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _create_all_specific_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> CreateWebsiteSpecificPagesForViewInternalAsync(object new_view, object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _create_website_specific_pages_for_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> EditableNodeInternalAsync(object node, object name_manager)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_node) ---
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagFieldInternalAsync(object node, object name_manager)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_field) ---
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagFormInternalAsync(object node, object name_manager)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_form) ---
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagListInternalAsync(object node, object name_manager)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_list) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> FetchTemplateViewsInternalAsync(object ids_or_xmlids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _fetch_template_views) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _fetch_template_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> FilterLoadedViewsInternalAsync(List<Guid> check_view_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _filter_loaded_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> FindAvailableNameInternalAsync(object name, object used_names)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _find_available_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetAllowedRootAttrsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _get_allowed_root_attrs) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_allowed_root_attrs) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetBaseLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_base_lang) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetCachedTemplateInfoInternalAsync(object id_or_xmlid, object _view)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_cached_template_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetCachedTemplatePrefetchedKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_cached_template_prefetched_keys) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_cached_template_prefetched_keys) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetCachedVisibilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_cached_visibility) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetCleanedNonEditingAttributesInternalAsync(object attributes)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _get_cleaned_non_editing_attributes) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetCombinedArchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_combined_arch) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetCombinedArchsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_combined_archs) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetDefaultViewDomainInternalAsync(object model, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_view_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetFilterXmlidQueryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_filter_xmlid_query) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_filter_xmlid_query) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetInheritingViewsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_inheriting_views_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_inheriting_views_domain) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetInheritingViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_inheriting_views) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_inheriting_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetPwdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_pwd) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetSnippetAdditionViewKeyInternalAsync(object template_key, object key)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _get_snippet_addition_view_key) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetSpecificViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_specific_views) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<object> GetTemplateDomainInternalAsync(List<string> xmlids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_template_domain) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetTemplateMinimalCacheKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_minimal_cache_keys) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_template_minimal_cache_keys) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<string> GetTemplateOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_order) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_template_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> GetTemplateViewInternalAsync(object id_or_xmlid, object raise_if_not_found)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_template_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetViewEtreesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_etrees) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetViewInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetViewRefsInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_refs) ---
            */
            return default;
        }

        protected async Task<IrUiView> GetX2manyMissingViewArchsInternalAsync(object field, object field_node, object node_info)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_x2many_missing_view_archs) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> HandleVisibilityInternalAsync(object do_raise)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _handle_visibility) ---
            */
            return default;
        }

        protected async Task<IrUiView> InverseArchBaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_arch_base) ---
            */
            return default;
        }

        protected async Task<IrUiView> InverseArchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_arch) ---
            */
            return default;
        }

        protected async Task<IrUiView> InverseComputeModelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_compute_model_id) ---
            */
            return default;
        }

        protected async Task<IrUiView> IsQwebBasedViewInternalAsync(object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        protected async Task<IrUiView> LoadRecordsWriteOnCowInternalAsync(object cow_view, Guid inherit_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _load_records_write_on_cow) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _load_records_write_on_cow) ---
            */
            return default;
        }

        protected async Task<IrUiView> LogViewWarningInternalAsync(object message, object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _log_view_warning) ---
            */
            return default;
        }

        protected async Task<IrUiView> ModifiersFromModelInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _modifiers_from_model) ---
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewFormInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_form) ---
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewKanbanInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_kanban) ---
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewListInternalAsync(object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_list) ---
            */
            return default;
        }

        protected async Task<IrUiView> PopViewBrandingInternalAsync(object element)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _pop_view_branding) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessAccessRightsInternalAsync(object tree)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_access_rights) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> PostprocessAttributesInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_attributes) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessDebugInternalAsync(object tree)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_debug) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> PostprocessDebugToCacheInternalAsync(object tree)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_debug_to_cache) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> PostprocessOnChangeInternalAsync(object arch, object model)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_on_change) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagCalendarInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_calendar) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagFieldInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_field) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagFormInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_form) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagGroupbyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_groupby) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagLabelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_label) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagListInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_list) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagSearchInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_search) ---
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessViewInternalAsync(object node, object model_name, object editable, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> PreloadViewsInternalAsync(object refs)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _preload_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> RaiseViewErrorInternalAsync(object message, object node)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _raise_view_error) ---
            */
            return default;
        }

        protected async Task<IrUiView> ReadTemplateKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _read_template_keys) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _read_template_keys) ---
            */
            return default;
        }

        protected async Task<IrUiView> RenderTemplateInternalAsync(object template, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _render_template) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _render_template) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> SaveOeStructureHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _save_oe_structure_hook) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _save_oe_structure_hook) ---
            */
            return default;
        }

        protected async Task<IrUiView> SearchModelDataIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _search_model_data_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> SetNoupdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _set_noupdate) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _set_noupdate) ---
            */
            return default;
        }

        protected async Task<IrUiView> SetPwdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _set_pwd) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> SnippetSaveViewValuesHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _snippet_save_view_values_hook) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _snippet_save_view_values_hook) ---
            */
            return default;
        }

        protected async Task<IrUiView> UpdateFieldTranslationsInternalAsync(object field_name, object translations, object digest, object source_lang)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _update_field_translations) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _update_field_translations) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidInheritanceInternalAsync(object arch)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _valid_inheritance) ---
            #endif
            return default;
        }

        protected async Task<IrUiView> ValidateAttributesInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_attributes) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateClassesInternalAsync(object node, object expr)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_classes) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> ValidateCustomViewsInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_ui_view.py, METHOD: _validate_custom_views) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_custom_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateDomainIdentifiersInternalAsync(object node, object name_manager, object domain, object use, object target_model, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_domain_identifiers) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateExpressionInternalAsync(object node, object name_manager, object py_expression, object use, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_expression) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateFaClassAccessibilityInternalAsync(object node, object description)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_fa_class_accessibility) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> ValidateModuleViewsInternalAsync(object module)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_module_views) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateQwebDirectiveInternalAsync(object node, object directive, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_qweb_directive) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagAInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_a) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagButtonInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_button) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagCalendarInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_calendar) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagDivInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_div) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFieldInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_field) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFilterInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_filter) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFormInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_form) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagGraphInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_graph) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagGroupbyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_groupby) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagHierarchyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _validate_tag_hierarchy) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagImgInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_img) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagLabelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_label) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagListInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_list) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagPageInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_page) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagSearchInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_search) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagSearchpanelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_searchpanel) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagUlInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_ul) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateViewInternalAsync(object node, object model_name, object view_type, object editable, object node_info)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_view) ---
            */
            return default;
        }

        protected async Task<IrUiView> ValidateXmlEncodingInternalAsync(object text)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_xml_encoding) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> ViewGetInheritedChildrenInternalAsync(object view)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _view_get_inherited_children) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _view_get_inherited_children) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiView> ViewsGetInternalAsync(Guid view_id, object get_children, object bundles, object root, object visited)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _views_get) ---
            */
            return default;
        }
    }
}