using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: web_tour
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/web-tour/WebTourTourStep")]
    public partial class WebTourTourStepController : AbpController
    {
        private readonly IWebTourTourStepAppService _appService;
        public WebTourTourStepController(IWebTourTourStepAppService appService) { _appService = appService; }
    }
}