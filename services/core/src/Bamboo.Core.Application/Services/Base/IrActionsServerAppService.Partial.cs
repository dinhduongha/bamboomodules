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
    public partial class IrActionsServerAppService
    {

        protected async Task<IrActServer> CanExecuteActionOnRecordsInternalAsync(object records)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _can_execute_action_on_records) ---
            */
            return default;
        }

        protected async Task<IrActServer> CheckChildrenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_children) ---
            */
            return default;
        }

        protected async Task<IrActServer> CheckPythonCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_python_code) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeActivityInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_activity_info) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeActivityUserInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_activity_user_info) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeAllowedStatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_allowed_states) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeAvailableModelIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _compute_available_model_ids) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_available_model_ids) ---
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _compute_available_model_ids) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_available_model_ids) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeCrudRelationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_crud_relations) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeFollowersInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_followers_info) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeFollowersTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_followers_type) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeMailPostAutofollowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_mail_post_autofollow) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeMailPostMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_mail_post_method) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeShowCodeHistoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_show_code_history) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeSmsMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _compute_sms_method) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeSmsTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _compute_sms_template_id) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_template_id) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeValueFieldToShowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_value_field_to_show) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_warning) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWebhookSamplePayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_webhook_sample_payload) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeWebsiteUrlInternalAsync(object website_path, Guid xml_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<IrActServer> ComputeXmlIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _compute_xml_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrActServer> DefaultUpdatePathInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _default_update_path) ---
            */
            return default;
        }

        protected async Task<IrActServer> EvalValueInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _eval_value) ---
            */
            return default;
        }

        protected async Task<IrActServer> GenerateActionNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _generate_action_name) ---
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _generate_action_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _generate_action_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrActServer> GetChildrenDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _get_children_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_children_domain) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetEvalContextInternalAsync(object action)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _get_eval_context) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _get_eval_context) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _get_eval_context) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_eval_context) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetReadableFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetRelationChainInternalAsync(object searched_field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_relation_chain) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetRunnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_runner) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetWarningMessagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _get_warning_messages) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _get_warning_messages) ---
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _get_warning_messages) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_warning_messages) ---
            */
            return default;
        }

        protected async Task<IrActServer> GetWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _get_website_url) ---
            */
            return default;
        }

        protected async Task<IrActServer> IsRecomputeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _is_recompute) ---
            */
            return default;
        }

        protected async Task<IrActServer> NameDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _name_depends) ---
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _name_depends) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _name_depends) ---
            */
            return default;
        }

        protected async Task<IrActServer> OnchangeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _onchange_name) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionCodeMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _run_action_code_multi) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_code_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionFollowersMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_followers_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionMailPostMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_mail_post_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionNextActivityInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_next_activity) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectCopyInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_copy) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectCreateInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_create) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionObjectWriteInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_write) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionRemoveFollowersMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_remove_followers_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionSmsMultiInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _run_action_sms_multi) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunActionWebhookInternalAsync(object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_webhook) ---
            */
            return default;
        }

        protected async Task<IrActServer> RunInternalAsync(object records, object eval_context)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrActServer> SelectionTargetModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _selection_target_model) ---
            */
            return default;
        }

        protected async Task<IrActServer> SetCrudModelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_crud_model_id) ---
            */
            return default;
        }

        protected async Task<IrActServer> SetResourceRefInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_resource_ref) ---
            */
            return default;
        }

        protected async Task<IrActServer> SetSelectionValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_selection_value) ---
            */
            return default;
        }

        protected async Task<IrActServer> TraversePathInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _traverse_path) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrActServer> WarningDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _warning_depends) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _warning_depends) ---
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _warning_depends) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _warning_depends) ---
            */
            return default;
        }
    }
}