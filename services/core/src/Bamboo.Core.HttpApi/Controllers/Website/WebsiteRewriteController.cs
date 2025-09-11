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
    [Route("api/v1/website/WebsiteRewrite")]
    public partial class WebsiteRewriteController : AbpController
    {
        private readonly IWebsiteRewriteAppService _appService;
        public WebsiteRewriteController(IWebsiteRewriteAppService appService) { _appService = appService; }
    }
}