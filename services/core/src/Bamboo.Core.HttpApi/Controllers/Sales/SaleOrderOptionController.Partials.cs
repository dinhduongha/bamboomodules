using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SaleOrderOptionController
    {
        
        [HttpPost]
        [Route("{id}/add-option-to-order")]
        public async Task<IActionResult> AddOptionToOrderAsync(Guid id)
        {
            var result = await _appService.AddOptionToOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-add-to-order")]
        public async Task<IActionResult> ButtonAddToOrderAsync(Guid id)
        {
            var result = await _appService.ButtonAddToOrderAsync(id);
            return Ok(result);
        }
    }
}