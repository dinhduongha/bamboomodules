using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AccountEdi
{
    [Route("api/v1/accounting/AccountEdiDocument")]
    public partial class AccountEdiDocumentController : AbpControllerBase
    {
        private readonly IAccountEdiDocumentAppService _appService;
        public AccountEdiDocumentController(IAccountEdiDocumentAppService appService) { _appService = appService; }
    }
}