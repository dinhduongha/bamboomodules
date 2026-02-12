using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/website/WebsiteSnippetFilter")]
    public partial class WebsiteSnippetFilterController : AbpController
    {
        protected readonly IWebsiteSnippetFilterAppService _appService;
        public WebsiteSnippetFilterController(IWebsiteSnippetFilterAppService appService) { _appService = appService; }
        
        
    }
    
}