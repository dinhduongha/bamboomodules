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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("transifex", Category = "Misc", Depends = new[] { "base", "web" })]
    public partial class TransifexCodeTranslationAppService : ApplicationService, ITransifexCodeTranslationAppService
    {

        public TransifexCodeTranslationAppService() 
        {

        }

        public async Task<TEntity> ComputeTransifexUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_code_translation.py, METHOD: _compute_transifex_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLanguagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_code_translation.py, METHOD: _get_languages) ---
            */
            return default;
        }

        public async Task<TEntity> LoadCodeTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module_names, object langs) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_code_translation.py, METHOD: _load_code_translations) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCodeTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_code_translation.py, METHOD: _open_code_translations) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexCodeTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_code_translation.py, METHOD: reload) ---
            */
            return default;
        }
    }
}