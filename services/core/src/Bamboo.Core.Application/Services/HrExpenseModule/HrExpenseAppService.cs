using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("HrExpenseModule", Depends = new[] { "account", "web_tour", "hr" })]
    public class HrExpenseAppService : GenericApplicationService<HrExpense>, IHrExpenseAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrExpenseAppService(IRepository<HrExpense, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<HrExpense> ApproveDuplicatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_approve_duplicates(self):
            // root = self.env['ir.model.data']._xmlid_to_res_id("base.partner_root")
            // for expense in self.duplicate_expense_ids:
            //     expense.message_post(
            //         body=_('%(user)s confirms this expense is not a duplicate with similar expense.', user=self.env.user.name),
            //         author_id=root,
            //     )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> AttachDocumentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def attach_document(self, **kwargs):
            // """When an attachment is uploaded as a receipt, set it as the main attachment."""
            // self._message_set_main_attachment_id(self.env["ir.attachment"].browse(kwargs['attachment_ids'][-1:]), force=True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> CheckAmountNotZeroAsync(Guid id, HrExpenseCheckAmountNotZeroRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def check_amount_not_zero(self, vals):
            // error_msgs = []
            // if 'total_amount' in vals:
            //     if any(expense.company_currency_id.is_zero(vals['total_amount']) for expense in self):
            //         error_msgs.append(_("You cannot set the expense total to 0 if it's linked to a report."))
            // if 'total_amount_currency' in vals:
            //     if any(expense.currency_id.is_zero(vals['total_amount_currency']) for expense in self):
            //         error_msgs.append(_("You cannot set the expense total in currency to 0 if it's linked to a report."))
            // if error_msgs:
            //     raise UserError("\n".join(error_msgs))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> CheckPaymentModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_payment_mode(self):
            // self.sheet_id._check_payment_mode()
            */
            return default;
        }

        protected async Task<HrExpense> ComputeAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_account_id(self):
            // property_field = self.env['product.category']._fields['property_account_expense_categ_id']
            // for _expense in self:
            //     expense = _expense.with_company(_expense.company_id)
            //     if not expense.product_id:
            //         expense.account_id = property_field.get_company_dependent_fallback(self.env['product.category'])
            //         continue
            //     account = expense.product_id.product_tmpl_id._get_product_accounts()['expense']
            //     if account:
            //         expense.account_id = account
            */
            return default;
        }

        protected async Task<HrExpense> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_analytic_distribution(self):
            // for expense in self:
            //     distribution = self.env['account.analytic.distribution.model']._get_distribution({
            //         'product_id': expense.product_id.id,
            //         'product_categ_id': expense.product_id.categ_id.id,
            //         'partner_id': expense.employee_id.work_contact_id.id,
            //         'partner_category_id': expense.employee_id.work_contact_id.category_id.ids,
            //         'account_prefix': expense.account_id.code,
            //         'company_id': expense.company_id.id,
            //     })
            //     expense.analytic_distribution = distribution or expense.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: hr_expense.py) ---
            // def _compute_analytic_distribution(self):
            // project_id = self.env.context.get('project_id')
            // if not project_id:
            //     super()._compute_analytic_distribution()
            // else:
            //     analytic_distribution = self.env['project.project'].browse(project_id)._get_analytic_distribution()
            //     for expense in self:
            //         expense.analytic_distribution = expense.analytic_distribution or analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: project_sale_expense, FILE: hr_expense.py) ---
            // def _compute_analytic_distribution(self):
            // super()._compute_analytic_distribution()
            // if not self.env.context.get('project_id'):
            //     for expense in self:
            //         if not self.sale_order_id:
            //             continue
            //         expense.analytic_distribution = expense.sale_order_id.project_id._get_analytic_distribution()
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCanBeReinvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py) ---
            // def _compute_can_be_reinvoiced(self):
            // for expense in self:
            //     expense.can_be_reinvoiced = expense.product_id.expense_policy in ['sales_price', 'cost']
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_currency_id(self):
            // for expense in self:
            //     if expense.product_has_cost and expense.state in {'draft', 'reported'}:
            //         expense.currency_id = expense.company_currency_id
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_currency_rate(self):
            // """
            //     We want the default odoo rate when the following change:
            //     - the currency of the expense
            //     - the total amount in foreign currency
            //     - the date of the expense
            //     this will cause the rate to be recomputed twice with possible changes but we don't have the required fields
            //     to store the override state in stable
            // """
            // date_today = fields.Date.context_today(self)
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         if (
            //                 expense.currency_id != expense._origin.currency_id
            //                 or expense.total_amount_currency != expense._origin.total_amount_currency
            //                 or expense.date != expense._origin.date
            //         ):
            //             expense._set_expense_currency_rate(date_today=date_today)
            //         else:
            //             expense.currency_rate = expense.total_amount / expense.total_amount_currency if expense.total_amount_currency else 1.0
            //     else:  # Mono-currency case computation shortcut, no need for the label if there is no conversion
            //         expense.currency_rate = 1.0
            //         expense.label_currency_rate = False
            //         continue
            // 
            //     expense.label_currency_rate = _(
            //         '1 %(exp_cur)s = %(rate)s %(comp_cur)s',
            //         exp_cur=expense.currency_id.name,
            //         rate=float_repr(expense.currency_rate, 6),
            //         comp_cur=expense.company_currency_id.name,
            //     )
            */
            return default;
        }

        protected async Task<HrExpense> ComputeDuplicateExpenseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_duplicate_expense_ids(self):
            // self.duplicate_expense_ids = [Command.clear()]
            // 
            // expenses = self.filtered(lambda expense: expense.employee_id and expense.product_id and expense.total_amount_currency)
            // if expenses.ids:
            //     duplicates_query = """
            //       SELECT ARRAY_AGG(DISTINCT he.id)
            //         FROM hr_expense AS he
            //         JOIN hr_expense AS ex ON he.employee_id = ex.employee_id
            //                              AND he.product_id = ex.product_id
            //                              AND he.date = ex.date
            //                              AND he.total_amount_currency = ex.total_amount_currency
            //                              AND he.company_id = ex.company_id
            //                              AND he.currency_id = ex.currency_id
            //        WHERE ex.id in %(expense_ids)s
            //        GROUP BY he.employee_id, he.product_id, he.date, he.total_amount_currency, he.company_id, he.currency_id
            //       HAVING COUNT(he.id) > 1
            //     """
            //     self.env.cr.execute(duplicates_query, {'expense_ids': tuple(expenses.ids)})
            // 
            //     for duplicates_ids in (x[0] for x in self.env.cr.fetchall()):
            //         expenses_duplicates = expenses.filtered(lambda expense: expense.id in duplicates_ids)
            //         expenses_duplicates.duplicate_expense_ids = [Command.set(duplicates_ids)]
            //         expenses = expenses - expenses_duplicates
            */
            return default;
        }

        protected async Task<HrExpense> ComputeEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_employee_id(self):
            // if not self.env.context.get('default_employee_id'):
            //     for expense in self:
            //         expense.employee_id = self.env.user.with_company(expense.company_id).employee_id
            */
            return default;
        }

        protected async Task<HrExpense> ComputeFromProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_from_product(self):
            // for expense in self:
            //     expense.product_has_cost = expense.product_id and not expense.company_currency_id.is_zero(expense.product_id.standard_price)
            //     expense.product_has_tax = bool(expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id)))
            */
            return default;
        }

        protected async Task<HrExpense> ComputeIsEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_is_editable(self):
            // for expense in self:
            //     if expense.sheet_id:
            //         expense.is_editable = expense.sheet_id.is_editable
            //     else:
            //         expense.is_editable = True
            */
            return default;
        }

        protected async Task<HrExpense> ComputeIsMultipleCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_is_multiple_currency(self):
            // for expense in self:
            //     expense.is_multiple_currency = expense.currency_id != expense.company_currency_id
            */
            return default;
        }

        protected async Task<HrExpense> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_name(self):
            // for expense in self:
            //     expense.name = expense.name or expense.product_id.display_name
            */
            return default;
        }

        protected async Task<HrExpense> ComputeNbAttachmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_nb_attachment(self):
            // attachment_data = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.expense'), ('res_id', 'in', self.ids)],
            //     ['res_id'],
            //     ['__count'],
            // )
            // attachment = dict(attachment_data)
            // for expense in self:
            //     expense.nb_attachment = attachment.get(expense._origin.id, 0)
            */
            return default;
        }

        protected async Task<HrExpense> ComputePriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_price_unit(self):
            // """
            //    The price_unit is the unit price of the product if no product is set and no attachment overrides it.
            //    Otherwise it is always computed from the total_amount and the quantity else it would break the vendor bill
            //    when edited after creation.
            // """
            // for expense in self:
            //     if expense.state not in {'draft', 'reported'}:
            //         continue
            //     product_id = expense.product_id
            //     if expense._needs_product_price_computation():
            //         expense.price_unit = product_id._price_compute(
            //             'standard_price',
            //             uom=expense.product_uom_id,
            //             company=expense.company_id,
            //         )[product_id.id]
            //     else:
            //         expense.price_unit = expense.company_currency_id.round(expense.total_amount / expense.quantity) if expense.quantity else 0.
            */
            return default;
        }

        protected async Task<HrExpense> ComputeProductDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_product_description(self):
            // for expense in self:
            //     expense.product_description = not is_html_empty(expense.product_id.description) and expense.product_id.description
            */
            return default;
        }

        protected async Task<HrExpense> ComputeSaleOrderIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py) ---
            // def _compute_sale_order_id(self):
            // for expense in self.filtered(lambda e: not e.can_be_reinvoiced):
            //     expense.sale_order_id = False
            */
            return default;
        }

        protected async Task<HrExpense> ComputeSameReceiptExpenseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_same_receipt_expense_ids(self):
            // self.same_receipt_expense_ids = [Command.clear()]
            // 
            // expenses_with_attachments = self.filtered(lambda expense: expense.attachment_ids)
            // if not expenses_with_attachments:
            //     return
            // 
            // expenses_groupby_checksum = dict(self.env['ir.attachment']._read_group(domain=[
            //     ('res_model', '=', 'hr.expense'),
            //     ('checksum', 'in', expenses_with_attachments.attachment_ids.mapped('checksum'))],
            //     groupby=['checksum'],
            //     aggregates=['res_id:array_agg'],
            // ))
            // 
            // for expense in expenses_with_attachments:
            //     same_receipt_ids = set()
            //     for attachment in expense.attachment_ids:
            //         same_receipt_ids.update(expenses_groupby_checksum[attachment.checksum])
            //     same_receipt_ids.remove(expense.id)
            // 
            //     expense.same_receipt_expense_ids = [Command.set(list(same_receipt_ids))]
            */
            return default;
        }

        protected async Task<HrExpense> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_state(self):
            // for expense in self:
            //     if not expense.sheet_id:
            //         expense.state = 'draft'
            //     elif expense.sheet_id.state == 'draft':
            //         expense.state = 'reported'
            //     elif expense.sheet_id.state == 'cancel':
            //         expense.state = 'refused'
            //     elif expense.sheet_id.state in {'approve', 'post'}:
            //         expense.state = 'approved'
            //     elif not expense.sheet_id.account_move_ids:
            //         expense.state = 'submitted'
            //     else:
            //         expense.state = 'done'
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxAmountCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_amount_currency(self):
            // """
            //      Note: as total_amount_currency can be set directly by the user (for product without cost)
            //      or needs to be computed (for product with cost), `untaxed_amount_currency` can't be computed in the same method as `total_amount_currency`.
            // """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     base_line = expense._prepare_base_line_for_taxes_computation(
            //         price_unit=expense.total_amount_currency,
            //         quantity=1.0,
            //     )
            //     AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //     AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //     tax_details = base_line['tax_details']
            //     expense.tax_amount_currency = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     expense.untaxed_amount_currency = tax_details['total_excluded_currency']
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_amount(self):
            // """
            //      Note: as total_amount can be set directly by the user when the currency_rate is overriden,
            //      the tax must be computed after the total_amount.
            // """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount,
            //             quantity=1.0,
            //             currency=expense.company_currency_id,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         tax_details = base_line['tax_details']
            //         expense.tax_amount = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     else:  # Mono-currency case computation shortcut
            //         expense.tax_amount = expense.tax_amount_currency
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_ids(self):
            // for _expense in self:
            //     expense = _expense.with_company(_expense.company_id)
            //     # taxes only from the same company
            //     expense.tax_ids = expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id))
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTotalAmountCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_total_amount_currency(self):
            // AccountTax = self.env['account.tax']
            // for expense in self.filtered('product_has_cost'):
            //     base_line = expense._prepare_base_line_for_taxes_computation(price_unit=expense.price_unit, quantity=expense.quantity)
            //     AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //     AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //     expense.total_amount_currency = base_line['tax_details']['total_included_currency']
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTotalAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_total_amount(self):
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount_currency * expense.currency_rate,
            //             quantity=1.0,
            //             currency_id=expense.company_currency_id,
            //             rate=1.0,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         expense.total_amount = base_line['tax_details']['total_included_currency']
            //     else:  # Mono-currency case computation shortcut
            //         expense.total_amount = expense.total_amount_currency
            */
            return default;
        }

        protected async Task<HrExpense> ComputeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_uom_id(self):
            // for expense in self:
            //     expense.product_uom_id = expense.product_id.uom_id
            */
            return default;
        }

        public override async Task<HrExpense> CreateAsync(HrExpense entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def create(self, vals_list):
            // expenses = super().create(vals_list)
            // if self.env.context.get('check_total_amount_not_zero'):
            //     for expense, vals in zip(expenses, vals_list):
            //         expense.check_amount_not_zero(vals)
            // return expenses
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: hr_expense.py) ---
            // def create(self, vals_list):
            // project_id = self.env.context.get('project_id')
            // if project_id:
            //     analytic_distribution = self.env['project.project'].browse(project_id)._get_analytic_distribution()
            //     if analytic_distribution:
            //         for vals in vals_list:
            //             vals['analytic_distribution'] = vals.get('analytic_distribution', analytic_distribution)
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<HrExpense> CreateExpenseFromAttachmentsAsync(Guid id, HrExpenseCreateExpenseFromAttachmentsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def create_expense_from_attachments(self, attachment_ids=None, view_type='list'):
            // """
            //     Create the expenses from files.
            // 
            //     :return: An action redirecting to hr.expense list view.
            // """
            // if not attachment_ids:
            //     raise UserError(_("No attachment was provided"))
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // expenses = self.env['hr.expense']
            // 
            // if any(attachment.res_id or attachment.res_model != 'hr.expense' for attachment in attachments):
            //     raise UserError(_("Invalid attachments!"))
            // 
            // product = self.env['product.product'].search([('can_be_expensed', '=', True)])
            // if product:
            //     product = product.filtered(lambda p: p.default_code == "EXP_GEN")[:1] or product[0]
            // else:
            //     raise UserError(_("You need to have at least one category that can be expensed in your database to proceed!"))
            // 
            // for attachment in attachments:
            //     attachment_name = '.'.join(attachment.name.split('.')[:-1])
            //     vals = {
            //         'name': attachment_name,
            //         'price_unit': 0,
            //         'product_id': product.id,
            //     }
            //     if product.property_account_expense_id:
            //         vals['account_id'] = product.property_account_expense_id.id
            //     expense = self.env['hr.expense'].create(vals)
            //     attachment.write({'res_model': 'hr.expense', 'res_id': expense.id})
            // 
            //     expense._message_set_main_attachment_id(attachment, force=True)
            //     expenses += expense
            // return {
            //     'name': _('Generate Expenses'),
            //     'res_model': 'hr.expense',
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, view_type], [False, "form"]],
            //     'domain': [('id', 'in', expenses.ids)],
            //     'context': self.env.context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> CreateSheetsFromExpenseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _create_sheets_from_expense(self):
            // if self.filtered(lambda expense: not expense.is_editable):
            //     raise UserError(_('You are not authorized to edit this expense.'))
            // sheets = self.env['hr.expense.sheet'].create(self._get_default_expense_sheet_values())
            // return sheets
            */
            return default;
        }

        protected async Task<HrExpense> DefaultEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _default_employee_id(self):
            // employee = self.env.user.employee_id
            // if not employee and not self.env.user.has_group('hr_expense.group_hr_expense_team_approver'):
            //     raise ValidationError(_('The current user has no related employee. Please, create one.'))
            // return employee
            */
            return default;
        }

        public async Task<HrExpense> GetAttachmentViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_get_attachment_view(self):
            // self.ensure_one()
            // res = self.env['ir.actions.act_window']._for_xml_id('base.action_attachment')
            // res.update({
            //     'domain': [('res_model', '=', 'hr.expense'), ('res_id', 'in', self.ids)],
            //     'context': {'default_res_model': 'hr.expense', 'default_res_id': self.id},
            // })
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> GetBaseAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_base_account(self):
            // """
            // Returns the expense account or forces default values if none was found
            // We need to do this as the installation process may delete the original account, and it doesn't recompute properly after
            // Returned expense accounts are the first expense account encountered in the following list:
            // 1. expense account of the expense itself
            // 2. expense account of the product
            // 3. expense account of the product category
            // 4. expense account on the purchase journal for employee expense
            // """
            // 
            // # expense account of the expense itself
            // account = self.account_id
            // 
            // if account:
            //     return account
            // 
            // # expense account of the product then the product category
            // if self.product_id:
            //     account = self.product_id.product_tmpl_id._get_product_accounts()['expense']
            // else:
            //     field = self.env['product.category']._fields['property_account_expense_categ_id']
            //     account = field.get_company_dependent_fallback(self.env['product.category'])
            // 
            // if account:
            //     return account
            // 
            // # expense account on the purchase journal for employee expense
            // journal = self.sheet_id.journal_id
            // if journal.type == 'purchase':
            //     account = journal.default_account_id
            // 
            // return account
            */
            return default;
        }

        protected async Task<HrExpense> GetDefaultExpenseSheetValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_default_expense_sheet_values(self):
            // # If there is an expense with total_amount == 0, it means that expense has not been processed by OCR yet
            // expenses_with_amount = self.filtered(lambda expense: not (
            //     expense.currency_id.is_zero(expense.total_amount_currency)
            //     or expense.company_currency_id.is_zero(expense.total_amount)
            //     or (expense.product_id and not float_round(expense.quantity, precision_rounding=expense.product_uom_id.rounding))
            // ))
            // 
            // if any(expense.state != 'draft' or expense.sheet_id for expense in expenses_with_amount):
            //     raise UserError(_("You cannot report twice the same line!"))
            // if not expenses_with_amount:
            //     raise UserError(_("You cannot report the expenses without amount!"))
            // if len(expenses_with_amount.mapped('employee_id')) != 1:
            //     raise UserError(_("You cannot report expenses for different employees in the same report."))
            // if any(not expense.product_id for expense in expenses_with_amount):
            //     raise UserError(_("You can not create report without category."))
            // if len(self.company_id) != 1:
            //     raise UserError(_("You cannot report expenses for different companies in the same report."))
            // 
            // # Check if two reports should be created
            // own_expenses = expenses_with_amount.filtered(lambda x: x.payment_mode == 'own_account')
            // company_expenses = expenses_with_amount - own_expenses
            // create_two_reports = own_expenses and company_expenses
            // 
            // sheets = (own_expenses, company_expenses) if create_two_reports else (expenses_with_amount,)
            // values = []
            // 
            // # We use a fallback name only when several expense sheets are created,
            // # else we use the form view required name to force the user to set a name
            // for todo in sheets:
            //     paid_by = 'company' if todo[0].payment_mode == 'company_account' else 'employee'
            //     sheet_name = self.env['hr.expense.sheet']._get_default_sheet_name(todo)
            //     if not sheet_name and len(sheets) > 1:
            //         sheet_name = _("New Expense Report, paid by %(paid_by)s", paid_by=paid_by)
            //     values.append({
            //         'company_id': self.company_id.id,
            //         'employee_id': self[0].employee_id.id,
            //         'name': sheet_name,
            //         'expense_line_ids': [Command.set(todo.ids)],
            //         'state': 'draft',
            //     })
            // return values
            */
            return default;
        }

        protected async Task<HrExpense> GetEmployeeFromEmailInternalAsync(object email_address)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_employee_from_email(self, email_address):
            // employee = self.env['hr.employee'].search([
            //     ('user_id', '!=', False),
            //     '|',
            //     ('work_email', 'ilike', email_address),
            //     ('user_id.email', 'ilike', email_address),
            // ])
            // 
            // if len(employee) > 1:
            //     # Several employees can be linked to the same user.
            //     # In that case, we only keep the employee that matched the user's company.
            //     return employee.filtered(lambda e: e.company_id == e.user_id.company_id)
            // 
            // if not employee:
            //     # An employee does not always have a user.
            //     return self.env['hr.employee'].search([
            //         ('user_id', '=', False),
            //         ('work_email', 'ilike', email_address),
            //     ], limit=1)
            // 
            // return employee
            */
            return default;
        }

        public async Task<HrExpense> GetEmptyListHelpAsync(Guid id, HrExpenseGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_empty_list_help(self, help_message):
            // return super().get_empty_list_help((help_message or '') + self._get_empty_list_mail_alias())
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> GetEmptyListMailAliasInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_empty_list_mail_alias(self):
            // use_mailgateway = self.env['ir.config_parameter'].sudo().get_param('hr_expense.use_mailgateway')
            // expense_alias = self.env.ref('hr_expense.mail_alias_expense', raise_if_not_found=False) if use_mailgateway else False
            // if expense_alias and expense_alias.alias_domain and expense_alias.alias_name:
            //     # encode, but force %20 encoding for space instead of a + (URL / mailto difference)
            //     params = werkzeug.urls.url_encode({'subject': _("Lunch with customer $12.32")}).replace('+', '%20')
            //     return Markup(
            //         """<div class="text-muted mt-4">%(send_string)s <a class="text-body" href="mailto:%(alias_email)s?%(params)s">%(alias_email)s</a></div>"""
            //     ) % {
            //         'alias_email': expense_alias.display_name,
            //         'params': params,
            //         'send_string': _("Tip: try sending receipts by email"),
            //     }
            // return ""
            */
            return default;
        }

        public async Task<HrExpense> GetExpenseAttachmentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expense_attachments(self):
            // return self.attachment_ids.mapped('image_src')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> GetExpenseDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expense_dashboard(self):
            // expense_state = {
            //     'to_submit': {
            //         'description': _('to submit'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'submitted': {
            //         'description': _('under validation'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'approved': {
            //         'description': _('to be reimbursed'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     }
            // }
            // if not self.env.user.employee_ids:
            //     return expense_state
            // target_currency = self.env.company.currency_id
            // # Counting the expenses to display in the dashboard:
            // # - To submit: contains the expenses paid either by the employee or by the company, and that are draft or reported
            // # - Under validation: contains expenses paid by the employee or paid by the company, and that have been submitted but still need to be approved/refused
            // # - To be reimbursed: contains ONLY expenses paid by the employee that are approved, the payment has not yet been made
            // expenses = self._read_group(
            //     [
            //         ('employee_id', 'in', self.env.user.employee_ids.ids),
            //         '|', '&', ('payment_mode', 'in', ('own_account', 'company_account')), ('state', 'in', ('draft', 'reported', 'submitted')),
            //              '&', ('payment_mode', '=', 'own_account'), ('state', '=', 'approved')
            //     ], ['state'], ['total_amount:sum'])
            // for state, total_amount_sum in expenses:
            //     if state in {'draft', 'reported'}:  # Fuse the two states into only one "To Submit" state
            //         state = 'to_submit'
            //     expense_state[state]['amount'] += total_amount_sum
            // return expense_state
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> GetExpensesToSubmitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expenses_to_submit(self):
            // # if there ere no records selected, then select all draft expenses for the user
            // if self:
            //     expenses = self.filtered(lambda expense: expense.state == 'draft' and not expense.sheet_id and expense.is_editable)
            // else:
            //     expenses = self.env['hr.expense'].search([
            //         ('state', '=', 'draft'),
            //         ('sheet_id', '=', False),
            //         ('employee_id', '=', self.env.user.employee_id.id),
            //     ]).filtered(lambda expense: expense.is_editable)
            // 
            // if not expenses:
            //     raise UserError(_('You have no expense to report'))
            // return expenses.action_submit_expenses()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> GetMoveLineNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_move_line_name(self):
            // """ Helper to get the name of the account move lines related to an expense """
            // self.ensure_one()
            // expense_name = self.name.split("\n")[0][:64]
            // return _('%(employee_name)s: %(expense_name)s', employee_name=self.employee_id.name, expense_name=expense_name)
            */
            return default;
        }

        protected async Task<HrExpense> GetSplitValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_split_values(self):
            // self.ensure_one()
            // half_price = self.total_amount_currency / 2
            // price_round_up = float_round(half_price, precision_digits=self.currency_id.decimal_places, rounding_method='UP')
            // price_round_down = float_round(half_price, precision_digits=self.currency_id.decimal_places, rounding_method='DOWN')
            // 
            // return [{
            //     'name': self.name,
            //     'product_id': self.product_id.id,
            //     'total_amount_currency': price,
            //     'tax_ids': self.tax_ids.ids,
            //     'currency_id': self.currency_id.id,
            //     'company_id': self.company_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'employee_id': self.employee_id.id,
            //     'expense_id': self.id,
            // } for price in (price_round_up, price_round_down)]
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py) ---
            // def _get_split_values(self):
            // vals = super(Expense, self)._get_split_values()
            // for split_value in vals:
            //     split_value['sale_order_id'] = self.sale_order_id.id
            // return vals
            */
            return default;
        }

        protected async Task<HrExpense> InverseTotalAmountCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _inverse_total_amount_currency(self):
            // for expense in self:
            //     if not expense.is_editable:
            //         raise UserError(_('You are not authorized to edit this expense.'))
            //     expense.price_unit = (expense.total_amount / expense.quantity) if expense.quantity != 0 else 0.
            */
            return default;
        }

        protected async Task<HrExpense> InverseTotalAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _inverse_total_amount(self):
            // """ Allows to set a custom rate on the expense, and avoid the override when it makes no sense """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount,
            //             quantity=1.0,
            //             currency=expense.company_currency_id,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         tax_details = base_line['tax_details']
            //         expense.tax_amount = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     else:
            //         expense.total_amount_currency = expense.total_amount
            //         expense.tax_amount = expense.tax_amount_currency
            //     expense.currency_rate = expense.total_amount / expense.total_amount_currency if expense.total_amount_currency else 1.0
            //     expense.price_unit = expense.total_amount / expense.quantity if expense.quantity else expense.total_amount
            */
            return default;
        }

        public async Task<HrExpense> MessageNewAsync(Guid id, HrExpenseMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // email_address = email_split(msg_dict.get('email_from', False))[0]
            // employee = self._get_employee_from_email(email_address)
            // 
            // if not employee:
            //     return super().message_new(msg_dict, custom_values=custom_values)
            // 
            // expense_description = msg_dict.get('subject', '')
            // 
            // if employee.user_id:
            //     company = employee.user_id.company_id
            //     currencies = company.currency_id | employee.user_id.company_ids.mapped('currency_id')
            // else:
            //     company = employee.company_id
            //     currencies = company.currency_id
            // 
            // if not company:  # ultimate fallback, since company_id is required on expense
            //     company = self.env.company
            // 
            // # The expenses alias is the same for all companies, we need to set the proper context
            // # To select the product account
            // self = self.with_company(company)
            // 
            // product, price, currency_id, expense_description = self._parse_expense_subject(expense_description, currencies)
            // vals = {
            //     'employee_id': employee.id,
            //     'name': expense_description,
            //     'total_amount_currency': price,
            //     'product_id': product.id if product else None,
            //     'product_uom_id': product.uom_id.id,
            //     'tax_ids': [Command.set(product.supplier_taxes_id.filtered(lambda r: r.company_id == company).ids)],
            //     'quantity': 1,
            //     'company_id': company.id,
            //     'currency_id': currency_id.id
            // }
            // 
            // account = product.product_tmpl_id._get_product_accounts()['expense']
            // if account:
            //     vals['account_id'] = account.id
            // 
            // expense = super().message_new(msg_dict, dict(custom_values or {}, **vals))
            // self._send_expense_success_mail(msg_dict, expense)
            // return expense
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> NeedsProductPriceComputationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _needs_product_price_computation(self):
            // # Hook to be overridden.
            // self.ensure_one()
            // return self.product_has_cost
            */
            return default;
        }

        protected async Task<HrExpense> OnchangeProductHasCostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _onchange_product_has_cost(self):
            // """ Reset quantity to 1, in case of 0-cost product. To make sure switching non-0-cost to 0-cost doesn't keep the quantity."""
            // if not self.product_has_cost and self.state in {'draft', 'reported'}:
            //     self.quantity = 1
            */
            return default;
        }

        protected async Task<HrExpense> OnchangeSaleOrderIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py) ---
            // def _onchange_sale_order_id(self):
            // to_reset = self.filtered(lambda line: not self.env.is_protected(self._fields['analytic_distribution'], line))
            // to_reset.invalidate_recordset(['analytic_distribution'])
            // self.env.add_to_compute(self._fields['analytic_distribution'], to_reset)
            */
            return default;
        }

        protected async Task<HrExpense> ParseExpenseSubjectInternalAsync(object expense_description, object currencies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_expense_subject(self, expense_description, currencies):
            // """
            //     Fetch product, price and currency info from mail subject.
            // 
            //     Product can be identified based on product name or product code.
            //     It can be passed between [] or it can be placed at start.
            // 
            //     When parsing, only consider currencies passed as parameter.
            //     This will fetch currency in symbol($) or ISO name (USD).
            // 
            //     Some valid examples:
            //         Travel by Air [TICKET] USD 1205.91
            //         TICKET $1205.91 Travel by Air
            //         Extra expenses 29.10EUR [EXTRA]
            // """
            // product, expense_description = self._parse_product(expense_description)
            // price, currency_id, expense_description = self._parse_price(expense_description, currencies)
            // 
            // return product, price, currency_id, expense_description
            */
            return default;
        }

        protected async Task<HrExpense> ParsePriceInternalAsync(object expense_description, object currencies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_price(self, expense_description, currencies):
            // """ Return price, currency and updated description """
            // symbols, symbols_pattern, float_pattern = [], '', r'[+-]?(\d+[.,]?\d*)'
            // price = 0.0
            // for currency in currencies:
            //     symbols += [re.escape(currency.symbol), re.escape(currency.name)]
            // symbols_pattern = '|'.join(symbols)
            // price_pattern = f'(({symbols_pattern})?\\s?{float_pattern}\\s?({symbols_pattern})?)'
            // matches = re.findall(price_pattern, expense_description)
            // currency = currencies[:1]
            // if matches:
            //     match = max(matches, key=lambda match: len([group for group in match if group]))
            //     # get the longest match. e.g. "2 chairs 120$" -> the price is 120$, not 2
            //     full_str = match[0]
            //     currency_str = match[1] or match[3]
            //     price = match[2].replace(',', '.')
            // 
            //     if currency_str and currencies:
            //         currencies = currencies.filtered(lambda c: currency_str in [c.symbol, c.name])
            //         currency = currencies[:1] or currency
            //     expense_description = expense_description.replace(full_str, ' ')  # remove price from description
            //     expense_description = re.sub(' +', ' ', expense_description.strip())
            // 
            // return float(price), currency, expense_description
            */
            return default;
        }

        protected async Task<HrExpense> ParseProductInternalAsync(object expense_description)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_product(self, expense_description):
            // """
            //     Parse the subject to find the product.
            //     Product code should be the first word of expense_description
            //     Return product.product and updated description
            // """
            // product_code = expense_description.split(' ')[0]
            // product = self.env['product.product'].search([('can_be_expensed', '=', True), ('default_code', '=ilike', product_code)], limit=1)
            // if product:
            //     expense_description = expense_description.replace(product_code, '', 1)
            // 
            // return product, expense_description
            */
            return default;
        }

        protected async Task<HrExpense> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_base_line_for_taxes_computation(self, **kwargs):
            // self.ensure_one()
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     **{
            //         'partner_id': self.vendor_id,
            //         'special_mode': 'total_included',
            //         'rate': self.currency_rate,
            //         **kwargs,
            //     },
            // )
            */
            return default;
        }

        protected async Task<HrExpense> PrepareMoveLinesValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_move_lines_vals(self):
            // self.ensure_one()
            // account = self._get_base_account()
            // 
            // return {
            //     'name': self._get_move_line_name(),
            //     'account_id': account.id,
            //     'quantity': self.quantity or 1,
            //     'price_unit': self.price_unit,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'expense_id': self.id,
            //     'partner_id': False if self.payment_mode == 'company_account' else self.employee_id.sudo().work_contact_id.id,
            //     'tax_ids': [Command.set(self.tax_ids.ids)],
            // }
            */
            return default;
        }

        protected async Task<HrExpense> PreparePaymentsValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_payments_vals(self):
            // self.ensure_one()
            // 
            // journal = self.sheet_id.journal_id
            // payment_method_line = self.sheet_id.payment_method_line_id
            // if not payment_method_line:
            //     raise UserError(_("You need to add a manual payment method on the journal (%s)", journal.name))
            // 
            // AccountTax = self.env['account.tax']
            // rate = abs(self.total_amount_currency / self.total_amount) if self.total_amount else 0.0
            // base_line = self._prepare_base_line_for_taxes_computation(
            //     price_unit=self.total_amount_currency,
            //     quantity=1.0,
            //     account_id=self._get_base_account(),
            //     rate=rate,
            // )
            // base_lines = [base_line]
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id, include_caba_tags=self.payment_mode == 'company_account')
            // tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            // 
            // # Base line.
            // move_lines = []
            // for base_line, to_update in tax_results['base_lines_to_update']:
            //     base_move_line = {
            //         'name': self._get_move_line_name(),
            //         'account_id': base_line['account_id'].id,
            //         'product_id': base_line['product_id'].id,
            //         'analytic_distribution': base_line['analytic_distribution'],
            //         'expense_id': self.id,
            //         'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //         'tax_tag_ids': to_update['tax_tag_ids'],
            //         'amount_currency': to_update['amount_currency'],
            //         'balance': to_update['balance'],
            //         'currency_id': base_line['currency_id'].id,
            //         'partner_id': self.vendor_id.id,
            //         'quantity': self.quantity,
            //     }
            //     move_lines.append(base_move_line)
            // 
            // # Tax lines.
            // total_tax_line_balance = 0.0
            // for tax_line in tax_results['tax_lines_to_add']:
            //     total_tax_line_balance += tax_line['balance']
            //     move_lines.append(tax_line)
            // base_move_line['balance'] = self.total_amount - total_tax_line_balance
            // 
            // # Outstanding payment line.
            // move_lines.append({
            //     'name': self._get_move_line_name(),
            //     'account_id': self.sheet_id._get_expense_account_destination(),
            //     'balance': -self.total_amount,
            //     'amount_currency': self.currency_id.round(-self.total_amount_currency),
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.vendor_id.id,
            // })
            // payment_vals = {
            //     'date': self.date,
            //     'memo': self.name,
            //     'journal_id': journal.id,
            //     'amount': self.total_amount_currency,
            //     'payment_type': 'outbound',
            //     'partner_type': 'supplier',
            //     'partner_id': self.vendor_id.id,
            //     'currency_id': self.currency_id.id,
            //     'payment_method_line_id': payment_method_line.id,
            //     'company_id': self.company_id.id,
            // }
            // move_vals = {
            //     **self.sheet_id._prepare_move_vals(),
            //     'ref': self.name,
            //     'date': self.date,  # Overidden from self.sheet_id._prepare_move_vals() so we can use the expense date for the account move date
            //     'journal_id': journal.id,
            //     'partner_id': self.vendor_id.id,
            //     'currency_id': self.currency_id.id,
            //     'line_ids': [Command.create(line) for line in move_lines],
            //     'attachment_ids': [
            //         Command.create(attachment.copy_data({'res_model': 'account.move', 'res_id': False, 'raw': attachment.raw})[0])
            //         for attachment in self.message_main_attachment_id]
            // }
            // return move_vals, payment_vals
            */
            return default;
        }

        protected async Task<HrExpense> SendExpenseSuccessMailInternalAsync(object msg_dict, object expense)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _send_expense_success_mail(self, msg_dict, expense):
            // if expense.employee_id.user_id:
            //     mail_template_id = 'hr_expense.hr_expense_template_register'
            // else:
            //     mail_template_id = 'hr_expense.hr_expense_template_register_no_user'
            // rendered_body = self.env['ir.qweb']._render(mail_template_id, {'expense': expense})
            // body = self.env['mail.render.mixin']._replace_local_links(rendered_body)
            // if expense.employee_id.user_id.partner_id:
            //     expense.message_post(
            //         body=body,
            //         email_layout_xmlid='mail.mail_notification_light',
            //         partner_ids=expense.employee_id.user_id.partner_id.ids,
            //         subject=f'Re: {msg_dict.get("subject", "")}',
            //         subtype_xmlid='mail.mt_note',
            //     )
            // else:
            //     self.env['mail.mail'].sudo().create({
            //         'author_id': self.env.user.partner_id.id,
            //         'auto_delete': True,
            //         'body_html': body,
            //         'email_from': self.env.user.email_formatted,
            //         'email_to': msg_dict.get('email_from', False),
            //         'references': msg_dict.get('message_id'),
            //         'subject': f'Re: {msg_dict.get("subject", "")}',
            //     }).send()
            */
            return default;
        }

        protected async Task<HrExpense> SetExpenseCurrencyRateInternalAsync(object date_today)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _set_expense_currency_rate(self, date_today):
            // for expense in self:
            //     expense.currency_rate = expense.env['res.currency']._get_conversion_rate(
            //         from_currency=expense.currency_id,
            //         to_currency=expense.company_currency_id,
            //         company=expense.company_id,
            //         date=expense.date or date_today,
            //     )
            */
            return default;
        }

        public async Task<HrExpense> ShowSameReceiptExpenseIdsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_show_same_receipt_expense_ids(self):
            // self.ensure_one()
            // return self.same_receipt_expense_ids._get_records_action(
            //     name=_("Expenses with a similar receipt to %(other_expense_name)s", other_expense_name=self.name),
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> SplitWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_split_wizard(self):
            // self.ensure_one()
            // splits = self.env['hr.expense.split'].create(self._get_split_values())
            // 
            // wizard = self.env['hr.expense.split.wizard'].create({
            //     'expense_split_line_ids': splits.ids,
            //     'expense_id': self.id,
            // })
            // return {
            //     'name': _('Expense split'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [[False, "form"]],
            //     'res_model': 'hr.expense.split.wizard',
            //     'res_id': wizard.id,
            //     'target': 'new',
            //     'context': self.env.context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpense> SubmitExpensesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_submit_expenses(self):
            // sheets = self._create_sheets_from_expense()
            // return {
            //     'name': _('New Expense Reports'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.expense.sheet',
            //     'context': self.env.context,
            //     'views': [[False, "list"], [False, "form"]] if len(sheets) > 1 else [[False, "form"]],
            //     'domain': [('id', 'in', sheets.ids)],
            //     'res_id': sheets.id if len(sheets) == 1 else False,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpense> UnlinkExceptPostedOrApprovedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _unlink_except_posted_or_approved(self):
            // for expense in self:
            //     if expense.state in {'done', 'approved'}:
            //         raise UserError(_('You cannot delete a posted or approved expense.'))
            */
            return default;
        }

        public async Task<HrExpense> ViewSheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_view_sheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [[False, "form"]],
            //     'res_model': 'hr.expense.sheet',
            //     'target': 'current',
            //     'res_id': self.sheet_id.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}