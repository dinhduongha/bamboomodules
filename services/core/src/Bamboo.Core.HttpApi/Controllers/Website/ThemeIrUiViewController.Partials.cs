using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ThemeIrUiViewController
    {
        
        [HttpPost]
        [Route("{id}/compute-arch-fs")]
        public async Task<IActionResult> ComputeArchFsAsync(Guid id)
        {
            var result = await _appService.ComputeArchFsAsync(id);
            return Ok(result);
        }
    }
}