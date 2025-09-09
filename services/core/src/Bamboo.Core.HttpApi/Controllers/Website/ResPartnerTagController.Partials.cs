using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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