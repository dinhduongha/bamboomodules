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
    [Route("api/v1/productivity/PublisherWarrantyContract")]
    public partial class PublisherWarrantyContractController : AbpController
    {
        protected readonly IPublisherWarrantyContractAppService _appService;
        public PublisherWarrantyContractController(IPublisherWarrantyContractAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("update-notification")]
        public async Task<IActionResult> UpdateNotificationAsync([FromBody] PublisherWarrantyContractUpdateNotificationRequestDto input)
        {
            var result = await _appService.UpdateNotificationAsync(input);
            return Ok(result);
        }
    }
    
}