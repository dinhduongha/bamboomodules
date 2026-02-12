using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/BarcodeNomenclature")]
    public partial class BarcodeNomenclatureController : AbpController
    {
        protected readonly IBarcodeNomenclatureAppService _appService;
        public BarcodeNomenclatureController(IBarcodeNomenclatureAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("gs1-date-to-date")]
        public async Task<IActionResult> Gs1DateToDateAsync([FromBody] BarcodeNomenclatureGs1DateToDateRequestDto input)
        {
            var result = await _appService.Gs1DateToDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("gs1-decompose-extended")]
        public async Task<IActionResult> Gs1DecomposeExtendedAsync([FromBody] BarcodeNomenclatureGs1DecomposeExtendedRequestDto input)
        {
            var result = await _appService.Gs1DecomposeExtendedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("match-pattern")]
        public async Task<IActionResult> MatchPatternAsync([FromBody] BarcodeNomenclatureMatchPatternRequestDto input)
        {
            var result = await _appService.MatchPatternAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-barcode")]
        public async Task<IActionResult> ParseBarcodeAsync([FromBody] BarcodeNomenclatureParseBarcodeRequestDto input)
        {
            var result = await _appService.ParseBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-gs1-rule-pattern")]
        public async Task<IActionResult> ParseGs1RulePatternAsync([FromBody] BarcodeNomenclatureParseGs1RulePatternRequestDto input)
        {
            var result = await _appService.ParseGs1RulePatternAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-nomenclature-barcode")]
        public async Task<IActionResult> ParseNomenclatureBarcodeAsync([FromBody] BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input)
        {
            var result = await _appService.ParseNomenclatureBarcodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-uri")]
        public async Task<IActionResult> ParseUriAsync([FromBody] BarcodeNomenclatureParseUriRequestDto input)
        {
            var result = await _appService.ParseUriAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sanitize-ean")]
        public async Task<IActionResult> SanitizeEanAsync([FromBody] BarcodeNomenclatureSanitizeEanRequestDto input)
        {
            var result = await _appService.SanitizeEanAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sanitize-upc")]
        public async Task<IActionResult> SanitizeUpcAsync([FromBody] BarcodeNomenclatureSanitizeUpcRequestDto input)
        {
            var result = await _appService.SanitizeUpcAsync(input);
            return Ok(result);
        }
    }
    
}