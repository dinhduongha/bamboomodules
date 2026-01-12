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
    public class IrQwebFieldIntegerAppService : ApplicationService, IIrQwebFieldIntegerAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldIntegerAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // lang = self.user_lang()
            // value = element.text_content().strip()
            // return int(value.replace(lang.thousands_sep or '', ''))
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(IntegerConverter, self).get_available_options()
            // options.update(
            //     format_decimalized_number=dict(type='boolean', string=_('Decimalized number')),
            //     precision_digits=dict(type='integer', string=_('Precision Digits')),
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldIntegerable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if options.get('format_decimalized_number'):
            //     return tools.misc.format_decimalized_number(value, options.get('precision_digits', 1))
            // return self.user_lang().format('%d', value, grouping=True).replace(r'-', '-\N{ZERO WIDTH NO-BREAK SPACE}')
            */
            return default;
        }
    }
}