using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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