using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    [Route("api/v1/human-resources/HrExpense")]
    public partial class HrExpenseController : AbpController
    {
        private readonly IHrExpenseAppService _appService;
        public HrExpenseController(IHrExpenseAppService appService) { _appService = appService; }
    }
}