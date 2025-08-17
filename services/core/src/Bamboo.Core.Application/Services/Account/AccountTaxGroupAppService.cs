using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountTaxGroupAppService : GenericApplicationService<AccountTaxGroup>, IAccountTaxGroupAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountTaxGroupAppService(IRepository<AccountTaxGroup, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<AccountTaxGroup> CheckAccountsConfigurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_tax.py) ---
            // def _check_accounts_configuration(self):
            // account_fields = self.env['account.account']._fields
            // account_type_selection_values = dict(account_fields['account_type']._description_selection(self.env))
            // reconcile_field_name = account_fields['reconcile'].get_description(self.env)['string']
            // non_trade_field_name = account_fields['non_trade'].get_description(self.env)['string']
            // 
            // for group in self:
            //     for field_name in ('tax_payable_account_id', 'tax_receivable_account_id'):
            //         if group[field_name] and not (
            //             group[field_name].account_type in ('asset_receivable', 'liability_payable')
            //             and group[field_name].reconcile
            //             and group[field_name].non_trade
            //         ):
            //             raise ValidationError(
            //                 self.env._(
            //                     '%(tax_account)s (%(account_name)s) should be an account of type "%(receivable)s" or "%(payable)s" with both options "%(allow_reconciliation)s" and "%(non_trade)s" enabled.',
            //                     tax_account=self._fields[field_name].get_description(self.env)['string'],
            //                     account_name=group[field_name].display_name,
            //                     receivable=account_type_selection_values['asset_receivable'],
            //                     payable=account_type_selection_values['liability_payable'],
            //                     allow_reconciliation=reconcile_field_name,
            //                     non_trade=non_trade_field_name,
            //                 ),
            //             )
            */
            return default;
        }

        protected async Task<AccountTaxGroup> CheckMisconfiguredTaxGroupsInternalAsync(object company, object countries)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_tax.py) ---
            // def _check_misconfigured_tax_groups(self, company, countries):
            // """ Searches the tax groups used on the taxes from company in countries that don't have
            // at least a tax payable account, a tax receivable account or an advance tax payment account.
            // 
            // :return: A boolean telling whether or not there are misconfigured groups for any
            //          of these countries, in this company
            // """
            // return bool(self.env['account.tax'].search([
            //     *self.env['account.tax']._check_company_domain(company),
            //     ('country_id', 'in', countries.ids),
            //     '|',
            //     ('tax_group_id.tax_payable_account_id', '=', False),
            //     ('tax_group_id.tax_receivable_account_id', '=', False),
            // ], limit=1))
            */
            return default;
        }

        public async Task<AccountTaxGroup> CheckUninstallRequiredAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: account_tax_group.py) ---
            // def check_uninstall_required(self):
            // """
            // Make sure we don't uninstall a required tax group
            // """
            // ar_companies = self.filtered(lambda g: g.company_id.chart_template.startswith('ar_')).mapped('company_id')
            // profits_tax_group_ids = self.env['ir.model.data'].search([
            //     ('name', 'in', [f'{company.id}_tax_group_percepcion_ganancias' for company in ar_companies]),
            //     ('module', '=', 'account'),
            // ]).mapped('res_id')
            // if profit_tax_groups_to_be_deleted := self.filtered(lambda g: g.id in profits_tax_group_ids):
            //     raise UserError(
            //         _(
            //             "The tax group '%s' can't be removed, since it is required in the Argentinian localization.",
            //             profit_tax_groups_to_be_deleted[0].name,
            //         )
            //     )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountTaxGroup> ComputeCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_tax.py) ---
            // def _compute_country_id(self):
            // for group in self:
            //     group.country_id = group.company_id.account_fiscal_country_id or group.company_id.country_id
            */
            return default;
        }

        protected async Task<AccountTaxGroup> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_tax_group.py) ---
            // def _load_pos_data_domain(self, data):
            // tax_group_ids = [tax_data['tax_group_id'] for tax_data in data['account.tax']['data']]
            // return [('id', 'in', tax_group_ids)]
            */
            return default;
        }

        protected async Task<AccountTaxGroup> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_tax_group.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'pos_receipt_label']
            */
            return default;
        }
    }
}