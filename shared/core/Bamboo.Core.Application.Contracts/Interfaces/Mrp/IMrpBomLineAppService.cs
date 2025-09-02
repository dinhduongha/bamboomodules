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
    public interface IMrpBomLineAppService : IGenericApplicationService<MrpBomLine>
    {
        Task<MrpBomLine> AddFromCatalogAsync(Guid id);
        Task<MrpBomLine> OnchangeProductIdAsync(Guid id);
        Task<MrpBomLine> OnchangeProductUomIdAsync(Guid id);
        Task<MrpBomLine> SeeAttachmentsAsync(Guid id);
    }
}