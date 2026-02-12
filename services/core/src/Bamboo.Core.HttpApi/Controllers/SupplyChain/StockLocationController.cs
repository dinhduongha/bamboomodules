using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockLocation")]
    public partial class StockLocationController : AbpController
    {
        protected readonly IStockLocationAppService _appService;
        public StockLocationController(IStockLocationAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-equipments-records")]
        public async Task<IActionResult> ViewEquipmentsRecordsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewEquipmentsRecordsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] StockLocationCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-subcontract")]
        public async Task<IActionResult> IsSubcontractAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IsSubcontractAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("should-bypass-reservation")]
        public async Task<IActionResult> ShouldBypassReservationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShouldBypassReservationAsync(ids);
            return Ok(result);
        }
    }
    
}