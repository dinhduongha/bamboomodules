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
    // Category: Website/Live Chat, Module: im_livechat
    [Authorize]
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpController
    {
        private readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
    }
}