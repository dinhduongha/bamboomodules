using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RecurringPaymentLineController
    {
        
        [HttpPost]
        [Route("{id}/action-create-payment")]
        public async Task<IActionResult> ActionCreatePaymentAsync(Guid id)
        {
            var result = await _appService.CreatePaymentAsync(id);
            return Ok(result);
        }
    }
}