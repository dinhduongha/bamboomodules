using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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