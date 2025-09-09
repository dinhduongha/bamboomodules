using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessageSubtype")]
    public partial class MailMessageSubtypeController : AbpController
    {
        private readonly IMailMessageSubtypeAppService _appService;
        public MailMessageSubtypeController(IMailMessageSubtypeAppService appService) { _appService = appService; }
    }
}