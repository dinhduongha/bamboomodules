using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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