using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
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