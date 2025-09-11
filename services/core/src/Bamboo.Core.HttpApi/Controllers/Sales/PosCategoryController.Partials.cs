using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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