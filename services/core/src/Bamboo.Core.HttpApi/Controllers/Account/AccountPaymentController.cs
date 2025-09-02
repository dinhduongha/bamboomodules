using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountPayment")]
    public partial class AccountPaymentController : AbpControllerBase
    {
        private readonly IAccountPaymentAppService _appService;
        public AccountPaymentController(IAccountPaymentAppService appService) { _appService = appService; }
    }
}