using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteControllerPage")]
    public partial class WebsiteControllerPageController : AbpControllerBase
    {
        private readonly IWebsiteControllerPageAppService _appService;
        public WebsiteControllerPageController(IWebsiteControllerPageAppService appService) { _appService = appService; }
    }
}