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
    public interface IProductSupplierinfoAppService : IGenericAppService<ProductSupplierinfo>
    {
        Task<ProductSupplierinfo> GetImportTemplatesAsync(Guid[] ids);
        Task<ProductSupplierinfo> SetSupplierAsync(Guid[] ids);
    }
}