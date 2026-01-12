using Volo.Abp.ObjectMapping;
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
    public class IrQwebFieldImageUrlAppService : ApplicationService, IIrQwebFieldImageUrlAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldImageUrlAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetSrcUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageUrlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_qweb_fields.py) ---
            // def _get_src_urls(self, record, field_name, options):
            // image_url = record[options.get('preview_image', field_name)]
            // return image_url, options.get("zoom", None)
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageUrlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // return Markup('<img src="%s">' % (value))
            */
            return default;
        }
    }
}