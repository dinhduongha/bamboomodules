using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebTour
{
    [Route("api/v1/web-tour/WebTourTourStep")]
    public partial class WebTourTourStepController : AbpControllerBase
    {
        private readonly IWebTourTourStepAppService _appService;
        public WebTourTourStepController(IWebTourTourStepAppService appService) { _appService = appService; }
    }
}