using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class IrCronAppService
    {

        protected async Task<IrCron> AcquireOneJobInternalAsync(object cr, Guid job_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _acquire_one_job) ---
            */
            return default;
        }

        protected async Task<IrCron> AddProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _add_progress) ---
            */
            return default;
        }

        protected async Task<IrCron> CallbackInternalAsync(object cron_name, Guid server_action_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _callback) ---
            */
            return default;
        }

        protected async Task<IrCron> CheckModulesStateInternalAsync(object cr, object jobs)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _check_modules_state) ---
            */
            return default;
        }

        protected async Task<IrCron> CheckVersionInternalAsync(object cron_cr)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _check_version) ---
            */
            return default;
        }

        protected async Task<IrCron> ComputeCronNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _compute_cron_name) ---
            */
            return default;
        }

        protected async Task<IrCron> GetAllReadyJobsInternalAsync(object cr)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _get_all_ready_jobs) ---
            */
            return default;
        }

        protected async Task<IrCron> NotifyAdminInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_cron.py, METHOD: _notify_admin) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notify_admin) ---
            */
            return default;
        }

        protected async Task<IrCron> NotifyProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notify_progress) ---
            */
            return default;
        }

        protected async Task<IrCron> NotifydbInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notifydb) ---
            */
            return default;
        }

        protected async Task<IrCron> ProcessJobInternalAsync(object db, object cron_cr, object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _process_job) ---
            */
            return default;
        }

        protected async Task<IrCron> ProcessJobsInternalAsync(object db_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _process_jobs) ---
            */
            return default;
        }

        protected async Task<IrCron> RescheduleAsapInternalAsync(object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _reschedule_asap) ---
            */
            return default;
        }

        protected async Task<IrCron> RescheduleLaterInternalAsync(object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _reschedule_later) ---
            */
            return default;
        }

        protected async Task<IrCron> RunJobInternalAsync(object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _run_job) ---
            */
            return default;
        }

        protected async Task<IrCron> TriggerInternalAsync(object at)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _trigger) ---
            */
            return default;
        }

        protected async Task<IrCron> TriggerListInternalAsync(object at_list)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _trigger_list) ---
            */
            return default;
        }

        protected async Task<IrCron> TryLockInternalAsync(object lockfk)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _try_lock) ---
            */
            return default;
        }

        protected async Task<IrCron> UpdateFailureCountInternalAsync(object job, object status)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _update_failure_count) ---
            */
            return default;
        }
    }
}