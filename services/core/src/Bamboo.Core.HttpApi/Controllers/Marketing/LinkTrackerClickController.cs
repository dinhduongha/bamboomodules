using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.LinkTrackerModule
{
    [Route("api/v1/marketing/LinkTrackerClick")]
    public partial class LinkTrackerClickController : AbpController
    {
        private readonly ILinkTrackerClickAppService _appService;
        public LinkTrackerClickController(ILinkTrackerClickAppService appService) { _appService = appService; }
    }
}