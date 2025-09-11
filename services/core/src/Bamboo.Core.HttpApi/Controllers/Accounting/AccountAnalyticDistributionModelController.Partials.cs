using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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