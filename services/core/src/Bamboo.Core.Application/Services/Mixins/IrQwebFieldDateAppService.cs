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
    public class IrQwebFieldDateAppService : ApplicationService, IIrQwebFieldDateAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldDateAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldDateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def attributes(self, record, field_name, options, values):
            // attrs = super(Date, self).attributes(record, field_name, options, values)
            // if options.get('inherit_branding'):
            //     attrs['data-oe-original'] = record[field_name]
            // 
            //     if record._fields[field_name].type == 'datetime':
            //         attrs = self.env['ir.qweb.field.datetime'].attributes(record, field_name, options, values)
            //         attrs['data-oe-type'] = 'datetime'
            //         return attrs
            // 
            //     lg = get_lang(self.env, self.env.user.lang)
            //     locale = babel_locale_parse(lg.code)
            //     babel_format = value_format = posix_to_ldml(lg.date_format, locale=locale)
            // 
            //     if record[field_name]:
            //         date = fields.Date.from_string(record[field_name])
            //         value_format = babel.dates.format_date(date, format=babel_format, locale=locale)
            // 
            //     attrs['data-oe-original-with-format'] = value_format
            // return attrs
            */
            return default;
        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldDateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // value = element.text_content().strip()
            // if not value:
            //     return False
            // 
            // lg = get_lang(self.env, self.env.user.lang)
            // date = datetime.strptime(value, lg.date_format)
            // return fields.Date.to_string(date)
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldDateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(DateConverter, self).get_available_options()
            // options.update(
            //     format=dict(type='string', string=_('Date format'))
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldDateable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // return format_date(self.env, value, date_format=options.get('format'))
            */
            return default;
        }
    }
}