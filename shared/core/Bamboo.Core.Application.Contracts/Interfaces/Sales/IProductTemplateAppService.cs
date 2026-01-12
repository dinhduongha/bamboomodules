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
    public interface IProductTemplateAppService : IGenericApplicationService<ProductTemplate>
    {
        Task<ProductTemplate> ArchiveAsync(Guid id);
        Task<ProductTemplate> BomCostAsync(Guid id);
        Task<ProductTemplate> ButtonBomCostAsync(Guid id);
        Task<ProductTemplate> ComputeIsStorableAsync(Guid id);
        Task<ProductTemplate> CopyDataAsync(Guid id, ProductTemplateCopyDataRequestDto input);
        Task<ProductTemplate> CreateProductVariantAsync(Guid id, ProductTemplateCreateProductVariantRequestDto input);
        Task<ProductTemplate> CreateProductVariantsFromGelatoTemplateAsync(Guid id);
        Task<ProductTemplate> GetContextualPriceAsync(Guid id, ProductTemplateGetContextualPriceRequestDto input);
        Task<ProductTemplate> GetEmptyListHelpAsync(Guid id, ProductTemplateGetEmptyListHelpRequestDto input);
        Task<ProductTemplate> GetImportTemplatesAsync(Guid id);
        Task<ProductTemplate> GetProductAccountsAsync(Guid id, ProductTemplateGetProductAccountsRequestDto input);
        Task<ProductTemplate> GetSingleProductVariantAsync(Guid id);
        Task<ProductTemplate> HasDynamicAttributesAsync(Guid id);
        Task<ProductTemplate> OpenDocumentsAsync(Guid id);
        Task<ProductTemplate> OpenLabelLayoutAsync(Guid id);
        Task<ProductTemplate> OpenPricelistRulesAsync(Guid id);
        Task<ProductTemplate> OpenProductLotAsync(Guid id);
        Task<ProductTemplate> OpenQuantsAsync(Guid id);
        Task<ProductTemplate> OpenRoutesDiagramAsync(Guid id);
        Task<ProductTemplate> ProductTmplForecastReportAsync(Guid id);
        Task<ProductTemplate> SetSequenceBottomAsync(Guid id);
        Task<ProductTemplate> SetSequenceDownAsync(Guid id);
        Task<ProductTemplate> SetSequenceTopAsync(Guid id);
        Task<ProductTemplate> SetSequenceUpAsync(Guid id);
        Task<ProductTemplate> SyncGelatoTemplateInfoAsync(Guid id);
        Task<ProductTemplate> UpdateQuantityOnHandAsync(Guid id);
        Task<ProductTemplate> UsedInBomAsync(Guid id);
        Task<ProductTemplate> ViewMosAsync(Guid id);
        Task<ProductTemplate> ViewOrderpointsAsync(Guid id);
        Task<ProductTemplate> ViewPoAsync(Guid id);
        Task<ProductTemplate> ViewRelatedPutawayRulesAsync(Guid id);
        Task<ProductTemplate> ViewSalesAsync(Guid id);
        Task<ProductTemplate> ViewStockMoveLinesAsync(Guid id);
        Task<ProductTemplate> ViewStorageCategoryCapacityAsync(Guid id);
    }
}