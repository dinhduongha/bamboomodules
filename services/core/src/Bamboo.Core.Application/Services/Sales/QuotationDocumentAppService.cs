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
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("SalePdfQuoteBuilder", Depends = new[] { "sale_management" })]
    public class QuotationDocumentAppService : GenericApplicationService<QuotationDocument>, IQuotationDocumentAppService
    {

        public QuotationDocumentAppService(IRepository<QuotationDocument, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<QuotationDocument> CheckPdfValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py) ---
            // def _check_pdf_validity(self):
            // for doc in self:
            //     if doc.datas and not doc.mimetype.endswith('pdf'):
            //         raise ValidationError(_("Only PDF documents can be used as header or footer."))
            //     utils._ensure_document_not_encrypted(base64.b64decode(doc.datas))
            */
            return default;
        }

        protected async Task<QuotationDocument> ComputeFormFieldIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py) ---
            // def _compute_form_field_ids(self):
            // # Empty the linked form fields as we want all and only those from the current datas
            // self.form_field_ids = [Command.clear()]
            // document_to_parse = self.filtered(lambda doc: doc.datas)
            // if document_to_parse:
            //     doc_type = 'quotation_document'
            //     self.env['sale.pdf.form.field']._create_or_update_form_fields_on_pdf_records(
            //         document_to_parse, doc_type
            //     )
            */
            return default;
        }

        public async Task<QuotationDocument> OpenPdfFormFieldsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py) ---
            // def action_open_pdf_form_fields(self):
            // self.ensure_one()
            // return {
            //     'name': _('Form Fields'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.pdf.form.field',
            //     'view_mode': 'list',
            //     'context': {
            //         'default_document_type': 'quotation_document',
            //         'default_product_document_ids': False,
            //         'default_quotation_document_ids': self.id,
            //         'search_default_context_document': True,
            //     },
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}