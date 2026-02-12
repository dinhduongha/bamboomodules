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
    public partial class SmsSmsAppService
    {

        protected async Task<SmsSms> ComputeSmsTrackerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _compute_sms_tracker_id) ---
            */
            return default;
        }

        protected async Task<SmsSms> GcDeviceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _gc_device) ---
            */
            return default;
        }

        protected async Task<SmsSms> GetSendBatchSizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _get_send_batch_size) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: _get_send_batch_size) ---
            */
            return default;
        }

        protected async Task<SmsSms> GetSmsCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _get_sms_company) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: _get_sms_company) ---
            */
            return default;
        }

        protected async Task<SmsSms> HandleCallResultHookInternalAsync(object results)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _handle_call_result_hook) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: _handle_call_result_hook) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SmsSms> ProcessQueueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _process_queue) ---
            */
            return default;
        }

        protected async Task<SmsSms> SendInternalAsync(object unlink_failed, object unlink_sent, object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _send) ---
            */
            return default;
        }

        protected async Task<SmsSms> SendWithApiInternalAsync(object sms_api, object unlink_failed, object unlink_sent, object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _send_with_api) ---
            */
            return default;
        }

        protected async Task<SmsSms> SplitBatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _split_batch) ---
            */
            return default;
        }

        protected async Task<SmsSms> SplitByApiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _split_by_api) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: _split_by_api) ---
            */
            return default;
        }

        protected async Task<SmsSms> UpdateBodyShortLinksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: sms_sms.py, METHOD: _update_body_short_links) ---
            */
            return default;
        }

        protected async Task<SmsSms> UpdateSmsStateAndTrackersInternalAsync(object new_state, object failure_type)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: _update_sms_state_and_trackers) ---
            */
            return default;
        }
    }
}