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
    [Module("Iap", Category = "Misc", Depends = new[] { "web", "base_setup" })]
    public partial class IapAccountAppService : GenericAppService<IapAccount>, IIapAccountAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public IapAccountAppService(IRepository<IapAccount, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<IapAccount> BuyCreditsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: action_buy_credits) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IapAccount> GetAccountIdAsync(IapAccountGetAccountIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_account_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IapAccount> GetAsync(IapAccountGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IapAccount> GetConfigAccountUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_config_account_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IapAccount> GetCreditsAsync(IapAccountGetCreditsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_credits) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IapAccount> GetCreditsUrlAsync(IapAccountGetCreditsUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_credits_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IapAccount> OpenRegistrationWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: action_open_registration_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IapAccount> OpenSenderNameWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: action_open_sender_name_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IapAccount> ValidateWarningAlertsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: validate_warning_alerts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IapAccount> WebReadAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: web_read) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IapAccount> WebSaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: web_save) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}