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
    [Route("api/v1/auth-ldap/ResCompanyLdap")]
    public partial class ResCompanyLdapController : AbpController
    {
        protected readonly IResCompanyLdapAppService _appService;
        public ResCompanyLdapController(IResCompanyLdapAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("test-ldap-connection")]
        public async Task<IActionResult> TestLdapConnectionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestLdapConnectionAsync(ids);
            return Ok(result);
        }
    }
    
}