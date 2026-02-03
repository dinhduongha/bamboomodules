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
    public interface IMrpBomLineAppService : IGenericAppService<MrpBomLine>
    {
        Task<MrpBomLine> AddFromCatalogAsync(Guid[] ids);
        Task<MrpBomLine> OnchangeProductIdAsync(Guid[] ids);
        Task<MrpBomLine> SeeAttachmentsAsync(Guid[] ids);
    }
}