using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Website/eLearning, Module: website_slides
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpController
    {
        private readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
    }
}