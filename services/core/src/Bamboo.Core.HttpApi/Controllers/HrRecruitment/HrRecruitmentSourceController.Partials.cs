using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    public partial class HrRecruitmentSourceController
    {
        
        [HttpPost]
        [Route("{id}/create-alias")]
        public async Task<IActionResult> CreateAliasAsync(Guid id)
        {
            var result = await _appService.CreateAliasAsync(id);
            return Ok(result);
        }
    }
}