using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    public partial class PosCategoryController
    {
        
        [HttpPost]
        [Route("{id}/get-default-color")]
        public async Task<IActionResult> GetDefaultColorAsync(Guid id)
        {
            var result = await _appService.GetDefaultColorAsync(id);
            return Ok(result);
        }
    }
}