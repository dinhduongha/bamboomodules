using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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