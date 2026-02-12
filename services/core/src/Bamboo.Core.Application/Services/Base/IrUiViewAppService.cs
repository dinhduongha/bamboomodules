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
    [Module("BaseModule", Category = "Base")]
    public partial class IrUiViewAppService : GenericAppService<IrUiView>, IIrUiViewAppService
    {
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public IrUiViewAppService(IRepository<IrUiView, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        [ApiModel]
        public async Task<IrUiView> ApplyInheritanceSpecsAsync(IrUiViewApplyInheritanceSpecsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: apply_inheritance_specs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> CopyDataAsync(IrUiViewCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<IrUiView> CreateAsync(CreateRequestDto<IrUiView> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<IrUiView> DefaultViewAsync(IrUiViewDefaultViewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: default_view) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> DeleteSnippetAsync(IrUiViewDeleteSnippetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: delete_snippet) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> DistributeBrandingAsync(IrUiViewDistributeBrandingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: distribute_branding) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> ExtractEmbeddedFieldsAsync(IrUiViewExtractEmbeddedFieldsRequestDto input)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: extract_embedded_fields) ---
            #endif
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> ExtractOeStructuresAsync(IrUiViewExtractOeStructuresRequestDto input)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: extract_oe_structures) ---
            #endif
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> FilterDuplicateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: filter_duplicate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> GetCombinedArchAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_combined_arch) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> GetDefaultLangCodeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: get_default_lang_code) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_default_lang_code) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> GetRelatedViewsAsync(IrUiViewGetRelatedViewsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: get_related_views) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_related_views) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> GetViewHierarchyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_view_hierarchy) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> GetViewInfoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py, METHOD: get_view_info) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> InheritBrandingAsync(IrUiViewInheritBrandingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: inherit_branding) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> IsNodeBrandedAsync(IrUiViewIsNodeBrandedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: is_node_branded) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> LocateNodeAsync(IrUiViewLocateNodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: locate_node) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> PostprocessAndFieldsAsync(IrUiViewPostprocessAndFieldsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: postprocess_and_fields) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> RenameSnippetAsync(IrUiViewRenameSnippetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: rename_snippet) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> RenderPublicAssetAsync(IrUiViewRenderPublicAssetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: render_public_asset) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: render_public_asset) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> ReplaceArchSectionAsync(IrUiViewReplaceArchSectionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: replace_arch_section) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> ResetArchAsync(IrUiViewResetArchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: reset_arch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> SaveAsync(IrUiViewSaveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: save) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> SaveEmbeddedFieldAsync(IrUiViewSaveEmbeddedFieldRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_embedded_field) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiView> SaveOeStructureAsync(IrUiViewSaveOeStructureRequestDto input)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_oe_structure) ---
            #endif
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> SaveSnippetAsync(IrUiViewSaveSnippetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_snippet) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> ToEmptyOeStructureAsync(IrUiViewToEmptyOeStructureRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: to_empty_oe_structure) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiView> ToFieldRefAsync(IrUiViewToFieldRefRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: to_field_ref) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrUiView> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}