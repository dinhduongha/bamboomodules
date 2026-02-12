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
    public partial class MailActivityTypeAppService
    {

        protected async Task<MailActivityType> CheckActivityTypeResModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _check_activity_type_res_model) ---
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeDelayLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _compute_delay_label) ---
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeInitialResModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _compute_initial_res_model) ---
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeSuggestedNextTypeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _compute_suggested_next_type_ids) ---
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeTriggeredNextTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _compute_triggered_next_type_id) ---
            */
            return default;
        }

        protected async Task<MailActivityType> GetDateDeadlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _get_date_deadline) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailActivityType> GetModelInfoByXmlidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: mail_activity_type.py, METHOD: _get_model_info_by_xmlid) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: mail_activity_type.py, METHOD: _get_model_info_by_xmlid) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _get_model_info_by_xmlid) ---
            */
            return default;
        }

        protected async Task<MailActivityType> GetModelSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _get_model_selection) ---
            */
            return default;
        }

        protected async Task<MailActivityType> InverseSuggestedNextTypeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _inverse_suggested_next_type_ids) ---
            */
            return default;
        }

        protected async Task<MailActivityType> InverseTriggeredNextTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _inverse_triggered_next_type_id) ---
            */
            return default;
        }

        protected async Task<MailActivityType> OnchangeResModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _onchange_res_model) ---
            */
            return default;
        }

        protected async Task<MailActivityType> UnlinkExceptTodoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py, METHOD: _unlink_except_todo) ---
            */
            return default;
        }
    }
}