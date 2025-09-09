using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    [Route("api/v1/MailGroup")]
    public partial class MailGroupController : AbpController
    {
        private readonly IMailGroupAppService _appService;
        public MailGroupController(IMailGroupAppService appService) { _appService = appService; }
    }
}