using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpControllerBase
    {
        private readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
    }
}