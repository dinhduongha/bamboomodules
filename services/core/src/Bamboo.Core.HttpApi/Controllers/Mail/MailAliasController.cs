using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailAlias")]
    public partial class MailAliasController : AbpControllerBase
    {
        private readonly IMailAliasAppService _appService;
        public MailAliasController(IMailAliasAppService appService) { _appService = appService; }
    }
}