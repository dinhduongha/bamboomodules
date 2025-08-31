using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    [Route("api/v1/MailGroup")]
    public partial class MailGroupController : AbpControllerBase
    {
        private readonly IMailGroupAppService _appService;
        public MailGroupController(IMailGroupAppService appService) { _appService = appService; }
    }
}