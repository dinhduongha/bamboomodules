using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebTour
{
    [Route("api/v1/web-tour/WebTourTour")]
    public partial class WebTourTourController : AbpControllerBase
    {
        private readonly IWebTourTourAppService _appService;
        public WebTourTourController(IWebTourTourAppService appService) { _appService = appService; }
    }
}