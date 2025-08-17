using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountChartTemplateAppService : ApplicationService, IAccountChartTemplateAppService
    {

        public AccountChartTemplateAppService() 
        {

        }

        public async Task<TEntity> DerefAccountTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object tax_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _deref_account_tags(self, template_code, tax_data):
            // mapper = self._get_tag_mapper(self._get_chart_template_mapping()[template_code]['country_id'])
            // for tax_values in tax_data.values():
            //     for field_name in ('repartition_line_ids', 'invoice_repartition_line_ids', 'refund_repartition_line_ids'):
            //         for element in tax_values.get(field_name, []):
            //             match element:
            //                 case int() as command, _, {'tag_ids': str() as tags} as values if command in tuple(Command):
            //                     values['tag_ids'] = [Command.set(mapper(*tags.split(TAX_TAG_DELIMITER)))]
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_mc.py) ---
            // def _deref_account_tags(self, template_code, tax_data):
            // if template_code == 'mc':
            //     template_code = 'fr'
            // return super()._deref_account_tags(template_code, tax_data)
            */
            return default;
        }

        public async Task<TEntity> GetAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_account(self, template_code):
            // return self._parse_csv(template_code, 'account.account')
            */
            return default;
        }

        public async Task<TEntity> GetAccountFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_fiscal_position(self, template_code):
            // return self._parse_csv(template_code, 'account.fiscal.position')
            */
            return default;
        }

        public async Task<TEntity> GetAccountGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_group(self, template_code):
            // return self._parse_csv(template_code, 'account.group')
            */
            return default;
        }

        public async Task<TEntity> GetAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_journal(self, template_code):
            // return {
            //     "sale": {
            //         'name': _('Customer Invoices'),
            //         'type': 'sale',
            //         'code': _('INV'),
            //         'show_on_dashboard': True,
            //         'color': 11,
            //         'sequence': 5,
            //     },
            //     "purchase": {
            //         'name': _('Vendor Bills'),
            //         'type': 'purchase',
            //         'code': _('BILL'),
            //         'show_on_dashboard': True,
            //         'color': 11,
            //         'sequence': 6,
            //     },
            //     "general": {
            //         'name': _('Miscellaneous Operations'),
            //         'type': 'general',
            //         'code': _('MISC'),
            //         'show_on_dashboard': False,
            //         'sequence': 9,
            //     },
            //     "exch": {
            //         'name': _('Exchange Difference'),
            //         'type': 'general',
            //         'code': _('EXCH'),
            //         'show_on_dashboard': False,
            //     },
            //     "caba": {
            //         'name': _('Cash Basis Taxes'),
            //         'type': 'general',
            //         'code': _('CABA'),
            //         'show_on_dashboard': False,
            //     },
            //     "bank": {
            //         'name': _('Bank'),
            //         'type': 'bank',
            //         'show_on_dashboard': True,
            //         'sequence': 7,
            //     },
            //     "cash": {
            //         'name': _('Cash'),
            //         'type': 'cash',
            //         'show_on_dashboard': True,
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_pt, FILE: template_pt.py) ---
            // def _get_account_journal(self, template_code):
            // vals = super()._get_account_journal(template_code)
            // if template_code == 'pt':
            //     if 'cash' in vals:
            //         vals['cash']['default_account_id'] = 'chart_11'
            //     if 'bank' in vals:
            //         vals['bank']['default_account_id'] = 'chart_12'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetAccountReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_reconcile_model(self, template_code):
            // return {
            //     "reconcile_perfect_match": {
            //         "name": _('Invoices/Bills Perfect Match'),
            //         "sequence": 1,
            //         "rule_type": 'invoice_matching',
            //         "auto_reconcile": True,
            //         "match_nature": 'both',
            //         "match_same_currency": True,
            //         "allow_payment_tolerance": True,
            //         "payment_tolerance_type": 'percentage',
            //         "payment_tolerance_param": 0,
            //         "match_partner": True,
            //     },
            //     "reconcile_partial_underpaid": {
            //         "name": _('Invoices/Bills Partial Match if Underpaid'),
            //         "sequence": 2,
            //         "rule_type": 'invoice_matching',
            //         "auto_reconcile": False,
            //         "match_nature": 'both',
            //         "match_same_currency": True,
            //         "allow_payment_tolerance": False,
            //         "match_partner": True,
            //     },
            //     "reconcile_bill": {
            //         "name": _('Create Bill'),
            //         "sequence": 5,
            //         "rule_type": 'writeoff_button',
            //         'counterpart_type': 'purchase',
            //         'line_ids': [
            //             Command.create({
            //                 'amount_type': 'percentage_st_line',
            //                 'amount_string': '100',
            //             }),
            //         ],
            //     },
            //     'internal_transfer_reco': {
            //         'name': _('Internal Transfers'),
            //         'rule_type': 'writeoff_button',
            //         'line_ids': [
            //             Command.create({
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': _('Internal Transfers'),
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_tax_group(self, template_code):
            // return self._parse_csv(template_code, 'account.tax.group')
            */
            return default;
        }

        public async Task<TEntity> GetAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_account_tax(self, template_code):
            // tax_data = self._parse_csv(template_code, 'account.tax')
            // self._deref_account_tags(template_code, tax_data)
            // return tax_data
            */
            return default;
        }

        public async Task<TEntity> GetAccountsDataValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object bank_prefix, object code_digits) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_accounts_data_values(self, company, template_data, bank_prefix='', code_digits=0):
            // bank_prefix = bank_prefix or company.bank_account_code_prefix
            // code_digits = code_digits or int(template_data.get('code_digits', 6))
            // return {
            //     'account_journal_suspense_account_id': {
            //         'name': _("Bank Suspense Account"),
            //         'prefix': bank_prefix,
            //         'code_digits': code_digits,
            //         'account_type': 'asset_current',
            //     },
            //     'account_journal_early_pay_discount_loss_account_id': {
            //         'name': _("Cash Discount Loss"),
            //         'code': '999998',
            //         'account_type': 'expense',
            //     },
            //     'account_journal_early_pay_discount_gain_account_id': {
            //         'name': _("Cash Discount Gain"),
            //         'code': '999997',
            //         'account_type': 'income_other',
            //     },
            //     'default_cash_difference_income_account_id': {
            //         'name': _("Cash Difference Gain"),
            //         'prefix': '999',
            //         'code_digits': code_digits,
            //         'account_type': 'income_other',
            //         'tag_ids': [(6, 0, self.ref('account.account_tag_investing').ids)],
            //     },
            //     'default_cash_difference_expense_account_id': {
            //         'name': _("Cash Difference Loss"),
            //         'prefix': '999',
            //         'code_digits': code_digits,
            //         'account_type': 'expense',
            //         'tag_ids': [(6, 0, self.ref('account.account_tag_investing').ids)],
            //     },
            //     'transfer_account_id': {
            //         'name': _("Liquidity Transfer"),
            //         'prefix': company.transfer_account_code_prefix,
            //         'code_digits': code_digits,
            //         'account_type': 'asset_current',
            //         'reconcile': True,
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_mx, FILE: template_mx.py) ---
            // def _get_accounts_data_values(self, company, template_data, bank_prefix='', code_digits=0):
            // accounts_data = super()._get_accounts_data_values(company, template_data, bank_prefix=bank_prefix, code_digits=code_digits)
            // if company.account_fiscal_country_id.code == 'MX':
            //     accounts_data.update({
            //         'default_cash_difference_income_account_id': {
            //             'name': _('Other Income'),
            //             'code': '403.01.01'
            //         },
            //         'default_cash_difference_expense_account_id': {
            //             'name': 'Cash Difference Loss',
            //             'code': '601.84.02',
            //         }
            //     })
            // return accounts_data
            */
            return default;
        }

        public async Task<TEntity> GetAeAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ae, FILE: template_ae.py) ---
            // def _get_ae_account_account(self):
            // return {
            //     "uae_account_100101": {
            //         'allowed_journal_ids': [Command.link('ifrs16')],
            //     },
            //     "uae_account_100102": {
            //         'allowed_journal_ids': [Command.link('ifrs16')],
            //     },
            //     "uae_account_400070": {
            //         'allowed_journal_ids': [Command.link('ifrs16')],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAeAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ae, FILE: template_ae.py) ---
            // def _get_ae_account_journal(self):
            // """ If UAE chart, we add 2 new journals TA and IFRS"""
            // return {
            //     "tax_adjustment":{
            //         "name": "Tax Adjustments",
            //         "code": "TA",
            //         "type": "general",
            //         "show_on_dashboard": True,
            //         "sequence": 1,
            //     },
            //     "ifrs16": {
            //         "name": "IFRS 16",
            //         "code": "IFRS",
            //         "type": "general",
            //         "show_on_dashboard": True,
            //         "sequence": 10,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ae, FILE: template_ae.py) ---
            // def _get_ae_res_company(self):
            // sales_tax_xmlid = {
            //     'AZ': 'uae_sale_tax_5_abu_dhabi',
            //     'AJ': 'uae_sale_tax_5_ajman',
            //     'DU': 'uae_sale_tax_5_dubai',
            //     'FU': 'uae_sale_tax_5_fujairah',
            //     'RK': 'uae_sale_tax_5_ras_al_khaima',
            //     'SH': 'uae_sale_tax_5_sharjah',
            //     'UQ': 'uae_sale_tax_5_umm_al_quwain',
            // }.get(self.env.company.state_id.code, 'uae_sale_tax_5_abu_dhabi')
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ae',
            //         'bank_account_code_prefix': '101',
            //         'cash_account_code_prefix': '105',
            //         'transfer_account_code_prefix': '100',
            //         'account_default_pos_receivable_account_id': 'uae_account_102012',
            //         'income_currency_exchange_account_id': 'uae_account_500011',
            //         'expense_currency_exchange_account_id': 'uae_account_400053',
            //         'account_journal_early_pay_discount_loss_account_id': 'uae_account_400071',
            //         'account_journal_early_pay_discount_gain_account_id': 'uae_account_500014',
            //         'account_sale_tax_id': sales_tax_xmlid,
            //         'account_purchase_tax_id': 'uae_purchase_tax_5',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ae, FILE: template_ae.py) ---
            // def _get_ae_template_data(self):
            // return {
            //     'property_account_receivable_id': 'uae_account_102011',
            //     'property_account_payable_id': 'uae_account_201002',
            //     'property_account_expense_categ_id': 'uae_account_400001',
            //     'property_account_income_categ_id': 'uae_account_500001',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_base.py) ---
            // def _get_ar_account_journal(self):
            // """ In case of an Argentinean CoA, we modify the default values of the sales journal to be a preprinted journal"""
            // return {
            //     'sale': {
            //         "name": self.env._("Ventas Preimpreso"),
            //         "code": "0001",
            //         "l10n_ar_afip_pos_number": 1,
            //         "l10n_ar_afip_pos_partner_id": self.env.company.partner_id.id,
            //         "l10n_ar_afip_pos_system": 'II_IM',
            //         "refund_sequence": False,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArBaseResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_base.py) ---
            // def _get_ar_base_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ar',
            //         'bank_account_code_prefix': '1.1.1.02.',
            //         'cash_account_code_prefix': '1.1.1.01.',
            //         'transfer_account_code_prefix': '6.0.00.00.',
            //         'account_default_pos_receivable_account_id': 'base_deudores_por_ventas_pos',
            //         'income_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //         'expense_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_base_res_company(self):
            // res = super()._get_ar_base_res_company()
            // res[self.env.company.id].update({'l10n_ar_tax_base_account_id': 'base_tax_account'})
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetArBaseTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_base.py) ---
            // def _get_ar_base_template_data(self):
            // return {
            //     'property_account_receivable_id': 'base_deudores_por_ventas',
            //     'property_account_payable_id': 'base_proveedores',
            //     'property_account_expense_categ_id': 'base_compra_mercaderia',
            //     'property_account_income_categ_id': 'base_venta_de_mercaderia',
            //     'name': _('Generic Chart of Accounts Argentina Single Taxpayer / Basis'),
            //     'code_digits': '12',
            //     'sequence': 1,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArBaseWithholdingAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_base_withholding_account_account(self):
            // return self._parse_csv('ar_base', 'account.account', module='l10n_ar_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetArExResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_ex.py) ---
            // def _get_ar_ex_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ar',
            //         'bank_account_code_prefix': '1.1.1.02.',
            //         'cash_account_code_prefix': '1.1.1.01.',
            //         'transfer_account_code_prefix': '6.0.00.00.',
            //         'account_default_pos_receivable_account_id': 'base_deudores_por_ventas_pos',
            //         'income_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //         'expense_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArExTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_ex.py) ---
            // def _get_ar_ex_template_data(self):
            // return {
            //     'name': _('Argentine Generic Chart of Accounts for Exempt Individuals'),
            //     'parent': 'ar_base',
            //     'code_digits': '12',
            //     'sequence': 2,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArExWithholdingAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_ex_withholding_account_tax_group(self):
            // return self._parse_csv('ar_ex', 'account.tax.group', module='l10n_ar_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetArExWithholdingAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_ex_withholding_account_tax(self):
            // additional = self._parse_csv('ar_ex', 'account.tax', module='l10n_ar_withholding')
            // self._deref_account_tags('ar_ex', additional)
            // return additional
            */
            return default;
        }

        public async Task<TEntity> GetArResponsibilityMatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chart_template) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: account_chart_template.py) ---
            // def _get_ar_responsibility_match(self, chart_template):
            // """ return responsibility type that match with the given chart_template code
            // """
            // match = {
            //     'ar_base': self.env.ref('l10n_ar.res_RM'),
            //     'ar_ex': self.env.ref('l10n_ar.res_IVAE'),
            //     'ar_ri': self.env.ref('l10n_ar.res_IVARI'),
            // }
            // return match.get(chart_template)
            */
            return default;
        }

        public async Task<TEntity> GetArRiResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_ri.py) ---
            // def _get_ar_ri_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ar',
            //         'bank_account_code_prefix': '1.1.1.02.',
            //         'cash_account_code_prefix': '1.1.1.01.',
            //         'transfer_account_code_prefix': '6.0.00.00.',
            //         'account_default_pos_receivable_account_id': 'base_deudores_por_ventas_pos',
            //         'income_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //         'expense_currency_exchange_account_id': 'base_diferencias_de_cambio',
            //         'account_sale_tax_id': 'ri_tax_vat_21_ventas',
            //         'account_purchase_tax_id': 'ri_tax_vat_21_compras',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArRiTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: template_ar_ri.py) ---
            // def _get_ar_ri_template_data(self):
            // return {
            //     'name': _('Argentine Generic Chart of Accounts for Registered Accountants'),
            //     'parent': 'ar_ex',
            //     'code_digits': '12',
            //     'sequence': 0,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetArRiWithholdingAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_ri_withholding_account_tax_group(self):
            // return self._parse_csv('ar_ri', 'account.tax.group', module='l10n_ar_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetArRiWithholdingAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_withholding, FILE: account_chart_template.py) ---
            // def _get_ar_ri_withholding_account_tax(self):
            // additional = self._parse_csv('ar_ri', 'account.tax', module='l10n_ar_withholding')
            // self._deref_account_tags('ar_ri', additional)
            // return additional
            */
            return default;
        }

        public async Task<TEntity> GetAtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_at, FILE: template_at.py) ---
            // def _get_at_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.at',
            //         'bank_account_code_prefix': '280',
            //         'cash_account_code_prefix': '270',
            //         'transfer_account_code_prefix': '288',
            //         'account_default_pos_receivable_account_id': 'chart_at_template_2099',
            //         'income_currency_exchange_account_id': 'chart_at_template_4860',
            //         'expense_currency_exchange_account_id': 'chart_at_template_7860',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart_at_template_5800',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart_at_template_8350',
            //         'external_report_layout_id': 'l10n_din5008.external_layout_din5008',
            //         'paperformat_id': 'l10n_din5008.paperformat_euro_din',
            //         'account_sale_tax_id': 'account_tax_template_sales_20_code022',
            //         'account_purchase_tax_id': 'account_tax_template_purchase_20_code060',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_at, FILE: template_at.py) ---
            // def _get_at_template_data(self):
            // return {
            //     'visible': True,
            //     'property_account_receivable_id': 'chart_at_template_2000',
            //     'property_account_payable_id': 'chart_at_template_3300',
            //     'property_account_income_categ_id': 'chart_at_template_4000',
            //     'property_account_expense_categ_id': 'chart_at_template_5010',
            //     'property_stock_account_input_categ_id': 'chart_at_template_3740',
            //     'property_stock_account_output_categ_id': 'chart_at_template_5000',
            //     'property_stock_valuation_account_id': 'chart_at_template_1600',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAuResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_au, FILE: template_au.py) ---
            // def _get_au_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.au',
            //         'bank_account_code_prefix': '1111',
            //         'cash_account_code_prefix': '1113',
            //         'transfer_account_code_prefix': '11170',
            //         'account_default_pos_receivable_account_id': 'au_11201',
            //         'income_currency_exchange_account_id': 'au_61640',
            //         'expense_currency_exchange_account_id': 'au_61630',
            //         'account_journal_early_pay_discount_loss_account_id': 'au_61610',
            //         'account_journal_early_pay_discount_gain_account_id': 'au_61620',
            //         'fiscalyear_last_month': '6',
            //         'fiscalyear_last_day': 30,
            //         # Changing the opening date to the first day of the fiscal year.
            //         # This way the opening entries will be set to the 30th of June.
            //         'account_opening_date': fields.Date.context_today(self).replace(month=7, day=1),
            //         'account_sale_tax_id': 'au_tax_sale_10',
            //         'account_purchase_tax_id': 'au_tax_purchase_10_service',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAuTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_au, FILE: template_au.py) ---
            // def _get_au_template_data(self):
            // return {
            //     'code_digits': '5',
            //     'property_account_receivable_id': 'au_11200',
            //     'property_stock_account_production_cost_id': 'au_11350',
            //     'property_account_payable_id': 'au_21200',
            //     'property_account_expense_categ_id': 'au_51110',
            //     'property_account_income_categ_id': 'au_41110',
            //     'property_stock_account_input_categ_id': 'au_21210',
            //     'property_stock_account_output_categ_id': 'au_11340',
            //     'property_stock_valuation_account_id': 'au_11330',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBdAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bd, FILE: template_bd.py) ---
            // def _get_bd_account_journal(self):
            // return {
            //     "tax_adjustment": {
            //         "name": "Tax Adjustments",
            //         "code": "TA",
            //         "type": "general",
            //         "show_on_dashboard": True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBdResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bd, FILE: template_bd.py) ---
            // def _get_bd_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.bd',
            //         'bank_account_code_prefix': '10010',
            //         'cash_account_code_prefix': '10010',
            //         'account_default_pos_receivable_account_id': 'l10n_bd_100202',
            //         'account_journal_suspense_account_id': 'l10n_bd_100102',
            //         'default_cash_difference_income_account_id': 'l10n_bd_400302',
            //         'default_cash_difference_expense_account_id': 'l10n_bd_500909',
            //         'income_currency_exchange_account_id': 'l10n_bd_400301',
            //         'expense_currency_exchange_account_id': 'l10n_bd_500903',
            //         'transfer_account_id': 'l10n_bd_100101',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_bd_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_bd_400304',
            //         'account_sale_tax_id': 'VAT_S_IN_BD_10',
            //         'account_purchase_tax_id': 'VAT_P_IN_BD_10'
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBdTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bd, FILE: template_bd.py) ---
            // def _get_bd_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_bd_100201',
            //     'property_account_payable_id': 'l10n_bd_200101',
            //     'property_account_expense_categ_id': 'l10n_bd_500200',
            //     'property_account_income_categ_id': 'l10n_bd_400100'
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be.py) ---
            // def _get_be_account_journal(self):
            // return {
            //     'sale': {'refund_sequence': True},
            //     'purchase': {'refund_sequence': True},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeAssoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be_asso.py) ---
            // def _get_be_asso_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.be',
            //         'bank_account_code_prefix': '550',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '580',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeAssoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be_asso.py) ---
            // def _get_be_asso_template_data(self):
            // return {
            //     'name': _('Associations and Foundations'),
            //     'parent': 'be',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeCompResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be_comp.py) ---
            // def _get_be_comp_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.be',
            //         'bank_account_code_prefix': '550',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '580',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeCompTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be_comp.py) ---
            // def _get_be_comp_template_data(self):
            // return {
            //     'name': _('Companies'),
            //     'parent': 'be',
            //     'code_digits': '6',
            //     'sequence': 0,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBePosRestaurantAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be_pos_restaurant, FILE: template_be.py) ---
            // def _get_be_pos_restaurant_account_tax(self):
            // be_restaurant_tax = self._parse_csv('be', 'account.tax', module='l10n_be_pos_restaurant')
            // existing_taxes = self.env['account.tax'].search([('company_id', 'child_of', self.env.company.root_id.id)])
            // # Filter out taxes that already exist
            // existing_tax_names = set(existing_taxes.mapped('name'))
            // taxes_to_create = {name: tax for name, tax in be_restaurant_tax.items() if tax['name'] not in existing_tax_names}
            // self._deref_account_tags('be_comp', be_restaurant_tax)
            // return taxes_to_create
            */
            return default;
        }

        public async Task<TEntity> GetBeReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be.py) ---
            // def _get_be_reconcile_model(self):
            // return {
            //     'escompte_template': {
            //         'name': 'Cash Discount',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'a653',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Cash Discount Granted',
            //             }),
            //         ],
            //         'name@fr': 'Escompte',
            //         'name@nl': 'Betalingskorting',
            //         'name@de': 'Skonto',
            //     },
            //     'frais_bancaires_htva_template': {
            //         'name': 'Bank Fees (No VAT)',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'a6560',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Bank Fees (No VAT)',
            //             }),
            //         ],
            //         'name@fr': 'Frais bancaires (Hors TVA)',
            //         'name@nl': 'Bankkosten (Geen BTW)',
            //         'name@de': 'Bankgebühren (Ohne MwSt.)',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be.py) ---
            // def _get_be_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.be',
            //         'bank_account_code_prefix': '550',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '580',
            //         'account_default_pos_receivable_account_id': 'a4001',
            //         'income_currency_exchange_account_id': 'a754',
            //         'expense_currency_exchange_account_id': 'a654',
            //         'account_journal_suspense_account_id': 'a499',
            //         'account_journal_early_pay_discount_loss_account_id': 'a657000',
            //         'account_journal_early_pay_discount_gain_account_id': 'a757000',
            //         'account_sale_tax_id': 'attn_VAT-OUT-21-L',
            //         'account_purchase_tax_id': 'attn_VAT-IN-V81-21',
            //         'default_cash_difference_income_account_id': 'a757100',
            //         'default_cash_difference_expense_account_id': 'a657100',
            //         'transfer_account_id': 'a58',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: template_be.py) ---
            // def _get_be_template_data(self):
            // return {
            //     'name': _('Base'),
            //     'visible': False,
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'a400',
            //     'property_account_payable_id': 'a440',
            //     'property_account_expense_categ_id': 'a600',
            //     'property_account_income_categ_id': 'a7000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBfAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf.py) ---
            // def _get_bf_account_account(self):
            // return self._parse_csv('bf', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetBfResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf.py) ---
            // def _get_bf_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.bf',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetBfSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf_syscebnl.py) ---
            // def _get_bf_syscebnl_account_account(self):
            // return self._parse_csv('bf_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetBfSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf_syscebnl.py) ---
            // def _get_bf_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.bf',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetBfSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf_syscebnl.py) ---
            // def _get_bf_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBfTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bf, FILE: template_bf.py) ---
            // def _get_bf_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bg, FILE: template_bg.py) ---
            // def _get_bg_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.bg',
            //         'bank_account_code_prefix': '503',
            //         'cash_account_code_prefix': '501',
            //         'transfer_account_code_prefix': '430',
            //         'income_currency_exchange_account_id': 'l10n_bg_624',
            //         'expense_currency_exchange_account_id': 'l10n_bg_624',
            //         'account_sale_tax_id': 'l10n_bg_sale_vat_20',
            //         'account_purchase_tax_id': 'l10n_bg_purchase_vat_20_ptc',
            //         'account_default_pos_receivable_account_id': 'l10n_bg_4111',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bg, FILE: template_bg.py) ---
            // def _get_bg_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_bg_411',
            //     'property_account_payable_id': 'l10n_bg_401',
            //     'property_account_expense_categ_id': 'l10n_bg_601',
            //     'property_account_income_categ_id': 'l10n_bg_701',
            //     'default_cash_difference_income_account_id': 'l10n_bg_791001',
            //     'default_cash_difference_expense_account_id': 'l10n_bg_691001',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBhResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bh, FILE: template_bh.py) ---
            // def _get_bh_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.bh',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1009',
            //         'transfer_account_code_prefix': '1001',
            //         'account_default_pos_receivable_account_id': 'bh_account_100202',
            //         'income_currency_exchange_account_id': 'bh_account_400301',
            //         'expense_currency_exchange_account_id': 'bh_account_500903',
            //         'account_journal_suspense_account_id': 'bh_account_100102',
            //         'account_journal_early_pay_discount_loss_account_id': 'bh_account_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'bh_account_400304',
            //         'default_cash_difference_income_account_id': 'bh_account_400302',
            //         'default_cash_difference_expense_account_id': 'bh_account_500909',
            //         'deferred_expense_account_id': 'bh_account_100416',
            //         'deferred_revenue_account_id': 'bh_account_200401',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBhTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bh, FILE: template_bh.py) ---
            // def _get_bh_template_data(self):
            // return {
            //     'property_account_receivable_id': 'bh_account_100201',
            //     'property_account_payable_id': 'bh_account_200101',
            //     'property_account_expense_categ_id': 'bh_account_500101',
            //     'property_account_income_categ_id': 'bh_account_400101',
            //     'property_account_expense_id': 'bh_account_500101',
            //     'property_account_income_id': 'bh_account_400101',
            //     'property_stock_valuation_account_id': 'bh_account_100502',
            //     'property_stock_account_input_categ_id': 'bh_account_100503',
            //     'property_stock_account_output_categ_id': 'bh_account_100504',
            //     'property_stock_account_production_cost_id': 'bh_account_100505',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBjAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj.py) ---
            // def _get_bj_account_account(self):
            // return self._parse_csv('bj', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetBjResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj.py) ---
            // def _get_bj_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.bj',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetBjSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj_syscebnl.py) ---
            // def _get_bj_syscebnl_account_account(self):
            // return self._parse_csv('bj_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetBjSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj_syscebnl.py) ---
            // def _get_bj_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.bj',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetBjSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj_syscebnl.py) ---
            // def _get_bj_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBjTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bj, FILE: template_bj.py) ---
            // def _get_bj_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bo, FILE: template_bo.py) ---
            // def _get_bo_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.bo',
            //         'bank_account_code_prefix': '11130',
            //         'cash_account_code_prefix': '11110',
            //         'transfer_account_code_prefix': '11110',
            //         'account_default_pos_receivable_account_id': 'l10n_bo_11211',
            //         'income_currency_exchange_account_id': 'l10n_bo_4303',
            //         'expense_currency_exchange_account_id': 'l10n_bo_5602',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_bo_5104',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_bo_4102',
            //         'default_cash_difference_income_account_id': 'l10n_bo_4301',
            //         'default_cash_difference_expense_account_id': 'l10n_bo_5601',
            //         'account_sale_tax_id': 'l10n_bo_iva_13_sale',
            //         'account_purchase_tax_id': 'l10n_bo_iva_13_purchase',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_bo, FILE: template_bo.py) ---
            // def _get_bo_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'l10n_bo_1121',
            //     'property_account_payable_id': 'l10n_bo_2121',
            //     'property_account_expense_categ_id': 'l10n_bo_53008',
            //     'property_account_income_categ_id': 'l10n_bo_4101',
            //     'property_stock_account_input_categ_id': 'l10n_bo_11341',
            //     'property_stock_account_output_categ_id': 'l10n_bo_11342',
            //     'property_stock_valuation_account_id': 'l10n_bo_1131',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBrAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_br, FILE: template_br.py) ---
            // def _get_br_account_journal(self):
            // return {
            //     'sale': {
            //         'l10n_br_invoice_serial': '1',
            //         'refund_sequence': False,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_br, FILE: template_br.py) ---
            // def _get_br_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.br',
            //         'bank_account_code_prefix': '1.01.01.02.00',
            //         'cash_account_code_prefix': '1.01.01.01.00',
            //         'transfer_account_code_prefix': '1.01.01.12.00',
            //         'account_default_pos_receivable_account_id': 'account_template_101010402',
            //         'income_currency_exchange_account_id': 'br_3_01_01_05_01_47',
            //         'expense_currency_exchange_account_id': 'br_3_11_01_09_01_40',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_template_31101010202',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_template_30101050148',
            //         'account_sale_tax_id': 'tax_template_out_icms_interno17',
            //         'account_purchase_tax_id': 'tax_template_in_icms_interno17',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_br, FILE: template_br.py) ---
            // def _get_br_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'account_template_101010401',
            //     'property_account_payable_id': 'account_template_201010301',
            //     'property_account_expense_categ_id': 'account_template_30101030101',
            //     'property_account_income_categ_id': 'account_template_30101010105',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ca, FILE: template_ca.py) ---
            // def _get_ca_res_company(self):
            // 
            // default_sales_tax, default_purchase_tax = {
            //     'BC': ('gstpst_sale_tax_12_bc', 'gstpst_purchase_tax_12_bc'),
            //     'MB': ('gstpst_sale_tax_12_mb', 'gstpst_purchase_tax_12_mb'),
            //     'QC': ('gstqst_sale_tax_14975', 'gstqst_purchase_tax_14975'),
            //     'SK': ('gstpst_sale_tax_11', 'gstpst_purchase_tax_11'),
            //     'ON': ('hst_sale_tax_13', 'hst_purchase_tax_13'),
            //     'NB': ('hst_sale_tax_15', 'hst_purchase_tax_15'),
            //     'NL': ('hst_sale_tax_15', 'hst_purchase_tax_15'),
            //     'NS': ('hst_sale_tax_15', 'hst_purchase_tax_15'),
            //     'PE': ('hst_sale_tax_15', 'hst_purchase_tax_15'),
            // }.get(self.env.company.state_id.code, ('gst_sale_tax_5', 'gst_purchase_tax_5'))
            // 
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.ca',
            //         'bank_account_code_prefix': '11131',
            //         'cash_account_code_prefix': '11121',
            //         'transfer_account_code_prefix': '1111',
            //         'account_default_pos_receivable_account_id': 'l10n_ca_112113',
            //         'income_currency_exchange_account_id': 'l10n_ca_423100',
            //         'expense_currency_exchange_account_id': 'l10n_ca_522100',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_ca_522200',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_ca_423200',
            //         'account_sale_tax_id': default_sales_tax,
            //         'account_purchase_tax_id': default_purchase_tax,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ca, FILE: template_ca.py) ---
            // def _get_ca_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_ca_112110',
            //     'property_account_payable_id': 'l10n_ca_221110',
            //     'property_account_income_categ_id': 'l10n_ca_411100',
            //     'property_account_expense_categ_id': 'l10n_ca_511210',
            //     'property_stock_account_input_categ_id': 'l10n_ca_121130',
            //     'property_stock_account_output_categ_id': 'l10n_ca_121140',
            //     'property_stock_valuation_account_id': 'l10n_ca_121120',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCdAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd.py) ---
            // def _get_cd_account_account(self):
            // return self._parse_csv('cd', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCdResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd.py) ---
            // def _get_cd_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cd',
            //         'account_sale_tax_id': 'tva_sale_16',
            //         'account_purchase_tax_id': 'tva_purchase_good_16',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCdSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd_syscebnl.py) ---
            // def _get_cd_syscebnl_account_account(self):
            // return self._parse_csv('cd_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCdSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd_syscebnl.py) ---
            // def _get_cd_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cd',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_16',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_good_16',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCdSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd_syscebnl.py) ---
            // def _get_cd_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCdTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cd, FILE: template_cd.py) ---
            // def _get_cd_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCfAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf.py) ---
            // def _get_cf_account_account(self):
            // return self._parse_csv('cf', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCfResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf.py) ---
            // def _get_cf_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cf',
            //         'account_sale_tax_id': 'tva_sale_19',
            //         'account_purchase_tax_id': 'tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCfSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf_syscebnl.py) ---
            // def _get_cf_syscebnl_account_account(self):
            // return self._parse_csv('cf_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCfSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf_syscebnl.py) ---
            // def _get_cf_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cf',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_19',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCfTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf.py) ---
            // def _get_cf_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_cf, FILE: template_cf_syscebnl.py) ---
            // def _get_cf_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCgAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg.py) ---
            // def _get_cg_account_account(self):
            // return self._parse_csv('cg', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg.py) ---
            // def _get_cg_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cg',
            //         'account_sale_tax_id': 'tva_sale_18_9',
            //         'account_purchase_tax_id': 'tva_purchase_18_9',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCgSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg_syscebnl.py) ---
            // def _get_cg_syscebnl_account_account(self):
            // return self._parse_csv('cg_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCgSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg_syscebnl.py) ---
            // def _get_cg_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cg',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18_9',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18_9',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCgSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg_syscebnl.py) ---
            // def _get_cg_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cg, FILE: template_cg.py) ---
            // def _get_cg_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetChResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ch, FILE: template_ch.py) ---
            // def _get_ch_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ch',
            //         'bank_account_code_prefix': '102',
            //         'cash_account_code_prefix': '100',
            //         'transfer_account_code_prefix': '1090',
            //         'account_default_pos_receivable_account_id': 'ch_coa_1101',
            //         'income_currency_exchange_account_id': 'ch_coa_3806',
            //         'expense_currency_exchange_account_id': 'ch_coa_4906',
            //         'account_journal_early_pay_discount_loss_account_id': 'ch_coa_4901',
            //         'account_journal_early_pay_discount_gain_account_id': 'ch_coa_3801',
            //         'default_cash_difference_expense_account_id': 'ch_coa_4991',
            //         'default_cash_difference_income_account_id': 'ch_coa_4992',
            //         'account_sale_tax_id': 'vat_sale_81',
            //         'account_purchase_tax_id': 'vat_purchase_81',
            //         'external_report_layout_id': 'l10n_din5008.external_layout_din5008',
            //         'paperformat_id': 'l10n_din5008.paperformat_euro_din',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetChTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ch, FILE: template_ch.py) ---
            // def _get_ch_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'ch_coa_1100',
            //     'property_account_payable_id': 'ch_coa_2000',
            //     'property_account_expense_categ_id': 'ch_coa_4200',
            //     'property_account_income_categ_id': 'ch_coa_3200',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetChartTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_chart_template_data(self, template_code):
            // template_data = defaultdict(lambda: defaultdict(dict))
            // template_data['res.company']  # ensure it's the first property when iterating
            // translatable_model_fields = self._get_translatable_template_model_fields()
            // untranslatable_model_fields = self._get_untranslatable_fields_to_translate()
            // for code in [None] + self._get_parent_template(template_code):
            //     for model, funcs in sorted(
            //         self._template_register[code].items(),
            //         key=lambda i: TEMPLATE_MODELS.index(i[0]) if i[0] in TEMPLATE_MODELS else 1000
            //     ):
            //         translatable_fields = translatable_model_fields.get(model, [])
            //         untranslatable_fields = untranslatable_model_fields.get(model, [])
            //         for func in funcs:
            //             data = func(self, template_code)
            //             if data is not None:
            //                 if model == 'template_data':
            //                     template_data[model].update(data)
            //                 else:
            //                     for xmlid, record in data.items():
            //                         # Store information about which module each field value originates from (for code translations).
            //                         # The final value of different fields may be determined by different functions.
            //                         # The last function to modify the record may not modify all or any of the translatable fields.
            //                         for field in translatable_fields + untranslatable_fields:
            //                             if field in record:
            //                                 record.setdefault('__translation_module__', {})[field] = func._module
            // 
            //                         template_data[model][xmlid].update(record)
            // return template_data
            */
            return default;
        }

        public async Task<TEntity> GetChartTemplateMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object get_all) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_chart_template_mapping(self, get_all=False):
            // """Get basic information about available CoA and their modules.
            // 
            // :return: a mapping between the template code and a dictionary containing the
            //          name, country id, country name, module dependencies and parent template
            // :rtype: dict[str, dict]
            // """
            // # This function is called many times. Avoid doing a search every time by using the ORM's cache.
            // # We assume that the field is always computed for all the modules at once (by this function)
            // field = self.env['ir.module.module']._fields['account_templates']
            // modules = (
            //     self.env.cache.get_records(self.env['ir.module.module'], field)
            //     or self.env['ir.module.module'].sudo().search([])
            // )
            // 
            // return {
            //     name: template
            //     for mapping in modules.mapped('account_templates')
            //     for name, template in mapping.items()
            //     if get_all or template['visible']
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCiAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci.py) ---
            // def _get_ci_account_account(self):
            // return self._parse_csv('ci', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCiResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci.py) ---
            // def _get_ci_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ci',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCiSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci_syscebnl.py) ---
            // def _get_ci_syscebnl_account_account(self):
            // return self._parse_csv('ci_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCiSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci_syscebnl.py) ---
            // def _get_ci_syscebnl_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ci',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCiSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci_syscebnl.py) ---
            // def _get_ci_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCiTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ci, FILE: template_ci.py) ---
            // def _get_ci_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetClResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cl, FILE: template_cl.py) ---
            // def _get_cl_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.cl',
            //         'bank_account_code_prefix': '1101',
            //         'cash_account_code_prefix': '1101',
            //         'transfer_account_code_prefix': '117',
            //         'account_default_pos_receivable_account_id': 'account_110421',
            //         'income_currency_exchange_account_id': 'account_320265',
            //         'expense_currency_exchange_account_id': 'account_410195',
            //         'tax_calculation_rounding_method': 'round_globally',
            //         'account_sale_tax_id': 'ITAX_19',
            //         'account_purchase_tax_id': 'OTAX_19',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetClTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cl, FILE: template_cl.py) ---
            // def _get_cl_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'account_110310',
            //     'property_account_payable_id': 'account_210210',
            //     'property_account_expense_categ_id': 'account_410235',
            //     'property_account_income_categ_id': 'account_310115',
            //     'property_stock_account_input_categ_id': 'account_210230',
            //     'property_stock_account_output_categ_id': 'account_110640',
            //     'property_stock_valuation_account_id': 'account_110610',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCmAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm.py) ---
            // def _get_cm_account_account(self):
            // return self._parse_csv('cm', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCmResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm.py) ---
            // def _get_cm_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cm',
            //         'account_sale_tax_id': 'tva_sale_19_25',
            //         'account_purchase_tax_id': 'tva_purchase_good_19_25',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCmSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm_syscebnl.py) ---
            // def _get_cm_syscebnl_account_account(self):
            // return self._parse_csv('cm_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetCmSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm_syscebnl.py) ---
            // def _get_cm_syscebnl_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.cm',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_19_25',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_good_19_25',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetCmSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm_syscebnl.py) ---
            // def _get_cm_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCmTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cm, FILE: template_cm.py) ---
            // def _get_cm_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn_common.py) ---
            // def _get_cn_account_journal(self):
            // return {
            //     'cash': {'default_account_id': 'l10n_cn_common_account_1001'},
            //     'bank': {'default_account_id': 'l10n_cn_common_account_1002'},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnCommonResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn_common.py) ---
            // def _get_cn_common_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cn',
            //         'bank_account_code_prefix': '1002',
            //         'cash_account_code_prefix': '1001',
            //         'deferred_expense_account_id': 'l10n_cn_common_account_1801',
            //         'deferred_revenue_account_id': 'l10n_cn_common_account_2401',
            //         'account_default_pos_receivable_account_id': 'l10n_cn_common_account_112201',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnCommonTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn_common.py) ---
            // def _get_cn_common_template_data(self):
            // return {
            //     'name': _('Common'),
            //     'visible': 0,
            //     'code_digits': 6,
            //     'use_storno_accounting': True,
            //     'property_account_receivable_id': 'l10n_cn_common_account_1122',
            //     'property_account_payable_id': 'l10n_cn_common_account_2202',
            //     'property_stock_valuation_account_id': 'l10n_cn_common_account_1405',
            //     'property_stock_account_production_cost_id': 'l10n_cn_common_account_1411',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnLargeBisCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn_large_bis.py) ---
            // def _get_cn_large_bis_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cn',
            //         'transfer_account_code_prefix': '1004',
            //         'income_currency_exchange_account_id': 'l10n_cn_large_bis_account_6061',
            //         'expense_currency_exchange_account_id': 'l10n_cn_large_bis_account_6061',
            //         'account_journal_suspense_account_id': 'l10n_cn_large_bis_account_100201',
            //         'transfer_account_id': 'l10n_cn_large_bis_account_1004',
            //         'account_production_wip_account_id': 'l10n_cn_large_bis_account_140501',
            //         'default_cash_difference_income_account_id': 'l10n_cn_large_bis_account_630101',
            //         'default_cash_difference_expense_account_id': 'l10n_cn_large_bis_account_671101',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_cn_large_bis_account_630102',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_cn_large_bis_account_671102',
            //         'account_production_wip_overhead_account_id': 'l10n_cn_large_bis_account_140502',
            //         'account_sale_tax_id': 'l10n_cn_tax_large_bis_sales_excluded_13',
            //         'account_purchase_tax_id': 'l10n_cn_purchase_excluded_13',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnLargeBisTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn_large_bis.py) ---
            // def _get_cn_large_bis_template_data(self):
            // return {
            //     'name': _('Accounting Standards for Business Enterprises'),
            //     'parent': 'cn_common',
            //     'property_account_expense_categ_id': 'l10n_cn_large_bis_account_6401',
            //     'property_account_income_categ_id': 'l10n_cn_large_bis_account_6001',
            //     'property_stock_account_input_categ_id': 'l10n_cn_large_bis_account_140601',
            //     'property_stock_account_output_categ_id': 'l10n_cn_large_bis_account_140602',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn.py) ---
            // def _get_cn_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cn',
            //         'transfer_account_code_prefix': '1012',
            //         'income_currency_exchange_account_id': 'l10n_cn_account_530102',
            //         'expense_currency_exchange_account_id': 'l10n_cn_account_560302',
            //         'account_journal_suspense_account_id': 'l10n_cn_account_101201',
            //         'transfer_account_id': 'l10n_cn_account_101202',
            //         'account_production_wip_account_id': 'l10n_cn_account_1406',
            //         'default_cash_difference_income_account_id': 'l10n_cn_account_530103',
            //         'default_cash_difference_expense_account_id': 'l10n_cn_account_560303',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_cn_account_530104',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_cn_account_560304',
            //         'account_production_wip_overhead_account_id': 'l10n_cn_account_140601',
            //         'account_sale_tax_id': 'l10n_cn_sales_excluded_13',
            //         'account_purchase_tax_id': 'l10n_cn_purchase_excluded_13',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cn, FILE: template_cn.py) ---
            // def _get_cn_template_data(self):
            // return {
            //     'name': _('Accounting Standards for Small Business Enterprises'),
            //     'parent': 'cn_common',
            //     'property_account_expense_categ_id': 'l10n_cn_account_5401',
            //     'property_account_income_categ_id': 'l10n_cn_account_5001',
            //     'property_stock_account_input_categ_id': 'l10n_cn_account_140201',
            //     'property_stock_account_output_categ_id': 'l10n_cn_account_140202',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_co, FILE: template_co.py) ---
            // def _get_co_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.co',
            //         'bank_account_code_prefix': '1110',
            //         'cash_account_code_prefix': '1105',
            //         'transfer_account_code_prefix': '1115',
            //         'account_default_pos_receivable_account_id': 'co_puc_130507',
            //         'income_currency_exchange_account_id': 'co_puc_421005',
            //         'expense_currency_exchange_account_id': 'co_puc_530505',
            //         'account_journal_early_pay_discount_loss_account_id': 'co_puc_530535',
            //         'account_journal_early_pay_discount_gain_account_id': 'co_puc_421040',
            //         'account_sale_tax_id': 'l10n_co_tax_8',
            //         'account_purchase_tax_id': 'l10n_co_tax_1',
            //         'default_cash_difference_income_account_id': 'co_puc_428000',
            //         'default_cash_difference_expense_account_id': 'co_puc_532000',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_co, FILE: template_co.py) ---
            // def _get_co_template_data(self):
            // return {
            //     'property_account_receivable_id': 'co_puc_130500',
            //     'property_account_payable_id': 'co_puc_220500',
            //     'property_account_expense_categ_id': 'co_puc_610000',
            //     'property_account_income_categ_id': 'co_puc_417500',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cr, FILE: template_cr.py) ---
            // def _get_cr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cr',
            //         'bank_account_code_prefix': '0.1112',
            //         'cash_account_code_prefix': '0.1111',
            //         'transfer_account_code_prefix': '0.1114',
            //         'account_default_pos_receivable_account_id': 'account_account_template_0_112011',
            //         'income_currency_exchange_account_id': 'account_account_template_0_450001',
            //         'expense_currency_exchange_account_id': 'account_account_template_0_530004',
            //         'account_sale_tax_id': 'account_tax_template_IV_0',
            //         'account_purchase_tax_id': 'account_tax_template_IV_1',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cr, FILE: template_cr.py) ---
            // def _get_cr_template_data(self):
            // return {
            //     'property_account_receivable_id': 'account_account_template_0_112001',
            //     'property_account_payable_id': 'account_account_template_0_211001',
            //     'property_account_income_categ_id': 'account_account_template_0_410001',
            //     'property_account_expense_categ_id': 'account_account_template_0_511301',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCyResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cy, FILE: template_cy.py) ---
            // def _get_cy_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cy',
            //         'bank_account_code_prefix': '1200',
            //         'cash_account_code_prefix': '1231',
            //         'transfer_account_code_prefix': '1261',
            //         'account_default_pos_receivable_account_id': 'cy_1100',
            //         'income_currency_exchange_account_id': 'cy_7910',
            //         'expense_currency_exchange_account_id': 'cy_7910',
            //         'account_sale_tax_id': 'VAT_S_IN_CY_19_G',
            //         'account_purchase_tax_id': 'VAT_P_IN_CY_19_G',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCyTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cy, FILE: template_cy.py) ---
            // def _get_cy_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'cy_1100',
            //     'property_account_payable_id': 'cy_2100',
            //     'property_account_expense_categ_id': 'cy_5100',
            //     'property_account_income_categ_id': 'cy_4000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cz, FILE: template_cz.py) ---
            // def _get_cz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.cz',
            //         'bank_account_code_prefix': '221',
            //         'cash_account_code_prefix': '211',
            //         'transfer_account_code_prefix': '261',
            //         'income_currency_exchange_account_id': 'chart_cz_663000',
            //         'expense_currency_exchange_account_id': 'chart_cz_563000',
            //         'account_journal_suspense_account_id': 'chart_cz_261000',
            //         'default_cash_difference_income_account_id': 'chart_cz_668000',
            //         'default_cash_difference_expense_account_id': 'chart_cz_568000',
            //         'account_default_pos_receivable_account_id': 'chart_cz_311001',
            //         'account_sale_tax_id': 'l10n_cz_21_domestic_supplies',
            //         'account_purchase_tax_id': 'l10n_cz_21_receipt_domestic_supplies',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cz, FILE: template_cz.py) ---
            // def _get_cz_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            //     'property_account_receivable_id': 'chart_cz_311000',
            //     'property_account_payable_id': 'chart_cz_321000',
            //     'property_account_expense_categ_id': 'chart_cz_504000',
            //     'property_account_income_categ_id': 'chart_cz_604000',
            //     'property_stock_account_input_categ_id': 'chart_cz_131000',
            //     'property_stock_account_output_categ_id': 'chart_cz_504000',
            //     'property_stock_valuation_account_id': 'chart_cz_132000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: chart_template.py) ---
            // def _get_de_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'external_report_layout_id': 'l10n_din5008.external_layout_din5008',
            //         'paperformat_id': 'l10n_din5008.paperformat_euro_din',
            //         'check_account_audit_trail': True,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr03ReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr03.py) ---
            // def _get_de_skr03_reconcile_model(self):
            // return {
            //     'reconcile_3731': {
            //         'name': 'Discount-EK-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_3731',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_vst_7_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-EK-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_3736': {
            //         'name': 'Discount-EK-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_3736',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_vst_19_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-EK-19%',
            //             }),
            //         ],
            //     },
            //     'reconcile_8731': {
            //         'name': 'Discount-VK-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_8731',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_7_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-VK-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_8736': {
            //         'name': 'Discount-VK-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_8736',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_19_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-VK-19%',
            //             }),
            //         ],
            //     },
            //     'reconcile_2401': {
            //         'name': 'Loss of receivables-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_2401',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_7_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Loss of receivables-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_2406': {
            //         'name': 'Loss of receivables-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'account_2406',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_19_skr03',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Loss of receivables-19%',
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr03ResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr03.py) ---
            // def _get_de_skr03_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.de',
            //         'bank_account_code_prefix': '120',
            //         'cash_account_code_prefix': '100',
            //         'transfer_account_code_prefix': '1360',
            //         'account_default_pos_receivable_account_id': 'account_1411',
            //         'income_currency_exchange_account_id': 'account_2660',
            //         'expense_currency_exchange_account_id': 'account_2150',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_2130',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_2670',
            //         'account_sale_tax_id': 'tax_ust_19_skr03',
            //         'account_purchase_tax_id': 'tax_vst_19_skr03',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr03TemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr03.py) ---
            // def _get_de_skr03_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'account_1410',
            //     'property_account_payable_id': 'account_1610',
            //     'property_account_expense_categ_id': 'account_3400',
            //     'property_account_income_categ_id': 'account_8400',
            //     'property_stock_account_input_categ_id': 'account_3970',
            //     'property_stock_account_output_categ_id': 'account_3980',
            //     'property_stock_valuation_account_id': 'account_3960',
            //     'name': 'German Chart of Accounts SKR03',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr04ReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr04.py) ---
            // def _get_de_skr04_reconcile_model(self):
            // return {
            //     'reconcile_5731': {
            //         'name': 'Discount-EK-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_5731',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_vst_7_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-EK-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_5736': {
            //         'name': 'Discount-EK-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_5736',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_vst_19_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-EK-19%',
            //             }),
            //         ],
            //     },
            //     'reconcile_4731': {
            //         'name': 'Skonto-VK-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_4731',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_7_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-VK-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_4736': {
            //         'name': 'Discount-VK-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_4736',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_19_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Discount-VK-19%',
            //             }),
            //         ],
            //     },
            //     'reconcile_6931': {
            //         'name': 'Loss of receivables-7%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_6931',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_7_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Loss of receivables-7%',
            //             }),
            //         ],
            //     },
            //     'reconcile_6936': {
            //         'name': 'Loss of receivables-19%',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'chart_skr04_6936',
            //                 'amount_type': 'percentage',
            //                 'tax_ids': [
            //                     Command.set([
            //                         'tax_ust_19_skr04',
            //                     ]),
            //                 ],
            //                 'amount_string': '100',
            //                 'label': 'Loss of receivables-19%',
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr04ResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr04.py) ---
            // def _get_de_skr04_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.de',
            //         'bank_account_code_prefix': '180',
            //         'cash_account_code_prefix': '160',
            //         'transfer_account_code_prefix': '1460',
            //         'account_default_pos_receivable_account_id': 'chart_skr04_1206',
            //         'income_currency_exchange_account_id': 'chart_skr04_4840',
            //         'expense_currency_exchange_account_id': 'chart_skr04_6880',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart_skr04_4730',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart_skr04_5730',
            //         'default_cash_difference_income_account_id': 'chart_skr04_9991',
            //         'default_cash_difference_expense_account_id': 'chart_skr04_9994',
            //         'account_sale_tax_id': 'tax_ust_19_skr04',
            //         'account_purchase_tax_id': 'tax_vst_19_skr04',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeSkr04TemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: template_de_skr04.py) ---
            // def _get_de_skr04_template_data(self):
            // return {
            //     'name': 'German chart of accounts SKR04',
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'chart_skr04_1205',
            //     'property_account_payable_id': 'chart_skr04_3301',
            //     'property_account_expense_categ_id': 'chart_skr04_5400',
            //     'property_account_income_categ_id': 'chart_skr04_4400',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDkResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk, FILE: template_dk.py) ---
            // def _get_dk_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.dk',
            //         'bank_account_code_prefix': '648',
            //         'cash_account_code_prefix': '647',
            //         'transfer_account_code_prefix': '683',
            //         'account_default_pos_receivable_account_id': 'dk_coa_6190',
            //         'income_currency_exchange_account_id': 'dk_coa_3610',
            //         'expense_currency_exchange_account_id': 'dk_coa_3610',
            //         'account_journal_early_pay_discount_loss_account_id': 'dk_coa_2720',
            //         'account_journal_early_pay_discount_gain_account_id': 'dk_coa_2720',
            //         'account_sale_tax_id': 'tax_s1',
            //         'account_purchase_tax_id': 'tax_k1',
            //         'check_account_audit_trail': True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDkTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk, FILE: template_dk.py) ---
            // def _get_dk_template_data(self):
            // return {
            //     'property_account_receivable_id': 'dk_coa_6190',
            //     'property_account_payable_id': 'dk_coa_7440',
            //     'property_account_expense_categ_id': 'dk_coa_1610',
            //     'property_account_income_categ_id': 'dk_coa_1010',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_do, FILE: template_do.py) ---
            // def _get_do_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.do',
            //         'bank_account_code_prefix': '110102',
            //         'cash_account_code_prefix': '110101',
            //         'transfer_account_code_prefix': '11010100',
            //         'account_default_pos_receivable_account_id': 'l10n_do_11030210',
            //         'income_currency_exchange_account_id': 'l10n_do_42040100',
            //         'expense_currency_exchange_account_id': 'l10n_do_61070800',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_do_61081000',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_do_42040400',
            //         'default_cash_difference_income_account_id': 'l10n_do_42040400',
            //         'default_cash_difference_expense_account_id': 'l10n_do_61081000',
            //         'account_sale_tax_id': 'tax_18_sale',
            //         'account_purchase_tax_id': 'tax_18_purch',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_do, FILE: template_do.py) ---
            // def _get_do_template_data(self):
            // return {
            //     'code_digits': '8',
            //     'property_account_receivable_id': 'l10n_do_11030201',
            //     'property_account_payable_id': 'l10n_do_21010200',
            //     'property_account_income_categ_id': 'l10n_do_41010100',
            //     'property_account_expense_categ_id': 'l10n_do_51010100',
            //     'property_stock_account_input_categ_id': 'l10n_do_21021200',
            //     'property_stock_account_output_categ_id': 'l10n_do_11050600',
            //     'property_stock_valuation_account_id': 'l10n_do_11050100',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dz, FILE: template_dz.py) ---
            // def _get_dz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.dz',
            //         'bank_account_code_prefix': '512',
            //         'cash_account_code_prefix': '53',
            //         'transfer_account_code_prefix': '58',
            //         'account_default_pos_receivable_account_id': 'l10n_dz_412',
            //         'income_currency_exchange_account_id': 'l10n_dz_766',
            //         'expense_currency_exchange_account_id': 'l10n_dz_666',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_dz_709',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_dz_609',
            //         'default_cash_difference_income_account_id': 'l10n_dz_758',
            //         'default_cash_difference_expense_account_id': 'l10n_dz_657',
            //         'account_sale_tax_id': 'l10n_dz_vat_sale_19_prod',
            //         'account_purchase_tax_id': 'l10n_dz_vat_purchase_19',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dz, FILE: template_dz.py) ---
            // def _get_dz_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_dz_413',
            //     'property_account_payable_id': 'l10n_dz_401',
            //     'property_account_expense_categ_id': 'l10n_dz_600',
            //     'property_account_income_categ_id': 'l10n_dz_700',
            //     'code_digits': 6,
            //     'display_invoice_amount_total_words': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEcAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: template_ec.py) ---
            // def _get_ec_account_journal(self):
            // """ In case of an Ecuador, we modified the sales journal"""
            // return {
            //     'sale': {
            //         'name': "001-001 Facturas de cliente",
            //         'l10n_ec_entity': '001',
            //         'l10n_ec_emission': '001',
            //         'l10n_ec_emission_address_id': self.env.company.partner_id.id,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEcResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: template_ec.py) ---
            // def _get_ec_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ec',
            //         'bank_account_code_prefix': '11010201',
            //         'cash_account_code_prefix': '1101010',
            //         'transfer_account_code_prefix': '1101030',
            //         'account_default_pos_receivable_account_id': 'ec1102050103',
            //         'income_currency_exchange_account_id': 'ec430501',
            //         'expense_currency_exchange_account_id': 'ec520304',
            //         'account_journal_early_pay_discount_loss_account_id': 'ec_early_pay_discount_loss',
            //         'account_journal_early_pay_discount_gain_account_id': 'ec_early_pay_discount_gain',
            //         'default_cash_difference_income_account_id': 'ec_income_cash_difference',
            //         'default_cash_difference_expense_account_id': 'ec_expense_cash_difference',
            //         'account_sale_tax_id': 'tax_vat_15_411_goods',
            //         'account_purchase_tax_id': 'tax_vat_15_510_sup_01',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEcTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: template_ec.py) ---
            // def _get_ec_template_data(self):
            // return {
            //     'property_account_receivable_id': 'ec1102050101',
            //     'property_account_payable_id': 'ec210301',
            //     'property_account_expense_categ_id': 'ec110307',
            //     'journal_account_expense_categ_id': 'ec52022816',
            //     'property_account_income_categ_id': 'ec410101',
            //     'property_stock_account_input_categ_id': 'ec110307',
            //     'property_stock_account_output_categ_id': 'ec510102',
            //     'property_stock_valuation_account_id': 'ec110306',
            //     'loss_stock_valuation_account': 'ec510112',
            //     'production_stock_valuation_account': 'ec110302',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ee, FILE: template_ee.py) ---
            // def _get_ee_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ee',
            //         'bank_account_code_prefix': '1001',
            //         'cash_account_code_prefix': '1000',
            //         'transfer_account_code_prefix': '1008',
            //         'account_default_pos_receivable_account_id': 'l10n_ee_10201',
            //         'income_currency_exchange_account_id': 'l10n_ee_422',
            //         'expense_currency_exchange_account_id': 'l10n_ee_673',
            //         'account_journal_suspense_account_id': 'l10n_ee_1009',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_ee_6850',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_ee_430',
            //         'default_cash_difference_income_account_id': 'l10n_ee_420',
            //         'default_cash_difference_expense_account_id': 'l10n_ee_671',
            //         'account_sale_tax_id': 'l10n_ee_vat_out_22_g',
            //         'account_purchase_tax_id': 'l10n_ee_vat_in_22_g',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ee, FILE: template_ee.py) ---
            // def _get_ee_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_ee_10200',
            //     'property_account_payable_id': 'l10n_ee_2010',
            //     'property_account_income_categ_id': 'l10n_ee_40000',
            //     'property_account_expense_categ_id': 'l10n_ee_50',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEgAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg, FILE: template_eg.py) ---
            // def _get_eg_account_journal(self):
            // """ If EGYPT chart, we add 2 new journals TA and IFRS"""
            // return {
            //     "tax_adjustment": {
            //         "name": "Tax Adjustments",
            //         "code": "TA",
            //         "type": "general",
            //         "sequence": 1,
            //         "show_on_dashboard": True,
            //     },
            //     "ifrs": {
            //         "name": "IFRS 16",
            //         "code": "IFRS",
            //         "type": "general",
            //         "show_on_dashboard": True,
            //         "sequence": 10,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg, FILE: template_eg.py) ---
            // def _get_eg_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.eg',
            //         'bank_account_code_prefix': '101',
            //         'cash_account_code_prefix': '105',
            //         'transfer_account_code_prefix': '100',
            //         'account_default_pos_receivable_account_id': 'egy_account_102012',
            //         'income_currency_exchange_account_id': 'egy_account_500011',
            //         'expense_currency_exchange_account_id': 'egy_account_400053',
            //         'account_journal_suspense_account_id': 'egy_account_201001',
            //         'account_journal_early_pay_discount_loss_account_id': 'egy_account_400079',
            //         'account_journal_early_pay_discount_gain_account_id': 'egy_account_500014',
            //         'default_cash_difference_income_account_id': 'egy_account_999002',
            //         'default_cash_difference_expense_account_id': 'egy_account_999001',
            //         'account_sale_tax_id': 'eg_standard_sale_14',
            //         'account_purchase_tax_id': 'eg_standard_purchase_14',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg, FILE: template_eg.py) ---
            // def _get_eg_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'egy_account_102011',
            //     'property_account_payable_id': 'egy_account_201002',
            //     'property_account_expense_categ_id': 'egy_account_400028',
            //     'property_account_income_categ_id': 'egy_account_500001',
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetEsAssecResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_assec.py) ---
            // def _get_es_assec_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsAssecTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_assec.py) ---
            // def _get_es_assec_template_data(self):
            // return {
            //     'name': _('Non-profit entities (2008)'),
            //     'parent': 'es_common_mainland',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryAssocAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_assoc.py) ---
            // def _get_es_canary_assoc_account_account(self):
            // return self._parse_csv('es_assec', 'account.account', module='l10n_es')
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryAssocResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_assoc.py) ---
            // def _get_es_canary_assoc_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '572999',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryAssocTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_assoc.py) ---
            // def _get_es_canary_assoc_template_data(self):
            // return {
            //     'name': _('Canary Islands - PGCE non-profit entities (2008)'),
            //     'parent': 'es_canary_common',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryCommonResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_common.py) ---
            // def _get_es_canary_common_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '572999',
            //         'account_sale_tax_id': 'account_tax_template_igic_r_7',
            //         'account_purchase_tax_id': 'account_tax_template_igic_sop_7',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryCommonTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_common.py) ---
            // def _get_es_canary_common_template_data(self):
            // return {
            //     'name': 'Common Canary Islands',
            //     'visible': 0,
            //     'parent': 'es_common',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryFullAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_full.py) ---
            // def _get_es_canary_full_account_account(self):
            // return self._parse_csv('es_full', 'account.account', module='l10n_es')
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryFullResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_full.py) ---
            // def _get_es_canary_full_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '572999',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryFullTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_full.py) ---
            // def _get_es_canary_full_template_data(self):
            // return {
            //     'name': _('Canary Islands - Complete (2008)'),
            //     'parent': 'es_canary_common',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryPymesAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_pymes.py) ---
            // def _get_es_canary_pymes_account_account(self):
            // return self._parse_csv('es_pymes', 'account.account', module='l10n_es')
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryPymesResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_pymes.py) ---
            // def _get_es_canary_pymes_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '572999',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCanaryPymesTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_canary_pymes.py) ---
            // def _get_es_canary_pymes_template_data(self):
            // return {
            //     'name': _('Canary Islands - SMEs (2008)'),
            //     'parent': 'es_canary_common',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCommonMainlandResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_common_mainland.py) ---
            // def _get_es_common_mainland_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCommonMainlandTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_common_mainland.py) ---
            // def _get_es_common_mainland_template_data(self):
            // return {
            //     'name': 'Common Mainland',
            //     'visible': 0,
            //     'parent': 'es_common',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCommonResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_common.py) ---
            // def _get_es_common_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_default_pos_receivable_account_id': 'account_common_4301',
            //         'income_currency_exchange_account_id': 'account_common_768',
            //         'expense_currency_exchange_account_id': 'account_common_668',
            //         'account_journal_suspense_account_id': 'account_common_572998',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_common_6060',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_common_7060',
            //         'default_cash_difference_income_account_id': 'account_common_778',
            //         'default_cash_difference_expense_account_id': 'account_common_678',
            //         'deferred_expense_account_id': 'account_common_480',
            //         'deferred_revenue_account_id': 'account_common_485',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCommonTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_common.py) ---
            // def _get_es_common_template_data(self):
            // return {
            //     'name': _('Common'),
            //     'visible': 0,
            //     'property_account_receivable_id': 'account_common_4300',
            //     'property_account_payable_id': 'account_common_4100',
            //     'property_account_expense_categ_id': 'account_common_600',
            //     'property_account_income_categ_id': 'account_common_7000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCoopFullResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_coop_full.py) ---
            // def _get_es_coop_full_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCoopFullTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_coop_full.py) ---
            // def _get_es_coop_full_template_data(self):
            // return {
            //     'name': _('Cooperatives - Complete (2008)'),
            //     'parent': 'es_coop_pymes',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCoopPymesResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_coop_pymes.py) ---
            // def _get_es_coop_pymes_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsCoopPymesTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_coop_pymes.py) ---
            // def _get_es_coop_pymes_template_data(self):
            // return {
            //     'name': _('Cooperatives - SMEs (2008)'),
            //     'parent': 'es_common_mainland',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsFacturaeAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: account_chart_template.py) ---
            // def _get_es_facturae_account_tax(self):
            // taxes = self._parse_csv('es_common', 'account.tax', module='l10n_es_edi_facturae')
            // # only return existing taxes
            // taxes = {
            //     key: value
            //     for key, value in taxes.items()
            //     if self.env['account.chart.template'].ref(key, raise_if_not_found=False)
            // }
            // return taxes
            */
            return default;
        }

        public async Task<TEntity> GetEsFullResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_full.py) ---
            // def _get_es_full_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsFullTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_full.py) ---
            // def _get_es_full_template_data(self):
            // return {
            //     'name': _('Complete (2008)'),
            //     'parent': 'es_common_mainland',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsPymesResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_pymes.py) ---
            // def _get_es_pymes_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.es',
            //         'bank_account_code_prefix': '572',
            //         'cash_account_code_prefix': '570',
            //         'transfer_account_code_prefix': '57299',
            //         'account_sale_tax_id': 'account_tax_template_s_iva21b',
            //         'account_purchase_tax_id': 'account_tax_template_p_iva21_bc',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEsPymesTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_pymes.py) ---
            // def _get_es_pymes_template_data(self):
            // return {
            //     'name': _('SMEs (2008)'),
            //     'parent': 'es_common_mainland',
            //     'sequence': 0,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_et, FILE: template_et.py) ---
            // def _get_et_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.et',
            //         'bank_account_code_prefix': '211',
            //         'cash_account_code_prefix': '211',
            //         'transfer_account_code_prefix': '212',
            //         'account_default_pos_receivable_account_id': 'l10n_et2215',
            //         'income_currency_exchange_account_id': 'l10n_et6435',
            //         'expense_currency_exchange_account_id': 'l10n_et6436',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_et626001',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_et120001',
            //         'account_sale_tax_id': 'id_tax03',
            //         'account_purchase_tax_id': 'id_tax08',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_et, FILE: template_et.py) ---
            // def _get_et_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'l10n_et2211',
            //     'property_account_payable_id': 'l10n_et3002',
            //     'property_account_expense_categ_id': 'l10n_et2301',
            //     'property_account_income_categ_id': 'l10n_et1100',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFiResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fi, FILE: template_fi.py) ---
            // def _get_fi_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.fi',
            //         'bank_account_code_prefix': '1921',
            //         'cash_account_code_prefix': '1910',
            //         'transfer_account_code_prefix': '1950',
            //         'account_default_pos_receivable_account_id': 'account_1701',
            //         'income_currency_exchange_account_id': 'account_3500',
            //         'expense_currency_exchange_account_id': 'account_4380',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_4230',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_3500',
            //         'account_sale_tax_id': 'tax_dom_sales_goods_25_5',
            //         'account_purchase_tax_id': 'tax_dom_purchase_goods_25_5',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFiTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fi, FILE: template_fi.py) ---
            // def _get_fi_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'account_1701',
            //     'property_account_payable_id': 'account_2871',
            //     'property_account_expense_categ_id': 'account_4000',
            //     'property_account_income_categ_id': 'account_3000',
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetFieldTranslationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object fname, object lang) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_field_translation(self, record, fname, lang):
            // """Return the value for language lang for field with fname from record (or None if none exists).
            // 
            // :param record: record formatted like in the template data (generated by _get_chart_template_data)
            // :type record: dict
            // :param fname: the name of a field (in record) as string
            // :type str
            // :param lang: the code of a res.lang
            // :type str
            // :return record[fname] translated into lang (or None)
            // :rtype str
            // """
            // generic_lang = lang.split('_')[0]  # manage generic locale (i.e. `fr` instead of `fr_BE`)
            // translation_module = record.get('__translation_module__', {}).get(fname, 'account')
            // translation = record.get(f"{fname}@{lang}") or record.get(f"{fname}@{generic_lang}")
            // if translation or fname not in record:
            //     return translation
            // else:
            //     return (
            //         code_translations.get_python_translations(translation_module, lang).get(record[fname])
            //         or code_translations.get_python_translations(translation_module, generic_lang).get(record[fname])
            //     )
            */
            return default;
        }

        public async Task<TEntity> GetFrAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_fr.py) ---
            // def _get_fr_account_journal(self):
            // return {
            //     'sale': {'refund_sequence': True},
            //     'purchase': {'refund_sequence': True},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFrReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_fr.py) ---
            // def _get_fr_reconcile_model(self):
            // return {
            //     'bank_charges_reconcile_model': {
            //         'name': 'Bank fees',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_6278',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_fr.py) ---
            // def _get_fr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.fr',
            //         'bank_account_code_prefix': '512',
            //         'cash_account_code_prefix': '53',
            //         'transfer_account_code_prefix': '58',
            //         'account_default_pos_receivable_account_id': 'fr_pcg_recv_pos',
            //         'income_currency_exchange_account_id': 'pcg_766',
            //         'expense_currency_exchange_account_id': 'pcg_666',
            //         'account_journal_suspense_account_id': 'pcg_471',
            //         'account_journal_early_pay_discount_loss_account_id': 'pcg_665',
            //         'account_journal_early_pay_discount_gain_account_id': 'pcg_765',
            //         'deferred_expense_account_id': 'pcg_486',
            //         'deferred_revenue_account_id': 'pcg_487',
            //         'l10n_fr_rounding_difference_loss_account_id': 'pcg_4768',
            //         'l10n_fr_rounding_difference_profit_account_id': 'pcg_4778',
            //         'account_sale_tax_id': 'tva_normale',
            //         'account_purchase_tax_id': 'tva_acq_normale',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_fr.py) ---
            // def _get_fr_template_data(self):
            // return {
            //     'code_digits': 6,
            //     'property_account_receivable_id': 'fr_pcg_recv',
            //     'property_account_payable_id': 'fr_pcg_pay',
            //     'property_account_expense_categ_id': 'pcg_607_account',
            //     'property_account_income_categ_id': 'pcg_707_account',
            //     'property_account_downpayment_categ_id': 'pcg_4191',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGaAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga.py) ---
            // def _get_ga_account_account(self):
            // return self._parse_csv('ga', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga.py) ---
            // def _get_ga_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ga',
            //         'account_sale_tax_id': 'tva_sale_19',
            //         'account_purchase_tax_id': 'tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGaSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga_syscebnl.py) ---
            // def _get_ga_syscebnl_account_account(self):
            // return self._parse_csv('ga_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGaSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga_syscebnl.py) ---
            // def _get_ga_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ga',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_19',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGaSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga_syscebnl.py) ---
            // def _get_ga_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ga, FILE: template_ga.py) ---
            // def _get_ga_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGenericCoaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: template_generic_coa.py) ---
            // def _get_generic_coa_res_company(self):
            // """Return the data to be written on the company.
            // 
            // The data is a mapping the XMLID to the create/write values of a record.
            // 
            // :rtype: dict[(str, int), dict]
            // """
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.us',
            //         'bank_account_code_prefix': '1014',
            //         'cash_account_code_prefix': '1015',
            //         'transfer_account_code_prefix': '1017',
            //         'account_default_pos_receivable_account_id': 'pos_receivable',
            //         'income_currency_exchange_account_id': 'income_currency_exchange',
            //         'expense_currency_exchange_account_id': 'expense_currency_exchange',
            //         'default_cash_difference_income_account_id': 'cash_diff_income',
            //         'default_cash_difference_expense_account_id': 'cash_diff_expense',
            //         'account_journal_early_pay_discount_loss_account_id': 'cash_discount_loss',
            //         'account_journal_early_pay_discount_gain_account_id': 'cash_discount_gain',
            //     }
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: template_generic_coa.py) ---
            // def _get_generic_coa_res_company(self):
            // res = super()._get_generic_coa_res_company()
            // res[self.env.company.id].update({
            //     'account_production_wip_account_id': 'wip',
            //     'account_production_wip_overhead_account_id': 'cost_of_production',
            // })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetGenericCoaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: template_generic_coa.py) ---
            // def _get_generic_coa_template_data(self):
            // """Return the data necessary for the chart template.
            // 
            // :return: all the values that are not stored but are used to instancieate
            //          the chart of accounts. Common keys are:
            //          * property_*
            //          * code_digits
            // :rtype: dict
            // """
            // return {
            //     'name': _("United States of America (Generic)"),
            //     'country': None,
            //     'property_account_receivable_id': 'receivable',
            //     'property_account_payable_id': 'payable',
            //     'property_account_expense_categ_id': 'expense',
            //     'property_account_income_categ_id': 'income',
            //     'property_stock_account_input_categ_id': 'stock_in',
            //     'property_stock_account_output_categ_id': 'stock_out',
            //     'property_stock_valuation_account_id': 'stock_valuation',
            //     'property_stock_account_production_cost_id': 'cost_of_production',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGnAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn.py) ---
            // def _get_gn_account_account(self):
            // return self._parse_csv('gn', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn.py) ---
            // def _get_gn_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gn',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_good_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGnSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn_syscebnl.py) ---
            // def _get_gn_syscebnl_account_account(self):
            // return self._parse_csv('gn_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGnSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn_syscebnl.py) ---
            // def _get_gn_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gn',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_good_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGnSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn_syscebnl.py) ---
            // def _get_gn_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gn, FILE: template_gn.py) ---
            // def _get_gn_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGqAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq.py) ---
            // def _get_gq_account_account(self):
            // return self._parse_csv('gq', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGqResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq.py) ---
            // def _get_gq_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gq',
            //         'account_sale_tax_id': 'tva_sale_15',
            //         'account_purchase_tax_id': 'tva_purchase_15',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGqSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq_syscebnl.py) ---
            // def _get_gq_syscebnl_account_account(self):
            // return self._parse_csv('gq_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGqSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq_syscebnl.py) ---
            // def _get_gq_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gq',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_15',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_15',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGqSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq_syscebnl.py) ---
            // def _get_gq_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGqTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gq, FILE: template_gq.py) ---
            // def _get_gq_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gr, FILE: template_gr.py) ---
            // def _get_gr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.gr',
            //         'bank_account_code_prefix': '38.00.0',
            //         'cash_account_code_prefix': '38.00.0',
            //         'transfer_account_code_prefix': '38.00.0',
            //         'account_default_pos_receivable_account_id': 'l10n_gr_38_01',
            //         'income_currency_exchange_account_id': 'l10n_gr_73_01_01',
            //         'expense_currency_exchange_account_id': 'l10n_gr_62_01_01',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_gr_64_12_01',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_gr_70_01_03',
            //         'default_cash_difference_income_account_id': 'l10n_gr_71_06',
            //         'default_cash_difference_expense_account_id': 'l10n_gr_64_14',
            //         'account_sale_tax_id': 'l10n_gr_tax_s24_G',
            //         'account_purchase_tax_id': 'l10n_gr_tax_p24_G',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gr, FILE: template_gr.py) ---
            // def _get_gr_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_gr_30_01_01_01',
            //     'property_account_payable_id': 'l10n_gr_50_01_01',
            //     'property_account_expense_categ_id': 'l10n_gr_64_01_01_01',
            //     'property_account_income_categ_id': 'l10n_gr_70_01_01',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gt, FILE: template_gt.py) ---
            // def _get_gt_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.gt',
            //         'bank_account_code_prefix': '1.0.01.0',
            //         'cash_account_code_prefix': '1.0.02.0',
            //         'transfer_account_code_prefix': '1.0.03.01',
            //         'account_default_pos_receivable_account_id': 'cta110205',
            //         'income_currency_exchange_account_id': 'cta410103',
            //         'expense_currency_exchange_account_id': 'cta710101',
            //         'account_sale_tax_id': 'impuestos_plantilla_iva_por_pagar',
            //         'account_purchase_tax_id': 'impuestos_plantilla_iva_por_cobrar',
            // 
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gt, FILE: template_gt.py) ---
            // def _get_gt_template_data(self):
            // return {
            //     'code_digits': '9',
            //     'property_account_receivable_id': 'cta110201',
            //     'property_account_payable_id': 'cta210101',
            //     'property_account_income_categ_id': 'cta410101',
            //     'property_account_expense_categ_id': 'cta510101',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGwAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw.py) ---
            // def _get_gw_account_account(self):
            // return self._parse_csv('gw', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGwResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw.py) ---
            // def _get_gw_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gw',
            //         'account_sale_tax_id': 'tva_sale_5',
            //         'account_purchase_tax_id': 'tva_purchase_5',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGwSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw_syscebnl.py) ---
            // def _get_gw_syscebnl_account_account(self):
            // return self._parse_csv('gw_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetGwSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw_syscebnl.py) ---
            // def _get_gw_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.gw',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_5',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_5',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetGwSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw_syscebnl.py) ---
            // def _get_gw_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGwTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gw, FILE: template_gw.py) ---
            // def _get_gw_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHkResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hk, FILE: template_hk.py) ---
            // def _get_hk_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.hk',
            //         'bank_account_code_prefix': '1200',
            //         'cash_account_code_prefix': '1210',
            //         'transfer_account_code_prefix': '111220',
            //         'account_default_pos_receivable_account_id': 'l10n_hk_1243',
            //         'income_currency_exchange_account_id': 'l10n_hk_4240',
            //         'expense_currency_exchange_account_id': 'l10n_hk_5240',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_hk_5250',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_hk_4250',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHkTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hk, FILE: template_hk.py) ---
            // def _get_hk_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_hk_1240',
            //     'property_account_payable_id': 'l10n_hk_2211',
            //     'property_account_income_categ_id': 'l10n_hk_41',
            //     'property_account_expense_categ_id': 'l10n_hk_51',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hn, FILE: template_hn.py) ---
            // def _get_hn_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.hn',
            //         'bank_account_code_prefix': '1.1.01.',
            //         'cash_account_code_prefix': '1.1.01.',
            //         'transfer_account_code_prefix': '1.1.01.00',
            //         'account_default_pos_receivable_account_id': 'cta110205',
            //         'income_currency_exchange_account_id': 'cta410103',
            //         'expense_currency_exchange_account_id': 'cta710101',
            //         'account_journal_early_pay_discount_loss_account_id': 'cta620202',
            //         'account_journal_early_pay_discount_gain_account_id': 'cta420102',
            //         'account_sale_tax_id': 'impuestos_plantilla_isv_por_pagar',
            //         'account_purchase_tax_id': 'impuestos_plantilla_isv_por_cobrar',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hn, FILE: template_hn.py) ---
            // def _get_hn_template_data(self):
            // return {
            //     'property_account_receivable_id': 'cta110201',
            //     'property_account_payable_id': 'cta210101',
            //     'property_account_income_categ_id': 'cta410101',
            //     'property_account_expense_categ_id': 'cta510101',
            //     'code_digits': '9',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHrKunaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hr_kuna, FILE: template_hr_kuna.py) ---
            // def _get_hr_kuna_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.hr',
            //         'bank_account_code_prefix': '101',
            //         'cash_account_code_prefix': '102',
            //         'transfer_account_code_prefix': '1009',
            //         'account_default_pos_receivable_account_id': 'kp_rrif1213',
            //         'income_currency_exchange_account_id': 'kp_rrif1050',
            //         'expense_currency_exchange_account_id': 'kp_rrif4754',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHrKunaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hr_kuna, FILE: template_hr_kuna.py) ---
            // def _get_hr_kuna_template_data(self):
            // return {
            //     'name': 'RRIF-ov računski plan za poduzetnike',
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            //     'property_account_receivable_id': 'kp_rrif1200',
            //     'property_account_payable_id': 'kp_rrif2200',
            //     'property_account_expense_categ_id': 'kp_rrif4199',
            //     'property_account_income_categ_id': 'kp_rrif7500',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hr, FILE: template_hr.py) ---
            // def _get_hr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.hr',
            //         'bank_account_code_prefix': '100',
            //         'cash_account_code_prefix': '102',
            //         'transfer_account_code_prefix': '1009',
            //         'account_default_pos_receivable_account_id': 'hr_120100',
            //         'income_currency_exchange_account_id': 'hr_772000',
            //         'expense_currency_exchange_account_id': 'hr_475000',
            //         'account_sale_tax_id': 'VAT_S_IN_ROC_25',
            //         'account_purchase_tax_id': 'VAT_P_IN_ROC_25',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hr, FILE: template_hr.py) ---
            // def _get_hr_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            //     'property_account_receivable_id': 'hr_120000',
            //     'property_account_payable_id': 'hr_220000',
            //     'property_account_expense_categ_id': 'hr_400000',
            //     'property_account_income_categ_id': 'hr_750000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHuAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: template_hu.py) ---
            // def _get_hu_account_tax(self):
            // data = self._parse_csv('hu', 'account.tax', module='l10n_hu_edi')
            // return data
            */
            return default;
        }

        public async Task<TEntity> GetHuResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu, FILE: template_hu.py) ---
            // def _get_hu_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.hu',
            //         'tax_calculation_rounding_method': 'round_globally',
            //         'bank_account_code_prefix': '384',
            //         'cash_account_code_prefix': '381',
            //         'transfer_account_code_prefix': '389',
            //         'income_currency_exchange_account_id': 'l10n_hu_976',
            //         'expense_currency_exchange_account_id': 'l10n_hu_876',
            //         'account_sale_tax_id': 'F27',
            //         'account_purchase_tax_id': 'V27',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetHuTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu, FILE: template_hu.py) ---
            // def _get_hu_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_hu_311',
            //     'property_account_payable_id': 'l10n_hu_454',
            //     'property_account_expense_categ_id': 'l10n_hu_811',
            //     'property_account_income_categ_id': 'l10n_hu_911',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIdResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_id, FILE: template_id.py) ---
            // def _get_id_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.id',
            //         'bank_account_code_prefix': '1112',
            //         'cash_account_code_prefix': '1111',
            //         'transfer_account_code_prefix': '1999999',
            //         'account_default_pos_receivable_account_id': 'l10n_id_11210011',
            //         'income_currency_exchange_account_id': 'l10n_id_81100010',
            //         'expense_currency_exchange_account_id': 'l10n_id_91100010',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_id_99900003',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_id_99900004',
            //         'account_sale_tax_id': 'tax_ST1',
            //         'account_purchase_tax_id': 'tax_PT1',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIdTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_id, FILE: template_id.py) ---
            // def _get_id_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_id_11210010',
            //     'property_account_payable_id': 'l10n_id_21100010',
            //     'property_account_expense_categ_id': 'l10n_id_51000010',
            //     'property_account_income_categ_id': 'l10n_id_41000010',
            //     'property_stock_account_input_categ_id': 'l10n_id_29000000',
            //     'property_stock_account_output_categ_id': 'l10n_id_29000000',
            //     'property_stock_valuation_account_id': 'l10n_id_11300180',
            //     'code_digits': '8',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ie, FILE: template_ie.py) ---
            // def _get_ie_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ie',
            //         'bank_account_code_prefix': '230',
            //         'cash_account_code_prefix': '231',
            //         'transfer_account_code_prefix': '232',
            //         'account_default_pos_receivable_account_id': 'l10n_ie_account_2101',
            //         'income_currency_exchange_account_id': 'l10n_ie_account_761',
            //         'expense_currency_exchange_account_id': 'l10n_ie_account_661',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_ie_account_640',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_ie_account_730',
            //         'default_cash_difference_expense_account_id': 'l10n_ie_account_641',
            //         'default_cash_difference_income_account_id': 'l10n_ie_account_731',
            //         'account_sale_tax_id': 'ie_tax_sale_goods_23',
            //         'account_purchase_tax_id': 'ie_tax_purchase_goods_23',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ie, FILE: template_ie.py) ---
            // def _get_ie_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_ie_account_2100',
            //     'property_account_payable_id': 'l10n_ie_account_34',
            //     'property_account_expense_categ_id': 'l10n_ie_account_60',
            //     'property_account_income_categ_id': 'l10n_ie_account_70',
            //     'property_stock_valuation_account_id': 'l10n_ie_account_630',
            //     'property_advance_tax_payment_account_id': 'l10n_ie_account_2132',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_il, FILE: template_il.py) ---
            // def _get_il_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.il',
            //         'bank_account_code_prefix': '1014',
            //         'cash_account_code_prefix': '1015',
            //         'transfer_account_code_prefix': '1017',
            //         'account_default_pos_receivable_account_id': 'il_account_101201',
            //         'income_currency_exchange_account_id': 'il_account_201000',
            //         'expense_currency_exchange_account_id': 'il_account_202100',
            //         'account_sale_tax_id': 'il_vat_sales_18',
            //         'account_purchase_tax_id': 'il_vat_inputs_18',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_il, FILE: template_il.py) ---
            // def _get_il_template_data(self):
            // return {
            //     'property_account_receivable_id': 'il_account_101200',
            //     'property_account_payable_id': 'il_account_111100',
            //     'property_account_expense_categ_id': 'il_account_212200',
            //     'property_account_income_categ_id': 'il_account_200000',
            //     'property_stock_account_input_categ_id': 'il_account_101120',
            //     'property_stock_account_output_categ_id': 'il_account_101130',
            //     'property_stock_valuation_account_id': 'il_account_101110',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInAccountCashRoundingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_in_account_cash_rounding(self):
            // return {
            //     'l10n_in.cash_rounding_in_half_up': {
            //         'profit_account_id': 'p213202',
            //         'loss_account_id': 'p213201',
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInAccountFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_in_account_fiscal_position(self):
            // company = self.env.company
            // state_ids = [Command.set(company.state_id.ids)] if company.state_id else False
            // intra_state_name = company.state_id and _('Within %s', company.state_id.name) or _('Intra State')
            // state_specific = {
            //     'fiscal_position_in_intra_state': {
            //         'name': intra_state_name,
            //         'sequence': 1,
            //         'auto_apply': True,
            //         'state_ids': state_ids,
            //         'country_id': self.env.ref('base.in').id,
            //     },
            //     'fiscal_position_in_inter_state': {
            //         'name': _('Inter State'),
            //         'sequence': 2,
            //         'auto_apply': True,
            //         'tax_ids': self._get_l10n_in_fiscal_tax_vals(),
            //         'country_id': self.env.ref('base.in').id
            //     },
            // }
            // if company.parent_id:
            //     return state_specific
            // return {
            //     **state_specific,
            //     'fiscal_position_in_export_sez_in': {
            //         'name': _('Export/SEZ'),
            //         'sequence': 3,
            //         'auto_apply': True,
            //         'note': _('SUPPLY MEANT FOR EXPORT/SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS ON PAYMENT OF INTEGRATED TAX.'),
            //         'tax_ids': (
            //             self._get_l10n_in_fiscal_tax_vals(trailing_id='_sez_exp')
            //             + self._get_l10n_in_zero_rated_with_igst_zero_tax_vals()
            //         ),
            //     },
            //     'fiscal_position_in_lut_sez': {
            //         'name': _('LUT - Export/SEZ'),
            //         'sequence': 4,
            //         'note': _('SUPPLY MEANT FOR EXPORT/SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX.'),
            //         'tax_ids': (
            //             self._get_l10n_in_fiscal_tax_vals(use_zero_rated_igst=True, trailing_id='_sez_exp_lut')
            //             + self._get_l10n_in_zero_rated_with_igst_zero_tax_vals()
            //         )
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInBaseResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_withholding, FILE: account_chart_template.py) ---
            // def _get_in_base_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'l10n_in_withholding_account_id': 'p100595',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_in_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.in',
            //         'bank_account_code_prefix': '1002',
            //         'cash_account_code_prefix': '1001',
            //         'transfer_account_code_prefix': '1008',
            //         'account_default_pos_receivable_account_id': 'p10041',
            //         'income_currency_exchange_account_id': 'p2013',
            //         'expense_currency_exchange_account_id': 'p2117',
            //         'account_journal_early_pay_discount_loss_account_id': 'p2132',
            //         'account_journal_early_pay_discount_gain_account_id': '2012',
            //         'account_opening_date': fields.Date.context_today(self).replace(month=4, day=1),
            //         'fiscalyear_last_month': '3',
            //         'account_sale_tax_id': 'sgst_sale_5',
            //         'account_purchase_tax_id': 'sgst_purchase_5',
            //         'deferred_expense_account_id': 'p10084',
            //         'deferred_revenue_account_id': 'p10085',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_in_template_data(self):
            // return {
            //     'property_account_receivable_id': 'p10040',
            //     'property_account_payable_id': 'p11211',
            //     'property_account_expense_categ_id': 'p2107',
            //     'property_account_income_categ_id': 'p20011',
            //     'code_digits': '6',
            //     'display_invoice_amount_total_words': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInWithholdingAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_withholding, FILE: account_chart_template.py) ---
            // def _get_in_withholding_account_account(self):
            // return self._parse_csv('in', 'account.account', module='l10n_in_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetInWithholdingAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_withholding, FILE: account_chart_template.py) ---
            // def _get_in_withholding_account_tax(self):
            // tax_data = self._parse_csv('in', 'account.tax', module='l10n_in_withholding')
            // self._deref_account_tags('in', tax_data)
            // return tax_data
            */
            return default;
        }

        public async Task<TEntity> GetIqResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_iq, FILE: template_iq.py) ---
            // def _get_iq_res_company(self):
            // return {
            //     self.env.company.id: {
            //         "account_fiscal_country_id": "base.iq",
            //         "bank_account_code_prefix": "1000",
            //         "cash_account_code_prefix": "1009",
            //         "transfer_account_code_prefix": "1001",
            //         "account_default_pos_receivable_account_id": "iq_account_100202",
            //         "income_currency_exchange_account_id": "iq_account_400301",
            //         "expense_currency_exchange_account_id": "iq_account_500903",
            //         "account_journal_suspense_account_id": "iq_account_100102",
            //         "account_journal_early_pay_discount_loss_account_id": "iq_account_501107",
            //         "account_journal_early_pay_discount_gain_account_id": "iq_account_400304",
            //         "default_cash_difference_income_account_id": "iq_account_400302",
            //         "default_cash_difference_expense_account_id": "iq_account_500909",
            //         "deferred_expense_account_id": "iq_account_100416",
            //         "deferred_revenue_account_id": "iq_account_200401",
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIqTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_iq, FILE: template_iq.py) ---
            // def _get_iq_template_data(self):
            // return {
            //     "property_account_receivable_id": "iq_account_100201",
            //     "property_account_payable_id": "iq_account_200101",
            //     "property_account_expense_categ_id": "iq_account_500101",
            //     "property_account_income_categ_id": "iq_account_400101",
            //     "property_account_expense_id": "iq_account_500101",
            //     "property_account_income_id": "iq_account_400101",
            //     "property_stock_valuation_account_id": "iq_account_100502",
            //     "property_stock_account_input_categ_id": "iq_account_100503",
            //     "property_stock_account_output_categ_id": "iq_account_100504",
            //     "property_stock_account_production_cost_id": "iq_account_100505",
            //     "code_digits": "6",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetItEdiDoiAccountFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_doi, FILE: account_chart_template.py) ---
            // def _get_it_edi_doi_account_fiscal_position(self):
            // return self._parse_csv('it', 'account.fiscal.position', module='l10n_it_edi_doi')
            */
            return default;
        }

        public async Task<TEntity> GetItEdiDoiAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_doi, FILE: account_chart_template.py) ---
            // def _get_it_edi_doi_account_tax(self):
            // tax_data = self._parse_csv('it', 'account.tax', module='l10n_it_edi_doi')
            // self._deref_account_tags('it', tax_data)
            // return tax_data
            */
            return default;
        }

        public async Task<TEntity> GetItEdiDoiResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_doi, FILE: account_chart_template.py) ---
            // def _get_it_edi_doi_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'l10n_it_edi_doi_tax_id': '00di',
            //         'l10n_it_edi_doi_fiscal_position_id': 'declaration_of_intent_fiscal_position',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetItResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it, FILE: template_it.py) ---
            // def _get_it_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.it',
            //         'bank_account_code_prefix': '182',
            //         'cash_account_code_prefix': '180',
            //         'transfer_account_code_prefix': '183',
            //         'account_default_pos_receivable_account_id': '1508',
            //         'income_currency_exchange_account_id': '3220',
            //         'expense_currency_exchange_account_id': '4920',
            //         'account_journal_early_pay_discount_loss_account_id': '4111',
            //         'account_journal_early_pay_discount_gain_account_id': '3111',
            //         'tax_calculation_rounding_method': 'round_globally',
            //         'account_sale_tax_id': '22v',
            //         'account_purchase_tax_id': '22am',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetItTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it, FILE: template_it.py) ---
            // def _get_it_template_data(self):
            // return {
            //     'property_account_receivable_id': '1501',
            //     'property_account_payable_id': '2501',
            //     'property_account_expense_categ_id': '4101',
            //     'property_account_income_categ_id': '3101',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetItWithholdingAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_withholding, FILE: account_chart_template.py) ---
            // def _get_it_withholding_account_account(self):
            // return self._parse_csv('it', 'account.account', module='l10n_it_edi_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetItWithholdingAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_withholding, FILE: account_chart_template.py) ---
            // def _get_it_withholding_account_tax_group(self):
            // return self._parse_csv('it', 'account.tax.group', module='l10n_it_edi_withholding')
            */
            return default;
        }

        public async Task<TEntity> GetItWithholdingAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_withholding, FILE: account_chart_template.py) ---
            // def _get_it_withholding_account_tax(self):
            // additionnal = self._parse_csv('it', 'account.tax', module='l10n_it_edi_withholding')
            // self._deref_account_tags('it', additionnal)
            // return additionnal
            */
            return default;
        }

        public async Task<TEntity> GetJoStandardResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo, FILE: template_jo_standard.py) ---
            // def _get_jo_standard_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.jo',
            //         'tax_calculation_rounding_method': 'round_globally',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1009',
            //         'transfer_account_code_prefix': '1001',
            //         'account_default_pos_receivable_account_id': 'jo_account_100202',
            //         'income_currency_exchange_account_id': 'jo_account_400301',
            //         'expense_currency_exchange_account_id': 'jo_account_500903',
            //         'account_journal_suspense_account_id': 'jo_account_100102',
            //         'account_journal_early_pay_discount_loss_account_id': 'jo_account_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'jo_account_400304',
            //         'default_cash_difference_income_account_id': 'jo_account_400302',
            //         'default_cash_difference_expense_account_id': 'jo_account_500909',
            //         'deferred_expense_account_id': 'jo_account_100416',
            //         'deferred_revenue_account_id': 'jo_account_200401',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetJoStandardTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo, FILE: template_jo_standard.py) ---
            // def _get_jo_standard_template_data(self):
            // return {
            //     'property_account_receivable_id': 'jo_account_100201',
            //     'property_account_payable_id': 'jo_account_200101',
            //     'property_account_expense_categ_id': 'jo_account_500101',
            //     'property_account_income_categ_id': 'jo_account_400101',
            //     'property_account_expense_id': 'jo_account_500101',
            //     'property_account_income_id': 'jo_account_400101',
            //     'property_stock_valuation_account_id': 'jo_account_100502',
            //     'property_stock_account_input_categ_id': 'jo_account_100503',
            //     'property_stock_account_output_categ_id': 'jo_account_100504',
            //     'property_stock_account_production_cost_id': 'jo_account_100505',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetJpResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jp, FILE: template_jp.py) ---
            // def _get_jp_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.jp',
            //         'bank_account_code_prefix': '1202',
            //         'cash_account_code_prefix': '1201',
            //         'transfer_account_code_prefix': '1236',
            //         'transfer_account_id': 'l10n_jp_123600',
            //         'account_default_pos_receivable_account_id': 'l10n_jp_126200',
            //         'income_currency_exchange_account_id': 'l10n_jp_425700',
            //         'expense_currency_exchange_account_id': 'l10n_jp_513500',
            //         'account_journal_suspense_account_id': 'l10n_jp_123900',
            //         'default_cash_difference_expense_account_id': 'l10n_jp_510100',
            //         'default_cash_difference_income_account_id': 'l10n_jp_999002',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_jp_510200',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_jp_425000',
            //         'account_sale_tax_id': 'l10n_jp_tax_sale_exc_10',
            //         'account_purchase_tax_id': 'l10n_jp_tax_purchase_exc_10',
            //         'tax_calculation_rounding_method': 'round_globally',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetJpTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jp, FILE: template_jp.py) ---
            // def _get_jp_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'l10n_jp_126000',
            //     'property_account_payable_id': 'l10n_jp_220000',
            //     'property_account_expense_categ_id': 'l10n_jp_510000',
            //     'property_account_income_categ_id': 'l10n_jp_410000',
            //     'property_stock_valuation_account_id': 'l10n_jp_121100',
            //     'property_stock_account_input_categ_id': 'l10n_jp_121200',
            //     'property_stock_account_output_categ_id': 'l10n_jp_121300',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ke, FILE: template_ke.py) ---
            // def _get_ke_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.ke',
            //         'bank_account_code_prefix': '12000',
            //         'cash_account_code_prefix': '12500',
            //         'transfer_account_code_prefix': '12100',
            //         'account_default_pos_receivable_account_id': 'ke110010',
            //         'income_currency_exchange_account_id': 'ke5144',
            //         'expense_currency_exchange_account_id': 'ke5144',
            //         'account_journal_early_pay_discount_loss_account_id': 'ke5147',
            //         'account_journal_early_pay_discount_gain_account_id': 'ke400710',
            //         'default_cash_difference_income_account_id': 'ke5146',
            //         'default_cash_difference_expense_account_id': 'ke5146',
            //         'account_sale_tax_id': 'ST16',
            //         'account_purchase_tax_id': 'PT16',
            //         'tax_exigibility': 'True',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ke, FILE: template_ke.py) ---
            // def _get_ke_template_data(self):
            // return {
            //     'property_account_receivable_id': 'ke1100',
            //     'property_account_payable_id': 'ke2100',
            //     'property_account_expense_categ_id': 'ke5001',
            //     'property_account_income_categ_id': 'ke4001',
            //     'property_stock_valuation_account_id': 'ke1001',
            //     'property_stock_account_output_categ_id': 'ke100120',
            //     'property_stock_account_input_categ_id': 'ke100110',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKmAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km.py) ---
            // def _get_km_account_account(self):
            // return self._parse_csv('km', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetKmResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km.py) ---
            // def _get_km_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.km',
            //         'account_sale_tax_id': 'tva_sale_10',
            //         'account_purchase_tax_id': 'tva_purchase',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetKmSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km_syscebnl.py) ---
            // def _get_km_syscebnl_account_account(self):
            // return self._parse_csv('km_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetKmSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km_syscebnl.py) ---
            // def _get_km_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.km',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_10',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetKmSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km_syscebnl.py) ---
            // def _get_km_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKmTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_km, FILE: template_km.py) ---
            // def _get_km_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kr, FILE: template_kr.py) ---
            // def _get_kr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_price_include': 'tax_included',
            //         'account_fiscal_country_id': 'base.kr',
            //         'transfer_account_code_prefix': '1116',
            //         'bank_account_code_prefix': '1111',
            //         'account_default_pos_receivable_account_id': 'l10n_kr_111303',
            //         'income_currency_exchange_account_id': 'l10n_kr_420007',
            //         'expense_currency_exchange_account_id': 'l10n_kr_620007',
            //         'transfer_account_id': 'l10n_kr_111611',
            //         'account_journal_suspense_account_id': 'l10n_kr_111610',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_kr_410003',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_kr_410008',
            //         'account_sale_tax_id': 'l10n_kr_sale_10',
            //         'account_purchase_tax_id': 'l10n_kr_purchase_10',
            //         'deferred_expense_account_id': 'l10n_kr_111401',
            //         'deferred_revenue_account_id': 'l10n_kr_216005',
            //         'account_production_wip_account_id': 'l10n_kr_112401',
            //         'account_production_wip_overhead_account_id': 'l10n_kr_610013',
            //         'default_cash_difference_income_account_id': 'l10n_kr_420013',
            //         'default_cash_difference_expense_account_id': 'l10n_kr_620014',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kr, FILE: template_kr.py) ---
            // def _get_kr_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'l10n_kr_111301',
            //     'property_account_payable_id': 'l10n_kr_212001',
            //     'property_account_expense_categ_id': 'l10n_kr_510001',
            //     'property_account_income_categ_id': 'l10n_kr_410001',
            //     'property_stock_valuation_account_id': 'l10n_kr_112101',
            //     'property_stock_account_input_categ_id': 'l10n_kr_112702',
            //     'property_stock_account_output_categ_id': 'l10n_kr_112703',
            //     'property_stock_account_production_cost_id': 'l10n_kr_112704',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKwResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kw, FILE: template_kw.py) ---
            // def _get_kw_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.kw',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1009',
            //         'transfer_account_code_prefix': '1001',
            //         'account_default_pos_receivable_account_id': 'kw_account_100202',
            //         'income_currency_exchange_account_id': 'kw_account_400301',
            //         'expense_currency_exchange_account_id': 'kw_account_500903',
            //         'account_journal_suspense_account_id': 'kw_account_100102',
            //         'account_journal_early_pay_discount_loss_account_id': 'kw_account_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'kw_account_400304',
            //         'default_cash_difference_income_account_id': 'kw_account_400302',
            //         'default_cash_difference_expense_account_id': 'kw_account_500909',
            //         'deferred_expense_account_id': 'kw_account_100416',
            //         'deferred_revenue_account_id': 'kw_account_200401',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKwTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kw, FILE: template_kw.py) ---
            // def _get_kw_template_data(self):
            // return {
            //     'property_account_receivable_id': 'kw_account_100201',
            //     'property_account_payable_id': 'kw_account_200101',
            //     'property_account_expense_categ_id': 'kw_account_500101',
            //     'property_account_income_categ_id': 'kw_account_400101',
            //     'property_account_expense_id': 'kw_account_500101',
            //     'property_account_income_id': 'kw_account_400101',
            //     'property_stock_valuation_account_id': 'kw_account_100502',
            //     'property_stock_account_input_categ_id': 'kw_account_100503',
            //     'property_stock_account_output_categ_id': 'kw_account_100504',
            //     'property_stock_account_production_cost_id': 'kw_account_100505',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKzAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kz, FILE: template_kz.py) ---
            // def _get_kz_account_journal(self):
            // return {
            //     'cash': {'default_account_id': 'kz1010'},
            //     'bank': {'default_account_id': 'kz1030'},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kz, FILE: template_kz.py) ---
            // def _get_kz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.kz',
            //         'bank_account_code_prefix': '103',
            //         'cash_account_code_prefix': '101',
            //         'transfer_account_code_prefix': '102',
            //         'income_currency_exchange_account_id': 'kz6250',
            //         'expense_currency_exchange_account_id': 'kz7430',
            //         'account_journal_early_pay_discount_loss_account_id': 'kz7481',
            //         'account_journal_early_pay_discount_gain_account_id': 'kz6291',
            //         'default_cash_difference_income_account_id': 'kz6210',
            //         'default_cash_difference_expense_account_id': 'kz7410',
            //         'account_sale_tax_id': 'l10n_kz_tax_vat_12_sale',
            //         'account_purchase_tax_id': 'l10n_kz_tax_vat_12_purchase',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetKzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_kz, FILE: template_kz.py) ---
            // def _get_kz_template_data(self):
            // return {
            //     'property_account_receivable_id': 'kz1210',
            //     'property_account_payable_id': 'kz3310',
            //     'property_account_income_categ_id': 'kz6010',
            //     'property_account_expense_categ_id': 'kz7010',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetL10nInFiscalTaxValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object use_zero_rated_igst, Guid trailing_id) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_l10n_in_fiscal_tax_vals(self, use_zero_rated_igst=False, trailing_id=False):
            // return [Command.clear()] + [
            //     Command.create({
            //         'tax_src_id': f"sgst_{tax_type}_{rate}",
            //         'tax_dest_id': f"igst_{tax_type}_{0 if use_zero_rated_igst and tax_type == 'purchase' else rate}{(tax_type == 'sale' and trailing_id) or ''}",
            //     })
            //     for tax_type in ["sale", "purchase"]
            //     for rate in [1, 2, 5, 12, 18, 28]  # Available existing GST Rates
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetL10nInZeroRatedWithIgstZeroTaxValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: template_in.py) ---
            // def _get_l10n_in_zero_rated_with_igst_zero_tax_vals(self):
            // return [
            //     Command.create({
            //         'tax_src_id': zero_tax,
            //         'tax_dest_id': "igst_sale_0"
            //     })
            //     for zero_tax in ["exempt_sale", "nil_rated_sale"]
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetLatamCheckAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_check, FILE: account_chart_template.py) ---
            // def _get_latam_check_account_journal(self, template_code):
            // if self.env.company.country_id.code in self._get_third_party_checks_country_codes():
            //     return {
            //         "third_party_check": {
            //             'name': _('Third Party Checks'),
            //             'type': 'cash',
            //             'outbound_payment_method_line_ids': [
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_out_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_payments',
            //                 }),
            //             ],
            //             'inbound_payment_method_line_ids': [
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_new_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_receipts',
            //                 }),
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_in_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_receipts',
            //                 }),
            //             ],
            //         },
            //         "rejected_third_party_check": {
            //             'name': _('Rejected Third Party Checks'),
            //             'type': 'cash',
            //             'outbound_payment_method_line_ids': [
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_out_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_payments',
            //                 }),
            //             ],
            //             'inbound_payment_method_line_ids': [
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_new_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_receipts',
            //                 }),
            //                 Command.create({
            //                     'payment_method_id': self.env.ref('l10n_latam_check.account_payment_method_in_third_party_checks').id,
            //                     'payment_account_id': 'base_outstanding_receipts',
            //                 }),
            //             ],
            //         },
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetLatamCheckOutstandingAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_check, FILE: account_chart_template.py) ---
            // def _get_latam_check_outstanding_account_account(self, template_code):
            // if self.env.company.country_id.code in self._get_third_party_checks_country_codes():
            //     return {
            //         'base_outstanding_receipts': {
            //             'name': _("Outstanding Receipts"),
            //             'code': '1.1.1.02.003',
            //             'reconcile': True,
            //             'account_type': 'asset_current',
            //         },
            //         'base_outstanding_payments': {
            //             'name': _("Outstanding Payments"),
            //             'code': '1.1.1.02.004',
            //             'reconcile': True,
            //             'account_type': 'asset_current',
            //         },
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetLatamDocumentAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_invoice_document, FILE: account_chart_template.py) ---
            // def _get_latam_document_account_journal(self, template_code):
            // """ We add use_documents or not depending on the context"""
            // if self.env.company._localization_use_documents():
            //     return {
            //         'sale': {'l10n_latam_use_documents': True},
            //         'purchase': {'l10n_latam_use_documents': True},
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetLbTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lb_account, FILE: template_lb.py) ---
            // def _get_lb_template_data(self):
            // return {
            //     "property_account_receivable_id": "lb_account_413004",
            //     "property_account_payable_id": "lb_account_403501",
            //     "property_account_expense_categ_id": "lb_account_601101",
            //     "property_account_income_categ_id": "lb_account_701000",
            //     "property_account_expense_id": "lb_account_601101",
            //     "property_account_income_id": "lb_account_701000",
            //     "property_stock_valuation_account_id": "lb_account_370001",
            //     "property_stock_account_input_categ_id": "lb_account_370002",
            //     "property_stock_account_output_categ_id": "lb_account_370003",
            //     "property_stock_account_production_cost_id": "lb_account_370004",
            //     "tax_payable_account_id": "lb_account_442001",
            //     "tax_receivable_account_id": "lb_account_442201",
            //     "code_digits": "6",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLebResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lb_account, FILE: template_lb.py) ---
            // def _get_leb_res_company(self):
            // return {
            //     self.env.company.id: {
            //         "account_fiscal_country_id": "base.lb",
            //         "bank_account_code_prefix": "5121",
            //         "cash_account_code_prefix": "5300",
            //         "transfer_account_code_prefix": "5400",
            //         "account_default_pos_receivable_account_id": "lb_account_413003",
            //         "income_currency_exchange_account_id": "lb_account_775100",
            //         "expense_currency_exchange_account_id": "lb_account_675100",
            //         "account_journal_suspense_account_id": "lb_account_540002",
            //         "account_journal_early_pay_discount_loss_account_id": "lb_account_709001",
            //         "account_journal_early_pay_discount_gain_account_id": "lb_account_778001",
            //         "default_cash_difference_income_account_id": "lb_account_701000",
            //         "default_cash_difference_expense_account_id": "lb_account_601101",
            //         "deferred_expense_account_id": "lb_account_472001",
            //         "deferred_revenue_account_id": "lb_account_473001",
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lt, FILE: template_lt.py) ---
            // def _get_lt_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.lt',
            //         'bank_account_code_prefix': '271',
            //         'cash_account_code_prefix': '272',
            //         'transfer_account_code_prefix': '273',
            //         'account_default_pos_receivable_account_id': 'account_account_template_2411',
            //         'income_currency_exchange_account_id': 'account_account_template_5803',
            //         'expense_currency_exchange_account_id': 'account_account_template_6803',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_account_template_509',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_account_template_6209',
            //         'account_sale_tax_id': 'account_tax_template_sales_21',
            //         'account_purchase_tax_id': 'account_tax_template_purchase_21',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lt, FILE: template_lt.py) ---
            // def _get_lt_template_data(self):
            // return {
            //     'property_account_receivable_id': 'account_account_template_2410',
            //     'property_account_payable_id': 'account_account_template_4430',
            //     'property_account_expense_categ_id': 'account_account_template_6000',
            //     'property_account_income_categ_id': 'account_account_template_5000',
            //     'property_stock_account_input_categ_id': 'account_account_template_2045',
            //     'property_stock_account_output_categ_id': 'account_account_template_2045',
            //     'property_stock_valuation_account_id': 'account_account_template_2040',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLuAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lu, FILE: template_lu.py) ---
            // def _get_lu_account_journal(self):
            // return {
            //     'sale': {'refund_sequence': True},
            //     'purchase': {'refund_sequence': True},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLuReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lu, FILE: template_lu.py) ---
            // def _get_lu_reconcile_model(self):
            // return {
            //     'bank_fees_template': {
            //         'name': 'Bank Fees',
            //         'rule_type': 'writeoff_button',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'lu_2011_account_61333',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Bank Fees',
            //             }),
            //         ],
            //     },
            //     'cash_discount_template': {
            //         'name': 'Cash Discount',
            //         'rule_type': 'writeoff_button',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'lu_2020_account_65562',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Cash Discount',
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLuResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lu, FILE: template_lu.py) ---
            // def _get_lu_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.lu',
            //         'bank_account_code_prefix': '513',
            //         'cash_account_code_prefix': '516',
            //         'transfer_account_code_prefix': '517',
            //         'account_default_pos_receivable_account_id': 'lu_2011_account_40111',
            //         'income_currency_exchange_account_id': 'lu_2020_account_7561',
            //         'expense_currency_exchange_account_id': 'lu_2020_account_6561',
            //         'account_journal_suspense_account_id': 'lu_2011_account_484',
            //         'account_journal_early_pay_discount_loss_account_id': 'lu_2020_account_65562',
            //         'account_journal_early_pay_discount_gain_account_id': 'lu_2020_account_75562',
            //         'account_sale_tax_id': 'lu_2015_tax_VP-PA-17',
            //         'account_purchase_tax_id': 'lu_2015_tax_AP-PA-17',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLuTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lu, FILE: template_lu.py) ---
            // def _get_lu_template_data(self):
            // return {
            //     'property_account_receivable_id': 'lu_2011_account_4011',
            //     'property_account_payable_id': 'lu_2011_account_44111',
            //     'property_account_expense_categ_id': 'lu_2011_account_6061',
            //     'property_account_income_categ_id': 'lu_2020_account_703001',
            //     'property_stock_account_input_categ_id': 'lu_2011_account_321',
            //     'property_stock_account_output_categ_id': 'lu_2011_account_321',
            //     'property_stock_valuation_account_id': 'lu_2020_account_60761',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLvResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lv, FILE: template_lv.py) ---
            // def _get_lv_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.lv',
            //         'bank_account_code_prefix': '2620',
            //         'cash_account_code_prefix': '2610',
            //         'transfer_account_code_prefix': '2700',
            //         'account_default_pos_receivable_account_id': 'a2613',
            //         'income_currency_exchange_account_id': 'a8150',
            //         'expense_currency_exchange_account_id': 'a8250',
            //         'account_journal_suspense_account_id': 'a26291',
            //         'account_journal_early_pay_discount_loss_account_id': 'a8299',
            //         'account_journal_early_pay_discount_gain_account_id': 'a8199',
            //         'default_cash_difference_income_account_id': 'a8199',
            //         'default_cash_difference_expense_account_id': 'a8299',
            //         'account_sale_tax_id': 'VAT_S_G_21_LV',
            //         'account_purchase_tax_id': 'VAT_P_G_21_LV',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLvTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_lv, FILE: template_lv.py) ---
            // def _get_lv_template_data(self):
            // return {
            //     'property_account_receivable_id': 'a2310',
            //     'property_account_payable_id': 'a5310',
            //     'property_account_expense_categ_id': 'a7550',
            //     'property_account_income_categ_id': 'a6110',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ma, FILE: template_ma.py) ---
            // def _get_ma_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ma',
            //         'bank_account_code_prefix': '5141',
            //         'cash_account_code_prefix': '51611',
            //         'transfer_account_code_prefix': '5115',
            //         'account_default_pos_receivable_account_id': 'pcg_34218',
            //         'income_currency_exchange_account_id': 'pcg_7331',
            //         'expense_currency_exchange_account_id': 'pcg_6331',
            //         'account_journal_suspense_account_id': 'pcg_3497',
            //         'default_cash_difference_income_account_id': 'pcg_73861',
            //         'default_cash_difference_expense_account_id': 'pcg_63861',
            //         'account_journal_early_pay_discount_gain_account_id': 'pcg_73862',
            //         'account_journal_early_pay_discount_loss_account_id': 'pcg_63862',
            //         'account_sale_tax_id': 'vat_out_20_80',
            //         'account_purchase_tax_id': 'vat_in_20_146',
            //         'tax_exigibility': 'True',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ma, FILE: template_ma.py) ---
            // def _get_ma_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'pcg_34211',
            //     'property_account_payable_id': 'pcg_44111',
            //     'property_account_income_categ_id': 'pcg_7111',
            //     'property_account_expense_categ_id': 'pcg_6111',
            //     'display_invoice_amount_total_words': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMcTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_fr_account, FILE: template_mc.py) ---
            // def _get_mc_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'parent': 'fr',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml.py) ---
            // def _get_ml_account_account(self):
            // return self._parse_csv('ml', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetMlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml.py) ---
            // def _get_ml_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ml',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetMlSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml_syscebnl.py) ---
            // def _get_ml_syscebnl_account_account(self):
            // return self._parse_csv('ml_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetMlSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml_syscebnl.py) ---
            // def _get_ml_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ml',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetMlSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml_syscebnl.py) ---
            // def _get_ml_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ml, FILE: template_ml.py) ---
            // def _get_ml_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mn, FILE: template_mn.py) ---
            // def _get_mn_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.mn',
            //         'bank_account_code_prefix': '11',
            //         'cash_account_code_prefix': '10',
            //         'transfer_account_code_prefix': '1109',
            //         'account_default_pos_receivable_account_id': 'account_template_1201_0202',
            //         'income_currency_exchange_account_id': 'account_template_5301_0201',
            //         'expense_currency_exchange_account_id': 'account_template_5302_0201',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_template_5701_0201',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_template_5701_0101',
            //         'account_sale_tax_id': 'account_tax_sale_vat1',
            //         'account_purchase_tax_id': 'account_tax_purchase_vat1',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mn, FILE: template_mn.py) ---
            // def _get_mn_template_data(self):
            // return {
            //     'property_account_receivable_id': 'account_template_1201_0201',
            //     'property_account_payable_id': 'account_template_3101_0201',
            //     'property_account_expense_categ_id': 'account_template_6101_0101',
            //     'property_account_income_categ_id': 'account_template_5101_0101',
            //     'property_stock_account_input_categ_id': 'account_template_1407_0101',
            //     'property_stock_account_output_categ_id': 'account_template_1408_0101',
            //     'property_stock_valuation_account_id': 'account_template_1401_0101',
            //     'code_digits': '8',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mt, FILE: template_mt.py) ---
            // def _get_mt_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.mt',
            //         'bank_account_code_prefix': '2150',
            //         'cash_account_code_prefix': '2155',
            //         'transfer_account_code_prefix': '2300',
            //         'account_default_pos_receivable_account_id': 'mt_2040',
            //         'income_currency_exchange_account_id': 'mt_5400',
            //         'expense_currency_exchange_account_id': 'mt_5540',
            //         'account_sale_tax_id': 'VAT_S_IN_MT_18_G',
            //         'account_purchase_tax_id': 'VAT_P_IN_MT_18_G',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mt, FILE: template_mt.py) ---
            // def _get_mt_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'mt_2050',
            //     'property_account_payable_id': 'mt_3100',
            //     'property_account_expense_categ_id': 'mt_5550',
            //     'property_account_income_categ_id': 'mt_5000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMuResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mu_account, FILE: template_mu.py) ---
            // def _get_mu_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.mu',
            //         'bank_account_code_prefix': '230',
            //         'cash_account_code_prefix': '231',
            //         'transfer_account_code_prefix': '232',
            //         'account_default_pos_receivable_account_id': 'mu_pos_receivable',
            //         'income_currency_exchange_account_id': 'mu_income_currency_exchange',
            //         'expense_currency_exchange_account_id': 'mu_expense_currency_exchange',
            //         'account_journal_early_pay_discount_gain_account_id': 'mu_cash_discount_gain',
            //         'account_journal_early_pay_discount_loss_account_id': 'mu_cash_discount_loss',
            //         'default_cash_difference_income_account_id': 'mu_cash_diff_income',
            //         'default_cash_difference_expense_account_id': 'mu_cash_diff_expense',
            //         'account_sale_tax_id': 'mu_tax_sale_15',
            //         'account_purchase_tax_id': 'mu_tax_purchase_15',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMuTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mu_account, FILE: template_mu.py) ---
            // def _get_mu_template_data(self):
            // return {
            //     'property_account_receivable_id': 'mu_receivable',
            //     'property_account_payable_id': 'mu_payable',
            //     'property_account_expense_categ_id': 'mu_expense',
            //     'property_account_income_categ_id': 'mu_income',
            //     'property_stock_valuation_account_id': 'mu_stock_valuation',
            //     'property_advance_tax_payment_account_id': 'mu_tax_paid',
            //     'property_tax_payable_account_id': 'mu_tax_payable',
            //     'property_tax_receivable_account_id': 'mu_tax_receivable',
            //     'use_anglo_saxon': False,
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMxAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mx, FILE: template_mx.py) ---
            // def _get_mx_account_journal(self):
            // return {
            //     "cbmx": {
            //         'type': 'general',
            //         'name': _('Effectively Paid'),
            //         'code': 'CBMX',
            //         'default_account_id': "cuenta118_01",
            //         'show_on_dashboard': True,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMxResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mx, FILE: template_mx.py) ---
            // def _get_mx_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.mx',
            //         'bank_account_code_prefix': '102.01.0',
            //         'cash_account_code_prefix': '101.01.0',
            //         'transfer_account_code_prefix': '102.01.01',
            //         'account_default_pos_receivable_account_id': 'cuenta105_02',
            //         'income_currency_exchange_account_id': 'cuenta702_01',
            //         'expense_currency_exchange_account_id': 'cuenta701_01',
            //         'deferred_expense_account_id': 'cuenta173_01',
            //         'account_journal_early_pay_discount_loss_account_id': 'cuenta402_01',
            //         'account_journal_early_pay_discount_gain_account_id': 'cuenta503_01',
            //         'tax_cash_basis_journal_id': 'cbmx',
            //         'tax_calculation_rounding_method': 'round_globally',
            //         'account_sale_tax_id': 'tax12',
            //         'account_purchase_tax_id': 'tax14',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMxTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mx, FILE: template_mx.py) ---
            // def _get_mx_template_data(self):
            // return {
            //     'code_digits': '9',
            //     'display_invoice_amount_total_words': True,
            //     'property_account_receivable_id': 'cuenta105_01',
            //     'property_account_payable_id': 'cuenta201_01',
            //     'property_account_expense_categ_id': 'cuenta601_84',
            //     'property_account_income_categ_id': 'cuenta401_01',
            //     'property_stock_account_input_categ_id': 'cuenta205_06_01',
            //     'property_stock_account_output_categ_id': 'cuenta107_05_01',
            //     'property_stock_valuation_account_id': 'cuenta115_01',
            //     'property_cash_basis_base_account_id': 'cuenta801_01_99',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMyResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my, FILE: template_my.py) ---
            // def _get_my_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.my',
            //         'bank_account_code_prefix': '1200',
            //         'cash_account_code_prefix': '1210',
            //         'transfer_account_code_prefix': '111220',
            //         'account_default_pos_receivable_account_id': 'l10n_my_1243',
            //         'income_currency_exchange_account_id': 'l10n_my_4240',
            //         'expense_currency_exchange_account_id': 'l10n_my_5240',
            //         'account_sale_tax_id': 'l10n_my_tax_sale_10',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMyTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my, FILE: template_my.py) ---
            // def _get_my_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_my_1240',
            //     'property_account_payable_id': 'l10n_my_2211',
            //     'property_account_income_categ_id': 'l10n_my_41',
            //     'property_account_expense_categ_id': 'l10n_my_51',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mz, FILE: template_mz.py) ---
            // def _get_mz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.mz',
            //         'bank_account_code_prefix': '12',
            //         'cash_account_code_prefix': '11',
            //         'transfer_account_code_prefix': '456',
            //         'account_default_pos_receivable_account_id': 'l10n_mz_account_413',
            //         'income_currency_exchange_account_id': 'l10n_mz_account_7841',
            //         'expense_currency_exchange_account_id': 'l10n_mz_account_6941',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_mz_account_695',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_mz_account_785',
            //         'account_sale_tax_id': 'vat_sale_16',
            //         'account_purchase_tax_id': 'vat_purch_16_inventories',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_mz, FILE: template_mz.py) ---
            // def _get_mz_template_data(self):
            // return {
            //     'code_digits': '7',
            //     'property_account_receivable_id': 'l10n_mz_account_411',
            //     'property_account_payable_id': 'l10n_mz_account_421',
            //     'property_account_expense_categ_id': 'l10n_mz_account_61161',
            //     'property_account_income_categ_id': 'l10n_mz_account_711',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNeAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne.py) ---
            // def _get_ne_account_account(self):
            // return self._parse_csv('ne', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetNeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne.py) ---
            // def _get_ne_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ne',
            //         'account_sale_tax_id': 'tva_sale_19',
            //         'account_purchase_tax_id': 'tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetNeSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne_syscebnl.py) ---
            // def _get_ne_syscebnl_account_account(self):
            // return self._parse_csv('ne_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetNeSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne_syscebnl.py) ---
            // def _get_ne_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.ne',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_19',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_19',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetNeSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne_syscebnl.py) ---
            // def _get_ne_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ne, FILE: template_ne.py) ---
            // def _get_ne_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNgAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ng, FILE: template_ng.py) ---
            // def _get_ng_account_account(self):
            // """ Nigerian companies are fine with using the generic COA
            // but we need to add Nigeria-specific taxes and a tax report
            // """
            // return {
            //     **{f'l10n_ng_{k}': v for k, v in self._parse_csv('generic_coa', 'account.account').items()},
            //     'l10n_ng_withholding': {
            //         'name': _("Withholding Tax on Purchases"),
            //         'code': '252001',
            //         'account_type': 'liability_current',
            //         'reconcile': False,
            //     },
            //     'l10n_ng_withholding_transitional': {
            //         'name': _("Withholding Tax on Purchases - Transition Account"),
            //         'code': '252002',
            //         'account_type': 'liability_current',
            //         'reconcile': False,
            //     },
            //     'l10n_ng_withholding_payable': {
            //         'name': _("Withholding Tax Payable"),
            //         'code': '252003',
            //         'account_type': 'liability_payable',
            //         'reconcile': True,
            //         'non_trade': True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ng, FILE: template_ng.py) ---
            // def _get_ng_res_company(self):
            // res_company_data = self._get_generic_coa_res_company()[self.env.company.id]
            // res_company_data['account_fiscal_country_id'] = 'base.ng'
            // 
            // for field, value in res_company_data.items():
            //     if 'account_id' in field:
            //         res_company_data[field] = f'l10n_ng_{value}'
            // return {self.env.company.id: res_company_data}
            */
            return default;
        }

        public async Task<TEntity> GetNgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ng, FILE: template_ng.py) ---
            // def _get_ng_template_data(self):
            // """ Copies the generic CoA template data.
            // Changes to it will be reflected here as well.
            // We remove the name and country to use the default values,
            // whereas the generic CoA has to override these.
            // """
            // res = self._get_generic_coa_template_data()
            // return {k: f'l10n_ng_{v}' for k, v in res.items() if k not in ('name', 'country')}
            */
            return default;
        }

        public async Task<TEntity> GetNlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_nl, FILE: template_nl.py) ---
            // def _get_nl_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.nl',
            //         'bank_account_code_prefix': '103',
            //         'cash_account_code_prefix': '101',
            //         'transfer_account_code_prefix': '1060',
            //         'account_default_pos_receivable_account_id': 'recv_pos',
            //         'income_currency_exchange_account_id': '8920',
            //         'expense_currency_exchange_account_id': '4920',
            //         'account_journal_early_pay_discount_loss_account_id': '7065',
            //         'account_journal_early_pay_discount_gain_account_id': '8065',
            //         'l10n_nl_rounding_difference_loss_account_id': '4960',
            //         'l10n_nl_rounding_difference_profit_account_id': '4950',
            //         'account_sale_tax_id': 'btw_21',
            //         'account_purchase_tax_id': 'btw_21_buy',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_nl, FILE: template_nl.py) ---
            // def _get_nl_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'recv',
            //     'property_account_payable_id': 'pay',
            //     'property_account_expense_categ_id': '7001',
            //     'property_account_income_categ_id': '8001',
            //     'property_stock_account_input_categ_id': '1450',
            //     'property_stock_account_output_categ_id': '1250',
            //     'property_stock_valuation_account_id': '3200',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_no, FILE: template_no.py) ---
            // def _get_no_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.no',
            //         'bank_account_code_prefix': '1920',
            //         'cash_account_code_prefix': '1900',
            //         'transfer_account_code_prefix': '1940',
            //         'account_default_pos_receivable_account_id': 'chart1500',
            //         'income_currency_exchange_account_id': 'chart8060',
            //         'expense_currency_exchange_account_id': 'chart8160',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart4372',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart3082',
            //         'account_sale_tax_id': 'tax3',
            //         'account_purchase_tax_id': 'tax2',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_no, FILE: template_no.py) ---
            // def _get_no_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'chart1500',
            //     'property_account_payable_id': 'chart2400',
            //     'property_account_expense_categ_id': 'chart4000',
            //     'property_account_income_categ_id': 'chart3000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_nz, FILE: template_nz.py) ---
            // def _get_nz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.nz',
            //         'bank_account_code_prefix': '1111',
            //         'cash_account_code_prefix': '1113',
            //         'transfer_account_code_prefix': '11170',
            //         'account_default_pos_receivable_account_id': 'nz_11220',
            //         'income_currency_exchange_account_id': 'nz_61630',
            //         'expense_currency_exchange_account_id': 'nz_61630',
            //         'account_journal_early_pay_discount_loss_account_id': 'nz_61610',
            //         'account_journal_early_pay_discount_gain_account_id': 'nz_61620',
            //         'account_sale_tax_id': 'nz_tax_sale_15',
            //         'account_purchase_tax_id': 'nz_tax_purchase_15',
            //         'fiscalyear_last_month': '3',
            //         'fiscalyear_last_day': 31,
            //         # Changing the opening date to the first day of the fiscal year.
            //         # This way the opening entries will be set to the 31st of March.
            //         'account_opening_date': fields.Date.context_today(self).replace(month=4, day=1),
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_nz, FILE: template_nz.py) ---
            // def _get_nz_template_data(self):
            // return {
            //     'code_digits': '5',
            //     'property_account_receivable_id': 'nz_11200',
            //     'property_account_payable_id': 'nz_21200',
            //     'property_account_expense_categ_id': 'nz_51110',
            //     'property_account_income_categ_id': 'nz_41110',
            //     'property_stock_account_input_categ_id': 'nz_21210',
            //     'property_stock_account_output_categ_id': 'nz_11340',
            //     'property_stock_valuation_account_id': 'nz_11330',
            //     'property_stock_account_production_cost_id': 'nz_11350',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetOmResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_om, FILE: template_om.py) ---
            // def _get_om_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.om',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1009',
            //         'transfer_account_code_prefix': '1001',
            //         'account_default_pos_receivable_account_id': 'om_account_100202',
            //         'income_currency_exchange_account_id': 'om_account_400301',
            //         'expense_currency_exchange_account_id': 'om_account_500903',
            //         'account_journal_suspense_account_id': 'om_account_100102',
            //         'account_journal_early_pay_discount_loss_account_id': 'om_account_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'om_account_400304',
            //         'default_cash_difference_income_account_id': 'om_account_400302',
            //         'default_cash_difference_expense_account_id': 'om_account_500909',
            //         'deferred_expense_account_id': 'om_account_100416',
            //         'deferred_revenue_account_id': 'om_account_200401',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetOmTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_om, FILE: template_om.py) ---
            // def _get_om_template_data(self):
            // return {
            //     'property_account_receivable_id': 'om_account_100201',
            //     'property_account_payable_id': 'om_account_200101',
            //     'property_account_expense_categ_id': 'om_account_500101',
            //     'property_account_income_categ_id': 'om_account_400101',
            //     'property_account_expense_id': 'om_account_500101',
            //     'property_account_income_id': 'om_account_400101',
            //     'property_stock_valuation_account_id': 'om_account_100502',
            //     'property_stock_account_input_categ_id': 'om_account_100503',
            //     'property_stock_account_output_categ_id': 'om_account_100504',
            //     'property_stock_account_production_cost_id': 'om_account_100505',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pa, FILE: template_pa.py) ---
            // def _get_pa_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.pa',
            //         'bank_account_code_prefix': '111.',
            //         'cash_account_code_prefix': '113.',
            //         'transfer_account_code_prefix': '112.',
            //         'account_default_pos_receivable_account_id': '121_01',
            //         'income_currency_exchange_account_id': 'gain81_01',
            //         'expense_currency_exchange_account_id': 'loss81_01',
            //         'account_sale_tax_id': 'ITAX_19',
            //         'account_purchase_tax_id': 'OTAX_19',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pa, FILE: template_pa.py) ---
            // def _get_pa_template_data(self):
            // return {
            //     'code_digits': '7',
            //     'property_account_receivable_id': '121',
            //     'property_account_payable_id': '211',
            //     'property_account_expense_categ_id': '62_01',
            //     'property_account_income_categ_id': '411_01',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetParentTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_parent_template(self, code):
            // parents = []
            // template_mapping = self._get_chart_template_mapping(get_all=True)
            // while template_mapping.get(code):
            //     parents.append(code)
            //     code = template_mapping.get(code).get('parent')
            // return parents
            */
            return default;
        }

        public async Task<TEntity> GetPeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe, FILE: template_pe.py) ---
            // def _get_pe_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.pe',
            //         'bank_account_code_prefix': '1041',
            //         'cash_account_code_prefix': '1031',
            //         'transfer_account_code_prefix': '1051',
            //         'account_default_pos_receivable_account_id': 'chart1215',
            //         'income_currency_exchange_account_id': 'chart776',
            //         'expense_currency_exchange_account_id': 'chart676',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart675',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart775',
            //         'account_sale_tax_id': 'sale_tax_igv_18',
            //         'account_purchase_tax_id': 'purchase_tax_igv_18',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe, FILE: template_pe.py) ---
            // def _get_pe_template_data(self):
            // return {
            //     'property_account_receivable_id': 'chart1213',
            //     'property_account_payable_id': 'chart4212',
            //     'property_account_expense_categ_id': 'chart6329',
            //     'property_account_income_categ_id': 'chart70121',
            //     'property_stock_account_input_categ_id': 'chart6111',
            //     'property_stock_account_output_categ_id': 'chart69111',
            //     'property_stock_valuation_account_id': 'chart20111',
            //     'code_digits': '7',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPhResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ph, FILE: template_ph.py) ---
            // def _get_ph_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.ph',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1001',
            //         'transfer_account_code_prefix': '1002',
            //         'account_default_pos_receivable_account_id': 'l10n_ph_110003',
            //         'income_currency_exchange_account_id': 'l10n_ph_710100',
            //         'expense_currency_exchange_account_id': 'l10n_ph_710101',
            //         'account_journal_suspense_account_id': 'l10n_ph_100000',
            //         'default_cash_difference_income_account_id': 'l10n_ph_710102',
            //         'default_cash_difference_expense_account_id': 'l10n_ph_710103',
            //         'account_sale_tax_id': 'l10n_ph_tax_sale_vat_12',
            //         'account_purchase_tax_id': 'l10n_ph_tax_purchase_vat_12',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPhTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ph, FILE: template_ph.py) ---
            // def _get_ph_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_ph_110000',
            //     'property_account_payable_id': 'l10n_ph_200000',
            //     'property_account_income_categ_id': 'l10n_ph_430400',
            //     'property_account_expense_categ_id': 'l10n_ph_620000',
            //     'property_stock_valuation_account_id': 'l10n_ph_110300',
            //     'property_stock_account_input_categ_id': 'l10n_ph_110302',
            //     'property_stock_account_output_categ_id': 'l10n_ph_110303',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPkResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pk, FILE: template_pk.py) ---
            // def _get_pk_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.pk',
            //         'bank_account_code_prefix': '112600',
            //         'cash_account_code_prefix': '112600',
            //         'transfer_account_code_prefix': '112600',
            //         'account_default_pos_receivable_account_id': 'l10n_pk_1121001',
            //         'account_journal_suspense_account_id': 'l10n_pk_2226000',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_pk_4411003',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_pk_3112004',
            //         'account_sale_tax_id': 'pk_sales_tax_17',
            //         'account_purchase_tax_id': 'purchases_tax_17',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPkTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pk, FILE: template_pk.py) ---
            // def _get_pk_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_pk_1121001',
            //     'property_account_payable_id': 'l10n_pk_2221001',
            //     'property_account_income_categ_id': 'l10n_pk_3111001',
            //     'property_account_expense_categ_id': 'l10n_pk_4111001',
            //     'code_digits': '7',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pl, FILE: template_pl.py) ---
            // def _get_pl_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.pl',
            //         'bank_account_code_prefix': '11.000.00',
            //         'cash_account_code_prefix': '12.000.00',
            //         'transfer_account_code_prefix': '11.090.00',
            //         'account_default_pos_receivable_account_id': 'chart20000200',
            //         'income_currency_exchange_account_id': 'chart75000600',
            //         'expense_currency_exchange_account_id': 'chart75010400',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart75010900',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart75000900',
            //         'default_cash_difference_income_account_id': 'chart75000700',
            //         'default_cash_difference_expense_account_id': 'chart75010500',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pl, FILE: template_pl.py) ---
            // def _get_pl_template_data(self):
            // return {
            //     'property_account_receivable_id': 'chart20000100',
            //     'property_account_payable_id': 'chart21000100',
            //     'property_account_expense_categ_id': 'chart70010100',
            //     'property_account_income_categ_id': 'chart73000100',
            //     'code_digits': '8',
            //     'use_storno_accounting': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: template_es_common_mainland.py) ---
            // def _get_product(self):
            // return {
            //     'l10n_es.product_dua_valuation_4': {'supplier_taxes_id': [Command.set(['account_tax_template_p_iva4_ibc_group'])]},
            //     'l10n_es.product_dua_valuation_10': {'supplier_taxes_id': [Command.set(['account_tax_template_p_iva10_ibc_group'])]},
            //     'l10n_es.product_dua_valuation_21': {'supplier_taxes_id': [Command.set(['account_tax_template_p_iva21_ibc_group'])]},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPropertyAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_properties) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_property_accounts(self, additional_properties):
            // return {
            //     **additional_properties,
            //     'property_account_receivable_id': 'res.partner',
            //     'property_account_payable_id': 'res.partner',
            //     'property_account_expense_categ_id': 'product.category',
            //     'property_account_income_categ_id': 'product.category',
            //     'property_stock_journal': 'product.category',
            // }
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: chart_template.py) ---
            // def _get_property_accounts(self, additional_properties):
            // property_accounts = super()._get_property_accounts(additional_properties)
            // property_accounts['property_account_downpayment_categ_id'] = 'product.category'
            // return property_accounts
            */
            return default;
        }

        public async Task<TEntity> GetPtResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pt, FILE: template_pt.py) ---
            // def _get_pt_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.pt',
            //         'bank_account_code_prefix': '12',
            //         'cash_account_code_prefix': '11',
            //         'transfer_account_code_prefix': '1431',
            //         'account_default_pos_receivable_account_id': 'chart_2117',
            //         'income_currency_exchange_account_id': 'chart_7861',
            //         'expense_currency_exchange_account_id': 'chart_6863',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart_682',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart_728',
            //         'account_sale_tax_id': 'iva_pt_sale_normal',
            //         'account_purchase_tax_id': 'iva_pt_purchase_normal',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPtTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pt, FILE: template_pt.py) ---
            // def _get_pt_template_data(self):
            // return {
            //     'property_account_receivable_id': 'chart_2111',
            //     'property_account_payable_id': 'chart_2211',
            //     'property_account_income_categ_id': 'chart_711',
            //     'property_account_expense_categ_id': 'chart_311',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetQaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_qa, FILE: template_qa.py) ---
            // def _get_qa_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.qa',
            //         'bank_account_code_prefix': '1000',
            //         'cash_account_code_prefix': '1009',
            //         'transfer_account_code_prefix': '1001',
            //         'account_default_pos_receivable_account_id': 'qa_account_100202',
            //         'income_currency_exchange_account_id': 'qa_account_400301',
            //         'expense_currency_exchange_account_id': 'qa_account_500903',
            //         'account_journal_suspense_account_id': 'qa_account_100102',
            //         'account_journal_early_pay_discount_loss_account_id': 'qa_account_501107',
            //         'account_journal_early_pay_discount_gain_account_id': 'qa_account_400304',
            //         'default_cash_difference_income_account_id': 'qa_account_400302',
            //         'default_cash_difference_expense_account_id': 'qa_account_500909',
            //         'deferred_expense_account_id': 'qa_account_100416',
            //         'deferred_revenue_account_id': 'qa_account_200401',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetQaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_qa, FILE: template_qa.py) ---
            // def _get_qa_template_data(self):
            // return {
            //     'property_account_receivable_id': 'qa_account_100201',
            //     'property_account_payable_id': 'qa_account_200101',
            //     'property_account_expense_categ_id': 'qa_account_500101',
            //     'property_account_income_categ_id': 'qa_account_400101',
            //     'property_account_expense_id': 'qa_account_500101',
            //     'property_account_income_id': 'qa_account_400101',
            //     'property_stock_valuation_account_id': 'qa_account_100502',
            //     'property_stock_account_input_categ_id': 'qa_account_100503',
            //     'property_stock_account_output_categ_id': 'qa_account_100504',
            //     'property_stock_account_production_cost_id': 'qa_account_100505',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRoReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ro, FILE: template_ro.py) ---
            // def _get_ro_reconcile_model(self):
            // return {
            //     'suppadvance_template': {
            //         'name': 'Avans Furnizor - Imobilizări Necorporale',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_4094',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Supplier Advance - Intangible Assets',
            //             }),
            //         ],
            //     },
            //     'custadvance_template': {
            //         'name': 'Customer Advances',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_419',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Customer Advances',
            //             }),
            //         ],
            //     },
            //     'bankcomm_template': {
            //         'name': 'Bank Commission',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_627',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Bank Commission',
            //             }),
            //         ],
            //     },
            //     'interest_template': {
            //         'name': 'Interests',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_766',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Interests',
            //             }),
            //         ],
            //     },
            //     'inttransfer_template': {
            //         'name': 'Internal transfer',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_581',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Internal transfer',
            //             }),
            //         ],
            //     },
            //     'payroll_template': {
            //         'name': 'Wages',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_421',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Wages',
            //             }),
            //         ],
            //     },
            //     'pendsettl_template': {
            //         'name': 'Operations being clarified',
            //         'line_ids': [
            //             Command.create({
            //                 'account_id': 'pcg_473',
            //                 'amount_type': 'percentage',
            //                 'amount_string': '100',
            //                 'label': 'Operations being clarified',
            //             }),
            //         ],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRoResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ro, FILE: template_ro.py) ---
            // def _get_ro_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ro',
            //         'bank_account_code_prefix': '5121',
            //         'cash_account_code_prefix': '5311',
            //         'transfer_account_code_prefix': '581',
            //         'account_default_pos_receivable_account_id': 'ro_pcg_recv',
            //         'income_currency_exchange_account_id': 'pcg_7651',
            //         'expense_currency_exchange_account_id': 'pcg_6651',
            //         'account_journal_suspense_account_id': 'pcg_5125',
            //         'account_journal_early_pay_discount_loss_account_id': 'pcg_6092',
            //         'account_journal_early_pay_discount_gain_account_id': 'pcg_709',
            //         'account_sale_tax_id': 'tvac_19',
            //         'account_purchase_tax_id': 'tvad_19',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRoTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ro, FILE: template_ro.py) ---
            // def _get_ro_template_data(self):
            // return {
            //     'property_account_receivable_id': 'ro_pcg_recv',
            //     'property_account_payable_id': 'pcg_4011',
            //     'property_account_expense_categ_id': 'ro_pcg_expense',
            //     'property_account_income_categ_id': 'ro_pcg_sale',
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRsResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs, FILE: template_rs.py) ---
            // def _get_rs_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.rs',
            //         'bank_account_code_prefix': '241',
            //         'cash_account_code_prefix': '243',
            //         'transfer_account_code_prefix': '250',
            //         'income_currency_exchange_account_id': 'rs_663',
            //         'expense_currency_exchange_account_id': 'rs_563',
            //         'default_cash_difference_income_account_id': 'rs_6791',
            //         'default_cash_difference_expense_account_id': 'rs_5791',
            //         'account_sale_tax_id': 'rs_sale_vat_20',
            //         'account_purchase_tax_id': 'rs_purchase_vat_20',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRsTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs, FILE: template_rs.py) ---
            // def _get_rs_template_data(self):
            // return {
            //     'property_account_expense_categ_id': 'rs_501',
            //     'property_account_income_categ_id': 'rs_604',
            //     'property_account_payable_id': 'rs_435',
            //     'property_account_receivable_id': 'rs_204',
            //     'code_digits': '4',
            //     'use_storno_accounting': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRwResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rw, FILE: template_rw.py) ---
            // def _get_rw_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.rw',
            //         'cash_account_code_prefix': '101',
            //         'bank_account_code_prefix': '103',
            //         'transfer_account_code_prefix': '105',
            //         'account_default_pos_receivable_account_id': 'rw_155',
            //         'income_currency_exchange_account_id': 'rw_671',
            //         'expense_currency_exchange_account_id': 'rw_672',
            //         'deferred_revenue_account_id': 'rw_181',
            //         'deferred_expense_account_id': 'rw_342',
            //         'account_sale_tax_id': 'VAT_S_IN_RW_18',
            //         'account_purchase_tax_id': 'VAT_P_IN_RW_18',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRwTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rw, FILE: template_rw.py) ---
            // def _get_rw_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'rw_190',
            //     'property_account_payable_id': 'rw_311',
            //     'property_account_expense_categ_id': 'rw_510',
            //     'property_account_income_categ_id': 'rw_400',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSaAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa, FILE: template_sa.py) ---
            // def _get_sa_account_account(self):
            // return {
            //     "sa_account_100101": {'allowed_journal_ids': [Command.link('ifrs16')]},
            //     "sa_account_100102": {'allowed_journal_ids': [Command.link('ifrs16')]},
            //     "sa_account_400070": {'allowed_journal_ids': [Command.link('ifrs16')]},
            //     "sa_account_201019": {'allowed_journal_ids': [Command.link('zakat')]},
            //     "sa_account_400072": {'allowed_journal_ids': [Command.link('zakat')]},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSaAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa, FILE: template_sa.py) ---
            // def _get_sa_account_journal(self):
            // """ If Saudi Arabia chart, we add 3 new journals Tax Adjustments, IFRS 16 and Zakat"""
            // return {
            //     "tax_adjustment": {
            //         'name': 'Tax Adjustments',
            //         'code': 'TA',
            //         'type': 'general',
            //         'show_on_dashboard': True,
            //         'sequence': 1,
            //     },
            //     "ifrs16": {
            //         'name': 'IFRS 16 Right of Use Asset',
            //         'code': 'IFRS',
            //         'type': 'general',
            //         'show_on_dashboard': True,
            //         'sequence': 10,
            //     },
            //     "zakat": {
            //         'name': 'Zakat',
            //         'code': 'ZAKAT',
            //         'type': 'general',
            //         'show_on_dashboard': True,
            //         'sequence': 10,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa, FILE: template_sa.py) ---
            // def _get_sa_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.sa',
            //         'bank_account_code_prefix': '101',
            //         'cash_account_code_prefix': '105',
            //         'transfer_account_code_prefix': '100',
            //         'account_default_pos_receivable_account_id': 'sa_account_102012',
            //         'income_currency_exchange_account_id': 'sa_account_500011',
            //         'expense_currency_exchange_account_id': 'sa_account_400053',
            //         'account_sale_tax_id': 'sa_sales_tax_15',
            //         'account_purchase_tax_id': 'sa_purchase_tax_15',
            //         'deferred_expense_account_id': 'sa_account_104020',
            //         'deferred_revenue_account_id': 'sa_account_201018'
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa, FILE: template_sa.py) ---
            // def _get_sa_template_data(self):
            // return {
            //     'property_account_receivable_id': 'sa_account_102011',
            //     'property_account_payable_id': 'sa_account_201002',
            //     'property_account_expense_categ_id': 'sa_account_400001',
            //     'property_account_income_categ_id': 'sa_account_500001',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeK2ResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se_K2.py) ---
            // def _get_se_K2_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.se',
            //         'bank_account_code_prefix': '193',
            //         'cash_account_code_prefix': '191',
            //         'transfer_account_code_prefix': '194',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeK2TemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se_K2.py) ---
            // def _get_se_K2_template_data(self):
            // return {
            //     'name': 'Swedish BAS Chart of Account complete K2',
            //     'parent': 'se',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeK3ResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se_K3.py) ---
            // def _get_se_K3_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.se',
            //         'bank_account_code_prefix': '193',
            //         'cash_account_code_prefix': '191',
            //         'transfer_account_code_prefix': '194',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeK3TemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se_K3.py) ---
            // def _get_se_K3_template_data(self):
            // return {
            //     'name': 'Swedish BAS Chart of Account complete K3',
            //     'parent': 'se_K2',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se.py) ---
            // def _get_se_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.se',
            //         'bank_account_code_prefix': '193',
            //         'cash_account_code_prefix': '191',
            //         'transfer_account_code_prefix': '194',
            //         'account_default_pos_receivable_account_id': 'a1910',
            //         'income_currency_exchange_account_id': 'a3960',
            //         'expense_currency_exchange_account_id': 'a3960',
            //         'account_journal_early_pay_discount_loss_account_id': 'a9993',
            //         'account_journal_early_pay_discount_gain_account_id': 'a9994',
            //         'account_sale_tax_id': 'sale_tax_25_goods',
            //         'account_purchase_tax_id': 'purchase_tax_25_goods',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: template_se.py) ---
            // def _get_se_template_data(self):
            // return {
            //     'property_account_receivable_id': 'a1510',
            //     'property_account_payable_id': 'a2440',
            //     'property_account_expense_categ_id': 'a4000',
            //     'property_account_income_categ_id': 'a3001',
            //     'property_stock_account_input_categ_id': 'a4960',
            //     'property_stock_account_output_categ_id': 'a4960',
            //     'property_stock_valuation_account_id': 'a1410',
            //     'code_digits': '4',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg, FILE: template_sg.py) ---
            // def _get_sg_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.sg',
            //         'bank_account_code_prefix': '10141',
            //         'cash_account_code_prefix': '10140',
            //         'transfer_account_code_prefix': '101100',
            //         'account_default_pos_receivable_account_id': 'account_account_737',
            //         'income_currency_exchange_account_id': 'account_account_853',
            //         'expense_currency_exchange_account_id': 'account_account_853',
            //         'account_journal_early_pay_discount_loss_account_id': 'account_account_800',
            //         'account_journal_early_pay_discount_gain_account_id': 'account_account_856',
            //         'account_sale_tax_id': 'sg_sale_tax_sr_9',
            //         'account_purchase_tax_id': 'sg_purchase_tax_tx8_9',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg, FILE: template_sg.py) ---
            // def _get_sg_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'account_account_735',
            //     'property_account_payable_id': 'account_account_777',
            //     'property_account_expense_categ_id': 'account_account_819',
            //     'property_account_income_categ_id': 'account_account_803',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSiResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_si, FILE: template_si.py) ---
            // def _get_si_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.si',
            //         'bank_account_code_prefix': '110',
            //         'cash_account_code_prefix': '100',
            //         'transfer_account_code_prefix': '109',
            //         'account_default_pos_receivable_account_id': 'gd_acc_125000',
            //         'income_currency_exchange_account_id': 'gd_acc_777000',
            //         'expense_currency_exchange_account_id': 'gd_acc_484000',
            //         'account_sale_tax_id': 'gd_taxr_3',
            //         'account_purchase_tax_id': 'gd_taxp_3',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSiTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_si, FILE: template_si.py) ---
            // def _get_si_template_data(self):
            // return {
            //     'property_account_receivable_id': 'gd_acc_120000',
            //     'property_account_payable_id': 'gd_acc_220000',
            //     'property_account_expense_categ_id': 'gd_acc_702000',
            //     'property_account_income_categ_id': 'gd_acc_762000',
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSkResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sk, FILE: template_sk.py) ---
            // def _get_sk_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.sk',
            //         'bank_account_code_prefix': '221',
            //         'cash_account_code_prefix': '211',
            //         'transfer_account_code_prefix': '261',
            //         'income_currency_exchange_account_id': 'chart_sk_663000',
            //         'expense_currency_exchange_account_id': 'chart_sk_563000',
            //         'account_journal_suspense_account_id': 'chart_sk_261000',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart_sk_546000',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart_sk_646000',
            //         'default_cash_difference_income_account_id': 'chart_sk_668000',
            //         'default_cash_difference_expense_account_id': 'chart_sk_568000',
            //         'account_sale_tax_id': 'vy_tuz_23',
            //         'account_purchase_tax_id': 'vs_tuz_23',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSkTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sk, FILE: template_sk.py) ---
            // def _get_sk_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            //     'property_account_receivable_id': 'chart_sk_311000',
            //     'property_account_payable_id': 'chart_sk_321000',
            //     'property_account_expense_categ_id': 'chart_sk_504000',
            //     'property_account_income_categ_id': 'chart_sk_604000',
            //     'property_stock_account_input_categ_id': 'chart_sk_131000',
            //     'property_stock_account_output_categ_id': 'chart_sk_504000',
            //     'property_stock_valuation_account_id': 'chart_sk_132000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSnAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn.py) ---
            // def _get_sn_account_account(self):
            // return self._parse_csv('sn', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetSnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn.py) ---
            // def _get_sn_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.sn',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetSnSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn_syscebnl.py) ---
            // def _get_sn_syscebnl_account_account(self):
            // return self._parse_csv('sn_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetSnSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn_syscebnl.py) ---
            // def _get_sn_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.sn',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetSnSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn_syscebnl.py) ---
            // def _get_sn_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sn, FILE: template_sn.py) ---
            // def _get_sn_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetStockAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py) ---
            // def _get_stock_account_journal(self, template_code):
            // return {
            //     'inventory_valuation': {
            //         'name': _('Inventory Valuation'),
            //         'code': 'STJ',
            //         'type': 'general',
            //         'sequence': 10,
            //         'show_on_dashboard': False,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetStockTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py) ---
            // def _get_stock_template_data(self, template_code):
            // return {
            //     'property_stock_journal': 'inventory_valuation',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_syscohada, FILE: template_syscebnl.py) ---
            // def _get_syscebnl_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'bank_account_code_prefix': '521',
            //         'cash_account_code_prefix': '571',
            //         'transfer_account_code_prefix': '585',
            //         'account_default_pos_receivable_account_id': 'syscebnl_412',
            //         'income_currency_exchange_account_id': 'syscebnl_776',
            //         'expense_currency_exchange_account_id': 'syscebnl_676',
            //         'account_journal_early_pay_discount_loss_account_id': 'syscebnl_601',
            //         'account_journal_early_pay_discount_gain_account_id': 'syscebnl_773',
            //         'default_cash_difference_expense_account_id': 'syscebnl_658',
            //         'default_cash_difference_income_account_id': 'syscebnl_758',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_syscohada, FILE: template_syscebnl.py) ---
            // def _get_syscebnl_template_data(self):
            // return {
            //     'property_account_receivable_id': 'syscebnl_409',
            //     'property_account_payable_id': 'syscebnl_419',
            //     'property_account_expense_categ_id': 'syscebnl_601',
            //     'property_account_income_categ_id': 'syscebnl_7051',
            //     'name': 'SYSCEBNL',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSyscohadaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_syscohada, FILE: template_syscohada.py) ---
            // def _get_syscohada_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'bank_account_code_prefix': '521',
            //         'cash_account_code_prefix': '571',
            //         'transfer_account_code_prefix': '585',
            //         'account_default_pos_receivable_account_id': 'pcg_4113',
            //         'income_currency_exchange_account_id': 'pcg_776',
            //         'expense_currency_exchange_account_id': 'pcg_676',
            //         'account_journal_early_pay_discount_loss_account_id': 'pcg_6019',
            //         'account_journal_early_pay_discount_gain_account_id': 'pcg_7019',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSyscohadaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_syscohada, FILE: template_syscohada.py) ---
            // def _get_syscohada_template_data(self):
            // return {
            //     'property_account_receivable_id': 'pcg_4111',
            //     'property_account_payable_id': 'pcg_4011',
            //     'property_account_expense_categ_id': 'pcg_6011',
            //     'property_account_income_categ_id': 'pcg_7011',
            //     'name': 'SYSCOHADA - Revised',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTagMapperInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_tag_mapper(self, country_id):
            // tags = {x.name: x.id for x in self.env['account.account.tag'].with_context(active_test=False, lang='en_US').search([
            //     ('applicability', '=', 'taxes'),
            //     ('country_id', '=', country_id),
            // ])}
            // 
            // def mapping_getter(*args):
            //     res = []
            //     for tag in args:
            //         if re.match(r"^\w+\.\w+$", tag):
            //             # xml_id => explicit data, doesn't need to be mapped
            //             res.append(tag)
            //         else:
            //             format_tag = re.sub(r'\s+', ' ', tag.strip())
            //             mapped_tag = tags.get(format_tag)
            //             if not mapped_tag:
            //                 country = self.env['res.country'].browse(country_id)
            //                 message = self.env._(
            //                     'Error while loading the localization: missing tax tag %(tag_name)s for country %(country_name)s. You should probably update your localization app first.',
            //                     tag_name=format_tag, country_name=country.name)
            //                 if not self._context.get('ignore_missing_tags'):
            //                     raise UserError(message)
            //                 else:
            //                     _logger.error(message)
            //                     continue
            //             res.append(mapped_tag)
            //     return res
            // return mapping_getter
            */
            return default;
        }

        public async Task<TEntity> GetTdAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td.py) ---
            // def _get_td_account_account(self):
            // return self._parse_csv('td', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetTdResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td.py) ---
            // def _get_td_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.td',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetTdSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td_syscebnl.py) ---
            // def _get_td_syscebnl_account_account(self):
            // return self._parse_csv('td_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetTdSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td_syscebnl.py) ---
            // def _get_td_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.td',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetTdSyscebnlTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td_syscebnl.py) ---
            // def _get_td_syscebnl_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTdTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_td, FILE: template_td.py) ---
            // def _get_td_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTgAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg.py) ---
            // def _get_tg_account_account(self):
            // return self._parse_csv('tg', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetTgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg.py) ---
            // def _get_tg_res_company(self):
            // company_values = super()._get_syscohada_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.tg',
            //         'account_sale_tax_id': 'tva_sale_18',
            //         'account_purchase_tax_id': 'tva_purchase_good_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetTgSyscebnlAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg_syscebnl.py) ---
            // def _get_tg_syscebnl_account_account(self):
            // return self._parse_csv('tg_syscebnl', 'account.account', module='l10n_syscohada')
            */
            return default;
        }

        public async Task<TEntity> GetTgSyscebnlResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg_syscebnl.py) ---
            // def _get_tg_syscebnl_res_company(self):
            // company_values = super()._get_syscebnl_res_company()
            // company_values[self.env.company.id].update(
            //     {
            //         'account_fiscal_country_id': 'base.tg',
            //         'account_sale_tax_id': 'syscebnl_tva_sale_18',
            //         'account_purchase_tax_id': 'syscebnl_tva_purchase_good_18',
            //     }
            // )
            // return company_values
            */
            return default;
        }

        public async Task<TEntity> GetTgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg.py) ---
            // def _get_tg_template_data(self):
            // return {
            //     'name': _('SYSCOHADA for Companies'),
            //     'parent': 'syscohada',
            //     'code_digits': '6',
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_tg, FILE: template_tg_syscebnl.py) ---
            // def _get_tg_template_data(self):
            // return {
            //     'name': _('SYSCEBNL for Associations'),
            //     'parent': 'syscebnl',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetThResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_th, FILE: template_th.py) ---
            // def _get_th_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.th',
            //         'bank_account_code_prefix': '1110',
            //         'cash_account_code_prefix': '1100',
            //         'transfer_account_code_prefix': '16',
            //         'account_default_pos_receivable_account_id': 'a_recv_pos',
            //         'income_currency_exchange_account_id': 'a_income_gain',
            //         'expense_currency_exchange_account_id': 'a_exp_loss',
            //         'account_sale_tax_id': 'tax_output_vat',
            //         'account_purchase_tax_id': 'tax_input_vat',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetThTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_th, FILE: template_th.py) ---
            // def _get_th_template_data(self):
            // return {
            //     'property_account_receivable_id': 'a_recv',
            //     'property_account_payable_id': 'a_pay',
            //     'property_account_expense_categ_id': 'a_exp_cogs',
            //     'property_account_income_categ_id': 'a_sales',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetThirdPartyChecksCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_check, FILE: account_chart_template.py) ---
            // def _get_third_party_checks_country_codes(self):
            // """ Return the list of country codes for the countries where third party checks journals should be created
            // when installing the COA"""
            // return ["AR"]
            */
            return default;
        }

        public async Task<TEntity> GetTnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tn, FILE: template_tn.py) ---
            // def _get_tn_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.tn',
            //         'bank_account_code_prefix': '5321',
            //         'cash_account_code_prefix': '5411',
            //         'transfer_account_code_prefix': '58',
            //         'account_default_pos_receivable_account_id': 'l10n_tn_5411',
            //         'income_currency_exchange_account_id': 'l10n_tn_756',
            //         'expense_currency_exchange_account_id': 'l10n_tn_655',
            //         'account_journal_early_pay_discount_loss_account_id': 'l10n_tn_609',
            //         'account_journal_early_pay_discount_gain_account_id': 'l10n_tn_709',
            //         'default_cash_difference_income_account_id': 'l10n_tn_756',
            //         'default_cash_difference_expense_account_id': 'l10n_tn_655',
            //         'account_sale_tax_id': 'l10n_tn_tax_vat_sale_19',
            //         'account_purchase_tax_id': 'l10n_tn_tax_vat_purchase_19_other_local',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tn, FILE: template_tn.py) ---
            // def _get_tn_template_data(self):
            // return {
            //     'property_account_receivable_id': 'l10n_tn_4111',
            //     'property_account_payable_id': 'l10n_tn_4011',
            //     'property_account_expense_categ_id': 'l10n_tn_607',
            //     'property_account_income_categ_id': 'l10n_tn_707',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTrResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr, FILE: template_tr.py) ---
            // def _get_tr_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.tr',
            //         'bank_account_code_prefix': '102',
            //         'cash_account_code_prefix': '100',
            //         'transfer_account_code_prefix': '103',
            //         'account_default_pos_receivable_account_id': 'tr123',
            //         'income_currency_exchange_account_id': 'tr646',
            //         'expense_currency_exchange_account_id': 'tr656',
            //         'account_journal_suspense_account_id': 'tr102999',
            //         'account_sale_tax_id': 'tr_s_20',
            //         'account_purchase_tax_id': 'tr_p_20',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTrTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr, FILE: template_tr.py) ---
            // def _get_tr_template_data(self):
            // return {
            //     'property_account_receivable_id': 'tr120',
            //     'property_account_payable_id': 'tr320',
            //     'property_account_expense_categ_id': 'tr150',
            //     'property_account_income_categ_id': 'tr600',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTranslatableTemplateModelFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_translatable_template_model_fields(self):
            // return {
            //     model: [fieldname for (fieldname, field) in self.env[model]._fields.items() if field.translate]
            //     for model in TEMPLATE_MODELS
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTwResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tw, FILE: template_tw.py) ---
            // def _get_tw_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.tw',
            //         'bank_account_code_prefix': '1113',
            //         'cash_account_code_prefix': '1111',
            //         'transfer_account_code_prefix': '1114',
            //         'account_default_pos_receivable_account_id': 'tw_119150',
            //         'income_currency_exchange_account_id': 'tw_718100',
            //         'expense_currency_exchange_account_id': 'tw_718200',
            //         'account_journal_early_pay_discount_loss_account_id': 'tw_411400',
            //         'account_journal_early_pay_discount_gain_account_id': 'tw_512400',
            //         'default_cash_difference_income_account_id': 'tw_718500',
            //         'default_cash_difference_expense_account_id': 'tw_718600',
            //         'account_sale_tax_id': 'tw_tax_sale_5',
            //         'account_purchase_tax_id': 'tw_tax_purchase_5',
            //         'tax_calculation_rounding_method': 'round_globally',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTwTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tw, FILE: template_tw.py) ---
            // def _get_tw_template_data(self):
            // return {
            //     'code_digits': '6',
            //     'property_account_receivable_id': 'tw_119100',
            //     'property_account_payable_id': 'tw_217100',
            //     'property_account_expense_categ_id': 'tw_511100',
            //     'property_account_income_categ_id': 'tw_411100',
            //     'property_stock_account_input_categ_id': 'tw_124500',
            //     'property_stock_account_output_categ_id': 'tw_124600',
            //     'property_stock_valuation_account_id': 'tw_123100',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTzResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tz_account, FILE: template_tz.py) ---
            // def _get_tz_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.tz',
            //         'cash_account_code_prefix': '101',
            //         'bank_account_code_prefix': '103',
            //         'transfer_account_code_prefix': '105',
            //         'account_default_pos_receivable_account_id': 'tz_155',
            //         'income_currency_exchange_account_id': 'tz_671',
            //         'expense_currency_exchange_account_id': 'tz_672',
            //         'deferred_revenue_account_id': 'tz_181',
            //         'deferred_expense_account_id': 'tz_342',
            //         'account_sale_tax_id': 'VAT_S_TAXABLE_18',
            //         'account_purchase_tax_id': 'VAT_P_TAXABLE_18',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTzTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tz_account, FILE: template_tz.py) ---
            // def _get_tz_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'tz_190',
            //     'property_account_payable_id': 'tz_311',
            //     'property_account_expense_categ_id': 'tz_510',
            //     'property_account_income_categ_id': 'tz_400',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUaPsboResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ua, FILE: template_ua_psbo.py) ---
            // def _get_ua_psbo_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.ua',
            //         'bank_account_code_prefix': '311',
            //         'cash_account_code_prefix': '301',
            //         'transfer_account_code_prefix': '333',
            //         'account_default_pos_receivable_account_id': 'ua_psbp_366',
            //         'income_currency_exchange_account_id': 'ua_psbp_711',
            //         'expense_currency_exchange_account_id': 'ua_psbp_942',
            //         'account_sale_tax_id': 'sale_tax_template_vat20_psbo',
            //         'account_purchase_tax_id': 'purchase_tax_template_vat20_psbo',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUaPsboTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ua, FILE: template_ua_psbo.py) ---
            // def _get_ua_psbo_template_data(self):
            // return {
            //     'property_account_receivable_id': 'ua_psbp_361',
            //     'property_account_payable_id': 'ua_psbp_631',
            //     'property_account_expense_categ_id': 'ua_psbp_901',
            //     'property_account_income_categ_id': 'ua_psbp_701',
            //     'property_stock_account_input_categ_id': 'ua_psbp_2812',
            //     'property_stock_account_output_categ_id': 'ua_psbp_2811',
            //     'property_stock_valuation_account_id': 'ua_psbp_281',
            //     'name': _('IFRS Chart of Accounts'),
            //     'code_digits': '6',
            //     'use_storno_accounting': True,
            //     'display_invoice_amount_total_words': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUgResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ug, FILE: template_ug.py) ---
            // def _get_ug_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.ug',
            //         'bank_account_code_prefix': '3528',
            //         'cash_account_code_prefix': '3528',
            //         'transfer_account_code_prefix': '3528',
            //         'account_default_pos_receivable_account_id': '3528',
            //         'income_currency_exchange_account_id': '221018',
            //         'expense_currency_exchange_account_id': '221018',
            //         'account_journal_early_pay_discount_loss_account_id': '221019',
            //         'account_journal_early_pay_discount_gain_account_id': '191001',
            //         'account_sale_tax_id': 'sale_vat_18',
            //         'account_purchase_tax_id': 'purchase_vat_18',
            //         'fiscalyear_last_day': '30',
            //         'fiscalyear_last_month': '6',
            //         'deferred_expense_account_id': '352809',
            //         'deferred_revenue_account_id': '411726',
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUgTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ug, FILE: template_ug.py) ---
            // def _get_ug_template_data(self):
            // return {
            //     'name': "Uganda Generic Chart of Accounts",
            //     'code_digits': 6,
            //     'property_account_receivable_id': '3528',
            //     'property_account_payable_id': '4117',
            //     'property_account_expense_categ_id': '2240',
            //     'property_account_income_categ_id': '1420',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUkResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uk, FILE: template_uk.py) ---
            // def _get_uk_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.uk',
            //         'bank_account_code_prefix': '1200',
            //         'cash_account_code_prefix': '1210',
            //         'transfer_account_code_prefix': '1220',
            //         'account_default_pos_receivable_account_id': '1104',
            //         'income_currency_exchange_account_id': '7700',
            //         'expense_currency_exchange_account_id': '7700',
            //         'account_sale_tax_id': 'ST11',
            //         'account_purchase_tax_id': 'PT_20_G',
            //         'deferred_expense_account_id': '1103',
            //         'deferred_revenue_account_id': '2109',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUkTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uk, FILE: template_uk.py) ---
            // def _get_uk_template_data(self):
            // return {
            //     'property_account_receivable_id': '1100',
            //     'property_account_payable_id': '2100',
            //     'property_account_expense_categ_id': '5000',
            //     'property_account_income_categ_id': '4000',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatableFieldsTargetLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_untranslatable_fields_target_language(self, template_code, company):
            // """Return the code of the language we want to translate the untranslatable fields into.
            // """
            // # Note: In case this function is called during module installation
            // #   * The active user is the super user.
            // #   * There is no 'lang' in the context.
            // return company.partner_id.lang or get_lang(self.env).code
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatableFieldsToTranslateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_untranslatable_fields_to_translate(self):
            // """Return information about the untranslatable fields we want to translate anyway.
            // 
            // :param langs: The codes of the languages into which we want to translate the records.
            // :type langs: list[str]
            // :param companies: Records belonging to these companies will be considered.
            // :type companies: Model<res.company>
            // :return: Dictionary (model -> list of fields) where the list of fields contains
            //          all the untranslatable fields of the model we want to translate anyway
            // :rtype: dict[str, list[str]]
            // """
            // return {
            //     'account.journal': [
            //         'code',
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUntranslatedTranslatableTemplateModelRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _get_untranslated_translatable_template_model_records(self, langs, companies):
            // """Return information about the records of any model in TEMPLATE_MODELS (and belonging to companies) that need to be translated.
            // Records are in need of translation if they have a translatable field which is missing a translation (into any of the languages given in langs).
            // 
            // :param langs: The codes of the languages into which we want to translate the records.
            // :type langs: list[str]
            // :param companies: Records belonging to these companies will be considered.
            // :type companies: Model<res.company>
            // :return: The records which information will be returned are those records that have at least 1 untranslated translatable field.
            //          A field is 'untranslated' if it does not have a translation for all languages in langs.
            //          The returned value is a List of tuples:
            //              (model, xmlid (without module prefix), module, dictionary from name to value for each translatable field)
            // :rtype: list[tuple(str, str, str, dict[str, str])]
            // """
            // if not langs or not companies:
            //     return []
            // 
            // company_ids = tuple(companies.ids)
            // 
            // translatable_model_fields = self._get_translatable_template_model_fields()
            // 
            // # Generate a list of queries; exactly 1 per model
            // queries = []
            // for model in TEMPLATE_MODELS:
            //     translatable_fields = translatable_model_fields[model]
            //     if not translatable_fields:
            //         continue
            //     company_id_field = 'company_ids' if model == 'account.account' else 'company_id'
            // 
            //     self.env[model].flush_model(['id', company_id_field] + translatable_model_fields[model])
            // 
            //     query = self.env[model]._where_calc([(company_id_field, 'in', company_ids)])
            // 
            //     # We only want records that have at least 1 missing translation in any of its translatable fields
            //     missing_translation_clauses = [
            //         SQL("(%s ->> %s) IS NULL", SQL.identifier(query.table, field), lang)
            //         for field in translatable_fields
            //         for lang in langs
            //     ]
            // 
            //     translatable_field_column_args = []
            //     for field in translatable_fields:
            //         translatable_field_column_args.extend((SQL("%s", field), SQL.identifier(query.table, field)))
            // 
            //     queries.append(SQL(
            //         """
            //          SELECT %(model)s AS model,
            //                 model_data.name AS xmlid,
            //                 model_data.module AS module,
            //                 json_build_object(%(translatable_field_column_args)s) AS fields
            //            FROM %(from_clause)s
            //            JOIN ir_model_data model_data ON model_data.model = %(model)s
            //                                         AND %(model_id)s = model_data.res_id
            //           WHERE %(where_clause)s
            //                 AND (%(missing_translation_clauses)s)
            //         """,
            //         model=model,
            //         translatable_field_column_args=SQL(", ").join(translatable_field_column_args),
            //         from_clause=query.from_clause,
            //         model_id=SQL.identifier(query.table, 'id'),
            //         where_clause=query.where_clause or SQL("TRUE"),
            //         missing_translation_clauses=SQL(" OR ").join(missing_translation_clauses),
            //     ))
            // 
            // query = (SQL(' UNION ALL ').join(queries))
            // # the queried models have been flushed already as part of the loop building the queries per model
            // self.env['ir.model.data'].flush_model(['res_id', 'model', 'name'])
            // 
            // self._cr.execute(query)
            // return self._cr.fetchall()
            */
            return default;
        }

        public async Task<TEntity> GetUyAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: template_uy.py) ---
            // def _get_uy_account_journal(self):
            // return {
            //     'sale': {
            //         "name": _("Customer Invoices"),
            //         "code": "0001",
            //         "l10n_latam_use_documents": True,
            //         "refund_sequence": False,
            //     },
            //     'purchase': {
            //         "name": _("Vendor Bills"),
            //         "code": "0002",
            //         "l10n_latam_use_documents": True,
            //         "refund_sequence": False,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUyResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: template_uy.py) ---
            // def _get_uy_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.uy',
            //         'bank_account_code_prefix': '1111',
            //         'cash_account_code_prefix': '1112',
            //         'transfer_account_code_prefix': '11120',
            //         'account_default_pos_receivable_account_id': 'uy_code_11307',
            //         'income_currency_exchange_account_id': 'uy_code_4302',
            //         'expense_currency_exchange_account_id': 'uy_code_5302',
            //         'account_journal_early_pay_discount_loss_account_id': 'uy_code_5303',
            //         'account_journal_early_pay_discount_gain_account_id': 'uy_code_4303',
            //         'account_sale_tax_id': 'vat1',
            //         'account_purchase_tax_id': 'vat4',
            //         'deferred_expense_account_id': 'uy_code_11407',
            //         'deferred_revenue_account_id': 'uy_code_21321',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetUyTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: template_uy.py) ---
            // def _get_uy_template_data(self):
            // return {
            //     'property_account_receivable_id': 'uy_code_11300',
            //     'property_account_payable_id': 'uy_code_21100',
            //     'property_account_income_categ_id': 'uy_code_4102',
            //     'property_account_expense_categ_id': 'uy_code_5100',
            //     'code_digits': '6',
            //     'name': _('Uruguayan Generic Chart of Accounts'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetVeResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ve, FILE: template_ve.py) ---
            // def _get_ve_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'account_fiscal_country_id': 'base.ve',
            //         'bank_account_code_prefix': '1113',
            //         'cash_account_code_prefix': '1111',
            //         'transfer_account_code_prefix': '1129003',
            //         'account_default_pos_receivable_account_id': 'account_activa_account_1122003',
            //         'income_currency_exchange_account_id': 'account_activa_account_9212003',
            //         'expense_currency_exchange_account_id': 'account_activa_account_9113006',
            //         'account_sale_tax_id': 'tax3sale',
            //         'account_purchase_tax_id': 'tax3purchase',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetVeTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ve, FILE: template_ve.py) ---
            // def _get_ve_template_data(self):
            // return {
            //     'code_digits': '7',
            //     'property_account_receivable_id': 'account_activa_account_1122001',
            //     'property_account_payable_id': 'account_activa_account_2122001',
            //     'property_account_expense_categ_id': 'account_activa_account_7151001',
            //     'property_account_income_categ_id': 'account_activa_account_5111001',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetVnResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_vn, FILE: template_vn.py) ---
            // def _get_vn_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.vn',
            //         'bank_account_code_prefix': '112',
            //         'cash_account_code_prefix': '111',
            //         'transfer_account_code_prefix': '113',
            //         'account_default_pos_receivable_account_id': 'chart131',
            //         'income_currency_exchange_account_id': 'chart515',
            //         'expense_currency_exchange_account_id': 'chart635',
            //         'account_journal_early_pay_discount_loss_account_id': 'chart635',
            //         'account_journal_early_pay_discount_gain_account_id': 'chart515',
            //         'account_sale_tax_id': 'tax_sale_vat10',
            //         'account_purchase_tax_id': 'tax_purchase_vat10',
            //         'transfer_account_id': 'chart1131',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetVnTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_vn, FILE: template_vn.py) ---
            // def _get_vn_template_data(self):
            // return {
            //     'code_digits': '4',
            //     'property_account_receivable_id': 'chart131',
            //     'property_account_payable_id': 'chart331',
            //     'property_account_expense_categ_id': 'chart1561',
            //     'property_account_income_categ_id': 'chart5111',
            //     'display_invoice_amount_total_words': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetZaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_za, FILE: template_za.py) ---
            // def _get_za_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.za',
            //         'bank_account_code_prefix': '1200',
            //         'cash_account_code_prefix': '1250',
            //         'transfer_account_code_prefix': '1010',
            //         'account_default_pos_receivable_account_id': '110030',
            //         'income_currency_exchange_account_id': '500100',
            //         'expense_currency_exchange_account_id': '610340',
            //         'default_cash_difference_income_account_id': '500110',
            //         'default_cash_difference_expense_account_id': '610460',
            //         'account_sale_tax_id': 'ST1',
            //         'account_purchase_tax_id': 'PT15',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetZaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_za, FILE: template_za.py) ---
            // def _get_za_template_data(self):
            // return {
            //     'property_account_receivable_id': '110010',
            //     'property_account_payable_id': '220010',
            //     'property_account_expense_categ_id': '600010',
            //     'property_account_income_categ_id': '500010',
            //     'property_stock_account_input_categ_id': '200010',
            //     'property_stock_account_output_categ_id': '100050',
            //     'property_stock_valuation_account_id': '100020',
            //     'code_digits': '6',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetZmResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_zm_account, FILE: template_zm.py) ---
            // def _get_zm_res_company(self):
            // return {
            //     self.env.company.id: {
            //         'anglo_saxon_accounting': True,
            //         'account_fiscal_country_id': 'base.zm',
            //         'bank_account_code_prefix': '840000',
            //         'cash_account_code_prefix': '840000',
            //         'transfer_account_code_prefix': '840000',
            //         'income_currency_exchange_account_id': 'zm_account_4210000',
            //         'expense_currency_exchange_account_id': 'zm_account_4210000',
            //         'account_default_pos_receivable_account_id': 'zm_account_8100000',
            //         'account_journal_early_pay_discount_loss_account_id': 'zm_account_3550000',
            //         'account_journal_early_pay_discount_gain_account_id': 'zm_account_2700000',
            //         'deferred_expense_account_id': 'zm_account_8900000',
            //         'deferred_revenue_account_id': 'zm_account_9900000',
            //         'account_sale_tax_id': 'zm_tax_sale_16',
            //         'account_purchase_tax_id': 'zm_tax_purchase_16',
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetZmTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_zm_account, FILE: template_zm.py) ---
            // def _get_zm_template_data(self):
            // return {
            //     'code_digits': 7,
            //     'property_account_income_categ_id': 'zm_account_1000000',
            //     'property_account_expense_categ_id': 'zm_account_3800000',
            //     'property_account_receivable_id': 'zm_account_8000000',
            //     'property_account_payable_id': 'zm_account_9000000',
            // }
            */
            return default;
        }

        public async Task<TEntity> GuessChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _guess_chart_template(self, country):
            // """Guess the most appropriate template based on the country."""
            // return self._select_chart_template(country)[0][0]
            */
            return default;
        }

        public async Task<TEntity> InstallDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _install_demo(self, companies):
            // if not isinstance(companies, models.BaseModel):
            //     companies = self.env['res.company'].browse(companies)
            // for company in companies:
            //     self.sudo()._load_data(self._get_demo_data(company), ignore_duplicates=True)
            //     self._post_load_demo_data(company)
            */
            return default;
        }

        public async Task<TEntity> InstantiateForeignTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _instantiate_foreign_taxes(self, country, company):
            // """Create and configure foreign taxes from the provided country.
            // 
            // Instantiate the taxes as they would be for the foreign localization only replacing the accounts used by the most
            // probable account we can retrieve from the company's localization.
            // This method is intended as a shortcut for instantiation, accelerating it, not as an out-of-the-box solution 100%
            // correct solution.
            // """
            // # Implementation:
            // # - Check if there is any tax for this country and stop the process if yes
            // # - Retrieve the tax group and tax template data
            // # - Try to create accounts at most probable location in the CoA
            // # - Assign those accounts to the data
            // # - Creates tax group and taxes with their ir.model.data
            // 
            // taxes_in_country = self.env['account.tax'].search([
            //     *self.env['account.tax']._check_company_domain(company),
            //     ('country_id', '=', country.id),
            // ])
            // if taxes_in_country:
            //     return
            // 
            // def create_foreign_tax_account(existing_account, additional_label, reconcilable=False):
            //     new_code = self.env['account.account'].with_company(company)._search_new_account_code(existing_account.code)
            //     return self.env['account.account'].create({
            //         'name': f"{existing_account.name} - {additional_label}",
            //         'code': new_code,
            //         'account_type': existing_account.account_type,
            //         'reconcile': reconcilable or existing_account.reconcile,
            //         'non_trade': existing_account.non_trade,
            //         'company_ids': [Command.link(company.id)],
            //     })
            // 
            // existing_accounts = {'': None, None: None}  # keeps tracks of the created account by foreign xml_id
            // default_company_taxes = company.account_sale_tax_id + company.account_purchase_tax_id
            // chart_template_code = self._guess_chart_template(country=country)
            // tax_group_data = self._get_chart_template_data(chart_template_code)['account.tax.group']
            // tax_data = self._get_chart_template_data(chart_template_code)['account.tax']
            // 
            // # Populate foreign accounts mapping
            // # Try to create tax group accounts if not mapped
            // field_and_names = (
            //     ('tax_payable_account_id', _("Foreign tax account payable (%s)", country.code)),
            //     ('tax_receivable_account_id', _("Foreign tax account receivable (%s)", country.code)),
            //     ('advance_tax_payment_account_id', _("Foreign tax account advance payment (%s)", country.code)),
            // )
            // for field, account_name in field_and_names:
            //     for tax_group in tax_group_data.values():
            //         account_template_xml_id = tax_group.get(field)
            //         if account_template_xml_id in existing_accounts:
            //             continue
            //         local_tax_group = self.env["account.tax.group"].search([
            //             *self.env['account.tax.group']._check_company_domain(company),
            //             ('country_id', '=', company.account_fiscal_country_id.id),
            //             (field, '!=', False),
            //         ], limit=1)
            //         if local_tax_group:
            //             existing_accounts[account_template_xml_id] = create_foreign_tax_account(local_tax_group[field], account_name).id
            // 
            // # Try to create repartition lines account if not mapped
            // for tax_template in tax_data.values():
            //     for _command, _id, rep_line in tax_template.get('repartition_line_ids', []):
            //         if 'account_id' in rep_line and rep_line['repartition_type'] == 'tax':
            //             type_tax_use, foreign_tax_rep_line = tax_template['type_tax_use'], rep_line
            //             account_template_xml_id = foreign_tax_rep_line['account_id']
            //             if account_template_xml_id in existing_accounts:
            //                 continue
            // 
            //             sign_comparator = '<' if float(foreign_tax_rep_line.get('factor_percent', 100)) < 0 else '>'
            //             minimal_domain = [
            //                 *self.env['account.tax.repartition.line']._check_company_domain(company),
            //                 ('account_id', '!=', False),
            //                 ('factor_percent', sign_comparator, 0),
            //             ]
            //             additional_domain = [
            //                 ('tax_id.type_tax_use', '=', type_tax_use),
            //                 ('tax_id.country_id', '=', company.account_fiscal_country_id.id),
            //                 ('tax_id', 'in', default_company_taxes.ids),
            //             ]
            // 
            //             # Trying to find an account being less restrictive on each iteration until the minimum acceptable is
            //             # reached. If nothing is found, don't fill it to avoid setting a wrong account
            //             similar_repartition_line = None
            //             while not similar_repartition_line and additional_domain:
            //                 search_domain = minimal_domain + additional_domain
            //                 similar_repartition_line = self.env['account.tax.repartition.line'].search(search_domain, limit=1)
            //                 additional_domain.pop()
            // 
            //             if similar_repartition_line:
            //                 local_tax_account = similar_repartition_line.account_id
            //                 similar_account_id = create_foreign_tax_account(local_tax_account, _("Foreign tax account (%s)", country.code))
            //                 existing_accounts[account_template_xml_id] = similar_account_id.id
            // 
            // # Try to create cash basis account if not mapped
            // local_cash_basis_tax = self.env["account.tax"].search([
            //     *self.env['account.tax']._check_company_domain(company),
            //     ('country_id', '=', company.account_fiscal_country_id.id),
            //     ('tax_exigibility', '=', 'on_payment'),
            //     ('cash_basis_transition_account_id', '!=', False)
            // ], limit=1)
            // has_cash_basis = False
            // for tax_template in sorted(tax_data.values(), key=lambda x: any(rep_line.get('account_id') for _command, _id, rep_line in x.get('repartition_line_ids', [])), reverse=True):
            //     if tax_template.get('tax_exigibility') == 'on_payment':
            //         has_cash_basis = True
            // 
            //         account_xml_id = tax_template.get('cash_basis_transition_account_id')
            //         if account_xml_id not in existing_accounts:
            //             if local_cash_basis_tax:
            //                 existing_accounts[account_xml_id] = create_foreign_tax_account(
            //                     local_cash_basis_tax.cash_basis_transition_account_id,
            //                     _("Cash basis transition account"),
            //                     reconcilable=True,
            //                 ).id
            // 
            //             elif account_ids := [rep_line['account_id'] for _command, _id, rep_line in tax_template.get('repartition_line_ids', []) if rep_line.get('account_id')]:
            //                 local_account = self.env['account.account'].browse(existing_accounts[account_ids[0]])
            //                 existing_accounts[account_xml_id] = create_foreign_tax_account(local_account, _("Cash basis transition account"), reconcilable=True).id
            // 
            //             else:
            //                 existing_accounts[account_xml_id] = None
            // 
            // if has_cash_basis:
            //     company.tax_exigibility = True
            // 
            // # Assign the account based on the map
            // for field, account_name in field_and_names:
            //     for tax_group in tax_group_data.values():
            //         tax_group[field] = existing_accounts.get(tax_group.get(field))
            // 
            // for tax_template in tax_data.values():
            //     # This is required because the country isn't provided directly by the template
            //     tax_template['country_id'] = country.id
            // 
            //     if tax_template.get('tax_group_id'):
            //         tax_template['tax_group_id'] = f"{chart_template_code}_{tax_template['tax_group_id']}"
            // 
            //     for _command, _id, rep_line in tax_template.get('repartition_line_ids', []):
            //         rep_line['account_id'] = existing_accounts.get(rep_line.get('account_id'))
            // 
            //     account_xml_id = tax_template.get('cash_basis_transition_account_id')
            //     if account_xml_id:
            //         tax_template['cash_basis_transition_account_id'] = existing_accounts[account_xml_id]
            // 
            // data = {
            //     'account.tax.group': tax_group_data,
            //     'account.tax': tax_data,
            // }
            // # prefix the xml_id with the chart template code to avoid collision
            // # because since 16.2 xml_ids are regrouped under module account
            // data = {
            //     model: {
            //         f"{chart_template_code}_{xml_id}": template
            //         for xml_id, template in templates.items()
            //     }
            //     for model, templates in data.items()
            // }
            // # add the prefix to the "children_tax_ids" value for group-type taxes
            // for tax_data in data['account.tax'].values():
            //     if tax_data.get('amount_type') == 'group' and 'children_tax_ids' in tax_data:
            //         children_taxes = tax_data['children_tax_ids'].split(',')
            //         for idx, child_tax in enumerate(children_taxes):
            //             children_taxes[idx] = f"{chart_template_code}_{child_tax}"
            //         tax_data['children_tax_ids'] = ','.join(children_taxes)
            // self._load_data(data)
            */
            return default;
        }

        public async Task<TEntity> L10nEcSetupLocationAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec_stock, FILE: account_chart_template.py) ---
            // def _l10n_ec_setup_location_accounts(self, companies):
            // parent_location = self.env.ref('stock.stock_location_locations_virtual', raise_if_not_found=False)
            // loss_locs = dict(self.env['stock.location']._read_group(domain=[('location_id', '=', parent_location.id), ('usage', '=', 'inventory'), ('scrap_location', '=', False)], groupby=['company_id', 'id'])) if parent_location else {}
            // prod_locs = dict(self.env['stock.location']._read_group(domain=[('location_id', '=', parent_location.id), ('usage', '=', 'production'), ('scrap_location', '=', False)], groupby=['company_id', 'id'])) if parent_location else {}
            // for company in companies:
            //     # get template data
            //     Template = self.env['account.chart.template'].with_company(company)
            //     template_code = company.chart_template
            //     full_data = Template._get_chart_template_data(template_code)
            //     template_data = full_data.pop('template_data')
            // 
            //     ref = template_data.get('loss_stock_valuation_account')
            //     if (loss_loc := loss_locs.get(company)) and (loss_loc_account := ref and Template.ref(ref, raise_if_not_found=False)):
            //         loss_loc.write({
            //             'valuation_in_account_id': loss_loc_account.id,
            //             'valuation_out_account_id': loss_loc_account.id,
            //         })
            // 
            //     ref = template_data.get('production_stock_valuation_account')
            //     if (prod_loc := prod_locs.get(company)) and (prod_loc_account := ref and Template.ref(ref, raise_if_not_found=False)):
            //         prod_loc.write({
            //             'valuation_in_account_id': prod_loc_account.id,
            //             'valuation_out_account_id': prod_loc_account.id,
            //         })
            */
            return default;
        }

        public async Task<TEntity> LoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object ignore_duplicates) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _load_data(self, data, ignore_duplicates=False):
            // """Load all the data linked to the template into the database.
            // 
            // The data can contain translation values (i.e. `name@fr_FR` to translate the name in French)
            // An xml_id that doesn't contain a `.` will be treated as being linked to `account` and prefixed
            // with the company's id (i.e. `cash` is interpreted as `account.1_cash` if the company's id is 1)
            // 
            // :param data: Basically all the final data of records to create/update for the chart
            //              of accounts. It is a mapping {model: {xml_id: values}}.
            // :type data: dict[str, dict[(str, int), dict]]
            // 
            // :param ignore_duplicates: if true, inputs that match records already in the DB will be ignored
            // """
            // def deref_values(values, model):
            //     """Replace xml_id references by database ids in all provided values.
            // 
            //     This allows to define all the data before the records even exist in the database.
            //     """
            //     fields = ((model._fields[k], k, v) for k, v in values.items() if k in model._fields)
            //     failed_fields = []
            //     for field, fname, value in fields:
            //         if not value:
            //             values[fname] = False
            //         elif isinstance(value, str) and (
            //             field.type == 'many2one'
            //             or (field.type in ('integer', 'many2one_reference') and not value.isdigit())
            //         ):
            //             try:
            //                 values[fname] = self.ref(value).id if value not in ('', 'False', 'None') else False
            //             except ValueError:
            //                 if model._name == 'res.company':
            //                     # Try a fallback on the company when reloading/loading on a branch
            //                     values[fname] = self.env.company[fname] or self.env.company.root_id[fname] or False
            //                 else:
            //                     _logger.warning("Failed when trying to recover %s for field=%s", value, field)
            //                     failed_fields.append(fname)
            //                     values[fname] = False
            //         elif field.type in ('one2many', 'many2many') and isinstance(value[0], (list, tuple)):
            //             for i, (command, _id, *last_part) in enumerate(value):
            //                 if last_part:
            //                     last_part = last_part[0]
            //                 # (0, 0, {'test': 'account.ref_name'}) -> Command.Create({'test': 13})
            //                 if command in (Command.CREATE, Command.UPDATE):
            //                     deref_values(last_part, self.env[field.comodel_name])
            //                 # (6, 0, ['account.ref_name']) -> Command.Set([13])
            //                 elif command == Command.SET:
            //                     for subvalue_idx, subvalue in enumerate(last_part):
            //                         if isinstance(subvalue, str):
            //                             last_part[subvalue_idx] = self.ref(subvalue).id
            //                 elif command == Command.LINK and isinstance(_id, str):
            //                     value[i] = Command.link(self.ref(_id).id)
            //         elif field.type in ('one2many', 'many2many') and isinstance(value, str):
            //             values[fname] = [Command.set([
            //                 self.ref(v).id
            //                 for v in value.split(',')
            //                 if v
            //             ])]
            //     for fname in failed_fields:
            //         del values[fname]
            //     return values
            // 
            // def delay(all_data):
            //     """Defer writing some relations if the related records don't exist yet."""
            // 
            //     def should_delay(created_models, yet_to_be_created_models, model, field_name, field_val, parent_models=None):
            //         parent_models = (parent_models or []) + [model]
            //         field = self.env[model]._fields.get(field_name)
            //         if not field or not field.relational or field.comodel_name in created_models or isinstance(field_val, int):
            //             return False
            //         field_yet_to_be_created = field.comodel_name in parent_models + yet_to_be_created_models
            //         if not isinstance(field_val, list | tuple):
            //             return field_yet_to_be_created
            //         # Check recursively if there are subfields that should be delayed
            //         for element in field_val:
            //             match element:
            //                 case Command.CREATE, _, dict() as values:
            //                     for subkey, subvalue in values.items():
            //                         if should_delay(created_models, yet_to_be_created_models, field.comodel_name, subkey, subvalue, parent_models):
            //                             return True
            //                 case int() as command, *_ if command in tuple(Command):
            //                     if field_yet_to_be_created:
            //                         return True
            //         return False
            // 
            //     created_models = set()
            //     while all_data:
            //         (model, data), *all_data = all_data
            //         yet_to_be_created_models = [model for model, _data in all_data if _data]
            //         to_delay = defaultdict(dict)
            //         for xml_id, vals in data.items():
            //             to_be_removed = []
            //             for field_name, field_val in vals.items():
            //                 if should_delay(created_models, yet_to_be_created_models, model, field_name, field_val):
            //                     # Default repartition lines will be created when we create account.tax
            //                     # If we delay the creation of repartition_line_ids, then we must get rid of the defaults
            //                     if (
            //                         model == 'account.tax' and 'repartition_line_ids' in field_name
            //                         and not self.ref(xml_id, raise_if_not_found=False)
            //                         and all(
            //                             isinstance(x, tuple | list) and len(x)
            //                             and isinstance(x[0], Command | int) for x in field_val
            //                         )
            //                     ):
            //                         field_val = [Command.clear()] + field_val
            //                     to_be_removed.append(field_name)
            //                     to_delay[xml_id][field_name] = field_val
            //             for field_name in to_be_removed:
            //                 del vals[field_name]
            //         if any(to_delay.values()):
            //             all_data.append((model, to_delay))
            //         yield model, data
            //         created_models.add(model)
            // 
            // created_records = {}
            // for model, model_data in delay(list(deepcopy(data).items())):
            //     all_records_vals = []
            //     for xml_id, record_vals in model_data.items():
            //         # Extract the translations from the values
            //         for key in list(record_vals):
            //             if '@' in key or key == '__translation_module__':
            //                 del record_vals[key]
            // 
            //         # Manage ids given as database id or xml_id
            //         if isinstance(xml_id, int):
            //             record_vals['id'] = xml_id
            //             xml_id = False
            //         else:
            //             xml_id = f"{('account.' + str(self.env.company.id) + '_') if '.' not in xml_id else ''}{xml_id}"
            // 
            //         all_records_vals.append({
            //             'xml_id': xml_id,
            //             'values': deref_values(record_vals, self.env[model]),
            //             'noupdate': True,
            //         })
            //     created_records[model] = self.with_context(lang='en_US').env[model]._load_records(all_records_vals, ignore_duplicates=ignore_duplicates)
            // return created_records
            */
            return default;
        }

        public async Task<TEntity> LoadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _load(self, template_code, company, install_demo, force_create=True ):
            // """Install this chart of accounts for the current company.
            // 
            // :param template_code: code of the chart template to be loaded.
            // :param company: the company we try to load the chart template on.
            //     If not provided, it is retrieved from the context.
            // :param install_demo: whether or not we should load demo data right after loading the
            //     chart template.
            // """
            // # Ensure that the context is the correct one, even if not called by try_loading
            // if not self.env.is_system():
            //     raise AccessError(_("Only administrators can install chart templates"))
            // 
            // chart_template_mapping = self._get_chart_template_mapping()[template_code]
            // if not company.country_id:
            //     company.country_id = chart_template_mapping.get('country_id')
            // 
            // module_name = chart_template_mapping.get('module')
            // module = self.env['ir.module.module'].search([('name', '=', module_name), ('state', '=', 'uninstalled')])
            // if module:
            //     module.button_immediate_install()
            //     self.env.reset()  # clear the envs with an old registry
            //     self = self.env()['account.chart.template']  # create a new env with the new registry
            // 
            // # To be able to use code translation we load everything in 'en_US'
            // # The demo data is still loaded "normally" since code translations cannot be used for them reliably.
            // # (Since we rely on the "@template functions" to determine the module to take the code translations from.)
            // original_context_lang = self.env.context.get('lang')
            // self = self.with_context(
            //     default_company_id=company.id,
            //     allowed_company_ids=[company.id],
            //     tracking_disable=True,
            //     delay_account_group_sync=True,
            //     lang='en_US',
            //     chart_template_load=True,
            // )
            // company = self.env['res.company'].browse(company.id)  # also update company.pool
            // 
            // reload_template = template_code == company.chart_template
            // company.chart_template = template_code
            // 
            // if not reload_template and (not company.root_id._existing_accounting() or self.env.ref('base.module_account').demo):
            //     children_companies = self.env['res.company'].search([('id', 'child_of', company.id)])
            //     for model in ('account.move',) + TEMPLATE_MODELS[::-1]:
            //         if not company.parent_id:
            //             company_field = 'company_id' if 'company_id' in self.env[model] else 'company_ids'
            //             records = self.env[model].sudo().with_context(active_test=False).search([(company_field, 'child_of', company.id)])
            //             if company_field == 'company_ids':
            //                 records_to_keep = records.filtered(lambda r: r.company_ids - children_companies)
            //                 records -= records_to_keep
            //                 for records_for_companies in records_to_keep.grouped('company_ids').values():
            //                     records_for_companies.company_ids -= children_companies
            //             records.with_context({MODULE_UNINSTALL_FLAG: True}).unlink()
            // 
            // data = self._get_chart_template_data(template_code)
            // template_data = data.pop('template_data')
            // if company.parent_id:
            //     data = {
            //         'res.company': data['res.company'],
            //     }
            // 
            // if reload_template:
            //     self._pre_reload_data(company, template_data, data, force_create)
            //     install_demo = False
            // data = self._pre_load_data(template_code, company, template_data, data)
            // self._load_data(data)
            // self._post_load_data(template_code, company, template_data)
            // self._load_translations(companies=company)
            // 
            // # Manual sync because disable above (delay_account_group_sync)
            // AccountGroup = self.env['account.group'].with_context(delay_account_group_sync=False)
            // AccountGroup._adapt_parent_account_group(company=company)
            // 
            // # Install the demo data when the first localization is instanciated on the company
            // if install_demo and self.ref('base.module_account').demo and not reload_template:
            //     try:
            //         with self.env.cr.savepoint():
            //             self = self.with_context(lang=original_context_lang)
            //             self._install_demo(company.with_env(self.env))
            //     except Exception:
            //         # Do not rollback installation of CoA if demo data failed
            //         _logger.exception('Error while loading accounting demo data')
            // for subsidiary in company.child_ids:
            //     self._load(template_code, subsidiary, install_demo, force_create)
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: account_chart_template.py) ---
            // def _load(self, template_code, company, install_demo,force_create=True):
            // """ Set companies AFIP Responsibility and Country if AR CoA is installed, also set tax calculation rounding
            // method required in order to properly validate match AFIP invoices.
            // 
            // Also, raise a warning if the user is trying to install a CoA that does not match with the defined AFIP
            // Responsibility defined in the company
            // """
            // coa_responsibility = self._get_ar_responsibility_match(template_code)
            // if coa_responsibility:
            //     company.write({
            //         'l10n_ar_afip_responsibility_type_id': coa_responsibility.id,
            //         'country_id': self.env['res.country'].search([('code', '=', 'AR')]).id,
            //         'tax_calculation_rounding_method': 'round_globally',
            //     })
            // 
            //     current_identification_type = company.partner_id.l10n_latam_identification_type_id
            //     try:
            //         # set CUIT identification type (which is the argentinean vat) in the created company partner instead of
            //         # the default VAT type.
            //         company.partner_id.l10n_latam_identification_type_id = self.env.ref('l10n_ar.it_cuit')
            //     except ValidationError:
            //         # put back previous value if we could not validate the CUIT
            //         company.partner_id.l10n_latam_identification_type_id = current_identification_type
            // 
            // res = super()._load(template_code, company, install_demo,force_create)
            // 
            // # If Responsable Monotributista remove the default purchase tax
            // if template_code in ('ar_base', 'ar_ex'):
            //     company.account_purchase_tax_id = self.env['account.tax']
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_ec_stock, FILE: account_chart_template.py) ---
            // def _load(self, template_code, company, install_demo, force_create=True):
            // # EXTENDS account to set up default accounts on stock locations
            // res = super()._load(template_code, company, install_demo, force_create)
            // if template_code == 'ec':
            //     self._l10n_ec_setup_location_accounts(company)
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: template_hu.py) ---
            // def _load(self, template_code, company, install_demo, force_create=True):
            // res = super()._load(template_code, company, install_demo, force_create)
            // if template_code == 'hu':
            //     company._l10n_hu_edi_configure_company()
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: template_uy.py) ---
            // def _load(self, template_code, company, install_demo, force_create=True):
            // """ Set companies rut as the company identification type  after install the chart of account,
            // this one is the uruguayan vat """
            // res = super()._load(template_code, company, install_demo, force_create)
            // if template_code == 'uy':
            //     company.partner_id.l10n_latam_identification_type_id = self.env.ref('l10n_uy.it_rut')
            // return res
            */
            return default;
        }

        public async Task<TEntity> LoadTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _load_translations(self, langs=None, companies=None, template_data=None):
            // """Load the translations of the chart template.
            // 
            // :param langs: the lang code to load the translations for. If one of the codes is not present,
            //               we are looking for it more generic locale (i.e. `en` instead of `en_US`)
            // :type langs: list[str]
            // :param companies: the companies to load the translations for
            // :type companies: Model<res.company>
            // """
            // langs = langs or [code for code, _name in self.env['res.lang'].get_installed()]
            // available_template_codes = list(self._get_chart_template_mapping(get_all=True))
            // companies = companies or self.env['res.company'].search([('chart_template', 'in', available_template_codes)])
            // 
            // translation_importer = TranslationImporter(self.env.cr, verbose=False)
            // 
            // # Gather translations for records that are created from the chart_template data
            // for chart_template, chart_companies in groupby(companies, lambda c: c.chart_template):
            //     chart_template_data = template_data or self.env['account.chart.template'] \
            //         .with_context(ignore_missing_tags=True) \
            //         ._get_chart_template_data(chart_template)
            //     chart_template_data.pop('template_data', None)
            //     for mname, data in chart_template_data.items():
            //         for _xml_id, record in data.items():
            //             fnames = {fname.split('@')[0] for fname in record if fname != '__translation_module__'}
            //             for lang in langs:
            //                 for fname in fnames:
            //                     field = self.env[mname]._fields.get(fname)
            //                     if not field or not field.translate:
            //                         continue
            //                     field_translation = self._get_field_translation(record, fname, lang)
            //                     if field_translation:
            //                         for company in chart_companies:
            //                             xml_id = _xml_id if '.' in _xml_id else f"account.{company.id}_{_xml_id}"
            //                             translation_importer.model_translations[mname][fname][xml_id][lang] = field_translation
            // 
            // # Gather translations for the TEMPLATE_MODELS records that are not created from the chart_template data
            // translation_langs = [lang for lang in langs if lang != 'en_US']  # there are no code translations for 'en_US' (original language)
            // for (mname, _xml_id, module, fields) in self._get_untranslated_translatable_template_model_records(translation_langs, companies):
            //     for (field, value) in fields.items():
            //         if not value or 'en_US' not in value:
            //             continue
            //         value_en_US = value['en_US']
            //         xml_id = f"{module}.{_xml_id}"
            //         for lang in [lang for lang in translation_langs if lang not in value]:
            //             if lang in translation_importer.model_translations[mname][field][xml_id]:
            //                 continue
            //             value_translated = None
            //             for code_module in ([module, 'account'] if module != 'account' else ['account']):
            //                 value_translated = code_translations.get_python_translations(code_module, lang).get(value_en_US)
            //                 if not value_translated:  # manage generic locale (i.e. `fr` instead of `fr_BE`)
            //                     value_translated = code_translations.get_python_translations(code_module, lang.split('_')[0]).get(value_en_US)
            //                 if value_translated:
            //                     translation_importer.model_translations[mname][field][xml_id][lang] = value_translated
            //                     break
            // 
            // translation_importer.save(overwrite=False)
            */
            return default;
        }

        public async Task<TEntity> LoadWipAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: template_generic_coa.py) ---
            // def _load_wip_accounts(self, company, template_data):
            // company = company or self.env.company
            // if company.id in template_data:
            //     company_data = template_data[company.id]
            //     if 'account_production_wip_account_id' in company_data:
            //         company.account_production_wip_account_id = self.ref(company_data['account_production_wip_account_id'])
            //     if 'account_production_wip_overhead_account_id' in company_data:
            //         company.account_production_wip_overhead_account_id = self.ref(company_data['account_production_wip_overhead_account_id'])
            */
            return default;
        }

        public async Task<TEntity> ParseCsvInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object model, object module) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _parse_csv(self, template_code, model, module=None):
            // Model = self.env[model]
            // model_fields = Model._fields
            // 
            // if module is None:
            //     module = self._get_chart_template_mapping().get(template_code)['module']
            // assert re.fullmatch(r"[a-z0-9_]+", module)
            // 
            // def evaluate(key, value, model_fields):
            //     if not value:
            //         return value
            //     if '@' in key:
            //         return value
            //     if '/' in key:
            //         return []
            //     if model_fields:
            //         if model_fields[key].type in ('boolean', 'int', 'float'):
            //             return ast.literal_eval(value)
            //         if model_fields[key].type == 'char':
            //             return value.strip()
            //     return value
            // 
            // res = {}
            // for template in self._get_parent_template(template_code)[::-1] or ['']:
            //     try:
            //         with file_open(f"{module}/data/template/{model}{f'-{template}' if template else ''}.csv", 'r') as csv_file:
            //             for row in csv.DictReader(csv_file):
            //                 if row['id']:
            //                     last_id = row['id']
            //                     res[row['id']] = {
            //                         key.split('/')[0]: evaluate(key, value, model_fields)
            //                         for key, value in row.items()
            //                         if key != 'id' and value and ('@' in key or key in model_fields)
            //                     }
            //                 create_added = set()
            //                 for key, value in row.items():
            //                     if '/' in key and value:
            //                         CurrentModel = Model
            //                         sub = res[last_id]
            //                         *model_path, fname = key.split('/')
            //                         path_str = "/".join(model_path)
            //                         for path_component in model_path:
            //                             if path_str not in create_added:
            //                                 create_added.add(path_str)
            //                                 sub.setdefault(path_component, [])
            //                                 sub[path_component].append(Command.create({}))
            //                             sub = sub[path_component][-1][2]
            //                             CurrentModel = self.env[CurrentModel[path_component]._name]
            //                         sub[fname] = evaluate(fname, value, CurrentModel._fields)
            // 
            //     except FileNotFoundError:
            //         _logger.debug("No file %s found for template '%s'", model, module)
            // return res
            */
            return default;
        }

        public async Task<TEntity> PostLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _post_load_data(self, template_code, company, template_data):
            // company = (company or self.env.company)
            // additional_properties = template_data.pop('additional_properties', {})
            // 
            // self._setup_utility_bank_accounts(template_code, company, template_data)
            // 
            // # Unaffected earnings account on the company (if not present yet)
            // company.get_unaffected_earnings_account()
            // 
            // # Set newly created Cash difference and Suspense accounts to the Cash and Bank journals
            // for journal in [self.ref(kind, raise_if_not_found=False) for kind in ('bank', 'cash', 'credit')]:
            //     if journal:
            //         journal.suspense_account_id = journal.suspense_account_id or company.account_journal_suspense_account_id
            //         journal.profit_account_id = journal.profit_account_id or company.default_cash_difference_income_account_id
            //         journal.loss_account_id = journal.loss_account_id or company.default_cash_difference_expense_account_id
            // 
            // # Set newly created journals as defaults for the company
            // if not company.tax_cash_basis_journal_id:
            //     company.tax_cash_basis_journal_id = self.ref('caba', raise_if_not_found=False)
            // if not company.currency_exchange_journal_id:
            //     company.currency_exchange_journal_id = self.ref('exch', raise_if_not_found=False)
            // 
            // # Setup default Income/Expense Accounts on Sale/Purchase journals
            // sale_journal = self.ref("sale", raise_if_not_found=False)
            // if sale_journal and template_data.get('property_account_income_categ_id'):
            //     sale_journal.default_account_id = self.ref(template_data.get('property_account_income_categ_id'))
            // purchase_journal = self.ref("purchase", raise_if_not_found=False)
            // if purchase_journal and template_data.get('property_account_expense_categ_id'):
            //     purchase_journal.default_account_id = self.ref(template_data.get('property_account_expense_categ_id'))
            // 
            // # Set default Purchase and Sale taxes on the company
            // if not company.account_sale_tax_id:
            //     company.account_sale_tax_id = self.env['account.tax'].search([
            //         *self.env['account.tax']._check_company_domain(company),
            //         ('type_tax_use', 'in', ('sale', 'all'))], limit=1).id
            // if not company.account_purchase_tax_id:
            //     company.account_purchase_tax_id = self.env['account.tax'].search([
            //         *self.env['account.tax']._check_company_domain(company),
            //         ('type_tax_use', 'in', ('purchase', 'all'))], limit=1).id
            // # Set default taxes on products (only on products having already a tax set in another company, as some flows require no tax at all (e.g TIPS in PoS))
            // # We need to browse the product in sudo to check for the taxes_id and supplier_taxes_id fields regardless of the companies record rules
            // # that would, otherwise, just look empty all the time for the current user/company
            // sudoed_products = self.env['product.template'].sudo().search(self.env['product.template']._check_company_domain(company))
            // 
            // if company.account_sale_tax_id:
            //     sudoed_products_sale = sudoed_products.filtered(
            //         lambda p: p.taxes_id and not p.taxes_id.filtered_domain(p.taxes_id._check_company_domain(company)))
            //     sudoed_products_sale._force_default_sale_tax(company)
            // if company.account_purchase_tax_id:
            //     sudoed_products_purchase = sudoed_products.filtered(
            //         lambda p: p.supplier_taxes_id and not p.supplier_taxes_id.filtered_domain(p.taxes_id._check_company_domain(company)))
            //     sudoed_products_purchase._force_default_purchase_tax(company)
            // 
            // # Display caba fields if there are caba taxes
            // if not company.parent_id and self.env['account.tax'].search_count([('tax_exigibility', '=', 'on_payment')], limit=1):
            //     company.tax_exigibility = True
            // 
            // for field, model in self._get_property_accounts(additional_properties).items():
            //     value = template_data.get(field)
            //     if value and field in self.env[model]._fields:
            //         self.env['ir.default'].set(model, field, self.ref(value).id, company_id=company.id)
            // 
            // # Set default transfer account on the internal transfer reconciliation model
            // reco = self.ref('internal_transfer_reco', raise_if_not_found=False)
            // if reco:
            //     reco.line_ids.sudo().write({'account_id': company.transfer_account_id.id})
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: template_ec.py) ---
            // def _post_load_data(self, template_code, company, template_data):
            // super()._post_load_data(template_code, company, template_data)
            // # Setup default Income/Expense Accounts on Sale/Purchase journals
            // if (purchase_journal := self.ref("purchase", raise_if_not_found=False)) and (expense_account_ref := template_data.get('journal_account_expense_categ_id')):
            //     purchase_journal.default_account_id = self.ref(expense_account_ref, raise_if_not_found=False)
            --- ODOO METHOD SOURCE (MODULE: l10n_nl, FILE: account_chart_template.py) ---
            // def _post_load_data(self, template_code, company, template_data):
            // super()._post_load_data(template_code, company, template_data)
            // if template_code == 'nl':
            //     if cash_tag := self.env.ref('l10n_nl.account_tag_25', raise_if_not_found=False):
            //         company.account_journal_suspense_account_id.tag_ids += cash_tag
            //         company.transfer_account_id.tag_ids += cash_tag
            //     if undist_profit_tag := self.env.ref('l10n_nl.account_tag_undist_profit', raise_if_not_found=False):
            //         company.get_unaffected_earnings_account().tag_ids += undist_profit_tag
            --- ODOO METHOD SOURCE (MODULE: l10n_uk, FILE: template_uk.py) ---
            // def _post_load_data(self, template_code, company, template_data):
            // """If the company is located in Northern Ireland, activate the relevant taxes and fiscal postions."""
            // result = super()._post_load_data(template_code, company, template_data)
            // 
            // is_ni = {
            //     'base.state_uk18', 'base.state_uk19', 'base.state_uk20', 'base.state_uk21',
            //     'base.state_uk22', 'base.state_uk23', 'base.state_uk24',
            // }.intersection(
            //     company.state_id._get_external_ids().get(company.state_id.id, [])
            // )
            // 
            // if is_ni:
            //     for xmlid in ['PT8', 'ST4', 'PT7', 'account_fiscal_position_ni_to_eu_b2b']:
            //         self.ref(xmlid).active = True
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_chart_template.py) ---
            // def _post_load_data(self, template_code, company, template_data):
            // super()._post_load_data(template_code, company, template_data)
            // company = company or self.env.company
            // fields_name = self.env['product.category']._get_stock_account_property_field_names()
            // ProductCategory = self.env['product.category'].with_company(company.id)
            // for fname in fields_name:
            //     fallback = ProductCategory._fields[fname].get_company_dependent_fallback(ProductCategory).id
            //     if ProductCategory.search_count([(fname, '!=', fallback)], limit=1):
            //         continue
            //     value = template_data.get(fname)
            //     if value:
            //         self.env['ir.default'].set('product.category', fname, self.ref(value).id, company_id=company.id)
            */
            return default;
        }

        public async Task<TEntity> PreLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data, object data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _pre_load_data(self, template_code, company, template_data, data):
            // """Pre-process the data and preload some values.
            // 
            // Some of the data needs special pre_process before being fed to the database.
            // e.g. the account codes' width must be standardized to the code_digits applied.
            // The fiscal country code must be put in place before taxes are generated.
            // """
            // if 'account_fiscal_country_id' in data.get('res.company', {}).get(company.id, {}):
            //     fiscal_country = self.ref(data['res.company'][company.id]['account_fiscal_country_id'])
            // else:
            //     fiscal_country = company.account_fiscal_country_id
            // 
            // # Apply template data to the company
            // filter_properties = lambda key: (
            //     (not key.startswith("property_") or key.startswith("property_stock_") or key == "additional_properties")
            //     and key != 'name'
            //     and key in company._fields
            // )
            // 
            // # Set the currency to the fiscal country's currency
            // vals = {key: val for key, val in template_data.items() if filter_properties(key)}
            // if not company.root_id._existing_accounting():
            //     if company.parent_id:
            //         vals['currency_id'] = company.parent_id.currency_id.id
            //     else:
            //         vals['currency_id'] = fiscal_country.currency_id.id
            // if not company.country_id:
            //     vals['country_id'] = fiscal_country.id
            // 
            // # Ensure that we write on 'anglo_saxon_accounting' when changing to a CoA that relies on the default of `False`.
            // vals.setdefault('anglo_saxon_accounting', False)
            // 
            // # This write method is important because it's overridden and has additional triggers
            // # e.g it activates the currency
            // company.write(vals)
            // 
            // # Normalize the code_digits of the accounts
            // code_digits = int(template_data.get('code_digits', 6))
            // for key, account_data in data.get('account.account', {}).items():
            //     if 'code' in account_data:
            //         data['account.account'][key]['code'] = f'{account_data["code"]:<0{code_digits}}'
            // 
            // for model in ('account.fiscal.position', 'account.reconcile.model'):
            //     if model in data:
            //         data[model] = data.pop(model)
            // 
            // if data.get('res.company', {}).get(company.id):
            //     # Filter out default values that we don't want to ignore if the field is not present, in any case.
            //     company_data_to_filter = {'account_production_wip_account_id', 'account_production_wip_overhead_account_id'}
            //     # Remove data of unknown fields present in the company template
            //     for fname in list(data['res.company'][company.id]):
            //         if fname not in company._fields and (not self.env.context.get('l10n_check_fields_complete') or fname in company_data_to_filter):
            //             del data['res.company'][company.id][fname]
            // 
            // # Translate the untranslatable fields we want to translate anyway
            // untranslatable_model_fields = self._get_untranslatable_fields_to_translate()
            // untranslatable_target_lang = self._get_untranslatable_fields_target_language(template_code, company)
            // for model_name, records in data.items():
            //     untranslatable_fields = untranslatable_model_fields.get(model_name, [])
            //     if not untranslatable_fields:
            //         continue
            //     for _xmlid, record in records.items():
            //         for field in untranslatable_fields:
            //             if field not in record:
            //                 continue
            //             translation = self._get_field_translation(record, field, untranslatable_target_lang)
            //             if translation:
            //                 record[field] = translation
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> PreReloadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object data, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _pre_reload_data(self, company, template_data, data, force_create=True):
            // """Pre-process the data in case of reloading the chart of accounts.
            // 
            // When we reload the chart of accounts, we only want to update fields that are main
            // configuration, like:
            // - tax tags
            // - fiscal position mappings linked to new records
            // """
            // for prop in list(template_data):
            //     if prop.startswith('property_'):
            //         template_data.pop(prop)
            // data.pop('account.reconcile.model', None)
            // if 'res.company' in data:
            //     data['res.company'][company.id].clear()
            //     data['res.company'][company.id].setdefault('anglo_saxon_accounting', company.anglo_saxon_accounting)
            // for xmlid, journal_data in list(data.get('account.journal', {}).items()):
            //     if self.ref(xmlid, raise_if_not_found=False):
            //         del data['account.journal'][xmlid]
            //     else:
            //         journal = None
            //         lang = self._get_untranslatable_fields_target_language(company.chart_template, company)
            //         translated_code = self._get_field_translation(journal_data, 'code', lang)
            //         if 'code' in journal_data:
            //             journal_code = translated_code or journal_data['code']
            //             journal = self.env['account.journal'].with_context(active_test=False).search([
            //                 *self.env['account.journal']._check_company_domain(company),
            //                 ('code', '=', journal_code),
            //             ])
            //         # Try to match by journal name to avoid conflict in the unique constraint on the mail alias
            //         translated_name = self._get_field_translation(journal_data, 'name', lang)
            //         if not journal and 'name' in journal_data and 'type' in journal_data:
            //             journal = self.env['account.journal'].with_context(active_test=False).search([
            //                 *self.env['account.journal']._check_company_domain(company),
            //                 ('type', '=', journal_data['type']),
            //                 ('name', 'in', (journal_data['name'], translated_name)),
            //             ], limit=1)
            //         if journal:
            //             del data['account.journal'][xmlid]
            //             self.env['ir.model.data']._update_xmlids([{
            //                 'xml_id': f"account.{company.id}_{xmlid}",
            //                 'record': journal,
            //                 'noupdate': True,
            //             }])
            // 
            // account_group_count = self.env['account.group'].search_count([])
            // if account_group_count:
            //     data.pop('account.group', None)
            // 
            // current_taxes = self.env['account.tax'].with_context(active_test=False).search([
            //     *self.env['account.tax']._check_company_domain(company),
            // ])
            // 
            // current_fiscal_positions =  self.env['account.fiscal.position'].with_context(active_test=False).search([
            //     *self.env['account.fiscal.position']._check_company_domain(company),
            // ])
            // 
            // current_tax_groups = self.env['account.tax.group'].with_context(active_test=False).search([
            //     *self.env['account.tax.group']._check_company_domain(company)
            // ])
            // 
            // unique_tax_name_key = lambda t: (t.name, t.type_tax_use, t.tax_scope, t.company_id)
            // unique_tax_name_keys = set(current_taxes.mapped(unique_tax_name_key))
            // xmlid2tax = {
            //     xml_id.split('.')[1].split('_', maxsplit=1)[1]: self.env['account.tax'].browse(record)
            //     for record, xml_id in current_taxes.get_external_id().items() if xml_id.startswith('account.')
            // }
            // xmlid2fiscal_position= {
            //     xml_id.split('.')[1].split('_', maxsplit=1)[1]: self.env['account.fiscal.position'].browse(record)
            //     for record, xml_id in current_fiscal_positions.get_external_id().items() if xml_id.startswith('account.')
            // }
            // xmlid2tax_group = {
            //     xml_id.split('.')[1].split('_', maxsplit=1)[1]: self.env['account.tax.group'].browse(res_id)
            //     for res_id, xml_id in current_tax_groups.get_external_id().items() if xml_id.startswith('account.')
            // }
            // def tax_template_changed(tax, template):
            //     template_line_ids = [x for x in template.get('repartition_line_ids', []) if x[0] != Command.CLEAR]
            //     return (
            //         tax.amount_type != template.get('amount_type', 'percent')
            //         or float_compare(tax.amount, template.get('amount', 0), precision_digits=4) != 0
            //         # Taxes that don't have repartition lines in their templates get theirs created by default
            //         or len(template_line_ids) not in (0, len(tax.repartition_line_ids))
            //     )
            // 
            // existing_current_year_earnings_account = self.env['account.account'].search([('company_ids', '=', company.id),('account_type', '=', 'equity_unaffected')], limit=1)
            // obsolete_xmlid = set()
            // skip_update = set()
            // for model_name, records in data.items():
            //     for xmlid, values in records.items():
            //         if model_name == 'account.fiscal.position':
            //             # if xmlid is not in xmlid2fiscal_position and we do not force create so we will skip_update for that record
            //             if xmlid not in xmlid2fiscal_position and not force_create:
            //                 skip_update.add((model_name, xmlid))
            //                 continue
            //             # Only add accounts and taxes mappings containing new records
            //             for model in ['account', 'tax']:
            //                 if not force_create:  # there can't be new records if we don't create them
            //                     values.pop(f'{model}_ids', [])
            //                 if old_ids := values.pop(f'{model}_ids', []):
            //                     new_ids = []
            //                     for element in old_ids:
            //                         match element:
            //                             case Command.CREATE, _, (
            //                                 {'tax_src_id': src_id, 'tax_dest_id': dest_id}
            //                                 | {'account_src_id': src_id, 'account_dest_id': dest_id}
            //                             ) if (
            //                                 not self.ref(src_id, raise_if_not_found=False)
            //                                 or (dest_id and not self.ref(dest_id, raise_if_not_found=False))
            //                             ):
            //                                 new_ids.append(element)
            //                     if new_ids:
            //                         values[f'{model}_ids'] = new_ids
            // 
            //         elif model_name == 'account.tax.group':
            //             if xmlid not in xmlid2tax_group and not force_create:
            //                 skip_update.add((model_name, xmlid))
            //                 continue
            // 
            //         elif model_name == 'account.tax':
            //             # Only update the tags of existing taxes
            //             if xmlid not in xmlid2tax or tax_template_changed(xmlid2tax[xmlid], values):
            //                 if not force_create:
            //                     skip_update.add((model_name, xmlid))
            //                     continue
            //                 if self._context.get('force_new_tax_active'):
            //                     values['active'] = True
            //                 if xmlid in xmlid2tax:
            //                     obsolete_xmlid.add(xmlid)
            //                     oldtax = xmlid2tax[xmlid]
            //                 else:
            //                     oldtax = current_taxes.filtered(
            //                         lambda t: t.name == values.get('name')\
            //                               and t.type_tax_use == values.get('type_tax_use')\
            //                               and t.tax_scope == values.get('tax_scope', False)
            //                     )
            //                 uniq_key = unique_tax_name_key(oldtax[0] if len(oldtax) > 1 else oldtax)
            //                 matching_names = len(list(filter(lambda t: re.match(fr"^(?:\[old\d*\] |){uniq_key[0]}$", t[0]) and t[1:] == uniq_key[1:], unique_tax_name_keys)))
            //                 for index, tax_to_rename in enumerate(oldtax):
            //                     rename_idx = index + matching_names
            //                     if rename_idx:
            //                         tax_to_rename.name = f"[old{rename_idx - 1 if rename_idx > 1 else ''}] {tax_to_rename.name}"
            //             else:
            //                 repartition_lines = values.get('repartition_line_ids')
            //                 values.clear()
            //                 if repartition_lines:
            //                     values['repartition_line_ids'] = repartition_lines
            //                     for element in values.get('repartition_line_ids', []):
            //                         match element:
            //                             case int() as command, _, {'tag_ids': tags} as repartition_line_values if command in tuple(Command):
            //                                 repartition_line_values.clear()
            //                                 repartition_line_values['tag_ids'] = tags or [Command.clear()]
            //         elif model_name == 'account.account':
            //             if  existing_current_year_earnings_account and values['account_type'] == 'equity_unaffected':
            //                 skip_update.add((model_name, xmlid))
            //                 continue
            //             # Point or create xmlid to existing record to avoid duplicate code
            //             account = self.ref(xmlid, raise_if_not_found=False)
            //             normalized_code = f'{values["code"]:<0{int(template_data.get("code_digits", 6))}}'
            //             if not account or not re.match(f'^{values["code"]}0*$', account.code):
            //                 query = self.env['account.account']._search(self.env['account.account']._check_company_domain(company))
            //                 account_code = self.with_company(company).env['account.account']._field_to_sql('account_account', 'code', query)
            //                 query.add_where(SQL("%s SIMILAR TO %s", account_code, f'{values["code"]}0*'))
            //                 accounts = self.env['account.account'].browse(query)
            //                 existing_account = accounts.sorted(key=lambda x: x.code != normalized_code)[0] if accounts else None
            //                 if existing_account:
            //                     self.env['ir.model.data']._update_xmlids([{
            //                         'xml_id': f"account.{company.id}_{xmlid}",
            //                         'record': existing_account,
            //                         'noupdate': True,
            //                     }])
            //                     account = existing_account
            // 
            //             # Prevents overriding user setting & raising a partial reconcile error.
            //             values.pop('reconcile', None)
            //             # on existing accounts, only tag_ids are to be updated using default data
            //             if account and 'tag_ids' in data[model_name][xmlid]:
            //                 data[model_name][xmlid] = {'tag_ids': data[model_name][xmlid]['tag_ids']}
            //             elif account or not force_create:
            //                 skip_update.add((model_name, xmlid))
            // 
            // for skip_model, skip_xmlid in skip_update:
            //     data[skip_model].pop(skip_xmlid, None)
            // 
            // if obsolete_xmlid:
            //     self.env['ir.model.data'].search([
            //         ('name', 'in', [f"{company.id}_{xmlid}" for xmlid in obsolete_xmlid]),
            //         ('module', '=', 'account'),
            //     ]).unlink()
            // 
            // custom_fields = {  # Don't alter values that can be changed by the users
            //     'account.fiscal.position.tax_ids',
            // }
            // for model_name, records in data.items():
            //     _fields = self.env[model_name]._fields
            //     for xmlid, values in records.items():
            //         x2manyfields = [
            //             fname
            //             for fname in values
            //             if fname in _fields
            //             and f"{model_name}.{fname}" not in custom_fields
            //             and _fields[fname].type in ('one2many', 'many2many')
            //             and isinstance(values[fname], (list, tuple))
            //         ]
            //         if x2manyfields:
            //             if isinstance(xmlid, int):
            //                 rec = self.env[model_name].browse(xmlid).exists()
            //             else:
            //                 rec = self.ref(xmlid, raise_if_not_found=False)
            //             if rec:
            //                 for fname in x2manyfields:
            //                     for i, (line, (command, _id, vals)) in enumerate(zip(rec[fname], values[fname])):
            //                         if command == Command.CREATE:  # converts ORM command `create` into `update`
            //                             values[fname][i] = Command.update(line.id, vals)
            */
            return default;
        }

        public async Task<TEntity> RefAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object raise_if_not_found) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def ref(self, xmlid, raise_if_not_found=True):
            // if '.' in xmlid:
            //     return self.env.ref(xmlid, raise_if_not_found)
            // return (
            //     self.env.ref(f"account.{self.env.company.id}_{xmlid}", raise_if_not_found=False)
            //     or self.env.ref(f"account.{self.env.company.parent_ids[0].id}_{xmlid}", raise_if_not_found)
            // )
            */
            return default;
        }

        public async Task<TEntity> SelectChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _select_chart_template(self, country=None):
            // """Get the available templates in a format suited for Selection fields."""
            // country = country if country is not None else self.env.company.country_id
            // chart_template_mapping = self._get_chart_template_mapping()
            // return [
            //     (template_code, template['name'])
            //     for template_code, template in sorted(chart_template_mapping.items(), key=(lambda t: (
            //         t[1]['name'] != 'generic_coa' if not country
            //         else t[1]['country_id'] != country.id
            //     )))
            // ]
            */
            return default;
        }

        public async Task<TEntity> SetupCompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _setup_complete(self):
            // super()._setup_complete()
            // self.env.registry[self._name]._template_register = AccountChartTemplate._template_register
            */
            return default;
        }

        public async Task<TEntity> SetupUtilityBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _setup_utility_bank_accounts(self, template_code, company, template_data):
            // """Define basic bank accounts for the company.
            // 
            // - Suspense Account
            // - Outstanding Receipts/Payments Accounts
            // - Cash Difference Gain/Loss Accounts
            // - Liquidity Transfer Account
            // """
            // # Create utility bank_accounts
            // bank_prefix = company.bank_account_code_prefix
            // code_digits = int(template_data.get('code_digits', 6))
            // accounts_data = self._get_accounts_data_values(company, template_data, bank_prefix=bank_prefix, code_digits=code_digits)
            // for fname in list(accounts_data):
            //     if company[fname]:
            //         del accounts_data[fname]
            // if company.parent_id:
            //     for company_attr_name in accounts_data:
            //         company[company_attr_name] = company.parent_ids[0][company_attr_name]
            // else:
            //     accounts = self.env['account.account']._load_records([
            //         {
            //             'xml_id': f"account.{company.id}_{xml_id}",
            //             'values': values,
            //             'noupdate': True,
            //         }
            //         for xml_id, values in accounts_data.items()
            //     ])
            //     for company_attr_name, account in zip(accounts_data.keys(), accounts):
            //         company[company_attr_name] = account
            // 
            // # No fields on company
            // if not company.parent_id:
            //     accounts_data_no_fields = {
            //         'account_journal_payment_debit_account_id': {
            //             'name': _("Outstanding Receipts"),
            //             'prefix': bank_prefix,
            //             'code_digits': code_digits,
            //             'account_type': 'asset_current',
            //             'reconcile': True,
            //         },
            //         'account_journal_payment_credit_account_id': {
            //             'name': _("Outstanding Payments"),
            //             'prefix': bank_prefix,
            //             'code_digits': code_digits,
            //             'account_type': 'asset_current',
            //             'reconcile': True,
            //         },
            //     }
            //     self.env['account.account']._load_records([
            //         {
            //             'xml_id': f"account.{company.id}_{xml_id}",
            //             'values': values,
            //             'noupdate': True,
            //         }
            //         for xml_id, values in accounts_data_no_fields.items()
            //     ])
            --- ODOO METHOD SOURCE (MODULE: l10n_at, FILE: template_at.py) ---
            // def _setup_utility_bank_accounts(self, template_code, company, template_data):
            // super()._setup_utility_bank_accounts(template_code, company, template_data)
            // if template_code == "at":
            //     bank_tags = self.env.ref('l10n_at.account_tag_external_code_2300') | self.env.ref('l10n_at.account_tag_l10n_at_ABIV')
            //     company.account_journal_suspense_account_id.tag_ids = bank_tags
            //     company.transfer_account_id.tag_ids = self.env.ref('l10n_at.account_tag_external_code_2885') | self.env.ref('l10n_at.account_tag_l10n_at_ABIV')
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: chart_template.py) ---
            // def _setup_utility_bank_accounts(self, template_code, company, template_data):
            // super()._setup_utility_bank_accounts(template_code, company, template_data)
            // if template_code in ["de_skr03", "de_skr04"]:
            //     company.account_journal_suspense_account_id.tag_ids = self.env.ref('l10n_de.tag_de_asset_bs_B_II_4')
            //     company.transfer_account_id.tag_ids = self.env.ref('l10n_de.tag_de_asset_bs_B_IV')
            --- ODOO METHOD SOURCE (MODULE: l10n_dk, FILE: template_dk.py) ---
            // def _setup_utility_bank_accounts(self, template_code, company, template_data):
            // super()._setup_utility_bank_accounts(template_code, company, template_data)
            // if template_code == 'dk':
            //     company.account_journal_suspense_account_id.tag_ids = self.env.ref('l10n_dk.account_tag_6482')
            //     company.transfer_account_id.tag_ids = self.env.ref('l10n_dk.account_tag_6831')
            --- ODOO METHOD SOURCE (MODULE: l10n_lt, FILE: template_lt.py) ---
            // def _setup_utility_bank_accounts(self, template_code, company, template_data):
            // super()._setup_utility_bank_accounts(template_code, company, template_data)
            // if template_code == "lt":
            //     bank_tags = self.env.ref('l10n_lt.account_account_tag_b_4')
            //     company.account_journal_suspense_account_id.tag_ids |= bank_tags
            //     company.transfer_account_id.tag_ids |= bank_tags
            // 
            //     other_operating_results_tags = self.env.ref('l10n_lt.account_account_tag_6_other_operating_results')
            //     company.default_cash_difference_income_account_id.tag_ids |= other_operating_results_tags
            //     company.default_cash_difference_expense_account_id.tag_ids |= other_operating_results_tags
            */
            return default;
        }

        public async Task<TEntity> TemplateRegisterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def _template_register(self):
            // def is_template(func):
            //     return callable(func) and hasattr(func, '_l10n_template')
            // template_register = defaultdict(lambda: defaultdict(list))
            // cls = self.env.registry[self._name]
            // for _attr, func in getmembers(cls, is_template):
            //     template, model = func._l10n_template
            //     template_register[template][model].append(func)
            // cls._template_register = template_register
            // return template_register
            */
            return default;
        }

        public async Task<TEntity> TryLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: chart_template.py) ---
            // def try_loading(self, template_code, company, install_demo=False, force_create=True):
            // """Check if the chart template can be loaded then proceeds installing it.
            // 
            // :param template_code: code of the chart template to be loaded.
            // :type template_code: str
            // :param company: the company we try to load the chart template on.
            //     If not provided, it is retrieved from the context.
            // :type company: int, Model<res.company>
            // :param install_demo: whether or not we should load demo data right after loading the
            //     chart template.
            // :type install_demo: bool
            // """
            // if not company:
            //     return
            // if not self.env.registry.loaded and not install_demo and not hasattr(self.env.registry, '_auto_install_template'):
            //     _logger.warning(
            //         'Incorrect usage of try_loading without a fully loaded registry. This could lead to issues. (%s-%s)',
            //         company.name,
            //         template_code
            //     )
            // if isinstance(company, int):
            //     company = self.env['res.company'].browse([company])
            // 
            // template_code = template_code or company and self._guess_chart_template(company.country_id)
            // 
            // if template_code in {'syscohada', 'syscebnl'} and template_code != company.chart_template:
            //     raise UserError(_("The %s chart template shouldn't be selected directly. Instead, you should directly select the chart template related to your country.", template_code))
            // 
            // return self._load(template_code, company, install_demo, force_create)
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: account_chart_template.py) ---
            // def try_loading(self, template_code, company, install_demo=False, force_create=True):
            // # During company creation load template code corresponding to the AFIP Responsibility
            // if not company:
            //     return
            // if isinstance(company, int):
            //     company = self.env['res.company'].browse([company])
            // if company.country_code == 'AR' and not company.chart_template:
            //     match = {
            //         self.env.ref('l10n_ar.res_RM'): 'ar_base',
            //         self.env.ref('l10n_ar.res_IVAE'): 'ar_ex',
            //         self.env.ref('l10n_ar.res_IVARI'): 'ar_ri',
            //     }
            //     template_code = match.get(company.l10n_ar_afip_responsibility_type_id, template_code)
            // return super().try_loading(template_code, company, install_demo, force_create)
            */
            return default;
        }
    }
}