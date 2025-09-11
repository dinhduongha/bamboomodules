using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: web_tour
    [Authorize]
    [Route("api/v1/web-tour/WebTourTourStep")]
    public partial class WebTourTourStepController : AbpController
    {
        private readonly IWebTourTourStepAppService _appService;
        public WebTourTourStepController(IWebTourTourStepAppService appService) { _appService = appService; }
    }
}