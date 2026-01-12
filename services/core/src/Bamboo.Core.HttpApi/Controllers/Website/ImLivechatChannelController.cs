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
    // Category: Website/Live Chat, Module: im_livechat
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/website/ImLivechatChannel")]
    public partial class ImLivechatChannelController : AbpController
    {
        private readonly IImLivechatChannelAppService _appService;
        public ImLivechatChannelController(IImLivechatChannelAppService appService) { _appService = appService; }
    }
}