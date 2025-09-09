using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsitePage")]
    public partial class WebsitePageController : AbpController
    {
        private readonly IWebsitePageAppService _appService;
        public WebsitePageController(IWebsitePageAppService appService) { _appService = appService; }
    }
}