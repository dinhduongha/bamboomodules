using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAssetCategoryController
    {
        
        [HttpPost]
        [Route("onchange-account-asset")]
        public async Task<IActionResult> OnchangeAccountAssetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeAccountAssetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-type")]
        public async Task<IActionResult> OnchangeTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeTypeAsync(ids);
            return Ok(result);
        }
    }
}