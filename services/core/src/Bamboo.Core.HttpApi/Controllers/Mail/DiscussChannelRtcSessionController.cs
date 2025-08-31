using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/DiscussChannelRtcSession")]
    public partial class DiscussChannelRtcSessionController : AbpControllerBase
    {
        private readonly IDiscussChannelRtcSessionAppService _appService;
        public DiscussChannelRtcSessionController(IDiscussChannelRtcSessionAppService appService) { _appService = appService; }
    }
}