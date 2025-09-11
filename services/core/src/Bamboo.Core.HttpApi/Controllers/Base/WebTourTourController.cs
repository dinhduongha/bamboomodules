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
    [Route("api/v1/web-tour/WebTourTour")]
    public partial class WebTourTourController : AbpController
    {
        private readonly IWebTourTourAppService _appService;
        public WebTourTourController(IWebTourTourAppService appService) { _appService = appService; }
    }
}