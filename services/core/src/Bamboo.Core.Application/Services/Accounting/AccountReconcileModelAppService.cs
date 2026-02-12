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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountReconcileModelAppService : GenericAppService<AccountReconcileModel>, IAccountReconcileModelAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public AccountReconcileModelAppService(IRepository<AccountReconcileModel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<AccountReconcileModel> CopyDataAsync(AccountReconcileModelCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> ReconcileStatAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_reconcile_stat) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> SetAutoReconcileAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_set_auto_reconcile) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> SetManualAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_set_manual) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}