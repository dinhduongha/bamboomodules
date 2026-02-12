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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class MailScheduledMessageAppService
    {

        [ApiModel]
        protected async Task<MailScheduledMessage> CheckInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _check) ---
            */
            return default;
        }

        protected async Task<MailScheduledMessage> CheckModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _check_model) ---
            */
            return default;
        }

        protected async Task<MailScheduledMessage> CheckScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _check_scheduled_date) ---
            */
            return default;
        }

        protected async Task<MailScheduledMessage> MessageCreatedHookInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _message_created_hook) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailScheduledMessage> NotificationParametersWhitelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _notification_parameters_whitelist) ---
            */
            return default;
        }

        protected async Task<MailScheduledMessage> PostMessageInternalAsync(object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _post_message) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailScheduledMessage> PostMessagesCronInternalAsync(object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _post_messages_cron) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailScheduledMessage> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<MailScheduledMessage> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }
    }
}