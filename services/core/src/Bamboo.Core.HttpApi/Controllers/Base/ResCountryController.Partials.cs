using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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