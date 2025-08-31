using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteControllerPage")]
    public partial class WebsiteControllerPageController : AbpControllerBase
    {
        private readonly IWebsiteControllerPageAppService _appService;
        public WebsiteControllerPageController(IWebsiteControllerPageAppService appService) { _appService = appService; }
    }
}