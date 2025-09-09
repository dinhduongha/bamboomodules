using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Crm
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