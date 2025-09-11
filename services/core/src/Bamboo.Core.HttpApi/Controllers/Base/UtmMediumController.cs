using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: utm
    [Authorize]
    [Route("api/v1/utm/UtmMedium")]
    public partial class UtmMediumController : AbpController
    {
        private readonly IUtmMediumAppService _appService;
        public UtmMediumController(IUtmMediumAppService appService) { _appService = appService; }
    }
}