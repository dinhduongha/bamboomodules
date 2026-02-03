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
    public interface IIrModuleModuleAppService : IGenericAppService<IrModuleModule>
    {
        Task<IrModuleModule> ButtonChooseThemeAsync(Guid[] ids);
        Task<IrModuleModule> ButtonImmediateInstallAppAsync(Guid[] ids);
        Task<IrModuleModule> ButtonImmediateInstallAsync(Guid[] ids);
        Task<IrModuleModule> ButtonImmediateUninstallAsync(Guid[] ids);
        Task<IrModuleModule> ButtonImmediateUpgradeAsync(Guid[] ids);
        Task<IrModuleModule> ButtonInstallAsync(Guid[] ids);
        Task<IrModuleModule> ButtonRefreshThemeAsync(Guid[] ids);
        Task<IrModuleModule> ButtonRemoveThemeAsync(Guid[] ids);
        Task<IrModuleModule> ButtonResetStateAsync(Guid[] ids);
        Task<IrModuleModule> ButtonUninstallAsync(Guid[] ids);
        Task<IrModuleModule> ButtonUninstallWizardAsync(Guid[] ids);
        Task<IrModuleModule> ButtonUpgradeAsync(Guid[] ids);
        Task<IrModuleModule> CheckExternalDependenciesAsync(IrModuleModuleCheckExternalDependenciesRequestDto input);
        Task<IrModuleModule> CheckModuleUpdateAsync(Guid[] ids);
        Task<IrModuleModule> DownstreamDependenciesAsync(IrModuleModuleDownstreamDependenciesRequestDto input);
        Task<IrModuleModule> GetModuleInfoAsync(IrModuleModuleGetModuleInfoRequestDto input);
        Task<IrModuleModule> GetThemesDomainAsync(Guid[] ids);
        Task<IrModuleModule> GetValuesFromTerpAsync(Guid[] ids);
        Task<IrModuleModule> ModuleUninstallAsync(Guid[] ids);
        Task<IrModuleModule> MoreInfoAsync(Guid[] ids);
        Task<IrModuleModule> NextAsync(Guid[] ids);
        Task<IrModuleModule> OpenInstallRequestAsync(Guid[] ids);
        Task<IrModuleModule> SearchPanelSelectRangeAsync(IrModuleModuleSearchPanelSelectRangeRequestDto input);
        Task<IrModuleModule> UpdateListAsync(Guid[] ids);
        Task<IrModuleModule> UpdateThemeImagesAsync(Guid[] ids);
        Task<IrModuleModule> UpstreamDependenciesAsync(IrModuleModuleUpstreamDependenciesRequestDto input);
        Task<IrModuleModule> ViewDeliveryMethodsAsync(Guid[] ids);
        Task<IrModuleModule> WebReadAsync(IrModuleModuleWebReadRequestDto input);
        Task<IrModuleModule> WebSearchReadAsync(IrModuleModuleWebSearchReadRequestDto input);
    }
}