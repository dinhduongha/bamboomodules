using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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