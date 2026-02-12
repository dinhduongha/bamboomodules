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
    public partial class ResPartnerBankAppService
    {

        protected async Task<ResPartnerBank> BuildQrCodeValsInternalAsync(object amount, object free_communication, object structured_communication, object currency, object debtor_partner, object qr_method, object silent_errors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _build_qr_code_vals) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckAllowOutPaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_allow_out_payment) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckForQrCodeErrorsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_for_qr_code_errors) ---
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _check_for_qr_code_errors) ---
            --- METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py, METHOD: _check_for_qr_code_errors) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckIbanInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: _check_iban) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_journal_id) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeAccTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_acc_type) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeAccountHolderNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_account_holder_name) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeCountryProxyKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _compute_country_proxy_keys) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayAccountWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_display_account_warning) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayQrSettingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _compute_display_qr_setting) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDuplicateBankPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_duplicate_bank_partner_ids) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeLockTrustFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_lock_trust_fields) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeMoneyTransferServiceNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_money_transfer_service_name) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeSalaryAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _compute_salary_amount) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeSanitizedAccNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_sanitized_acc_number) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeUserHasGroupValidateBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_user_has_group_validate_bank_account) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetAdditionalDataFieldInternalAsync(object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_additional_data_field) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartnerBank> GetAvailableQrMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_available_qr_methods) ---
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_available_qr_methods) ---
            --- METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py, METHOD: _get_available_qr_methods) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetCrc16InternalAsync(object data, object poly, object init)
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_crc16) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetErrorMessagesForQrInternalAsync(object qr_method, object debtor_partner, object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_error_messages_for_qr) ---
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_error_messages_for_qr) ---
            --- METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py, METHOD: _get_error_messages_for_qr) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetMerchantAccountInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_merchant_account_info) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetMerchantCategoryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_merchant_category_code) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetMoneyTransferServicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_money_transfer_services) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeBase64InternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_base64) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeGenerationParamsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_generation_params) ---
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_qr_code_generation_params) ---
            --- METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py, METHOD: _get_qr_code_generation_params) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeUrlInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_url) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeValsListInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_qr_code_vals_list) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrValsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_vals) ---
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_qr_vals) ---
            --- METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py, METHOD: _get_qr_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartnerBank> GetSupportedAccountTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: _get_supported_account_types) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _get_supported_account_types) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartnerBank> RemoveAccentsInternalAsync(object @string)
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _remove_accents) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> SearchAccNumberInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _search_acc_number) ---
            */
            return default;
        }

        protected async Task<ResPartnerBank> SearchEmployeeIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _search_employee_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartnerBank> SerializeInternalAsync(object header, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _serialize) ---
            */
            return default;
        }
    }
}