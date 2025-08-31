using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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