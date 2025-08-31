using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    public partial class AccountAnalyticDistributionModelController
    {
        
        [HttpPost]
        [Route("{id}/action-read-distribution-model")]
        public async Task<IActionResult> ActionReadDistributionModelAsync(Guid id)
        {
            var result = await _appService.ReadDistributionModelAsync(id);
            return Ok(result);
        }
    }
}