using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    [Route("api/v1/MailGroupMessage")]
    public partial class MailGroupMessageController : AbpControllerBase
    {
        private readonly IMailGroupMessageAppService _appService;
        public MailGroupMessageController(IMailGroupMessageAppService appService) { _appService = appService; }
    }
}