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
    public partial class DiscussChannelRtcSessionAppService
    {

        protected async Task<DiscussChannelRtcSession> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> DeleteInactiveRtcSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _delete_inactive_rtc_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> GcInactiveSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _gc_inactive_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> GetStoreExtraFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _get_store_extra_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannelRtcSession> InactiveRtcSessionDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _inactive_rtc_session_domain) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> NotifyPeersInternalAsync(object notifications)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _notify_peers) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> UpdateAndBroadcastInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: _update_and_broadcast) ---
            */
            return default;
        }
    }
}