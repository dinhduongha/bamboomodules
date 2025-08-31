using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteMenu")]
    public partial class WebsiteMenuController : AbpControllerBase
    {
        private readonly IWebsiteMenuAppService _appService;
        public WebsiteMenuController(IWebsiteMenuAppService appService) { _appService = appService; }
    }
}