using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base")]
    public class IrQwebFieldRelativeAppService : ApplicationService, IIrQwebFieldRelativeAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldRelativeAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldRelativeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(RelativeDatetimeConverter, self).get_available_options()
            // options.update(
            //     now=dict(type='datetime', string=_('Reference date'), description=_('Date to compare with the field value, by default use the current date.'))
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldRelativeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // if 'now' not in options:
            //     options = dict(options, now=record._fields[field_name].now())
            // return super(RelativeDatetimeConverter, self).record_to_html(record, field_name, options)
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldRelativeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // locale = babel_locale_parse(self.user_lang().code)
            // 
            // if isinstance(value, str):
            //     value = fields.Datetime.from_string(value)
            // 
            // # value should be a naive datetime in UTC. So is fields.Datetime.now()
            // reference = fields.Datetime.from_string(options['now'])
            // 
            // return babel.dates.format_timedelta(value - reference, add_direction=True, locale=locale)
            */
            return default;
        }
    }
}