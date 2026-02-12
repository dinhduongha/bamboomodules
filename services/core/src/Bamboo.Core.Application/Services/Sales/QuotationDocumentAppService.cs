using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("SalePdfQuoteBuilder", Category = "Sales", Depends = new[] { "sale_management" })]
    public partial class QuotationDocumentAppService : GenericAppService<QuotationDocument>, IQuotationDocumentAppService
    {

        public QuotationDocumentAppService(IRepository<QuotationDocument, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<QuotationDocument> OpenPdfFormFieldsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py, METHOD: action_open_pdf_form_fields) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}