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
    public interface IMrpBomAppService : IGenericApplicationService<MrpBom>
    {
        Task<MrpBom> ArchiveAsync(Guid id);
        Task<MrpBom> CheckKitHasNotOrderpointAsync(Guid id);
        Task<MrpBom> ComputeBomDaysAsync(Guid id);
        Task<MrpBom> ExplodeAsync(Guid id, MrpBomExplodeRequestDto input);
        Task<MrpBom> GetImportTemplatesAsync(Guid id);
        Task<MrpBom> OnchangeBomStructureAsync(Guid id);
        Task<MrpBom> OnchangeProductTmplIdAsync(Guid id);
        Task<MrpBom> OpenOperationFormAsync(Guid id);
        Task<MrpBom> SetBomOnOrderpointAsync(Guid id);
        Task<MrpBom> UnarchiveAsync(Guid id);
    }
}