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
    // Category: Marketing, Module: link_tracker
    [Authorize]
    [Route("api/v1/marketing/LinkTracker")]
    public partial class LinkTrackerController : AbpController
    {
        private readonly ILinkTrackerAppService _appService;
        public LinkTrackerController(ILinkTrackerAppService appService) { _appService = appService; }
    }
}