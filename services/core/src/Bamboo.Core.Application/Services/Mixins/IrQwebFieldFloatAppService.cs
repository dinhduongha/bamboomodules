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
    public partial class IrQwebFieldFloatAppService : ApplicationService, IIrQwebFieldFloatAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldFloatAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        [ApiModel]
        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldFloatable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // lang = self.user_lang()
            // value = element.text_content().strip()
            // return float(value.replace(lang.thousands_sep or '', '')
            //                   .replace(lang.decimal_point, '.'))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldFloatable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super().get_available_options()
            // options.update(
            //     precision=dict(type='integer', string=_('Rounding precision')),
            // )
            // return options
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldFloatable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // if 'precision' not in options and 'decimal_precision' not in options:
            //     _, precision = record._fields[field_name].get_digits(record.env) or (None, None)
            //     options = dict(options, precision=precision)
            // return super().record_to_html(record, field_name, options)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldFloatable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if 'decimal_precision' in options:
            //     precision = self.env['decimal.precision'].precision_get(options['decimal_precision'])
            // else:
            //     precision = options['precision']
            // 
            // if precision is None:
            //     fmt = '%f'
            // else:
            //     value = float_utils.float_round(value, precision_digits=precision)
            //     fmt = '%.{precision}f'.format(precision=precision)
            // 
            // formatted = self.user_lang().format(fmt, value, grouping=True).replace(r'-', '-\N{ZERO WIDTH NO-BREAK SPACE}')
            // 
            // # %f does not strip trailing zeroes. %g does but its precision causes
            // # it to switch to scientific notation starting at a million *and* to
            // # strip decimals. So use %f and if no precision was specified manually
            // # strip trailing 0.
            // if precision is None:
            //     formatted = re.sub(r'(?:(0|\d+?)0+)$', r'\1', formatted)
            // 
            // return formatted
            */
            return default;
        }
    }
}