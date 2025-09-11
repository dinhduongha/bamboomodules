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
    // Category: Productivity/Discuss, Module: mail
    [Authorize]
    [Route("api/v1/productivity/DiscussChannelRtcSession")]
    public partial class DiscussChannelRtcSessionController : AbpController
    {
        private readonly IDiscussChannelRtcSessionAppService _appService;
        public DiscussChannelRtcSessionController(IDiscussChannelRtcSessionAppService appService) { _appService = appService; }
    }
}