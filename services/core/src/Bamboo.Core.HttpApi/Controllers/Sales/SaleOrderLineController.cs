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
    [Route("api/v1/sales/SaleOrderLine")]
    public partial class SaleOrderLineController : AbpController
    {
        protected readonly ISaleOrderLineAppService _appService;
        public SaleOrderLineController(ISaleOrderLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-uom-qty")]
        public async Task<IActionResult> ComputeUomQtyAsync([FromBody] SaleOrderLineComputeUomQtyRequestDto input)
        {
            var result = await _appService.ComputeUomQtyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SaleOrderLineCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-description-following-lines")]
        public async Task<IActionResult> GetDescriptionFollowingLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDescriptionFollowingLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetParentSectionLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-valued-move-ids")]
        public async Task<IActionResult> HasValuedMoveIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasValuedMoveIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-converted")]
        public async Task<IActionResult> ReadConvertedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReadConvertedAsync(ids);
            return Ok(result);
        }
    }
    
}