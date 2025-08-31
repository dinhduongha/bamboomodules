using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSaleWishlist
{
    public partial class ProductWishlistController
    {
        
        [HttpPost]
        [Route("{id}/current")]
        public async Task<IActionResult> CurrentAsync(Guid id)
        {
            var result = await _appService.CurrentAsync(id);
            return Ok(result);
        }
    }
}