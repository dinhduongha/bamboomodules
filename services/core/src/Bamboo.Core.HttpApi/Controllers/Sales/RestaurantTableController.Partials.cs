using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RestaurantTableController
    {
        
        [HttpPost]
        [Route("{id}/are-orders-still-in-draft")]
        public async Task<IActionResult> AreOrdersStillInDraftAsync(Guid id)
        {
            var result = await _appService.AreOrdersStillInDraftAsync(id);
            return Ok(result);
        }
    }
}