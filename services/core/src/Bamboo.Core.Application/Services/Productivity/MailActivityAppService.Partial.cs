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
    public partial class MailActivityAppService
    {

        protected async Task<MailActivity> ActionDoneInternalAsync(object feedback, List<Guid> attachment_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: mail_activity.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _action_done) ---
            */
            return default;
        }

        protected async Task<MailActivity> CheckAccessInternalAsync(string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _check_access) ---
            */
            return default;
        }

        protected async Task<MailActivity> ClassifyByModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _classify_by_model) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeCanWriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_can_write) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeDateDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_date_done) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeHasRecommendedActivitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_has_recommended_activities) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeResNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_res_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailActivity> ComputeStateFromDateInternalAsync(object date_deadline, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_state_from_date) ---
            */
            return default;
        }

        protected async Task<MailActivity> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _compute_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailActivity> DefaultActivityTypeForModelInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _default_activity_type_for_model) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailActivity> DefaultActivityTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _default_activity_type) ---
            */
            return default;
        }

        protected async Task<MailActivity> GcDeleteOldOverdueActivitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _gc_delete_old_overdue_activities) ---
            */
            return default;
        }

        protected async Task<object> MakeAccessErrorInternalAsync(string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _make_access_error) ---
            */
            return default;
        }

        protected async Task<MailActivity> OnchangeActivityTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _onchange_activity_type_id) ---
            */
            return default;
        }

        protected async Task<MailActivity> OnchangePreviousActivityTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _onchange_previous_activity_type_id) ---
            */
            return default;
        }

        protected async Task<MailActivity> OnchangeRecommendedActivityTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _onchange_recommended_activity_type_id) ---
            */
            return default;
        }

        protected async Task<MailActivity> PrepareNextActivityValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _prepare_next_activity_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailActivity> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<MailActivity> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: mail_activity.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: mail_activity.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }
    }
}