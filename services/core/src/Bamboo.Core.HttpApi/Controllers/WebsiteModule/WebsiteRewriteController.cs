using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteRewrite")]
    public partial class WebsiteRewriteController : AbpControllerBase
    {
        private readonly IWebsiteRewriteAppService _appService;
        public WebsiteRewriteController(IWebsiteRewriteAppService appService) { _appService = appService; }
    }
}