using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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