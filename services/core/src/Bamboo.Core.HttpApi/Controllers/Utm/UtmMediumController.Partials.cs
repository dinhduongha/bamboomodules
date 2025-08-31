using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Utm
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