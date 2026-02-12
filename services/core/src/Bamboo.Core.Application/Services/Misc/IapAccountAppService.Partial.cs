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
    public partial class IapAccountAppService
    {

        protected async Task<IapAccount> GetAccountInfoInternalAsync(Guid account_id, object balance, object information)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _get_account_info) ---
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: _get_account_info) ---
            */
            return default;
        }

        protected async Task<IapAccount> GetAccountInformationFromIapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _get_account_information_from_iap) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IapAccount> HashIapTokenInternalAsync(object key)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _hash_iap_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IapAccount> SendErrorNotificationInternalAsync(object message, object title)
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_error_notification) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IapAccount> SendNoCreditNotificationInternalAsync(object service_name, object title)
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_no_credit_notification) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IapAccount> SendStatusNotificationInternalAsync(object message, object status, object title)
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_status_notification) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IapAccount> SendSuccessNotificationInternalAsync(object message, object title)
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_success_notification) ---
            */
            return default;
        }
    }
}