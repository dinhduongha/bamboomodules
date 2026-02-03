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
        [Route("action-view-all-routes")]
        public async Task<IActionResult> ActionViewAllRoutesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewAllRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockWarehouseCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-resupply-routes")]
        public async Task<IActionResult> CreateResupplyRoutesAsync(StockWarehouseCreateResupplyRoutesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateResupplyRoutesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-warehouses")]
        public async Task<IActionResult> GetCurrentWarehousesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCurrentWarehousesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-rules-dict")]
        public async Task<IActionResult> GetRulesDictAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetRulesDictAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-global-route-dropship-subcontractor")]
        public async Task<IActionResult> UpdateGlobalRouteDropshipSubcontractorAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateGlobalRouteDropshipSubcontractorAsync(ids);
            return Ok(result);
        }
    }
}