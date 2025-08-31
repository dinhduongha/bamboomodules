using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsitePage")]
    public partial class WebsitePageController : AbpControllerBase
    {
        private readonly IWebsitePageAppService _appService;
        public WebsitePageController(IWebsitePageAppService appService) { _appService = appService; }
    }
}