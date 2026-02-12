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
    public partial class ResCountryAppService
    {

        protected async Task<ResCountry> CheckAddressFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_country.py, METHOD: _check_address_format) ---
            */
            return default;
        }

        protected async Task<ResCountry> ComputeCountryGroupCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_country.py, METHOD: _compute_country_group_codes) ---
            */
            return default;
        }

        protected async Task<ResCountry> ComputeHasForeignFiscalPositionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_country.py, METHOD: _compute_has_foreign_fiscal_position) ---
            */
            return default;
        }

        protected async Task<ResCountry> ComputeImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_country.py, METHOD: _compute_image_url) ---
            */
            return default;
        }

        protected async Task<ResCountry> ComputeProviderSupportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_country.py, METHOD: _compute_provider_support) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCountry> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_country.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCountry> LoadPosSelfDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_country.py, METHOD: _load_pos_self_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCountry> PhoneCodeForInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_country.py, METHOD: _phone_code_for) ---
            */
            return default;
        }
    }
}