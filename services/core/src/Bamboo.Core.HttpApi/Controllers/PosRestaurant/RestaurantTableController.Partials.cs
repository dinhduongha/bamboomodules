using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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