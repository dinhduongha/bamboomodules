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
    public interface IBaseImportImportAppService : IGenericApplicationService<BaseImportImport>
    {
        Task<BaseImportImport> ExecuteImportAsync(Guid id, BaseImportImportExecuteImportRequestDto input);
        Task<BaseImportImport> GetFieldsTreeAsync(Guid id, BaseImportImportGetFieldsTreeRequestDto input);
        Task<BaseImportImport> ParsePreviewAsync(Guid id, BaseImportImportParsePreviewRequestDto input);
    }
}