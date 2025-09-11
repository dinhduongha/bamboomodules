using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPackageLevelController
    {
        
        [HttpPost]
        [Route("{id}/action-show-package-details")]
        public async Task<IActionResult> ActionShowPackageDetailsAsync(Guid id)
        {
            var result = await _appService.ShowPackageDetailsAsync(id);
            return Ok(result);
        }
    }
}