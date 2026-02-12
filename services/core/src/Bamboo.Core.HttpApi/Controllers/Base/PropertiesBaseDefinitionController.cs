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
    [Route("api/v1/base/PropertiesBaseDefinition")]
    public partial class PropertiesBaseDefinitionController : AbpController
    {
        protected readonly IPropertiesBaseDefinitionAppService _appService;
        public PropertiesBaseDefinitionController(IPropertiesBaseDefinitionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-properties-base-definition")]
        public async Task<IActionResult> GetPropertiesBaseDefinitionAsync([FromBody] PropertiesBaseDefinitionGetPropertiesBaseDefinitionRequestDto input)
        {
            var result = await _appService.GetPropertiesBaseDefinitionAsync(input);
            return Ok(result);
        }
    }
    
}