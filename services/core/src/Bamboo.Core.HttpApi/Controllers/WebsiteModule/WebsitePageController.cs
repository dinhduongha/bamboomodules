using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsitePage")]
    public partial class WebsitePageController : AbpControllerBase
    {
        private readonly IWebsitePageAppService _appService;
        public WebsitePageController(IWebsitePageAppService appService) { _appService = appService; }
    }
}