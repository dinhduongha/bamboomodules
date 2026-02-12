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
    [Module("base", Category = "Base")]
    public partial class IrQwebFieldIntegerAppService : ApplicationService, IIrQwebFieldIntegerAppService
    {

        public IrQwebFieldIntegerAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: from_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: get_available_options) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: value_to_html) ---
            */
            return default;
        }
    }
}