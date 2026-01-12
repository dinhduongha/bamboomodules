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
        [Route("{id}/create-alias")]
        public async Task<IActionResult> CreateAliasAsync(Guid id)
        {
            var result = await _appService.CreateAliasAsync(id);
            return Ok(result);
        }
    }
}