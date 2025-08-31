using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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