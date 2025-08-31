using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/Website")]
    public partial class WebsiteController : AbpControllerBase
    {
        private readonly IWebsiteAppService _appService;
        public WebsiteController(IWebsiteAppService appService) { _appService = appService; }
    }
}