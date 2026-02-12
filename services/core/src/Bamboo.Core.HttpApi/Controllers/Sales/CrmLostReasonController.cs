using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/sales/CrmLostReason")]
    public partial class CrmLostReasonController : AbpController
    {
        protected readonly ICrmLostReasonAppService _appService;
        public CrmLostReasonController(ICrmLostReasonAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-lost-leads")]
        public async Task<IActionResult> LostLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LostLeadsAsync(ids);
            return Ok(result);
        }
    }
    
}