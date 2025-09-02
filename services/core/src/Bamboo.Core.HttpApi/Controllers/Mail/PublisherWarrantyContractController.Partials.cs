using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
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