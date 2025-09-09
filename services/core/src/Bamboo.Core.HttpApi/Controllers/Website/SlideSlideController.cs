using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideSlide")]
    public partial class SlideSlideController : AbpController
    {
        private readonly ISlideSlideAppService _appService;
        public SlideSlideController(ISlideSlideAppService appService) { _appService = appService; }
    }
}