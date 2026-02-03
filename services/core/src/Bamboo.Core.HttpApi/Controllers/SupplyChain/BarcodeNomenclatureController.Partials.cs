using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BarcodeNomenclatureController
    {
        
        [HttpPost]
        [Route("gs1-date-to-date")]
        public async Task<IActionResult> Gs1DateToDateAsync(BarcodeNomenclatureGs1DateToDateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.Gs1DateToDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("gs1-decompose-extended")]
        public async Task<IActionResult> Gs1DecomposeExtendedAsync(BarcodeNomenclatureGs1DecomposeExtendedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.Gs1DecomposeExtendedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("match-pattern")]
        public async Task<IActionResult> MatchPatternAsync(BarcodeNomenclatureMatchPatternRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MatchPatternAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-barcode")]
        public async Task<IActionResult> ParseBarcodeAsync(BarcodeNomenclatureParseBarcodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ParseBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-gs1-rule-pattern")]
        public async Task<IActionResult> ParseGs1RulePatternAsync(BarcodeNomenclatureParseGs1RulePatternRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ParseGs1RulePatternAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-nomenclature-barcode")]
        public async Task<IActionResult> ParseNomenclatureBarcodeAsync(BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ParseNomenclatureBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-uri")]
        public async Task<IActionResult> ParseUriAsync(BarcodeNomenclatureParseUriRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ParseUriAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sanitize-ean")]
        public async Task<IActionResult> SanitizeEanAsync(BarcodeNomenclatureSanitizeEanRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SanitizeEanAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sanitize-upc")]
        public async Task<IActionResult> SanitizeUpcAsync(BarcodeNomenclatureSanitizeUpcRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SanitizeUpcAsync(input);
            return Ok(result);
        }
    }
}