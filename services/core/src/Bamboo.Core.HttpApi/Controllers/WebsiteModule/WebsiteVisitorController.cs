using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteVisitor")]
    public partial class WebsiteVisitorController : AbpControllerBase
    {
        private readonly IWebsiteVisitorAppService _appService;
        public WebsiteVisitorController(IWebsiteVisitorAppService appService) { _appService = appService; }
    }
}