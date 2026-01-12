using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosPresetController
    {
        
        [HttpPost]
        [Route("{id}/action-open-linked-config")]
        public async Task<IActionResult> ActionOpenLinkedConfigAsync(Guid id)
        {
            var result = await _appService.OpenLinkedConfigAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-linked-orders")]
        public async Task<IActionResult> ActionOpenLinkedOrdersAsync(Guid id)
        {
            var result = await _appService.OpenLinkedOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-available-slots")]
        public async Task<IActionResult> GetAvailableSlotsAsync(Guid id)
        {
            var result = await _appService.GetAvailableSlotsAsync(id);
            return Ok(result);
        }
    }
}