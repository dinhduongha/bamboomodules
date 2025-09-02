using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteMenu")]
    public partial class WebsiteMenuController : AbpControllerBase
    {
        private readonly IWebsiteMenuAppService _appService;
        public WebsiteMenuController(IWebsiteMenuAppService appService) { _appService = appService; }
    }
}