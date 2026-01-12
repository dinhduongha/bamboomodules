using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountPaymentTermAppService : GenericApplicationService<AccountPaymentTerm>, IAccountPaymentTermAppService
    {

        public AccountPaymentTermAppService(IRepository<AccountPaymentTerm, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<AccountPaymentTerm> CheckLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _check_lines(self):
            // round_precision = self.env['decimal.precision'].precision_get('Payment Terms')
            // for terms in self:
            //     total_percent = sum(line.value_amount for line in terms.line_ids if line.value == 'percent')
            //     if float_round(total_percent, precision_digits=round_precision) != 100:
            //         raise ValidationError(_('The Payment Term must have at least one percent line and the sum of the percent must be 100%.'))
            //     if len(terms.line_ids) > 1 and terms.early_discount:
            //         raise ValidationError(
            //             _("The Early Payment Discount functionality can only be used with payment terms using a single 100% line. "))
            //     if terms.early_discount and terms.discount_percentage <= 0.0:
            //         raise ValidationError(_("The Early Payment Discount must be strictly positive."))
            //     if terms.early_discount and terms.discount_days <= 0:
            //         raise ValidationError(_("The Early Payment Discount days must be strictly positive."))
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_currency_id(self):
            // for payment_term in self:
            //     payment_term.currency_id = payment_term.company_id.currency_id or self.env.company.currency_id
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeDiscountComputationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_discount_computation(self):
            // for pay_term in self:
            //     country_code = pay_term.company_id.country_code or self.env.company.country_code
            //     if country_code == 'BE':
            //         pay_term.early_pay_discount_computation = 'mixed'
            //     elif country_code == 'NL':
            //         pay_term.early_pay_discount_computation = 'excluded'
            //     else:
            //         pay_term.early_pay_discount_computation = 'included'
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeExampleInvalidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_example_invalid(self):
            // for payment_term in self:
            //     payment_term.example_invalid = not payment_term.line_ids
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeExamplePreviewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_example_preview(self):
            // for record in self:
            //     example_preview = ""
            //     record.example_preview_discount = ""
            //     currency = record.currency_id
            //     if record.early_discount:
            //         date = record._get_last_discount_date_formatted(record.example_date or fields.Date.context_today(record))
            //         discount_amount = record._get_amount_due_after_discount(record.example_amount, 0.0)
            //         record.example_preview_discount = _(
            //             "Early Payment Discount: <b>%(amount)s</b> if paid before <b>%(date)s</b>",
            //             amount=formatLang(self.env, discount_amount, currency_obj=currency),
            //             date=date,
            //         )
            // 
            //     if not record.example_invalid:
            //         terms = record._compute_terms(
            //             date_ref=record.example_date or fields.Date.context_today(record),
            //             currency=currency,
            //             company=self.env.company,
            //             tax_amount=0,
            //             tax_amount_currency=0,
            //             untaxed_amount=record.example_amount,
            //             untaxed_amount_currency=record.example_amount,
            //             sign=1)
            //         for i, info_by_dates in enumerate(record._get_amount_by_date(terms).values()):
            //             date = info_by_dates['date']
            //             amount = info_by_dates['amount']
            //             example_preview += "<div>"
            //             example_preview += _(
            //                 "<b>%(count)s#</b> Installment of <b>%(amount)s</b> due on <b style='color: #704A66;'>%(date)s</b>",
            //                 count=i+1,
            //                 amount=formatLang(self.env, amount, currency_obj=currency),
            //                 date=date,
            //             )
            //             example_preview += "</div>"
            // 
            //     record.example_preview = example_preview
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     allowed_companies = record.company_id or self.env.companies
            //     record.fiscal_country_codes = ",".join(allowed_companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeTermsInternalAsync(object date_ref, object currency, object company, object tax_amount, object tax_amount_currency, object sign, object untaxed_amount, object untaxed_amount_currency, object cash_rounding)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _compute_terms(self, date_ref, currency, company, tax_amount, tax_amount_currency, sign, untaxed_amount, untaxed_amount_currency, cash_rounding=None):
            // """Get the distribution of this payment term.
            // :param date_ref: The move date to take into account
            // :param currency: the move's currency
            // :param company: the company issuing the move
            // :param tax_amount: the signed tax amount for the move
            // :param tax_amount_currency: the signed tax amount for the move in the move's currency
            // :param untaxed_amount: the signed untaxed amount for the move
            // :param untaxed_amount_currency: the signed untaxed amount for the move in the move's currency
            // :param sign: the sign of the move
            // :param cash_rounding: the cash rounding that should be applied (or None).
            //     We assume that the input total in move currency (tax_amount_currency + untaxed_amount_currency) is already cash rounded.
            //     The cash rounding does not change the totals: Consider the sum of all the computed payment term amounts in move / company currency.
            //     It is the same as the input total in move / company currency.
            // :return (list<tuple<datetime.date,tuple<float,float>>>): the amount in the company's currency and
            //     the document's currency, respectively for each required payment date
            // """
            // self.ensure_one()
            // company_currency = company.currency_id
            // total_amount = tax_amount + untaxed_amount
            // total_amount_currency = tax_amount_currency + untaxed_amount_currency
            // rate = abs(total_amount_currency / total_amount) if total_amount else 0.0
            // 
            // pay_term = {
            //     'total_amount': total_amount,
            //     'discount_percentage': self.discount_percentage if self.early_discount else 0.0,
            //     'discount_date': date_ref + relativedelta(days=(self.discount_days or 0)) if self.early_discount else False,
            //     'discount_balance': 0,
            //     'line_ids': [],
            // }
            // 
            // if self.early_discount:
            //     # Early discount is only available on single line, 100% payment terms.
            //     discount_percentage = self.discount_percentage / 100.0
            //     if self.early_pay_discount_computation in ('excluded', 'mixed'):
            //         pay_term['discount_balance'] = company_currency.round(total_amount - untaxed_amount * discount_percentage)
            //         pay_term['discount_amount_currency'] = currency.round(total_amount_currency - untaxed_amount_currency * discount_percentage)
            //     else:
            //         pay_term['discount_balance'] = company_currency.round(total_amount * (1 - discount_percentage))
            //         pay_term['discount_amount_currency'] = currency.round(total_amount_currency * (1 - discount_percentage))
            // 
            //     if cash_rounding:
            //         cash_rounding_difference_currency = cash_rounding.compute_difference(currency, pay_term['discount_amount_currency'])
            //         if not currency.is_zero(cash_rounding_difference_currency):
            //             pay_term['discount_amount_currency'] += cash_rounding_difference_currency
            //             pay_term['discount_balance'] = company_currency.round(pay_term['discount_amount_currency'] / rate) if rate else 0.0
            // 
            // residual_amount = total_amount
            // residual_amount_currency = total_amount_currency
            // 
            // for i, line in enumerate(self.line_ids):
            //     term_vals = {
            //         'date': line._get_due_date(date_ref),
            //         'company_amount': 0,
            //         'foreign_amount': 0,
            //     }
            // 
            //     # The last line is always the balance, no matter the type
            //     on_balance_line = i == len(self.line_ids) - 1
            //     if on_balance_line:
            //         term_vals['company_amount'] = residual_amount
            //         term_vals['foreign_amount'] = residual_amount_currency
            //     elif line.value == 'fixed':
            //         # Fixed amounts
            //         term_vals['company_amount'] = sign * company_currency.round(line.value_amount / rate) if rate else 0.0
            //         term_vals['foreign_amount'] = sign * currency.round(line.value_amount)
            //     else:
            //         # Percentage amounts
            //         line_amount = company_currency.round(total_amount * (line.value_amount / 100.0))
            //         line_amount_currency = currency.round(total_amount_currency * (line.value_amount / 100.0))
            //         term_vals['company_amount'] = line_amount
            //         term_vals['foreign_amount'] = line_amount_currency
            // 
            //     if cash_rounding and not on_balance_line:
            //         # The value `residual_amount_currency` is always cash rounded (in case of cash rounding).
            //         #   * We assume `total_amount_currency` is cash rounded.
            //         #   * We only subtract cash rounded amounts.
            //         # Thus the balance line is cash rounded.
            //         cash_rounding_difference_currency = cash_rounding.compute_difference(currency, term_vals['foreign_amount'])
            //         if not currency.is_zero(cash_rounding_difference_currency):
            //             term_vals['foreign_amount'] += cash_rounding_difference_currency
            //             term_vals['company_amount'] = company_currency.round(term_vals['foreign_amount'] / rate) if rate else 0.0
            // 
            //     residual_amount -= term_vals['company_amount']
            //     residual_amount_currency -= term_vals['foreign_amount']
            //     pay_term['line_ids'].append(term_vals)
            // 
            // return pay_term
            */
            return default;
        }

        public async Task<AccountPaymentTerm> CopyDataAsync(Guid id, AccountPaymentTermCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=_("%s (copy)", line.name)) for line, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPaymentTerm> DefaultExampleDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _default_example_date(self):
            // return self._context.get('example_date') or fields.Date.today()
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> DefaultLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _default_line_ids(self):
            // return [Command.create({'value': 'percent', 'value_amount': 100.0, 'nb_days': 0})]
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetAmountByDateInternalAsync(object terms)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _get_amount_by_date(self, terms):
            // """
            // Returns a dictionary with the amount for each date of the payment term
            // (grouped by date, discounted percentage and discount last date,
            // sorted by date and ignoring null amounts).
            // """
            // terms_lines = sorted(terms["line_ids"], key=lambda t: t.get('date'))
            // amount_by_date = {}
            // for term in terms_lines:
            //     key = frozendict({
            //         'date': term['date'],
            //     })
            //     results = amount_by_date.setdefault(key, {
            //         'date': format_date(self.env, term['date']),
            //         'amount': 0.0,
            //     })
            //     results['amount'] += term['foreign_amount']
            // return amount_by_date
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetAmountDueAfterDiscountInternalAsync(object total_amount, object untaxed_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _get_amount_due_after_discount(self, total_amount, untaxed_amount):
            // self.ensure_one()
            // if self.early_discount:
            //     percentage = self.discount_percentage / 100.0
            //     if self.early_pay_discount_computation in ('excluded', 'mixed'):
            //         discount_amount_currency = (total_amount - untaxed_amount) * percentage
            //     else:
            //         discount_amount_currency = total_amount * percentage
            //     return self.currency_id.round(total_amount - discount_amount_currency)
            // return total_amount
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetLastDiscountDateFormattedInternalAsync(object date_ref)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _get_last_discount_date_formatted(self, date_ref):
            // self.ensure_one()
            // if not date_ref:
            //     return None
            // return format_date(self.env, self._get_last_discount_date(date_ref))
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetLastDiscountDateInternalAsync(object date_ref)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _get_last_discount_date(self, date_ref):
            // self.ensure_one()
            // if not date_ref:
            //     return None
            // return date_ref + relativedelta(days=self.discount_days or 0) if self.early_discount else False
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> UnlinkExceptReferencedTermsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_term.py) ---
            // def _unlink_except_referenced_terms(self):
            // if self.env['account.move'].search_count([('invoice_payment_term_id', 'in', self.ids)], limit=1):
            //     raise UserError(_('You can not delete payment terms as other records still reference it. However, you can archive it.'))
            */
            return default;
        }
    }
}