using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    [Route("api/v1/MailGroupMessage")]
    public partial class MailGroupMessageController : AbpControllerBase
    {
        private readonly IMailGroupMessageAppService _appService;
        public MailGroupMessageController(IMailGroupMessageAppService appService) { _appService = appService; }
    }
}