using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideSlide")]
    public partial class SlideSlideController : AbpControllerBase
    {
        private readonly ISlideSlideAppService _appService;
        public SlideSlideController(ISlideSlideAppService appService) { _appService = appService; }
    }
}