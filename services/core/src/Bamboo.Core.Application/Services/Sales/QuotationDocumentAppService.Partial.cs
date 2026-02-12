using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class QuotationDocumentAppService
    {

        protected async Task<QuotationDocument> CheckPdfValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py, METHOD: _check_pdf_validity) ---
            */
            return default;
        }

        protected async Task<QuotationDocument> ComputeFormFieldIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: quotation_document.py, METHOD: _compute_form_field_ids) ---
            */
            return default;
        }
    }
}