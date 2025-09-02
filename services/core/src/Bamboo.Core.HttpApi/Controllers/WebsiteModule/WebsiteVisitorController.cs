using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteVisitor")]
    public partial class WebsiteVisitorController : AbpControllerBase
    {
        private readonly IWebsiteVisitorAppService _appService;
        public WebsiteVisitorController(IWebsiteVisitorAppService appService) { _appService = appService; }
    }
}