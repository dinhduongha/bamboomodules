using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrFiltersController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrFiltersCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-filter")]
        public async Task<IActionResult> CreateFilterAsync(Guid id, [FromBody] IrFiltersCreateFilterRequestDto input)
        {
            var result = await _appService.CreateFilterAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-filters")]
        public async Task<IActionResult> GetFiltersAsync(Guid id, [FromBody] IrFiltersGetFiltersRequestDto input)
        {
            var result = await _appService.GetFiltersAsync(id, input);
            return Ok(result);
        }
    }
}