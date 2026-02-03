using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPackageLevelController
    {
        
        [HttpPost]
        [Route("action-show-package-details")]
        public async Task<IActionResult> ActionShowPackageDetailsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowPackageDetailsAsync(ids);
            return Ok(result);
        }
    }
}