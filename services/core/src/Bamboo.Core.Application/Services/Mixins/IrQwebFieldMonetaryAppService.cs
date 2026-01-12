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
    public class IrQwebFieldMonetaryAppService : ApplicationService, IIrQwebFieldMonetaryAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldMonetaryAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // lang = self.user_lang()
            // 
            // value = element.find('span').text_content().strip()
            // 
            // return float(value.replace(lang.thousands_sep or '', '')
            //                   .replace(lang.decimal_point, '.'))
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(MonetaryConverter, self).get_available_options()
            // options.update(
            //     from_currency=dict(type='model', params='res.currency', string=_('Original currency')),
            //     display_currency=dict(type='model', params='res.currency', string=_('Display currency'), required="value_to_html"),
            //     date=dict(type='date', string=_('Date'), description=_('Date used for the original currency (only used for t-esc). by default use the current date.')),
            //     company_id=dict(type='model', params='res.company', string=_('Company'), description=_('Company used for the original currency (only used for t-esc). By default use the user company')),
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // options = dict(options)
            // #currency should be specified by monetary field
            // field = record._fields[field_name]
            // 
            // if not options.get('display_currency') and field.type == 'monetary' and field.get_currency_field(record):
            //     options['display_currency'] = record[field.get_currency_field(record)]
            // if not options.get('display_currency'):
            //     # search on the model if they are a res.currency field to set as default
            //     fields = record._fields.items()
            //     currency_fields = [k for k, v in fields if v.type == 'many2one' and v.comodel_name == 'res.currency']
            //     if currency_fields:
            //         options['display_currency'] = record[currency_fields[0]]
            // if 'date' not in options:
            //     options['date'] = record._context.get('date')
            // if 'company_id' not in options:
            //     options['company_id'] = record._context.get('company_id')
            // 
            // return super(MonetaryConverter, self).record_to_html(record, field_name, options)
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // display_currency = options['display_currency']
            // 
            // if not isinstance(value, (int, float)):
            //     raise ValueError(_("The value send to monetary field is not a number."))
            // 
            // # lang.format mandates a sprintf-style format. These formats are non-
            // # minimal (they have a default fixed precision instead), and
            // # lang.format will not set one by default. currency.round will not
            // # provide one either. So we need to generate a precision value
            // # (integer > 0) from the currency's rounding (a float generally < 1.0).
            // fmt = "%.{0}f".format(options.get('decimal_places', display_currency.decimal_places))
            // 
            // if options.get('from_currency'):
            //     date = options.get('date') or fields.Date.today()
            //     company_id = options.get('company_id')
            //     if company_id:
            //         company = self.env['res.company'].browse(company_id)
            //     else:
            //         company = self.env.company
            //     value = options['from_currency']._convert(value, display_currency, company, date)
            // 
            // lang = self.user_lang()
            // formatted_amount = lang.format(fmt, display_currency.round(value), grouping=True)\
            //     .replace(r' ', '\N{NO-BREAK SPACE}').replace(r'-', '-\N{ZERO WIDTH NO-BREAK SPACE}')
            // 
            // pre = post = ''
            // if display_currency.position == 'before':
            //     pre = '{symbol}\N{NO-BREAK SPACE}'.format(symbol=display_currency.symbol or '')
            // else:
            //     post = '\N{NO-BREAK SPACE}{symbol}'.format(symbol=display_currency.symbol or '')
            // 
            // if options.get('label_price') and lang.decimal_point in formatted_amount:
            //     sep = lang.decimal_point
            //     integer_part, decimal_part = formatted_amount.split(sep)
            //     integer_part += sep
            //     return Markup('{pre}<span class="oe_currency_value">{0}</span><span class="oe_currency_value" style="font-size:0.5em">{1}</span>{post}').format(integer_part, decimal_part, pre=pre, post=post)
            // 
            // return Markup('{pre}<span class="oe_currency_value">{0}</span>{post}').format(formatted_amount, pre=pre, post=post)
            */
            return default;
        }
    }
}