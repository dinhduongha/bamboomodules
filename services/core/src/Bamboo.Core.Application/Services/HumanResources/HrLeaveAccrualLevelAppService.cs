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
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveAccrualLevelAppService : GenericApplicationService<HrLeaveAccrualLevel>, IHrLeaveAccrualLevelAppService
    {

        public HrLeaveAccrualLevelAppService(IRepository<HrLeaveAccrualLevel, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<HrLeaveAccrualLevel> CheckDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _check_dates(self):
            // error_message = ''
            // for level in self:
            //     if level.frequency == 'weekly' and not level.week_day:
            //         error_message = _("Weekday must be selected to use the frequency weekly")
            //     elif level.frequency == 'bimonthly' and int(level.first_day) >= int(level.second_day):
            //         error_message = _("The first day must be lower than the second day.")
            // if error_message:
            //     raise ValidationError(error_message)
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> CheckMaximumLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _check_maximum_leaves(self):
            // for level in self:
            //     if level.cap_accrued_time and level.maximum_leave <= 0:
            //         raise UserError(self.env._("You cannot have a balance cap on accrued time set to 0."))
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> CheckWorkedHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py) ---
            // def _check_worked_hours(self):
            // for level in self:
            //     if level.frequency == 'worked_hours' and level.accrued_gain_time == 'start':
            //         raise ValidationError(self.env._("You can't base accrued time on hours worked, because time is accrued at the start of the period."))
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeAccrualValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_accrual_validity(self):
            // for level in self:
            //     if level.action_with_unused_accruals == 'lost':
            //         level.accrual_validity = False
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeActionWithUnusedAccrualsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_action_with_unused_accruals(self):
            // for level in self:
            //     if not level.can_be_carryover:
            //         level.action_with_unused_accruals = 'lost'
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeAddedValueTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_added_value_type(self):
            // for level in self:
            //     if level.accrual_plan_id.time_off_type_id:
            //         level.added_value_type = "day" if level.accrual_plan_id.time_off_type_id.request_unit in ["day", "half_day"] else "hour"
            //     elif level.accrual_plan_id.level_ids and level.accrual_plan_id.level_ids[0] != level:
            //         level.added_value_type = level.accrual_plan_id.level_ids[0].added_value_type
            //     elif not level.added_value_type:
            //         level.added_value_type = "day"
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeCanModifyValueTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_can_modify_value_type(self):
            // for level in self:
            //     level.can_modify_value_type = not level.accrual_plan_id.time_off_type_id and level.accrual_plan_id.level_ids and level.accrual_plan_id.level_ids[0] == level
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeCarryoverOptionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_carryover_options(self):
            // for level in self:
            //     if level.action_with_unused_accruals == 'lost':
            //         level.carryover_options = 'unlimited'
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeFirstMonthDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_first_month_day(self):
            // self._set_day("first_month_day", "first_month")
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeFrequencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_frequency(self):
            // for level in self:
            //     if level.accrued_gain_time == 'start' and level.frequency == 'worked_hours':
            //         level.frequency = 'hourly'
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeMaximumLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_maximum_leave(self):
            // for level in self:
            //     if not level.cap_accrued_time:
            //         level.maximum_leave = 0
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeMilestoneDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_milestone_date(self):
            // for level in self:
            //     if level.start_count == 0:
            //         level.milestone_date = 'creation'
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeSecondMonthDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_second_month_day(self):
            // self._set_day("second_month_day", "second_month")
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_sequence(self):
            // # Not 100% accurate because of odd months/years, but good enough
            // start_type_multipliers = {
            //     'day': 1,
            //     'month': 30,
            //     'year': 365,
            // }
            // for level in self:
            //     level.sequence = level.start_count * start_type_multipliers[level.start_type]
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeYearlyDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _compute_yearly_day(self):
            // self._set_day("yearly_day", "yearly_month")
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetHourlyFrequenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _get_hourly_frequencies(self):
            // return ['hourly']
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py) ---
            // def _get_hourly_frequencies(self):
            // return super()._get_hourly_frequencies() + ["worked_hours"]
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetLevelTransitionDateInternalAsync(object allocation_start)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _get_level_transition_date(self, allocation_start):
            // if self.start_type == 'day':
            //     return allocation_start + relativedelta(days=self.start_count)
            // if self.start_type == 'month':
            //     return allocation_start + relativedelta(months=self.start_count)
            // if self.start_type == 'year':
            //     return allocation_start + relativedelta(years=self.start_count)
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetNextDateInternalAsync(object last_call)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _get_next_date(self, last_call):
            // """
            // Returns the next date with the given last call
            // """
            // self.ensure_one()
            // if self.frequency in self._get_hourly_frequencies() + ['daily']:
            //     return last_call + relativedelta(days=1)
            // 
            // if self.frequency == 'weekly':
            //     return last_call + relativedelta(days=1, weekday=int(self.week_day))
            // 
            // if self.frequency == 'bimonthly':
            //     first_date = last_call + relativedelta(day=int(self.first_day))
            //     second_date = last_call + relativedelta(day=int(self.second_day))
            //     if last_call < first_date:
            //         return first_date
            //     if last_call < second_date:
            //         return second_date
            //     return last_call + relativedelta(day=int(self.first_day), months=1)
            // 
            // if self.frequency == 'monthly':
            //     date = last_call + relativedelta(day=int(self.first_day))
            //     if last_call < date:
            //         return date
            //     return last_call + relativedelta(day=int(self.first_day), months=1)
            // 
            // if self.frequency == 'biyearly':
            //     first_date = last_call + relativedelta(month=int(self.first_month), day=int(self.first_month_day))
            //     second_date = last_call + relativedelta(month=int(self.second_month), day=int(self.second_month_day))
            //     if last_call < first_date:
            //         return first_date
            //     if last_call < second_date:
            //         return second_date
            //     return last_call + relativedelta(month=int(self.first_month), day=int(self.first_month_day), years=1)
            // 
            // if self.frequency == 'yearly':
            //     date = last_call + relativedelta(month=int(self.yearly_month), day=int(self.yearly_day))
            //     if last_call < date:
            //         return date
            //     return last_call + relativedelta(month=int(self.yearly_month), day=int(self.yearly_day), years=1)
            // 
            // raise ValidationError(_("Your frequency selection is not correct: please choose a frequency between theses options:"
            //     "Hourly, Daily, Weekly, Twice a month, Monthly, Twice a year and Yearly."))
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetPreviousDateInternalAsync(object last_call)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _get_previous_date(self, last_call):
            // """
            // Returns the date a potential previous call would have been at
            // For example if you have a monthly level giving 16/02 would return 01/02
            // Contrary to `_get_next_date` this function will return the 01/02 if that date is given
            // """
            // self.ensure_one()
            // if self.frequency in self._get_hourly_frequencies() + ['daily']:
            //     return last_call
            // 
            // if self.frequency == 'weekly':
            //     return last_call + relativedelta(days=-6, weekday=int(self.week_day))
            // 
            // if self.frequency == 'bimonthly':
            //     first_date = last_call + relativedelta(day=int(self.first_day))
            //     second_date = last_call + relativedelta(day=int(self.second_day))
            //     if last_call >= second_date:
            //         return second_date
            //     if last_call >= first_date:
            //         return first_date
            //     return last_call + relativedelta(day=int(self.second_day), months=-1)
            // 
            // if self.frequency == 'monthly':
            //     date = last_call + relativedelta(day=int(self.first_day))
            //     if last_call >= date:
            //         return date
            //     return last_call + relativedelta(day=int(self.first_day), months=-1, days=1)
            // 
            // if self.frequency == 'biyearly':
            //     first_date = last_call + relativedelta(month=int(self.first_month), day=int(self.first_month_day))
            //     second_date = last_call + relativedelta(month=int(self.second_month), day=int(self.second_month_day))
            //     if last_call >= second_date:
            //         return second_date
            //     if last_call >= first_date:
            //         return first_date
            //     return last_call + relativedelta(month=int(self.second_month), day=int(self.second_month_day), years=-1)
            // 
            // if self.frequency == 'yearly':
            //     year_date = last_call + relativedelta(month=int(self.yearly_month), day=int(self.yearly_day))
            //     if last_call >= year_date:
            //         return year_date
            //     return last_call + relativedelta(month=int(self.yearly_month), day=int(self.yearly_day), years=-1)
            // 
            // raise ValidationError(_("Your frequency selection is not correct: please choose a frequency between theses options:"
            //     "Hourly, Daily, Weekly, Twice a month, Monthly, Twice a year and Yearly."))
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> InverseAddedValueTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _inverse_added_value_type(self):
            // for level in self:
            //     if level.accrual_plan_id.level_ids[0] == level:
            //         level.accrual_plan_id.added_value_type = level.added_value_type
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> InverseMilestoneDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _inverse_milestone_date(self):
            // for level in self:
            //     if level.milestone_date == 'creation':
            //         level.start_count = 0
            */
            return default;
        }

        public async Task<HrLeaveAccrualLevel> SaveNewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def action_save_new(self):
            // return self.accrual_plan_id.action_create_accrual_plan_level()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveAccrualLevel> SetDayInternalAsync(object day_field, object month_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py) ---
            // def _set_day(self, day_field, month_field):
            // for level in self:
            //     # 2020 is a leap year, so monthrange(2020, february) will return [2, 29]
            //     level[day_field] = str(min(monthrange(2020, int(level[month_field]))[1], int(level[day_field])))
            */
            return default;
        }
    }
}