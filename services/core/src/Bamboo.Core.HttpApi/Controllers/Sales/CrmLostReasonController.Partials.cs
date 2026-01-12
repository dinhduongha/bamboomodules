using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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