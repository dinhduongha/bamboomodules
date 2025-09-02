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
    public interface IProductAttributeValueAppService : IGenericApplicationService<ProductAttributeValue>
    {
        Task<ProductAttributeValue> AddToProductsAsync(Guid id);
        Task<ProductAttributeValue> CheckIsUsedOnProductsAsync(Guid id);
        Task<ProductAttributeValue> UpdatePricesAsync(Guid id);
    }
}