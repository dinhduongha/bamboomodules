using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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