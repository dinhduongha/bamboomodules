using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden/Tools, Module: auth_ldap
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/auth-ldap/ResCompanyLdap")]
    public partial class ResCompanyLdapController : AbpController
    {
        private readonly IResCompanyLdapAppService _appService;
        public ResCompanyLdapController(IResCompanyLdapAppService appService) { _appService = appService; }
    }
}