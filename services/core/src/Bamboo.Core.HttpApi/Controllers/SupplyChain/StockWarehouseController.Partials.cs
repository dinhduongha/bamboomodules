using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockWarehouseController
    {
        
        [HttpPost]
        [Route("{id}/action-view-all-routes")]
        public async Task<IActionResult> ActionViewAllRoutesAsync(Guid id)
        {
            var result = await _appService.ViewAllRoutesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockWarehouseCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-resupply-routes")]
        public async Task<IActionResult> CreateResupplyRoutesAsync(Guid id, [FromBody] StockWarehouseCreateResupplyRoutesRequestDto input)
        {
            var result = await _appService.CreateResupplyRoutesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-current-warehouses")]
        public async Task<IActionResult> GetCurrentWarehousesAsync(Guid id)
        {
            var result = await _appService.GetCurrentWarehousesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-rules-dict")]
        public async Task<IActionResult> GetRulesDictAsync(Guid id)
        {
            var result = await _appService.GetRulesDictAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-global-route-dropship-subcontractor")]
        public async Task<IActionResult> UpdateGlobalRouteDropshipSubcontractorAsync(Guid id)
        {
            var result = await _appService.UpdateGlobalRouteDropshipSubcontractorAsync(id);
            return Ok(result);
        }
    }
}