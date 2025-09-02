using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base")]
    public class IrQwebFieldBarcodeAppService : ApplicationService, IIrQwebFieldBarcodeAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldBarcodeAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldBarcodeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(BarcodeConverter, self).get_available_options()
            // options.update(
            //     symbology=dict(type='string', string=_('Barcode symbology'), description=_('Barcode type, eg: UPCA, EAN13, Code128'), default_value='Code128'),
            //     width=dict(type='integer', string=_('Width'), default_value=600),
            //     height=dict(type='integer', string=_('Height'), default_value=100),
            //     humanreadable=dict(type='integer', string=_('Human Readable'), default_value=0),
            //     quiet=dict(type='integer', string='Quiet', default_value=1),
            //     mask=dict(type='string', string='Mask', default_value='')
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldBarcodeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options=None):
            // if not value:
            //     return ''
            // if not bool(re.match(r'^[\x00-\x7F]+$', value)):
            //     return nl2br(value)
            // barcode_symbology = options.get('symbology', 'Code128')
            // barcode = self.env['ir.actions.report'].barcode(
            //     barcode_symbology,
            //     value,
            //     **{key: value for key, value in options.items() if key in ['width', 'height', 'humanreadable', 'quiet', 'mask']})
            // 
            // img_element = html.Element('img')
            // for k, v in options.items():
            //     if k.startswith('img_') and k[4:] in safe_attrs:
            //         img_element.set(k[4:], v)
            // if not img_element.get('alt'):
            //     img_element.set('alt', _('Barcode %s', value))
            // img_element.set('src', 'data:image/png;base64,%s' % base64.b64encode(barcode).decode())
            // return Markup(html.tostring(img_element, encoding='unicode'))
            */
            return default;
        }
    }
}