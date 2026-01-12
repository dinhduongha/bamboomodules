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
        [Route("{id}/action-show-package-details")]
        public async Task<IActionResult> ActionShowPackageDetailsAsync(Guid id)
        {
            var result = await _appService.ShowPackageDetailsAsync(id);
            return Ok(result);
        }
    }
}