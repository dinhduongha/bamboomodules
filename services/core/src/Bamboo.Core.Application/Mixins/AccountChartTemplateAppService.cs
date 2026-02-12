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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountChartTemplateAppService : ApplicationService, IAccountChartTemplateAppService
    {

        public AccountChartTemplateAppService() 
        {

        }

        public async Task<TEntity> CompanyXmlidAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: company_xmlid) ---
            */
            return default;
        }

        public async Task<TEntity> CreateOutstandingAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object bank_prefix, object code_digits) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _create_outstanding_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> DerefAccountTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object tax_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _deref_account_tags) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_fiscal_position) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_group) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_journal) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_reconcile_model) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_tax_group) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_account_tax) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountsDataValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object bank_prefix, object code_digits) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_accounts_data_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankFeesRecoAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_bank_fees_reco_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetChartTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_chart_template_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetChartTemplateMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object get_all) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_chart_template_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> GetChartTemplateModelDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object model) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_chart_template_model_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldTranslationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object fname, object lang) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_field_translation) ---
            */
            return default;
        }

        public async Task<TEntity> GetGenericCoaAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: template_generic_coa.py, METHOD: _get_generic_coa_account_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetGenericCoaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: template_generic_coa.py, METHOD: _get_generic_coa_res_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetGenericCoaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: template_generic_coa.py, METHOD: _get_generic_coa_template_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_parent_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetPropertyAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_properties) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_property_accounts) ---
            --- METHOD SOURCE (MODULE: sale, FILE: chart_template.py, METHOD: _get_property_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py, METHOD: _get_stock_account_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py, METHOD: _get_stock_account_journal) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockAccountResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py, METHOD: _get_stock_account_res_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py, METHOD: _get_stock_template_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagMapperInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_tag_mapper) ---
            */
            return default;
        }

        public async Task<TEntity> GetTranslatableTemplateModelFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_translatable_template_model_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatableFieldsTargetLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_untranslatable_fields_target_language) ---
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatableFieldsToTranslateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_untranslatable_fields_to_translate) ---
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatedTranslatableTemplateModelRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _get_untranslated_translatable_template_model_records) ---
            */
            return default;
        }

        public async Task<TEntity> GuessChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _guess_chart_template) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InstallDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _install_demo) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InstantiateForeignTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _instantiate_foreign_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _load_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _load) ---
            */
            return default;
        }

        public async Task<TEntity> LoadTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _load_translations) ---
            */
            return default;
        }

        public async Task<TEntity> ParseCsvInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object model, object module) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _parse_csv) ---
            */
            return default;
        }

        public async Task<TEntity> PostLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _post_load_data) ---
            */
            return default;
        }

        public async Task<TEntity> PostModelSetupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _post_model_setup__) ---
            */
            return default;
        }

        public async Task<TEntity> PreLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data, object data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _pre_load_data) ---
            */
            return default;
        }

        public async Task<TEntity> PreReloadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object data, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _pre_reload_data) ---
            */
            return default;
        }

        public async Task<TEntity> RefAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object raise_if_not_found) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: ref) ---
            */
            return default;
        }

        public async Task<TEntity> SelectChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _select_chart_template) ---
            */
            return default;
        }

        public async Task<TEntity> SetupUtilityBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _setup_utility_bank_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> TemplateRegisterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: _template_register) ---
            */
            return default;
        }

        public async Task<TEntity> TryLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: chart_template.py, METHOD: try_loading) ---
            */
            return default;
        }
    }
}