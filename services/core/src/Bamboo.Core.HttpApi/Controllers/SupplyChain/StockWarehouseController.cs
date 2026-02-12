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
    [Route("api/v1/supply-chain/StockWarehouse")]
    public partial class StockWarehouseController : AbpController
    {
        protected readonly IStockWarehouseAppService _appService;
        public StockWarehouseController(IStockWarehouseAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-all-routes")]
        public async Task<IActionResult> ViewAllRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAllRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] StockWarehouseCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-resupply-routes")]
        public async Task<IActionResult> CreateResupplyRoutesAsync([FromBody] StockWarehouseCreateResupplyRoutesRequestDto input)
        {
            var result = await _appService.CreateResupplyRoutesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-warehouses")]
        public async Task<IActionResult> GetCurrentWarehousesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCurrentWarehousesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-rules-dict")]
        public async Task<IActionResult> GetRulesDictAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetRulesDictAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-global-route-dropship-subcontractor")]
        public async Task<IActionResult> UpdateGlobalRouteDropshipSubcontractorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateGlobalRouteDropshipSubcontractorAsync(ids);
            return Ok(result);
        }
    }
    
}