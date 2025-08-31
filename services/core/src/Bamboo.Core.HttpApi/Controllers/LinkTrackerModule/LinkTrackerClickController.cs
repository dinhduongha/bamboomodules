using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.LinkTrackerModule
{
    [Route("api/v1/marketing/LinkTrackerClick")]
    public partial class LinkTrackerClickController : AbpControllerBase
    {
        private readonly ILinkTrackerClickAppService _appService;
        public LinkTrackerClickController(ILinkTrackerClickAppService appService) { _appService = appService; }
    }
}