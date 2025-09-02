using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ImLivechatChannel")]
    public partial class ImLivechatChannelController : AbpControllerBase
    {
        private readonly IImLivechatChannelAppService _appService;
        public ImLivechatChannelController(IImLivechatChannelAppService appService) { _appService = appService; }
    }
}