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
    public partial class ResLangAppService : GenericAppService<ResLang>, IResLangAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResLangAppService(IRepository<ResLang, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ResLang> ActivateLangsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_lang.py, METHOD: action_activate_langs) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: action_activate_langs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<object> CACHEDFIELDSAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: CACHED_FIELDS) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResLang> CopyDataAsync(ResLangCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<string> FormatAsync(ResLangFormatRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: format) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<List<object>> GetInstalledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: get_installed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResLang> GetLocalesForSpreadsheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py, METHOD: get_locales_for_spreadsheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResLang> InstallLangAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: install_lang) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResLang> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResLang> input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_lang.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_lang.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_lang.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}