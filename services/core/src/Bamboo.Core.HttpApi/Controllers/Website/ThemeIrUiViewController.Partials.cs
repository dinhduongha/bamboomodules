using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
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