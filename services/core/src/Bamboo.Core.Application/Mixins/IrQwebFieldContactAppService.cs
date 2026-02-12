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
    public partial class IrQwebFieldContactAppService : ApplicationService, IIrQwebFieldContactAppService
    {

        public IrQwebFieldContactAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldContactable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: attributes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldContactable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_qweb_fields.py, METHOD: get_available_options) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: get_available_options) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> contact_ids, object options) where TEntity : IEntity<Guid>, IIrQwebFieldContactable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: get_record_to_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldContactable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: value_to_html) ---
            */
            return default;
        }
    }
}