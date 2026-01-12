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