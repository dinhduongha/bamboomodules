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
    [Module("Analytic", Depends = new[] { "base", "mail", "uom" })]
    public class AccountAnalyticLineAppService : GenericApplicationService<AccountAnalyticLine>, IAccountAnalyticLineAppService
    {
        private readonly IAnalyticPlanFieldsMixinAppService _analyticPlanFieldsMixinAppService;
        public AccountAnalyticLineAppService(IRepository<AccountAnalyticLine, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticPlanFieldsMixinAppService analyticPlanFieldsMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticPlanFieldsMixinAppService = analyticPlanFieldsMixinAppService;
        }

        protected async Task<AccountAnalyticLine> CheckCanCreateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _check_can_create(self):
            // # override in other modules to check current user has create access
            // pass
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py) ---
            // def _check_can_create(self):
            // if not self.env.su and any(task.is_timeoff_task for task in self.task_id):
            //     raise UserError(_('You cannot create timesheets for a task that is linked to a time off type. Please use the Time Off application to request new time off instead.'))
            // return  super()._check_can_create()
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckCanWriteInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _check_can_write(self, values):
            // # If it's a basic user then check if the timesheet is his own.
            // if (
            //     not (self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver') or self.env.su)
            //     and any(analytic_line.user_id != self.env.user for analytic_line in self)
            // ):
            //     raise AccessError(_("You cannot access timesheets that are not yours."))
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py) ---
            // def _check_can_write(self, values):
            // if not self.env.su and self.holiday_id:
            //     raise UserError(_('You cannot modify timesheets that are linked to time off requests. Please use the Time Off application to modify your time off requests instead.'))
            // return super()._check_can_write(values)
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _check_can_write(self, values):
            // # prevent to update invoiced timesheets if one line is of type delivery
            // if self.sudo().filtered(lambda aal: aal.so_line.product_id.invoice_policy == "delivery") and self.filtered(lambda t: t.timesheet_invoice_id and t.timesheet_invoice_id.state != 'cancel'):
            //     if any(field_name in values for field_name in ['unit_amount', 'employee_id', 'project_id', 'task_id', 'so_line', 'date']):
            //         raise UserError(_('You cannot modify timesheets that are already invoiced.'))
            // return super()._check_can_write(values)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckGeneralAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def _check_general_account_id(self):
            // for line in self:
            //     if line.move_line_id and line.general_account_id != line.move_line_id.account_id:
            //         raise ValidationError(_('The journal item is not linked to the correct financial account'))
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckTimesheetCanBeBilledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _check_timesheet_can_be_billed(self):
            // return self.so_line in self.project_id.mapped('sale_line_employee_ids.sale_line_id') | self.task_id.sale_line_id | self.project_id.sale_line_id
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeCommercialPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_commercial_partner(self):
            // for timesheet in self:
            //     timesheet.commercial_partner_id = timesheet.task_id.partner_id.commercial_partner_id or timesheet.project_id.partner_id.commercial_partner_id
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_department_id(self):
            // for line in self:
            //     line.department_id = line.employee_id.department_id
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_display_name(self):
            // analytic_line_with_project = self.filtered('project_id')
            // super(AccountAnalyticLine, self - analytic_line_with_project)._compute_display_name()
            // for analytic_line in analytic_line_with_project:
            //     if analytic_line.task_id:
            //         analytic_line.display_name = f"{analytic_line.project_id.display_name} - {analytic_line.task_id.display_name}"
            //     else:
            //         analytic_line.display_name = analytic_line.project_id.display_name
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeEncodingUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_encoding_uom_id(self):
            // for analytic_line in self:
            //     analytic_line.encoding_uom_id = analytic_line.company_id.timesheet_encode_uom_id
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeGeneralAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def _compute_general_account_id(self):
            // for line in self:
            //     line.general_account_id = line.move_line_id.account_id
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeMessagePartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_message_partner_ids(self):
            // for line in self:
            //     line.message_partner_ids = line.task_id.message_partner_ids | line.project_id.message_partner_ids
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def _compute_partner_id(self):
            // for line in self:
            //     line.partner_id = line.move_line_id.partner_id or line.partner_id
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_partner_id(self):
            // super()._compute_partner_id()
            // for timesheet in self:
            //     if timesheet.project_id:
            //         timesheet.partner_id = timesheet.task_id.partner_id or timesheet.project_id.partner_id
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_partner_id(self):
            // super(AccountAnalyticLine, self.filtered(lambda t: t._is_not_billed()))._compute_partner_id()
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_project_id(self):
            // for line in self:
            //     if not line.task_id.project_id or line.project_id == line.task_id.project_id:
            //         continue
            //     line.project_id = line.task_id.project_id
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_project_id(self):
            // super(AccountAnalyticLine, self.filtered(lambda t: t._is_not_billed()))._compute_project_id()
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeReadonlyTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_readonly_timesheet(self):
            // # Since the mrp_module gives write access to portal user on timesheet, we check that the user is an internal one before giving the write access.
            // # It is not supposed to be needed, since portal user are not supposed to have access to the views using this field, but better be safe than sorry
            // if not self.env.user.has_group('base.group_user'):
            //     self.readonly_timesheet = True
            // else:
            //     readonly_timesheets = self.filtered(lambda timesheet: timesheet._is_readonly())
            //     readonly_timesheets.readonly_timesheet = True
            //     (self - readonly_timesheets).readonly_timesheet = False
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeSoLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_so_line(self):
            // for timesheet in self.filtered(lambda t: not t.is_so_line_edited and t._is_not_billed()):  # Get only the timesheets are not yet invoiced
            //     timesheet.so_line = timesheet.project_id.allow_billable and timesheet._timesheet_determine_sale_line()
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeTaskIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_task_id(self):
            // self.filtered(lambda t: not t.project_id).task_id = False
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeTimesheetInvoiceTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_timesheet_invoice_type(self):
            // for timesheet in self:
            //     if timesheet.project_id:  # AAL will be set to False
            //         invoice_type = False
            //         if not timesheet.so_line:
            //             invoice_type = 'non_billable' if timesheet.project_id.billing_type != 'manually' else 'billable_manual'
            //         elif timesheet.so_line.product_id.type == 'service':
            //             if timesheet.so_line.product_id.invoice_policy == 'delivery':
            //                 if timesheet.so_line.product_id.service_type == 'timesheet':
            //                     invoice_type = 'timesheet_revenues' if timesheet.amount > 0 and timesheet.unit_amount > 0 else 'billable_time'
            //                 else:
            //                     service_type = timesheet.so_line.product_id.service_type
            //                     invoice_type = f'billable_{service_type}' if service_type in ['milestones', 'manual'] else 'billable_fixed'
            //             elif timesheet.so_line.product_id.invoice_policy == 'order':
            //                 invoice_type = 'billable_fixed'
            //         timesheet.timesheet_invoice_type = invoice_type
            //     else:
            //         if timesheet.amount >= 0 and timesheet.unit_amount >= 0:
            //             if timesheet.so_line and timesheet.so_line.product_id.type == 'service':
            //                 timesheet.timesheet_invoice_type = 'service_revenues'
            //             else:
            //                 timesheet.timesheet_invoice_type = 'other_revenues'
            //         else:
            //             timesheet.timesheet_invoice_type = 'other_costs'
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _compute_user_id(self):
            // for line in self:
            //     line.user_id = line.employee_id.user_id if line.employee_id else self._default_user()
            */
            return default;
        }

        protected async Task<object> ConditionToSqlInternalAsync(string @alias, string fname, string @operator, object @value, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_line.py) ---
            // def _condition_to_sql(self, alias: str, fname: str, operator: str, value, query: Query) -> SQL:
            // if fname == 'date' and value == 'fiscal_start_year':
            //     fiscalyear_date_range = self.env.company.compute_fiscalyear_dates(fields.Date.today())
            //     value = fiscalyear_date_range['date_from'] - relativedelta(years=1)
            // return super()._condition_to_sql(alias, fname, operator, value, query)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ConvertHoursToDaysInternalAsync(object time)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _convert_hours_to_days(self, time):
            // uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_day = self.env.ref('uom.product_uom_day')
            // return round(uom_hour._compute_quantity(time, uom_day, raise_if_failure=False), 2)
            */
            return default;
        }

        public override async Task<AccountAnalyticLine> CreateAsync(AccountAnalyticLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def create(self, vals):
            // analytic_lines = super().create(vals)
            // analytic_lines.move_line_id._update_analytic_distribution()
            // return analytic_lines
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def create(self, vals_list):
            // # Before creating a timesheet, we need to put a valid employee_id in the vals
            // default_user_id = self._default_user()
            // user_ids = []
            // employee_ids = []
            // # 1/ Collect the user_ids and employee_ids from each timesheet vals
            // for vals in vals_list:
            //     task = self.env['project.task'].sudo().browse(vals.get('task_id'))
            //     project = self.env['project.project'].sudo().browse(vals.get('project_id'))
            //     if not (task or project):
            //         # It is not a timesheet
            //         continue
            //     elif task:
            //         if not task.project_id:
            //             raise ValidationError(_('Timesheets cannot be created on a private task.'))
            //         if not project:
            //             vals['project_id'] = task.project_id.id
            // 
            //     company = task.company_id or project.company_id or self.env['res.company'].browse(vals.get('company_id'))
            //     vals['company_id'] = company.id
            //     vals.update({
            //         fname: account_id
            //         for fname, account_id in self._timesheet_preprocess_get_accounts(vals).items()
            //         if fname not in vals
            //     })
            // 
            //     if not vals.get('product_uom_id'):
            //         vals['product_uom_id'] = company.project_time_mode_id.id
            // 
            //     if not vals.get('name'):
            //         vals['name'] = '/'
            //     employee_id = vals.get('employee_id', self._context.get('default_employee_id', False))
            //     if employee_id and employee_id not in employee_ids:
            //         employee_ids.append(employee_id)
            //     else:
            //         user_id = vals.get('user_id', default_user_id)
            //         if user_id not in user_ids:
            //             user_ids.append(user_id)
            // 
            // # 2/ Search all employees related to user_ids and employee_ids, in the selected companies
            // HrEmployee_sudo = self.env['hr.employee'].sudo()
            // employees = HrEmployee_sudo.search([
            //     '&', '|', ('user_id', 'in', user_ids), ('id', 'in', employee_ids), ('company_id', 'in', self.env.companies.ids)
            // ])
            // 
            // #                 ┌───── in search results = active/in companies ────────> was found with... ─── employee_id ───> (A) There is nothing to do, we will use this employee_id
            // # 3/ Each employee                                                                          └──── user_id ──────> (B)** We'll need to select the right employee for this user
            // #                 └─ not in search results = archived/not in companies ──> (C) We raise an error as we can't create a timesheet for an archived employee
            // # ** We can rely on the user to get the employee_id if
            // #    he has an active employee in the company of the timesheet
            // #    or he has only one active employee for all selected companies
            // valid_employee_per_id = {}
            // employee_id_per_company_per_user = defaultdict(dict)
            // for employee in employees:
            //     if employee.id in employee_ids:
            //         valid_employee_per_id[employee.id] = employee
            //     else:
            //         employee_id_per_company_per_user[employee.user_id.id][employee.company_id.id] = employee.id
            // 
            // # 4/ Put valid employee_id in each vals
            // error_msg = _('Timesheets must be created with an active employee in the selected companies.')
            // for vals in vals_list:
            //     if not vals.get('project_id'):
            //         continue
            //     employee_in_id = vals.get('employee_id', self._context.get('default_employee_id', False))
            //     if employee_in_id:
            //         company = False
            //         if not vals.get('company_id'):
            //             company = HrEmployee_sudo.browse(employee_in_id).company_id
            //             vals['company_id'] = company.id
            //         if not vals.get('product_uom_id'):
            //             vals['product_uom_id'] = company.project_time_mode_id.id if company else self.env['res.company'].browse(vals.get('company_id', self.env.company.id)).project_time_mode_id.id
            //         if employee_in_id in valid_employee_per_id:
            //             vals['user_id'] = valid_employee_per_id[employee_in_id].sudo().user_id.id   # (A) OK
            //             continue
            //         else:
            //             raise ValidationError(error_msg)                                            # (C) KO
            //     else:
            //         user_id = vals.get('user_id', default_user_id)                                  # (B)...
            // 
            //     # ...Look for an employee, with ** conditions
            //     employee_per_company = employee_id_per_company_per_user.get(user_id)
            //     employee_out_id = False
            //     if employee_per_company:
            //         company_id = list(employee_per_company)[0] if len(employee_per_company) == 1\
            //                 else vals.get('company_id', self.env.company.id)
            //         employee_out_id = employee_per_company.get(company_id, False)
            // 
            //     if employee_out_id:
            //         vals['employee_id'] = employee_out_id
            //         vals['user_id'] = user_id
            //         company = False
            //         if not vals.get('company_id'):
            //             company = HrEmployee_sudo.browse(employee_out_id).company_id
            //             vals['company_id'] = company.id
            //         if not vals.get('product_uom_id'):
            //             vals['product_uom_id'] = company.project_time_mode_id.id if company else self.env['res.company'].browse(vals.get('company_id', self.env.company.id)).project_time_mode_id.id
            //     else:  # ...and raise an error if they fail
            //         raise ValidationError(error_msg)
            // 
            // # 5/ Finally, create the timesheets
            // lines = super(AccountAnalyticLine, self).create(vals_list)
            // lines._check_can_create()
            // for line, values in zip(lines, vals_list):
            //     if line.project_id:  # applied only for timesheet
            //         line._timesheet_postprocess(values)
            // return lines
            */
            return await base.CreateAsync(entity, fields);
        }

        public override async Task<AccountAnalyticLine> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def default_get(self, field_list):
            // result = super(AccountAnalyticLine, self).default_get(field_list)
            // if not self.env.context.get('default_employee_id') and 'employee_id' in field_list and result.get('user_id'):
            //     result['employee_id'] = self.env['hr.employee'].search([('user_id', '=', result['user_id']), ('company_id', '=', result.get('company_id', self.env.company.id))], limit=1).id
            // if not self._context.get('default_project_id') and self._context.get('is_timesheet'):
            //     employee_id = result.get('employee_id', self.env.context.get('default_employee_id', False))
            //     favorite_project_id = self._get_favorite_project_id(employee_id)
            //     if favorite_project_id:
            //         result['project_id'] = favorite_project_id
            // return result
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<AccountAnalyticLine> DefaultUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _default_user(self):
            // return self.env.context.get('user_id', self.env.user.id)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _domain_employee_id(self):
            // domain = [('company_id', 'in', self._context.get('allowed_company_ids'))]
            // if not self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver'):
            //     domain = expression.AND([domain, [('user_id', '=', self.env.user.id)]])
            // return domain
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _domain_project_id(self):
            // domain = [('allow_timesheets', '=', True)]
            // if not self.env.user.has_group('hr_timesheet.group_timesheet_manager'):
            //     return expression.AND([domain,
            //         ['|', ('privacy_visibility', '!=', 'followers'), ('message_partner_ids', 'in', [self.env.user.partner_id.id])]
            //     ])
            // return domain
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainSoLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _domain_so_line(self):
            // domain = expression.AND([
            //     self.env['sale.order.line']._sellable_lines_domain(),
            //     self.env['sale.order.line']._domain_sale_line_service(),
            //     [
            //         ('order_partner_id.commercial_partner_id', '=', unquote('commercial_partner_id')),
            //     ],
            // ])
            // return str(domain)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> EnsureUomHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _ensure_uom_hours(self):
            // uom_hours = self.env.ref('uom.product_uom_hour', raise_if_not_found=False)
            // if not uom_hours:
            //     uom_hours = self.env['uom.uom'].create({
            //         'name': "Hours",
            //         'category_id': self.env.ref('uom.uom_categ_wtime').id,
            //         'factor': 8,
            //         'uom_type': "smaller",
            //     })
            //     self.env['ir.model.data'].create({
            //         'name': 'product_uom_hour',
            //         'model': 'uom.uom',
            //         'module': 'uom',
            //         'res_id': uom_hours.id,
            //         'noupdate': True,
            //     })
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetEmployeeMappingEntryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _get_employee_mapping_entry(self):
            // self.ensure_one()
            // return self.env['project.sale.line.employee.map'].search([('project_id', '=', self.project_id.id), ('employee_id', '=', self.employee_id.id or self.env.user.employee_id.id)])
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetFavoriteProjectIdDomainInternalAsync(Guid employee_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _get_favorite_project_id_domain(self, employee_id=False):
            // employee_id = employee_id or self.env.user.employee_id.id
            // return [
            //     ('employee_id', '=', employee_id),
            //     ('project_id', '!=', False),
            //     ('project_id.active', '=', True),
            //     ('project_id.allow_timesheets', '=', True)
            // ]
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py) ---
            // def _get_favorite_project_id_domain(self, employee_id=False):
            // return expression.AND([
            //     super()._get_favorite_project_id_domain(employee_id),
            //     [('holiday_id', '=', False), ('global_leave_id', '=', False)],
            // ])
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetFavoriteProjectIdInternalAsync(Guid employee_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _get_favorite_project_id(self, employee_id=False):
            // last_timesheets = self.search_fetch(
            //     self._get_favorite_project_id_domain(employee_id), ['project_id'], limit=5
            // )
            // if not last_timesheets:
            //     internal_project = self.env.company.internal_project_id
            //     return internal_project.active and internal_project.allow_timesheets and internal_project.id
            // return mode([t.project_id.id for t in last_timesheets])
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetRedirectActionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py) ---
            // def _get_redirect_action(self):
            // leave_form_view_id = self.env.ref('hr_holidays.hr_leave_view_form').id
            // action_data = {
            //    'name': _('Time Off'),
            //    'type': 'ir.actions.act_window',
            //    'res_model': 'hr.leave',
            //    'views': [(self.env.ref('hr_holidays.hr_leave_view_tree_my').id, 'list'), (leave_form_view_id, 'form')],
            //    'domain': [('id', 'in', self.holiday_id.ids)],
            // }
            // if len(self.holiday_id) == 1:
            //     action_data['views'] = [(leave_form_view_id, 'form')]
            //     action_data['res_id'] = self.holiday_id.id
            // return action_data
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _get_report_base_filename(self):
            // task_ids = self.task_id
            // if len(task_ids) == 1:
            //     return _('Timesheets - %s', task_ids.name)
            // return _('Timesheets')
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetTimesheetTimeDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _get_timesheet_time_day(self):
            // return self._convert_hours_to_days(self.unit_amount)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetTimesheetsToMergeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _get_timesheets_to_merge(self):
            // res = super()._get_timesheets_to_merge()
            // return res.filtered(lambda l: not l.timesheet_invoice_id or l.timesheet_invoice_id.state != 'posted')
            */
            return default;
        }

        public async Task<AccountAnalyticLine> GetViewsAsync(Guid id, AccountAnalyticLineGetViewsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def get_views(self, views, options=None):
            // res = super().get_views(views, options)
            // if options and options.get('toolbar'):
            //     wip_report_id = None
            // 
            //     def get_wip_report_id():
            //         return self.env['ir.model.data']._xmlid_to_res_id("mrp_account.wip_report", raise_if_not_found=False)
            // 
            //     for view_data in res['views'].values():
            //         print_data_list = view_data.get('toolbar', {}).get('print')
            //         if print_data_list:
            //             if wip_report_id is None and re.search(r'widget="timesheet_uom(\w)*"', view_data['arch']):
            //                 wip_report_id = get_wip_report_id()
            //             if wip_report_id:
            //                 view_data['toolbar']['print'] = [print_data for print_data in print_data_list if print_data['id'] != wip_report_id]
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAnalyticLine> HourlyCostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _hourly_cost(self):
            // self.ensure_one()
            // return self.employee_id.hourly_cost or 0.0
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _hourly_cost(self):
            // if self.project_id.pricing_type == 'employee_rate':
            //     mapping_entry = self._get_employee_mapping_entry()
            //     if mapping_entry:
            //         return mapping_entry.cost
            // return super()._hourly_cost()
            */
            return default;
        }

        public async Task<AccountAnalyticLine> InvoiceFromTimesheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def action_invoice_from_timesheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Invoice'),
            //     'res_model': 'account.move',
            //     'views': [[False, 'form']],
            //     'context': {'create': False},
            //     'res_id': self.timesheet_invoice_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAnalyticLine> IsNotBilledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _is_not_billed(self):
            // self.ensure_one()
            // return not self.timesheet_invoice_id or (self.timesheet_invoice_id.state == 'cancel' and self.timesheet_invoice_id.payment_state != 'invoicing_legacy')
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsReadonlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _is_readonly(self):
            // self.ensure_one()
            // # is overridden in other timesheet related modules
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _is_readonly(self):
            // return super()._is_readonly() or not self._is_not_billed()
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsTimesheetEncodeUomDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _is_timesheet_encode_uom_day(self):
            // company_uom = self.env.company.timesheet_encode_uom_id
            // return company_uom == self.env.ref('uom.product_uom_day')
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsUpdatableTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _is_updatable_timesheet(self):
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _is_updatable_timesheet(self):
            // return super()._is_updatable_timesheet and self._is_not_billed()
            */
            return default;
        }

        public async Task<AccountAnalyticLine> OnChangeUnitAmountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def on_change_unit_amount(self):
            // if not self.product_id:
            //     return {}
            // 
            // prod_accounts = self.product_id.product_tmpl_id.with_company(self.company_id)._get_product_accounts()
            // unit = self.product_uom_id
            // account = prod_accounts['expense']
            // if not unit or self.product_id.uom_po_id.category_id.id != unit.category_id.id:
            //     unit = self.product_id.uom_po_id
            // 
            // # Compute based on pricetype
            // amount_unit = self.product_id._price_compute('standard_price', uom=unit)[self.product_id.id]
            // amount = amount_unit * self.unit_amount or 0.0
            // result = (self.currency_id.round(amount) if self.currency_id else round(amount, 2)) * -1
            // self.amount = result
            // self.general_account_id = account
            // self.product_uom_id = unit
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAnalyticLine> OnchangeProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _onchange_project_id(self):
            // # TODO KBA in master - check to do it "properly", currently:
            // # This onchange is used to reset the task_id when the project changes.
            // # Doing it in the compute will remove the task_id when the project of a task changes.
            // if self.project_id != self.task_id.project_id:
            //     self.task_id = False
            */
            return default;
        }

        public async Task<AccountAnalyticLine> OpenTimesheetViewPortalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def action_open_timesheet_view_portal(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_id': self.id,
            //     'res_model': 'account.analytic.line',
            //     'views': [(self.env.ref('hr_timesheet.timesheet_view_form_portal_user').id, 'form')],
            //     'context': self._context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAnalyticLine> SaleOrderFromTimesheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def action_sale_order_from_timesheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Sales Order'),
            //     'res_model': 'sale.order',
            //     'views': [[False, 'form']],
            //     'context': {'create': False, 'show_sale': True},
            //     'res_id': self.order_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAnalyticLine> SearchMessagePartnerIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _search_message_partner_ids(self, operator, value):
            // followed_ids_by_model = dict(self.env['mail.followers']._read_group([
            //     ('partner_id', operator, value),
            //     ('res_model', 'in', ('project.project', 'project.task')),
            // ], ['res_model'], ['res_id:array_agg']))
            // if not followed_ids_by_model:
            //     return expression.FALSE_DOMAIN
            // domains = []
            // if project_ids := followed_ids_by_model.get('project.project'):
            //     domains.append([('project_id', 'in', project_ids)])
            // if task_ids := followed_ids_by_model.get('project.task'):
            //     domains.append([('task_id', 'in', task_ids)])
            // domain = expression.OR(domains)
            // return domain
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetConvertSolUomInternalAsync(object sol, object to_unit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_convert_sol_uom(self, sol, to_unit):
            // to_uom = self.env.ref(to_unit)
            // return round(sol.product_uom._compute_quantity(sol.product_uom_qty, to_uom, raise_if_failure=False), 2)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetDetermineSaleLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_determine_sale_line(self):
            // """ Deduce the SO line associated to the timesheet line:
            //     1/ timesheet on task rate: the so line will be the one from the task
            //     2/ timesheet on employee rate task: find the SO line in the map of the project (even for subtask), or fallback on the SO line of the task, or fallback
            //         on the one on the project
            // """
            // self.ensure_one()
            // 
            // if not self.task_id:
            //     if self.project_id.pricing_type == 'employee_rate':
            //         map_entry = self._get_employee_mapping_entry()
            //         if map_entry:
            //             return map_entry.sale_line_id
            //     if self.project_id.sale_line_id:
            //         return self.project_id.sale_line_id
            // if self.task_id.allow_billable and self.task_id.sale_line_id:
            //     if self.task_id.pricing_type in ('task_rate', 'fixed_rate'):
            //         return self.task_id.sale_line_id
            //     else:  # then pricing_type = 'employee_rate'
            //         map_entry = self.project_id.sale_line_employee_ids.filtered(
            //             lambda map_entry:
            //                 map_entry.employee_id == (self.employee_id or self.env.user.employee_id)
            //                 and map_entry.sale_line_id.order_partner_id.commercial_partner_id == self.task_id.partner_id.commercial_partner_id
            //         )
            //         if map_entry:
            //             return map_entry.sale_line_id
            //         return self.task_id.sale_line_id
            // return False
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetGetPortalDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_get_portal_domain(self):
            // if self.env.user.has_group('hr_timesheet.group_hr_timesheet_user'):
            //     # Then, he is internal user, and we take the domain for this current user
            //     return self.env['ir.rule']._compute_domain(self._name)
            // return [
            //     ('message_partner_ids', 'child_of', [self.env.user.partner_id.commercial_partner_id.id]),
            //     ('project_id.privacy_visibility', '=', 'portal'),
            // ]
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_get_portal_domain(self):
            // """ Only the timesheets with a product invoiced on delivered quantity are concerned.
            //     since in ordered quantity, the timesheet quantity is not invoiced,
            //     thus there is no meaning of showing invoice with ordered quantity.
            // """
            // domain = super()._timesheet_get_portal_domain()
            // return expression.AND([domain, [('timesheet_invoice_type', 'in', ['billable_time', 'non_billable', 'billable_fixed', 'billable_manual', 'billable_milestones'])]])
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetGetSaleDomainInternalAsync(List<Guid> order_lines_ids, List<Guid> invoice_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_get_sale_domain(self, order_lines_ids, invoice_ids):
            // if not invoice_ids:
            //     return [('so_line', 'in', order_lines_ids.ids)]
            // 
            // return [
            //     '|',
            //     '&',
            //     ('timesheet_invoice_id', 'in', invoice_ids.ids),
            //     # TODO : Master: Check if non_billable should be removed ?
            //     ('timesheet_invoice_type', 'in', ['billable_time', 'non_billable']),
            //     '&',
            //     ('timesheet_invoice_type', '=', 'billable_fixed'),
            //         '&',
            //         ('so_line', 'in', order_lines_ids.ids),
            //         ('timesheet_invoice_id', '=', False),
            // ]
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPostprocessInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_postprocess(self, values):
            // """ Hook to update record one by one according to the values of a `write` or a `create`. """
            // sudo_self = self.sudo()  # this creates only one env for all operation that required sudo() in `_timesheet_postprocess_values`override
            // values_to_write = self._timesheet_postprocess_values(values)
            // for timesheet in sudo_self:
            //     if values_to_write[timesheet.id]:
            //         timesheet.write(values_to_write[timesheet.id])
            // return values
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_postprocess(self, values):
            // if values.get('so_line'):
            //     for timesheet in self.sudo():
            //         # If no account_id was found in the SOL's distribution, we fallback on the project's account_id
            //         if not timesheet.account_id:
            //             timesheet.account_id = timesheet.project_id.account_id
            // return super()._timesheet_postprocess(values)
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPostprocessValuesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_postprocess_values(self, values):
            // """ Get the addionnal values to write on record
            //     :param dict values: values for the model's fields, as a dictionary::
            //         {'field_name': field_value, ...}
            //     :return: a dictionary mapping each record id to its corresponding
            //         dictionary values to write (may be empty).
            // """
            // result = {id_: {} for id_ in self.ids}
            // sudo_self = self.sudo()  # this creates only one env for all operation that required sudo()
            // # (re)compute the amount (depending on unit_amount, employee_id for the cost, and account_id for currency)
            // if any(field_name in values for field_name in ['unit_amount', 'employee_id', 'account_id']):
            //     for timesheet in sudo_self:
            //         if not timesheet.account_id.active:
            //             project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            //             raise ValidationError(_(
            //                 "Timesheets must be created with at least an active analytic account defined in the plan '%(plan_name)s'.",
            //                 plan_name=project_plan.name
            //             ))
            //         accounts = timesheet._get_analytic_accounts()
            //         companies = timesheet.company_id | accounts.company_id | timesheet.task_id.company_id | timesheet.project_id.company_id
            //         if len(companies) > 1:
            //             raise ValidationError(_('The project, the task and the analytic accounts of the timesheet must belong to the same company.'))
            // 
            //         cost = timesheet._hourly_cost()
            //         amount = -timesheet.unit_amount * cost
            //         amount_converted = timesheet.employee_id.currency_id._convert(
            //             amount, timesheet.account_id.currency_id or timesheet.currency_id, self.env.company, timesheet.date)
            //         result[timesheet.id].update({
            //             'amount': amount_converted,
            //         })
            // return result
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPreprocessGetAccountsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_preprocess_get_accounts(self, vals):
            // project = self.env['project.project'].sudo().browse(vals.get('project_id'))
            // if not project:
            //     return {}
            // company = self.env['res.company'].browse(vals.get('company_id'))
            // mandatory_plans = [plan for plan in self._get_mandatory_plans(company, business_domain='timesheet') if plan['column_name'] != 'account_id']
            // missing_plan_names = [plan['name'] for plan in mandatory_plans if not project[plan['column_name']]]
            // if missing_plan_names:
            //     raise ValidationError(_(
            //         "'%(missing_plan_names)s' analytic plan(s) required on the project '%(project_name)s' linked to the timesheet.",
            //         missing_plan_names=format_list(self.env, missing_plan_names),
            //         project_name=project.name,
            //     ))
            // return {
            //     fname: project[fname].id
            //     for fname in self._get_plan_fnames()
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _timesheet_preprocess_get_accounts(self, vals):
            // so_line = self.env['sale.order.line'].browse(vals.get('so_line'))
            // if not (so_line and (distribution := so_line.sudo().analytic_distribution)):
            //     return super()._timesheet_preprocess_get_accounts(vals)
            // 
            // company = self.env['res.company'].browse(vals.get('company_id'))
            // accounts = self.env['account.analytic.account'].browse([
            //     int(account_id) for account_id in next(iter(distribution)).split(',')
            // ]).exists()
            // 
            // if not accounts:
            //     return super()._timesheet_preprocess_get_accounts(vals)
            // 
            // plan_column_names = {account.root_plan_id._column_name() for account in accounts}
            // mandatory_plans = [plan for plan in self._get_mandatory_plans(company, business_domain='timesheet') if plan['column_name'] != 'account_id']
            // missing_plan_names = [plan['name'] for plan in mandatory_plans if plan['column_name'] not in plan_column_names]
            // if missing_plan_names:
            //     raise ValidationError(_(
            //         "'%(missing_plan_names)s' analytic plan(s) required on the analytic distribution of the sale order item '%(so_line_name)s' linked to the timesheet.",
            //         missing_plan_names=format_list(self.env, missing_plan_names),
            //         so_line_name=so_line.name,
            //     ))
            // 
            // account_id_per_fname = dict.fromkeys(self._get_plan_fnames(), False)
            // for account in accounts:
            //     account_id_per_fname[account.root_plan_id._column_name()] = account.id
            // return account_id_per_fname
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def unlink(self):
            // affected_move_lines = self.move_line_id
            // res = super().unlink()
            // affected_move_lines._update_analytic_distribution()
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<AccountAnalyticLine> UnlinkExceptInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py) ---
            // def _unlink_except_invoiced(self):
            // if any(line.timesheet_invoice_id and line.timesheet_invoice_id.state == 'posted' for line in self):
            //     raise UserError(_('You cannot remove a timesheet that has already been invoiced.'))
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> UnlinkExceptLinkedLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py) ---
            // def _unlink_except_linked_leave(self):
            // if any(line.global_leave_id for line in self):
            //     raise UserError(_('You cannot delete timesheets that are linked to global time off.'))
            // elif any(line.holiday_id for line in self):
            //     error_message = _('You cannot delete timesheets that are linked to time off requests. Please cancel your time off request from the Time Off application instead.')
            //     if not self.env.user.has_group('hr_holidays.group_hr_holidays_user') and self.env.user not in self.holiday_id.sudo().user_id:
            //         raise UserError(error_message)
            //     action = self._get_redirect_action()
            //     raise RedirectWarning(error_message, action, _('View Time Off'))
            */
            return default;
        }

        public async Task<AccountAnalyticLine> ViewHeaderGetAsync(Guid id, AccountAnalyticLineViewHeaderGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self.env.context.get('account_id'):
            //     return _(
            //         "Entries: %(account)s",
            //         account=self.env['account.analytic.account'].browse(self.env.context['account_id']).name
            //     )
            // return super().view_header_get(view_id, view_type)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountAnalyticLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py) ---
            // def write(self, vals):
            // affected_move_lines = self.move_line_id
            // res = super().write(vals)
            // if any(field in vals for field in ['amount', 'move_line_id'] + self._get_plan_fnames()):
            //     if 'move_line_id' in vals:
            //         affected_move_lines |= self.move_line_id
            //     affected_move_lines._update_analytic_distribution()
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py) ---
            // def write(self, values):
            // self._check_can_write(values)
            // 
            // task = self.env['project.task'].sudo().browse(values.get('task_id'))
            // project = self.env['project.project'].sudo().browse(values.get('project_id'))
            // if task and not task.project_id:
            //     raise ValidationError(_('Timesheets cannot be created on a private task.'))
            // if project or task:
            //     values['company_id'] = task.company_id.id or project.company_id.id
            // values.update({
            //     fname: account_id
            //     for fname, account_id in self._timesheet_preprocess_get_accounts(values).items()
            //     if fname not in values
            // })
            // 
            // if values.get('employee_id'):
            //     employee = self.env['hr.employee'].browse(values['employee_id'])
            //     if not employee.active:
            //         raise UserError(_('You cannot set an archived employee on existing timesheets.'))
            // if 'name' in values and not values.get('name'):
            //     values['name'] = '/'
            // if 'company_id' in values and not values.get('company_id'):
            //     del values['company_id']
            // result = super(AccountAnalyticLine, self).write(values)
            // # applied only for timesheet
            // self.filtered(lambda t: t.project_id)._timesheet_postprocess(values)
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}