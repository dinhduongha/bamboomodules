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
    public partial class BarcodeNomenclatureAppService
    {

        protected async Task<BarcodeNomenclature> CheckPatternInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: _check_pattern) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BarcodeNomenclature> ConvertUriGtinDataIntoTrackingNumberInternalAsync(object base_code, object data)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: _convert_uri_gtin_data_into_tracking_number) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BarcodeNomenclature> ConvertUriSsccDataIntoPackageInternalAsync(object base_code, object data)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: _convert_uri_sscc_data_into_package) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BarcodeNomenclature> PreprocessGs1SearchArgsInternalAsync(object domain, object barcode_types, object field)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: _preprocess_gs1_search_args) ---
            */
            return default;
        }

        protected async Task<BarcodeNomenclature> UnlinkExceptDefaultInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: _unlink_except_default) ---
            */
            return default;
        }
    }
}