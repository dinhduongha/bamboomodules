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
    [Module("BaseModule", Category = "Base")]
    public partial class ResCurrencyAppService : GenericAppService<ResCurrency>, IResCurrencyAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResCurrencyAppService(IRepository<ResCurrency, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ResCurrency> AmountToTextAsync(ResCurrencyAmountToTextRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: amount_to_text) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCurrency> CompareAmountsAsync(ResCurrencyCompareAmountsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: compare_amounts) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCurrency> FormatAsync(ResCurrencyFormatRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: format) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCurrency> GetAllCurrenciesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: get_all_currencies) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCurrency> GetCompanyCurrencyForSpreadsheetAsync(ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: res_currency.py, METHOD: get_company_currency_for_spreadsheet) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCurrency> IsZeroAsync(ResCurrencyIsZeroRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: is_zero) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCurrency> RoundAsync(ResCurrencyRoundRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: round) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResCurrency> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: res_currency.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}