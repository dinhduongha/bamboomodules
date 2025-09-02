using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    [Route("api/v1/MailGroup")]
    public partial class MailGroupController : AbpControllerBase
    {
        private readonly IMailGroupAppService _appService;
        public MailGroupController(IMailGroupAppService appService) { _appService = appService; }
    }
}