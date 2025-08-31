using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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