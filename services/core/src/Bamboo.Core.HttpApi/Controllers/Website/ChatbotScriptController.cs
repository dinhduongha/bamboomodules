using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpController
    {
        private readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
    }
}