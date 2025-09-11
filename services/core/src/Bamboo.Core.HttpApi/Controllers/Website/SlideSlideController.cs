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
    // Category: Website/eLearning, Module: website_slides
    [Authorize]
    [Route("api/v1/website/SlideSlide")]
    public partial class SlideSlideController : AbpController
    {
        private readonly ISlideSlideAppService _appService;
        public SlideSlideController(ISlideSlideAppService appService) { _appService = appService; }
    }
}