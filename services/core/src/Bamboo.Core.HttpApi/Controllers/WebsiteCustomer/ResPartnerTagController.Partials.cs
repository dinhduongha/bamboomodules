using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCustomer
{
    public partial class ResPartnerTagController
    {
        
        [HttpPost]
        [Route("{id}/get-selection-class")]
        public async Task<IActionResult> GetSelectionClassAsync(Guid id)
        {
            var result = await _appService.GetSelectionClassAsync(id);
            return Ok(result);
        }
    }
}