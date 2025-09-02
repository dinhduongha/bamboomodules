using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideSlide")]
    public partial class SlideSlideController : AbpControllerBase
    {
        private readonly ISlideSlideAppService _appService;
        public SlideSlideController(ISlideSlideAppService appService) { _appService = appService; }
    }
}