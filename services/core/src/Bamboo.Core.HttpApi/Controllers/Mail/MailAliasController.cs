using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailAlias")]
    public partial class MailAliasController : AbpControllerBase
    {
        private readonly IMailAliasAppService _appService;
        public MailAliasController(IMailAliasAppService appService) { _appService = appService; }
    }
}