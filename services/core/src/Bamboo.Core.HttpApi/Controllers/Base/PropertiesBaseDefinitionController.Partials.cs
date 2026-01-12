using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PropertiesBaseDefinitionController
    {
        
        [HttpPost]
        [Route("{id}/get-properties-base-definition")]
        public async Task<IActionResult> GetPropertiesBaseDefinitionAsync(Guid id, [FromBody] PropertiesBaseDefinitionGetPropertiesBaseDefinitionRequestDto input)
        {
            var result = await _appService.GetPropertiesBaseDefinitionAsync(id, input);
            return Ok(result);
        }
    }
}