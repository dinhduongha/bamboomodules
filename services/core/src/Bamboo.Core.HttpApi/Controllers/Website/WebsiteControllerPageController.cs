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
    // Category: Website/Website, Module: website
    [Authorize]
    [Route("api/v1/website/WebsiteControllerPage")]
    public partial class WebsiteControllerPageController : AbpController
    {
        private readonly IWebsiteControllerPageAppService _appService;
        public WebsiteControllerPageController(IWebsiteControllerPageAppService appService) { _appService = appService; }
    }
}