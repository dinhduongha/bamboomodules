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
    public partial class BaseAutomationAppService
    {

        [ApiModel]
        protected async Task<BaseAutomation> AddPostmortemInternalAsync(object e)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _add_postmortem) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckActionServerModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_action_server_model) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckInternalAsync(object automatic, object use_new_cursor)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckTimeTriggerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_time_trigger) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckTriggerFieldsInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger_fields) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckTriggerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> CheckTriggerStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger_state) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeActionServerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_action_server_ids) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeFilterDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_filter_domain) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeFilterPreDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_filter_pre_domain) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeOnChangeFieldIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_on_change_field_ids) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgDateCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_calendar_id) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgDateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_id) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgDateRangeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_range_data) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgFieldRefInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_field_ref) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgFieldRefModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_field_ref_model_name) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTrgSelectionFieldIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_selection_field_id) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTriggerFieldIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trigger_field_ids) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeTriggerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trigger) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ComputeUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_url) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseAutomation> CronProcessTimeBasedActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _cron_process_time_based_actions) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ExecuteWebhookInternalAsync(object payload)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _execute_webhook) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> FilterPostExportDomainInternalAsync(object records, object feedback)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_post_export_domain) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> FilterPostInternalAsync(object records, object feedback)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_post) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> FilterPreInternalAsync(object records, object feedback)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_pre) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> GetActionsInternalAsync(object records, object triggers)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_actions) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseAutomation> GetCalendarInternalAsync(object automation, object record)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_calendar) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> GetCronIntervalInternalAsync(object automations)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_cron_interval) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> GetEvalContextInternalAsync(object payload)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_eval_context) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> GetTriggerSpecificFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_trigger_specific_field) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> HasTriggerOnchangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _has_trigger_onchange) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> InverseModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _inverse_model_name) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> OnchangeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_domain) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> OnchangeTrgDateRangeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trg_date_range_data) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> OnchangeTriggerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trigger) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> OnchangeTriggerOrActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trigger_or_actions) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> PrepareLogginValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _prepare_loggin_values) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> ProcessInternalAsync(object records, object domain_post)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _process) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> RegisterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _register_hook) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> SearchTimeBasedAutomationRecordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _search_time_based_automation_records) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> UnregisterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _unregister_hook) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> UpdateCronInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _update_cron) ---
            */
            return default;
        }

        protected async Task<BaseAutomation> UpdateRegistryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _update_registry) ---
            */
            return default;
        }
    }
}