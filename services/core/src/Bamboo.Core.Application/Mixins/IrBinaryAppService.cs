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
    public partial class IrBinaryAppService : ApplicationService, IIrBinaryAppService
    {

        public IrBinaryAppService() 
        {

        }

        public async Task<TEntity> FindRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object res_model, Guid res_id, object access_token, object field) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_binary.py, METHOD: _find_record) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _find_record) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageStreamFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object filename, object filename_field, object mimetype, object default_mimetype, object placeholder, object width, object height, object crop, object quality) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _get_image_stream_from) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderStreamInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _get_placeholder_stream) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreamFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object filename, object filename_field, object mimetype, object default_mimetype) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _get_stream_from) ---
            */
            return default;
        }

        public async Task<TEntity> PlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> RecordToStreamInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name) where TEntity : IEntity<Guid>, IIrBinaryable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_binary.py, METHOD: _record_to_stream) ---
            */
            return default;
        }
    }
}