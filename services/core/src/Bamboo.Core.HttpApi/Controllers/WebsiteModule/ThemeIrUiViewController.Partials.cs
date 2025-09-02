using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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