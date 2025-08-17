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
    [Module("l10n_account_withholding_tax", Depends = new[] { "account" })]
    public class AccountWithholdingLineAppService : ApplicationService, IAccountWithholdingLineAppService
    {

        public AccountWithholdingLineAppService() 
        {

        }

        public async Task<TEntity> ComputeAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_account_id(self):
            // """
            // If there is an account set on the withholding_tax_base_account_id, this field will be invisible and use that
            // account as default value.
            // """
            // for line in self:
            //     line.account_id = line.account_id or line.company_id.withholding_tax_base_account_id
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_amount(self):
            // """
            // Compute the tax amount by multiplying the original tax amount (amount in currency, at the time of creation) by
            // a ratio calculated from the current base amount and the original base amount.
            // """
            // for line in self:
            //     line_curr = line.comodel_currency_id
            //     if line.original_base_amount:
            //         line.amount = line_curr.round(line.original_tax_amount * line.base_amount / line.original_base_amount)
            //     else:
            //         line.amount = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_base_amount(self):
            // """
            // Computation of the base amount is done by using a paid factor.
            // This factor is unused on payments, but used for lines on the register payment wizard in order to dynamically
            // support installments, early payment discounts,...
            // """
            // for line in self:
            //     line_curr = line.comodel_currency_id
            //     if line.source_currency_id:
            //         percentage_paid_factor = line.comodel_percentage_paid_factor
            //         line.base_amount = line_curr.round(line.original_base_amount * percentage_paid_factor)
            */
            return default;
        }

        public async Task<TEntity> ComputeComodelCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_comodel_currency_id(self):
            // for line in self:
            //     line.comodel_currency_id = line.payment_id.currency_id
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_comodel_currency_id(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ComputeComodelDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_comodel_date(self):
            // for line in self:
            //     line.comodel_date = line.payment_id.date
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_comodel_date(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ComputeComodelFullAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_comodel_full_amount(self):
            // for line in self:
            //     line.comodel_full_amount = line.payment_register_id.amount
            */
            return default;
        }

        public async Task<TEntity> ComputeComodelPaymentTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_comodel_payment_type(self):
            // for line in self:
            //     line.comodel_payment_type = line.payment_id.payment_type
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_comodel_payment_type(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ComputeComodelPercentagePaidFactorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_comodel_percentage_paid_factor(self):
            // self.comodel_percentage_paid_factor = 1.0
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_company_id(self):
            // for line in self:
            //     line.company_id = line.payment_id.company_id
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_company_id(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_currency_id(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ComputeOriginalAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_original_amounts(self):
            // """ Adds a dependency to the payment amount to ensure recomputation when necessary. """
            // super()._compute_original_amounts()
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_original_amounts(self):
            // """
            // Computes the two original_xx_amount fields; that are used during computation of the withholding line base and tax
            // amounts.
            // These amounts correspond to the source amounts (from the payment or register payment wizard) after converting them
            // to the line currency.
            // """
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     source_curr = line.source_currency_id
            //     company = line.company_id
            //     date = line.comodel_date
            //     comp_curr = line.comodel_company_currency_id
            //     line_curr = line.comodel_currency_id
            //     if not source_curr:
            //         rate = 1.0
            //         base_amount = line.base_amount
            //         if line.tax_id:
            //             base_line = AccountTax._prepare_base_line_for_taxes_computation(
            //                 line,
            //                 tax_ids=line.tax_id,
            //                 price_unit=base_amount,
            //                 quantity=1.0,
            //                 currency_id=line_curr,
            //                 calculate_withholding_taxes=True,
            //             )
            //             AccountTax._add_tax_details_in_base_line(base_line, company)
            //             AccountTax._round_base_lines_tax_details([base_line], company)
            //             tax_amount = -base_line['tax_details']['taxes_data'][0]['tax_amount_currency']
            //         else:
            //             tax_amount = 0.0
            //     elif source_curr == line_curr:
            //         rate = 1.0
            //         base_amount = line.source_base_amount_currency
            //         tax_amount = line.source_tax_amount_currency
            //     elif source_curr != comp_curr and line_curr == comp_curr:
            //         rate = self.env['res.currency']._get_conversion_rate(
            //             from_currency=source_curr,
            //             to_currency=comp_curr,
            //             company=company,
            //             date=date,
            //         )
            //         base_amount = line.source_base_amount_currency
            //         tax_amount = line.source_tax_amount_currency
            //     else:
            //         rate = self.env['res.currency']._get_conversion_rate(
            //             from_currency=comp_curr,
            //             to_currency=line_curr,
            //             company=company,
            //             date=date,
            //         )
            //         base_amount = line.source_base_amount
            //         tax_amount = line.source_tax_amount
            //     line.original_base_amount = line_curr.round(base_amount * rate)
            //     line.original_tax_amount = line_curr.round(tax_amount * rate)
            */
            return default;
        }

        public async Task<TEntity> ComputePlaceholderTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_placeholder_type(self):
            // """
            // Since the placeholder_value has to be recomputed on all lines by the comodel, we need
            // a way to track the changed regarding the sequence and the name. Since the ORM is quite
            // limited for such advance feature, we use a trick here: we store the current and the previous
            // state of the placeholder to be able to detect the changes.
            // """
            // for line in self:
            //     line.previous_placeholder_type = line.placeholder_type
            //     if not line.name and line.withholding_sequence_id:
            //         line.placeholder_type = 'given_by_sequence'
            //     elif line.name:
            //         line.placeholder_type = 'given_by_name'
            //     else:
            //         line.placeholder_type = 'not_defined'
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeTaxUseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _compute_type_tax_use(self):
            // for line in self:
            //     line.type_tax_use = 'sale' if line.payment_id.payment_type == 'inbound' else 'purchase'
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _compute_type_tax_use(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ConstrainsAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _constrains_account_id(self):
            // """ The account on the line cannot be one deemed as liquidity account, otherwise it will cause issues with the final entry. """
            // for line in self:
            //     if line.account_id in line._get_valid_liquidity_accounts():
            //         raise UserError(line.env._('The account "%(account_name)s" is not valid to use on withholding lines.', account_name=line.account_id.display_name))
            */
            return default;
        }

        public async Task<TEntity> ConstrainsBaseAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _constrains_base_amount(self):
            // """ It wouldn't make sense to register a withholding tax with no base amount. """
            // for line in self:
            //     if line.comodel_currency_id.compare_amounts(line.base_amount, 0) <= 0:
            //         raise UserError(line.env._("The base amount of a withholding tax line must be above 0."))
            */
            return default;
        }

        public async Task<TEntity> GetGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _get_grouping_key(self):
            // """ Helper returning the grouping key for this line; should match what is done in _prepare_withholding_lines_commands. """
            // self.ensure_one()
            // # /!\ Please keep this aligned with _prepare_withholding_lines_commands to ensure correct computation.
            // return frozendict({
            //     'name': self.name,
            //     'analytic_distribution': self.analytic_distribution,
            //     'account': self.account_id.id,
            //     'tax_id': self.tax_id.id,
            //     'skip': False,
            //     'currency_id': self.source_currency_id.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> GetValidLiquidityAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _get_valid_liquidity_accounts(self):
            // """
            // Get the valid liquidity accounts for the payment;
            // If the account of the line matches one of these, the resulting entry will be wrong, thus we need to check the
            // account against these to avoid such issue.
            // """
            // return (
            //     self.payment_id.journal_id.default_account_id |
            //     self.payment_id.payment_method_line_id.payment_account_id |
            //     self.payment_id.journal_id.inbound_payment_method_line_ids.payment_account_id |
            //     self.payment_id.journal_id.outbound_payment_method_line_ids.payment_account_id |
            //     self.payment_id.outstanding_account_id
            // )
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _get_valid_liquidity_accounts(self):
            // """ Get the valid liquidity accounts for the payment; we need to ensure that the line account does not match any of them. """
            // return ()
            */
            return default;
        }

        public async Task<TEntity> GetWithholdingTaxDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object payment_type) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _get_withholding_tax_domain(self, company, payment_type):
            // """ Construct and return a domain that will filter withholding taxes available for this company and payment type. """
            // filter_domain = models.check_company_domain_parent_of(self, company)
            // payment_type = 'purchase' if payment_type == 'outbound' else 'sale'
            // return expression.AND([filter_domain, [('type_tax_use', '=', payment_type), ('is_withholding_tax_on_payment', '=', True)]])
            */
            return default;
        }

        public async Task<TEntity> NeedUpdateWithholdingLinesPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _need_update_withholding_lines_placeholder(self):
            // """ Determines if the lines' placeholders needs update or not. """
            // return self and any(line.previous_placeholder_type != line.placeholder_type for line in self)
            */
            return default;
        }

        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self):
            // """
            // Convert self to a tax base line using the correct structure needed for tax computation.
            // This is used when preparing the journal items representing the withholding lines in the final payment entry.
            // """
            // self.ensure_one()
            // company = self.company_id
            // currency = self.comodel_currency_id
            // conversion_date = self.comodel_date
            // conversion_rate = self.env['res.currency']._get_conversion_rate(company.currency_id, currency, company, conversion_date)
            // payment_type = self.comodel_payment_type
            // sign = 1 if payment_type == 'inbound' else -1
            // # We need to make sure that we use the actual amounts set on the line; in case of manual adjustment.
            // manual_tax_amounts = {str(self.tax_id.id): {
            //     'base_amount_currency': self.base_amount,
            //     'tax_amount_currency': -self.amount,
            // }}
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     tax_ids=self.tax_id,
            //     price_unit=self.base_amount,
            //     quantity=1.0,
            //     currency_id=currency,
            //     rate=conversion_rate,
            //     sign=sign,
            //     account_id=self.account_id,
            //     calculate_withholding_taxes=True,
            //     manual_tax_line_name=self.name,
            //     computation_key=str(self.id),
            //     manual_tax_amounts=manual_tax_amounts,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareWithholdingAmlsCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_payment_withholding_line.py) ---
            // def _prepare_withholding_amls_create_values(self):
            // """
            // Simply adds a check to ensure that we don't call this method on lines belonging to multiple payments; as it
            // is not intended.
            // """
            // assert len(self.payment_id) == 1, self.env._("All withholding lines in self must have the same payment.")
            // return super()._prepare_withholding_amls_create_values()
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _prepare_withholding_amls_create_values(self):
            // """ Prepare and return a list of values that will be used to create the journal items for the withholding lines.
            // 
            // For an invoice for 1000 with 10% withholding tax:
            // Outstanding:              900.0
            // Receivable:               -1000.0
            // Tax withheld:             100.0
            // WHT base:                 1000.0
            // WHT base counterpart:     1000.0
            // 
            // :return: A list of dictionaries, each one being a journal item to be created.
            // """
            // if not self:
            //     return []
            // 
            // company = self.company_id
            // AccountTax = self.env['account.tax']
            // 
            // # Check names first to not consume sequences if any is missing
            // for line in self:
            //     if not line.name and not line.withholding_sequence_id:
            //         raise UserError(self.env._('Please enter the withholding number for the tax %(tax_name)s', tax_name=line.tax_id.name))
            // 
            // # Convert them to base lines to compute the taxes.
            // base_lines = []
            // for line in self:
            //     if not line.name:
            //         line.name = line.tax_id.withholding_sequence_id.next_by_id()
            // 
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     base_lines.append(base_line)
            // AccountTax._round_base_lines_tax_details(base_lines, company)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, company)
            // tax_results = AccountTax._prepare_tax_lines(base_lines, company)
            // 
            // # Add the tax lines.
            // aml_create_values_list = []
            // for tax_line_vals in tax_results['tax_lines_to_add']:
            //     aml_create_values_list.append({
            //         **tax_line_vals,
            //         'name': self.env._("WH Tax: %(name)s", name=tax_line_vals['name']),
            //         'amount_currency': -tax_line_vals['amount_currency'],
            //         'balance': -tax_line_vals['balance'],
            //     })
            // 
            // # Aggregate the base lines.
            // aggregated_base_lines = defaultdict(lambda: {
            //     'names': set(),
            //     'amount_currency': 0.0,
            //     'balance': 0.0,
            // })
            // for base_line, to_update in tax_results['base_lines_to_update']:
            //     grouping_key = frozendict({
            //         **AccountTax._prepare_base_line_grouping_key(base_line),
            //         'tax_tag_ids': to_update['tax_tag_ids'],
            //     })
            //     aggregated_amounts = aggregated_base_lines[grouping_key]
            //     aggregated_amounts['names'].add(base_line['record'].name)
            //     aggregated_amounts['amount_currency'] += to_update['amount_currency']
            //     aggregated_amounts['balance'] += to_update['balance']
            // 
            // # Add the base lines.
            // for grouping_key, amounts in aggregated_base_lines.items():
            //     aml_create_values_list.append({
            //         **grouping_key,
            //         'name': self.env._('WH Base: %(names)s', names=', '.join(amounts['names'])),
            //         'amount_currency': amounts['amount_currency'],
            //         'balance': amounts['balance'],
            //     })
            //     aml_create_values_list.append({
            //         **grouping_key,
            //         'name': self.env._('WH Base Counterpart: %(names)s', names=', '.join(amounts['names'])),
            //         'tax_ids': [],
            //         'tax_tag_ids': [],
            //         'analytic_distribution': None,
            //         'amount_currency': -amounts['amount_currency'],
            //         'balance': -amounts['balance'],
            //     })
            // 
            // return aml_create_values_list
            */
            return default;
        }

        public async Task<TEntity> PrepareWithholdingLinesCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _prepare_withholding_lines_commands(self, base_lines, company):
            // """
            // Calculate the withholding tax amounts by using the provided tax base lines, and then compare the resulting values
            // with the withholding line in self to determine which line should be updated, deleted or created.
            // 
            // :returns A list of commands that should be used to update the withholding line field in the calling model.
            // """
            // AccountTax = self.env['account.tax']
            // 
            // # The base lines completely ignore the withholding taxes.
            // # Now, it's time to compute them.
            // new_base_lines = []
            // for base_line in base_lines:
            //     new_base_lines.append(AccountTax._prepare_base_line_for_taxes_computation(
            //         base_line,
            //         calculate_withholding_taxes=True,
            //         manual_tax_line_name=base_line.get('manual_tax_line_name'),
            //         filter_tax_function=None,
            //     ))
            // 
            // AccountTax._add_tax_details_in_base_lines(new_base_lines, company)
            // AccountTax._round_base_lines_tax_details(new_base_lines, company)
            // 
            // # Map the existing withholding tax lines to their grouping key in order to know which line to update, create or delete.
            // existing_withholding_line_map = self.grouped(key=lambda l: l._get_grouping_key())
            // 
            // def grouping_function(base_line_data, tax_data):
            //     if not tax_data:
            //         return None
            //     account = company.withholding_tax_base_account_id or base_line_data['account_id']
            //     tax = tax_data['tax']
            //     # Note: keep this aligned with _get_grouping_key
            //     return {
            //         'name': base_line_data.get('manual_tax_line_name', tax.name),
            //         'analytic_distribution': base_line_data['analytic_distribution'],
            //         'account': account.id,
            //         'tax_id': tax_data['tax'].id,
            //         'skip': not tax_data['tax'].is_withholding_tax_on_payment,
            //         'currency_id': base_line_data['currency_id'].id,
            //     }
            // 
            // base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(new_base_lines, grouping_function)
            // values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            // withholding_line_commands = []
            // for grouping_key, values in values_per_grouping_key.items():
            //     if not grouping_key or grouping_key['skip']:
            //         continue
            // 
            //     existing_line = existing_withholding_line_map.get(grouping_key)
            // 
            //     # If we have more than one existing line matching the grouping key, we will create a new one instead.
            //     if existing_line and len(existing_line) > 1:
            //         for line in existing_line[1:]:
            //             withholding_line_commands.append(Command.delete(line.id))
            //         existing_line = existing_line[:1]
            // 
            //     if existing_line:
            //         # Compute the amount for existing withholding lines when the lines are updated in the view
            //         # We only want to recompute the tax amount
            //         withholding_line_commands.append(Command.update(existing_line.id, {
            //             'source_base_amount_currency': values['base_amount_currency'],
            //             'source_base_amount': values['base_amount'],
            //             'source_tax_amount_currency': -values['tax_amount_currency'],
            //             'source_tax_amount': -values['tax_amount'],
            //         }))
            //     else:
            //         withholding_line_commands.append(Command.create({
            //             'name': grouping_key['name'],
            //             'tax_id': grouping_key['tax_id'],
            //             'analytic_distribution': grouping_key['analytic_distribution'],
            //             'account_id': grouping_key['account'],
            //             'source_base_amount_currency': values['base_amount_currency'],
            //             'source_base_amount': values['base_amount'],
            //             'source_tax_amount_currency': -values['tax_amount_currency'],
            //             'source_tax_amount': -values['tax_amount'],
            //             'source_tax_id': grouping_key['tax_id'],
            //             'source_currency_id': grouping_key['currency_id'],
            //         }))
            // 
            // keys_to_remove = existing_withholding_line_map.keys() - values_per_grouping_key.keys()
            // for key in keys_to_remove:
            //     for line in existing_withholding_line_map[key]:
            //         withholding_line_commands.append(Command.delete(line.id))
            // 
            // return withholding_line_commands
            */
            return default;
        }

        public async Task<TEntity> UpdatePlaceholdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountWithholdingLineable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: account_withholding_line.py) ---
            // def _update_placeholders(self):
            // """ Update the placeholders for the lines in self; updating them sequentially so that the placeholders make sense. """
            // lines_per_sequence = self\
            //     .sorted()\
            //     .grouped(lambda l: l.placeholder_type == 'given_by_sequence' and l.withholding_sequence_id)
            // for sequence, lines in lines_per_sequence.items():
            //     if sequence:
            //         for i, line in enumerate(lines):
            //             line.write({
            //                 'placeholder_value': sequence.get_next_char(sequence.number_next_actual + i),
            //                 'previous_placeholder_type': line.placeholder_type,
            //             })
            //     else:
            //         for line in lines:
            //             line.write({
            //                 'placeholder_value': None,
            //                 'previous_placeholder_type': line.placeholder_type,
            //             })
            */
            return default;
        }
    }
}