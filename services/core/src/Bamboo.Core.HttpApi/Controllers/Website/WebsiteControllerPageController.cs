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
    // Category: Website/Website, Module: website
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/website/WebsiteControllerPage")]
    public partial class WebsiteControllerPageController : AbpController
    {
        private readonly IWebsiteControllerPageAppService _appService;
        public WebsiteControllerPageController(IWebsiteControllerPageAppService appService) { _appService = appService; }
    }
}