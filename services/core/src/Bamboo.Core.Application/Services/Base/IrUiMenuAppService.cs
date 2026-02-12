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
    public partial class IrUiMenuAppService : GenericAppService<IrUiMenu>, IIrUiMenuAppService
    {

        public IrUiMenuAppService(IRepository<IrUiMenu, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<IrUiMenu> GetUserRootsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: get_user_roots) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiMenu> LoadMenusAsync(IrUiMenuLoadMenusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: load_menus) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrUiMenu> LoadMenusRootAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_menu.py, METHOD: load_menus_root) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: load_menus_root) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrUiMenu> LoadWebMenusAsync(IrUiMenuLoadWebMenusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_ui_menu.py, METHOD: load_web_menus) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}