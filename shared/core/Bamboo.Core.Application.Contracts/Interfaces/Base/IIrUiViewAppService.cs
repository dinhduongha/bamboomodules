using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIrUiViewAppService : IGenericAppService<IrUiView>
    {
        Task<IrUiView> ApplyInheritanceSpecsAsync(IrUiViewApplyInheritanceSpecsRequestDto input);
        Task<IrUiView> CopyDataAsync(IrUiViewCopyDataRequestDto input);
        Task<IrUiView> DefaultViewAsync(IrUiViewDefaultViewRequestDto input);
        Task<IrUiView> DeleteSnippetAsync(IrUiViewDeleteSnippetRequestDto input);
        Task<IrUiView> DistributeBrandingAsync(IrUiViewDistributeBrandingRequestDto input);
        Task<IrUiView> ExtractEmbeddedFieldsAsync(IrUiViewExtractEmbeddedFieldsRequestDto input);
        Task<IrUiView> ExtractOeStructuresAsync(IrUiViewExtractOeStructuresRequestDto input);
        Task<IrUiView> FilterDuplicateAsync(Guid[] ids);
        Task<IrUiView> GetCombinedArchAsync(Guid[] ids);
        Task<IrUiView> GetDefaultLangCodeAsync(Guid[] ids);
        Task<IrUiView> GetRelatedViewsAsync(IrUiViewGetRelatedViewsRequestDto input);
        Task<IrUiView> GetViewHierarchyAsync(Guid[] ids);
        Task<IrUiView> GetViewInfoAsync(Guid[] ids);
        Task<IrUiView> InheritBrandingAsync(IrUiViewInheritBrandingRequestDto input);
        Task<IrUiView> IsNodeBrandedAsync(IrUiViewIsNodeBrandedRequestDto input);
        Task<IrUiView> LocateNodeAsync(IrUiViewLocateNodeRequestDto input);
        Task<IrUiView> PostprocessAndFieldsAsync(IrUiViewPostprocessAndFieldsRequestDto input);
        Task<IrUiView> RenameSnippetAsync(IrUiViewRenameSnippetRequestDto input);
        Task<IrUiView> RenderPublicAssetAsync(IrUiViewRenderPublicAssetRequestDto input);
        Task<IrUiView> ReplaceArchSectionAsync(IrUiViewReplaceArchSectionRequestDto input);
        Task<IrUiView> ResetArchAsync(IrUiViewResetArchRequestDto input);
        Task<IrUiView> SaveAsync(IrUiViewSaveRequestDto input);
        Task<IrUiView> SaveEmbeddedFieldAsync(IrUiViewSaveEmbeddedFieldRequestDto input);
        Task<IrUiView> SaveOeStructureAsync(IrUiViewSaveOeStructureRequestDto input);
        Task<IrUiView> SaveSnippetAsync(IrUiViewSaveSnippetRequestDto input);
        Task<IrUiView> ToEmptyOeStructureAsync(IrUiViewToEmptyOeStructureRequestDto input);
        Task<IrUiView> ToFieldRefAsync(IrUiViewToFieldRefRequestDto input);
    }
}