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
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpController
    {
        private readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
    }
}