using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.LinkTrackerModule
{
    [Route("api/v1/marketing/LinkTrackerClick")]
    public partial class LinkTrackerClickController : AbpControllerBase
    {
        private readonly ILinkTrackerClickAppService _appService;
        public LinkTrackerClickController(ILinkTrackerClickAppService appService) { _appService = appService; }
    }
}