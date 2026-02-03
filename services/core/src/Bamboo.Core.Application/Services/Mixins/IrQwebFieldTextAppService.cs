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
    public partial class IrQwebFieldTextAppService : ApplicationService, IIrQwebFieldTextAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldTextAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        [ApiModel]
        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldTextable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // return html_to_text(element)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldTextable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // """
            // Escapes the value and converts newlines to br. This is bullshit.
            // """
            // return nl2br(value) if value else ''
            */
            return default;
        }
    }
}