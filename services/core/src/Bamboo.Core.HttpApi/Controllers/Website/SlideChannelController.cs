using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpController
    {
        private readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
    }
}