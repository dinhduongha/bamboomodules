using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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