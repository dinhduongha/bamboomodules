using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailAlias")]
    public partial class MailAliasController : AbpController
    {
        private readonly IMailAliasAppService _appService;
        public MailAliasController(IMailAliasAppService appService) { _appService = appService; }
    }
}