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
    public interface IProductProductAppService : IGenericApplicationService<ProductProduct>
    {
        Task<ProductProduct> ArchiveAsync(Guid[] ids);
        Task<ProductProduct> BomCostAsync(Guid[] ids);
        Task<ProductProduct> ButtonBomCostAsync(Guid[] ids);
        Task<ProductProduct> FilterHasRoutesAsync(Guid[] ids);
        Task<ProductProduct> GetComponentsAsync(Guid[] ids);
        Task<ProductProduct> GetContextualPriceAsync(Guid[] ids);
        Task<ProductProduct> GetEmptyListHelpAsync(ProductProductGetEmptyListHelpRequestDto input);
        Task<ProductProduct> GetProductMultilineDescriptionSaleAsync(Guid[] ids);
        Task<ProductProduct> GetTotalRoutesAsync(Guid[] ids);
        Task<ProductProduct> OpenDocumentsAsync(Guid[] ids);
        Task<ProductProduct> OpenLabelLayoutAsync(Guid[] ids);
        Task<ProductProduct> OpenProductLotAsync(Guid[] ids);
        Task<ProductProduct> OpenProductTemplateAsync(Guid[] ids);
        Task<ProductProduct> OpenQuantsAsync(Guid[] ids);
        Task<ProductProduct> OpenWebsiteUrlAsync(Guid[] ids);
        Task<ProductProduct> ProductForecastReportAsync(Guid[] ids);
        Task<ProductProduct> UnarchiveAsync(Guid[] ids);
        Task<ProductProduct> UsedInBomAsync(Guid[] ids);
        Task<ProductProduct> ViewBomAsync(Guid[] ids);
        Task<ProductProduct> ViewHeaderGetAsync(ProductProductViewHeaderGetRequestDto input);
        Task<ProductProduct> ViewMosAsync(Guid[] ids);
        Task<ProductProduct> ViewOrderpointsAsync(Guid[] ids);
        Task<ProductProduct> ViewPoAsync(Guid[] ids);
        Task<ProductProduct> ViewRelatedPutawayRulesAsync(Guid[] ids);
        Task<ProductProduct> ViewRoutesAsync(Guid[] ids);
        Task<ProductProduct> ViewSalesAsync(Guid[] ids);
        Task<ProductProduct> ViewStockMoveLinesAsync(Guid[] ids);
        Task<ProductProduct> ViewStorageCategoryCapacityAsync(Guid[] ids);
        Task<ProductProduct> WebsitePublishButtonAsync(Guid[] ids);
    }
}