using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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