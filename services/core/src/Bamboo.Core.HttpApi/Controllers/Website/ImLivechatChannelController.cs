using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ImLivechatChannel")]
    public partial class ImLivechatChannelController : AbpController
    {
        private readonly IImLivechatChannelAppService _appService;
        public ImLivechatChannelController(IImLivechatChannelAppService appService) { _appService = appService; }
    }
}