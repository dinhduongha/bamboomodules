using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockLocationController
    {
        
        [HttpPost]
        [Route("{id}/action-view-equipments-records")]
        public async Task<IActionResult> ActionViewEquipmentsRecordsAsync(Guid id)
        {
            var result = await _appService.ViewEquipmentsRecordsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockLocationCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-subcontract")]
        public async Task<IActionResult> IsSubcontractAsync(Guid id)
        {
            var result = await _appService.IsSubcontractAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/should-bypass-reservation")]
        public async Task<IActionResult> ShouldBypassReservationAsync(Guid id)
        {
            var result = await _appService.ShouldBypassReservationAsync(id);
            return Ok(result);
        }
    }
}