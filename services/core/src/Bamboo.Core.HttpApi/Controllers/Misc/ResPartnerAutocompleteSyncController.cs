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
    [Route("api/v1/partner-autocomplete/ResPartnerAutocompleteSync")]
    public partial class ResPartnerAutocompleteSyncController : AbpController
    {
        protected readonly IResPartnerAutocompleteSyncAppService _appService;
        public ResPartnerAutocompleteSyncController(IResPartnerAutocompleteSyncAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("add-to-queue")]
        public async Task<IActionResult> AddToQueueAsync([FromBody] ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            var result = await _appService.AddToQueueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("start-sync")]
        public async Task<IActionResult> StartSyncAsync([FromBody] ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            var result = await _appService.StartSyncAsync(input);
            return Ok(result);
        }
    }
    
}