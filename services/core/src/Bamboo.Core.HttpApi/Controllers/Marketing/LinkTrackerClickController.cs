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
    [Route("api/v1/marketing/LinkTrackerClick")]
    public partial class LinkTrackerClickController : AbpController
    {
        private readonly ILinkTrackerClickAppService _appService;
        public LinkTrackerClickController(ILinkTrackerClickAppService appService) { _appService = appService; }
    }
}