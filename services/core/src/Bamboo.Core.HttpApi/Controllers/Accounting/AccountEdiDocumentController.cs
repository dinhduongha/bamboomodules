using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AccountEdi
{
    [Route("api/v1/accounting/AccountEdiDocument")]
    public partial class AccountEdiDocumentController : AbpController
    {
        private readonly IAccountEdiDocumentAppService _appService;
        public AccountEdiDocumentController(IAccountEdiDocumentAppService appService) { _appService = appService; }
    }
}