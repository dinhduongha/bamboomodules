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
    public partial class AccountFiscalPositionAppService
    {

        protected async Task<AccountFiscalPosition> CheckZipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_zip) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeAccountMapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_map) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeForeignVatHeaderModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_foreign_vat_header_mode) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeIsDomesticInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_is_domestic) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeStatesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_states_count) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeTaxMapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_tax_map) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountFiscalPosition> ConvertZipValuesInternalAsync(object zip_from, object zip_to)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _convert_zip_values) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> GetFirstMatchingFposInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_first_matching_fpos) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountFiscalPosition> GetFiscalPositionInternalAsync(object partner, object delivery)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_fiscal_position) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> GetFposValidationFunctionsInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_fpos_validation_functions) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> InverseForeignVatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_foreign_vat) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountFiscalPosition> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountFiscalPosition> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> OnchangeCountryGroupIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _onchange_country_group_id) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> OnchangeCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> OnchangeForeignVatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _onchange_foreign_vat) ---
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ValidateForeignVatCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _validate_foreign_vat_country) ---
            */
            return default;
        }
    }
}