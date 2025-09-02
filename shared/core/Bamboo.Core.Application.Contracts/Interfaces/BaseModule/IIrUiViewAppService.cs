using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIrUiViewAppService : IGenericApplicationService<IrUiView>
    {
        Task<IrUiView> ApplyInheritanceSpecsAsync(Guid id, IrUiViewApplyInheritanceSpecsRequestDto input);
        Task<IrUiView> CopyDataAsync(Guid id, IrUiViewCopyDataRequestDto input);
        Task<IrUiView> DefaultViewAsync(Guid id, IrUiViewDefaultViewRequestDto input);
        Task<IrUiView> DeleteSnippetAsync(Guid id, IrUiViewDeleteSnippetRequestDto input);
        Task<IrUiView> DistributeBrandingAsync(Guid id, IrUiViewDistributeBrandingRequestDto input);
        Task<IrUiView> ExtractEmbeddedFieldsAsync(Guid id, IrUiViewExtractEmbeddedFieldsRequestDto input);
        Task<IrUiView> ExtractOeStructuresAsync(Guid id, IrUiViewExtractOeStructuresRequestDto input);
        Task<IrUiView> FilterDuplicateAsync(Guid id);
        Task<IrUiView> GetCombinedArchAsync(Guid id);
        Task<IrUiView> GetDefaultLangCodeAsync(Guid id);
        Task<IrUiView> GetRelatedViewsAsync(Guid id, IrUiViewGetRelatedViewsRequestDto input);
        Task<IrUiView> GetViewHierarchyAsync(Guid id);
        Task<IrUiView> GetViewInfoAsync(Guid id);
        Task<IrUiView> InheritBrandingAsync(Guid id, IrUiViewInheritBrandingRequestDto input);
        Task<IrUiView> IsNodeBrandedAsync(Guid id, IrUiViewIsNodeBrandedRequestDto input);
        Task<IrUiView> LocateNodeAsync(Guid id, IrUiViewLocateNodeRequestDto input);
        Task<IrUiView> PostprocessAndFieldsAsync(Guid id, IrUiViewPostprocessAndFieldsRequestDto input);
        Task<IrUiView> RenameSnippetAsync(Guid id, IrUiViewRenameSnippetRequestDto input);
        Task<IrUiView> RenderPublicAssetAsync(Guid id, IrUiViewRenderPublicAssetRequestDto input);
        Task<IrUiView> ReplaceArchSectionAsync(Guid id, IrUiViewReplaceArchSectionRequestDto input);
        Task<IrUiView> ResetArchAsync(Guid id, IrUiViewResetArchRequestDto input);
        Task<IrUiView> SaveAsync(Guid id, IrUiViewSaveRequestDto input);
        Task<IrUiView> SaveEmbeddedFieldAsync(Guid id, IrUiViewSaveEmbeddedFieldRequestDto input);
        Task<IrUiView> SaveOeStructureAsync(Guid id, IrUiViewSaveOeStructureRequestDto input);
        Task<IrUiView> SaveSnippetAsync(Guid id, IrUiViewSaveSnippetRequestDto input);
        Task<IrUiView> ToEmptyOeStructureAsync(Guid id, IrUiViewToEmptyOeStructureRequestDto input);
        Task<IrUiView> ToFieldRefAsync(Guid id, IrUiViewToFieldRefRequestDto input);
    }
}