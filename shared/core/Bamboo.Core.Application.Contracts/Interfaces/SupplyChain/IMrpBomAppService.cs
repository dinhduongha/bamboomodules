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
    public interface IMrpBomAppService : IGenericAppService<MrpBom>
    {
        Task<MrpBom> ArchiveAsync(Guid[] ids);
        Task<MrpBom> CheckKitHasNotOrderpointAsync(Guid[] ids);
        Task<MrpBom> ComputeBomDaysAsync(Guid[] ids);
        Task<MrpBom> ExplodeAsync(MrpBomExplodeRequestDto input);
        Task<MrpBom> GetImportTemplatesAsync(Guid[] ids);
        Task<MrpBom> OnchangeBomStructureAsync(Guid[] ids);
        Task<MrpBom> OnchangeProductTmplIdAsync(Guid[] ids);
        Task<MrpBom> OpenOperationFormAsync(Guid[] ids);
        Task<MrpBom> SetBomOnOrderpointAsync(Guid[] ids);
        Task<MrpBom> UnarchiveAsync(Guid[] ids);
    }
}