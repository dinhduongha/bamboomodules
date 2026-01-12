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
    public interface IBaseImportModuleAppService : IGenericApplicationService<BaseImportModule>
    {
        Task<BaseImportModule> GetDependenciesToInstallNamesAsync(Guid id);
        Task<BaseImportModule> ImportModuleAsync(Guid id);
        Task<BaseImportModule> ModuleOpenAsync(Guid id);
    }
}