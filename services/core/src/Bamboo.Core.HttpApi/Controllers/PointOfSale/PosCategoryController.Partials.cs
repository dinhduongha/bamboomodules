using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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