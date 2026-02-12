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
    public partial class MailNotificationAppService
    {

        protected async Task<MailNotification> ComputeSmsIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_notification.py, METHOD: _compute_sms_id) ---
            */
            return default;
        }

        protected async Task<MailNotification> FilteredForWebClientInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_notification.py, METHOD: _filtered_for_web_client) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailNotification> GcNotificationsInternalAsync(object max_age_days)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_notification.py, METHOD: _gc_notifications) ---
            */
            return default;
        }

        protected async Task<MailNotification> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_notification.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }
    }
}