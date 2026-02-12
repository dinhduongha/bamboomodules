using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class IrModuleModuleAppService : GenericAppService<IrModuleModule>, IIrModuleModuleAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public IrModuleModuleAppService(IRepository<IrModuleModule, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<IrModuleModule> ButtonChooseThemeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: button_choose_theme) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonImmediateInstallAppAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: button_immediate_install_app) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonImmediateInstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_immediate_install) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonImmediateUninstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_immediate_uninstall) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonImmediateUpgradeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_immediate_upgrade) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonInstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_install) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonRefreshThemeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: button_refresh_theme) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonRemoveThemeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: button_remove_theme) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> ButtonResetStateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_reset_state) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonUninstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_uninstall) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonUninstallWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_uninstall_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ButtonUpgradeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: button_upgrade) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: button_upgrade) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> CheckExternalDependenciesAsync(IrModuleModuleCheckExternalDependenciesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: check_external_dependencies) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> CheckModuleUpdateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: check_module_update) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> DownstreamDependenciesAsync(IrModuleModuleDownstreamDependenciesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: downstream_dependencies) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> GetModuleInfoAsync(IrModuleModuleGetModuleInfoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: get_module_info) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> GetThemesDomainAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: get_themes_domain) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> GetValuesFromTerpAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: get_values_from_terp) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ModuleUninstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_module.py, METHOD: module_uninstall) ---
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: module_uninstall) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: module_uninstall) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> MoreInfoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: more_info) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> NextAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: next) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> OpenInstallRequestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_install_request, FILE: ir_module_module.py, METHOD: action_open_install_request) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> SearchPanelSelectRangeAsync(IrModuleModuleSearchPanelSelectRangeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: search_panel_select_range) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: search_panel_select_range) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> UpdateListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: update_list) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: update_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> UpdateThemeImagesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: update_theme_images) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> UpstreamDependenciesAsync(IrModuleModuleUpstreamDependenciesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: upstream_dependencies) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> ViewDeliveryMethodsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: ir_module_module.py, METHOD: action_view_delivery_methods) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModuleModule> WebReadAsync(IrModuleModuleWebReadRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: web_read) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModuleModule> WebSearchReadAsync(IrModuleModuleWebSearchReadRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py, METHOD: web_search_read) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrModuleModule> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_module.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_module_module.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}