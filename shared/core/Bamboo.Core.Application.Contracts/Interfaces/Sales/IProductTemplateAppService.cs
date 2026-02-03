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
    public interface IProductTemplateAppService : IGenericAppService<ProductTemplate>
    {
        Task<ProductTemplate> ArchiveAsync(Guid[] ids);
        Task<ProductTemplate> BomCostAsync(Guid[] ids);
        Task<ProductTemplate> ButtonBomCostAsync(Guid[] ids);
        Task<ProductTemplate> ComputeIsStorableAsync(Guid[] ids);
        Task<ProductTemplate> CopyDataAsync(ProductTemplateCopyDataRequestDto input);
        Task<ProductTemplate> CreateProductVariantAsync(ProductTemplateCreateProductVariantRequestDto input);
        Task<ProductTemplate> CreateProductVariantFromPosAsync(ProductTemplateCreateProductVariantFromPosRequestDto input);
        Task<ProductTemplate> CreateProductVariantsFromGelatoTemplateAsync(Guid[] ids);
        Task<ProductTemplate> GetContextualPriceAsync(ProductTemplateGetContextualPriceRequestDto input);
        Task<ProductTemplate> GetEmptyListHelpAsync(ProductTemplateGetEmptyListHelpRequestDto input);
        Task<ProductTemplate> GetImportTemplatesAsync(Guid[] ids);
        Task<ProductTemplate> GetProductAccountsAsync(ProductTemplateGetProductAccountsRequestDto input);
        Task<ProductTemplate> GetProductInfoPosAsync(ProductTemplateGetProductInfoPosRequestDto input);
        Task<ProductTemplate> GetSingleProductVariantAsync(Guid[] ids);
        Task<ProductTemplate> HasDynamicAttributesAsync(Guid[] ids);
        Task<ProductTemplate> LoadProductFromPosAsync(ProductTemplateLoadProductFromPosRequestDto input);
        Task<ProductTemplate> OpenDocumentsAsync(Guid[] ids);
        Task<ProductTemplate> OpenLabelLayoutAsync(Guid[] ids);
        Task<ProductTemplate> OpenProductLotAsync(Guid[] ids);
        Task<ProductTemplate> OpenQuantsAsync(Guid[] ids);
        Task<ProductTemplate> OpenRoutesDiagramAsync(Guid[] ids);
        Task<ProductTemplate> ProductTmplForecastReportAsync(Guid[] ids);
        Task<ProductTemplate> SetSequenceBottomAsync(Guid[] ids);
        Task<ProductTemplate> SetSequenceDownAsync(Guid[] ids);
        Task<ProductTemplate> SetSequenceTopAsync(Guid[] ids);
        Task<ProductTemplate> SetSequenceUpAsync(Guid[] ids);
        Task<ProductTemplate> SyncGelatoTemplateInfoAsync(Guid[] ids);
        Task<ProductTemplate> UsedInBomAsync(Guid[] ids);
        Task<ProductTemplate> ViewMosAsync(Guid[] ids);
        Task<ProductTemplate> ViewOrderpointsAsync(Guid[] ids);
        Task<ProductTemplate> ViewPoAsync(Guid[] ids);
        Task<ProductTemplate> ViewRelatedPutawayRulesAsync(Guid[] ids);
        Task<ProductTemplate> ViewSalesAsync(Guid[] ids);
        Task<ProductTemplate> ViewStockMoveLinesAsync(Guid[] ids);
        Task<ProductTemplate> ViewStorageCategoryCapacityAsync(Guid[] ids);
    }
}