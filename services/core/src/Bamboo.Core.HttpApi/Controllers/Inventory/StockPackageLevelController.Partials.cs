using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Stock
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