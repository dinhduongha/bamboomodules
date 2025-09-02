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
    [Module("Hr", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public class HrEmployeeAppService : GenericApplicationService<HrEmployee>, IHrEmployeeAppService
    {
        private readonly IAvatarMixinAppService _avatarMixinAppService;
        private readonly IHrEmployeeBaseAppService _hrEmployeeBaseAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IResourceMixinAppService _resourceMixinAppService;
        public HrEmployeeAppService(IRepository<HrEmployee, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAvatarMixinAppService avatarMixinAppService, IHrEmployeeBaseAppService hrEmployeeBaseAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IResourceMixinAppService resourceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _hrEmployeeBaseAppService = hrEmployeeBaseAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _resourceMixinAppService = resourceMixinAppService;
        }

        protected async Task<HrEmployee> AttendanceActionChangeInternalAsync(object geo_information)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _attendance_action_change(self, geo_information=None):
            // """ Check In/Check Out action
            //     Check In: create a new attendance record
            //     Check Out: modify check_out field of appropriate attendance record
            // """
            // self.ensure_one()
            // action_date = fields.Datetime.now()
            // 
            // if self.attendance_state != 'checked_in':
            //     if geo_information:
            //         vals = {
            //             'employee_id': self.id,
            //             'check_in': action_date,
            //             **{'in_%s' % key: geo_information[key] for key in geo_information}
            //         }
            //     else:
            //         vals = {
            //             'employee_id': self.id,
            //             'check_in': action_date,
            //         }
            //     return self.env['hr.attendance'].create(vals)
            // attendance = self.env['hr.attendance'].search([('employee_id', '=', self.id), ('check_out', '=', False)], limit=1)
            // if attendance:
            //     if geo_information:
            //         attendance.write({
            //             'check_out': action_date,
            //             **{'out_%s' % key: geo_information[key] for key in geo_information}
            //         })
            //     else:
            //         attendance.write({
            //             'check_out': action_date
            //         })
            // else:
            //     raise exceptions.UserError(_(
            //         'Cannot perform check out on %(empl_name)s, could not find corresponding check in. '
            //         'Your attendances have probably been modified manually by human resources.',
            //         empl_name=self.sudo().name))
            // return attendance
            */
            return default;
        }

        protected async Task<HrEmployee> CheckPrivateFieldsInternalAsync(object field_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_private_fields(self, field_names):
            // """ Check whether ``field_names`` contain private fields. """
            // public_fields = self.env['hr.employee.public']._fields
            // private_fields = [fname for fname in field_names if fname not in public_fields]
            // if private_fields:
            //     raise AccessError(_('The fields “%s”, which you are trying to read, are not available for employee public profiles.', ','.join(private_fields)))
            */
            return default;
        }

        protected async Task<HrEmployee> CheckSsnidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_ssnid(self):
            // # By default, an Social Security Number is always valid, but each localization
            // # may want to add its own constraints
            // pass
            */
            return default;
        }

        protected async Task<HrEmployee> CheckWorkContactIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def _check_work_contact_id(self):
            // no_address = self.filtered(lambda r: not r.work_contact_id)
            // car_ids = self.env['fleet.vehicle'].sudo().search([
            //     ('driver_employee_id', 'in', no_address.ids),
            // ])
            // # Prevent from removing employee address when linked to a car
            // if car_ids:
            //     raise ValidationError(_('Cannot remove address from employees with linked cars.'))
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAttendanceStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_attendance_state(self):
            // for employee in self:
            //     att = employee.last_attendance_id.sudo()
            //     employee.attendance_state = att and not att.check_out and 'checked_in' or 'checked_out'
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar1024InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar1920InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar256InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar512InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatarInternalAsync(object avatar_field, object image_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // employee_wo_user_and_image = self.env['hr.employee']
            // for employee in self:
            //     if not employee.user_id and not employee._origin[image_field]:
            //         employee_wo_user_and_image += employee
            //         continue
            //     avatar = employee._origin[image_field]
            //     if not avatar and employee.user_id:
            //         avatar = employee.user_id.sudo()[avatar_field]
            //     employee[avatar_field] = avatar
            // super(HrEmployeePrivate, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeContractWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _compute_contract_warning(self):
            // for employee in self:
            //     employee.contract_warning = not employee.contract_id or employee.contract_id.kanban_state == 'blocked' or employee.contract_id.state != 'open'
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeContractsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _compute_contracts_count(self):
            // # read_group as sudo, since contract count is displayed on form view
            // contract_histories = self.env['hr.contract.history'].sudo().search([('employee_id', 'in', self.ids)])
            // for employee in self:
            //     contract_history = contract_histories.filtered(lambda ch: ch.employee_id == employee)
            //     employee.contracts_count = contract_history.contract_count
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCoursesCompletionTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee.py) ---
            // def _compute_courses_completion_text(self):
            // for employee in self:
            //     if not employee.user_partner_id:
            //         employee.courses_completion_text = False
            //         employee.has_subscribed_courses = False
            //         continue
            //     total_completed_courses = len(employee.user_partner_id.slide_channel_completed_ids)
            //     total = len(employee.subscribed_courses)
            //     employee.courses_completion_text = _("%(completed)s / %(total)s",
            //         completed=total_completed_courses,
            //         total=total)
            //     employee.has_subscribed_courses = total > 0
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCurrentLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_current_leave(self):
            // self.current_leave_id = False
            // 
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', 'in', self.ids),
            //     ('date_from', '<=', fields.Datetime.now()),
            //     ('date_to', '>=', fields.Datetime.now()),
            //     ('state', '=', 'validate'),
            // ])
            // for holiday in holidays:
            //     employee = self.filtered(lambda e: e.id == holiday.employee_id.id)
            //     employee.current_leave_id = holiday.holiday_status_id.id
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // if self.browse().has_access('read'):
            //     return super()._compute_display_name()
            // for employee_private, employee_public in zip(self, self.env['hr.employee.public'].browse(self.ids)):
            //     employee_private.display_name = employee_public.display_name
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // allowed_company_ids = self.env.context.get('allowed_company_ids', [])
            // if len(allowed_company_ids) <= 1:
            //     return
            // 
            // employees_count_per_user = {
            //     user.id: count
            //     for user, count in self.env['hr.employee'].sudo()._read_group(
            //         [('user_id', 'in', self.user_id.ids), ('company_id', 'in', allowed_company_ids)],
            //         ['user_id'],
            //         ['__count'],
            //     )
            // }
            // for employee in self:
            //     if employees_count_per_user.get(employee.user_id.id, 0) > 1:
            //         employee.display_name = f'{employee.display_name} - {employee.company_id.name}'
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEmployeeCarsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def _compute_employee_cars_count(self):
            // rg = self.env['fleet.vehicle.assignation.log']._read_group([
            //     ('driver_employee_id', 'in', self.ids), ('driver_id', 'in', self.work_contact_id.ids),
            // ], ['driver_employee_id'], ['__count'])
            // cars_count = {driver_employee.id: count for driver_employee, count in rg}
            // for employee in self:
            //     employee.employee_cars_count = cars_count.get(employee.id, 0)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEquipmentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: res_users.py) ---
            // def _compute_equipment_count(self):
            // for employee in self:
            //     employee.equipment_count = len(employee.equipment_ids)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeExpenseManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py) ---
            // def _compute_expense_manager(self):
            // for employee in self:
            //     previous_manager = employee._origin.parent_id.user_id
            //     manager = employee.parent_id.user_id
            //     if manager and manager.has_group('hr_expense.group_hr_expense_user') \
            //             and (employee.expense_manager_id == previous_manager or not employee.expense_manager_id):
            //         employee.expense_manager_id = manager
            //     elif not employee.expense_manager_id:
            //         employee.expense_manager_id = False
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeFirstContractDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _compute_first_contract_date(self):
            // for employee in self:
            //     employee.first_contract_date = employee._get_first_contract_date()
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py) ---
            // def _compute_has_timesheet(self):
            // self.env.cr.execute("""
            // SELECT id, EXISTS(SELECT 1 FROM account_analytic_line WHERE project_id IS NOT NULL AND employee_id = e.id limit 1)
            //   FROM hr_employee e
            //  WHERE id in %s
            // """, (tuple(self.ids), ))
            // 
            // result = {eid[0]: eid[1] for eid in self.env.cr.fetchall()}
            // 
            // for employee in self:
            //     employee.has_timesheet = result.get(employee.id, False)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py) ---
            // def _compute_has_work_entries(self):
            // self.env.cr.execute("""
            // SELECT id, EXISTS(SELECT 1 FROM hr_work_entry WHERE employee_id = e.id limit 1)
            //   FROM hr_employee e
            //  WHERE id in %s
            // """, (tuple(self.ids), ))
            // 
            // result = {eid[0]: eid[1] for eid in self.env.cr.fetchall()}
            // 
            // for employee in self:
            //     employee.has_work_entries = result.get(employee.id, False)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHoursLastMonthInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_hours_last_month(self):
            // """
            // Compute hours in the current month, if we are the 15th of october, will compute hours from 1 oct to 15 oct
            // """
            // now = fields.Datetime.now()
            // now_utc = pytz.utc.localize(now)
            // for employee in self:
            //     tz = pytz.timezone(employee.tz or 'UTC')
            //     now_tz = now_utc.astimezone(tz)
            //     start_tz = now_tz.replace(day=1, hour=0, minute=0, second=0, microsecond=0)
            //     start_naive = start_tz.astimezone(pytz.utc).replace(tzinfo=None)
            //     end_tz = now_tz
            //     end_naive = end_tz.astimezone(pytz.utc).replace(tzinfo=None)
            // 
            //     hours = sum(
            //         att.worked_hours or 0
            //         for att in employee.attendance_ids.filtered(
            //             lambda att: att.check_in >= start_naive and att.check_out and att.check_out <= end_naive
            //         )
            //     )
            // 
            //     employee.hours_last_month = round(hours, 2)
            //     employee.hours_last_month_display = "%g" % employee.hours_last_month
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHoursTodayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_hours_today(self):
            // now = fields.Datetime.now()
            // now_utc = pytz.utc.localize(now)
            // for employee in self:
            //     # start of day in the employee's timezone might be the previous day in utc
            //     tz = pytz.timezone(employee.tz)
            //     now_tz = now_utc.astimezone(tz)
            //     start_tz = now_tz + relativedelta(hour=0, minute=0)  # day start in the employee's timezone
            //     start_naive = start_tz.astimezone(pytz.utc).replace(tzinfo=None)
            // 
            //     attendances = self.env['hr.attendance'].search([
            //         ('employee_id', 'in', employee.ids),
            //         ('check_in', '<=', now),
            //         '|', ('check_out', '>=', start_naive), ('check_out', '=', False),
            //     ], order='check_in asc')
            //     hours_previously_today = 0
            //     worked_hours = 0
            //     attendance_worked_hours = 0
            //     for attendance in attendances:
            //         delta = (attendance.check_out or now) - max(attendance.check_in, start_naive)
            //         attendance_worked_hours = delta.total_seconds() / 3600.0
            //         worked_hours += attendance_worked_hours
            //         hours_previously_today += attendance_worked_hours
            //     employee.last_attendance_worked_hours = attendance_worked_hours
            //     hours_previously_today -= attendance_worked_hours
            //     employee.hours_previously_today = hours_previously_today
            //     employee.hours_today = worked_hours
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeKmHomeWorkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_km_home_work(self):
            // for employee in self:
            //     employee.km_home_work = employee.distance_home_work * 1.609 if employee.distance_home_work_unit == "miles" else employee.distance_home_work
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLastAttendanceIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_last_attendance_id(self):
            // for employee in self:
            //     employee.last_attendance_id = self.env['hr.attendance'].search([
            //         ('employee_id', 'in', employee.ids),
            //     ], order="check_in desc", limit=1)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLegalNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _compute_legal_name(self):
            // for employee in self:
            //     if not employee.legal_name:
            //         employee.legal_name = employee.name
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLicensePlateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def _compute_license_plate(self):
            // for employee in self:
            //     if employee.private_car_plate and employee.car_ids.license_plate:
            //         employee.license_plate = ' '.join(employee.car_ids.filtered('license_plate').mapped('license_plate') + [employee.private_car_plate])
            //     else:
            //         employee.license_plate = ' '.join(employee.car_ids.filtered('license_plate').mapped('license_plate')) or employee.private_car_plate
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePayslipCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_employee.py) ---
            // def _compute_payslip_count(self):
            // for employee in self:
            //     employee.payslip_count = len(employee.slip_ids)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeRelatedPartnersCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _compute_skill_ids(self):
            // for employee in self:
            //     employee.skill_ids = employee.employee_skill_ids.skill_id
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeTotalOvertimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_total_overtime(self):
            // mapped_validated_overtimes = dict(self.env['hr.attendance']._read_group(
            //     domain=[('overtime_status', '=', 'approved')],
            //     groupby=['employee_id'],
            //     aggregates=['validated_overtime_hours:sum']
            // ))
            // 
            // mapped_overtime_adjustments = dict(self.env['hr.attendance.overtime']._read_group(
            //     domain=[('adjustment', '=', True)],
            //     groupby=['employee_id'],
            //     aggregates=['duration:sum']
            // ))
            // 
            // for employee in self:
            //     employee.total_overtime = mapped_validated_overtimes.get(employee, 0) + mapped_overtime_adjustments.get(employee, 0)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkPermitNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_permit_name(self):
            // for employee in self:
            //     name = employee.name.replace(' ', '_') + '_' if employee.name else ''
            //     permit_no = '_' + employee.permit_no if employee.permit_no else ''
            //     employee.work_permit_name = "%swork_permit%s" % (name, permit_no)
            */
            return default;
        }

        protected async Task<HrEmployee> CopyCacheFromInternalAsync(object @public, object field_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _copy_cache_from(self, public, field_names):
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // for fname in field_names:
            //     values = self.env.cache.get_values(public, public._fields[fname])
            //     if self._fields[fname].translate:
            //         values = [(value.copy() if value else None) for value in values]
            //     self.env.cache.update_raw(self, self._fields[fname], values)
            */
            return default;
        }

        public override async Task<HrEmployee> CreateAsync(HrEmployee entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            // employees = super().create(vals_list)
            // # Sudo in case HR officer doesn't have the Contact Creation group
            // employees.filtered(lambda e: not e.work_contact_id).sudo()._create_work_contacts()
            // for employee_sudo in employees.sudo():
            //     # creating 'svg/xml' attachments requires specific rights
            //     if not employee_sudo.image_1920 and self.env['ir.ui.view'].sudo(False).has_access('write'):
            //         employee_sudo.image_1920 = employee_sudo._avatar_generate_svg()
            //         employee_sudo.work_contact_id.image_1920 = employee_sudo.image_1920
            // if self.env.context.get('salary_simulation'):
            //     return employees
            // employee_departments = employees.department_id
            // if employee_departments:
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', employee_departments.ids)
            //     ])._subscribe_users_automatically()
            // onboarding_notes_bodies = {}
            // hr_root_menu = self.env.ref('hr.menu_hr_root')
            // for employee in employees:
            //     # Launch onboarding plans
            //     url = '/odoo/%s/action-hr.plan_wizard_action?active_model=hr.employee&menu_id=%s' % (employee.id, hr_root_menu.id)
            //     onboarding_notes_bodies[employee.id] = Markup(_(
            //         '<b>Congratulations!</b> May I recommend you to setup an <a href="%s">onboarding plan?</a>',
            //     )) % url
            // employees._message_log_batch(onboarding_notes_bodies)
            // return employees
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // officer_group = self.env.ref('hr_attendance.group_hr_attendance_officer', raise_if_not_found=False)
            // group_updates = []
            // for vals in vals_list:
            //     if officer_group and vals.get('attendance_manager_id'):
            //         group_updates.append((4, vals['attendance_manager_id']))
            // if group_updates:
            //     officer_group.sudo().write({'users': group_updates})
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // employees = super().create(vals_list)
            // for employee in employees:
            //     if employee.candidate_id:
            //         employee.candidate_id._message_log_with_view(
            //             'hr_recruitment.candidate_hired_template',
            //             render_values={'candidate': employee.candidate_id}
            //         )
            // return employees
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // res = super(Employee, self).create(vals_list)
            // if self.env.context.get('salary_simulation'):
            //     return res
            // resume_lines_values = []
            // for employee in res:
            //     line_type = self.env.ref('hr_skills.resume_type_experience', raise_if_not_found=False)
            //     resume_lines_values.append({
            //         'employee_id': employee.id,
            //         'name': employee.company_id.name or '',
            //         'date_start': employee.create_date.date(),
            //         'description': employee.job_title or '',
            //         'line_type_id': line_type and line_type.id,
            //     })
            // self.env['hr.resume.line'].create(resume_lines_values)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // employees = super().create(vals_list)
            // if self.env.context.get('salary_simulation'):
            //     return employees
            // 
            // # We need to create timesheet entries for the global time off that are already created
            // # and are planned for after this employee creation date
            // self.with_context(allowed_company_ids=employees.company_id.ids) \
            //     ._create_future_public_holidays_timesheets(employees)
            // return employees
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<HrEmployee> CreateFuturePublicHolidaysTimesheetsInternalAsync(object employees)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py) ---
            // def _create_future_public_holidays_timesheets(self, employees):
            // lines_vals = []
            // today = fields.Datetime.today()
            // global_leaves_wo_calendar = defaultdict(lambda: self.env["resource.calendar.leaves"])
            // global_leaves_wo_calendar.update(dict(self.env['resource.calendar.leaves']._read_group(
            //     [('calendar_id', '=', False), ('date_from', '>=', today)],
            //     groupby=['company_id'],
            //     aggregates=['id:recordset'],
            // )))
            // for employee in employees:
            //     if not employee.active:
            //         continue
            //     # First we look for the global time off that are already planned after today
            //     global_leaves = employee.resource_calendar_id.global_leave_ids.filtered(lambda l: l.date_from >= today) + global_leaves_wo_calendar[employee.company_id]
            //     work_hours_data = global_leaves._work_time_per_day()
            //     for global_time_off in global_leaves:
            //         for index, (day_date, work_hours_count) in enumerate(work_hours_data[employee.resource_calendar_id.id][global_time_off.id]):
            //             lines_vals.append(
            //                 global_time_off._timesheet_prepare_line_values(
            //                     index,
            //                     employee,
            //                     work_hours_data[global_time_off.id],
            //                     day_date,
            //                     work_hours_count
            //                 )
            //             )
            // return self.env['account.analytic.line'].sudo().create(lines_vals)
            */
            return default;
        }

        public async Task<HrEmployee> CreateUserAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_user(self):
            // self.ensure_one()
            // if self.user_id:
            //     raise ValidationError(_("This employee already has an user."))
            // return {
            //     'name': _('Create User'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users',
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('hr.view_users_simple_form').id,
            //     'target': 'new',
            //     'context': dict(self._context, **{
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     })
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> CronCheckWorkPermitValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_check_work_permit_validity(self):
            // # Called by a cron
            // # Schedule an activity 1 month before the work permit expires
            // outdated_days = fields.Date.today() + relativedelta(months=+1)
            // nearly_expired_work_permits = self.search([('work_permit_scheduled_activity', '=', False), ('work_permit_expiration_date', '<', outdated_days)])
            // employees_scheduled = self.env['hr.employee']
            // for employee in nearly_expired_work_permits.filtered(lambda employee: employee.parent_id):
            //     responsible_user_id = employee.parent_id.user_id.id
            //     if responsible_user_id:
            //         employees_scheduled |= employee
            //         lang = self.env['res.users'].browse(responsible_user_id).lang
            //         formated_date = format_date(employee.env, employee.work_permit_expiration_date, date_format="dd MMMM y", lang_code=lang)
            //         employee.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('The work permit of %(employee)s expires at %(date)s.',
            //                 employee=employee.name,
            //                 date=formated_date),
            //             user_id=responsible_user_id)
            // employees_scheduled.write({'work_permit_scheduled_activity': True})
            */
            return default;
        }

        public override async Task<HrEmployee> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_employee.py) ---
            // def default_get(self, fields):
            // result = super(HrEmployee, self).default_get(fields)
            // project_company_id = self.env.context.get('create_project_employee_mapping', False)
            // if project_company_id:
            //     result['company_id'] = project_company_id
            // return result
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<HrEmployee> DeleteFuturePublicHolidaysTimesheetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py) ---
            // def _delete_future_public_holidays_timesheets(self):
            // future_timesheets = self.env['account.analytic.line'].sudo().search([('global_leave_id', '!=', False), ('date', '>=', fields.date.today()), ('employee_id', 'in', self.ids)])
            // future_timesheets.write({'global_leave_id': False})
            // future_timesheets.unlink()
            */
            return default;
        }

        protected async Task<HrEmployee> EmployeeAttendanceIntervalsInternalAsync(object start, object stop, object lunch)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     valid_contracts = self.sudo()._get_contracts(start, stop, states=['open', 'close'])
            //     if not valid_contracts:
            //         return super()._employee_attendance_intervals(start, stop, lunch)
            //     employee_tz = timezone(self.tz) if self.tz else None
            //     duration_data = Intervals()
            //     for contract in valid_contracts:
            //         contract_start = datetime.combine(contract.date_start, time.min, employee_tz)
            //         contract_end = datetime.combine(contract.date_end or date.max, time.max, employee_tz)
            //         calendar = contract.resource_calendar_id or contract.company_id.resource_calendar_id
            //         lunch_intervals = calendar._attendance_intervals_batch(
            //             max(start, contract_start),
            //             min(stop, contract_end),
            //             resources=self.resource_id,
            //             lunch=True)[self.resource_id.id]
            //         duration_data = duration_data | lunch_intervals
            //     return duration_data
            */
            return default;
        }

        public async Task<HrEmployee> FetchAsync(Guid id, HrEmployeeFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def fetch(self, field_names):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // self._copy_cache_from(public, field_names)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GenerateRandomBarcodeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GenerateWorkEntriesAsync(Guid id, HrEmployeeGenerateWorkEntriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_employee.py) ---
            // def generate_work_entries(self, date_start, date_stop, force=False):
            // date_start = fields.Date.to_date(date_start)
            // date_stop = fields.Date.to_date(date_stop)
            // 
            // if self:
            //     current_contracts = self._get_contracts(date_start, date_stop, states=['open', 'close'])
            // else:
            //     current_contracts = self._get_all_contracts(date_start, date_stop, states=['open', 'close'])
            // 
            // return current_contracts.generate_work_entries(date_start, date_stop, force=force)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetAgeInternalAsync(object target_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_age(self, target_date=None):
            // self.ensure_one()
            // if target_date is None:
            //     target_date = fields.Date.context_today(self.env.user)
            // return relativedelta(target_date, self.birthday).years if self.birthday else 0
            */
            return default;
        }

        protected async Task<HrEmployee> GetAllContractsInternalAsync(object date_from, object date_to, object states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_all_contracts(self, date_from, date_to, states=['open']):
            // """
            // Returns the contracts of all employees between date_from and date_to
            // """
            // return self.search(['|', ('active', '=', True), ('active', '=', False)])._get_contracts(date_from, date_to, states=states)
            */
            return default;
        }

        public async Task<HrEmployee> GetAllocationRequestsAmountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_allocation_requests_amount(self):
            // employee = self._get_contextual_employee()
            // return self.env['hr.leave.allocation'].search_count([
            //     ('employee_id', '=', employee.id),
            //     ('state', '=', 'confirm'),
            // ])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetBarcodesAndPinHashedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def get_barcodes_and_pin_hashed(self):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     return []
            // # Apply visibility filters (record rules)
            // visible_emp_ids = self.search([('id', 'in', self.ids)])
            // employees_data = self.sudo().search_read([('id', 'in', visible_emp_ids.ids)], ['barcode', 'pin'])
            // 
            // for e in employees_data:
            //     e['barcode'] = hashlib.sha1(e['barcode'].encode('utf8')).hexdigest() if e['barcode'] else False
            //     e['pin'] = hashlib.sha1(e['pin'].encode('utf8')).hexdigest() if e['pin'] else False
            // return employees_data
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetCalendarAttendancesInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // return calendar\
            //     .with_context(employee_timezone=employee_timezone)\
            //     .get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_contracts = self.sudo()._get_contracts(date_from, date_to, states=['open', 'close'])
            // if not valid_contracts:
            //     return super()._get_calendar_attendances(date_from, date_to)
            // employee_tz = timezone(self.tz) if self.tz else None
            // duration_data = {'days': 0, 'hours': 0}
            // for contract in valid_contracts:
            //     contract_start = datetime.combine(contract.date_start, time.min, employee_tz)
            //     contract_end = datetime.combine(contract.date_end or date.max, time.max, employee_tz)
            //     calendar = contract.resource_calendar_id or contract.company_id.resource_calendar_id
            //     contract_duration_data = calendar\
            //         .with_context(employee_timezone=employee_tz)\
            //         .get_work_duration_data(
            //             max(date_from, contract_start),
            //             min(date_to, contract_end),
            //             domain=[('company_id', 'in', [False, contract.company_id.id])])
            //     duration_data['days'] += contract_duration_data['days']
            //     duration_data['hours'] += contract_duration_data['hours']
            // return duration_data
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarPeriodsInternalAsync(object start, object stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_calendar_periods(self, start, stop):
            // """
            // :param datetime start: the start of the period
            // :param datetime stop: the stop of the period
            // """
            // calendar_periods_by_employee = defaultdict(list)
            // contracts_by_employee = self.env['hr.contract'].sudo()._read_group(domain=[
            //     '|',
            //         ('state', 'in', ['open', 'close']),
            //         '&',
            //             ('state', '=', 'draft'),
            //             ('kanban_state', '=', 'done'),
            //     ('date_start', '<=', stop),
            //     '|',
            //         ('date_end', '=', False),
            //         ('date_end', '>=', start),
            //     ('employee_id', 'in', self.ids),
            // ], groupby=['employee_id'], aggregates=['id:recordset'])
            // for employee, contracts in contracts_by_employee:
            //     for contract in contracts:
            //         # if employee is under fully flexible contract, use timezone of the employee
            //         calendar_tz = timezone(contract.resource_calendar_id.tz) if contract.resource_calendar_id else timezone(employee.resource_id.tz)
            //         utc = timezone('UTC')
            //         date_start = datetime.combine(
            //             contract.date_start,
            //             time(0, 0, 0)
            //         ).replace(tzinfo=calendar_tz).astimezone(utc)
            //         if contract.date_end:
            //             date_end = datetime.combine(
            //                 contract.date_end + relativedelta(days=1),
            //                 time(0, 0, 0)
            //             ).replace(tzinfo=calendar_tz).astimezone(utc)
            //         else:
            //             date_end = stop
            //         calendar_periods_by_employee[employee].append(
            //             (max(date_start, start), min(date_end, stop), contract.resource_calendar_id)
            //         )
            // return calendar_periods_by_employee
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarsInternalAsync(object date_from)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_calendars(self, date_from=None):
            // res = super()._get_calendars(date_from=date_from)
            // if not date_from:
            //     return res
            // contracts = self.env['hr.contract'].sudo().search([
            //     '|',
            //         ('state', 'in', ['open', 'close']),
            //         '&',
            //             ('state', '=', 'draft'),
            //             ('kanban_state', '=', 'done'),
            //     ('employee_id', 'in', self.ids),
            //     ('date_start', '<=', date_from),
            //     '|',
            //         ('date_end', '=', False),
            //         ('date_end', '>=', date_from)
            // ])
            // contracts_by_employee = defaultdict(lambda: self.env['hr.contract'])
            // for contract in contracts:
            //     contracts_by_employee[contract.employee_id] += contract
            // for employee in self:
            //     employee_contracts = contracts_by_employee[employee.id]
            //     if employee_contracts:
            //         res[employee.id] = contracts[0].resource_calendar_id.sudo(False)
            // return res
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractsInternalAsync(object date_from, object date_to, object states, object kanban_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_contracts(self, date_from, date_to, states=['open'], kanban_state=False):
            // """
            // Returns the contracts of the employee between date_from and date_to
            // """
            // state_domain = [('state', 'in', states)]
            // if kanban_state:
            //     state_domain = expression.AND([state_domain, [('kanban_state', 'in', kanban_state)]])
            // 
            // return self.env['hr.contract'].search(
            //     expression.AND([[('employee_id', 'in', self.ids)],
            //     state_domain,
            //     [('date_start', '<=', date_to),
            //         '|',
            //             ('date_end', '=', False),
            //             ('date_end', '>=', date_from)]]))
            */
            return default;
        }

        protected async Task<HrEmployee> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        protected async Task<HrEmployee> GetExpectedAttendancesInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // calendar_intervals = calendar._work_intervals_batch(
            //                         date_from,
            //                         date_to,
            //                         tz=employee_timezone,
            //                         resources=self.resource_id,
            //                         compute_leaves=True,
            //                         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            // return calendar_intervals
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_contracts = self.sudo()._get_contracts(date_from, date_to, states=['open', 'close'])
            // if not valid_contracts:
            //     return super()._get_expected_attendances(date_from, date_to)
            // employee_tz = timezone(self.tz) if self.tz else None
            // duration_data = Intervals()
            // for contract in valid_contracts:
            //     contract_start = datetime.combine(contract.date_start, time.min, employee_tz)
            //     contract_end = datetime.combine(contract.date_end or date.max, time.max, employee_tz)
            //     calendar = contract.resource_calendar_id or contract.company_id.resource_calendar_id
            //     contract_intervals = calendar._work_intervals_batch(
            //                             max(date_from, contract_start),
            //                             min(date_to, contract_end),
            //                             tz=employee_tz,
            //                             resources=self.resource_id,
            //                             compute_leaves=True)[self.resource_id.id]
            //     duration_data = duration_data | contract_intervals
            // return duration_data
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstContractDateInternalAsync(object no_gap)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_first_contract_date(self, no_gap=True):
            // self.ensure_one()
            // 
            // def remove_gap(contracts):
            //     # We do not consider a gap of more than 4 days to be a same occupation
            //     # contracts are considered to be ordered correctly
            //     if not contracts:
            //         return self.env['hr.contract']
            //     if len(contracts) == 1:
            //         return contracts
            //     current_contract = contracts[0]
            //     older_contracts = contracts[1:]
            //     current_date = current_contract.date_start
            //     for i, other_contract in enumerate(older_contracts):
            //         # Consider current_contract.date_end being false as an error and cut the loop
            //         gap = (current_date - (other_contract.date_end or date(2100, 1, 1))).days
            //         current_date = other_contract.date_start
            //         if gap >= 4:
            //             return older_contracts[0:i] + current_contract
            //     return older_contracts + current_contract
            // 
            // contracts = self._get_first_contracts().sorted('date_start', reverse=True)
            // if no_gap:
            //     contracts = remove_gap(contracts)
            // return min(contracts.mapped('date_start')) if contracts else False
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstContractsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_first_contracts(self):
            // self.ensure_one()
            // contracts = self.sudo().contract_ids.filtered(lambda c: c.state != 'cancel')
            // if self.env.context.get('before_date'):
            //     contracts = contracts.filtered(lambda c: c.date_start <= self.env.context['before_date'])
            // return contracts
            */
            return default;
        }

        public async Task<HrEmployee> GetFormviewActionAsync(Guid id, HrEmployeeGetFormviewActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super(HrEmployeePrivate, self).get_formview_action(access_uid=access_uid)
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if not user.has_group('hr.group_hr_user'):
            //     res['res_model'] = 'hr.employee.public'
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetFormviewIdAsync(Guid id, HrEmployeeGetFormviewIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_id(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if user.has_group('hr.group_hr_user'):
            //     return super(HrEmployeePrivate, self).get_formview_id(access_uid=access_uid)
            // # Hardcode the form view for public employee
            // return self.env.ref('hr.hr_employee_public_view_form').id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetHoursPerDayInternalAsync(object date_from)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_hours_per_day(self, date_from):
            // ''' Return 24H to handle the case of Fully Flexible (ones without a working calendar)'''
            // if not self:
            //     return 0
            // calendars = self._get_calendars(date_from)
            // return calendars[self.id].hours_per_day if calendars[self.id] else 24
            */
            return default;
        }

        public async Task<HrEmployee> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Employees'),
            //     'template': '/hr/static/xls/hr_employee.xls'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetIncomingContractsInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_incoming_contracts(self, date_from, date_to):
            // return self._get_contracts(date_from, date_to, states=['draft'], kanban_state=['done'])
            */
            return default;
        }

        public async Task<HrEmployee> GetMandatoryDaysAsync(Guid id, HrEmployeeGetMandatoryDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_mandatory_days(self, start_date, end_date):
            // all_days = {}
            // 
            // self = self or self.env.user.employee_id
            // 
            // mandatory_days = self._get_mandatory_days(start_date, end_date)
            // for mandatory_day in mandatory_days:
            //     num_days = (mandatory_day.end_date - mandatory_day.start_date).days
            //     for d in range(num_days + 1):
            //         all_days[str(mandatory_day.start_date + relativedelta(days=d))] = mandatory_day.color
            // 
            // return all_days
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetMandatoryDaysDataAsync(Guid id, HrEmployeeGetMandatoryDaysDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_mandatory_days_data(self, date_start, date_end):
            // self = self._get_contextual_employee()
            // mandatory_days = self._get_mandatory_days(date_start, date_end).sorted('start_date')
            // return list(map(lambda sd: {
            //     'id': -sd.id,
            //     'colorIndex': sd.color,
            //     'end': datetime.combine(sd.end_date, datetime.max.time()).isoformat(),
            //     'endType': "datetime",
            //     'isAllDay': True,
            //     'start': datetime.combine(sd.start_date, datetime.min.time()).isoformat(),
            //     'startType': "datetime",
            //     'title': sd.name,
            // }, mandatory_days))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetMandatoryDaysInternalAsync(object start_date, object end_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_mandatory_days(self, start_date, end_date):
            // domain = [
            //     ('start_date', '<=', end_date),
            //     ('end_date', '>=', start_date),
            //     ('company_id', 'in', self.env.companies.ids),
            //     '|',
            //     ('resource_calendar_id', '=', False),
            //     ('resource_calendar_id', '=', self.resource_calendar_id.id),
            // ]
            // 
            // if self.department_id:
            //     domain += [
            //         '|',
            //         ('department_ids', '=', False),
            //         ('department_ids', 'parent_of', self.department_id.id),
            //     ]
            // else:
            //     domain += [('department_ids', '=', False)]
            // 
            // return self.env['hr.leave.mandatory.day'].search(domain)
            */
            return default;
        }

        protected async Task<HrEmployee> GetMaritalStatusSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_marital_status_selection(self):
            // return [
            //     ('single', _('Single')),
            //     ('married', _('Married')),
            //     ('cohabitant', _('Legal Cohabitant')),
            //     ('widower', _('Widower')),
            //     ('divorced', _('Divorced')),
            // ]
            */
            return default;
        }

        protected async Task<HrEmployee> GetPartnerCountDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return super()._get_partner_count_depends() + ['candidate_id']
            */
            return default;
        }

        public async Task<HrEmployee> GetPublicHolidaysDataAsync(Guid id, HrEmployeeGetPublicHolidaysDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_public_holidays_data(self, date_start, date_end):
            // self = self._get_contextual_employee()
            // employee_tz = pytz.timezone(self._get_tz() if self else self.env.user.tz or 'utc')
            // public_holidays = self._get_public_holidays(date_start, date_end).sorted('date_from')
            // return list(map(lambda bh: {
            //     'id': -bh.id,
            //     'colorIndex': 0,
            //     'end': datetime.combine(bh.date_to.astimezone(employee_tz), datetime.max.time()).isoformat(),
            //     'endType': "datetime",
            //     'isAllDay': True,
            //     'start': datetime.combine(bh.date_from.astimezone(employee_tz), datetime.min.time()).isoformat(),
            //     'startType': "datetime",
            //     'title': bh.name,
            // }, public_holidays))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetPublicHolidaysInternalAsync(object date_start, object date_end)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_public_holidays(self, date_start, date_end):
            // domain = [
            //     ('resource_id', '=', False),
            //     ('company_id', 'in', self.env.companies.ids),
            //     ('date_from', '<=', date_end),
            //     ('date_to', '>=', date_start),
            //     '|',
            //     ('calendar_id', '=', False),
            //     ('calendar_id', '=', self.resource_calendar_id.id),
            // ]
            // 
            // return self.env['resource.calendar.leaves'].search(domain)
            */
            return default;
        }

        protected async Task<HrEmployee> GetRelatedPartnersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // partners = super()._get_related_partners()
            // return partners | self.sudo().candidate_id.partner_id
            */
            return default;
        }

        public async Task<HrEmployee> GetSpecialDaysDataAsync(Guid id, HrEmployeeGetSpecialDaysDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_special_days_data(self, date_start, date_end):
            // return {
            //     'mandatoryDays': self.get_mandatory_days_data(date_start, date_end),
            //     'bankHolidays': self.get_public_holidays_data(date_start, date_end),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetTzBatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz_batch(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC
            // # Returns a dict {employee_id: tz}
            // return {emp.id: emp._get_tz() for emp in self}
            */
            return default;
        }

        protected async Task<HrEmployee> GetTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC and returns it as a string
            // self.ensure_one()
            // return self.tz or\
            //        self.resource_calendar_id.tz or\
            //        self.company_id.resource_calendar_id.tz or\
            //        'UTC'
            */
            return default;
        }

        protected async Task<HrEmployee> GetUnusualDaysInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // # Checking the calendar directly allows to not grey out the leaves taken
            // # by the employee or fallback to the company calendar
            // return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //     self.company_id,
            // )
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // employee_contracts = self.env['hr.contract'].sudo().search([
            //     ('state', '!=', 'cancel'),
            //     ('employee_id', '=', self.id),
            //     ('date_start', '<=', date_to),
            //     '|',
            //     ('date_end', '=', False),
            //     ('date_end', '>=', date_from),
            // ])
            // if not employee_contracts:
            //     return super()._get_unusual_days(date_from, date_to)
            // unusual_days = {}
            // date_from_date = datetime.strptime(date_from, '%Y-%m-%d %H:%M:%S').date()
            // date_to_date = datetime.strptime(date_to, '%Y-%m-%d %H:%M:%S').date() if date_to else None
            // for contract in employee_contracts:
            //     tmp_date_from = max(date_from_date, contract.date_start)
            //     tmp_date_to = min(date_to_date, contract.date_end) if contract.date_end else date_to_date
            //     unusual_days.update(contract.resource_calendar_id.sudo(False)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(tmp_date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(tmp_date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     ))
            // return unusual_days
            */
            return default;
        }

        protected async Task<HrEmployee> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return super()._get_user_m2o_to_empty_on_archived_employees() + ['expense_manager_id']
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return super()._get_user_m2o_to_empty_on_archived_employees() + ['leave_manager_id']
            */
            return default;
        }

        public async Task<HrEmployee> GetViewAsync(Guid id, HrEmployeeGetViewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if self.browse().has_access('read'):
            //     return super().get_view(view_id, view_type, **options)
            // return self.env['hr.employee.public'].get_view(view_id, view_type, **options)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetViewsAsync(Guid id, HrEmployeeGetViewsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // if self.browse().has_access('read'):
            //     return super().get_views(views, options)
            // res = self.env['hr.employee.public'].get_views(views, options)
            // res['models'].update({'hr.employee': res['models']['hr.employee.public']})
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GroupHrExpenseUserDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py) ---
            // def _group_hr_expense_user_domain(self):
            // # We return the domain only if the group exists for the following reason:
            // # When a group is created (at module installation), the `res.users` form view is
            // # automatically modified to add application accesses. When modifying the view, it
            // # reads the related field `expense_manager_id` of `res.users` and retrieve its domain.
            // # This is a problem because the `group_hr_expense_user` record has already been created but
            // # not its associated `ir.model.data` which makes `self.env.ref(...)` fail.
            // group = self.env.ref('hr_expense.group_hr_expense_team_approver', raise_if_not_found=False)
            // return [('groups_id', 'in', group.ids)] if group else []
            */
            return default;
        }

        protected async Task<HrEmployee> InverseKmHomeWorkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_km_home_work(self):
            // for employee in self:
            //     employee.distance_home_work = employee.km_home_work / 1.609 if employee.distance_home_work_unit == "miles" else employee.km_home_work
            */
            return default;
        }

        protected async Task<HrEmployee> IsLeaveUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _is_leave_user(self):
            // return self == self.env.user.employee_id and self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            */
            return default;
        }

        protected async Task<HrEmployee> LangGetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data_domain(self, data):
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // return config_id._employee_domain(config_id.current_user_id.id)
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['name', 'user_id', 'work_contact_id']
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(data['pos.config']['data'][0]['id'])
            // 
            // employees = self.search(domain)
            // manager_ids = employees.filtered(lambda emp: data['pos.config']['data'][0]['group_pos_manager_id'] in emp.user_id.groups_id.ids).mapped('id')
            // 
            // employees_barcode_pin = employees.get_barcodes_and_pin_hashed()
            // bp_per_employee_id = {bp_e['id']: bp_e for bp_e in employees_barcode_pin}
            // 
            // employees = employees.read(fields, load=False)
            // for employee in employees:
            //     if employee['id'] in manager_ids or employee['id'] in data['pos.config']['data'][0]['advanced_employee_ids']:
            //         role = 'manager'
            //     else:
            //         role = 'cashier'
            // 
            //     employee['_role'] = role
            //     employee['_barcode'] = bp_per_employee_id[employee['id']]['barcode']
            //     employee['_pin'] = bp_per_employee_id[employee['id']]['pin']
            // 
            // return {
            //     'data': employees,
            //     'fields': fields,
            // }
            */
            return default;
        }

        protected async Task<HrEmployee> LoadScenarioInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // demo_tag = self.env.ref('hr.employee_category_demo', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init', kind='data')
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // super()._load_scenario()
            // demo_tag = self.env.ref('hr_skills.employee_resume_line_emp_eg_1', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init', kind='data')
            // convert.convert_file(self.env, 'hr_skills', 'data/scenarios/hr_skills_scenario.xml', None, mode='init', kind='data')
            */
            return default;
        }

        protected async Task<HrEmployee> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['user_partner_id']
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_company_id(self):
            // if self._origin:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("To avoid multi company issues (losing the access to your previous contracts, leaves, ...), you should create another employee in the new company instead.")
            //     }}
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeTimezoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_user(self):
            // self.update(self._sync_user(self.user_id, (bool(self.image_1920))))
            // if not self.name:
            //     self.name = self.user_id.name
            */
            return default;
        }

        public async Task<HrEmployee> OpenContractAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def action_open_contract(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('hr_contract.action_hr_contract')
            // action['views'] = [(False, 'form')]
            // if not self.contract_ids:
            //     action['context'] = {
            //         'default_employee_id': self.id,
            //         # display current resource_calendar_id as the default one if it exists (if False, fully flexible calendar)
            //         'default_resource_calendar_id': self.resource_calendar_id.id or False,
            //         'from_action_open_contract': True,
            //     }
            //     action['target'] = 'current'
            //     return action
            // 
            // target_contract = self.contract_id
            // if target_contract:
            //     action['res_id'] = target_contract.id
            //     return action
            // 
            // target_contract = self.contract_ids.filtered(lambda c: c.state == 'draft')
            // if target_contract:
            //     action['res_id'] = target_contract[0].id
            //     return action
            // 
            // action['res_id'] = self.contract_ids[0].id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenCoursesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee.py) ---
            // def action_open_courses(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': '/profile/user/%s' % self.user_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenEmployeeCarsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def action_open_employee_cars(self):
            // self.ensure_one()
            // 
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "fleet.vehicle.assignation.log",
            //     "views": [[self.env.ref("hr_fleet.fleet_vehicle_assignation_log_employee_view_list").id, "list"], [False, "form"]],
            //     "domain": [("driver_employee_id", "in", self.ids), ("driver_id", "in", self.work_contact_id.ids)],
            //     "context": dict(self._context, default_driver_id=self.user_id.partner_id.id, default_driver_employee_id=self.id),
            //     "name": self.env._("History Employee Cars"),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenLastMonthAttendancesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def action_open_last_month_attendances(self):
            // self.ensure_one()
            // return {
            //     "type": "ir.actions.act_window",
            //     "name": _("Attendances This Month"),
            //     "res_model": "hr.attendance",
            //     "views": [[self.env.ref('hr_attendance.hr_attendance_employee_simple_tree_view').id, "list"]],
            //     "context": {
            //         "create": 0
            //     },
            //     "domain": [('employee_id', '=', self.id),
            //                ('check_in', ">=", fields.datetime.today().replace(day=1, hour=0, minute=0))]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenLastMonthOvertimeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def action_open_last_month_overtime(self):
            // self.ensure_one()
            // return {
            //     "type": "ir.actions.act_window",
            //     "name": _("Attendances This Month"),
            //     "res_model": "hr.attendance",
            //     "views": [[self.env.ref('hr_attendance.hr_attendance_validated_hours_employee_simple_tree_view').id, "list"]],
            //     "context": {
            //         "create": 0
            //     },
            //     "domain": [('employee_id', '=', self.id), ('overtime_status', '=', 'approved')]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenWorkEntriesAsync(Guid id, HrEmployeeOpenWorkEntriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py) ---
            // def action_open_work_entries(self, initial_date=False):
            // self.ensure_one()
            // ctx = {'default_employee_id': self.id}
            // if initial_date:
            //     ctx['initial_date'] = initial_date
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('%s work entries', self.display_name),
            //     'view_mode': 'calendar,list,form',
            //     'res_model': 'hr.work.entry',
            //     'context': ctx,
            //     'domain': [('employee_id', '=', self.id)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            */
            return default;
        }

        protected async Task<HrEmployee> PrepareResourceValuesInternalAsync(object vals, object tz)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_resource_values(self, vals, tz):
            // resource_vals = super()._prepare_resource_values(vals, tz)
            // vals.pop('name')  # Already considered by super call but no popped
            // # We need to pop it to avoid useless resource update (& write) call
            // # on every newly created resource (with the correct name already)
            // user_id = vals.pop('user_id', None)
            // if user_id:
            //     resource_vals['user_id'] = user_id
            // active_status = vals.get('active')
            // if active_status is not None:
            //     resource_vals['active'] = active_status
            // return resource_vals
            */
            return default;
        }

        public async Task<HrEmployee> RelatedContactsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_related_contacts(self):
            // related_partners = self._get_related_partners()
            // action = {
            //     'name': _("Related Contacts"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.partner',
            //     'view_mode': 'form',
            // }
            // if len(related_partners) > 1:
            //     action['view_mode'] = 'kanban,list,form'
            //     action['domain'] = [('id', 'in', related_partners.ids)]
            //     return action
            // else:
            //     action['res_id'] = related_partners.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> RemoveWorkContactIdInternalAsync(object user, object employee_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _remove_work_contact_id(self, user, employee_company):
            // """ Remove work_contact_id for previous employee if the user is assigned to a new employee """
            // employee_company = employee_company or self.company_id.id
            // # For employees with a user_id, the constraint (user can't be linked to multiple employees) is triggered
            // old_partner_employee_ids = user.partner_id.employee_ids.filtered(lambda e:
            //     not e.user_id
            //     and e.company_id.id == employee_company
            //     and e != self
            // )
            // old_partner_employee_ids.work_contact_id = None
            */
            return default;
        }

        public async Task<HrEmployee> SearchFetchAsync(Guid id, HrEmployeeSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read'):
            //     return super()._search(domain, offset, limit, order)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order)
            // except ValueError:
            //     raise AccessError(_('You do not have access to this document.'))
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployeePrivate, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        protected async Task<HrEmployee> SearchLicensePlateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def _search_license_plate(self, operator, value):
            // employees = self.env['hr.employee'].search(['|', ('car_ids.license_plate', operator, value), ('private_car_plate', operator, value)])
            // return [('id', 'in', employees.ids)]
            */
            return default;
        }

        protected async Task<HrEmployee> SyncUserInternalAsync(object user, object employee_has_image)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_user(self, user, employee_has_image=False):
            // vals = dict(
            //     work_contact_id=user.partner_id.id if user else self.work_contact_id.id,
            //     user_id=user.id,
            // )
            // if not employee_has_image:
            //     vals['image_1920'] = user.image_1920
            // if user.tz:
            //     vals['tz'] = user.tz
            // return vals
            */
            return default;
        }

        public async Task<HrEmployee> TimeOffDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def action_time_off_dashboard(self):
            // return {
            //     'name': _('Time Off Dashboard'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.leave',
            //     'views': [[self.env.ref('hr_holidays.hr_leave_employee_view_dashboard').id, 'calendar']],
            //     'domain': [('employee_id', 'in', self.ids)],
            //     'context': {
            //         'employee_id': self.ids,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> TimesheetFromEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py) ---
            // def action_timesheet_from_employee(self):
            // action = self.env["ir.actions.act_window"]._for_xml_id("hr_timesheet.timesheet_action_from_employee")
            // context = literal_eval(action['context'].replace('active_id', str(self.id)))
            // context['create'] = context.get('create', True) and self.active
            // action['context'] = context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def toggle_active(self):
            // res = super(HrEmployeePrivate, self).toggle_active()
            // unarchived_employees = self.filtered(lambda employee: employee.active)
            // unarchived_employees.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
            // 
            // archived_employees = self.filtered(lambda e: not e.active)
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = [[(field, 'in', archived_employees.ids)] for field in employee_fields_to_empty]
            //     user_domain = [[(field, 'in', archived_employees.user_id.ids)] for field in user_fields_to_empty]
            //     employees = self.env['hr.employee'].search(expression.OR(employee_domain + user_domain))
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            // if len(self) == 1 and not self.active and not self.env.context.get('no_wizard', False):
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'name': _('Register Departure'),
            //         'res_model': 'hr.departure.wizard',
            //         'view_mode': 'form',
            //         'target': 'new',
            //         'context': {'active_id': self.id},
            //         'views': [[False, 'form']]
            //     }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _unlink_except_active_pos_session(self):
            // configs_with_employees = self.env['pos.config'].sudo().search([('module_pos_hr', '=', True)]).filtered(lambda c: c.current_session_id)
            // configs_with_all_employees = configs_with_employees.filtered(lambda c: not c.basic_employee_ids and not c.advanced_employee_ids)
            // configs_with_specific_employees = configs_with_employees.filtered(lambda c: (c.basic_employee_ids or c.advanced_employee_ids) & self)
            // if configs_with_all_employees or configs_with_specific_employees:
            //     error_msg = _("You cannot delete an employee that may be used in an active PoS session, close the session(s) first: \n")
            //     for employee in self:
            //         config_ids = configs_with_all_employees | configs_with_specific_employees.filtered(lambda c: employee in c.basic_employee_ids)
            //         if config_ids:
            //             error_msg += _("Employee: %(employee)s - PoS Config(s): %(config_list)s \n", employee=employee.name, config_list=format_list(self.env, config_ids.mapped("name")))
            // 
            //     raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<HrEmployee> UnlinkExceptOpenContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _unlink_except_open_contract(self):
            // if any(contract.state == 'open' for contract in self.contract_ids):
            //     raise UserError(_('You cannot delete an employee with a running contract.'))
            */
            return default;
        }

        public async Task<HrEmployee> UnlinkWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py) ---
            // def action_unlink_wizard(self):
            // wizard = self.env['hr.employee.delete.wizard'].create({
            //     'employee_ids': self.ids,
            // })
            // if not self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver') and wizard.has_timesheet and not wizard.has_active_employee:
            //     raise UserError(_('You cannot delete employees who have timesheets.'))
            // 
            // return {
            //     'name': _('Confirmation'),
            //     'view_mode': 'form',
            //     'res_model': 'hr.employee.delete.wizard',
            //     'views': [(self.env.ref('hr_timesheet.hr_employee_delete_wizard_form').id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'res_id': wizard.id,
            //     'target': 'new',
            //     'context': self.env.context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> VerifyBarcodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_barcode(self):
            // for employee in self:
            //     if employee.barcode:
            //         if not (re.match(r'^[A-Za-z0-9]+$', employee.barcode) and len(employee.barcode) <= 18):
            //             raise ValidationError(_("The Badge ID must be alphanumeric without any accents and no longer than 18 characters."))
            */
            return default;
        }

        protected async Task<HrEmployee> VerifyPinInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_pin(self):
            // for employee in self:
            //     if employee.pin and not employee.pin.isdigit():
            //         raise ValidationError(_("The PIN must be a sequence of digits."))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrEmployee entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'work_contact_id' in vals:
            //     account_ids = vals.get('bank_account_id') or self.bank_account_id.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            //     self.message_unsubscribe(self.work_contact_id.ids)
            //     if vals['work_contact_id']:
            //         self._message_subscribe([vals['work_contact_id']])
            // if vals.get('user_id'):
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // res = super(HrEmployeePrivate, self).write(vals)
            // if vals.get('department_id') or vals.get('user_id'):
            //     department_id = vals['department_id'] if vals.get('department_id') else self[:1].department_id.id
            //     # When added to a department or changing user, subscribe to the channels auto-subscribed by department
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', department_id)
            //     ])._subscribe_users_automatically()
            // if vals.get('departure_description'):
            //     for employee in self:
            //         employee.message_post(body=_(
            //             'Additional Information: \n %(description)s',
            //             description=vals.get('departure_description')))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def write(self, values):
            // old_officers = self.env['res.users']
            // if 'attendance_manager_id' in values:
            //     old_officers = self.attendance_manager_id
            //     # Officer was added
            //     if values['attendance_manager_id']:
            //         officer = self.env['res.users'].browse(values['attendance_manager_id'])
            //         officers_group = self.env.ref('hr_attendance.group_hr_attendance_officer', raise_if_not_found=False)
            //         if officers_group and not officer.has_group('hr_attendance.group_hr_attendance_officer'):
            //             officer.sudo().write({'groups_id': [(4, officers_group.id)]})
            // 
            // res = super(HrEmployee, self).write(values)
            // old_officers.sudo()._clean_attendance_officers()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if vals.get('contract_id'):
            //     for employee in self:
            //         employee.resource_calendar_id.transfer_leaves_to(employee.contract_id.resource_calendar_id, employee.resource_id)
            //         employee.resource_calendar_id = employee.contract_id.resource_calendar_id
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // # Update car partner when it is changed on the employee
            // if 'work_contact_id' in vals:
            //     car_ids = self.env['fleet.vehicle'].sudo().search([
            //         '|',
            //             ('driver_employee_id', 'in', self.ids),
            //             ('future_driver_employee_id', 'in', self.ids),
            //     ])
            //     if car_ids:
            //         car_ids.filtered(lambda c: c.driver_employee_id.id in self.ids).write({
            //             'driver_id': vals['work_contact_id'],
            //         })
            //         car_ids.filtered(lambda c: c.future_driver_employee_id.id in self.ids).write({
            //             'future_driver_id': vals['work_contact_id'],
            //         })
            // if 'mobility_card' in vals:
            //     car_ids = self.env['fleet.vehicle'].sudo().search([
            //         ('driver_employee_id', 'in', self.ids),
            //     ])
            //     car_ids._compute_mobility_card()
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'department_id' in vals:
            //     self.employee_skill_ids._create_logs()
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if vals.get('active'):
            //     inactive_emp = self.filtered(lambda e: not e.active)
            // result = super(Employee, self).write(vals)
            // self_company = self.with_context(allowed_company_ids=self.company_id.ids)
            // if 'active' in vals:
            //     if vals.get('active'):
            //         # Create future holiday timesheets
            //         inactive_emp = inactive_emp.with_env(self_company.env)
            //         inactive_emp._create_future_public_holidays_timesheets(inactive_emp)
            //     else:
            //         # Delete future holiday timesheets
            //         self_company._delete_future_public_holidays_timesheets()
            // elif 'resource_calendar_id' in vals:
            //     # Update future holiday timesheets
            //     self_company._delete_future_public_holidays_timesheets()
            //     self_company._create_future_public_holidays_timesheets(self_company)
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}