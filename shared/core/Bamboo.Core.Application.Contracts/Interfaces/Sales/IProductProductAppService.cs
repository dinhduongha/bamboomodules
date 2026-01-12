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
        Task<ProductProduct> ArchiveAsync(Guid id);
        Task<ProductProduct> BomCostAsync(Guid id);
        Task<ProductProduct> ButtonBomCostAsync(Guid id);
        Task<ProductProduct> FilterHasRoutesAsync(Guid id);
        Task<ProductProduct> GetComponentsAsync(Guid id);
        Task<ProductProduct> GetContextualPriceAsync(Guid id);
        Task<ProductProduct> GetEmptyListHelpAsync(Guid id, ProductProductGetEmptyListHelpRequestDto input);
        Task<ProductProduct> GetProductMultilineDescriptionSaleAsync(Guid id);
        Task<ProductProduct> GetTotalRoutesAsync(Guid id);
        Task<ProductProduct> OpenDocumentsAsync(Guid id);
        Task<ProductProduct> OpenLabelLayoutAsync(Guid id);
        Task<ProductProduct> OpenProductLotAsync(Guid id);
        Task<ProductProduct> OpenProductTemplateAsync(Guid id);
        Task<ProductProduct> OpenQuantsAsync(Guid id);
        Task<ProductProduct> OpenWebsiteUrlAsync(Guid id);
        Task<ProductProduct> ProductForecastReportAsync(Guid id);
        Task<ProductProduct> UnarchiveAsync(Guid id);
        Task<ProductProduct> UsedInBomAsync(Guid id);
        Task<ProductProduct> ViewBomAsync(Guid id);
        Task<ProductProduct> ViewHeaderGetAsync(Guid id, ProductProductViewHeaderGetRequestDto input);
        Task<ProductProduct> ViewMosAsync(Guid id);
        Task<ProductProduct> ViewOrderpointsAsync(Guid id);
        Task<ProductProduct> ViewPoAsync(Guid id);
        Task<ProductProduct> ViewRelatedPutawayRulesAsync(Guid id);
        Task<ProductProduct> ViewRoutesAsync(Guid id);
        Task<ProductProduct> ViewSalesAsync(Guid id);
        Task<ProductProduct> ViewStockMoveLinesAsync(Guid id);
        Task<ProductProduct> ViewStorageCategoryCapacityAsync(Guid id);
        Task<ProductProduct> WebsitePublishButtonAsync(Guid id);
    }
}