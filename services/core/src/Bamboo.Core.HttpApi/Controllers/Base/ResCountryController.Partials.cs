using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResCountryController
    {
        
        [HttpPost]
        [Route("get-address-fields")]
        public async Task<IActionResult> GetAddressFieldsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAddressFieldsAsync(ids);
            return Ok(result);
        }
    }
}