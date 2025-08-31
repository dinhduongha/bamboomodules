using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResCountryController
    {
        
        [HttpPost]
        [Route("{id}/get-address-fields")]
        public async Task<IActionResult> GetAddressFieldsAsync(Guid id)
        {
            var result = await _appService.GetAddressFieldsAsync(id);
            return Ok(result);
        }
    }
}