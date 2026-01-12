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
    // Category: Marketing, Module: link_tracker
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/LinkTracker")]
    public partial class LinkTrackerController : AbpController
    {
        private readonly ILinkTrackerAppService _appService;
        public LinkTrackerController(ILinkTrackerAppService appService) { _appService = appService; }
    }
}