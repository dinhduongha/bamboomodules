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
    public partial class TransifexTranslationAppService : ApplicationService, ITransifexTranslationAppService
    {

        public TransifexTranslationAppService() 
        {

        }

        public async Task<TEntity> GetTransifexProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITransifexTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_translation.py, METHOD: _get_transifex_projects) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateTransifexUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object translations) where TEntity : IEntity<Guid>, ITransifexTranslationable
        {
            /*
            --- METHOD SOURCE (MODULE: transifex, FILE: transifex_translation.py, METHOD: _update_transifex_url) ---
            */
            return default;
        }
    }
}