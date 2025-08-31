using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.AccountEdi
{
    [Route("api/v1/accounting/AccountEdiDocument")]
    public partial class AccountEdiDocumentController : AbpControllerBase
    {
        private readonly IAccountEdiDocumentAppService _appService;
        public AccountEdiDocumentController(IAccountEdiDocumentAppService appService) { _appService = appService; }
    }
}