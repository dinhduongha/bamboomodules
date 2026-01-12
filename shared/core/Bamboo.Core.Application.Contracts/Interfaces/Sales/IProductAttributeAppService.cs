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
    public interface IProductAttributeAppService : IGenericApplicationService<ProductAttribute>
    {
        Task<ProductAttribute> ArchiveAsync(Guid id);
        Task<ProductAttribute> OpenProductTemplateAttributeLinesAsync(Guid id);
    }
}