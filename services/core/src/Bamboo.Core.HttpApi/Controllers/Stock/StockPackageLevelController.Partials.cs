using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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