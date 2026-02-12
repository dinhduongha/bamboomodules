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
    public partial class ResLangAppService
    {

        protected async Task<ResLang> ActivateAndInstallLangInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _activate_and_install_lang) ---
            */
            return default;
        }

        protected async Task<ResLang> ActivateLangInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _activate_lang) ---
            */
            return default;
        }

        protected async Task<ResLang> CheckActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _check_active) ---
            */
            return default;
        }

        protected async Task<ResLang> CheckFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _check_format) ---
            */
            return default;
        }

        protected async Task<ResLang> ComputeFieldFlagImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _compute_field_flag_image_url) ---
            */
            return default;
        }

        protected async Task<ResLang> CreateLangInternalAsync(object lang, object lang_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _create_lang) ---
            */
            return default;
        }

        protected async Task<object> GetActiveByInternalAsync(string field)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _get_active_by) ---
            */
            return default;
        }

        protected async Task<ResLang> GetCodeInternalAsync(string code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _get_code) ---
            */
            return default;
        }

        protected async Task<object> GetDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _get_data) ---
            */
            return default;
        }

        protected async Task<ResLang> GetDateFormatSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _get_date_format_selection) ---
            */
            return default;
        }

        protected async Task<object> GetFrontendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: res_lang.py, METHOD: _get_frontend) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_lang.py, METHOD: _get_frontend) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResLang> GetUserSpreadsheetLocaleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py, METHOD: _get_user_spreadsheet_locale) ---
            */
            return default;
        }

        protected async Task<ResLang> LangGetInternalAsync(string code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResLang> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_lang.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ResLang> OdooLangToSpreadsheetLocaleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py, METHOD: _odoo_lang_to_spreadsheet_locale) ---
            */
            return default;
        }

        protected async Task<ResLang> OnchangeFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _onchange_format) ---
            */
            return default;
        }

        protected async Task<ResLang> RegisterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _register_hook) ---
            */
            return default;
        }

        protected async Task<ResLang> UnlinkExceptDefaultLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: _unlink_except_default_lang) ---
            */
            return default;
        }
    }
}