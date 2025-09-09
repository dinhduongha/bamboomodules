using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
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