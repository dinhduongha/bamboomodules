using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpControllerBase
    {
        private readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
    }
}