using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebTour
{
    [Route("api/v1/web-tour/WebTourTour")]
    public partial class WebTourTourController : AbpControllerBase
    {
        private readonly IWebTourTourAppService _appService;
        public WebTourTourController(IWebTourTourAppService appService) { _appService = appService; }
    }
}