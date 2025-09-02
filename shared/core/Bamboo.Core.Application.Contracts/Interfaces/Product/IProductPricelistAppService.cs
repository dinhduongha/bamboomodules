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
    public interface IProductPricelistAppService : IGenericApplicationService<ProductPricelist>
    {
        Task<ProductPricelist> ArchiveAsync(Guid id);
        Task<ProductPricelist> CopyDataAsync(Guid id, ProductPricelistCopyDataRequestDto input);
        Task<ProductPricelist> GetImportTemplatesAsync(Guid id);
        Task<ProductPricelist> OpenPricelistReportAsync(Guid id);
    }
}