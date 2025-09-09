using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteMenu")]
    public partial class WebsiteMenuController : AbpController
    {
        private readonly IWebsiteMenuAppService _appService;
        public WebsiteMenuController(IWebsiteMenuAppService appService) { _appService = appService; }
    }
}