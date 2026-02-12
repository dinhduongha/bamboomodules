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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base", Category = "Base")]
    public partial class IrCronMixinAppService : ApplicationService, IIrCronMixinAppService
    {

        public IrCronMixinAppService()
        {

        }

        protected async Task<object> AcquireOneJobInternalAsync(Guid job_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _acquire_one_job) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAutomationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: action_open_automation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: action_open_parent_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenScheduledActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: action_open_scheduled_action) ---
            */
            return default;
        }

        public async Task<TEntity> AddProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _add_progress) ---
            */
            return default;
        }

        public async Task<TEntity> CallbackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cron_name, Guid server_action_id) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _callback) ---
            */
            return default;
        }

        protected async Task<object> CheckModulesStateInternalAsync(object jobs)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _check_modules_state) ---
            */
            return default;
        }

        protected async Task<object> CheckVersionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _check_version) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClearScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _clear_schedule) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<float> CommitProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities, int processed) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _commit_progress) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCronNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _compute_cron_name) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: default_get) ---
            */
            return default;
        }

        protected async Task<List<Dictionary<string, object>>> GetAllReadyJobsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _get_all_ready_jobs) ---
            */
            return default;
        }

        protected async Task<object> GetReadySqlConditionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _get_ready_sql_condition) ---
            */
            return default;
        }

        public async Task<TEntity> MethodDirectTriggerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: method_direct_trigger) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyAdminInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_cron.py, METHOD: _notify_admin) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notify_admin) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notify_progress) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifydbInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _notifydb) ---
            */
            return default;
        }

        protected async Task<object> ProcessJobInternalAsync(object cron_cr, object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _process_job) ---
            */
            return default;
        }

        protected async Task<object> ProcessJobsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _process_jobs) ---
            */
            return default;
        }

        protected async Task<object> ProcessJobsLoopInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _process_jobs_loop) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RescheduleAsapInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _reschedule_asap) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RescheduleLaterInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _reschedule_later) ---
            */
            return default;
        }

        protected async Task<object> RunJobInternalAsync(object job)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _run_job) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToggleAsync<TEntity>(IEnumerable<TEntity> entities, object model, object domain) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: toggle) ---
            */
            return default;
        }

        public async Task<TEntity> TriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object at) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _trigger) ---
            */
            return default;
        }

        public async Task<TEntity> TriggerListInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<DateTime> at_list) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _trigger_list) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkUnlessRunningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _unlink_unless_running) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdateFailureCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job, object status) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: _update_failure_count) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IIrCronable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_cron.py, METHOD: write) ---
            */
            return default;
        }
    }
}