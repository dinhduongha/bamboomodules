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
    public interface IIrModuleModuleAppService : IGenericApplicationService<IrModuleModule>
    {
        Task<IrModuleModule> ButtonChooseThemeAsync(Guid id);
        Task<IrModuleModule> ButtonImmediateInstallAppAsync(Guid id);
        Task<IrModuleModule> ButtonImmediateInstallAsync(Guid id);
        Task<IrModuleModule> ButtonImmediateUninstallAsync(Guid id);
        Task<IrModuleModule> ButtonImmediateUpgradeAsync(Guid id);
        Task<IrModuleModule> ButtonInstallAsync(Guid id);
        Task<IrModuleModule> ButtonInstallCancelAsync(Guid id);
        Task<IrModuleModule> ButtonRefreshThemeAsync(Guid id);
        Task<IrModuleModule> ButtonRemoveThemeAsync(Guid id);
        Task<IrModuleModule> ButtonUninstallAsync(Guid id);
        Task<IrModuleModule> ButtonUninstallCancelAsync(Guid id);
        Task<IrModuleModule> ButtonUninstallWizardAsync(Guid id);
        Task<IrModuleModule> ButtonUpgradeAsync(Guid id);
        Task<IrModuleModule> ButtonUpgradeCancelAsync(Guid id);
        Task<IrModuleModule> CheckExternalDependenciesAsync(Guid id, IrModuleModuleCheckExternalDependenciesRequestDto input);
        Task<IrModuleModule> DownstreamDependenciesAsync(Guid id, IrModuleModuleDownstreamDependenciesRequestDto input);
        Task<IrModuleModule> GetModuleInfoAsync(Guid id, IrModuleModuleGetModuleInfoRequestDto input);
        Task<IrModuleModule> GetThemesDomainAsync(Guid id);
        Task<IrModuleModule> GetValuesFromTerpAsync(Guid id);
        Task<IrModuleModule> ModuleUninstallAsync(Guid id);
        Task<IrModuleModule> MoreInfoAsync(Guid id);
        Task<IrModuleModule> NextAsync(Guid id);
        Task<IrModuleModule> OpenInstallRequestAsync(Guid id);
        Task<IrModuleModule> SearchPanelSelectRangeAsync(Guid id, IrModuleModuleSearchPanelSelectRangeRequestDto input);
        Task<IrModuleModule> UpdateListAsync(Guid id);
        Task<IrModuleModule> UpdateThemeImagesAsync(Guid id);
        Task<IrModuleModule> UpstreamDependenciesAsync(Guid id, IrModuleModuleUpstreamDependenciesRequestDto input);
        Task<IrModuleModule> WebReadAsync(Guid id, IrModuleModuleWebReadRequestDto input);
        Task<IrModuleModule> WebSearchReadAsync(Guid id, IrModuleModuleWebSearchReadRequestDto input);
    }
}