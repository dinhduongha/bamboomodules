using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmLostReasonController
    {
        
        [HttpPost]
        [Route("{id}/action-lost-leads")]
        public async Task<IActionResult> ActionLostLeadsAsync(Guid id)
        {
            var result = await _appService.LostLeadsAsync(id);
            return Ok(result);
        }
    }
}