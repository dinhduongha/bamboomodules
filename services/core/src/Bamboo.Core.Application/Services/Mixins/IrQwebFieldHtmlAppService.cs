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
    public partial class IrQwebFieldHtmlAppService : ApplicationService, IIrQwebFieldHtmlAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldHtmlAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        [ApiModel]
        public async Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def attributes(self, record, field_name, options, values=None):
            // attrs = super().attributes(record, field_name, options, values)
            // if options.get('inherit_branding'):
            //     field = record._fields[field_name]
            //     if field.sanitize:
            //         if field.sanitize_overridable:
            //             if record.env.user.has_group('base.group_sanitize_override'):
            //                 # Don't mark the field as 'sanitize' if the sanitize
            //                 # is defined as overridable and the user has the right
            //                 # to do so
            //                 return attrs
            //             else:
            //                 try:
            //                     field.convert_to_column_insert(record[field_name], record)
            //                 except UserError:
            //                     # The field contains element(s) that would be
            //                     # removed if sanitized. It means that someone who
            //                     # was part of a group allowing to bypass the
            //                     # sanitation saved that field previously. Mark the
            //                     # field as not editable.
            //                     attrs['data-oe-sanitize-prevent-edition'] = 1
            //                     return attrs
            //         # The field edition is not fully prevented and the sanitation cannot be bypassed
            //         attrs['data-oe-sanitize'] = 'no_block' if field.sanitize_attributes else 1 if field.sanitize_form else 'allow_form'
            // 
            // return attrs
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // content = []
            // if element.text:
            //     content.append(element.text)
            // content.extend(html.tostring(child, encoding='unicode')
            //                for child in element.iterchildren(tag=etree.Element))
            // return '\n'.join(content)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldHtmlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // res = super().value_to_html(value, options)
            // 
            // if res and '<form' in res:  # Efficient check
            //     # The usage of `fromstring`, `HTMLParser`, `tostring` and `Markup`
            //     # is replicating what is done in the `super()` implementation.
            //     body = etree.fromstring("<body>%s</body>" % res, etree.HTMLParser())[0]
            //     add_form_signature(body, self.sudo().env)
            //     res = Markup(etree.tostring(body, encoding='unicode', method='html')[6:-7])
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // irQweb = self.env['ir.qweb']
            // # wrap value inside a body and parse it as HTML
            // body = etree.fromstring("<body>%s</body>" % value, etree.HTMLParser(encoding='utf-8'))[0]
            // # use pos processing for all nodes with attributes
            // for element in body.iter():
            //     if element.attrib:
            //         attrib = dict(element.attrib)
            //         attrib = irQweb._post_processing_att(element.tag, attrib)
            //         element.attrib.clear()
            //         element.attrib.update(attrib)
            // return Markup(etree.tostring(body, encoding='unicode', method='html')[6:-7])
            */
            return default;
        }
    }
}