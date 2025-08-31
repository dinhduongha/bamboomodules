using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    public partial class DataRecycleRecordController
    {
        
        [HttpPost]
        [Route("{id}/action-discard")]
        public async Task<IActionResult> ActionDiscardAsync(Guid id)
        {
            var result = await _appService.DiscardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
    }
}