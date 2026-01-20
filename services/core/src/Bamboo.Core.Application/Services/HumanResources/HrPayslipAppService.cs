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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmHrPayroll", Category = "HumanResources", Depends = new[] { "mail", "hr_contract", "hr_holidays" })]
    public partial class HrPayslipAppService : GenericApplicationService<HrPayslip>, IHrPayslipAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrPayslipAppService(IRepository<HrPayslip, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<HrPayslip> CheckDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def _check_dates(self):
            // if any(self.filtered(lambda payslip: payslip.date_from > payslip.date_to)):
            //     raise ValidationError(_("Payslip 'Date From' must be earlier 'Date To'."))
            */
            return default;
        }

        public async Task<HrPayslip> CheckDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def check_done(self):
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrPayslip> ComputeDetailsBySalaryRuleCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def _compute_details_by_salary_rule_category(self):
            // for payslip in self:
            //     payslip.details_by_salary_rule_category = payslip.mapped('line_ids').filtered(lambda line: line.category_id)
            */
            return default;
        }

        protected async Task<HrPayslip> ComputePayslipCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def _compute_payslip_count(self):
            // for payslip in self:
            //     payslip.payslip_count = len(payslip.line_ids)
            */
            return default;
        }

        public async Task<HrPayslip> ComputeSheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def compute_sheet(self):
            // for payslip in self:
            //     number = payslip.number or self.env['ir.sequence'].next_by_code('salary.slip')
            //     # delete old payslip lines
            //     payslip.line_ids.unlink()
            //     # set the list of contract for which the rules have to be applied
            //     # if we don't give the contract, then the rules to apply should be for all current contracts of the employee
            //     contract_ids = payslip.contract_id.ids or \
            //         self.get_contract(payslip.employee_id, payslip.date_from, payslip.date_to)
            //     if not contract_ids:
            //         raise ValidationError(_("No running contract found for the employee: %s or no contract in the given period" % payslip.employee_id.name))
            //     lines = [(0, 0, line) for line in self._get_payslip_lines(contract_ids, payslip.id)]
            //     payslip.write({'line_ids': lines, 'number': number})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<HrPayslip> CreateAsync(HrPayslip entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py) ---
            // def create(self, vals_list):
            // if 'journal_id' in self.env.context:
            //     for vals in vals_list:
            //         vals['journal_id'] = self.env.context.get('journal_id')
            // return super(HrPayslip, self).create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<HrPayslip> GetContractAsync(Guid id, HrPayslipGetContractRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def get_contract(self, employee, date_from, date_to):
            // """
            // @param employee: recordset of employee
            // @param date_from: date field
            // @param date_to: date field
            // @return: returns the ids of all the contracts for the given employee that need to be considered for the given dates
            // """
            // # a contract is valid if it ends between the given dates
            // clause_1 = ['&', ('date_end', '<=', date_to), ('date_end', '>=', date_from)]
            // # OR if it starts between the given dates
            // clause_2 = ['&', ('date_start', '<=', date_to), ('date_start', '>=', date_from)]
            // # OR if it starts before the date_from and finish after the date_end (or never finish)
            // clause_3 = ['&', ('date_start', '<=', date_from), '|', ('date_end', '=', False), ('date_end', '>=', date_to)]
            // clause_final = [('employee_id', '=', employee.id), ('state', '=', 'open'), '|', '|'] + clause_1 + clause_2 + clause_3
            // return self.env['hr.contract'].search(clause_final).ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> GetInputsAsync(Guid id, HrPayslipGetInputsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def get_inputs(self, contracts, date_from, date_to):
            // res = []
            // 
            // structure_ids = contracts.get_all_structures()
            // rule_ids = self.env['hr.payroll.structure'].browse(structure_ids).get_all_rules()
            // sorted_rule_ids = [id for id, sequence in sorted(rule_ids, key=lambda x:x[1])]
            // inputs = self.env['hr.salary.rule'].browse(sorted_rule_ids).mapped('input_ids')
            // 
            // for contract in contracts:
            //     for input in inputs:
            //         input_data = {
            //             'name': input.name,
            //             'code': input.code,
            //             'contract_id': contract.id,
            //         }
            //         res += [input_data]
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrPayslip> GetPayslipLinesInternalAsync(List<Guid> contract_ids, Guid payslip_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def _get_payslip_lines(self, contract_ids, payslip_id):
            // def _sum_salary_rule_category(localdict, category, amount):
            //     if category.parent_id:
            //         localdict = _sum_salary_rule_category(localdict, category.parent_id, amount)
            //     localdict['categories'].dict[category.code] = category.code in localdict['categories'].dict and localdict['categories'].dict[category.code] + amount or amount
            //     return localdict
            // 
            // class BrowsableObject(object):
            //     def __init__(self, employee_id, dict, env):
            //         self.employee_id = employee_id
            //         self.dict = dict
            //         self.env = env
            // 
            //     def __getattr__(self, attr):
            //         return attr in self.dict and self.dict.__getitem__(attr) or 0.0
            // 
            // class InputLine(BrowsableObject):
            //     """a class that will be used into the python code, mainly for usability purposes"""
            //     def sum(self, code, from_date, to_date=None):
            //         if to_date is None:
            //             to_date = fields.Date.today()
            //         self.env.cr.execute("""
            //             SELECT sum(amount) as sum
            //             FROM hr_payslip as hp, hr_payslip_input as pi
            //             WHERE hp.employee_id = %s AND hp.state = 'done'
            //             AND hp.date_from >= %s AND hp.date_to <= %s AND hp.id = pi.payslip_id AND pi.code = %s""",
            //             (self.employee_id, from_date, to_date, code))
            //         return self.env.cr.fetchone()[0] or 0.0
            // 
            // class WorkedDays(BrowsableObject):
            //     """a class that will be used into the python code, mainly for usability purposes"""
            //     def _sum(self, code, from_date, to_date=None):
            //         if to_date is None:
            //             to_date = fields.Date.today()
            //         self.env.cr.execute("""
            //             SELECT sum(number_of_days) as number_of_days, sum(number_of_hours) as number_of_hours
            //             FROM hr_payslip as hp, hr_payslip_worked_days as pi
            //             WHERE hp.employee_id = %s AND hp.state = 'done'
            //             AND hp.date_from >= %s AND hp.date_to <= %s AND hp.id = pi.payslip_id AND pi.code = %s""",
            //             (self.employee_id, from_date, to_date, code))
            //         return self.env.cr.fetchone()
            // 
            //     def sum(self, code, from_date, to_date=None):
            //         res = self._sum(code, from_date, to_date)
            //         return res and res[0] or 0.0
            // 
            //     def sum_hours(self, code, from_date, to_date=None):
            //         res = self._sum(code, from_date, to_date)
            //         return res and res[1] or 0.0
            // 
            // class Payslips(BrowsableObject):
            //     """a class that will be used into the python code, mainly for usability purposes"""
            // 
            //     def sum(self, code, from_date, to_date=None):
            //         if to_date is None:
            //             to_date = fields.Date.today()
            //         self.env.cr.execute("""SELECT sum(case when hp.credit_note = False then (pl.total) else (-pl.total) end)
            //                     FROM hr_payslip as hp, hr_payslip_line as pl
            //                     WHERE hp.employee_id = %s AND hp.state = 'done'
            //                     AND hp.date_from >= %s AND hp.date_to <= %s AND hp.id = pl.slip_id AND pl.code = %s""",
            //                     (self.employee_id, from_date, to_date, code))
            //         res = self.env.cr.fetchone()
            //         return res and res[0] or 0.0
            // 
            // #we keep a dict with the result because a value can be overwritten by another rule with the same code
            // result_dict = {}
            // rules_dict = {}
            // worked_days_dict = {}
            // inputs_dict = {}
            // blacklist = []
            // payslip = self.env['hr.payslip'].browse(payslip_id)
            // for worked_days_line in payslip.worked_days_line_ids:
            //     worked_days_dict[worked_days_line.code] = worked_days_line
            // for input_line in payslip.input_line_ids:
            //     inputs_dict[input_line.code] = input_line
            // 
            // categories = BrowsableObject(payslip.employee_id.id, {}, self.env)
            // inputs = InputLine(payslip.employee_id.id, inputs_dict, self.env)
            // worked_days = WorkedDays(payslip.employee_id.id, worked_days_dict, self.env)
            // payslips = Payslips(payslip.employee_id.id, payslip, self.env)
            // rules = BrowsableObject(payslip.employee_id.id, rules_dict, self.env)
            // 
            // baselocaldict = {'categories': categories, 'rules': rules, 'payslip': payslips, 'worked_days': worked_days, 'inputs': inputs}
            // #get the ids of the structures on the contracts and their parent id as well
            // contracts = self.env['hr.contract'].browse(contract_ids)
            // if len(contracts) == 1 and payslip.struct_id:
            //     structure_ids = list(set(payslip.struct_id._get_parent_structure().ids))
            // else:
            //     structure_ids = contracts.get_all_structures()
            // #get the rules of the structure and thier children
            // rule_ids = self.env['hr.payroll.structure'].browse(structure_ids).get_all_rules()
            // #run the rules by sequence
            // sorted_rule_ids = [id for id, sequence in sorted(rule_ids, key=lambda x:x[1])]
            // sorted_rules = self.env['hr.salary.rule'].browse(sorted_rule_ids)
            // 
            // for contract in contracts:
            //     employee = contract.employee_id
            //     localdict = dict(baselocaldict, employee=employee, contract=contract)
            //     for rule in sorted_rules:
            //         key = rule.code + '-' + str(contract.id)
            //         localdict['result'] = None
            //         localdict['result_qty'] = 1.0
            //         localdict['result_rate'] = 100
            //         #check if the rule can be applied
            //         if rule._satisfy_condition(localdict) and rule.id not in blacklist:
            //             #compute the amount of the rule
            //             amount, qty, rate = rule._compute_rule(localdict)
            //             #check if there is already a rule computed with that code
            //             previous_amount = rule.code in localdict and localdict[rule.code] or 0.0
            //             #set/overwrite the amount computed for this rule in the localdict
            //             tot_rule = contract.company_id.currency_id.round(amount * qty * rate / 100.0)
            //             localdict[rule.code] = tot_rule
            //             rules_dict[rule.code] = rule
            //             #sum the amount for its salary category
            //             localdict = _sum_salary_rule_category(localdict, rule.category_id, tot_rule - previous_amount)
            //             #create/overwrite the rule in the temporary results
            //             result_dict[key] = {
            //                 'salary_rule_id': rule.id,
            //                 'contract_id': contract.id,
            //                 'name': rule.name,
            //                 'code': rule.code,
            //                 'category_id': rule.category_id.id,
            //                 'sequence': rule.sequence,
            //                 'appears_on_payslip': rule.appears_on_payslip,
            //                 'condition_select': rule.condition_select,
            //                 'condition_python': rule.condition_python,
            //                 'condition_range': rule.condition_range,
            //                 'condition_range_min': rule.condition_range_min,
            //                 'condition_range_max': rule.condition_range_max,
            //                 'amount_select': rule.amount_select,
            //                 'amount_fix': rule.amount_fix,
            //                 'amount_python_compute': rule.amount_python_compute,
            //                 'amount_percentage': rule.amount_percentage,
            //                 'amount_percentage_base': rule.amount_percentage_base,
            //                 'register_id': rule.register_id.id,
            //                 'amount': amount,
            //                 'employee_id': contract.employee_id.id,
            //                 'quantity': qty,
            //                 'rate': rate,
            //             }
            //         else:
            //             #blacklist this rule and its children
            //             blacklist += [id for id, seq in rule._recursive_search_of_rules()]
            // 
            // return list(result_dict.values())
            */
            return default;
        }

        public async Task<HrPayslip> GetSalaryLineTotalAsync(Guid id, HrPayslipGetSalaryLineTotalRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def get_salary_line_total(self, code):
            // self.ensure_one()
            // line = self.line_ids.filtered(lambda line: line.code == code)
            // if line:
            //     return line[0].total
            // else:
            //     return 0.0
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> GetWorkedDayLinesAsync(Guid id, HrPayslipGetWorkedDayLinesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def get_worked_day_lines(self, contracts, date_from, date_to):
            // """
            // @param contract: Browse record of contracts
            // @return: returns a list of dict containing the input that should be applied for the given contract between date_from and date_to
            // """
            // res = []
            // # fill only if the contract as a working schedule linked
            // for contract in contracts.filtered(lambda contract: contract.resource_calendar_id):
            //     day_from = datetime.combine(fields.Date.from_string(date_from), time.min)
            //     day_to = datetime.combine(fields.Date.from_string(date_to), time.max)
            // 
            //     # compute leave days
            //     leaves = {}
            //     calendar = contract.resource_calendar_id
            //     tz = timezone(calendar.tz)
            //     day_leave_intervals = contract.employee_id.list_leaves(day_from, day_to, calendar=contract.resource_calendar_id)
            //     for day, hours, leave in day_leave_intervals:
            //         holiday = leave.holiday_id
            //         current_leave_struct = leaves.setdefault(holiday.holiday_status_id, {
            //             'name': holiday.holiday_status_id.name or _('Global Leaves'),
            //             'sequence': 5,
            //             'code': holiday.holiday_status_id.code or 'GLOBAL',
            //             'number_of_days': 0.0,
            //             'number_of_hours': 0.0,
            //             'contract_id': contract.id,
            //         })
            //         current_leave_struct['number_of_hours'] -= hours
            //         work_hours = calendar.get_work_hours_count(
            //             tz.localize(datetime.combine(day, time.min)),
            //             tz.localize(datetime.combine(day, time.max)),
            //             compute_leaves=False,
            //         )
            //         if work_hours:
            //             current_leave_struct['number_of_days'] -= hours / work_hours
            // 
            //     # compute worked days
            //     work_data = contract.employee_id._get_work_days_data(
            //         day_from,
            //         day_to,
            //         calendar=contract.resource_calendar_id,
            //         compute_leaves=False,
            //     )
            //     attendances = {
            //         'name': _("Normal Working Days paid at 100%"),
            //         'sequence': 1,
            //         'code': 'WORK100',
            //         'number_of_days': work_data['days'],
            //         'number_of_hours': work_data['hours'],
            //         'contract_id': contract.id,
            //     }
            // 
            //     res.append(attendances)
            //     res.extend(leaves.values())
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> OnchangeContractAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def onchange_contract(self):
            // if not self.contract_id:
            //     self.struct_id = False
            // self.with_context(contract=True).onchange_employee()
            // return
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py) ---
            // def onchange_contract(self):
            // super(HrPayslip, self).onchange_contract()
            // self.journal_id = self.contract_id.journal_id.id or (not self.contract_id and self.default_get(['journal_id'])['journal_id'])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> OnchangeEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def onchange_employee(self):
            // self.ensure_one()
            // if (not self.employee_id) or (not self.date_from) or (not self.date_to):
            //     return
            // employee = self.employee_id
            // date_from = self.date_from
            // date_to = self.date_to
            // contract_ids = []
            // 
            // ttyme = datetime.combine(fields.Date.from_string(date_from), time.min)
            // locale = self.env.context.get('lang') or 'en_US'
            // self.name = _('Salary Slip of %s for %s') % (employee.name, tools.ustr(babel.dates.format_date(date=ttyme, format='MMMM-y', locale=locale)))
            // self.company_id = employee.company_id
            // 
            // if not self.env.context.get('contract') or not self.contract_id:
            //     contract_ids = self.get_contract(employee, date_from, date_to)
            //     if not contract_ids:
            //         return
            //     self.contract_id = self.env['hr.contract'].browse(contract_ids[0])
            // 
            // if not self.contract_id.struct_id:
            //     return
            // self.struct_id = self.contract_id.struct_id
            // 
            // #computation of the salary input
            // contracts = self.env['hr.contract'].browse(contract_ids)
            // if contracts:
            //     worked_days_line_ids = self.get_worked_day_lines(contracts, date_from, date_to)
            //     worked_days_lines = self.worked_days_line_ids.browse([])
            //     for r in worked_days_line_ids:
            //         worked_days_lines += worked_days_lines.new(r)
            //     self.worked_days_line_ids = worked_days_lines
            // 
            //     input_line_ids = self.get_inputs(contracts, date_from, date_to)
            //     input_lines = self.input_line_ids.browse([])
            //     for r in input_line_ids:
            //         input_lines += input_lines.new(r)
            //     self.input_line_ids = input_lines
            //     return
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> OnchangeEmployeeIdAsync(Guid id, HrPayslipOnchangeEmployeeIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def onchange_employee_id(self, date_from, date_to, employee_id=False, contract_id=False):
            // #defaults
            // res = {
            //     'value': {
            //         'line_ids': [],
            //         #delete old input lines
            //         'input_line_ids': [(2, x,) for x in self.input_line_ids.ids],
            //         #delete old worked days lines
            //         'worked_days_line_ids': [(2, x,) for x in self.worked_days_line_ids.ids],
            //         #'details_by_salary_head':[], TODO put me back
            //         'name': '',
            //         'contract_id': False,
            //         'struct_id': False,
            //     }
            // }
            // if (not employee_id) or (not date_from) or (not date_to):
            //     return res
            // ttyme = datetime.combine(fields.Date.from_string(date_from), time.min)
            // employee = self.env['hr.employee'].browse(employee_id)
            // locale = self.env.context.get('lang') or 'en_US'
            // res['value'].update({
            //     'name': _('Salary Slip of %s for %s') % (employee.name, tools.ustr(babel.dates.format_date(date=ttyme, format='MMMM-y', locale=locale))),
            //     'company_id': employee.company_id.id,
            // })
            // 
            // if not self.env.context.get('contract'):
            //     #fill with the first contract of the employee
            //     contract_ids = self.get_contract(employee, date_from, date_to)
            // else:
            //     if contract_id:
            //         #set the list of contract for which the input have to be filled
            //         contract_ids = [contract_id]
            //     else:
            //         #if we don't give the contract, then the input to fill should be for all current contracts of the employee
            //         contract_ids = self.get_contract(employee, date_from, date_to)
            // 
            // if not contract_ids:
            //     return res
            // contract = self.env['hr.contract'].browse(contract_ids[0])
            // res['value'].update({
            //     'contract_id': contract.id
            // })
            // struct = contract.struct_id
            // if not struct:
            //     return res
            // res['value'].update({
            //     'struct_id': struct.id,
            // })
            // #computation of the salary input
            // contracts = self.env['hr.contract'].browse(contract_ids)
            // worked_days_line_ids = self.get_worked_day_lines(contracts, date_from, date_to)
            // input_line_ids = self.get_inputs(contracts, date_from, date_to)
            // res['value'].update({
            //     'worked_days_line_ids': worked_days_line_ids,
            //     'input_line_ids': input_line_ids,
            // })
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> PayslipCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def action_payslip_cancel(self):
            // # if self.filtered(lambda slip: slip.state == 'done'):
            // #     raise UserError(_("Cannot cancel a payslip that is done."))
            // return self.write({'state': 'cancel'})
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py) ---
            // def action_payslip_cancel(self):
            // moves = self.mapped('move_id')
            // moves.filtered(lambda x: x.state == 'posted').button_cancel()
            // moves.unlink()
            // return super(HrPayslip, self).action_payslip_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> PayslipDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def action_payslip_done(self):
            // self.compute_sheet()
            // return self.write({'state': 'done'})
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py) ---
            // def action_payslip_done(self):
            // res = super(HrPayslip, self).action_payslip_done()
            // 
            // for slip in self:
            //     line_ids = []
            //     debit_sum = 0.0
            //     credit_sum = 0.0
            //     date = slip.date or slip.date_to
            //     currency = slip.company_id.currency_id
            // 
            //     name = _('Payslip of %s') % (slip.employee_id.name)
            //     move_dict = {
            //         'narration': name,
            //         'ref': slip.number,
            //         'journal_id': slip.journal_id.id,
            //         'date': date,
            //     }
            //     if not any(line.salary_rule_id.account_debit and line.salary_rule_id.account_credit for line in slip.details_by_salary_rule_category):
            //         raise UserError(_('Missing Debit Or Credit Account in Salary Rule'))
            //     for line in slip.details_by_salary_rule_category:
            //         amount = currency.round(slip.credit_note and -line.total or line.total)
            //         if currency.is_zero(amount):
            //             continue
            // 
            //         debit_account_id = line.salary_rule_id.account_debit.id
            //         credit_account_id = line.salary_rule_id.account_credit.id
            //         # if not debit_account_id or not credit_account_id:
            //         #     raise UserError(_('Missing Debit Or Credit Account in salary rule: "%s" !') % (
            //         #         line.salary_rule_id))
            //         if debit_account_id:
            //             debit_line = (0, 0, {
            //                 'name': line.name,
            //                 'partner_id': line._get_partner_id(credit_account=False),
            //                 'account_id': debit_account_id,
            //                 'journal_id': slip.journal_id.id,
            //                 'date': date,
            //                 'debit': amount > 0.0 and amount or 0.0,
            //                 'credit': amount < 0.0 and -amount or 0.0,
            //                 'analytic_distribution': {line.salary_rule_id.analytic_account_id.id: 100} if line.salary_rule_id.analytic_account_id else {},
            //                 'tax_line_id': line.salary_rule_id.account_tax_id.id,
            //             })
            //             line_ids.append(debit_line)
            //             debit_sum += debit_line[2]['debit'] - debit_line[2]['credit']
            // 
            //         if credit_account_id:
            //             credit_line = (0, 0, {
            //                 'name': line.name,
            //                 'partner_id': line._get_partner_id(credit_account=True),
            //                 'account_id': credit_account_id,
            //                 'journal_id': slip.journal_id.id,
            //                 'date': date,
            //                 'debit': amount < 0.0 and -amount or 0.0,
            //                 'credit': amount > 0.0 and amount or 0.0,
            //                 'analytic_distribution': {line.salary_rule_id.analytic_account_id.id: 100} if line.salary_rule_id.analytic_account_id else {},
            //                 'tax_line_id': line.salary_rule_id.account_tax_id.id,
            //             })
            //             line_ids.append(credit_line)
            //             credit_sum += credit_line[2]['credit'] - credit_line[2]['debit']
            // 
            //     if currency.compare_amounts(credit_sum, debit_sum) == -1:
            //         acc_id = slip.journal_id.default_account_id.id
            //         if not acc_id:
            //             raise UserError(_('The Expense Journal "%s" has not properly configured the Credit Account!') % (slip.journal_id.name))
            //         adjust_credit = (0, 0, {
            //             'name': _('Adjustment Entry'),
            //             'partner_id': False,
            //             'account_id': acc_id,
            //             'journal_id': slip.journal_id.id,
            //             'date': date,
            //             'debit': 0.0,
            //             'credit': currency.round(debit_sum - credit_sum),
            //         })
            //         line_ids.append(adjust_credit)
            // 
            //     elif currency.compare_amounts(debit_sum, credit_sum) == -1:
            //         acc_id = slip.journal_id.default_account_id.id
            //         if not acc_id:
            //             raise UserError(_('The Expense Journal "%s" has not properly configured the Debit Account!') % (slip.journal_id.name))
            //         adjust_debit = (0, 0, {
            //             'name': _('Adjustment Entry'),
            //             'partner_id': False,
            //             'account_id': acc_id,
            //             'journal_id': slip.journal_id.id,
            //             'date': date,
            //             'debit': currency.round(credit_sum - debit_sum),
            //             'credit': 0.0,
            //         })
            //         line_ids.append(adjust_debit)
            //     move_dict['line_ids'] = line_ids
            //     move = self.env['account.move'].create(move_dict)
            //     slip.write({'move_id': move.id, 'date': date})
            //     move.action_post()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> PayslipDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def action_payslip_draft(self):
            // return self.write({'state': 'draft'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> RefundSheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def refund_sheet(self):
            // for payslip in self:
            //     copied_payslip = payslip.copy({'credit_note': True, 'name': _('Refund: ') + payslip.name})
            //     copied_payslip.compute_sheet()
            //     copied_payslip.action_payslip_done()
            // form_view_ref = self.env.ref('om_om_hr_payroll.view_hr_payslip_form', False)
            // list_view_ref = self.env.ref('om_om_hr_payroll.view_hr_payslip_tree', False)
            // return {
            //     'name': (_("Refund Payslip")),
            //     'view_mode': 'list, form',
            //     'view_id': False,
            //     'view_type': 'form',
            //     'res_model': 'hr.payslip',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'domain': "[('id', 'in', %s)]" % copied_payslip.ids,
            //     'views': [(list_view_ref and list_view_ref.id or False, 'list'), (form_view_ref and form_view_ref.id or False, 'form')],
            //     'context': {}
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrPayslip> SendEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py) ---
            // def action_send_email(self):
            // self.ensure_one()
            // ir_model_data = self.env['ir.model.data']
            // try:
            //     template_id = self.env.ref('om_hr_payroll.mail_template_payslip').id
            // except ValueError:
            //     template_id = False
            // try:
            //     compose_form_id = ir_model_data._xmlid_lookup('mail.email_compose_message_wizard_form')[1]
            // 
            // except ValueError:
            //     compose_form_id = False
            // ctx = {
            //     'default_model': 'hr.payslip',
            //     'default_res_ids': self.ids,
            //     'default_use_template': bool(template_id),
            //     'default_template_id': template_id,
            //     'default_composition_mode': 'comment',
            // }
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form_id, 'form')],
            //     'view_id': compose_form_id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}