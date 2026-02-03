using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductDocumentAppService : GenericAppService<ProductDocument>, IProductDocumentAppService
    {

        public ProductDocumentAppService(IRepository<ProductDocument, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<ProductDocument> CheckAttachedOnAndDatasCompatibilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: product_document.py) ---
            // def _check_attached_on_and_datas_compatibility(self):
            // for doc in self.filtered(lambda doc: doc.attached_on_sale == 'inside'):
            //     if doc.type != 'binary':
            //         raise ValidationError(_(
            //             "When attached inside a quote, the document must be a file, not a URL."
            //         ))
            //     if doc.datas and not doc.mimetype.endswith('pdf'):
            //         raise ValidationError(_("Only PDF documents can be attached inside a quote."))
            //     if doc.datas:
            //         utils._ensure_document_not_encrypted(base64.b64decode(doc.datas))
            */
            return default;
        }

        protected async Task<ProductDocument> CheckProductIsUnpublishedBeforeRemovingPrintImagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_document.py) ---
            // def _check_product_is_unpublished_before_removing_print_images(self):
            // for print_image in self.filtered(lambda i: i.is_gelato):
            //     template = self.env['product.template'].browse(print_image.res_id)
            //     if template.is_published and not print_image.datas:
            //         raise ValidationError(
            //             _("Products must be unpublished before print images can be removed.")
            //         )
            */
            return default;
        }

        protected async Task<ProductDocument> ComputeFormFieldIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: product_document.py) ---
            // def _compute_form_field_ids(self):
            // # Empty the linked form fields as we want all and only those from the current datas
            // self.form_field_ids = [Command.clear()]
            // document_to_parse = self.filtered(
            //     lambda doc: doc.attached_on_sale == 'inside' and doc.datas and doc.mimetype and doc.mimetype.endswith('pdf')
            // )
            // if document_to_parse:
            //     doc_type = 'product_document'
            //     self.env['sale.pdf.form.field']._create_or_update_form_fields_on_pdf_records(
            //         document_to_parse, doc_type
            //     )
            */
            return default;
        }

        public async Task<ProductDocument> CopyDataAsync(ProductDocumentCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_document.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // ir_default = default
            // if ir_default:
            //     ir_fields = list(self.env['ir.attachment']._fields)
            //     ir_default = {field : default[field] for field in default if field in ir_fields}
            // for document, vals in zip(self, vals_list):
            //     vals['ir_attachment_id'] = document.ir_attachment_id.with_context(
            //         no_document=True,
            //         disable_product_documents_creation=True,
            //     ).copy(ir_default).id
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<ProductDocument> DefaultAttachedOnMrpInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product_document.py) ---
            // def _default_attached_on_mrp(self):
            // return "bom" if self.env.context.get('attached_on_bom') else "hidden"
            */
            return default;
        }

        protected async Task<ProductDocument> GelatoPrepareFilePayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_document.py) ---
            // def _gelato_prepare_file_payload(self):
            // """ Create the payload for a single file of an 'orders' request.
            // 
            // :return: The file payload.
            // :rtype: dict
            // """
            // if not self.datas:
            //     raise UserError(_("Print images must be set on products before they can be ordered."))
            // 
            // query_string = f'access_token={self.ir_attachment_id.generate_access_token()[0]}'
            // url = f'{self.get_base_url()}{self.ir_attachment_id.image_src}?{query_string}'
            // return {
            //     'type': self.name.lower(),  # Gelato requires lowercase types.
            //     'url': url,
            // }
            */
            return default;
        }

        protected async Task<ProductDocument> OnchangeUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_document.py) ---
            // def _onchange_url(self):
            // for attachment in self:
            //     if attachment.type == 'url' and attachment.url and\
            //         not attachment.url.startswith(('https://', 'http://', 'ftp://')):
            //         raise ValidationError(_(
            //             "Please enter a valid URL.\nExample: https://www.odoo.com\n\nInvalid URL: %s",
            //             attachment.url
            //         ))
            */
            return default;
        }

        public async Task<ProductDocument> OpenPdfFormFieldsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: product_document.py) ---
            // def action_open_pdf_form_fields(self):
            // self.ensure_one()
            // return {
            //     'name': _('Form Fields'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.pdf.form.field',
            //     'view_mode': 'list',
            //     'context': {
            //         'default_document_type': 'product_document',
            //         'default_product_document_ids': self.id,
            //         'default_quotation_document_ids': False,
            //         'search_default_context_document': True,
            //     },
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<ProductDocument> UnsupportedProductProductDocumentOnEcommerceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_document.py) ---
            // def _unsupported_product_product_document_on_ecommerce(self):
            // # Not supported for now because product page is dynamic and it would require a lot of work
            // # to update documents shown according to combination. It'll wait for planned tasks
            // # rebuilding the product page & variant mixin.
            // for document in self:
            //     if document.res_model == 'product.product' and document.shown_on_product_page:
            //         raise ValidationError(
            //             _("Documents shown on product page cannot be restricted to a specific variant"))
            */
            return default;
        }
    }
}