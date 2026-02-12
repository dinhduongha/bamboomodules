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
    public partial class IrQwebFieldImageAppService : ApplicationService, IIrQwebFieldImageAppService
    {

        public IrQwebFieldImageAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: from_html) ---
            --- METHOD SOURCE (MODULE: web_unsplash, FILE: ir_qweb_fields.py, METHOD: from_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSrcDataB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: _get_src_data_b64) ---
            */
            return default;
        }

        public async Task<TEntity> GetSrcUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_qweb_fields.py, METHOD: _get_src_urls) ---
            */
            return default;
        }

        public async Task<TEntity> LoadLocalUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: load_local_url) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRemoteUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py, METHOD: load_remote_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_qweb_fields.py, METHOD: record_to_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: value_to_html) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py, METHOD: value_to_html) ---
            */
            return default;
        }
    }
}