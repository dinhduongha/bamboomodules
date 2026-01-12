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
    // Category: Marketing, Module: utm
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/UtmMedium")]
    public partial class UtmMediumController : AbpController
    {
        private readonly IUtmMediumAppService _appService;
        public UtmMediumController(IUtmMediumAppService appService) { _appService = appService; }
    }
}