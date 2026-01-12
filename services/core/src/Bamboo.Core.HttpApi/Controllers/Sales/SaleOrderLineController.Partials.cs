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
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-uom-qty")]
        public async Task<IActionResult> ComputeUomQtyAsync(Guid id, [FromBody] SaleOrderLineComputeUomQtyRequestDto input)
        {
            var result = await _appService.ComputeUomQtyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SaleOrderLineCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-description-following-lines")]
        public async Task<IActionResult> GetDescriptionFollowingLinesAsync(Guid id)
        {
            var result = await _appService.GetDescriptionFollowingLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync(Guid id)
        {
            var result = await _appService.GetParentSectionLineAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-valued-move-ids")]
        public async Task<IActionResult> HasValuedMoveIdsAsync(Guid id)
        {
            var result = await _appService.HasValuedMoveIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/read-converted")]
        public async Task<IActionResult> ReadConvertedAsync(Guid id)
        {
            var result = await _appService.ReadConvertedAsync(id);
            return Ok(result);
        }
    }
}