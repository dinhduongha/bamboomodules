using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    [Route("api/v1/human-resources/HrExpense")]
    public partial class HrExpenseController : AbpControllerBase
    {
        private readonly IHrExpenseAppService _appService;
        public HrExpenseController(IHrExpenseAppService appService) { _appService = appService; }
    }
}