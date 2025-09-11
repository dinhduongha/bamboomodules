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
    [Route("api/v1/accounting/AccountPayment")]
    public partial class AccountPaymentController : AbpController
    {
        private readonly IAccountPaymentAppService _appService;
        public AccountPaymentController(IAccountPaymentAppService appService) { _appService = appService; }
    }
}