using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class IrUiMenuAppService
    {

        protected async Task<IrUiMenu> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeWebIconDataInternalAsync(object web_icon)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _compute_web_icon_data) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> FilterVisibleMenusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _filter_visible_menus) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiMenu> GetBestBackendRootMenuIdForModelInternalAsync(object res_model)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_ui_menu.py, METHOD: _get_best_backend_root_menu_id_for_model) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> GetFullNameInternalAsync(object level)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _get_full_name) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> GetMenuitemsXmlidsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _get_menuitems_xmlids) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> LoadMenusBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: hr_timesheet_attendance, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: project, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _load_menus_blacklist) ---
            */
            return default;
        }

        protected async Task<IrUiMenu> ReadImageInternalAsync(object path)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _read_image) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrUiMenu> VisibleMenuIdsInternalAsync(object debug)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py, METHOD: _visible_menu_ids) ---
            */
            return default;
        }
    }
}