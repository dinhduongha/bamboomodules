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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrEmployeeAppService : GenericApplicationService<HrEmployee>, IHrEmployeeAppService
    {
        private readonly IAvatarMixinAppService _avatarMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IResourceMixinAppService _resourceMixinAppService;
        public HrEmployeeAppService(IRepository<HrEmployee, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAvatarMixinAppService avatarMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IPosLoadMixinAppService posLoadMixinAppService, IResourceMixinAppService resourceMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _resourceMixinAppService = resourceMixinAppService;
        }

        protected async Task<HrEmployee> ActionSetManualPresenceInternalAsync(object state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def _action_set_manual_presence(self, state):
            // if not self.env.user.has_group('hr.group_hr_manager'):
            //     raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // self.write({
            //     'manually_set_present': state,
            //     'manually_set_presence': True,
            //     "hr_presence_state_display": 'present' if state else 'absent',
            // })
            */
            return default;
        }

        protected async Task<HrEmployee> AddCertificationActivityToEmployeesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _add_certification_activity_to_employees(self):
            // today = fields.Date.today()
            // three_months_later = today + relativedelta(months=3)
            // return_val = self.env["mail.activity"]
            // 
            // jobs_with_certification = self.env["hr.job"].search([("job_skill_ids.is_certification", "=", True)])
            // if not jobs_with_certification:
            //     return return_val
            // 
            // job_skill_level_mapping = defaultdict(dict)
            // 
            // for job in jobs_with_certification:
            //     for cert in job.job_skill_ids.filtered(lambda s: s.is_certification):
            //         key = (cert.skill_id, cert.skill_level_id)
            //         summary = f"{cert.skill_id.name}: {cert.skill_level_id.name}"
            //         job_skill_level_mapping[job][key] = summary
            // 
            // if not job_skill_level_mapping:
            //     return return_val
            // 
            // employee_domain = Domain.AND(
            //     [
            //         Domain("job_id", "in", jobs_with_certification.ids),
            //         Domain.OR(
            //             [
            //                 Domain("user_id", "!=", False),
            //                 Domain("parent_id.user_id", "!=", False),
            //                 Domain("job_id.user_id", "!=", False),
            //             ],
            //         ),
            //     ],
            // )
            // employees = self.env["hr.employee"].search(employee_domain)
            // if not employees:
            //     return return_val
            // 
            // emp_skills = self.env["hr.employee.skill"].search(
            //     Domain.AND(
            //         [Domain("employee_id", "in", employees.ids), Domain("is_certification", "=", True)],
            //     ),
            // )
            // 
            // employee_cert_data = defaultdict(dict)
            // for es in emp_skills:
            //     key = (es.skill_id, es.skill_level_id)
            //     employee_cert_data[es.employee_id][key] = es.valid_to
            // 
            // existing_activities = self.env["mail.activity"].search(
            //     Domain.AND(
            //         [
            //             Domain("active", "=", True),
            //             Domain("activity_category", "=", "upload_file"),
            //             Domain("res_model", "=", "hr.employee"),
            //             Domain("res_id", "in", employees.ids),
            //         ],
            //     ),
            // )
            // existing_activity_keys = {(act.res_id, act.summary) for act in existing_activities}
            // 
            // for employee in employees:
            //     job_id = employee.job_id
            //     responsible = employee.user_id or employee.parent_id.user_id or job_id.user_id
            //     if job_id not in job_skill_level_mapping or not responsible:
            //         continue
            // 
            //     for skill_level_key, summary in job_skill_level_mapping[job_id].items():
            //         if (employee.id, summary) in existing_activity_keys:
            //             continue
            // 
            //         valid_to_date = employee_cert_data.get(employee, {}).get(skill_level_key)
            //         if valid_to_date is not None and (valid_to_date is False or valid_to_date > three_months_later):
            //             continue
            // 
            //         activity = employee.activity_schedule(
            //             act_type_xmlid="hr_skills.mail_activity_data_upload_certification",
            //             summary=summary,
            //             note="Certification missing or expiring soon",
            //             date_deadline=valid_to_date or today,
            //             user_id=responsible.id,
            //         )
            //         return_val += activity
            // 
            // return return_val
            */
            return default;
        }

        public async Task<HrEmployee> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_archive(self):
            // archived_employees = self.filtered('active')
            // res = super().action_archive()
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = Domain.OR(Domain(field, 'in', archived_employees.ids) for field in employee_fields_to_empty)
            //     user_domain = Domain.OR(Domain(field, 'in', archived_employees.user_id.ids) for field in user_fields_to_empty)
            //     employees = self.env['hr.employee'].search(employee_domain | user_domain)
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            //     if len(archived_employees) == 1 and not self.env.context.get('no_wizard', False):
            //         return {
            //             'type': 'ir.actions.act_window',
            //             'name': _('Register Departure'),
            //             'res_model': 'hr.departure.wizard',
            //             'view_mode': 'form',
            //             'target': 'new',
            //             'context': {'active_id': self.id},
            //             'views': [[False, 'form']]
            //         }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<HrEmployee> CheckAccessInternalAsync(object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_access(self, operation):
            // # This method override provides read access to 'hr.employee' in some
            // # situations, like setting a many2many field to comodel 'hr.employee'.
            // # Since Odoo 19, one must have read access to the comodel to modify the
            // # relation.
            // if operation == 'read' and self.env.context.get('_allow_read_hr_employee') is _ALLOW_READ_HR_EMPLOYEE:
            //     return None
            // 
            // return super()._check_access(operation)
            */
            return default;
        }

        public async Task<HrEmployee> CheckNoExistingContractAsync(Guid id, HrEmployeeCheckNoExistingContractRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_no_existing_contract(self, date):
            // if isinstance(date, str):
            //     date = fields.Date.from_string(date)
            // if self._is_in_contract(date):
            //     raise ValidationError(self.env._("The employee is already in contract on %s. "
            //                                      "Please select a date outside existing contracts",
            //                                      format_date_abbr(self.env, date)))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> CheckPresenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def _check_presence(self):
            // company = self.env.company
            // employees = self.env['hr.employee'].search([('company_id', '=', company.id)])
            // 
            // employees.write({
            //     'email_sent': False,
            //     'ip_connected': False,
            //     'manually_set_present': False,
            //     'manually_set_presence': False,
            // })
            // 
            // all_employees = employees
            // 
            // 
            // # Check on IP
            // if company.hr_presence_control_ip:
            //     ip_list = company.hr_presence_control_ip_list
            //     ip_list = ip_list.split(',') if ip_list else []
            //     ip_employees = self.env['hr.employee']
            //     for employee in employees:
            //         employee_ips = self.env['res.users.log'].sudo().search([
            //             ('create_uid', '=', employee.user_id.id),
            //             ('ip', '!=', False),
            //             ('create_date', '>=', Datetime.to_string(Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0)))]
            //         ).mapped('ip')
            //         if any(ip in ip_list for ip in employee_ips):
            //             ip_employees |= employee
            //     ip_employees.write({'ip_connected': True})
            //     employees = employees - ip_employees
            // 
            // # Check on sent emails
            // if company.hr_presence_control_email:
            //     email_employees = self.env['hr.employee']
            //     threshold = company.hr_presence_control_email_amount
            //     for employee in employees:
            //         sent_emails = self.env['mail.message'].search_count([
            //             ('author_id', '=', employee.user_id.partner_id.id),
            //             ('date', '>=', Datetime.to_string(Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0))),
            //             ('date', '<=', Datetime.to_string(Datetime.now()))])
            //         if sent_emails >= threshold:
            //             email_employees |= employee
            //     email_employees.write({'email_sent': True})
            //     employees = employees - email_employees
            // 
            // company.sudo().hr_presence_last_compute_date = Datetime.now()
            // 
            // for employee in all_employees:
            //     employee.hr_presence_state_display = employee.hr_presence_state
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

        protected async Task<HrEmployee> CheckSalaryDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_salary_distribution(self):
            // for employee in self:
            //     dist = employee.salary_distribution
            //     if not dist:
            //         continue
            // 
            //     total = 0
            //     check_total = False
            //     for ba_values in dist.values():
            //         amount = ba_values.get('amount')
            //         is_percentage = ba_values.get('amount_is_percentage', True)
            //         if is_percentage and (not isinstance(amount, (float, int)) or not (0 <= amount <= 100)):
            //             raise ValidationError(self.env._("Each amount percentage must be a number between 0 and 100."))
            //         if is_percentage:
            //             check_total = True
            //             total += amount
            // 
            //     if check_total and not float_is_zero(total - 100.0, precision_digits=4):
            //         raise ValidationError(self.env._("Total salary distribution on bank accounts must be exactly 100%."))
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

        protected async Task<HrEmployee> ComputeAllocationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_allocation_count(self):
            // # Don't get allocations that are expired
            // current_date = date.today()
            // data = self.env['hr.leave.allocation']._read_group([
            //     ('employee_id', 'in', self.ids),
            //     ('holiday_status_id.active', '=', True),
            //     ('holiday_status_id.requires_allocation', '=', 'yes'),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<=', current_date),
            //     '|',
            //     ('date_to', '=', False),
            //     ('date_to', '>=', current_date),
            // ], ['employee_id'], ['__count', 'number_of_days:sum'])
            // rg_results = {employee.id: (count, days) for employee, count, days in data}
            // for employee in self:
            //     count, days = rg_results.get(employee.id, (0, 0))
            //     employee.allocation_count = float_round(days, precision_digits=2)
            //     employee.allocations_count = count
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAllocationRemainingDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_allocation_remaining_display(self):
            // current_date = date.today()
            // allocations = self.env['hr.leave.allocation'].search([('employee_id', 'in', self.ids)])
            // leaves_taken = self._get_consumed_leaves(allocations.holiday_status_id)[0]
            // for employee in self:
            //     employee_remaining_leaves = 0
            //     employee_max_leaves = 0
            //     for leave_type in leaves_taken[employee]:
            //         if leave_type.requires_allocation == 'no' or leave_type.hide_on_dashboard or not leave_type.active:
            //             continue
            //         for allocation in leaves_taken[employee][leave_type]:
            //             if allocation and allocation.date_from <= current_date\
            //                     and (not allocation.date_to or allocation.date_to >= current_date):
            //                 virtual_remaining_leaves = leaves_taken[employee][leave_type][allocation]['virtual_remaining_leaves']
            //                 employee_remaining_leaves += virtual_remaining_leaves\
            //                     if leave_type.request_unit in ['day', 'half_day']\
            //                     else virtual_remaining_leaves / (employee.resource_calendar_id.hours_per_day or HOURS_PER_DAY)
            //                 employee_max_leaves += allocation.number_of_days
            //     employee.allocation_remaining_display = "%g" % float_round(employee_remaining_leaves, precision_digits=2)
            //     employee.allocation_display = "%g" % float_round(employee_max_leaves, precision_digits=2)
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
            // super(HrEmployee, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeBirthdayPublicDisplayStringInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_birthday_public_display_string(self):
            // for employee in self:
            //     if employee.birthday and employee.birthday_public_display:
            //         employee.birthday_public_display_string = datetime.strftime(employee.birthday, "%d %B")
            //     else:
            //         employee.birthday_public_display_string = "hidden"
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCertificationIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _compute_certification_ids(self):
            // for employee in self:
            //     employee.certification_ids = employee.employee_skill_ids.filtered('is_certification')
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeChildCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_child_count(self):
            // employee_read_group = self._read_group(
            //     [('parent_id', 'in', self.ids)],
            //     ['parent_id'],
            //     ['id:count'],
            // )
            // child_count_per_parent_id = dict(employee_read_group)
            // for employee in self:
            //     employee.child_count = child_count_per_parent_id.get(employee._origin, 0)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCoachInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_coach(self):
            // for version in self:
            //     manager = version.parent_id
            //     previous_manager = version._origin.parent_id
            //     if manager and (version.coach_id == previous_manager or not version.coach_id):
            //         version.coach_id = manager
            //     elif not version.coach_id:
            //         version.coach_id = False
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

        protected async Task<HrEmployee> ComputeCurrentEmployeeSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _compute_current_employee_skill_ids(self):
            // current_employee_skill_by_employee = self.employee_skill_ids.get_current_skills_by_employee()
            // for employee in self:
            //     employee.current_employee_skill_ids = current_employee_skill_by_employee[employee.id]
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

        protected async Task<HrEmployee> ComputeCurrentVersionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_current_version_id(self):
            // for employee in self:
            //     version = self.env['hr.version'].search(
            //         [('employee_id', 'in', employee.ids), ('date_version', '<=', fields.Date.today())],
            //         order='date_version desc',
            //         limit=1,
            //     )
            //     new_current_version = False
            //     if version:
            //         new_current_version = version
            //     elif employee.version_ids:
            //         new_current_version = employee.version_ids[0]
            //     # To not trigger computed properties if still the same version
            //     if employee.current_version_id != new_current_version:
            //         employee.current_version_id = new_current_version
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeDisplayCertificationPageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _compute_display_certification_page(self):
            // self.display_certification_page = bool(self.env['hr.skill.type'].search_count([('is_certification', '=', True)], limit=1))
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

        protected async Task<HrEmployee> ComputeEmployeeBadgesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py) ---
            // def _compute_employee_badges(self):
            // for employee in self:
            //     badge_ids = self.env['gamification.badge.user'].search([
            //         '|', ('employee_id', 'in', employee.ids),
            //              '&', ('employee_id', '=', False),
            //                   ('user_id', 'in', employee.user_id.ids)
            //     ])
            //     employee.has_badges = bool(badge_ids)
            //     employee.badge_ids = badge_ids
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

        protected async Task<HrEmployee> ComputeEmployeeGoalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py) ---
            // def _compute_employee_goals(self):
            // for employee in self:
            //     employee.goal_ids = self.env['gamification.goal'].search([
            //         ('user_id', '=', employee.user_id.id),
            //         ('challenge_id.challenge_category', '=', 'hr'),
            //     ])
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEquipmentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: hr_employee.py) ---
            // def _compute_equipment_count(self):
            // for employee in self:
            //     employee.equipment_count = len(employee.equipment_ids)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeExceptionalLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_exceptional_location_id(self):
            // today = fields.Date.today()
            // current_employee_locations = self.env['hr.employee.location'].search([
            //     ('employee_id', 'in', self.ids),
            //     ('date', '=', today),
            // ])
            // employee_work_locations = {l.employee_id.id: l.work_location_id for l in current_employee_locations}
            // 
            // for employee in self:
            //     employee.exceptional_location_id = employee_work_locations.get(employee.id, False)
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
            //     new_manager = employee.parent_id.user_id
            //     if new_manager and (employee.expense_manager_id == previous_manager or not employee.expense_manager_id):
            //         employee.expense_manager_id = new_manager
            //     elif not employee.expense_manager_id:
            //         employee.expense_manager_id = False
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasMultipleBankAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_has_multiple_bank_accounts(self):
            // for employee in self:
            //     if employee.bank_account_ids and len(employee.bank_account_ids) > 1:
            //         employee.has_multiple_bank_accounts = True
            //     else:
            //         employee.has_multiple_bank_accounts = False
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py) ---
            // def _compute_has_timesheet(self):
            // if self.ids:
            //     result = dict(self.env.execute_query(SQL(
            //         """ SELECT id, EXISTS(
            //                     SELECT 1 FROM account_analytic_line
            //                      WHERE project_id IS NOT NULL AND employee_id = e.id
            //                      LIMIT 1)
            //               FROM hr_employee e
            //              WHERE id in %s """,
            //         tuple(self.ids),
            //     )))
            // else:
            //     result = {}
            // 
            // for employee in self:
            //     employee.has_timesheet = result.get(employee._origin.id, False)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py) ---
            // def _compute_has_work_entries(self):
            // if self.ids:
            //     result = dict(self.env.execute_query(SQL(
            //         """ SELECT id, EXISTS(SELECT 1 FROM hr_work_entry WHERE employee_id = e.id LIMIT 1)
            //               FROM hr_employee e
            //              WHERE id in %s """,
            //         tuple(self.ids),
            //     )))
            // else:
            //     result = {}
            // 
            // for employee in self:
            //     employee.has_work_entries = result.get(employee._origin.id, False)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHoursLastMonthInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_hours_last_month(self):
            // """
            // Compute hours and overtime hours in the current month, if we are the 15th of october, will compute from 1 oct to 15 oct
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
            //     current_month_attendances = employee.attendance_ids.filtered(
            //         lambda att: att.check_in >= start_naive and att.check_out and att.check_out <= end_naive
            //     )
            //     hours = 0
            //     overtime_hours = 0
            //     for att in current_month_attendances:
            //         hours += att.worked_hours or 0
            //         overtime_hours += att.validated_overtime_hours or 0
            //     employee.hours_last_month = round(hours, 2)
            //     employee.hours_last_month_display = "%g" % employee.hours_last_month
            //     # overtime_adjustments = sum(
            //     #     ot.duration or 0
            //     #     for ot in employee.overtime_ids.filtered(
            //     #         lambda ot: ot.date >= start_tz.date() and ot.date <= end_tz.date() and ot.adjustment
            //     #     )
            //     # )
            //     employee.hours_last_month_overtime = round(overtime_hours, 2)
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

        protected async Task<HrEmployee> ComputeIsSubordinateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_is_subordinate(self):
            // subordinates = self.env.user.employee_id.subordinate_ids
            // if not subordinates:
            //     self.is_subordinate = False
            // else:
            //     for employee in self:
            //         employee.is_subordinate = employee in subordinates
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeIsTrustedBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_is_trusted_bank_account(self):
            // for employee in self:
            //     employee.is_trusted_bank_account = employee.primary_bank_account_id.allow_out_payment
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLastActivityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_last_activity(self):
            // for employee in self:
            //     tz = employee.tz
            //     # sudo: res.users - can access presence of accessible user
            //     if last_presence := employee.user_id.sudo().presence_ids.last_presence:
            //         last_activity_datetime = last_presence.replace(tzinfo=UTC).astimezone(timezone(tz)).replace(tzinfo=None)
            //         employee.last_activity = last_activity_datetime.date()
            //         if employee.last_activity == fields.Date.today():
            //             employee.last_activity_time = format_time(self.env, last_presence, time_format='short')
            //         else:
            //             employee.last_activity_time = False
            //     else:
            //         employee.last_activity = False
            //         employee.last_activity_time = False
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

        protected async Task<HrEmployee> ComputeLeaveManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_leave_manager(self):
            // for employee in self:
            //     previous_manager = employee._origin.parent_id.user_id
            //     manager = employee.parent_id.user_id
            //     if manager and employee.leave_manager_id == previous_manager or not employee.leave_manager_id:
            //         employee.leave_manager_id = manager
            //     elif not employee.leave_manager_id:
            //         employee.leave_manager_id = False
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLeaveStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_leave_status(self):
            // # Used SUPERUSER_ID to forcefully get status of other user's leave, to bypass record rule
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', 'in', self.ids),
            //     ('date_from', '<=', fields.Datetime.now()),
            //     ('date_to', '>=', fields.Datetime.now()),
            //     ('holiday_status_id.time_type', '=', 'leave'),
            //     ('state', '=', 'validate'),
            // ])
            // leave_data = {}
            // for holiday in holidays:
            //     leave_data[holiday.employee_id.id] = {}
            //     leave_data[holiday.employee_id.id]['leave_date_from'] = holiday.date_from.date()
            //     back_on = holiday.employee_id._get_first_working_interval(holiday.date_to)
            //     leave_data[holiday.employee_id.id]['leave_date_to'] = back_on.date() if back_on else None
            //     leave_data[holiday.employee_id.id]['current_leave_state'] = holiday.state
            // 
            // for employee in self:
            //     employee.leave_date_from = leave_data.get(employee.id, {}).get('leave_date_from')
            //     employee.leave_date_to = leave_data.get(employee.id, {}).get('leave_date_to')
            //     employee.current_leave_state = leave_data.get(employee.id, {}).get('current_leave_state')
            //     employee.is_absent = leave_data.get(employee.id) and leave_data.get(employee.id).get('current_leave_state') == 'validate'
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLegalNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
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

        protected async Task<HrEmployee> ComputeNewlyHiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_newly_hired(self):
            // new_hire_field = self._get_new_hire_field()
            // new_hire_date = fields.Datetime.now() - timedelta(days=90)
            // for employee in self:
            //     if not employee[new_hire_field]:
            //         employee.newly_hired = False
            //     elif not isinstance(employee[new_hire_field], datetime):
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date.date()
            //     else:
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePresenceIconInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // """
            // This method compute the state defining the display icon in the kanban view.
            // It can be overriden to add other possibilities, like time off or attendances recordings.
            // """
            // for employee in self:
            //     employee.hr_icon_display = 'presence_' + employee.hr_presence_state
            //     employee.show_hr_icon_display = bool(employee.user_id)
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // res = super()._compute_presence_icon()
            // # All employee must chek in or check out. Everybody must have an icon
            // for employee in self:
            //     employee.show_hr_icon_display = employee.company_id.hr_presence_control_attendance or bool(employee.user_id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // super()._compute_presence_icon()
            // employees_absent = self.filtered(
            //     lambda employee: employee.hr_presence_state != 'present' and employee.is_absent)
            // employees_absent.update({'hr_icon_display': 'presence_holiday_absent', 'show_hr_icon_display': True})
            // employees_present = self.filtered(
            //     lambda employee: employee.hr_presence_state == 'present' and employee.is_absent)
            // employees_present.update({'hr_icon_display': 'presence_holiday_present', 'show_hr_icon_display': True})
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_homeworking, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // super()._compute_presence_icon()
            // dayfield = self._get_current_day_location_field()
            // for employee in self:
            //     today_employee_location_id = employee.sudo().exceptional_location_id or employee[dayfield]
            //     if employee.is_absent:
            //         employee.hr_icon_display = f'presence_holiday_{"absent" if employee.hr_presence_state != "present" else "present"}'
            //         employee.show_hr_icon_display = True
            //     elif today_employee_location_id:
            //         employee.hr_icon_display = f'presence_{today_employee_location_id.location_type}'
            //         employee.show_hr_icon_display = True
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // super()._compute_presence_icon()
            // dayfield = self._get_current_day_location_field()
            // for employee in self:
            //     today_employee_location_id = employee.sudo().exceptional_location_id or employee[dayfield]
            //     if not today_employee_location_id:
            //         continue
            //     employee.hr_icon_display = f'presence_{today_employee_location_id.location_type}'
            //     employee.show_hr_icon_display = True
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePresenceStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // """
            // This method is overritten in several other modules which add additional
            // presence criterions. e.g. hr_attendance, hr_holidays
            // """
            // # sudo: res.users - can access presence of accessible user
            // employee_to_check_working = self.filtered(
            //     lambda e: (e.user_id.sudo().presence_ids.status or "offline") == "offline"
            // )
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in self:
            //     state = 'out_of_working_hour'
            //     if employee.company_id.sudo().hr_presence_control_login:
            //         # sudo: res.users - can access presence of accessible user
            //         presence_status = employee.user_id.sudo().presence_ids.status or "offline"
            //         if presence_status == "online":
            //             state = 'present'
            //         elif presence_status == "offline" and employee.id in working_now_list:
            //             state = 'absent'
            //     if not employee.active:
            //         state = 'archive'
            //     employee.hr_presence_state = state
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // """
            // Override to include checkin/checkout in the presence state
            // Attendance has the second highest priority after login
            // """
            // super()._compute_presence_state()
            // employees = self.filtered(lambda e: e.hr_presence_state != "present")
            // employee_to_check_working = self.filtered(lambda e: e.sudo().attendance_state == "checked_out"
            //                                                     and e.hr_presence_state == "out_of_working_hour")
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in employees:
            //     if employee.sudo().attendance_state == "checked_out" and employee.hr_presence_state == "out_of_working_hour" and \
            //             employee.id in working_now_list:
            //         employee.hr_presence_state = "absent"
            //     elif employee.sudo().attendance_state == "checked_in":
            //         employee.hr_presence_state = "present"
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // super()._compute_presence_state()
            // employees = self.filtered(lambda employee: employee.hr_presence_state != 'present' and employee.is_absent)
            // employees.update({'hr_presence_state': 'absent'})
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // super()._compute_presence_state()
            // company = self.env.company
            // working_now_list = self._get_employee_working_now()
            // for employee in self:
            //     if employee.manually_set_presence:
            //         employee.hr_presence_state = employee.hr_presence_state_display
            //         continue
            // 
            //     if not employee.company_id.hr_presence_control_email and not employee.company_id.hr_presence_control_ip:
            //         continue
            //     if company.hr_presence_last_compute_date and employee.id in working_now_list and \
            //             company.hr_presence_last_compute_date.day == fields.Datetime.now().day and \
            //             (employee.email_sent or employee.ip_connected or employee.manually_set_present):
            //         employee.hr_presence_state = 'present'
            //     elif employee.id in working_now_list and employee.is_absent and \
            //         not (employee.email_sent or employee.ip_connected or employee.manually_set_present):
            //         employee.hr_presence_state = 'absent'
            //     else:
            //         employee.hr_presence_state = 'out_of_working_hour'
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePrimaryBankAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_primary_bank_account_id(self):
            // for employee in self:
            //     if employee.bank_account_ids:
            //         primary_account = min(
            //             employee.bank_account_ids,
            //             key=lambda acc: employee.salary_distribution.get(str(acc.id), {}).get("sequence", float("inf")),
            //         )
            //         employee.primary_bank_account_id = primary_account
            //     else:
            //         employee.primary_bank_account_id = False
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

        protected async Task<HrEmployee> ComputeShowLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _compute_show_leaves(self):
            // show_leaves = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // for employee in self:
            //     if show_leaves or employee.user_id == self.env.user:
            //         employee.show_leaves = True
            //     else:
            //         employee.show_leaves = False
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

        protected async Task<HrEmployee> ComputeSubordinatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_subordinates(self):
            // for employee in self:
            //     employee.subordinate_ids = employee._get_subordinates()
            //     employee.child_all_count = len(employee.subordinate_ids)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeTotalOvertimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _compute_total_overtime(self):
            // mapped_validated_overtimes = dict(
            //     self.env['hr.attendance.overtime.line']._read_group(
            //     domain=[('status', '=', 'approved')],
            //     groupby=['employee_id'],
            //     aggregates=['manual_duration:sum']
            // ))
            // 
            // for employee in self:
            //     employee.total_overtime = mapped_validated_overtimes.get(employee, 0)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeVersionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_version_id(self):
            // context_version_id = self.env.context.get('version_id', False)
            // context_version = self.env['hr.version'].browse(context_version_id).exists() if context_version_id else self.env['hr.version']
            // 
            // for employee in self:
            //     if context_version.employee_id == self:
            //         version = context_version
            //     else:
            //         version = employee.current_version_id
            //     employee.version_id = version
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeVersionsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_versions_count(self):
            // version_count_per_employee = dict(
            //     self.env['hr.version']._read_group(
            //         [('employee_id', 'in', self.ids)],
            //         ['employee_id'],
            //         ['id:count'],
            //     ),
            // )
            // for employee in self:
            //     employee.versions_count = version_count_per_employee.get(employee, 0)
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkContactDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_contact_details(self):
            // for employee in self:
            //     if employee.work_contact_id:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_phone = employee.work_contact_id.phone
            //             employee.work_email = employee.work_contact_id.email
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkLocationNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_name(self):
            // for employee in self:
            //     employee.work_location_name = employee.version_id.work_location_id.name or None
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_work_location_name(self):
            // dayfield = self.env['hr.employee']._get_current_day_location_field()
            // for employee in self:
            //     current_location = employee.exceptional_location_id or employee[dayfield]
            //     employee.work_location_name = current_location.name
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkLocationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_type(self):
            // for employee in self:
            //     employee.work_location_type = employee.version_id.work_location_id.location_type or 'other'
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_work_location_type(self):
            // dayfield = self.env['hr.employee']._get_current_day_location_field()
            // for employee in self:
            //     current_location = employee.exceptional_location_id or employee[dayfield]
            //     employee.work_location_type = current_location.location_type
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
            // vals_per_company = defaultdict(list)
            // for idx, vals in enumerate(vals_list):
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            //     # Having one create per company is necessary to pass the company in the context to correctly set it in
            //     # the underlying version created by the framework
            //     vals_per_company[vals.get('company_id', self.env.company)].append((idx, vals))
            // index_per_employee = {}
            // employees = self.env['hr.employee']
            // for company, vals_list in vals_per_company.items():
            //     idxs, vals_list = zip(*vals_list)
            //     new_employees = super(HrEmployee, self.with_company(company)).create(vals_list)
            //     index_per_employee.update(dict(zip(new_employees, idxs)))
            //     employees |= new_employees
            // # As we do a custom batch by company, we must reorder the records to respect the original order.
            // employees = employees.sorted(key=lambda employee: index_per_employee[employee])
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
            // employees.invalidate_recordset()
            // return employees
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // officer_group = self.env.ref('hr_attendance.group_hr_attendance_officer', raise_if_not_found=False)
            // group_updates = []
            // for vals in vals_list:
            //     if officer_group and vals.get('attendance_manager_id'):
            //         group_updates.append((4, vals['attendance_manager_id']))
            // if group_updates:
            //     officer_group.sudo().write({'user_ids': group_updates})
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // if self.env.context.get('salary_simulation'):
            //     return super().create(vals_list)
            // approver_group = self.env.ref('hr_holidays.group_hr_holidays_responsible', raise_if_not_found=False)
            // group_updates = []
            // for vals in vals_list:
            //     if 'parent_id' in vals:
            //         manager = self.env['hr.employee'].browse(vals['parent_id']).user_id
            //         vals['leave_manager_id'] = vals.get('leave_manager_id', manager.id)
            //     if approver_group and vals.get('leave_manager_id'):
            //         group_updates.append((4, vals['leave_manager_id']))
            // if group_updates:
            //     approver_group.sudo().write({'user_ids': group_updates})
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // employees = super().create(vals_list)
            // for employee_sudo in employees.sudo():
            //     if employee_sudo.applicant_ids:
            //         employee_sudo.applicant_ids._message_log_with_view(
            //             'hr_recruitment.applicant_hired_template',
            //             render_values={'applicant': employee_sudo.applicant_ids}
            //         )
            // return employees
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     vals_emp_skill = vals.pop('current_employee_skill_ids', [])\
            //         + vals.pop('certification_ids', []) + vals.get('employee_skill_ids', [])
            //     vals['employee_skill_ids'] = self.env['hr.employee.skill']._get_transformed_commands(vals_emp_skill, self)
            // return super().create(vals_list)
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

        public async Task<HrEmployee> CreateContractAsync(Guid id, HrEmployeeCreateContractRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_contract(self, date):
            // # Here we can assume that there is no existing contract on the date given
            // self.ensure_one()
            // if date and isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // 
            // contracts = self._get_contract_versions(date)[self.id]
            // future_contract_dates = [d for d in list(contracts.keys()) if d > date]
            // new_contract_date_end = min(future_contract_dates) + relativedelta(days=-1) if future_contract_dates else False
            // 
            // # There is already a version but with no contract defined on it so we simply write on it the dates
            // if version_same_date := self.version_ids.filtered(lambda v: v.date_version == date):
            //     version_same_date.write({
            //         'contract_date_start': date,
            //         'contract_date_end': new_contract_date_end
            //     })
            //     return version_same_date
            // 
            // return self.create_version({
            //     'date_version': date,
            //     'contract_date_start': date,
            //     'contract_date_end': new_contract_date_end
            // })
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     [('calendar_id', '=', False), ('resource_id', '=', False), ('date_from', '>=', today)],
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

        protected async Task<HrEmployee> CreateInternalAsync(object data_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create(self, data_list):
            // versions = [vals['stored'].pop('version_id', None) for vals in data_list]
            // result = super()._create(data_list)
            // for (employee, version_id, vals) in zip(result, versions, data_list):
            //     version = self.env['hr.version'].browse(version_id)
            //     version.employee_id = employee.id
            //     version.write({**vals.get('inherited', {})['hr.version'], 'employee_id': employee.id})
            // return result
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
            //     'context': {
            //         **self.env.context,
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> CreateUsersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users(self):
            // def _get_user_creation_notification_action(message, message_type, next_action):
            //     return {
            //             'type': 'ir.actions.client',
            //             'tag': 'display_notification',
            //             'params': {
            //                 'title': self.env._("User Creation Notification"),
            //                 'type': message_type,
            //                 'message': message,
            //                 'next': next_action
            //             }
            //         }
            // 
            // employee_emails = [
            //     normalized_email
            //     for employee in self
            //     for normalized_email in tools.mail.email_normalize_all(employee.work_email)
            // ]
            // conflicting_users = self.env['res.users']
            // if employee_emails:
            //     conflicting_users = self.env['res.users'].search([
            //         '|', ('email_normalized', 'in', employee_emails),
            //         ('login', 'in', employee_emails),
            //     ])
            // old_users = []
            // new_users = []
            // users_without_emails = []
            // users_with_invalid_emails = []
            // users_with_existing_email = []
            // for employee in self:
            //     if employee.user_id:
            //         old_users.append(employee.name)
            //         continue
            //     if not employee.work_email:
            //         users_without_emails.append(employee.name)
            //         continue
            //     if not tools.email_normalize(employee.work_email):
            //         users_with_invalid_emails.append(employee.name)
            //         continue
            //     if email_normalize(employee.work_email) in conflicting_users.mapped('email_normalized'):
            //         users_with_existing_email.append(employee.name)
            //         continue
            //     new_users.append({
            //         'create_employee_id': employee.id,
            //         'name': employee.name,
            //         'phone': employee.work_phone,
            //         'login': tools.email_normalize(employee.work_email),
            //         'partner_id': employee.work_contact_id.id,
            //     })
            // 
            // next_action = {'type': 'ir.actions.act_window_close'}
            // if new_users:
            //     self.env['res.users'].create(new_users)
            //     message = _('Users %s creation successful', ', '.join([user['name'] for user in new_users]))
            //     next_action = _get_user_creation_notification_action(message, 'success', {
            //         "type": "ir.actions.client",
            //         "tag": "soft_reload",
            //         "params": {"next": next_action},
            //     })
            // 
            // if old_users:
            //     message = _('User already exists for Those Employees %s', ', '.join(old_users))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // if users_without_emails:
            //     message = _("You need to set the work email address for %s", ', '.join(users_without_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_invalid_emails:
            //     message = _("You need to set a valid work email address for %s", ', '.join(users_with_invalid_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_existing_email:
            //     message = _('User already exists with the same email for Employees %s', ', '.join(users_with_existing_email))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // return next_action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> CreateUsersConfirmationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users_confirmation(self):
            // raise RedirectWarning(
            //         message=_("You're about to invite new users. %s users will be created with the default user template's rights. "
            //         "Adding new users may increase your subscription cost. Do you wish to continue?", len(self.ids)),
            //         action=self.env.ref('hr.action_hr_employee_create_users').id,
            //         button_text=_('Confirm'),
            //         additional_context={
            //             'selected_ids': self.ids,
            //         },
            //     )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> CreateVersionAsync(Guid id, HrEmployeeCreateVersionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_version(self, values):
            // self.ensure_one()
            // 
            // date = values.get('date_version', False)
            // if not date:
            //     raise ValueError("date_version is required")
            // 
            // if isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // elif isinstance(date, datetime):
            //     date = date.date()
            // 
            // version_to_copy = self._get_version(date)
            // if not version_to_copy:
            //     version_to_copy = self.env['hr.version'].search([('employee_id', '=', self.id)], limit=1)
            // if version_to_copy.date_version == date:
            //     return version_to_copy
            // 
            // date_from, date_to = self.sudo()._get_contract_dates(date)
            // contract_date_start = values.get('contract_date_start', date_from)
            // contract_date_end = values.get('contract_date_end', date_to)
            // employee_id = values.get('employee_id', self.id)
            // 
            // if isinstance(contract_date_start, str):
            //     contract_date_start = fields.Date.to_date(contract_date_start)
            // if isinstance(contract_date_end, str):
            //     contract_date_end = fields.Date.to_date(contract_date_end)
            // 
            // if contract_date_start == date_from and contract_date_end != date_to:
            //     versions_sudo_to_sync = self.env['hr.version'].with_context(sync_contract_dates=True).sudo().search([
            //         ('employee_id', '=', employee_id),
            //         ('contract_date_start', '=', date_from),
            //     ])
            //     if versions_sudo_to_sync:
            //         versions_sudo_to_sync.write({
            //             'contract_date_end': contract_date_end,
            //         })
            // self.check_access('write')
            // version_to_copy.check_access('write')
            // # to be sure even if the user has no access to certain fields, we can still copy the verison without any issues.
            // copy_vals = {
            //     'date_version': date,
            //     'employee_id': employee_id,
            //     'contract_date_start': contract_date_start,
            //     'contract_date_end': contract_date_end,
            // }
            // if 'active' in values:
            //     copy_vals['active'] = values['active']
            // if calendar_id := values.get('resource_calendar_id'):
            //     copy_vals['resource_calendar_id'] = calendar_id
            // # apply the changes on the new versions.
            // new_version_vals = {
            //     field_name: field_value
            //     for field_name, field_value in values.items()
            //     if field_name not in copy_vals
            // }
            // version_fields = self.env['hr.version']._fields
            // copy_vals = {
            //     k: v
            //     for k, v in version_to_copy.sudo().copy_data()[0].items()
            //     if not (k in new_version_vals and version_fields[k].type in ['one2many', 'many2many'])
            // } | copy_vals
            // new_version = self.env['hr.version'].sudo().create(copy_vals).sudo(False)
            // with self.env.protecting([f for f_name, f in version_fields.items() if f_name not in new_version_vals and f.copy], new_version):
            //     properties_fields_vals = {
            //         field_name: field_value
            //         for field_name, field_value in copy_vals.items()
            //         if version_fields[field_name].type == 'properties' and field_name not in new_version_vals
            //     }
            //     if properties_fields_vals:  # make sure properties vals are correctly copied.
            //         new_version.sudo().write(properties_fields_vals)
            //     new_version.write(new_version_vals)
            // return new_version
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py) ---
            // def create_version(self, values):
            // new_version = super().create_version(values)
            // new_version.update({
            //     'date_generated_from': fields.Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0),
            //     'date_generated_to': fields.Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0),
            // })
            // return new_version
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> CreateWorkContactsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create_work_contacts(self):
            // if any(employee.work_contact_id for employee in self):
            //     raise UserError(_('Some employee already have a work contact'))
            // work_contacts = self.env['res.partner'].create([{
            //     'email': employee.work_email,
            //     'phone': employee.work_phone,
            //     'name': employee.name,
            //     'image_1920': employee.image_1920,
            //     'company_id': employee.company_id.id
            // } for employee in self])
            // for employee, work_contact in zip(self, work_contacts):
            //     employee.work_contact_id = work_contact
            */
            return default;
        }

        protected async Task<HrEmployee> CronUpdateCurrentVersionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_update_current_version_id(self):
            // self.search([])._compute_current_version_id()
            */
            return default;
        }

        public override async Task<HrEmployee> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_employee.py) ---
            // def default_get(self, fields):
            // result = super().default_get(fields)
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
            // future_timesheets = self.env['account.analytic.line'].sudo().search([('global_leave_id', '!=', False), ('date', '>=', fields.Date.today()), ('employee_id', 'in', self.ids)])
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
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            //     if not valid_versions:
            //         calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //         return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            //     employee_tz = timezone(self.tz) if self.tz else None
            //     duration_data = Intervals()
            //     for version in valid_versions:
            //         version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //         version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //         calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //         lunch_intervals = calendar._attendance_intervals_batch(
            //             max(start, version_start),
            //             min(stop, version_end),
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
            // def fetch(self, field_names=None):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // # make sure all related fields from employee are in cache
            // for field_name in field_names:
            //     public_field = self.env['hr.employee.public']._fields[field_name]
            //     private_field = self.env['hr.employee']._fields[field_name]
            //     if (public_field.related and public_field.related_field.model_name == 'hr.employee'
            //             or private_field.inherited and private_field.inherited_field.model_name == 'hr.version'):
            //         public.mapped(field_name)
            // self._copy_cache_from(public, field_names)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string field_expr, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _field_to_sql(self, alias: str, field_expr: str, query: (Query | None) = None) -> SQL:
            // """This is required to search for the related fields of version_id as version_id is not stored"""
            // if field_expr == 'version_id':
            //     field_expr = 'current_version_id'
            // return super()._field_to_sql(alias, field_expr, query)
            */
            return default;
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
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py) ---
            // def generate_work_entries(self, date_start, date_stop, force=False):
            // date_start = fields.Date.to_date(date_start)
            // date_stop = fields.Date.to_date(date_stop)
            // 
            // if self:
            //     versions = self._get_versions_with_contract_overlap_with_period(date_start, date_stop)
            // else:
            //     versions = self._get_all_versions_with_contract_overlap_with_period(date_start, date_stop)
            // return versions.generate_work_entries(date_start, date_stop, force=force)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetAccountsWithFixedAllocationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_accounts_with_fixed_allocations(self):
            // self.ensure_one()
            // return self.bank_account_ids.filtered(
            //     lambda a: not self.salary_distribution.get(str(a.id), {}).get('amount_is_percentage', True)
            // )
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

        protected async Task<HrEmployee> GetAllContractDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_contract_dates(self):
            // """
            // Return a list of intervals (date_from, date_to) where the employee is in contract.
            // For a permanent contract, the interval is (date_from, False).
            // """
            // self.ensure_one()
            // return self.env['hr.version']._read_group(
            //     [('employee_id', '=', self.id), ('contract_date_start', '!=', False)],
            //     ['contract_date_start:day', 'contract_date_end:day'])
            */
            return default;
        }

        protected async Task<HrEmployee> GetAllVersionsWithContractOverlapWithPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of all employees between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // all_employees = self.search(['|', ('active', '=', True), ('active', '=', False)])
            // return all_employees._get_versions_with_contract_overlap_with_period(date_from, date_to)
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

        public async Task<HrEmployee> GetAvatarCardDataAsync(Guid id, HrEmployeeGetAvatarCardDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_avatar_card_data(self, fields):
            // return self.read(fields)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetBankAccountSalaryAllocationAsync(Guid id, HrEmployeeGetBankAccountSalaryAllocationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_bank_account_salary_allocation(self, account_id):
            // ba_info = self.salary_distribution.get(str(account_id), {})
            // return ba_info.get('amount', 0), ba_info.get('amount_is_percentage')
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
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     return calendar.with_context(employee_timezone=employee_tz).get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            // duration_data = {'days': 0, 'hours': 0}
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     version_duration_data = calendar\
            //         .with_context(employee_timezone=employee_tz)\
            //         .get_work_duration_data(
            //             max(date_from, version_start),
            //             min(date_to, version_end),
            //             domain=[('company_id', 'in', [False, version.company_id.id])])
            //     duration_data['days'] += version_duration_data['days']
            //     duration_data['hours'] += version_duration_data['hours']
            // return duration_data
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarPeriodsInternalAsync(object start, object stop, object check_contract)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_periods(self, start, stop, check_contract=True):
            // """
            // :param datetime start: the start of the period
            // :param datetime stop: the stop of the period
            // """
            // return self.sudo()._get_version_periods(start, stop, 'resource_calendar_id', check_contract)
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarTzBatchInternalAsync(object dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_tz_batch(self, dt=None):
            // """ Return a mapping { employee id : employee's effective schedule's (at dt) timezone }
            // """
            // employees_by_id = self.grouped('id')
            // if not dt:
            //     calendars = self._get_calendars()
            //     return {
            //         emp_id: calendar.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, calendar in calendars.items()
            //     }
            // 
            // employees_by_tz = self.grouped(lambda emp: emp._get_tz())
            // 
            // employee_timezones = {}
            // for tz, employee_ids in employees_by_tz.items():
            //     date_at = timezone(tz).localize(dt).date()
            //     calendars = self._get_calendars(date_at)
            //     employee_timezones |= {
            //         emp_id: cal.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, cal in calendars.items()
            //     }
            // return employee_timezones
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarsInternalAsync(object date_from)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendars(self, date_from=None):
            // res = super()._get_calendars(date_from=date_from)
            // if not date_from:
            //     return res
            // 
            // date_from = fields.Date.to_date(date_from)
            // for employee in self:
            //     employee_versions_sudo = employee.sudo().version_ids.filtered(lambda v: v._is_in_contract(date_from))
            //     if employee_versions_sudo:
            //         res[employee.id] = employee_versions_sudo[0].resource_calendar_id.sudo(False)
            // return res
            */
            return default;
        }

        protected async Task<HrEmployee> GetCertificateSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_certificate_selection(self):
            // return [
            //     ('graduate', self.env._('Graduate')),
            //     ('bachelor', self.env._('Bachelor')),
            //     ('master', self.env._('Master')),
            //     ('doctor', self.env._('Doctor')),
            //     ('other', self.env._('Other')),
            // ]
            */
            return default;
        }

        protected async Task<HrEmployee> GetConsumedLeavesInternalAsync(object leave_types, object target_date, object ignore_future)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_consumed_leaves(self, leave_types, target_date=False, ignore_future=False):
            // employees = self or self._get_contextual_employee()
            // leaves_domain = [
            //     ('holiday_status_id', 'in', leave_types.ids),
            //     ('employee_id', 'in', employees.ids),
            //     ('state', 'in', ['confirm', 'validate1', 'validate']),
            // ]
            // if self.env.context.get('ignored_leave_ids'):
            //     leaves_domain.append(('id', 'not in', self.env.context.get('ignored_leave_ids')))
            // 
            // if not target_date:
            //     target_date = fields.Date.today()
            // if ignore_future:
            //     leaves_domain.append(('date_from', '<=', target_date))
            // leaves = self.env['hr.leave'].search(leaves_domain)
            // leaves_per_employee_type = defaultdict(lambda: defaultdict(lambda: self.env['hr.leave']))
            // for leave in leaves:
            //     leaves_per_employee_type[leave.employee_id][leave.holiday_status_id] |= leave
            // 
            // allocations = self.env['hr.leave.allocation'].with_context(active_test=False).search([
            //     ('employee_id', 'in', employees.ids),
            //     ('holiday_status_id', 'in', leave_types.ids),
            //     ('state', '=', 'validate'),
            // ])
            // allocations_per_employee_type = defaultdict(lambda: defaultdict(lambda: self.env['hr.leave.allocation']))
            // for allocation in allocations:
            //     allocations_per_employee_type[allocation.employee_id][allocation.holiday_status_id] |= allocation
            // 
            // # _get_consumed_leaves returns a tuple of two dictionnaries.
            // # 1) The first is a dictionary to map the number of days/hours of leaves taken per allocation
            // # The structure is the following:
            // # - KEYS:
            // # allocation_leaves_consumed
            // #  |--employee_id
            // #      |--holiday_status_id
            // #          |--allocation
            // #              |--virtual_leaves_taken
            // #              |--leaves_taken
            // #              |--virtual_remaining_leaves
            // #              |--remaining_leaves
            // #              |--max_leaves
            // #              |--accrual_bonus
            // # - VALUES:
            // # Integer representing the number of (virtual) remaining leaves, (virtual) leaves taken or max leaves
            // # for each allocation.
            // # leaves_taken and remaining_leaves only take into account validated leaves, while the "virtual" equivalent are
            // # also based on leaves in "confirm" or "validate1" state.
            // # Accrual bonus gives the amount of additional leaves that will have been granted at the given
            // # target_date in comparison to today.
            // # The unit is in hour or days depending on the leave type request unit
            // # 2) The second is a dictionary mapping the remaining days per employee and per leave type that are either
            // # not taken into account by the allocations, mainly because accruals don't take future leaves into account.
            // # This is used to warn the user if the leaves they takes bring them above their available limit.
            // # - KEYS:
            // # allocation_leaves_consumed
            // #  |--employee_id
            // #      |--holiday_status_id
            // #          |--to_recheck_leaves
            // #          |--excess_days
            // #          |--exceeding_duration
            // # - VALUES:
            // # "to_recheck_leaves" stores every leave that is not yet taken into account by the "allocation_leaves_consumed" dictionary.
            // # "excess_days" represents the excess amount that somehow isn't taken into account by the first dictionary.
            // # "exceeding_duration" sum up the to_recheck_leaves duration and compares it to the maximum allocated for that time period.
            // allocations_leaves_consumed = defaultdict(lambda: defaultdict(lambda: defaultdict(lambda: defaultdict(lambda: 0))))
            // 
            // to_recheck_leaves_per_leave_type = defaultdict(lambda:
            //     defaultdict(lambda: {
            //         'excess_days': defaultdict(lambda: {
            //             'amount': 0,
            //             'is_virtual': True,
            //         }),
            //         'exceeding_duration': 0,
            //         'to_recheck_leaves': self.env['hr.leave']
            //     })
            // )
            // for allocation in allocations:
            //     allocation_data = allocations_leaves_consumed[allocation.employee_id][allocation.holiday_status_id][allocation]
            //     future_leaves = 0
            //     if allocation.allocation_type == 'accrual':
            //         future_leaves = allocation._get_future_leaves_on(target_date)
            //     max_leaves = allocation.number_of_hours_display\
            //         if allocation.holiday_status_id.request_unit in ['hour']\
            //         else allocation.number_of_days_display
            //     max_leaves += future_leaves
            //     allocation_data.update({
            //         'max_leaves': max_leaves,
            //         'accrual_bonus': future_leaves,
            //         'virtual_remaining_leaves': max_leaves,
            //         'remaining_leaves': max_leaves,
            //         'leaves_taken': 0,
            //         'virtual_leaves_taken': 0,
            //     })
            // 
            // for employee in employees:
            //     for leave_type in leave_types:
            //         allocations_with_date_to = self.env['hr.leave.allocation']
            //         allocations_without_date_to = self.env['hr.leave.allocation']
            //         for leave_allocation in allocations_per_employee_type[employee][leave_type]:
            //             if leave_allocation.date_to:
            //                 allocations_with_date_to |= leave_allocation
            //             else:
            //                 allocations_without_date_to |= leave_allocation
            //         sorted_leave_allocations = allocations_with_date_to.sorted(key='date_to') + allocations_without_date_to
            // 
            //         if leave_type.request_unit in ['day', 'half_day']:
            //             leave_duration_field = 'number_of_days'
            //             leave_unit = 'days'
            //         else:
            //             leave_duration_field = 'number_of_hours'
            //             leave_unit = 'hours'
            // 
            //         leave_type_data = allocations_leaves_consumed[employee][leave_type]
            //         for leave in leaves_per_employee_type[employee][leave_type].sorted('date_from'):
            //             leave_duration = leave[leave_duration_field]
            //             skip_excess = False
            // 
            //             if leave.date_from.date() > target_date and sorted_leave_allocations.filtered(lambda a:
            //                 a.allocation_type == 'accrual' and
            //                 (not a.date_to or a.date_to >= target_date) and
            //                 a.date_from <= leave.date_to.date()
            //             ):
            //                 to_recheck_leaves_per_leave_type[employee][leave_type]['to_recheck_leaves'] |= leave
            //                 skip_excess = True
            //                 continue
            // 
            //             if leave_type.requires_allocation:
            //                 for allocation in sorted_leave_allocations:
            //                     # We don't want to include future leaves linked to accruals into the total count of available leaves.
            //                     # However, we'll need to check if those leaves take more than what will be accrued in total of those days
            //                     # to give a warning if the total exceeds what will be accrued.
            //                     if allocation.date_from > leave.date_to.date() or (allocation.date_to and allocation.date_to < leave.date_from.date()):
            //                         continue
            //                     interval_start = max(
            //                         leave.date_from,
            //                         datetime.combine(allocation.date_from, time.min)
            //                     )
            //                     interval_end = min(
            //                         leave.date_to,
            //                         datetime.combine(allocation.date_to, time.max)
            //                         if allocation.date_to else leave.date_to
            //                     )
            //                     duration = leave[leave_duration_field]
            //                     if leave.date_from != interval_start or leave.date_to != interval_end:
            //                         duration_info = employee._get_calendar_attendances(interval_start.replace(tzinfo=pytz.UTC), interval_end.replace(tzinfo=pytz.UTC))
            //                         duration = duration_info['hours' if leave_unit == 'hours' else 'days']
            //                     max_allowed_duration = min(
            //                         duration,
            //                         leave_type_data[allocation]['virtual_remaining_leaves']
            //                     )
            // 
            //                     if not max_allowed_duration:
            //                         continue
            // 
            //                     allocated_time = min(max_allowed_duration, leave_duration)
            //                     leave_type_data[allocation]['virtual_leaves_taken'] += allocated_time
            //                     leave_type_data[allocation]['virtual_remaining_leaves'] -= allocated_time
            //                     if leave.state == 'validate':
            //                         leave_type_data[allocation]['leaves_taken'] += allocated_time
            //                         leave_type_data[allocation]['remaining_leaves'] -= allocated_time
            // 
            //                     leave_duration -= allocated_time
            //                     if not leave_duration:
            //                         break
            //                 if round(leave_duration, 2) > 0 and not skip_excess:
            //                     to_recheck_leaves_per_leave_type[employee][leave_type]['excess_days'][leave.date_to.date()] = {
            //                         'amount': leave_duration,
            //                         'is_virtual': leave.state != 'validate',
            //                         'leave_id': leave.id,
            //                     }
            //             else:
            //                 if leave_unit == 'hours':
            //                     allocated_time = leave.number_of_hours
            //                 else:
            //                     allocated_time = leave.number_of_days
            //                 leave_type_data[False]['virtual_leaves_taken'] += allocated_time
            //                 leave_type_data[False]['virtual_remaining_leaves'] = 0
            //                 leave_type_data[False]['remaining_leaves'] = 0
            //                 if leave.state == 'validate':
            //                     leave_type_data[False]['leaves_taken'] += allocated_time
            // for employee in to_recheck_leaves_per_leave_type:
            //     for leave_type in to_recheck_leaves_per_leave_type[employee]:
            //         content = to_recheck_leaves_per_leave_type[employee][leave_type]
            //         consumed_content = allocations_leaves_consumed[employee][leave_type]
            //         if content['to_recheck_leaves']:
            //             date_to_simulate = max(content['to_recheck_leaves'].mapped('date_from')).date()
            //             latest_accrual_bonus = 0
            //             date_accrual_bonus = 0
            //             virtual_remaining = 0
            //             additional_leaves_duration = 0
            //             for allocation in consumed_content:
            //                 latest_accrual_bonus += allocation and allocation._get_future_leaves_on(date_to_simulate)
            //                 date_accrual_bonus += consumed_content[allocation]['accrual_bonus']
            //                 virtual_remaining += consumed_content[allocation]['virtual_remaining_leaves']
            //             for leave in content['to_recheck_leaves']:
            //                 additional_leaves_duration += leave.number_of_hours if leave_type.request_unit == 'hour' else leave.number_of_days
            //             latest_remaining = virtual_remaining - date_accrual_bonus + latest_accrual_bonus
            //             content['exceeding_duration'] = round(min(0, latest_remaining - additional_leaves_duration), 2)
            // 
            // return (allocations_leaves_consumed, to_recheck_leaves_per_leave_type)
            */
            return default;
        }

        protected async Task<HrEmployee> GetContextualEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_contextual_employee(self):
            // ctx = self.env.context
            // if self.env.context.get('employee_id') is not None:
            //     return self.browse(ctx.get('employee_id'))
            // if self.env.context.get('default_employee_id') is not None:
            //     return self.browse(ctx.get('default_employee_id'))
            // return self.env.user.employee_id
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractDatesInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_dates(self, date):
            // """
            // Return a tuple (date_from, date_to) of the contract at the date given.
            // (False, False) if the employee is not in contract at that date.
            // """
            // self.ensure_one()
            // for date_from, date_to in self._get_all_contract_dates():
            //     if date_from <= date and (date_to is False or date_to >= date):
            //         return date_from, date_to
            // return False, False
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractVersionsInternalAsync(object date_start, object date_end, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_versions(self, date_start=None, date_end=None, domain=None):
            // """
            // Retrieves contract versions for employees within the specified date range and
            // domain. The function constructs a dynamic domain to filter contracts based on
            // the provided arguments and retrieves grouped results. The grouping ensures
            // organization by employee and date, and the results are stored in a structured
            // format for ease of use.
            // 
            // Args:
            //     date_start (datetime.date | None): The start date for filtering contracts.
            //     date_end (datetime.date | None): The end date for filtering contracts.
            //     domain (list | None): Additional domain constraints for filtering.
            // 
            // Returns:
            //     dict: A dictionary where keys are employee IDs and values are lists of
            //           contract version records organized by contract date start and date
            //           range.
            // """
            // version_domain = Domain('contract_date_start', '!=', False)
            // if self.ids:
            //     version_domain &= Domain('employee_id', 'in', self.ids)
            // elif not any(self._ids):  # onchange
            //     version_domain &= Domain('employee_id', 'in', self._origin.ids)
            // if date_start:
            //     version_domain &= Domain('contract_date_end', '=', False) | Domain('contract_date_end', '>=', date_start)
            // if date_end:
            //     version_domain &= Domain('contract_date_start', '<=', date_end)
            // if domain:
            //     version_domain &= domain
            // all_versions = self.env['hr.version']._read_group(
            //     domain=version_domain,
            //     groupby=['employee_id', 'date_version:day'],
            //     aggregates=['id:recordset'],
            // )
            // contract_versions_by_employee = defaultdict(lambda: defaultdict(lambda: self.env["hr.version"]))
            // for employee, _date_version, version in all_versions:
            //     first_version = next(iter(version), version)
            //     contract_versions_by_employee[employee.id][first_version.contract_date_start] |= version
            // return contract_versions_by_employee
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractsInternalAsync(object date_start, object date_end, object use_latest_version, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contracts(self, date_start=None, date_end=None, use_latest_version=True, domain=None):
            // """
            // Retrieve the contracts for employees within a specified date range and based
            // on specified criteria, such as domain filtering and version selection.
            // 
            // This method is used to collect and organize employee contracts based on their
            // versions, date ranges, and other specified options. The resulting contracts are
            // grouped by employee, and their selection logic depends on whether the latest
            // version should be used or not. It supports flexibility in contract retrieval by
            // allowing optional filters for date range and domain.
            // 
            // Args:
            //     date_start (Optional[datetime.date]): The start date to filter the contracts
            //         by. If provided, only contract versions <= this date are considered
            //         based on the selection logic.
            //     date_end (Optional[datetime.date]): The end date to filter the contracts by.
            //         Only contract versions within the range will be retrieved. Defaults to
            //         None if not specified.
            //     domain (Optional[dict]): A dictionary representing additional filters or
            //         constraints to apply to the contract versions retrieved. Defaults to
            //         None.
            //     use_latest_version (bool): Indicates whether to retrieve the version
            //     effective at the end of the contract (or before the date_end) for each employee (True) or
            //     at the start of the contract (before the date_start) (False). Defaults to True.
            // 
            // Returns:
            //     collections.defaultdict: A dictionary mapping each employee's identifier
            //     (employee.id) to a set of their corresponding contracts. Each set contains
            //     version records retrieved and filtered based on the specified criteria.
            // """
            // contract_versions_by_employee = self._get_contract_versions(date_start, date_end, domain)
            // contracts_by_employee = defaultdict(lambda: self.env["hr.version"])
            // for employee_id in contract_versions_by_employee:
            //     for contract_versions in contract_versions_by_employee[employee_id].values():
            //         effective_date = date_end if use_latest_version else date_start
            //         if use_latest_version:
            //             if effective_date:
            //                 correct_versions = contract_versions.filtered(lambda v: v.date_version <= effective_date)
            //                 contracts_by_employee[employee_id] |= correct_versions[-1] if correct_versions else contract_versions[0]
            //             else:
            //                 contracts_by_employee[employee_id] |= contract_versions[-1] if use_latest_version else contract_versions[0]
            // return contracts_by_employee
            */
            return default;
        }

        protected async Task<HrEmployee> GetCurrentDayLocationFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _get_current_day_location_field(self):
            // return DAYS[fields.Date.today().weekday()]
            */
            return default;
        }

        protected async Task<HrEmployee> GetDepartureDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_departure_date(self):
            // # Primarily used in the archive wizard
            // # to pick a good default for the departure date
            // self.ensure_one()
            // if self.date_end and self.date_end < fields.Date.today():
            //     return self.departure_date
            // return False
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

        protected async Task<HrEmployee> GetEmployeeWorkingNowInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_working_now(self):
            // """ Sudo needed to get resource_calendar_id as its normally only accessible by hr_users on version model
            // (accessible on employee by inherits)."""
            // working_now = []
            // # We loop over all the employee tz and the resource calendar_id to detect working hours in batch.
            // all_employee_tz = set(self.mapped('tz'))
            // for tz in all_employee_tz:
            //     employee_ids = self.filtered(lambda e: e.tz == tz)
            //     resource_calendar_ids = employee_ids.sudo().mapped('resource_calendar_id')
            //     for calendar_id in resource_calendar_ids:
            //         res_employee_ids = employee_ids.sudo().filtered(lambda e: e.resource_calendar_id.id == calendar_id.id)
            //         start_dt = fields.Datetime.now()
            //         stop_dt = start_dt + timedelta(hours=1)
            //         from_datetime = utc.localize(start_dt).astimezone(timezone(tz or 'UTC'))
            //         to_datetime = utc.localize(stop_dt).astimezone(timezone(tz or 'UTC'))
            //         # Getting work interval of the first is working. Functions called on resource_calendar_id
            //         # are waiting for singleton
            //         work_interval = res_employee_ids[0].resource_calendar_id._work_intervals_batch(from_datetime, to_datetime)[False]
            //         # Employee that is not supposed to work have empty items.
            //         if len(work_interval._items) > 0:
            //             # The employees should be working now according to their work schedule
            //             working_now += res_employee_ids.ids
            // return working_now
            */
            return default;
        }

        protected async Task<HrEmployee> GetExpectedAttendancesInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     calendar_intervals = calendar._work_intervals_batch(
            //         date_from,
            //         date_to,
            //         tz=employee_tz,
            //         resources=self.resource_id,
            //         compute_leaves=True,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            //     return calendar_intervals
            // duration_data = Intervals()
            // version_prev = datetime.combine(valid_versions[0].date_start, time.min, employee_tz)
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     contract_start = datetime.combine(version.contract_date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     start_date = version_start if version_prev < version_start else contract_start
            //     version_intervals = calendar._work_intervals_batch(
            //                             max(date_from, start_date),
            //                             min(date_to, version_end),
            //                             tz=employee_tz,
            //                             resources=self.resource_id,
            //                             compute_leaves=True,
            //                             domain=[('company_id', 'in', [False, self.company_id.id]), ('time_type', '=', 'leave')])[self.resource_id.id]
            //     duration_data = duration_data | version_intervals
            // return duration_data
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstVersionDateInternalAsync(object no_gap)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_version_date(self, no_gap=True):
            // self.ensure_one()
            // if not self.env.su and not self.env.user.has_group("hr.group_hr_user"):
            //     raise AccessError(_("Only HR users can access first version date on an employee."))
            // 
            // def remove_gap(versions):
            //     # We do not consider a gap of more than 4 days to be a same occupation
            //     # versions are considered to be ordered correctly
            //     if not versions:
            //         return self.env['hr.version']
            //     if len(versions) == 1:
            //         return versions
            //     current_version = versions[0]
            //     older_versions = versions[1:]
            //     current_date = current_version.date_start
            //     for i, other_version in enumerate(older_versions):
            //         # Consider current_version.date_end being false as an error and cut the loop
            //         gap = (current_date - (other_version.date_end or date(2100, 1, 1))).days
            //         current_date = other_version.date_start
            //         if gap >= 4:
            //             return older_versions[0:i] + current_version
            //     return older_versions + current_version
            // 
            // versions = self._get_first_versions().sorted('date_start', reverse=True)
            // if no_gap:
            //     versions = remove_gap(versions)
            // return min(versions.mapped('date_start')) if versions else False
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstVersionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_versions(self):
            // self.ensure_one()
            // versions = self.version_ids
            // if self.env.context.get('before_date'):
            //     versions = versions.filtered(lambda c: c.date_start <= self.env.context['before_date'])
            // return versions
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstWorkingIntervalInternalAsync(object dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_first_working_interval(self, dt):
            // # find the first working interval after a given date
            // dt = dt.replace(tzinfo=timezone.utc)
            // lookahead_days = [7, 30, 90, 180, 365, 730]
            // work_intervals = None
            // for lookahead_day in lookahead_days:
            //     periods = self._get_calendar_periods(dt, dt + timedelta(days=lookahead_day))
            //     if not periods:
            //         calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //         work_intervals = calendar._work_intervals_batch(
            //             dt, dt + timedelta(days=lookahead_day), resources=self.resource_id)
            //     else:
            //         for period in periods[self]:
            //             start, end, calendar = period
            //             calendar = calendar or self.company_id.resource_calendar_id
            //             work_intervals = calendar._work_intervals_batch(
            //                 start, end, resources=self.resource_id)
            //     if work_intervals.get(self.resource_id.id) and work_intervals[self.resource_id.id]._items:
            //         # return start time of the earliest interval
            //         return work_intervals[self.resource_id.id]._items[0][0]
            */
            return default;
        }

        public async Task<HrEmployee> GetFormviewActionAsync(Guid id, HrEmployeeGetFormviewActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super().get_formview_action(access_uid=access_uid)
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
            //     return super().get_formview_id(access_uid=access_uid)
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

        public async Task<HrEmployee> GetInternalResumeLinesAsync(Guid id, HrEmployeeGetInternalResumeLinesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def get_internal_resume_lines(self, res_id, res_model):
            // if not res_id:
            //     return []
            // if res_model == 'res.users':
            //     res_id = self.env['res.users'].browse(res_id).employee_id.id
            // if not self.env['hr.employee.public'].browse(res_id).has_access('read'):
            //     raise AccessError(self.env._("You cannot access the resume of this employee."))
            // res = []
            // employee_versions = self.env['hr.employee'].sudo().browse(res_id).version_ids
            // if not employee_versions:
            //     return res
            // interval_date_start = False
            // for i in range(len(employee_versions) - 1):
            //     current_version = employee_versions[i]
            //     next_version = employee_versions[i + 1]
            //     current_date_start = max(current_version.date_version, current_version.contract_date_start or date.min)
            //     current_date_end = min(next_version.date_version + relativedelta(days=-1), current_version.contract_date_end or date.max)
            //     if not current_version.job_title:
            //         if interval_date_start:
            //             previous_version = employee_versions[i - 1]
            //             res.append({
            //                 'id': previous_version.id,
            //                 'job_title': previous_version.job_title,
            //                 'date_start': interval_date_start,
            //                 'date_end': current_date_start + relativedelta(days=-1),
            //             })
            //             interval_date_start = False
            //     elif current_version.job_title != next_version.job_title or current_date_end + relativedelta(days=1) != next_version.date_version:
            //         res.append({
            //             'id': current_version.id,
            //             'job_title': current_version.job_title,
            //             'date_start': interval_date_start or current_date_start,
            //             'date_end': current_date_end,
            //         })
            //         interval_date_start = False
            //     else:
            //         interval_date_start = interval_date_start or current_date_start
            // 
            // last_version = employee_versions[-1]
            // if last_version.job_title:
            //     current_date_start = max(last_version.date_version, last_version.contract_date_start or date.min)
            //     res.append({
            //         'id': last_version.id,
            //         'job_title': last_version.job_title,
            //         'date_start': interval_date_start or current_date_start,
            //         'date_end': last_version.contract_date_end or False,
            //     })
            // elif interval_date_start:
            //     previous_version = employee_versions[-2]
            //     res.append({
            //         'id': previous_version.id,
            //         'job_title': previous_version.job_title,
            //         'date_start': interval_date_start,
            //         'date_end': current_date_start + relativedelta(days=-1),
            //     })
            // return res[::-1]
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // self_with_context = self._get_contextual_employee()
            // if isinstance(date_start, str):
            //     date_start = datetime.fromisoformat(date_start).replace(tzinfo=None)
            // elif isinstance(date_start, datetime):
            //     date_start = date_start.replace(tzinfo=None)
            // 
            // if isinstance(date_end, str):
            //     date_end = datetime.fromisoformat(date_end).replace(tzinfo=None)
            // elif isinstance(date_end, datetime):
            //     date_end = date_end.replace(tzinfo=None)
            // 
            // mandatory_days = self_with_context._get_mandatory_days(date_start, date_end).sorted('start_date')
            // return [{
            //     'id': -sd.id,
            //     'colorIndex': sd.color,
            //     'end': datetime.combine(sd.end_date, datetime.max.time()).isoformat(),
            //     'endType': "datetime",
            //     'isAllDay': True,
            //     'start': datetime.combine(sd.start_date, datetime.min.time()).isoformat(),
            //     'startType': "datetime",
            //     'title': sd.name,
            // } for sd in mandatory_days]
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
            //     ('resource_calendar_id', 'in', self.resource_calendar_id.ids),
            // ]
            // 
            // if self.job_id:
            //     domain += [
            //         ('job_ids', 'in', [False] + self.job_id.ids),
            //     ]
            // if self.department_id:
            //     department_ids = self.department_id.ids
            //     domain += [
            //         '|',
            //         ('department_ids', '=', False),
            //         ('department_ids', 'parent_of', department_ids),
            //     ]
            // else:
            //     domain += [('department_ids', '=', False)]
            // 
            // return self.env['hr.leave.mandatory.day'].search(domain)
            */
            return default;
        }

        protected async Task<HrEmployee> GetNewHireFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_new_hire_field(self):
            // return 'create_date'
            */
            return default;
        }

        public async Task<HrEmployee> GetOvertimeDataAsync(Guid id, HrEmployeeGetOvertimeDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def get_overtime_data(self, domain=None, employee_id=None):
            // domain = [] if domain is None else domain
            // validated_overtime = {
            //     attendance[0].id: attendance[1]
            //     for attendance in self.env["hr.attendance"]._read_group(
            //         domain=domain,
            //         groupby=['employee_id'],
            //         aggregates=['validated_overtime_hours:sum']
            //     )
            // }
            // return {"validated_overtime": validated_overtime, "overtime_adjustments": {}}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> GetOvertimeDataByEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_employee.py) ---
            // def get_overtime_data_by_employee(self):
            // """
            // Provide a summary of an employee's overtime.
            // A compensable overtime is an overtime that can be cumulated to be used
            // as time off.
            // Extra hours and overtime is used interchangably.
            // """
            // # Make so that at least all employees are present in return value
            // overtime_data = {}
            // for employee_id in self.ids:
            //     overtime_data[employee_id] = {
            //         "compensable_overtime": 0,
            //         "not_compensable_overtime": 0,
            //         "unspent_compensable_overtime": 0,
            //     }
            // 
            // unspent_overtime = self.env[
            //     'hr.leave'
            // ]._get_deductible_employee_overtime(self)
            // for employee in unspent_overtime:
            //     overtime_data[employee.id]['unspent_compensable_overtime'] += max(
            //         0, unspent_overtime[employee]
            //     )
            // 
            // all_overtimes = self.env['hr.attendance.overtime.line']._read_group(
            //     domain=[
            //         ('employee_id', 'in', self.ids),
            //     ],
            //     groupby=["employee_id", "compensable_as_leave"],
            //     aggregates=["duration:sum"],
            // )
            // for employee, is_compensable, amount in all_overtimes:
            //     overtime_type = (
            //         'compensable_overtime'
            //         if is_compensable
            //         else 'not_compensable_overtime'
            //     )
            //     overtime_data[employee.id][overtime_type] += amount
            // 
            // return overtime_data
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetPartnerCountDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return super()._get_partner_count_depends() + ['applicant_ids']
            */
            return default;
        }

        public async Task<HrEmployee> GetPresenceServerDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def get_presence_server_action_data(self):
            // server_action_xmlids = [
            //     'action_hr_employee_presence_present',
            //     'action_hr_employee_presence_absent',
            //     'action_hr_employee_presence_log',
            //     'action_hr_employee_presence_sms',
            //     'action_hr_employee_presence_time_off',
            // ]
            // actions = self.env['ir.actions.server'].sudo()
            // for xmlid in server_action_xmlids:
            //     actions += actions.env.ref(f"hr_presence.{xmlid}")
            // return actions.read(['id', 'value'])
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // return partners | self.sudo().applicant_ids.partner_id
            */
            return default;
        }

        public async Task<HrEmployee> GetRemainingPercentageAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_remaining_percentage(self):
            // self.ensure_one()
            // distribution = self.salary_distribution or {}
            // allocated = 0.0
            // 
            // for ba_id, vals in distribution.items():
            //     if vals.get('amount_is_percentage'):
            //         allocated += vals.get('amount', 0.0)
            // 
            // remaining = 100.0 - allocated
            // return max(0.0, remaining)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetSchedulesByEmployeeByWorkTypeInternalAsync(object start, object stop, object version_periods_by_employee)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def _get_schedules_by_employee_by_work_type(self, start, stop, version_periods_by_employee):
            // employees_by_calendar = defaultdict(lambda: self.env['hr.employee'])
            // leave_intervals_by_cal_by_resource = defaultdict(lambda: defaultdict(Intervals))
            // attendance_intervals_by_cal = defaultdict(Intervals)
            // lunch_intervals_by_cal = defaultdict(Intervals)
            // 
            // for employee, intervals in version_periods_by_employee.items():
            //     for (_start, _stop, version) in intervals:
            //         employees_by_calendar[version.resource_calendar_id] |= employee
            // 
            // for cal, employees in employees_by_calendar.items():
            //     if not cal:  # employees are fully flex
            //         continue
            //     cal_leave_intervals_by_resource = cal._leave_intervals_batch(
            //         start,
            //         stop,
            //         resources=employees.resource_id,
            //     )
            //     for resource, leave_intervals in cal_leave_intervals_by_resource.items():
            //         naive_leave_intervals = Intervals([(
            //             i_start.replace(tzinfo=None),
            //             i_stop.replace(tzinfo=None),
            //             i_model
            //         ) for (i_start, i_stop, i_model) in leave_intervals])
            //         leave_intervals_by_cal_by_resource[cal][resource] = naive_leave_intervals
            // 
            //     cal_attendance_intervals = cal._attendance_intervals_batch(
            //         start,
            //         stop,
            //     )[False]
            //     attendance_intervals_by_cal[cal] = Intervals([(
            //             i_start.replace(tzinfo=None),
            //             i_stop.replace(tzinfo=None),
            //             i_model
            //         ) for (i_start, i_stop, i_model) in cal_attendance_intervals])
            // 
            //     cal_lunch_intervals = cal._attendance_intervals_batch(
            //         start,
            //         stop,
            //         lunch=True
            //     )[False]
            //     lunch_intervals_by_cal[cal] = Intervals([(
            //             i_start.replace(tzinfo=None),
            //             i_stop.replace(tzinfo=None),
            //             i_model
            //         ) for (i_start, i_stop, i_model) in cal_lunch_intervals])
            // 
            // full_schedule_by_employee = {
            //     'leave': defaultdict(Intervals),
            //     'schedule': defaultdict(lambda: {
            //         'work': Intervals([]),
            //         'lunch': Intervals([]),
            //     }),
            //     'fully_flexible': defaultdict(Intervals)
            // }
            // for employee, intervals in version_periods_by_employee.items():
            //     for (p_start, p_stop, version) in intervals:
            //         interval = Intervals([(p_start.replace(tzinfo=None), p_stop.replace(tzinfo=None), self.env['resource.calendar'])])
            //         calendar = version.resource_calendar_id
            //         if not calendar:
            //             full_schedule_by_employee['fully_flexible'][employee] |= interval
            //             continue
            //         employee_leaves = leave_intervals_by_cal_by_resource[calendar][employee.resource_id.id]
            //         full_schedule_by_employee['leave'][employee] |= employee_leaves & interval
            //         employee_attendances = attendance_intervals_by_cal[calendar]
            //         full_schedule_by_employee['schedule'][employee]['work'] |= employee_attendances & interval
            //         employee_lunches = lunch_intervals_by_cal[calendar]
            //         full_schedule_by_employee['schedule'][employee]['lunch'] |= employee_lunches & interval
            // 
            // return full_schedule_by_employee
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

        protected async Task<HrEmployee> GetStoreAvatarCardFieldsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_store_avatar_card_fields(self, target):
            // employee_fields = [
            //     "company_id",
            //     Store.One("department_id", ["name"]),
            //     "work_email",
            //     Store.One("work_location_id", ["location_type", "name"]),
            //     "work_phone",
            // ]
            // user = target.get_user(self.env)
            // if user.has_group("hr.group_hr_user"):
            //     # job_title is not a field of hr.employee.public, but it is a field of hr.employee
            //     employee_fields.append("job_title")
            // # HACK: fetch the employee fields from employees to retrieve hr.employee.public fields if no access to hr.employee
            // if len(self) > 0:
            //     self.fetch([
            //         field.field_name if isinstance(field, Store.Attr) else field
            //         for field in employee_fields
            //     ])
            // return employee_fields
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _get_store_avatar_card_fields(self, target):
            // return [*super()._get_store_avatar_card_fields(target), "leave_date_to"]
            */
            return default;
        }

        protected async Task<HrEmployee> GetSubordinatesInternalAsync(object parents)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _get_subordinates(self, parents=None):
            // """
            // Helper function to compute subordinates_ids.
            // Get all subordinates (direct and indirect) of an employee.
            // An employee can be a manager of his own manager (recursive hierarchy; e.g. the CEO is manager of everyone but is also
            // member of the RD department, managed by the CTO itself managed by the CEO).
            // In that case, the manager in not counted as a subordinate if it's in the 'parents' set.
            // """
            // if not parents:
            //     parents = self.env[self._name]
            // 
            // indirect_subordinates = self.env[self._name]
            // parents |= self
            // direct_subordinates = self.child_ids - parents
            // child_subordinates = direct_subordinates._get_subordinates(parents=parents) if direct_subordinates else self.browse()
            // indirect_subordinates |= child_subordinates
            // return indirect_subordinates | direct_subordinates
            */
            return default;
        }

        public async Task<HrEmployee> GetTimeOffDashboardDataAsync(Guid id, HrEmployeeGetTimeOffDashboardDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def get_time_off_dashboard_data(self, target_date=None):
            // dashboard_data = {}
            // dashboard_data['has_accrual_allocation'] = self.env['hr.leave.type'].has_accrual_allocation()
            // dashboard_data['allocation_data'] = self.env['hr.leave.type'].get_allocation_data_request(target_date, False)
            // dashboard_data['allocation_request_amount'] = self.get_allocation_requests_amount()
            // return dashboard_data
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
            // self.ensure_one()
            // return self.resource_calendar_id.tz or\
            //        self.tz or\
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
            // date_from_date = datetime.strptime(date_from, '%Y-%m-%d %H:%M:%S').date()
            // date_to_date = datetime.strptime(date_to, '%Y-%m-%d %H:%M:%S').date() if date_to else None
            // employee_versions = self.env['hr.version'].sudo().search([('employee_id', '=', self.id)]).filtered(
            //     lambda v: v._is_overlapping_period(date_from_date, date_to_date))
            // if not employee_versions:
            //     # Checking the calendar directly allows to not grey out the leaves taken
            //     # by the employee or fallback to the company calendar
            //     return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     )
            // unusual_days = {}
            // for version in employee_versions:
            //     tmp_date_from = max(date_from_date, version.date_start)
            //     tmp_date_to = min(date_to_date, version.date_end) if version.date_end else date_to_date
            //     unusual_days.update(version.resource_calendar_id.sudo(False)._get_unusual_days(
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

        protected async Task<HrEmployee> GetVersionInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version(self, date=fields.Date.today()):
            // """
            // Return the version that should be used for the given date.
            // If no valid version is found, we return the very first version of the employee.
            // """
            // self.ensure_one()
            // versions = self.version_ids.filtered_domain([('date_version', '<=', date)])
            // return max(versions, key=lambda v: v.date_version) if versions else self.version_ids[0]
            */
            return default;
        }

        protected async Task<HrEmployee> GetVersionPeriodsInternalAsync(object start, object stop, object field, object check_contract)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version_periods(self, start, stop, field=None, check_contract=False):
            // if field and field not in self:
            //     raise UserError(self.env._(
            //         "This field %(field_name)s doesn't exist on this model (hr.version).",
            //         field_name=field
            //     ))
            // version_periods_by_employee = defaultdict(list)
            // if check_contract:
            //     versions = self._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            // else:
            //     versions = self.version_ids.filtered_domain([
            //         ('date_start', '<=', stop),
            //         '|',
            //             ('date_end', '=', False),
            //             ('date_end', '>=', start)
            //     ])
            // for version in versions:
            //     # if employee is under fully flexible contract, use timezone of the employee
            //     calendar_tz = timezone(version.resource_calendar_id.tz) if version.resource_calendar_id else timezone(version.employee_id.resource_id.tz)
            //     date_start = datetime.combine(version.date_start, time.min).replace(tzinfo=calendar_tz).astimezone(utc)
            //     end_date = version.date_end
            //     if end_date:
            //         date_end = datetime.combine(
            //             end_date + relativedelta(days=1),
            //             time.min,
            //         ).replace(tzinfo=calendar_tz).astimezone(utc)
            //     else:
            //         date_end = stop
            //     version_periods_by_employee[version.employee_id].append(
            //         (max(date_start, start), min(date_end, stop), version[field] if field else version))
            // return version_periods_by_employee
            */
            return default;
        }

        protected async Task<HrEmployee> GetVersionsWithContractOverlapWithPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of the employee between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // return self.version_ids.filtered_domain([
            //     ('contract_date_start', '!=', False), ('contract_date_start', '<=', date_to),
            //     '|', ('contract_date_end', '>=', date_from), ('contract_date_end', '=', False),
            // ])
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
            //         if self.browse().has_access('read'):
            //             return super().get_views(views, options)
            //         # returning public employee data would cause a traceback when building
            //         # the private employee xml view
            //         raise RedirectWarning(
            //             message=_(
            //             """You are not allowed to access "Employee" (hr.employee) records.
            // We can redirect you to the public employee list."""
            //             ),
            //             action=self.env.ref('hr.hr_employee_public_action').id,
            //             button_text=_("Employees profile"),
            //         )
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // res = super().get_views(views, options)
            // dayfield = self._get_current_day_location_field()
            // if 'search' in res['views']:
            //     res['views']['search']['arch'] = res['views']['search']['arch'].replace('today_location_name', dayfield)
            // if 'list' in res['views']:
            //     res['views']['list']['arch'] = res['views']['list']['arch'].replace('work_location_name', dayfield)
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> GetWorklocationInternalAsync(object start_date, object end_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: hr_employee.py) ---
            // def _get_worklocation(self, start_date, end_date):
            // work_locations_by_employee = defaultdict(dict)
            // for employee in self:
            //     work_locations_by_employee[employee.id].update({
            //         "user_id": employee.user_id.id,
            //         "employee_id": employee.id,
            //         "partner_id": employee.user_partner_id.id or employee.work_contact_id.id,
            //         "employee_name": employee.name
            //     })
            // 
            //     for day in DAYS:
            //         work_locations_by_employee[employee.id][day] = {
            //             'location_type': employee[day]["location_type"],
            //             'location_name': employee[day]["name"],
            //             'work_location_id': employee[day].id,
            //         }
            // 
            // exceptions_for_period = self.env['hr.employee.location'].search_read([
            //     ('employee_id', 'in', self.ids),
            //     ('date', '>=', start_date),
            //     ('date', '<=', end_date)
            // ], ['employee_id', 'date', 'work_location_name', 'work_location_id', 'work_location_type'])
            // 
            // for exception in exceptions_for_period:
            //     date = exception["date"].strftime(DEFAULT_SERVER_DATE_FORMAT)
            //     exception_value = {
            //         'hr_employee_location_id': exception["id"],
            //         'location_type': exception['work_location_type'],
            //         'location_name': exception['work_location_name'],
            //         'work_location_id': exception['work_location_id'][0],
            //     }
            //     employee_id = exception["employee_id"][0]
            //     if "exceptions" not in work_locations_by_employee[employee_id]:
            //         work_locations_by_employee[employee_id]["exceptions"] = {}
            //     work_locations_by_employee[employee_id]["exceptions"][date] = exception_value
            // 
            // return work_locations_by_employee
            */
            return default;
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
            // # This is a problem because the `group_hr_expense_team_approver` record has already been created but
            // # not its associated `ir.model.data` which makes `self.env.ref(...)` fail.
            // group = self.env.ref('hr_expense.group_hr_expense_team_approver', raise_if_not_found=False)
            // return [
            //     '|', ('id', 'parent_of', self.ids), ('all_group_ids', 'in', group.ids)
            // ] if group else [('id', 'parent_of', self.ids)]
            */
            return default;
        }

        protected async Task<HrEmployee> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _has_field_access(self, field, operation):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // return super()._has_field_access(field, operation) and (
            //     self.env.su
            //     or self.env.user.has_group("hr.group_hr_user")
            //     or field.name not in ('activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error')
            // )
            */
            return default;
        }

        protected async Task<HrEmployee> InverseWorkContactDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_work_contact_details(self):
            // employees_without_work_contact = self.env['hr.employee']
            // for employee in self:
            //     if not employee.work_contact_id:
            //         employees_without_work_contact += employee
            //     else:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_contact_id.sudo().write({
            //                 'email': employee.work_email,
            //                 'phone': employee.work_phone,
            //             })
            // if employees_without_work_contact:
            //     employees_without_work_contact.sudo()._create_work_contacts()
            */
            return default;
        }

        protected async Task<HrEmployee> IsInContractInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _is_in_contract(self, date):
            // return self._get_contract_dates(date) != (False, False)
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

        protected async Task<HrEmployee> LoadDemoDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_demo_data(self):
            // dep_rd = self.env.ref('hr.dep_rd', raise_if_not_found=False)
            // action_reload = {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload',
            // }
            // if dep_rd:
            //     return action_reload
            // convert.convert_file(env=self.sudo().env, module='hr', filename='data/scenarios/hr_scenario.xml', idref=None, mode='init')
            // if 'resume_line_ids' in self:
            //     convert.convert_file(env=self.env, module='hr_skills', filename='data/scenarios/hr_skills_scenario.xml', idref=None, mode='init')
            // return action_reload
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return config._employee_domain(config.current_user_id.id)
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['name', 'user_id', 'work_contact_id']
            */
            return default;
        }

        protected async Task<HrEmployee> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // manager_ids = records.filtered(lambda emp: config.group_pos_manager_id.id in emp.user_id.all_group_ids.ids).ids
            // 
            // employees_barcode_pin = records.get_barcodes_and_pin_hashed()
            // bp_per_employee_id = {bp_e['id']: bp_e for bp_e in employees_barcode_pin}
            // 
            // for employee in read_records:
            //     if employee['id'] in manager_ids:
            //         role = 'manager'
            //         employee['_user_role'] = 'admin'
            //     elif employee['id'] in config.advanced_employee_ids.ids:
            //         role = 'manager'
            //     elif employee['id'] in config.minimal_employee_ids.ids:
            //         role = 'minimal'
            //     else:
            //         role = 'cashier'
            // 
            //     employee['_role'] = role
            //     employee['_barcode'] = bp_per_employee_id[employee['id']]['barcode']
            //     employee['_pin'] = bp_per_employee_id[employee['id']]['pin']
            // 
            // return read_records
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
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init')
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // super()._load_scenario()
            // demo_tag = self.env.ref('hr_skills.employee_resume_line_emp_eg_1', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init')
            // convert.convert_file(self.env, 'hr_skills', 'data/scenarios/hr_skills_scenario.xml', None, mode='init')
            */
            return default;
        }

        protected async Task<HrEmployee> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['work_contact_id', 'user_partner_id']
            */
            return default;
        }

        public async Task<HrEmployee> NewAsync(Guid id, HrEmployeeNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def new(self, values=None, origin=None, ref=None):
            // if not values:
            //     values = {}
            // new_vals = values.copy()
            // version_vals = {val: new_vals.pop(val) for val in values if val in self._fields and self._fields[val].inherited}
            // 
            // employee = super().new(new_vals, origin, ref)
            // version_vals['employee_id'] = employee
            // self.env['hr.version'].new({
            //     f_name: value
            //     for f_name, value in version_vals.items()
            //     if self.env['hr.version']._has_field_access(self.env['hr.version']._fields[f_name], 'read')
            // })
            // return employee
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> NotifyExpiringContractWorkPermitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def notify_expiring_contract_work_permit(self):
            // companies = self.env['res.company'].search([])
            // employees_contract_expiring = self.env['hr.employee']
            // employees_work_permit_expiring = self.env['hr.employee']
            // 
            // for company in companies:
            //     employees_contract_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('contract_date_start', '!=', False),
            //         ('contract_date_start', '<', fields.Date.today()),
            //         ('contract_date_end', '=', fields.Date.today() + relativedelta(days=company.contract_expiration_notice_period)),
            //     ])
            // 
            //     employees_work_permit_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('work_permit_expiration_date', '!=', False),
            //         ('work_permit_expiration_date', '=', fields.Date.today() + relativedelta(days=company.work_permit_expiration_notice_period)),
            //     ])
            // 
            // for employee in employees_contract_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.contract_date_end,
            //         _("The contract of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // for employee in employees_work_permit_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.work_permit_expiration_date,
            //         _("The work permit of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<HrEmployee> OnchangeContractDateStartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_date_start(self):
            // if not self.contract_date_start:
            //     self.contract_date_end = False
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeContractTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_template_id(self):
            // if self.contract_template_id:
            //     whitelist = self.env['hr.version']._get_whitelist_fields_from_template()
            //     for field in self.contract_template_id._fields:
            //         if field in whitelist and not self.env['hr.version']._fields[field].related:
            //             self[field] = self.contract_template_id[field]
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangePhoneValidationEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_phone_validation_employee(self):
            // if self.work_phone:
            //     self.work_phone = self._phone_format(number=self.work_phone, force_format='INTERNATIONAL') or self.work_phone
            // if self.mobile_phone:
            //     self.mobile_phone = self._phone_format(number=self.mobile_phone, force_format='INTERNATIONAL') or self.mobile_phone
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangePrivateStateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_private_state_id(self):
            // if self.private_state_id:
            //     self.private_country_id = self.private_state_id.country_id
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

        public async Task<HrEmployee> OpenAllocationWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_allocation_wizard(self):
            // self.ensure_one()
            // wizard = self.env['hr.bank.account.allocation.wizard'].create({
            //     'employee_id': self.id,
            // })
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.env._('Bank Account Allocation'),
            //     'res_model': 'hr.bank.account.allocation.wizard',
            //     'res_id': wizard.id,
            //     'view_mode': 'form',
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenBarcodeScannerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def open_barcode_scanner(self):
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "employee_barcode_scanner",
            //     "name": "Badge Scanner"
            // }
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
            //     "context": dict(self.env.context, default_driver_id=self.user_id.partner_id.id, default_driver_employee_id=self.id),
            //     "name": self.env._("Cars History"),
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
            //         "create": 0,
            //         "search_default_check_in_filter": 1,
            //         "employee_id": self.id,
            //         "display_extra_hours": self.display_extra_hours,
            //     },
            //     "domain": [('employee_id', '=', self.id)]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenLeaveRequestAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_open_leave_request(self):
            // if len(self) == 1:
            //     model = 'hr.leave'
            //     context = {'default_employee_id': self.id}
            // else:
            //     model = 'hr.leave.generate.multi.wizard'
            //     context = {
            //         'default_employee_ids': self.ids,
            //         'default_date_from': fields.Date.today(),
            //         'default_date_to': fields.Date.today(),
            //         'default_name': _('Unplanned Absence'),
            //     }
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': model,
            //     'views': [[False, 'form']],
            //     'view_mode': 'form',
            //     'context': context,
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> OpenVersionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_versions(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.employee_id.name + self.env._(' Records'),
            //     'path': 'versions',
            //     'res_model': 'hr.version',
            //     'view_mode': 'list,graph,pivot',
            //     'views': [(self.env.ref('hr.hr_version_list_view').id, 'list'), (False, 'graph'), (False, 'pivot')],
            //     'domain': [('employee_id', '=', self.employee_id.id)],
            //     'search_view_id': self.env.ref('hr.hr_version_search_view').id
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
            //     'path': 'work-entries',
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

        protected async Task<HrEmployee> PrepareCreateValuesInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_create_values(self, vals_list):
            // result = super()._prepare_create_values(vals_list)
            // new_vals_list = []
            // Version = self.env['hr.version']
            // version_fields = [fname for fname, field in Version._fields.items() if Version._has_field_access(field, 'write')]
            // for vals in result:
            //     employee_vals = {}
            //     version_vals = {}
            //     for fname, value in vals.items():
            //         employee_field = self._fields.get(fname)
            //         if not (employee_field and employee_field.inherited and employee_field.related_field.model_name == 'hr.version'):
            //             employee_vals[fname] = value
            //         else:
            //             version_vals[fname] = value
            //     new_vals_list.append({
            //         **employee_vals,
            //         **{k: v for k, v in version_vals.items() if k in version_fields},
            //     })
            // return new_vals_list
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

        protected async Task<HrEmployee> SearchAbsentEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def _search_absent_employee(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // # This search is only used for the 'Absent Today' filter however
            // # this only returns employees that are absent right now.
            // today_start = date.today()
            // today_end = today_start + timedelta(1)
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', '!=', False),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<', today_end),
            //     ('date_to', '>=', today_start),
            // ])
            // return [('id', 'in', holidays.employee_id.ids)]
            */
            return default;
        }

        public async Task<HrEmployee> SearchFetchAsync(Guid id, HrEmployeeSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> SearchFilterForExpenseInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py) ---
            // def _search_filter_for_expense(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domain = Domain.FALSE  # Nothing accepted by domain, by default
            // user = self.env.user
            // employee = user.employee_id
            // if user.has_groups('hr_expense.group_hr_expense_user'):
            //     domain = Domain('company_id', '=', False) | Domain('company_id', 'child_of', self.env.company.root_id.id)  # Then, domain accepts everything
            // elif user.has_groups('hr_expense.group_hr_expense_team_approver') and user.employee_ids:
            //     domain = (
            //         Domain('department_id.manager_id', '=', employee.id)
            //         | Domain('parent_id', '=', employee.id)
            //         | Domain('id', '=', employee.id)
            //         | Domain('expense_manager_id', '=', user.id)
            //     ) & Domain('company_id', 'in', [False, employee.company_id.id])
            // elif user.employee_id:
            //     domain = Domain('id', '=', employee.id) & Domain('company_id', 'in', [False, employee.company_id.id])
            // return domain
            */
            return default;
        }

        protected async Task<HrEmployee> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, *, bypass_access=False, **kwargs):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read') or bypass_access:
            //     return super()._search(domain, offset, limit, order, bypass_access=bypass_access, **kwargs)
            // domain = Domain(domain)
            // # HACK Some fields are inherited from the `current_version_id` and may have been already
            // # optimized, showing current_version_id in the domain, but public employee does not have
            // # that field and may have fields directly on the model, just change the condition to `id` in
            // # that case.
            // domain = domain.map_conditions(lambda cond: Domain('id', cond.operator, cond.value) if cond.field_expr == 'current_version_id' else cond)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order, **kwargs)
            // except ValueError as e:
            //     raise AccessError(self.env._('You do not have access to this document.')) from e
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployee, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        protected async Task<HrEmployee> SearchIsSubordinateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _search_is_subordinate(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // subordinates = self.env.user.employee_id.subordinate_ids
            // return [('id', 'in', subordinates.ids)]
            */
            return default;
        }

        protected async Task<HrEmployee> SearchLicensePlateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def _search_license_plate(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // return ['|', ('car_ids.license_plate', operator, value), ('private_car_plate', operator, value)]
            */
            return default;
        }

        protected async Task<HrEmployee> SearchNewlyHiredInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_newly_hired(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // new_hire_field = self._get_new_hire_field()
            // new_hires = self.env['hr.employee'].sudo().search([
            //     (new_hire_field, '>', fields.Datetime.now() - timedelta(days=90))
            // ])
            // return [('id', operator, new_hires.ids)]
            */
            return default;
        }

        protected async Task<HrEmployee> SearchVersionIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_version_id(self, operator, value):
            // if operator in ('any', 'any!'):
            //     return Domain('current_version_id', operator, value)
            // domain = Domain('id', operator, value)
            // return Domain('id', 'in', self.env['hr.version']._search(domain).select('employee_id'))
            */
            return default;
        }

        public async Task<HrEmployee> SendLogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_send_log(self):
            // if not self.env.user.has_group('hr.group_hr_manager'):
            //     raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // 
            // for employee in self:
            //     employee.message_post(body=_(
            //         "%(name)s has been noted as %(state)s today",
            //         name=employee.name,
            //         state=employee.hr_presence_state_display))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> SendSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_send_sms(self):
            //         if not self.env.user.has_group('hr.group_hr_manager'):
            //             raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // 
            //         context = dict(self.env.context)
            //         context.update(default_res_model='hr.employee', default_res_ids=self.ids, default_composition_mode='mass', default_number_field_name='mobile_phone', default_mass_keep_log=True)
            // 
            //         template = self.env.ref('hr_presence.sms_template_presence', False)
            //         if not template:
            //             context['default_body'] = _("""We hope this message finds you well. It has come to our attention that you are currently not present at work, and there is no record of a time off request from you. If this absence is due to an oversight on our part, we sincerely apologize for any confusion.
            // Please take the necessary steps to address this unplanned absence. Should you have any questions or need assistance, do not hesitate to reach out to your manager or the HR department at your earliest convenience.
            // Thank you for your prompt attention to this matter.""")
            //         else:
            //             context['default_template_id'] = template.id
            // 
            //         return {
            //             "type": "ir.actions.act_window",
            //             "res_model": "sms.composer",
            //             "view_mode": 'form',
            //             "context": context,
            //             "name": self.env._("Send SMS"),
            //             "target": "new",
            //         }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> ServerDateToDomainInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py) ---
            // def _server_date_to_domain(self, domain):
            // return domain
            */
            return default;
        }

        public async Task<HrEmployee> SetAbsentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_set_absent(self):
            // self._action_set_manual_presence(False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> SetPresentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_set_present(self):
            // self._action_set_manual_presence(True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployee> SyncSalaryDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_salary_distribution(self):
            // for employee in self:
            //     current_salary_distribution = employee.salary_distribution or {}
            //     current_ids = set(map(int, current_salary_distribution.keys()))
            //     account_ids = set(employee.bank_account_ids.ids)
            // 
            //     added_ids = account_ids - current_ids
            //     removed_ids = current_ids - account_ids
            //     unchanged_ids = account_ids & current_ids
            // 
            //     # Preserve existing data and order
            //     ordered = sorted([
            //         (int(i), data) for i, data in current_salary_distribution.items()
            //         if int(i) in unchanged_ids
            //     ], key=lambda x: (not x[1].get('amount_is_percentage'), x[1].get('sequence', float('inf'))))
            // 
            //     new_salary_distribution = {str(i): data for i, data in ordered}
            // 
            //     # Redistribute removed % to first item
            //     removed_percentage = sum(current_salary_distribution[str(i)]['amount']
            //         for i in removed_ids if str(i) in current_salary_distribution and current_salary_distribution[str(i)]['amount_is_percentage'])
            //     if removed_percentage and ordered:
            //         first_id = str(ordered[0][0])
            //         if new_salary_distribution[first_id]['amount_is_percentage']:
            //             new_salary_distribution[first_id]['amount'] += removed_percentage
            // 
            //     # Add new entries with remaining %
            //     total_allocated = sum(d['amount'] for d in new_salary_distribution.values() if d['amount_is_percentage'])
            //     remaining = max(0.0, 100.0 - total_allocated)
            //     seq = max((d.get('sequence', 0) for d in new_salary_distribution.values()), default=0)
            //     amount = employee.currency_id.round(remaining / len(added_ids)) if added_ids else 0.0
            //     for i, new_id in enumerate(added_ids):
            //         seq += 1
            //         if i == len(added_ids) - 1:
            //             amount = remaining
            //         new_salary_distribution[str(new_id)] = {
            //             'amount': amount,
            //             'amount_is_percentage': True,
            //             'sequence': seq,
            //         }
            //         remaining -= amount
            // 
            //     employee.salary_distribution = new_salary_distribution
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

        public async Task<HrEmployee> TogglePrimaryBankAccountTrustAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_toggle_primary_bank_account_trust(self):
            // self.ensure_one()
            // current_val = self.primary_bank_account_id.allow_out_payment
            // self.primary_bank_account_id.allow_out_payment = not current_val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployee> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_unarchive(self):
            // res = super().action_unarchive()
            // self.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
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
            // configs_with_all_employees = configs_with_employees.filtered(lambda c: not c.basic_employee_ids and not c.advanced_employee_ids and not c.minimal_employee_ids)
            // configs_with_specific_employees = configs_with_employees.filtered(lambda c: (c.basic_employee_ids or c.advanced_employee_ids or c.minimal_employee_ids) & self)
            // if configs_with_all_employees or configs_with_specific_employees:
            //     error_msg = _("You cannot delete an employee that may be used in an active PoS session, close the session(s) first: \n")
            //     for employee in self:
            //         config_ids = configs_with_all_employees | configs_with_specific_employees.filtered(lambda c: employee in c.basic_employee_ids)
            //         if config_ids:
            //             error_msg += _("Employee: %(employee)s - PoS Config(s): %(config_list)s \n", employee=employee.name, config_list=config_ids.mapped("name"))
            // 
            //     raise UserError(error_msg)
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
            //     self.message_unsubscribe(self.work_contact_id.ids)
            // if 'user_id' in vals:
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // if vals.get('tz'):
            //     users_to_update = self.env['res.users']
            //     for employee in self:
            //         if employee.user_id and employee.company_id == employee.user_id.company_id and vals['tz'] != employee.user_id.tz:
            //             users_to_update |= employee.user_id
            //     if users_to_update:
            //         users_to_update.write({'tz': vals['tz']})
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
            // # Only one write call for all the fields from hr.version
            // new_vals = vals.copy()
            // version_vals = {val: new_vals.pop(val) for val in vals if val in self._fields and self._fields[val].inherited}
            // res = super().write(new_vals)
            // if 'work_contact_id' in vals:
            //     account_ids = self.bank_account_ids.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            // if version_vals:
            //     version_vals['last_modified_date'] = fields.Datetime.now()
            //     version_vals['last_modified_uid'] = self.env.uid
            //     self.version_id.write(version_vals)
            // 
            //     for employee in self:
            //         employee._track_set_log_message(Markup("<b>Modified on the Version '%s'</b>") % employee.version_id.display_name)
            // if res and 'resource_calendar_id' in vals:
            //     resources_per_calendar_id = defaultdict(lambda: self.env['resource.resource'])
            //     for employee in self:
            //         if employee.version_id == employee.current_version_id:
            //             resources_per_calendar_id[employee.resource_calendar_id.id] += employee.resource_id
            //     for calendar_id, resources in resources_per_calendar_id.items():
            //         resources.write({'calendar_id': calendar_id})
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py) ---
            // def write(self, vals):
            // old_officers = self.env['res.users']
            // if 'attendance_manager_id' in vals:
            //     old_officers = self.attendance_manager_id
            //     # Officer was added
            //     if vals['attendance_manager_id']:
            //         officer = self.env['res.users'].browse(vals['attendance_manager_id'])
            //         officers_group = self.env.ref('hr_attendance.group_hr_attendance_officer', raise_if_not_found=False)
            //         if officers_group and not officer.has_group('hr_attendance.group_hr_attendance_officer'):
            //             officer.sudo().write({'group_ids': [(4, officers_group.id)]})
            // 
            // res = super().write(vals)
            // old_officers.sudo()._clean_attendance_officers()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py) ---
            // def write(self, vals):
            // # Update car partner when it is changed on the employee
            // old_work_contact_id_mapping = {e.id: e.work_contact_id.id for e in self}
            // res = super().write(vals)
            // 
            // # Update car partner when it is changed on the employee needs to be done after because of _sync_user
            // if 'work_contact_id' in vals:
            //     for employee in self:
            //         if vals['work_contact_id'] != old_work_contact_id_mapping[employee.id]:
            //             car_ids = self.env['fleet.vehicle'].sudo().search([
            //                 '|',
            //                     ('driver_employee_id', '=', employee.id),
            //                     ('future_driver_employee_id', '=', employee.id),
            //             ])
            //             if car_ids:
            //                 car_ids.filtered(lambda c: c.driver_employee_id.id == employee.id).write({
            //                     'driver_id': vals['work_contact_id'],
            //                 })
            //                 car_ids.filtered(lambda c: c.future_driver_employee_id.id == employee.id).write({
            //                     'future_driver_id': vals['work_contact_id'],
            //                 })
            // 
            // if 'mobility_card' in vals:
            //     car_ids = self.env['fleet.vehicle'].sudo().search([
            //         ('driver_employee_id', 'in', self.ids),
            //     ])
            //     car_ids._compute_mobility_card()
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py) ---
            // def write(self, vals):
            // values = vals
            // # Prevent the resource calendar of leaves to be updated by a write to
            // # employee. When this module is enabled the resource calendar of
            // # leaves are determined by those of the contracts.
            // self = self.with_context(no_leave_resource_calendar_update=True)  # noqa: PLW0642
            // if 'parent_id' in values:
            //     manager = self.env['hr.employee'].browse(values['parent_id']).user_id
            //     if manager:
            //         to_change = self.filtered(lambda e: e.leave_manager_id == e.parent_id.user_id or not e.leave_manager_id)
            //         to_change.write({'leave_manager_id': values.get('leave_manager_id', manager.id)})
            // 
            // old_managers = self.env['res.users']
            // if 'leave_manager_id' in values:
            //     old_managers = self.mapped('leave_manager_id')
            //     if values['leave_manager_id']:
            //         leave_manager = self.env['res.users'].browse(values['leave_manager_id'])
            //         old_managers -= leave_manager
            //         approver_group = self.env.ref('hr_holidays.group_hr_holidays_responsible', raise_if_not_found=False)
            //         if approver_group and not leave_manager.has_group('hr_holidays.group_hr_holidays_responsible'):
            //             leave_manager.sudo().write({'group_ids': [(4, approver_group.id)]})
            // 
            // res = super().write(values)
            // # remove users from the Responsible group if they are no longer leave managers
            // old_managers.sudo()._clean_leave_responsible_users()
            // 
            // # Change the resource calendar of the employee's leaves in the future
            // # Other modules can disable this behavior by setting the context key
            // # 'no_leave_resource_calendar_update'
            // if 'resource_calendar_id' in values and not self.env.context.get('no_leave_resource_calendar_update'):
            //     try:
            //         self.env['hr.leave'].search([
            //             ('employee_id', 'in', self.ids),
            //             ('resource_calendar_id', '!=', int(values['resource_calendar_id'])),
            //             ('date_from', '>', fields.Datetime.now())]).write({'resource_calendar_id': values['resource_calendar_id']})
            //     except ValidationError:
            //         raise ValidationError(_("Changing this working schedule results in the affected employee(s) not having enough "
            //                                 "leaves allocated to accomodate for their leaves already taken in the future. Please "
            //                                 "review this employee's leaves and adjust their allocation accordingly."))
            // 
            // if 'parent_id' in values or 'department_id' in values:
            //     today_date = fields.Datetime.now()
            //     hr_vals = {}
            //     if values.get('department_id') is not None:
            //         hr_vals['department_id'] = values['department_id']
            //     holidays = self.env['hr.leave'].sudo().search([
            //         '|',
            //         ('state', '=', 'confirm'),
            //         ('date_from', '>', today_date),
            //         ('employee_id', 'in', self.ids),
            //     ])
            //     holidays.write(hr_vals)
            //     if values.get('parent_id') is not None:
            //         hr_vals['manager_id'] = values['parent_id']
            //     allocations = self.env['hr.leave.allocation'].sudo().search([
            //         ('state', '=', 'confirm'),
            //         ('employee_id', 'in', self.ids),
            //     ])
            //     allocations.write(hr_vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if vals.get('hr_presence_state_display') == 'present':
            //     vals['manually_set_present'] = True
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'current_employee_skill_ids' in vals or 'certification_ids' in vals or 'employee_skill_ids' in vals:
            //     vals_emp_skill = vals.pop('current_employee_skill_ids', []) + vals.pop('certification_ids', [])\
            //         + vals.get('employee_skill_ids', [])
            //     vals['employee_skill_ids'] = self.env['hr.employee.skill']._get_transformed_commands(vals_emp_skill, self)
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if vals.get('active'):
            //     inactive_emp = self.filtered(lambda e: not e.active)
            // result = super().write(vals)
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