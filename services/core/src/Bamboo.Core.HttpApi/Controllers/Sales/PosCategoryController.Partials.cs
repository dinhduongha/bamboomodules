using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosCategoryController
    {
        
        [HttpPost]
        [Route("{id}/get-default-color")]
        public async Task<IActionResult> GetDefaultColorAsync(Guid id)
        {
            var result = await _appService.GetDefaultColorAsync(id);
            return Ok(result);
        }
    }
}