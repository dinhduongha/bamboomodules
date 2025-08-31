using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    public partial class AccountAssetCategoryController
    {
        
        [HttpPost]
        [Route("{id}/onchange-account-asset")]
        public async Task<IActionResult> OnchangeAccountAssetAsync(Guid id)
        {
            var result = await _appService.OnchangeAccountAssetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-type")]
        public async Task<IActionResult> OnchangeTypeAsync(Guid id)
        {
            var result = await _appService.OnchangeTypeAsync(id);
            return Ok(result);
        }
    }
}