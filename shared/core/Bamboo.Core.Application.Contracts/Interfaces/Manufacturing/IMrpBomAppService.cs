using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMrpBomAppService : IGenericApplicationService<MrpBom>
    {
        Task<MrpBom> CheckKitHasNotOrderpointAsync(Guid id);
        Task<MrpBom> ComputeBomDaysAsync(Guid id);
        Task<MrpBom> ExplodeAsync(Guid id, MrpBomExplodeRequestDto input);
        Task<MrpBom> GetImportTemplatesAsync(Guid id);
        Task<MrpBom> OnchangeBomStructureAsync(Guid id);
        Task<MrpBom> OnchangeProductTmplIdAsync(Guid id);
        Task<MrpBom> OnchangeProductUomIdAsync(Guid id);
        Task<MrpBom> ToggleActiveAsync(Guid id);
    }
}