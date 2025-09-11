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
    // Category: Accounting/Accounting, Module: account
    [Authorize]
    [Route("api/v1/accounting/AccountReconcileModelPartnerMapping")]
    public partial class AccountReconcileModelPartnerMappingController : AbpController
    {
        private readonly IAccountReconcileModelPartnerMappingAppService _appService;
        public AccountReconcileModelPartnerMappingController(IAccountReconcileModelPartnerMappingAppService appService) { _appService = appService; }
    }
}