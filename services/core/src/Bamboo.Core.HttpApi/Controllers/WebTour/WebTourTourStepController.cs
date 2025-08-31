using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebTour
{
    [Route("api/v1/web-tour/WebTourTourStep")]
    public partial class WebTourTourStepController : AbpControllerBase
    {
        private readonly IWebTourTourStepAppService _appService;
        public WebTourTourStepController(IWebTourTourStepAppService appService) { _appService = appService; }
    }
}