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
    public interface IProductPricelistAppService : IGenericApplicationService<ProductPricelist>
    {
        Task<ProductPricelist> ArchiveAsync(Guid id);
        Task<ProductPricelist> CopyDataAsync(Guid id, ProductPricelistCopyDataRequestDto input);
        Task<ProductPricelist> GetImportTemplatesAsync(Guid id);
        Task<ProductPricelist> OpenPricelistReportAsync(Guid id);
    }
}