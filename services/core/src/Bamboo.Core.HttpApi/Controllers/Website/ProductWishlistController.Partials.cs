using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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