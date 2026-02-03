using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SaleOrderLineController
    {
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-uom-qty")]
        public async Task<IActionResult> ComputeUomQtyAsync(SaleOrderLineComputeUomQtyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeUomQtyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SaleOrderLineCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-description-following-lines")]
        public async Task<IActionResult> GetDescriptionFollowingLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDescriptionFollowingLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetParentSectionLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-valued-move-ids")]
        public async Task<IActionResult> HasValuedMoveIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasValuedMoveIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-converted")]
        public async Task<IActionResult> ReadConvertedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReadConvertedAsync(ids);
            return Ok(result);
        }
    }
}