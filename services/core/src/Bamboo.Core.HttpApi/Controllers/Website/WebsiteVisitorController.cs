using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/WebsiteVisitor")]
    public partial class WebsiteVisitorController : AbpController
    {
        private readonly IWebsiteVisitorAppService _appService;
        public WebsiteVisitorController(IWebsiteVisitorAppService appService) { _appService = appService; }
    }
}