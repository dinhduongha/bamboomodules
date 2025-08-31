using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountReconcileModelPartnerMapping")]
    public partial class AccountReconcileModelPartnerMappingController : AbpControllerBase
    {
        private readonly IAccountReconcileModelPartnerMappingAppService _appService;
        public AccountReconcileModelPartnerMappingController(IAccountReconcileModelPartnerMappingAppService appService) { _appService = appService; }
    }
}