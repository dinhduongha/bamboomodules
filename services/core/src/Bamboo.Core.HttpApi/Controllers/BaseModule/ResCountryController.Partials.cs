using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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