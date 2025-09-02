using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ImLivechatChannelRule")]
    public partial class ImLivechatChannelRuleController : AbpControllerBase
    {
        private readonly IImLivechatChannelRuleAppService _appService;
        public ImLivechatChannelRuleController(IImLivechatChannelRuleAppService appService) { _appService = appService; }
    }
}