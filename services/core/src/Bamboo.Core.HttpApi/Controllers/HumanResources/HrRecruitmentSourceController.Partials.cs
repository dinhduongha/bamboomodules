using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrRecruitmentSourceController
    {
        
        [HttpPost]
        [Route("create-alias")]
        public async Task<IActionResult> CreateAliasAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateAliasAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-and-get-alias")]
        public async Task<IActionResult> CreateAndGetAliasAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateAndGetAliasAsync(ids);
            return Ok(result);
        }
    }
}