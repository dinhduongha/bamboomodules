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
    [Route("api/v1/web-tour/WebTourTour")]
    public partial class WebTourTourController : AbpController
    {
        protected readonly IWebTourTourAppService _appService;
        public WebTourTourController(IWebTourTourAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("consume")]
        public async Task<IActionResult> ConsumeAsync([FromBody] WebTourTourConsumeRequestDto input)
        {
            var result = await _appService.ConsumeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("export-js-file")]
        public async Task<IActionResult> ExportJsFileAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExportJsFileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-tour")]
        public async Task<IActionResult> GetCurrentTourAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCurrentTourAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tour-json-by-name")]
        public async Task<IActionResult> GetTourJsonByNameAsync([FromBody] WebTourTourGetTourJsonByNameRequestDto input)
        {
            var result = await _appService.GetTourJsonByNameAsync(input);
            return Ok(result);
        }
    }
    
}