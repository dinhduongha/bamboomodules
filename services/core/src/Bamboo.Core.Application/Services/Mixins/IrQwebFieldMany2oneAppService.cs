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
    public class IrQwebFieldMany2oneAppService : ApplicationService, IIrQwebFieldMany2oneAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldMany2oneAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldMany2oneable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def attributes(self, record, field_name, options, values):
            // attrs = super(ManyToOne, self).attributes(record, field_name, options, values)
            // if options.get('inherit_branding'):
            //     many2one = record[field_name]
            //     if many2one:
            //         attrs['data-oe-many2one-id'] = many2one.id
            //         attrs['data-oe-many2one-model'] = many2one._name
            //     if options.get('null_text'):
            //         attrs['data-oe-many2one-allowreset'] = 1
            //         if not many2one:
            //             attrs['data-oe-many2one-model'] = record._fields[field_name].comodel_name
            // return attrs
            */
            return default;
        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldMany2oneable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // Model = self.env[element.get('data-oe-model')]
            // id = int(element.get('data-oe-id'))
            // M2O = self.env[field.comodel_name]
            // field_name = element.get('data-oe-field')
            // many2one_id = int(element.get('data-oe-many2one-id'))
            // 
            // allow_reset = element.get('data-oe-many2one-allowreset')
            // if allow_reset and not many2one_id:
            //     # Reset the id of the many2one
            //     Model.browse(id).write({field_name: False})
            //     return None
            // 
            // record = many2one_id and M2O.browse(many2one_id)
            // if record and record.exists():
            //     # save the new id of the many2one
            //     Model.browse(id).write({field_name: many2one_id})
            // 
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldMany2oneable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def get_available_options(self):
            // options = super(Contact, self).get_available_options()
            // contact_fields = [
            //     {'field_name': 'name', 'label': _('Name'), 'default': True},
            //     {'field_name': 'address', 'label': _('Address'), 'default': True},
            //     {'field_name': 'phone', 'label': _('Phone'), 'default': True},
            //     {'field_name': 'mobile', 'label': _('Mobile'), 'default': True},
            //     {'field_name': 'email', 'label': _('Email'), 'default': True},
            //     {'field_name': 'vat', 'label': _('VAT')},
            // ]
            // separator_params = dict(
            //     type='selection',
            //     selection=[[" ", _("Space")], [",", _("Comma")], ["-", _("Dash")], ["|", _("Vertical bar")], ["/", _("Slash")]],
            //     placeholder=_('Linebreak'),
            // )
            // options.update(
            //     fields=dict(type='array', params=dict(type='selection', params=contact_fields), string=_('Displayed fields'), description=_('List of contact fields to display in the widget'), default_value=[param.get('field_name') for param in contact_fields if param.get('default')]),
            //     separator=dict(type='selection', params=separator_params, string=_('Address separator'), description=_('Separator use to split the address from the display_name.'), default_value=False),
            //     no_marker=dict(type='boolean', string=_('Hide badges'), description=_("Don't display the font awesome marker")),
            //     no_tag_br=dict(type='boolean', string=_('Use comma'), description=_("Use comma instead of the <br> tag to display the address")),
            //     phone_icons=dict(type='boolean', string=_('Display phone icons'), description=_("Display the phone icons even if no_marker is True")),
            //     country_image=dict(type='boolean', string=_('Display country image'), description=_("Display the country image if the field is present on the record")),
            // )
            // return options
            */
            return default;
        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMany2oneable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // view = record[field_name]
            // if not view:
            //     return ''
            // 
            // if view._name != "ir.ui.view":
            //     _logger.warning("%s.%s must be a 'ir.ui.view', got %r.", record, field_name, view._name)
            //     return ''
            // 
            // return self.env['ir.qweb']._render(view.id, options.get('values', {}))
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMany2oneable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if not value:
            //     return False
            // value = value.sudo().display_name
            // if not value:
            //     return False
            // return nl2br(value)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if not value:
            //     if options.get('null_text'):
            //         val = {
            //             'options': options,
            //         }
            //         template_options = options.get('template_options', {})
            //         return self.env['ir.qweb']._render('base.no_contact', val, **template_options)
            //     return ''
            // 
            // opf = options.get('fields') or ["name", "address", "phone", "mobile", "email"]
            // sep = options.get('separator')
            // if sep:
            //     opsep = escape(sep)
            // elif options.get('no_tag_br'):
            //     # escaped joiners will auto-escape joined params
            //     opsep = escape(', ')
            // else:
            //     opsep = Markup('<br/>')
            // 
            // value = value.sudo().with_context(show_address=True)
            // display_name = value.display_name or ''
            // # Avoid having something like:
            // # display_name = 'Foo\n  \n' -> This is a res.partner with a name and no address
            // # That would return markup('<br/>') as address. But there is no address set.
            // if any(elem.strip() for elem in display_name.split("\n")[1:]):
            //     address = opsep.join(display_name.split("\n")[1:]).strip()
            // else:
            //     address = ''
            // val = {
            //     'name': display_name.split("\n")[0],
            //     'address': address,
            //     'phone': value.phone,
            //     'mobile': value.mobile,
            //     'city': value.city,
            //     'country_id': value.country_id.display_name,
            //     'website': value.website,
            //     'email': value.email,
            //     'vat': value.vat,
            //     'vat_label': value.country_id.vat_label or _('VAT'),
            //     'fields': opf,
            //     'object': value,
            //     'options': options
            // }
            // return self.env['ir.qweb']._render('base.contact', val, minimal_qcontext=True)
            */
            return default;
        }
    }
}