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
        [Route("s-e-l-f-r-e-q-u-i-r-e-d-u-t-m-m-e-d-i-u-m-s-r-e-f")]
        public async Task<IActionResult> SELFREQUIREDUTMMEDIUMSREFAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SELFREQUIREDUTMMEDIUMSREFAsync(ids);
            return Ok(result);
        }
    }
}