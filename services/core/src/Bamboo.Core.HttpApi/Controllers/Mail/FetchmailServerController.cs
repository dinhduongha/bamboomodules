using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/FetchmailServer")]
    public partial class FetchmailServerController : AbpControllerBase
    {
        private readonly IFetchmailServerAppService _appService;
        public FetchmailServerController(IFetchmailServerAppService appService) { _appService = appService; }
    }
}