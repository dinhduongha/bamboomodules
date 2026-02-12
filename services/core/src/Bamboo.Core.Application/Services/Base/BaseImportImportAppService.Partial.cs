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
    public partial class BaseImportImportAppService
    {

        protected async Task<BaseImportImport> BuildImportErrorMsgInternalAsync(object message, object record, object row_index, object field)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _build_import_error_msg) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> ConvertImportDataInternalAsync(object fields, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _convert_import_data) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> DeduplicateMappingSuggestionsInternalAsync(object mapping_suggestions)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _deduplicate_mapping_suggestions) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ExtractBinaryFilenamesInternalAsync(object import_fields, object data, object model, object prefix, object binary_filenames)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _extract_binary_filenames) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> ExtractHeaderTypesInternalAsync(object preview_values, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _extract_header_types) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> ExtractHeadersTypesInternalAsync(object headers, object preview, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _extract_headers_types) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> FilterFieldsByTypesInternalAsync(object model_fields_tree, object header_types)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _filter_fields_by_types) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> GetDistanceInternalAsync(object a, object b)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _get_distance) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> GetMappingSuggestionInternalAsync(object header, object fields_tree, object header_types, object mapping_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _get_mapping_suggestion) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> GetMappingSuggestionsInternalAsync(object headers, object header_types, object fields_tree)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _get_mapping_suggestions) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> HandleFallbackValuesInternalAsync(object import_field, object input_file_data, object fallback_values)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _handle_fallback_values) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> HandleMultiMappingInternalAsync(object import_fields, object input_file_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _handle_multi_mapping) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ImportFileByUrlInternalAsync(object url, object session, object field, object line_number)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _import_file_by_url) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> InferSeparatorsInternalAsync(object @value, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _infer_separators) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ParseDateFromDataInternalAsync(object data, object index, object name, object field_type, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _parse_date_from_data) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ParseDatetimeDataInternalAsync(object import_fields, object input_file_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _parse_datetime_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> ParseFloatFromDataInternalAsync(object data, object index, object name, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _parse_float_from_data) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ParseImportDataInternalAsync(object data, object import_fields, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _parse_import_data) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ParseImportDataRecursiveInternalAsync(object model, object prefix, object data, object import_fields, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _parse_import_data_recursive) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadCsvInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_csv) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadFileInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_file) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadOdsInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_ods) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadXlsBookInternalAsync(object book, object sheet_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_xls_book) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadXlsInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_xls) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> ReadXlsxInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _read_xlsx) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> RemoveCurrencySymbolInternalAsync(object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _remove_currency_symbol) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BaseImportImport> StringifyDateLikeObjectsInternalAsync(object data, object options, object trim)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _stringify_date_like_objects) ---
            */
            return default;
        }

        protected async Task<BaseImportImport> TryMatchDateTimeInternalAsync(object preview_values, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _try_match_date_time) ---
            */
            return default;
        }
    }
}