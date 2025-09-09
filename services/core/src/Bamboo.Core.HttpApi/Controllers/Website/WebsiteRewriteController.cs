using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteRewrite")]
    public partial class WebsiteRewriteController : AbpController
    {
        private readonly IWebsiteRewriteAppService _appService;
        public WebsiteRewriteController(IWebsiteRewriteAppService appService) { _appService = appService; }
    }
}