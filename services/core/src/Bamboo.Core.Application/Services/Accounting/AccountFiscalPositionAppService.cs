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
    public partial class AccountFiscalPositionAppService : GenericAppService<AccountFiscalPosition>, IAccountFiscalPositionAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountFiscalPositionAppService(IRepository<AccountFiscalPosition, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<AccountFiscalPosition> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountFiscalPosition> CreateForeignTaxesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_create_foreign_taxes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountFiscalPosition> MapAccountAsync(AccountFiscalPositionMapAccountRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: map_account) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountFiscalPosition> MapTaxAsync(AccountFiscalPositionMapTaxRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: map_tax) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountFiscalPosition> OpenRelatedTaxesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_related_taxes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}