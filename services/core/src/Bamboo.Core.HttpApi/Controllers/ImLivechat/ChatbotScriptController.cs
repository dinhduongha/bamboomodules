using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpControllerBase
    {
        private readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
    }
}