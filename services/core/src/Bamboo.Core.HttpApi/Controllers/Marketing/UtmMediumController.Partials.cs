using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class UtmMediumController
    {
        
        [HttpPost]
        [Route("{id}/s-e-l-f-r-e-q-u-i-r-e-d-u-t-m-m-e-d-i-u-m-s-r-e-f")]
        public async Task<IActionResult> SELFREQUIREDUTMMEDIUMSREFAsync(Guid id)
        {
            var result = await _appService.SELFREQUIREDUTMMEDIUMSREFAsync(id);
            return Ok(result);
        }
    }
}