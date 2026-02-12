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
    [Module("base", Category = "Base")]
    public partial class IrQwebAppService : ApplicationService, IIrQwebAppService
    {

        public IrQwebAppService() 
        {

        }

        public async Task<TEntity> AdaptStyleBackgroundImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object atts, object url_adapter) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _adapt_style_background_image) ---
            */
            return default;
        }

        public async Task<TEntity> AppendTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object text, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _append_text) ---
            */
            return default;
        }

        public async Task<TEntity> CompileBoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attr, object @default) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_bool) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveAsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_as) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveAttInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _compile_directive_att) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_att) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveCallAssetsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_call_assets) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_call) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveConsumedOptionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_consumed_options) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveDebugInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_debug) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveElifInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_elif) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveElseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_else) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveEscInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_esc) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_field) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveForeachInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_foreach) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_groups) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveIfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_if) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInnerContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_inner_content) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _compile_directive_install) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object directive, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _compile_directive) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_lang) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveOptionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_options) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveOutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _compile_directive_out) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_out) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectivePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _compile_directive_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_raw) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_set) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSnippetCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _compile_directive_snippet_call) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSnippetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _compile_directive_snippet) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveTagCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_tag_close) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveTagOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_tag_open) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_value) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveValuefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directive_valuef) ---
            */
            return default;
        }

        public async Task<TEntity> CompileDirectivesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_directives) ---
            */
            return default;
        }

        public async Task<TEntity> CompileExprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr, object raise_on_missing) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _compile_expr) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_expr) ---
            */
            return default;
        }

        public async Task<TEntity> CompileExprTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tokens, object allowed_keys, object argument_names, object raise_on_missing) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_expr_tokens) ---
            */
            return default;
        }

        public async Task<TEntity> CompileFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_format) ---
            */
            return default;
        }

        public async Task<TEntity> CompileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile) ---
            */
            return default;
        }

        public async Task<TEntity> CompileNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _compile_node) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_node) ---
            */
            return default;
        }

        public async Task<TEntity> CompileStaticNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_static_node) ---
            */
            return default;
        }

        public async Task<TEntity> CompileToStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _compile_to_str) ---
            */
            return default;
        }

        public async Task<TEntity> DebugTraceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debugger, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _debug_trace) ---
            */
            return default;
        }

        public async Task<TEntity> DirectivesEvalOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _directives_eval_order) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _directives_eval_order) ---
            */
            return default;
        }

        public async Task<TEntity> FlushTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object compile_context, object level, object rstrip) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _flush_text) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAssetLinksCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object assets_params, object rtl, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _generate_asset_links_cache) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAssetLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug_assets, object assets_params, object rtl, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _generate_asset_links) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, int @ref) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _generate_code_cached) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _generate_code) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeUncachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _generate_code_uncached) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetBundleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle_name, object css, object js, object debug_assets, object rtl, object assets_params, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_asset_bundle) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object assets_params) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_asset_content) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetLinkUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object debug) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_asset_link_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_asset_links) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug, object defer_load, object lazy_load, object media, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_asset_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> GetBundlesToPregenarateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _get_bundles_to_pregenarate) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_bundles_to_pregenarate) ---
            #endif
            return default;
        }

        public async Task<TEntity> GetConvertedImageDataUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base64_source) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_converted_image_data_uri) ---
            */
            return default;
        }

        public async Task<object> GetErrorInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, List<object> stack, object frame) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_error_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object expression, object tagName, object field_options, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_field) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPreloadAttributeXmlidsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _get_preload_attribute_xmlids) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_preload_attribute_xmlids) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateCacheKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: _get_template_cache_keys) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _get_template_cache_keys) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _get_template_cache_keys) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_template_cache_keys) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_template_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _get_template) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object expression, object tagName, object field_options, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _get_widget) ---
            */
            return default;
        }

        public async Task<TEntity> IsExpressionAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expression, object model) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py, METHOD: _is_expression_allowed) ---
            */
            return default;
        }

        public async Task<TEntity> IsStaticNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _is_static_node) ---
            */
            return default;
        }

        public async Task<TEntity> LinkToNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path, object defer_load, object lazy_load, object media) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _link_to_node) ---
            */
            return default;
        }

        public async Task<TEntity> LinksToNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object paths, object defer_load, object lazy_load, object media) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _links_to_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> PostProcessingAttInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tagName, object atts) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _post_processing_att) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _post_processing_att) ---
            */
            return default;
        }

        public async Task<TEntity> PregenerateAssetsBundlesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _pregenerate_assets_bundles) ---
            */
            return default;
        }

        public async Task<TEntity> PreloadTreesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refs) where TEntity : IEntity<Guid>, IIrQwebable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _preload_trees) ---
            #endif
            return default;
        }

        public async Task<TEntity> PrepareEnvironmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_qweb.py, METHOD: _prepare_environment) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _prepare_environment) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareFrontendEnvironmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_qweb.py, METHOD: _prepare_frontend_environment) ---
            --- METHOD SOURCE (MODULE: portal, FILE: ir_qweb.py, METHOD: _prepare_frontend_environment) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb.py, METHOD: _prepare_frontend_environment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<object> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _render) ---
            */
            return default;
        }

        public async Task<TEntity> RenderIterallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_ref, object method, object values, object directive) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _render_iterall) ---
            */
            return default;
        }

        public async Task<TEntity> RstripTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: _rstrip_text) ---
            */
            return default;
        }

        public async Task<TEntity> _PrepareGlobalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb.py, METHOD: __prepare_globals) ---
            */
            return default;
        }
    }
}