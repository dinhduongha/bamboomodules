using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    public partial class PaymentTokenController
    {
        
        [HttpPost]
        [Route("{id}/get-linked-records-info")]
        public async Task<IActionResult> GetLinkedRecordsInfoAsync(Guid id)
        {
            var result = await _appService.GetLinkedRecordsInfoAsync(id);
            return Ok(result);
        }
    }
}