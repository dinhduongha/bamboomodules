using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PublisherWarrantyContractController
    {
        
        [HttpPost]
        [Route("{id}/update-notification")]
        public async Task<IActionResult> UpdateNotificationAsync(Guid id, [FromBody] PublisherWarrantyContractUpdateNotificationRequestDto input)
        {
            var result = await _appService.UpdateNotificationAsync(id, input);
            return Ok(result);
        }
    }
}