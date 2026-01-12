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
    public class IrQwebFieldSelectionAppService : ApplicationService, IIrQwebFieldSelectionAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldSelectionAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldSelectionable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // value = element.text_content().strip()
            // selection = field.get_description(self.env)['selection']
            // for k, v in selection:
            //     if value == v:
            //         return k
            // 
            // raise ValueError("No value found for label %s in selection %s" % (
            //                  value, selection))
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldSelectionable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super().get_available_options()
            // options.update(
            //     selection=dict(type='selection', string=_('Selection'), description=_('By default the widget uses the field information'), required=True)
            // )
            // options.update(
            //     selection=dict(type='json', string=_('Json'), description=_('By default the widget uses the field information'), required=True)
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldSelectionable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // if 'selection' not in options:
            //     options = dict(options, selection=dict(record._fields[field_name].get_description(self.env)['selection']))
            // return super().record_to_html(record, field_name, options)
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldSelectionable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if not value:
            //     return ''
            // return escape(options['selection'][value] or '')
            */
            return default;
        }
    }
}