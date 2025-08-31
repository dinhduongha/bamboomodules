using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpControllerBase
    {
        private readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
    }
}