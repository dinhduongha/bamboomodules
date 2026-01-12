using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting/Accounting, Module: account
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountReconcileModelPartnerMapping")]
    public partial class AccountReconcileModelPartnerMappingController : AbpController
    {
        private readonly IAccountReconcileModelPartnerMappingAppService _appService;
        public AccountReconcileModelPartnerMappingController(IAccountReconcileModelPartnerMappingAppService appService) { _appService = appService; }
    }
}