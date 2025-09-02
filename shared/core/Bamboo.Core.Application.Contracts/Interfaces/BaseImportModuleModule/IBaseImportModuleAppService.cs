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
    public interface IBaseImportModuleAppService : IGenericApplicationService<BaseImportModule>
    {
        Task<BaseImportModule> GetDependenciesToInstallNamesAsync(Guid id);
        Task<BaseImportModule> ImportModuleAsync(Guid id);
        Task<BaseImportModule> ModuleOpenAsync(Guid id);
    }
}