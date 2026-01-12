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
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpController
    {
        private readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
    }
}