using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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