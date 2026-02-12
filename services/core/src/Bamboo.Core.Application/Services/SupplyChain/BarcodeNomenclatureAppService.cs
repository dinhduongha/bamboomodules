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
    [Module("Barcodes", Category = "SupplyChain", Depends = new[] { "web" })]
    public partial class BarcodeNomenclatureAppService : GenericAppService<BarcodeNomenclature>, IBarcodeNomenclatureAppService
    {

        public BarcodeNomenclatureAppService(IRepository<BarcodeNomenclature, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<BarcodeNomenclature> Gs1DateToDateAsync(BarcodeNomenclatureGs1DateToDateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: gs1_date_to_date) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BarcodeNomenclature> Gs1DecomposeExtendedAsync(BarcodeNomenclatureGs1DecomposeExtendedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: gs1_decompose_extended) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BarcodeNomenclature> MatchPatternAsync(BarcodeNomenclatureMatchPatternRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: match_pattern) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BarcodeNomenclature> ParseBarcodeAsync(BarcodeNomenclatureParseBarcodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: parse_barcode) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BarcodeNomenclature> ParseGs1RulePatternAsync(BarcodeNomenclatureParseGs1RulePatternRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: parse_gs1_rule_pattern) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BarcodeNomenclature> ParseNomenclatureBarcodeAsync(BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: parse_nomenclature_barcode) ---
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py, METHOD: parse_nomenclature_barcode) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<BarcodeNomenclature> ParseUriAsync(BarcodeNomenclatureParseUriRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: parse_uri) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<BarcodeNomenclature> SanitizeEanAsync(BarcodeNomenclatureSanitizeEanRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: sanitize_ean) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<BarcodeNomenclature> SanitizeUpcAsync(BarcodeNomenclatureSanitizeUpcRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py, METHOD: sanitize_upc) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}