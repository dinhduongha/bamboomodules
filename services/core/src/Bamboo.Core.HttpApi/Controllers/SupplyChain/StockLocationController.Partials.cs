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
        [Route("action-view-equipments-records")]
        public async Task<IActionResult> ActionViewEquipmentsRecordsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewEquipmentsRecordsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockLocationCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-subcontract")]
        public async Task<IActionResult> IsSubcontractAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsSubcontractAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("should-bypass-reservation")]
        public async Task<IActionResult> ShouldBypassReservationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShouldBypassReservationAsync(ids);
            return Ok(result);
        }
    }
}