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
        [Route("{id}/get-address-fields")]
        public async Task<IActionResult> GetAddressFieldsAsync(Guid id)
        {
            var result = await _appService.GetAddressFieldsAsync(id);
            return Ok(result);
        }
    }
}