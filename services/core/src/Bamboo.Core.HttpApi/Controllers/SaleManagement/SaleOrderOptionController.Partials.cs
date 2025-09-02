using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SaleManagement
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