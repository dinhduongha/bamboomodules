using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting/Accounting, Module: account_edi
    [Authorize]
    [Route("api/v1/accounting/AccountEdiDocument")]
    public partial class AccountEdiDocumentController : AbpController
    {
        private readonly IAccountEdiDocumentAppService _appService;
        public AccountEdiDocumentController(IAccountEdiDocumentAppService appService) { _appService = appService; }
    }
}