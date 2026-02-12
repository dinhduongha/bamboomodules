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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class ProductDocumentAppService
    {

        protected async Task<ProductDocument> CheckAttachedOnAndDatasCompatibilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: product_document.py, METHOD: _check_attached_on_and_datas_compatibility) ---
            */
            return default;
        }

        protected async Task<ProductDocument> CheckProductIsUnpublishedBeforeRemovingPrintImagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_document.py, METHOD: _check_product_is_unpublished_before_removing_print_images) ---
            */
            return default;
        }

        protected async Task<ProductDocument> ComputeFormFieldIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: product_document.py, METHOD: _compute_form_field_ids) ---
            */
            return default;
        }

        protected async Task<ProductDocument> DefaultAttachedOnMrpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product_document.py, METHOD: _default_attached_on_mrp) ---
            */
            return default;
        }

        protected async Task<ProductDocument> GelatoPrepareFilePayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_document.py, METHOD: _gelato_prepare_file_payload) ---
            */
            return default;
        }

        protected async Task<ProductDocument> OnchangeUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_document.py, METHOD: _onchange_url) ---
            */
            return default;
        }

        protected async Task<ProductDocument> UnsupportedProductProductDocumentOnEcommerceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_document.py, METHOD: _unsupported_product_product_document_on_ecommerce) ---
            */
            return default;
        }
    }
}