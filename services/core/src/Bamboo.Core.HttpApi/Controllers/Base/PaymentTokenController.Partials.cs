using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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