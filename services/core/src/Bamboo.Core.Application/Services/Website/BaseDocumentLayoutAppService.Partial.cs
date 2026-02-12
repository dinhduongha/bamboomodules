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
    public partial class BaseDocumentLayoutAppService
    {

        protected async Task<BaseDocumentLayout> CleanAddressFormatInternalAsync(object address_format, object company_data)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _clean_address_format) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeCustomColorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _compute_custom_colors) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeEmptyCompanyDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _compute_empty_company_details) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputeLogoColorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _compute_logo_colors) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> ComputePreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _compute_preview) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseDocumentLayout> DefaultCompanyDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _default_company_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseDocumentLayout> DefaultReportFooterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _default_report_footer) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetAssetStyleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _get_asset_style) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseDocumentLayout> GetCssForPreviewInternalAsync(object scss, Guid new_id)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _get_css_for_preview) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetPreviewTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _get_preview_template) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> GetRenderInformationInternalAsync(object styles)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _get_render_information) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeCustomColorsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _onchange_custom_colors) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeLogoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _onchange_logo) ---
            */
            return default;
        }

        protected async Task<BaseDocumentLayout> OnchangeReportLayoutIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: _onchange_report_layout_id) ---
            */
            return default;
        }
    }
}