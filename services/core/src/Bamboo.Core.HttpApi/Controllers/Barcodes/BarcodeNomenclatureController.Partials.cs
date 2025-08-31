using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Barcodes
{
    public partial class BarcodeNomenclatureController
    {
        
        [HttpPost]
        [Route("{id}/gs1-date-to-date")]
        public async Task<IActionResult> Gs1DateToDateAsync(Guid id, [FromBody] BarcodeNomenclatureGs1DateToDateRequestDto input)
        {
            var result = await _appService.Gs1DateToDateAsync(id, input.Gs1Date);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/gs1-decompose-extanded")]
        public async Task<IActionResult> Gs1DecomposeExtandedAsync(Guid id, [FromBody] BarcodeNomenclatureGs1DecomposeExtandedRequestDto input)
        {
            var result = await _appService.Gs1DecomposeExtandedAsync(id, input.Barcode);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/match-pattern")]
        public async Task<IActionResult> MatchPatternAsync(Guid id, [FromBody] BarcodeNomenclatureMatchPatternRequestDto input)
        {
            var result = await _appService.MatchPatternAsync(id, input.Barcode, input.Pattern);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/parse-barcode")]
        public async Task<IActionResult> ParseBarcodeAsync(Guid id, [FromBody] BarcodeNomenclatureParseBarcodeRequestDto input)
        {
            var result = await _appService.ParseBarcodeAsync(id, input.Barcode);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/parse-gs1-rule-pattern")]
        public async Task<IActionResult> ParseGs1RulePatternAsync(Guid id, [FromBody] BarcodeNomenclatureParseGs1RulePatternRequestDto input)
        {
            var result = await _appService.ParseGs1RulePatternAsync(id, input.Match, input.Rule);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/parse-nomenclature-barcode")]
        public async Task<IActionResult> ParseNomenclatureBarcodeAsync(Guid id, [FromBody] BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input)
        {
            var result = await _appService.ParseNomenclatureBarcodeAsync(id, input.Barcode);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/parse-uri")]
        public async Task<IActionResult> ParseUriAsync(Guid id, [FromBody] BarcodeNomenclatureParseUriRequestDto input)
        {
            var result = await _appService.ParseUriAsync(id, input.Barcode);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sanitize-ean")]
        public async Task<IActionResult> SanitizeEanAsync(Guid id, [FromBody] BarcodeNomenclatureSanitizeEanRequestDto input)
        {
            var result = await _appService.SanitizeEanAsync(id, input.Ean);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sanitize-upc")]
        public async Task<IActionResult> SanitizeUpcAsync(Guid id, [FromBody] BarcodeNomenclatureSanitizeUpcRequestDto input)
        {
            var result = await _appService.SanitizeUpcAsync(id, input.Upc);
            return Ok(result);
        }
    }
}