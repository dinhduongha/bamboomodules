using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountPaymentMethodLine")]
    public partial class AccountPaymentMethodLineController : AbpController
    {
        private readonly IAccountPaymentMethodLineAppService _appService;
        public AccountPaymentMethodLineController(IAccountPaymentMethodLineAppService appService) { _appService = appService; }
    }
}